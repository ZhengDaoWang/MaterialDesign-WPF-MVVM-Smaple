namespace ZFS.ServerClient
{
    partial class Run_Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.Txt_info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(307, 15);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(129, 51);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "启动服务";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(460, 15);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(129, 51);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "关闭服务";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // Txt_info
            // 
            this.Txt_info.Location = new System.Drawing.Point(17, 75);
            this.Txt_info.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_info.Multiline = true;
            this.Txt_info.Name = "Txt_info";
            this.Txt_info.Size = new System.Drawing.Size(569, 346);
            this.Txt_info.TabIndex = 2;
            this.Txt_info.Text = "请开启服务...";
            // 
            // Run_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 438);
            this.Controls.Add(this.Txt_info);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Run_Server";
            this.Text = "WCF服务端控制台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Run_Server_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox Txt_info;
    }
}