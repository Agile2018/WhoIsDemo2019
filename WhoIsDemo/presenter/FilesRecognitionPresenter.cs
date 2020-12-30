using System;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.presenter
{
    class FilesRecognitionPresenter
    {
        #region constants
        
        #endregion
        #region variables
        
        private int linkVideo;
        private int taskIdentify;
        public Subject<bool> subjectLoad = new Subject<bool>();
        private bool cancelLoad = false;
        private bool isLoadFile = false;

        public int LinkVideo { get => linkVideo; set => linkVideo = value; }
        public bool CancelLoad { get => cancelLoad; set => cancelLoad = value; }
        public bool IsLoadFile { get => isLoadFile; set => isLoadFile = value; }
        public int TaskIdentify { get => taskIdentify; set => taskIdentify = value; }

        #endregion

        #region methods

        public FilesRecognitionPresenter() { }

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

                if (AipuFace.Instance.GetIsFinishLoadFiles())
                {
                    AipuFace.Instance.SetIsFinishLoadFiles(false);
                    string fileImage = listPath[count];

                    AipuFace.Instance.RecognitionFaceFiles(fileImage, linkVideo, TaskIdentify);

                    count++;

                }

            }

            Thread.Sleep(30);

            CancelLoad = false;

            subjectLoad.OnNext(true);

        }

        public void AddCollectionOfImages(string folder, int client, int doing)
        {
            AipuFace.Instance.AddCollectionOfImages(folder, client, doing);
        }

        #endregion
    }
}
