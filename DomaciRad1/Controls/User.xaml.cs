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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...probat sliku minjat!!
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register
        (
            "Title", 
            typeof(string), 
            typeof(User), 
            new UIPropertyMetadata("Title")
        );

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User) //event owner
        );

        public event RoutedEventHandler Delete  
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }


        void RaiseDeleteEvent()
        {
            RaiseEvent(new RoutedEventArgs(User.DeleteEvent));
        }

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
            "Edit",
            RoutingStrategy.Bubble, //provjerit!!
            typeof(RoutedEventHandler),
            typeof(User)
        );

        public event RoutedEventHandler Edit
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RaiseEvent(new RoutedEventArgs(User.EditEvent));
        }

        private void OnUserControlLoaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon.MouseDown += (obj, eventHandler) => RaiseDeleteEvent();
            this.EditIcon.MouseDown += (obj, eventHandler) => RaiseEditEvent();
        }

    }
}
