namespace WinFormClient
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxAnalysisType = new System.Windows.Forms.ComboBox();
            this.textBoxProjectDirectory = new System.Windows.Forms.TextBox();
            this.labelProjectDirectory = new System.Windows.Forms.Label();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxAnalysisType);
            this.panel1.Controls.Add(this.textBoxProjectDirectory);
            this.panel1.Controls.Add(this.labelProjectDirectory);
            this.panel1.Controls.Add(this.buttonAnalyze);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 101);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxAnalysisType
            // 
            this.comboBoxAnalysisType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnalysisType.FormattingEnabled = true;
            this.comboBoxAnalysisType.Location = new System.Drawing.Point(12, 12);
            this.comboBoxAnalysisType.Name = "comboBoxAnalysisType";
            this.comboBoxAnalysisType.Size = new System.Drawing.Size(333, 21);
            this.comboBoxAnalysisType.TabIndex = 0;
            // 
            // textBoxProjectDirectory
            // 
            this.textBoxProjectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProjectDirectory.Location = new System.Drawing.Point(128, 50);
            this.textBoxProjectDirectory.Name = "textBoxProjectDirectory";
            this.textBoxProjectDirectory.Size = new System.Drawing.Size(524, 20);
            this.textBoxProjectDirectory.TabIndex = 3;
            // 
            // labelProjectDirectory
            // 
            this.labelProjectDirectory.AutoSize = true;
            this.labelProjectDirectory.Location = new System.Drawing.Point(12, 53);
            this.labelProjectDirectory.Name = "labelProjectDirectory";
            this.labelProjectDirectory.Size = new System.Drawing.Size(85, 13);
            this.labelProjectDirectory.TabIndex = 2;
            this.labelProjectDirectory.Text = "Project Directory";
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(364, 12);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(75, 23);
            this.buttonAnalyze.TabIndex = 1;
            this.buttonAnalyze.Text = "Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 101);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(664, 286);
            this.treeView.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 387);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Reference Analyzer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxProjectDirectory;
        private System.Windows.Forms.Label labelProjectDirectory;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ComboBox comboBoxAnalysisType;
    }
}

