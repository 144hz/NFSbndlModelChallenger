using System;
using System.Collections.Generic;
using System.IO;

namespace NFSbndlModelChallenger {
    class BNDLHelper {

        private static readonly byte link_offset = 0x38;
        private static readonly Dictionary<uint, string> datType2id = new() {
            { 1, "Texture" },
            { 2, "Material" },
            { 5, "Model" },
            { 21, "Script-" },
            { 81, "LODGroup" },
            { 96, "UnusedColsn" },
            { 128, "RPMSound" },
            { 129, "EffectSound" },
            { 176, "SkeletonDefm" },
            { 178, "Skeleton" },
            { 179, "Animation" },
            { 262, "Synthesis" },
            { 1281, "SpoilerAnim" }
        };
        private static readonly Dictionary<string, (int syn_id, int syn_offset)> para2syn = new() {
            { "wheel", (2, 0x20) },
            { "driver", (1, 0x50) },
            { "hitbox", (2, 0x0) }
        };
        private static readonly Dictionary<string, int[]> para2idOffset = new() {
            { "wheel", new[] { 0x50, 0x60, 0x70, 0x80 } }
        };
        private static readonly Dictionary<string, int[][]> para2dataPos = new() {
            { "wheel", new[] { new[]{ 0xCC, 0xD0, 0xF4, 0xF8 }, 
                new[] { 0x38 }, new[] { 0x38 }, new[] { 0x38 }, new[] { 0x38 } } },
            { "driver", new[] { new[] { 0x10, 0x14, 0x18, 0x30, 0x34, 0x38 } } },
            { "hitbox", new[] { new[] { 0x50, 0x54, 0x58, 0x110, 0x114, 0x118 } } }
        };

        public static void Get_model_output_path(string veh_path, out string tex_path, out string mtl_path, out string mesh_path, out string ref_path) {
            string root_path = veh_path + @"raw\1_block\";

            datType2id.TryGetValue(1, out string type);
            tex_path = root_path + "1_" + type + '\\';

            datType2id.TryGetValue(2, out type);
            mtl_path = root_path + "2_" + type + '\\';

            datType2id.TryGetValue(5, out type);
            mesh_path = root_path + "5_" + type + '\\';

            datType2id.TryGetValue(7, out type);
            ref_path = root_path + "7_" + type + '\\';
        }

        public static uint Get_mesh_id(string veh_path, uint car_id, bool fixLOD) {
            string root_path = veh_path + @"raw\1_block\";

            datType2id.TryGetValue(262, out string type);
            string syn_path = root_path + "262_" + type + '\\';

            datType2id.TryGetValue(81, out type);
            string lod_path = root_path + "81_" + type + '\\';

            byte[] syn_a = File.ReadAllBytes(syn_path + car_id + "_a.dat");
            byte[] syn_b = File.ReadAllBytes(syn_path + car_id + "_b.dat");
            uint lod_id = BitConverter.ToUInt32(syn_b, BitConverter.ToInt32(syn_a, link_offset) + 0x20);

            byte[] lod_a = File.ReadAllBytes(lod_path + lod_id + "_a.dat");
            byte[] lod_b = File.ReadAllBytes(lod_path + lod_id + "_b.dat");
            int mesh_id_pos = BitConverter.ToInt32(lod_a, link_offset);
            uint mesh_id = BitConverter.ToUInt32(lod_b, mesh_id_pos);

            if (fixLOD) {
                byte count = lod_a[0x40];
                byte[] mesh_id_b = BitConverter.GetBytes(mesh_id);
                for (int i = 1; i < count - 2; i++) {
                    mesh_id_b.CopyTo(lod_b, mesh_id_pos + 0x10 * i);
                }
                File.WriteAllBytes(lod_path + lod_id + "_b.dat", lod_b);
            }

            return mesh_id;
        }

        public static string Get_script_path(string veh_path) {
            string root_path, script_path;
            for (int i = 2; i <= 6; i++) {
                root_path = veh_path + "raw\\"+ i +"_block\\";
                datType2id.TryGetValue(21, out string base_syn);
                script_path = root_path + "21_" + base_syn + '\\';
                if (File.Exists(script_path + "1_a.dat"))
                    return script_path;
            }
            return "";
        }

        public static List<string> Get_para_path(string type, string script_path) {

            List<string> para_path = new();
            para2syn.TryGetValue(type, out var syn_inf);
            if(syn_inf.syn_offset == 0) {
                para_path.Add(script_path + syn_inf.syn_id + "_b.dat");
                return para_path;
            }

            byte[] syn4_a = File.ReadAllBytes(script_path + syn_inf.syn_id + "_a.dat");
            byte[] syn4_b = File.ReadAllBytes(script_path + syn_inf.syn_id + "_b.dat");
            int para_id_pos = BitConverter.ToInt32(syn4_a, link_offset) + syn_inf.syn_offset;
            uint para_id = BitConverter.ToUInt32(syn4_b, para_id_pos);
            para_path.Add(script_path + para_id + "_b.dat");

            para2idOffset.TryGetValue(type, out int[] offset);
            if (offset == null) return para_path;

            byte[] para_base_a = File.ReadAllBytes(script_path + para_id + "_a.dat");
            byte[] para_base_b = File.ReadAllBytes(script_path + para_id + "_b.dat");
            int para_link_pos = BitConverter.ToInt32(para_base_a, link_offset);
            foreach (int id_offset in offset) {
                uint para_link_id = BitConverter.ToUInt32(para_base_b, para_link_pos + id_offset);
                para_path.Add(script_path + para_link_id + "_b.dat");
            }
            return para_path;
        }

        public static float[] Get_para_float_value(string type, List<string> path) {
            para2dataPos.TryGetValue(type, out int[][] datapos);
            List<float> values = new();

            for (int i=0;i< datapos.Length; i++) {
                byte[] parafile = File.ReadAllBytes(path[i]);
                for (int j=0;j< datapos[i].Length; j++) {
                    values.Add(BitConverter.ToSingle(parafile, datapos[i][j]));
                }
            }
            return values.ToArray();
        }

        public static void Set_para_float_value(string type, List<string> path, float[] values) {
            para2dataPos.TryGetValue(type, out int[][] datapos);
            int value_index = 0;

            for (int i = 0; i < datapos.Length; i++) {
                byte[] parafile = File.ReadAllBytes(path[i]);
                for (int j = 0; j < datapos[i].Length; j++) {
                    BitConverter.GetBytes(values[value_index]).CopyTo(parafile, datapos[i][j]);
                    value_index++;
                }
                File.WriteAllBytes(path[i], parafile);
            }
        }
    }
}
