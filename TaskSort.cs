using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLista
{
    public class TaskSort : ITaskSort
    {
        public List<Task> sortByDate(List<Task> taskovi)
        {
            taskovi.Sort((task1, task2) => task1.datum.CompareTo(task2.datum));
            return taskovi;
        }

        public List<Task> sortByPriority(List<Task> taskovi)
        {
            taskovi.Sort((task1, task2) => task1.vaznost.CompareTo(task2.vaznost));
            return taskovi;
        }
    }
}
