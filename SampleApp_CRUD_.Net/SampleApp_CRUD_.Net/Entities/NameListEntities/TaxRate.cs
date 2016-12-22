using System;
using System.Collections.Generic;
using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.QueryFilter;
using Intuit.Ipp.DataService;
using Intuit.Ipp.Exception;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleApp_CRUD_DotNet
{
    public class TaxRateCRUD
    {
        #region Sync 

        #region  Query

        public void TaxRateQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<TaxRate> entityQuery = new QueryService<TaxRate>(qboContextoAuth);

            List<TaxRate> test = entityQuery.ExecuteIdsQuery("SELECT * FROM TaxRate").ToList<TaxRate>();
        }

        #endregion


        #endregion
    }
}