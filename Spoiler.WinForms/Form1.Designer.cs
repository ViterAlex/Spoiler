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
            this.spoiler1 = new Spoiler.Lib.Spoiler();
            this.button2 = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.spoiler1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spoiler1
            // 
            this.spoiler1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.spoiler1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spoiler1.Controls.Add(this.button2);
            this.spoiler1.Location = new System.Drawing.Point(25, 33);
            this.spoiler1.Name = "spoiler1";
            this.spoiler1.Size = new System.Drawing.Size(306, 147);
            this.spoiler1.TabIndex = 3;
            this.spoiler1.Text = "spoiler1";
            this.spoiler1.TitlebarBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.spoiler1.TitlebarTextPadding = new System.Windows.Forms.Padding(3);
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.Controls.Add(this.spoiler1);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.spoiler1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Lib.Spoiler spoiler1;
    }
}

