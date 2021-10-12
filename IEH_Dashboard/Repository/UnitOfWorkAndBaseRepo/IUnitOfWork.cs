namespace IEH_Dashboard.Repository.UnitOfWorkAndBaseRepo
{
    using IEH_Dashboard.Repository.Interfaces;
    using System;

    /// <summary>
    /// Defines the <see cref="IUnitOfWork" />
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the AdminDashboard
        /// </summary>
        IDashboardRepository AdminDashboard { get; }

        /// <summary>
        /// The Complete
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        int Complete();
    }
}
