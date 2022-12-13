using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Models.Dictionaries;

namespace TestProject.Models
{
    public class DocumentEntity : BaseEntity
    {
        public DateTime? RegisterDate { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public ProjectEntity Project { get; set; }

        public int HTabId { get; set; }
        [ForeignKey(nameof(HTabId))]
        public HTabEntity HTab { get; set; }

        public int? HFolderId { get; set; }
        [ForeignKey(nameof(HFolderId))]
        public HFolderEntity HFolder { get; set; }

        public int HDocumentTypeId { get; set; }
        [ForeignKey(nameof(HDocumentTypeId))]
        public HDocumentTypeEntity HDocumentType { get; set; }

        public int? UploadId { get; set; }
        [ForeignKey(nameof(UploadId))]
        public UploadEntity Upload { get; set; }
    }
}

