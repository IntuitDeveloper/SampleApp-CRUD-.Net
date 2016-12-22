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
    public class TimeActivityCRUD
    {
        #region Sync Methods

        #region  Add Operations

        
        public void TimeActivityAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TimeActivity for Add
            TimeActivity timeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, timeActivity);
      
        }

        #endregion

        #region  FindAll Operations

        
        public void TimeActivityFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            TimeActivityAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the TimeActivity using FindAll
            List<TimeActivity> timeActivitys = Helper.FindAll<TimeActivity>(qboContextoAuth, new TimeActivity(), 1, 500);
      
        }

        #endregion

        #region  FindbyId Operations

        
        public void TimeActivityFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TimeActivity for Adding
            TimeActivity timeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            TimeActivity added = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());
            TimeActivity found = Helper.FindById<TimeActivity>(qboContextoAuth, added);
            
        }

        #endregion

        #region  Update Operations

        
        public void TimeActivityUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            /*
            //Creating the TimeActivity for Adding
            TimeActivity timeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, timeActivity);
            */

            TimeActivity added = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());
            //Change the data of added entity
            TimeActivity changed = QBOHelper.UpdateTimeActivity(qboContextoAuth, added);
            //Update the returned entity data
            TimeActivity updated = Helper.Update<TimeActivity>(qboContextoAuth, changed);//Verify the updated TimeActivity
            
        }

        
        public void TimeActivitySparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            /*
            //Creating the TimeActivity for Adding
            TimeActivity timeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, timeActivity);
            */

            TimeActivity added = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());
            //Change the data of added entity
            TimeActivity changed = QBOHelper.UpdateTimeActivitySparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            TimeActivity updated = Helper.Update<TimeActivity>(qboContextoAuth, changed);//Verify the updated TimeActivity
            
        }

        #endregion

        #region  Delete Operations

        
        public void TimeActivityDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TimeActivity for Adding
            //TimeActivity timeActivity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            //TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, timeActivity);
            TimeActivity added = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());

            //Delete the returned entity
            try
            {
                TimeActivity deleted = Helper.Delete<TimeActivity>(qboContextoAuth, added);
  
            }
            catch (IdsException ex)
            {
               
            }
        }

        
       

        #endregion

        

        #region  Batch

        
        public void TimeActivityBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            TimeActivity existing = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());

            //  batchEntries.Add(OperationEnum.create, QBOHelper.CreateTimeActivity(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateTimeActivity(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from TimeActivity");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<TimeActivity>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region  Query
        
        public void TimeActivityQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<TimeActivity> entityQuery = new QueryService<TimeActivity>(qboContextoAuth);
            TimeActivity existing = Helper.FindOrAdd<TimeActivity>(qboContextoAuth, new TimeActivity());

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void TimeActivityAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TimeActivity for Add
            TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);

            TimeActivity added = Helper.AddAsync<TimeActivity>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation

        
        public void TimeActivityRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            //TimeActivityAddTestUsingoAuth(ServiceContext qboContextoAuth);

            //Retrieving the TimeActivity using FindAll
            Helper.FindAllAsync<TimeActivity>(qboContextoAuth, new TimeActivity());
        }

        #endregion

        #region  FindById Operation

        
        public void TimeActivityFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TimeActivity for Adding
            //TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            //TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, entity);

            TimeActivity added = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());
            //FindById and verify
            Helper.FindByIdAsync<TimeActivity>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        
        public void TimeActivityUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TimeActivity for Adding
            //TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            //TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, entity);

            TimeActivity added = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());
            //Update the TimeActivity
            TimeActivity updated = QBOHelper.UpdateTimeActivity(qboContextoAuth, added);
            //Call the service
            TimeActivity updatedReturned = Helper.UpdateAsync<TimeActivity>(qboContextoAuth, updated);
     
        }

        
        public void TimeActivitySparseUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TimeActivity for Adding
            //TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            //TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, entity);

            TimeActivity added = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());
            //Update the TimeActivity
            TimeActivity updated = QBOHelper.UpdateTimeActivitySparse(qboContextoAuth, added.Id, added.SyncToken);
            //Call the service
            TimeActivity updatedReturned = Helper.UpdateAsync<TimeActivity>(qboContextoAuth, updated);
           
        }

        #endregion

        #region  Delete Operation

        
        public void TimeActivityDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the TimeActivity for Adding
            //TimeActivity entity = QBOHelper.CreateTimeActivity(qboContextoAuth);
            //Adding the TimeActivity
            //TimeActivity added = Helper.Add<TimeActivity>(qboContextoAuth, entity);

            TimeActivity added = Helper.FindOrAdd(qboContextoAuth, new TimeActivity());

            Helper.DeleteAsync<TimeActivity>(qboContextoAuth, added);
        }

        #endregion

      

        #endregion
    }
}