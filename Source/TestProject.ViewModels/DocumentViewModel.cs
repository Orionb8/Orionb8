using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Models;
using TestProject.Models.Dictionaries;

namespace TestProject.ViewModels
{
	public class DocumentViewModel:BaseViewModel<DocumentEntity>
	{
        public DateTime? RegisterDate { get; set; }
        public ProjectViewModel Project { get; set; }
        public HTabViewModel HTab { get; set; }
        public HFolderViewModel HFolder { get; set; }
        public HDocumentTypeViewModel HDocumentType { get; set; }
        public UploadViewModel Upload { get; set; }
    }
}

