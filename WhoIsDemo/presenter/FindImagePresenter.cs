using System;
using System.Drawing;
using System.Reactive.Subjects;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.presenter
{
    class FindImagePresenter
    {
        #region variables
     
        FindImage findImage = new FindImage();

        public Subject<ImageBMP> subjectImage = new Subject<ImageBMP>();
        
        #endregion

        #region methods
        public FindImagePresenter()
        {
            this.findImage.OnImage += new FindImage
                .ImageDelegate(SendBitmap);
            
        }
        

        public void GetImage64ByUser(int idFace)
        {
            findImage.GetImageByIdFace(idFace);
        }

        public void GetListImage64ByUser(int idFace)
        {
            findImage.GetListImageByIdFace(idFace);
        }

        private void SendBitmap(Image64 image64)
        {
            ImageBMP imageBMP = new ImageBMP();
            if (String.IsNullOrEmpty(image64.data_64_aux))
            {                
                Bitmap imageTransform = Transform.Instance.Base64StringToBitmap(image64.data_64);
                if (imageTransform != null)
                {
                    imageBMP.id_face = image64.id_face;
                    imageBMP.imageStore = imageTransform;
                    imageBMP.log = image64.log;
                    subjectImage.OnNext(imageBMP);
                }
            }
            else
            {
                Bitmap imageGallery = Transform.Instance.Base64StringToBitmap(image64.data_64);
                Bitmap imageCamera = Transform.Instance.Base64StringToBitmap(image64.data_64_aux);
                if (imageGallery != null && imageCamera != null)
                {
                    imageBMP.id_face = image64.id_face;
                    imageBMP.imageStore = imageGallery;
                    imageBMP.imageNew = imageCamera;
                    imageBMP.log = image64.log;
                    subjectImage.OnNext(imageBMP);
                }
            }
            
        }

   

        public void ClearPlanCacheImages()
        {
            findImage.ClearPlanCacheImages();
        }
  
        #endregion
    }
}
