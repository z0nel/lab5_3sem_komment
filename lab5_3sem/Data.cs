using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab5_3sem
{
    public class Data
    {
        public string Text { get; set; }

        public string FileName { get; set; }

        public Match? Match { get; set; }

        private Regex? re;

        public void ReadFile(string fileName) // функция считывания файла 
        {
            using (StreamReader sr = new StreamReader(fileName))  // в sr запоминаем наш файл 
            {
                this.Text=sr.ReadToEnd().Replace("\r\n", "\n");
                this.FileName= fileName;



            }
        }

        internal void Find(string text) // функция поиска 
        {
            try 
            {
                re = new Regex(text, RegexOptions.Multiline);  // в re то что ищем 
                Match = re.Match(this.Text);
            }
            catch(RegexParseException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        internal void GoNext() // кнопка "еще" или типо того,будет искать , тоесть еще раз повторять функцию find 
        {
            if (Match == null || !Match.Success) return; // если find не нажимался то и эта функция не должна работать

            Match m = Match?.NextMatch();
            if (!m.Success)
            {
                if (re!= null)
                {
                    Match = re.Match(Text);
                }
            }
            else
            {
                Match = Match?.NextMatch();
            }
            
        }
    }
}
