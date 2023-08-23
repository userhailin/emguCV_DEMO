using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using System.Runtime.InteropServices;

namespace EmguCV.demo5
{
    public partial class Form1 : Form
    {
        [STAThread]
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, out RECT rect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hdcSrc, int nXSrc, int nYSrc, CopyPixelOperation dwRop);

        private const int SRCCOPY = 0x00CC0020;
        public Form1()
        {
            InitializeComponent();
            //Application.Idle += ImageCapture_Click;
        }

        Image<Bgr, byte> scaledImage;
        private void LoadImage_Click(object sender, EventArgs e)
        {
            var dialog=new OpenFileDialog();
            //文件筛选器，结构：显示名称|文件类型
            dialog.Filter = "图片(*.jpg/*.png/*.gif/*/bmp)|*.jpg;*.png;*.gif;*.bmp";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var filename=dialog.FileName;
                Image<Bgr, byte> image;
                image = new Image<Bgr, byte>(@filename);
                // 获取 ImageBox 控件的尺寸
                int imageBoxWidth = imageBox1.Width;
                int imageBoxHeight = imageBox1.Height;

                // 获取图像的尺寸
                int imageWidth = image.Width;
                int imageHeight = image.Height;

                // 计算缩放比例
                double scaleWidth = (double)imageBoxWidth / imageWidth;
                double scaleHeight = (double)imageBoxHeight / imageHeight;
                double scaleFactor = Math.Min(scaleWidth, scaleHeight);

                // 缩放图像,为了完整显示整个图像
                scaledImage = image.Resize(scaleFactor, Inter.Linear);
                imageBox1.Image = scaledImage;
                
            }
        }

        private void FormColor_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(640, 400, new Bgr(200, 200, 0));
            imageBox1.Image=img;
        }

        private void ScreenCapture_Click(object sender, EventArgs e)
        {
            string targetWindowTitle = "Visual studio 2010配置OpenCV环境.docx - Word"; // 指定目标窗口标题
            //FindWindow函数查找具有类名为 "TXGuiFoundation" 的窗口。IntPtr 是一个指向内存中一个整数的指针，它在这里用于存储窗口的句柄。
            //IntPtr targetWindowHandle = FindWindow("TXGuiFoundation", null);//第一个参数是类名，第二个参数是窗口标题名
            IntPtr targetWindowHandle = FindWindow(null, targetWindowTitle);//第一个参数是类名，第二个参数是窗口标题名

            if (targetWindowHandle != IntPtr.Zero)
            {
                RECT windowRect;
                GetWindowRect(targetWindowHandle, out windowRect);//out表示windowRect是输出参数

                int width = windowRect.Right - windowRect.Left;
                int height = windowRect.Bottom - windowRect.Top;

                using (Bitmap bitmap = new Bitmap(width, height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        // IntPtr hdcDest = graphics.GetHdc();
                        //IntPtr hdcSrc = GetWindowDC(targetWindowHandle);

                        // 使用 BitBlt 将窗口内容复制到位图
                        // BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, CopyPixelOperation.SourceInvert);

                        // ReleaseDC(targetWindowHandle, hdcSrc);
                        //graphics.ReleaseHdc(hdcDest);
                        IntPtr hdc = graphics.GetHdc();
                        PrintWindow(targetWindowHandle, hdc, 0);
                        graphics.ReleaseHdc(hdc);
                    }

                    bitmap.Save("C:\\Users\\dhl\\Pictures\\测试图片\\123.png");
                }
                
            }
            else
            {
                MessageBox.Show("Target window not found.");
            }

        }
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);
        

        private void WindowTitle_Click(object sender, EventArgs e)
        {
            bool EnumWindowCallback(IntPtr hWnd, IntPtr lParam)
            {
                const int maxWindowTextLength = 256;
                System.Text.StringBuilder windowText = new System.Text.StringBuilder(maxWindowTextLength);
                int length = GetWindowText(hWnd, windowText, maxWindowTextLength);

                if (length > 0)
                {
                    string windowTitle = windowText.ToString();
                    WinTitleBox.AppendText("Window Title: " + windowTitle + Environment.NewLine + "------------------------" + Environment.NewLine);
                }

                return true; // 继续遍历其他窗口
            }
            EnumWindows(EnumWindowCallback, IntPtr.Zero);
        }

        private void GrayCheck_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> grayImage = scaledImage.Convert<Gray, byte>();
            double thresholdValue = 20;
            // 创建一个输出图像，用于存储阈值处理后的结果
            Image<Gray, byte> thresholdedImage = new Image<Gray, byte>(grayImage.Width, grayImage.Height);

            // 应用阈值处理
            CvInvoke.Threshold(grayImage, thresholdedImage, thresholdValue, 255, ThresholdType.Binary);

            // 统计非零像素的数量
            int nonZeroPixelCount = CvInvoke.CountNonZero(thresholdedImage);
            MessageBox.Show(nonZeroPixelCount.ToString());

            // 判断是否全黑，0表示黑色，255则表示白色
            bool isAllBlack = (nonZeroPixelCount <= 1000);

            MessageBox.Show("Is the image all black? " + isAllBlack);

            // CvInvoke.Imshow("Thresholded Image", thresholdedImage);

            imageBox1.Image = thresholdedImage;
        }

        private void ImageCapture_Click(object sender, EventArgs e)
        {
            VideoCapture capture = new VideoCapture();
            //imageBox1.Image = capture.QueryFrame();
            Application.Idle += new EventHandler(delegate (object s, EventArgs ea)
            {
                imageBox1.Image = capture.QueryFrame();
            });
        }
        private Image<Bgr, byte> ProcessImage(Image<Bgr, byte> inputFrame)
        {
            // 在这里进行图像处理，例如滤波、边缘检测等
            return inputFrame; // 返回处理后的图像
        }
       
        private void GrayConvert_Click(object sender, EventArgs e)
        {
            //CvInvoke.Imshow("Jinx", scaledImage);
            Mat grayImage = new Mat();
            //转为灰度图像
            CvInvoke.CvtColor(scaledImage, grayImage, ColorConversion.Rgb2Gray);
            CvInvoke.Imshow("Gray Image", grayImage);
        }

        private void canny_Click(object sender, EventArgs e)
        {
            Mat grayImage = new Mat();
            //转为灰度图像
            CvInvoke.CvtColor(scaledImage, grayImage, ColorConversion.Rgb2Gray);
            CvInvoke.GaussianBlur(grayImage, grayImage, new Size(3, 3), 3);
            Mat cannyImg = new Mat();
            CvInvoke.Canny(grayImage, cannyImg, 20, 40);
            CvInvoke.Imshow("Canny Image", cannyImg);
        }

        private void Equalization_Click(object sender, EventArgs e)
        {
            Mat grayImage = new Mat();
            //转为灰度图像
            CvInvoke.CvtColor(scaledImage, grayImage, ColorConversion.Rgb2Gray);
            Mat equalizationImage= new Mat(scaledImage.Size, DepthType.Cv8U, 1);
            CvInvoke.EqualizeHist(grayImage, equalizationImage);
            CvInvoke.Imshow("Equalization", equalizationImage);
        }

        private void GaussianBlur_Click(object sender, EventArgs e)
        {
            Mat grayImage = new Mat();
            //转为灰度图像
            CvInvoke.CvtColor(scaledImage, grayImage, ColorConversion.Rgb2Gray);
            CvInvoke.GaussianBlur(grayImage, grayImage, new Size(3, 3), 3);
            CvInvoke.Imshow("GaussianBlur Image", grayImage);
        }

        private void MeanFilter_Click(object sender, EventArgs e)
        {
            Mat grayImage = new Mat();
            //转为灰度图像
            CvInvoke.CvtColor(scaledImage, grayImage, ColorConversion.Rgb2Gray);
            CvInvoke.Blur(grayImage, grayImage, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Imshow("MeanFilter Image", grayImage);
        }

        private void HoughCircles_Click(object sender, EventArgs e)
        {
            Mat grayImage = new Mat();
            //转为灰度图像
            CvInvoke.CvtColor(scaledImage, grayImage, ColorConversion.Rgb2Gray);
            //使用高斯滤波去除噪声
            CvInvoke.GaussianBlur(grayImage, grayImage, new Size(5, 5), 3);
            //霍夫圆检测
            CircleF[] circles = CvInvoke.HoughCircles(grayImage, HoughType.Gradient, 2.0, 20.0, 100.0, 180.0, 5);
            #region draw circles
            Image<Bgr, Byte> circleImage = scaledImage.Clone();
            foreach (CircleF circle in circles)
                circleImage.Draw(circle, new Bgr(Color.Blue), 4);
            CvInvoke.Imshow("HoughCircles", circleImage);
            #endregion
        }
    }
}
