using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLoggerPlugin
{

    public class CommandLoggerPlugin : RocketPlugin<CommandLoggerConfiguration> 
    {

        public object PysicsUtility { get; private set; }
        public static CommandLoggerPlugin Instance;
        protected override void Load()
        {
            Logger.Log($"{Name} {Assembly.GetName().Version} has loaded!", ConsoleColor.Green);
            Logger.Log($"{Name} {Assembly.GetName().Version} Has Been Loaded!");

            UnturnedPlayerEvents.OnPlayerChatted += UnturnedPlayerEvents_OnPlayerChatted;
        }

        private void UnturnedPlayerEvents_OnPlayerChatted(UnturnedPlayer player, ref UnityEngine.Color color, string message, EChatMode chatMode, ref bool cancel)
        {
            if (!message.StartsWith("/"))
            {
 
                   WebhookMessage CommandLoggerPlugin = new WebhookMessage()
                     .PassEmbed()
                .WithTitle("Player Command Logger")
                .WithField("Player Name:", Translate("webhook", player.DisplayName, player.CSteamID))
                .WithField("Player Message:", message)
                .WithField("blue Hammed", Translate("webhook", player.IsAdmin.ToString(), player.SteamName))
                .WithField("Player ID", Translate("webhook", player.Id.Length.ToString(), player.Id))
                .WithColor(color)
                .Finalize();
                DiscordWebhookService.PostMessage(Configuration.Instance.CommandLoggerWebHook, CommandLoggerPlugin);
            };


        }

        protected override void Unload()
        {
            Logger.Log($"{Name} Has Unloaded");
            Logger.Log($"{Name} Has been Unloaded!", ConsoleColor.Green);
        }

    }







}







    
    
































