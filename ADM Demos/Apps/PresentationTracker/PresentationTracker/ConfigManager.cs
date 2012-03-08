using System;

namespace PresentationTracker
{
    public static class ConfigManager
    {
        public static UserSpecificConfig CurrentUserSpecific;

        public static UserSpecificConfig GetUserSpecificConfig()
        {
            CurrentUserSpecific = UserSpecificConfig.OpenOrCreate(UserSpecificConfig.DefaultFileName);
            return CurrentUserSpecific;
        }
    }
}