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
    public class TaxAgencyCRUD
    {
        #region Sync Methods

        #region  Add Operations


        public void TaxAgencyAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Add
            TaxAgency taxAgency = QBOHelper.CreateTaxAgency(qboContextoAuth);
            //Adding the TaxAgency
            TaxAgency added = Helper.Add<TaxAgency>(qboContextoAuth, taxAgency);
            
        }

        #endregion

        #region  FindAll Operations


        public void TaxAgencyFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            TaxAgencyAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Bill using FindAll
            List<TaxAgency> taxAgencys = Helper.FindAll<TaxAgency>(qboContextoAuth, new TaxAgency(), 1, 500);
       
        }

        #endregion

        #region  FindbyId Operations

    
        public void TaxAgencyFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TaxAgency for Adding
            TaxAgency taxAgency = QBOHelper.CreateTaxAgency(qboContextoAuth);
            //Adding the TaxAgency
            TaxAgency added = Helper.Add<TaxAgency>(qboContextoAuth, taxAgency);
            TaxAgency found = Helper.FindById<TaxAgency>(qboContextoAuth, added);

        }

        #endregion



        #region  Query

        public void TaxAgencyQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<TaxAgency> entityQuery = new QueryService<TaxAgency>(qboContextoAuth);
            
            List<TaxAgency> test = entityQuery.ExecuteIdsQuery("SELECT * FROM TaxAgency").ToList<TaxAgency>();
        }

        #endregion

        #endregion
    }
}