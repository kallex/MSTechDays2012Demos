using System;
using System.IO;
using System.Xml.Serialization;

namespace PresentationTracker
{
    [Serializable]
    [XmlRoot]
    public class UserSpecificConfig
    {
        public static readonly string DefaultFileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PresentationTracker.config";
        public bool IsValidated
        {
            get { return String.IsNullOrEmpty(AccessSecret) && String.IsNullOrEmpty(AccessToken); }
        }

        public static UserSpecificConfig OpenOrCreate(string configFileName)
        {
            if(File.Exists(configFileName) == false)
                return Create(configFileName);
            using(FileStream fileStream = File.OpenRead(configFileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserSpecificConfig));
                UserSpecificConfig result = (UserSpecificConfig) serializer.Deserialize(fileStream);
                return result;
            }
        }

        private static UserSpecificConfig Create(string configFileName)
        {
            UserSpecificConfig freshConfig = new UserSpecificConfig();
            SaveConfig(configFileName, freshConfig);
            return freshConfig;
        }

        private static void SaveConfig(string configFileName, UserSpecificConfig freshConfig)
        {
            using (FileStream fileStream = File.Create(configFileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof (UserSpecificConfig));
                serializer.Serialize(fileStream, freshConfig);
                fileStream.Close();
            }
        }

        public void Save(string configFileName)
        {
            SaveConfig(configFileName, this);
        }

        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }
        public string PresentationSubject { get; set; }
        public bool IsEnabled { get; set; }
    }
}