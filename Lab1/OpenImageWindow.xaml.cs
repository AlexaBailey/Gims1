using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Lab1;

public partial class OpenImageWindow : Window
{
    public OpenImageWindow()
    {
        InitializeComponent();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if(openFileDialog.ShowDialog() == true)
        {
                
            Uri fileUri = new Uri(openFileDialog.FileName);
            ShowHeader(openFileDialog.FileName);
            Image.Source = new BitmapImage(fileUri);
        }
    }
    public class MyClass
    {
        public Int16 _type;//
        public int _colorsUsed;//
        public int _type2;//
        public Int16 _sizeOfHeader = 21;
        public int _sizeOfRast;//
        public int _sizeOf;//
        public int _width;//
        public int _height;
        
    }
    private void ShowHeader(string path)
    {
        FileStream stream = new FileStream(path, FileMode.Open);
        MyClass header = new MyClass();
        using (BinaryReader reader = new BinaryReader(stream))
        {
            header._type = reader.ReadInt16();
            reader.ReadInt32();
            reader.ReadInt16();
            reader.ReadInt16();
            reader.ReadInt32();

            reader.ReadInt32();
            header._width = reader.ReadInt32();
            header._height = reader.ReadInt32();
                
            reader.ReadInt16();
            reader.ReadInt16();
            header._type2 = reader.ReadInt32();
            header._sizeOfRast = reader.ReadInt32();
            reader.ReadInt32();
            reader.ReadInt32();
            header._colorsUsed = reader.ReadInt32();
            reader.ReadInt32();
        }
        header._sizeOf = header._width * header._height;
        HeaderBox.Text = $"{header._type}\n{header._type2}\n{header._colorsUsed}\n{header._sizeOfHeader}\n{header._sizeOfRast}\n" +
                             $"{header._width}\n{header._sizeOf}";
    }
}