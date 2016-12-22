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
    public class DepositCRUD
    {
        #region Sync Methods

        #region  Add Operations

        

        public void DepositAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Add
            Deposit deposit = QBOHelper.CreateDeposit(qboContextoAuth);
            //Adding the Deposit
            Deposit added = Helper.Add<Deposit>(qboContextoAuth, deposit);
 
        }

        #endregion

        #region  FindAll Operations

        
        public void DepositFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
       

            //Retrieving the Deposit using FindAll
            List<Deposit> deposits = Helper.FindAll<Deposit>(qboContextoAuth, new Deposit(), 1, 500);
           
        }

        #endregion

        #region  FindbyId Operations

        
        public void DepositFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Adding
            Deposit deposit = QBOHelper.CreateDeposit(qboContextoAuth);
            //Adding the Deposit
            Deposit added = Helper.Add<Deposit>(qboContextoAuth, deposit);
            Deposit found = Helper.FindById<Deposit>(qboContextoAuth, added);
         
        }

        #endregion

        #region  Update Operations

        

        public void DepositUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Adding
            Deposit deposit = QBOHelper.CreateDeposit(qboContextoAuth);
            //Adding the Deposit
            Deposit added = Helper.Add<Deposit>(qboContextoAuth, deposit);
            //Change the data of added entity
            Deposit changed = QBOHelper.UpdateDeposit(qboContextoAuth, added);
            //Update the returned entity data
            Deposit updated = Helper.Update<Deposit>(qboContextoAuth, changed);//Verify the updated Deposit
 
        }


        

        public void DepositSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Adding
            Deposit deposit = QBOHelper.CreateDeposit(qboContextoAuth);
            //Adding the Deposit
            Deposit added = Helper.Add<Deposit>(qboContextoAuth, deposit);
            //Change the data of added entity
            Deposit changed = QBOHelper.UpdateDepositSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Deposit updated = Helper.Update<Deposit>(qboContextoAuth, changed);//Verify the updated Deposit
          
        }
        #endregion

        #region  Delete Operations

        

        public void DepositDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Adding
            Deposit deposit = QBOHelper.CreateDeposit(qboContextoAuth);
            //Adding the Deposit
            Deposit added = Helper.Add<Deposit>(qboContextoAuth, deposit);
            //Delete the returned entity
            try
            {
                Deposit deleted = Helper.Delete<Deposit>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {
        
            }
        }

        
    
        #endregion

        #region  CDC Operations

        

        public void DepositCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            DepositAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Deposit using CDC
            List<Deposit> entities = Helper.CDC(qboContextoAuth, new Deposit(), DateTime.Today.AddDays(-1));
            
        }

        #endregion

        #region  Batch

        

        public void DepositBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Deposit existing = Helper.FindOrAdd(qboContextoAuth, new Deposit());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateDeposit(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateDeposit(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Deposit");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Deposit>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region  Query
        
        public void DepositQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Deposit> entityQuery = new QueryService<Deposit>(qboContextoAuth);
            Deposit existing = Helper.FindOrAdd<Deposit>(qboContextoAuth, new Deposit());
            List<Deposit> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Deposit where Id='" + existing.Id+"'").ToList<Deposit>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        

        public void DepositAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Add
            Deposit entity = QBOHelper.CreateDeposit(qboContextoAuth);

            Deposit added = Helper.AddAsync<Deposit>(qboContextoAuth, entity);
 
        }

        #endregion

        #region  FindAll Operation

        
        public void DepositRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            DepositAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Deposit using FindAll
            Helper.FindAllAsync<Deposit>(qboContextoAuth, new Deposit());
        }

        #endregion

        #region  FindById Operation

        
        public void DepositFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Adding
            Deposit entity = QBOHelper.CreateDeposit(qboContextoAuth);
            //Adding the Deposit
            Deposit added = Helper.Add<Deposit>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Deposit>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        

        public void DepositUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Adding
            Deposit entity = QBOHelper.CreateDeposit(qboContextoAuth);
            //Adding the Deposit
            Deposit added = Helper.Add<Deposit>(qboContextoAuth, entity);

            //Update the Deposit
            Deposit updated = QBOHelper.UpdateDeposit(qboContextoAuth, added);
            //Call the service
            Deposit updatedReturned = Helper.UpdateAsync<Deposit>(qboContextoAuth, updated);
         
        }

        #endregion

        #region  Delete Operation

        

        public void DepositDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Deposit for Adding
            Deposit entity = QBOHelper.CreateDeposit(qboContextoAuth);
            //Adding the Deposit
            Deposit added = Helper.Add<Deposit>(qboContextoAuth, entity);

            Helper.DeleteAsync<Deposit>(qboContextoAuth, added);
        }

        #endregion


        #endregion
    }
}