﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using KryptonAccessController.OperationFile;

namespace KryptonAccessController.WidgetThread
{
    class ImageOperate
    {
        public static void DrawStringToPictureBox(Image Img, string str, System.Drawing.Font Var_Font)
        {
            Graphics g = null;
            g = Graphics.FromImage(Img);
            Brush Var_Brush = new SolidBrush(Color.Red);
            System.Drawing.Point location = new System.Drawing.Point(25, 6);
            g.DrawString(str, Var_Font, Var_Brush, location);
        }
        /// <summary>
        /// 向工具栏添加按钮项
        /// </summary>
        /// <param name="toolstrip">工具栏名</param>
        /// <param name="Imagepath">图像路径</param>
        /// <param name="buttonname">工具栏按钮名</param>
        /// <param name="clickeven">单击时触发的事件</param>
        public static void AddButtonItemToToolStrip(ToolStrip toolstrip, string imageName, string buttonname, EventHandler clickeven)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (IniFile.getStartUpLanguage() != "English")
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"ToolStripImage_English\";
            }
            else
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"ToolStripImage_Chinese\";
            }
            path = path + imageName;

            Image img = Image.FromFile(path);
            ToolStripButton tsb = new ToolStripButton(buttonname, img);
            tsb.Name = buttonname;

            tsb.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsb.ImageScaling = ToolStripItemImageScaling.None;
            tsb.Click += new EventHandler(clickeven);
            toolstrip.Items.Add(tsb);
        }
        /// <summary>
        /// 修改该工具栏
        /// </summary>
        /// <param name="toolstrip">工具栏名</param>
        /// <param name="Imagepath">图像路径</param>
        /// <param name="buttonname">工具栏按钮名</param>
        /// <param name="clickeven">单击时触发的事件</param>
        public static void UpdateButtonItemToToolStrip(ToolStrip toolstrip,int item, string imageName,string buttonname)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (IniFile.getStartUpLanguage() != "English")
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"ToolStripImage_English\";
            }
            else
            {
                path = AppDomain.CurrentDomain.BaseDirectory + @"ToolStripImage_Chinese\";
            }
            path = path + imageName;
            Image img = Image.FromFile(path);
            toolstrip.Items[item].Image = img;
            toolstrip.Items[item].Text = buttonname;

        }
        public static int findStringInArrary(string[] sourceString, string destinationString)
        {
            int index = 0;
            //index = sourceString.Contains(destinationString);
            foreach (string str in sourceString)
            {
                if (str == destinationString)
                    break;
                else
                    index++;
            }
            return index;

        }
        public static void AddComboBoxItemToToolStrip(ToolStrip toolstrip, string[] items, string comboboxname, EventHandler clickeven)
        {
            ToolStripComboBox tscb = new ToolStripComboBox(comboboxname);
            tscb.Width = 25;
            foreach (string item in items)
            {
                tscb.Items.Add(item);
            }
            tscb.TextChanged += new EventHandler(clickeven);
            try
            {
                tscb.SelectedIndex = findStringInArrary(items, "100%");
            }
            catch
            {
                tscb.SelectedIndex = 0;
            }
            toolstrip.Items.Add(tscb);
        }
    }
}
