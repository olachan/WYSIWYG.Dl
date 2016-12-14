namespace WYSIWYG.Dl
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源,为 true；否则为 false。</param>
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtSaveDir = new System.Windows.Forms.TextBox();
            this.btnBroswer = new System.Windows.Forms.Button();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.labUrl = new System.Windows.Forms.Label();
            this.labRegex = new System.Windows.Forms.Label();
            this.labSaveDir = new System.Windows.Forms.Label();
            this.ssProcess = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTotalTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.tsSystem = new System.Windows.Forms.ToolStrip();
            this.tsddbSetting = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsddbAbout = new System.Windows.Forms.ToolStripDropDownButton();
            this.lvLog = new System.Windows.Forms.ListView();
            this.chURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ssProcess.SuspendLayout();
            this.tsSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(101, 141);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(318, 22);
            this.txtUrl.TabIndex = 1;
            // 
            // txtSaveDir
            // 
            this.txtSaveDir.Location = new System.Drawing.Point(101, 55);
            this.txtSaveDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSaveDir.Name = "txtSaveDir";
            this.txtSaveDir.Size = new System.Drawing.Size(318, 22);
            this.txtSaveDir.TabIndex = 0;
            // 
            // btnBroswer
            // 
            this.btnBroswer.Location = new System.Drawing.Point(439, 54);
            this.btnBroswer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBroswer.Name = "btnBroswer";
            this.btnBroswer.Size = new System.Drawing.Size(87, 22);
            this.btnBroswer.TabIndex = 3;
            this.btnBroswer.Text = "输出路径";
            this.btnBroswer.UseVisualStyleBackColor = true;
            this.btnBroswer.Click += new System.EventHandler(this.btnBroswer_Click);
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(101, 93);
            this.txtRegex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(318, 22);
            this.txtRegex.TabIndex = 4;
            // 
            // labUrl
            // 
            this.labUrl.AutoSize = true;
            this.labUrl.Location = new System.Drawing.Point(12, 145);
            this.labUrl.Name = "labUrl";
            this.labUrl.Size = new System.Drawing.Size(30, 16);
            this.labUrl.TabIndex = 5;
            this.labUrl.Text = "解析地址";
            // 
            // labRegex
            // 
            this.labRegex.AutoSize = true;
            this.labRegex.Location = new System.Drawing.Point(13, 96);
            this.labRegex.Name = "labRegex";
            this.labRegex.Size = new System.Drawing.Size(52, 16);
            this.labRegex.TabIndex = 6;
            this.labRegex.Text = "定义正则";
            // 
            // labSaveDir
            // 
            this.labSaveDir.AutoSize = true;
            this.labSaveDir.Location = new System.Drawing.Point(13, 57);
            this.labSaveDir.Name = "labSaveDir";
            this.labSaveDir.Size = new System.Drawing.Size(52, 16);
            this.labSaveDir.TabIndex = 7;
            this.labSaveDir.Text = "保存路径";
            // 
            // ssProcess
            // 
            this.ssProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tsslTime,
            this.tsslCount,
            this.tsslTotalTime});
            this.ssProcess.Location = new System.Drawing.Point(0, 697);
            this.ssProcess.Name = "ssProcess";
            this.ssProcess.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ssProcess.Size = new System.Drawing.Size(558, 22);
            this.ssProcess.TabIndex = 8;
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslTime
            // 
            this.tsslTime.Name = "tsslTime";
            this.tsslTime.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslCount
            // 
            this.tsslCount.Name = "tsslCount";
            this.tsslCount.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslTotalTime
            // 
            this.tsslTotalTime.Name = "tsslTotalTime";
            this.tsslTotalTime.Size = new System.Drawing.Size(0, 17);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(439, 140);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(87, 22);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "下载图片";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // tsSystem
            // 
            this.tsSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbSetting,
            this.tsSeparator,
            this.tsddbAbout});
            this.tsSystem.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsSystem.Location = new System.Drawing.Point(0, 0);
            this.tsSystem.Name = "tsSystem";
            this.tsSystem.Size = new System.Drawing.Size(558, 23);
            this.tsSystem.TabIndex = 10;
            // 
            // tsddbSetting
            // 
            this.tsddbSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsddbSetting.Image")));
            this.tsddbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbSetting.Name = "tsddbSetting";
            this.tsddbSetting.Size = new System.Drawing.Size(60, 19);
            this.tsddbSetting.Text = "设置(&S)";
            // 
            // tsSeparator
            // 
            this.tsSeparator.Name = "tsSeparator";
            this.tsSeparator.Size = new System.Drawing.Size(6, 23);
            // 
            // tsddbAbout
            // 
            this.tsddbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsddbAbout.Image")));
            this.tsddbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbAbout.Name = "tsddbAbout";
            this.tsddbAbout.Size = new System.Drawing.Size(62, 19);
            this.tsddbAbout.Text = "关于(&A)";
            this.tsddbAbout.Click += new System.EventHandler(this.tsddbAbout_Click);
            // 
            // lvLog
            // 
            this.lvLog.AllowDrop = true;
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chURL,
            this.chTime,
            this.chStatus,
            this.chSite,
            this.chFormat});
            this.lvLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvLog.GridLines = true;
            this.lvLog.Location = new System.Drawing.Point(0, 213);
            this.lvLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(558, 484);
            this.lvLog.TabIndex = 11;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            this.lvLog.SizeChanged += new System.EventHandler(this.lvLog_SizeChanged);
            // 
            // chURL
            // 
            this.chURL.Text = "URL";
            this.chURL.Width = 36;
            // 
            // chTime
            // 
            this.chTime.Text = "时间";
            this.chTime.Width = 36;
            // 
            // chStatus
            // 
            this.chStatus.Text = "状态";
            this.chStatus.Width = 36;
            // 
            // chSite
            // 
            this.chSite.Text = "大小";
            this.chSite.Width = 36;
            // 
            // chFormat
            // 
            this.chFormat.Text = "文件类型";
            this.chFormat.Width = 330;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 719);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.tsSystem);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.labSaveDir);
            this.Controls.Add(this.labRegex);
            this.Controls.Add(this.labUrl);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.btnBroswer);
            this.Controls.Add(this.txtSaveDir);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.ssProcess);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资源WYSIWYG下载器";
            this.ssProcess.ResumeLayout(false);
            this.ssProcess.PerformLayout();
            this.tsSystem.ResumeLayout(false);
            this.tsSystem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtSaveDir;
        private System.Windows.Forms.Button btnBroswer;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label labUrl;
        private System.Windows.Forms.Label labRegex;
        private System.Windows.Forms.Label labSaveDir;
        private System.Windows.Forms.StatusStrip ssProcess;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ToolStrip tsSystem;
        private System.Windows.Forms.ToolStripDropDownButton tsddbSetting;
        private System.Windows.Forms.ToolStripSeparator tsSeparator;
        private System.Windows.Forms.ToolStripDropDownButton tsddbAbout;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader chURL;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chSite;
        private System.Windows.Forms.ColumnHeader chFormat;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotalTime;
    }
}

