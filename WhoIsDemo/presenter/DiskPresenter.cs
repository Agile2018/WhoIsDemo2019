using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WhoIsDemo.model;
using WhoIsDemo.repository;

namespace WhoIsDemo.presenter
{
    class DiskPresenter
    {
        #region constants
        public const string directoryTemp = "temp";
        
        public const string folder_configuration = "configuration";


        public const string file_database = "database.txt";
        public const string file_global_params = "global.txt";
        
        public const string file_performance = "performance.txt";
                       
        public const string file_list_images = "images_temp.txt";

        #endregion

        #region variables
        Disk disk = new Disk();
        

        private List<string> filesConfiguration = new List<string>()
        {
            
            "configPipeOne.txt",
            "configPipeTwo.txt",
            "configPipeThree.txt",
            "configPipeFour.txt"
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

        public void SaveConfigurationPipe(int channel, ConfigurationPipeline config)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(config);
                string pathFile = folder_configuration + "/" + filesConfiguration[channel];
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }
        public void SaveGlobalConfiguration(ConfigurationGlobalLib configurationGlobalLib)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(configurationGlobalLib);
                string pathFile = folder_configuration + "/" + file_global_params;
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
             

        public ConfigurationPipeline ReadConfigurationPipe(int channel)
        {
            ConfigurationPipeline configurationPipeline = new ConfigurationPipeline();
            try
            {
                string pathFile = folder_configuration + "/" + filesConfiguration[channel];
                string content = disk.ReadTextFile(pathFile);
                configurationPipeline = JsonConvert.DeserializeObject<ConfigurationPipeline>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return configurationPipeline;

        }                       


        public void SaveDatabaseConfiguration(DatabaseConfig databaseConfig)
        {

            try
            {
                string jsonOut = JsonConvert.SerializeObject(databaseConfig);
                string pathFile = folder_configuration + "/" + file_database;
                disk.WriteFile(pathFile, jsonOut);

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public ConfigurationGlobalLib ReadGlobalParameters()
        {
            ConfigurationGlobalLib configurationGlobalLib = new ConfigurationGlobalLib();
            try
            {
                string pathFile = folder_configuration + "/" + file_global_params;
                string content = disk.ReadTextFile(pathFile);
                configurationGlobalLib = JsonConvert.DeserializeObject<ConfigurationGlobalLib>(content);

            }
            catch (System.IO.FileNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return configurationGlobalLib;
        }
        public DatabaseConfig ReadDatabaseConfiguration()
        {
            DatabaseConfig databaseConfig = new DatabaseConfig();
            try
            {
                string pathFile = folder_configuration + "/" + file_database;
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

        public void CreateDirectoryWork()
        {
            disk.CreateWorkDirectory(folder_configuration);
            //directoryConfiguration[channel]
        }

        public bool VerifyFileOfConfiguration(int channel)
        {
            
            string pathFile = string.Empty;
            switch (channel)
            {
                case 0:
                    pathFile = folder_configuration + "/" + filesConfiguration[channel];
                    break;
                case 1:
                    pathFile = folder_configuration + "/" + filesConfiguration[channel];
                    break;
                case 2:
                    pathFile = folder_configuration + "/" + filesConfiguration[channel];
                    break;
                case 3:
                    pathFile = folder_configuration + "/" + filesConfiguration[channel];
                    break;
                default:
                    break;
            }
            
            return disk.IsFileExists(pathFile);

        }
        

        public void GenerateListChannels()
        {
            if (Configuration.Instance.Channels.Count == 0)
            {
                int news = Configuration.Instance.NumberChannels + 1;
                AddNewsChannels(news);
            }
            else
            {
                int news = (Configuration.Instance.NumberChannels + 1) - 
                    Configuration.Instance.Channels.Count;
                AddNewsChannels(news);
                UpdateChannels();
            }
            //int currentChannels = Configuration.Instance.NumberChannels + 1;
            //AipuFace.Instance.SetNumberPipelines(currentChannels);

            
        }        

        private void AddNewsChannels(int news)
        {
            for (int i = 0; i < news; i++)
            {
                Channel channel = new Channel();
                channel.id = i;                
                ConfigurationPipeline configurationPipeline = ReadConfigurationPipe(i);
                
                if (configurationPipeline != null)
                {
                    channel.task = configurationPipeline
                    .paramsEnrollmentProcessing.AFACE_PARAMETER_ENROLL;
                    Configuration.Instance.Channels.Add(channel);
                }
                else
                {
                    break;
                }
                
            }
        }

        private void UpdateChannels()
        {
            for (int i = 0; i < Configuration.Instance.Channels.Count; i++)
            {
                
                ConfigurationPipeline configurationPipeline = ReadConfigurationPipe(i);
                Configuration.Instance.Channels[i].task = configurationPipeline
                    .paramsEnrollmentProcessing.AFACE_PARAMETER_ENROLL;
            }
        }

        #endregion
    }
}
