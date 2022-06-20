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
    
    public partial class Train : Form
    {
        public Train()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CreateFileButton_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream("Поезда.txt", FileMode.Create);
            file.Close();
            OutputText.Items.Add("Файл создан");
        }

        private void AddTrainButton_Click(object sender, EventArgs e)
        {
            OutputText.Items.Clear();
            string path = "Поезда.txt";
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            int number = Convert.ToInt32(NumberTrainText.Text);
            string name = Convert.ToString(NameTrainText.Text);
            int speed = Convert.ToInt32(SpeedTrainText.Text);
            int kupe= Convert.ToInt32(KupeTrainText.Text);
            int platskart = Convert.ToInt32(PlatskartTrainText.Text);
            Trains z = new Trains(number, name, speed, kupe, platskart);
            z.File();
            OutputText.Items.Add(z.ToString());
        }

        private void Train_Load(object sender, EventArgs e)
        {
            this.Show();
        }
        private void ChangeFileButton_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(StrokaChangeText.Text);
            if ((num != 0) && (num > 0))
            {
                string path = "Поезда.txt";
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
                            Trains t = new Trains(number, name, speed, kupe, platskart);
                            if (NumberChangeText.Text != "")
                            {
                                int l = Convert.ToInt32(NumberChangeText.Text);
                                t.setnumber(l);
                            }
                            if (NameChangeText.Text != "")
                            {
                                string l = Convert.ToString(NameChangeText.Text);
                                t.setname(l);
                            }
                            if (SpeedChangeText.Text != "")
                            {
                                int l = Convert.ToInt32(SpeedChangeText.Text);
                                t.setspeed(l);
                            }
                            if (KupeChangeText.Text != "")
                            {
                                int l = Convert.ToInt32(KupeChangeText.Text);
                                t.setkupe(l);
                            }
                            if (PlatskartChangeText.Text != "")
                            {
                                int l = Convert.ToInt32(PlatskartChangeText.Text);
                                t.setplatskart(l);
                            }
                            string line = "";
                            fileContent[i] = t.Vozr(line);
                        }
                    }
                }
                OutputText.Items.Clear();
                File.WriteAllLines(path, fileContent);
                string[] readText = File.ReadAllLines(path, Encoding.UTF8);
                for (int i = 0; i < readText.Length; i++)
                {
                    string[] y = readText[i].Split(new char[] { '|', ' ' },StringSplitOptions.RemoveEmptyEntries);
                    int number = Convert.ToInt32(y[0]);
                    string name = Convert.ToString(y[1]);
                    int speed = Convert.ToInt32(y[2]);
                    int kupe = Convert.ToInt32(y[3]);
                    int platskart = Convert.ToInt32(y[4]);
                    Trains t = new Trains(number, name, speed, kupe, platskart);
                    OutputText.Items.Add(t.ToString());
                }
            }
        }

        private void SearchTrainButton_Click(object sender, EventArgs e)
        {
            OutputText.Items.Clear();
            int numberSearch = Convert.ToInt32(SearchNumberText.Text);
            string path = "Поезда.txt";
            List<string> fileContent = new List<string>();
            fileContent.AddRange(File.ReadAllLines(path));
            for (int s=0; s< fileContent.Count; s++)
            {
                string[] q = fileContent[s].Split(new char[] { ' ','|' }, StringSplitOptions.RemoveEmptyEntries);
              
                    int number2 = Convert.ToInt32(q[0]);
                    if (number2==numberSearch)
                    {
                        string name = Convert.ToString(q[1]);
                        int speed = Convert.ToInt32(q[2]);
                        int kupe = Convert.ToInt32(q[3]);
                        int platskart = Convert.ToInt32(q[4]);
                        Trains z = new Trains(number2, name, speed, kupe, platskart);
                        OutputText.Items.Add(z.ToString());
                    }
              
            }
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OutputText.Items.Clear();
            string path = "Поезда.txt";
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            string t;
            for(int i=0;i<readText.Length;i++)
            {
                string[] s2 = readText[i].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                int l2 = Convert.ToInt32(s2[0]);
                for(int j=0;j< readText.Length;j++)
                {
                    string[]s1 = readText[j].Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    int l1 = Convert.ToInt32(s1[0]);
                    if(l1>l2)
                    {
                        t = readText[j];
                        readText[j] = readText[i];
                        readText[i] = t;
                    }
                }
            }
            for(int j=0;j<readText.Length;j++)
            {
                string[] s = readText[j].Split(new char[] {' ','|'}, StringSplitOptions.RemoveEmptyEntries);
                int number2 = Convert.ToInt32(s[0]);
                string name2 = Convert.ToString(s[1]);
                int speed2 = Convert.ToInt32(s[2]);
                int kupe2 = Convert.ToInt32(s[3]);
                int platskart2 = Convert.ToInt32(s[4]);
                Trains trains2 = new Trains(number2, name2, speed2, kupe2, platskart2);
                OutputText.Items.Add(trains2.ToString());
            }
        }

        private void form2Button_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }
        public class Trains
        {
            public int number;
            public string name;
            public int speed;
            public int kupe;
            public int platskart;

            public Trains(int number, string name, int speed, int kupe, int platskart)
            {
                this.number = number;
                this.name = name;
                this.speed = speed;
                this.kupe = kupe;
                this.platskart = platskart;
            }
            public Trains()
            {
                number = 233;
                name = "Москва-Владивосток";
                speed = 120;
                kupe = 100;
                platskart = 500;
            }

            public override string ToString()
            {
                return String.Format($"{number} | {name} | {speed} | {kupe} | {platskart}");
            }

            public void File()
            {
                string s = number + " |" + name + " |" + speed + " |" + kupe + " |" + platskart;
                StreamWriter sw;
                FileInfo file = new FileInfo("Поезда.txt");
                sw = file.AppendText();
                sw.WriteLine(s);
                sw.Close();
            }
            public string Vozr(string s)
            {
                return s = number + " |" + name + " |" + speed + " |" + kupe + " |" + platskart;
            }
            public void setname(string b)
            {
                name = b;
            }
            public void setnumber(int c)
            {
                number = c;
            }
            public void setspeed(int d)
            {
                speed = d;
            }
            public void setkupe(int e)
            {
                kupe = e;
            }
            public void setplatskart(int f)
            {
                platskart = f;
            }
        }
        public class Electrichka : Trains
        {
            public int numberPlace;
            public Electrichka(int number, string name, int speed, int kupe, int platskart, int numberPlace) : base(number, name, speed, kupe, platskart)
            {
                this.numberPlace = numberPlace;
            }
            public Electrichka()
            {
                numberPlace = 100;
            }
            public override string ToString()
            {
                return String.Format($"{number} | {name} | {speed} | {kupe} | {platskart} | {numberPlace}");
            }
            public void File()
            {
                string s = number + " |" + name + " |" + speed + " |" + kupe + " |" + platskart + " |" + numberPlace;
                StreamWriter sw;
                FileInfo file = new FileInfo("Электрички.txt");
                sw = file.AppendText();
                sw.WriteLine(s);
                sw.Close();
            }
            public string Vozr(string s)
            {
                return s = number + " |" + name + " |" + speed + " |" + kupe + " |" + platskart + " |" + numberPlace;
            }

            public void setplace(int g)
            {
                if (g < 10000)
                {
                    numberPlace = g;
                }
                else
                {
                    Train.ActiveForm.Close();
                }
            }
            public void setnumberPlace(int q)
            {
                numberPlace = q;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutputText.Items.Clear();
            string path = "Поезда.txt";
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
                    if(result>0)
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
                Trains trains3 = new Trains(number3, name3, speed3, kupe3, platskart3);
                OutputText.Items.Add(trains3.ToString());
            }
        }
    }
    }
    

