namespace Anno_2070_Assistant_2
{
    partial class frmConfig
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
            this.cmbThemes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPopulation = new System.Windows.Forms.TabPage();
            this.optByResidence = new System.Windows.Forms.RadioButton();
            this.optByType = new System.Windows.Forms.RadioButton();
            this.txtResearchers = new System.Windows.Forms.TextBox();
            this.txtTycoonExecutives = new System.Windows.Forms.TextBox();
            this.txtTycoonEngineers = new System.Windows.Forms.TextBox();
            this.imgResearchers = new System.Windows.Forms.PictureBox();
            this.txtLabAssistants = new System.Windows.Forms.TextBox();
            this.txtTycoonEmployees = new System.Windows.Forms.TextBox();
            this.txtTycoonWorkers = new System.Windows.Forms.TextBox();
            this.imgLabAssistants = new System.Windows.Forms.PictureBox();
            this.imgTycoonExecutives = new System.Windows.Forms.PictureBox();
            this.imgTycoonEngineers = new System.Windows.Forms.PictureBox();
            this.imgTycoonEmployees = new System.Windows.Forms.PictureBox();
            this.txtEcoExecutives = new System.Windows.Forms.TextBox();
            this.txtEcoEngineers = new System.Windows.Forms.TextBox();
            this.txtEcoEmployees = new System.Windows.Forms.TextBox();
            this.txtEcoWorkers = new System.Windows.Forms.TextBox();
            this.imgTycoonWorkers = new System.Windows.Forms.PictureBox();
            this.imgEcoExecutives = new System.Windows.Forms.PictureBox();
            this.imgEcoEngineers = new System.Windows.Forms.PictureBox();
            this.imgEcoEmployees = new System.Windows.Forms.PictureBox();
            this.imgEcoWorkers = new System.Windows.Forms.PictureBox();
            this.tabModifications = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpGeneral.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPopulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgResearchers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLabAssistants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTycoonExecutives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTycoonEngineers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTycoonEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTycoonWorkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEcoExecutives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEcoEngineers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEcoEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEcoWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbThemes
            // 
            this.cmbThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThemes.FormattingEnabled = true;
            this.cmbThemes.Items.AddRange(new object[] {
            "Default",
            "Red",
            "Blue",
            "Green",
            "Pink",
            "Black"});
            this.cmbThemes.Location = new System.Drawing.Point(79, 13);
            this.cmbThemes.Name = "cmbThemes";
            this.cmbThemes.Size = new System.Drawing.Size(121, 21);
            this.cmbThemes.TabIndex = 0;
            this.cmbThemes.SelectedIndexChanged += new System.EventHandler(this.cmbThemes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Color Theme";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Anno_2070_Assistant_2.Properties.Resources.accept;
            this.btnSave.Location = new System.Drawing.Point(356, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.TabStop = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.label1);
            this.grpGeneral.Controls.Add(this.cmbThemes);
            this.grpGeneral.Location = new System.Drawing.Point(12, 12);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(208, 42);
            this.grpGeneral.TabIndex = 4;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General Settings";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPopulation);
            this.tabControl1.Controls.Add(this.tabModifications);
            this.tabControl1.Location = new System.Drawing.Point(12, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(388, 246);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPopulation
            // 
            this.tabPopulation.Controls.Add(this.optByResidence);
            this.tabPopulation.Controls.Add(this.optByType);
            this.tabPopulation.Controls.Add(this.txtResearchers);
            this.tabPopulation.Controls.Add(this.txtTycoonExecutives);
            this.tabPopulation.Controls.Add(this.txtTycoonEngineers);
            this.tabPopulation.Controls.Add(this.imgResearchers);
            this.tabPopulation.Controls.Add(this.txtLabAssistants);
            this.tabPopulation.Controls.Add(this.txtTycoonEmployees);
            this.tabPopulation.Controls.Add(this.txtTycoonWorkers);
            this.tabPopulation.Controls.Add(this.imgLabAssistants);
            this.tabPopulation.Controls.Add(this.imgTycoonExecutives);
            this.tabPopulation.Controls.Add(this.imgTycoonEngineers);
            this.tabPopulation.Controls.Add(this.imgTycoonEmployees);
            this.tabPopulation.Controls.Add(this.txtEcoExecutives);
            this.tabPopulation.Controls.Add(this.txtEcoEngineers);
            this.tabPopulation.Controls.Add(this.txtEcoEmployees);
            this.tabPopulation.Controls.Add(this.txtEcoWorkers);
            this.tabPopulation.Controls.Add(this.imgTycoonWorkers);
            this.tabPopulation.Controls.Add(this.imgEcoExecutives);
            this.tabPopulation.Controls.Add(this.imgEcoEngineers);
            this.tabPopulation.Controls.Add(this.imgEcoEmployees);
            this.tabPopulation.Controls.Add(this.imgEcoWorkers);
            this.tabPopulation.Location = new System.Drawing.Point(4, 22);
            this.tabPopulation.Name = "tabPopulation";
            this.tabPopulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPopulation.Size = new System.Drawing.Size(380, 220);
            this.tabPopulation.TabIndex = 0;
            this.tabPopulation.Text = "Population";
            this.tabPopulation.UseVisualStyleBackColor = true;
            // 
            // optByResidence
            // 
            this.optByResidence.AutoSize = true;
            this.optByResidence.Location = new System.Drawing.Point(180, 190);
            this.optByResidence.Name = "optByResidence";
            this.optByResidence.Size = new System.Drawing.Size(91, 17);
            this.optByResidence.TabIndex = 10;
            this.optByResidence.Text = "By Residence";
            this.optByResidence.UseVisualStyleBackColor = true;
            this.optByResidence.CheckedChanged += new System.EventHandler(this.optByResidence_CheckedChanged);
            // 
            // optByType
            // 
            this.optByType.AutoSize = true;
            this.optByType.Location = new System.Drawing.Point(64, 190);
            this.optByType.Name = "optByType";
            this.optByType.Size = new System.Drawing.Size(64, 17);
            this.optByType.TabIndex = 10;
            this.optByType.Text = "By Type";
            this.optByType.UseVisualStyleBackColor = true;
            this.optByType.CheckedChanged += new System.EventHandler(this.optByType_CheckedChanged);
            // 
            // txtResearchers
            // 
            this.txtResearchers.Location = new System.Drawing.Point(292, 164);
            this.txtResearchers.Name = "txtResearchers";
            this.txtResearchers.Size = new System.Drawing.Size(60, 20);
            this.txtResearchers.TabIndex = 9;
            this.txtResearchers.Tag = "Tech Researchers";
            // 
            // txtTycoonExecutives
            // 
            this.txtTycoonExecutives.Location = new System.Drawing.Point(226, 164);
            this.txtTycoonExecutives.Name = "txtTycoonExecutives";
            this.txtTycoonExecutives.Size = new System.Drawing.Size(60, 20);
            this.txtTycoonExecutives.TabIndex = 8;
            this.txtTycoonExecutives.Tag = "Tycoon Executives";
            // 
            // txtTycoonEngineers
            // 
            this.txtTycoonEngineers.Location = new System.Drawing.Point(160, 164);
            this.txtTycoonEngineers.Name = "txtTycoonEngineers";
            this.txtTycoonEngineers.Size = new System.Drawing.Size(60, 20);
            this.txtTycoonEngineers.TabIndex = 7;
            this.txtTycoonEngineers.Tag = "Tycoon Engineers";
            // 
            // imgResearchers
            // 
            this.imgResearchers.Image = global::Anno_2070_Assistant_2.Properties.Resources.Researchers;
            this.imgResearchers.Location = new System.Drawing.Point(292, 98);
            this.imgResearchers.Name = "imgResearchers";
            this.imgResearchers.Size = new System.Drawing.Size(60, 60);
            this.imgResearchers.TabIndex = 21;
            this.imgResearchers.TabStop = false;
            // 
            // txtLabAssistants
            // 
            this.txtLabAssistants.Location = new System.Drawing.Point(292, 72);
            this.txtLabAssistants.Name = "txtLabAssistants";
            this.txtLabAssistants.Size = new System.Drawing.Size(60, 20);
            this.txtLabAssistants.TabIndex = 4;
            this.txtLabAssistants.Tag = "Tech Lab Assistants";
            // 
            // txtTycoonEmployees
            // 
            this.txtTycoonEmployees.Location = new System.Drawing.Point(94, 164);
            this.txtTycoonEmployees.Name = "txtTycoonEmployees";
            this.txtTycoonEmployees.Size = new System.Drawing.Size(60, 20);
            this.txtTycoonEmployees.TabIndex = 6;
            this.txtTycoonEmployees.Tag = "Tycoon Employees";
            // 
            // txtTycoonWorkers
            // 
            this.txtTycoonWorkers.Location = new System.Drawing.Point(28, 164);
            this.txtTycoonWorkers.Name = "txtTycoonWorkers";
            this.txtTycoonWorkers.Size = new System.Drawing.Size(60, 20);
            this.txtTycoonWorkers.TabIndex = 5;
            this.txtTycoonWorkers.Tag = "Tycoon Workers";
            // 
            // imgLabAssistants
            // 
            this.imgLabAssistants.Image = global::Anno_2070_Assistant_2.Properties.Resources.Lab_Assistants;
            this.imgLabAssistants.Location = new System.Drawing.Point(292, 6);
            this.imgLabAssistants.Name = "imgLabAssistants";
            this.imgLabAssistants.Size = new System.Drawing.Size(60, 60);
            this.imgLabAssistants.TabIndex = 17;
            this.imgLabAssistants.TabStop = false;
            // 
            // imgTycoonExecutives
            // 
            this.imgTycoonExecutives.Image = global::Anno_2070_Assistant_2.Properties.Resources.Tycoon_Executives;
            this.imgTycoonExecutives.Location = new System.Drawing.Point(226, 98);
            this.imgTycoonExecutives.Name = "imgTycoonExecutives";
            this.imgTycoonExecutives.Size = new System.Drawing.Size(60, 60);
            this.imgTycoonExecutives.TabIndex = 16;
            this.imgTycoonExecutives.TabStop = false;
            // 
            // imgTycoonEngineers
            // 
            this.imgTycoonEngineers.Image = global::Anno_2070_Assistant_2.Properties.Resources.Tycoon_Engineers;
            this.imgTycoonEngineers.Location = new System.Drawing.Point(160, 98);
            this.imgTycoonEngineers.Name = "imgTycoonEngineers";
            this.imgTycoonEngineers.Size = new System.Drawing.Size(60, 60);
            this.imgTycoonEngineers.TabIndex = 15;
            this.imgTycoonEngineers.TabStop = false;
            // 
            // imgTycoonEmployees
            // 
            this.imgTycoonEmployees.Image = global::Anno_2070_Assistant_2.Properties.Resources.Tycoon_Employees;
            this.imgTycoonEmployees.Location = new System.Drawing.Point(94, 98);
            this.imgTycoonEmployees.Name = "imgTycoonEmployees";
            this.imgTycoonEmployees.Size = new System.Drawing.Size(60, 60);
            this.imgTycoonEmployees.TabIndex = 14;
            this.imgTycoonEmployees.TabStop = false;
            // 
            // txtEcoExecutives
            // 
            this.txtEcoExecutives.Location = new System.Drawing.Point(226, 72);
            this.txtEcoExecutives.Name = "txtEcoExecutives";
            this.txtEcoExecutives.Size = new System.Drawing.Size(60, 20);
            this.txtEcoExecutives.TabIndex = 3;
            this.txtEcoExecutives.Tag = "Eco Executives";
            // 
            // txtEcoEngineers
            // 
            this.txtEcoEngineers.Location = new System.Drawing.Point(160, 72);
            this.txtEcoEngineers.Name = "txtEcoEngineers";
            this.txtEcoEngineers.Size = new System.Drawing.Size(60, 20);
            this.txtEcoEngineers.TabIndex = 2;
            this.txtEcoEngineers.Tag = "Eco Engineers";
            // 
            // txtEcoEmployees
            // 
            this.txtEcoEmployees.Location = new System.Drawing.Point(94, 72);
            this.txtEcoEmployees.Name = "txtEcoEmployees";
            this.txtEcoEmployees.Size = new System.Drawing.Size(60, 20);
            this.txtEcoEmployees.TabIndex = 1;
            this.txtEcoEmployees.Tag = "Eco Employees";
            // 
            // txtEcoWorkers
            // 
            this.txtEcoWorkers.Location = new System.Drawing.Point(28, 72);
            this.txtEcoWorkers.Name = "txtEcoWorkers";
            this.txtEcoWorkers.Size = new System.Drawing.Size(60, 20);
            this.txtEcoWorkers.TabIndex = 0;
            this.txtEcoWorkers.Tag = "Eco Workers";
            // 
            // imgTycoonWorkers
            // 
            this.imgTycoonWorkers.Image = global::Anno_2070_Assistant_2.Properties.Resources.Tycoon_Workers;
            this.imgTycoonWorkers.Location = new System.Drawing.Point(28, 98);
            this.imgTycoonWorkers.Name = "imgTycoonWorkers";
            this.imgTycoonWorkers.Size = new System.Drawing.Size(60, 60);
            this.imgTycoonWorkers.TabIndex = 9;
            this.imgTycoonWorkers.TabStop = false;
            // 
            // imgEcoExecutives
            // 
            this.imgEcoExecutives.Image = global::Anno_2070_Assistant_2.Properties.Resources.Eco_Executives;
            this.imgEcoExecutives.Location = new System.Drawing.Point(226, 6);
            this.imgEcoExecutives.Name = "imgEcoExecutives";
            this.imgEcoExecutives.Size = new System.Drawing.Size(60, 60);
            this.imgEcoExecutives.TabIndex = 8;
            this.imgEcoExecutives.TabStop = false;
            // 
            // imgEcoEngineers
            // 
            this.imgEcoEngineers.Image = global::Anno_2070_Assistant_2.Properties.Resources.Eco_Engineers;
            this.imgEcoEngineers.Location = new System.Drawing.Point(160, 6);
            this.imgEcoEngineers.Name = "imgEcoEngineers";
            this.imgEcoEngineers.Size = new System.Drawing.Size(60, 60);
            this.imgEcoEngineers.TabIndex = 7;
            this.imgEcoEngineers.TabStop = false;
            // 
            // imgEcoEmployees
            // 
            this.imgEcoEmployees.Image = global::Anno_2070_Assistant_2.Properties.Resources.Eco_Employees;
            this.imgEcoEmployees.Location = new System.Drawing.Point(94, 6);
            this.imgEcoEmployees.Name = "imgEcoEmployees";
            this.imgEcoEmployees.Size = new System.Drawing.Size(60, 60);
            this.imgEcoEmployees.TabIndex = 6;
            this.imgEcoEmployees.TabStop = false;
            // 
            // imgEcoWorkers
            // 
            this.imgEcoWorkers.Image = global::Anno_2070_Assistant_2.Properties.Resources.Eco_Workers;
            this.imgEcoWorkers.Location = new System.Drawing.Point(28, 6);
            this.imgEcoWorkers.Name = "imgEcoWorkers";
            this.imgEcoWorkers.Size = new System.Drawing.Size(60, 60);
            this.imgEcoWorkers.TabIndex = 5;
            this.imgEcoWorkers.TabStop = false;
            // 
            // tabModifications
            // 
            this.tabModifications.Location = new System.Drawing.Point(4, 22);
            this.tabModifications.Name = "tabModifications";
            this.tabModifications.Padding = new System.Windows.Forms.Padding(3);
            this.tabModifications.Size = new System.Drawing.Size(380, 220);
            this.tabModifications.TabIndex = 1;
            this.tabModifications.Text = "Modifications";
            this.tabModifications.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Anno_2070_Assistant_2.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(310, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(40, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.TabStop = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 318);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Civilization Configuration";
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPopulation.ResumeLayout(false);
            this.tabPopulation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgResearchers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLabAssistants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTycoonExecutives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTycoonEngineers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTycoonEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTycoonWorkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEcoExecutives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEcoEngineers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEcoEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEcoWorkers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbThemes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.PictureBox imgEcoWorkers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPopulation;
        private System.Windows.Forms.TextBox txtResearchers;
        private System.Windows.Forms.TextBox txtTycoonExecutives;
        private System.Windows.Forms.TextBox txtTycoonEngineers;
        private System.Windows.Forms.PictureBox imgResearchers;
        private System.Windows.Forms.TextBox txtLabAssistants;
        private System.Windows.Forms.TextBox txtTycoonEmployees;
        private System.Windows.Forms.TextBox txtTycoonWorkers;
        private System.Windows.Forms.PictureBox imgLabAssistants;
        private System.Windows.Forms.PictureBox imgTycoonExecutives;
        private System.Windows.Forms.PictureBox imgTycoonEngineers;
        private System.Windows.Forms.PictureBox imgTycoonEmployees;
        private System.Windows.Forms.TextBox txtEcoExecutives;
        private System.Windows.Forms.TextBox txtEcoEngineers;
        private System.Windows.Forms.TextBox txtEcoEmployees;
        private System.Windows.Forms.TextBox txtEcoWorkers;
        private System.Windows.Forms.PictureBox imgTycoonWorkers;
        private System.Windows.Forms.PictureBox imgEcoExecutives;
        private System.Windows.Forms.PictureBox imgEcoEngineers;
        private System.Windows.Forms.PictureBox imgEcoEmployees;
        private System.Windows.Forms.TabPage tabModifications;
        private System.Windows.Forms.RadioButton optByResidence;
        private System.Windows.Forms.RadioButton optByType;
    }
}