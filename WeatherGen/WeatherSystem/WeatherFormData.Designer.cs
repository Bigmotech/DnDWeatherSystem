namespace WeatherGen.WeatherSystem
{
    partial class WeatherFormData
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
            this.components = new System.ComponentModel.Container();
            this.EditButton = new System.Windows.Forms.Button();
            this.TerrainButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RainCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LocalRainText = new System.Windows.Forms.TextBox();
            this.OutgoingText = new System.Windows.Forms.TextBox();
            this.IncomingText = new System.Windows.Forms.TextBox();
            this.TotalText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Basic = new System.Windows.Forms.Panel();
            this.Advance = new System.Windows.Forms.Panel();
            this.AdvanceTable = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Cloudcov = new System.Windows.Forms.Label();
            this.RainLL = new System.Windows.Forms.LinkLabel();
            this.TempLL = new System.Windows.Forms.LinkLabel();
            this.CloudcoverLL = new System.Windows.Forms.LinkLabel();
            this.ToolInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.Basic.SuspendLayout();
            this.Advance.SuspendLayout();
            this.AdvanceTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            this.EditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditButton.Location = new System.Drawing.Point(0, 0);
            this.EditButton.Margin = new System.Windows.Forms.Padding(6);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(297, 42);
            this.EditButton.TabIndex = 0;
            this.EditButton.Text = "Details";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // TerrainButton
            // 
            this.TerrainButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TerrainButton.Location = new System.Drawing.Point(0, 327);
            this.TerrainButton.Margin = new System.Windows.Forms.Padding(6);
            this.TerrainButton.Name = "TerrainButton";
            this.TerrainButton.Size = new System.Drawing.Size(297, 42);
            this.TerrainButton.TabIndex = 1;
            this.TerrainButton.Text = "None";
            this.TerrainButton.UseVisualStyleBackColor = true;
            this.TerrainButton.Click += new System.EventHandler(this.TerrainButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Controls.Add(this.RainCombo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LocalRainText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OutgoingText, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.IncomingText, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TotalText, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(299, 271);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // RainCombo
            // 
            this.RainCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this.RainCombo.FormattingEnabled = true;
            this.RainCombo.Items.AddRange(new object[] {
            "Rain",
            "NoRain"});
            this.RainCombo.Location = new System.Drawing.Point(6, 6);
            this.RainCombo.Margin = new System.Windows.Forms.Padding(6);
            this.RainCombo.Name = "RainCombo";
            this.RainCombo.Size = new System.Drawing.Size(137, 32);
            this.RainCombo.TabIndex = 0;
            this.RainCombo.SelectedIndexChanged += new System.EventHandler(this.RainCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(155, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local Rain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(155, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Outgoing Rain";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(155, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Incoming Rain";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(155, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total Rain";
            // 
            // LocalRainText
            // 
            this.LocalRainText.Dock = System.Windows.Forms.DockStyle.Top;
            this.LocalRainText.Location = new System.Drawing.Point(6, 60);
            this.LocalRainText.Margin = new System.Windows.Forms.Padding(6);
            this.LocalRainText.Name = "LocalRainText";
            this.LocalRainText.Size = new System.Drawing.Size(137, 29);
            this.LocalRainText.TabIndex = 6;
            this.LocalRainText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocalRainText_KeyDown);
            // 
            // OutgoingText
            // 
            this.OutgoingText.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutgoingText.Location = new System.Drawing.Point(6, 114);
            this.OutgoingText.Margin = new System.Windows.Forms.Padding(6);
            this.OutgoingText.Name = "OutgoingText";
            this.OutgoingText.Size = new System.Drawing.Size(137, 29);
            this.OutgoingText.TabIndex = 7;
            this.OutgoingText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OutgoingText_KeyDown);
            // 
            // IncomingText
            // 
            this.IncomingText.Dock = System.Windows.Forms.DockStyle.Top;
            this.IncomingText.Location = new System.Drawing.Point(6, 168);
            this.IncomingText.Margin = new System.Windows.Forms.Padding(6);
            this.IncomingText.Name = "IncomingText";
            this.IncomingText.Size = new System.Drawing.Size(137, 29);
            this.IncomingText.TabIndex = 8;
            this.IncomingText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IncomingText_KeyDown_1);
            // 
            // TotalText
            // 
            this.TotalText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TotalText.Enabled = false;
            this.TotalText.Location = new System.Drawing.Point(6, 222);
            this.TotalText.Margin = new System.Windows.Forms.Padding(6);
            this.TotalText.Name = "TotalText";
            this.TotalText.Size = new System.Drawing.Size(137, 29);
            this.TotalText.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(155, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rain/NoRain";
            // 
            // Basic
            // 
            this.Basic.Controls.Add(this.EditButton);
            this.Basic.Controls.Add(this.tableLayoutPanel1);
            this.Basic.Controls.Add(this.TerrainButton);
            this.Basic.Dock = System.Windows.Forms.DockStyle.Left;
            this.Basic.Location = new System.Drawing.Point(0, 0);
            this.Basic.Margin = new System.Windows.Forms.Padding(6);
            this.Basic.Name = "Basic";
            this.Basic.Size = new System.Drawing.Size(297, 369);
            this.Basic.TabIndex = 3;
            // 
            // Advance
            // 
            this.Advance.Controls.Add(this.AdvanceTable);
            this.Advance.Dock = System.Windows.Forms.DockStyle.Right;
            this.Advance.Location = new System.Drawing.Point(290, 0);
            this.Advance.Margin = new System.Windows.Forms.Padding(6);
            this.Advance.Name = "Advance";
            this.Advance.Size = new System.Drawing.Size(152, 369);
            this.Advance.TabIndex = 4;
            // 
            // AdvanceTable
            // 
            this.AdvanceTable.ColumnCount = 2;
            this.AdvanceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.Controls.Add(this.label6, 0, 0);
            this.AdvanceTable.Controls.Add(this.label8, 0, 1);
            this.AdvanceTable.Controls.Add(this.Cloudcov, 0, 2);
            this.AdvanceTable.Controls.Add(this.RainLL, 1, 0);
            this.AdvanceTable.Controls.Add(this.TempLL, 1, 1);
            this.AdvanceTable.Controls.Add(this.CloudcoverLL, 1, 2);
            this.AdvanceTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdvanceTable.Location = new System.Drawing.Point(0, 0);
            this.AdvanceTable.Margin = new System.Windows.Forms.Padding(6, 9, 6, 6);
            this.AdvanceTable.Name = "AdvanceTable";
            this.AdvanceTable.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.AdvanceTable.RowCount = 3;
            this.AdvanceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.Size = new System.Drawing.Size(152, 369);
            this.AdvanceTable.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 50);
            this.label6.TabIndex = 0;
            this.label6.Text = "Rain Fall";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 129);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Temp";
            // 
            // Cloudcov
            // 
            this.Cloudcov.AutoSize = true;
            this.Cloudcov.Location = new System.Drawing.Point(6, 249);
            this.Cloudcov.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Cloudcov.Name = "Cloudcov";
            this.Cloudcov.Size = new System.Drawing.Size(64, 50);
            this.Cloudcov.TabIndex = 3;
            this.Cloudcov.Text = "Cloud cover";
            // 
            // RainLL
            // 
            this.RainLL.AutoEllipsis = true;
            this.RainLL.AutoSize = true;
            this.RainLL.Location = new System.Drawing.Point(82, 9);
            this.RainLL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.RainLL.Name = "RainLL";
            this.RainLL.Size = new System.Drawing.Size(23, 25);
            this.RainLL.TabIndex = 7;
            this.RainLL.TabStop = true;
            this.RainLL.Text = "0";
            this.RainLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RainLL_LinkClicked);
            this.RainLL.MouseHover += new System.EventHandler(this.RainLL_MouseHover);
            // 
            // TempLL
            // 
            this.TempLL.AutoSize = true;
            this.TempLL.Location = new System.Drawing.Point(82, 129);
            this.TempLL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TempLL.Name = "TempLL";
            this.TempLL.Size = new System.Drawing.Size(53, 25);
            this.TempLL.TabIndex = 9;
            this.TempLL.TabStop = true;
            this.TempLL.Text = "Cool";
            this.TempLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TempLL_LinkClicked);
            this.TempLL.MouseHover += new System.EventHandler(this.TempLL_MouseHover);
            // 
            // CloudcoverLL
            // 
            this.CloudcoverLL.AutoSize = true;
            this.CloudcoverLL.Location = new System.Drawing.Point(82, 249);
            this.CloudcoverLL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.CloudcoverLL.Name = "CloudcoverLL";
            this.CloudcoverLL.Size = new System.Drawing.Size(62, 50);
            this.CloudcoverLL.TabIndex = 10;
            this.CloudcoverLL.TabStop = true;
            this.CloudcoverLL.Text = "Sunny Day";
            // 
            // WeatherFormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(442, 369);
            this.Controls.Add(this.Advance);
            this.Controls.Add(this.Basic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WeatherFormData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Basic.ResumeLayout(false);
            this.Advance.ResumeLayout(false);
            this.AdvanceTable.ResumeLayout(false);
            this.AdvanceTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button TerrainButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox RainCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LocalRainText;
        private System.Windows.Forms.TextBox OutgoingText;
        private System.Windows.Forms.TextBox IncomingText;
        private System.Windows.Forms.TextBox TotalText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Basic;
        private System.Windows.Forms.Panel Advance;
        private System.Windows.Forms.TableLayoutPanel AdvanceTable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Cloudcov;
        private System.Windows.Forms.LinkLabel RainLL;
        private System.Windows.Forms.LinkLabel TempLL;
        private System.Windows.Forms.LinkLabel CloudcoverLL;
        private System.Windows.Forms.ToolTip ToolInfo;
    }
}