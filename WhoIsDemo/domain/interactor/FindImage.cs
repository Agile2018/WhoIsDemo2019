using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class FindImage
    {
        #region variables
        //private string connection;
        //private string nameDatabase;
        //private string imageBase64;
        private Image64 imageReturn;
        //private Database database = new Database();
        //private List<String> listImage = new List<string>();
        public delegate void ImageDelegate(Image64 imageReturn);
        public event ImageDelegate OnImage;
        //public delegate void ListImageDelegate(List<String> list);
        //public event ListImageDelegate OnListImage;
        #endregion

        #region methods
        public FindImage() { }

        //public void Connect()
        //{
        //    database.Connect();
        //    database.GetImages();
        //}

        public Image64 ImageReturn
        {
            get
            {
                return imageReturn;
            }
            set
            {
                imageReturn = value;
                OnImage(imageReturn);
            }
        }

        public void GetImageByIdFace(int idFace)
        {

            //Image imageDb = database.GetImageByUser(idFace);
            Image imageDb = Database.Instance.GetImageByUser(idFace);
            if (imageDb != null)
            {
                Image64 image64 = new Image64();
                image64.id_face = idFace;
                image64.data_64 = imageDb.data_64;
                ImageReturn = image64;
            }
                        
        }

        public void ClearPlanCacheImages()
        {
            //database.ClearPlanCacheImages();
            Database.Instance.ClearPlanCacheImages();
        }

        public void GetListImageByIdFace(int idFace)
        {

            //Image imageDb = database.GetImageByUser(idFace);
            Image imageDb = Database.Instance.GetImageByUser(idFace);
            if (imageDb != null)
            {
                Image64 image64 = new Image64();
                image64.id_face = idFace;
                image64.data_64 = imageDb.data_64;
                image64.data_64_aux = imageDb.data_64_aux;
                ImageReturn = image64;
                //List<String> list = new List<string>();
                //list.Add(imageDb.data_64);
                //list.Add(imageDb.data_64_aux);
                //this.ListImage = list;
            }

        }

        //public string Connection {
        //    get
        //    {
        //        return connection;
        //    }

        //    set
        //    {
        //        connection = value;
        //        //database.Connection = connection;
        //    }
            
        //}

        //public string NameDatabase {
        //    get
        //    {
        //        return nameDatabase;
        //    }

        //    set
        //    {
        //        nameDatabase = value;
        //        //database.NameDatabase = nameDatabase;
        //    }
            
        //}

        //public string ImageBase64 {
        //    get
        //    {
        //        return imageBase64;
        //    }

        //    set
        //    {
        //        imageBase64 = value;
        //        OnImage(imageBase64);
        //    }
           
        //}

        //public List<string> ListImage {
        //    get
        //    {
        //        return listImage;
        //    }

        //    set
        //    {
        //        listImage = value;
        //        OnListImage(listImage);
        //    }
            
        //}

        


        #endregion


    }
}
