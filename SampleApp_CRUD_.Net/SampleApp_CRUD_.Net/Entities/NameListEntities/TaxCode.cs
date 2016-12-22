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
    public class TaxCodeCRUD
    {
        #region Sync 

        #region  Query

        public void TaxCodeQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<TaxCode> entityQuery = new QueryService<TaxCode>(qboContextoAuth);

            List<TaxCode> test = entityQuery.ExecuteIdsQuery("SELECT * FROM TaxCode").ToList<TaxCode>();
        }

        #endregion

        #endregion

    }
}