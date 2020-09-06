using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Windows.Forms;
using WhoIsDemo.domain.interactor;
using WhoIsDemo.model;
using WhoIsDemo.presenter;
using WhoIsDemo.repository;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmConfiguration : Form
    {
        #region constants
        
        #endregion
        #region variables
        public string strNameMenu;        
        ManagerControlView managerControlView = new ManagerControlView();
        DiskPresenter diskPresenter = new DiskPresenter();
        //DropDatabasePresenter dropDatabasePresenter = new DropDatabasePresenter();
        private RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
        private StatusStrip status;
        private int channelCurrent = 0;
        private bool testVideo = false;
        
        #endregion
        public frmConfiguration()
        {
            InitializeComponent();
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);
            
        }      

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            try
            {                
                          
                GetDatabaseConfiguration();
                
            }
            catch (FieldAccessException fe)
            {
                if (fe != null)
                {

                    string messageError = ManagerResource.Instance.resourceManager
                    .GetString("value_key_empty") + ": " +
                        fe.Source + ": " + fe.Message;
                    managerControlView
                    .SetValueTextStatusStrip(messageError, 0, this.status);
                }

            }

        }
    

        private void frmConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
            managerControlView.EnabledOptionMenu("controlDeEntradaToolStripMenuItem", mdiMain.NAME);
            managerControlView.EnabledOptionMenu("enrolamientoToolStripMenuItem", mdiMain.NAME);
            managerControlView.EnabledOptionMenu("channelHandlerToolStripMenuItem", mdiMain.NAME);
        }

        private bool ValidateDatabase()
        {
            return !string.IsNullOrEmpty(txtNameDatabase.Text) && 
                !string.IsNullOrEmpty(txtConnect.Text);
        }
       

        private void GetDatabaseConfiguration()
        {
            DatabaseConfig databaseConfig = diskPresenter
                .ReadDatabaseConfiguration(0);
            if (databaseConfig != null)
            {
                txtNameDatabase.Text = (string.IsNullOrEmpty(databaseConfig
                    .Params.name.ToString())) ? " " :
                    databaseConfig.Params.name.ToString();
                txtConnect.Text = (string.IsNullOrEmpty(databaseConfig
                    .Params.connect.ToString())) ? " " :
                    databaseConfig.Params.connect.ToString();

            }

        }

        private void InitControls()
        {
            cboChannel.SelectedIndex = 0;
            

        }

        private void GetParamsDetection(int channel)
        {
            Detect detect = diskPresenter.ReadDetectConfiguration(channel);
            Identify identify = diskPresenter.ReadIdentifyConfiguration(channel);
            if (detect != null && identify != null)
            {
                txtAccurancy.Text = (string.IsNullOrEmpty(detect.Params.accuracy.ToString())) ? "0" :
                    detect.Params.accuracy.ToString();
                txtMaxEye.Text = (string.IsNullOrEmpty(detect.Params.maxeye.ToString())) ? "0" :
                    detect.Params.maxeye.ToString();
                txtMaxDetect.Text = (string.IsNullOrEmpty(detect.Params.maxfaces.ToString())) ? "0" :
                    detect.Params.maxfaces.ToString();
                txtMinEye.Text = (string.IsNullOrEmpty(detect.Params.mineye.ToString())) ? "0" :
                    detect.Params.mineye.ToString();
                txtModelQuality.Text = (string.IsNullOrEmpty(detect.Params.qualitymodel.ToString())) ? "0" :
                    detect.Params.qualitymodel.ToString();
                cboDetectorMode.SelectedIndex = detect.Params.modedetect;
                cboExtractionMode.SelectedIndex = detect.Params.extractionmode;
                /////////////
                managerControlView.SetValueToComboBox(cboDetectForced,
                    identify.Params.A_FaceDetectionForced.ToString());
                managerControlView.SetValueToComboBox(cboIdentificationSpeed,
                    identify.Params.A_IdentificationSpeed.ToString());              
                txtASimilarity.Text = (string.IsNullOrEmpty(identify.Params.A_SimilarityThreshold.ToString())) ? "0" :
                    identify.Params.A_SimilarityThreshold.ToString();
                txtBestMatched.Text = (string.IsNullOrEmpty(identify.Params.A_BestMatchedCandidates.ToString())) ? "0" :
                    identify.Params.A_BestMatchedCandidates.ToString();
                cboBiometricLogLevel.SelectedIndex = identify.Params.A_BiometricLogLevel;
                cboIgnoreMultipleFaces.SelectedIndex = identify.Params.A_IgnoreMultipleFaces;
                cboFaceDetectionMode.SelectedIndex = identify.Params.A_FaceDetectionMode;
                txtSearchorExtractionThreads.Text = (string.IsNullOrEmpty(identify.Params.A_SearchorExtractionThreads.ToString())) ? "0" :
                    identify.Params.A_SearchorExtractionThreads.ToString();
                cboFaceExtractionMode.SelectedIndex = identify.Params.A_FaceExtractionMode;

                cboRegisterUser.SelectedIndex = identify.Params.is_register;
            }

        }

        

        private void txtMaxDetect_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtAccurancy_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtMaxEye_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtMinEye_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }  

        private bool VerifyInputDetect()
        {
            return (!string.IsNullOrEmpty(txtAccurancy.Text) &&
                !string.IsNullOrEmpty(txtMaxDetect.Text) &&
                !string.IsNullOrEmpty(txtMaxEye.Text) &&
                !string.IsNullOrEmpty(txtMinEye.Text) &&
                !string.IsNullOrEmpty(txtMaxEyeTrack.Text) &&
                cboDetectForced.SelectedIndex != -1 && 
                cboIdentificationSpeed.SelectedIndex != -1 && 
                cboDetectorMode.SelectedIndex != -1);
        }        

        private int CheckTypeVideo(string description)
        {
            int device;
            if (int.TryParse(description, out device))
            {
                return Configuration.VIDEO_TYPE_CAMERA;
            }            
            if (description.Substring(0, 4) == "rtsp")
            {
                return Configuration.VIDEO_TYPE_IP;
            }
            if (description.Substring(description.LastIndexOf('.') + 1) == "mp4")
            {
                return Configuration.VIDEO_TYPE_FILE;
            }
            
            return 0;
        }

        //private void btnSaveVideoList_Click(object sender, EventArgs e)
        //{
        //    string quantityVideo = "video_" + (lvwVideo.Items.Count + 1).ToString();
           
        //    ListViewItem item = new ListViewItem(quantityVideo,
        //            lvwVideo.Items.Count);
        //    item.SubItems.Add(txtIpVideo.Text);
        //    int typeVideo = CheckTypeVideo(txtIpVideo.Text);
        //    switch (typeVideo)
        //    {
        //        case Configuration.VIDEO_TYPE_IP:
        //            item.SubItems.Add(Configuration.DESC_TYPE_IP);
        //            lvwVideo.Items.Add(item);
        //            break;
        //        case Configuration.VIDEO_TYPE_FILE:
        //            item.SubItems.Add(Configuration.DESC_TYPE_FILE);
        //            lvwVideo.Items.Add(item);
        //            break;
        //        case Configuration.VIDEO_TYPE_CAMERA:
        //            item.SubItems.Add(Configuration.DESC_TYPE_CAMERA);
        //            lvwVideo.Items.Add(item);
        //            break;
        //        default:
        //            MessageBox.Show(ManagerResource.Instance.resourceManager
        //            .GetString("type_video_incorrect"));
        //            break;
        //    }
            
        //}

        private string GetDescTypeVideo(int type)
        {
            switch (type)
            {
                case Configuration.VIDEO_TYPE_IP:
                    return Configuration.DESC_TYPE_IP;
                case Configuration.VIDEO_TYPE_FILE:
                    return Configuration.DESC_TYPE_FILE;
                case Configuration.VIDEO_TYPE_CAMERA:
                    return Configuration.DESC_TYPE_CAMERA;
                default:
                    break;
            }
            return "";
        }

        private int GetTypeVideo(string description)
        {
            switch (description)
            {
                case Configuration.DESC_TYPE_IP:
                    return Configuration.VIDEO_TYPE_IP;                    
                case Configuration.DESC_TYPE_FILE:
                    return Configuration.VIDEO_TYPE_FILE;
                case Configuration.DESC_TYPE_CAMERA:
                    return Configuration.VIDEO_TYPE_CAMERA;
                default:
                    break;
            }
            return 0;
        }

        //private void SaveVideos()
        //{
        //    List<Video> list = new List<Video>();
        //    foreach (ListViewItem item in lvwVideo.Items)
        //    {
        //        Video video = new Video();
        //        video.id = item.Text;                
        //        video.type = GetTypeVideo(item.SubItems[2].Text);
        //        if (video.type == Configuration.VIDEO_TYPE_CAMERA && !item.SubItems[1].Text.Contains("dev"))
        //        {
        //            video.path = "/dev/video" + item.SubItems[1].Text;
        //        }
        //        else
        //        {
        //            video.path = item.SubItems[1].Text;
        //        }
                
        //        list.Add(video);
        //    }

        //    VideoConfig videoConfig = new VideoConfig();
        //    videoConfig.configuration = "video_configuration";
        //    videoConfig.videos = list;
        //    Configuration.Instance.ListVideo = list;
        //    SetVideoInControl();
        //    diskPresenter.SaveVideoConfiguration(videoConfig);
        //    this.lblVideoOk.Text = "OK";
        //}

        //private void SetVideoInControl()
        //{
        //    if (Configuration.Instance.ListVideo.Count != 0)
        //    {
        //        cboVideos.Items.Clear();
        //        foreach (Video vid in Configuration.Instance.ListVideo)
        //        {
        //            cboVideos.Items.Add(vid.path);
        //        }
        //    }
        //}

        //private void btnSaveVideosFile_Click(object sender, EventArgs e)
        //{
        //   // SaveVideos();
        //}

        //private void lvwVideo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
        //    {
        //        lvwVideo.SelectedItems[0].Remove();
        //    }
        //}

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            if (ValidateDatabase())
            {
                DatabaseConfig databaseConfig = new DatabaseConfig();
                databaseConfig.configuration = "database_configuration";
                ParamsDatabase paramsDatabase = new ParamsDatabase();
                paramsDatabase.connect = txtConnect.Text;
                paramsDatabase.name = txtNameDatabase.Text;
                databaseConfig.Params = paramsDatabase;
                diskPresenter.SaveDatabaseConfiguration(0, databaseConfig);
                System.Threading.Thread closeLibrary = new System
                .Threading.Thread(new System.Threading
                .ThreadStart(AipuFace.Instance.Terminate));
                closeLibrary.Start();
                System.Windows.Forms.Application.Exit();
            }
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(ManagerResource.Instance.resourceManager
                    .GetString("delete_database"), "Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //AipuFace.Instance.Terminate();

                Database.Instance.DropDatabase();

                diskPresenter.FileDelete("iengine.db");
                lblOkClearDatabase.Text = "OK";
                this.MdiParent.Close();                
                

                //System.Windows.Forms.Application.Exit();

                //if (dropDatabasePresenter.DropCurrentDatabase())
                //{
                //    diskPresenter.FileDelete("iengine.db");
                //    lblOkClearDatabase.Text = "OK";
                    
                //    System.Windows.Forms.Application.Exit();
                //}
                //else
                //{
                //    managerControlView.SetValueTextStatusStrip(ManagerResource.Instance.resourceManager
                //        .GetString("error"),
                //        0, this.status);
                //}
            }            
            
            
        }
                    
        private void txtTrackingRefresh_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtMaxEyeTrack_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtMinEyeTrack_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtRefreshTrack_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtConfidenceTrack_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }        

        private void GetParamsFlow(int channel)
        {
            Flow flow = diskPresenter.ReadFlowConfiguration(channel);

            if (flow != null)
            {
                int sourceFlow = flow.Params.sourceFlow;
                switch (sourceFlow)
                {
                    case 1:
                        rbTypeChannelIP.Checked = true;
                        txtDescriptionChannel.Text = flow.Params.ipCamera;
                        break;
                    case 2:
                        rbTypeChannelFile.Checked = true;
                        txtDescriptionChannel.Text = flow.Params.fileVideo;
                        break;
                    case 3:
                        rbTypeChannelDevice.Checked = true;
                        txtDescriptionChannel.Text = flow.Params.deviceVideo;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                txtDescriptionChannel.Text = string.Empty;
                MessageBox.Show(ManagerResource.Instance.resourceManager
                .GetString("channel_not_exist"));
            }
        }

        private void GetParamsTracking(int channel)
        {
            Tracking tracking = diskPresenter.ReadTrackingConfiguration(channel);
            
            if (tracking != null)
            {

                txtMaxEyeTrack.Text = (string.IsNullOrEmpty(tracking.Params.maxeye.ToString())) ? "0" :
                    tracking.Params.maxeye.ToString();
                txtMinEyeTrack.Text = (string.IsNullOrEmpty(tracking.Params.mineye.ToString())) ? "0" :
                    tracking.Params.mineye.ToString();

                txtRefreshTrack.Text = (string.IsNullOrEmpty(tracking.Params.refreshInterval.ToString())) ? "0" :
                    tracking.Params.refreshInterval.ToString();

                txtConfidenceTrack.Text = (string.IsNullOrEmpty(tracking.Params.faceConfidenceThresh.ToString())) ? "0" :
                    tracking.Params.faceConfidenceThresh.ToString();

                chkDeepTrack.Checked = Convert.ToBoolean(tracking.Params.deepTrack);
                cboTrackingMode.SelectedIndex = tracking.Params.trackingMode;
                cboTrackSpeed.SelectedIndex = tracking.Params.trackSpeed;
                cboTrackMotion.SelectedIndex = tracking.Params.motionOptimization;
               
            }

        }        

        private bool ValidateFlow()
        {

            return (CheckTypeVideo(txtDescriptionChannel.Text) != 0);
            
        }
        private bool SaveConfigurationFlow(int channel)
        {
            bool result = false;

            if (ValidateFlow())
            {
                Flow flow = new Flow();
                flow.configuration = "flowvideo_configuration";
                ParamsFlow paramsFlow = new ParamsFlow();
                if (rbTypeChannelIP.Checked == true)
                {
                    paramsFlow.sourceFlow = 1;
                    paramsFlow.ipCamera = txtDescriptionChannel.Text;
                    paramsFlow.fileVideo = string.Empty;
                    paramsFlow.deviceVideo = string.Empty;
                }

                if (rbTypeChannelFile.Checked == true)
                {
                    paramsFlow.sourceFlow = 2;
                    paramsFlow.ipCamera = string.Empty;
                    paramsFlow.fileVideo = txtDescriptionChannel.Text;
                    paramsFlow.deviceVideo = string.Empty;
                }

                if (rbTypeChannelDevice.Checked == true)
                {
                    paramsFlow.sourceFlow = 3;
                    paramsFlow.ipCamera = string.Empty;
                    paramsFlow.fileVideo = string.Empty;
                    paramsFlow.deviceVideo = txtDescriptionChannel.Text;
                }

                paramsFlow.videoScaleMethod = 1;

                flow.Params = paramsFlow;
                diskPresenter.SaveFlowConfiguration(channel, flow);
                result = true;
            }
            
            return result;
        }

        private bool ValidateTracking()
        {
            return (txtMaxEyeTrack.Text != "0"
                && txtMinEyeTrack.Text != "0"
                && txtRefreshTrack.Text != "0"
                && txtConfidenceTrack.Text != "0");
        }

        private bool SaveConfigurationTracking(int channel)
        {
            bool result = false;
            if (ValidateTracking())
            {
                Tracking tracking = new Tracking();
                tracking.configuration = "tracking_configuration";
                ParamsTracking paramsTracking = new ParamsTracking();
                paramsTracking.maxeye = Convert.ToInt16(txtMaxEyeTrack.Text);
                paramsTracking.mineye = Convert.ToInt16(txtMinEyeTrack.Text);
                paramsTracking.maxfaces = 5;
                paramsTracking.refreshInterval = Convert.ToInt16(txtRefreshTrack.Text);
                paramsTracking.faceConfidenceThresh = Convert.ToInt16(txtConfidenceTrack.Text);
                paramsTracking.deepTrack = Convert.ToInt16(chkDeepTrack.Checked);
                paramsTracking.trackingMode = cboTrackingMode.SelectedIndex;
                paramsTracking.trackSpeed = cboTrackSpeed.SelectedIndex;
                paramsTracking.motionOptimization = cboTrackMotion.SelectedIndex;
                paramsTracking.qualitymodel = Convert.ToInt16(txtModelQuality.Text);
                tracking.Params = paramsTracking;
                diskPresenter.SaveTrackingConfiguration(channel, tracking);

                result = true;
            }
            
            return result;
        }

        private bool SaveConfigurationDetect(int channel)
        {
            bool result = false;
            if (VerifyInputDetect())
            {
                Detect detect = new Detect();
                Identify identify = new Identify();
                identify.configuration = "identify_configuration";
                detect.configuration = "detect_configuration";
                ParamsIdentify paramsIdentify = new ParamsIdentify();
                ParamsDetect paramsDetect = new ParamsDetect();
                paramsDetect.accuracy = Convert.ToInt16(txtAccurancy.Text);
                paramsDetect.maxeye = Convert.ToInt16(txtMaxEye.Text);
                paramsDetect.maxfaces = Convert.ToInt16(txtMaxDetect.Text);
                paramsDetect.mineye = Convert.ToInt16(txtMinEye.Text);
                paramsDetect.extractionmode = cboExtractionMode.SelectedIndex;
                paramsDetect.modedetect = cboDetectorMode.SelectedIndex;
                paramsDetect.qualitymodel = Convert.ToInt16(txtModelQuality.Text);
                paramsIdentify.A_MaxEyeDist = Convert.ToInt16(txtMaxEye.Text);
                paramsIdentify.A_MinEyeDist = Convert.ToInt16(txtMinEye.Text);
                paramsIdentify.A_FaceDetectionForced = Convert.ToInt16(cboDetectForced.Text);
                paramsIdentify.A_IdentificationSpeed = Convert.ToInt16(cboIdentificationSpeed.Text);
                paramsIdentify.A_SimilarityThreshold = Convert.ToInt16(txtASimilarity.Text);
                paramsIdentify.A_BiometricLogLevel = cboBiometricLogLevel.SelectedIndex;
                paramsIdentify.A_BestMatchedCandidates = Convert.ToInt16(txtBestMatched.Text);
                paramsIdentify.A_IgnoreMultipleFaces = cboIgnoreMultipleFaces.SelectedIndex;
                paramsIdentify.A_FaceDetectionMode = cboFaceDetectionMode.SelectedIndex;
                paramsIdentify.A_SearchorExtractionThreads = Convert.ToInt16(txtSearchorExtractionThreads.Text);
                paramsIdentify.A_FaceExtractionMode = cboFaceExtractionMode.SelectedIndex;
                paramsIdentify.is_register = cboRegisterUser.SelectedIndex;
                detect.Params = paramsDetect;
                identify.Params = paramsIdentify;
                diskPresenter.SaveDetectConfiguration(channel, detect);
                diskPresenter.SaveIdentifyConfiguration(channel, identify);
                result = true;
                
            }
            return result;
        }
        

        private void txtASimilarity_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtBestMatched_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                testVideo = false;
                channelCurrent = (sender as ComboBox).SelectedIndex;
                GetDataConfiguration(channelCurrent);
            }
                        
        }

        private void GetDataConfiguration(int channel)
        {
            GetParamsFlow(channel);
            GetParamsDetection(channel);
            GetParamsTracking(channel);
        }

        private bool SaveDataConfiguration(int channel)
        {
            bool result = false;
            if (channel > Configuration.Instance.NumberChannels + 2)
            {
                return result;
            }
            diskPresenter.CreateDirectoryWork(channel);
            diskPresenter.CreateContentDirectoryWork(channel);
            if (SaveConfigurationFlow(channel))
            {
                if (SaveConfigurationTracking(channel))
                {
                    if (SaveConfigurationDetect(channel))
                    {
                        result = true;
                    }
                }
            }

            if (channel > Configuration.Instance.NumberChannels)
            {
                registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                        RegistryValueDataReader.NUM_CHANNELS_KEY, Convert.ToString(channel));
                Configuration.Instance.NumberChannels = channel;
            }

            diskPresenter.GenerateListChannels();

            return result;
        }

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            if (!testVideo || !SaveDataConfiguration(channelCurrent))
            {
                MessageBox.Show(ManagerResource.Instance.resourceManager
                    .GetString("configuration_empty"));
            }
            else
            {
                managerControlView.SetValueTextStatusStrip(ManagerResource
                    .Instance.resourceManager
                        .GetString("save_ok"),
                        0, this.status);
            }
        }

        private void frmConfiguration_Shown(object sender, EventArgs e)
        {
            InitControls();
        }

        private int VerifyDescriptionChannel()
        {
            int checkType = CheckTypeVideo(txtDescriptionChannel.Text);

            switch (checkType)
            {
                case 1:
                    rbTypeChannelIP.Checked = true;
                    break;
                case 2:
                    rbTypeChannelFile.Checked = true;
                    break;
                case 3:
                    rbTypeChannelDevice.Checked = true;
                    break;
                default:
                    break;
            }
            return checkType;
        }
        private void btnTestChannel_Click(object sender, EventArgs e)
        {
            if (VerifyDescriptionChannel() != 0)
            {
                VideoCapture captureInit = new VideoCapture(txtDescriptionChannel.Text);
                if (captureInit.IsOpened)
                {
                    double fps = captureInit.GetCaptureProperty(CapProp.Fps);

                    captureInit.Stop();
                    captureInit.Dispose();
                    managerControlView
                        .SetValueTextStatusStrip(ManagerResource
                        .Instance.resourceManager
                            .GetString("video_ok") + " " + Convert.ToString(fps) + " fps.",
                        0, this.status);
                    testVideo = true;
                }
                else
                {
                    testVideo = false;
                    managerControlView
                        .SetValueTextStatusStrip(ManagerResource
                        .Instance.resourceManager
                            .GetString("ip_video_empty"),
                        0, this.status);
                }
            }
            else
            {
                testVideo = false;
                managerControlView
                    .SetValueTextStatusStrip(ManagerResource
                    .Instance.resourceManager
                        .GetString("ip_video_empty"),
                    0, this.status);
            }
            
        }

        private void txtSearchorExtractionThreads_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }
    }
}
