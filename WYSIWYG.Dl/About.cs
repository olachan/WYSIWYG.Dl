using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WYSIWYG.Dl
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 点击超链接打开网页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //打开博客地址
            Process.Start(lnkBlog.Text);
        }

        private void lnkQQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //建立QQ临时会话
            Process.Start("tencent://message/?uin=286064707");
        }

        private void lnkMSN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //复制MSN到剪切板
            DataObject m_data = new DataObject();
            m_data.SetData(DataFormats.Text, true, "rainalley@msn.com");
            Clipboard.SetDataObject(m_data, true);
            MessageBox.Show("MSN:rainalley@msn.com复制成功！");
            //建立MSN临时会话
            Process.Start("msnim:chat?contact=rainalley@msn.com");
        }
    }
}