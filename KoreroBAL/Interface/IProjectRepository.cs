using KoreroModel.Models.Input;
using KoreroModel.Models.Output;
using System.Collections.Generic;

namespace KoreroBAL.Interface
{
    public interface IProjectRepository
    {
        List<ProjectListModel> GetProjects();
        ProjectInfoDTO GetProjectInfo(int Id);
        int CreateNewProject(ProjectListModel project);
        int DeleteProject(int Id);
        int UpdateProject(string projectName, int Id);
    }
}