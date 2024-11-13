using System;
using System.Collections.Generic;

namespace ToDoLista
{


    class Program
    {
        static void Main(string[] args)
        {
            TaskService taskService = new TaskService();
            TaskSearch taskSearch = new TaskSearch();
            TaskSort taskSort = new TaskSort();
            Statistic statistic = new Statistic(taskService.getList());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("To-Do List Aplikacija");
                Console.WriteLine("1. Dodaj task");
                Console.WriteLine("2. Brisanje taska");
                Console.WriteLine("3. Čekiraj task");
                Console.WriteLine("4. Pregled taskova");
                Console.WriteLine("5. Pretraga taskova");
                Console.WriteLine("6. Sortiraj taskove");
                Console.WriteLine("7. Statistika");
                Console.WriteLine("8. Izlaz");
                Console.Write("Izaberite opciju: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Dodavanje taska
                        Console.Clear();
                        Console.Write("Unesite naziv taska: ");
                        string naziv = Console.ReadLine();
                        Console.Write("Unesite važnost (1-5): ");
                        int vaznost = int.Parse(Console.ReadLine());
                        Console.Write("Unesite datum (yyyy-mm-dd): ");
                        DateTime datum = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Izaberite kategoriju (1 - Obrazovanje, 2 - Domacinstvo, 3 - Sport, 4 - Dogadjaji, 5 - Ostalo): ");
                        Kategorija kategorija = (Kategorija)Enum.Parse(typeof(Kategorija), Console.ReadLine());
                        taskService.addTask(new Task(taskService.getList().Count, naziv, vaznost, datum, kategorija, false));
                        Console.WriteLine("Task je uspešno dodat!");
                        break;

                    case "2":
                        Console.Write("Unesite ID taska za brisanje: ");
                        string input = Console.ReadLine();

                        // Provjeravamo da li je unos validan broj koristeći int.TryParse
                        if (int.TryParse(input, out int id))
                        {
                            try
                            {
                                // Pokušavamo obrisati task po ID-u
                                taskService.deleteTask(id);
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine($"Greška: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Uneseni ID nije validan broj!");
                        }
                        break;

                    case "3":
                        Console.Write("Unesite ID taska za čekiranje: ");
                        string checkInput = Console.ReadLine();

                        if (int.TryParse(checkInput, out int checkId))
                        {
                            try
                            {
                                taskService.checkTask(checkId);
                                Console.WriteLine($"Task s ID-om {checkId} označen kao završen.");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine($"Greška: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Uneseni ID nije validan broj!");
                        }
                        break;

                    case "4": // Pregled taskova
                        Console.Clear();
                        Console.WriteLine("Lista svih taskova:");
                        foreach (var task in taskService.getList())
                        {
                            string status = task.zavrsen ? "Završen" : "Nije završen";
                            Console.WriteLine($"ID: {task.ID}, Naziv: {task.naziv}, Važnost: {task.vaznost}, Kategorija: {task.kategorija}, Status: {status}");
                        }
                        break;

                    case "5": // Pretraga taskova
                        Console.Clear();
                        Console.WriteLine("1. Pretraga po ID-u");
                        Console.WriteLine("2. Pretraga po Nazivu");
                        Console.Write("Izaberite opciju: ");
                        string searchChoice = Console.ReadLine();

                        if (searchChoice == "1")
                        {
                            Console.Write("Unesite ID za pretragu: ");
                            input = Console.ReadLine();

                            // Provjera da li je unos validan broj koristeći int.TryParse
                            if (int.TryParse(input, out id))
                            {
                                try
                                {
                                    // Pretražuje task po ID-u
                                    String foundTask = taskSearch.searchById(taskService.getList(), id);
                                    Console.WriteLine($"Pronađen task: {foundTask}");
                                }
                                catch (ArgumentOutOfRangeException ex)
                                {
                                    Console.WriteLine($"Greška: {ex.Message}");
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    Console.WriteLine($"Greška: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Uneseni ID nije validan broj!");
                            }
                        }
                        else if (searchChoice == "2")
                        {
                            Console.Write("Unesite naziv taska: ");
                            string nazivSearch = Console.ReadLine();
                            Console.WriteLine(taskSearch.searchByName(taskService.getList(), nazivSearch));
                        }
                        break;

                    case "6": // Sortiranje taskova
                        Console.Clear();
                        Console.WriteLine("1. Sortiraj po datumu");
                        Console.WriteLine("2. Sortiraj po važnosti");
                        Console.Write("Izaberite opciju: ");
                        string sortChoice = Console.ReadLine();

                        if (sortChoice == "1")
                        {
                            var sortedByDate = taskSort.sortByDate(taskService.getList());
                            Console.WriteLine("Taskovi sortirani po datumu:");
                            foreach (var task in sortedByDate)
                            {
                                Console.WriteLine($"{task.naziv} - {task.datum.ToShortDateString()}");
                            }
                        }
                        else if (sortChoice == "2")
                        {
                            var sortedByPriority = taskSort.sortByPriority(taskService.getList());
                            Console.WriteLine("Taskovi sortirani po važnosti:");
                            foreach (var task in sortedByPriority)
                            {
                                Console.WriteLine($"{task.naziv} - Važnost: {task.vaznost}");
                            }
                        }
                        break;

                    case "7": // Statistika
                        Console.Clear();
                        Console.WriteLine($"Broj završenih taskova: {statistic.GetCompletedTasksCount()} ");
                        Console.WriteLine($"Broj nezavršenih taskova: {statistic.GetPendingTasksCount()} ");
                        Console.WriteLine($"Kategorija s najviše završenih taskova: {statistic.GetCategoryWithMostCompletedTasks()}");
                        Console.WriteLine($"Kategorija s najmanje završenih taskova: {statistic.GetCategoryWithLeastCompletedTasks()}");

                        break;

                    case "8": // Izlaz
                        Console.WriteLine("Izlaz iz aplikacije...");
                        return;

                    default:
                        Console.WriteLine("Nevažeća opcija, pokušajte ponovo.");
                        break;


                }

                Console.WriteLine("\nPritisnite bilo koji taster za povratak u meni...");
                Console.ReadKey();

            }
        }
    }
}