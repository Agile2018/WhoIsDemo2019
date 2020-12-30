using System.Collections.Generic;

namespace WhoIsDemo.model
{
    public class Configuration
    {
        #region constants
        //public const int templateHeight = 400;
        //public const int templateWidth = 640;
        //public const float scalingFontSize = 0.4f;
        //public const float incrementHeight = 20;
        public const int VIDEO_TYPE_CAMERA = 3;
        public const int VIDEO_TYPE_IP = 1;
        public const int VIDEO_TYPE_FILE = 2;
        //public const string DESC_TYPE_CAMERA = "CAM";
        //public const string DESC_TYPE_IP = "IP";
        //public const string DESC_TYPE_FILE = "FILE";
        #endregion
        #region variables
        private int channelSelected = -1;
        private static readonly Configuration instance = new Configuration();
        public static Configuration Instance => instance;
        public string ConnectDatabase { get => connectDatabase; set => connectDatabase = value; }
        public string NameDatabase { get => nameDatabase; set => nameDatabase = value; }
       
        public List<int> ListTimeRefreshEntryControl { get => listTimeRefreshEntryControl; set => listTimeRefreshEntryControl = value; }
        public int TimeRefreshEntryControl { get => timeRefreshEntryControl; set => timeRefreshEntryControl = value; }
        
        public int NumberChannels { get => numberChannels; set => numberChannels = value; }
        public List<Channel> Channels { get => channels; set => channels = value; }
        public bool IsShowWindow { get => isShowWindow; set => isShowWindow = value; }
        public int NumberWindowsShow { get => numberWindowsShow; set => numberWindowsShow = value; }
        public int ChannelSelected { get => channelSelected; set => channelSelected = value; }

        private List<Channel> channels = new List<Channel>();
        
        private List<int> listTimeRefreshEntryControl = new List<int>();
        private int timeRefreshEntryControl = 0; 
        
        private string connectDatabase;
        private string nameDatabase;
        
        private int numberChannels = 0;
        private bool isShowWindow = false;
        private int numberWindowsShow = 0;
        private Dictionary<int, int> taskRunning = new Dictionary<int, int>();
        #endregion

        #region constants

        #endregion

        #region methods
        public Configuration()
        {
            
            ListTimeRefreshEntryControl.Add(0);
            ListTimeRefreshEntryControl.Add(1);
            ListTimeRefreshEntryControl.Add(5);
            ListTimeRefreshEntryControl.Add(10);
            ListTimeRefreshEntryControl.Add(15);
            ListTimeRefreshEntryControl.Add(20);
            ListTimeRefreshEntryControl.Add(25);
            ListTimeRefreshEntryControl.Add(30);

        }        

        private void TurnOffControlEntry(int index)
        {
            int channel = index + 1;
            if (channels[index].task == 0)
            {
                AipuFace.Instance.SetChannel(channel);
                int task = AipuFace.Instance.GetTaskIdentify();
                taskRunning.Add(channel, task);
                AipuFace.Instance.SetTaskIdentify(-1, channel);
            }
        }

        public void SynchronizeDatabaseFace()
        {
                       
            if (isShowWindow)
            {
                switch (numberWindowsShow)
                {
                    case 1:
                        TurnOffControlEntry(0);
                       
                        break;
                    case 2:
                        TurnOffControlEntry(0);
                        TurnOffControlEntry(1);
                        
                        break;
                    case 3:
                        TurnOffControlEntry(0);
                        TurnOffControlEntry(1);
                        TurnOffControlEntry(2);
                        
                        break;
                    case 4:
                        TurnOffControlEntry(0);
                        TurnOffControlEntry(1);
                        TurnOffControlEntry(2);
                        TurnOffControlEntry(3);
                        
                        break;
                    default:
                        break;
                }

                foreach (KeyValuePair<int, int> kvp in taskRunning)
                {
                    AipuFace.Instance.CloseConnectionIdentification(kvp.Key);
                    
                }

                foreach (KeyValuePair<int, int> kvp in taskRunning)
                {
                    AipuFace.Instance.LoadConnectionIdentification(kvp.Key);

                }

                foreach (KeyValuePair<int, int> kvp in taskRunning)
                {
                    AipuFace.Instance.SetTaskIdentify(kvp.Value, kvp.Key);

                }


            }
            int currentChannels = numberChannels + 1;
            if (taskRunning.Count == 0)
            {                
                for (int i = 1; i < currentChannels + 1; i++)
                {
                    AipuFace.Instance.CloseConnectionIdentification(i);
                }
                for (int i = 1; i < currentChannels + 1; i++)
                {
                    AipuFace.Instance.LoadConnectionIdentification(i);
                }
            }
            else
            {
                for (int i = 1; i < currentChannels + 1; i++)
                {
                    if (!taskRunning.ContainsKey(i))
                    {
                        AipuFace.Instance.CloseConnectionIdentification(i);
                    }
                   
                }
                for (int i = 1; i < currentChannels + 1; i++)
                {
                    if (!taskRunning.ContainsKey(i))
                    {
                        AipuFace.Instance.LoadConnectionIdentification(i);
                    }
                   
                }
            }
            taskRunning.Clear();
        }

        #endregion

    }
}
