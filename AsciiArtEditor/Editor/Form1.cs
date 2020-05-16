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
        private List<TextBox> listOfFields;

        private int countX;
        private int countY;

        public Form()
        {
            InitializeComponent();

            // Расчёты для генерации
            BL.Accountant count = new BL.Accountant();
            const int bordersX = 16; // Сумма левой и правой границы окна.
            const int bordersY = 35; // Сумма верхней и нижней границы окна.
            countX = count.CountAmountSymbolsInSting(Width - bordersX, BL.ModelAdjuster.ModelSizeX);
            countY = count.CountAmountSymbolsInSting(Height - (Menu.Height + bordersY), BL.ModelAdjuster.ModelSizeY);

            // Сама генерация
            BL.FieldsPositionGenerator generate = new BL.FieldsPositionGenerator();
            listOfFields = generate.GenerateFields(0, Menu.Height, countX, countY);
            visualizeFields(listOfFields);
        }

        /// <summary>
        /// Нажатие на кнопку "Сохранить" в полоске меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BL.SaveFile save = new BL.SaveFile();
            save.Save(listOfFields, countX);
        }

        /// <summary>
        /// Нажатие на кнопку "Открыть" в полоске меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BL.OpenFile open = new BL.OpenFile();
            char[] listOfSymbolsInDocument = open.Open();

            if (listOfSymbolsInDocument != null)
                changeContentOfFields(listOfSymbolsInDocument, countX, countY);
        }

        // При нажатии на кнопки "Сохранить" и "Загрузить" память процесса резко увеличивается.

        /// <summary>
        /// Визуализирует все поля из списка.
        /// </summary>
        /// <param name="listOfFields">Список полей.</param>
        private void visualizeFields(List<TextBox> listOfFields)
        {
            foreach (TextBox i in listOfFields)
            {
                Controls.Add(i);
            }
        }

        private void changeContentOfFields(char[] listOfSymbolsInDocument, int countX, int countY)
        {
            List<char> changedListOfSymbolsInDocument = new List<char>();
            foreach (char i in listOfSymbolsInDocument)
            {
                if (Convert.ToString(i) != "\r" && Convert.ToString(i) != "\n")
                {
                    changedListOfSymbolsInDocument.Add(i);
                }
            }

            if (changedListOfSymbolsInDocument.Count <= countX * countY) 
            {
                for (int i = 0; i < changedListOfSymbolsInDocument.Count; i++)
                {
                    if (changedListOfSymbolsInDocument[i] != ' ')
                    {
                        listOfFields[i].Text = Convert.ToString(changedListOfSymbolsInDocument[i]);
                    }
                    else
                    {
                        listOfFields[i].Text = "";
                    }
                }
            }
            else 
            {
                MessageBox.Show("Количество символов в выбранном вами файле превышает максимальное.", "Ошибка");
            }
        }
    }
}
