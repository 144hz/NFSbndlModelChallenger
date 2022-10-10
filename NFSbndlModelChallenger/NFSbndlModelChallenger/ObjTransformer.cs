using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NFSbndlModelChallenger {
    class ObjTransformer {

        public enum MeshType { metal, glass, carbon, light, interior, tmask };
        public struct MeshBlock {

            public MeshType meshType;
            public string blockName;
            public uint color;
            public List<double[]> ver_list, vn_list, vt_list;
            public List<int[]> face_list;

            public MeshBlock(MeshType type) {
                meshType = type;
                blockName = "";
                color = 0;
                ver_list = new();
                vn_list = new();
                vt_list = new();
                face_list = new();
            }
        };

        private List<MeshBlock> meshBlocks;
        MeshType default_type = MeshType.metal;

        private uint mesh_id, base_mtl_id, base_tex_id;

        private string tex_path, mtl_path, mesh_path, ref_path;
        private string input_obj_path;


        public void ObjTransform(uint car_id, string input_vehicle_path, string input_obj_file) {

            base_mtl_id = 0x80000000 + car_id * 0x100;
            base_tex_id = 0x80000000 + car_id * 0x100 + 0x40;
            input_obj_path = Path.GetDirectoryName(input_obj_file) + '\\';

            if (!input_vehicle_path.EndsWith("\\")) input_vehicle_path += '\\';
            BNDLHelper.Get_model_output_path(input_vehicle_path, out tex_path, out mtl_path, out mesh_path, out ref_path);
            mesh_id = BNDLHelper.Get_mesh_id(input_vehicle_path, car_id, true);

            meshBlocks = LoadObj(input_obj_file);
            if (meshBlocks.Count > 0x40) {
                NBMC.OutputLog("OBJ too many object blocks! OBJ物体数量太多，最大数量<64");
                meshBlocks.RemoveRange(0x40, meshBlocks.Count - 0x40);
            }
            CreateMesh();
            CreateMaterial();
            CreateRef();

        }

        private void CreateMaterial() {
            for (int block_n = 0; block_n < meshBlocks.Count; block_n++) {
                uint mtl_id = (uint)(base_mtl_id + block_n);
                uint tex_id = (uint)(base_tex_id + block_n);

                MtltexHelper.Get_material_header(meshBlocks[block_n].meshType, mtl_id, tex_id, 
                    out byte[] mtl_a, out byte[] mtl_b);
                if (meshBlocks[block_n].meshType == MeshType.light && meshBlocks[block_n].color != 0) {
                    MtltexHelper.Set_light_color(meshBlocks[block_n].color, ref mtl_b);
                }
                WriteMtlDat(mtl_id, mtl_a, mtl_b);

                if (MtltexHelper.generate_texture.Contains(meshBlocks[block_n].meshType)) {
                    MtltexHelper.Get_texture_header(tex_id, out byte[] tex_a, out byte[] tex_b);
                    string dds_path = input_obj_path + meshBlocks[block_n].blockName + ".dds";
                    byte[] file_dds;
                    if (File.Exists(dds_path)) {
                        file_dds = File.ReadAllBytes(dds_path);
                    }
                    else {
                        if(meshBlocks[block_n].meshType != MeshType.carbon)
                            NBMC.OutputLog(meshBlocks[block_n].blockName + ".dds" + " 不存在 not found");
                        file_dds = MtltexHelper.Get_default_texture(meshBlocks[block_n].meshType);
                    }
                    WriteTexDat(tex_id, tex_a, tex_b, file_dds);
                }
            }
        }

        private void WriteMtlDat(uint mtl_id, byte[] mtl_a, byte[] mtl_b) {
            File.WriteAllBytes(mtl_path + mtl_id + "_a.dat", mtl_a);
            File.WriteAllBytes(mtl_path + mtl_id + "_b.dat", mtl_b);
        }

        private void WriteTexDat(uint tex_id, byte[] tex_a, byte[] tex_b, byte[] file_dds) {

            int dds_size = file_dds.Length - 128;
            byte[] tex_c = new byte[dds_size];
            Array.Copy(file_dds, 128, tex_c, 0, dds_size);

            byte DXTn = file_dds[0x57];
            ushort resoX = BitConverter.ToUInt16(file_dds, 12);
            ushort resoY = BitConverter.ToUInt16(file_dds, 16);
            if (resoX > 0x800 || resoY > 0x800) 
                NBMC.OutputLog("建议最大贴图分辨率 maximum recommended texture resolution 2048x2048");

            byte log2(ushort input) {
                byte output = 0;
                while (input != 0) {
                    input >>= 1;
                    output++;
                }
                return output;
            }

            tex_b[0x1C] = DXTn == 0x31 ? (byte)0x47 : (byte)0x4D;
            tex_b[0x2D] = log2(resoX);
            BitConverter.GetBytes(resoX).CopyTo(tex_b, 0x26);
            BitConverter.GetBytes(resoY).CopyTo(tex_b, 0x24);

            File.WriteAllBytes(tex_path + tex_id + "_a.dat", tex_a);
            File.WriteAllBytes(tex_path + tex_id + "_b.dat", tex_b);
            File.WriteAllBytes(tex_path + tex_id + "_c.dat", tex_c);
        }

        private void CreateMesh() {
            MeshHelper.Get_mesh_header(mesh_id, out byte[] mesh_a, out byte[] mesh_b, meshBlocks.Count);
            WriteMeshDat(mesh_id, mesh_a, mesh_b);
        }

        private void WriteMeshDat(uint mesh_id, byte[] mesh_a, byte[] mesh_b) {

            MemoryStream ms1 = new MemoryStream(mesh_b);
            List<byte> mesh_c = new();

            ms1.Position = 0x12;
            ms1.WriteByte((byte)meshBlocks.Count);

            int old_vertex_count = 0;

            for (int block_n = 0; block_n < meshBlocks.Count; block_n++) {

                List<byte> re_meshf = MeshHelper.Generate_face(meshBlocks[block_n].face_list, old_vertex_count);
                List<byte> re_meshp = MeshHelper.Generate_model(meshBlocks[block_n]);

                int cur_pos = BitConverter.ToInt32(mesh_b, 0x20 + 4 * block_n);
                int data1_start = mesh_c.Count;
                int data1_size = re_meshf.Count;
                int data2_start = data1_start + data1_size;
                int data2_size = re_meshp.Count;
                //surface_count
                ms1.Position = cur_pos + 0x1c;
                ms1.Write(BitConverter.GetBytes(re_meshf.Count / 2), 0, 4);
                ms1.Position = cur_pos + 0x3c;
                ms1.Write(BitConverter.GetBytes(data1_start), 0, 4);
                ms1.Write(BitConverter.GetBytes(data1_size), 0, 4);
                ms1.Position = cur_pos + 0x54;
                ms1.Write(BitConverter.GetBytes(data2_start), 0, 4);
                ms1.Write(BitConverter.GetBytes(data2_size), 0, 4);
                //material id
                int mtl_pos = BitConverter.ToInt32(mesh_a, 0x38) + block_n * 0x10;
                ms1.Position = mtl_pos;
                ms1.Write(BitConverter.GetBytes((uint)(base_mtl_id + block_n)), 0, 4);

                mesh_c.AddRange(re_meshf);
                mesh_c.AddRange(re_meshp);

                old_vertex_count += meshBlocks[block_n].ver_list.Count;
            }
            ms1.Dispose();

            File.WriteAllBytes(mesh_path + mesh_id + "_a.dat", mesh_a);
            File.WriteAllBytes(mesh_path + mesh_id + "_b.dat", mesh_b);
            File.WriteAllBytes(mesh_path + mesh_id + "_c.dat", mesh_c.ToArray());
        }

        private void CreateRef() {
            if(Directory.Exists(mesh_path) && Directory.Exists(tex_path)) 
                WriteRefDat();
        }

        private void WriteRefDat() {
            Dictionary<string, byte[]> dic = MtltexHelper.Get_ref_flie();
            foreach(var dic_pair in dic) {
                File.WriteAllBytes(ref_path + dic_pair.Key, dic_pair.Value);
            }
        }

        private List<MeshBlock> LoadObj(string input_obj_file) {
            string[] obj = File.ReadAllText(input_obj_file).Split(
                new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            void checkPixel(ref List<double[]> ver_list, ref List<double[]> vn_list, ref List<double[]> vt_list) {
                if (vn_list.Count < ver_list.Count) {
                    NBMC.OutputLog("OBJ vn count not match! OBJ模型法线向量数量错误");
                    for (int i = vn_list.Count; i < ver_list.Count; i++) {
                        vn_list.Add(new double[] { 0, 0, 0 });
                    }
                }
                if (vt_list.Count < ver_list.Count) {
                    NBMC.OutputLog("OBJ vt count not match! OBJ模型uv座标数量错误");
                    for (int i = vt_list.Count; i < ver_list.Count; i++) {
                        vt_list.Add(new double[] { 0, 0 });
                    }
                }
            }

            List<MeshBlock> meshBlocks = new();
            MeshBlock meshBlock = new(default_type);

            for (int i = 0; i < obj.Length; i++) {
                if (obj[i].StartsWith("o ")) { 
                    if(meshBlock.face_list.Count > 0) {
                        checkPixel(ref meshBlock.ver_list, ref meshBlock.vn_list, ref meshBlock.vt_list);
                        if(meshBlock.ver_list.Count > 0xFFF0) NBMC.OutputLog("OBJ too many vertexes! OBJ模型顶点太多");
                        if(meshBlock.face_list.Count > 0xFFF0) NBMC.OutputLog("OBJ toooo many faces! OBJ模型面数太多");
                        meshBlocks.Add(meshBlock);
                    }
                    string[] str_obj = obj[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    meshBlock = new(default_type);
                    if (str_obj.Length > 1) {
                        string[] object_name = str_obj[1].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        if (Enum.TryParse(object_name[0].ToLower(), out MeshType block_type) &&
                            Enum.IsDefined(typeof(MeshType), block_type)) {
                            meshBlock.meshType = block_type;
                        }
                        else {
                            NBMC.OutputLog("未知材质！ material unknown!");
                        }
                        if (object_name.Length > 1) {
                            meshBlock.blockName = object_name[0] + "_" +object_name[1];
                            if (meshBlock.meshType == MeshType.glass || meshBlock.meshType == MeshType.light) {
                                try {
                                    meshBlock.color = Convert.ToUInt32(object_name[1], 16);
                                }
                                catch (Exception) {
                                    NBMC.OutputLog(meshBlock.blockName + " Error hexadecimal color 无法转换16进制ARGB颜色");
                                }
                            }
                        }
                    }
                }
                else if (obj[i].StartsWith("v ")) {
                    string[] ver = obj[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    double[] ver3 = new double[3];
                    for (int j = 0; j < 3; j++) {
                        ver3[j] = Convert.ToDouble(ver[j + 1]);
                    }
                    meshBlock.ver_list.Add(ver3);
                }
                else if (obj[i].StartsWith("vn ")) {
                    string[] vn = obj[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    double[] vn3 = new double[3];
                    for (int j = 0; j < 3; j++) {
                        vn3[j] = Convert.ToDouble(vn[j + 1]);
                    }
                    meshBlock.vn_list.Add(vn3);
                }
                else if (obj[i].StartsWith("vt ")) {
                    string[] vt = obj[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    double[] vt2 = new double[2];
                    for (int j = 0; j < 2; j++) {
                        vt2[j] = Convert.ToDouble(vt[j + 1]);
                    }
                    meshBlock.vt_list.Add(vt2);
                }
                else if (obj[i].StartsWith("f ")) {
                    string[] fac = obj[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] fac_n = new int[fac.Length - 1];
                    for (int j = 0; j < fac_n.Length; j++) {
                        string[] pixel_str = fac[j + 1].Split('/');
                        if(pixel_str[0] != pixel_str[1] || pixel_str[1] != pixel_str[2]) {
                            NBMC.OutputLog("顶点/uv/法向不一致，请使用blender NBMC脚本导出模型 " +
                                "v/vn/vt are inconsistent, use NBMC script for blender to export");
                        }
                        fac_n[j] = Convert.ToInt32(pixel_str[0]);
                    }
                    meshBlock.face_list.Add(fac_n);
                }
            }
            meshBlocks.Add(meshBlock);
            return meshBlocks;
        }

    }
}
