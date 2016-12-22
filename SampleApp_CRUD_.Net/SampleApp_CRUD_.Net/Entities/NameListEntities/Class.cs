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
    public class ClassCRUD
    {
        #region Sync Methods

        #region  Add Operations

         
        public void ClassAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Class for Add
            Class class1 = QBOHelper.CreateClass(qboContextoAuth);
            //Adding the Class
            Class added = Helper.Add<Class>(qboContextoAuth, class1);
   
        }

        #endregion

        #region  FindAll Operations

         
        public void ClassFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            ClassAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Class using FindAll
            List<Class> classes = Helper.FindAll<Class>(qboContextoAuth, new Class(), 1, 500);
   
        }

        #endregion

        #region  FindbyId Operations

         
        public void ClassFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Class for Adding
            Class class1 = QBOHelper.CreateClass(qboContextoAuth);
            //Adding the Class
            Class added = Helper.Add<Class>(qboContextoAuth, class1);
            Class found = Helper.FindById<Class>(qboContextoAuth, added);
          
        }

        #endregion

        #region  Update Operations

         
        public void ClassUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Class for Adding
            Class class1 = QBOHelper.CreateClass(qboContextoAuth);
            //Adding the Class
            Class added = Helper.Add<Class>(qboContextoAuth, class1);
            //Change the data of added entity
            Class changed = QBOHelper.UpdateClass(qboContextoAuth, added);
            //Update the returned entity data
            Class updated = Helper.Update<Class>(qboContextoAuth, changed);//Verify the updated Class

        }

         
        public void ClassSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Class for Adding
            Class class1 = QBOHelper.CreateClass(qboContextoAuth);
            //Adding the Class
            Class added = Helper.Add<Class>(qboContextoAuth, class1);
            //Change the data of added entity
            Class changed = QBOHelper.SparseUpdateClass(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Class updated = Helper.Update<Class>(qboContextoAuth, changed);//Verify the updated Class

        }

        #endregion

        #region  Delete Operations


        //Delete is Soft Delete for Name List entities- Update operation with Active=false


        #endregion

        #region  CDC Operations

         
        public void ClassCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            ClassAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Class using FindAll
            List<Class> classes = Helper.CDC(qboContextoAuth, new Class(), DateTime.Today.AddDays(-1));
    
        }

        #endregion

        #region  Batch

         
        public void ClassBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Class existing = Helper.FindOrAdd(qboContextoAuth, new Class());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateClass(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateClass(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Class");

            // batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Class>(qboContextoAuth, batchEntries);

        }

        #endregion

        #region  Query
         
        public void ClassQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Class> entityQuery = new QueryService<Class>(qboContextoAuth);
            Class existing = Helper.FindOrAdd<Class>(qboContextoAuth, new Class());
            List<Class> cl = entityQuery.ExecuteIdsQuery("SELECT * FROM Class where Id='" + existing.Id+"'").ToList<Class>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

         
        public void ClassAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Class for Add
            Class entity = QBOHelper.CreateClass(qboContextoAuth);

            Class added = Helper.AddAsync<Class>(qboContextoAuth, entity);
            
        }

        #endregion

        #region  FindAll Operation

         
        public void ClassRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            ClassAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Class using FindAll
            Helper.FindAllAsync<Class>(qboContextoAuth, new Class());
        }

        #endregion

        #region  FindById Operation

         
        public void ClassFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Class for Adding
            Class entity = QBOHelper.CreateClass(qboContextoAuth);
            //Adding the Class
            Class added = Helper.Add<Class>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Class>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation

         
        public void ClassUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Class for Adding
            Class entity = QBOHelper.CreateClass(qboContextoAuth);
            //Adding the Class
            Class added = Helper.Add<Class>(qboContextoAuth, entity);

            //Update the Class
            Class updated = QBOHelper.UpdateClass(qboContextoAuth, added);
            //Call the service
            Class updatedReturned = Helper.UpdateAsync<Class>(qboContextoAuth, updated);
  
        }

        #endregion

        #region  Delete Operation


        //Delete is Soft Delete for Name List entities- Update operation with Active=false



        #endregion
        #endregion
    }
}