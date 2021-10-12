using IEH_Identity.Common;
using IEH_Identity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IEH_Identity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public System.Data.Common.DbConnection GetDbConnection()
        {
            return this.Database.GetDbConnection();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //stagging
            optionsBuilder.UseSqlServer(Constants.DbConn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public IList<T> DataReaderMapToList<T>(IDataReader dr)
        {
            IList<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())               //Solution - Check if property is there in the reader and then try to remove try catch code
                {
                    try
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    catch { continue; }
                }
                list.Add(obj);
            }
            return list;
        }
        public void AddParametersToDbCommand(string commandText, object[] parameters, System.Data.Common.DbCommand cmd)
        {
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1000;
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    if (p != null)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
            }
        }
        public DbSet<User> Users { get; set; }
    }
}
