using IEH_Identity.Common;
using IEH_Identity.Data;
using IEH_Identity.Entity;
using IEH_Identity.IService;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Identity.service
{
    public class DataService :IDataService
    {
        protected readonly ApplicationDbContext _IEHDbContext;

        public DataService(ApplicationDbContext IEHDbContext)
        {
            _IEHDbContext = IEHDbContext;
          
        }
        public User GetUserById(string id)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Id",id),
                    

                };
                var connection = _IEHDbContext.GetDbConnection();
                User result = new User();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetUserById, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<User>(reader).FirstOrDefault();
                            reader.NextResult();
                        }
                    }
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }
        public User GetUserByEmail(string email)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@email",email),


                };
                var connection = _IEHDbContext.GetDbConnection();
                User result = new User();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetUserByEmail, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<User>(reader).FirstOrDefault();
                            reader.NextResult();
                        }
                    }
                    return result;
                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



}
