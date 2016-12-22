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
    public class PurchaseOrderCRUD
    {


        #region Sync Methods

        #region  Add Operations

        
        public void PurchaseOrderAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Add
            PurchaseOrder purchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, purchaseOrder);
       
        }

        #endregion

        #region  FindAll Operations

        
        public void PurchaseOrderFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PurchaseOrderAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the PurchaseOrder using FindAll
            List<PurchaseOrder> purchaseOrders = Helper.FindAll<PurchaseOrder>(qboContextoAuth, new PurchaseOrder(), 1, 500);
      
        }

        #endregion

        #region  FindbyId Operations

        
        public void PurchaseOrderFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Adding
            PurchaseOrder purchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, purchaseOrder);
            PurchaseOrder found = Helper.FindById<PurchaseOrder>(qboContextoAuth, added);
         
        }

        #endregion

        #region  Update Operations

        
        public void PurchaseOrderUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Adding
            PurchaseOrder purchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, purchaseOrder);
            //Change the data of added entity
            PurchaseOrder changed = QBOHelper.UpdatePurchaseOrder(qboContextoAuth, added);
            //Update the returned entity data
            PurchaseOrder updated = Helper.Update<PurchaseOrder>(qboContextoAuth, changed);
          
        }

        
        public void PurchaseOrderSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Adding
            PurchaseOrder purchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, purchaseOrder);
            //Change the data of added entity
            PurchaseOrder changed = QBOHelper.UpdatePurchaseOrderSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            PurchaseOrder updated = Helper.Update<PurchaseOrder>(qboContextoAuth, changed);
           
        }

        #endregion

        #region  Delete Operations

        
        public void PurchaseOrderDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Adding
            PurchaseOrder purchaseOrder = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, purchaseOrder);
            //Delete the returned entity
            try
            {
                PurchaseOrder deleted = Helper.Delete<PurchaseOrder>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }

        
    

        #endregion

        #region  CDC Operations

        
        public void PurchaseOrderCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PurchaseOrderAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the PurchaseOrder using CDC
            List<PurchaseOrder> entities = Helper.CDC(qboContextoAuth, new PurchaseOrder(), DateTime.Today.AddDays(-1));

        }

        #endregion

        #region  Batch

        
        public void PurchaseOrderBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            PurchaseOrder existing = Helper.FindOrAdd(qboContextoAuth, new PurchaseOrder());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreatePurchaseOrder(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdatePurchaseOrder(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from PurchaseOrder");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<PurchaseOrder>(qboContextoAuth, batchEntries);

            
        }

        #endregion

        #region  Query
        
        public void PurchaseOrderQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<PurchaseOrder> entityQuery = new QueryService<PurchaseOrder>(qboContextoAuth);
            PurchaseOrder existing = Helper.FindOrAdd<PurchaseOrder>(qboContextoAuth, new PurchaseOrder());
            List<PurchaseOrder> test = entityQuery.ExecuteIdsQuery("SELECT * FROM PurchaseOrder where Id='" + existing.Id+"'").ToList<PurchaseOrder>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void PurchaseOrderAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Add
            PurchaseOrder entity = QBOHelper.CreatePurchaseOrder(qboContextoAuth);

            PurchaseOrder added = Helper.AddAsync<PurchaseOrder>(qboContextoAuth, entity);
            
        }

        #endregion

        #region  FindAll Operation

        
        public void PurchaseOrderRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PurchaseOrderAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the PurchaseOrder using FindAll
            Helper.FindAllAsync<PurchaseOrder>(qboContextoAuth, new PurchaseOrder());
        }

        #endregion

        #region  FindById Operation

        
        public void PurchaseOrderFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Adding
            PurchaseOrder entity = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<PurchaseOrder>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        
        public void PurchaseOrderUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Adding
            PurchaseOrder entity = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, entity);

            //Update the PurchaseOrder
            PurchaseOrder updated = QBOHelper.UpdatePurchaseOrder(qboContextoAuth, added);
            //Call the service
            PurchaseOrder updatedReturned = Helper.UpdateAsync<PurchaseOrder>(qboContextoAuth, updated);
  
        }

        
        public void PurchaseOrderSparseUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Adding
            PurchaseOrder entity = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, entity);

            //Update the PurchaseOrder
            PurchaseOrder updated = QBOHelper.UpdatePurchaseOrderSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Call the service
            PurchaseOrder updatedReturned = Helper.UpdateAsync<PurchaseOrder>(qboContextoAuth, updated);
           
        }

        #endregion

        #region  Delete Operation

        
        public void PurchaseOrderDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PurchaseOrder for Adding
            PurchaseOrder entity = QBOHelper.CreatePurchaseOrder(qboContextoAuth);
            //Adding the PurchaseOrder
            PurchaseOrder added = Helper.Add<PurchaseOrder>(qboContextoAuth, entity);

            Helper.DeleteAsync<PurchaseOrder>(qboContextoAuth, added);
        }

        #endregion

       

        #endregion
    }
}