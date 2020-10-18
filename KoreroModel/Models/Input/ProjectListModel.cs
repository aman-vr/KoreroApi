using System.ComponentModel.DataAnnotations;
using KoreroModel.Models.common;

namespace KoreroModel.Models.Input
{
    public class ProjectListModel : Entity
    {
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        InProgress,
        Completed,
        Todo,
        ForFuture

    }
}
