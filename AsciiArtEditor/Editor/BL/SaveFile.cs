using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Editor.BL
{
    /// <summary>
    /// Задача: Сохранить файл.
    /// </summary>
    class SaveFile
    {
        /// <summary>
        /// Сохраняет содержимое рабочего поля в отдельный файл.
        /// </summary>
        /// <param name="listOfFieldsContent">Список содержимого полей.</param>
        /// <param name="countSymbolsInString">Количество символов в строке.</param>
        public void Save(List<TextBox> listOfFields, int countSymbolsInString)
        {
            int count = 0; // Считает уже написанные символы в строке.
            string result = ""; // Здесь будет написан полноценный результат, который уже можно сохранить.

            foreach (TextBox i in listOfFields)
            {
                if (count == countSymbolsInString)
                {
                    result += Environment.NewLine;
                    count = 0;
                }

                if (i.Text == "")
                    result += " ";
                else
                    result += i.Text;

                count++;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.txt";
            sfd.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Default))
                {
                    sw.Write(result);
                    sw.Close();
                }
            }
        }
    }
}
