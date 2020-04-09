﻿using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;

namespace WhoIsDemo.presenter
{
    class GraffitsPresenter
    {
        #region constants
        private const float aspectRatio = 1.6F;
        #endregion
        #region variables
        private int heightScaling;
        private float factorScalingWidth = -1;
        private float factorScalingHeight = -1;
        private int widthScaling;
        private bool isWritingImage = false;
        private bool isWritingImageForCoordinates = false;
        private bool isWritingImageForTracking = false;
        private int linkVideo;
        public Subject<bool> subjectLoad = new Subject<bool>();
        private bool cancelLoad = false;
        private bool isLoadFile = false;
        private static readonly object _balanceLocker = new object();
        DiskPresenter diskPresenter = new DiskPresenter();
        #endregion

        #region methods
        public GraffitsPresenter() { }

        public int HeightScaling { get => heightScaling; }
        public float FactorScalingWidth { get => factorScalingWidth;}
        public int WidthScaling { get => widthScaling;}
        public bool IsWritingImage { get => isWritingImage; set => isWritingImage = value; }
        public bool IsWritingImageForCoordinates { get => isWritingImageForCoordinates; set => isWritingImageForCoordinates = value; }
        public int LinkVideo { get => linkVideo; set => linkVideo = value; }
        public bool IsWritingImageForTracking { get => isWritingImageForTracking; set => isWritingImageForTracking = value; }
        public bool CancelLoad { get => cancelLoad; set => cancelLoad = value; }
        public bool IsLoadFile { get => isLoadFile; set => isLoadFile = value; }
        public float FactorScalingHeight { get => factorScalingHeight; set => factorScalingHeight = value; }

        public void DimesionAdjustment(int width, int height)
        {
            //if (width > Configuration.Instance.MaximumResolutionAccepted)
            //{
            //    float aspectRatio = Convert.ToSingle(width) / Convert.ToSingle(height);
            //    Configuration.Instance.Width = Configuration.Instance.MaximumResolutionAccepted;
            //    float approximateHigh = Convert.ToSingle(Configuration.Instance.Width) / aspectRatio;
            //    Configuration.Instance.Height = Convert.ToInt32(approximateHigh);

            //}
            //else
            //{
            //    Configuration.Instance.Width = width;
            //    Configuration.Instance.Height = height;
            //}
            Configuration.Instance.WidthReal = width;
            Configuration.Instance.HeightReal = height;
            ScalingCoordinatesText();
        }

        private void ScalingCoordinatesText()
        {
            Configuration.Instance.FactorScalingWidthText = 
                Convert.ToSingle(Configuration.Instance.WidthReal) / Convert.ToSingle(Configuration.templateWidth);
            Configuration.Instance.FactorScalingHeightText =
                Convert.ToSingle(Configuration.Instance.HeightReal) / Convert.ToSingle(Configuration.templateHeight);

        }

        public void TextScalingAdjustment()
        {
            int width = Configuration.Instance.WidthReal;
            int height = Configuration.Instance.HeightReal;
            int approximateArea = width * height;

            float differenceArea = Convert.ToSingle(approximateArea) / Convert
                .ToSingle(Configuration.Instance.AreaDefault);
            Configuration.Instance.FactorScalingSizeFont = differenceArea * Configuration.scalingFontSize;
            Configuration.Instance.FactorScalingIncrementHeight = differenceArea * Configuration.incrementHeight;
        }
        public void ImageScalingAdjustment()
        {
            int width = Configuration.Instance.WidthReal;
            int height = Configuration.Instance.HeightReal;
            int approximateArea = width * height;

            if (approximateArea > Configuration.Instance.AreaDefault)
            {
                //float aspectRatio = Convert.ToSingle(width) / Convert.ToSingle(height);
                
                float approximateHigh = Convert.ToSingle(Configuration
                    .Instance.ResolutionWidthDefault) / aspectRatio;
                heightScaling = Convert.ToInt32(approximateHigh);
                widthScaling = Configuration
                    .Instance.ResolutionWidthDefault;
                //factorScaling = Convert.ToSingle(approximateArea) / Convert.ToSingle(standardArea);
                factorScalingWidth = Convert.ToSingle(width) / Convert.ToSingle(widthScaling);
                
            }
            else
            {                
                widthScaling = width;
                float approximateHigh = Convert.ToSingle(widthScaling) / aspectRatio;
                heightScaling = Convert.ToInt32(approximateHigh);
                //heightScaling = height;
                factorScalingWidth = 1f;
                

            }

            factorScalingHeight = Convert.ToSingle(height) / Convert.ToSingle(heightScaling);            

        }

