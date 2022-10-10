using System;
using System.Collections.Generic;

namespace NFSbndlModelChallenger {
    class MeshHelper {

        public static List<byte> Generate_face(List<int[]> face_list, int old_vertex_count) {
            List<byte> re_meshf = new();
            foreach (var face in face_list) {
                ushort[] fi_id = new ushort[face.Length + 1];
                fi_id[fi_id.Length - 1] = 0xFFFF;
                fi_id[0] = (ushort)(face[0] - old_vertex_count - 1);
                for (int j = 1; j <= face.Length / 2; j++) {
                    fi_id[2 * j - 1] = (ushort)(face[j] - old_vertex_count - 1);
                    if (j == face.Length - j) break;
                    fi_id[2 * j] = (ushort)(face[face.Length - j] - old_vertex_count - 1);
                }
                foreach (var fi1 in fi_id) {
                    re_meshf.AddRange(BitConverter.GetBytes(fi1));
                }
            }
            re_meshf.AddRange(new byte[16 - re_meshf.Count % 16]);
            return re_meshf;
        }

        public static List<byte> Generate_model(ObjTransformer.MeshBlock meshBlock) {
            return meshBlock.meshType switch {
                ObjTransformer.MeshType.metal => Metal_model(meshBlock.ver_list, meshBlock.vn_list, meshBlock.vt_list),
                ObjTransformer.MeshType.glass => Glass_model(meshBlock.ver_list, meshBlock.vn_list, meshBlock.color),
                ObjTransformer.MeshType.carbon => Carbon_model(meshBlock.ver_list, meshBlock.vn_list, meshBlock.vt_list),
                ObjTransformer.MeshType.light => Light_model(meshBlock.ver_list, meshBlock.vn_list, meshBlock.vt_list),
                ObjTransformer.MeshType.tmask => Tmask_model(meshBlock.ver_list, meshBlock.vn_list, meshBlock.vt_list),
                ObjTransformer.MeshType.interior => Interior_model(meshBlock.ver_list, meshBlock.vn_list, meshBlock.vt_list),
                _ => new List<byte>(),
            };
        }

        private static List<byte> Metal_model(List<double[]> ver_list, List<double[]> vn_list, List<double[]> vt_list) {
            List<byte> re_meshp = new();
            for (int i = 0; i < ver_list.Count; i++) {
                byte[] pixel = new byte[0x2c];
                //generate one pixel
                Get_vertex_byte8(ver_list[i]).CopyTo(pixel, 0x0);
                Get_damage_unk_byte8().CopyTo(pixel, 0x8);
                Get_bright_byte4(0xC0).CopyTo(pixel, 0x10);
                Get_uv_byte4(vt_list[i]).CopyTo(pixel, 0x14);
                Get_uv_unk_byte8().CopyTo(pixel, 0x18);
                Get_3C_unk_byte4().CopyTo(pixel, 0x20);
                Get_normal_short4_byte8(vn_list[i]).CopyTo(pixel, 0x24);
                //total 0x2c
                re_meshp.AddRange(pixel);
            }
            re_meshp.AddRange(new byte[16 - re_meshp.Count % 16]);
            return re_meshp;
        }

        private static List<byte> Glass_model(List<double[]> ver_list, List<double[]> vn_list, uint color) {
            List<byte> re_meshp = new();
            for (int i = 0; i < ver_list.Count; i++) {
                byte[] pixel = new byte[0x34];
                Get_vertex_byte8(ver_list[i]).CopyTo(pixel, 0x0);
                Get_normal_float3_byte12(vn_list[i]).CopyTo(pixel, 0x8);
                Get_normal_unk_float3_byte12().CopyTo(pixel, 0x14);
                Get_damage_unk_byte8().CopyTo(pixel, 0x20);
                Get_color_ABGR_byte4(color).CopyTo(pixel, 0x28);
                Get_damage_unk_byte8().CopyTo(pixel, 0x2c);
                //total 0x34
                re_meshp.AddRange(pixel);
            }
            re_meshp.AddRange(new byte[16 - re_meshp.Count % 16]);
            return re_meshp;
        }

