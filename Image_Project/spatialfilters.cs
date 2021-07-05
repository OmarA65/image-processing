using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Project
{
    public partial class spatialfilters : Form
    {
        Bitmap img;
        int width;
        int height;
        Color pixel;
        double grPixel;
        double [,] Myimg;
        double[,] undoMyimg;
        public spatialfilters()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Image Files(*.jpg; *.jpeg; *.bmp ) |*.jpg; *.jpeg; *.bmp ";
            if(open.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(open.FileName);
                pictureBox1.Image = img;
            }
        }
        //grayscale
        private void button1_Click(object sender, EventArgs e)
        {
            width = img.Width;
            height = img.Height;
            Myimg = new double[width, height];
            undoMyimg = new double[width, height];
            for (int i=0;i<width;i++)
            {
                for(int j=0;j<height;j++)
                {
                    pixel = img.GetPixel(i, j);

                    double R = pixel.R * 0.3;
                    double G = pixel.G * 0.59;
                    double B = pixel.B * 0.11;
                    int grayScale = (int)((pixel.R * 0.2125) + (pixel.G * 0.7154) + (pixel.B * 0.0721));
                    Myimg[i, j] = grayScale;
                    undoMyimg[i, j] = grayScale;
                    img.SetPixel(i, j, Color.FromArgb(grayScale, grayScale, grayScale));
                }
            }
            pictureBox2.Image = img;
        }
        void ImageLoop()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int r = (int)Myimg[i, j];
                    img.SetPixel(i, j, Color.FromArgb(r, r, r));
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Model.correlation(Myimg, Filters.BlurFilter, width, height,5,5);
            ImageLoop();
            pictureBox2.Image = img;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Model.correlation(Myimg, Filters.SobelhorizontalEdge, width, height, 3, 3);
            ImageLoop();
            pictureBox2.Image = img;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Model.correlation(Myimg, Filters.SobelverticalEdge, width, height, 3, 3);
            ImageLoop();
            pictureBox2.Image = img;
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Blur
            string selected = comboBox1.SelectedItem.ToString();
            if (selected == "Blur")
            {
                Model.correlation(Myimg, Filters.BlurFilter, width, height, 5, 5);
                ImageLoop();
                pictureBox2.Image = img;
            }
            //SobelHorizontalEdge
            if (selected == "Sobel Horizontal Edge")
            {
                Model.correlation(Myimg, Filters.SobelhorizontalEdge, width, height, 3, 3);
                ImageLoop();
                pictureBox2.Image = img;
            }
            //SobelVerticalEdge
            if (selected == "Sobel Vertical Edge")
            {
                Model.correlation(Myimg, Filters.SobelverticalEdge, width, height, 3, 3);
                ImageLoop();
                pictureBox2.Image = img;
            }

            //sharpen
            if (selected == "Sharpen")
            {
                Model.correlation(Myimg, Filters.Sharpen, width, height, 3, 3);
                ImageLoop();
                pictureBox2.Image = img;
            }
            if (selected == "Inverse")
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        grPixel = Myimg[i, j];
                        Myimg[i, j] = 255 - grPixel;
                    }
                }
                ImageLoop();
                pictureBox2.Image = img;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Myimg[i, j] = undoMyimg[i, j];
                }
            }
            ImageLoop();
            pictureBox2.Image = img;
        }
    }
}
