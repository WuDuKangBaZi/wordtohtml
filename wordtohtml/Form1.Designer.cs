namespace wordtohtml
{
    partial class demo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(demo));
            this.FeilsURL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.FeilList = new System.Windows.Forms.CheckedListBox();
            this.openfolder = new System.Windows.Forms.FolderBrowserDialog();
            this.saveurl = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            // 
            // FeilsURL
            // 
            this.FeilsURL.Enabled = false;
            this.FeilsURL.Location = new System.Drawing.Point(12, 12);
            this.FeilsURL.Name = "FeilsURL";
            this.FeilsURL.Size = new System.Drawing.Size(588, 21);
            this.FeilsURL.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "选择文件路径";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FeilList
            // 
            this.FeilList.FormattingEnabled = true;
            this.FeilList.Location = new System.Drawing.Point(12, 39);
            this.FeilList.Name = "FeilList";
            this.FeilList.Size = new System.Drawing.Size(686, 292);
            this.FeilList.TabIndex = 2;
            // 
            // saveurl
            // 
            this.saveurl.Enabled = false;
            this.saveurl.Location = new System.Drawing.Point(12, 337);
            this.saveurl.Name = "saveurl";
            this.saveurl.Size = new System.Drawing.Size(587, 21);
            this.saveurl.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(605, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "选择文件路径";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 367);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saveurl);
            this.Controls.Add(this.FeilList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FeilsURL);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "demo";
            this.Text = ".NETFramWork 3.0版本";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FeilsURL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox FeilList;
        private System.Windows.Forms.FolderBrowserDialog openfolder;
        private System.Windows.Forms.TextBox saveurl;
        private System.Windows.Forms.Button button2;
    }
}

