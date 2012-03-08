 

using System;
using Extensibility;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;

namespace PresentationTracker
{

	#region Read me for Add-in installation and setup information.
	// When run, the Add-in wizard prepared the registry for the Add-in.
	// At a later time, if the Add-in becomes unavailable for reasons such as:
	//   1) You moved this project to a computer other than which is was originally created on.
	//   2) You chose 'Yes' when presented with a message asking if you wish to remove the Add-in.
	//   3) Registry corruption.
	// you will need to re-register the Add-in by building the CSOfficeSharedAddInSetup project, 
	// right click the project in the Solution Explorer, then choose install.
	#endregion
	
	/// <summary>
	///   The object for implementing an Add-in.
	/// </summary>
	/// <seealso class='IDTExtensibility2' />
	[GuidAttribute("A018A1FA-745B-4A7E-AA69-D9B396075576"), ProgId("PresentationTrackerDemo.Connect")]
	public class Connect : Object, Extensibility.IDTExtensibility2 , IRibbonExtensibility
	{
				private EApplication_AfterNewPresentationEventHandler _WarnForTweeterOnNewField;
				private EApplication_PresentationOpenEventHandler _WarnForTweeterField;
			    private void RegisterEvents(Application powerPointApp)
	    {
				        {
	            _WarnForTweeterOnNewField = new EApplication_AfterNewPresentationEventHandler(HandlerForEvent_WarnForTweeterOnNew_AfterNewPresentation);
	            powerPointApp.AfterNewPresentation += _WarnForTweeterOnNewField;                
	        }
			        {
	            _WarnForTweeterField = new EApplication_PresentationOpenEventHandler(HandlerForEvent_WarnForTweeter_PresentationOpen);
	            powerPointApp.PresentationOpen += _WarnForTweeterField;                
	        }
			    }
			    private void UnregisterEvents(Application powerPointApp)
	    {
			            powerPointApp.AfterNewPresentation -= _WarnForTweeterOnNewField;                
            _WarnForTweeterOnNewField = null;
		            powerPointApp.PresentationOpen -= _WarnForTweeterField;                
            _WarnForTweeterField = null;
			    }
			    private void HandlerForEvent_WarnForTweeterOnNew_AfterNewPresentation(Presentation presentation)
	    {
			
			// TESTI
			            Application powerpointApplication = (Application)applicationObject;
	        EventHandlerImpl.WarnForTweeterOnNew_AfterNewPresentation(powerpointApplication, presentation);
	    }
		
			    private void HandlerForEvent_WarnForTweeter_PresentationOpen(Presentation presentation)
	    {
			
			// TESTI
			            Application powerpointApplication = (Application)applicationObject;
	        EventHandlerImpl.WarnForTweeter_PresentationOpen(powerpointApplication, presentation);
	    }
		
							
			public void ExecuteCommand_VerifyPIN(IRibbonControl activatedControl)
			{
				CommandHandler.ExecuteCommand_VerifyPIN(activatedControl);
			}
						
			public void ExecuteCommand_SetSubject(IRibbonControl activatedControl)
			{
				CommandHandler.ExecuteCommand_SetSubject(activatedControl);
			}
						
