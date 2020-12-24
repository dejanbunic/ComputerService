namespace ComputerService
{
    partial class ServiceSheetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceSheetForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.updateServiceSheetButton = new System.Windows.Forms.Button();
            this.deleteServiceSheet = new System.Windows.Forms.Button();
            this.addServiceSheetButton = new System.Windows.Forms.Button();
            this.serviceSheetGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appearanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.serbianToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameServiceSheet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceSheetGridView)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.serviceSheetGridView, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.updateServiceSheetButton, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.deleteServiceSheet, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.addServiceSheetButton, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // updateServiceSheetButton
            // 
            resources.ApplyResources(this.updateServiceSheetButton, "updateServiceSheetButton");
            this.updateServiceSheetButton.Name = "updateServiceSheetButton";
            this.updateServiceSheetButton.UseVisualStyleBackColor = true;
            this.updateServiceSheetButton.Click += new System.EventHandler(this.updateServiceSheetButton_Click);
            // 
            // deleteServiceSheet
            // 
            resources.ApplyResources(this.deleteServiceSheet, "deleteServiceSheet");
            this.deleteServiceSheet.Name = "deleteServiceSheet";
            this.deleteServiceSheet.UseVisualStyleBackColor = true;
            this.deleteServiceSheet.Click += new System.EventHandler(this.deleteServiceSheet_Click);
            // 
            // addServiceSheetButton
            // 
            resources.ApplyResources(this.addServiceSheetButton, "addServiceSheetButton");
            this.addServiceSheetButton.Name = "addServiceSheetButton";
            this.addServiceSheetButton.UseVisualStyleBackColor = true;
            this.addServiceSheetButton.Click += new System.EventHandler(this.addServiceSheetButton_Click);
            // 
            // serviceSheetGridView
            // 
            this.serviceSheetGridView.AllowUserToAddRows = false;
            this.serviceSheetGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.serviceSheetGridView, "serviceSheetGridView");
            this.serviceSheetGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.serviceSheetGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.serviceSheetGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceSheetGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NameServiceSheet,
            this.PhoneNumber,
            this.Email,
            this.ProductNumber,
            this.Type,
            this.Manufacturer,
            this.Seria,
            this.Date,
            this.Description,
            this.Status,
            this.Price});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.serviceSheetGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.serviceSheetGridView.Name = "serviceSheetGridView";
            this.serviceSheetGridView.ReadOnly = true;
            this.serviceSheetGridView.RowTemplate.Height = 24;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CausesValidation = false;
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.componentsToolStripMenuItem,
            this.servicesToolStripMenuItem,
            this.serviceSheetToolStripMenuItem,
            this.appearanceToolStripMenuItem,
            this.languageToolStripMenuItem1,
            this.logoutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            resources.ApplyResources(this.homeToolStripMenuItem, "homeToolStripMenuItem");
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // componentsToolStripMenuItem
            // 
            this.componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            resources.ApplyResources(this.componentsToolStripMenuItem, "componentsToolStripMenuItem");
            this.componentsToolStripMenuItem.Click += new System.EventHandler(this.componentsToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            resources.ApplyResources(this.servicesToolStripMenuItem, "servicesToolStripMenuItem");
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.servicesToolStripMenuItem_Click);
            // 
            // serviceSheetToolStripMenuItem
            // 
            this.serviceSheetToolStripMenuItem.Name = "serviceSheetToolStripMenuItem";
            resources.ApplyResources(this.serviceSheetToolStripMenuItem, "serviceSheetToolStripMenuItem");
            this.serviceSheetToolStripMenuItem.Click += new System.EventHandler(this.serviceSheetToolStripMenuItem_Click);
            // 
            // appearanceToolStripMenuItem
            // 
            this.appearanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkThemeToolStripMenuItem,
            this.lightThemeToolStripMenuItem,
            this.blueThemeToolStripMenuItem});
            this.appearanceToolStripMenuItem.Name = "appearanceToolStripMenuItem";
            resources.ApplyResources(this.appearanceToolStripMenuItem, "appearanceToolStripMenuItem");
            // 
            // darkThemeToolStripMenuItem
            // 
            this.darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
            resources.ApplyResources(this.darkThemeToolStripMenuItem, "darkThemeToolStripMenuItem");
            this.darkThemeToolStripMenuItem.Click += new System.EventHandler(this.darkThemeToolStripMenuItem_Click);
            // 
            // lightThemeToolStripMenuItem
            // 
            this.lightThemeToolStripMenuItem.Name = "lightThemeToolStripMenuItem";
            resources.ApplyResources(this.lightThemeToolStripMenuItem, "lightThemeToolStripMenuItem");
            this.lightThemeToolStripMenuItem.Click += new System.EventHandler(this.lightThemeToolStripMenuItem_Click);
            // 
            // blueThemeToolStripMenuItem
            // 
            this.blueThemeToolStripMenuItem.Name = "blueThemeToolStripMenuItem";
            resources.ApplyResources(this.blueThemeToolStripMenuItem, "blueThemeToolStripMenuItem");
            this.blueThemeToolStripMenuItem.Click += new System.EventHandler(this.blueThemeToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem1
            // 
            this.languageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem1,
            this.serbianToolStripMenuItem1});
            this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
            resources.ApplyResources(this.languageToolStripMenuItem1, "languageToolStripMenuItem1");
            // 
            // englishToolStripMenuItem1
            // 
            this.englishToolStripMenuItem1.Name = "englishToolStripMenuItem1";
            resources.ApplyResources(this.englishToolStripMenuItem1, "englishToolStripMenuItem1");
            this.englishToolStripMenuItem1.Click += new System.EventHandler(this.englishToolStripMenuItem1_Click);
            // 
            // serbianToolStripMenuItem1
            // 
            this.serbianToolStripMenuItem1.Name = "serbianToolStripMenuItem1";
            resources.ApplyResources(this.serbianToolStripMenuItem1, "serbianToolStripMenuItem1");
            this.serbianToolStripMenuItem1.Click += new System.EventHandler(this.serbianToolStripMenuItem1_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            resources.ApplyResources(this.logoutToolStripMenuItem, "logoutToolStripMenuItem");
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Id
            // 
            resources.ApplyResources(this.Id, "Id");
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // NameServiceSheet
            // 
            resources.ApplyResources(this.NameServiceSheet, "NameServiceSheet");
            this.NameServiceSheet.Name = "NameServiceSheet";
            this.NameServiceSheet.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            resources.ApplyResources(this.PhoneNumber, "PhoneNumber");
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            // 
            // Email
            // 
            resources.ApplyResources(this.Email, "Email");
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // ProductNumber
            // 
            resources.ApplyResources(this.ProductNumber, "ProductNumber");
            this.ProductNumber.Name = "ProductNumber";
            this.ProductNumber.ReadOnly = true;
            // 
            // Type
            // 
            resources.ApplyResources(this.Type, "Type");
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Manufacturer
            // 
            resources.ApplyResources(this.Manufacturer, "Manufacturer");
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.ReadOnly = true;
            // 
            // Seria
            // 
            resources.ApplyResources(this.Seria, "Seria");
            this.Seria.Name = "Seria";
            this.Seria.ReadOnly = true;
            // 
            // Date
            // 
            resources.ApplyResources(this.Date, "Date");
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Description
            // 
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Status
            // 
            resources.ApplyResources(this.Status, "Status");
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Price
            // 
            resources.ApplyResources(this.Price, "Price");
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // ServiceSheetForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ServiceSheetForm";
            this.Load += new System.EventHandler(this.ServiceSheet_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serviceSheetGridView)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button updateServiceSheetButton;
        private System.Windows.Forms.Button deleteServiceSheet;
        private System.Windows.Forms.Button addServiceSheetButton;
        private System.Windows.Forms.DataGridView serviceSheetGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem appearanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueThemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem serbianToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameServiceSheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}