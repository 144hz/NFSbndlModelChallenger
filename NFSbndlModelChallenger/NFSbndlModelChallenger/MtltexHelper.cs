using System;
using System.Collections.Generic;

namespace NFSbndlModelChallenger {
    class MtltexHelper {

        public static readonly ObjTransformer.MeshType[] generate_texture = {
            ObjTransformer.MeshType.carbon, ObjTransformer.MeshType.interior,
            ObjTransformer.MeshType.light, ObjTransformer.MeshType.metal,
            ObjTransformer.MeshType.tmask
        };

        private static readonly Dictionary<ObjTransformer.MeshType, List<byte[]>> methType2id = new() {
            { ObjTransformer.MeshType.metal, new List<byte[]> { Resource1.mtl_metal_a, Resource1.mtl_metal_b } },
            { ObjTransformer.MeshType.glass, new List<byte[]> { Resource1.mtl_glass_a, Resource1.mtl_glass_b } },
            { ObjTransformer.MeshType.carbon, new List<byte[]> { Resource1.mtl_carbon_a, Resource1.mtl_carbon_b } },
            { ObjTransformer.MeshType.light, new List<byte[]> { Resource1.mtl_light_a, Resource1.mtl_light_b } },
            { ObjTransformer.MeshType.tmask, new List<byte[]> { Resource1.mtl_tmask_a, Resource1.mtl_tmask_b } },
            { ObjTransformer.MeshType.interior, new List<byte[]> { Resource1.mtl_interior_a, Resource1.mtl_interior_b } }
        };
        private static readonly Dictionary<ObjTransformer.MeshType, List<uint>> methType2pos = new() {
            { ObjTransformer.MeshType.metal, new List<uint> { 0x60 } },
            { ObjTransformer.MeshType.glass, new List<uint> {  } },
            { ObjTransformer.MeshType.carbon, new List<uint> { 0xb0, 0xd0 } },
            { ObjTransformer.MeshType.light, new List<uint> { 0x110, 0x120, 0x130 } },
            { ObjTransformer.MeshType.tmask, new List<uint> { 0x180 } },
            { ObjTransformer.MeshType.interior, new List<uint> { 0xd0, 0xe0, 0xf0 } }
        };
        private static readonly uint[] ref_file_id = { 174749567, 724597386, 772636000, 798052309, 1842883188, 2592913033 };

        public static void Get_material_header(ObjTransformer.MeshType meshType, uint mtl_id, uint tex_id, out byte[] mtl_a, out byte[] mtl_b) {
            List<byte[]> mtl_list = methType2id[meshType];
            mtl_a = mtl_list[0];
            mtl_b = mtl_list[1];
            byte[] mtl_id_b = BitConverter.GetBytes(mtl_id);
            byte[] tex_id_b = BitConverter.GetBytes(tex_id);
            mtl_id_b.CopyTo(mtl_a, 0);
            mtl_id_b.CopyTo(mtl_b, 0);
            foreach(uint pos in methType2pos[meshType]) {
                tex_id_b.CopyTo(mtl_b, pos);
            }
        }

        public static void Get_texture_header(uint tex_id, out byte[] tex_a, out byte[] tex_b) {
            tex_a = Resource1.texture_a;
            tex_b = Resource1.texture_b;
            byte[] tex_id_b = BitConverter.GetBytes(tex_id);
            tex_id_b.CopyTo(tex_a, 0);
        }

        public static byte[] Get_default_texture(ObjTransformer.MeshType meshType) {
            return meshType switch {
                ObjTransformer.MeshType.carbon => Resource1.tex_carbon,
                ObjTransformer.MeshType.light => Resource1.tex_light,
                _ => Resource1.tex_tranblack,
            };
        }

        public static Dictionary<string, byte[]> Get_ref_flie() {
            Dictionary<string, byte[]> dic = new();
            foreach(var id in ref_file_id) {
                dic.Add(id + "_a.dat", (byte[])Resource2.ResourceManager.GetObject("ref_" + id + "_a"));
                dic.Add(id + "_b.dat", (byte[])Resource2.ResourceManager.GetObject("ref_" + id + "_b"));
            }
            return dic;
        }

        public static void Set_light_color(uint color, ref byte[] mtl_b) {
            byte[] color_byte = BitConverter.GetBytes(color);
            for (int i = 0; i < 3; i++) {
                float color_channel = (float)color_byte[2 - i] / 0xFF;
                color_channel = (float)Math.Pow(100, color_channel) * 0.001f - 0.001f;
                BitConverter.GetBytes(color_channel).CopyTo(mtl_b, 0x80 + 4 * i);
            }
        }

    }
}
