using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KoreroModel.Models.common;

namespace KoreroModel.Models.Input
{
    public class ProjectInfoModel : Entity
    {
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string LiveUrl { get; set; }
        public string GitUrl { get; set; }
        public string TechUsed { get; set; }
        public int ProjectListId { get; set; }
    }

    public class TechUsed
    {
        public List<string> FrontEnd { get; set; }
        public List<string> BackEnd { get; set; }
    }




}
