using System;
using System.Windows.Forms;
using WhoIsDemo.model;
using WhoIsDemo.view.tool;

namespace WhoIsDemo.form
{
    public partial class frmManagerChannels : Form
    {
        #region constants

        #endregion

        #region variables
        public string strNameMenu;
        private int numberWindow = 1;
        ManagerControlView managerControlView = new ManagerControlView();
        #endregion
        public frmManagerChannels()
        {
            InitializeComponent();
        }

        private void EnableChannels()
        {
            switch (Configuration.Instance.NumberChannels)
            {
                case 0:
                    gbChannel1.Enabled = true;
                    rbOne.Enabled = true;
                    rbOne.Checked = true;
                    lblRegisterChannel1.Text = (Configuration.Instance.Channels[0].task == 0 ? 
                        "Entry control" : "Enrollment");
                    break;
                case 1:
                    gbChannel1.Enabled = true;
                    gbChannel2.Enabled = true;
                    rbOne.Enabled = true;
                    rbOne.Checked = true;
                    rbTwo.Enabled = true;
                    lblRegisterChannel1.Text = (Configuration.Instance.Channels[0].task == 0 ?
                        "Entry control" : "Enrollment");
                    lblRegisterChannel2.Text = (Configuration.Instance.Channels[1].task == 0 ?
                        "Entry control" : "Enrollment");
                    break;
                case 2:
                    gbChannel1.Enabled = true;
                    gbChannel2.Enabled = true;
                    gbChannel3.Enabled = true;
                    rbOne.Enabled = true;
                    rbOne.Checked = true;
                    rbTwo.Enabled = true;
                    rbThree.Enabled = true;
                    lblRegisterChannel1.Text = (Configuration.Instance.Channels[0].task == 0 ?
                        "Entry control" : "Enrollment");
                    lblRegisterChannel2.Text = (Configuration.Instance.Channels[1].task == 0 ?
                        "Entry control" : "Enrollment");
                    lblRegisterChannel3.Text = (Configuration.Instance.Channels[2].task == 0 ?
                        "Entry control" : "Enrollment");
                    break;
                case 3:
                    gbChannel1.Enabled = true;
                    gbChannel2.Enabled = true;
                    gbChannel3.Enabled = true;
                    gbChannel4.Enabled = true;
                    rbOne.Enabled = true;
                    rbOne.Checked = true;
                    rbTwo.Enabled = true;
                    rbThree.Enabled = true;
                    rbFour.Enabled = true;
                    lblRegisterChannel1.Text = (Configuration.Instance.Channels[0].task == 0 ?
                        "Entry control" : "Enrollment");
                    lblRegisterChannel2.Text = (Configuration.Instance.Channels[1].task == 0 ?
                        "Entry control" : "Enrollment");
                    lblRegisterChannel3.Text = (Configuration.Instance.Channels[2].task == 0 ?
                        "Entry control" : "Enrollment");
                    lblRegisterChannel4.Text = (Configuration.Instance.Channels[3].task == 0 ?
                        "Entry control" : "Enrollment");
                    break;

                default:
                    break;
            }
        }

        private void frmManagerChannels_Load(object sender, EventArgs e)
        {
            EnableChannels();
            EnablePanelControlVideo();
        }

