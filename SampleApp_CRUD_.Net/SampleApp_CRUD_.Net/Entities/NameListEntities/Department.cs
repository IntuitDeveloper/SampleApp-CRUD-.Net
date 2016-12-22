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
    public class DepartmentCRUD
    {


        #region Sync Methods

        #region  Add Operations

        
        public void DepartmentAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Department for Add
            Department department = QBOHelper.CreateDepartment(qboContextoAuth);
            //Adding the Department
            Department added = Helper.Add<Department>(qboContextoAuth, department);
    
        }

        #endregion

        #region  FindAll Operations

        
        public void DepartmentFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            DepartmentAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Department using FindAll
            List<Department> departments = Helper.FindAll<Department>(qboContextoAuth, new Department(), 1, 500);
        
        }

        #endregion

        #region  FindbyId Operations

        
        public void DepartmentFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Department for Adding
            Department department = QBOHelper.CreateDepartment(qboContextoAuth);
            //Adding the Department
            Department added = Helper.Add<Department>(qboContextoAuth, department);
            Department found = Helper.FindById<Department>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

        
        public void DepartmentUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Department for Adding
            Department department = QBOHelper.CreateDepartment(qboContextoAuth);
            //Adding the Department
            Department added = Helper.Add<Department>(qboContextoAuth, department);
            //Change the data of added entity
            Department changed = QBOHelper.UpdateDepartment(qboContextoAuth, added);
            //Update the returned entity data
            Department updated = Helper.Update<Department>(qboContextoAuth, changed);//Verify the updated Department
          
        }

        
        public void DepartmentSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Department for Adding
            Department department = QBOHelper.CreateDepartment(qboContextoAuth);
            //Adding the Department
            Department added = Helper.Add<Department>(qboContextoAuth, department);
            //Change the data of added entity
            Department changed = QBOHelper.UpdateDepartmentSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Department updated = Helper.Update<Department>(qboContextoAuth, changed);//Verify the updated Department

        }

        #endregion

       



        #region  CDC Operations

        
        public void DepartmentCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            DepartmentAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Department using CDC
            List<Department> entities = Helper.CDC(qboContextoAuth, new Department(), DateTime.Today.AddDays(-1));

        }

        #endregion

        #region  Batch

        
        public void DepartmentBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Department existing = Helper.FindOrAdd(qboContextoAuth, new Department());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateDepartment(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateDepartment(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Department");

            //batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Department>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region Query
        
        public void DepartmentQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Department> entityQuery = new QueryService<Department>(qboContextoAuth);
            Department existing = Helper.FindOrAdd<Department>(qboContextoAuth, new Department());
            List<Department> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Department where Id='" + existing.Id+"'").ToList<Department>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void DepartmentAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Department for Add
            Department entity = QBOHelper.CreateDepartment(qboContextoAuth);

            Department added = Helper.AddAsync<Department>(qboContextoAuth, entity);
     
        }

        #endregion

        #region  FindAll Operation

        
        public void DepartmentRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            DepartmentAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Department using FindAll
            Helper.FindAllAsync<Department>(qboContextoAuth, new Department());
        }

        #endregion

     

        #region  Update Operation

        
        public void DepartmentUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Department for Adding
            Department entity = QBOHelper.CreateDepartment(qboContextoAuth);
            //Adding the Department
            Department added = Helper.Add<Department>(qboContextoAuth, entity);

            //Update the Department
            Department updated = QBOHelper.UpdateDepartment(qboContextoAuth, added);
            //Call the service
            Department updatedReturned = Helper.UpdateAsync<Department>(qboContextoAuth, updated);
     
        }

        
        public void DepartmentSparseUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Department for Adding
            Department entity = QBOHelper.CreateDepartment(qboContextoAuth);
            //Adding the Department
            Department added = Helper.Add<Department>(qboContextoAuth, entity);

            //Update the Department
            Department updated = QBOHelper.UpdateDepartmentSparse(qboContextoAuth, added.Id, added.SyncToken);
            //Call the service
            Department updatedReturned = Helper.UpdateAsync<Department>(qboContextoAuth, updated);
         
        }

        #endregion

        

        #endregion
    }
}