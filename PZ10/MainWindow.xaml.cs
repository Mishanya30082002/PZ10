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
using System.Collections.ObjectModel;


namespace PZ10
{
        public partial class MainWindow : Window
        {
            private ObservableCollection<Task> tasks = new ObservableCollection<Task>();
            private ObservableCollection<Task> tasks1 = new ObservableCollection<Task>();

        public MainWindow()
            {
                InitializeComponent();

                TodoListBox.ItemsSource = tasks;
                CompletedListBox.ItemsSource = tasks1;
            }

            private void AddTaskButton_Click(object sender, RoutedEventArgs e)
            {
                var text = AddTaskTextBox.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    tasks.Add(new Task(text));
                }

                AddTaskTextBox.Text = "";
            }

            private void TodoListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                if (TodoListBox.SelectedItem != null)
                {
                    var task = (Task)TodoListBox.SelectedItem;
                    task.IsCompleted = true;
                    tasks1.Add(task);
                }
            }

            private void DeleteCompletedButton_Click(object sender, RoutedEventArgs e)
            {
                tasks1.Clear();
            }

        private void TodoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Task
        {
            public Task(string text)
            {
                Text = text;
            }

            public string Text { get; set; }
            public bool IsCompleted { get; set; }
        }
}


    


