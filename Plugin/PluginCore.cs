using OQ.MineBot.PluginBase.Bot;
using OQ.MineBot.PluginBase.Base;
using OQ.MineBot.PluginBase.Base.Plugin;

namespace ContainerNavigator.Plugin
{
    // Plugin Information shown in the plugins in the plugins tab
    [Plugin(3, "AutoNavigate", "Takes a container navigation image")]
    public class PluginCore : IStartPlugin
    {
        // Runs when the plugin loads (when MineBot starts)
        public override void OnLoad(int version, int subversion, int buildversion)
        {
            // Adds the path setting (file path)
            Setting.Add(new PathSetting("Image Location", "Location of image", ""));
            // Adds the bool setting (shows the GUI on enable)
            Setting.Add(new BoolSetting("Show GUI", "Shows the GUI on enable", true));
        }

        // Run when the plugin is enabled
        public override PluginResponse OnEnable(IBotSettings botSettings)
        {
            // Checks if the inventory setting is enabled
            if (!botSettings.loadInventory)
                // Shows if inventory setting is disabled (disables the plugin)
                return new PluginResponse(false, "Please enable 'Load Inventory'");
            
            // Checks if the user wants to show the GUI
            if (Setting.GetValue<bool>("Show GUI"))
            {
                // Runs if the user wants to show the GUI
                GUI.MainDialog md = new GUI.MainDialog("LOL");
                md.ShowDialog();
            }

            // Checks if the image location is valid
            if (System.IO.File.Exists(Setting.GetValue<string>("Image Location")))
                // Enables the plugin if the image location is valid
                return new PluginResponse(true);
            // Disables if the image location is invalid
            return new PluginResponse(false, "Please select an image");
        }

        // Runs when the plugin starts
        public override void OnStart() => 
            // Runs the PluginTask class for each bot
            RegisterTask(new PluginTask());
    }
}
