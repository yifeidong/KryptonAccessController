﻿using System;
using System.Data;
using System.Windows.Forms;
using KryptonAccessController.ResourcesFile;
using System.Collections.Generic;
using KryptonAccessController;
using KryptonAccessController.Common;
namespace KryptonAccessController.RelationRealTimeMoni
{
    public partial class FormElectronicMap : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private OpenMode openMode;
        private KryptonAccessController.AccessDataBase.BLL.ElectronicMap bllElectronicMap = new KryptonAccessController.AccessDataBase.BLL.ElectronicMap();
        private KryptonAccessController.AccessDataBase.Model.ElectronicMap modelElectronicMap = new KryptonAccessController.AccessDataBase.Model.ElectronicMap();

        public FormElectronicMap(AccessDataBase.Model.ElectronicMap modelElectronicMap, OpenMode openMode)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Icon = GetResourcesFile.getSystemIco();

            this.openMode = openMode;
            if (modelElectronicMap !=null)
                this.modelElectronicMap = modelElectronicMap;
            initUI();
            if (this.openMode == OpenMode.Add)
            { }
            else if (this.openMode == OpenMode.Update)
            {
                textBoxElectronicMapName.Text = modelElectronicMap.ElectronicMapName;
                textBoxElectronicMapName.Enabled = false;
                List<KryptonAccessController.AccessDataBase.Model.ElectronicMap> listElectronicMap = bllElectronicMap.GetModelList("ElectronicMapName = '" + modelElectronicMap.ElectronicMapName + "'");
                textBoxElectronicMapDes.Text = listElectronicMap[0].ElectronicMapDes;
            }
        }

        private void initUI()
        {

        }

        private void buttonElectrniocOK_Click(object sender, EventArgs e)
        {
            modelElectronicMap.ElectronicMapName = textBoxElectronicMapName.Text.Trim();
            modelElectronicMap.ElectronicMapDes = textBoxElectronicMapDes.Text.Trim();
            
            if (string.IsNullOrEmpty(modelElectronicMap.ElectronicMapName))
            {
                MyMessageBox.MessageBoxOK("textMapNameIsNULL");
                return;
            }
            string pictureFilePath = textBoxElectronicMapPath.Text;
            
            byte[] map = MyImageOperate.getByteByPath(pictureFilePath);
            if (map != null)
                modelElectronicMap.Map = map;

            try
            {
                if (this.openMode == OpenMode.Add)
                {
                    modelElectronicMap.ElectronicMapID = bllElectronicMap.GetMaxId();
                    bllElectronicMap.Add(modelElectronicMap);
                }
                else if (this.openMode == OpenMode.Update)
                    bllElectronicMap.Update(modelElectronicMap);

                this.Close();
            }
            catch
            {
                MyMessageBox.MessageBoxOK("textMapPathIsError");
            }
            
        }

        private void buttonElectronicMapPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            if (FileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxElectronicMapPath.Text = FileDialog.FileName.ToString(); //获得文件路径 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