        private void EnableStateButton()
        {
            for (int i = 0; i < Configuration.Instance.Channels.Count; i++)
            {
                if (Configuration.Instance.Channels[i].flow == 0)
                {
                    switch (i)
                    {
                        case 0:
                            btnPlay1.Enabled = false;
                            btnPause1.Enabled = true;
                            break;
                        case 1:
                            btnPlay2.Enabled = false;
                            btnPause2.Enabled = true;
                            break;
                        case 2:
                            btnPlay3.Enabled = false;
                            btnPause3.Enabled = true;
                            break;
                        case 3:
                            btnPlay4.Enabled = false;
                            btnPause4.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            btnPlay1.Enabled = true;
                            btnPause1.Enabled = false;
                            break;
                        case 1:
                            btnPlay2.Enabled = true;
                            btnPause2.Enabled = false;
                            break;
                        case 2:
                            btnPlay3.Enabled = true;
                            btnPause3.Enabled = false;
                            break;
                        case 3:
                            btnPlay4.Enabled = true;
                            btnPause4.Enabled = false;
                            break;
                        default:
                            break;
                    }
                }

                if (Configuration.Instance.Channels[i].loop == 0)
                {
                    switch (i)
                    {
                        case 0:
                            btnRunFlow1.Enabled = false;
                            btnQuitLoop1.Enabled = true;
                            break;
                        case 1:
                            btnRunFlow2.Enabled = false;
                            btnQuitLoop2.Enabled = true;
                            break;
                        case 2:
                            btnRunFlow3.Enabled = false;
                            btnQuitLoop3.Enabled = true;
                            break;
                        case 3:
                            btnRunFlow4.Enabled = false;
                            btnQuitLoop4.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            btnRunFlow1.Enabled = true;
                            btnQuitLoop1.Enabled = false;
                            panel1Channel1.Enabled = false;
                            break;
                        case 1:
                            btnRunFlow2.Enabled = true;
                            btnQuitLoop2.Enabled = false;
                            panel1Channel2.Enabled = false;
                            break;
                        case 2:
                            btnRunFlow3.Enabled = true;
                            btnQuitLoop3.Enabled = false;
                            panel1Channel3.Enabled = false;
                            break;
                        case 3:
                            btnRunFlow4.Enabled = true;
                            btnQuitLoop4.Enabled = false;
                            panel1Channel4.Enabled = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void EnablePanelControlVideo()
        {
            if (Configuration.Instance.IsShowWindow)
            {
                btnPlayAll.Enabled = false;
                switch (Configuration.Instance.NumberWindowsShow)
                {
                    case 1:
                        rbOne.Checked = true;
                        panel1Channel1.Enabled = true;
                        panel2Channel1.Enabled = true;
                        break;
                    case 2:
                        rbTwo.Checked = true;
                        panel1Channel1.Enabled = true;
                        panel2Channel1.Enabled = true;
                        panel1Channel2.Enabled = true;
                        panel2Channel2.Enabled = true;
                        break;
                    case 3:
                        rbThree.Checked = true;
                        panel1Channel1.Enabled = true;
                        panel2Channel1.Enabled = true;
                        panel1Channel2.Enabled = true;
                        panel2Channel2.Enabled = true;
                        panel1Channel3.Enabled = true;
                        panel2Channel3.Enabled = true;
                        //if (gbChannel4.Enabled)
                        //{
                        //    panel1Channel4.Enabled = true;
                        //}
                        break;
                    case 4:
                        rbFour.Checked = true;
                        panel1Channel1.Enabled = true;
                        panel2Channel1.Enabled = true;
                        panel1Channel2.Enabled = true;
                        panel2Channel2.Enabled = true;
                        panel1Channel3.Enabled = true;
                        panel2Channel3.Enabled = true;
                        panel1Channel4.Enabled = true;
                        panel2Channel4.Enabled = true;
                        break;
                    default:
                        break;
                }

                EnableStateButton();
            }
        }

        private void rbOne_Click(object sender, EventArgs e)
        {
            numberWindow = 1;
        }

        private void rbTwo_Click(object sender, EventArgs e)
        {
            numberWindow = 2;
        }

        private void rbThree_Click(object sender, EventArgs e)
        {
            numberWindow = 3;
        }

        private void btnPlayAll_Click(object sender, EventArgs e)
        {
            
            Configuration.Instance.IsShowWindow = true;
            Configuration.Instance.NumberWindowsShow = numberWindow;
            SetStateButtonChannel();
            ThrowChannels();
            //Thread videoThread = new Thread(new ThreadStart(ThrowChannels));
            //videoThread.Priority = ThreadPriority.AboveNormal;
            //videoThread.Start();
            //videoThread.Abort();
        }

        private void SetStateButtonChannel()
        {
            switch (Configuration.Instance.NumberWindowsShow)
            {
                case 1:
                    Configuration.Instance.Channels[0].flow = 0;
                    Configuration.Instance.Channels[0].loop = 0;                    
                    break;
                case 2:
                    Configuration.Instance.Channels[0].flow = 0;
                    Configuration.Instance.Channels[0].loop = 0;
                    Configuration.Instance.Channels[1].flow = 0;
                    Configuration.Instance.Channels[1].loop = 0;
                    break;
                case 3:
                    Configuration.Instance.Channels[0].flow = 0;
                    Configuration.Instance.Channels[0].loop = 0;
                    Configuration.Instance.Channels[1].flow = 0;
                    Configuration.Instance.Channels[1].loop = 0;
                    Configuration.Instance.Channels[2].flow = 0;
                    Configuration.Instance.Channels[2].loop = 0;
                    break;
                case 4:
                    Configuration.Instance.Channels[0].flow = 0;
                    Configuration.Instance.Channels[0].loop = 0;
                    Configuration.Instance.Channels[1].flow = 0;
                    Configuration.Instance.Channels[1].loop = 0;
                    Configuration.Instance.Channels[2].flow = 0;
                    Configuration.Instance.Channels[2].loop = 0;
                    Configuration.Instance.Channels[3].flow = 0;
                    Configuration.Instance.Channels[3].loop = 0;
                    break;
                default:
                    break;
            }
        }

        private void ThrowChannels()
        {
            AipuFace.Instance.LoadConfiguration(numberWindow);
            AipuFace.Instance.InitWindowMain(numberWindow);
            AipuFace.Instance.RunVideo(numberWindow);
        }

        private void frmManagerChannels_FormClosing(object sender, FormClosingEventArgs e)
        {
            managerControlView.EnabledOptionMenu(strNameMenu, mdiMain.NAME);
            managerControlView.EnabledOptionMenu("configuraciónToolStripMenuItem", mdiMain.NAME);
        }

        private void btnPlay1_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.StatePlay(1);
            btnPlay1.Enabled = false;
            btnPause1.Enabled = true;
            Configuration.Instance.Channels[0].flow = 0;
        }

        private void btnPause1_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.StatePaused(1);
            btnPlay1.Enabled = true;
            btnPause1.Enabled = false;
            Configuration.Instance.Channels[0].flow = 1;
        }

        private void rbFour_Click(object sender, EventArgs e)
        {
            numberWindow = 4;
        }

        private void btnPlay2_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.StatePlay(2);
            btnPlay2.Enabled = false;
            btnPause2.Enabled = true;
            Configuration.Instance.Channels[1].flow = 0;
        }

        private void btnPause2_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.StatePaused(2);
            btnPlay1.Enabled = true;
            btnPause2.Enabled = false;
            Configuration.Instance.Channels[1].flow = 1;
        }

