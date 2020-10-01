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

        public void LoadConfigurationPipe(int pipeline)
        {
            aipu.LoadConfigurationPipe(pipeline);
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

        public void SetTaskIdentify(int value, int option)
        {
            aipu.SetTaskIdentify(value, option);
        }

        public void ResetEnrollVideo(int option)
        {
            aipu.ResetEnrollVideo(option);
        }

        public void SetColourTextFrameOne(float red, float green, float blue)
        {
            aipu.SetColourTextFrameOne(red, green, blue);
        }

        public void SetColourTextFrameTwo(float red, float green, float blue)
        {
            aipu.SetColourTextFrameTwo(red, green, blue);
        }

        public void SetColourTextFrameThree(float red, float green, float blue)
        {
            aipu.SetColourTextFrameThree(red, green, blue);
        }

        public void SetColourTextFrameFour(float red, float green, float blue)
        {
            aipu.SetColourTextFrameFour(red, green, blue);
        }

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

        public void StatePlay(int option)
        {
            aipu.StatePlay(option);
        }
        public void StatePaused(int option)
        {
            aipu.StatePaused(option);
        }               
        
        public void RecognitionFaceFiles(string file, int client, int task)
        {
            aipu.RecognitionFaceFiles(file, client, task);
        }

        public void AddCollectionOfImages(string folder, int client, int doing)
        {
            aipu.AddCollectionOfImages(folder, client, doing);
        }

        public void SetIsFinishLoadFiles(bool value)
        {
            aipu.SetIsFinishLoadFiles(value);
        }
        public bool GetIsFinishLoadFiles()
        {
            return aipu.GetIsFinishLoadFiles;
        }

        public void SetNumberPipelines(int value)
        {
            aipu.SetNumberPipelines(value);
        }

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
