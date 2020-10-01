using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Windows.Forms;
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
        
        private RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
        private StatusStrip status;
        private int channelCurrent = 0;
        private bool testVideo = false;
        private System.Windows.Forms.ErrorProvider valueErrortxtAccurancy;
        private System.Windows.Forms.ErrorProvider valueErrortxtModelQuality;
        private System.Windows.Forms.ErrorProvider valueErrortxtMaxDetect;
        private System.Windows.Forms.ErrorProvider valueErrortxtRefreshTrack;
        private System.Windows.Forms.ErrorProvider valueErrortxtRedetectTimeDelta;
        private System.Windows.Forms.ErrorProvider valueErrortxtDetectionThreshold;
        private System.Windows.Forms.ErrorProvider valueErrortxtSimilarityThreshold;
        private System.Windows.Forms.ErrorProvider valueErrortxtScoreMin;
        private System.Windows.Forms.ErrorProvider valueErrortxtScoreMax;
        private System.Windows.Forms.ErrorProvider valueErrortxtASimilarity;
        private System.Windows.Forms.ErrorProvider valueErrortxtBestMatched;
       

        #endregion
        public frmConfiguration()
        {
            InitializeComponent();
            this.status = managerControlView.GetStatusStripMain(mdiMain.NAME);

            valueErrortxtAccurancy = new System.Windows.Forms.ErrorProvider();
            valueErrortxtAccurancy.SetIconAlignment(this.txtAccurancy, ErrorIconAlignment.MiddleRight);
            valueErrortxtAccurancy.SetIconPadding(this.txtAccurancy, 2);
            valueErrortxtAccurancy.BlinkRate = 1000;
            valueErrortxtAccurancy.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtModelQuality = new System.Windows.Forms.ErrorProvider();
            valueErrortxtModelQuality.SetIconAlignment(this.txtModelQuality, ErrorIconAlignment.MiddleRight);
            valueErrortxtModelQuality.SetIconPadding(this.txtModelQuality, 2);
            valueErrortxtModelQuality.BlinkRate = 1000;
            valueErrortxtModelQuality.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtMaxDetect = new System.Windows.Forms.ErrorProvider();
            valueErrortxtMaxDetect.SetIconAlignment(this.txtMaxDetect, ErrorIconAlignment.MiddleRight);
            valueErrortxtMaxDetect.SetIconPadding(this.txtMaxDetect, 2);
            valueErrortxtMaxDetect.BlinkRate = 1000;
            valueErrortxtMaxDetect.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtRefreshTrack = new System.Windows.Forms.ErrorProvider();
            valueErrortxtRefreshTrack.SetIconAlignment(this.txtRefreshTrack, ErrorIconAlignment.MiddleRight);
            valueErrortxtRefreshTrack.SetIconPadding(this.txtRefreshTrack, 2);
            valueErrortxtRefreshTrack.BlinkRate = 1000;
            valueErrortxtRefreshTrack.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtRedetectTimeDelta = new System.Windows.Forms.ErrorProvider();
            valueErrortxtRedetectTimeDelta.SetIconAlignment(this.txtRedetectTimeDelta, ErrorIconAlignment.MiddleRight);
            valueErrortxtRedetectTimeDelta.SetIconPadding(this.txtRedetectTimeDelta, 2);
            valueErrortxtRedetectTimeDelta.BlinkRate = 1000;
            valueErrortxtRedetectTimeDelta.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtDetectionThreshold = new System.Windows.Forms.ErrorProvider();
            valueErrortxtDetectionThreshold.SetIconAlignment(this.txtDetectionThreshold, ErrorIconAlignment.MiddleRight);
            valueErrortxtDetectionThreshold.SetIconPadding(this.txtDetectionThreshold, 2);
            valueErrortxtDetectionThreshold.BlinkRate = 1000;
            valueErrortxtDetectionThreshold.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtSimilarityThreshold = new System.Windows.Forms.ErrorProvider();
            valueErrortxtSimilarityThreshold.SetIconAlignment(this.txtSimilarityThreshold, ErrorIconAlignment.MiddleRight);
            valueErrortxtSimilarityThreshold.SetIconPadding(this.txtSimilarityThreshold, 2);
            valueErrortxtSimilarityThreshold.BlinkRate = 1000;
            valueErrortxtSimilarityThreshold.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtScoreMin = new System.Windows.Forms.ErrorProvider();
            valueErrortxtScoreMin.SetIconAlignment(this.txtScoreMin, ErrorIconAlignment.MiddleRight);
            valueErrortxtScoreMin.SetIconPadding(this.txtScoreMin, 2);
            valueErrortxtScoreMin.BlinkRate = 1000;
            valueErrortxtScoreMin.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtScoreMax = new System.Windows.Forms.ErrorProvider();
            valueErrortxtScoreMax.SetIconAlignment(this.txtScoreMax, ErrorIconAlignment.MiddleRight);
            valueErrortxtScoreMax.SetIconPadding(this.txtScoreMax, 2);
            valueErrortxtScoreMax.BlinkRate = 1000;
            valueErrortxtScoreMax.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtASimilarity = new System.Windows.Forms.ErrorProvider();
            valueErrortxtASimilarity.SetIconAlignment(this.txtASimilarity, ErrorIconAlignment.MiddleRight);
            valueErrortxtASimilarity.SetIconPadding(this.txtASimilarity, 2);
            valueErrortxtASimilarity.BlinkRate = 1000;
            valueErrortxtASimilarity.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

            valueErrortxtBestMatched = new System.Windows.Forms.ErrorProvider();
            valueErrortxtBestMatched.SetIconAlignment(this.txtBestMatched, ErrorIconAlignment.MiddleRight);
            valueErrortxtBestMatched.SetIconPadding(this.txtBestMatched, 2);
            valueErrortxtBestMatched.BlinkRate = 1000;
            valueErrortxtBestMatched.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            try
            {                
                          
                GetDatabaseConfiguration();
                GetGlobalParameters();


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
                .ReadDatabaseConfiguration();
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

        private void GetParamsEnrollProcessing(ParamsEnrollmentProcessing paramsEnrollmentProcessing)
        {
            if (paramsEnrollmentProcessing != null)
            {
                //managerControlView.SetValueToComboBox(cboDetectForced,
                //   paramsEnrollmentProcessing.CFG_IFACE_DETECT_FORCED.ToString());
                cboDetectForced.SelectedIndex = paramsEnrollmentProcessing.CFG_IFACE_DETECT_FORCED;
                cboIdentificationSpeed.SelectedIndex = paramsEnrollmentProcessing.CFG_IDENTIFICATION_SPEED;
                //managerControlView.SetValueToComboBox(cboIdentificationSpeed,
                //    paramsEnrollmentProcessing.CFG_IDENTIFICATION_SPEED.ToString());
                txtASimilarity.Text = (string.IsNullOrEmpty(paramsEnrollmentProcessing.CFG_SIMILARITY_THRESHOLD.ToString())) ? "0" :
                    paramsEnrollmentProcessing.CFG_SIMILARITY_THRESHOLD.ToString();
                txtBestMatched.Text = (string.IsNullOrEmpty(paramsEnrollmentProcessing.CFG_BEST_CANDIDATES_COUNT.ToString())) ? "0" :
                    paramsEnrollmentProcessing.CFG_BEST_CANDIDATES_COUNT.ToString();                
                cboIgnoreMultipleFaces.SelectedIndex = paramsEnrollmentProcessing.CFG_IFACE_IGNORE_MULTIPLE_FACES;
                cboFaceDetectionMode.SelectedIndex = paramsEnrollmentProcessing.CFG_IFACE_DETECTION_MODE;                                              
                cboFaceExtractionMode.SelectedIndex = paramsEnrollmentProcessing.CFG_IFACE_EXTRACTION_MODE;
                cboRegisterUser.SelectedIndex = paramsEnrollmentProcessing.AFACE_PARAMETER_ENROLL;
                txtDetectionThreshold.Text = (string.IsNullOrEmpty(paramsEnrollmentProcessing.CFG_IFACE_DETECTION_THRESHOLD.ToString())) ? "0" :
                    paramsEnrollmentProcessing.CFG_IFACE_DETECTION_THRESHOLD.ToString();
                txtScoreMin.Text = (string.IsNullOrEmpty(paramsEnrollmentProcessing.AFACE_PARAMETER_SCORE_MIN.ToString())) ? "0" :
                    paramsEnrollmentProcessing.AFACE_PARAMETER_SCORE_MIN.ToString();
                txtScoreMax.Text = (string.IsNullOrEmpty(paramsEnrollmentProcessing.AFACE_PARAMETER_SCORE_MAX.ToString())) ? "0" :
                    paramsEnrollmentProcessing.AFACE_PARAMETER_SCORE_MAX.ToString();
              //////////
                txtSimilarityThreshold.Text = (string.IsNullOrEmpty(paramsEnrollmentProcessing.CFG_SIMILARITY_THRESHOLD_DEDUPLICATION.ToString())) ? "0" :
                    paramsEnrollmentProcessing.CFG_SIMILARITY_THRESHOLD_DEDUPLICATION.ToString();
                cboDeduplicate.SelectedIndex = paramsEnrollmentProcessing.AFACE_PARAMETER_DEDUPLICATION;
                cboConcatenateTemplates.SelectedIndex = paramsEnrollmentProcessing.AFACE_PARAMETER_CONCATENATE_TEMPLATES;
                txtMaximumTemplates.Text = (string.IsNullOrEmpty(paramsEnrollmentProcessing.AFACE_PARAMETER_MAXIMUM_TEMPLATES.ToString())) ? "0" :
                    paramsEnrollmentProcessing.AFACE_PARAMETER_MAXIMUM_TEMPLATES.ToString();
                cboModeConcatenation.SelectedIndex = paramsEnrollmentProcessing.AFACE_PARAMETER_CONCATENATION_MODE;
                txtVerificationScoreThreshold.Text = (string.IsNullOrEmpty(paramsEnrollmentProcessing.AFACE_PARAMETER_VERIFICATION_SCORE.ToString())) ? "0" :
                    paramsEnrollmentProcessing.AFACE_PARAMETER_VERIFICATION_SCORE.ToString();
            }
                
        }
        private void GetParamsFaceProcessing(ParamsFaceProcessing paramsFaceProcessing)
        {
                       
            if (paramsFaceProcessing != null)
            {
                txtAccurancy.Text = (string.IsNullOrEmpty(paramsFaceProcessing.FACEDET_CONFIDENCE_THRESHOLD.ToString())) ? "0" :
                    paramsFaceProcessing.FACEDET_CONFIDENCE_THRESHOLD.ToString();
                txtMaxEye.Text = (string.IsNullOrEmpty(paramsFaceProcessing.TRACK_MAX_FACE_SIZE.ToString())) ? "0" :
                    paramsFaceProcessing.TRACK_MAX_FACE_SIZE.ToString();
                txtMaxDetect.Text = (string.IsNullOrEmpty(paramsFaceProcessing.FACE_MAX_DETECT.ToString())) ? "0" :
                    paramsFaceProcessing.FACE_MAX_DETECT.ToString();
                txtMinEye.Text = (string.IsNullOrEmpty(paramsFaceProcessing.TRACK_MIN_FACE_SIZE.ToString())) ? "0" :
                    paramsFaceProcessing.TRACK_MIN_FACE_SIZE.ToString();
                txtModelQuality.Text = (string.IsNullOrEmpty(paramsFaceProcessing.QUALITY_MODEL.ToString())) ? "0" :
                    paramsFaceProcessing.QUALITY_MODEL.ToString();
                cboDetectorMode.SelectedIndex = paramsFaceProcessing.FACEDET_SPEED_ACCURACY_MODE;
                cboExtractionMode.SelectedIndex = paramsFaceProcessing.FACETMPLEXT_SPEED_ACCURACY_MODE;
                cboFaceCrop.SelectedIndex = paramsFaceProcessing.IFACE_GetFaceCropImage;           
               
            }

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
                diskPresenter.SaveDatabaseConfiguration(databaseConfig);
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
                

                Database.Instance.DropDatabase();

                diskPresenter.FileDelete("iengine.db");
                lblOkClearDatabase.Text = "OK";
                this.MdiParent.Close();                
                                
            }            
            
            
        }                          

        private void txtRefreshTrack_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void GetGlobalParameters()
        {
            ConfigurationGlobalLib configurationGlobalLib = diskPresenter.ReadGlobalParameters();
            ParamsGlobal paramsGlobal = configurationGlobalLib.paramsGlobal;
            txtGBMinImage.Text = paramsGlobal.GLOBAL_MIN_VALID_IMAGE_SIZE.ToString();
            cboGBThreadMode.SelectedIndex = paramsGlobal.GLOBAL_THREAD_MANAGEMENT_MODE;
            txtGBThreadNum.Text = paramsGlobal.GLOBAL_THREAD_NUM.ToString();
            txtGBLogLevel.Text = paramsGlobal.GLOBAL_CFG_LOG_LEVEL.ToString();
            cboGBEnabledConfigurationGPU.SelectedIndex = paramsGlobal.AFACE_PARAMETER_GPU_ENABLED;
            txtGBGpuDevice.Text = paramsGlobal.GLOBAL_GPU_DEVICE_ID;            
            managerControlView.SetValueToComboBox(cboGBGpuEnabled,
                paramsGlobal.GLOBAL_GPU_ENABLED);
        }
        
        private void GetParamsConfiguration(int channel)
        {
            ConfigurationPipeline configurationPipeline = diskPresenter.ReadConfigurationPipe(channel);
            if (configurationPipeline != null)
            {
                ParamsFlow paramsFlow = configurationPipeline.paramsFlow;
                GetParamsFlow(paramsFlow);
                ParamsTrackingProcessing paramsTrackingProcessing = configurationPipeline.paramsTrackingProcessing;
                GetParamsTracking(paramsTrackingProcessing);
                ParamsFaceProcessing paramsFaceProcessing = configurationPipeline.paramsFaceProcessing;
                GetParamsFaceProcessing(paramsFaceProcessing);
                ParamsEnrollmentProcessing paramsEnrollmentProcessing = configurationPipeline.paramsEnrollmentProcessing;
                GetParamsEnrollProcessing(paramsEnrollmentProcessing);
            }
        }

        private void GetParamsFlow(ParamsFlow paramsFlow)
        {
            

            if (paramsFlow != null)
            {
                int sourceFlow = paramsFlow.sourceFlow;
                switch (sourceFlow)
                {
                    case 1:
                        rbTypeChannelIP.Checked = true;
                        txtDescriptionChannel.Text = paramsFlow.ipCamera;
                        break;
                    case 2:
                        rbTypeChannelFile.Checked = true;
                        txtDescriptionChannel.Text = paramsFlow.fileVideo;
                        break;
                    case 3:
                        rbTypeChannelDevice.Checked = true;
                        txtDescriptionChannel.Text = paramsFlow.deviceVideo;
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

        private void GetParamsTracking(ParamsTrackingProcessing paramsTrackingProcessing)
        {
            

            if (paramsTrackingProcessing != null)
            {                

                txtRefreshTrack.Text = (string.IsNullOrEmpty(paramsTrackingProcessing.TRACK_FACE_DISCOVERY_FREQUENCE_MS.ToString())) ? "0" :
                    paramsTrackingProcessing.TRACK_FACE_DISCOVERY_FREQUENCE_MS.ToString();
                if (paramsTrackingProcessing.TRACK_DEEP_TRACK == "true")
                {
                    chkDeepTrack.Checked = true;
                }
                else
                {
                    chkDeepTrack.Checked = false;
                }
                
                cboTrackingMode.SelectedIndex = paramsTrackingProcessing.TRACK_TRACKING_MODE;
                cboTrackSpeed.SelectedIndex = paramsTrackingProcessing.TRACK_SPEED_ACCURACY_MODE;
                cboTrackMotion.SelectedIndex = paramsTrackingProcessing.TRACK_MOTION_OPTIMIZATION;
                txtRedetectTimeDelta.Text = paramsTrackingProcessing.COUNT_REDETECT_TIME_DELTA.ToString();

            }

        }

        private bool ValidateFlow()
        {

            return (CheckTypeVideo(txtDescriptionChannel.Text) != 0);
            
        }                                    

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex != -1)
            {
                testVideo = false;
                channelCurrent = (sender as ComboBox).SelectedIndex;
                GetParamsConfiguration(channelCurrent);
            }

        }       

        private bool SaveDataConfiguration(int channel)
        {
            
            if (channel > Configuration.Instance.NumberChannels + 2 || !ValidateFlow())
            {
                return false;
            }
            
            ConfigurationPipeline configurationPipeline = new ConfigurationPipeline();
            configurationPipeline.configurationFaceProcessing = "Face processing";
            ParamsFaceProcessing paramsFaceProcessing = new ParamsFaceProcessing();
            paramsFaceProcessing.IFACE_GetFaceCropImage = cboFaceCrop.SelectedIndex;
            paramsFaceProcessing.FACEDET_CONFIDENCE_THRESHOLD = Convert.ToInt16(txtAccurancy.Text.ToString());
            paramsFaceProcessing.FACEDET_SPEED_ACCURACY_MODE = cboDetectorMode.SelectedIndex;
            paramsFaceProcessing.FACETMPLEXT_SPEED_ACCURACY_MODE = cboExtractionMode.SelectedIndex;
            paramsFaceProcessing.TRACK_MAX_FACE_SIZE = Convert.ToInt16(txtMaxEye.Text.ToString());
            paramsFaceProcessing.TRACK_MIN_FACE_SIZE = Convert.ToInt16(txtMinEye.Text.ToString());
            paramsFaceProcessing.QUALITY_MODEL = Convert.ToInt32(txtModelQuality.Text);
            paramsFaceProcessing.FACE_MAX_DETECT = Convert.ToInt32(txtMaxDetect.Text);
            configurationPipeline.paramsFaceProcessing = paramsFaceProcessing;
            configurationPipeline.configurationTrackingProcessing = "Tracking processing";
            ParamsTrackingProcessing paramsTrackingProcessing = new ParamsTrackingProcessing();
            if (chkDeepTrack.Checked)
            {
                paramsTrackingProcessing.TRACK_DEEP_TRACK = "true";
            }
            else
            {
                paramsTrackingProcessing.TRACK_DEEP_TRACK = "false";
            }

            paramsTrackingProcessing.TRACK_FACE_DISCOVERY_FREQUENCE_MS = Convert.ToInt32(txtRefreshTrack.Text);
            paramsTrackingProcessing.COUNT_REDETECT_TIME_DELTA = Convert.ToInt32(txtRedetectTimeDelta.Text);
            paramsTrackingProcessing.TRACK_MOTION_OPTIMIZATION = cboTrackMotion.SelectedIndex;
            paramsTrackingProcessing.TRACK_SPEED_ACCURACY_MODE = cboTrackSpeed.SelectedIndex;
            paramsTrackingProcessing.TRACK_TRACKING_MODE = cboTrackingMode.SelectedIndex;
            configurationPipeline.paramsTrackingProcessing = paramsTrackingProcessing;
            configurationPipeline.configurationEnrollmentProcessing = "Enrollment processing";
            ParamsEnrollmentProcessing paramsEnrollmentProcessing = new ParamsEnrollmentProcessing();
            paramsEnrollmentProcessing.CFG_BEST_CANDIDATES_COUNT = Convert.ToInt16(txtBestMatched.Text); ;
            paramsEnrollmentProcessing.CFG_SIMILARITY_THRESHOLD = Convert.ToInt16(txtASimilarity.Text);
            paramsEnrollmentProcessing.CFG_IDENTIFICATION_SPEED = Convert.ToInt16(cboIdentificationSpeed.Text);
            paramsEnrollmentProcessing.CFG_IFACE_DETECT_FORCED = cboDetectForced.SelectedIndex;
            paramsEnrollmentProcessing.CFG_IFACE_IGNORE_MULTIPLE_FACES = cboIgnoreMultipleFaces.SelectedIndex;
            paramsEnrollmentProcessing.CFG_IFACE_DETECTION_MODE = cboFaceDetectionMode.SelectedIndex;
            paramsEnrollmentProcessing.CFG_IFACE_EXTRACTION_MODE = cboFaceExtractionMode.SelectedIndex;
            paramsEnrollmentProcessing.CFG_IFACE_DETECTION_THRESHOLD = Convert.ToInt16(txtDetectionThreshold.Text);
            paramsEnrollmentProcessing.AFACE_PARAMETER_SCORE_MIN = Convert.ToInt16(txtScoreMin.Text);
            paramsEnrollmentProcessing.AFACE_PARAMETER_SCORE_MAX = Convert.ToInt16(txtScoreMax.Text);
            paramsEnrollmentProcessing.AFACE_PARAMETER_ENROLL = cboRegisterUser.SelectedIndex;
            /////////
            paramsEnrollmentProcessing.CFG_SIMILARITY_THRESHOLD_DEDUPLICATION = Convert.ToInt16(txtSimilarityThreshold.Text);
            paramsEnrollmentProcessing.AFACE_PARAMETER_DEDUPLICATION = cboDeduplicate.SelectedIndex;
            paramsEnrollmentProcessing.AFACE_PARAMETER_CONCATENATE_TEMPLATES = cboConcatenateTemplates.SelectedIndex;
            paramsEnrollmentProcessing.AFACE_PARAMETER_MAXIMUM_TEMPLATES = Convert.ToInt16(txtMaximumTemplates.Text);
            paramsEnrollmentProcessing.AFACE_PARAMETER_CONCATENATION_MODE = cboModeConcatenation.SelectedIndex;
            paramsEnrollmentProcessing.AFACE_PARAMETER_VERIFICATION_SCORE = Convert.ToInt16(txtVerificationScoreThreshold.Text);

            configurationPipeline.paramsEnrollmentProcessing = paramsEnrollmentProcessing;
            configurationPipeline.configurationFlowVideo = "Flow video";
            ParamsFlow paramsFlow = new ParamsFlow();
            if (rbTypeChannelIP.Checked == true)
            {
                paramsFlow.deviceVideo = string.Empty;
                paramsFlow.fileVideo = string.Empty;
                paramsFlow.ipCamera = txtDescriptionChannel.Text;
                paramsFlow.sourceFlow = 1;
            }
            if (rbTypeChannelFile.Checked == true)
            {
                paramsFlow.deviceVideo = string.Empty;
                paramsFlow.fileVideo = txtDescriptionChannel.Text;
                paramsFlow.ipCamera = string.Empty;
                paramsFlow.sourceFlow = 2;
            }

            if (rbTypeChannelDevice.Checked == true)
            {
                paramsFlow.deviceVideo = txtDescriptionChannel.Text;
                paramsFlow.fileVideo = string.Empty;
                paramsFlow.ipCamera = string.Empty;
                paramsFlow.sourceFlow = 3;
            }
            paramsFlow.videoScaleMethod = 1;
            configurationPipeline.paramsFlow = paramsFlow;

            diskPresenter.SaveConfigurationPipe(channel, configurationPipeline);
            
            if (channel > Configuration.Instance.NumberChannels)
            {
                registryValueDataReader.setKeyValueRegistry(RegistryValueDataReader.PATH_KEY,
                        RegistryValueDataReader.NUM_CHANNELS_KEY, Convert.ToString(channel));
                Configuration.Instance.NumberChannels = channel;
            }

            diskPresenter.GenerateListChannels();

            return true;
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

        private void txtRedetectTimeDelta_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtDetectionThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtScoreMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtScoreMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void btnSaveGlobalParameters_Click(object sender, EventArgs e)
        {
            ConfigurationGlobalLib configurationGlobalLib = new ConfigurationGlobalLib();
            ParamsGlobal paramsGlobal = new ParamsGlobal();
            paramsGlobal.GLOBAL_MIN_VALID_IMAGE_SIZE = Convert.ToInt16(txtGBMinImage.Text);
            paramsGlobal.GLOBAL_THREAD_MANAGEMENT_MODE = cboGBThreadMode.SelectedIndex;
            paramsGlobal.GLOBAL_THREAD_NUM = txtGBThreadNum.Text;
            paramsGlobal.GLOBAL_CFG_LOG_LEVEL = Convert.ToInt16(txtGBLogLevel.Text);
            paramsGlobal.AFACE_PARAMETER_GPU_ENABLED = cboGBEnabledConfigurationGPU.SelectedIndex;
            paramsGlobal.GLOBAL_GPU_DEVICE_ID = txtGBGpuDevice.Text;
            paramsGlobal.GLOBAL_GPU_ENABLED = cboGBGpuEnabled.SelectedText;
            configurationGlobalLib.paramsGlobal = paramsGlobal;
            diskPresenter.SaveGlobalConfiguration(configurationGlobalLib);

            managerControlView.SetValueTextStatusStrip(ManagerResource
                   .Instance.resourceManager
                       .GetString("save_ok"),
                       0, this.status);
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void txtBestMatched_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtASimilarity_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtMaxDetect_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtSimilarityThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void cboModeConcatenation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == 0)
            {
                txtScoreMin.ReadOnly = false;
                txtScoreMax.ReadOnly = false;
            }
            else
            {
                txtScoreMin.ReadOnly = true;
                txtScoreMax.ReadOnly = true;
            }
        }

        private void cboConcatenateTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == 1)
            {
                cboModeConcatenation.SelectedIndex = 0;
                cboModeConcatenation.Enabled = true;
            }
            else
            {
                cboModeConcatenation.SelectedIndex = 1;
                cboModeConcatenation.Enabled = false;
            }
        }

        private void txtModelQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtMaximumTemplates_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtVerificationScoreThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.managerControlView.OnlyInteger(e);
        }

        private void txtAccurancy_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(), 
                out errorMsg, 0, 10000))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtAccurancy.SetError((sender as TextBox), errorMsg);
            }
        }

        private bool ValidValueInput(string inputData, out string errorMessage, int limLower, int limHigher)
        {
            int input = -1;

            if (string.IsNullOrEmpty(inputData))
            {
                errorMessage = ManagerResource.Instance.resourceManager
                    .GetString("empty_data");
                return false;
            }
            else
            {
                input = Convert.ToInt16(inputData);
            }

            if (input <= limHigher && input >= limLower)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = ManagerResource.Instance.resourceManager
                    .GetString("number_out_range");
                return false;
            }
                                
        }

        private void txtAccurancy_Validated(object sender, EventArgs e)
        {
            valueErrortxtAccurancy.SetError((sender as TextBox), "");
        }

        private void txtModelQuality_Validated(object sender, EventArgs e)
        {
            valueErrortxtModelQuality.SetError((sender as TextBox), "");
        }

        private void txtModelQuality_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 1, 255))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtModelQuality.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtRefreshTrack_Validated(object sender, EventArgs e)
        {
            valueErrortxtRefreshTrack.SetError((sender as TextBox), "");
        }

        private void txtRefreshTrack_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 100, 3000))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtRefreshTrack.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtRedetectTimeDelta_Validated(object sender, EventArgs e)
        {
            valueErrortxtRedetectTimeDelta.SetError((sender as TextBox), "");
        }

        private void txtRedetectTimeDelta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 0, 10000))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtRedetectTimeDelta.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtDetectionThreshold_Validated(object sender, EventArgs e)
        {
            valueErrortxtDetectionThreshold.SetError((sender as TextBox), "");
        }

        private void txtDetectionThreshold_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 1, 10000))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtDetectionThreshold.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtSimilarityThreshold_Validated(object sender, EventArgs e)
        {
            valueErrortxtSimilarityThreshold.SetError((sender as TextBox), "");
        }

        private void txtSimilarityThreshold_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 0, 1000))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtSimilarityThreshold.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtScoreMin_Validated(object sender, EventArgs e)
        {
            valueErrortxtScoreMin.SetError((sender as TextBox), "");
        }

        private void txtScoreMin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 0, 100))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtScoreMin.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtScoreMax_Validated(object sender, EventArgs e)
        {
            valueErrortxtScoreMax.SetError((sender as TextBox), "");
        }

        private void txtScoreMax_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 0, 100))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtScoreMax.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtASimilarity_Validated(object sender, EventArgs e)
        {
            valueErrortxtASimilarity.SetError((sender as TextBox), "");
        }

        private void txtASimilarity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 0, 1000))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtASimilarity.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtBestMatched_Validated(object sender, EventArgs e)
        {
            valueErrortxtBestMatched.SetError((sender as TextBox), "");
        }

        private void txtBestMatched_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 1, 5))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtBestMatched.SetError((sender as TextBox), errorMsg);
            }
        }

        private void txtMaxDetect_Validated(object sender, EventArgs e)
        {
            valueErrortxtMaxDetect.SetError((sender as TextBox), "");
        }

        private void txtMaxDetect_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidValueInput((sender as TextBox).Text.ToString(),
                out errorMsg, 1, 5))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.valueErrortxtMaxDetect.SetError((sender as TextBox), errorMsg);
            }
        }
    }
}
