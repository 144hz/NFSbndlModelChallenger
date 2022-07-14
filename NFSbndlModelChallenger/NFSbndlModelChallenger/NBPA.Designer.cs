
namespace NFSbndlModelChallenger {
    partial class NBPA {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox_veh = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_wheel = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_wheel4 = new System.Windows.Forms.TextBox();
            this.textBox_wheel5 = new System.Windows.Forms.TextBox();
            this.textBox_wheel6 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_wheel1 = new System.Windows.Forms.TextBox();
            this.textBox_wheel2 = new System.Windows.Forms.TextBox();
            this.textBox_wheel3 = new System.Windows.Forms.TextBox();
            this.tabPage_driver = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_hand1 = new System.Windows.Forms.TextBox();
            this.textBox_hand2 = new System.Windows.Forms.TextBox();
            this.textBox_hand3 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_driver1 = new System.Windows.Forms.TextBox();
            this.textBox_driver2 = new System.Windows.Forms.TextBox();
            this.textBox_driver3 = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.button_set = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_wheel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage_driver.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_veh
            // 
            this.textBox_veh.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox_veh.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_veh.Location = new System.Drawing.Point(0, 0);
            this.textBox_veh.Name = "textBox_veh";
            this.textBox_veh.ReadOnly = true;
            this.textBox_veh.Size = new System.Drawing.Size(782, 25);
            this.textBox_veh.TabIndex = 8;
            this.textBox_veh.Text = "vehicle folder path";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_wheel);
            this.tabControl1.Controls.Add(this.tabPage_driver);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 422);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage_wheel
            // 
            this.tabPage_wheel.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_wheel.Controls.Add(this.flowLayoutPanel2);
            this.tabPage_wheel.Controls.Add(this.flowLayoutPanel1);
            this.tabPage_wheel.Location = new System.Drawing.Point(4, 25);
            this.tabPage_wheel.Name = "tabPage_wheel";
            this.tabPage_wheel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_wheel.Size = new System.Drawing.Size(774, 393);
            this.tabPage_wheel.TabIndex = 0;
            this.tabPage_wheel.Text = "车轮位置 Wheels";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.textBox_wheel4);
            this.flowLayoutPanel2.Controls.Add(this.textBox_wheel5);
            this.flowLayoutPanel2.Controls.Add(this.textBox_wheel6);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(80, 120);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(600, 50);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 7, 20, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "后轮 rear (xyz) ";
            // 
            // textBox_wheel4
            // 
            this.textBox_wheel4.Location = new System.Drawing.Point(193, 13);
            this.textBox_wheel4.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_wheel4.Name = "textBox_wheel4";
            this.textBox_wheel4.Size = new System.Drawing.Size(100, 25);
            this.textBox_wheel4.TabIndex = 1;
            // 
            // textBox_wheel5
            // 
            this.textBox_wheel5.Location = new System.Drawing.Point(313, 13);
            this.textBox_wheel5.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_wheel5.Name = "textBox_wheel5";
            this.textBox_wheel5.Size = new System.Drawing.Size(100, 25);
            this.textBox_wheel5.TabIndex = 2;
            // 
            // textBox_wheel6
            // 
            this.textBox_wheel6.Location = new System.Drawing.Point(433, 13);
            this.textBox_wheel6.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_wheel6.Name = "textBox_wheel6";
            this.textBox_wheel6.Size = new System.Drawing.Size(100, 25);
            this.textBox_wheel6.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBox_wheel1);
            this.flowLayoutPanel1.Controls.Add(this.textBox_wheel2);
            this.flowLayoutPanel1.Controls.Add(this.textBox_wheel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(80, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 50);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 7, 20, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "前轮 front (xyz)";
            // 
            // textBox_wheel1
            // 
            this.textBox_wheel1.Location = new System.Drawing.Point(193, 13);
            this.textBox_wheel1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_wheel1.Name = "textBox_wheel1";
            this.textBox_wheel1.Size = new System.Drawing.Size(100, 25);
            this.textBox_wheel1.TabIndex = 1;
            // 
            // textBox_wheel2
            // 
            this.textBox_wheel2.Location = new System.Drawing.Point(313, 13);
            this.textBox_wheel2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_wheel2.Name = "textBox_wheel2";
            this.textBox_wheel2.Size = new System.Drawing.Size(100, 25);
            this.textBox_wheel2.TabIndex = 2;
            // 
            // textBox_wheel3
            // 
            this.textBox_wheel3.Location = new System.Drawing.Point(433, 13);
            this.textBox_wheel3.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_wheel3.Name = "textBox_wheel3";
            this.textBox_wheel3.Size = new System.Drawing.Size(100, 25);
            this.textBox_wheel3.TabIndex = 3;
            // 
            // tabPage_driver
            // 
            this.tabPage_driver.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_driver.Controls.Add(this.flowLayoutPanel3);
            this.tabPage_driver.Controls.Add(this.flowLayoutPanel4);
            this.tabPage_driver.Location = new System.Drawing.Point(4, 25);
            this.tabPage_driver.Name = "tabPage_driver";
            this.tabPage_driver.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_driver.Size = new System.Drawing.Size(774, 393);
            this.tabPage_driver.TabIndex = 1;
            this.tabPage_driver.Text = "驾驶员位置 Driver";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.textBox_hand1);
            this.flowLayoutPanel3.Controls.Add(this.textBox_hand2);
            this.flowLayoutPanel3.Controls.Add(this.textBox_hand3);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(80, 120);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(600, 50);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 7, 20, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "手部 hand (xyz)    ";
            // 
            // textBox_hand1
            // 
            this.textBox_hand1.Location = new System.Drawing.Point(217, 13);
            this.textBox_hand1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_hand1.Name = "textBox_hand1";
            this.textBox_hand1.Size = new System.Drawing.Size(100, 25);
            this.textBox_hand1.TabIndex = 1;
            // 
            // textBox_hand2
            // 
            this.textBox_hand2.Location = new System.Drawing.Point(337, 13);
            this.textBox_hand2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_hand2.Name = "textBox_hand2";
            this.textBox_hand2.Size = new System.Drawing.Size(100, 25);
            this.textBox_hand2.TabIndex = 2;
            // 
            // textBox_hand3
            // 
            this.textBox_hand3.Location = new System.Drawing.Point(457, 13);
            this.textBox_hand3.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_hand3.Name = "textBox_hand3";
            this.textBox_hand3.Size = new System.Drawing.Size(100, 25);
            this.textBox_hand3.TabIndex = 3;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.textBox_driver1);
            this.flowLayoutPanel4.Controls.Add(this.textBox_driver2);
            this.flowLayoutPanel4.Controls.Add(this.textBox_driver3);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(80, 50);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel4.Size = new System.Drawing.Size(600, 50);
            this.flowLayoutPanel4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 7, 20, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "驾驶员 driver (xyz)";
            // 
            // textBox_driver1
            // 
            this.textBox_driver1.Location = new System.Drawing.Point(216, 13);
            this.textBox_driver1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_driver1.Name = "textBox_driver1";
            this.textBox_driver1.Size = new System.Drawing.Size(100, 25);
            this.textBox_driver1.TabIndex = 1;
            // 
            // textBox_driver2
            // 
            this.textBox_driver2.Location = new System.Drawing.Point(336, 13);
            this.textBox_driver2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_driver2.Name = "textBox_driver2";
            this.textBox_driver2.Size = new System.Drawing.Size(100, 25);
            this.textBox_driver2.TabIndex = 2;
            // 
            // textBox_driver3
            // 
            this.textBox_driver3.Location = new System.Drawing.Point(456, 13);
            this.textBox_driver3.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.textBox_driver3.Name = "textBox_driver3";
            this.textBox_driver3.Size = new System.Drawing.Size(100, 25);
            this.textBox_driver3.TabIndex = 3;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(200, 350);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(125, 30);
            this.button_load.TabIndex = 0;
            this.button_load.Text = "获取值 load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_set
            // 
            this.button_set.Location = new System.Drawing.Point(450, 350);
            this.button_set.Name = "button_set";
            this.button_set.Size = new System.Drawing.Size(125, 30);
            this.button_set.TabIndex = 9;
            this.button_set.Text = "设定值 set";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            // 
            // NBPA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.button_set);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.textBox_veh);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "NBPA";
            this.Text = "Position Adjustment";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_wheel.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage_driver.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_veh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_wheel;
        private System.Windows.Forms.TabPage tabPage_driver;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_wheel4;
        private System.Windows.Forms.TextBox textBox_wheel5;
        private System.Windows.Forms.TextBox textBox_wheel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_wheel1;
        private System.Windows.Forms.TextBox textBox_wheel2;
        private System.Windows.Forms.TextBox textBox_wheel3;
        private System.Windows.Forms.Button button_set;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_hand1;
        private System.Windows.Forms.TextBox textBox_hand2;
        private System.Windows.Forms.TextBox textBox_hand3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_driver1;
        private System.Windows.Forms.TextBox textBox_driver2;
        private System.Windows.Forms.TextBox textBox_driver3;
    }
}