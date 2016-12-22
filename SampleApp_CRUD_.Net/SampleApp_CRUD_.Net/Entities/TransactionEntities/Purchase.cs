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
    public class PurchaseCRUD
    {
        #region Cash Purchase Methods

        #region  Add Operations

        
        public void CashPurchaseAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Add
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
 
        }

        #endregion

        #region  FindAll Operations

        
        public void CashPurchaseFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CashPurchaseAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Purchase using FindAll
            List<Purchase> purchases = Helper.FindAll<Purchase>(qboContextoAuth, new Purchase(), 1, 500);
      
        }

        #endregion

        #region  FindbyId Operations

        
        public void CashPurchaseFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            Purchase found = Helper.FindById<Purchase>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

        
        public void CashPurchaseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Change the data of added entity
            Purchase changed = QBOHelper.UpdatePurchase(qboContextoAuth, added);
            //Update the returned entity data
            Purchase updated = Helper.Update<Purchase>(qboContextoAuth, changed);//Verify the updated Purchase

        }


        
        public void CashPurchaseSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Change the data of added entity
            Purchase changed = QBOHelper.SparseUpdatePurchase(qboContextoAuth, added.Id, added.PaymentType, added.SyncToken);
            //Update the returned entity data
            Purchase updated = Helper.Update<Purchase>(qboContextoAuth, changed);//Verify the updated Purchase

        }

        #endregion

        #region  Delete Operations

        
        public void CashPurchaseDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Delete the returned entity
            try
            {
                Purchase deleted = Helper.Delete<Purchase>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }

        
      

        #endregion

        #region  CDC Operations

        
        public void CashPurchaseCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CashPurchaseAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Purchase using FindAll
            List<Purchase> cashPurchases = Helper.CDC(qboContextoAuth, new Purchase(), DateTime.Today.AddDays(-1));
          
        }

        #endregion

        #region  Batch

        
        public void PurchaseBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Purchase existing = Helper.FindOrAdd(qboContextoAuth, new Purchase());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Cash));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdatePurchase(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Purchase");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Purchase>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region  Query
        
        public void CashPurchaseQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Purchase> entityQuery = new QueryService<Purchase>(qboContextoAuth);
            Purchase existing = Helper.FindOrAddPurchase(qboContextoAuth, PaymentTypeEnum.Cash);
            List<Purchase> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Purchase where Id='" + existing.Id+"'").ToList<Purchase>();

        }

        #endregion

        #endregion

        #region Check Purchase Methods

        #region  Add Operations

        
        public void CheckPurchaseAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Add
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
           
        }

        #endregion

        #region  FindAll Operations

        
        public void CheckPurchaseFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CheckPurchaseAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Purchase using FindAll
            List<Purchase> purchases = Helper.FindAll<Purchase>(qboContextoAuth, new Purchase(), 1, 500);
           
        }

        #endregion

        #region  FindbyId Operations

        
        public void CheckPurchaseFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            Purchase found = Helper.FindById<Purchase>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

        
        public void CheckPurchaseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Change the data of added entity
            Purchase changed = QBOHelper.UpdatePurchase(qboContextoAuth, added);
            //Update the returned entity data
            Purchase updated = Helper.Update<Purchase>(qboContextoAuth, changed);//Verify the updated Purchase

        }


        
        public void CheckPurchaseSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Change the data of added entity
            Purchase changed = QBOHelper.SparseUpdatePurchase(qboContextoAuth, added.Id, added.PaymentType, added.SyncToken);
            //Update the returned entity data
            Purchase updated = Helper.Update<Purchase>(qboContextoAuth, changed);//Verify the updated Purchase

        }

        #endregion

        #region  Delete Operations

        
        public void CheckPurchaseDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Delete the returned entity
            try
            {
                Purchase deleted = Helper.Delete<Purchase>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {
      
            }
        }

        
       

        #endregion

        #region  CDC Operations

        
        public void CheckPurchaseCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CheckPurchaseAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Purchase using FindAll
            List<Purchase> checkPurchases = Helper.CDC(qboContextoAuth, new Purchase(), DateTime.Today.AddDays(-1));
          
        }

        #endregion

        #region  Query
        
        public void CheckPurchaseQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Purchase> entityQuery = new QueryService<Purchase>(qboContextoAuth);
            Purchase existing = Helper.FindOrAddPurchase(qboContextoAuth, PaymentTypeEnum.Check);
            List<Purchase> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Purchase where Id='" + existing.Id+"'").ToList<Purchase>();

        }

        #endregion

        #endregion

        #region CreditCard Purchase Methods

        #region  Add Operations

        
        public void CreditCardPurchaseAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Add
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
       
        }


        
        public void CheckPurchaseAddDuplicateDocNumberGlobalTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Add
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.Check);
            purchase.DocNumber = "DUPLICATE";
            //Pass parameter to allow duplicate doc numbers
            qboContextoAuth.Include.Add("allowduplicatedocnum");
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            Purchase addedDuplicate = Helper.Add<Purchase>(qboContextoAuth, purchase);
     
          
        }

        #endregion

        #region  FindAll Operations

        
        public void CreditCardPurchaseFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CreditCardPurchaseAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Purchase using FindAll
            List<Purchase> purchases = Helper.FindAll<Purchase>(qboContextoAuth, new Purchase(), 1, 500);

        }

        #endregion

        #region  FindbyId Operations

        
        public void CreditCardPurchaseFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            Purchase found = Helper.FindById<Purchase>(qboContextoAuth, added);
      
        }

        #endregion

        #region  Update Operations

        
        public void CreditCardPurchaseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Change the data of added entity
            Purchase changed = QBOHelper.UpdatePurchase(qboContextoAuth, added);
            //Update the returned entity data
            Purchase updated = Helper.Update<Purchase>(qboContextoAuth, changed);//Verify the updated Purchase

        }


        
        public void CreditCardPurchaseSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Change the data of added entity
            Purchase changed = QBOHelper.SparseUpdatePurchase(qboContextoAuth, added.Id, added.PaymentType, added.SyncToken);
            //Update the returned entity data
            Purchase updated = Helper.Update<Purchase>(qboContextoAuth, changed);//Verify the updated Purchase

        }

        #endregion

        #region  Delete Operations

        
        public void CreditCardPurchaseDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Purchase for Adding
            Purchase purchase = QBOHelper.CreatePurchase(qboContextoAuth, PaymentTypeEnum.CreditCard);
            //Adding the Purchase
            Purchase added = Helper.Add<Purchase>(qboContextoAuth, purchase);
            //Delete the returned entity
            try
            {
                Purchase deleted = Helper.Delete<Purchase>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }

        }

        
        

        #endregion

        #region  CDC Operations

        
        public void CreditCardPurchaseCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CreditCardPurchaseAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Purchase using FindAll
            List<Purchase> creditCardPurchases = Helper.CDC(qboContextoAuth, new Purchase(), DateTime.Today.AddDays(-1));
      
        }

        #endregion

        #region  Query
        
        public void CreditCardPurchaseQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Purchase> entityQuery = new QueryService<Purchase>(qboContextoAuth);
            Purchase existing = Helper.FindOrAddPurchase(qboContextoAuth, PaymentTypeEnum.CreditCard);
            List<Purchase> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Purchase where Id='" + existing.Id+"'").ToList<Purchase>();

        }

        #endregion

        #endregion

    }
}