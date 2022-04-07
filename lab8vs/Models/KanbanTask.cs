using ReactiveUI;
using Avalonia.Media.Imaging;
using System.IO;

namespace lab8vs.Models
{
    public class KanbanTask : ReactiveObject
    {
        string header;       
        string? info;    
        Bitmap? image;       
        bool choose;     

        public KanbanTask()
        {
            header = "Введите своё название задачи";           
            Description = "Введите своё описание";               
            Path = "";                      
        }

        public string Header
        {
            set => this.RaiseAndSetIfChanged(ref header, value);    

            get => header;                                        
        }

        public string Description
        {
            set => this.RaiseAndSetIfChanged(ref info, value);   

            get => info;                                        
        }

        public Bitmap? Image
        {
            set => this.RaiseAndSetIfChanged(ref image, value);     

            get => image;                                              
        }

        public string Path
        {
            set;      

            get;       
        }

        public bool Choose
        {
            set => this.RaiseAndSetIfChanged(ref choose, value);   

            get => choose;                                         
        }

        public void setImage(string path)
        {
            if (!File.Exists(path))       
            {
                return;
            }

            Path = path;                    
            Image = new Bitmap(path);     
        }
    }
}