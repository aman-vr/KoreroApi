using System.Collections.Generic;

namespace KoreroDAL.Interface
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string sqlString, U parameters, string connectionStringName);
        int SaveData<U>(string sqlString, U parameters, string connectionStringName);
    }
}
