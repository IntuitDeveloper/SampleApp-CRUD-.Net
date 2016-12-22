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
    public class VendorCRUD
    {

        #region Sync Methods

        #region  Add Operations

         
        public void VendorAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Vendor for Add
            Vendor vendor = QBOHelper.CreateVendor(qboContextoAuth);
            //Adding the Vendor
            Vendor added = Helper.Add<Vendor>(qboContextoAuth, vendor);
            
        }

        #endregion

        #region  FindAll Operations

         
        public void VendorFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            VendorAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Vendor using FindAll
            List<Vendor> vendors = Helper.FindAll<Vendor>(qboContextoAuth, new Vendor(), 1, 500);
           
        }

        #endregion

        #region  FindbyId Operations

         
        public void VendorFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Vendor for Adding
            Vendor vendor = QBOHelper.CreateVendor(qboContextoAuth);
            //Adding the Vendor
            Vendor added = Helper.Add<Vendor>(qboContextoAuth, vendor);
            Vendor found = Helper.FindById<Vendor>(qboContextoAuth, added);
 
        }

        #endregion

        #region  Update Operations

         
        public void VendorUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Vendor for Adding
            Vendor vendor = QBOHelper.CreateVendor(qboContextoAuth);
            //Adding the Vendor
            Vendor added = Helper.Add<Vendor>(qboContextoAuth, vendor);
            //Change the data of added entity
            Vendor changed = QBOHelper.UpdateVendor(qboContextoAuth, added);
            //Update the returned entity data
            Vendor updated = Helper.Update<Vendor>(qboContextoAuth, changed);//Verify the updated Vendor

        }

         
        public void VendorSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Vendor for Adding
            Vendor vendor = QBOHelper.CreateVendor(qboContextoAuth);
            //Adding the Vendor
            Vendor added = Helper.Add<Vendor>(qboContextoAuth, vendor);
            //Change the data of added entity
            Vendor changed = QBOHelper.SparseUpdateVendor(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Vendor updated = Helper.Update<Vendor>(qboContextoAuth, changed);//Verify the updated Vendor

        }

        #endregion


       


        #region  Delete Operations

      

        #endregion

        #region  CDC Operations

         
        public void VendorCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            VendorAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Vendor using FindAll
            List<Vendor> vendors = Helper.CDC(qboContextoAuth, new Vendor(), DateTime.Today.AddDays(-1));

        }

        #endregion

        #region  Batch

         
        public void VendorBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Vendor existing = Helper.FindOrAdd(qboContextoAuth, new Vendor());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateVendor(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateVendor(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Vendor");

            //   batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Vendor>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region  Query
         
        public void VendorQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Vendor> entityQuery = new QueryService<Vendor>(qboContextoAuth);
            Vendor existing = Helper.FindOrAdd<Vendor>(qboContextoAuth, new Vendor());
            List<Vendor> ve = entityQuery.ExecuteIdsQuery("SELECT * FROM Vendor where Id='" + existing.Id+"'").ToList<Vendor>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

         
        public void VendorAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Vendor for Add
            Vendor entity = QBOHelper.CreateVendor(qboContextoAuth);

            Vendor added = Helper.AddAsync<Vendor>(qboContextoAuth, entity);
          
        }

        #endregion

        #region  FindAll Operation

         
        public void VendorRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            VendorAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Vendor using FindAll
            Helper.FindAllAsync<Vendor>(qboContextoAuth, new Vendor());
        }

        #endregion

        #region  FindById Operation

         
        public void VendorFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Vendor for Adding
            Vendor entity = QBOHelper.CreateVendor(qboContextoAuth);
            //Adding the Vendor
            Vendor added = Helper.Add<Vendor>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Vendor>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

         
        public void VendorUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Vendor for Adding
            Vendor entity = QBOHelper.CreateVendor(qboContextoAuth);
            //Adding the Vendor
            Vendor added = Helper.Add<Vendor>(qboContextoAuth, entity);

            //Update the Vendor
            Vendor updated = QBOHelper.UpdateVendor(qboContextoAuth, added);
            //Call the service
            Vendor updatedReturned = Helper.UpdateAsync<Vendor>(qboContextoAuth, updated);
    
        }

        #endregion


       




        #region  Delete Operation

        #endregion

        #endregion
    }
}