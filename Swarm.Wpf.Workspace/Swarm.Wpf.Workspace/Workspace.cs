using System.Collections.Generic;
using System.Windows;
using System.Windows.Markup;

namespace Swarm.Wpf.Workspace
{
    public class Workspace
    {
        public Workspace() { ElementKeys = new Dictionary<string, UIElement>(); }
        public Dictionary<string, UIElement> ElementKeys { get; protected set; }
    }
}