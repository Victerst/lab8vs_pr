using Avalonia.Controls;
using lab8vs.Models;

namespace lab8vs.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<MenuItem>("New").Click += delegate
            {
                var context = this.DataContext as lab8vs.ViewModels.MainWindowViewModel; 
                context.clear();                                                      
            };

            this.FindControl<MenuItem>("Save").Click += async delegate
            {
                var dialog_window = new SaveFileDialog().ShowAsync(this.VisualRoot as MainWindow);  

                string path = await dialog_window;  

                var context = this.DataContext as lab8vs.ViewModels.MainWindowViewModel; 

                if (path != null)
                {
                    context.Save(path);
                }
            };

            this.FindControl<MenuItem>("Load").Click += async delegate
            {
                var dialog_window = new OpenFileDialog().ShowAsync(this.VisualRoot as MainWindow);  

                string[] path = await dialog_window;       

                var context = this.DataContext as lab8vs.ViewModels.MainWindowViewModel; 

                if (path != null)
                {
                    context.Load(path[0]);
                }
            };

            this.FindControl<MenuItem>("Exit").Click += delegate
            {
                this.Close();
            };

            this.FindControl<MenuItem>("About").Click += async delegate
            {
                await new About().ShowDialog(this.VisualRoot as MainWindow);
            };
        }

        public async void addImage(KanbanTask kanbantask)
        {
            var dialog_window = new OpenFileDialog().ShowAsync(this.VisualRoot as MainWindow);  

            var path = await dialog_window; 

            if (path != null)
            {
                kanbantask.setImage(path[0]);
            }
        }
    }
}