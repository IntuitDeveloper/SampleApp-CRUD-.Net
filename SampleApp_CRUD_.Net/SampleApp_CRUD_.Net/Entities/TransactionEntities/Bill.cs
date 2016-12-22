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
    public class BillCRUD
    {

        #region Sync Methods

        #region  Add Operations

        
        public void BillAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Add
            Bill bill = QBOHelper.CreateBill(qboContextoAuth);
            //Adding the Bill
            Bill added = Helper.Add<Bill>(qboContextoAuth, bill);
          
        }

        #endregion

        #region  FindAll Operations


        public void BillFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            BillAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Bill using FindAll
            List<Bill> bills = Helper.FindAll<Bill>(qboContextoAuth, new Bill(), 1, 500);
        }

        #endregion

        #region  FindbyId Operations

        
        public void BillFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Adding
            Bill bill = QBOHelper.CreateBill(qboContextoAuth);
            //Adding the Bill
            Bill added = Helper.Add<Bill>(qboContextoAuth, bill);
            Bill found = Helper.FindById<Bill>(qboContextoAuth, added);
   
        }

        #endregion

        #region  Update Operations

        
        public void BillUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Adding
            Bill bill = QBOHelper.CreateBill(qboContextoAuth);
            //Adding the Bill
            Bill added = Helper.Add<Bill>(qboContextoAuth, bill);
            //Change the data of added entity
            Bill changed = QBOHelper.UpdateBill(qboContextoAuth, added);
            //Update the returned entity data
            Bill updated = Helper.Update<Bill>(qboContextoAuth, changed);//Verify the updated Bill
          
        }

        
        public void BillSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Adding
            Bill bill = QBOHelper.CreateBill(qboContextoAuth);
            //Adding the Bill
            Bill added = Helper.Add<Bill>(qboContextoAuth, bill);
            //Change the data of added entity
            Bill changed = QBOHelper.UpdateBillSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Bill updated = Helper.Update<Bill>(qboContextoAuth, changed);//Verify the updated Bill

        }

        #endregion

        #region Delete Operations


        public void BillDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Adding
            Bill bill = QBOHelper.CreateBill(qboContextoAuth);
            //Adding the Bill
            Bill added = Helper.Add<Bill>(qboContextoAuth, bill);
            //Delete the returned entity
            try
            {
                Bill deleted = Helper.Delete<Bill>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }

        #endregion


        #region  CDC Operations


        public void BillCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            BillAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Bill using CDC
            List<Bill> entities = Helper.CDC(qboContextoAuth, new Bill(), DateTime.Today.AddDays(-1));
       
        }

        #endregion

        #region  Batch

        
        public void BillBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Bill existing = Helper.FindOrAdd(qboContextoAuth, new Bill());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateBill(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateBill(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Bill");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Bill>(qboContextoAuth, batchEntries);

          
        }

        #endregion

        #region  Query
        
        public void BillQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Bill> entityQuery = new QueryService<Bill>(qboContextoAuth);
            Bill existing = Helper.FindOrAdd<Bill>(qboContextoAuth, new Bill());
            List<Bill> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Bill where Id='" + existing.Id+"'").ToList<Bill>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void BillAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Add
            Bill entity = QBOHelper.CreateBill(qboContextoAuth);

            Bill added = Helper.AddAsync<Bill>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation

        
        public void BillRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            BillAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Bill using FindAll
            Helper.FindAllAsync<Bill>(qboContextoAuth, new Bill());
        }

        #endregion

        #region  FindById Operation

        
        public void BillFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Adding
            Bill entity = QBOHelper.CreateBill(qboContextoAuth);
            //Adding the Bill
            Bill added = Helper.Add<Bill>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Bill>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        
        public void BillUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Adding
            Bill entity = QBOHelper.CreateBill(qboContextoAuth);
            //Adding the Bill
            Bill added = Helper.Add<Bill>(qboContextoAuth, entity);

            //Update the Bill
            Bill updated = QBOHelper.UpdateBill(qboContextoAuth, added);
            //Call the service
            Bill updatedReturned = Helper.UpdateAsync<Bill>(qboContextoAuth, updated);
        
        }

        
        public void BillSparseUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Adding
            Bill entity = QBOHelper.CreateBill(qboContextoAuth);
            //Adding the Bill
            Bill added = Helper.Add<Bill>(qboContextoAuth, entity);

            //Update the Bill
            Bill updated = QBOHelper.UpdateBillSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Call the service
            Bill updatedReturned = Helper.UpdateAsync<Bill>(qboContextoAuth, updated);
     
        }

        #endregion

       

        #endregion
    }
}