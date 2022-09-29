using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;


namespace ImageLabeler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FolderBrowserDialog folderBrowserDialog;
        private string folderPath = "";
        private int Mouse1X, Mouse1Y;
        private int Mouse2X, Mouse2Y;
        public MainWindow()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
        }
        
        

        private void FolderButtonClick(object sender, RoutedEventArgs e)
        {
            if (folderBrowserDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
                AddFilesToListBox(folderPath);
            }
            
        }
        private void AddFilesToListBox(string path)
        {
            ClearListBox();
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                
                imageListBox.Items.Add(files[i].Name);
            }

        }
        private void ClearListBox()
        {
            imageListBox.Items.Clear();
            
        }

        private void ImageCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(ImageCanvas);
            Mouse2X = (int)p.X;
            Mouse2Y = (int)p.Y;
            Rectangle rect = new Rectangle();
            rect.Fill = Brushes.Transparent;
            rect.Stroke = Brushes.DarkRed;
            rect.Width = Mouse2X - Mouse1X;
            rect.Height = Mouse2Y - Mouse1Y;
            Canvas.SetLeft(rect, Mouse1X);
            Canvas.SetTop(rect, Mouse1Y);
            ImageCanvas.Children.Add(rect);
        }
        Rectangle tmpRec;
        private void ImageCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point p = e.GetPosition(ImageCanvas);
            if (tmpRec == null)
            {
                tmpRec = new Rectangle();
                tmpRec.Fill = Brushes.Transparent;
                tmpRec.Stroke = Brushes.DarkRed;
                tmpRec.Width = p.X - Mouse1X;
                tmpRec.Height = p.Y - Mouse1Y;
                Canvas.SetLeft(tmpRec, Mouse1X);
                Canvas.SetTop(tmpRec, Mouse1Y);
                ImageCanvas.Children.Add(tmpRec);
            }
            else
            {
                ImageCanvas.Children.Remove(tmpRec);
                tmpRec = null;
            }
                
            
        }

        private void imageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedImage = imageListBox.SelectedItem;
            ImageBrush brush = new ImageBrush();
            Uri uri = new Uri((folderPath + "\\" + selectedImage), UriKind.Absolute);
            brush.ImageSource = new BitmapImage(uri);
            ImageCanvas.Background = brush;
        }

        private void ImageCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p =e.GetPosition(ImageCanvas);
            Mouse1X = (int)p.X;
            Mouse1Y = (int)p.Y;
        }
    }
}
