using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Editor.BL
{
    /// <summary>
    /// Задача: Сгенерировать все поля при старте.
    /// </summary>
    class FieldsGenerator
    {
        /// <summary>
        /// Генерирует позиции полей, исполняет единственную обязанность всего класса.
        /// </summary>
        /// <param name="xStart">Начало построения всех полей по X.</param>
        /// <param name="yStart">Начало построения всех полей по Y.</param>
        /// <param name="countSymbolsInString">Количество символов в строке.</param>
        /// <param name="countStrings">Количество строк на рабочем поле.</param>
        /// <param name="model">Модель, по принципу которой создаются все поля.</param>
        /// <returns>Список полей.</returns>
        public List<TextBox> GenerateFields(int xStart, int yStart, int countSymbolsInString, int countStrings)
        {
            ModelAdjuster adjust = new ModelAdjuster();

            List<TextBox> listOfFields = new List<TextBox>();

            // Для того, чтобы распространять поля далее.
            int x = 0;
            int y = 0;

            for (int i = 0; i < countStrings; i++)
            {
                for (int j = 0; j < countSymbolsInString; j++)
                {
                    TextBox field = adjust.GetModel(new TextBox());
                    field.Location = new Point(xStart + x, yStart + y);
                    listOfFields.Add(field);

                    x += ModelAdjuster.ModelSizeX;
                }

                y += ModelAdjuster.ModelSizeY;
                x = 0;
            }

            return listOfFields;
        }
        //Здесь по идее больше одного метода не должно быть, судя по описанию метода выше
    }
}
