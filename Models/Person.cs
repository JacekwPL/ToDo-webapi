using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_webapi.Models
{
    public class Person
    {
        private static int maxid = 0;
        private int id;
        public int Id { get => id; }
        public string Name { get; set; } = String.Empty;
        public string? Surrname { get; set; }
        public string? Description { get; set; }
        public Person(string Name, string? Surrname, string? Description)
        {
            id = maxid++;
            this.Name = Name;
            this.Surrname = Surrname;
            this.Description = Description;
        }
    }
}