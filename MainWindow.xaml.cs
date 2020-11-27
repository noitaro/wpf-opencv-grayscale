using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System.Windows;
using System.Windows.Media.Imaging;
using Window = System.Windows.Window;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Image コントロールから画像データを BitmapSource 形式で取得する。
            var bitmapSource = (BitmapSource)image.Source;
            // BitmapSource 形式を OpenCV の Mat 形式に変換する。
            var mat = BitmapSourceConverter.ToMat(bitmapSource);
            // OpenCV で グレースケール化する。
            Cv2.CvtColor(mat, mat, ColorConversionCodes.RGB2GRAY);
            // OpenCV の Mat 形式を BitmapSource 形式に変換する。
            var bitmapSource_gray = BitmapSourceConverter.ToBitmapSource(mat);
            // Image コントロールに BitmapSource 形式の画像データを設定する。
            image.Source = bitmapSource_gray;
        }
    }
}
