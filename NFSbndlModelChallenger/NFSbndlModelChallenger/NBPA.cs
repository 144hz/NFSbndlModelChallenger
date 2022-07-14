using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NFSbndlModelChallenger {
    public partial class NBPA : Form {

        private readonly ParameterEditor pe;
        private readonly List<TextBox[]> textBox_list = new();

        public NBPA(string path) {
            InitializeComponent();
            Icon = Properties.Resources._1icon;
            TextBox[] textBox_wheel = new TextBox[] { textBox_wheel1, textBox_wheel2, textBox_wheel3,
                            textBox_wheel4, textBox_wheel5, textBox_wheel6 };
            TextBox[] textBox_driver = new TextBox[] { textBox_driver1, textBox_driver2, textBox_driver3,
                            textBox_hand1, textBox_hand2, textBox_hand3 };
            textBox_list.Add(textBox_wheel);
            textBox_list.Add(textBox_driver);

            if (path.Contains("VEH_")) {
                if (!path.EndsWith("\\")) path += "\\";
                textBox_veh.Text = path;
                pe = new ParameterEditor(path);
            }
        }

        private void button_load_Click(object sender, EventArgs e) {
            int index = tabControl1.SelectedIndex;
            float[] pos = index switch {
                0 => pe.Wheel_position,
                1 => pe.Driver_position,
                2 => pe.Hitbox_size,
                _ => null,
            };
            for (int i = 0; i < textBox_list[index].Length; i++) {
                textBox_list[index][i].Text = string.Format("{0:N3}", pos[i]);
            }
        }

        private void button_set_Click(object sender, EventArgs e) {
            int index = tabControl1.SelectedIndex;
            float[] float_xyz = new float[textBox_list[index].Length];
            for (int i = 0; i < float_xyz.Length; i++) {
                float_xyz[i] = Convert.ToSingle(textBox_list[index][i].Text);
            }
            switch (index) {
                case 0:
                    pe.Wheel_position = float_xyz;
                    break;
                case 1:
                    pe.Driver_position = float_xyz;
                    break;
                case 2:
                    pe.Hitbox_size = float_xyz;
                    break;
            }
            MessageBox.Show("写入成功 success");
        }
    }
}
