using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class RequestAipu
    {
        #region variables
        private static readonly RequestAipu instance = new RequestAipu();
        public static RequestAipu Instance => instance;
        #endregion
        #region methods
        public RequestAipu() { }        

       

        public bool IsEnableObserverUser()
        {
            return AipuFace.Instance.IsObserverUser();
        }

        public void EnableEarUser()
        {
            AipuFace.Instance.EnableObserverUser();
        }     
       
        public void ReloadAipu()
        {
            AipuFace.Instance.ReloadAipu();
        }

        public void StopAipu()
        {
            AipuFace.Instance.StopAipu();
        }
        public void Terminate()
        {
            AipuFace.Instance.Terminate();
        }
       

        public void InitLibrary()
        {
            AipuFace.Instance.InitLibrary();
        }

           
        public void RecognitionFaceFiles(string file, int client)
        {
            AipuFace.Instance.RecognitionFaceFiles(file, client);
        }

        public void SetIsFinishLoadFiles(bool value)
        {
            AipuFace.Instance.SetIsFinishLoadFiles(value);
        }
        public bool GetIsFinishLoadFiles()
        {
            return AipuFace.Instance.GetIsFinishLoadFiles();
        }

        

        public void StatePlay(int option)
        {
            AipuFace.Instance.StatePlay(option);
        }
        public void StatePaused(int option)
        {
            AipuFace.Instance.StatePaused(option);
        }
       

        #endregion
    }
}
