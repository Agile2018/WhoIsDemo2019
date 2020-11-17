using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using WhoIsDemo.model;
using Newtonsoft.Json;
using System.Drawing;
using WhoIsDemo.view.tool;
using System.Diagnostics;
using System.Threading;

namespace WhoIsDemo.presenter
{
    class HearTemplateImagePresenter
    {
        #region variables                
        private List<int> idVideos = new List<int>();
        public Subject<Bitmap> subjectImage = new Subject<Bitmap>();

        public List<int> IdVideos { get => idVideos; set => idVideos = value; }

        #endregion

        #region methods

        public HearTemplateImagePresenter() {
            
        }
        
        private void LaunchTemplate(string dataImage)
        {
            ImageTemplate imageTemplate;
            try
            {

                imageTemplate = JsonConvert.DeserializeObject<ImageTemplate>(dataImage);
                if (imageTemplate != null)
                {
                    int idVid = Convert.ToInt16(imageTemplate.Params.client);

                    if (idVideos.Count > 0 && idVideos.Contains(idVid))
                    {
                        var sw = Stopwatch.StartNew();
                        Bitmap imageTransform = Transform.Instance
                            .Base64StringToBitmap(imageTemplate.Params.data_image);
                        if (imageTransform != null)
                        {
                            
                            subjectImage.OnNext(imageTransform);
                        }
                        sw.Stop();                        
                        //Console.WriteLine(".............OUT IMAGE PRESENTER........................................");
                        //Console.WriteLine(sw.ElapsedMilliseconds.ToString());
                    }
                }
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetTemplateData(int quantity)
        {
            List<string> listData = new List<string>();
            //bool flagRead = false;
            //var sw = Stopwatch.StartNew();

            //while (sw.ElapsedMilliseconds < 500 && !flagRead)
            //{
            //    flagRead = AipuFace.Instance.GetIsFinishLoadTemplates();
            //    Console.WriteLine("........ELAPSE TEMPLATES........................" + flagRead.ToString());

            //}
            //sw.Stop();
            
            for (int i = 0; i < quantity; i++)
            {
                string dataImage = AipuFace.Instance.GetTemplateDataJSON();
                if (!string.IsNullOrEmpty(dataImage))
                {
                    listData.Add(dataImage);
                }
                
            }
            foreach (string item in listData)
            {
                LaunchTemplate(item);
            }
            listData.Clear();
        }

        #endregion
    }
}
