using System.Collections.Generic;
using System.Windows;

namespace Swarm.Wpf.Workspace
{
    public class Workspace
    {
        public Workspace() { ElementKeys = new Dictionary<string, UIElement>(); }
        public Dictionary<string, UIElement> ElementKeys { get; protected set; }
    }
}