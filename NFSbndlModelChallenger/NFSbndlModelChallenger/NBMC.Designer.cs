
namespace NFSbndlModelChallenger {
    partial class NBMC {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.button_transform = new System.Windows.Forms.Button();
            this.select_obj = new System.Windows.Forms.OpenFileDialog();
            this.load_obj = new System.Windows.Forms.Button();
            this.load_veh = new System.Windows.Forms.Button();
            this.textBox_obj = new System.Windows.Forms.TextBox();
            this.textBox_veh = new System.Windows.Forms.TextBox();
            this.texBox_output = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.select_veh = new System.Windows.Forms.OpenFileDialog();
            this.button_readme = new System.Windows.Forms.Button();
            this.button_adjust = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_transform
            // 
            this.button_transform.Location = new System.Drawing.Point(350, 200);
            this.button_transform.Name = "button_transform";
            this.button_transform.Size = new System.Drawing.Size(200, 50);
            this.button_transform.TabIndex = 0;
            this.button_transform.Text = "转换模型 Transform";
            this.button_transform.UseVisualStyleBackColor = true;
            this.button_transform.Click += new System.EventHandler(this.button_transform_Click);
            // 
            // load_obj
            // 
            this.load_obj.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.load_obj.Location = new System.Drawing.Point(680, 120);
            this.load_obj.Name = "load_obj";
            this.load_obj.Size = new System.Drawing.Size(125, 30);
            this.load_obj.TabIndex = 1;
            this.load_obj.Text = "OBJ文件";
            this.load_obj.UseVisualStyleBackColor = true;
            this.load_obj.Click += new System.EventHandler(this.load_obj_Click);
            // 
            // load_veh
            // 
            this.load_veh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.load_veh.Location = new System.Drawing.Point(680, 50);
            this.load_veh.Name = "load_veh";
            this.load_veh.Size = new System.Drawing.Size(125, 30);
            this.load_veh.TabIndex = 3;
            this.load_veh.Text = "VEH车辆文件夹";
            this.load_veh.UseVisualStyleBackColor = true;
            this.load_veh.Click += new System.EventHandler(this.load_veh_Click);
            // 
            // textBox_obj
            // 
            this.textBox_obj.Location = new System.Drawing.Point(100, 120);
            this.textBox_obj.Name = "textBox_obj";
            this.textBox_obj.Size = new System.Drawing.Size(550, 25);
            this.textBox_obj.TabIndex = 4;
            this.textBox_obj.Text = "select the obj file";
            // 
            // textBox_veh
            // 
            this.textBox_veh.Location = new System.Drawing.Point(100, 50);
            this.textBox_veh.Name = "textBox_veh";
            this.textBox_veh.Size = new System.Drawing.Size(550, 25);
            this.textBox_veh.TabIndex = 6;
            this.textBox_veh.Text = "select the unpacked vehicle folder";
            // 
            // texBox_output
            // 
            this.texBox_output.AutoSize = true;
            this.texBox_output.BackColor = System.Drawing.Color.Transparent;
            this.texBox_output.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.texBox_output.ForeColor = System.Drawing.Color.White;
            this.texBox_output.Location = new System.Drawing.Point(100, 300);
            this.texBox_output.MaximumSize = new System.Drawing.Size(680, 160);
            this.texBox_output.MinimumSize = new System.Drawing.Size(680, 160);
            this.texBox_output.Name = "texBox_output";
            this.texBox_output.Size = new System.Drawing.Size(680, 160);
            this.texBox_output.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(596, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Binko_J 144hz@sina.com";
            // 
            // select_veh
            // 
            this.select_veh.CheckFileExists = false;
            this.select_veh.ValidateNames = false;
            // 
            // button_readme
            // 
            this.button_readme.Location = new System.Drawing.Point(120, 200);
            this.button_readme.Name = "button_readme";
            this.button_readme.Size = new System.Drawing.Size(200, 50);
            this.button_readme.TabIndex = 14;
            this.button_readme.Text = "使用说明 README";
            this.button_readme.UseVisualStyleBackColor = true;
            this.button_readme.Click += new System.EventHandler(this.button_readme_Click);
            // 
            // button_adjust
            // 
            this.button_adjust.Location = new System.Drawing.Point(580, 200);
            this.button_adjust.Name = "button_adjust";
            this.button_adjust.Size = new System.Drawing.Size(200, 50);
            this.button_adjust.TabIndex = 15;
            this.button_adjust.Text = "外观定位 Position";
            this.button_adjust.UseVisualStyleBackColor = true;
            this.button_adjust.Click += new System.EventHandler(this.button_adjust_Click);
            // 
            // NBMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NFSbndlModelChallenger.Properties.Resources._1background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(882, 493);
            this.Controls.Add(this.button_adjust);
            this.Controls.Add(this.button_readme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.texBox_output);
            this.Controls.Add(this.textBox_veh);
            this.Controls.Add(this.textBox_obj);
            this.Controls.Add(this.load_veh);
            this.Controls.Add(this.load_obj);
            this.Controls.Add(this.button_transform);
            this.MaximumSize = new System.Drawing.Size(900, 540);
            this.MinimumSize = new System.Drawing.Size(900, 540);
            this.Name = "NBMC";
            this.Text = "NFS BNDL Model Challenger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_transform;
        private System.Windows.Forms.OpenFileDialog select_obj;
        private System.Windows.Forms.Button load_obj;
        private System.Windows.Forms.Button load_veh;
        private System.Windows.Forms.TextBox textBox_obj;
        private System.Windows.Forms.TextBox textBox_veh;
        private System.Windows.Forms.Label texBox_output;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog select_veh;
        private System.Windows.Forms.Button button_readme;
        private System.Windows.Forms.Button button_adjust;
    }
}

