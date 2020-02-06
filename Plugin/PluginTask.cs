using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Base.Plugin.Tasks;

namespace ContainerNavigator.Plugin
{
    // Class to be ran for each bot
    class PluginTask : ITask
    {
        // Abstract method (must be implemented)
        public override bool Exec() => 
            // Returns true (what the hell does it want me to do anyway)
            true;
    }
}
