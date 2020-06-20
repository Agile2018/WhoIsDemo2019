using Aipu2NetLib;

namespace WhoIsDemo.model
{
    class AipuFace
    {
        #region constant
        private const int reset = 1;
        private const int finish = 0;
        #endregion
        #region variables
        AipuNet aipu;
        AipuObserver aipuObserver;
        private bool isRunVideo = false;
        private bool isStopAipu = false;
        private bool isTracking = false;
        private bool isLoadLibrary = false;
        private static readonly AipuFace instance = new AipuFace();
        public static AipuFace Instance => instance;

        public bool IsRunVideo { get => isRunVideo; set => isRunVideo = value; }
        public bool IsStopAipu { get => isStopAipu; set => isStopAipu = value; }
        public bool IsTracking { get => isTracking; set => isTracking = value; }
        public bool IsLoadLibrary { get => isLoadLibrary; set => isLoadLibrary = value; }
        #endregion

        #region methods
        public AipuFace()
        {
            aipu = new AipuNet();
            aipuObserver = new AipuObserver(aipu);
            
        }

        private void InitProcessAipu()
        {
            aipu = new AipuNet();
            aipuObserver = new AipuObserver(aipu);
        }

        //public void LoadConfiguration(string nameFileConfiguration)
        //{
        //    try
        //    {
        //        aipu.LoadConfiguration(nameFileConfiguration);
        //        IsLoadConfiguration = true;
        //    }
        //    catch (SEHException sehException)
        //    {
        //        throw new Exception(sehException.Message);

        //    }
        //}

        public void ConnectDatabase()
        {
            aipu.ConnectDatabase();
        }

        public void InitLibrary()
        {
            aipu.InitLibrary();
            IsLoadLibrary = true;
        }

        public void LoadConfiguration(int option)
        {
            aipu.LoadConfiguration(option);
        }

        public void InitWindowMain(int option)
        {
            aipu.InitWindowMain(option);
        }

        public void RunVideo(int option)
        {
            aipu.RunVideo(option);
            IsRunVideo = true;
        }

        public void CloseWindow()
        {
            aipu.CloseWindow();
        }

        public void ReRunVideo(int option)
        {
            aipu.ReRunVideo(option);
        }
        public void SetFinishLoop(int option)
        {
            aipu.SetFinishLoop(option);
        }

        //public void SetFileVideo(string file)
        //{
        //    aipu.SetFileVideo(file);
        //}

        //public void SetNameWindow(string name)
        //{
        //    aipu.SetNameWindow(name);
        //}

        //public void SetFramesTotal(int total)
        //{
        //    aipu.SetFramesTotal(total);
        //}

        //public void SetWidthFrame(int value)
        //{
        //    aipu.SetWidthFrame(value);

        //}

        //public void SetHeightFrame(int value)
        //{
        //    aipu.SetHeightFrame(value);

        //}

        //public void CaptureFlow(int optionFlow)
        //{
        //    isTracking = true;
        //    aipu.CaptureFlow(optionFlow);
        //}

        //public void SetIpCamera(string ip)
        //{
        //    aipu.SetIpCamera(ip);
        //}

        //public void SetDeviceVideo(string device)
        //{
        //    aipu.SetDeviceVideo(device);
        //}

        //public void SetDeepTrack(string value)
        //{
        //    aipu.SetDeepTrack(value);
        //}

        public void SetChannel(int channel)
        {
            aipu.SetChannel(channel);
        }

        public void ResetPerformance(int option)
        {
            aipu.ResetPerformance(option);
        }
        public void SavePerformance(int option)
        {
            aipu.SavePerformance(option);
        }
        //public void ResetCountRepeatUser()
        //{
        //    aipu.ResetCountRepeatUser();
        //}
        //public int GetCountRepeatUser()
        //{
        //    return aipu.GetCountRepeatUser;
        //}

        //public void SetFaceConfidenceThresh(int value)
        //{
        //    aipu.SetFaceConfidenceThresh(value);
        //}

