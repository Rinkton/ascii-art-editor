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
    /// Задача: Открыть файл.
    /// </summary>
    class OpenFile
    {
        public char[] Open()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            char[] listOfSymbolsInDocument;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileText = File.ReadAllText(ofd.FileName, Encoding.Default);
                listOfSymbolsInDocument = fileText.ToCharArray();

                return listOfSymbolsInDocument;
            }
            else
            {
                return null;
            }
        }
    }
}
