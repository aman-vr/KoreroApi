using KoreroModel.Models.Input;
using System.Collections.Generic;

namespace KoreroBAL.Interface
{
    public interface IProject
    {
        List<ProjectModel> GetProjects();
    }
}