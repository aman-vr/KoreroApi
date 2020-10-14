using System.Collections.Generic;
using System.Linq;
using KoreroBAL.Interface;
using KoreroModel.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace KoreroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject _project;

        public ProjectController(IProject project)
        {
            _project = project;
        }

        [HttpGet]
        public List<ProjectModel> GetProjects()
        {
            var projects = _project.GetProjects();
            return projects;
        }
    }
}
