using System;
using Microsoft.Office.Core;

namespace PresentationTracker
{
    public static class StateHandlerImpl
    {
        public static bool GetCheckBox_TweetingEnabled_InitialState(IRibbonControl control)
        {
            return ConfigManager.CurrentUserSpecific.IsEnabled;
        }
    }
}