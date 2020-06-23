﻿using System.Linq;
using System.Reactive.Subjects;
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
        public Subject<bool> subjectLoad = new Subject<bool>();
        private bool cancelLoad = false;
        private bool isLoadFile = false;

        public int LinkVideo { get => linkVideo; set => linkVideo = value; }
        public bool CancelLoad { get => cancelLoad; set => cancelLoad = value; }
        public bool IsLoadFile { get => isLoadFile; set => isLoadFile = value; }

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
                    
                    string fileImage = listPath[count];

                    AipuFace.Instance.RecognitionFaceFiles(fileImage, linkVideo);
                    count++;

                }

            }
            
            CancelLoad = false;
            AipuFace.Instance.SavePerformance(linkVideo);
            subjectLoad.OnNext(true);
            
        }
        #endregion
    }
}