using System;
using TestProject.Models;

namespace TestProject.ViewModels
{
    public class UploadViewModel : BaseViewModel<UploadEntity>
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Наименование файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Guid
        /// </summary>
        public string downloadUrl { get; set; }

        /// <summary>
        /// Наименование файла для пользователя
        /// </summary>
        public string FileScreenName { get; set; }

        /// <summary>
        /// Размер файла в байтах
        /// </summary>
        public double FileSize { get; set; }
    }
}

