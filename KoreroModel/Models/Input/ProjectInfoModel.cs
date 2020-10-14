using System;
using System.Collections.Generic;
using System.Text;

namespace KoreroModel.Models.Input
{
    public class ProjectInfoModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string LiveUrl { get; set; }
        public string GitUrl { get; set; }
        public string TechUsed { get; set; }
        public int ProjectListId { get; set; }
    }
}
