using System.ComponentModel;

using Exiled.API.Interfaces;

namespace BodyEject
{
    public class Config : IConfig
    {
        
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Remove items?")]
        public bool ItemDrop { get; set; } = true;


        [Description("Enable debug logs?")]
        public bool Debug { get; set; } = false;
    }
}
