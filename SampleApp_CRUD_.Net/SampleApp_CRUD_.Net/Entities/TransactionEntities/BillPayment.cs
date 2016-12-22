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
    public class BillPaymentCRUD
    {
        #region Sync Methods

        #region  Add Operations

        
        public void BillPaymentCheckAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Add
            BillPayment billPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);
            //Adding the BillPayment
            BillPayment added = Helper.Add<BillPayment>(qboContextoAuth, billPayment);

        }

        
        public void BillPaymentCreditCardAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Add
            BillPayment billPayment = QBOHelper.CreateBillPaymentCreditCard(qboContextoAuth);
            //Adding the BillPayment
            BillPayment added = Helper.Add<BillPayment>(qboContextoAuth, billPayment);
           
        }

        #endregion

        #region  FindbyId Operations

        
        public void BillPaymentFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Adding
            BillPayment billPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);
            //Adding the BillPayment
            BillPayment added = Helper.Add<BillPayment>(qboContextoAuth, billPayment);
            BillPayment found = Helper.FindById<BillPayment>(qboContextoAuth, added);
       
        }

        #endregion

        #region  Update Operations

        
        public void BillPaymentUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Adding
            BillPayment billPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);
            //Adding the BillPayment
            BillPayment added = Helper.Add<BillPayment>(qboContextoAuth, billPayment);
            //Change the data of added entity
            BillPayment changed = QBOHelper.UpdateBillPayment(qboContextoAuth, added);
            //Update the returned entity data
            BillPayment updated = Helper.Update<BillPayment>(qboContextoAuth, changed);//Verify the updated BillPayment
      
        }

        #endregion

        #region Delete Operations


        public void BillPaymentDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Adding
            BillPayment billPayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);
            //Adding the BillPayment
            BillPayment added = Helper.Add<BillPayment>(qboContextoAuth, billPayment);
            //Delete the returned entity
            try
            {
                BillPayment deleted = Helper.Delete<BillPayment>(qboContextoAuth, added);
            
            }
            catch (IdsException ex)
            {
        
            }
        }

        #endregion

        #region Void-Beta

        public void BillPaymentVoidTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Adding
            BillPayment billpayment = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);
            //Adding the BillPayment
            BillPayment added = Helper.Add<BillPayment>(qboContextoAuth, billpayment);
            //Void the returned entity
            try
            {
                BillPayment voided = Helper.Void<BillPayment>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }
        #endregion

        #region  CDC Operations

        //[Ignore]  //IgnoreReason:  Not Supported
        public void BillPaymentCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            BillPaymentCheckAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the BillPayment using CDC
            List<BillPayment> entities = Helper.CDC(qboContextoAuth, new BillPayment(), DateTime.Today.AddDays(-100));
            
        }

        #endregion

        #region  Batch

        
        public void BillPaymentBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            BillPayment entity = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);
            BillPayment existing = Helper.Add<BillPayment>(qboContextoAuth, entity);

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateBillPaymentCheck(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateBillPayment(qboContextoAuth, existing));

            //batchEntries.Add(OperationEnum.query, "select * from BillPayment");

            //batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<BillPayment>(qboContextoAuth, batchEntries);

        }

        #endregion

        #region  Query


        public void BillPaymentQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<BillPayment> entityQuery = new QueryService<BillPayment>(qboContextoAuth);
            BillPayment existing = Helper.FindOrAdd<BillPayment>(qboContextoAuth, new BillPayment());
            List<BillPayment> test = entityQuery.ExecuteIdsQuery("SELECT * FROM BillPayment where Id='" + existing.Id+"'").ToList<BillPayment>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation


        public void BillPaymentAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Add
            BillPayment entity = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);

            BillPayment added = Helper.AddAsync<BillPayment>(qboContextoAuth, entity);
        
        }

        #endregion

        #region  FindAll Operation

         //[Ignore] //IgnoreReason:  Not supported
        public void BillPaymentRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            BillPaymentCheckAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the BillPayment using FindAll
            Helper.FindAllAsync<BillPayment>(qboContextoAuth, new BillPayment());
        }

        #endregion

        #region  FindById Operation

        
        public void BillPaymentFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Adding
            BillPayment entity = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);
            //Adding the BillPayment
            BillPayment added = Helper.Add<BillPayment>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<BillPayment>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        
        public void BillPaymentUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the BillPayment for Adding
            BillPayment entity = QBOHelper.CreateBillPaymentCheck(qboContextoAuth);
            //Adding the BillPayment
            BillPayment added = Helper.Add<BillPayment>(qboContextoAuth, entity);

            //Update the BillPayment
            BillPayment updated = QBOHelper.UpdateBillPayment(qboContextoAuth, added);
            //Call the service
            BillPayment updatedReturned = Helper.UpdateAsync<BillPayment>(qboContextoAuth, updated);
       
        }

        #endregion

        

        #endregion
    }
}