        //private void WriteImageForRecognition(string pathImage)
        //{
        //    Mat clone = CvInvoke.Imread(pathImage, ImreadModes.Color);
        //    if (clone != null)
        //    {
        //        int length = clone.Width * clone.Height * clone.NumberOfChannels;
        //        byte[] data = new byte[length];                
        //        GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        //        using (Mat m2 = new Mat(clone.Size, DepthType.Cv8U, clone.NumberOfChannels,
        //            handle.AddrOfPinnedObject(), clone.Width * clone.NumberOfChannels))
        //            CvInvoke.BitwiseNot(clone, m2);
        //        handle.Free();

        //        RequestAipu.Instance.SendFrame(data, clone.Height,
        //            clone.Width, linkVideo);
        //        clone.Dispose();

        //    }
        //    isWritingImage = false;

        //}
        //public void WriteImageForRecognition(object state)
        //{
        //    lock (_balanceLocker)
        //    {
        //        Mat img = (Mat)state;
        //        Mat clone = img.Clone();
        //        //if (factorScaling != 1)
        //        //{
        //        //    CvInvoke.Resize(clone, clone, new Size(widthScaling, heightScaling), 0, 0, Inter.Area);
        //        //}
        //        //CvInvoke.Resize(clone, clone, new Size(widthScaling, heightScaling), 0, 0, Inter.Lanczos4);
        //        CvInvoke.Resize(clone, clone, new Size(widthScaling, heightScaling), 0, 0, Inter.Area);

        //        int length = clone.Width * clone.Height * clone.NumberOfChannels;
        //        byte[] data = new byte[length];

        //        GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        //        using (Mat m2 = new Mat(clone.Size, DepthType.Cv8U, clone.NumberOfChannels,
        //            handle.AddrOfPinnedObject(), clone.Width * clone.NumberOfChannels))
        //            CvInvoke.BitwiseNot(clone, m2);
        //        handle.Free();

        //        RequestAipu.Instance.Tracking(data, clone.Height,
        //           clone.Width);
        //        RequestAipu.Instance.SendFrame(data, clone.Height,
        //            clone.Width, linkVideo);

        //        clone.Dispose();
        //        //isWritingImage = false;
        //    }

        //}

        public void ReloadAipu()
        {
            RequestAipu.Instance.StopAipu();
            Task.Delay(500).Wait();
            RequestAipu.Instance.ReloadAipu();
            Task.Delay(500).Wait();

        }

        public async Task TaskImageFileForRecognition(string[] listPath)
        {

            await Task.Run(() =>
            {
                LaunchImageFileForRecognition(listPath);

            });

        }

        public void LaunchImageFileForRecognition(string[] listPath)
        {
            int count = 0;
            while (count < listPath.Count() && !CancelLoad)
            {
                //Task.Delay(20).Wait();
                if (RequestAipu.Instance.GetIsFinishLoadFiles())
                {

                    //WriteImageForRecognition(listPath[count]);
                    //if ((count % 100) == 0)
                    //{
                    //    RequestAipu.Instance.StopAipu();
                    //    Task.Delay(500).Wait();
                    //    RequestAipu.Instance.ReloadAipu();
                    //    Task.Delay(500).Wait();
                    //}
                    string fileImage = listPath[count];
                    
                    RequestAipu.Instance.RecognitionFaceFiles(fileImage, linkVideo);
                    count++;

                }
                
            }
            //Task.Delay(300).Wait();
            CancelLoad = false;
            subjectLoad.OnNext(true);

            //diskPresenter.WriteFileOfFiles(listPath);
            //RequestAipu.Instance.RecognitionFaceFiles(DiskPresenter.file_list_images, linkVideo);
            //subjectLoad.OnNext(true);
        }
        //public async Task TaskImageForRecognition(Mat img)
        //{

        //    await Task.Run(() =>
        //    {
        //        LaunchImageForRecognition(img);

        //    });

        //}

        //private void WriteImageForCoordinates(Mat img)
        //{
        //    Mat clone = img.Clone();

