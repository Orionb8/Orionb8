using System;
using TestProject.Models.Dictionaries;

namespace TestProject.ViewModels
{
	public class HFolderViewModel:BaseViewModel<HFolderEntity>
	{
		public HTabViewModel HTab { get; set; }
	}
}

