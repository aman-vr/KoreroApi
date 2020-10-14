using KoreroBAL.Interface;
using KoreroDAL.ConnectionString;
using KoreroDAL.Interface;
using KoreroModel.Models.Input;
using KoreroModel.Models.Output;
using System.Collections.Generic;
using System.Linq;

namespace KoreroBAL.Implimentation
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDataAccess _data;
        private readonly ConnectionStringData _connection;

        public ProjectRepository(IDataAccess data, ConnectionStringData connection)
        {
            _data = data;
            _connection = connection;
        }

        public int CreateNewProject(ProjectListModel project)
        {
            string sQuery = "INSERT INTO dbo.ProjectList VALUES (@ProjectName); ";
            return _data.SaveData(sQuery, project, _connection.ConnectionStringName);
        }

        public ProjectInfoDTO GetProjectInfo(int Id)
        {
            //string sQuery = "SELECT * FROM dbo.ProjectInfo WHERE id = @Id";
            string sJoinQuery = "select * from dbo.ProjectInfo pi inner join dbo.ProjectList pl on pi.ProjectListId = pl.id  where pi.id = @Id";
            return _data.LoadData<ProjectInfoDTO, dynamic>(sJoinQuery, new { id = Id }, _connection.ConnectionStringName).FirstOrDefault();
        }

        public List<ProjectListModel> GetProjects()
        {
            string sQuery = "SELECT * FROM dbo.ProjectList";
            return _data.LoadData<ProjectListModel, dynamic>(sQuery, new { }, _connection.ConnectionStringName);
        }

        public int UpdateProject(string projectName, int Id)
        {
            string sQuery = "UPDATE dbo.ProjectList SET ProjectName = @ProjectName WHERE Id = @Id ";
            return _data.SaveData(sQuery, new { Id = Id, ProjectName = projectName }, _connection.ConnectionStringName);
        }

        public int DeleteProject(int Id)
        {
            string sQuery = "DELETE FROM dbo.ProjectList WHERE Id = @Id";
            return _data.SaveData(sQuery, new { Id }, _connection.ConnectionStringName);
        }
    }
}
