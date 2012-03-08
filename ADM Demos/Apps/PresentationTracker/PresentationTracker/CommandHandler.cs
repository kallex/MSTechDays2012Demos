using System;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace PresentationTracker
{
    internal static class CommandHandler
    {
        public static void ExecuteCommand_DemoCommand(IRibbonControl activatedControl)
        {
            MessageBox.Show(activatedControl.Id);
        }

        public static void ExecuteCommand_VerifyPIN(IRibbonControl activatedControl)
        {
            TwitterFeedSupport.VerifyPIN();
        }

        public static void ExecuteCommand_SetSubject(IRibbonControl activatedControl)
        {
            TwitterFeedSupport.SetSubject();
        }

        //public static void ExecuteCommand_OpenTwitterInBrowser(IRibbonControl activatedControl)
        //{
        //    TwitterFeedSupport.OpenDefaultBrowser("http://twitter.com");
        //}
        public static void ExecuteCommand_OpenTwitterInBrowser(IRibbonControl activatedControl)
        {
            TwitterFeedSupport.OpenDefaultBrowser("http://twitter.com");
        }

    }
}