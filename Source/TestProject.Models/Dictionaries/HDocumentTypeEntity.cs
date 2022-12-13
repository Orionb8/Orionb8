using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models.Dictionaries
{
	public class HDocumentTypeEntity:HBaseEntity
	{
        public int HTabId { get; set; }
        [ForeignKey(nameof(HTabId))]
        public HTabEntity HTab { get; set; }

        public int? HFolderId { get; set; }
        [ForeignKey(nameof(HFolderId))]
        public HFolderEntity HFolder { get; set; }
    }
}

