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
    public class TermCRUD
    {
        #region Sync Methods

        #region  Add Operations


        public void TermAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Bill for Add
            Term term = QBOHelper.CreateTerm(qboContextoAuth);
            //Adding the Term
            Term added = Helper.Add<Term>(qboContextoAuth, term);

        }

        #endregion

        #region  FindAll Operations


        public void TermFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            TermAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Term using FindAll
            List<Term> terms = Helper.FindAll<Term>(qboContextoAuth, new Term(), 1, 500);

        }

        #endregion

        #region  FindbyId Operations


        public void TermFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Term for Adding
            Term term = QBOHelper.CreateTerm(qboContextoAuth);
            //Adding the Term
            Term added = Helper.Add<Term>(qboContextoAuth, term);
            Term found = Helper.FindById<Term>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations


        public void TermUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Term for Adding
            Term term = QBOHelper.CreateTerm(qboContextoAuth);
            //Adding the Term
            Term added = Helper.Add<Term>(qboContextoAuth, term);
            //Change the data of added entity
            Term changed = QBOHelper.UpdateTerm(qboContextoAuth, added);
            //Update the returned entity data
            Term updated = Helper.Update<Term>(qboContextoAuth, changed);//Verify the updated Term

        }


        public void TermSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Term for Adding
            Term term = QBOHelper.CreateTerm(qboContextoAuth);
            //Adding the Term
            Term added = Helper.Add<Term>(qboContextoAuth, term);
            //Change the data of added entity
            Term changed = QBOHelper.SparseUpdateTerm(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Term updated = Helper.Update<Term>(qboContextoAuth, changed);//Verify the updated Term

        }

        #endregion



        #region  CDC Operations


        public void TermCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            TermAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Term using CDC
            List<Term> entities = Helper.CDC(qboContextoAuth, new Term(), DateTime.Today.AddDays(-1));

        }

        #endregion

        #region  Batch


        public void TermBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Term existing = Helper.FindOrAdd(qboContextoAuth, new Term());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateTerm(qboContextoAuth));

            //batchEntries.Add(OperationEnum.update, QBOHelper.UpdateTerm(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Term");

            //  batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Term>(qboContextoAuth, batchEntries);


        }

        #endregion

        #region  Query

        public void TermQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Term> entityQuery = new QueryService<Term>(qboContextoAuth);
            Term existing = Helper.FindOrAdd<Term>(qboContextoAuth, new Term());
            List<Term> test = entityQuery.ExecuteIdsQuery("SELECT * FROM Term where Id='" + existing.Id+"'").ToList<Term>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation


        public void TermAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Term for Add
            Term entity = QBOHelper.CreateTerm(qboContextoAuth);

            Term added = Helper.AddAsync<Term>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation


        public void TermRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            TermAddTestUsingoAuth(qboContextoAuth);

            //Retrieving the Term using FindAll
            Helper.FindAllAsync<Term>(qboContextoAuth, new Term());
        }

        #endregion

        #region  FindById Operation


        public void TermFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Term for Adding
            Term entity = QBOHelper.CreateTerm(qboContextoAuth);
            //Adding the Term
            Term added = Helper.Add<Term>(qboContextoAuth, entity);

            //FindById and verify
            Helper.FindByIdAsync<Term>(qboContextoAuth, added);
        }

        #endregion

        #region  Update Operation


        public void TermUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Term for Adding
            Term entity = QBOHelper.CreateTerm(qboContextoAuth);
            //Adding the Term
            Term added = Helper.Add<Term>(qboContextoAuth, entity);

            //Update the Term
            Term updated = QBOHelper.UpdateTerm(qboContextoAuth, added);
            //Call the service
            Term updatedReturned = Helper.UpdateAsync<Term>(qboContextoAuth, updated);

        }

        #endregion
        #endregion

    }
}