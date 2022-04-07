using System.Collections.ObjectModel;
using lab8vs.Models;
using ReactiveUI;
using System.IO;

namespace lab8vs.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<KanbanTask> planned;     
        ObservableCollection<KanbanTask> processing;     
        ObservableCollection<KanbanTask> done;        

        public MainWindowViewModel()
        {
            Planned = new ObservableCollection<KanbanTask>();     
            Processing = new ObservableCollection<KanbanTask>();    
            Done = new ObservableCollection<KanbanTask>();        
        }

        public ObservableCollection<KanbanTask> Planned
        {
            set => this.RaiseAndSetIfChanged(ref planned, value);   

            get => planned;                                     
        }

        public ObservableCollection<KanbanTask> Processing
        {
            set => this.RaiseAndSetIfChanged(ref processing, value);  

            get => processing;                                        
        }

        public ObservableCollection<KanbanTask> Done
        {
            set => this.RaiseAndSetIfChanged(ref done, value);   

            get => done;                                        
        }

        public void clear()
        {
            Planned.Clear();    
            Processing.Clear();    
            Done.Clear();       
        }

        public void Save(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(Planned.Count);           
                foreach (var task in Planned)           
                {
                    sw.WriteLine(task.Header);                
                    sw.WriteLine(task.Description);            
                    sw.WriteLine(task.Path);                   
                }

                sw.WriteLine(Processing.Count);            
                foreach (var task in Processing)          
                {
                    sw.WriteLine(task.Header);                  
                    sw.WriteLine(task.Description);             
                    sw.WriteLine(task.Path);                   
                }

                sw.WriteLine(Done.Count);             
                foreach (var task in Done)            
                {
                    sw.WriteLine(task.Header);                
                    sw.WriteLine(task.Description);            
                    sw.WriteLine(task.Path);                    
                }
            }
        }

        public void Load(string path)
        {
            if (!File.Exists(path))        
            {
                return;
            }

            clear();                       

            using (StreamReader sr = File.OpenText(path))
            {
              
                var planned_count = int.Parse(sr.ReadLine());   
                for (int i = 0; i < planned_count; ++i)
                {
                    var header = sr.ReadLine();               
                    var info = sr.ReadLine();            
                    var img_path = sr.ReadLine();             

                    var item = new KanbanTask();                      

                    item.Header = header;                       
                    item.Description = info;             
                    item.setImage(img_path);                    

                    Planned.Add(item);                          
                }

                var task_count = int.Parse(sr.ReadLine());   
                for (int i = 0; i < task_count; ++i)
                {
                    var header = sr.ReadLine();             
                    var info = sr.ReadLine();            
                    var img_path = sr.ReadLine();               

                    var item = new KanbanTask();                     

                    item.Header = header;                       
                    item.Description = info;            
                    item.setImage(img_path);                  

                    Processing.Add(item);                           
                }

              
                var done_count = int.Parse(sr.ReadLine());      
                for (int i = 0; i < done_count; ++i)
                {
                    var header = sr.ReadLine();               
                    var info = sr.ReadLine();          
                    var img_path = sr.ReadLine();               

                    var item = new KanbanTask();                 

                    item.Header = header;                       
                    item.Description = info;          
                    item.setImage(img_path);                   

                    Done.Add(item);                             
                }
            }
        }

        public void addPlannedTask()
        {
            Planned.Add(new KanbanTask());
        }

        public void addAtWorkTask()
        {
            Processing.Add(new KanbanTask());
        }

        public void addDoneTask()
        {
            Done.Add(new KanbanTask());
        }

        public void deletePlannedTask(KanbanTask task)
        {
            Planned.Remove(task);
        }

        public void deleteAtWorkTask(KanbanTask task)
        {
            Processing.Remove(task);
        }

        public void deleteDoneTask(KanbanTask task)
        {
            Done.Remove(task);
        }
    }
}