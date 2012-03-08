using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using Application = Microsoft.Office.Interop.PowerPoint.Application;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;
using TextFrame = Microsoft.Office.Interop.PowerPoint.TextFrame;

namespace PresentationTracker
{
    public static class EventHandlerImpl
    {
        public static void TweetSlideChange_SlideShowNextSlide(Application powerpointApplication, SlideShowWindow slideShowWindow)
        {
            try
            {
                string subject = ConfigManager.CurrentUserSpecific.PresentationSubject;
                string notesFirstLine = GetNotesFirstLine(slideShowWindow);
                if (String.IsNullOrEmpty(notesFirstLine))
                    return;
                string tweet = String.Format("{0} {1}", subject, notesFirstLine).Trim();
                TwitterFeedSupport.Tweet(tweet);
            } 
            catch
            {
            }
        }

        private static string GetNotesFirstLine(SlideShowWindow slideShowWindow)
        {
            var slide = slideShowWindow.View.Slide;
            var result = slideShowWindow.View.Slide.HasNotesPage;
            if (result == MsoTriState.msoTrue)
            {
                var notes = slide.NotesPage;
                var shapes = notes.Shapes;
                foreach (Shape shape in shapes)
                {
                    if (shape.Type == MsoShapeType.msoPlaceholder && shape.PlaceholderFormat.Type == PpPlaceholderType.ppPlaceholderBody)
                    {
                        if (shape.HasTextFrame == MsoTriState.msoTrue)
                        {
                            TextFrame textFrame = shape.TextFrame;
                            if (textFrame.HasText == MsoTriState.msoTrue)
                            {
                                TextRange textRange = textFrame.TextRange;
                                string allText = textRange.Text;
                                string[] lines = allText.Split('\r');
                                string notesFirstLine = lines.FirstOrDefault();
                                return notesFirstLine;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static void WarnForTweeter_PresentationOpen(Application powerpointApplication, Presentation presentation)
        {
            warnForTwitter();
        }

        //public static void WarnForTweeterOnNew_AfterNewPresentation(Application powerpointApplication, Presentation presentation)
        //{
        //    warnForTwitter();
        //}

        private static void warnForTwitter()
        {
            MessageBox.Show("Remember: Tweeter Installed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void WarnForTweeterOnNew_AfterNewPresentation(Application powerpointApplication, Presentation presentation)
        {
            warnForTwitter();
        }

        public static void CheckBox_TweetingEnabled_Toggled(IRibbonControl checkBox, bool isChecked)
        {
            ConfigManager.CurrentUserSpecific.IsEnabled = isChecked;
            ConfigManager.CurrentUserSpecific.Save(UserSpecificConfig.DefaultFileName);
        }
    }
}