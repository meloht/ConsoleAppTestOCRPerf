using OpenCvSharp;
using Sdcb.PaddleInference;
using Sdcb.PaddleOCR;
using Sdcb.PaddleOCR.Models;
using Sdcb.PaddleOCR.Models.Local;

namespace ConsoleAppOCRPerfPaddle
{
    internal class Program
    {
        const string dir = @"C:\FtpFiles\OCRTestImages";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            OcrTest();

            Console.ReadKey();

        }

        private static void OcrTest()
        {
            FullOcrModel model = LocalFullModels.ChineseV5;


            var list = Directory.GetFiles(dir);


            using (PaddleOcrAll all = new PaddleOcrAll(model, PaddleDevice.Gpu())
            {
                AllowRotateDetection = true, /* 允许识别有角度的文字 */
                Enable180Classification = true, /* 允许识别旋转角度大于90度的文字 */
            })
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                foreach (var file in list)
                {
                    // Load local file by following code:
                    using (Mat src = Cv2.ImRead(file))
                    {
                        PaddleOcrResult result = all.Run(src);
                        Console.WriteLine("Detected text blocks: " + result.Regions.Count());

                    }
                }
                sw.Stop();

                Console.WriteLine($"PaddleSharp Elapsed time:{sw.Elapsed}");

            }
        }
    }
}