        //public void SetRefreshInterval(int value)
        //{
        //    aipu.SetRefreshInterval(value);
        //}

        //public void SetMinEyeDistance(int minDistance)
        //{
        //    aipu.SetMinEyeDistance(minDistance);
        //}

        //public void SetMaxEyeDistance(int maxDistance)
        //{
        //    aipu.SetMaxEyeDistance(maxDistance);
        //}

        //public void SetSequenceFps(int value)
        //{
        //    if (value != 0)
        //    {
        //        aipu.SetSequenceFps(value);
        //    }
            

        //}

        //public void SetClient(int value)
        //{
        //    aipu.SetClient(value);
        //}

        //public void SetFlagFlow(bool flag)
        //{
        //    aipu.SetFlagFlow(flag);
        //}

        //public void ShowWindow(int option)
        //{
        //    aipu.ShowWindow(option);
        //}
                
        //public void SetConfigurationDatabase()
        //{
        //    aipu.SetConfigurationDatabase();
        //}

        public void StatePlay(int option)
        {
            aipu.StatePlay(option);
        }
        public void StatePaused(int option)
        {
            aipu.StatePaused(option);
        }
        //public void SetTrackingMode(int mode)
        //{
        //    aipu.SetTrackingMode(mode);
        //}
        //public void SetTrackSpeed(int speed)
        //{
        //    aipu.SetTrackSpeed(speed);
        //}
        //public void SetMotionOptimization(int motion)
        //{
        //    aipu.SetMotionOptimization(motion);
        //}

        //public void TerminateTracking()
        //{
        //    if (isTracking)
        //    {
        //        aipu.SetFlagFlow(true);
        //    }
            
        //    isTracking = false;
        //}

        //public void SetIsRegister(bool option)
        //{
        //    aipu.SetIsRegister(option);
        //}                              
        
        public void RecognitionFaceFiles(string file, int client)
        {
            aipu.RecognitionFaceFiles(file, client);
        }

        public void SetIsFinishLoadFiles(bool value)
        {
            aipu.SetIsFinishLoadFiles(value);
        }
        public bool GetIsFinishLoadFiles()
        {
            return aipu.GetIsFinishLoadFiles;
        }

        //public void InitLibraryIdentify()
        //{
        //    aipu.InitLibraryIdentify();
        //}

        //public void ResetLowScore()
        //{
        //    aipu.ResetLowScore();
        //}
        //public int GetCountLowScore()
        //{
        //    return aipu.GetCountLowScore;
        //}
        //public void ResetCountNotDetect()
        //{
        //    aipu.ResetCountNotDetect();
        //}
        //public int GetCountNotDetect()
        //{
        //    return aipu.GetCountNotDetect;
        //}
        //public void SendFrame(byte[] data, int rows, int cols, int client)
        //{
        //    aipu.SetFrame(data, rows, cols, client);

        //}       

        public AipuObserver GetObserver()
        {
            return aipuObserver;
        }

        public void EnableObserverUser()
        {
            aipuObserver.EnableObserverUser();
        }        

        public bool IsObserverUser()
        {
            return aipuObserver.IsHearObserverUser;
        }        

        public void ReloadAipu()
        {
            if (IsRunVideo && IsStopAipu)
            {
                aipu.ReloadRecognitionFace();
                IsStopAipu = false;
            }
        }

        public void StopAipu()
        {
            if (IsRunVideo && !IsStopAipu)
            {
                aipu.Terminate();
                IsStopAipu = true;
            }
        }
        
        public void Terminate()
        {
            if (IsRunVideo)
            {
                aipu.CloseWindow();
                aipu.Terminate();
                IsLoadLibrary = false;                
                IsRunVideo = false;
            }

            if (IsLoadLibrary)
            {
                aipu.Terminate();
            }

            aipu.Dispose();
            aipuObserver.Dispose();
        }
        #endregion
    }
}
