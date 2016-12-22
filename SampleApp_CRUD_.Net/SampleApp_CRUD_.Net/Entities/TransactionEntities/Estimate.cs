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
    public class EstimateCRUD
    {
        #region Sync Methods

        #region  Add Operations

         
        public void EstimateAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Add
            Estimate estimate = QBOHelper.CreateEstimate(qboContextoAuth);
            //Adding the Estimate
            Estimate added = Helper.Add<Estimate>(qboContextoAuth, estimate);
          
        }

        #endregion

        #region  FindAll Operations

         
        public void EstimateFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            EstimateAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Estimate using FindAll
            List<Estimate> estimates = Helper.FindAll<Estimate>(qboContextoAuth, new Estimate(), 1, 500);
          
        }

        #endregion

        #region  FindbyId Operations

         
        public void EstimateFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Adding
            Estimate estimate = QBOHelper.CreateEstimate(qboContextoAuth);
            //Adding the Estimate
            Estimate added = Helper.Add<Estimate>(qboContextoAuth, estimate);
            Estimate found = Helper.FindById<Estimate>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

         
        public void EstimateUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Adding
            Estimate estimate = QBOHelper.CreateEstimate(qboContextoAuth);
            //Adding the Estimate
            Estimate added = Helper.Add<Estimate>(qboContextoAuth, estimate);
            //Change the data of added entity
            Estimate changed = QBOHelper.UpdateEstimate(qboContextoAuth, added);
            //Update the returned entity data
            Estimate updated = Helper.Update<Estimate>(qboContextoAuth, changed);//Verify the updated Estimate

        }

         
        public void EstimateSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Adding
            Estimate estimate = QBOHelper.CreateEstimate(qboContextoAuth);
            //Adding the Estimate
            Estimate added = Helper.Add<Estimate>(qboContextoAuth, estimate);
            //Change the data of added entity
            Estimate changed = QBOHelper.SparseUpdateEstimate(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Estimate updated = Helper.Update<Estimate>(qboContextoAuth, changed);//Verify the updated Estimate
        
        }

        #endregion

        #region  Delete Operations

         
        public void EstimateDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Adding
            Estimate estimate = QBOHelper.CreateEstimate(qboContextoAuth);
            //Adding the Estimate
            Estimate added = Helper.Add<Estimate>(qboContextoAuth, estimate);
            //Delete the returned entity
            try
            {
                Estimate deleted = Helper.Delete<Estimate>(qboContextoAuth, added);
               
            }
            catch (IdsException ex)
            {
              
            }
        }

     

        #endregion

        #region  CDC Operations

         
        public void EstimateCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            EstimateAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Estimate using FindAll
            List<Estimate> estimates = Helper.CDC(qboContextoAuth, new Estimate(), DateTime.Today.AddDays(-1));
           
        }

        #endregion

        #region  Batch

         
        public void EstimateBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Estimate existing = Helper.FindOrAdd(qboContextoAuth, new Estimate());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateEstimate(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateEstimate(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Estimate");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Estimate>(qboContextoAuth, batchEntries);
            
        }

        #endregion

        #region  Query
         
        public void EstimateQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Estimate> entityQuery = new QueryService<Estimate>(qboContextoAuth);
            Estimate existing = Helper.FindOrAdd<Estimate>(qboContextoAuth, new Estimate());
            List<Estimate> es = entityQuery.ExecuteIdsQuery("SELECT * FROM Estimate where Id='" + existing.Id+"'").ToList<Estimate>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

         
        public void EstimateAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Add
            Estimate entity = QBOHelper.CreateEstimate(qboContextoAuth);

            Estimate added = Helper.AddAsync<Estimate>(qboContextoAuth, entity);
   
        }

        #endregion

        #region  FindAll Operation

         
        public void EstimateRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            EstimateAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Estimate using FindAll
            Helper.FindAllAsync<Estimate>(qboContextoAuth, new Estimate());
        }

        #endregion

        #region  FindById Operation

         
        public void EstimateFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Adding
            Estimate entity = QBOHelper.CreateEstimate(qboContextoAuth);
            //Adding the Estimate
            Estimate added = Helper.Add<Estimate>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Estimate>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

         
        public void EstimateUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Adding
            Estimate entity = QBOHelper.CreateEstimate(qboContextoAuth);
            //Adding the Estimate
            Estimate added = Helper.Add<Estimate>(qboContextoAuth, entity);

            //Update the Estimate
            Estimate updated = QBOHelper.UpdateEstimate(qboContextoAuth, added);
            //Call the service
            Estimate updatedReturned = Helper.UpdateAsync<Estimate>(qboContextoAuth, updated);
           
        }

        #endregion

        #region  Delete Operation

         
        public void EstimateDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Estimate for Adding
            Estimate entity = QBOHelper.CreateEstimate(qboContextoAuth);
            //Adding the Estimate
            Estimate added = Helper.Add<Estimate>(qboContextoAuth, entity);

            Helper.DeleteAsync<Estimate>(qboContextoAuth, added);
        }

        #endregion

      

        #endregion

    }
}