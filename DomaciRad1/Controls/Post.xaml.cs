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

namespace DomaciRad1.Controls
{
    /// <summary>
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register
        (
            "Text", 
            typeof(string), 
            typeof(Post), 
            new UIPropertyMetadata("Text")
        );

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //event owner
        );

        public event RoutedEventHandler Delete
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }


        void RaiseDeleteEvent()
        {
            RaiseEvent(new RoutedEventArgs(Post.DeleteEvent));
        }

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
            "Edit",
            RoutingStrategy.Bubble, //provjerit!!
            typeof(RoutedEventHandler),
            typeof(Post)
        );

        public event RoutedEventHandler Edit
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RaiseEvent(new RoutedEventArgs(Post.EditEvent));
        }
             
        private void OnPostControlLoaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon.MouseDown += (obj, eventHandler) => RaiseDeleteEvent();
            this.EditIcon.MouseDown += (obj, eventHandler) => RaiseEditEvent();
        }

    }
}
