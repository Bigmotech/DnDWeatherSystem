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
            this.label9 = new System.Windows.Forms.Label();
            this.RainLL = new System.Windows.Forms.LinkLabel();
            this.TempLL = new System.Windows.Forms.LinkLabel();
            this.WindSpeedLL = new System.Windows.Forms.LinkLabel();
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
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(162, 23);
            this.EditButton.TabIndex = 0;
            this.EditButton.Text = "Details";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // TerrainButton
            // 
            this.TerrainButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TerrainButton.Location = new System.Drawing.Point(0, 177);
            this.TerrainButton.Name = "TerrainButton";
            this.TerrainButton.Size = new System.Drawing.Size(162, 23);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(163, 147);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // RainCombo
            // 
            this.RainCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this.RainCombo.FormattingEnabled = true;
            this.RainCombo.Items.AddRange(new object[] {
            "Rain",
            "NoRain"});
            this.RainCombo.Location = new System.Drawing.Point(3, 3);
            this.RainCombo.Name = "RainCombo";
            this.RainCombo.Size = new System.Drawing.Size(75, 21);
            this.RainCombo.TabIndex = 0;
            this.RainCombo.SelectedIndexChanged += new System.EventHandler(this.RainCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(84, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local Rain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(84, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Outgoing Rain";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(84, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Incoming Rain";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(84, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total Rain";
            // 
            // LocalRainText
            // 
            this.LocalRainText.Dock = System.Windows.Forms.DockStyle.Top;
            this.LocalRainText.Location = new System.Drawing.Point(3, 32);
            this.LocalRainText.Name = "LocalRainText";
            this.LocalRainText.Size = new System.Drawing.Size(75, 20);
            this.LocalRainText.TabIndex = 6;
            this.LocalRainText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocalRainText_KeyDown);
            // 
            // OutgoingText
            // 
            this.OutgoingText.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutgoingText.Location = new System.Drawing.Point(3, 61);
            this.OutgoingText.Name = "OutgoingText";
            this.OutgoingText.Size = new System.Drawing.Size(75, 20);
            this.OutgoingText.TabIndex = 7;
            this.OutgoingText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OutgoingText_KeyDown);
            // 
            // IncomingText
            // 
            this.IncomingText.Dock = System.Windows.Forms.DockStyle.Top;
            this.IncomingText.Location = new System.Drawing.Point(3, 90);
            this.IncomingText.Name = "IncomingText";
            this.IncomingText.Size = new System.Drawing.Size(75, 20);
            this.IncomingText.TabIndex = 8;
            this.IncomingText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IncomingText_KeyDown_1);
            // 
            // TotalText
            // 
            this.TotalText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TotalText.Enabled = false;
            this.TotalText.Location = new System.Drawing.Point(3, 119);
            this.TotalText.Name = "TotalText";
            this.TotalText.Size = new System.Drawing.Size(75, 20);
            this.TotalText.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(84, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
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
            this.Basic.Name = "Basic";
            this.Basic.Size = new System.Drawing.Size(162, 200);
            this.Basic.TabIndex = 3;
            // 
            // Advance
            // 
            this.Advance.Controls.Add(this.AdvanceTable);
            this.Advance.Dock = System.Windows.Forms.DockStyle.Right;
            this.Advance.Location = new System.Drawing.Point(158, 0);
            this.Advance.Name = "Advance";
            this.Advance.Size = new System.Drawing.Size(83, 200);
            this.Advance.TabIndex = 4;
            // 
            // AdvanceTable
            // 
            this.AdvanceTable.ColumnCount = 2;
            this.AdvanceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.Controls.Add(this.label6, 0, 0);
            this.AdvanceTable.Controls.Add(this.label8, 0, 1);
            this.AdvanceTable.Controls.Add(this.label9, 0, 2);
            this.AdvanceTable.Controls.Add(this.RainLL, 1, 0);
            this.AdvanceTable.Controls.Add(this.TempLL, 1, 1);
            this.AdvanceTable.Controls.Add(this.WindSpeedLL, 1, 2);
            this.AdvanceTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdvanceTable.Location = new System.Drawing.Point(0, 0);
            this.AdvanceTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.AdvanceTable.Name = "AdvanceTable";
            this.AdvanceTable.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.AdvanceTable.RowCount = 3;
            this.AdvanceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AdvanceTable.Size = new System.Drawing.Size(83, 200);
            this.AdvanceTable.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "Rain Fall";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Temp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 39);
            this.label9.TabIndex = 3;
            this.label9.Text = "Wind Speed";
            // 
            // RainLL
            // 
            this.RainLL.AutoEllipsis = true;
            this.RainLL.AutoSize = true;
            this.RainLL.Location = new System.Drawing.Point(44, 5);
            this.RainLL.Name = "RainLL";
            this.RainLL.Size = new System.Drawing.Size(13, 13);
            this.RainLL.TabIndex = 7;
            this.RainLL.TabStop = true;
            this.RainLL.Text = "0";
            this.RainLL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RainLL_LinkClicked);
            this.RainLL.MouseHover += new System.EventHandler(this.RainLL_MouseHover);
            // 
            // TempLL
            // 
            this.TempLL.AutoSize = true;
            this.TempLL.Location = new System.Drawing.Point(44, 70);
            this.TempLL.Name = "TempLL";
            this.TempLL.Size = new System.Drawing.Size(28, 13);
            this.TempLL.TabIndex = 9;
            this.TempLL.TabStop = true;
            this.TempLL.Text = "Cool";
            this.TempLL.MouseHover += new System.EventHandler(this.TempLL_MouseHover);
            // 
            // WindSpeedLL
            // 
            this.WindSpeedLL.AutoSize = true;
            this.WindSpeedLL.Location = new System.Drawing.Point(44, 135);
            this.WindSpeedLL.Name = "WindSpeedLL";
            this.WindSpeedLL.Size = new System.Drawing.Size(33, 13);
            this.WindSpeedLL.TabIndex = 10;
            this.WindSpeedLL.TabStop = true;
            this.WindSpeedLL.Text = "0mph";
            // 
            // WeatherControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(241, 200);
            this.Controls.Add(this.Advance);
            this.Controls.Add(this.Basic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WeatherControlForm";
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel RainLL;
        private System.Windows.Forms.LinkLabel TempLL;
        private System.Windows.Forms.LinkLabel WindSpeedLL;
        private System.Windows.Forms.ToolTip ToolInfo;
    }
}