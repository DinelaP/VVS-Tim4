using System.Collections.Generic;

namespace ToDoLista
{
    public interface ITaskSort
    {
        List<Task> sortByDate(List<Task> taskovi);
        List<Task> sortByPriority(List<Task> taskovi);
    }
}
