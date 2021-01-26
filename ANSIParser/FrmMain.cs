using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANSIParser
{//WORK IN PROGRESS
    public partial class FrmMain : Form
    {
        /// \u001b[STYLE,FORE,BACK
        string[] test = { "\u001b[1;32;44mHello World\r\n", 
            "\u001b[4;32mHello World\r\n" };

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
             rtxtBox.Clear();
             foreach (string str in test)
             {
                 foreach (Ansi.AnsiString line in Ansi.AnsiParser(str))
                 {
                    rtxtBox.SelectionStart = rtxtBox.Text.Length;
                    rtxtBox.SelectionLength = 0;
                    rtxtBox.SelectionColor = Ansi.FromColor(line.Style.ForeColor);
                    rtxtBox.SelectionBackColor = Ansi.FromColor(line.Style.BackColor);
                    rtxtBox.SelectionFont = new Font(rtxtBox.Font,line.Style.Font);
                    rtxtBox.AppendText(line.Text);
                 }
             }
            /*int start = rtxtBox.Text.IndexOf(':');
            int lenght = rtxtBox.Text.Length - start;

            rtxtBox.SelectionStart = start;
            rtxtBox.SelectionLength = lenght;

            rtxtBox.SelectionFont = new Font(rtxtBox.SelectionFont, FontStyle.Underline);

            rtxtBox.SelectionColor = Color.FromArgb (100,120,200);

            rtxtBox.SelectionStart = rtxtBox.Text.Length;
            rtxtBox.SelectionLength = 0;*/
        }
    }
}
