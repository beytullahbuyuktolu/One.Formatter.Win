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
            txtInput = new TextBox();
            btnFormat = new Button();
            lblTitle = new Label();
            lblInstructions = new Label();
            txtFileName = new TextBox();
            lblFileName = new Label();
            cboFormatType = new ComboBox();
            lblFormatType = new Label();
            txtOutput = new TextBox();
            lblInputTitle = new Label();
            lblOutputTitle = new Label();
            btnSave = new Button();
            
            // 
            // txtInput
            // 
            txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            txtInput.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtInput.Location = new System.Drawing.Point(12, 140);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Both;
            txtInput.Size = new System.Drawing.Size(400, 312);
            txtInput.TabIndex = 4;
            txtInput.WordWrap = false;
            txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // txtOutput
            // 
            txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            txtOutput.BackColor = System.Drawing.Color.White;
            txtOutput.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtOutput.Location = new System.Drawing.Point(428, 140);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Both;
            txtOutput.Size = new System.Drawing.Size(400, 312);
            txtOutput.TabIndex = 8;
            txtOutput.WordWrap = false;
            // 
            // lblInputTitle
            // 
            lblInputTitle.AutoSize = true;
            lblInputTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblInputTitle.Location = new System.Drawing.Point(12, 120);
            lblInputTitle.Name = "lblInputTitle";
            lblInputTitle.Size = new System.Drawing.Size(45, 20);
            lblInputTitle.TabIndex = 9;
            lblInputTitle.Text = "Input";
            // 
            // lblOutputTitle
            // 
            lblOutputTitle.AutoSize = true;
            lblOutputTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblOutputTitle.Location = new System.Drawing.Point(428, 120);
            lblOutputTitle.Name = "lblOutputTitle";
            lblOutputTitle.Size = new System.Drawing.Size(152, 20);
            lblOutputTitle.TabIndex = 10;
            lblOutputTitle.Text = "Formatted Output";
            // 
            // btnFormat
            // 
            btnFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            btnFormat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFormat.Location = new System.Drawing.Point(12, 467);
            btnFormat.Name = "btnFormat";
            btnFormat.Size = new System.Drawing.Size(120, 40);
            btnFormat.TabIndex = 5;
            btnFormat.Text = "Format";
            btnFormat.UseVisualStyleBackColor = true;
            btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnSave
            // 
            btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSave.Location = new System.Drawing.Point(708, 467);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(120, 40);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.Location = new System.Drawing.Point(301, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(238, 32);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Multi-Format Parser";
            // 
            // lblInstructions
            // 
            lblInstructions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lblInstructions.AutoSize = true;
            lblInstructions.Location = new System.Drawing.Point(301, 80);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new System.Drawing.Size(413, 20);
            lblInstructions.TabIndex = 3;
            lblInstructions.Text = "Enter your text on the left and see formatted output on the right.";
            //
            // lblFileName
            //
            lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            lblFileName.AutoSize = true;
            lblFileName.Location = new System.Drawing.Point(428, 477);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new System.Drawing.Size(77, 20);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "File Name:";
            lblFileName.Visible = false;
            //
            // txtFileName
            //
            txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            txtFileName.Location = new System.Drawing.Point(505, 474);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new System.Drawing.Size(197, 27);
            txtFileName.TabIndex = 2;
            txtFileName.Visible = false;
            //
            // lblFormatType
            //
            lblFormatType.AutoSize = true;
            lblFormatType.Location = new System.Drawing.Point(12, 50);
            lblFormatType.Name = "lblFormatType";
            lblFormatType.Size = new System.Drawing.Size(98, 20);
            lblFormatType.TabIndex = 6;
            lblFormatType.Text = "Format Type:";
            //
            // cboFormatType
            //
            cboFormatType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormatType.FormattingEnabled = true;
            cboFormatType.Location = new System.Drawing.Point(116, 47);
            cboFormatType.Name = "cboFormatType";
            cboFormatType.Size = new System.Drawing.Size(200, 28);
            cboFormatType.TabIndex = 1;
            cboFormatType.SelectedIndexChanged += new System.EventHandler(this.cboFormatType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 520);
            this.Controls.Add(btnSave);
            this.Controls.Add(lblOutputTitle);
            this.Controls.Add(lblInputTitle);
            this.Controls.Add(txtOutput);
            this.Controls.Add(cboFormatType);
            this.Controls.Add(lblFormatType);
            this.Controls.Add(txtFileName);
            this.Controls.Add(lblFileName);
            this.Controls.Add(lblInstructions);
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnFormat);
            this.Controls.Add(txtInput);
            this.MinimumSize = new System.Drawing.Size(858, 567);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "One.Formatter - Multi-Format Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnFormat;
        private Label lblTitle;
        private Label lblInstructions;
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