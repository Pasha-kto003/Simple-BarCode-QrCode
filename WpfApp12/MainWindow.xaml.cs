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

namespace WpfApp12
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

        private void QRCodeClick(object sender, RoutedEventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw codeQrBarcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            var qrimage = codeQrBarcode.Draw(txtQrcode.Text, 50);
            pictureBox.Source = ConvertDrawingImageToWPFImage(qrimage);
        }

        private void BtnBarcodeClick(object sender, RoutedEventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw barcode128 = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            var barimage = barcode128.Draw(txtBarcode.Text, 50);
            pictureBox.Source = ConvertDrawingImageToWPFImage(barimage);
        }

        private ImageSource ConvertDrawingImageToWPFImage(System.Drawing.Image gdiImg)
        {
           Image img = new Image();

            //convert System.Drawing.Image to WPF image
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(gdiImg);
            IntPtr hBitmap = bmp.GetHbitmap();
            ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            img.Source = WpfBitmap;
            img.Width = 403;
            img.Height = 145;
            img.Stretch = System.Windows.Media.Stretch.Fill;
            return WpfBitmap;
        }
    }
}
