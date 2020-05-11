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
    /// Задача: Выдать экземляр поля, который будет настроен подобающе полю.
    /// </summary>
    class ModelAdjuster
    {
        /// <summary>
        /// Ширина эталона поля.
        /// </summary>
        public const int ModelSizeX = 13;

        /// <summary>
        /// Высота эталона поля.
        /// </summary>
        public const int ModelSizeY = 13;

        /// <summary>
        /// Получение настроенного поля.
        /// </summary>
        /// <param name="model">Ненастроенный TextBox.</param>
        /// <returns>Настроенное поле.</returns>
        public TextBox GetModel(TextBox model)
        {
            model.BorderStyle = BorderStyle.None;
            model.Width = ModelSizeX;
            model.Height = ModelSizeY;
            model.MaxLength = 1;
            model.TextAlign = HorizontalAlignment.Center;
            model.Multiline = false;

            return model;
        }
    }
}
