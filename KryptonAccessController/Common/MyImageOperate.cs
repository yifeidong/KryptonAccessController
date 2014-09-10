﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace KryptonAccessController.Common
{
    static class MyImageOperate
    {
        public static byte[] getByteByImage(Image Pic)
        {
            if (Pic != null)
            {
                MemoryStream sf = new MemoryStream();
                Pic.Save(sf, ImageFormat.Bmp);
                int length = (int)sf.Length;

                byte[] buffer = sf.ToArray();
                sf.Close();
                return buffer;
            }
            else
                return null;
        }

        public static Bitmap getImageByByte(byte[] bytes)
        {
            if (bytes != null)
            {
                MemoryStream ms = new MemoryStream(bytes);   //将字节数组存入到二进制流中
                return new Bitmap(ms);
            }
            else
            {
                return null;
            }
        }
        public static Image scaleImage(Image img, double scale)
        {

            System.Drawing.Bitmap objPic, objNewPic;
            try
            {
                objPic = new System.Drawing.Bitmap(img);
                double doubleHeight = objPic.Height * scale;
                double doubleWidth = objPic.Width * scale;

                objNewPic = new System.Drawing.Bitmap(objPic, Convert.ToInt32(doubleWidth), Convert.ToInt32(doubleHeight));
            }
            catch
            {
                objNewPic = null;
            }
            return objNewPic;
        }
        public static byte[] getByteByPath(string path)
        {
            FileStream sf1 = new FileStream(path, FileMode.Open);
            int length = (int)sf1.Length;
            byte[] buffer = new byte[length];

            sf1.Read(buffer, 0, length);
            sf1.Close();
            return buffer;
        }
    }

}
