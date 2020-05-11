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
    /// Задача: Выдать экземляр поля, который будет являться эталоном для всех полей.
    /// </summary>
    class ModelCreater
    {
        /// <summary>
        /// Получение эталона поля.
        /// </summary>
        /// <returns>Эталон поля.</returns>
        public TextBox GetModel()
        {
            TextBox model = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Width = 13,
                Height = 13,
                MaxLength = 1,
                TextAlign = HorizontalAlignment.Center,
                Multiline = false
            };

            return model;
        }
    }
}
