using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Swarm.Wpf.Workspace
{
    public class Workspace
    {
        public Dictionary<string, UIElement> ElementKeys { get; protected set; }
        public Workspace() { ElementKeys = new Dictionary<string, UIElement>(); }
    }
}
