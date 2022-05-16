using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Описываем объект класса OpenFileDialog 
            OpenFileDialog dialog = new OpenFileDialog();
            // Задаем расширения файлов 
            dialog.Filter = "Image files (*.BMP, *.JPG, " + "*.GIF, *.PNG)|*.bmp;*.jpg;*.gif;*.png";
            // Вызываем диалог и проверяем выбран ли файл 
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Загружаем изображение из выбранного файла  
                pictureBox1.Load(dialog.FileName);
                pictureBox2.Image = ToImage(ToByte(pictureBox1.Image, (byte)trackBar1.Value));
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = ToImage(ToByte(pictureBox1.Image, (byte)trackBar1.Value));

        }

        public int[,] ToByte(Image img, byte level = 230)
        {
            var bmp = new Bitmap(img);
            var mass = new int[bmp.Width, bmp.Height];
            for (var y = 0; y < img.Height; y++)
            {
                for (var x = 0; x < img.Width; x++)
                {
                    var isWhite = bmp.GetPixel(x, y).R >= level &&
                                  bmp.GetPixel(x, y).G >= level &&
                                  bmp.GetPixel(x, y).B >= level;
                    mass[x, y] = isWhite ? 0 : 1;
                }
            }
            return mass;
        }
        public Image ToImage(int[,] img)
        {
            var bmp = new Bitmap(img.GetLength(0), img.GetLength(1));
            for (var y = 0; y < bmp.Height; y++)
            {
                for (var x = 0; x < bmp.Width; x++)
                {
                    bmp.SetPixel(x, y, img[x, y] == 1 ? Color.Black : Color.White);
                }
            }
            return bmp;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
