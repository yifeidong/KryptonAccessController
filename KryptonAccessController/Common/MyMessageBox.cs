﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Resources;
using ComponentFactory.Krypton.Toolkit;

namespace KryptonAccessController.Common
{
    class MyMessageBox
    {
        static public string getStringFromRes(string str)
        {
            /*
            International international = International.getInstance();
            return international.GetString(str);*/
            return str;
        }

        static public DialogResult MessageBoxTextOk(string message)
        {
            string title = getStringFromRes("Title");
            return KryptonMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //return System.Windows.Forms.MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        static public DialogResult MessageBoxTextOkCancel(string message)
        {
            string title = getStringFromRes("Title");
            return KryptonMessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //return System.Windows.Forms.MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        static public DialogResult MessageBoxOK(string message)
        {
            string title = getStringFromRes("Title");
            return KryptonMessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //return System.Windows.Forms.MessageBox.Show(getStringFromRes(message), title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        static public DialogResult MessageBoxOkCancel(string message)
        {
            string title = getStringFromRes("Title");
            return KryptonMessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //return System.Windows.Forms.MessageBox.Show(getStringFromRes(message), title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
