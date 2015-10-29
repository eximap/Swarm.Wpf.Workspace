using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using Swarm.Wpf.Actions;
using Swarm.Wpf.Workspace.Controls.Tasks;
using System.Threading;

namespace Swarm.Wpf.Workspace.Controls
{
    /// <summary>
    /// Interaction logic for ServiceDesc.xaml
    /// </summary>
    public partial class ServiceDesc : UserControl
    {
        List<SdTask> Tasks { get; set; }

        public ServiceDesc()
        {
            InitializeComponent();

            Tasks = new List<SdTask>();

            var t1 = GetTasks(10);
            var t2 = GetTasks(10);

            foreach (var t in t1) Grid2.Children.Add(t.Element);
            foreach (var t in t2) Grid4.Children.Add(t.Element);

            Tasks.AddRange(t1);
            Tasks.AddRange(t2);

            DragBetween.UIElements(Grid2, Grid4);

            DragBetween.UIElements(Grid2, Preview);
            DragBetween.UIElements(Grid4, Preview);

            foreach(var c in Tasks.Select(t=>t.Element))
                c.MouseDown += c_MouseDown;

            DispatcherTimer dpTimer = new DispatcherTimer();
            dpTimer.Interval = new TimeSpan(16);
            dpTimer.Tick += dpTimer_Tick;
            dpTimer.Start();
        }

        void c_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var task = Tasks.Where(t => t.Element == sender).ToArray();
            if(task.Any())
            {
                //Swarm.Wpf.Workspace.Controls.TaskEditor;
            }
        }

        private static SdTask[] GetTasks(int count)
        {
            return Enumerable.Range(0, count).Select(i => new SdTask { Id = i * 3 + i * 2, Url = "Link" + i }).ToArray();
        }

        void Grid1_Drop(object sender, DragEventArgs e)
        {
            foreach (var task in Tasks)
            {
                //if (Grid1.Children.Contains(task.Element))
                //{
                //    //task.Pause();
                //}
            }
        }
        void Grid2_Drop(object sender, DragEventArgs e)
        {
            foreach (var task in Tasks)
            {
                if (Grid2.Children.Contains(task.Element))
                {
                    //task.Start();
                }
            }
        }

        void dpTimer_Tick(object sender, EventArgs e)
        {
            foreach (var task in Tasks)
            {
                task.IsFull = Grid2.Children.Contains(task.Element);
             //   task.IsFull = !Grid4.Children.Contains(task.Element);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
