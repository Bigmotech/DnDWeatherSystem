﻿namespace WeatherGen.WeatherSystem
{
    partial class WeatherCelliconDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabel1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(20, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.UseVisualStyleBackColor = true;
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // WeatherCelliconDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.linkLabel1);
            this.Name = "WeatherCelliconDisplay";
            this.Size = new System.Drawing.Size(20, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button linkLabel1;
    }
}
