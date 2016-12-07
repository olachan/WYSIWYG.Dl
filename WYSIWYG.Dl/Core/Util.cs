using System;
using System.Drawing;
using System.Windows.Forms;

namespace WYSIWYG.Dl.Core
{
    public class Util
    {
        public static bool UrlIsAlive(string url)
        {
            Msxml.XMLHTTP _xmlhttp = new Msxml.XMLHTTPClass();
            _xmlhttp.open("GET", url, false, null, null);
            return (_xmlhttp.status == 200);
        }

        public static bool UrlIsAlive(Uri uri)
        {
            return UrlIsAlive(uri.AbsoluteUri);
        }

        public static void AutoResizeColumnWidthByFont(ListView lv)
        {
            int count = lv.Columns.Count;
            int MaxWidth = 0;
            Graphics graphics = lv.CreateGraphics();
            Font font = lv.Font;
            ListView.ListViewItemCollection items = lv.Items;

            string str = string.Empty;
            int width = 0;

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            for (int i = 0; i < count; i++)
            {
                str = lv.Columns[i].Text;
                MaxWidth = lv.Columns[i].Width;

                foreach (ListViewItem item in items)
                {
                    str = item.SubItems[i].Text;
                    width = (int)graphics.MeasureString(str, font).Width;
                    MaxWidth = (width > MaxWidth) ? width : MaxWidth;
                }
                if (i == 0) lv.Columns[i].Width = lv.SmallImageList.ImageSize.Width + MaxWidth;
                lv.Columns[i].Width = MaxWidth;
            }
        }

        public static void AutoResizeColumnWidthByGraphics(ListView lv)
        {
            int count = lv.Columns.Count;
            int MaxWidth = 0;
            Graphics graphics = lv.CreateGraphics();
            Font font = lv.Font;
            ListView.ListViewItemCollection items = lv.Items;

            string str = string.Empty;
            int width = 0;

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            for (int i = 0; i < count; i++)
            {
                str = lv.Columns[i].Text;
                MaxWidth = lv.Columns[i].Width;

                foreach (ListViewItem item in items)
                {
                    str = item.SubItems[i].Text;
                    width = (int)graphics.MeasureString(str, font).Width;
                    MaxWidth = (width > MaxWidth) ? width : MaxWidth;
                }
                if (i == 0) lv.Columns[i].Width = lv.SmallImageList.ImageSize.Width + MaxWidth;
                lv.Columns[i].Width = MaxWidth;
            }
        }
    }
}