using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const int maxSymbolsInString = 71;

        public Form()
        {
            InitializeComponent();
            TextBox.Text = "                                                                                                                                                                                                             ";
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                TextBox.SelectionStart += maxSymbolsInString;
            }
            if (e.KeyValue == (char)Keys.ControlKey)
            {
                TextBox.SelectionStart += 1;
            }
        }
    }
}
