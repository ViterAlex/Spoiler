using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spoiler.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //spoiler2.Text = "OK!";
        }

        //protected override void OnMouseClick(MouseEventArgs e)
        //{
        //    base.OnMouseClick(e);
        //    spoiler2.Text = $"{e.Location}";
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            //spoiler1.ClientSize = new Size(spoiler1.Width, SystemInformation.CaptionHeight);
        }
    }
}
