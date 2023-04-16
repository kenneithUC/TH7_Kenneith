using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH_7_Kenneith
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        PictureBox pictureBox1;
        Button[]button1=new Button[3];
        Button[,]button2=new Button[10,10];
        Random rnd = new Random();
        Label label1,layar,kursipilih;
        Button submit,reset;
        Form1 form1;
        Form2 form2;
        string kursi="";
        int Movienumber = Convert.ToInt32(Form1.movietype);
        public static List<String> Moviejam = new List<String>();
        int moviejamtype;
        int x, y,t,u;
        int counter = 0;
        char[] angkabesar = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'j' };

        public void tampilkursi()
        {
            t = 40;
            u = 0;
            int probability = rnd.Next(0, 70);
            int count = 0;
            panel1.Controls.Clear();

            layar = new Label();
            layar.Text = "--------------------------------------LAYAR--------------------------------------";
            layar.Location = new Point(35, 500);
            layar.Font = new Font("Arial", 15, FontStyle.Bold);
            layar.Size = new Size(1000, 20);
            layar.ForeColor = Color.Black;
            this.panel1.Controls.Add(layar);

            reset = new Button();
            reset.Location = new Point(520, 520);
            reset.Size = new Size(100, 30);
            reset.Font = new Font("Arial", 15, FontStyle.Bold);
            reset.ForeColor = Color.Black;
            reset.BackColor = Color.Orange;
            reset.Text = "Reset";
            reset.Click += Reset_Click;
            this.panel1.Controls.Add(reset);

            submit = new Button();
            submit.Location = new Point(35, 520);
            submit.Size = new Size(480, 30);
            submit.Font = new Font("Arial", 12, FontStyle.Bold);
            submit.ForeColor = Color.Black;
            submit.BackColor = Color.Orange;
            submit.Text = "Confirm Order";
            submit.Click += Submit_Click;
            this.panel1.Controls.Add(submit);

            if (Form1.film[Movienumber, moviejamtype]==null)
            {
                Form1.film[Movienumber, moviejamtype] = new List<Button>();
                counter = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        int warna = rnd.Next(2);
                        button2[i, j] = new Button();
                        button2[i, j].Location = new Point(t, u);
                        button2[i, j].Size = new Size(50, 50);
                        button2[i, j].ForeColor = Color.Black;
                        button2[i, j].Font = new Font("Arial", 10, FontStyle.Bold);
                        button2[i, j].Text = angkabesar[counter].ToString() + (j + 1);
                        button2[i,j].Tag= (angkabesar[counter].ToString() + (j + 1)).ToString();
                        button2[i, j].Click += Form2_Click1;
                        if (count < probability && warna == 0)
                        {
                            button2[i, j].BackColor = Color.Red;
                            count++;
                            button2[i, j].Enabled = false;
                        }
                        else
                        {
                            button2[i, j].BackColor = Color.Green;
                        }

                        Form1.film[Movienumber, moviejamtype].Add(button2[i, j]);
                        t += 60;
                    }
                    u += 50;
                    t = 40;
                    counter++;
                }
                foreach (Button button in Form1.film[Movienumber, moviejamtype])
                {
                    this.panel1.Controls.Add(button);
                }
            }
            else
            {
                foreach (Button button in Form1.film[Movienumber, moviejamtype])
                {
                    this.panel1.Controls.Add(button);
                }
            }
        }
        List<string> kodeKursi = new List<string>();
        private void Form2_Click1(object sender, EventArgs e)
        {
            var send = sender as Button;
            if(send.BackColor==Color.Green)
            {
                send.BackColor = Color.Red;
                kursi=send.Tag.ToString();
                kodeKursi.Add(kursi);
                kursipilih.Text = "";
                kursipilih.Text = "kursi dipilih: ";
                foreach (string k in kodeKursi)
                {
                    kursipilih.Text += k;
                }
                this.Controls.Add(kursipilih);
            }
            else if(send.BackColor==Color.Red)
            {
                kursi = send.Tag.ToString();
                kodeKursi.Remove(kursi);
                kursipilih.Text = "";
                kursipilih.Text = "kursi dipilih: ";
                foreach (string k in kodeKursi)
                {
                    kursipilih.Text += k;
                }
                send.BackColor = Color.Green;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Tan;

            x =520;
            y =0;
            for (int i = 0; i < 3; i++)
            {
                button1[i] = new Button();
                button1[i].Location = new Point(x,y);
                button1[i].Size = new Size(200, 50);
                button1[i].ForeColor = Color.Black;
                button1[i].Font = new Font("Arial", 20, FontStyle.Bold);
                button1[i].Tag = i.ToString();
                button1[i].Click += Form2_Click;
                this.Controls.Add(button1[i]);
                x += 200;
            }

            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(300, 350);
            pictureBox1.Location = new Point(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox1);

            label1 = new Label();
            label1.Size = new Size(300, 200);
            label1.Location = new Point(50,400);
            label1.Font = new Font("Arial", 12, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            this.Controls.Add(label1);

            submit = new Button();
            submit.Location = new Point(520, 630);
            submit.Size = new Size(600, 30);
            submit.Font = new Font("Arial", 15, FontStyle.Bold);
            submit.ForeColor = Color.Black;
            submit.BackColor = Color.Orange;
            submit.Text = "Confirm Order";
            submit.Click += Submit_Click;
            this.panel1.Controls.Add(submit);

            kursipilih= new Label();
            kursipilih.Size = new Size(200, 200);
            kursipilih.Location = new Point(45, 650);
            kursipilih.Font = new Font("Arial", 12, FontStyle.Bold);
            kursipilih.ForeColor = Color.Black;
            kursipilih.Text = "kursi dipilih: ";
            this.Controls.Add(kursipilih);


            switch (Movienumber)
            {
                case 1:
                    pictureBox1.Image = Image.FromFile(Form1.@moviepicture[0]);
                    label1.Text = "Armed with the astonishing ability to shrink in scale but increase in strength, con-man Scott Lang must embrace his inner-hero and help his mentor, Dr. Hank Pym, protect the secret behind his spectacular Ant-Man suit from a new generation of towering threats. Against seemingly insurmountable obstacles, Pym and Lang must plan and pull off a heist that will save the world.";
                    button1[0].Text = "14:00";
                    button1[1].Text = "17:00";
                    button1[2].Text = "21:00";
                    break;
                case 2:

                    pictureBox1.Image = Image.FromFile(Form1.@moviepicture[1]);
                    label1.Text = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.";
                    button1[0].Text = "13:00";
                    button1[1].Text = "15:00";
                    button1[2].Text = "19:00";
                    break;
                case 3:
                    pictureBox1.Image = Image.FromFile(Form1.@moviepicture[7]);
                    label1.Text = "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela.";
                    button1[0].Text = "10:00";
                    button1[1].Text = "13:00";
                    button1[2].Text = "20:00";
                    break;
                case 4:
                    pictureBox1.Image = Image.FromFile(Form1.@moviepicture[2]);
                    label1.Text = "The people of Wakanda fight to protect their home from intervening world powers as they mourn the death of King T'Challa";
                    button1[0].Text = "16:00";
                    button1[1].Text = "18:00";
                    button1[2].Text = "22:00";
                    break;
                case 5:
                    pictureBox1.Image = Image.FromFile(Form1.@moviepicture[4]);
                    label1.Text = "While on a journey of physical and spiritual healing, a brilliant neurosurgeon is drawn into the world of the mystic arts.";
                    button1[0].Text = "12:00";
                    button1[1].Text = "16:00";
                    button1[2].Text = "22:00";
                    break;
                case 6:
                    pictureBox1.Image = Image.FromFile(Form1.@moviepicture[3]);
                    label1.Text = "Bruce Banner, a scientist on the run from the U.S. Government, must find a cure for the monster he turns into whenever he loses his temper.";
                    button1[0].Text = "13:00";
                    button1[1].Text = "19:00";
                    button1[2].Text = "23:00";
                    break;
                case 7:
                    pictureBox1.Image = Image.FromFile(Form1.@moviepicture[5]);
                    label1.Text = "When Tony Stark's world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.";
                    button1[0].Text = "10:00";
                    button1[1].Text = "19:00";
                    button1[2].Text = "23:00";
                    break;
                case 8:
                    pictureBox1.Image = Image.FromFile(Form1.@moviepicture[6]);
                    label1.Text = "After Peter Parker is bitten by a genetically altered spider, he gains newfound, spider-like powers and ventures out to save the city from the machinations of a mysterious reptilian foe.";
                    button1[0].Text = "09:00";
                    button1[1].Text = "15:00";
                    button1[2].Text = "22:00";
                    break;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            foreach (Button button in Form1.film[Movienumber, moviejamtype])
            {
                button.Enabled = true;
                button.BackColor = Color.Green;
            }
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            foreach(Button button in Form1.film[Movienumber, moviejamtype])
            {
                if(button.BackColor==Color.Red)
                {
                    button.Enabled = false;
                }
            }
            this.Controls.Clear();
            form1 = new Form1();
            form1.TopLevel = false;
            form1.Dock = DockStyle.Fill;
            this.Controls.Add(form1);
            form1.Show();
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            var send = sender as MenuStrip;
            for(int i=0;i<3;i++)
            {
                if (sender == button1[i])
                {
                    moviejamtype = Convert.ToInt32(button1[i].Tag.ToString());
                }
            }
            tampilkursi();
        }

    }
}
