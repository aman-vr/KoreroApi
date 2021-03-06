﻿using System.Collections.Generic;
using KoreroBAL.Interface;
using KoreroModel.Models.Input;
using Microsoft.AspNetCore.Mvc;

namespace KoreroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _project;

        public ProjectController(IProjectRepository project)
        {
            _project = project;
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public List<ProjectListModel> GetProjects()
        {
            var projects = _project.GetProjects();
            return projects;
        }

        [HttpPost]
        [Route("GetProjectInfo/{Id}")]
        public IActionResult GetProjectInfo(int Id)
        {
            var projectInfo = _project.GetProjectInfo(Id);
            return Ok(projectInfo);
        }

        [HttpPost]
        [Route("CreateProject")]
        public IActionResult CreateProject(ProjectListModel project)
        {
            return Ok(_project.CreateNewProject(project));
        }
        [HttpPost]
        [Route("UpdateProject/{Id}")]
        public IActionResult UpdateProject(string projectName, int Id)
        {
            return Ok(_project.UpdateProject(projectName, Id));
        }
        [HttpPost]
        [Route("DeleteProject/{Id}")]
        public IActionResult DeleteProject(int Id)
        {
            return Ok(_project.DeleteProject(Id));
        }
     
    }
}
