using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPlayer
{
    public partial class Form1 : Form
    {
        protected Outputable artistList = new Outputable();
        protected Outputable playList = new Outputable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddArtist();
        }

        private void AddArtist()
        {
            if (IsValid(textBox1))
            {
                this.artistList.Add(new Artist(){ Title = textBox1.Text} );
                OutputArtists();
            }

        }

        private void OutputArtists()
        {
            this.artistList.OutputInListBox(this.listBox3);
            this.artistList.OutputInComboBox(this.comboBox1);
            this.artistList.OutputInComboBox(this.comboBox3);
            this.artistList.OutputInComboBox(this.comboBox4);
            textBox1.Clear();
        }

        private bool IsValid(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show("Enter data");
                return false;
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditArtist();
        }

        private void EditArtist()
        {
            if (IsValid(textBox1) && HasSelected(listBox3))
            {
                this.artistList[listBox3.SelectedIndex] = new Artist() { Title = textBox1.Text };
                OutputArtists();
            }
        }

        private bool HasSelected(ListBox listBox)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select item");
                return false;
            }
            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveArtist();
        }

        private void RemoveArtist()
        {
            if (HasSelected(listBox3))
            {
                artistList.RemoveAt(listBox3.SelectedIndex);
                OutputArtists();
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox3.SelectedItem.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddAlbum();
        }

        private void AddAlbum()
        {
            if (IsValid(textBox2) && HasSelectedC(comboBox3))
            {
                Artist a = (Artist)artistList[comboBox3.SelectedIndex];
                a.Albums.Add(
                    new Album() { Title = textBox2.Text, Artist = a }
                    );
                OutputAlbums();
            }
        }

        private bool HasSelectedC(ComboBox comboBox, bool flag = true)
        {
            if (comboBox.SelectedIndex == -1)
            {
                if (flag)
                {
                    MessageBox.Show("Select item");
                }
                return false;
            }
            return true;
        }

        private void OutputAlbums()
        {
            textBox2.Clear();
            if (HasSelectedC(comboBox4, false))
            {
                ((Artist)artistList[comboBox4.SelectedIndex]).Albums.OutputInComboBox(comboBox5);
            }
            ((Artist)artistList[comboBox3.SelectedIndex]).Albums.OutputInListBox(listBox4);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Artist)artistList[comboBox3.SelectedIndex]).Albums.OutputInListBox(listBox4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EditAlbum();

        }

        private void EditAlbum()
        {
            if (IsValid(textBox2) && HasSelectedC(comboBox3) && HasSelected(listBox4))
            {
                Artist a = (Artist)artistList[comboBox3.SelectedIndex];
                a.Albums[listBox4.SelectedIndex] = new Album() { Title = textBox2.Text, Artist = a };
                OutputAlbums();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RemoveAlbum();
        }

        private void RemoveAlbum()
        {
            if (HasSelected(listBox4) && HasSelectedC(comboBox3))
            {
                Artist a = (Artist)artistList[comboBox3.SelectedIndex];
                a.Albums.RemoveAt(listBox4.SelectedIndex);
                OutputAlbums();
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox4.SelectedItem.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddTrack();
        }

        private void AddTrack()
        {
            if (IsValid(textBox3) && HasSelectedC(comboBox4) && HasSelectedC(comboBox5))
            {
                Artist a = (Artist)artistList[comboBox4.SelectedIndex];
                Album al = (Album)a.Albums[comboBox5.SelectedIndex];
                al.Tracks.Add(new Track() { Title = textBox3.Text, Album = al });
                OutputTracks();
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = listBox5.SelectedItem.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RemoveTrack();
        }

        private void RemoveTrack()
        {
            if (HasSelected(listBox5)) 
            {
                Artist a = (Artist)artistList[comboBox4.SelectedIndex];
                Album al = (Album)a.Albums[comboBox5.SelectedIndex];
                al.Tracks.RemoveAt(listBox5.SelectedIndex);
                OutputTracks();
            }
        }

        private void OutputTracks()
        {
                Artist a = (Artist)artistList[comboBox4.SelectedIndex];
                Album al = (Album)a.Albums[comboBox5.SelectedIndex];
                al.Tracks.OutputInListBox(listBox5);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasSelectedC(comboBox4, false))
            {
                ((Artist)artistList[comboBox4.SelectedIndex]).Albums.OutputInComboBox(comboBox5);
            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasSelectedC(comboBox5, false))
            {
                Artist a = (Artist)artistList[comboBox4.SelectedIndex];
                Album al = (Album)a.Albums[comboBox5.SelectedIndex];
                al.Tracks.OutputInListBox(listBox5);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasSelectedC(comboBox1, false))
            {
                Artist a = (Artist)artistList[comboBox1.SelectedIndex];
                a.Albums.OutputInComboBox(comboBox2);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HasSelectedC(comboBox1, false))
            {
                Artist a = (Artist)artistList[comboBox1.SelectedIndex];
                Album al = (Album)a.Albums[comboBox2.SelectedIndex];
                al.Tracks.OutputInListBox(listBox1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddToPlayList();
        }

        private void AddToPlayList()
        {
            if (HasSelectedC(comboBox1) && HasSelectedC(comboBox2) && HasSelected(listBox1))
            {
                Artist a = (Artist)artistList[comboBox1.SelectedIndex];
                Album al = (Album)a.Albums[comboBox2.SelectedIndex];
                Track t = (Track)al.Tracks[listBox1.SelectedIndex];
                playList.Add(t);
                OutputPlayList();
            }
        }

        private void OutputPlayList()
        {
            this.playList.OutputInListBox(listBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (HasSelected(listBox2))
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                OutputPlayList();
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 52)
            {
                MessageBox.Show("Error: You have maximal amount of controls");
                return;
            }
            Button btn = new Button();
            if (!IsValid(textBox4))
            {
                return;
            }
            btn.Click += new System.EventHandler(this.buttons_Click);
            btn.Text = textBox4.Text;
            int xOffset = 5;
            int yOffset = 10;
            int btnHeight = 30;
            int btnWidth = 80;
            btn.Width = btnWidth;
            btn.Height = btnHeight;
            panel1.Controls.Add(btn);
            int lenght = panel1.Height / (btnHeight);
            int amount = panel1.Controls.Count;
            int x = xOffset + btnWidth * (amount / lenght);
            int y = yOffset + btnHeight * (amount % lenght);
            btn.Top = y;
            btn.Left = x;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 1)
            {
                panel1.Controls.RemoveAt(panel1.Controls.Count - 1);
            }
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            string number = panel1.Controls.IndexOf(btn).ToString();
            MessageBox.Show("Hello, I'm button\nMy name is " + btn.Text + "\nmy number in panel is " + number);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            generateUI();
        }

        private void generateUI()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.myTab = new System.Windows.Forms.TabPage();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(571, 349);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox2);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(563, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Playlist";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 8);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(210, 251);
            this.listBox2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(222, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "remove >>X ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(346, 32);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(208, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(346, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tracks:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Albums:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Artist:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "<< add to playlist";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(346, 59);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(208, 199);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.listBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(563, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Artists";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(5, 82);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Remove";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(88, 52);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "List";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 20);
            this.textBox1.TabIndex = 1;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(169, 25);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 238);
            this.listBox3.TabIndex = 0;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox3);
            this.tabPage3.Controls.Add(this.button6);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.listBox4);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(563, 325);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Albums";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(8, 60);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(157, 21);
            this.comboBox3.TabIndex = 12;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "Remove";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(90, 87);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "Edit";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(8, 87);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Add";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "List";
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(171, 20);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(120, 238);
            this.listBox4.TabIndex = 7;
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(157, 20);
            this.textBox2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Artist:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Title:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.comboBox5);
            this.tabPage4.Controls.Add(this.comboBox4);
            this.tabPage4.Controls.Add(this.button9);
            this.tabPage4.Controls.Add(this.button11);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.listBox5);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.textBox3);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(563, 325);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tracks";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(6, 64);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(157, 21);
            this.comboBox5.TabIndex = 21;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(6, 105);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(157, 21);
            this.comboBox4.TabIndex = 21;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(87, 132);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Remove";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 132);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 18;
            this.button11.Text = "Add";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(166, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "List";
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.Location = new System.Drawing.Point(169, 24);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(120, 238);
            this.listBox5.TabIndex = 16;
            this.listBox5.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Album:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(157, 20);
            this.textBox3.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Artist:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Title:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.textBox4);
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.Controls.Add(this.button12);
            this.tabPage5.Controls.Add(this.button10);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(563, 325);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Constructor";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(166, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Button label";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(235, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(5, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 285);
            this.panel1.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 39);
            this.label14.TabIndex = 0;
            this.label14.Text = "Місце для \r\nвашої \r\nреклами";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(85, 3);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 1;
            this.button12.Text = "Remove last";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(4, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 0;
            this.button10.Text = "Add button";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Controls.Add(this.tabControl1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();


            myTab.Text = "My tab";
            this.tabControl1.Controls.Add(this.myTab);
            TabControl tabC = new TabControl();
            myTab.Height = 300;
            myTab.Width = 400;
            tabC.Height = 300;
            tabC.Width = 400;
            Random randonGen = new Random();
            for (int i = 0; i < 4; i++)
            {
                TabPage page = new TabPage("Tab " + i.ToString());
                page.Height = 300;
                page.Width = 400;
                page.BackColor = Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
                tabC.Controls.Add(page);
            }
            myTab.Controls.Add(tabC);
        }
        private void покинутиЦюНещаснуПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