        //    //GpuMat gMatSrc = new GpuMat();
        //    //GpuMat gMatDst = new GpuMat();
        //    //gMatSrc.Upload(clone);
        //    //Emgu.CV.Cuda.CudaInvoke.Resize(gMatSrc, gMatDst,
        //    //        new Size(widthScaling, heightScaling));
        //    //gMatDst.Download(clone);
        //    //using (GpuMat gMatSrc = new GpuMat())
        //    //using (GpuMat gMatDst = new GpuMat())
        //    //{
        //    //    gMatSrc.Upload(clone);
        //    //    Emgu.CV.Cuda.CudaInvoke.Resize(gMatSrc, gMatDst, 
        //    //        new Size(widthScaling, heightScaling));
        //    //    gMatDst.Download(clone);
        //    //}

        //    if (factorScaling != 1)
        //    {
        //        CvInvoke.Resize(clone, clone, new Size(widthScaling, heightScaling));
        //    }
        //    int length = clone.Width * clone.Height * clone.NumberOfChannels;
        //    byte[] data = new byte[length];

        //    GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        //    using (Mat m2 = new Mat(clone.Size, DepthType.Cv8U, clone.NumberOfChannels,
        //        handle.AddrOfPinnedObject(), clone.Width * clone.NumberOfChannels))
        //        CvInvoke.BitwiseNot(clone, m2);
        //    handle.Free();

        //    RequestAipu.Instance.SendFastFrame(data, clone.Height,
        //        clone.Width);
        //    clone.Dispose();
        //    isWritingImageForCoordinates = false;
        //}

        //private void LaunchImageForCoordinates(Mat img)
        //{
        //    isWritingImageForCoordinates = true;

        //    WriteImageForCoordinates(img);

        //}

        //public async Task TaskImageForCoordinates(Mat img)
        //{

        //    await Task.Run(() =>
        //    {
        //        LaunchImageForCoordinates(img);

        //    });

        //}

        //public async Task TaskInitTracking()
        //{

        //    await Task.Run(() =>
        //    {
        //        InitTracking();

        //    });

        //}
        //private void InitTracking()
        //{
        //    //RequestAipu.Instance.InitTracking();
        //    //Mat clone = CvInvoke.Imread("camera\\mask.png");
        //    //if (clone != null)
        //    //{                
        //    //    CvInvoke.Resize(clone, clone, new Size(widthScaling, heightScaling), 0, 0, Inter.Area);
        //    //    //Console.WriteLine("MASK TRACKING WIDTH: {0} HEIGHT: {1} NUMBER CHANNELS: {2}", 
        //    //    //    widthScaling, heightScaling, clone.NumberOfChannels);
        //    //    //CvInvoke.Imwrite("camera\\maskTest.png", clone);

        //    //    int length = clone.Width * clone.Height * clone.NumberOfChannels;
        //    //    byte[] data = new byte[length];

        //    //    GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        //    //    using (Mat m2 = new Mat(clone.Size, DepthType.Cv8U, clone.NumberOfChannels,
        //    //        handle.AddrOfPinnedObject(), clone.Width * clone.NumberOfChannels))
        //    //        CvInvoke.BitwiseNot(clone, m2);
        //    //    handle.Free();

        //    //    RequestAipu.Instance.InitTracking();
        //    //    clone.Dispose();
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine("Mask NULL...");
        //    //}

        //}

        //public async Task TaskTracking(Mat img)
        //{

        //    await Task.Run(() =>
        //    {
        //        LaunchImageForTracking(img);

        //    });

        //}

        //private void LaunchImageForTracking(Mat img)
        //{
        //    isWritingImageForTracking = true;

        //    WriteImageForTracking(img);

        //}

        //private void WriteImageForTracking(Mat img)
        //{
        //    Mat clone = img.Clone();
        //    if (factorScaling != 1)
        //    {
        //        CvInvoke.Resize(clone, clone, new Size(widthScaling, heightScaling));

        //    }

        //    int length = clone.Width * clone.Height * clone.NumberOfChannels;
        //    byte[] data = new byte[length];

        //    GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        //    using (Mat m2 = new Mat(clone.Size, DepthType.Cv8U, clone.NumberOfChannels,
        //        handle.AddrOfPinnedObject(), clone.Width * clone.NumberOfChannels))
        //        CvInvoke.BitwiseNot(clone, m2);
        //    handle.Free();

        //    RequestAipu.Instance.Tracking(data, clone.Height,
        //        clone.Width);
        //    clone.Dispose();
        //    isWritingImageForTracking = false;
        //}

        public void SetSequenceFps(int value)
        {
            RequestAipu.Instance.SetSequenceFps(value);
        }

        public void SetWidthFrame(int value)
        {
            RequestAipu.Instance.SetWidthFrame(value);
        }

