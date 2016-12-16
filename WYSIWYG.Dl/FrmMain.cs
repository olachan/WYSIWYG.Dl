using WYSIWYG.Dl.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Win32;

namespace WYSIWYG.Dl
{
    public partial class FrmMain : Form
    {
        #region Const

        private const string LINK_PATTERN = @"(href|src)=['""]?(?<link>[^'""\s]*)['""]?";
        private const string BACKGROUND_IMAGE_PATTERN = @"(url)\(['""]?(?<url>[^'""\s]*)['""]?\)";
        private const string CHECK_URL_PATTERN = @"^http(s)?://+([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

        private const string DESC_ANALYSISING = "���ڷ���...";
        private const string DESC_DOWNLOADING = "������ϣ���������...";
        private const string DESC_COMPELE = "������ϣ�";
        private const string DESC_SPAND_TIME = " | ������ʱ:{0}";
        private const string DESC_IMAGES_COUNT = " | �� {0} ��ͼƬ";
        private const string DESC_DOWNLOAD_TOTAL_TIME = " | ���غ�ʱ:{0}";

        private const string MSG_IS_EMPTY = "��ѡ�񱣴�·����";
        private const string URL_IS_EMPTY = "�����������ַ��";
        private const string MSG_FORMAT_ERROR = "��ַ��ʽ���ԣ�\n\r��������ɵ���ַ,�� http://www.taotao.com ";

        private const string STATUS_ANALYSIS = "������վ";
        private const string STATUS_QUEUE = "�������";
        private const string STATUS_COMPLETE = "�������";
        private const string STATUS_ERROR = "����ʧ��";

        private const string TIME_FORMAT = "HH:mm:ss.fff";

        #endregion Const

        #region ˽�б���

        private Uri _basicUri = null;

        #endregion ˽�б���

        #region ����

        /// <summary>
        /// ����
        /// </summary>
        public FrmMain()
        {
            SetFeatureBrowserEmulation();
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
            txtSaveDir.Text = Environment.CurrentDirectory;
            txtRegex.Text = LINK_PATTERN;
            txtRegex.ReadOnly = true;
            WinAPI.SendMessage(txtUrl.Handle, WinAPI.EM_SETCUEBANNER, 0, "����:http://chenzheng.me");

        }

        

        #endregion ����

        #region �����¼�

        /// <summary>
        /// ��ť�¼�:ѡ���ļ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBroswer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", txtSaveDir.Text);
            //using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            //{
            //    if (fbd.ShowDialog() == DialogResult.OK) txtSaveDir.Text = fbd.SelectedPath;
            //}
        }

        /// <summary>
        /// ��ť�¼�:����
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
            _basicUri = new Uri(txtUrl.Text.Trim());
            var dir = Path.Combine(txtSaveDir.Text, _basicUri.Host);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            txtSaveDir.Text = dir;

