using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ToDo_webapi.Models
{
    public class ToDoTask
    {
        private static int maxid = 0;
        private int id;
        public int Id { get => id; }
        public string Topic { get; set; } = string.Empty;
        public bool IsComplite { get; set; }
        public string? Description { get; set; }
        private DateOnly creationDate;
        public DateOnly CreationDate { get => creationDate; }
        public DateOnly? EndDate { get; set; }
        public ushort? Priority { get; set; }
        public string? Category { get; set; }
        public List<Person>? Persons { get; set; }

        public static bool operator ==(ToDoTask? left, ToDoTask? right)
        {
            if (left is null || right is null) return false;
            if (left.Topic == right.Topic && left.Description == right.Description)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(ToDoTask? left, ToDoTask? right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return this.Topic.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is ToDoTask)
            {
                return ((ToDoTask)obj) == this;
            }
            return false;
        }

        public ToDoTask(string Topic, bool IsComplite, string? Description, DateOnly? EndDate, ushort? Priority, string? Category, List<Person>? Persons)
        {
            id = maxid++;
            this.Topic = Topic;
            this.IsComplite = IsComplite;
            this.Description = Description;
            creationDate = DateOnly.FromDateTime(DateTime.Now);
            this.EndDate = EndDate;
            this.Priority = Priority;
            this.Category = Category;
            this.Persons = Persons;
        }
    }
}