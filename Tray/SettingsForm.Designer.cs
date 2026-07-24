namespace scalecloud_scale_agent.Tray
{
    partial class SettingsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkEnabled1 = new System.Windows.Forms.CheckBox();
            this.chkEnabled2 = new System.Windows.Forms.CheckBox();
            this.cmbPort1 = new System.Windows.Forms.ComboBox();
            this.cmbPort2 = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate1 = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate2 = new System.Windows.Forms.ComboBox();
            this.cmbProtocol1 = new System.Windows.Forms.ComboBox();
            this.cmbProtocol2 = new System.Windows.Forms.ComboBox();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.bascule1_title = new System.Windows.Forms.Label();
            this.bascule2_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 262);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bascule1_title);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbProtocol1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbBaudRate1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbPort1);
            this.splitContainer1.Panel1.Controls.Add(this.chkEnabled1);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bascule2_title);
            this.splitContainer1.Panel2.Controls.Add(this.lblStatus2);
            this.splitContainer1.Panel2.Controls.Add(this.cmbProtocol2);
            this.splitContainer1.Panel2.Controls.Add(this.cmbBaudRate2);
            this.splitContainer1.Panel2.Controls.Add(this.cmbPort2);
            this.splitContainer1.Panel2.Controls.Add(this.chkEnabled2);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.splitContainer1.Size = new System.Drawing.Size(316, 193);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 0;
            // 
            // chkEnabled1
            // 
            this.chkEnabled1.AutoSize = true;
            this.chkEnabled1.Location = new System.Drawing.Point(9, 62);
            this.chkEnabled1.Name = "chkEnabled1";
            this.chkEnabled1.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled1.TabIndex = 0;
            this.chkEnabled1.Text = "Enabled";
            this.chkEnabled1.UseVisualStyleBackColor = true;
            
            // 
            // chkEnabled2
            // 
            this.chkEnabled2.AutoSize = true;
            this.chkEnabled2.Location = new System.Drawing.Point(3, 62);
            this.chkEnabled2.Name = "chkEnabled2";
            this.chkEnabled2.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled2.TabIndex = 1;
            this.chkEnabled2.Text = "Enabled";
            this.chkEnabled2.UseVisualStyleBackColor = true;
            // 
            // cmbPort1
            // 
            this.cmbPort1.FormattingEnabled = true;
            this.cmbPort1.Location = new System.Drawing.Point(9, 85);
            this.cmbPort1.Name = "cmbPort1";
            this.cmbPort1.Size = new System.Drawing.Size(121, 21);
            this.cmbPort1.TabIndex = 1;
            this.cmbPort1.Text = "COM Port";
            // 
            // cmbPort2
            // 
            this.cmbPort2.FormattingEnabled = true;
            this.cmbPort2.Location = new System.Drawing.Point(3, 85);
            this.cmbPort2.Name = "cmbPort2";
            this.cmbPort2.Size = new System.Drawing.Size(121, 21);
            this.cmbPort2.TabIndex = 2;
            this.cmbPort2.Text = "COM Port";
            // 
            // cmbBaudRate1
            // 
            this.cmbBaudRate1.FormattingEnabled = true;
            this.cmbBaudRate1.Location = new System.Drawing.Point(9, 112);
            this.cmbBaudRate1.Name = "cmbBaudRate1";
            this.cmbBaudRate1.Size = new System.Drawing.Size(121, 21);
            this.cmbBaudRate1.TabIndex = 2;
            this.cmbBaudRate1.Text = "BaudRate";
            // 
            // cmbBaudRate2
            // 
            this.cmbBaudRate2.FormattingEnabled = true;
            this.cmbBaudRate2.Location = new System.Drawing.Point(3, 112);
            this.cmbBaudRate2.Name = "cmbBaudRate2";
            this.cmbBaudRate2.Size = new System.Drawing.Size(121, 21);
            this.cmbBaudRate2.TabIndex = 3;
            this.cmbBaudRate2.Text = "BaudRate";
            // 
            // cmbProtocol1
            // 
            this.cmbProtocol1.FormattingEnabled = true;
            this.cmbProtocol1.Location = new System.Drawing.Point(9, 139);
            this.cmbProtocol1.Name = "cmbProtocol1";
            this.cmbProtocol1.Size = new System.Drawing.Size(121, 21);
            this.cmbProtocol1.TabIndex = 3;
            this.cmbProtocol1.Text = "Protocol";
            // 
            // cmbProtocol2
            // 
            this.cmbProtocol2.FormattingEnabled = true;
            this.cmbProtocol2.Location = new System.Drawing.Point(3, 139);
            this.cmbProtocol2.Name = "cmbProtocol2";
            this.cmbProtocol2.Size = new System.Drawing.Size(121, 21);
            this.cmbProtocol2.TabIndex = 4;
            this.cmbProtocol2.Text = "Protocol";
            // 
            // lblStatus1
            // 
            this.lblStatus1.AutoSize = true;
            this.lblStatus1.Location = new System.Drawing.Point(9, 163);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(37, 13);
            this.lblStatus1.TabIndex = 4;
            this.lblStatus1.Text = "Status";
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = true;
            this.lblStatus2.Location = new System.Drawing.Point(3, 163);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(37, 13);
            this.lblStatus2.TabIndex = 5;
            this.lblStatus2.Text = "Status";
            // 
            // bascule1_title
            // 
            this.bascule1_title.AutoSize = true;
            this.bascule1_title.Location = new System.Drawing.Point(45, 26);
            this.bascule1_title.Name = "bascule1_title";
            this.bascule1_title.Size = new System.Drawing.Size(51, 13);
            this.bascule1_title.TabIndex = 5;
            this.bascule1_title.Text = "Bascule1";
            // 
            // bascule2_title
            // 
            this.bascule2_title.AutoSize = true;
            this.bascule2_title.Location = new System.Drawing.Point(59, 26);
            this.bascule2_title.Name = "bascule2_title";
            this.bascule2_title.Size = new System.Drawing.Size(51, 13);
            this.bascule2_title.TabIndex = 6;
            this.bascule2_title.Text = "Bascule2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 57);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(12, 25);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(221, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScaleCloud Scale Agent";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.Load +=new System.EventHandler(
this.SettingsForm_Load);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbBaudRate1;
        private System.Windows.Forms.ComboBox cmbPort1;
        private System.Windows.Forms.CheckBox chkEnabled1;
        private System.Windows.Forms.ComboBox cmbBaudRate2;
        private System.Windows.Forms.ComboBox cmbPort2;
        private System.Windows.Forms.CheckBox chkEnabled2;
        private System.Windows.Forms.Label bascule1_title;
        private System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.ComboBox cmbProtocol1;
        private System.Windows.Forms.Label bascule2_title;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.ComboBox cmbProtocol2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSave;
    }
}