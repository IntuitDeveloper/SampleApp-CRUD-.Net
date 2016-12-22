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
    public class VendorCreditCRUD
    {

        #region Sync Methods

        #region  Add Operations

        
        public void VendorCreditAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Add
            VendorCredit vendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth);
            //Adding the VendorCredit
            VendorCredit added = Helper.Add<VendorCredit>(qboContextoAuth, vendorCredit);
     
        }

        #endregion


        #region  FindbyId Operations

        
        public void VendorCreditFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Adding
            VendorCredit vendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth);
            //Adding the VendorCredit
            VendorCredit added = Helper.Add<VendorCredit>(qboContextoAuth, vendorCredit);
            VendorCredit found = Helper.FindById<VendorCredit>(qboContextoAuth, added);
       
        }

        #endregion

        #region  Update Operations

        
        public void VendorCreditUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Adding
            VendorCredit vendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth);
            //Adding the VendorCredit
            VendorCredit added = Helper.Add<VendorCredit>(qboContextoAuth, vendorCredit);
            //Change the data of added entity
            VendorCredit changed = QBOHelper.UpdateVendorCredit(qboContextoAuth, added);
            //Update the returned entity data
            VendorCredit updated = Helper.Update<VendorCredit>(qboContextoAuth, changed);//Verify the updated VendorCredit

        }

        
        public void VendorCreditSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Adding
            VendorCredit vendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth);
            //Adding the VendorCredit
            VendorCredit added = Helper.Add<VendorCredit>(qboContextoAuth, vendorCredit);
            //Change the data of added entity
            VendorCredit changed = QBOHelper.UpdateVendorCreditSparse(qboContextoAuth, added.Id, added.SyncToken, added.VendorRef);
            //Update the returned entity data
            VendorCredit updated = Helper.Update<VendorCredit>(qboContextoAuth, changed);//Verify the updated VendorCredit

        }

        #endregion

        #region  Delete Operations

        
        public void VendorCreditDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Adding
            VendorCredit vendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth);
            //Adding the VendorCredit
            VendorCredit added = Helper.Add<VendorCredit>(qboContextoAuth, vendorCredit);
            //Delete the returned entity
            try
            {
                VendorCredit deleted = Helper.Delete<VendorCredit>(qboContextoAuth, added);

            }
            catch (IdsException ex)
            {
           
            }
        }

       

        #endregion

        #region  CDC Operations

        
        public void VendorCreditCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            VendorCreditAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the VendorCredit using CDC
            List<VendorCredit> entities = Helper.CDC(qboContextoAuth, new VendorCredit(), DateTime.Today.AddDays(-1));
          
        }

        #endregion

        #region  Batch

        
        public void VendorCreditBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            //VendorCredit existing = Helper.FindOrAdd(qboContextoAuth, new VendorCredit());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateVendorCredit(qboContextoAuth));

            //batchEntries.Add(OperationEnum.update, QBOHelper.UpdateVendorCredit(qboContextoAuth, existing));

            //batchEntries.Add(OperationEnum.query, "select * from VendorCredit");

            //batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<VendorCredit>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region  Query

        public void VendorCreditQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<VendorCredit> entityQuery = new QueryService<VendorCredit>(qboContextoAuth);
            VendorCredit existing = Helper.FindOrAdd<VendorCredit>(qboContextoAuth, new VendorCredit());
            List<VendorCredit> test = entityQuery.ExecuteIdsQuery("SELECT * FROM VendorCredit where Id='" + existing.Id+"'").ToList<VendorCredit>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void VendorCreditAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Add
            VendorCredit entity = QBOHelper.CreateVendorCredit(qboContextoAuth);

            VendorCredit added = Helper.AddAsync<VendorCredit>(qboContextoAuth, entity);
        
        }

        #endregion

        #region  FindAll Operation

         //[Ignore]  //IgnoreReason:  Not Supported
        public void VendorCreditRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            VendorCreditAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the VendorCredit using FindAll
            Helper.FindAllAsync<VendorCredit>(qboContextoAuth, new VendorCredit());
        }

        #endregion

        #region  FindById Operation

        
        public void VendorCreditFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Adding
            VendorCredit entity = QBOHelper.CreateVendorCredit(qboContextoAuth);
            //Adding the VendorCredit
            VendorCredit added = Helper.Add<VendorCredit>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<VendorCredit>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation


        public void VendorCreditUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Adding
            VendorCredit entity = QBOHelper.CreateVendorCredit(qboContextoAuth);
            //Adding the VendorCredit
            VendorCredit added = Helper.Add<VendorCredit>(qboContextoAuth, entity);

            //Update the VendorCredit
            VendorCredit updated = QBOHelper.UpdateVendorCredit(qboContextoAuth, added);
            //Call the service
            VendorCredit updatedReturned = Helper.UpdateAsync<VendorCredit>(qboContextoAuth, updated);
        }

        #endregion

        #region  Delete Operation

        
        public void VendorCreditDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the VendorCredit for Adding
            VendorCredit entity = QBOHelper.CreateVendorCredit(qboContextoAuth);
            //Adding the VendorCredit
            VendorCredit added = Helper.Add<VendorCredit>(qboContextoAuth, entity);

            Helper.DeleteAsync<VendorCredit>(qboContextoAuth, added);
        }

        #endregion

      

        #endregion



    }
}