﻿namespace JSGameIDE
{
    partial class ProjectOptionsForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.projectNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewHeightBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.viewWidthBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(274, 301);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // projectNameBox
            // 
            this.projectNameBox.Location = new System.Drawing.Point(89, 6);
            this.projectNameBox.MaxLength = 20;
            this.projectNameBox.Name = "projectNameBox";
            this.projectNameBox.Size = new System.Drawing.Size(100, 20);
            this.projectNameBox.TabIndex = 1;
            this.projectNameBox.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Map Width:";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(416, 6);
            this.widthTextBox.MaxLength = 4;
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(50, 20);
            this.widthTextBox.TabIndex = 4;
            this.widthTextBox.Tag = "";
            this.widthTextBox.TextChanged += new System.EventHandler(this.Check_If_Int_On_TextChanged);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(558, 6);
            this.heightTextBox.MaxLength = 4;
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(50, 20);
            this.heightTextBox.TabIndex = 6;
            this.heightTextBox.Tag = "";
            this.heightTextBox.TextChanged += new System.EventHandler(this.Check_If_Int_On_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Map Height:";
            // 
            // viewHeightBox
            // 
            this.viewHeightBox.Location = new System.Drawing.Point(558, 28);
            this.viewHeightBox.MaxLength = 4;
            this.viewHeightBox.Name = "viewHeightBox";
            this.viewHeightBox.Size = new System.Drawing.Size(50, 20);
            this.viewHeightBox.TabIndex = 10;
            this.viewHeightBox.Tag = "";
            this.viewHeightBox.TextChanged += new System.EventHandler(this.Check_If_Int_On_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "View Height:";
            // 
            // viewWidthBox
            // 
            this.viewWidthBox.Location = new System.Drawing.Point(416, 28);
            this.viewWidthBox.MaxLength = 4;
            this.viewWidthBox.Name = "viewWidthBox";
            this.viewWidthBox.Size = new System.Drawing.Size(50, 20);
            this.viewWidthBox.TabIndex = 8;
            this.viewWidthBox.Tag = "";
            this.viewWidthBox.TextChanged += new System.EventHandler(this.Check_If_Int_On_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "View Width:";
            // 
            // ProjectOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 336);
            this.Controls.Add(this.viewHeightBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.viewWidthBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectNameBox);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox projectNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox viewHeightBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox viewWidthBox;
        private System.Windows.Forms.Label label5;
    }
}