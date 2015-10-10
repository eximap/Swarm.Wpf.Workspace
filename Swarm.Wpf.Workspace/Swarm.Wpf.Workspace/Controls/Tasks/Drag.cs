using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Swarm.Wpf.Workspace.Controls.Tasks
{
    public class Drag : Drag<FrameworkElement, Panel>
    {
        public Drag(FrameworkElement target) : base(target) { }
    }

    public class Drag<TElement, TContainter>
        where TElement : FrameworkElement
        where TContainter : Panel
    {
        public TElement Target { get; protected set; }
        public IEnumerable<TContainter> Containers { get; protected set; }

        public DragDropEffects DragDropEffects { get; set; }

        public Drag(TElement target)
        {
            target.MouseDown += MouseDown;

            DragDropEffects = DragDropEffects.Move;

            Target = target;
        }
        public Drag<TElement, TContainter> Between(params TContainter[] containers)
        {
            return Between(containers as IEnumerable<TContainter>);
        }
        public Drag<TElement, TContainter> Between(IEnumerable<TContainter> containers)
        {
            Containers = containers;

            foreach (var c in Containers)
            {
                c.AllowDrop = true;
                c.Drop += Drop;
            }

            return this;
        }

        private void Drop(object sender, DragEventArgs e)
        {
            var element = e.Data.GetData(Target.GetType()) as TElement;
            if (element == null) return;

            var target = sender as TContainter;
            var source = element.Parent as TContainter;

            if (target == null || target.Children.Contains(element)) return;
            if (source != null && source.Children.Contains(element)) source.Children.Remove(element);
            target.Children.Add(element);
        }
        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            var target = (FrameworkElement)sender;
            DragDrop.DoDragDrop(target.Parent, target, DragDropEffects);
        }
    }
}
