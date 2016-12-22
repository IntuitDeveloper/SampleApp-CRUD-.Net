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
    public class CompanyCurrencyCRUD
    {
        #region Sync Methods


        #region  Add a currency to the active currency list


        public void CompanyCurrencyAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CompanyCurrency for Add
            CompanyCurrency companyCurrency = QBOHelper.CreateCompanyCurrency(qboContextoAuth);
            //Adding the CompanyCurrency
            CompanyCurrency added = Helper.Add<CompanyCurrency>(qboContextoAuth, companyCurrency);
        }

        #endregion


        #region  Update Operations


        public void CompanyCurrencyUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {

            QueryService<CompanyCurrency> entityQuery = new QueryService<CompanyCurrency>(qboContextoAuth);
            List<CompanyCurrency> foundall = entityQuery.ExecuteIdsQuery("SELECT * FROM CompanyCurrency").ToList<CompanyCurrency>();




            foreach (CompanyCurrency found in foundall)
            {
                CompanyCurrency changed = QBOHelper.UpdateCompanyCurrency(qboContextoAuth, found);
                //Update the returned entity data
                CompanyCurrency updated = Helper.Update<CompanyCurrency>(qboContextoAuth, changed);//Verify the updated CompanyCurrency

            }

        }



        #endregion



        #region  Query


        public void CompanyCurrencyQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<CompanyCurrency> entityQuery = new QueryService<CompanyCurrency>(qboContextoAuth);
            List<CompanyCurrency> exch = entityQuery.ExecuteIdsQuery("SELECT * FROM CompanyCurrency where SourceCurrencyCode in ('EUR', 'INR') and AsOfDate='2015-07-07'").ToList<CompanyCurrency>();

        }

        #endregion

        #endregion
    }
}