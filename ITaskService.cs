using System.Collections.Generic;

namespace ToDoLista
{
    public interface ITaskService
    {
        List<Task> getList();
        void addTask(Task task);
        void deleteTask(int id);
        void checkTask(int id);
    }
}
