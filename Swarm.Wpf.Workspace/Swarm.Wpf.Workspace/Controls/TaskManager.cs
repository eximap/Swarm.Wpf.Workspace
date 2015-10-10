using System.Windows.Controls;

namespace Swarm.Wpf.Workspace.Controls
{
    /// <summary>
    ///     Interaction logic for TaskManager.xaml
    /// </summary>
    public partial class TaskManager : UserControl
    {
        public TaskManager() { InitializeComponent(); }

        private void ProgressBar_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}