        private static List<byte> Light_model(List<double[]> ver_list, List<double[]> vn_list, List<double[]> vt_list) {
            List<byte> re_meshp = new();
            for (int i = 0; i < ver_list.Count; i++) {
                byte[] pixel = new byte[0x20];
                Get_vertex_byte8(ver_list[i]).CopyTo(pixel, 0x0);
                Get_damage_unk_byte8().CopyTo(pixel, 0x8);
                Get_bright_byte4(0xC0).CopyTo(pixel, 0x10);
                Get_uv_byte4(vt_list[i]).CopyTo(pixel, 0x14);
                Get_normal_short4_byte8(vn_list[i]).CopyTo(pixel, 0x18);
                //total 0x20
                re_meshp.AddRange(pixel);
            }
            re_meshp.AddRange(new byte[16 - re_meshp.Count % 16]);
            return re_meshp;
        }

        private static List<byte> Carbon_model(List<double[]> ver_list, List<double[]> vn_list, List<double[]> vt_list) {
            List<byte> re_meshp = new();
            for (int i = 0; i < ver_list.Count; i++) {
                byte[] pixel = new byte[0x28];
                Get_vertex_byte8(ver_list[i]).CopyTo(pixel, 0x0);
                Get_damage_unk_byte8().CopyTo(pixel, 0x8);
                Get_bright_byte4(0x60).CopyTo(pixel, 0x10);
                Get_uv_byte4(vt_list[i]).CopyTo(pixel, 0x14);
                Get_uv_unk_byte4().CopyTo(pixel, 0x18);
                Get_3C_unk_byte4().CopyTo(pixel, 0x1C);
                Get_normal_short4_byte8(vn_list[i]).CopyTo(pixel, 0x20);
                //total 0x28
                re_meshp.AddRange(pixel);
            }
            re_meshp.AddRange(new byte[16 - re_meshp.Count % 16]);
            return re_meshp;
        }

        private static List<byte> Tmask_model(List<double[]> ver_list, List<double[]> vn_list, List<double[]> vt_list) {
            List<byte> re_meshp = new();
            for (int i = 0; i < ver_list.Count; i++) {
                byte[] pixel = new byte[0x38];
                Get_vertex_byte8(ver_list[i]).CopyTo(pixel, 0x0);
                Get_normal_float3_byte12(vn_list[i]).CopyTo(pixel, 0x8);
                Get_normal_unk_float3_byte12().CopyTo(pixel, 0x14);
                Get_damage_unk_byte8().CopyTo(pixel, 0x20);
                Get_color_ABGR_byte4(0x00404040).CopyTo(pixel, 0x28);
                Get_uv_byte4(vt_list[i]).CopyTo(pixel, 0x2c);
                Get_uv_unk_byte8().CopyTo(pixel, 0x30);
                //total 0x38
                re_meshp.AddRange(pixel);
            }
            re_meshp.AddRange(new byte[16 - re_meshp.Count % 16]);
            return re_meshp;
        }

        private static List<byte> Interior_model(List<double[]> ver_list, List<double[]> vn_list, List<double[]> vt_list) {
            List<byte> re_meshp = new();
            for (int i = 0; i < ver_list.Count; i++) {
                byte[] pixel = new byte[0x24];
                Get_vertex_byte8(ver_list[i]).CopyTo(pixel, 0x0);
                Get_damage_unk_byte8().CopyTo(pixel, 0x8);
                Get_bright_byte4(0x40).CopyTo(pixel, 0x10);
                Get_uv_byte4(vt_list[i]).CopyTo(pixel, 0x14);
                Get_3C_unk_byte4().CopyTo(pixel, 0x18);
                Get_normal_short4_byte8(vn_list[i]).CopyTo(pixel, 0x1C);
                //total 0x24
                re_meshp.AddRange(pixel);
            }
            re_meshp.AddRange(new byte[16 - re_meshp.Count % 16]);
            return re_meshp;
        }

