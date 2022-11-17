using System;
using TestProject.Interfaces;

namespace TestProject.Models
{
    public class HBaseEntity:IHasId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

