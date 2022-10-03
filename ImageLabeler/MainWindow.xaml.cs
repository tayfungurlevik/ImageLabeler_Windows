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
using ImageLabeler.Helpers;

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
        DrawHelper drawHelper;
        public MainWindow()
        {
            InitializeComponent();
            folderBrowserDialog = new FolderBrowserDialog();
            drawHelper = new DrawHelper();
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
            var imageFiles = from file in files
                             where file.Extension == ".jpeg" || file.Extension == ".jpg" || file.Extension == ".png"
                             select file;
            foreach (FileInfo file in imageFiles)
            {
                imageListBox.Items.Add(file.Name);
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
            rect.Width = Math.Abs(Mouse2X - Mouse1X);
            rect.Height = Math.Abs(Mouse2Y - Mouse1Y);
            Canvas.SetLeft(rect, Math.Min(Mouse1X, Mouse2X));
            Canvas.SetTop(rect, Math.Min(Mouse1Y, Mouse2Y));
            ImageCanvas.Children.Add(rect);
            Mouse1X = 0; Mouse1Y = 0; Mouse2X = 0; Mouse2Y = 0;
        }
        Rectangle tmpRec;
        private void ImageCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point p = e.GetPosition(ImageCanvas);
            if (tmpRec == null)
            {
                if ( Mouse1X > 0 && Mouse1Y > 0)
                {
                    tmpRec = new Rectangle();
                    tmpRec.Fill = Brushes.Transparent;
                    tmpRec.Stroke = Brushes.DarkRed;
                    tmpRec.Width = p.X - Mouse1X;
                    tmpRec.Height = p.Y - Mouse1Y;
                    Canvas.SetLeft(tmpRec, Math.Min(Mouse1X, Mouse2X));
                    Canvas.SetTop(tmpRec, Math.Min(Mouse1Y, Mouse2Y));
                    ImageCanvas.Children.Add(tmpRec);
                }
                
            }
            else
            {
                tmpRec.Width = Math.Abs(p.X - Mouse1X);
                tmpRec.Height = Math.Abs(p.Y - Mouse1Y);
                Canvas.SetLeft(tmpRec, Math.Min(Mouse1X,Mouse2X));
                Canvas.SetTop(tmpRec, Math.Min(Mouse1Y, Mouse2Y));


            }
                
            
        }

        private void imageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedImage = imageListBox.SelectedItem;
            ImageBrush brush = new ImageBrush();
            Uri uri = new Uri((folderPath + "\\" + selectedImage), UriKind.Absolute);
            brush.ImageSource = new BitmapImage(uri);
            drawHelper.ImageWidth = brush.ImageSource.Width;
            drawHelper.ImageHeight = brush.ImageSource.Height;
            ImageCanvas.Background = brush;
        }

        private void ImageCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            drawHelper.MouseLeftDown = true;
            Point p =e.GetPosition(ImageCanvas);
            drawHelper.MouseDownPoint = p;
            Mouse1X = (int)p.X;
            Mouse1Y = (int)p.Y;
        }
    }
}
