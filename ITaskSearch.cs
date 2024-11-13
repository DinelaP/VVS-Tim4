using System;
using System.Collections.Generic;

namespace ToDoLista
{
    public interface ITaskSearch
    {
        string searchById(List<Task> taskovi, int id);
        string searchByName(List<Task> taskovi, string naziv);
    }
}
