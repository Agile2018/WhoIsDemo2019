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
        private const int number_channels = 4;
        #endregion
        #region variables
        private bool flagCloseApplication = false;
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
            //this.Height = Screen.PrimaryScreen.Bounds.Height;
            //this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = 750;
            this.Width = 850;
            this.Top = 0;
            this.Left = (int)((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.Black;
            managerControlView.CreateStatusBar(this, statusStrip);
            
            SubscriptionReactive();
            diskPresenter.CreateDirectoryWork();
            VerifyFileConfiguration();
            
        }        

        public void CloseApplication()
        {
            try
            {
                flagCloseApplication = true;
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
            diskPresenter.SaveDatabaseConfiguration(databaseConfig);
            Configuration.Instance.ConnectDatabase = databaseConfig.Params.connect;
            Configuration.Instance.NameDatabase = databaseConfig.Params.name;
            InitDatabase();
        }


        private void CreateParamsGlobal()
        {
            ConfigurationGlobalLib configurationGlobalLib = new ConfigurationGlobalLib();
            configurationGlobalLib.configurationGlobal = "Global processing";
            ParamsGlobal paramsGlobal = new ParamsGlobal();
            paramsGlobal.GLOBAL_MIN_VALID_IMAGE_SIZE = 200;
            paramsGlobal.GLOBAL_GPU_DEVICE_ID = "0";
            paramsGlobal.GLOBAL_GPU_ENABLED = "true";
            paramsGlobal.GLOBAL_THREAD_MANAGEMENT_MODE = 1;
            paramsGlobal.GLOBAL_THREAD_NUM = "4";
            paramsGlobal.GLOBAL_CFG_LOG_LEVEL = 0;
            paramsGlobal.AFACE_PARAMETER_GPU_ENABLED = 1;
            configurationGlobalLib.paramsGlobal = paramsGlobal;
            diskPresenter.SaveGlobalConfiguration(configurationGlobalLib);
        }

        private void VerifyFileConfiguration()
        {
            if (!diskPresenter.VerifyFileOfConfiguration(0))
            {
                //diskPresenter.CreateContentDirectoryWork(0);

                ConfigurationPipeline configurationPipeline = new ConfigurationPipeline();               
                configurationPipeline.configurationFaceProcessing = "Face processing";
                ParamsFaceProcessing paramsFaceProcessing = new ParamsFaceProcessing();
                paramsFaceProcessing.IFACE_GetFaceCropImage = 1;
                paramsFaceProcessing.FACEDET_CONFIDENCE_THRESHOLD = 200;
                paramsFaceProcessing.FACEDET_SPEED_ACCURACY_MODE = 0;
                paramsFaceProcessing.FACETMPLEXT_SPEED_ACCURACY_MODE = 0;
                paramsFaceProcessing.TRACK_MAX_FACE_SIZE = 200.0f;
                paramsFaceProcessing.TRACK_MIN_FACE_SIZE = 25.0f;
                paramsFaceProcessing.QUALITY_MODEL = 40;
                paramsFaceProcessing.FACE_MAX_DETECT = 1;
                configurationPipeline.paramsFaceProcessing = paramsFaceProcessing;
                configurationPipeline.configurationTrackingProcessing = "Tracking processing";
                ParamsTrackingProcessing paramsTrackingProcessing = new ParamsTrackingProcessing();
                paramsTrackingProcessing.TRACK_DEEP_TRACK = "true";
                paramsTrackingProcessing.TRACK_FACE_DISCOVERY_FREQUENCE_MS = 2000;
                paramsTrackingProcessing.COUNT_REDETECT_TIME_DELTA = 10000;
                paramsTrackingProcessing.TRACK_MOTION_OPTIMIZATION = 2;
                paramsTrackingProcessing.TRACK_SPEED_ACCURACY_MODE = 1;
                paramsTrackingProcessing.TRACK_TRACKING_MODE = 2;
                configurationPipeline.paramsTrackingProcessing = paramsTrackingProcessing;
                configurationPipeline.configurationEnrollmentProcessing = "Enrollment processing";
                ParamsEnrollmentProcessing paramsEnrollmentProcessing = new ParamsEnrollmentProcessing();
                paramsEnrollmentProcessing.CFG_BEST_CANDIDATES_COUNT = 1;
                paramsEnrollmentProcessing.CFG_SIMILARITY_THRESHOLD = 45;
                paramsEnrollmentProcessing.CFG_IDENTIFICATION_SPEED = 0;
                paramsEnrollmentProcessing.CFG_IFACE_DETECT_FORCED = 1;
                paramsEnrollmentProcessing.CFG_IFACE_IGNORE_MULTIPLE_FACES = 1;
                paramsEnrollmentProcessing.CFG_IFACE_DETECTION_MODE = 2;
                paramsEnrollmentProcessing.CFG_IFACE_EXTRACTION_MODE = 2;
                paramsEnrollmentProcessing.CFG_IFACE_DETECTION_THRESHOLD = 200;
                paramsEnrollmentProcessing.AFACE_PARAMETER_ENROLL = 1;
                paramsEnrollmentProcessing.AFACE_PARAMETER_DEDUPLICATION = 1;
                paramsEnrollmentProcessing.CFG_SIMILARITY_THRESHOLD_DEDUPLICATION = 45;
                paramsEnrollmentProcessing.AFACE_PARAMETER_CONCATENATE_TEMPLATES = 1;
                paramsEnrollmentProcessing.AFACE_PARAMETER_MAXIMUM_TEMPLATES = -1;
                paramsEnrollmentProcessing.AFACE_PARAMETER_CONCATENATION_MODE = 0;
                paramsEnrollmentProcessing.AFACE_PARAMETER_SCORE_MIN = 30;
                paramsEnrollmentProcessing.AFACE_PARAMETER_SCORE_MAX = 60;
                paramsEnrollmentProcessing.AFACE_PARAMETER_VERIFICATION_SCORE = 20;
                configurationPipeline.paramsEnrollmentProcessing = paramsEnrollmentProcessing;
                configurationPipeline.configurationFlowVideo = "Flow video";
                ParamsFlow paramsFlow = new ParamsFlow();
                paramsFlow.deviceVideo = string.Empty;
                paramsFlow.fileVideo = "video5.mp4";
                paramsFlow.ipCamera = string.Empty;
                paramsFlow.sourceFlow = 2;
                paramsFlow.videoScaleMethod = 1;
                configurationPipeline.paramsFlow = paramsFlow;

                diskPresenter.SaveConfigurationPipe(0, configurationPipeline);

                CreateParamsDatabase();
                CreateParamsGlobal();              

                registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                        RegistryValueDataReader.NUM_CHANNELS_KEY, Convert.ToString(0));
                Configuration.Instance.NumberChannels = 0;
                diskPresenter.GenerateListChannels();
                AipuFace.Instance.SetNumberPipelines(number_channels);
                this.statusStrip.Invoke(new Action(() => managerControlView
                    .SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                    .GetString("configuration_empty"), 0, this.statusStrip)));

            }
            else
            {
                GetDatabaseConfiguration();                
                GenerateChannels();
                AipuFace.Instance.SetNumberPipelines(number_channels);
            }
        }

        private void VerifyFileConfigurationChannel()
        {
            int index = Configuration.Instance.NumberChannels + 1;

            for (int i = 0; i < index; i++)
            {
                if (!diskPresenter.VerifyFileOfConfiguration(i))
                {
                    Configuration.Instance.NumberChannels = i - 1;
                    break;
                }
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
                VerifyFileConfigurationChannel();
                diskPresenter.GenerateListChannels();
            }
        }

        private void mdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flagCloseApplication == false)
            {
                CloseApplication();
            }                       

        }
                
        private void GetDatabaseConfiguration()
        {
            DatabaseConfig databaseConfig = diskPresenter.ReadDatabaseConfiguration();
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
            configuraciónToolStripMenuItem.Enabled = false;
            frmWork.Show();
        }

        private void controlDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            managerControlView.SetValueTextStatusStrip("", 0, statusStrip);
            
            frmAccessControl frmWork = new frmAccessControl() { MdiParent = this };
            frmWork.strNameMenu = "controlDeEntradaToolStripMenuItem";
            
            controlDeEntradaToolStripMenuItem.Enabled = false;
            
            configuraciónToolStripMenuItem.Enabled = false;
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
