using KoreroBAL.Interface;
using KoreroDAL.ConnectionString;
using KoreroDAL.Interface;
using KoreroModel.Models.Input;
using System.Collections.Generic;

namespace KoreroBAL.Implimentation
{
    public class Project : IProject
    {
        private readonly IDataAccess _data;
        private readonly ConnectionStringData _connection;

        public Project(IDataAccess data, ConnectionStringData connection)
        {
            _data = data;
            _connection = connection;
        }
        public List<ProjectModel> GetProjects()
        {
            return _data.LoadData<ProjectModel, dynamic>("select * from dbo.Project", new { }, _connection.ConnectionStringName);
        }


    }
}