			public void ExecuteCommand_OpenTwitterInBrowser(IRibbonControl activatedControl)
			{
				CommandHandler.ExecuteCommand_OpenTwitterInBrowser(activatedControl);
			}
			        public string GetCustomUI(string RibbonID)
        {
            return
			@"<customUI xmlns=""http://schemas.microsoft.com/office/2006/01/customui""> 
              <ribbon startFromScratch=""false""> 
                <tabs>
				          <tab id=""PresentationTrackerDemo"" label=""Presentation Tracker Demo""> 
			            <group id=""General"" label=""General"">
					<button id=""VerifyPIN"" imageMso=""HappyFace"" size=""normal"" 
			label=""Verify Twitter PIN"" onAction=""ExecuteCommand_VerifyPIN""
			/> 
				<button id=""SetSubject"" imageMso=""HappyFace"" size=""normal"" 
			label=""Set Subject"" onAction=""ExecuteCommand_SetSubject""
			/> 
				<button id=""OpenTwitter"" imageMso=""HappyFace"" size=""large"" 
			label=""Open Twitter"" onAction=""ExecuteCommand_OpenTwitterInBrowser""
			/> 
		       <checkBox id=""TweetingEnabled"" 
          enabled=""true"" 
          label=""Tweeting Enabled"" 
          keytip=""A1"" 
          supertip=""Tweeting toggler, Supertip Yippee!"" 
          visible=""true"" 
          getPressed=""GetPressedCheckBoxTweetingEnabled"" 
          onAction=""OnCheckBoxTweetingEnabledClicked"" />
		
		            </group> 
		          </tab> 
		                </tabs> 
              </ribbon> 
            </customUI>";
        }
		
				private bool checkBox_TweetingEnabled_CheckedState;
		public bool GetPressedCheckBoxTweetingEnabled(IRibbonControl checkBox)
		{
			checkBox_TweetingEnabled_CheckedState = StateHandlerImpl.GetCheckBox_TweetingEnabled_InitialState(checkBox);
			return checkBox_TweetingEnabled_CheckedState;
		}
		
		public void OnCheckBoxTweetingEnabledClicked(IRibbonControl checkBox, bool isChecked)
		{
			checkBox_TweetingEnabled_CheckedState = isChecked;
			EventHandlerImpl.CheckBox_TweetingEnabled_Toggled(checkBox, isChecked);
		}
		
				public readonly UserSpecificConfig UserConfig = ConfigManager.GetUserSpecificConfig();
				/// <summary>
		///		Implements the constructor for the Add-in object.
		///		Place your initialization code within this method.
		/// </summary>
		public Connect()
		{
		}

		/// <summary>
		///      Implements the OnConnection method of the IDTExtensibility2 interface.
		///      Receives notification that the Add-in is being loaded.
		/// </summary>
		/// <param term='application'>
		///      Root object of the host application.
		/// </param>
		/// <param term='connectMode'>
		///      Describes how the Add-in is being loaded.
		/// </param>
		/// <param term='addInInst'>
		///      Object representing this Add-in.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref System.Array custom)
		{
			applicationObject = application;
			addInInstance = addInInst;
            Application powerPointApp = (Application)application;
            RegisterEvents(powerPointApp);
		}

		/// <summary>
		///     Implements the OnDisconnection method of the IDTExtensibility2 interface.
		///     Receives notification that the Add-in is being unloaded.
		/// </summary>
		/// <param term='disconnectMode'>
		///      Describes how the Add-in is being unloaded.
		/// </param>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(Extensibility.ext_DisconnectMode disconnectMode, ref System.Array custom)
		{
            UnregisterEvents((Application) this.applicationObject);
		}

		/// <summary>
		///      Implements the OnAddInsUpdate method of the IDTExtensibility2 interface.
		///      Receives notification that the collection of Add-ins has changed.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnAddInsUpdate(ref System.Array custom)
		{
		}

		/// <summary>
		///      Implements the OnStartupComplete method of the IDTExtensibility2 interface.
		///      Receives notification that the host application has completed loading.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref System.Array custom)
		{
		}

		/// <summary>
		///      Implements the OnBeginShutdown method of the IDTExtensibility2 interface.
		///      Receives notification that the host application is being unloaded.
		/// </summary>
		/// <param term='custom'>
		///      Array of parameters that are host application specific.
		/// </param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref System.Array custom)
		{
		}
		
		private object applicationObject;
		private object addInInstance;

		//private Timer PostToTwitterOnSlideChangeTimer = new Timer(10000);

        //    if(PostToTwitterOnSlideChangeTimer.Enabled)
        //    {
        //        return;
        //    }

		// Strong type eventargs for delayed args, react also to the fact that the object references may have changed
	}
}		