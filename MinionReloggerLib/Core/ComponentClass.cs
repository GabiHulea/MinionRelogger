using MinionReloggerLib.Interfaces;

namespace MinionReloggerLib.Core
{
    public class ComponentClass
    {
        internal IRelogComponent Component { get; set; }
        internal bool IsEnabled { get; set; }
    }
}