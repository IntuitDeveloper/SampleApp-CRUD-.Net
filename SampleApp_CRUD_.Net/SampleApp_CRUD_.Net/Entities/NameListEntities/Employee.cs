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
    public class EmployeeCRUD
    {
        #region Sync Methods

        #region  Add Operations

        
        public void EmployeeAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Employee for Add
            Employee employee = QBOHelper.CreateEmployee(qboContextoAuth);
            //Adding the Employee
            Employee added = Helper.Add<Employee>(qboContextoAuth, employee);

    
        }

        #endregion

        #region  FindAll Operations

        
        public void EmployeeFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            Employee employee = Helper.FindOrAdd(qboContextoAuth, new Employee());

            //Retrieving the Employee using FindAll
            List<Employee> employees = Helper.FindAll<Employee>(qboContextoAuth, new Employee(), 1, 500);

        }

        #endregion

        #region  FindbyId Operations

        
        public void EmployeeFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Employee for Adding
            Employee employee = Helper.FindOrAdd(qboContextoAuth, new Employee());
            Employee found = Helper.FindById<Employee>(qboContextoAuth, employee);
            
        }

        #endregion

        #region  Update Operations

        
        public void EmployeeUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            Employee employee = Helper.FindOrAdd(qboContextoAuth, new Employee());
            //Change the data of added entity
            Employee changed = QBOHelper.UpdateEmployee(qboContextoAuth, employee);
            //Update the returned entity data
            Employee updated = Helper.Update<Employee>(qboContextoAuth, changed);//Verify the updated Employee
        
        }

        
        public void EmployeeSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            Employee employee = Helper.FindOrAdd(qboContextoAuth, new Employee());
            //Change the data of added entity
            Employee changed = QBOHelper.SparseUpdateEmployee(qboContextoAuth, employee.Id, employee.SyncToken);
            //Update the returned entity data
            Employee updated = Helper.Update<Employee>(qboContextoAuth, changed);//Verify the updated Employee
   
        }

        #endregion

        

        #region  CDC Operations

        
        public void EmployeeCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            Employee employee = Helper.FindOrAdd(qboContextoAuth, new Employee());

            //Retrieving the Employee using CDC
            List<Employee> entities = Helper.CDC(qboContextoAuth, new Employee(), DateTime.Now.AddDays(-100));
          
        }

        #endregion

        #region  Batch

        
        public void EmployeeBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Employee existing = Helper.FindOrAdd(qboContextoAuth, new Employee());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateEmployee(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateEmployee(qboContextoAuth, existing));

            //batchEntries.Add(OperationEnum.query, "select * from Employee");

            //batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Employee>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region  Query

        
        public void EmployeeQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Employee> entityQuery = new QueryService<Employee>(qboContextoAuth);
            Employee existing = Helper.FindOrAdd<Employee>(qboContextoAuth, new Employee());
            List<Employee> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Employee where Id='" + existing.Id+"'").ToList<Employee>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void EmployeeAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Employee for Add
            Employee entity = QBOHelper.CreateEmployee(qboContextoAuth);

            Employee added = Helper.AddAsync<Employee>(qboContextoAuth, entity);
            
        }

        #endregion

        #region  FindAll Operation

        
        public void EmployeeRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            Employee employee = Helper.FindOrAdd(qboContextoAuth, new Employee());

            //Retrieving the Employee using FindAll
            Helper.FindAllAsync<Employee>(qboContextoAuth, new Employee());
        }

        #endregion

        #region  FindById Operation

        
        public void EmployeeFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            Employee employee = Helper.FindOrAdd(qboContextoAuth, new Employee());

            //FindById and verify
            Helper.FindByIdAsync<Employee>(qboContextoAuth, employee);
        }

        #endregion

        #region  Update Operation

        
        public void EmployeeUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            Employee employee = Helper.FindOrAdd(qboContextoAuth, new Employee());

            //Update the Employee
            Employee updated = QBOHelper.UpdateEmployee(qboContextoAuth, employee);
            //Call the service
            Employee updatedReturned = Helper.UpdateAsync<Employee>(qboContextoAuth, updated);
            
        }

        #endregion

       

        #endregion

    }
}