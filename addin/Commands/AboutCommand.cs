using System;
using System.Reflection;
using Inventor;
using LinkParameters.AddIn;
using LinkParameters.Utilities;

namespace LinkParameters.Commands
{
    //[Command("coolOrange.linkParametersAddin.AboutCtrlCmd")]
    class AboutCommand : AdnButtonCommandBase
    {
        public AboutCommand(Application Application) : base(Application)
        {
        }

        public override string DisplayName
        {
            get { return "About"; }
        }

        public override string InternalName
        {
            get { return "coolOrange.linkParametersAddin.AboutCtrlCmd"; }
        }

        public override CommandTypesEnum Classification
        {
            get { return CommandTypesEnum.kEditMaskCmdType; }
        }

        public override string Description
        {
            get { return "Displays linkParameters info"; }
        }

        public override string ToolTipText
        {
            get { return "Displays linkParameters info"; }
        }

        public override ButtonDisplayEnum ButtonDisplay
        {
            get { return ButtonDisplayEnum.kDisplayTextInLearningMode; }
        }

        public override string StandardIconName
        {
            get { return "LinkParameters.Resources.about.ico"; }
        }

        public override string LargeIconName
        {
            get { return "LinkParameters.Resources.about.ico"; }
        }

        protected override void OnExecute(NameValueMap context)
        {
	        var frmSplashAbout = new FrmSplash()
	        {
		        lblInfo = { Text = "Free License"},
		        versionlbl = { Text = "2019"},
		        buildlbl = {Text = Assembly.GetExecutingAssembly().GetName().Version.ToString()},
		        BackgroundImage = Properties.Resources.linkParameters1
	        };
			RegisterCommandForm(frmSplashAbout, true);
        }

        protected override void OnHelp(NameValueMap context)
        {
            throw new NotImplementedException();
        }

        public override string ClientId
        {
            get
            {
                Type t = typeof(AddInServer);
                return t.GUID.ToString("B");
            }
        }
    }
}
