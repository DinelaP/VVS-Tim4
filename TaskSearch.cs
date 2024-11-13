using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLista
{
    public class TaskSearch : ITaskSearch
    {
        public String searchById(List<Task> taskovi, int id)
        {
            if (id >= 0 && id < taskovi.Count)
            {
                return taskovi[id].naziv;
            }

            return "Zadatak nije pronađen.";
            
        }

      
        public String searchByName(List<Task> taskovi, string naziv)
        {
            foreach (var task in taskovi)
            {
                if (task.naziv.Equals(naziv, StringComparison.OrdinalIgnoreCase))
                {
                    return task.naziv;
                }
            }

            return "Zadatak nije pronađen.";
        }

    }
}
