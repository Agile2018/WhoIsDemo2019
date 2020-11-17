using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmEnroll : Form
    {
        #region constants
        
        private const int sizeMaxFlowLayout = 30;
                       
        #endregion
        #region variables
               
        public string strNameMenu;        
        
        private bool isRunNewCard = false;
        private int countFlowLayoutControls = 0;
        private bool isAddNewCard = true;                
        private bool isFinishNewCard = false;
        private StatusStrip status;
        private int numberTemplates = 0;
        private ManagerControlView managerControlView = new ManagerControlView();
        private HearUserPresenter hearUserPresenter = new HearUserPresenter();
        private FindImagePresenter findImagePresenter = new FindImagePresenter();
        private HearTemplateImagePresenter hearTemplateImagePresenter = new HearTemplateImagePresenter();
        private List<ImageBMP> imagesNewCard = new List<ImageBMP>();
        private List<Person> listPersonNewCard = new List<Person>();
        private FilesRecognitionPresenter filesRecognitionPresenter = new FilesRecognitionPresenter();
        
        DiskPresenter diskPresenter = new DiskPresenter();
        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;
        IDisposable subscriptionHearTemplate;
        IDisposable subscriptionGraffits;
       
        
        OpenFileDialog openFileDialog = new OpenFileDialog();
        #endregion
        public frmEnroll()
        {
            InitializeComponent();
            
        }        

        private void frmEnroll_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.PerformAutoScale();
            this.Top = 0;
            this.Left = 0;
            this.Width = 789;
            this.Height = 648;
            InitControls();
            JoinChannels();
            SetNoneTaskChannels();
        }
        
        #region methods
        

        private void JoinChannels()
        {
            int count = 0;
            for (int i = 0; i < Configuration.Instance.Channels.Count; i++)
            {
                if (Configuration.Instance.Channels[i].task == 1)
                {
                    hearUserPresenter.IdVideos.Add(i + 1);
                    hearTemplateImagePresenter.IdVideos.Add(i + 1);
                    count++;
                                       
                }
            }
            string channels = ManagerResource.Instance.resourceManager
                .GetString("channels") + Convert.ToString(count);
            managerControlView
                .SetValueTextStatusStrip(channels, 0, this.status);            
        }
      

        private void InitControls()
        {
                     
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
            this.openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            this.openFileDialog.Multiselect = true;
            this.lblQuantityRecords.Text = SynchronizationPeoplePresenter
                .Instance.GetNumbersPersons().ToString();            
            SynchronizationPeoplePresenter.Instance.OnListPeople += new SynchronizationPeoplePresenter
                .ListPeopleDelegate(LoadListSyncUp);
            hearUserPresenter.EnableObserverUser();
        }

        private void LoadListSyncUp(List<People> list)
        {
            Task taskUploadPeople = TaskUploadPeopleOfDatabase(list);
        }               

        private void SubscriptionReactive()
        {

            subscriptionFindImage = findImagePresenter.subjectImage.Subscribe(
                image => AddImageOfPerson(image),
                () => Console.WriteLine(StringResource.complete));
            subscriptionHearUser = hearUserPresenter.subjectUser.Subscribe(
                person => AddPersonIndentify(person),
                () => Console.WriteLine(StringResource.complete));

            subscriptionGraffits = filesRecognitionPresenter.subjectLoad.Subscribe(
                load => FinishLoadFile(load),
                () => Console.WriteLine(StringResource.complete));
            subscriptionHearTemplate = hearTemplateImagePresenter.subjectImage.Subscribe(
                img => AddTemplate(img),
                () => Console.WriteLine(StringResource.complete));
        }

       

        private void AddTemplate(Bitmap img)
        {
            CardTemplate cardTemplate = new CardTemplate();
            if (img != null)
            {
                Bitmap imgResize = Transform.Instance.ResizeBitmap(img);
                cardTemplate.PhotoTemplate = imgResize;
                this.flpTemplates.Invoke(new Action(() =>
                this.flpTemplates.Controls.Add(cardTemplate)));
                this.flpTemplates.Invoke(new Action(() =>
                this.flpTemplates.Refresh()));
            }

        }

        private void AddPersonIndentify(Person person)
        {
            
            if (person.Params.Register == "1")
            {
                
                this.listPersonNewCard.Add(person);
                findImagePresenter.GetImage64ByUser(Convert
                .ToInt16(person.Params.Id_face));
            }            

        }

        private void AddImageOfPerson(ImageBMP imageBMP)
        {
            this.imagesNewCard.Add(imageBMP);
            
        }      

        private void FinishLoadFile(bool value)
        {
            if (value)
            {
                
                filesRecognitionPresenter.IsLoadFile = false;
                this.btnStopLoadFile.Invoke(new Action(() => this.btnStopLoadFile.Enabled = false));
                this.btnFile.Invoke(new Action(() => this.btnFile.Enabled = true));                
                this.status.Invoke(new Action(() => managerControlView
                .StopProgressStatusStrip(1, this.status)));
                this.lblQuantityRecords.Invoke(new Action(() => this.lblQuantityRecords.Text = SynchronizationPeoplePresenter
                .Instance.GetNumbersPersons().ToString()));
                this.status.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("complete"),
                    0, this.status)));
                this.openFileDialog.FileNames.ToList().Clear();               
                
                this.Invoke(new Action(() => managerControlView
                .EnabledOptionMenu("channelHandlerToolStripMenuItem", mdiMain.NAME)));
                
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

                    ImageBMP img = this.imagesNewCard.First();
                    if (img != null)
                    {
                        int index = SearchPersonList(img.id_face, this.listPersonNewCard);
                        if (index != -1)
                        {
                            try
                            {
                                Person personNewCard = this.listPersonNewCard[index];
                                //AddPersonToCard(img.imageStore, personNewCard);
                                AddNewCardPerson(img.imageStore, personNewCard, img.log);
                                this.listPersonNewCard.RemoveAt(index);
                                if (numberTemplates > 0)
                                {                                    
                                    Task setTemplates = TaskGetTemplates(numberTemplates);
                                }
                            }
                            catch (System.ArgumentOutOfRangeException ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                            
                        }
                        
                    }
                               
                    this.imagesNewCard.RemoveAt(0);                                        
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
        
        private int SearchPersonList(int id, List<Person> people)
        {
            int index = -1;
            Person personSearch = people
                .FirstOrDefault(item => item.Params.Id_face == id.ToString());
            
            if (personSearch != null)
            {
                index = people.IndexOf(personSearch);
            }
            return index;
        }

        private async Task TaskGetTemplates(int number)
        {
            await Task.Run(() =>
            {
                hearTemplateImagePresenter.GetTemplateData(number);

            });
        }

        private string BuildTracerResult(string log)
        {
            var dataJson = JsonConvert.DeserializeObject<dynamic>(log);
            string templatesJson = dataJson.Templates;
            
            bool isNumeric = int.TryParse(templatesJson, out numberTemplates);
            
            if (!isNumeric)
            {
                
                numberTemplates = 0;
            }
            string tracer = "Images: " + dataJson.Quantity_Flow + Environment.NewLine;
            tracer += "Size: " + dataJson.Size_Image + Environment.NewLine;
            tracer += "Confidence: " + dataJson.Confidence_Threshold + Environment.NewLine;
            tracer += "Quality: " + dataJson.Template_Quality + Environment.NewLine;
            tracer += "Find: " + dataJson.FindUser + Environment.NewLine;
            tracer += "Match Score: " + dataJson.Match_Score + Environment.NewLine;
            tracer += "Templates: " + dataJson.Templates + Environment.NewLine;
            tracer += "Result: " + dataJson.Result + Environment.NewLine;           
            return tracer;
        }

        private void AddNewCardPerson(Bitmap image, Person personNewCard, string log)
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
                cardPerson.Channel = personNewCard.Params.Client;
                cardPerson.Score = personNewCard.Params.Score;
                cardPerson.Tracer = BuildTracerResult(log);
                if (image != null)
                {
                    Bitmap imgResize = Transform.Instance.ResizeBitmap(image);
                    cardPerson.Photo = imgResize;
                    //picMainImage.Image = imgResize;
                }
                this.flowLayoutPanel1.Invoke(new Action(() =>
                this.flowLayoutPanel1.Controls.Add(cardPerson)));
                this.flowLayoutPanel1.Invoke(new Action(() =>
                this.flowLayoutPanel1.Refresh()));
                this.countFlowLayoutControls++;
                Task t = Task.Factory.StartNew(new 
                    Action(Configuration.Instance.SynchronizeDatabaseFace));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }                    
            
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
                Bitmap img = Transform.Instance.Base64StringToBitmap(people.Image);
                if (img != null)
                {
                    Bitmap imgResize = Transform.Instance.ResizeBitmap(img);
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
                                             
        #endregion        

        private void frmEnroll_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                
                if (filesRecognitionPresenter.IsLoadFile)
                {
                    filesRecognitionPresenter.IsLoadFile = false;
                    filesRecognitionPresenter.CancelLoad = true;
                    Task.Delay(300).Wait();
                }
                
                isFinishNewCard = true;

                int pipeSelect = hearUserPresenter.IdVideos[0];                
                AipuFace.Instance.ResetEnrollVideo(pipeSelect, 0);

                if (subscriptionHearUser != null) subscriptionHearUser.Dispose();
                if (subscriptionFindImage != null) subscriptionFindImage.Dispose();                
                if (subscriptionGraffits != null) subscriptionGraffits.Dispose();
                if (subscriptionHearTemplate != null) subscriptionHearTemplate.Dispose();
                
                this.flowLayoutPanel1.Dispose();
                
                this.imagesNewCard.Clear();
                this.listPersonNewCard.Clear();
                managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
                managerControlView.EnabledOptionMenu("controlDeEntradaToolStripMenuItem", mdiMain.NAME);
                if (Application.OpenForms.Count == 2)
                {
                    managerControlView.EnabledOptionMenu("configuraciónToolStripMenuItem", mdiMain.NAME);
                }
                managerControlView.SetValueTextStatusStrip("", 0, this.status);
            }
            catch (System.AccessViolationException ex)
            {

                Console.WriteLine(ex.Message);
            }
                                       
        }               

        private void frmEnroll_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void frmEnroll_Shown(object sender, EventArgs e)
        {            
            SubscriptionReactive();
            RunNewCardToFlowLayout();                                      
            Task taskLoadPeoples = SynchronizationPeoplePresenter.Instance.TaskLoadPeoples();
            
        }        

        private bool IsPipeEnabled()
        {

            if (hearUserPresenter.IdVideos.Count == 0) return false;

            int pipe = hearUserPresenter.IdVideos[0];
            AipuFace.Instance.SetChannel(pipe);
            if (!AipuFace.Instance.GetIsLoadConfiguration())
            {
                AipuFace.Instance.LoadConfigurationPipe(pipe);
            }
            return true;

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

        private void SetNoneTaskChannels()
        {
            for (int i = 0; i < hearUserPresenter.IdVideos.Count(); i++)
            {
                int index = hearUserPresenter.IdVideos[i];
                AipuFace.Instance.SetTaskIdentify(-1, index);
            }
        }

        private void SetTextColourFrame(int pipe, Single red, Single green, Single blue)
        {
            switch (pipe)
            {
                case 1:
                    AipuFace.Instance.SetColourTextFrameOne(red, green, blue);
                    break;
                case 2:
                    AipuFace.Instance.SetColourTextFrameTwo(red, green, blue);
                    break;
                case 3:
                    AipuFace.Instance.SetColourTextFrameThree(red, green, blue);
                    break;
                case 4:
                    AipuFace.Instance.SetColourTextFrameFour(red, green, blue);
                    break;
                default:
                    break;
            }
        }

        //private void btnImages_Click(object sender, EventArgs e)
        //{
        //    if (IsPipeEnabled())
        //    {
        //        SetNoneTaskChannels();
        //        using (var fldrDlg = new FolderBrowserDialog())
        //        {
        //            this.flpTemplates.Controls.Clear();
        //            //picMainImage.Image = WhoIsDemo.Properties.Resources.account;
        //            if (fldrDlg.ShowDialog() == DialogResult.OK)
        //            {                        
        //                filesRecognitionPresenter.AddCollectionOfImages(fldrDlg.SelectedPath,
        //                    hearUserPresenter.IdVideos[0], 2);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        managerControlView
        //            .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
        //            .GetString("video_not_found"),
        //            0, this.status);
        //    }
        //}

        private bool CheckVideoRunning()
        {
            if (hearUserPresenter.IdVideos.Count == 0) return false;

            int pipe = hearUserPresenter.IdVideos[0];

            if (pipe <= Configuration.Instance.NumberWindowsShow)
            {
                return true;
            }

            return false;
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            
            if (CheckVideoRunning())
            {
                int pipeSelect = 0;
                if (Convert.ToInt32((sender as Button).Tag) == 0)
                {
                    managerControlView.StartProgressStatusStrip(1, this.status);
                    this.flpTemplates.Controls.Clear();
                    //picMainImage.Image = WhoIsDemo.Properties.Resources.account;
                    pipeSelect = hearUserPresenter.IdVideos[0];
                    SetTextColourFrame(pipeSelect, 0.0f, 0.0f, 255.0f);
                    AipuFace.Instance.ResetEnrollVideo(pipeSelect, 0);
                    AipuFace.Instance.SetTaskIdentify(3, pipeSelect);
                    (sender as Button).Tag = pipeSelect;                    
                    (sender as Button).Image = WhoIsDemo.Properties.Resources.video_box_off;
                    

                }
                else
                {
                    managerControlView.StopProgressStatusStrip(1, this.status);
                    pipeSelect = Convert.ToInt32((sender as Button).Tag);
                    AipuFace.Instance.ResetEnrollVideo(pipeSelect, 1);
                    AipuFace.Instance.SetTaskIdentify(-1, pipeSelect);
                    AipuFace.Instance.AddUserEnrollVideo(pipeSelect);
                    SetTextColourFrame(pipeSelect, 0.0f, 0.0f, 0.0f);
                    (sender as Button).Tag = 0;
                    (sender as Button).Image = WhoIsDemo.Properties.Resources.video_box;
                }
                
            }
            else
            {
                managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("pipe_not loaded"),
                    0, this.status);
            }
        }

        //private void btnFile_Click(object sender, EventArgs e)
        //{
        //    SetNoneTaskChannels();
        //    this.flpTemplates.Controls.Clear();
        //    //picMainImage.Image = WhoIsDemo.Properties.Resources.account;

        //    if (IsPipeEnabled())
        //    {
        //        if (this.openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            managerControlView.DisabledOptionMenu("channelHandlerToolStripMenuItem", mdiMain.NAME);
        //            filesRecognitionPresenter.IsLoadFile = true;
        //            filesRecognitionPresenter.LinkVideo = hearUserPresenter.IdVideos[0];
        //            filesRecognitionPresenter.TaskIdentify = 0;
        //            this.btnFile.Enabled = false;
        //            this.btnStopLoadFile.Enabled = true;
        //            managerControlView
        //                .SetValueTextStatusStrip(StringResource.work,
        //                0, this.status);
        //            string folder = openFileDialog.InitialDirectory;
        //            managerControlView.StartProgressStatusStrip(1, this.status);
        //            AipuFace.Instance.SetChannel(hearUserPresenter.IdVideos[0]);
        //            AipuFace.Instance.SetIsFinishLoadFiles(true);
        //            Task taskRecognition = filesRecognitionPresenter
        //                .TaskImageFileForRecognition(openFileDialog.FileNames);

        //        }
        //    }
        //    else
        //    {
        //        managerControlView
        //            .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
        //            .GetString("video_not_found"),
        //            0, this.status);
        //    }
        //}

        private void btnImportVideo_Click(object sender, EventArgs e)
        {
            this.flpTemplates.Controls.Clear();

            if (CheckVideoRunning())
            {
                if (Convert.ToInt32((sender as Button).Tag) == 0)
                {
                    //picMainImage.Image = WhoIsDemo.Properties.Resources.account;
                    managerControlView.StartProgressStatusStrip(1, this.status);
                    (sender as Button).Tag = 1;
                    (sender as Button).Image = WhoIsDemo.Properties.Resources.video_box_off;
                    for (int i = 0; i < hearUserPresenter.IdVideos.Count(); i++)
                    {
                        int index = hearUserPresenter.IdVideos[i];
                        AipuFace.Instance.SetTaskIdentify(0, index);
                    }
                }
                else
                {
                    managerControlView.StopProgressStatusStrip(1, this.status);
                    (sender as Button).Tag = 0;
                    (sender as Button).Image = WhoIsDemo.Properties.Resources.video_account;
                    for (int i = 0; i < hearUserPresenter.IdVideos.Count(); i++)
                    {
                        int index = hearUserPresenter.IdVideos[i];
                        AipuFace.Instance.SetTaskIdentify(-1, index);
                    }
                }
            }
            else
            {
                managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("pipe_not loaded"),
                    0, this.status);
            }

        }

        //private void btnStopLoadFile_Click(object sender, EventArgs e)
        //{
        //    filesRecognitionPresenter.CancelLoad = true;
        //}

        private void btnCamera_MouseHover(object sender, EventArgs e)
        {
            toolTipBtn.SetToolTip(btnCamera, "Enroll video with templates");
        }

        private void btnImportVideo_MouseHover(object sender, EventArgs e)
        {
            toolTipBtn.SetToolTip(btnImportVideo, "Enroll one frame");
        }

        //private void btnImages_MouseHover(object sender, EventArgs e)
        //{
        //    toolTipBtn.SetToolTip(btnImages, "Enroll all folder");
        //}

        //private void btnFile_MouseHover(object sender, EventArgs e)
        //{
        //    toolTipBtn.SetToolTip(btnFile, "Enroll one file");
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStopLoadFile_Click(object sender, EventArgs e)
        {
            filesRecognitionPresenter.CancelLoad = true;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            SetNoneTaskChannels();
            this.flpTemplates.Controls.Clear();
            //picMainImage.Image = WhoIsDemo.Properties.Resources.account;

            if (IsPipeEnabled())
            {
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    managerControlView.DisabledOptionMenu("channelHandlerToolStripMenuItem", mdiMain.NAME);
                    filesRecognitionPresenter.IsLoadFile = true;
                    filesRecognitionPresenter.LinkVideo = hearUserPresenter.IdVideos[0];
                    filesRecognitionPresenter.TaskIdentify = 0;
                    this.btnFile.Enabled = false;
                    this.btnStopLoadFile.Enabled = true;
                    managerControlView
                        .SetValueTextStatusStrip(StringResource.work,
                        0, this.status);
                    string folder = openFileDialog.InitialDirectory;
                    managerControlView.StartProgressStatusStrip(1, this.status);
                    AipuFace.Instance.SetChannel(hearUserPresenter.IdVideos[0]);
                    AipuFace.Instance.SetIsFinishLoadFiles(true);
                    Task taskRecognition = filesRecognitionPresenter
                        .TaskImageFileForRecognition(openFileDialog.FileNames);

                }
            }
            else
            {
                managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("video_not_found"),
                    0, this.status);
            }
        }

        private void btnImages_Click(object sender, EventArgs e)
        {
            if (IsPipeEnabled())
            {
                SetNoneTaskChannels();
                using (var fldrDlg = new FolderBrowserDialog())
                {
                    this.flpTemplates.Controls.Clear();
                    //picMainImage.Image = WhoIsDemo.Properties.Resources.account;
                    if (fldrDlg.ShowDialog() == DialogResult.OK)
                    {
                        filesRecognitionPresenter.AddCollectionOfImages(fldrDlg.SelectedPath,
                            hearUserPresenter.IdVideos[0], 2);
                    }
                }
            }
            else
            {
                managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("video_not_found"),
                    0, this.status);
            }
        }

        private void btnFile_MouseHover(object sender, EventArgs e)
        {
            toolTipBtn.SetToolTip(btnFile, "Enroll one file");
        }

        private void btnImages_MouseHover(object sender, EventArgs e)
        {
            toolTipBtn.SetToolTip(btnImages, "Enroll all folder");
        }
    }
}
