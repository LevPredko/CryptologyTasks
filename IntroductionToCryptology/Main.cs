using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntroductionToCryptology
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Location = new System.Drawing.Point(10, 10);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            string selectedTask = comboBox1.SelectedItem?.ToString();

            if (selectedTask == "Task 1")
            {
                Task1 task1 = new Task1();
                task1.Show();
            } else if (selectedTask == "Task 2")
            {
                Task2 task2 = new Task2();
                task2.Show();
            }
            else if (selectedTask == "Task 4")
            {
                Task4 task4 = new Task4();
                task4.Show();
            }
        }
    }
}
