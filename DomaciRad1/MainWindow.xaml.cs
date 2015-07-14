using DomaciRad1.Controls;
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

namespace DomaciRad1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.AddFriendButton.Click += AddFriendButton_Click;
            this.AddPostButton.Click += AddPostButton_Click;

           // probat searchbox
            
            foreach (var child in this.UserPanel.Children)
            {
                if (!(child is User)) { continue; }

                var user = child as User;
                user.Delete += OnUserDelete;
                user.Edit += OnUserEdit;
            }

            foreach (var child in this.PostPanel.Children)
            {
                if (!(child is Post)) { continue; }

                var post = child as Post;
                post.Delete += OnPostDelete;
                post.Edit += OnPostEdit;
            }
        }

        private void OnUserEdit(object sender, RoutedEventArgs e)
        {
            //if (!(sender is User)) { return; }

            //var user = sender as User;
            //user.Title            
        }

        void OnUserDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return;  }

            var user = sender as User;
            this.UserPanel.Children.Remove(user);
        }

        private void OnPostEdit(object sender, RoutedEventArgs e)
        {
            //if (!(sender is Post)) { return; }

            //var post = sender as Post;
            //post.Text            
        }

        void OnPostDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }

            var post = sender as Post;
            this.PostPanel.Children.Remove(post);
        }

        void AddFriendButton_Click(object sender, RoutedEventArgs e)
        {
            var newFriend = new User() { Title = "N.N"};
            newFriend.Delete += OnUserDelete;
            newFriend.Edit += OnUserEdit;

            this.UserPanel.Children.Add(newFriend);              
        }


        void AddPostButton_Click(object sender, RoutedEventArgs e)
        {
            var newPost = new Post() { Text = "weeeee" };
            newPost.Delete += OnPostDelete;
            newPost.Edit += OnPostEdit;            
            
            this.PostPanel.Children.Add(newPost);
        }
    }
}
