using System;
using System.Collections.Generic;
using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.QueryFilter;
using Intuit.Ipp.Exception;
using Intuit.Ipp.DataService;
using System.Collections.ObjectModel;
using System.Linq;

namespace SampleApp_CRUD_DotNet
{
    //This entity is supported only for France
    public class JournalCodeCRUD
    {

        #region Sync Methods

        #region  Add Operations

         
        public void AddExpensesJournalCodeTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Add
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses);

            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
            

        }


         
        public void AddSalesJournalCodeTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Add
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Sales);

            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
            
        }


         
        public void AddBankJournalCodeTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Add
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Bank);

            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
            
        }






         
        public void AddWagesJournalCodeTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Add
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Wages);

            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
           
        }


         
        public void AddCashJournalCodeTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Add
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Cash);

            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
 
        }



         
        public void AddOthersJournalCodeTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Add
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Others);

            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
  
        }


        #endregion  Add Operations

        #region  FindAll Operations

         
        public void JournalCodeFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            AddExpensesJournalCodeTestUsingoAuth(qboContextoAuth);

            //Retrieving the JournalCode using FindAll
            List<JournalCode> journalCodes = Helper.FindAll<JournalCode>(qboContextoAuth, new JournalCode(), 1, 500);
 
        }

        #endregion

        #region  FindbyId Operations

         
        public void JournalCodeFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Adding
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses);
            //Adding the journalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
            JournalCode found = Helper.FindById<JournalCode>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations
        //check
         
        public void JournalCodeUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Adding
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses);
            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
            //Change the data of added entity
            JournalCode changed = QBOHelper.UpdateJournalCode(qboContextoAuth, added);
            //Update the returned entity data
            JournalCode updated = Helper.Update<JournalCode>(qboContextoAuth, changed);//Verify the updated JournalCode

        }

         

        public void JournalCodeSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Adding
            JournalCode journalCode = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses);
            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, journalCode);
            //Change the data of added entity
            JournalCode changed = QBOHelper.UpdateJournalCodeSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            JournalCode updated = Helper.Update<JournalCode>(qboContextoAuth, changed);//Verify the updated JournalCode

        }
        //check
        #endregion

    




        #region  Batch

         
        public void JournalCodeBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            JournalCode existing = Helper.FindOrAdd(qboContextoAuth, new JournalCode());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateJournalCode(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from JournalCode");



            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<JournalCode>(qboContextoAuth, batchEntries);

          
        }

        #endregion

        #region  Query
         
        public void JournalCodeQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<JournalCode> entityQuery = new QueryService<JournalCode>(qboContextoAuth);
            JournalCode existing = Helper.FindOrAdd<JournalCode>(qboContextoAuth, new JournalCode());
            List<JournalCode> jc = entityQuery.ExecuteIdsQuery("SELECT * FROM JournalCode where Id='" + existing.Id+"'").ToList<JournalCode>();

        }

        #endregion


        #endregion


        #region ASync Methods

        #region  Add Operation

         
        public void JournalCodeAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Add
            JournalCode entity = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses);

            JournalCode added = Helper.AddAsync<JournalCode>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation

         
        public void JournalCodeRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            JournalCodeAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Retrieving the JournalCode using FindAll
            Helper.FindAllAsync<JournalCode>(qboContextoAuth, new JournalCode());
        }

        #endregion

        #region  FindById Operation

         
        public void JournalCodeFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Adding
            JournalCode entity = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses);
            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<JournalCode>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

         
        public void JournalCodeUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the JournalCode for Adding
            JournalCode entity = QBOHelper.CreateJournalCode(qboContextoAuth, JournalCodeTypeEnum.Expenses);
            //Adding the JournalCode
            JournalCode added = Helper.Add<JournalCode>(qboContextoAuth, entity);

            //Update the JournalCode
            JournalCode updated = QBOHelper.UpdateJournalCode(qboContextoAuth, added);
            //Call the service
            JournalCode updatedReturned = Helper.UpdateAsync<JournalCode>(qboContextoAuth, updated);

        }

        #endregion

    



        #endregion
    }
}