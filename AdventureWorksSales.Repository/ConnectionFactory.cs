using AdventureWorksSales.Core.Data;
using System.Data.Entity;

namespace AdventureWorksSales.Repository
{
    /// <summary>
    /// Creates a single instance (singleton) DB Context for connection to Database
    /// </summary>
    public static class ConnectionFactory
    {
        private static readonly DbContext _dbContext = new AdventureWorksSalesEntities();
        public static DbContext DbContext { get { return _dbContext; } }
    }
}
