using System;
using System.Reflection;
using Inventor;
using LinkParameters.AddIn;
using LinkParameters.Utilities;

namespace LinkParameters.Commands
{
    //[Command("coolOrange.linkParametersAddin.HelpControlCommand")]
    class HelpControlCommand : AdnButtonCommandBase
    {
        public HelpControlCommand(Application Application) : base(Application)
        {
        }

        public override string DisplayName
        {
            get { return "Help"; }
        }

        public override string InternalName
        {
            get { return "coolOrange.linkParametersAddin.HelpControlCommand"; }
        }

        public override CommandTypesEnum Classification
        {
            get { return CommandTypesEnum.kEditMaskCmdType; }
        }

        public override string ClientId
        {
            get
            {
                Type t = typeof(AddInServer);
                return t.GUID.ToString("B");
            }
        }

        public override string Description
        {
            get { return "coolOrange linkParameters help"; }
        }

        public override string ToolTipText
        {
            get { return "linkParameters help"; }
        }

        public override ButtonDisplayEnum ButtonDisplay
        {
            get { return ButtonDisplayEnum.kDisplayTextInLearningMode; }
        }

        public override string StandardIconName
        {
            get { return "LinkParameters.Resources.Help.ico"; }
        }

        public override string LargeIconName
        {
            get { return "LinkParameters.Resources.Help.ico"; }
        }

        protected override void OnExecute(NameValueMap context)
        {
            System.Diagnostics.Process.Start("http://wiki.coolorange.com/display/LIN");
            Terminate();
        }

        protected override void OnHelp(NameValueMap context)
        {
            throw new NotImplementedException();
        }
    }
}
