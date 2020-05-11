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

            BL.Accountant count = new BL.Accountant();
            const int bordersX = 16; // Сумма левой и правой границы окна.
            const int bordersY = 35; // Сумма верхней и нижней границы окна.
            int countX = count.CountAmountSymbolsInSting(Width - bordersX, BL.ModelAdjuster.ModelSizeX);
            int countY = count.CountAmountSymbolsInSting(Height - (Menu.Height + bordersY), BL.ModelAdjuster.ModelSizeY);

            BL.FieldsGenerator generate = new BL.FieldsGenerator();
            List<TextBox> listOfFields = generate.GenerateFields(0, Menu.Height, countX, countY);
            visualizeFields(listOfFields);
        }

        /// <summary>
        /// Визуализирует все поля из списка.
        /// </summary>
        /// <param name="listOfFields">Список полей.</param>
        public void visualizeFields(List<TextBox> listOfFields)
        {
            for (int i = 0; i < listOfFields.Count; i++)
            {
                Controls.Add(listOfFields[i]);
            }
        }
    }
}
