using System;
using ToDoLista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLista;

public class Statistic
{
    private List<Task> tasks;

    public Statistic(List<Task> tasks)
    {
        this.tasks = tasks;
    }


    public int GetCompletedTasksCount()
    {
        return tasks.Count(task => task.zavrsen);
    }

    public double ProcenatZavrsenih()
    {

        return (tasks.Count(task => task.zavrsen) / tasks.Count()) * 100;
    }

    public double GetPendingTasksCount()
    {
        return tasks.Count(task => !task.zavrsen);
    }

    public int ProcenatNezavrsenih()
    {

        return (tasks.Count(task => !task.zavrsen) / tasks.Count()) * 100;
    }



    public Kategorija? GetCategoryWithMostCompletedTasks()
    {

        var categoryWithMost = tasks.Where(task => task.zavrsen)
                    .GroupBy(task => task.kategorija)
                    .OrderByDescending(group => group.Count())
                    .FirstOrDefault();
        return categoryWithMost?.Key;
    }

    public Kategorija? GetCategoryWithLeastCompletedTasks()
    {
        var categoryWithLeast = tasks.Where(task => task.zavrsen)
                                 .GroupBy(task => task.kategorija)
                                 .OrderBy(group => group.Count())
                                 .FirstOrDefault();

        return categoryWithLeast?.Key;
    }


}
