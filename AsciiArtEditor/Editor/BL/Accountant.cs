using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.BL
{
    /// <summary>
    /// Выдаёт, проверяет, исходя из выданных данных, значение находимого
    /// числа с помощью простых мат. операций.
    /// </summary>
    class Accountant
    {
        /// <summary>
        /// Считает кол-во символов с строке.
        /// С помощью длины рабочей области и размера единицы поля.
        /// </summary>
        /// <param name="lenghtWorkspace">Длина рабочей области.</param>
        /// <param name="fieldSize">Размер поля.</param>
        /// <returns>Количество символов в строке.</returns>
        public int CountAmountSymbolsInSting(float lenghtWorkspace, float fieldSize)
        {
            float amountSymbolsInString = lenghtWorkspace / fieldSize;
            if (isWholeNumber(amountSymbolsInString) == false)
                throw new Exception("ОШИБКА: Количество символов с строке не может быть дробным.");

            return Convert.ToInt32(amountSymbolsInString);
        }

        /// <summary>
        /// Проверяет целое число или дробное.
        /// </summary>
        /// <param name="number">Число, которое надо проверить.</param>
        /// <returns></returns>
        private bool isWholeNumber(float number)
        {
            return number == Convert.ToInt32(number) ? true : false;
        }
    }
}
