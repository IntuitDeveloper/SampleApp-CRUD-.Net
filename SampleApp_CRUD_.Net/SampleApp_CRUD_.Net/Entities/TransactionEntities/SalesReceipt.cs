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
    public class SalesReceiptCRUD
    {
        #region Sync Methods

        #region  Add Operations

        
        public void SalesReceiptAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the SalesReceipt for Add
            SalesReceipt salesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth);
            //Adding the SalesReceipt
            SalesReceipt added = Helper.Add<SalesReceipt>(qboContextoAuth, salesReceipt);

        }

        #endregion

        #region  FindAll Operations

        
        public void SalesReceiptFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            SalesReceiptAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the SalesReceipt using FindAll
            List<SalesReceipt> salesReceipts = Helper.FindAll<SalesReceipt>(qboContextoAuth, new SalesReceipt(), 1, 500);

        }

        #endregion

        #region  FindbyId Operations

        
        public void SalesReceiptFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the SalesReceipt for Adding
            SalesReceipt salesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth);
            //Adding the SalesReceipt
            SalesReceipt added = Helper.Add<SalesReceipt>(qboContextoAuth, salesReceipt);
            SalesReceipt found = Helper.FindById<SalesReceipt>(qboContextoAuth, added);
   
        }

        #endregion

        #region  Update Operations

        
        public void SalesReceiptUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {

            //Creating the SalesReceipt for Adding
            SalesReceipt salesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth);
            //Adding the SalesReceipt
            SalesReceipt added = Helper.Add<SalesReceipt>(qboContextoAuth, salesReceipt);
            //Change the data of added entity
            SalesReceipt changed = QBOHelper.UpdateSalesReceipt(qboContextoAuth, added);
            //Update the returned entity data
            SalesReceipt updated = Helper.Update<SalesReceipt>(qboContextoAuth, changed);//Verify the updated SalesReceipt
   
        }

        
        public void SalesReceiptSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the SalesReceipt for Adding
            SalesReceipt salesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth);
            //Adding the SalesReceipt
            SalesReceipt added = Helper.Add<SalesReceipt>(qboContextoAuth, salesReceipt);
            //Change the data of added entity
            SalesReceipt changed = QBOHelper.SparseUpdateSalesReceipt(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            SalesReceipt updated = Helper.Update<SalesReceipt>(qboContextoAuth, changed);//Verify the updated SalesReceipt

        }

        #endregion

        #region  Delete Operations

        
        public void SalesReceiptDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the SalesReceipt for Adding
            SalesReceipt salesReceipt = QBOHelper.CreateSalesReceipt(qboContextoAuth);
            //Adding the SalesReceipt
            SalesReceipt added = Helper.Add<SalesReceipt>(qboContextoAuth, salesReceipt);
            //Delete the returned entity
            try
            {
                SalesReceipt deleted = Helper.Delete<SalesReceipt>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }

        
       
        #endregion

        #region  CDC Operations

        
        public void SalesReceiptCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            SalesReceiptAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the SalesReceipt using FindAll
            List<SalesReceipt> salesReceipts = Helper.CDC(qboContextoAuth, new SalesReceipt(), DateTime.Today.AddDays(-1));
 
        }

        #endregion

        #region  Batch

        
        public void SalesReceiptBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            SalesReceipt existing = Helper.FindOrAdd(qboContextoAuth, new SalesReceipt());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateSalesReceipt(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateSalesReceipt(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from SalesReceipt");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<SalesReceipt>(qboContextoAuth, batchEntries);

            
        }

        #endregion

        #region  Query
        
        public void SalesReceiptQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<SalesReceipt> entityQuery = new QueryService<SalesReceipt>(qboContextoAuth);
            SalesReceipt existing = Helper.FindOrAdd<SalesReceipt>(qboContextoAuth, new SalesReceipt());
            List<SalesReceipt> test = entityQuery.ExecuteIdsQuery("SELECT * FROM SalesReceipt where Id='" + existing.Id+"'").ToList<SalesReceipt>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void SalesReceiptAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the SalesReceipt for Add
            SalesReceipt entity = QBOHelper.CreateSalesReceipt(qboContextoAuth);

            SalesReceipt added = Helper.AddAsync<SalesReceipt>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation

        
        public void SalesReceiptRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            SalesReceiptAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the SalesReceipt using FindAll
            Helper.FindAllAsync<SalesReceipt>(qboContextoAuth, new SalesReceipt());
        }

        #endregion

        #region  FindById Operation

        
        public void SalesReceiptFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the SalesReceipt for Adding
            SalesReceipt entity = QBOHelper.CreateSalesReceipt(qboContextoAuth);
            //Adding the SalesReceipt
            SalesReceipt added = Helper.Add<SalesReceipt>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<SalesReceipt>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        
        public void SalesReceiptUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the SalesReceipt for Adding
            SalesReceipt entity = QBOHelper.CreateSalesReceipt(qboContextoAuth);
            //Adding the SalesReceipt
            SalesReceipt added = Helper.Add<SalesReceipt>(qboContextoAuth, entity);

            //Update the SalesReceipt
            SalesReceipt updated = QBOHelper.UpdateSalesReceipt(qboContextoAuth, added);
            //Call the service
            SalesReceipt updatedReturned = Helper.UpdateAsync<SalesReceipt>(qboContextoAuth, updated);
            
        }

        #endregion

        #region  Delete Operation

        
        public void SalesReceiptDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the SalesReceipt for Adding
            SalesReceipt entity = QBOHelper.CreateSalesReceipt(qboContextoAuth);
            //Adding the SalesReceipt
            SalesReceipt added = Helper.Add<SalesReceipt>(qboContextoAuth, entity);

            Helper.DeleteAsync<SalesReceipt>(qboContextoAuth, added);
        }

        #endregion


        #endregion
    }
}