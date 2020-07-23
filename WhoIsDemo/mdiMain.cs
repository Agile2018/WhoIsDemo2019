using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WhoIsDemo.form;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.repository;
using WhoIsDemo.view.tool;


namespace WhoIsDemo
{
    public partial class mdiMain : Form
    {
        #region constants
        public const string NAME = "mdiMain";
        #endregion
        #region variables
        private ManagerControlView managerControlView = new ManagerControlView();
        DiskPresenter diskPresenter = new DiskPresenter();
        private RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
        private Random random = new Random();
        IDisposable subscriptionHearInvalid;
        #endregion

        public mdiMain()
        {
            DefineCurrentUICulture();
            InitializeComponent();
            
        }

        private void DefineCurrentUICulture()
        {
            if (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag != "en-US")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }

            ManagerResource.Instance.SetResourceManager();
        }

        private void SubscriptionReactive()
        {

            subscriptionHearInvalid = HearInvalidPresenter.Instance.subjectError.Subscribe(
                result => LaunchMessage(result),
                () => Console.WriteLine(ManagerResource.Instance.resourceManager
                    .GetString("complete")));

        }

        private void LaunchMessage(string result)
        {

            this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(result, 0, this.statusStrip)));
        }

        private void mdiMain_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Top = 0;
            this.Left = (int)((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.Black;
            managerControlView.CreateStatusBar(this, statusStrip);
            
            SubscriptionReactive();
            diskPresenter.CreateDirectoryWork(0);
            VerifyFileConfiguration();
            
        }        

        public void CloseApplication()
        {
            try
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i] != this)
                    {
                        Application.OpenForms[i].Close();
                    }
                }

                System.Threading.Thread closeLibrary = new System
                    .Threading.Thread(new System.Threading
                    .ThreadStart(AipuFace.Instance.Terminate));
                closeLibrary.Start();

                Thread.Sleep(100);
                System.Windows.Forms.Application.Exit();

            }
            catch (System.InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CloseApplication();
            

        }
  

        private void IntAipuFace()
        {
            if (!string.IsNullOrEmpty(Configuration.Instance.ConnectDatabase))
            {
                AipuFace.Instance.ConnectDatabase();
                AipuFace.Instance.InitLibrary();
                
            }
            else
            {
                this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("library_not_load"), 0, this.statusStrip)));

            }


        }

        private void CreateParamsDatabase()
        {
            DatabaseConfig databaseConfig = new DatabaseConfig();
            databaseConfig.configuration = "database_configuration";
            ParamsDatabase paramsDatabase = new ParamsDatabase();
            paramsDatabase.connect = "mongodb://localhost:27017/?minPoolSize=3&maxPoolSize=3";
            paramsDatabase.name = "dbass";
            databaseConfig.Params = paramsDatabase;
            diskPresenter.SaveDatabaseConfiguration(0, databaseConfig);
            Configuration.Instance.ConnectDatabase = databaseConfig.Params.connect;
            Configuration.Instance.NameDatabase = databaseConfig.Params.name;
            InitDatabase();
        }

        private void CreateParamsDetect()
        {
            Detect detect = new Detect();
            detect.configuration = "detect_configuration";
            ParamsDetect paramsDetect = new ParamsDetect();
            paramsDetect.accuracy = 600;
            paramsDetect.maxeye = 250 ;
            paramsDetect.maxfaces = 1;
            paramsDetect.mineye = 20;
            paramsDetect.modedetect = 1;
            paramsDetect.extractionmode = 0;
            paramsDetect.qualitymodel = 60;
            detect.Params = paramsDetect;
            diskPresenter.SaveDetectConfiguration(0, detect);
        }

        private void CreateParamsIdentify()
        {
            Identify identify = new Identify();
            identify.configuration = "identify_configuration";
            ParamsIdentify paramsIdentify = new ParamsIdentify();
            paramsIdentify.A_MinEyeDist = 20;
            paramsIdentify.A_MaxEyeDist = 250;
            paramsIdentify.A_FaceDetectionForced = 2;
            paramsIdentify.A_IdentificationSpeed = 5;
            paramsIdentify.A_SimilarityThreshold = 40;
            paramsIdentify.A_FaceDetectThreshold = 450;
            paramsIdentify.A_BestMatchedCandidates = 1;
            paramsIdentify.is_register = 1;
            identify.Params = paramsIdentify;
            diskPresenter.SaveIdentifyConfiguration(0, identify);
            
        }

        private void CreateParamsTracking()
        {
            Tracking tracking = new Tracking();
            tracking.configuration = "tracking_configuration";
            ParamsTracking paramsTracking = new ParamsTracking();
            paramsTracking.refreshInterval = 2000;
            paramsTracking.maxeye = 200;
            paramsTracking.mineye = 20;
            paramsTracking.maxfaces = 5;
            paramsTracking.faceConfidenceThresh = 450;
            paramsTracking.trackingMode = 1;
            paramsTracking.trackSpeed = 2;
            paramsTracking.motionOptimization = 2;
            paramsTracking.deepTrack = 1;
            paramsTracking.qualitymodel = 60;
            tracking.Params = paramsTracking;
            diskPresenter.SaveTrackingConfiguration(0, tracking);
        }

        private void CreateParamsFlow()
        {
            Flow flow = new Flow();
            flow.configuration = "flowvideo_configuration";
            ParamsFlow paramsFlow = new ParamsFlow();
            paramsFlow.deviceVideo = string.Empty;
            paramsFlow.fileVideo = "video5.mp4";
            paramsFlow.ipCamera = string.Empty;
            paramsFlow.sourceFlow = 2;
            paramsFlow.videoScaleMethod = 1;
            flow.Params = paramsFlow;
            diskPresenter.SaveFlowConfiguration(0, flow);
        }

        private void VerifyFileConfiguration()
        {
            if (!diskPresenter.VerifyFileOfConfiguration(0))
            {
                diskPresenter.CreateContentDirectoryWork(0);
                CreateParamsDatabase();
                CreateParamsDetect();
                CreateParamsIdentify();
                CreateParamsTracking();
                CreateParamsFlow();

                registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                        RegistryValueDataReader.NUM_CHANNELS_KEY, Convert.ToString(0));
                Configuration.Instance.NumberChannels = 0;
                diskPresenter.GenerateListChannels();

                this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("configuration_empty"), 0, this.statusStrip)));

            }
            else
            {
                GetDatabaseConfiguration();
                GenerateChannels();
            }
        }

        private void GenerateChannels()
        {            
            if (!string.IsNullOrEmpty(registryValueDataReader
                .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                RegistryValueDataReader.NUM_CHANNELS_KEY)))
            {
                Configuration.Instance.NumberChannels = Convert.ToInt16(registryValueDataReader
                    .getKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                    RegistryValueDataReader.NUM_CHANNELS_KEY));
                diskPresenter.GenerateListChannels();
            }
        }

        private void mdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseApplication();


        }
                
        private void GetDatabaseConfiguration()
        {
            DatabaseConfig databaseConfig = diskPresenter.ReadDatabaseConfiguration(0);
            if (!string.IsNullOrEmpty(databaseConfig.Params.connect))
            {
                Configuration.Instance.ConnectDatabase = databaseConfig.Params.connect;
                Configuration.Instance.NameDatabase = databaseConfig.Params.name;
                InitDatabase();


            }
        }

        private void InitDatabase()
        {
            Database.Instance.Connection = Configuration.Instance.ConnectDatabase;
            Database.Instance.NameDatabase = Configuration.Instance.NameDatabase;
            Database.Instance.Connect();
            Database.Instance.GetTables();

        }        
       
        private void enrolamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);
            frmEnroll frmWork = new frmEnroll() { MdiParent = this };
            frmWork.strNameMenu = "enrolamientoToolStripMenuItem";            
            enrolamientoToolStripMenuItem.Enabled = false;            
            //configuraciónToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void controlDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);
            
            frmAccessControl frmWork = new frmAccessControl() { MdiParent = this };
            frmWork.strNameMenu = "controlDeEntradaToolStripMenuItem";
            
            controlDeEntradaToolStripMenuItem.Enabled = false;
            
            //configuraciónToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void mdiMain_Shown(object sender, EventArgs e)
        {
            IntAipuFace();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration frmWork = new frmConfiguration() { MdiParent = this };
            frmWork.strNameMenu = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Enabled = false;
            channelHandlerToolStripMenuItem.Enabled = false;
            controlDeEntradaToolStripMenuItem.Enabled = false;
            enrolamientoToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void channelHandlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagerChannels frmWork = new frmManagerChannels() { MdiParent = this };
            frmWork.strNameMenu = "channelHandlerToolStripMenuItem";
            channelHandlerToolStripMenuItem.Enabled = false;
            configuraciónToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        
    }
}
