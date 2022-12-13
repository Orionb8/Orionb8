using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models.Dictionaries
{
    public class HFolderEntity : HBaseEntity
    {
        public int? HTabId { get; set; }
        [ForeignKey(nameof(HTabId))]
        public HTabEntity HTab { get; set; }
    }
}

