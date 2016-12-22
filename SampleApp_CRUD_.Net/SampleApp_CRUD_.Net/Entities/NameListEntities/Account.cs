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
    public class AccountCRUD
    {
        #region Sync Methods

        #region  Add Operations


        public void AddBankAccountTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Add
            Account account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            //Adding the Account
            Account added = Helper.Add<Account>(qboContextoAuth, account);
            //Verify the added Account
 
        }



        public void AddCreditCardAccountTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Add
            Account account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.CreditCard, AccountClassificationEnum.Liability);
            //Adding the Account
            Account added = Helper.Add<Account>(qboContextoAuth, account);


        }

    
     
        public void AddExpenseAccountTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Add
            Account account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Expense, AccountClassificationEnum.Expense);
            //Adding the Account
            Account added = Helper.Add<Account>(qboContextoAuth, account);
            //Verify the added Account
        
        }

        #endregion

        #region  FindAll Operations

 
        public void AccountFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            AddBankAccountTestUsingoAuth( qboContextoAuth);

            //Retrieving the Account using FindAll
            List<Account> accounts = Helper.FindAll<Account>(qboContextoAuth, new Account( ), 1, 500);
          
        }

        #endregion

        #region  FindbyId Operations

     
        public void AccountFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Adding
            Account account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            //Adding the Account
            Account added = Helper.Add<Account>(qboContextoAuth, account);
            Account found = Helper.FindById<Account>(qboContextoAuth, added);
      
        }

      

        #endregion

        #region  Update Operations

  
        public void AccountUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Adding
            Account account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            //Adding the Account
            Account added = Helper.Add<Account>(qboContextoAuth, account);
            //Change the data of added entity
            Account changed = QBOHelper.UpdateAccount(qboContextoAuth, added);
            //Update the returned entity data
            Account updated = Helper.Update<Account>(qboContextoAuth, changed);//Verify the updated Account
        
        }


        public void AccountSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Adding
            Account account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            //Adding the Account
            Account added = Helper.Add<Account>(qboContextoAuth, account);
            //Change the data of added entity
            Account changed = QBOHelper.SparseUpdateAccount(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Account updated = Helper.Update<Account>(qboContextoAuth, changed);//Verify the updated Account
    
        }

        #endregion

        #region  Delete Operations

       

        #endregion

        #region  CDC Operations


        public void AccountCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            AddBankAccountTestUsingoAuth( qboContextoAuth);

            //Retrieving the Entity using FindAll
            List<Account> entities = Helper.CDC(qboContextoAuth, new Account( ), DateTime.Today.AddDays(-1));
           
        }

        #endregion

        #region  Batch


        public void AccountBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Account existing = Helper.FindOrAdd(qboContextoAuth, new Account());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateAccount(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Account");



            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Account>(qboContextoAuth, batchEntries);

         
        }

        #endregion

        #region  Query

        public void AccountQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Account> entityQuery = new QueryService<Account>(qboContextoAuth);
            Account existing = Helper.FindOrAddAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Expense);
     
            List<Account> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Account where Id='" + existing.Id+"'").ToList<Account>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region Test Cases for Add Operation


        public void AccountAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Add
            Account entity = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Expense);

            Account added = Helper.AddAsync<Account>(qboContextoAuth, entity);
           
        }

        #endregion

        #region Test Cases for FindAll Operation

 
        public void AccountRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            AddBankAccountTestUsingoAuth( qboContextoAuth);

            //Retrieving the Account using FindAll
            Helper.FindAllAsync<Account>(qboContextoAuth, new Account());
        }

        #endregion

        #region Test Cases for FindById Operation

     
        public void AccountFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Adding
            Account entity = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Expense);
            //Adding the Account
            Account added = Helper.Add<Account>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Account>(qboContextoAuth, added);
        }

        #endregion

        #region Test Cases for Update Operation

        public void AccountUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Account for Adding
            Account entity = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Expense);
            //Adding the Account
            Account added = Helper.Add<Account>(qboContextoAuth, entity);

            //Update the Account
            Account updated = QBOHelper.UpdateAccount(qboContextoAuth, added);
            //Call the service
            Account updatedReturned = Helper.UpdateAsync<Account>(qboContextoAuth, updated);
     
        }

        

        #endregion

        #endregion


    }
}