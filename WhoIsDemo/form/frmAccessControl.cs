using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoIsDemo.locatable_resources;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmAccessControl : Form
    {
        #region constants
        
        private const int sizeMaxFlowLayout = 30;
        private const int elapseFrameRepeat = 10;

        #endregion

        #region variables
        
        private bool isAddNewCard = true;
        private bool isFinishNewCard = false;
        private bool isRunNewCard = false;
        public string strNameMenu;
        

        private int countFlowLayoutControls = 0;

        private StatusStrip status;
        
        private List<Person> listPersonRegister = new List<Person>();
        private List<TimePerson> lisTimePerson = new List<TimePerson>();        
        private List<ImageBMP> imagesNewCard = new List<ImageBMP>();
        private List<Person> listPersonNewCard = new List<Person>();
        ManagerControlView managerControlView = new ManagerControlView();
        HearUserPresenter hearUserPresenter = new HearUserPresenter();
        FindImagePresenter findImagePresenter = new FindImagePresenter();

        FilesRecognitionPresenter filesRecognitionPresenter = new FilesRecognitionPresenter();
        IDisposable subscriptionHearUser;
        IDisposable subscriptionFindImage;
        IDisposable subscriptionGraffits;        

        OpenFileDialog openFileDialog = new OpenFileDialog();

        #endregion
        public frmAccessControl()
        {
            InitializeComponent();
        }

        private void frmAccessControl_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.PerformAutoScale();
            this.Top = 0;
            this.Left = 0;
            this.Width = 440;
            this.Height = 540;
            InitControls();
            JoinChannels();
        }

        private void JoinChannels()
        {
            int count = 0;
            for (int i = 0; i < Configuration.Instance.Channels.Count; i++)
            {
                if (Configuration.Instance.Channels[i].task == 0)
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
            this.openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            this.openFileDialog.Multiselect = true;
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
            hearUserPresenter.EnableObserverUser();
            
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

        private void FinishLoadFile(bool value)
        {
            if (value)
            {
                filesRecognitionPresenter.IsLoadFile = false;
                this.btnStopLoadFile.Invoke(new Action(() => this.btnStopLoadFile.Enabled = false));
                this.btnLoadFile.Invoke(new Action(() => this.btnLoadFile.Enabled = true));                
                this.status.Invoke(new Action(() => managerControlView
                .StopProgressStatusStrip(1, this.status)));
                this.openFileDialog.FileNames.ToList().Clear();
                this.status.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("complete"),
                    0, this.status)));
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

        private async Task TaskNewCardToFlowLayout()
        {
            await Task.Run(() =>
            {
                SetNewCardToFlowLayout();

            });
        }

        private void SetNewCardToFlowLayout()
        {
            while (!isFinishNewCard)
            {
                if (imagesNewCard.Count > 0 && isAddNewCard)
                {
                    try
                    {
                        isAddNewCard = false;
                                              
                        ImageBMP img = this.imagesNewCard.First();
                        if (img != null)
                        {
                            int index = SearchPersonList(img.id_face, this.listPersonNewCard);
                            if (index != -1)
                            {
                                Person personNewCard = this.listPersonNewCard[index];
                                AddPersonToCard(img, personNewCard);
                                this.listPersonNewCard.RemoveAt(index);
                            }
                        }

                        this.imagesNewCard.RemoveAt(0);
                        isAddNewCard = true;
                    }
                    catch (System.InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        isAddNewCard = true;
                    }

                }
            }
        }

        private void AddPersonToCard(ImageBMP img, Person personNewCard)
        {
            if (this.countFlowLayoutControls >= sizeMaxFlowLayout)
            {
                this.listPersonRegister.Clear();
                this.lisTimePerson.Clear();
            }

            if (SearchPersonList(Convert.ToInt32(personNewCard.Params.Id_face),
                    this.listPersonRegister) == -1)
            {
                TimePerson timePerson = new TimePerson();
                timePerson.id = Convert.ToInt32(personNewCard.Params.Id_face);
                timePerson.income = DateTime.Now;
                this.lisTimePerson.Add(timePerson);
                this.listPersonRegister.Add(personNewCard);
                this.AddNewCardPerson(img, personNewCard);
            }
            else
            {
                if (VerifyTimePerson(Convert.ToInt32(personNewCard.Params.Id_face)))
                {
                    this.AddNewCardPerson(img, personNewCard);
                }
            }
        }

        private void AddImageOfPerson(ImageBMP imageBMP)
        {
            
            this.imagesNewCard.Add(imageBMP);
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

        private bool VerifyTimePerson(int id)
        {
            int elapse = 0;
            TimePerson timePerson = this.lisTimePerson
                .FirstOrDefault(item => item.id == id);
            int index = this.lisTimePerson.IndexOf(timePerson);

            if (timePerson != null)
            {
                DateTime now = DateTime.Now;
                TimeSpan ts = now - timePerson.income;
                Console.WriteLine("TIME LAPSE PERSON: " + ts.Seconds.ToString());

                if (Configuration.Instance.TimeRefreshEntryControl == 0)
                {
                    elapse = elapseFrameRepeat;
                }
                else
                {
                    elapse = Configuration.Instance.TimeRefreshEntryControl * 60;
                }

                if (ts.Seconds >= elapse)
                {
                    this.lisTimePerson[index].income = now;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        private void AddNewCardPerson(ImageBMP imageBMP, Person personNewCard)
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

                CardTwoImage cardPerson = new CardTwoImage();
                cardPerson.IdFace = personNewCard.Params.Id_face;
                cardPerson.Id = personNewCard.Params.Identification;
                cardPerson.FirstName = personNewCard.Params.Name;
                cardPerson.LastName = personNewCard.Params.Lastname;
                cardPerson.DateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                Bitmap imgGallery = findImagePresenter.ResizeBitmap(imageBMP.imageStore);
                cardPerson.Photo = imgGallery;
                Bitmap imgCamera = findImagePresenter.ResizeBitmap(imageBMP.imageNew);
                cardPerson.PhotoCamera = imgCamera;
                cardPerson.Channel = personNewCard.Params.Client;

                this.flowLayoutPanel1.Invoke(new Action(() =>
                this.flowLayoutPanel1.Controls.Add(cardPerson)));
                this.flowLayoutPanel1.Invoke(new Action(() =>
                this.flowLayoutPanel1.Refresh()));
                this.countFlowLayoutControls++;


            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (System.InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }            


        }

        private void AddPersonIndentify(Person person)
        {
            
            this.listPersonNewCard.Add(person);
            
            findImagePresenter.GetListImage64ByUser(Convert
                .ToInt16(person.Params.Id_face));

        }

        private void frmAccessControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {                
                isFinishNewCard = true;
                if (subscriptionHearUser != null) subscriptionHearUser.Dispose();
                if (subscriptionFindImage != null) subscriptionFindImage.Dispose();
                if (subscriptionGraffits != null) subscriptionGraffits.Dispose();
                
                this.flowLayoutPanel1.Dispose();
                
                this.listPersonRegister.Clear();
                this.lisTimePerson.Clear();
                
                this.imagesNewCard.Clear();
                this.listPersonNewCard.Clear();
                managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
                managerControlView.EnabledOptionMenu("enrolamientoToolStripMenuItem", mdiMain.NAME);
                managerControlView.EnabledOptionMenu("configuraciónToolStripMenuItem", mdiMain.NAME);
            }
            catch (System.AccessViolationException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void frmAccessControl_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void frmAccessControl_Shown(object sender, EventArgs e)
        {
            SubscriptionReactive();
            RunNewCardToFlowLayout();
        }        

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (Configuration.Instance.IsShowWindow && CheckPauseChannels())
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
                managerControlView.SetValueTextStatusStrip(ManagerResource
                    .Instance.resourceManager.GetString("window_disabled"),
                        0, this.status);
            }
        }

        private void btnStopLoadFile_Click(object sender, EventArgs e)
        {
            filesRecognitionPresenter.CancelLoad = true;
        }
    }
}
