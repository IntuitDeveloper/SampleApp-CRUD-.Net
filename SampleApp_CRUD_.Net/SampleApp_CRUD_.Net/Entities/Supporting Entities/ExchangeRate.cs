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
    public class ExchangeRateCRUD
    {
        #region Sync Methods





        #region  Update Operations


        public void ExchangeRateUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {

            QueryService<ExchangeRate> entityQuery = new QueryService<ExchangeRate>(qboContextoAuth);
            List<ExchangeRate> foundall = entityQuery.ExecuteIdsQuery("SELECT * FROM ExchangeRate where SourceCurrencyCode in ('INR') and AsOfDate='2015-07-07'").ToList<ExchangeRate>();




            foreach (ExchangeRate found in foundall)
            {
                ExchangeRate changed = QBOHelper.UpdateExchangeRate(qboContextoAuth, found);
                //Update the returned entity data
                ExchangeRate updated = Helper.Update<ExchangeRate>(qboContextoAuth, changed);//Verify the updated ExchangeRate

            }

        }



        #endregion



        #region  Query


        public void ExchangeRateQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<ExchangeRate> entityQuery = new QueryService<ExchangeRate>(qboContextoAuth);
            List<ExchangeRate> exch = entityQuery.ExecuteIdsQuery("SELECT * FROM ExchangeRate where SourceCurrencyCode in ('EUR', 'INR') and AsOfDate='2015-07-07'").ToList<ExchangeRate>();
    
        }

        #endregion

        #endregion
    }
}