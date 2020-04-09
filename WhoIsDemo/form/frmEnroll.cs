﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmEnroll : Form
    {
        #region constants
        private const int queueImage = 9;
        private const int sizeMaxFlowLayout = 30;
               
        const int HWND_TOPMOST = -1;
        const int HWND_BOTTOM = 1;
        #endregion
        #region variables
        private bool isSetImageToSlider = true;       
        public string strNameMenu;        
        private int indexPerson = 0;
        private bool isFinishSlider = false;
        private bool isRunSlider = false;
        private bool isRunNewCard = false;
        private int countFlowLayoutControls = 0;
        private bool isAddNewCard = true;        
        private int countNewPerson = 0;
        private bool isFinishNewCard = false;
        private StatusStrip status;
        private Person personTransition = new Person();
        private List<Person> listPersonSlider = new List<Person>();
        ManagerControlView managerControlView = new ManagerControlView();
        HearUserPresenter hearUserPresenter = new HearUserPresenter();
        FindImagePresenter findImagePresenter = new FindImagePresenter();
        private List<Bitmap> imagesSlider = new List<Bitmap>();
        private List<Bitmap> imagesNewCard = new List<Bitmap>();
        private List<Person> listPersonNewCard = new List<Person>();
        GraffitsPresenter graffitsPresenter = new GraffitsPresenter();
        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;
        
        IDisposable subscriptionGraffits;
        private int linkVideo;

        public int LinkVideo
        {
            get
            {
                return linkVideo;
            }

            set
            {
                linkVideo = value;
                hearUserPresenter.IdVideo = linkVideo;
                graffitsPresenter.LinkVideo = linkVideo;
            }

        }

        
        OpenFileDialog openFileDialog = new OpenFileDialog();
        #endregion
        public frmEnroll()
        {
            InitializeComponent();
            
        }

        private void SetImage(Bitmap image)
        {
            Bitmap imgLeft = null;
            Bitmap imgRight = null;

            try
            {
                //imgLeft = new Bitmap(pic1.Image);
                pic1.Invoke(new Action(() => imgLeft = new Bitmap(pic1.Image)));
                //pic1.Image = imgRight; 
                //pic1.Invoke(new Action(() => pic1.Image = image));
                //pic1.Image = image;
                pic2.Invoke(new Action(() => imgRight = new Bitmap(pic2.Image)));
                pic2.Invoke(new Action(() => pic2.Image = findImagePresenter
                    .AdjustAlpha(new Bitmap(imgLeft), 0.7f)));
                pic3.Invoke(new Action(() => imgLeft = new Bitmap(pic3.Image)));
                pic3.Invoke(new Action(() => pic3.Image = imgRight));
                pic4.Invoke(new Action(() => imgRight = new Bitmap(pic4.Image)));
                pic4.Invoke(new Action(() => pic4.Image = imgLeft));
                pic5.Invoke(new Action(() => imgLeft = new Bitmap(pic5.Image)));
                pic5.Invoke(new Action(() => pic5.Image = imgRight));
                pic6.Invoke(new Action(() => imgRight = new Bitmap(pic6.Image)));
                pic6.Invoke(new Action(() => pic6.Image = imgLeft));
                pic7.Invoke(new Action(() => imgLeft = new Bitmap(pic7.Image)));
                pic7.Invoke(new Action(() => pic7.Image = imgRight));
                pic8.Invoke(new Action(() => imgRight = new Bitmap(pic8.Image)));
                pic8.Invoke(new Action(() => pic8.Image = imgLeft));
                pic9.Invoke(new Action(() => imgLeft = new Bitmap(pic9.Image)));
                pic9.Invoke(new Action(() => pic9.Image = imgRight));
                
            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (System.InvalidOperationException)
            {
                //MessageBox.Show(ex.Message);
                managerControlView.ResetExceptionState(pic1);
                pic1.Invalidate();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                try
                {
                    pic1.Invoke(new Action(() => pic1.Image = image));
                    //pic1.Invoke(new Action(() => pic1.Update()));
                }
                catch (System.InvalidOperationException)
                {
                    
                    managerControlView.ResetExceptionState(pic1);
                    pic1.Invalidate();
                }
            }

        }

        private void frmEnroll_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.PerformAutoScale();
            this.Top = 0;
            this.Left = 0;
            this.Width = 1205;
            this.Height = 894;
                                 
            EnableObservers();                        
            
        }
        


        #region methods
        private void InitListPerson()
        {
            Person person = new Person();
            Params paramsPerson = new Params();
            paramsPerson.Id_face = "-1";
            person.Params = paramsPerson;

            for (int i = 0; i < queueImage; i++)
            {
                listPersonSlider.Add(person);
            }
        }
        private void InitControls()
        {
            RequestAipu.Instance.IsRegister(true);            
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
            this.openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            this.openFileDialog.Multiselect = true;
            this.lblQuantityRecords.Text = SynchronizationPeoplePresenter
                .Instance.GetNumbersPersons().ToString();
              

            if (!string.IsNullOrEmpty(Configuration.Instance.VideoDefault))
            {
                InitCapture();
            }
            else
            {
                this.btnStart.Enabled = false;

                managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("ip_video_empty"),
                    0, this.status);
            }

            SynchronizationPeoplePresenter.Instance.OnListPeople += new SynchronizationPeoplePresenter
                .ListPeopleDelegate(LoadListSyncUp);
        }

        private void LoadListSyncUp(List<People> list)
        {
            Task taskUploadPeople = TaskUploadPeopleOfDatabase(list);
        }
        

        private void EnableObservers()
        {
            if (!hearUserPresenter.EnableObserverUser())
            {
                managerControlView.SetValueTextStatusStrip(
                    ManagerResource.Instance.resourceManager
                    .GetString("load_library"), 0, this.status);

            }
            
        }

        private void SubscriptionReactive()
        {

            subscriptionFindImage = findImagePresenter.subjectImage.Subscribe(
                image => AddImageOfPerson(image),
                () => Console.WriteLine(StringResource.complete));
            subscriptionHearUser = hearUserPresenter.subjectUser.Subscribe(
                person => AddPersonIndentify(person),
                () => Console.WriteLine(StringResource.complete));
            
            subscriptionGraffits = graffitsPresenter.subjectLoad.Subscribe(
                load => FinishLoadFile(load),
                () => Console.WriteLine(StringResource.complete));
        }

        private void FinishLoadFile(bool value)
        {
            if (value)
            {
                graffitsPresenter.IsLoadFile = false;
                this.btnStopLoadFile.Invoke(new Action(() => this.btnStopLoadFile.Enabled = false));
                this.btnLoadFile.Invoke(new Action(() => this.btnLoadFile.Enabled = true));
                //this.btnStart.Invoke(new Action(() => this.btnStart.Enabled = true));
                this.status.Invoke(new Action(() => managerControlView
                .StopProgressStatusStrip(1, this.status)));
                this.lblQuantityRecords.Invoke(new Action(() => this.lblQuantityRecords.Text = SynchronizationPeoplePresenter
                .Instance.GetNumbersPersons().ToString()));
                this.status.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("complete"),
                    0, this.status)));
                this.openFileDialog.FileNames.ToList().Clear();
                int countLowScore = RequestAipu.Instance.GetCountLowScore();
               int countRepeatUser = RequestAipu.Instance.GetCountRepeatUser();
               int countNotDetect = RequestAipu.Instance.GetCountNotDetect();
                this.lblLowScore.Invoke(new Action(() => this.lblLowScore.Text =
                ManagerResource.Instance.resourceManager
                    .GetString("low_score") + countLowScore.ToString()));

                this.lblRepeated.Invoke(new Action(() => this.lblRepeated.Text =
                ManagerResource.Instance.resourceManager
                    .GetString("repetead_user") + countRepeatUser.ToString()));

                this.lblNotDetect.Invoke(new Action(() => this.lblNotDetect.Text =
                "ND: " + countNotDetect.ToString()));

                this.lblLowScore.Invoke(new Action(() => this.lblLowScore.Visible = true));

                this.lblRepeated.Invoke(new Action(() => this.lblRepeated.Visible = true));

                this.lblNotDetect.Invoke(new Action(() => this.lblNotDetect.Visible = true));
                
            }
        }

        //private async Task TaskAddPersonTemp(Bitmap image)
        //{
        //    await Task.Run(() =>
        //    {
        //        AddPersonTemp(image);

        //    });
        //}
       
        private void AddPersonTemp(Bitmap image)
        {

            SetPersonInList();
            this.imagesSlider.Add(image);
            //if (isSetImageToSlider)
            //{
            //    isSetImageToSlider = false;
            //    this.Invoke(new Action(() => this.SetImage(image)));
            //}

        }

        private async Task TaskSetImageToSlider()
        {
            await Task.Run(() =>
            {
                SetImageToSlider();

            });
        }

        private void RunSetImageToSlider()
        {
            if (!isRunSlider)
            {
                isRunSlider = true;
                InitSetImageToSlider();
                Task tpt = this.TaskSetImageToSlider();
            }
            
        }

        private void InitSetImageToSlider()
        {
            this.imagesSlider.Clear();
            this.isFinishSlider = false;
            this.isSetImageToSlider = true;
        }

        private void SetImageToSlider()
        {
            while (!isFinishSlider)
            {
                if (imagesSlider.Count > 0 && isSetImageToSlider)
                {
                    try
                    {
                        isSetImageToSlider = false;
                        if (imagesSlider[0] != null)
                        {
                            Bitmap img = new Bitmap(imagesSlider[0]);
                            //this.Invoke(new Action(() => this.SetImage(img)));
                            SetImage(img);
                            Task.Delay(10).Wait();
                            imagesSlider.RemoveAt(0);
                        }
                        
                    }
                    catch (System.InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    catch(System.NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        isSetImageToSlider = true;
                    }
                }
            }
        }

        private void RunNewCardToFlowLayout()
        {
            if (!isRunNewCard)
            {
                isRunNewCard = true;
                InitSetNewCardToFlowLayout();
                Task tnc = this.TaskNewCardToFlowLayout();
            }

        }

        private void InitSetNewCardToFlowLayout()
        {
            this.imagesNewCard.Clear();
            this.isFinishNewCard = false;
            this.isAddNewCard = true;
        }

        private void SetNewCardToFlowLayout()
        {
            while (!isFinishNewCard)
            {
                if (imagesNewCard.Count > 0 && isAddNewCard)
                {
                    isAddNewCard = false;
                    Bitmap img = this.imagesNewCard[0];
                    Person personNewCard = this.listPersonNewCard[0];
                    this.imagesNewCard.RemoveAt(0);
                    this.listPersonNewCard.RemoveAt(0);
                    AddPersonToCard(img, personNewCard);
                    isAddNewCard = true;
                }
            }
        }

        private async Task TaskNewCardToFlowLayout()
        {
            await Task.Run(() =>
            {
                SetNewCardToFlowLayout();

            });
        }

        //private async Task TaskAddPersonToCard(Bitmap image)
        //{
        //    await Task.Run(() =>
        //    {
        //        AddPersonToCard(image);

        //    });
        //}

        private void AddPersonToCard(Bitmap image, Person personNewCard)
        {
            countNewPerson++;
            this.AddNewCardPerson(image, personNewCard);
            this.lblCountNewPersons.Invoke(new Action(() =>
            this.lblCountNewPersons.Text = countNewPerson.ToString()));
        }


        private void ThreadAddImageOfPerson(Bitmap image)
        {
            if (!SearchPersonList(Convert.ToInt32(personTransition.Params.Id_face),
                    this.listPersonSlider))
            {
                //SetPersonInList();

                //this.Invoke(new Action(() => this.SetImage(image)));

                //Task tpt = this.TaskAddPersonTemp(image);
                AddPersonTemp(image);
            }

            if (personTransition.Params.Register == "1")
            {
                //countNewPerson++;                
                //this.AddNewCardPerson(image);
                //this.lblCountNewPersons.Invoke(new Action(() =>
                //this.lblCountNewPersons.Text = countNewPerson.ToString()));
                //Task tpc = this.TaskAddPersonToCard(image);
                this.imagesNewCard.Add(image);
            }
        }

        private void AddImageOfPerson(Bitmap image)
        {
            //Task t = this.TaskAddImageOfPerson(image);
            ThreadAddImageOfPerson(image);
        }
        //private async Task TaskAddImageOfPerson(Bitmap image)
        //{
        //    await Task.Run(() =>
        //    {
        //        ThreadAddImageOfPerson(image);

        //    });
        //}
        private bool SearchPersonList(int id, List<Person> people)
        {
            Person personSearch = people
                .FirstOrDefault(item => item.Params.Id_face == id.ToString());
            if (personSearch != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SetPersonInList()
        {            
            listPersonSlider[indexPerson] = personTransition;
            indexPerson += 1;
            if (indexPerson == queueImage)
            {
                indexPerson = 0;
            }
        }
        private void AddNewCardPerson(Bitmap image, Person personNewCard)
        {
            try
            {
                if (this.countFlowLayoutControls >= sizeMaxFlowLayout)
                {
                    this.countFlowLayoutControls = 0;
                    this.flowLayoutPanel1.Invoke(new Action(() =>
                    this.flowLayoutPanel1.Controls.Clear()));
                    findImagePresenter.ClearPlanCacheImages();
                    Task.Delay(20);
                }
                CardPerson cardPerson = new CardPerson();
                cardPerson.IdFace = personNewCard.Params.Id_face;
                cardPerson.Id = personNewCard.Params.Identification;
                cardPerson.FirstName = personNewCard.Params.Name;
                cardPerson.LastName = personNewCard.Params.Lastname;
                if (image != null)
                {
                    Bitmap imgResize = findImagePresenter.ResizeBitmap(image);
                    cardPerson.Photo = imgResize;
                }
                this.flowLayoutPanel1.Invoke(new Action(() =>
                this.flowLayoutPanel1.Controls.Add(cardPerson)));
                this.flowLayoutPanel1.Invoke(new Action(() =>
                this.flowLayoutPanel1.Refresh()));
                this.countFlowLayoutControls++;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            //finally
            //{
            //    isAddNewCard = true;
            //}
         
            
        }

        private async Task TaskUploadPeopleOfDatabase(List<People> list)
        {
            await Task.Run(() =>
            {
                UploadPeopleOfDatabase(list);

            });
        }

        private void UploadPeopleOfDatabase(List<People> list)
        {
            try
            {
                this.flpDatabase.Invoke(new Action(() =>
                    this.flpDatabase.Controls.Clear()));                
                findImagePresenter.ClearPlanCacheImages();
                foreach (People people in list)
                {
                    AddCardSimple(people);
                }
            }
            catch (System.InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
                   
        }

        private void AddCardSimple(People people)
        {
            try
            {
                CardSimple cardSimple = new CardSimple();
                cardSimple.IdFace = people.Id_face;
                cardSimple.NamePerson = people.Name + " " + people.Lastname;
                Bitmap img = findImagePresenter.Base64StringToBitmap(people.Image);
                if (img != null)
                {
                    Bitmap imgResize = findImagePresenter.ResizeBitmap(img);
                    cardSimple.Photo = imgResize;
                }
                this.flpDatabase.Invoke(new Action(() =>
                this.flpDatabase.Controls.Add(cardSimple)));
            }
            catch (System.InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
                        
        }
       
        private void AddPersonIndentify(Person person)
        {
            personTransition = person;
            if (personTransition.Params.Register == "1")
            {
                this.listPersonNewCard.Add(person);
            }
            
            findImagePresenter.GetImage64ByUser(Convert
                .ToInt16(person.Params.Id_face));

        }                    

        private void InitCapture()
        {
            int totalFrame = 0;
            double fps;
            VideoCapture captureInit = new VideoCapture(Configuration.Instance.VideoDefault);
            if (captureInit.IsOpened)
            {
                Mat frame = new Mat();
                captureInit.Read(frame);
                
                fps = captureInit.GetCaptureProperty(CapProp.Fps);
                graffitsPresenter.SetSequenceFps(Convert.ToInt32(fps));
                graffitsPresenter.SetWidthFrame(Configuration.Instance.ResolutionWidthDefault);
                graffitsPresenter.SetHeightFrame(Configuration.Instance.ResolutionHeightDefault);
                graffitsPresenter.SetClient(LinkVideo);
                graffitsPresenter.SetMinEyeDistance(Configuration.Instance.MinEyeTrack);
                graffitsPresenter.SetMaxEyeDistance(Configuration.Instance.MaxEyeTrack);
                graffitsPresenter.SetFaceConfidenceThresh(Configuration.Instance.ConfidenceTrack);
                graffitsPresenter.SetRefreshInterval(Configuration.Instance.RefreshIntervalTrack);
                graffitsPresenter.SetDeepTrack(Configuration.Instance.DeepTrack);
                graffitsPresenter.SetTrackingMode(Configuration.Instance.TrackMode);
                graffitsPresenter.SetTrackSpeed(Configuration.Instance.TrackSpeed);
                graffitsPresenter.SetMotionOptimization(Configuration.Instance.TrackMotion);
                switch (Configuration.Instance.VideoTypeDefault)
                {
                    case Configuration.VIDEO_TYPE_IP:
                        graffitsPresenter.SetFramesTotal(totalFrame);
                        graffitsPresenter.SetIpCamera(Configuration.Instance.VideoDefault);
                        break;
                    case Configuration.VIDEO_TYPE_FILE:
                        totalFrame = (int)Math.Floor(captureInit.GetCaptureProperty(CapProp.FrameCount));
                        graffitsPresenter.SetFramesTotal(totalFrame);
                        graffitsPresenter.SetFileVideo(Configuration.Instance.VideoDefault);
                        break;
                    case Configuration.VIDEO_TYPE_CAMERA:
                        graffitsPresenter.SetDeviceVideo(Configuration.Instance.VideoDefault);
                        break;
                    
                }

                string nameWindow = "Enroll_" + LinkVideo.ToString();
                graffitsPresenter.SetNameWindow(nameWindow);               
                captureInit.Stop();
                captureInit.Dispose();
            }
            else
            {
                this.btnStart.Enabled = false;

                managerControlView
                    .SetValueTextStatusStrip(StringResource.ip_video_empty,
                    0, this.status);
            }

        }      
        
        #endregion

        private void BringToFrontImageViewer(int position)
        {
            //SetWindowPos(handle, position, 0, 0, 0, 0, wFlags); 
            graffitsPresenter.ShowWindow(position);
        }

        private void frmEnroll_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //VerifyIfVideoRun();
                if (graffitsPresenter.IsLoadFile)
                {
                    graffitsPresenter.IsLoadFile = false;
                    graffitsPresenter.CancelLoad = true;
                    Task.Delay(300).Wait();
                }
                isFinishSlider = true;
                isFinishNewCard = true;
                if (subscriptionHearUser != null) subscriptionHearUser.Dispose();
                if (subscriptionFindImage != null) subscriptionFindImage.Dispose();                
                if (subscriptionGraffits != null) subscriptionGraffits.Dispose();
                System.Threading.Thread closeTracking = new System
                    .Threading.Thread(new System.Threading
               .ThreadStart(graffitsPresenter.TerminateTracking));
                closeTracking.Start();

               // System.Threading.Thread reloadAPI = new System
               //     .Threading.Thread(new System.Threading
               //.ThreadStart(graffitsPresenter.ReloadAipu));
               // reloadAPI.Start();

                this.pic1.Dispose();
                this.pic2.Dispose();
                this.pic3.Dispose();
                this.pic4.Dispose();
                this.pic5.Dispose();
                this.pic6.Dispose();
                this.pic7.Dispose();
                this.pic8.Dispose();
                this.pic9.Dispose();
                this.flowLayoutPanel1.Dispose();
                this.listPersonSlider.Clear();                
                this.imagesSlider.Clear();
                this.imagesNewCard.Clear();
                this.listPersonNewCard.Clear();
                managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
                managerControlView.EnabledOptionMenu("controlDeEntradaToolStripMenuItem", mdiMain.NAME);
                managerControlView.EnabledOptionMenu("configuraciónToolStripMenuItem", mdiMain.NAME);
            }
            catch (System.AccessViolationException ex)
            {

                Console.WriteLine(ex.Message);
            }
           
            
                
        }        

        private void pic1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Rectangle rect = new Rectangle(0, 0, pic1.Width, pic1.Height);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(rect);
                Region reg = new Region(gp);
                pic1.Region = reg;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
            catch (System.InvalidOperationException)
            {
                
                managerControlView.ResetExceptionState((sender as PictureBox));
                (sender as PictureBox).Invalidate();
            }


        }

        private void pic2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic2.Width, pic2.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic2.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic3_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic3.Width, pic3.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic3.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic4_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic4.Width, pic4.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic4.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic5_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic5.Width, pic5.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic5.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic6_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic6.Width, pic6.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic6.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic7_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic7.Width, pic7.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic7.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic8_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic8.Width, pic8.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic8.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void pic9_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, pic9.Width, pic9.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(rect);
            Region reg = new Region(gp);
            pic9.Region = reg;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void frmEnroll_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void frmEnroll_Shown(object sender, EventArgs e)
        {
            SubscriptionReactive();
            InitControls();
            InitListPerson();
            Task taskLoadPeoples = SynchronizationPeoplePresenter.Instance.TaskLoadPeoples();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnRestart.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnLoadFile.Enabled = true;
            graffitsPresenter.StatePaused();
            
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            
            graffitsPresenter.StatePlay();
            this.btnStop.Enabled = true;
            this.btnRestart.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            //Task.Run(() =>
            //{
            //    CaptureFrame();
                
            //});

            this.btnLoadFile.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnFrontVideo.Enabled = true;
            this.btnBackVideo.Enabled = true;
            this.lblFiles.Visible = false;
            this.lblLowScore.Visible = false;
            this.lblRepeated.Visible = false;
            this.lblNotDetect.Visible = false;
            RunSetImageToSlider();
            RunNewCardToFlowLayout();
            Thread myThread = new Thread(new ThreadStart(RunFlowVideo));            
            myThread.Priority = ThreadPriority.AboveNormal;            
            myThread.Start();
            //graffitsPresenter.CaptureFlow(Configuration.Instance.VideoTypeDefault);
            
        }

        private void RunFlowVideo()
        {
            graffitsPresenter.CaptureFlow(Configuration.Instance.VideoTypeDefault);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnFrontVideo_Click(object sender, EventArgs e)
        {
            //this.viewer.Invoke(new Action(() => BringToFrontImageViewer(this.viewer.Handle, 
            //    HWND_TOPMOST)));
            BringToFrontImageViewer(HWND_TOPMOST);
        }

        private void btnBackVideo_Click(object sender, EventArgs e)
        {
            //this.viewer.Invoke(new Action(() => BringToFrontImageViewer(this.viewer.Handle,
            //    HWND_BOTTOM)));
            BringToFrontImageViewer(HWND_BOTTOM);
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                graffitsPresenter.IsLoadFile = true;
                this.btnLoadFile.Enabled = false;
                this.btnStart.Enabled = false;
                this.btnFrontVideo.Enabled = false;
                this.btnFrontVideo.Enabled = false;
                this.btnStopLoadFile.Enabled = true;
                managerControlView
                    .SetValueTextStatusStrip(StringResource.work,
                    0, this.status);
                this.lblRepeated.Visible = false;
                this.lblLowScore.Visible = false;
                this.lblNotDetect.Visible = false;
                this.lblFiles.Visible = true;
                this.lblFiles.Text = ManagerResource.Instance.resourceManager
                    .GetString("files") + openFileDialog.FileNames.Count().ToString();
                managerControlView.StartProgressStatusStrip(1, this.status);
                RequestAipu.Instance.SetIsFinishLoadFiles(true);                
                RequestAipu.Instance.ResetCountNotDetect();
                RequestAipu.Instance.ResetLowScore();
                RequestAipu.Instance.ResetCountRepeatUser();
                RunSetImageToSlider();
                RunNewCardToFlowLayout();
                Task taskRecognition = graffitsPresenter
                    .TaskImageFileForRecognition(openFileDialog.FileNames);
                
            }
        }

        private void btnStopLoadFile_Click(object sender, EventArgs e)
        {
            graffitsPresenter.CancelLoad = true;
            
        }

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.Refresh();
        }          

        private void flpDatabase_Scroll(object sender, ScrollEventArgs e)
        {
            
            
            flpDatabase.Refresh();

        }

        private void btnDownRecords_Click(object sender, EventArgs e)
        {
            SynchronizationPeoplePresenter.Instance.GetListPeople(true);
        }

        private void btnUploadRecords_Click(object sender, EventArgs e)
        {
            SynchronizationPeoplePresenter.Instance.GetListPeople(false);
        }
    }
}
