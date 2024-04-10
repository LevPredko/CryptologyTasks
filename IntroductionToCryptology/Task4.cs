using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IntroductionToCryptology
{
    public class Task4 : Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Button startAppButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox inputTextBox;
        private TextBox inputKeyBox;
        private TextBox encryptedTextBox;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button saveDataButton;
        private Button loadDataButton;
        private ComboBox chooseTypeBox;

        public Task4()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.startAppButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.inputKeyBox = new System.Windows.Forms.TextBox();
            this.encryptedTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.chooseTypeBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.startAppButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputKeyBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.encryptedTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chooseTypeBox, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // startAppButton
            // 
            this.startAppButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.startAppButton.Location = new System.Drawing.Point(317, 463);
            this.startAppButton.Margin = new System.Windows.Forms.Padding(23, 3, 23, 3);
            this.startAppButton.Name = "startAppButton";
            this.startAppButton.Size = new System.Drawing.Size(248, 42);
            this.startAppButton.TabIndex = 9;
            this.startAppButton.Text = "Start";
            this.startAppButton.UseVisualStyleBackColor = true;
            this.startAppButton.Click += new System.EventHandler(this.startAppButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(297, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input text:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(591, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Text:";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextBox.Location = new System.Drawing.Point(3, 79);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(288, 378);
            this.inputTextBox.TabIndex = 3;
            // 
            // inputKeyBox
            // 
            this.inputKeyBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputKeyBox.Location = new System.Drawing.Point(297, 79);
            this.inputKeyBox.Multiline = true;
            this.inputKeyBox.Name = "inputKeyBox";
            this.inputKeyBox.Size = new System.Drawing.Size(288, 378);
            this.inputKeyBox.TabIndex = 4;
            // 
            // encryptedTextBox
            // 
            this.encryptedTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.encryptedTextBox.Location = new System.Drawing.Point(591, 79);
            this.encryptedTextBox.Multiline = true;
            this.encryptedTextBox.Name = "encryptedTextBox";
            this.encryptedTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.encryptedTextBox.Size = new System.Drawing.Size(290, 378);
            this.encryptedTextBox.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.saveDataButton);
            this.flowLayoutPanel1.Controls.Add(this.loadDataButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 463);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(288, 95);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(3, 3);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(88, 42);
            this.saveDataButton.TabIndex = 0;
            this.saveDataButton.Text = "Save Data";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // loadDataButton
            // 
            this.loadDataButton.Location = new System.Drawing.Point(197, 3);
            this.loadDataButton.Margin = new System.Windows.Forms.Padding(103, 3, 3, 3);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(88, 42);
            this.loadDataButton.TabIndex = 1;
            this.loadDataButton.Text = "Load Data";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // chooseTypeBox
            // 
            this.chooseTypeBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.chooseTypeBox.FormattingEnabled = true;
            this.chooseTypeBox.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.chooseTypeBox.Location = new System.Drawing.Point(591, 463);
            this.chooseTypeBox.Name = "chooseTypeBox";
            this.chooseTypeBox.Size = new System.Drawing.Size(290, 21);
            this.chooseTypeBox.TabIndex = 8;
            this.chooseTypeBox.Text = "Choose type";
            // 
            // Lab4
            // 
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Lab4";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|JSON files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                var data = new
                {
                    InputText = inputTextBox.Text,
                    Key = inputKeyBox.Text,
                    EncryptedText = encryptedTextBox.Text
                };

                string outputData;

                if (Path.GetExtension(filePath) == ".json")
                {
                    outputData = JsonConvert.SerializeObject(data);
                }
                else
                {
                    outputData = $"Input text: {data.InputText}\nKey: {data.Key}\nEncrypted text: {data.EncryptedText}";
                }

                File.WriteAllText(filePath, outputData);
            }
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|JSON files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string inputData = File.ReadAllText(filePath);

                if (Path.GetExtension(filePath) == ".json")
                {
                    var data = JsonConvert.DeserializeObject<dynamic>(inputData);
                    inputTextBox.Text = data.InputText;
                    inputKeyBox.Text = data.Key;
                    encryptedTextBox.Text = data.EncryptedText;
                }
                else
                {
                    var lines = inputData.Split('\n');
                    inputTextBox.Text = lines[0].Split(new string[] { ": " }, StringSplitOptions.None)[1];
                    inputKeyBox.Text = lines[1].Split(new string[] { ": " }, StringSplitOptions.None)[1];
                    encryptedTextBox.Text = lines[2].Split(new string[] { ": " }, StringSplitOptions.None)[1];
                }
            }
        }

        private void startAppButton_Click(object sender, EventArgs e)
        {
            string alphabet = "";
            for (int i = 0; i < 256; i++)
            {
                alphabet += (char)i;
            }

            string inputText = inputTextBox.Text;
            string key = inputKeyBox.Text;
            string result = "";

            for (int i = 0; i < inputText.Length; i++)
            {
                int inputPos = alphabet.IndexOf(inputText[i]);
                int keyPos = alphabet.IndexOf(key[i % key.Length]);
                int resPos;

                if (chooseTypeBox.Text == "Encrypt")
                {
                    resPos = (inputPos + keyPos) % alphabet.Length;
                }
                else // Decrypt
                {
                    resPos = (inputPos - keyPos + alphabet.Length) % alphabet.Length;
                }

                result += alphabet[resPos];
            }

            if (chooseTypeBox.Text == "Encrypt")
            {
                encryptedTextBox.Text = result;
            }
            else // Decrypt
            {
                inputTextBox.Text = result;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
