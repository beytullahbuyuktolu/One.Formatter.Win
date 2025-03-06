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
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new System.Drawing.Point(12, 110);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new System.Drawing.Size(570, 276);
            txtInput.TabIndex = 0;
            // 
            // btnFormat
            // 
            btnFormat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFormat.Location = new System.Drawing.Point(237, 403);
            btnFormat.Name = "btnFormat";
            btnFormat.Size = new System.Drawing.Size(120, 40);
            btnFormat.TabIndex = 3;
            btnFormat.Text = "Create";
            btnFormat.UseVisualStyleBackColor = true;
            btnFormat.Click += btnFormat_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitle.Location = new System.Drawing.Point(207, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(195, 32);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "JSON Formatter";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Location = new System.Drawing.Point(12, 50);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new System.Drawing.Size(497, 20);
            lblInstructions.TabIndex = 3;
            lblInstructions.Text = "Enter your JSON text here and click the Create button to save it formatted.";
            // 
            // txtFileName
            // 
            txtFileName.Location = new System.Drawing.Point(95, 80);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new System.Drawing.Size(487, 27);
            txtFileName.TabIndex = 2;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new System.Drawing.Point(12, 80);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new System.Drawing.Size(79, 20);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "File Name:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(594, 455);
            Controls.Add(txtFileName);
            Controls.Add(lblFileName);
            Controls.Add(lblInstructions);
            Controls.Add(lblTitle);
            Controls.Add(btnFormat);
            Controls.Add(txtInput);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "One.Formatter - JSON Formatter & Saver";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnFormat;
        private Label lblTitle;
        private Label lblInstructions;
        private TextBox txtFileName;
        private Label lblFileName;
    }
}