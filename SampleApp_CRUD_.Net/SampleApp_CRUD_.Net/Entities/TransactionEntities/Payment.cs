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
    public class PaymentCRUD
    {
        #region Sync Methods

        #region Link Payment to Invoice
        //Link a Payment to Invoice

        ////payment add
        //Payment p1 = new Payment();
        //p1.TxnDate = DateTime.Now.Date;
        //                    p1.TxnDateSpecified = true;

        //                    //p1.Line = new Line[1];
        //                    //p1.Line[0] = new Line();
        //                    //p1.Line[0].Amount = 20.00M;
        //                    //p1.Line[0].AmountSpecified = true;

        //                    //p1.Line[0].LinkedTxn = new LinkedTxn[1];
        //                    //p1.Line[0].LinkedTxn[0] = new LinkedTxn();
        //                    //p1.Line[0].LinkedTxn[0].TxnId = "10";
        //                    //p1.Line[0].LinkedTxn[0].TxnType = "Invoice";// or creditmemo


        //                    List<Line> lineList1 = new List<Line>();
        //Line paymentLine = new Line();
        //paymentLine.Amount = 20.00M;
        //                    paymentLine.AmountSpecified = true;
        //                    List<LinkedTxn> linkedTxnList = new List<LinkedTxn>();
        //LinkedTxn linkedtxn = new LinkedTxn();
        //linkedtxn.TxnId = "24";
        //                    linkedtxn.TxnType = "Invoice";
        //                    linkedTxnList.Add( linkedtxn);
        //                    paymentLine.LinkedTxn = linkedTxnList.ToArray();
        //                    lineList1.Add(paymentLine);                        
        //                    p1.Line = lineList1.ToArray();


        //                    p1.CustomerRef = new ReferenceType() { Value = "1" };
        //p1.DepositToAccountRef = new ReferenceType() { Value = "4" };
        //p1.PaymentRefNum = "Cash#01";

        //                    p1.TotalAmt = 20.00M;
        //                    p1.TotalAmtSpecified = true;

        //                    var result = commonServiceQBO.Add<Payment>(p1);
        #endregion

        #region  Add Operations


        public void PaymentAddTestUsingCheck(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Add
            Payment payment = QBOHelper.CreatePaymentCheck(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, payment);
          
        }

        
        public void PaymentAddTestUsingCreditCard(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Add
            Payment payment = QBOHelper.CreatePaymentCreditCard(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, payment);
    
        }

        
        public void PaymentAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Add
            Payment payment = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, payment);
          
        }

        #endregion

        #region  FindAll Operations

        
        public void PaymentFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PaymentAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Payment using FindAll
            List<Payment> payments = Helper.FindAll<Payment>(qboContextoAuth, new Payment(), 1, 500);

        }

        #endregion

        #region  FindbyId Operations

        
        public void PaymentFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Adding
            Payment payment = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, payment);
            Payment found = Helper.FindById<Payment>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

        
        public void PaymentUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Adding
            Payment payment = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, payment);
            //Change the data of added entity
            Payment changed = QBOHelper.UpdatePayment(qboContextoAuth, added);
            //Update the returned entity data
            Payment updated = Helper.Update<Payment>(qboContextoAuth, changed);//Verify the updated Payment

        }

        
        public void PaymentSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Adding
            Payment payment = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, payment);
            //Change the data of added entity
            Payment changed = QBOHelper.SparseUpdatePayment(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Payment updated = Helper.Update<Payment>(qboContextoAuth, changed);//Verify the updated Payment

        }

        #endregion

        #region  Delete Operations

        
        public void PaymentDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Adding
            Payment payment = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, payment);
            //Delete the returned entity
            try
            {
                Payment deleted = Helper.Delete<Payment>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }




        #endregion

        #region Void operation

        public void PaymentVoidTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Adding
            Payment payment = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, payment);
            //Void the returned entity
            try
            {
                Payment voided = Helper.Void<Payment>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }

        #endregion


        #region  CDC Operations


        public void PaymentCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PaymentAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Payment using CDC
            List<Payment> entities = Helper.CDC(qboContextoAuth, new Payment(), DateTime.Today.AddDays(-1));

        }

        #endregion

        #region  Batch

        
        public void PaymentBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Payment existing = Helper.FindOrAdd(qboContextoAuth, new Payment());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreatePayment(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdatePayment(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Payment");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Payment>(qboContextoAuth, batchEntries);

          
        }

        #endregion

        #region  Query
        
        public void PaymentQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Payment> entityQuery = new QueryService<Payment>(qboContextoAuth);
            Payment existing = Helper.FindOrAdd<Payment>(qboContextoAuth, new Payment());
            List<Payment> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Payment where Id='" + existing.Id+"'").ToList<Payment>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void PaymentAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Add
            Payment entity = QBOHelper.CreatePayment(qboContextoAuth);

            Payment added = Helper.AddAsync<Payment>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation

        
        public void PaymentRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            PaymentAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Payment using FindAll
            Helper.FindAllAsync<Payment>(qboContextoAuth, new Payment());
        }

        #endregion

        #region  FindById Operation

        
        public void PaymentFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Adding
            Payment entity = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Payment>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

        
        public void PaymentUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Adding
            Payment entity = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, entity);

            //Update the Payment
            Payment updated = QBOHelper.UpdatePayment(qboContextoAuth, added);
            //Call the service
            Payment updatedReturned = Helper.UpdateAsync<Payment>(qboContextoAuth, updated);
      
        }

        #endregion

        #region  Delete Operation

        
        public void PaymentDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Payment for Adding
            Payment entity = QBOHelper.CreatePayment(qboContextoAuth);
            //Adding the Payment
            Payment added = Helper.Add<Payment>(qboContextoAuth, entity);

            Helper.DeleteAsync<Payment>(qboContextoAuth, added);
        }

        #endregion


        #endregion
    }
}