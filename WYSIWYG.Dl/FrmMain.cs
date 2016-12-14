using WYSIWYG.Dl.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace WYSIWYG.Dl
{
    public partial class FrmMain : Form
    {
        #region Const

        private const string LINK_PATTERN = @"(href|src)=['""]?(?<link>[^'""\s]*)['""]?";
        private const string BACKGROUND_IMAGE_PATTERN = @"(url)\(['""]?(?<url>[^'""\s]*)['""]?\)";
        private const string CHECK_URL_PATTERN = @"^http(s)?://+([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

        private const string DESC_ANALYSISING = "正在分析...";
        private const string DESC_DOWNLOADING = "分析完毕！正在下载...";
        private const string DESC_COMPELE = "下载完毕！";
        private const string DESC_SPAND_TIME = " | 分析耗时:{0}";
        private const string DESC_IMAGES_COUNT = " | 共 {0} 张图片";
        private const string DESC_DOWNLOAD_TOTAL_TIME = " | 下载耗时:{0}";

        private const string MSG_IS_EMPTY = "请选择保存路径！";
        private const string URL_IS_EMPTY = "请输入解析地址！";
        private const string MSG_FORMAT_ERROR = "网址格式不对！\n\r请输入完成的网址,如 http://www.taotao.com ";

        private const string STATUS_ANALYSIS = "分析网站";
        private const string STATUS_QUEUE = "进入队列";
        private const string STATUS_COMPLETE = "下载完成";
        private const string STATUS_ERROR = "下载失败";

        private const string TIME_FORMAT = "HH:mm:ss.fff";

        #endregion Const

        #region 私有变量

        private Uri _basicUri = null;

        #endregion 私有变量

        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        public FrmMain()
        {

            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            var dir = Path.Combine(Environment.CurrentDirectory, DateTime.Now.ToString("yyyyMMddHHmmss"));
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            txtSaveDir.Text = dir;
            txtRegex.Text = LINK_PATTERN;
            txtRegex.ReadOnly = true;
            WinAPI.SendMessage(txtUrl.Handle, WinAPI.EM_SETCUEBANNER, 0, "例如:http://www.taotao.com");
        }

        #endregion 构造

        #region 窗体事件

        /// <summary>
        /// 按钮事件:选定文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBroswer_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK) txtSaveDir.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// 按钮事件:下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaveDir.Text.Trim()))
            {
                MessageBox.Show(MSG_IS_EMPTY);
                return;
            }

            if (string.IsNullOrEmpty(txtUrl.Text.Trim()))
            {
                MessageBox.Show(URL_IS_EMPTY);
                return;
            }

            Match matchURL = Regex.Match(txtUrl.Text.Trim(), CHECK_URL_PATTERN, RegexOptions.IgnoreCase);
            if (!matchURL.Success)
            {
                MessageBox.Show(MSG_FORMAT_ERROR);
                return;
            }

            Thread t = new Thread(new ThreadStart(DoWork));
            t.Start();
        }

        /// <summary>
        /// 线程
        /// </summary>
        private void DoWork()
        {
            //网页路径
            string url = txtUrl.Text.Trim();
            //保存路径
            string saveDir = txtSaveDir.Text.Trim();

            lvLog.Items.Clear();
            tsslStatus.Text = DESC_ANALYSISING;
            tsslTime.Text = string.Format(DESC_SPAND_TIME, 0);
            tsslCount.Text = string.Format(DESC_IMAGES_COUNT, 0);
            tsslTotalTime.Text = string.Format(DESC_DOWNLOAD_TOTAL_TIME, 0);
            btnDownload.Enabled = false;

            Application.DoEvents();
            Run(url, saveDir);
        }

        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsddbAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        /// <summary>
        /// 调整ListView列宽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvLog_SizeChanged(object sender, EventArgs e)
        {
            lvLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        #endregion 窗体事件

        #region 同步下载

        /// <summary>
        /// 分析下载
        /// </summary>
        private void Run(string url, string savePath)
        {
            #region 计时

            long count = 0;
            long countLast = 0;
            long freq = 0;
            double result = 0;

            WinAPI.QueryPerformanceFrequency(ref freq);
            WinAPI.QueryPerformanceCounter(ref count);

            #endregion 计时

            List<Uri> list = FetchImgUris(url);

            #region 计时

            WinAPI.QueryPerformanceCounter(ref countLast);
            count = countLast - count;
            result = (double)(count) / (double)freq;

            #endregion 计时

            lvLog.Items.Add(new ListViewItem(new string[] { }));
            tsslStatus.Text = DESC_DOWNLOADING;
            tsslTime.Text = string.Format(DESC_SPAND_TIME, result);
            tsslCount.Text = string.Format(DESC_IMAGES_COUNT, list.Count);
            Application.DoEvents();

            #region 计时

            count = 0;
            countLast = 0;
            freq = 0;
            result = 0;

            WinAPI.QueryPerformanceFrequency(ref freq);
            WinAPI.QueryPerformanceCounter(ref count);

            #endregion 计时

            //下载数据
            DownLoad(list, savePath);

            #region 计时

            WinAPI.QueryPerformanceCounter(ref countLast);
            count = countLast - count;
            result = (double)(count) / (double)freq;

            #endregion 计时

            tsslStatus.Text = DESC_COMPELE;
            tsslTotalTime.Text = string.Format(DESC_SPAND_TIME, result);
            btnDownload.Enabled = true;
        }

        /// <summary>
        /// 根据网站URL获取CSS
        /// 分析CSS获取背景图片地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected List<Uri> FetchImgUris(string url)
        {
            var sourceCSS = new StringBuilder();
            List<Uri> list = new List<Uri>();
            using (WebClient client = new WebClient())
            {
                _basicUri = new Uri(url);
                string sourceHtml = client.DownloadString(_basicUri);
                sourceCSS.Append(sourceHtml);

                Regex regex = new Regex(LINK_PATTERN, RegexOptions.IgnoreCase);
                MatchCollection collection = regex.Matches(sourceHtml);
                if (collection == null) return null;
                string extension = string.Empty;
                string link = string.Empty;
                Uri uri = null;
                foreach (Match match in collection)
                {
                    link = match.Groups["link"].Value;
                    if (!Uri.TryCreate(_basicUri, link, out uri)) continue;

                    lvLog.Items.Add(new ListViewItem(new string[] { uri.AbsoluteUri,
                        DateTime.Now.ToString(TIME_FORMAT), STATUS_ANALYSIS,
                        string.Empty, link.Contains(".") ? link.Substring(link.LastIndexOf('.')) : string.Empty }));

                    if (!link.Contains(".")) continue;
                    extension = link.Substring(link.LastIndexOf('.'));
                    switch (extension.ToUpper())
                    {
                        case ".GIF":
                        case ".PNG":
                        case ".JPG":
                        case ".ICO":
                        case ".SVG":
                        case ".JPEG":
                            list.Add(uri);
                            break;
                        case ".CSS":
                            sourceCSS.Append(client.DownloadString(uri));
                            break;
                        default:
                            break;
                    }
                }
            }
            list.AddRange(FetchBgImgUris(sourceCSS.ToString()));
            DecodeBase64Img(sourceCSS.ToString());
            return list;
        }

        private void DecodeBase64Img(string input)
        {
            new Thread(() =>
            {
                var regex = new Regex(@"data:(?<mime>[\w/\-\.]+);(?<encoding>\w+),(?<data>.*)", RegexOptions.Compiled);
                MatchCollection collection = regex.Matches(input);
                if (collection == null) return;
                {
                    foreach (Match match in collection)
                    {
                        var mime = match.Groups["mime"].Value;
                        var encoding = match.Groups["encoding"].Value;
                        var data = match.Groups["data"].Value;
                        var filePath = Path.Combine("", Guid.NewGuid().ToString("N") + MimeExtensionHelper.GetExtension(mime));
                        File.WriteAllBytes(filePath, Convert.FromBase64String(data));
                    }
                }
            }).Start();

        }

        /// <summary>
        /// 分析CSS
        /// 获取背景图片地址
        /// </summary>
        /// <param name="css"></param>
        private List<Uri> FetchBgImgUris(string css)
        {
            List<Uri> list = new List<Uri>();
            Regex regex = new Regex(BACKGROUND_IMAGE_PATTERN, RegexOptions.IgnoreCase);
            MatchCollection collection = regex.Matches(css);
            if (collection == null) return null;
            string url = string.Empty;
            Uri uri = null;
            foreach (Match match in collection)
            {
                url = match.Groups["url"].Value;
                if (!Uri.TryCreate(_basicUri, url, out uri)) continue;
                list.Add(uri);
                lvLog.Items.Add(new ListViewItem(new string[] {uri.AbsoluteUri,
                    DateTime.Now.ToString(TIME_FORMAT),
                    STATUS_QUEUE, string.Empty,
                    Path.GetExtension(url)}));
            }
            return list;
        }

        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="list"></param>
        /// <param name="saveDir"></param>
        private void DownLoad(List<Uri> list, string saveDir)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.18 Safari/537.36");
                    foreach (Uri uri in list)
                    {
                        string savePath = Path.Combine(saveDir, uri.AbsoluteUri.Substring(uri.AbsoluteUri.LastIndexOf('/') + 1));
                        client.DownloadFile(uri, savePath);
                        lvLog.Items.Add(new ListViewItem(new string[] { uri.AbsoluteUri, DateTime.Now.ToString(TIME_FORMAT), STATUS_COMPLETE, string.Empty, uri.AbsoluteUri.Substring(uri.AbsoluteUri.LastIndexOf('.')) }));
                    }
                }
            }
            catch (Exception ex)
            {
                lvLog.Items.Add(new ListViewItem(new string[] { ex.Message, DateTime.Now.ToString(TIME_FORMAT), STATUS_ERROR, string.Empty, ex.StackTrace }));
            }
        }

        #endregion 同步下载
    }
}