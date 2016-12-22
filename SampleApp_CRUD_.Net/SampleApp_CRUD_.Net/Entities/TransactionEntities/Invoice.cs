using System;
using System.Collections.Generic;
using System.Linq;
using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.Exception;
using System.Collections.ObjectModel;
using Intuit.Ipp.DataService;
using Intuit.Ipp.QueryFilter;


namespace SampleApp_CRUD_DotNet
{
    public class InvoiceCRUD
    {
        #region Sync Methods


        #region  Add Operations

   
        public void InvoiceAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Add
            Invoice invoice = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, invoice);
           
        }

        #endregion

        #region   FindbyId Operations


        public void InvoiceFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Adding
            Invoice invoice = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, invoice);
            Invoice found = Helper.FindById<Invoice>(qboContextoAuth, added);

        }

        #endregion

        #region   Update Operations


        public void InvoiceUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Adding
            Invoice invoice = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, invoice);
            //Change the data of added entity
            Invoice changed = QBOHelper.UpdateInvoice(qboContextoAuth, added);
            //Update the returned entity data
            Invoice updated = Helper.Update<Invoice>(qboContextoAuth, changed);//Verify the updated Invoice

        }



        public void InvoiceSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Adding
            Invoice invoice = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, invoice);
            //Change the data of added entity
            Invoice changed = QBOHelper.SparseUpdateInvoice(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Invoice updated = Helper.Update<Invoice>(qboContextoAuth, changed);//Verify the updated Invoice

        }

        #endregion

        #region   Delete Operations


        public void InvoiceDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Adding
            Invoice invoice = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, invoice);
            //Delete the returned entity
            try
            {
                Invoice deleted = Helper.Delete<Invoice>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }




        public void InvoiceVoidTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Adding
            Invoice invoice = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, invoice);
            //Void the returned entity
            try
            {
                Invoice voided = Helper.Void<Invoice>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {

            }
        }

        #endregion

        #region   CDC Operations


        public void InvoiceCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            //InvoiceAddTestUsingoAuth();

            //Retrieving the Invoice using FindAll
            List<Invoice> invoices = Helper.CDC(qboContextoAuth, new Invoice(), DateTime.Today.AddDays(-1));

        }

        #endregion

        #region   Batch


        public void InvoiceBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Invoice existing = Helper.FindOrAdd(qboContextoAuth, new Invoice());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateInvoice(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateInvoice(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Invoice");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Invoice>(qboContextoAuth, batchEntries);



        }

        #endregion

        #region   Query

        public void InvoiceQueryTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Invoice> entityQuery = new QueryService<Invoice>(qboContextoAuth);
            Invoice existing = Helper.FindOrAdd<Invoice>(qboContextoAuth, new Invoice());
            List<Invoice> inv = entityQuery.ExecuteIdsQuery("SELECT * FROM Invoice where Id='" + existing.Id+"'").ToList<Invoice>();

        }

        #endregion
        #endregion

        #region ASync Methods

        #region   Add Operation

  
        public void InvoiceAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Add
            Invoice entity = QBOHelper.CreateInvoice(qboContextoAuth);

            Invoice added = Helper.AddAsync<Invoice>(qboContextoAuth, entity);
          
        }

        #endregion

       

        #region   FindById Operation


        public void InvoiceFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Adding
            Invoice entity = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Invoice>(qboContextoAuth, added);
        }

        #endregion

        #region   Update Operation

        
        public void InvoiceUpdateAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Adding
            Invoice entity = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, entity);

            //Update the Invoice
            Invoice updated = QBOHelper.UpdateInvoice(qboContextoAuth, added);
            //Call the service
            Invoice updatedReturned = Helper.UpdateAsync<Invoice>(qboContextoAuth, updated);
           
        }

        #endregion

        #region   Delete Operation


        public void InvoiceDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Invoice for Adding
            Invoice entity = QBOHelper.CreateInvoice(qboContextoAuth);
            //Adding the Invoice
            Invoice added = Helper.Add<Invoice>(qboContextoAuth, entity);

            Helper.DeleteAsync<Invoice>(qboContextoAuth, added);
        }

        #endregion

       

        #endregion
    }
}