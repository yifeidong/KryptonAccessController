using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using KryptonAccessController.WidgetThread;

namespace KryptonAccessController.RelationDepartment
{
    public partial class DepartmentInfo : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        AccessDataBase.BLL.DepartmentInfo bllDepartment = new AccessDataBase.BLL.DepartmentInfo();
        AccessDataBase.Model.DepartmentInfo modelDepartment = new AccessDataBase.Model.DepartmentInfo();

        private static object obj = new object();
        static DepartmentInfo _instance = null;
        public static DepartmentInfo getInstance()
        {
            if (_instance == null)
            {
                lock (obj)
                {
                    if (_instance == null)
                    {
                        _instance = new DepartmentInfo();
                    }
                }
            }
            return _instance;
        }

        public DepartmentInfo()
        {
            InitializeComponent();

            initToolStripMenu();
            refreshDataGridView();
        }
        public void initToolStripMenu()
        {
            toolStripDepartment.Items.Clear();
            ImageOperate.AddButtonItemToToolStrip(toolStripDepartment, "add.BMP", "Add", toolStripButtonAddDepartmentInfo_Click);
            ImageOperate.AddButtonItemToToolStrip(toolStripDepartment, "update.BMP", "Update", toolStripButtonUpdateDepartmentInfo_Click);
            ImageOperate.AddButtonItemToToolStrip(toolStripDepartment, "delete.BMP", "Del", toolStripButtonDeleteDepartmentInfo_Click);

        }
        public void refreshDataGridView()
        {
            DataTable dt = bllDepartment.GetAllList().Tables[0];
            kryptonDataGridViewDepartment.DataSource = dt;

        }
        private void toolStripButtonAddDepartmentInfo_Click(object sender, EventArgs e)
        {
            AccessDataBase.Model.DepartmentInfo modeDepartmentInfo = new AccessDataBase.Model.DepartmentInfo();
            AccessDataBase.BLL.DepartmentInfo bllDepartmentInfo = new AccessDataBase.BLL.DepartmentInfo();

            modeDepartmentInfo.DepartmentID = bllDepartmentInfo.GetMaxId();

            FormDepartment formCompany = new FormDepartment(modeDepartmentInfo, OpenMode.Add);
            formCompany.ShowDialog();
            this.refreshDataGridView();
        }

        private void toolStripButtonUpdateDepartmentInfo_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridViewDepartment.CurrentRow == null)
                return;

            AccessDataBase.BLL.DepartmentInfo bllDepartmentInfo = new AccessDataBase.BLL.DepartmentInfo();

            int selectIndex = kryptonDataGridViewDepartment.CurrentRow.Index;
            string departmentID = kryptonDataGridViewDepartment["DepartmentID", selectIndex].Value.ToString().Trim();

            AccessDataBase.Model.DepartmentInfo modeDepartmentInfo = bllDepartmentInfo.GetModel(int.Parse(departmentID));

            FormDepartment formDepartment = new FormDepartment(modeDepartmentInfo, OpenMode.Update);
            formDepartment.ShowDialog();

            this.refreshDataGridView();
        }

        private void toolStripButtonDeleteDepartmentInfo_Click(object sender, EventArgs e)
        {
            this.refreshDataGridView();
        }
    }
}