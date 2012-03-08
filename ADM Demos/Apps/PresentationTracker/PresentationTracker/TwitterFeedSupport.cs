using System;
using System.Diagnostics;
using System.Windows.Forms;
using Twitterizer;

namespace PresentationTracker
{
    public static class TwitterFeedSupport
    {
        private const string ConsumerKey = "enter-your-consumer-key";
        private const string ConsumerSecret = "enter-your-consumer-secret";

        public static OAuthTokenResponse GetRequestToken()
        {
            var result = OAuthUtility.GetRequestToken(ConsumerKey, ConsumerSecret, "oob");
            return result;
        }

        public static void VerifyPIN()
        {
            if(String.IsNullOrEmpty(ConfigManager.CurrentUserSpecific.AccessSecret))
            {
                var token = GetRequestToken();
                string requestUrl = GetRequestUrl(token);
                OpenDefaultBrowser(requestUrl);
                EnterPINForm pinForm = new EnterPINForm();
                var result = pinForm.ShowDialog();
                string pinNumber = pinForm.PINNumber;
                if(!String.IsNullOrEmpty(pinNumber))
                {
                    var accessToken = OAuthUtility.GetAccessToken(ConsumerKey, ConsumerSecret, token.Token, pinNumber);
                    ConfigManager.CurrentUserSpecific.AccessToken = accessToken.Token;
                    ConfigManager.CurrentUserSpecific.AccessSecret = accessToken.TokenSecret;
                    ConfigManager.CurrentUserSpecific.Save(UserSpecificConfig.DefaultFileName);
                }
            }
        }

        public static void OpenDefaultBrowser(string requestUrl)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(requestUrl);
            processStartInfo.UseShellExecute = true;
            Process.Start(processStartInfo);
        }

        public static void SetSubject()
        {
            EnterSubjectForm form = new EnterSubjectForm();
            var userSettings = ConfigManager.CurrentUserSpecific;
            form.SetPresentationSubjectText(userSettings.PresentationSubject ?? "");
            if(form.ShowDialog() == DialogResult.OK)
            {
                userSettings.PresentationSubject = form.PresentationSubject;
                userSettings.Save(UserSpecificConfig.DefaultFileName);
            }
        }


        private static string GetRequestUrl(OAuthTokenResponse token)
        {
            return string.Format("http://twitter.com/oauth/authorize?oauth_token={0}", token.Token);
        }

        public static void Tweet(string message)
        {
            throw new NotSupportedException("Remove this when you're ready to Tweet!");
            try
            {
                if (ConfigManager.CurrentUserSpecific.IsValidated)
                    return;
                if (ConfigManager.CurrentUserSpecific.IsEnabled == false)
                    return;
                var currConfig = ConfigManager.CurrentUserSpecific;
                OAuthTokens tokens = new OAuthTokens
                                         {
                                             ConsumerKey = ConsumerKey,
                                             ConsumerSecret = ConsumerSecret,
                                             AccessToken = currConfig.AccessToken,
                                             AccessTokenSecret = currConfig.AccessSecret
                                         };

                TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(tokens, message);
                if (tweetResponse.Result == RequestResult.Success)
                {
                    // Tweet posted successfully!
                }
                else
                {
                    // Something bad happened
                }
            } catch // Very silent
            {
                
            }
        }

    }
}