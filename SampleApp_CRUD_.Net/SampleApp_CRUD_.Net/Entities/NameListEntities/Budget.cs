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
    public class BudgetCRUD
    {
        #region Sync Methods

        

        #region  Query
         
        public void BudgetQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Budget> entityQuery = new QueryService<Budget>(qboContextoAuth);
            //Budget existing = Helper.FindOrAdd<Budget>(qboContextoAuth, new Budget());
            List<Budget> entities = entityQuery.ExecuteIdsQuery("select * from Budget").ToList();

        }

        #endregion

        #endregion

       



    }
}