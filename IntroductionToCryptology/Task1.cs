using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Linq;

namespace IntroductionToCryptology
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string data = textBox1.Text;

            // Analyze data
            Dictionary<char, float> frequency = new Dictionary<char, float>();
            foreach (char c in data)
            {
                if (char.IsLetter(c))
                {
                    char lower = char.ToLower(c);
                    if (frequency.ContainsKey(lower))
                    {
                        frequency[lower]++;
                    }
                    else
                    {
                        frequency[lower] = 1;
                    }
                }
            }

            float total = frequency.Values.Sum();
            foreach (char c in frequency.Keys.ToList())
            {
                frequency[c] = frequency[c] * 100 / total;
            }

            dataGridView1.Rows.Clear();

            foreach (KeyValuePair<char, float> entry in frequency)
            {
                dataGridView1.Rows.Add(entry.Key, Math.Round(entry.Value, 2));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            saveFileDialog.Title = "Save an Text File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                fs.Close();
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog.FileName);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString() + " " + dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File|*.txt";
            openFileDialog.Title = "Open an Text File";
            openFileDialog.ShowDialog();

            dataGridView1.Rows.Clear();

            if (openFileDialog.FileName != "")
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    dataGridView1.Rows.Add(parts[0], parts[1]);
                }
                sr.Close();
            }
        }
    }
}
