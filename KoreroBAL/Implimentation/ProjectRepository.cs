using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System;
using KoreroBAL.Interface;
using KoreroDAL.ConnectionString;
using KoreroDAL.Interface;
using KoreroModel.Models.Input;
using KoreroModel.Models.Output;
using System.Collections.Generic;
using System.Linq;
using Dapper;

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
            project.CreatedAt = DateTime.Now;
            project.ModifiedAt = DateTime.Now;
            string sQuery = "INSERT INTO dbo.ProjectList VALUES (@ProjectName, @CreatedAt, @ModifiedAt); ";
            return _data.SaveData(sQuery, project, _connection.ConnectionStringName);
        }
        public ProjectInfoDTO GetProjectInfo(int Id)
        {
            //string sQuery = "SELECT * FROM dbo.ProjectInfo WHERE id = @Id";
            string sJoinQuery = "select * from dbo.ProjectInfo pi inner join dbo.ProjectList pl on pi.ProjectListId = pl.id  where pl.id = @Id";
            return _data.LoadData<ProjectInfoDTO, dynamic>(sJoinQuery, new { id = Id }, _connection.ConnectionStringName).FirstOrDefault();
        }
        public List<ProjectListModel> GetProjects()
        {
            string sQuery = "SELECT * FROM dbo.ProjectList";
            var rows = _data.LoadData<ProjectListModel, dynamic>(sQuery, new { }, _connection.ConnectionStringName);
            if (rows.Count == 0)
            {
                throw new Exception("No projects");
            }
            return rows;
        }
        public int UpdateProject(string projectName, int Id)
        {
            // project.CreatedAt = DateTime.UtcNow;
            string sQuery = "UPDATE dbo.ProjectList SET ProjectName = @ProjectName WHERE Id = @Id ";
            return _data.SaveData(sQuery, new { Id = Id, ProjectName = projectName }, _connection.ConnectionStringName);
        }
        public int DeleteProject(int Id)
        {
            string sQuery = "DELETE FROM dbo.ProjectList WHERE Id = @Id";
            return _data.SaveData(sQuery, new { Id }, _connection.ConnectionStringName);
        }

        public int InsertProjectInfo(ProjectInfoModel projectInfo)
        {
            var proInfo = new ProjectInfoModel
            {
                Description = projectInfo.Description,
                ProjectListId = projectInfo.ProjectListId,
                ProjectName = projectInfo.ProjectName,
                LiveUrl = projectInfo.LiveUrl,
                GitUrl = projectInfo.GitUrl,
                TechUsed = projectInfo.TechUsed,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            string sQuery = "INSERT INTO dbo.ProjectInfo (ProjectName, Description, LiveUrl,GitUrl,ProjectListId,TechUsed,CreatedAt,ModifiedAt) VALUES (@ProjectName, @Description, @LiveUrl,@GitUrl,@ProjectListId,@TechUsed,@CreatedAt,@ModifiedAt ); ";
            return _data.SaveData(sQuery, proInfo, _connection.ConnectionStringName);
            // return p.Get<int>("Id");
        }
        public int UpdateProjectInfo(ProjectInfoUpdate projectInfoModel)
        {
            string sQuery = "UPDATE dbo.ProjectInfo SET ProjectName = @ProjectName, Description =@Description,LiveUrl=@LiveUrl, GitUrl=@GitUrl ,TechUsed=@TechUsed,ModifiedAt=@ModifiedAt WHERE ProjectListId = @ProjectListId";
            return _data.SaveData(sQuery, new { projectInfoModel.ProjectListId, projectInfoModel.Description, projectInfoModel.LiveUrl, projectInfoModel.GitUrl, projectInfoModel.ProjectName, projectInfoModel.TechUsed, ModifiedAt = DateTime.Now }, _connection.ConnectionStringName);
        }


    }
}
