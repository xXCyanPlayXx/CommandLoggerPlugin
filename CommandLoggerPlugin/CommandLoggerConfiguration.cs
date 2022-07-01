using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLoggerPlugin
{
    public class CommandLoggerConfiguration : IRocketPluginConfiguration
    {

        public string LoadMessage { get; set; }
        public string GetPluginVersion { get; set; }
        public string CommandLoggerWebHook;
        public string PlayerChatLoggerWebHook;
        
        public void LoadDefaults()
        {
            LoadMessage = "You Are Useing CommandLogger By CyanPlays Do not remove this";
            GetPluginVersion = "you are running Version 0.0.1";
            CommandLoggerWebHook = "this is where your CommandLogger webhook goses";
            PlayerChatLoggerWebHook = "This is where your chatlogger webhook goses";
        }
    }
}
