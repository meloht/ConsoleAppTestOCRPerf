using RapidOCRSharpOnnx;
using RapidOCRSharpOnnx.Configurations;
using RapidOCRSharpOnnx.Providers;
using RapidOCRSharpOnnx.Utils;
using System.Diagnostics;

namespace ConsoleAppTestOCRPerf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TestParallelBatch();
        }


        private static void TestParallelBatch()
        {

            //string detectPath = @"D:\code\RapidOCR-3.8.0\python\rapidocr\models\ch_PP-OCRv4_det_mobile.onnx";
            //string recogPath = @"D:\code\RapidOCR-3.8.0\python\rapidocr\models\ch_PP-OCRv4_rec_mobile.onnx";
            //string clsPath = @"D:\code\RapidOCR-3.8.0\python\rapidocr\models\ch_ppocr_mobile_v2.0_cls_mobile.onnx";

            //string saveDir = null;
            string detectPath = @"D:\code\RapidOCRSharpOnnx\RapidOCRSharpOnnx.TestCommon\Models\ch_PP-OCRv5_det_mobile.onnx";
            string recogPath = @"D:\code\RapidOCRSharpOnnx\RapidOCRSharpOnnx.TestCommon\Models\ch_PP-OCRv5_rec_mobile.onnx";
            string clsPath = @"D:\code\RapidOCRSharpOnnx\RapidOCRSharpOnnx.TestCommon\Models\ch_PP-LCNet_x0_25_textline_ori_cls_mobile.onnx";
          

            using RapidOCRSharp ocr = new RapidOCRSharp(new ExecutionProviderCPU(new OcrConfig(detectPath, recogPath, LangRec.CH, OCRVersion.PPOCRV5, clsPath)));
            var list = Directory.GetFiles(@"D:\code\model\OCRTestImages");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var resPath = ocr.BatchParallelAsync(list.ToList());
            sw.Stop();
            Console.WriteLine($"RapidOCRSharp Elapsed Time: {sw.ElapsedMilliseconds} ms");


            Console.WriteLine("end");
        }
    }
}
