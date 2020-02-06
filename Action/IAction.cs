using OQ.MineBot.PluginBase.Classes.Window;

namespace ContainerNavigator.Action
{
    // IAction base interface
    interface IAction
    {
        // ID of the container
        Container ContainerID { get; }
        // Method for serialization
        string Serialize();
        // Method for deserialization 
        void Deserialize(string[] data);
        // Executes the action
        void Execute(IWindow window);
    }
}
