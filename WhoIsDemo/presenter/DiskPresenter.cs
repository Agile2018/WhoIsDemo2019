using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;
using WhoIsDemo.repository;

namespace WhoIsDemo.presenter
{
    class DiskPresenter
    {
        #region constants
        public const string directoryTemp = "temp";
        public const string files_configuration = "files_configuration";
        public const string directory_train = "train";
        public const string directory_work = "camera";

        public const string file_database = "database.txt";
        public const string file_face = "detect.txt";
        public const string file_tracking = "tracking.txt";
        public const string file_identify = "identify.txt";
        public const string file_flow = "flow.txt";
        public const string file_performance = "performance.txt";
        public const string directory = "directory.txt";

        public const string file_video = "video.txt";                
        public const string file_list_images = "images_temp.txt";

        #endregion

        #region variables
        Disk disk = new Disk();
        private List<string> directoryConfiguration = new List<string>()
        {
            "configuration",
            "configuration1",
            "configuration2",
            "configuration3"
        };
        #endregion

        #region methods
        public DiskPresenter() { }

        public void FileDelete(string stringPath)
        {
            try
            {
                disk.FileDelete(stringPath);

            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public void SaveDetectConfiguration(int channel, Detect detect)
        {
            
            try
            {
                string jsonOut = JsonConvert.SerializeObject(detect);
                string pathFile = directoryConfiguration[channel] + "/" + file_face;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public void SaveTrackingConfiguration(int channel, Tracking tracking)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(tracking);
                string pathFile = directoryConfiguration[channel] + "/" + file_tracking;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public void SaveFlowConfiguration(int channel, Flow flow)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(flow);
                string pathFile = directoryConfiguration[channel] + "/" + file_flow;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public void WriteFileOfFiles(string[] content)
        {
            try
            {                
                string pathFile = directoryTemp + "/" + file_list_images;
                disk.WriteFileOfFiles(pathFile, content);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public void SaveIdentifyConfiguration(int channel, Identify identify)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(identify);
                string pathFile = directoryConfiguration[channel] + "/" + file_identify;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public Detect ReadDetectConfiguration(int channel)
        {
            Detect detect = new Detect();
            try
            {
                string pathFile = directoryConfiguration[channel] + "/" + file_face;
                string content = disk.ReadTextFile(pathFile);
                detect = JsonConvert.DeserializeObject<Detect>(content);
                
            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return detect;
        }

        public Identify ReadIdentifyConfiguration(int channel)
        {
            Identify identify = new Identify();
            try
            {
                string pathFile = directoryConfiguration[channel] + "/" + file_identify;
                string content = disk.ReadTextFile(pathFile);
                identify = JsonConvert.DeserializeObject<Identify>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return identify;
        }

        public Tracking ReadTrackingConfiguration(int channel)
        {
            Tracking tracking = new Tracking();
            try
            {
                string pathFile = directoryConfiguration[channel] + "/" + file_tracking;
                string content = disk.ReadTextFile(pathFile);
                tracking = JsonConvert.DeserializeObject<Tracking>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tracking;
        }

        public Flow ReadFlowConfiguration(int channel)
        {
            Flow flow = new Flow();
            try
            {
                string pathFile = directoryConfiguration[channel] + "/" + file_flow;
                string content = disk.ReadTextFile(pathFile);
                flow = JsonConvert.DeserializeObject<Flow>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flow;
        }

        public PerformanceRecognition ReadPerformance(int channel)
        {
            PerformanceRecognition performanceRecognition = new PerformanceRecognition();
            try
            {
                string pathFile = directoryConfiguration[channel] + "/" + file_performance;
                string content = disk.ReadTextFile(pathFile);
                performanceRecognition = JsonConvert.DeserializeObject<PerformanceRecognition>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return performanceRecognition;
        }
        //public void SaveVideoConfiguration(VideoConfig videoConfig)
        //{

        //    try
        //    {
        //        string jsonOut = JsonConvert.SerializeObject(videoConfig);
        //        string pathFile = directoryConfiguration + "/" + file_video;
        //        disk.WriteFile(pathFile, jsonOut);

        //    }
        //    catch (System.IO.IOException e)
        //    {
        //        Console.WriteLine(e.Message);

        //    }

        //}

        //public List<Video> ReadListVideo()
        //{
        //    VideoConfig videoConfig = new VideoConfig();
        //    List<Video> list = new List<Video>();

        //    try
        //    {
        //        string pathFile = directoryConfiguration + "/" + file_video;
        //        string content = disk.ReadTextFile(pathFile);
        //        videoConfig = JsonConvert.DeserializeObject<VideoConfig>(content);
        //        list = videoConfig.videos;
        //    }
        //    catch (System.IO.FileNotFoundException e)
        //    {

        //        Console.WriteLine(e.Message);
        //    }
        //    catch (Newtonsoft.Json.JsonReaderException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    catch(System.NullReferenceException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return list;
        //}
        //public VideoConfig ReadVideoConfiguration()
        //{
        //    VideoConfig videoConfig = new VideoConfig();
        //    try
        //    {
        //        string pathFile = directoryConfiguration + "/" + file_video;
        //        string content = disk.ReadTextFile(pathFile);
        //        videoConfig = JsonConvert.DeserializeObject<VideoConfig>(content);

        //    }
        //    catch (System.IO.FileNotFoundException e)
        //    {

        //        Console.WriteLine(e.Message);
        //    }
        //    catch (Newtonsoft.Json.JsonReaderException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return videoConfig;
        //}

        public void SaveDatabaseConfiguration(int channel, DatabaseConfig databaseConfig)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(databaseConfig);
                string pathFile = directoryConfiguration[channel] + "/" + file_database;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public DatabaseConfig ReadDatabaseConfiguration(int channel)
        {
            DatabaseConfig databaseConfig = new DatabaseConfig();
            try
            {
                string pathFile = directoryConfiguration[channel] + "/" + file_database;
                string content = disk.ReadTextFile(pathFile);
                databaseConfig = JsonConvert.DeserializeObject<DatabaseConfig>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return databaseConfig;
        }

        public void CreateDirectoryWork(int channel)
        {
            disk.CreateWorkDirectory(directoryConfiguration[channel]);
        }

        public bool VerifyFileOfConfiguration(int channel)
        {
            string pathFile = directoryConfiguration[channel] + "/" + directory;
            return disk.IsFileExists(pathFile);
        }
        public void CreateContentDirectoryWork(int channel)
        {
            FileConfiguration fileConfiguration = new FileConfiguration();
            fileConfiguration.configuration = files_configuration;
            ParamsFile paramsFile = new ParamsFile();
            //paramsFile.directory_train = directory_train;
            //paramsFile.directory_work = directory_work;
            paramsFile.file_database = file_database;
            paramsFile.file_face = file_face;
            paramsFile.file_flow = file_flow;
            paramsFile.file_identify = file_identify;
            paramsFile.file_tracking = file_tracking;
            fileConfiguration.Params = paramsFile;
            try
            {
                string jsonOut = JsonConvert.SerializeObject(fileConfiguration);
                string pathFile = directoryConfiguration[channel] + "/" + directory;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public void GenerateListChannels()
        {
            Configuration.Instance.Channels.Clear();
            int lim = Configuration.Instance.NumberChannels + 1;
            for (int i = 0; i < lim; i++)
            {
                Channel channel = new Channel();
                channel.id = i;
                Identify identify = ReadIdentifyConfiguration(i);
                channel.task = identify.Params.is_register;
                Configuration.Instance.Channels.Add(channel);
            }
        }
        #endregion
    }
}
