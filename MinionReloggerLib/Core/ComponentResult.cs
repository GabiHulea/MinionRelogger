using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Core
{
    public class ComponentResult
    {
        public ComponentResult()
        {
            Result = EComponentResult.Default;
            LogMessage = "";
        }

        public EComponentResult Result { get; set; }
        public string LogMessage { get; set; }
    }
}