            DoWork();

        }

        /// <summary>
        /// �߳�
        /// </summary>
        private void DoWork()
        {
            //��ҳ·��
            string url = txtUrl.Text.Trim();
            //����·��
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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsddbAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        /// <summary>
        /// ����ListView�п�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvLog_SizeChanged(object sender, EventArgs e)
        {
            lvLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        #endregion �����¼�

        #region ͬ������

        /// <summary>
        /// ��������
        /// </summary>
        private async void Run(string url, string savePath)
        {
            #region ��ʱ

            long count = 0;
            long countLast = 0;
            long freq = 0;
            double result = 0;

            WinAPI.QueryPerformanceFrequency(ref freq);
            WinAPI.QueryPerformanceCounter(ref count);

            #endregion ��ʱ

            var list = await FetchImgUris(url);

            #region ��ʱ

            WinAPI.QueryPerformanceCounter(ref countLast);
            count = countLast - count;
            result = (double)(count) / (double)freq;

            #endregion ��ʱ

            lvLog.Items.Add(new ListViewItem(new string[] { }));
            tsslStatus.Text = DESC_DOWNLOADING;
            tsslTime.Text = string.Format(DESC_SPAND_TIME, result);
            tsslCount.Text = string.Format(DESC_IMAGES_COUNT, list.Count);
            Application.DoEvents();

            #region ��ʱ

            count = 0;
            countLast = 0;
            freq = 0;
            result = 0;

            WinAPI.QueryPerformanceFrequency(ref freq);
            WinAPI.QueryPerformanceCounter(ref count);

            #endregion ��ʱ

            //��������
            DownLoad(list, savePath);

            #region ��ʱ

            WinAPI.QueryPerformanceCounter(ref countLast);
            count = countLast - count;
            result = (double)(count) / (double)freq;

            #endregion ��ʱ

            tsslStatus.Text = DESC_COMPELE;
            tsslTotalTime.Text = string.Format(DESC_SPAND_TIME, result);
            btnDownload.Enabled = true;
        }

        /// <summary>
        /// ������վURL��ȡCSS
        /// ����CSS��ȡ����ͼƬ��ַ
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<List<Uri>> FetchImgUris(string url)
        {
            var sourceCSS = new StringBuilder();
            var list = new List<Uri>();
            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.18 Safari/537.36");

                var cts = new CancellationTokenSource(10000); // cancel in 10s
                var sourceHtml = await LoadDynamicPage(url, cts.Token);

                //string sourceHtml = client.DownloadString(_basicUri);
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

                    //if (!link.Contains(".")) continue;
                    //extension = link.Substring(link.LastIndexOf('.'));
                    extension = Path.GetExtension(uri.OriginalString);
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
        /// ����CSS
        /// ��ȡ����ͼƬ��ַ
        /// </summary>
        /// <param name="css"></param>
        private List<Uri> FetchBgImgUris(string css)
        {
            var list = new List<Uri>();
            var regex = new Regex(BACKGROUND_IMAGE_PATTERN, RegexOptions.IgnoreCase);
            MatchCollection collection = regex.Matches(css);
            if (collection == null) return null;
            string url = string.Empty;
            Uri uri = null;
            var extension = string.Empty;
            foreach (Match match in collection)
            {
                url = match.Groups["url"].Value;
                if (!Uri.TryCreate(_basicUri, url, out uri)) continue;

                extension = Path.GetExtension(uri.OriginalString);
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
                    default:
                        break;
                }

                list.Add(uri);
                lvLog.Items.Add(new ListViewItem(new string[] {uri.AbsoluteUri,
                    DateTime.Now.ToString(TIME_FORMAT),
                    STATUS_QUEUE, string.Empty,
                    Path.GetExtension(url)}));
            }
            return list;
        }

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        /// <param name="list"></param>
        /// <param name="saveDir"></param>
        private void DownLoad(List<Uri> list, string saveDir)
        {

            using (var client = new WebClient())
            {
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.18 Safari/537.36");
                FileInfo fi = null;
                foreach (Uri uri in list)
                {
                    try
                    {
                        var fileName = string.Empty;
                        if (uri.Host == _basicUri.Host)
                            fileName = Path.Combine(saveDir, uri.LocalPath.Substring(1));
                        else
                            fileName = Path.Combine(saveDir, uri.Host, uri.LocalPath.Substring(1));
                        fi = new FileInfo(fileName);
                        if (!Directory.Exists(fi.DirectoryName)) Directory.CreateDirectory(fi.DirectoryName);
                        client.DownloadFile(uri, fileName);
                        lvLog.Items.Add(new ListViewItem(new string[] { uri.AbsoluteUri, DateTime.Now.ToString(TIME_FORMAT), STATUS_COMPLETE, string.Empty, uri.AbsoluteUri.Substring(uri.AbsoluteUri.LastIndexOf('.')) }));
                    }
                    catch (Exception ex)
                    {
                        lvLog.Items.Add(new ListViewItem(new string[] { ex.Message, DateTime.Now.ToString(TIME_FORMAT), STATUS_ERROR, string.Empty, ex.StackTrace }));
                    }
                }

            }
        }

        #endregion ͬ������

        // navigate and download 
        async Task<string> LoadDynamicPage(string url, CancellationToken token)
        {
            // navigate and await DocumentCompleted
            var tcs = new TaskCompletionSource<bool>();
            WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
                tcs.TrySetResult(true);

            using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: true))
            {
                this.webBrowser.DocumentCompleted += handler;
                try
                {
                    this.webBrowser.Navigate(url);
                    await tcs.Task; // wait for DocumentCompleted
                }
                finally
                {
                    this.webBrowser.DocumentCompleted -= handler;
                }
            }

            // get the root element
            var documentElement = this.webBrowser.Document.GetElementsByTagName("html")[0];

            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(500, token);

                // continue polling if the WebBrowser is still busy
                if (this.webBrowser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }

            // consider the page fully rendered 
            token.ThrowIfCancellationRequested();
            return html;
        }

        // enable HTML5 (assuming we're running IE10+)
        // more info: http://stackoverflow.com/a/18333982/1768303
        static void SetFeatureBrowserEmulation()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;
            var appName = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                appName, 10000, RegistryValueKind.DWord);
        }
    }
}