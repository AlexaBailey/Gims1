using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Color = System.Windows.Media.Color;
using Image = System.Windows.Controls.Image;


namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }



        public static int[,] _mask = new int[3, 3];

        struct Header
        {
            private short type;
            private short compression;
            private short header;
            private short rastreSize;
            private short height;
            private short width;
            private int countofColor;
            private string name;
        }






        private void defineInfo(ref byte[] b, byte[] bytes, int pos)
        {
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = bytes[pos++];
            }
        }
        private void addNoise(ref Bitmap bitmap)
        {
            int count = (bitmap.Width * bitmap.Height * Convert.ToInt32(RandomBox.Text)) / 100;

            for (int i = 0; i < count; i++)
            {
                var rnd = new Random();
                int x = rnd.Next(bitmap.Width);
                int y = rnd.Next(bitmap.Height);
                int r = rnd.Next(255);
                int g = rnd.Next(255);
                int b = rnd.Next(255);
                bitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(0, r, g, b));
            }
        }

        private void ConvertImg(ref Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Height - 1; i++)
            {
                for (int j = 0; j < bitmap.Width - 1; j++)
                {

                    System.Drawing.Color color1 = System.Drawing.Color.Red;
                    System.Drawing.Color color2 = System.Drawing.Color.Red;
                    System.Drawing.Color color3 = System.Drawing.Color.Red;
                    System.Drawing.Color color4 = System.Drawing.Color.Red;
                    System.Drawing.Color color5 = System.Drawing.Color.Red;
                    System.Drawing.Color color6 = System.Drawing.Color.Red;
                    System.Drawing.Color color7 = System.Drawing.Color.Red;
                    System.Drawing.Color color8 = System.Drawing.Color.Red;
                    System.Drawing.Color color9 = System.Drawing.Color.Red;
                    if (i == 0 && j == 0)
                    {
                        color1 = bitmap.GetPixel(j, i);
                        color2 = bitmap.GetPixel(j, i);
                        color3 = bitmap.GetPixel(j+1, i);
                        color4 = bitmap.GetPixel(j, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j + 1, i);
                        color7 = bitmap.GetPixel(j, i + 1);
                        color8 = bitmap.GetPixel(j, i + 1);
                        color9 = bitmap.GetPixel(j + 1, i + 1);
                    }
                    else if(i == 0 && j == bitmap.Width-1)
                    {
                        color1 = bitmap.GetPixel(j - 1, i);
                        color2 = bitmap.GetPixel(j, i);
                        color3 = bitmap.GetPixel(j, i);
                        color4 = bitmap.GetPixel(j - 1, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j, i);
                        color7 = bitmap.GetPixel(j - 1, i + 1);
                        color8 = bitmap.GetPixel(j, i + 1);
                        color9 = bitmap.GetPixel(j, i + 1);
                    }
                    else if(i == bitmap.Height -1 && j == bitmap.Width - 1)
                    {
                        color1 = bitmap.GetPixel(j - 1, i - 1);
                        color2 = bitmap.GetPixel(j, i - 1);
                        color3 = bitmap.GetPixel(j, i - 1);
                        color4 = bitmap.GetPixel(j - 1, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j, i);
                        color7 = bitmap.GetPixel(j - 1, i);
                        color8 = bitmap.GetPixel(j, i);
                        color9 = bitmap.GetPixel(j, i);
                    }
                    else if(i == bitmap.Height - 1 && j == 0)
                    {
                        color1 = bitmap.GetPixel(j, i - 1);
                        color2 = bitmap.GetPixel(j, i - 1);
                        color3 = bitmap.GetPixel(j + 1, i - 1);
                        color4 = bitmap.GetPixel(j, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j + 1, i);
                        color7 = bitmap.GetPixel(j, i);
                        color8 = bitmap.GetPixel(j, i);
                        color9 = bitmap.GetPixel(j + 1, i);
                    }
                    else if(i==0)
                    {
                        color1 = bitmap.GetPixel(j - 1, i);
                        color2 = bitmap.GetPixel(j, i);
                        color3 = bitmap.GetPixel(j + 1, i);
                        color4 = bitmap.GetPixel(j - 1, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j + 1, i);
                        color7 = bitmap.GetPixel(j - 1, i + 1);
                        color8 = bitmap.GetPixel(j, i + 1);
                        color9 = bitmap.GetPixel(j + 1, i + 1);
                    }
                    else if(i == bitmap.Height-1)
                    {
                        color1 = bitmap.GetPixel(j - 1, i - 1);
                        color2 = bitmap.GetPixel(j, i - 1);
                        color3 = bitmap.GetPixel(j + 1, i - 1);
                        color4 = bitmap.GetPixel(j - 1, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j + 1, i);
                        color7 = bitmap.GetPixel(j - 1, i);
                        color8 = bitmap.GetPixel(j, i);
                        color9 = bitmap.GetPixel(j + 1, i);
                    }
                    else if(j == 0)
                    {
                        color1 = bitmap.GetPixel(j, i - 1);
                        color2 = bitmap.GetPixel(j, i - 1);
                        color3 = bitmap.GetPixel(j + 1, i - 1);
                        color4 = bitmap.GetPixel(j, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j + 1, i);
                        color7 = bitmap.GetPixel(j, i + 1);
                        color8 = bitmap.GetPixel(j, i + 1);
                        color9 = bitmap.GetPixel(j + 1, i + 1);
                    }
                    else if(j == bitmap.Width-1)
                    {
                        color1 = bitmap.GetPixel(j - 1, i - 1);
                        color2 = bitmap.GetPixel(j, i - 1);
                        color3 = bitmap.GetPixel(j, i - 1);
                        color4 = bitmap.GetPixel(j - 1, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j, i);
                        color7 = bitmap.GetPixel(j - 1, i + 1);
                        color8 = bitmap.GetPixel(j, i + 1);
                        color9 = bitmap.GetPixel(j, i + 1);
                    }
                    else
                    {
                        color1 = bitmap.GetPixel(j - 1, i - 1);
                        color2 = bitmap.GetPixel(j, i - 1);
                        color3 = bitmap.GetPixel(j + 1, i - 1);
                        color4 = bitmap.GetPixel(j - 1, i);
                        color5 = bitmap.GetPixel(j, i);
                        color6 = bitmap.GetPixel(j + 1, i);
                        color7 = bitmap.GetPixel(j - 1, i + 1);
                        color8 = bitmap.GetPixel(j, i + 1);
                        color9 = bitmap.GetPixel(j + 1, i + 1);
                    }
                    

                    byte[] red = new byte[9] { color1.R, color2.R, color3.R, color4.R, color5.R, color6.R, color7.R, color8.R, color9.R };
                    byte[] green = new byte[9] {color1.G, color2.G, color3.G, color4.G, color5.G, color6.G, color7.G, color8.G, color9.G };
                    byte[] blue = new byte[9] {color1.B, color2.B, color3.B, color4.B, color5.B, color6.B, color7.B, color8.B, color9.B };

                    System.Drawing.Color color;
                    color = System.Drawing.Color.FromArgb(color2.A, calculateColor(red), calculateColor(green), calculateColor(blue));
                    bitmap.SetPixel(j, i, color);

                }
            }
        }
        private byte calculateColor(byte[] bytesArr)
        {
            int size=0;
            foreach(int i in _mask)
            {
                size += i;
            }
            byte res = (byte)((_mask[0, 0] * bytesArr[0] + _mask[0, 1] * bytesArr[1] + _mask[0, 2] * bytesArr[2]
                + _mask[1, 0] * bytesArr[3] + _mask[1, 1] * bytesArr[4] + _mask[1, 2] * bytesArr[5]
                + _mask[2, 0] * bytesArr[6] + _mask[2, 1] * bytesArr[7] + _mask[2, 2] * bytesArr[8]) / size);
            return res;
        }
        private void openImage(object sender, RoutedEventArgs e)
        {
            
        }

        private void ConvertImage_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("2");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                addNoise(ref bitmap);
                bitmap.Save("zebra.bmp");
                ConvertImg(ref bitmap);
                bitmap.Save("zebra2.bmp");
                bitmap.Save("result.sas");
                
            }
        }
        private void FiltImage(ref Bitmap bitmap)
        {


            /*            for (int i = 0; i < bitmap.Height - 1; i++)
                        {
                            for (int j = 0; j < bitmap.Width - 1; j++)
                            {

                            }
                        }
            */

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();

        }
    }
    }