        public static void Get_mesh_header(uint mesh_id, out byte[] mesh_a, out byte[] mesh_b, int block_num) {
            mesh_a = Resource1.mesh_a;
            BitConverter.GetBytes(mesh_id).CopyTo(mesh_a, 0);
            mesh_a[0x40] = (byte)block_num;

            byte[] mesh_b_header = new byte[0x20 + 0x10 * ((block_num - 1) / 4 + 1)];
            byte[] mesh_b_data = new byte[0x60 * block_num];
            byte[] mesh_b_link = new byte[0x10 * block_num];
            mesh_b = new byte[mesh_b_header.Length + mesh_b_data.Length + mesh_b_link.Length];

            Array.Copy(Resource1.mesh_b, mesh_b_header, 0x20);
            for (int i=0; i< block_num; i++) {
                Array.Copy(Resource1.mesh_b, 0x30, mesh_b_data, i * 0x60, 0x60);
                Array.Copy(Resource1.mesh_b, 0x90, mesh_b_link, i * 0x10, 0x10);
                BitConverter.GetBytes(mesh_b_header.Length + i * 0x60).CopyTo(mesh_b_header, 0x20 + i * 4);
                BitConverter.GetBytes(mesh_b_header.Length + i * 0x60 + 0x30).CopyTo(mesh_b_data, i * 0x60 + 0x28);
                BitConverter.GetBytes(mesh_b_header.Length + i * 0x60 + 0x48).CopyTo(mesh_b_data, i * 0x60 + 0x2C);
                BitConverter.GetBytes(mesh_b_header.Length + i * 0x60 + 0x20).CopyTo(mesh_b_link, i * 0x10 + 8);
            }

            BitConverter.GetBytes(mesh_b_header.Length + mesh_b_data.Length).CopyTo(mesh_a, 0x38);
            mesh_b[0x12] = (byte)block_num;

            mesh_b_header.CopyTo(mesh_b, 0);
            mesh_b_data.CopyTo(mesh_b, mesh_b_header.Length);
            mesh_b_link.CopyTo(mesh_b, mesh_b_header.Length + mesh_b_data.Length);
        }

        private static byte[] Get_vertex_byte8(double[] vertex_d) {
            double VET_CORD_RATE = 10;

            short[] vertex = new short[4];
            vertex[3] = 0x7FFF;
            for (int i = 0; i < 3; i++) {
                // [1] height
                double ver_t = vertex_d[i] / VET_CORD_RATE;
                if (ver_t > 1 || ver_t < -1) {
                    ver_t = 0;
                    NBMC.OutputLog("Object too large, try scaling down! 顶点座标过大，需要缩小模型");
                }
                vertex[i] = Convert.ToInt16(ver_t * 0x7FFF);
            }

            byte[] vertex_byte = new byte[8];
            for (int i = 0; i < 4; i++) {
                BitConverter.GetBytes(vertex[i]).CopyTo(vertex_byte, 2 * i);
            }
            return vertex_byte;
        }

        private static byte[] Get_damage_unk_byte8() {
            return new byte[8];
        }

        private static byte[] Get_bright_byte4(byte bright) {
            uint bright_color = (uint)(0xFF000000 + bright * 0x10000 + bright * 0x100 + bright);
            return BitConverter.GetBytes(bright_color);
        }

        private static byte[] Get_uv_byte4(double[] uv_d) {
            float[] vert_uv = new float[2];
            vert_uv[0] = (float)Convert.ToDouble(uv_d[0]);
            vert_uv[1] = (float)Convert.ToDouble(uv_d[1]);
            vert_uv[1] = vert_uv[1] >= 0 ? 1 - vert_uv[1] : -vert_uv[1];

            byte[] uv_byte = new byte[4];
            for(int i = 0; i < 2; i++) {
                byte[] FP32 = BitConverter.GetBytes(vert_uv[i]);
                uv_byte[2 * i + 1] = (byte)((FP32[3] & 0xC0) + ((FP32[3] & 0x7) << 3) + (FP32[2] >> 5));
                uv_byte[2 * i] = (byte)((FP32[2] << 3) + (FP32[1] >> 5));
            }
            return uv_byte;
        }

