using System;
using System.Collections.Generic;
using System.Linq;
using ToDo_webapi.Models;

namespace ToDo_webapi.Services
{
    public static class ToDoTaskServices
    {
        private static List<ToDoTask> ToDoTasks = new List<ToDoTask>([
            new ToDoTask("Przetestować webapi", false, "No co tu dużo opowiadać, jak do 22.01 nie dokończysz testów to będziesz łamany", DateOnly.FromDateTime(DateTime.Now), 1, "studia", new List<Person>([new Person("Piotrek", "Kula", "Normalnie go poznałem w liceum i od tego czasu cały czas mi mówi \"YEEES SIIIIR\""), new Person("Prowadzący", null, null)]))
            ,new ToDoTask("iść na siłkę", false, "Weź się grubasie do roboty bo formę na lato to ty będziesz miał za 2 lata", DateOnly.FromDateTime(DateTime.Now), 4, null, null)
            ,new ToDoTask("Napisać betę webapi", true, "Coś niecoś potrafię nie? B)", DateOnly.FromDateTime(DateTime.Now), 4, null, new List<Person>([new Person("Prowadzący", null, null)]))
            ,new ToDoTask("YES SIIIR", false, null, null, null, null, null)
            ,new ToDoTask("Jeszcze jakiś dla testu nie?", true, null, null, null, null, null)
            ,new ToDoTask("Napisać Magiesterkę", false, null, null, null, null, null)

        ]);

        public static void AddToDoTask(ToDoTask ToDoTask)
        {
            ToDoTasks.Add(ToDoTask);
        }

        public static bool DeleteToDoTask(ToDoTask ToDoTask)
        {
            if (ToDoTasks.Contains(ToDoTask))
            {
                ToDoTasks.Remove(ToDoTask);
                return true;
            }
            return false;
        }
        
        public static bool DeleteToDoTask(int id)
        {
            
            foreach (var ToDoTask in ToDoTasks)
            {
                if (ToDoTask.Id == id)
                {
                    ToDoTasks.Remove(ToDoTask);
                    return true;     
                }
            }
            return false;
        }

        public static bool UpdateToDoTask(int id, ToDoTask ToDoTask)
        {
            
            ToDoTask? ToDoTaskk = ToDoTasks.Find(t => t.Id == id);
            
            if (ToDoTaskk != null)
            {
                ToDoTaskk = ToDoTask;
                return true;
            }
            return false;
        }
        public static List<ToDoTask> GetAllToDoTasks()
        {
            return ToDoTasks;
        }

        public static List<ToDoTask> GetToDoTasksByCreationDate(DateOnly toDate)
        {
            return ToDoTasks.FindAll(t => t.CreationDate <= toDate);
        }

        public static List<ToDoTask> GetToDoTasksByPeoples()
        {
            return ToDoTasks.FindAll(t => t.Persons != null);
        }

        public static List<ToDoTask> GetToDoTasksByPriority(ushort priority)
        {
            return ToDoTasks.FindAll(t => t.Priority <= priority);
        }

        public static List<ToDoTask> GetToDoTasksByCategory(string category)
        {
            return ToDoTasks.FindAll(t => t.Category == category);
        }

        public static List<ToDoTask> GetToDoTasksByComplite(bool isComplite)
        {
            return ToDoTasks.FindAll(t => t.IsComplite == isComplite);
        }
        public static bool MarkAsDone(ToDoTask task)
        {
            int index = ToDoTasks.FindIndex(t => t == task);
            if (index == -1)
                return false;
            ToDoTasks[index].IsComplite = true;
            return true;
        }
        
        public static bool MarkAsDone(int id)
        {
            int index = ToDoTasks.FindIndex(t => t.Id == id);
            if (index == -1)
                return false;
            ToDoTasks[index].IsComplite = true;
            return true;
        }
    }
}