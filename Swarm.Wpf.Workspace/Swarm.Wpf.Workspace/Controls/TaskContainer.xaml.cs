using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Swarm.Wpf.Actions;

namespace Swarm.Wpf.Workspace.Controls
{
    /// <summary>
    ///     Interaction logic for TaskContainer.xaml
    /// </summary>
    public partial class TaskContainer : UserControl
    {
        [Category("Container"), Description("Tasks container")]
        public IEnumerable<Panel> MainPanel { get; set; }

        public TaskContainer()
        {
            InitializeComponent();

            foreach (FrameworkElement tb in Stack1.Children)
            {
                var mouseDrag = new MouseDrag(tb);
                var betweenDrags = new BetweenDrag(mouseDrag, 
                    new[] { (Panel)Stack1, (Panel)Stack2, (Canvas)Canvas1 });
            }

            MainPanel = new Panel[] { Stack1, Stack2, Canvas1 };
        }
    }
}