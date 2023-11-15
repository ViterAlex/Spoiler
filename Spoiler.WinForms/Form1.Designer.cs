namespace Spoiler.WinForms
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.spoiler2 = new Spoiler.Lib.Spoiler();
            this.spoiler1 = new Spoiler.Lib.Spoiler();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.spoiler1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // spoiler2
            // 
            this.spoiler2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spoiler2.CollapsedText = null;
            this.spoiler2.Location = new System.Drawing.Point(283, 90);
            this.spoiler2.Name = "spoiler2";
            this.spoiler2.Size = new System.Drawing.Size(192, 199);
            this.spoiler2.TabIndex = 6;
            this.spoiler2.UncollapsedText = null;
            // 
            // spoiler1
            // 
            this.spoiler1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.spoiler1.CollapsedText = "Розгорнути";
            this.spoiler1.Controls.Add(this.tableLayoutPanel1);
            this.spoiler1.Location = new System.Drawing.Point(41, 54);
            this.spoiler1.Name = "spoiler1";
            this.spoiler1.Size = new System.Drawing.Size(186, 165);
            this.spoiler1.TabIndex = 5;
            this.spoiler1.UncollapsedText = "Згорнути";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(186, 147);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(516, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.spoiler1;
            this.propertyGrid1.Size = new System.Drawing.Size(284, 328);
            this.propertyGrid1.TabIndex = 2;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 328);
            this.Controls.Add(this.spoiler2);
            this.Controls.Add(this.spoiler1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.spoiler1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button button1;
        private Lib.Spoiler spoiler1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Lib.Spoiler spoiler2;
    }
}

