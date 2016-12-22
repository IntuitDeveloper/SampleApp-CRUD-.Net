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
    public class PaymentMethodCRUD
    {

        #region Sync Methods

        #region  Add Operations

         
        public void PaymentMethodAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PaymentMethod for Add
            PaymentMethod paymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth);
            //Adding the PaymentMethod
            PaymentMethod added = Helper.Add<PaymentMethod>(qboContextoAuth, paymentMethod);
     
        }

        #endregion

        #region  FindAll Operations

         
        public void PaymentMethodFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PaymentMethodAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the PaymentMethod using FindAll
            List<PaymentMethod> paymentMethods = Helper.FindAll<PaymentMethod>(qboContextoAuth, new PaymentMethod(), 1, 500);
    
        }

        #endregion

        #region  FindbyId Operations

         
        public void PaymentMethodFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PaymentMethod for Adding
            PaymentMethod paymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth);
            //Adding the PaymentMethod
            PaymentMethod added = Helper.Add<PaymentMethod>(qboContextoAuth, paymentMethod);
            PaymentMethod found = Helper.FindById<PaymentMethod>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

         
        public void PaymentMethodUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PaymentMethod for Adding
            PaymentMethod paymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth);
            //Adding the PaymentMethod
            PaymentMethod added = Helper.Add<PaymentMethod>(qboContextoAuth, paymentMethod);
            //Change the data of added entity
            PaymentMethod changed = QBOHelper.UpdatePaymentMethod(qboContextoAuth, added);
            //Update the returned entity data
            PaymentMethod updated = Helper.Update<PaymentMethod>(qboContextoAuth, changed); //Verify the updated PaymentMethod
  
        }

         
        public void PaymentMethodSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PaymentMethod for Adding
            PaymentMethod paymentMethod = QBOHelper.CreatePaymentMethod(qboContextoAuth);
            //Adding the PaymentMethod
            PaymentMethod added = Helper.Add<PaymentMethod>(qboContextoAuth, paymentMethod);
            //Change the data of added entity
            PaymentMethod changed = QBOHelper.SparseUpdatePaymentMethod(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            PaymentMethod updated = Helper.Update<PaymentMethod>(qboContextoAuth, changed); //Verify the updated PaymentMethod
        
        }

        #endregion

        #region  Delete Operations


      

        #endregion

        #region  CDC Operations

         
        public void PaymentMethodCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PaymentMethodAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the PaymentMethod using CDC
            List<PaymentMethod> entities = Helper.CDC(qboContextoAuth, new PaymentMethod(), DateTime.Today.AddDays(-1));
           
        }

        #endregion

        #region  Batch

         
        public void PaymentMethodBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            PaymentMethod existing = Helper.FindOrAddPaymentMethod(qboContextoAuth, "CREDIT_CARD");

            batchEntries.Add(OperationEnum.create, QBOHelper.CreatePaymentMethod(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdatePaymentMethod(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from PaymentMethod");

            //  batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<PaymentMethod>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region  Query
         
        public void PaymentMethodQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<PaymentMethod> entityQuery = new QueryService<PaymentMethod>(qboContextoAuth);
            PaymentMethod existing = Helper.FindOrAdd<PaymentMethod>(qboContextoAuth, new PaymentMethod());
            List<PaymentMethod> tx = entityQuery.ExecuteIdsQuery("SELECT * FROM PaymentMethod where Id='" + existing.Id+"'").ToList<PaymentMethod>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

         
        public void PaymentMethodAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PaymentMethod for Add
            PaymentMethod entity = QBOHelper.CreatePaymentMethod(qboContextoAuth);

            PaymentMethod added = Helper.AddAsync<PaymentMethod>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation

         
        public void PaymentMethodRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PaymentMethodAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the PaymentMethod using FindAll
            Helper.FindAllAsync<PaymentMethod>(qboContextoAuth, new PaymentMethod());
        }

        #endregion

        #region  FindById Operation

         
        public void PaymentMethodFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PaymentMethod for Adding
            PaymentMethod entity = QBOHelper.CreatePaymentMethod(qboContextoAuth);
            //Adding the PaymentMethod
            PaymentMethod added = Helper.Add<PaymentMethod>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<PaymentMethod>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

         
        public void PaymentMethodUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the PaymentMethod for Adding
            PaymentMethod entity = QBOHelper.CreatePaymentMethod(qboContextoAuth);
            //Adding the PaymentMethod
            PaymentMethod added = Helper.Add<PaymentMethod>(qboContextoAuth, entity);

            //Update the PaymentMethod
            PaymentMethod updated = QBOHelper.UpdatePaymentMethod(qboContextoAuth, added);
            //Call the service
            PaymentMethod updatedReturned = Helper.UpdateAsync<PaymentMethod>(qboContextoAuth, updated);
           
        }

        #endregion

     

        #endregion
    }
}