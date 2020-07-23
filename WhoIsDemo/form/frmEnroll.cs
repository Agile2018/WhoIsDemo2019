using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
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
        
        ManagerControlView managerControlView = new ManagerControlView();
        HearUserPresenter hearUserPresenter = new HearUserPresenter();
        FindImagePresenter findImagePresenter = new FindImagePresenter();
        
        private List<ImageBMP> imagesNewCard = new List<ImageBMP>();
        private List<Person> listPersonNewCard = new List<Person>();
        FilesRecognitionPresenter filesRecognitionPresenter = new FilesRecognitionPresenter();
        DiskPresenter diskPresenter = new DiskPresenter();
        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;
        
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
            this.Width = 600;
            this.Height = 460;
            InitControls();
            JoinChannels();
                               

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
                    count++;
                }
            }
            string channels = ManagerResource.Instance.resourceManager
                .GetString("channels") + Convert.ToString(count);
            managerControlView
                .SetValueTextStatusStrip(channels, 0, this.status);            
        }

        private bool CheckPauseChannels()
        {
            bool result = true;
            if (hearUserPresenter.IdVideos.Count() == 0)
            {
                return false;
            }
            for (int i = 0; i < hearUserPresenter.IdVideos.Count(); i++)
            {
                int index = hearUserPresenter.IdVideos[i];
                if (Configuration.Instance.Channels[index - 1].flow != 1)
                {
                    result = false;
                }
            }

            return result;
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
                this.btnLoadFile.Invoke(new Action(() => this.btnLoadFile.Enabled = true));                
                this.status.Invoke(new Action(() => managerControlView
                .StopProgressStatusStrip(1, this.status)));
                this.lblQuantityRecords.Invoke(new Action(() => this.lblQuantityRecords.Text = SynchronizationPeoplePresenter
                .Instance.GetNumbersPersons().ToString()));
                this.status.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("complete"),
                    0, this.status)));
                this.openFileDialog.FileNames.ToList().Clear();
                PerformanceRecognition performanceRecognition = diskPresenter
                    .ReadPerformance(hearUserPresenter.IdVideos[0] - 1);
                if (performanceRecognition != null)
                {
                    int countLowScore = performanceRecognition.Params.LowScore;
                    int countRepeatUser = performanceRecognition.Params.RepeatUser;
                    int countNotDetect = performanceRecognition.Params.NotDetect;

                }
                
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
                            Person personNewCard = this.listPersonNewCard[index];
                            AddPersonToCard(img.imageStore, personNewCard);
                            this.listPersonNewCard.RemoveAt(index);
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

        private void AddPersonToCard(Bitmap image, Person personNewCard)
        {            
            this.AddNewCardPerson(image, personNewCard);
            
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
                cardPerson.Channel = personNewCard.Params.Client;
                cardPerson.Score = personNewCard.Params.Score;
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
                if (subscriptionHearUser != null) subscriptionHearUser.Dispose();
                if (subscriptionFindImage != null) subscriptionFindImage.Dispose();                
                if (subscriptionGraffits != null) subscriptionGraffits.Dispose();
               
                this.flowLayoutPanel1.Dispose();
                
                this.imagesNewCard.Clear();
                this.listPersonNewCard.Clear();
                managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
                managerControlView.EnabledOptionMenu("controlDeEntradaToolStripMenuItem", mdiMain.NAME);
                //managerControlView.EnabledOptionMenu("configuraciónToolStripMenuItem", mdiMain.NAME);
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

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            bool next = false;
            string message = string.Empty;
            if (Configuration.Instance.IsShowWindow)
            {
                if (CheckPauseChannels())
                {
                    next = true;
                }
                else
                {
                    message = ManagerResource
                   .Instance.resourceManager.GetString("set_pause_channels");

                }
            }
            else
            {
                if (hearUserPresenter.IdVideos.Count > 0)
                {
                    int pipe = hearUserPresenter.IdVideos[0];
                    AipuFace.Instance.LoadConfigurationPipe(pipe);
                    next = true;
                }
                else
                {
                    message = ManagerResource
                   .Instance.resourceManager.GetString("video_not_found");

                }
            }

            if (next)
            {
                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    managerControlView.DisabledOptionMenu("channelHandlerToolStripMenuItem", mdiMain.NAME);
                    filesRecognitionPresenter.IsLoadFile = true;
                    filesRecognitionPresenter.LinkVideo = hearUserPresenter.IdVideos[0];
                    this.btnLoadFile.Enabled = false;                    
                    this.btnStopLoadFile.Enabled = true;
                    managerControlView
                        .SetValueTextStatusStrip(StringResource.work,
                        0, this.status);
                    
                    managerControlView.StartProgressStatusStrip(1, this.status);
                    AipuFace.Instance.SetChannel(hearUserPresenter.IdVideos[0]);
                    AipuFace.Instance.SetIsFinishLoadFiles(true);
                    AipuFace.Instance.ResetPerformance(hearUserPresenter.IdVideos[0]);                                       
                    Task taskRecognition = filesRecognitionPresenter
                        .TaskImageFileForRecognition(openFileDialog.FileNames);

                }
            }
            else
            {
                managerControlView.SetValueTextStatusStrip(message,
                        0, this.status);
            }
        }

        private void btnStopLoadFile_Click(object sender, EventArgs e)
        {
            filesRecognitionPresenter.CancelLoad = true;
            
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
