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
    public class RefundReceiptCRUD
    {
        #region Sync Methods

        #region  Add Operations

        
        public void RefundReceiptAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Add
            RefundReceipt refundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth);
            //Adding the RefundReceipt
            RefundReceipt added = Helper.Add<RefundReceipt>(qboContextoAuth, refundReceipt);

        }

        #endregion

        #region  FindAll Operations

        
        public void RefundReceiptFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            RefundReceiptAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the RefundReceipt using FindAll
            List<RefundReceipt> refundReceipts = Helper.FindAll<RefundReceipt>(qboContextoAuth, new RefundReceipt(), 1, 500);
       
        }

        #endregion

        #region  FindbyId Operations

        
        public void RefundReceiptFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Adding
            RefundReceipt refundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth);
            //Adding the RefundReceipt
            RefundReceipt added = Helper.Add<RefundReceipt>(qboContextoAuth, refundReceipt);
            RefundReceipt found = Helper.FindById<RefundReceipt>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

        
        public void RefundReceiptUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Adding
            RefundReceipt refundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth);
            //Adding the RefundReceipt
            RefundReceipt added = Helper.Add<RefundReceipt>(qboContextoAuth, refundReceipt);
            //Change the data of added entity
            RefundReceipt changed = QBOHelper.UpdateRefundReceipt(qboContextoAuth, added);
            //Update the returned entity data
            RefundReceipt updated = Helper.Update<RefundReceipt>(qboContextoAuth, changed);//Verify the updated RefundReceipt

        }

        
        public void RefundReceiptSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Adding
            RefundReceipt refundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth);
            //Adding the RefundReceipt
            RefundReceipt added = Helper.Add<RefundReceipt>(qboContextoAuth, refundReceipt);
            //Change the data of added entity
            RefundReceipt changed = QBOHelper.UpdateRefundReceiptSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            RefundReceipt updated = Helper.Update<RefundReceipt>(qboContextoAuth, changed);//Verify the updated RefundReceipt

        }

        #endregion

        #region  Delete Operations

        
        public void RefundReceiptDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Adding
            RefundReceipt refundReceipt = QBOHelper.CreateRefundReceipt(qboContextoAuth);
            //Adding the RefundReceipt
            RefundReceipt added = Helper.Add<RefundReceipt>(qboContextoAuth, refundReceipt);
            //Delete the returned entity
            try
            {
                RefundReceipt deleted = Helper.Delete<RefundReceipt>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }

        
      

        #endregion

        #region  CDC Operations

        
        public void RefundReceiptCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            RefundReceiptAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the RefundReceipt using CDC
            List<RefundReceipt> entities = Helper.CDC(qboContextoAuth, new RefundReceipt(), DateTime.Today.AddDays(-1));
          
        }

        #endregion

        #region  Batch

        
        public void RefundReceiptBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            RefundReceipt existing = Helper.FindOrAdd(qboContextoAuth, new RefundReceipt());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateRefundReceipt(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateRefundReceipt(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from RefundReceipt");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<RefundReceipt>(qboContextoAuth, batchEntries);

          
        }

        #endregion

        #region  Query
        
        public void RefundReceiptQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<RefundReceipt> entityQuery = new QueryService<RefundReceipt>(qboContextoAuth);
            RefundReceipt existing = Helper.FindOrAdd<RefundReceipt>(qboContextoAuth, new RefundReceipt());
            List<RefundReceipt> test = entityQuery.ExecuteIdsQuery("SELECT * FROM RefundReceipt where Id='" + existing.Id+"'").ToList<RefundReceipt>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void RefundReceiptAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Add
            RefundReceipt entity = QBOHelper.CreateRefundReceipt(qboContextoAuth);

            RefundReceipt added = Helper.AddAsync<RefundReceipt>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation

        
        public void RefundReceiptRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            RefundReceiptAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the RefundReceipt using FindAll
            Helper.FindAllAsync<RefundReceipt>(qboContextoAuth, new RefundReceipt());
        }

        #endregion

        #region  FindById Operation

        
        public void RefundReceiptFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Adding
            RefundReceipt entity = QBOHelper.CreateRefundReceipt(qboContextoAuth);
            //Adding the RefundReceipt
            RefundReceipt added = Helper.Add<RefundReceipt>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<RefundReceipt>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        
        public void RefundReceiptUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Adding
            RefundReceipt entity = QBOHelper.CreateRefundReceipt(qboContextoAuth);
            //Adding the RefundReceipt
            RefundReceipt added = Helper.Add<RefundReceipt>(qboContextoAuth, entity);

            //Update the RefundReceipt
            RefundReceipt updated = QBOHelper.UpdateRefundReceipt(qboContextoAuth, added);
            //Call the service
            RefundReceipt updatedReturned = Helper.UpdateAsync<RefundReceipt>(qboContextoAuth, updated);
    
        }

        #endregion

        #region  Delete Operation

        
        public void RefundReceiptDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the RefundReceipt for Adding
            RefundReceipt entity = QBOHelper.CreateRefundReceipt(qboContextoAuth);
            //Adding the RefundReceipt
            RefundReceipt added = Helper.Add<RefundReceipt>(qboContextoAuth, entity);

            Helper.DeleteAsync<RefundReceipt>(qboContextoAuth, added);
        }

        #endregion

       
        #endregion
    }
}