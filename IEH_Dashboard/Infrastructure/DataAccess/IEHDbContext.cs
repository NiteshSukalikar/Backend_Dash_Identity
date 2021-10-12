namespace IEH_Dashboard.Infrastructure.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using IEH_Dashboard.Common.StaticConstants;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    /// <summary>
    /// Defines the <see cref="IEHDbContext" />
    /// </summary>
    public class IEHDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IEHDbContext"/> class.
        /// </summary>
        public IEHDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IEHDbContext"/> class.
        /// </summary>
        /// <param name="options">The info<see cref="DbContextOptions{SuluCRMDbContext}"/></param>
        public IEHDbContext(DbContextOptions<IEHDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// The GetDbConnection
        /// </summary>
        /// <returns>The <see cref="System.Data.Common.DbConnection"/></returns>
        public System.Data.Common.DbConnection GetDbConnection()
        {
            return this.Database.GetDbConnection();
        }

        /// <summary>
        /// The OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder">The optionsBuilder<see cref="DbContextOptionsBuilder"/></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //stagging
            optionsBuilder.UseSqlServer(Constants.DbConn);
        }

        /// <summary>
        /// The OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// The DataReaderMapToList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr">The modelBuilder<see cref="IDataReader"/></param>
        /// <returns>The <see cref="IList{T}"/></returns>
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

        /// <summary>
        /// The AddParametersToDbCommand
        /// </summary>
        /// <param name="commandText">The commandText<see cref="string"/></param>
        /// <param name="parameters">The cmd<see cref="object[]"/></param>
        /// <param name="cmd">The parameters<see cref="System.Data.Common.DbCommand"/></param>
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
    }
}
