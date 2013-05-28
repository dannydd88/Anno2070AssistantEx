namespace Anno_2070_Assistant_2
{
    partial class frmLayouts
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
            this.optEcos = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.optTycoons = new System.Windows.Forms.RadioButton();
            this.optTechs = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBuilding = new System.Windows.Forms.GroupBox();
            this.cmbBuilding = new System.Windows.Forms.ComboBox();
            this.grpHousing = new System.Windows.Forms.GroupBox();
            this.cmbHousing = new System.Windows.Forms.ComboBox();
            this.imgLayout = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpType.SuspendLayout();
            this.grpBuilding.SuspendLayout();
            this.grpHousing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLayout)).BeginInit();
            this.SuspendLayout();
            // 
            // optEcos
            // 
            this.optEcos.Checked = true;
            this.optEcos.Image = global::Anno_2070_Assistant_2.Properties.Resources.icon_27_99;
            this.optEcos.Location = new System.Drawing.Point(6, 19);
            this.optEcos.Name = "optEcos";
            this.optEcos.Size = new System.Drawing.Size(60, 50);
            this.optEcos.TabIndex = 0;
            this.optEcos.TabStop = true;
            this.optEcos.UseVisualStyleBackColor = true;
            this.optEcos.CheckedChanged += new System.EventHandler(this.optEcos_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tycoons";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Techs";
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.optEcos);
            this.grpType.Controls.Add(this.label3);
            this.grpType.Controls.Add(this.optTycoons);
            this.grpType.Controls.Add(this.label2);
            this.grpType.Controls.Add(this.optTechs);
            this.grpType.Controls.Add(this.label1);
            this.grpType.Location = new System.Drawing.Point(12, 12);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(136, 195);
            this.grpType.TabIndex = 6;
            this.grpType.TabStop = false;
            this.grpType.Text = "Type";
            // 
            // optTycoons
            // 
            this.optTycoons.Image = global::Anno_2070_Assistant_2.Properties.Resources.icon_27_100;
            this.optTycoons.Location = new System.Drawing.Point(6, 75);
            this.optTycoons.Name = "optTycoons";
            this.optTycoons.Size = new System.Drawing.Size(60, 50);
            this.optTycoons.TabIndex = 1;
            this.optTycoons.UseVisualStyleBackColor = true;
            this.optTycoons.CheckedChanged += new System.EventHandler(this.optTycoons_CheckedChanged);
            // 
            // optTechs
            // 
            this.optTechs.Image = global::Anno_2070_Assistant_2.Properties.Resources.icon_27_101;
            this.optTechs.Location = new System.Drawing.Point(6, 131);
            this.optTechs.Name = "optTechs";
            this.optTechs.Size = new System.Drawing.Size(60, 50);
            this.optTechs.TabIndex = 2;
            this.optTechs.UseVisualStyleBackColor = true;
            this.optTechs.CheckedChanged += new System.EventHandler(this.optTechs_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ecos";
            // 
            // grpBuilding
            // 
            this.grpBuilding.Controls.Add(this.cmbBuilding);
            this.grpBuilding.Location = new System.Drawing.Point(12, 213);
            this.grpBuilding.Name = "grpBuilding";
            this.grpBuilding.Size = new System.Drawing.Size(136, 54);
            this.grpBuilding.TabIndex = 7;
            this.grpBuilding.TabStop = false;
            this.grpBuilding.Text = "Building Layouts";
            // 
            // cmbBuilding
            // 
            this.cmbBuilding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuilding.FormattingEnabled = true;
            this.cmbBuilding.Location = new System.Drawing.Point(6, 19);
            this.cmbBuilding.Name = "cmbBuilding";
            this.cmbBuilding.Size = new System.Drawing.Size(121, 21);
            this.cmbBuilding.TabIndex = 8;
            this.cmbBuilding.SelectedIndexChanged += new System.EventHandler(this.cmbBuilding_SelectedIndexChanged);
            // 
            // grpHousing
            // 
            this.grpHousing.Controls.Add(this.cmbHousing);
            this.grpHousing.Location = new System.Drawing.Point(12, 273);
            this.grpHousing.Name = "grpHousing";
            this.grpHousing.Size = new System.Drawing.Size(136, 54);
            this.grpHousing.TabIndex = 10;
            this.grpHousing.TabStop = false;
            this.grpHousing.Text = "Housing Layouts";
            // 
            // cmbHousing
            // 
            this.cmbHousing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHousing.FormattingEnabled = true;
            this.cmbHousing.Location = new System.Drawing.Point(6, 19);
            this.cmbHousing.Name = "cmbHousing";
            this.cmbHousing.Size = new System.Drawing.Size(121, 21);
            this.cmbHousing.TabIndex = 9;
            this.cmbHousing.SelectedIndexChanged += new System.EventHandler(this.cmbHousing_SelectedIndexChanged);
            // 
            // imgLayout
            // 
            this.imgLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgLayout.Location = new System.Drawing.Point(154, 12);
            this.imgLayout.Name = "imgLayout";
            this.imgLayout.Size = new System.Drawing.Size(500, 500);
            this.imgLayout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLayout.TabIndex = 9;
            this.imgLayout.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Anno_2070_Assistant_2.Properties.Resources.accept;
            this.btnClose.Location = new System.Drawing.Point(12, 333);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLayouts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 736);
            this.ControlBox = false;
            this.Controls.Add(this.grpHousing);
            this.Controls.Add(this.imgLayout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpBuilding);
            this.Controls.Add(this.grpType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmLayouts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Building Layouts";
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.grpBuilding.ResumeLayout(false);
            this.grpHousing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLayout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optEcos;
        private System.Windows.Forms.RadioButton optTycoons;
        private System.Windows.Forms.RadioButton optTechs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.GroupBox grpBuilding;
        private System.Windows.Forms.ComboBox cmbBuilding;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox imgLayout;
        private System.Windows.Forms.GroupBox grpHousing;
        private System.Windows.Forms.ComboBox cmbHousing;
    }
}