        private static byte[] Get_uv_unk_byte4() {
            return new byte[4];
        }

        private static byte[] Get_uv_unk_byte8() {
            return new byte[8];
        }

        private static byte[] Get_3C_unk_byte4() {
            return BitConverter.GetBytes(0x3C000000);
        }

        private static byte[] Get_normal_short4_byte8(double[] normal_d) {

            double ab_to_tanhalf_ab(double a, double b) {
                double cot_a_b = b / a;
                double cot_a_b_2 = cot_a_b * cot_a_b;
                double csc_a_b = a > 0 ? Math.Sqrt(1 + cot_a_b_2) : -Math.Sqrt(1 + cot_a_b_2);
                return 1 / (cot_a_b + csc_a_b);
            }
            double[] nor4 = new double[4];
            nor4[2] = 1;
            nor4[3] = 0;

            //nfs format
            if (normal_d[0] == 0 && normal_d[1] == 0) {
                if (normal_d[2] < 0) {
                    nor4[0] = 1;
                    nor4[1] = nor4[2] = 0;
                }
                else {
                    nor4[0] = nor4[1] = 0;
                }
            }
            else if (normal_d[0] == 0) {
                double tanhalf_z_y = ab_to_tanhalf_ab(normal_d[1], normal_d[2]);
                nor4[1] = tanhalf_z_y * nor4[2];
                nor4[0] = 0;
            }
            else if (normal_d[1] == 0) {
                double tanhalf_x_y = ab_to_tanhalf_ab(normal_d[0], normal_d[2]);
                nor4[0] = tanhalf_x_y * nor4[2];
                nor4[1] = 0;
            }
            else {
                double xz_length = Math.Sqrt(normal_d[0] * normal_d[0] + normal_d[1] * normal_d[1]);
                double tanhalf_xz_y = ab_to_tanhalf_ab(xz_length, normal_d[2]);
                nor4[0] = (tanhalf_xz_y / xz_length) * normal_d[0] * nor4[2];
                nor4[1] = (tanhalf_xz_y / xz_length) * normal_d[1] * nor4[2];
            }

            //normalize
            double length = 0;
            for (int j = 0; j < 3; j++) {
                length += Math.Pow(nor4[j], 2);
            }
            length = Math.Sqrt(length);
            for (int j = 0; j < 3; j++) {
                nor4[j] = nor4[j] / length;
            }

            byte[] nor4_byte = new byte[8];
            for (int i = 0; i < 4; i++) {
                short value = (nor4[i] == 1) ? (short)0x7FFF : (short)(nor4[i] * 0x8000);
                BitConverter.GetBytes(value).CopyTo(nor4_byte, 2 * i);
            }

            return nor4_byte;
        }

        private static byte[] Get_normal_float3_byte12(double[] normal_d) {
            byte[] normal3 = new byte[12];
            for(int i = 0; i < 3; i++) {
                BitConverter.GetBytes((float)normal_d[i]).CopyTo(normal3, 4 * i);
            }
            return normal3;
        }

        private static byte[] Get_normal_unk_float3_byte12() {
            byte[] normal3 = new byte[12];
            normal3[6] = 0x80;
            normal3[7] = 0x3F;
            return normal3;
        }

        private static byte[] Get_color_ABGR_byte4(uint color) {
            byte[] ARGB = BitConverter.GetBytes(color);
            byte[] ABGR = new byte[4];
            ABGR[0] = ARGB[2];
            ABGR[1] = ARGB[1];
            ABGR[2] = ARGB[0];
            ABGR[3] = ARGB[3];
            return ABGR;
        }
    }
}
