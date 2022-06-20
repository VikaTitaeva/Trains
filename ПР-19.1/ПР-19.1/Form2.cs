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

namespace ПР_19._1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Train f)
        {
            InitializeComponent();

        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void CreateFileButtonElectr_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream("Электрички.txt", FileMode.Create);
            file.Close();
            OutputTextElectr.Items.Add("Файл создан");
        }

        private void AddElectrButton_Click(object sender, EventArgs e)
        {

            OutputTextElectr.Items.Clear();
            string path = "Электрички.txt";
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            int number = Convert.ToInt32(NumberElectrText.Text);
            string name = Convert.ToString(NameElectrText.Text);
            int speed = Convert.ToInt32(SpeedElectrText.Text);
            int kupe = Convert.ToInt32(KupeElectrText.Text);
            int platskart = Convert.ToInt32(PlatskartElectrText.Text);
            int numberPlace = Convert.ToInt32(NumberPlaceElectrText.Text);
            Train.Electrichka electr = new Train.Electrichka(number, name, speed, kupe, platskart, numberPlace);
            electr.File();
            OutputTextElectr.Items.Add(electr.ToString());
        }

        private void Goform1button_Click(object sender, EventArgs e)
        {
            Train form = new Train();
            form.Show();
        }

        private void ChangeElectrFileButton_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(StrokaElectrChangeText.Text);
            if ((num != 0) && (num > 0))
            {
                string path = "Электрички.txt";
                List<string> fileContent = new List<string>();
                fileContent.AddRange(File.ReadAllLines(path));
                if (fileContent.Count >= num)
                {
                    for (int i = 0; i < fileContent.Count; i++)
                    {
                        if (i == (num - 1))
                        {
                            string[] y = fileContent[i].Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            int number = Convert.ToInt32(y[0]);
                            string name = Convert.ToString(y[1]);
                            int speed = Convert.ToInt32(y[2]);
                            int kupe = Convert.ToInt32(y[3]);
                            int platskart = Convert.ToInt32(y[4]);
                            int numberPlace = Convert.ToInt32(y[5]);
                            Train.Electrichka t = new Train.Electrichka(number, name, speed, kupe, platskart, numberPlace);
                            if (NumberElectrChangeText.Text != "")
                            {
                                int l = Convert.ToInt32(NumberElectrChangeText.Text);
                                t.setnumber(l);
                            }
                            if (NameElectrChangeText.Text != "")
                            {
                                string l = Convert.ToString(NameElectrChangeText.Text);
                                t.setname(l);
                            }
                            if (SpeedElectrChangeText.Text != "")
                            {
                                int l = Convert.ToInt32(SpeedElectrChangeText.Text);
                                t.setspeed(l);
                            }
                            if (KupeElectrChangeText.Text != "")
                            {
                                int l = Convert.ToInt32(KupeElectrChangeText.Text);
                                t.setkupe(l);
                            }
                            if (PlatskartElectrChangeText.Text != "")
                            {
                                int l = Convert.ToInt32(PlatskartElectrChangeText.Text);
                                t.setplatskart(l);
                            }
                            if (ChangeNumberPlaceElectrText.Text != "")
                            {
                                int l = Convert.ToInt32(ChangeNumberPlaceElectrText.Text);
                                t.setnumberPlace(l);
                            }
                            string line = "";
                            fileContent[i] = t.Vozr(line);
                        }
                    }
                }
                OutputTextElectr.Items.Clear();
                File.WriteAllLines(path, fileContent);
                string[] readText = File.ReadAllLines(path, Encoding.UTF8);
                for (int j = 0; j < readText.Length; j++)
                {
                    string[] y = readText[j].Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int number = Convert.ToInt32(y[0]);
                    string name = Convert.ToString(y[1]);
                    int speed = Convert.ToInt32(y[2]);
                    int kupe = Convert.ToInt32(y[3]);
                    int platskart = Convert.ToInt32(y[4]);
                    int numberPlace = Convert.ToInt32(y[5]);
                    Train.Electrichka t = new Train.Electrichka(number, name, speed, kupe, platskart, numberPlace);
                    OutputTextElectr.Items.Add(t.ToString());
                }
            }
        }

        private void NumberSortElectrButton_Click(object sender, EventArgs e)
        {
            OutputTextElectr.Items.Clear();
            string path = "Электрички.txt";
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            string t;
            for (int i = 0; i < readText.Length; i++)
            {
                string[] s2 = readText[i].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                int l2 = Convert.ToInt32(s2[0]);
                for (int j = 0; j < readText.Length; j++)
                {
                    string[] s1 = readText[j].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    int l1 = Convert.ToInt32(s1[0]);
                    if (l1 > l2)
                    {
                        t = readText[j];
                        readText[j] = readText[i];
                        readText[i] = t;
                    }
                }
            }
            for (int j = 0; j < readText.Length; j++)
            {
                string[] s = readText[j].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                int number2 = Convert.ToInt32(s[0]);
                string name2 = Convert.ToString(s[1]);
                int speed2 = Convert.ToInt32(s[2]);
                int kupe2 = Convert.ToInt32(s[3]);
                int platskart2 = Convert.ToInt32(s[4]);
                int numberPlace2 = Convert.ToInt32(s[5]);
                Train.Electrichka electr2 = new Train.Electrichka(number2, name2, speed2, kupe2, platskart2, numberPlace2);
                OutputTextElectr.Items.Add(electr2.ToString());
            }
        }

        private void NameSortElectrButton_Click(object sender, EventArgs e)
        {
            OutputTextElectr.Items.Clear();
            string path = "Электрички.txt";
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            string v;
            for (int i = 0; i < readText.Length; i++)
            {
                string[] s2 = readText[i].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                string nm2 = Convert.ToString(s2[1]);
                for (int j = 0; j < readText.Length; j++)
                {
                    string[] s1 = readText[j].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string nm1 = Convert.ToString(s1[1]);
                    int result = string.Compare(nm1, nm2);
                    if (result > 0)
                    {
                        v = readText[j];
                        readText[j] = readText[i];
                        readText[i] = v;
                    }
                }
            }
            for (int j = 0; j < readText.Length; j++)
            {
                string[] x = readText[j].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                int number3 = Convert.ToInt32(x[0]);
                string name3 = Convert.ToString(x[1]);
                int speed3 = Convert.ToInt32(x[2]);
                int kupe3 = Convert.ToInt32(x[3]);
                int platskart3 = Convert.ToInt32(x[4]);
                int numberPlace3 = Convert.ToInt32(x[5]);
                Train.Electrichka electr3 = new Train.Electrichka(number3, name3, speed3, kupe3, platskart3, numberPlace3);
                OutputTextElectr.Items.Add(electr3.ToString());
            }
        }

        private void SearchElectrButton_Click(object sender, EventArgs e)
        {
            OutputTextElectr.Items.Clear();
            int numberSearch = Convert.ToInt32(SearchElectrNumberText.Text);
            string path = "Электрички.txt";
            List<string> fileContent = new List<string>();
            fileContent.AddRange(File.ReadAllLines(path));
            for (int s = 0; s < fileContent.Count; s++)
            {
                string[] q = fileContent[s].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                int number2 = Convert.ToInt32(q[0]);
                if (number2 == numberSearch)
                {
                    string name = Convert.ToString(q[1]);
                    int speed = Convert.ToInt32(q[2]);
                    int kupe = Convert.ToInt32(q[3]);
                    int platskart = Convert.ToInt32(q[4]);
                    int numberPlace = Convert.ToInt32(q[5]);
                    Train.Electrichka z = new Train.Electrichka(number2, name, speed, kupe, platskart, numberPlace);
                    OutputTextElectr.Items.Add(z.ToString());
                }

            }
        }

        private void StrokaElectrChangeText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



