using lab5_3sem.Properties;

namespace lab5_3sem
{
    public partial class Form1 : Form
    {
        Data data = new();
        public Form1()
        {
            InitializeComponent();

            data.ReadFile(Settings.Default.DefaulFileName); // после создания формы, считываем предыдущий файл, если его не было ту пусто
            richTextBox1.Text = data.Text;
           
        }

        private void OpenFile(object sender, EventArgs e) // функция открытия файла 
        {
            OpenFileDialog of = new(); // переменная в которую файл будет 
            if (of.ShowDialog()==DialogResult.OK )
            {
                data.ReadFile(of.FileName);
                richTextBox1.Text = data.Text;
                Settings.Default.DefaulFileName=data.FileName;
                Settings.Default.Save();
            }
        }

        private void FindRegex(object sender, EventArgs e) //помощь в поиске 
        {
            data.Find(textBox1.Text);
            ShowMatch();
        }

        private void ShowMatch() // функция в которой показываются слова которые мы нашли 
        {
            var m=data.Match;
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            if (m == null || !m.Success) return;
            
            richTextBox1.SelectionStart = m.Index;// индекс слова запоминается и ниже его длина 
            richTextBox1.SelectionLength = m.Length;
            richTextBox1.SelectionBackColor = Color.Yellow; //слово найденное выделяется 
            richTextBox1.ScrollToCaret();

            richTextBox2.Text += $"Найдено: {m.Value} на месте {m.Index}\n"; 
            if (m.Groups.Count> 1) 
            {
                richTextBox2.Text += $"Группы: {String.Join(", ",m.Groups.Values)}\n";//группы слов 

            }



        }

        private void ShowNextMatch(object sender, EventArgs e)
        {
            data.GoNext();
            ShowMatch();
        }

        private void buttonFind_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}