        private void btnPlay3_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.StatePlay(3);
            btnPlay3.Enabled = false;
            btnPause3.Enabled = true;
            Configuration.Instance.Channels[2].flow = 0;
        }

        private void btnPause3_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.StatePaused(3);
            btnPlay3.Enabled = true;
            btnPause3.Enabled = false;
            Configuration.Instance.Channels[2].flow = 1;
        }

        private void btnPlay4_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.StatePlay(4);
            btnPlay4.Enabled = false;
            btnPause4.Enabled = true;
            Configuration.Instance.Channels[3].flow = 0;
        }

        private void btnPause4_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.StatePaused(4);
            btnPlay4.Enabled = true;
            btnPause4.Enabled = false;
            Configuration.Instance.Channels[3].flow = 1;
        }

        private void btnQuitLoop1_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.SetFinishLoop(1);
            btnRunFlow1.Enabled = true;
            btnQuitLoop1.Enabled = false;
            Configuration.Instance.Channels[0].loop = 1;
            panel1Channel1.Enabled = false;
        }

        private void btnQuitLoop2_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.SetFinishLoop(2);
            btnRunFlow2.Enabled = true;
            btnQuitLoop2.Enabled = false;
            Configuration.Instance.Channels[1].loop = 1;
            panel1Channel2.Enabled = false;
        }

        private void btnQuitLoop3_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.SetFinishLoop(3);
            btnRunFlow3.Enabled = true;
            btnQuitLoop3.Enabled = false;
            Configuration.Instance.Channels[2].loop = 1;
            panel1Channel3.Enabled = false;
        }

        private void btnQuitLoop4_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.SetFinishLoop(4);
            btnRunFlow4.Enabled = true;
            btnQuitLoop4.Enabled = false;
            Configuration.Instance.Channels[3].loop = 1;
            panel1Channel4.Enabled = false;
        }

        private void btnRunFlow1_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.ReRunVideo(1);
            btnRunFlow1.Enabled = false;
            btnQuitLoop1.Enabled = true;
            Configuration.Instance.Channels[0].loop = 0;

            Configuration.Instance.Channels[0].flow = 0;
            panel1Channel1.Enabled = true;
            btnPlay1.Enabled = false;
            btnPause1.Enabled = true;
        }

        private void btnRunFlow2_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.ReRunVideo(2);
            btnRunFlow2.Enabled = false;
            btnQuitLoop2.Enabled = true;
            Configuration.Instance.Channels[1].loop = 0;
            Configuration.Instance.Channels[1].flow = 0;
            panel1Channel2.Enabled = true;
            btnPlay2.Enabled = false;
            btnPause2.Enabled = true;
        }

        private void btnRunFlow3_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.ReRunVideo(3);
            btnRunFlow3.Enabled = false;
            btnQuitLoop3.Enabled = true;
            Configuration.Instance.Channels[2].loop = 0;
            Configuration.Instance.Channels[2].flow = 0;
            panel1Channel3.Enabled = true;
            btnPlay3.Enabled = false;
            btnPause3.Enabled = true;
        }

        private void btnRunFlow4_Click(object sender, EventArgs e)
        {
            AipuFace.Instance.ReRunVideo(4);
            btnRunFlow4.Enabled = false;
            btnQuitLoop4.Enabled = true;
            Configuration.Instance.Channels[3].loop = 0;
            Configuration.Instance.Channels[3].flow = 0;
            panel1Channel4.Enabled = true;
            btnPlay4.Enabled = false;
            btnPause4.Enabled = true;
        }
      
    }
}
