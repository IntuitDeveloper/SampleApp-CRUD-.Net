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
    public class ItemCRUD
    {
        #region Sync Methods
        #region  Add Operations

         
        public void ItemAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Item for Add
            Item item = QBOHelper.CreateItem(qboContextoAuth);
            //Adding the Item
            Item added = Helper.Add<Item>(qboContextoAuth, item);
  

        }

        #endregion

        #region  FindAll Operations

         
        public void ItemFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            ItemAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Item using FindAll
            List<Item> items = Helper.FindAll<Item>(qboContextoAuth, new Item(), 1, 500);
  
        }

        #endregion

        #region  FindbyId Operations

         
        public void ItemFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Item for Adding
            Item item = QBOHelper.CreateItem(qboContextoAuth);
            //Adding the Item
            Item added = Helper.Add<Item>(qboContextoAuth, item);
            Item found = Helper.FindById<Item>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

         
        public void ItemUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Item for Adding
            Item item = QBOHelper.CreateItem(qboContextoAuth);

            //Adding the Item
            Item added = Helper.Add<Item>(qboContextoAuth, item);
            //Change the data of added entity
            Item changed = QBOHelper.UpdateItem(qboContextoAuth, added);
            //Update the returned entity data
            Item updated = Helper.Update<Item>(qboContextoAuth, changed);//Verify the updated Item
 
        }

 


         
        public void ItemSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Item for Adding
            Item item = QBOHelper.CreateItem(qboContextoAuth);
            //Adding the Item
            Item added = Helper.Add<Item>(qboContextoAuth, item);
            //Change the data of added entity
            Item changed = QBOHelper.SparseUpdateItem(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Item updated = Helper.Update<Item>(qboContextoAuth, changed);//Verify the updated Item
           
        }

        #endregion

        #region  Delete Operations



        //Delete is Soft Delete for Name List entities- Update operation with Active=false


        #endregion

        #region  CDC Operations

         
        public void ItemCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            ItemAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Item using FindAll
            List<Item> items = Helper.CDC(qboContextoAuth, new Item(), DateTime.Today.AddDays(-1));

        }

        #endregion

        #region  Batch

         
        public void ItemBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Item existing = Helper.FindOrAdd(qboContextoAuth, new Item());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateItem(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateItem(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Item");

            //batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Item>(qboContextoAuth, batchEntries);

        }

        #endregion

        #region  Query
         
        public void ItemQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Item> entityQuery = new QueryService<Item>(qboContextoAuth);
            Item existing = Helper.FindOrAdd<Item>(qboContextoAuth, new Item());
            List<Item> inv = entityQuery.ExecuteIdsQuery("SELECT * FROM Item where Id='" + existing.Id+"'").ToList<Item>();

        }

        #endregion


        #region ASync Methods

        #region  Add Operation

         
        public void ItemAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Item for Add
            Item entity = QBOHelper.CreateItem(qboContextoAuth);

            Item added = Helper.AddAsync<Item>(qboContextoAuth, entity);
         
        }

        #endregion

        #region  FindAll Operation

         
        public void ItemRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            ItemAddTestUsingoAuth (qboContextoAuth);

            //Retrieving the Item using FindAll
            Helper.FindAllAsync<Item>(qboContextoAuth, new Item());
        }

        #endregion

        #region  FindById Operation

         
        public void ItemFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Item for Adding
            Item entity = QBOHelper.CreateItem(qboContextoAuth);
            //Adding the Item
            Item added = Helper.Add<Item>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Item>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

         
        public void ItemUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Item for Adding
            Item entity = QBOHelper.CreateItem(qboContextoAuth);
            //Adding the Item
            Item added = Helper.Add<Item>(qboContextoAuth, entity);

            //Update the Item
            Item updated = QBOHelper.UpdateItem(qboContextoAuth, added);
            //Call the service
            Item updatedReturned = Helper.UpdateAsync<Item>(qboContextoAuth, updated);
            
        }

        #endregion

        #region  Delete Operation


        //Delete is Soft Delete for Name List entities- Update operation with Active=false

        #endregion



        #endregion

        #endregion
    }
}