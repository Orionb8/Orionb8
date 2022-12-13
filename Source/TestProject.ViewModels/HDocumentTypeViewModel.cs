using System;
using TestProject.Models.Dictionaries;

namespace TestProject.ViewModels
{
	public class HDocumentTypeViewModel:BaseViewModel<HDocumentTypeEntity>
	{
		public HTabViewModel HTab { get; set; }
		public HFolderViewModel HFolder { get; set; }
	}
}

