namespace IEH_Dashboard.Repository.UnitOfWorkAndBaseRepo
{
    using IEH_Dashboard.Infrastructure.DataAccess;
    using IEH_Dashboard.Repository.Implementations;
    using IEH_Dashboard.Repository.Interfaces;
    using System;

    /// <summary>
    /// Defines The UnitOfWork />
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Defines the _context
        /// </summary>
        private readonly IEHDbContext _context;

        /// <summary>
        /// Defines the adminDashboardRepository
        /// </summary>
        private IDashboardRepository adminDashboardRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="IEHDbContext"/></param>
        public UnitOfWork(IEHDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The Complete
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Gets the AdminDashboard
        /// </summary>
        public IDashboardRepository AdminDashboard
        {
            get
            {

                if (adminDashboardRepository == null)
                {
                    adminDashboardRepository = new DashboardRepository(_context);
                }
                return adminDashboardRepository;

            }
        }

        /// <summary>
        /// Defines the disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
