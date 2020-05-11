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
        public Form()
        {
            InitializeComponent();

            BL.ModelCreater modelling = new BL.ModelCreater();
            TextBox model = modelling.GetModel();

            BL.Accountant count = new BL.Accountant();
            const int borders = 16; // Сумма левой и правой границы окна.
            int countX = count.CountAmountSymbolsInSting(Width - borders, model.Width);
            int countY = count.CountAmountSymbolsInSting(Height - Menu.Height, model.Height);

            BL.FieldsGenerator generate = new BL.FieldsGenerator();
            List<TextBox> listOfFields = generate.GenerateFields(0, Menu.Height, countX, countY, model);
            visualizeFields(listOfFields);

            for (int i = 0; i < 2; i++)
            {
                richTextBox1.Text = listOfFields[i].Location.X + " / " + listOfFields[i].Location.Y;
            }
        }

        public void visualizeFields(List<TextBox> listOfFields)
        {
            for (int i = 0; i < listOfFields.Count; i++)
            {
                Controls.Add(listOfFields[i]);
            }
        }
    }
}
