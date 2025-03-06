using System.Windows.Forms;

namespace One.Formatter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            
            txtInput = new TextBox();
            btnFormat = new Button();
            lblTitle = new Label();
            txtFileName = new TextBox();
            lblFileName = new Label();
            cboFormatType = new ComboBox();
            lblFormatType = new Label();
            txtOutput = new TextBox();
            lblInputTitle = new Label();
            lblOutputTitle = new Label();
            btnSave = new Button();
            
            SuspendLayout();
            
            // 
            // txtInput
            // 
            txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            txtInput.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtInput.Location = new System.Drawing.Point(12, 80);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Both;
            txtInput.Size = new System.Drawing.Size(400, 350);
            txtInput.TabIndex = 1;
            txtInput.WordWrap = false;
            txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            
            // 
            // txtOutput
            // 
            txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            txtOutput.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtOutput.Location = new System.Drawing.Point(428, 80);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Both;
            txtOutput.Size = new System.Drawing.Size(400, 350);
            txtOutput.TabIndex = 2;
            txtOutput.WordWrap = false;
            
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(99)))), ((int)(((byte)(177)))));
            lblTitle.Location = new System.Drawing.Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(200, 25);
            lblTitle.Text = "Multi-Format Parser";
            
            // 
            // cboFormatType
            // 
            cboFormatType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormatType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFormatType.FormattingEnabled = true;
            cboFormatType.Location = new System.Drawing.Point(678, 12);
            cboFormatType.Name = "cboFormatType";
            cboFormatType.Size = new System.Drawing.Size(150, 25);
            cboFormatType.TabIndex = 0;
            cboFormatType.SelectedIndexChanged += new System.EventHandler(this.cboFormatType_SelectedIndexChanged);
            
            // 
            // lblFormatType
            // 
            lblFormatType.AutoSize = true;
            lblFormatType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblFormatType.Location = new System.Drawing.Point(598, 15);
            lblFormatType.Name = "lblFormatType";
            lblFormatType.Size = new System.Drawing.Size(74, 15);
            lblFormatType.Text = "Format Type:";
            
            // 
            // lblInputTitle
            // 
            lblInputTitle.AutoSize = true;
            lblInputTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblInputTitle.Location = new System.Drawing.Point(12, 60);
            lblInputTitle.Name = "lblInputTitle";
            lblInputTitle.Text = "Input";
            
            // 
            // lblOutputTitle
            // 
            lblOutputTitle.AutoSize = true;
            lblOutputTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblOutputTitle.Location = new System.Drawing.Point(428, 60);
            lblOutputTitle.Name = "lblOutputTitle";
            lblOutputTitle.Text = "Formatted Output";
            
            // 
            // btnFormat
            // 
            btnFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            btnFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            btnFormat.FlatAppearance.BorderSize = 0;
            btnFormat.FlatStyle = FlatStyle.Flat;
            btnFormat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFormat.ForeColor = System.Drawing.Color.White;
            btnFormat.Location = new System.Drawing.Point(12, 445);
            btnFormat.Name = "btnFormat";
            btnFormat.Size = new System.Drawing.Size(90, 30);
            btnFormat.Text = "Format";
            btnFormat.UseVisualStyleBackColor = false;
            btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            
            // 
            // btnSave
            // 
            btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(738, 445);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(90, 30);
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // 
            // lblFileName
            // 
            lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            lblFileName.AutoSize = true;
            lblFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblFileName.Location = new System.Drawing.Point(428, 451);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new System.Drawing.Size(71, 17);
            lblFileName.Text = "File Name:";
            lblFileName.Visible = false;
            
            // 
            // txtFileName
            // 
            txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            txtFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFileName.Location = new System.Drawing.Point(505, 448);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new System.Drawing.Size(220, 25);
            txtFileName.TabIndex = 3;
            txtFileName.Visible = false;
            
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(840, 480);
            Controls.Add(txtFileName);
            Controls.Add(lblFileName);
            Controls.Add(btnSave);
            Controls.Add(btnFormat);
            Controls.Add(lblOutputTitle);
            Controls.Add(lblInputTitle);
            Controls.Add(txtOutput);
            Controls.Add(txtInput);
            Controls.Add(cboFormatType);
            Controls.Add(lblFormatType);
            Controls.Add(lblTitle);
            MinimumSize = new System.Drawing.Size(856, 519);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "One.Formatter - Multi-Format Parser";
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            Load += new System.EventHandler(this.Form1_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnFormat;
        private Label lblTitle;
        private TextBox txtFileName;
        private Label lblFileName;
        private ComboBox cboFormatType;
        private Label lblFormatType;
        private TextBox txtOutput;
        private Label lblInputTitle;
        private Label lblOutputTitle;
        private Button btnSave;
    }
}