using AdventureWorksSales.Core.Data;
using AdventureWorksSales.Repository;
using System;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace AdventureWorksSales.Services
{
    public class ReportService
    {
        private readonly QueryRepository<SalesOrder> _salesQueryRepository;

        public ReportService()
        {
            _salesQueryRepository = new QueryRepository<SalesOrder>();
        }

        /// <summary>
        /// Gets the total orders
        /// </summary>
        /// <returns></returns>
        public int GetTotalOrders()
        {
            return _salesQueryRepository.GetQueryableEntityNoTracking().Count();
        }

        /// <summary>
        /// Retrieves the Highest Line total in US Dollars
        /// </summary>
        /// <returns></returns>
        public string GetHighestLineTotal()
        {
            return _salesQueryRepository.GetQueryableEntityNoTracking().Max(order => order.LineTotal).ToString("C", new CultureInfo("en_US", false));
        }

        /// <summary>
        /// Retrieves the total sales made for Front Brakes product
        /// </summary>
        /// <returns></returns>
        public int GetFrontBrakesTotal()
        {
            int frontBrakesId = Convert.ToInt32(ConfigurationManager.AppSettings["FrontBrakesId"]);
            return _salesQueryRepository.GetQueryableEntityNoTracking().Where(saleOrder => saleOrder.ProductID == frontBrakesId).Count();
        }
    }
}
