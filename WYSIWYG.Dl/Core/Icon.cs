using System;

namespace WYSIWYG.Dl.Core
{
    public class Icon
    {
        #region Win32 API

        [System.Runtime.InteropServices.DllImport("shell32.dll", EntryPoint = "ExtractAssociatedIcon")]
        private static extern IntPtr ExtractAssociatedIconA(
            IntPtr hInst,
            [System.Runtime.InteropServices.MarshalAs(
                 System.Runtime.InteropServices.UnmanagedType.LPStr)] string lpIconPath,
            ref int lpiIcon);

        [System.Runtime.InteropServices.DllImport("shell32.dll", EntryPoint = "ExtractIcon")]
        private static extern IntPtr ExtractIconA(
            IntPtr hInst,
            [System.Runtime.InteropServices.MarshalAs(
                 System.Runtime.InteropServices.UnmanagedType.LPStr)] string lpszExeFileName,
            int nIconIndex);

        private static IntPtr HInst = IntPtr.Zero;

        #endregion Win32 API

        #region ICON Tool

        public static System.Drawing.Icon ExtractIcon(string fileName, int index)
        {
            if (!System.IO.File.Exists(fileName)) return null;

            System.IntPtr hIcon;
            hIcon = ExtractIconA(HInst, fileName, -1);
            if (hIcon.Equals(IntPtr.Zero)) return ExtractAssociatedIcon(fileName);

            int numOfIcons = hIcon.ToInt32();
            if (0 <= index && index < numOfIcons)
            {
                hIcon = ExtractIconA(HInst, fileName, index);
                if (hIcon.Equals(IntPtr.Zero)) return null;
                return System.Drawing.Icon.FromHandle(hIcon);
            }
            return null;
        }

        public static System.Drawing.Icon ExtractAssociatedIcon(string fileName)
        {
            if (!System.IO.File.Exists(fileName)) return null;
            int i = 0;

            IntPtr hIcon = ExtractAssociatedIconA(HInst, fileName, ref i);

            if (hIcon.Equals(IntPtr.Zero)) return null;
            return System.Drawing.Icon.FromHandle(hIcon);
        }

        public static System.Drawing.Image GetIconFromFile(string aFilePath)
        {
            System.Drawing.Icon img = ExtractIcon(aFilePath.ToString(), 0);
            return img.ToBitmap();
        }

        public static System.Drawing.Image GetIconByMemoryStream(string aFilePath)
        {
            System.Drawing.Image img = new System.Drawing.Bitmap(aFilePath.ToString());
            System.IO.MemoryStream mStream = new System.IO.MemoryStream();
            img.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
            System.Drawing.Image IconShow = System.Drawing.Image.FromStream(mStream);
            mStream.Close();
            img.Dispose();
            return IconShow;
        }

        public static System.Drawing.Image GetImgFromPic(string aFilePath)
        {
            System.Drawing.Image img = new System.Drawing.Bitmap(aFilePath.ToString());
            return img;
        }

        public static System.Drawing.Icon GetIconFromPic(string aFilePath)
        {
            System.Drawing.Image img = new System.Drawing.Bitmap(aFilePath.ToString());
            System.IO.MemoryStream mStream = new System.IO.MemoryStream();
            img.Save(mStream, System.Drawing.Imaging.ImageFormat.Gif);
            System.Drawing.Icon IconShow = System.Drawing.Icon.FromHandle(new System.Drawing.Bitmap(mStream).GetHicon());
            mStream.Close();
            img.Dispose();
            return IconShow;
        }

        #endregion ICON Tool
    }
}