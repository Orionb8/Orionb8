using System;
using TestProject.Interfaces;

namespace TestProject.Models.Dictionaries
{
    public class HBaseEntity:IHasId<int>
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
}

