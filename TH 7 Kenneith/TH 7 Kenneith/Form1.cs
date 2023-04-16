using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace TH_7_Kenneith
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PictureBox antman;
        PictureBox avengersendgame;
        PictureBox blackPanther;
        PictureBox Hulk;
        PictureBox doctorstrange;
        PictureBox ironman3;
        PictureBox spiderman;
        PictureBox thorragnarok;
        Label cinema;
        Label labelantman;
        Label labelavenger;
        Label labelblackpanther;
        Label labelHulk;
        Label labeldoctorstrange;
        Label labelironman3;
        Label labelspiderman;
        Label labelthorragnarok;
        Button buttonantman;
        Button buttonavenger;
        Button buttonblackpanther;
        Button buttonHulk;
        Button buttondoctorstrange;
        Button buttonironman3;
        Button buttonspiderman;
        Button buttonthorragnarok;

        public static List<Button>[,] film = new List<Button>[100, 100];
        private Color[] colors = new Color[] { Color.Orange,Color.Black};
        private int currentColor = 0;
        private Timer timer;
        string wordlist =File.ReadAllText(@"C:\Users\ROG\Documents\wordlist movie appdev.txt fix.txt");
        public static List<string> moviepicture = new List<string>();
        public static List<string> moviename = new List<string>();
        public static string movietype;

        Form2 form2;
        Form1 form1;
        private void Form1_Load(object sender, EventArgs e)
        {
            string[]title=wordlist.Split(',');
            foreach(string s in title)
            {
                if (s[0]=='C')
                {
                    moviepicture.Add(s);
                }
                else
                {
                    moviename.Add(s);
                }
            }
            this.BackColor = Color.Tan;
            timer = new Timer();
            timer.Interval = 3000; // Set the timer interval to 50 milliseconds (20 frames per second)
            timer.Tick += Timer_Tick;
            timer.Start(); // Start the timer
            //title
            cinema = new Label();
            cinema.Text = "Ming Mang Suang Muzzikss Cinema";
            cinema.Font = new Font("Arial", 24, FontStyle.Bold);
            cinema.Location = new Point(380, 10);
            cinema.Size = new Size(600, 37);
            cinema.ForeColor = Color.Black;
            this.Controls.Add(cinema);
            //movie1
            antman = new PictureBox();
            antman.Image = Image.FromFile(@moviepicture[0]);
            antman.SizeMode=PictureBoxSizeMode.StretchImage;
            antman.Location = new Point(10, 10);
            antman.Size = new Size(212, 208);
            this.panel1.Controls.Add(antman);

            labelantman = new Label();
            labelantman.Text = @moviename[0];
            labelantman.Font= new Font("Arial", 15, FontStyle.Bold);
            labelantman.Size = new Size(100, 20);
            labelantman.ForeColor = Color.Black;
            labelantman.Location = new Point(150, 307);
            this.Controls.Add(labelantman);

            buttonantman=new Button();
            buttonantman.Text = "ORDER NOW";
            buttonantman.Font = new Font("Arial", 15, FontStyle.Bold);
            buttonantman.Size = new Size(200, 30);
            buttonantman.BackColor = Color.Orange;
            buttonantman.Location = new Point(100, 335);
            buttonantman.Click += Buttonantman_Click;
            buttonantman.Tag = "1";
            this.Controls.Add(buttonantman);

            //movie2
            avengersendgame = new PictureBox();
            avengersendgame.Image = Image.FromFile(@moviepicture[1]);
            avengersendgame.SizeMode = PictureBoxSizeMode.StretchImage;
            avengersendgame.Location = new Point(10, 10);
            avengersendgame.Size = new Size(212, 208);
            this.panel2.Controls.Add(avengersendgame);

            labelavenger = new Label();
            labelavenger.Text = @moviename[1];
            labelavenger.Font = new Font("Arial", 15, FontStyle.Bold);
            labelavenger.Size = new Size(300, 24);
            labelavenger.ForeColor = Color.Black;
            labelavenger.Location = new Point(400, 307);
            this.Controls.Add(labelavenger);

            buttonavenger = new Button();
            buttonavenger.Text = "ORDER NOW";
            buttonavenger.Font = new Font("Arial", 15, FontStyle.Bold);
            buttonavenger.Size = new Size(200, 30);
            buttonavenger.BackColor = Color.Orange;
            buttonavenger.Location = new Point(405, 335);
            buttonavenger.Click += Buttonavenger_Click;
            buttonavenger.Tag = "2";
            this.Controls.Add(buttonavenger);
            //movie3
            blackPanther = new PictureBox();
            blackPanther.Image = Image.FromFile(@moviepicture[2]);
            blackPanther.SizeMode = PictureBoxSizeMode.StretchImage;
            blackPanther.Location = new Point(10, 10);
            blackPanther.Size = new Size(212, 208);
            this.panel3.Controls.Add(blackPanther);

            labelblackpanther = new Label();
            labelblackpanther.Text = @moviename[2];
            labelblackpanther.Font = new Font("Arial", 15, FontStyle.Bold);
            labelblackpanther.Size = new Size(300, 24);
            labelblackpanther.ForeColor = Color.Black;
            labelblackpanther.Location = new Point(1070, 307);
            this.Controls.Add(labelblackpanther);

            buttonblackpanther = new Button();
            buttonblackpanther.Text = "ORDER NOW";
            buttonblackpanther.Font = new Font("Arial", 15, FontStyle.Bold);
            buttonblackpanther.Size = new Size(200, 30);
            buttonblackpanther.BackColor = Color.Orange;
            buttonblackpanther.Location = new Point(715, 335);
            buttonblackpanther.Click += Buttonblackpanther_Click;
            buttonblackpanther.Tag = "3";
            this.Controls.Add(buttonblackpanther);
            //movie4
            Hulk = new PictureBox();
            Hulk.Image = Image.FromFile(@moviepicture[3]);
            Hulk.SizeMode = PictureBoxSizeMode.StretchImage;
            Hulk.Location = new Point(10, 10);
            Hulk.Size = new Size(212, 208);
            this.panel4.Controls.Add(Hulk);

            labelHulk = new Label();
            labelHulk.Text = @moviename[3];
            labelHulk.Font = new Font("Arial", 15, FontStyle.Bold);
            labelHulk.Size = new Size(300, 24);
            labelHulk.ForeColor = Color.Black;
            labelHulk.Location = new Point(420, 605);
            this.Controls.Add(labelHulk);

            buttonHulk = new Button();
            buttonHulk.Text = "ORDER NOW";
            buttonHulk.Font = new Font("Arial", 15, FontStyle.Bold);
            buttonHulk.Size = new Size(200, 30);
            buttonHulk.BackColor = Color.Orange;
            buttonHulk.Location = new Point(1040, 335);
            buttonHulk.Click += ButtonHulk_Click;
            buttonHulk.Tag = "4";
            this.Controls.Add(buttonHulk);
            //movie5
            doctorstrange = new PictureBox();
            doctorstrange.Image = Image.FromFile(@moviepicture[4]);
            doctorstrange.SizeMode = PictureBoxSizeMode.StretchImage;
            doctorstrange.Location = new Point(10, 10);
            doctorstrange.Size = new Size(212, 208);
            this.panel5.Controls.Add(doctorstrange);

            labeldoctorstrange = new Label();
            labeldoctorstrange.Text = @moviename[4];
            labeldoctorstrange.Font = new Font("Arial", 15, FontStyle.Bold);
            labeldoctorstrange.Size = new Size(300, 24);
            labeldoctorstrange.ForeColor = Color.Black;
            labeldoctorstrange.Location = new Point(125, 605);
            this.Controls.Add(labeldoctorstrange);

            buttondoctorstrange = new Button();
            buttondoctorstrange.Text = "ORDER NOW";
            buttondoctorstrange.Font = new Font("Arial", 15, FontStyle.Bold);
            buttondoctorstrange.Size = new Size(200, 30);
            buttondoctorstrange.BackColor = Color.Orange;
            buttondoctorstrange.Location = new Point(100, 635);
            buttondoctorstrange.Click += Buttondoctorstrange_Click;
            buttondoctorstrange.Tag = "5";
            this.Controls.Add(buttondoctorstrange);
            //movie6
            ironman3 = new PictureBox();
            ironman3.Image = Image.FromFile(@moviepicture[5]);
            ironman3.SizeMode = PictureBoxSizeMode.StretchImage;
            ironman3.Location = new Point(10, 10);
            ironman3.Size = new Size(212, 208);
            this.panel6.Controls.Add(ironman3);

            labelironman3 = new Label();
            labelironman3.Text = @moviename[5];
            labelironman3.Font = new Font("Arial", 15, FontStyle.Bold);
            labelironman3.Size = new Size(200, 24);
            labelironman3.ForeColor = Color.Black;
            labelironman3.Location = new Point(755, 605);
            this.Controls.Add(labelironman3);

            buttonironman3 = new Button();
            buttonironman3.Text = "ORDER NOW";
            buttonironman3.Font = new Font("Arial", 15, FontStyle.Bold);
            buttonironman3.Size = new Size(200, 30);
            buttonironman3.BackColor = Color.Orange;
            buttonironman3.Location = new Point(405,635);
            buttonironman3.Click += Buttonironman3_Click;
            buttonironman3.Tag = "6";
            this.Controls.Add(buttonironman3);
            //movie7
            spiderman = new PictureBox();
            spiderman.Image = Image.FromFile(@moviepicture[6]);
            spiderman.SizeMode = PictureBoxSizeMode.StretchImage;
            spiderman.Location = new Point(10, 10);
            spiderman.Size = new Size(212, 208);
            this.panel7.Controls.Add(spiderman);

            labelspiderman = new Label();
            labelspiderman.Text = @moviename[6];
            labelspiderman.Font = new Font("Arial", 15, FontStyle.Bold);
            labelspiderman.Size = new Size(300, 24);
            labelspiderman.ForeColor = Color.Black;
            labelspiderman.Location = new Point(1014, 605);
            this.Controls.Add(labelspiderman);

            buttonspiderman = new Button();
            buttonspiderman.Text = "ORDER NOW";
            buttonspiderman.Font = new Font("Arial", 15, FontStyle.Bold);
            buttonspiderman.Size = new Size(200, 30);
            buttonspiderman.BackColor = Color.Orange;
            buttonspiderman.Location = new Point(715, 635);
            buttonspiderman.Click += Buttonspiderman_Click;
            buttonspiderman.Tag = "7";
            this.Controls.Add(buttonspiderman);
            //movie8
            thorragnarok = new PictureBox();
            thorragnarok.Image = Image.FromFile(@moviepicture[7]);
            thorragnarok.SizeMode = PictureBoxSizeMode.StretchImage;
            thorragnarok.Location = new Point(10, 10);
            thorragnarok.Size = new Size(212, 208);
            this.panel8.Controls.Add(thorragnarok);

            labelthorragnarok = new Label();
            labelthorragnarok.Text = @moviename[7];
            labelthorragnarok.Font = new Font("Arial", 15, FontStyle.Bold);
            labelthorragnarok.Size = new Size(300, 24);
            labelthorragnarok.ForeColor = Color.Black;
            labelthorragnarok.Location = new Point(740, 307);
            this.Controls.Add(labelthorragnarok);

            buttonthorragnarok = new Button();
            buttonthorragnarok.Text = "ORDER NOW";
            buttonthorragnarok.Font = new Font("Arial", 15, FontStyle.Bold);
            buttonthorragnarok.Size = new Size(200, 30);
            buttonthorragnarok.BackColor = Color.Orange;
            buttonthorragnarok.Location = new Point(1040, 635);
            buttonthorragnarok.Click += Buttonthorragnarok_Click;
            buttonthorragnarok.Tag = "8";
            this.Controls.Add(buttonthorragnarok);
        }

        private void Buttonantman_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype=send.Tag.ToString();
            //antman.Visible = false;
            //labelantman.Visible = false;
            //buttonantman.Visible = false;
            //panel1.Visible = false;
            //panel2.Visible = false;
            //panel3.Visible = false;
            //panel4.Visible = false;
            //panel5.Visible = false;
            //panel6.Visible = false;
            //panel7.Visible = false;
            //panel8.Visible = false;
            //avengersendgame.Visible = false;
            //labelavenger.Visible = false;
            //buttonavenger.Visible = false;            
            //blackPanther.Visible = false;
            //labelblackpanther.Visible = false;
            //buttonblackpanther.Visible = false;            
            //Hulk.Visible = false;
            //buttonHulk.Visible = false;
            //labelHulk.Visible = false;            
            //doctorstrange.Visible = false;
            //labeldoctorstrange.Visible = false;
            //buttondoctorstrange.Visible = false;
            //cinema.Visible = false;
            //ironman3.Visible = false;
            //labelironman3.Visible = false;
            //buttonironman3.Visible = false;
            //spiderman.Visible = false;
            //labelspiderman.Visible = false;
            //buttonspiderman.Visible = false;
            //thorragnarok.Visible = false;
            //labelthorragnarok.Visible = false;
            //buttonthorragnarok.Visible = false;

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            this.Controls.Add(form2);
            form2.Show();


        }

        private void Buttonavenger_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype = send.Tag.ToString();
            this.Controls.Clear();
            antman.Visible = false;
            labelantman.Visible = false;
            buttonantman.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            avengersendgame.Visible = false;
            labelavenger.Visible = false;
            buttonavenger.Visible = false;
            blackPanther.Visible = false;
            labelblackpanther.Visible = false;
            buttonblackpanther.Visible = false;
            Hulk.Visible = false;
            buttonHulk.Visible = false;
            labelHulk.Visible = false;
            doctorstrange.Visible = false;
            labeldoctorstrange.Visible = false;
            buttondoctorstrange.Visible = false;
            cinema.Visible = false;
            ironman3.Visible = false;
            labelironman3.Visible = false;
            buttonironman3.Visible = false;
            spiderman.Visible = false;
            labelspiderman.Visible = false;
            buttonspiderman.Visible = false;
            thorragnarok.Visible = false;
            labelthorragnarok.Visible = false;
            buttonthorragnarok.Visible = false;

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            this.Controls.Add(form2);
            form2.Show();


        }

        private void Buttonblackpanther_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype = send.Tag.ToString();
            this.Controls.Clear();
            antman.Visible = false;
            labelantman.Visible = false;
            buttonantman.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            avengersendgame.Visible = false;
            labelavenger.Visible = false;
            buttonavenger.Visible = false;
            blackPanther.Visible = false;
            labelblackpanther.Visible = false;
            buttonblackpanther.Visible = false;
            Hulk.Visible = false;
            buttonHulk.Visible = false;
            labelHulk.Visible = false;
            doctorstrange.Visible = false;
            labeldoctorstrange.Visible = false;
            buttondoctorstrange.Visible = false;
            cinema.Visible = false;
            ironman3.Visible = false;
            labelironman3.Visible = false;
            buttonironman3.Visible = false;
            spiderman.Visible = false;
            labelspiderman.Visible = false;
            buttonspiderman.Visible = false;
            thorragnarok.Visible = false;
            labelthorragnarok.Visible = false;
            buttonthorragnarok.Visible = false;

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            this.Controls.Add(form2);
            form2.Show();
        }

        private void ButtonHulk_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype = send.Tag.ToString();
            this.Controls.Clear();
            antman.Visible = false;
            labelantman.Visible = false;
            buttonantman.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            avengersendgame.Visible = false;
            labelavenger.Visible = false;
            buttonavenger.Visible = false;
            blackPanther.Visible = false;
            labelblackpanther.Visible = false;
            buttonblackpanther.Visible = false;
            Hulk.Visible = false;
            buttonHulk.Visible = false;
            labelHulk.Visible = false;
            doctorstrange.Visible = false;
            labeldoctorstrange.Visible = false;
            buttondoctorstrange.Visible = false;
            cinema.Visible = false;
            ironman3.Visible = false;
            labelironman3.Visible = false;
            buttonironman3.Visible = false;
            spiderman.Visible = false;
            labelspiderman.Visible = false;
            buttonspiderman.Visible = false;
            thorragnarok.Visible = false;
            labelthorragnarok.Visible = false;
            buttonthorragnarok.Visible = false;

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            this.Controls.Add(form2);
            form2.Show();
        }

        private void Buttondoctorstrange_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype = send.Tag.ToString();
            this.Controls.Clear();
            antman.Visible = false;
            labelantman.Visible = false;
            buttonantman.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            avengersendgame.Visible = false;
            labelavenger.Visible = false;
            buttonavenger.Visible = false;
            blackPanther.Visible = false;
            labelblackpanther.Visible = false;
            buttonblackpanther.Visible = false;
            Hulk.Visible = false;
            buttonHulk.Visible = false;
            labelHulk.Visible = false;
            doctorstrange.Visible = false;
            labeldoctorstrange.Visible = false;
            buttondoctorstrange.Visible = false;
            cinema.Visible = false;
            ironman3.Visible = false;
            labelironman3.Visible = false;
            buttonironman3.Visible = false;
            spiderman.Visible = false;
            labelspiderman.Visible = false;
            buttonspiderman.Visible = false;
            thorragnarok.Visible = false;
            labelthorragnarok.Visible = false;
            buttonthorragnarok.Visible = false;

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            this.Controls.Add(form2);
            form2.Show();
        }

        private void Buttonironman3_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype = send.Tag.ToString();
            this.Controls.Clear();
            antman.Visible = false;
            labelantman.Visible = false;
            buttonantman.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            avengersendgame.Visible = false;
            labelavenger.Visible = false;
            buttonavenger.Visible = false;
            blackPanther.Visible = false;
            labelblackpanther.Visible = false;
            buttonblackpanther.Visible = false;
            Hulk.Visible = false;
            buttonHulk.Visible = false;
            labelHulk.Visible = false;
            doctorstrange.Visible = false;
            labeldoctorstrange.Visible = false;
            buttondoctorstrange.Visible = false;
            cinema.Visible = false;
            ironman3.Visible = false;
            labelironman3.Visible = false;
            buttonironman3.Visible = false;
            spiderman.Visible = false;
            labelspiderman.Visible = false;
            buttonspiderman.Visible = false;
            thorragnarok.Visible = false;
            labelthorragnarok.Visible = false;
            buttonthorragnarok.Visible = false;

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            this.Controls.Add(form2);
            form2.Show();
        }

        private void Buttonspiderman_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype = send.Tag.ToString();
            this.Controls.Clear();
            antman.Visible = false;
            labelantman.Visible = false;
            buttonantman.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            avengersendgame.Visible = false;
            labelavenger.Visible = false;
            buttonavenger.Visible = false;
            blackPanther.Visible = false;
            labelblackpanther.Visible = false;
            buttonblackpanther.Visible = false;
            Hulk.Visible = false;
            buttonHulk.Visible = false;
            labelHulk.Visible = false;
            doctorstrange.Visible = false;
            labeldoctorstrange.Visible = false;
            buttondoctorstrange.Visible = false;
            cinema.Visible = false;
            ironman3.Visible = false;
            labelironman3.Visible = false;
            buttonironman3.Visible = false;
            spiderman.Visible = false;
            labelspiderman.Visible = false;
            buttonspiderman.Visible = false;
            thorragnarok.Visible = false;
            labelthorragnarok.Visible = false;
            buttonthorragnarok.Visible = false;

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            this.Controls.Add(form2);
            form2.Show();
        }

        private void Buttonthorragnarok_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            movietype = send.Tag.ToString();
            this.Controls.Clear();
            antman.Visible = false;
            labelantman.Visible = false;
            buttonantman.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            avengersendgame.Visible = false;
            labelavenger.Visible = false;
            buttonavenger.Visible = false;
            blackPanther.Visible = false;
            labelblackpanther.Visible = false;
            buttonblackpanther.Visible = false;
            Hulk.Visible = false;
            buttonHulk.Visible = false;
            labelHulk.Visible = false;
            doctorstrange.Visible = false;
            labeldoctorstrange.Visible = false;
            buttondoctorstrange.Visible = false;
            cinema.Visible = false;
            ironman3.Visible = false;
            labelironman3.Visible = false;
            buttonironman3.Visible = false;
            spiderman.Visible = false;
            labelspiderman.Visible = false;
            buttonspiderman.Visible = false;
            thorragnarok.Visible = false;
            labelthorragnarok.Visible = false;
            buttonthorragnarok.Visible = false;

            form2 = new Form2();
            form2.TopLevel = false;
            form2.Dock = DockStyle.Fill;
            this.Controls.Add(form2);
            form2.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Change the background color to the next color in the palette
            currentColor = (currentColor + 1) % colors.Length;
            panel1.BackColor = colors[currentColor];
            panel2.BackColor = colors[currentColor];
            panel3.BackColor = colors[currentColor];
            panel4.BackColor = colors[currentColor];
            panel5.BackColor = colors[currentColor];
            panel6.BackColor = colors[currentColor];
            panel7.BackColor = colors[currentColor];
            panel8.BackColor = colors[currentColor];
        }
    }
}
