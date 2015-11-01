using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickReportCore.Forms
{
    internal partial class frmTreeIconSelector : Form
    {
        public frmTreeIconSelector()
        {
            InitializeComponent();
            InitImage();
        }

        public delegate void SelectImageHandle(int index);
        public event SelectImageHandle SelectImage;

        private int selectedImage = 0;
        /// <summary>
        /// Ñ¡ÖÐµÄÍ¼Ïñ¡£
        /// </summary>
        public int SelectedImage
        {
            get
            {
                return selectedImage;
            }
            set
            {
                selectedImage = value;
                SelectOneImage(selectedImage);
            }
        }

        private void InitImage()
        {
            pictureBox1.Image = imageList.Images[0];
            pictureBox2.Image = imageList.Images[1];
            pictureBox3.Image = imageList.Images[2];
            pictureBox4.Image = imageList.Images[3];
            pictureBox5.Image = imageList.Images[4];
            pictureBox6.Image = imageList.Images[5];
            pictureBox7.Image = imageList.Images[6];
            pictureBox8.Image = imageList.Images[7];
            pictureBox9.Image = imageList.Images[8];
            pictureBox10.Image = imageList.Images[9];
            pictureBox11.Image = imageList.Images[10];
            pictureBox12.Image = imageList.Images[11];
            pictureBox13.Image = imageList.Images[12];
            pictureBox14.Image = imageList.Images[13];
            pictureBox15.Image = imageList.Images[14];
            pictureBox16.Image = imageList.Images[15];
            pictureBox17.Image = imageList.Images[16];
            pictureBox18.Image = imageList.Images[17];
            pictureBox1.Click += new EventHandler(pictureBox_Click);
            pictureBox2.Click += new EventHandler(pictureBox_Click);
            pictureBox3.Click += new EventHandler(pictureBox_Click);
            pictureBox4.Click += new EventHandler(pictureBox_Click);
            pictureBox5.Click += new EventHandler(pictureBox_Click);
            pictureBox6.Click += new EventHandler(pictureBox_Click);
            pictureBox7.Click += new EventHandler(pictureBox_Click);
            pictureBox8.Click += new EventHandler(pictureBox_Click);
            pictureBox9.Click += new EventHandler(pictureBox_Click);
            pictureBox10.Click += new EventHandler(pictureBox_Click);
            pictureBox11.Click += new EventHandler(pictureBox_Click);
            pictureBox12.Click += new EventHandler(pictureBox_Click);
            pictureBox13.Click += new EventHandler(pictureBox_Click);
            pictureBox14.Click += new EventHandler(pictureBox_Click);
            pictureBox15.Click += new EventHandler(pictureBox_Click);
            pictureBox16.Click += new EventHandler(pictureBox_Click);
            pictureBox17.Click += new EventHandler(pictureBox_Click);
            pictureBox18.Click += new EventHandler(pictureBox_Click);
        }

        void pictureBox_Click(object sender, EventArgs e)
        {
            SelectedImage = Convert.ToInt32((sender as PictureBox).Name.Replace("pictureBox", string.Empty)) - 1;
            if (SelectImage != null)
                SelectImage(SelectedImage);
            Close();
        }

        private void frmTreeIconSelector_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTreeIconSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void SelectOneImage(int index)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox4.BorderStyle = BorderStyle.None;
            pictureBox5.BorderStyle = BorderStyle.None;
            pictureBox6.BorderStyle = BorderStyle.None;
            pictureBox7.BorderStyle = BorderStyle.None;
            pictureBox8.BorderStyle = BorderStyle.None;
            pictureBox9.BorderStyle = BorderStyle.None;
            pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox13.BorderStyle = BorderStyle.None;
            pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox15.BorderStyle = BorderStyle.None;
            pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox17.BorderStyle = BorderStyle.None;
            pictureBox18.BorderStyle = BorderStyle.None;
            FindPictrueBoxByName("pictureBox" + (index + 1).ToString()).BorderStyle = BorderStyle.Fixed3D;
        }

        private PictureBox FindPictrueBoxByName(string name)
        {
            foreach (Control c in Controls)
            {
                if (c.Name == name)
                    return c as PictureBox;
            }
            return null;
        }
    }
}