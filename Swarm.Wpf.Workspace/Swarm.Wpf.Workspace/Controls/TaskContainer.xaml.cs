using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Swarm.Wpf.Workspace.Controls.Tasks;

namespace Swarm.Wpf.Workspace.Controls
{
    /// <summary>
    /// Interaction logic for TaskContainer.xaml
    /// </summary>
    public partial class TaskContainer : UserControl
    {
        [Category("Alignment"), Description("Specifies the alignment of text.")]
        public IEnumerable<Drag> DragableElements { get; protected set; }

        public TaskContainer()
        {
            InitializeComponent();

            foreach (FrameworkElement tb in Stack1.Children)
            {
                new Drag(tb).Between(Stack1, Stack2, Canvas1);
            }
        }
    }

}
