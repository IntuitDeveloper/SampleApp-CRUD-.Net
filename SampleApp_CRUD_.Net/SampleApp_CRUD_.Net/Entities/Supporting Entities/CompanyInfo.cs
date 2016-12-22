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
    public class CompanyInfoCRUD
    {
        #region  Query
       
        public void CompanyInfoQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<CompanyInfo> entityQuery = new QueryService<CompanyInfo>(qboContextoAuth);
            List<CompanyInfo> comp = entityQuery.ExecuteIdsQuery("SELECT * FROM CompanyInfo").ToList<CompanyInfo>();

        }
        #endregion
    }
}