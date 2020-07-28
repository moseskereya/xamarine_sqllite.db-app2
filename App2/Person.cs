using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Nationality { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
    }
}
