namespace KryptonAccessController.RelationDepartment
{
    partial class CompanyInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonDataGridViewCompany = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.toolStripCompany = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridViewCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.kryptonDataGridViewCompany);
            this.kryptonPanel.Controls.Add(this.toolStripCompany);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(292, 246);
            this.kryptonPanel.TabIndex = 0;
            // 
            // kryptonDataGridViewCompany
            // 
            this.kryptonDataGridViewCompany.AllowUserToAddRows = false;
            this.kryptonDataGridViewCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridViewCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridViewCompany.Location = new System.Drawing.Point(0, 25);
            this.kryptonDataGridViewCompany.Name = "kryptonDataGridViewCompany";
            this.kryptonDataGridViewCompany.ReadOnly = true;
            this.kryptonDataGridViewCompany.RowTemplate.Height = 23;
            this.kryptonDataGridViewCompany.Size = new System.Drawing.Size(292, 221);
            this.kryptonDataGridViewCompany.TabIndex = 1;
            // 
            // toolStripCompany
            // 
            this.toolStripCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripCompany.Location = new System.Drawing.Point(0, 0);
            this.toolStripCompany.Name = "toolStripCompany";
            this.toolStripCompany.Size = new System.Drawing.Size(292, 25);
            this.toolStripCompany.TabIndex = 0;
            this.toolStripCompany.Text = "toolStrip1";
            // 
            // CompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 246);
            this.Controls.Add(this.kryptonPanel);
            this.Name = "CompanyInfo";
            this.Text = "CompanyInfo";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridViewCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private System.Windows.Forms.ToolStrip toolStripCompany;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridViewCompany;
    }
}

