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
    public class CustomerCRUD
    {
        #region Sync Methods

        #region  Add Operations

        
        public void CustomerAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Customer for Add
            Customer customer = QBOHelper.CreateCustomer(qboContextoAuth);

            //Adding the Customer
            Customer added = Helper.Add<Customer>(qboContextoAuth, customer);

          
        }

        
      

        #endregion

        #region  FindAll Operations

        
        public void CustomerFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CustomerAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Customer using FindAll
            List<Customer> customers = Helper.FindAll<Customer>(qboContextoAuth, new Customer(), 1, 500);
        
        }


   

        
        public void CustomerRetrieveAsyncTestsNullEntityUsingoAuth(ServiceContext qboContextoAuth)
        {
            try
            {
                Helper.FindAll<Customer>(qboContextoAuth, null);
 
            }
            catch (IdsException)
            {

            }
        }

        #endregion

        #region  FindbyId Operations

        
        public void CustomerFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Customer for Adding
            Customer customer = QBOHelper.CreateCustomer(qboContextoAuth);
            //Adding the Customer
            Customer added = Helper.Add<Customer>(qboContextoAuth, customer);
            Customer found = Helper.FindById<Customer>(qboContextoAuth, added);
      
        }

     
        
        public void CustomerFindByIdTestsNullEntityUsingoAuth(ServiceContext qboContextoAuth)
        {
            try
            {
                Helper.FindById<Customer>(qboContextoAuth, null);

            }
            catch (IdsException)
            {

            }
        }

        #endregion

        #region  Update Operations

        
       
        public void CustomerUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Customer for Adding
            Customer customer = QBOHelper.CreateCustomer(qboContextoAuth);
            //Adding the Customer
            Customer added = Helper.Add<Customer>(qboContextoAuth, customer);
            //Change the data of added entity
            Customer updated = QBOHelper.UpdateCustomer(qboContextoAuth, added);
            //Update the returned entity data
            Customer updatedreturned = Helper.Update<Customer>(qboContextoAuth, updated);
         
        }


        
        public void CustomerSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Customer for Adding
            Customer customer = QBOHelper.CreateCustomer(qboContextoAuth);
            //Adding the Customer
            Customer added = Helper.Add<Customer>(qboContextoAuth, customer);
            //Change the data of added entity
            Customer updated = QBOHelper.SparseUpdateCustomer(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Customer updatedreturned = Helper.Update<Customer>(qboContextoAuth, updated);
            
        }

        
        public void CustomerUpdateTestsNullEntityUsingoAuth(ServiceContext qboContextoAuth)
        {
            try
            {
                Customer updatedReturned = Helper.Update<Customer>(qboContextoAuth, null);
       
            }
            catch (IdsException)
            {
            }

        }

        #endregion

        

     

        #region  CDC Operations

        
        public void CustomerCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CustomerAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Customer using FindAll
            List<Customer> customers = Helper.CDC(qboContextoAuth, new Customer(), DateTime.Today.AddDays(-1));
          
        }

        #endregion

        #region  Batch

        
        public void CustomerBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Customer existing = Helper.FindOrAdd(qboContextoAuth, new Customer());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateCustomer(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateCustomer(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Customer");

            //batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Customer>(qboContextoAuth, batchEntries);

          
        }

        #endregion

        #region  Query
        
        public void CustomerQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Customer> entityQuery = new QueryService<Customer>(qboContextoAuth);
            List<Customer> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Customer").ToList<Customer>();

        }

        
        public void CustomerQueryWithSpecialCharacterUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Customer> entityQuery = new QueryService<Customer>(qboContextoAuth);
            Customer test = entityQuery.ExecuteIdsQuery("SELECT * FROM Customer where DisplayName='Customer\\'s Business'").FirstOrDefault<Customer>();
        }

        #endregion

        #endregion

        #region ASync Methods

        #region Test Cases for Add Operation

        
        public void CustomerAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Customer for Add
            Customer entity = QBOHelper.CreateCustomer(qboContextoAuth);

            Customer added = Helper.AddAsync<Customer>(qboContextoAuth, entity);

        }

        #endregion

        #region Test Cases for FindAll Operation

        
        public void CustomerRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            CustomerAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Customer using FindAll
            Helper.FindAllAsync<Customer>(qboContextoAuth, new Customer());
        }

        #endregion

        #region Test Cases for FindById Operation

        
        public void CustomerFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Customer for Adding
            Customer entity = QBOHelper.CreateCustomer(qboContextoAuth);
            //Adding the Customer
            Customer added = Helper.Add<Customer>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Customer>(qboContextoAuth, added);
        }

        #endregion

        #region Test Cases for Update Operation

        
        public void CustomerUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Customer for Adding
            Customer entity = QBOHelper.CreateCustomer(qboContextoAuth);
            //Adding the Customer
            Customer added = Helper.Add<Customer>(qboContextoAuth, entity);

            //Update the Customer
            Customer updated = QBOHelper.UpdateCustomer(qboContextoAuth, added);
            //Call the service
            Customer updatedReturned = Helper.UpdateAsync<Customer>(qboContextoAuth, updated);

        }

        #endregion

       
        

        #endregion

    }
}