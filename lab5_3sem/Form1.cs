using lab5_3sem.Properties;

namespace lab5_3sem
{
    public partial class Form1 : Form
    {
        Data data = new();
        public Form1()
        {
            InitializeComponent();

            data.ReadFile(Settings.Default.DefaulFileName); // ����� �������� �����, ��������� ���������� ����, ���� ��� �� ���� �� �����
            richTextBox1.Text = data.Text;
           
        }

        private void OpenFile(object sender, EventArgs e) // ������� �������� ����� 
        {
            OpenFileDialog of = new(); // ���������� � ������� ���� ����� 
            if (of.ShowDialog()==DialogResult.OK )
            {
                data.ReadFile(of.FileName);
                richTextBox1.Text = data.Text;
                Settings.Default.DefaulFileName=data.FileName;
                Settings.Default.Save();
            }
        }

        private void FindRegex(object sender, EventArgs e) //������ � ������ 
        {
            data.Find(textBox1.Text);
            ShowMatch();
        }

        private void ShowMatch() // ������� � ������� ������������ ����� ������� �� ����� 
        {
            var m=data.Match;
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            if (m == null || !m.Success) return;
            
            richTextBox1.SelectionStart = m.Index;// ������ ����� ������������ � ���� ��� ����� 
            richTextBox1.SelectionLength = m.Length;
            richTextBox1.SelectionBackColor = Color.Yellow; //����� ��������� ���������� 
            richTextBox1.ScrollToCaret();

            richTextBox2.Text += $"�������: {m.Value} �� ����� {m.Index}\n"; 
            if (m.Groups.Count> 1) 
            {
                richTextBox2.Text += $"������: {String.Join(", ",m.Groups.Values)}\n";//������ ���� 

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