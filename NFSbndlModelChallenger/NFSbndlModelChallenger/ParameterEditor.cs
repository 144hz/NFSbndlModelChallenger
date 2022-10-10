using System;
using System.Collections.Generic;
using System.IO;

namespace NFSbndlModelChallenger {
    class ParameterEditor {

        public readonly string script_path;

        public ParameterEditor(string path) {
            if (!path.EndsWith("\\")) path += "\\";
            script_path = BNDLHelper.Get_script_path(path);
        }

        private List<string> wheel_path;
        public float[] Wheel_position {
            get {
                if (wheel_path == null) wheel_path = BNDLHelper.Get_para_path("wheel", script_path);
                float[] wheel_raw = BNDLHelper.Get_para_float_value("wheel", wheel_path);

                float[] wheel_xyz = { wheel_raw[4], wheel_raw[1], wheel_raw[0],
                    wheel_raw[6], wheel_raw[3], wheel_raw[2]};
                return wheel_xyz;
            }
            set {
                if (wheel_path.Count == 0) wheel_path = BNDLHelper.Get_para_path("wheel", script_path);
                float[] wheel_base = { value[2], value[1], value[5], value[4],
                    value[0], -value[0], value[3], -value[3] };

                BNDLHelper.Set_para_float_value("wheel", wheel_path, wheel_base);
            }
        }

        private List<string> driver_path;
        public float[] Driver_position {
            get {
                if (driver_path == null) driver_path = BNDLHelper.Get_para_path("driver", script_path);
                float[] driver_raw = BNDLHelper.Get_para_float_value("driver", driver_path);

                float[] driver_xyz = {driver_raw[0], driver_raw[2], driver_raw[1], 
                    driver_raw[3], driver_raw[5], driver_raw[4]};
                return driver_xyz;
            }
            set {
                if (driver_path == null) driver_path = BNDLHelper.Get_para_path("driver", script_path);
                float[] driver_base = {value[0], value[2], value[1],
                    value[3], value[5], value[4]};
                
                BNDLHelper.Set_para_float_value("driver", driver_path, driver_base);
            }
        }

        private List<string> hixbox_path;
        public float[] Hitbox_size {
            get {
                if (hixbox_path == null) hixbox_path = BNDLHelper.Get_para_path("hitbox", script_path);
                float[] hitbox_raw = BNDLHelper.Get_para_float_value("hitbox", hixbox_path);

                float[] hitbox_xyz = { hitbox_raw[3], hitbox_raw[5], hitbox_raw[4] };
                return hitbox_xyz;
            }
            set {
                if (hixbox_path == null) hixbox_path = BNDLHelper.Get_para_path("hitbox", script_path);
                float[] hitbox_base = {value[0], value[2], value[1],
                    value[0], value[2], value[1]};

                BNDLHelper.Set_para_float_value("hitbox", hixbox_path, hitbox_base);
            }
        }
    }
}
