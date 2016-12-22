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
    public class JournalEntryCRUD
    {
        #region Sync Methods

        #region  Add Operations

         
        public void JournalEntryAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Add
            JournalEntry journalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth);
            //Adding the JournalEntry
            JournalEntry added = Helper.Add<JournalEntry>(qboContextoAuth, journalEntry);
         
        }

        #endregion

        #region  FindAll Operations

         
        public void JournalEntryFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            JournalEntryAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the JournalEntry using FindAll
            List<JournalEntry> journalEntrys = Helper.FindAll<JournalEntry>(qboContextoAuth, new JournalEntry(), 1, 500);
           
        }

        #endregion

        #region  FindbyId Operations

         
        public void JournalEntryFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Adding
            JournalEntry journalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth);
            //Adding the JournalEntry
            JournalEntry added = Helper.Add<JournalEntry>(qboContextoAuth, journalEntry);
            JournalEntry found = Helper.FindById<JournalEntry>(qboContextoAuth, added);
           
        }

        #endregion

        #region  Update Operations

         
        public void JournalEntryUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Adding
            JournalEntry journalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth);
            //Adding the JournalEntry
            JournalEntry added = Helper.Add<JournalEntry>(qboContextoAuth, journalEntry);
            //Change the data of added entity
            JournalEntry changed = QBOHelper.UpdateJournalEntry(qboContextoAuth, added);
            //Update the returned entity data
            JournalEntry updated = Helper.Update<JournalEntry>(qboContextoAuth, changed);//Verify the updated JournalEntry
     
        }

         
        public void JournalEntrySparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Adding
            JournalEntry journalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth);
            //Adding the JournalEntry
            JournalEntry added = Helper.Add<JournalEntry>(qboContextoAuth, journalEntry);
            //Change the data of added entity
            JournalEntry changed = QBOHelper.UpdateJournalEntrySparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            JournalEntry updated = Helper.Update<JournalEntry>(qboContextoAuth, changed);//Verify the updated JournalEntry
           
        }

        #endregion

        #region  Delete Operations

         
        public void JournalEntryDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Adding
            JournalEntry journalEntry = QBOHelper.CreateJournalEntry(qboContextoAuth);
            //Adding the JournalEntry
            JournalEntry added = Helper.Add<JournalEntry>(qboContextoAuth, journalEntry);
            //Delete the returned entity
            try
            {
                JournalEntry deleted = Helper.Delete<JournalEntry>(qboContextoAuth, added);
             
            }
            catch (IdsException ex)
            {
              
            }
        }

       

        #endregion

        #region  CDC Operations

         
        public void JournalEntryCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            JournalEntryAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the JournalEntry using CDC
            List<JournalEntry> entities = Helper.CDC(qboContextoAuth, new JournalEntry(), DateTime.Today.AddDays(-1));
         
        }

        #endregion

        #region  Batch

         
        public void JournalEntryBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            JournalEntry existing = Helper.FindOrAdd(qboContextoAuth, new JournalEntry());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateJournalEntry(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateJournalEntry(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from JournalEntry");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<JournalEntry>(qboContextoAuth, batchEntries);

          
        }

        #endregion

        #region  Query
         
        public void JournalEntryQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<JournalEntry> entityQuery = new QueryService<JournalEntry>(qboContextoAuth);
            JournalEntry existing = Helper.FindOrAdd<JournalEntry>(qboContextoAuth, new JournalEntry());
            List<JournalEntry> je = entityQuery.ExecuteIdsQuery("SELECT * FROM JournalEntry where Id='" + existing.Id+"'").ToList<JournalEntry>();

        }

        #endregion
        #endregion

        #region ASync Methods

        #region  Add Operation

         
        public void JournalEntryAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Add
            JournalEntry entity = QBOHelper.CreateJournalEntry(qboContextoAuth);

            JournalEntry added = Helper.AddAsync<JournalEntry>(qboContextoAuth, entity);
         
        }

        #endregion

        #region  FindAll Operation

         
        public void JournalEntryRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            JournalEntryAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the JournalEntry using FindAll
            Helper.FindAllAsync<JournalEntry>(qboContextoAuth, new JournalEntry());
        }

        #endregion

        #region  FindById Operation

         
        public void JournalEntryFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Adding
            JournalEntry entity = QBOHelper.CreateJournalEntry(qboContextoAuth);
            //Adding the JournalEntry
            JournalEntry added = Helper.Add<JournalEntry>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<JournalEntry>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

         
        public void JournalEntryUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Adding
            JournalEntry entity = QBOHelper.CreateJournalEntry(qboContextoAuth);
            //Adding the JournalEntry
            JournalEntry added = Helper.Add<JournalEntry>(qboContextoAuth, entity);

            //Update the JournalEntry
            JournalEntry updated = QBOHelper.UpdateJournalEntry(qboContextoAuth, added);
            //Call the service
            JournalEntry updatedReturned = Helper.UpdateAsync<JournalEntry>(qboContextoAuth, updated);
      
        }

        #endregion

        #region  Delete Operation

         
        public void JournalEntryDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalEntry for Adding
            JournalEntry entity = QBOHelper.CreateJournalEntry(qboContextoAuth);
            //Adding the JournalEntry
            JournalEntry added = Helper.Add<JournalEntry>(qboContextoAuth, entity);

            Helper.DeleteAsync<JournalEntry>(qboContextoAuth, added);
        }

        #endregion


        #endregion
    }
}