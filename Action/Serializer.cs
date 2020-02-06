using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ContainerNavigator.Action
{
    // Manages the serialization and deserialization of data
    // Does not need to be instantiated
    static class Serializer
    {
        // types with Action Attribute
        private readonly static Type[] types;

        // Runs on first mention of class
        static Serializer() => 
            types = 
            // Gets all types in program
            (from type in Assembly.GetExecutingAssembly().GetTypes()
             // Checks if type has Action Attribute
            where type.GetCustomAttribute<ActionAttribute>() != null
            // Selects it if it does
            select type)
            // Converts to Type[]
            .ToArray();

        // Serializes the data
        public static void Serialize(string location, IAction[] actions)
        {
            // Creates file @ location (overwrites pre-existing files)
            using (StreamWriter sw = new StreamWriter(File.Create(location)))
                // Cycles through each action in actions
                foreach (IAction action in actions)
                    // Writes the return for string IAction.Serialize()
                    sw.WriteLine(action.Serialize());
        }

        // Deserializes the data
        public static IAction[] Deserialize(string location)
        {
            // Opens file for reading @ location
            using (StreamReader sw = new StreamReader(location))
            {
                // Gets lines
                string[] lines = sw.ReadToEnd().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                // Sets actions
                IAction[] actions = new IAction[lines.Length];

                // Cycles through each line
                for (int i = 0; i < lines.Length; i++)
                {
                    // Gets line properties
                    string[] line = lines[i].Split('/');
                    // Creates a new instance of the correct type
                    actions[i] = (IAction)Activator.CreateInstance(types.First(x => x.FullName == line[0]));
                    // Runs IAction.Deserialize(string[] data)
                    actions[i].Deserialize(line);
                }

                // Returns actions
                return actions;
            }
        }
    }
}
