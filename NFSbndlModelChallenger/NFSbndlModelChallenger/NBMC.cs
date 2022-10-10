using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NFSbndlModelChallenger {
    public partial class NBMC : Form {
        public NBMC() {
            InitializeComponent();
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            Icon = Properties.Resources._1icon;
            texBox_output.BackColor = System.Drawing.Color.FromArgb(10, 0, 0, 0);
        }

        private static string outputLog = "";
        public static void OutputLog(string log) {
            if(!outputLog.Contains(log))
                outputLog += log + "\r\n";
        }

        private void button_transform_Click(object sender, EventArgs e) {

            string input_vehicle = textBox_veh.Text;
            string input_obj = textBox_obj.Text;
            string vehicle_folder_name = new DirectoryInfo(input_vehicle).Name;
            uint car_id = 0;


            if (!vehicle_folder_name.StartsWith("VEH_")) {
                MessageBox.Show("无法识别VEH文件夹 Unrecognized vehicle folder");
                return;
            }
            try {
                car_id = Convert.ToUInt32(vehicle_folder_name.Split('_')[1]);
            }
            catch (Exception) {
                MessageBox.Show("无法识别车辆id Unrecognized vehicle id");
                return;
            }
            if (!File.Exists(input_obj)) {
                MessageBox.Show("未找到OBJ文件 OBJ file not found");
                return;
            }

            texBox_output.Text = "Running...\r\n";
            outputLog = "";

            ObjTransformer objTransformer = new();
            objTransformer.ObjTransform(car_id, input_vehicle, input_obj);

            texBox_output.Text = (outputLog == "") ? "All done!" : 
                "转换结果 Transform log: \r\n" + outputLog;
            MessageBox.Show("转换完成！ Transform complete!");
        }

        private void load_obj_Click(object sender, EventArgs e) {
            select_obj.FileName = "OBJ model";
            select_obj.Filter = "OBJ文件|*.obj";
            if (select_obj.ShowDialog() == DialogResult.OK) {
                textBox_obj.Text = select_obj.FileName;
            }
        }

        private void load_veh_Click(object sender, EventArgs e) {
            select_veh.FileName = "VEH folder";
            select_veh.Filter = "文件夹|Folder.";
            if (select_veh.ShowDialog() == DialogResult.OK) {
                textBox_veh.Text = Path.GetDirectoryName(select_veh.FileName) + '\\';
            }
        }

        private void button_readme_Click(object sender, EventArgs e) {
            if (MessageBox.Show(Properties.Resources._1readme, "README", MessageBoxButtons.OKCancel) ==
                DialogResult.OK) {
                Clipboard.SetDataObject(@"https://github.com/144hz/NFSbndlModelChallenger");
            }
        }

        private void button_adjust_Click(object sender, EventArgs e) {
            if (!textBox_veh.Text.Contains("VEH_")) {
                MessageBox.Show("无法识别VEH文件夹 Unrecognized vehicle folder");
                return;
            }
            new NBPA(textBox_veh.Text).ShowDialog();
        }
    }
}
