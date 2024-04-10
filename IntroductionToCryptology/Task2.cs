using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntroductionToCryptology
{
    public partial class Task2 : Form
    {
        Dictionary<char, char> symbolMap = new Dictionary<char, char>();
        static List<char> GetAllEnglishLettersDigitsAndSymbols()
        {
            List<char> allChars = new List<char>();

            // Додаємо англійські великі та малі літери
            for (char c = 'A'; c <= 'Z'; c++)
            {
                allChars.Add(c);
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                allChars.Add(c);
            }

            // Додаємо цифри
            for (char c = '0'; c <= '9'; c++)
            {
                allChars.Add(c);
            }

            // Додаємо символи
            for (char c = '!'; c <= '/'; c++)
            {
                allChars.Add(c);
            }

            for (char c = '['; c <= '`'; c++)
            {
                allChars.Add(c);
            }

            for (char c = '{'; c <= '~'; c++)
            {
                allChars.Add(c);
            }

            return allChars;
        }

        static Dictionary<char, char> CreateMap(string input)
        {
            Random random = new Random();
            Dictionary<char, char> charMap = new Dictionary<char, char>();

            //List<char> availableChars = Enumerable.Range(char.MinValue, char.MaxValue).Select(x => (char)x).ToList();
            List<char> availableChars = GetAllEnglishLettersDigitsAndSymbols();
            foreach (char c in input)
            {
                if (!charMap.ContainsKey(c))
                {
                    char randomChar = GetRandomChar(random, availableChars);
                    charMap[c] = randomChar;
                    availableChars.Remove(randomChar);
                }
            }

            return charMap;
        }

        static char GetRandomChar(Random random, List<char> availableChars)
        {
            int index = random.Next(availableChars.Count);
            char randomChar = availableChars[index];
            return randomChar;
        }

        public Task2()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select a File";
            radioButton1.Checked = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Run
            if (radioButton2.Checked)
            {
                // Create a reverse mapping based on the values in dataGridView1
                Dictionary<char, char> reverseMap = new Dictionary<char, char>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        string keyString = row.Cells[0].Value.ToString();
                        string valueString = row.Cells[1].Value.ToString();

                        if (keyString.Length == 1 && valueString.Length == 1)
                        {
                            char key = keyString[0];
                            char value = valueString[0];
                            reverseMap[value] = key;
                        }
                        else if (keyString.Length == 0 && valueString.Length == 1)
                        {
                            // Handle spaces (if needed)
                            char value = valueString[0];
                            reverseMap[' '] = value;
                        }
                        else
                        {
                            // Handle invalid characters (e.g., display an error message)
                            MessageBox.Show("Invalid character in dataGridView1");
                            return;
                        }
                    }
                }

                string encryptedText = textBox1.Text;
                StringBuilder decryptedText = new StringBuilder();

                foreach (char encryptedChar in encryptedText)
                {
                    char decryptedChar;
                    if (reverseMap.TryGetValue(encryptedChar, out decryptedChar))
                    {
                        decryptedText.Append(decryptedChar);
                    }
                    else
                    {
                        // Handle characters not found in the reverseMap (if needed)
                        decryptedText.Append(encryptedChar);
                    }
                }

                // Display the decrypted text in textBox2
                textBox2.Text = decryptedText.ToString();
            }
            else
            {
                String mainText = textBox1.Text;
                Dictionary<char, char> charMap = CreateMap(mainText);
                symbolMap = charMap;
                dataGridView1.Rows.Clear();
                foreach (KeyValuePair<char, char> entry in symbolMap)
                {
                    dataGridView1.Rows.Add(entry.Key, entry.Value);
                }

                string encryptedText = "";
                for (int i = 0; i < mainText.Length; i++)
                {
                    if (mainText[i] == ' ')
                    {
                        encryptedText += ' ';
                    }
                    else
                    {
                        encryptedText += charMap[mainText[i]];
                    }
                }
                textBox2.Text = encryptedText;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Save data from data grid
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
                sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString() + "@" + dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Save data from data grid
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
                sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString() + "@" + dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
            sw.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Run
            if (radioButton2.Checked)
            {
                // Create a reverse mapping based on the values in dataGridView1
                Dictionary<char, char> reverseMap = new Dictionary<char, char>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        string keyString = row.Cells[0].Value.ToString();
                        string valueString = row.Cells[1].Value.ToString();

                        if (keyString.Length == 1 && valueString.Length == 1)
                        {
                            char key = keyString[0];
                            char value = valueString[0];
                            reverseMap[value] = key;
                        }
                        else if (keyString.Length == 0 && valueString.Length == 1)
                        {
                            // Handle spaces (if needed)
                            char value = valueString[0];
                            reverseMap[' '] = value;
                        }
                        else
                        {
                            // Handle invalid characters (e.g., display an error message)
                            MessageBox.Show("Invalid character in dataGridView1");
                            return;
                        }
                    }
                }

                string encryptedText = textBox1.Text;
                StringBuilder decryptedText = new StringBuilder();

                foreach (char encryptedChar in encryptedText)
                {
                    char decryptedChar;
                    if (reverseMap.TryGetValue(encryptedChar, out decryptedChar))
                    {
                        decryptedText.Append(decryptedChar);
                    }
                    else
                    {
                        // Handle characters not found in the reverseMap (if needed)
                        decryptedText.Append(encryptedChar);
                    }
                }

                // Display the decrypted text in textBox2
                textBox2.Text = decryptedText.ToString();
            }
            else
            {
                String mainText = textBox1.Text;
                Dictionary<char, char> charMap = CreateMap(mainText);
                symbolMap = charMap;
                dataGridView1.Rows.Clear();
                foreach (KeyValuePair<char, char> entry in symbolMap)
                {
                    dataGridView1.Rows.Add(entry.Key, entry.Value);
                }

                string encryptedText = "";
                for (int i = 0; i < mainText.Length; i++)
                {
                    if (mainText[i] == ' ')
                    {
                        // Handle spaces (if needed)
                        encryptedText += ' ';
                    }
                    else
                    {
                        encryptedText += charMap[mainText[i]];
                    }
                }
                textBox2.Text = encryptedText;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

                // Load data from file and display in data grid
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
                        string[] parts = line.Split('@');
                        dataGridView1.Rows.Add(parts[0], parts[1]);
                    }
                    sr.Close();
                }
            
        }
    }
}
