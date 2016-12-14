namespace WYSIWYG.Dl
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblQQ = new System.Windows.Forms.Label();
            this.lblQQDesc = new System.Windows.Forms.Label();
            this.lblMSN = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblBlog = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.lnkBlog = new System.Windows.Forms.LinkLabel();
            this.lnkQQ = new System.Windows.Forms.LinkLabel();
            this.lnkMSN = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaption.Location = new System.Drawing.Point(29, 25);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(257, 20);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "URL图片分析器 V0.1";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(34, 83);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(101, 16);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "作者：    Ola Chan";
            // 
            // lblQQ
            // 
            this.lblQQ.AutoSize = true;
            this.lblQQ.Location = new System.Drawing.Point(31, 112);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(39, 16);
            this.lblQQ.TabIndex = 1;
            this.lblQQ.Text = "label2";
            // 
            // lblQQDesc
            // 
            this.lblQQDesc.AutoSize = true;
            this.lblQQDesc.Location = new System.Drawing.Point(34, 112);
            this.lblQQDesc.Name = "lblQQDesc";
            this.lblQQDesc.Size = new System.Drawing.Size(48, 16);
            this.lblQQDesc.TabIndex = 1;
            this.lblQQDesc.Text = "QQ号：";
            // 
            // lblMSN
            // 
            this.lblMSN.AutoSize = true;
            this.lblMSN.Location = new System.Drawing.Point(34, 143);
            this.lblMSN.Name = "lblMSN";
            this.lblMSN.Size = new System.Drawing.Size(45, 16);
            this.lblMSN.TabIndex = 1;
            this.lblMSN.Text = "MSN：";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(31, 177);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(39, 16);
            this.lblMail.TabIndex = 1;
            this.lblMail.Text = "label2";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(34, 175);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(156, 16);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "邮箱：   olar.tan@gmail.com";
            // 
            // lblBlog
            // 
            this.lblBlog.AutoSize = true;
            this.lblBlog.Location = new System.Drawing.Point(34, 207);
            this.lblBlog.Name = "lblBlog";
            this.lblBlog.Size = new System.Drawing.Size(50, 16);
            this.lblBlog.TabIndex = 1;
            this.lblBlog.Text = "博客：   ";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(121, 247);
            this.btnYes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(87, 31);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // lnkBlog
            // 
            this.lnkBlog.AutoSize = true;
            this.lnkBlog.Location = new System.Drawing.Point(90, 207);
            this.lnkBlog.Name = "lnkBlog";
            this.lnkBlog.Size = new System.Drawing.Size(125, 16);
            this.lnkBlog.TabIndex = 3;
            this.lnkBlog.TabStop = true;
            this.lnkBlog.Text = "http://chenzheng.me/";
            this.lnkBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBlog_LinkClicked);
            // 
            // lnkQQ
            // 
            this.lnkQQ.AutoSize = true;
            this.lnkQQ.Location = new System.Drawing.Point(90, 112);
            this.lnkQQ.Name = "lnkQQ";
            this.lnkQQ.Size = new System.Drawing.Size(62, 16);
            this.lnkQQ.TabIndex = 4;
            this.lnkQQ.TabStop = true;
            this.lnkQQ.Text = "286064707";
            this.lnkQQ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkQQ_LinkClicked);
            // 
            // lnkMSN
            // 
            this.lnkMSN.AutoSize = true;
            this.lnkMSN.Location = new System.Drawing.Point(90, 143);
            this.lnkMSN.Name = "lnkMSN";
            this.lnkMSN.Size = new System.Drawing.Size(107, 16);
            this.lnkMSN.TabIndex = 5;
            this.lnkMSN.TabStop = true;
            this.lnkMSN.Text = "olar.tan@msn.com";
            this.lnkMSN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMSN_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 307);
            this.Controls.Add(this.lnkMSN);
            this.Controls.Add(this.lnkQQ);
            this.Controls.Add(this.lnkBlog);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblBlog);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblMSN);
            this.Controls.Add(this.lblQQDesc);
            this.Controls.Add(this.lblQQ);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblCaption);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblQQ;
        private System.Windows.Forms.Label lblQQDesc;
        private System.Windows.Forms.Label lblMSN;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblBlog;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.LinkLabel lnkBlog;
        private System.Windows.Forms.LinkLabel lnkQQ;
        private System.Windows.Forms.LinkLabel lnkMSN;
    }
}