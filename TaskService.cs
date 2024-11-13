using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLista
{
    public class TaskService : ITaskService
    {
        private List<Task> listaTaskova = new List<Task>();
        public List<Task> getList() { return listaTaskova ; }
        public void addTask(Task task) {
            listaTaskova.Add(task);
        }

        public void deleteTask(int id)
        {
            try
            {
                if (id < 0 || id >= listaTaskova.Count) throw new ArgumentOutOfRangeException("ID ne postoji.");
                listaTaskova.RemoveAt(id);
                Console.WriteLine("Task uspješno obrisan.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška: {ex.Message}");
            }
        }


        public void checkTask(int id)
        {
            try
            {
                if (id < 0 || id >= listaTaskova.Count) throw new ArgumentOutOfRangeException("ID ne postoji.");
                listaTaskova[id].zavrsen = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greška: {ex.Message}");
            }
        }
    }
}
