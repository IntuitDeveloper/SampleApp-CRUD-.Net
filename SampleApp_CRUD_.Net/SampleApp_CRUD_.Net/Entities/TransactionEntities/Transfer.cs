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
    public class TransferCRUD
    {
        #region Sync Methods

        #region   Add Operations

         
         
        public void TransferAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Add
            Transfer transfer = QBOHelper.CreateTransfer(qboContextoAuth);
            //Adding the Transfer
            Transfer added = Helper.Add<Transfer>(qboContextoAuth, transfer);

        }

        #endregion

        #region   FindAll Operations

         
        public void TransferFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            TransferAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Transfer using FindAll
            List<Transfer> transfers = Helper.FindAll<Transfer>(qboContextoAuth, new Transfer(), 1, 500);

        }

        #endregion

        #region   FindbyId Operations

         
        public void TransferFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Adding
            Transfer transfer = QBOHelper.CreateTransfer(qboContextoAuth);
            //Adding the Transfer
            Transfer added = Helper.Add<Transfer>(qboContextoAuth, transfer);
            Transfer found = Helper.FindById<Transfer>(qboContextoAuth, added);
          
        }

        #endregion

        #region   Update Operations

         
         
        public void TransferUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Adding
            Transfer transfer = QBOHelper.CreateTransfer(qboContextoAuth);
            //Adding the Transfer
            Transfer added = Helper.Add<Transfer>(qboContextoAuth, transfer);
            //Change the data of added entity
            Transfer changed = QBOHelper.UpdateTransfer(qboContextoAuth, added);
            //Update the returned entity data
            Transfer updated = Helper.Update<Transfer>(qboContextoAuth, changed);

        }


         
         
        public void TransferSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Adding
            Transfer transfer = QBOHelper.CreateTransfer(qboContextoAuth);
            //Adding the Transfer
            Transfer added = Helper.Add<Transfer>(qboContextoAuth, transfer);
            //Change the data of added entity
            Transfer changed = QBOHelper.UpdateTransferSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Transfer updated = Helper.Update<Transfer>(qboContextoAuth, changed);
           
        }

        #endregion

        #region   Delete Operations

         
         
        public void TransferDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Adding
            Transfer transfer = QBOHelper.CreateTransfer(qboContextoAuth);
            //Adding the Transfer
            Transfer added = Helper.Add<Transfer>(qboContextoAuth, transfer);
            //Delete the returned entity
            try
            {
                Transfer deleted = Helper.Delete<Transfer>(qboContextoAuth, added);
  
            }
            catch (IdsException ex)
            {
          
            }
        }

        

        #endregion

        #region   CDC Operations

         
         
        public void TransferCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            TransferAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Transfer using CDC
            List<Transfer> entities = Helper.CDC(qboContextoAuth, new Transfer(), DateTime.Today.AddDays(-1));
            
        }

        #endregion

        #region   Batch

         
         
        public void TransferBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Transfer existing = Helper.FindOrAdd(qboContextoAuth, new Transfer());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateTransfer(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateTransfer(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Transfer");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Transfer>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region   Query
         
        public void TransferQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Transfer> entityQuery = new QueryService<Transfer>(qboContextoAuth);
            Transfer existing = Helper.FindOrAdd<Transfer>(qboContextoAuth, new Transfer());
            List<Transfer> tran = entityQuery.ExecuteIdsQuery("SELECT * FROM Transfer where Id='" + existing.Id+"'").ToList<Transfer>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region   Add Operation



        public void TransferAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Add
            Transfer entity = QBOHelper.CreateTransfer(qboContextoAuth);

            Transfer added = Helper.AddAsync<Transfer>(qboContextoAuth, entity);
         
        }

        #endregion

        #region   FindAll Operation

         
        public void TransferRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            TransferAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Transfer using FindAll
            Helper.FindAllAsync<Transfer>(qboContextoAuth, new Transfer());
        }

        #endregion

        #region   FindById Operation

         
        public void TransferFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Adding
            Transfer entity = QBOHelper.CreateTransfer(qboContextoAuth);
            //Adding the Transfer
            Transfer added = Helper.Add<Transfer>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Transfer>(qboContextoAuth, added);
        }

        #endregion

        #region   Update Operation

         
         
        public void TransferUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Adding
            Transfer entity = QBOHelper.CreateTransfer(qboContextoAuth);
            //Adding the Transfer
            Transfer added = Helper.Add<Transfer>(qboContextoAuth, entity);

            //Update the Transfer
            Transfer updated = QBOHelper.UpdateTransfer(qboContextoAuth, added);
            //Call the service
            Transfer updatedReturned = Helper.UpdateAsync<Transfer>(qboContextoAuth, updated);
         
        }

        #endregion

        #region   Delete Operation

         
         
        public void TransferDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Transfer for Adding
            Transfer entity = QBOHelper.CreateTransfer(qboContextoAuth);
            //Adding the Transfer
            Transfer added = Helper.Add<Transfer>(qboContextoAuth, entity);

            Helper.DeleteAsync<Transfer>(qboContextoAuth, added);
        }

        #endregion

       

        #endregion
    }
}