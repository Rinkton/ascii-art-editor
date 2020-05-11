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
            List<int[]> listOfFieldsLocation = generate.GenerateFields(0, Menu.Height, countX, countY, new int[2] { model.Width, model.Height });
            visualizeFields(listOfFieldsLocation, model);
        }

        public void visualizeFields(List<int[]> listOfFieldsLocation, TextBox model)
        {
            
            for (int i = 0; i < listOfFieldsLocation.Count; i++)
            {
                TextBox modelll = new TextBox
                {
                    BorderStyle = BorderStyle.None,
                    Width = 13,
                    Height = 13,
                    MaxLength = 1,
                    TextAlign = HorizontalAlignment.Center,
                    Multiline = false
                };
                modelll.Location = new Point(50 + i / 10, 50 + i / 10);

                Controls.Add(modelll);
            }
            
        }
    }
}