        public void SetHeightFrame(int value)
        {
            RequestAipu.Instance.SetHeightFrame(value);
        }

        public void SetClient(int value)
        {
            RequestAipu.Instance.SetClient(value);
        }

        public void SetMinEyeDistance(int minDistance)
        {
            RequestAipu.Instance.SetMinEyeDistance(minDistance);
        }

        public void SetMaxEyeDistance(int maxDistance)
        {
            RequestAipu.Instance.SetMaxEyeDistance(maxDistance);
        }

        public void SetFaceConfidenceThresh(int value)
        {
            RequestAipu.Instance.SetFaceConfidenceThresh(value);
        }

        public void SetRefreshInterval(int value)
        {
            RequestAipu.Instance.SetRefreshInterval(value);
        }

        public void SetFileVideo(string file)
        {
            RequestAipu.Instance.SetFileVideo(file);
        }

        public void SetIpCamera(string ip)
        {
            RequestAipu.Instance.SetIpCamera(ip);
        }

        public void SetTrackingMode(int mode)
        {
            RequestAipu.Instance.SetTrackingMode(mode);
        }
        public void SetTrackSpeed(int speed)
        {
            RequestAipu.Instance.SetTrackSpeed(speed);
        }
        public void SetMotionOptimization(int motion)
        {
            RequestAipu.Instance.SetMotionOptimization(motion);
        }

        public void SetDeviceVideo(string device)
        {
            RequestAipu.Instance.SetDeviceVideo(device);
        }

        public void SetDeepTrack(string value)
        {
            RequestAipu.Instance.SetDeepTrack(value);
        }
        public void ResetCountRepeatUser()
        {
            RequestAipu.Instance.ResetCountRepeatUser();
        }
        public int GetCountRepeatUser()
        {
            return RequestAipu.Instance.GetCountRepeatUser();
        }

        public void StatePlay()
        {
            RequestAipu.Instance.StatePlay();
        }
        public void StatePaused()
        {
            RequestAipu.Instance.StatePaused();
        }

        public void SetNameWindow(string name)
        {
            RequestAipu.Instance.SetNameWindow(name);
        }

        public void CaptureFlow(int optionFlow)
        {
            RequestAipu.Instance.CaptureFlow(optionFlow);
        }

        public void ShowWindow(int option)
        {
            RequestAipu.Instance.ShowWindow(option);
        }
        public void TerminateTracking()
        {
            RequestAipu.Instance.TerminateTracking();

        }

        public void SetFlagFlow(bool flag)
        {
            RequestAipu.Instance.SetFlagFlow(flag);
        }

        public void SetFramesTotal(int total)
        {
            RequestAipu.Instance.SetFramesTotal(total);
        }

        //public void PutTextInFrame(Mat img, int countNewPerson, double fps)
        //{
        //    string textBox = string.Format("Resolution:{0}x{1}",
        //Configuration.Instance.WidthReal, Configuration.Instance.HeightReal);
        //    int x = Convert.ToInt32(Convert
        //        .ToSingle(Configuration.Instance.CoordinatesXText) * Configuration
        //        .Instance.FactorScalingWidthText);
        //    int y = Convert.ToInt32(Convert
        //        .ToSingle(Configuration.Instance.CoordinatesYText) * Configuration
        //        .Instance.FactorScalingHeightText);
        //    CvInvoke.PutText(img, textBox, new System.Drawing
        //        .Point(x, y),
        //        FontFace.HersheySimplex, 0.4,
        //        new MCvScalar(255.0, 255.0, 255.0));
        //    textBox = string.Format("FPS: {0}",
        //        Convert.ToInt16(fps));
        //    y += 25; //Convert.ToInt32(Configuration.Instance.FactorScalingIncrementHeight);
        //    CvInvoke.PutText(img, textBox, new System.Drawing
        //        .Point(x, y),
        //        FontFace.HersheySimplex, 0.4,
        //        new MCvScalar(255.0, 255.0, 255.0));
        //    textBox = string.Format("Identified: {0}",
        //        countNewPerson);
        //    y += 25; // Convert.ToInt32(Configuration.Instance.FactorScalingIncrementHeight);
        //    CvInvoke.PutText(img, textBox, new System.Drawing
        //        .Point(x, y),
        //        FontFace.HersheySimplex, 0.4,
        //        new MCvScalar(255.0, 255.0, 255.0));
        //    //Configuration.Instance.FactorScalingSizeFont
        //}


        #endregion
    }
}
