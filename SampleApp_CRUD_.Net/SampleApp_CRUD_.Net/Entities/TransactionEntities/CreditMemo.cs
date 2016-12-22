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
    public class CreditMemoCRUD
    {



        #region  Add Operations

        
        public void CreditMemoAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Add
            CreditMemo creditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth);
            //Adding the CreditMemo
            CreditMemo added = Helper.Add<CreditMemo>(qboContextoAuth, creditMemo);
       
        }

        #endregion

        #region  FindAll Operations

        
        public void CreditMemoFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CreditMemoAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the CreditMemo using FindAll
            List<CreditMemo> creditMemos = Helper.FindAll<CreditMemo>(qboContextoAuth, new CreditMemo(), 1, 500);
   
        }

        #endregion

        #region  FindbyId Operations

        
        public void CreditMemoFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Adding
            CreditMemo creditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth);
            //Adding the CreditMemo
            CreditMemo added = Helper.Add<CreditMemo>(qboContextoAuth, creditMemo);
            CreditMemo found = Helper.FindById<CreditMemo>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

        
        public void CreditMemoUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Adding
            CreditMemo creditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth);
            //Adding the CreditMemo
            CreditMemo added = Helper.Add<CreditMemo>(qboContextoAuth, creditMemo);
            //Change the data of added entity
            CreditMemo changed = QBOHelper.UpdateCreditMemo(qboContextoAuth, added);
            //Update the returned entity data
            CreditMemo updated = Helper.Update<CreditMemo>(qboContextoAuth, changed);
            
        }

        
        public void CreditMemoSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Adding
            CreditMemo creditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth);
            //Adding the CreditMemo
            CreditMemo added = Helper.Add<CreditMemo>(qboContextoAuth, creditMemo);
            //Change the data of added entity
            CreditMemo changed = QBOHelper.UpdateCreditMemoSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            CreditMemo updated = Helper.Update<CreditMemo>(qboContextoAuth, changed);
   
        }

        #endregion


        #region Delete Operations

  
        public void CreditMemoDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Adding
            CreditMemo creditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth);
            //Adding the CreditMemo
            CreditMemo added = Helper.Add<CreditMemo>(qboContextoAuth, creditMemo);
            //Delete the returned entity
            try
            {
                CreditMemo deleted = Helper.Delete<CreditMemo>(qboContextoAuth, added);
                
            }
            catch (IdsException ex)
            {
       
            }
        }


        #region  CDC Operations


        public void CreditMemoCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CreditMemoAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the CreditMemo using CDC
            List<CreditMemo> entities = Helper.CDC(qboContextoAuth, new CreditMemo(), DateTime.Today.AddDays(-1));
           
        }

        #endregion

        #region  Batch

        
        public void CreditMemoBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            CreditMemo existing = Helper.FindOrAdd(qboContextoAuth, new CreditMemo());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateCreditMemo(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateCreditMemo(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from CreditMemo");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<CreditMemo>(qboContextoAuth, batchEntries);

            
        }

        #endregion

        #region  Query
        
        public void CreditMemoQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<CreditMemo> entityQuery = new QueryService<CreditMemo>(qboContextoAuth);
            CreditMemo existing = Helper.FindOrAdd<CreditMemo>(qboContextoAuth, new CreditMemo());
            List<CreditMemo> test = entityQuery.ExecuteIdsQuery("SELECT * FROM CreditMemo where Id='" + existing.Id+"'").ToList<CreditMemo>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void CreditMemoAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Add
            CreditMemo entity = QBOHelper.CreateCreditMemo(qboContextoAuth);

            CreditMemo added = Helper.AddAsync<CreditMemo>(qboContextoAuth, entity);
          
        }

        #endregion

        #region  FindAll Operation

        
        public void CreditMemoRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CreditMemoAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the CreditMemo using FindAll
            Helper.FindAllAsync<CreditMemo>(qboContextoAuth, new CreditMemo());
        }

        #endregion

        #region  FindById Operation

        
        public void CreditMemoFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Adding
            CreditMemo entity = QBOHelper.CreateCreditMemo(qboContextoAuth);
            //Adding the CreditMemo
            CreditMemo added = Helper.Add<CreditMemo>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<CreditMemo>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        
        public void CreditMemoUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Adding
            CreditMemo entity = QBOHelper.CreateCreditMemo(qboContextoAuth);
            //Adding the CreditMemo
            CreditMemo added = Helper.Add<CreditMemo>(qboContextoAuth, entity);

            //Update the CreditMemo
            CreditMemo updated = QBOHelper.UpdateCreditMemo(qboContextoAuth, added);
            //Call the service
            CreditMemo updatedReturned = Helper.UpdateAsync<CreditMemo>(qboContextoAuth, updated);
            
        }

        
        public void CreditMemoSparseUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the CreditMemo for Adding
            CreditMemo entity = QBOHelper.CreateCreditMemo(qboContextoAuth);
            //Adding the CreditMemo
            CreditMemo added = Helper.Add<CreditMemo>(qboContextoAuth, entity);

            //Update the CreditMemo
            CreditMemo updated = QBOHelper.UpdateCreditMemoSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Call the service
            CreditMemo updatedReturned = Helper.UpdateAsync<CreditMemo>(qboContextoAuth, updated);
           
        }
        #endregion

        

        #endregion
    }
}