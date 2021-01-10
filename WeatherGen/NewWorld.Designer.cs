namespace WeatherGen
{
    partial class NewWorld
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
            this.gridSize = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addPictureButton = new System.Windows.Forms.Button();
            this.previewPicBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.worldNameTB = new System.Windows.Forms.TextBox();
            this.dialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.removeMapLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridSize)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSize
            // 
            this.gridSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSize.Enabled = false;
            this.gridSize.Location = new System.Drawing.Point(17, 86);
            this.gridSize.Name = "gridSize";
            this.gridSize.Size = new System.Drawing.Size(68, 25);
            this.gridSize.TabIndex = 1;
            this.gridSize.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.addPictureButton);
            this.panel1.Controls.Add(this.previewPicBox);
            this.panel1.Location = new System.Drawing.Point(213, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 613);
            this.panel1.TabIndex = 2;
            // 
            // addPictureButton
            // 
            this.addPictureButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.addPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addPictureButton.Location = new System.Drawing.Point(240, 265);
            this.addPictureButton.Name = "addPictureButton";
            this.addPictureButton.Size = new System.Drawing.Size(103, 66);
            this.addPictureButton.TabIndex = 1;
            this.addPictureButton.Text = "+";
            this.addPictureButton.UseVisualStyleBackColor = true;
            this.addPictureButton.Click += new System.EventHandler(this.AddPictureButton_Click);
            // 
            // previewPicBox
            // 
            this.previewPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPicBox.Location = new System.Drawing.Point(0, 0);
            this.previewPicBox.Name = "previewPicBox";
            this.previewPicBox.Size = new System.Drawing.Size(589, 609);
            this.previewPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPicBox.TabIndex = 0;
            this.previewPicBox.TabStop = false;
            this.previewPicBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox1_DragDrop);
            this.previewPicBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox1_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grid Size\r\nEach Cell = 5 sq mile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Map Preview";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "World Name";
            // 
            // worldNameTB
            // 
            this.worldNameTB.BackColor = System.Drawing.Color.White;
            this.worldNameTB.Location = new System.Drawing.Point(12, 117);
            this.worldNameTB.Name = "worldNameTB";
            this.worldNameTB.Size = new System.Drawing.Size(190, 29);
            this.worldNameTB.TabIndex = 6;
            // 
            // dialog
            // 
            this.dialog.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 661);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Create World";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // removeMapLinkLabel
            // 
            this.removeMapLinkLabel.AutoSize = true;
            this.removeMapLinkLabel.LinkColor = System.Drawing.Color.Red;
            this.removeMapLinkLabel.Location = new System.Drawing.Point(345, 58);
            this.removeMapLinkLabel.Name = "removeMapLinkLabel";
            this.removeMapLinkLabel.Size = new System.Drawing.Size(128, 25);
            this.removeMapLinkLabel.TabIndex = 8;
            this.removeMapLinkLabel.TabStop = true;
            this.removeMapLinkLabel.Text = "Remove Map";
            this.removeMapLinkLabel.Visible = false;
            this.removeMapLinkLabel.VisitedLinkColor = System.Drawing.Color.Red;
            this.removeMapLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // NewWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 730);
            this.Controls.Add(this.removeMapLinkLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.worldNameTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewWorld";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New World";
            ((System.ComponentModel.ISupportInitialize)(this.gridSize)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown gridSize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addPictureButton;
        private System.Windows.Forms.PictureBox previewPicBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox worldNameTB;
        private System.Windows.Forms.OpenFileDialog dialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel removeMapLinkLabel;
    }
}