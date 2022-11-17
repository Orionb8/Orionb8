using System;
using TestProject.Interfaces;

namespace TestProject.Models {
    public class BaseEntity : ITrackable, IRecoverable, IHasId<int> {
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Кем создано
        /// </summary>
        public string CreatedByUser { get; set; }
        /// <summary>
        /// Когда создано
        /// </summary>
        public DateTime CreatedAtTime { get; set; }
        /// <summary>
        /// Кем обновлено
        /// </summary>
        public string UpdatedByUser { get; set; }
        /// <summary>
        /// Когда обновлено
        /// </summary>
        public DateTime? UpdatedAtTime { get; set; }
        /// <summary>
        /// Удаленная ли запись
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Кем удалено
        /// </summary>
        public string DeletedByUser { get; set; }
        /// <summary>
        /// Время удаления
        /// </summary>
        public DateTime? DeletedAtTime { get; set; }
    }
}
