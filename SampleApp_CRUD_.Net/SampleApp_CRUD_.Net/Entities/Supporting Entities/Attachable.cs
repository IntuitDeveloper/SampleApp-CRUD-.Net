using System;
using System.Collections.Generic;
using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.QueryFilter;
using Intuit.Ipp.DataService;
using Intuit.Ipp.Exception;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;

namespace SampleApp_CRUD_DotNet
{
    public class AttachableCRUD
    {

        #region Sync Methods

        #region  Add Operations

        //This attachable endpoint is used to add a note
        public void AttachableAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Add
            Attachable attachable = QBOHelper.CreateAttachable(qboContextoAuth);
            //Adding the Attachable
            Attachable added = Helper.Add<Attachable>(qboContextoAuth, attachable);
            //Verify the added Attachable

        }


        //This is the endpoint for actual uppload of any attachments pdf/images/xls etc
        public void AttachableUploadDownloadAddTestUsingoAuth(ServiceContext qboContextoAuth)
        {
           

            string imagePath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\", "Resource\\invoice.pdf");
            
            System.IO.FileInfo file = new System.IO.FileInfo(imagePath);
            Attachable attachable = QBOHelper.CreateAttachableUpload(qboContextoAuth);
            using (System.IO.FileStream fs = file.OpenRead())
            {
                //attachable.ContentType = "image/jpeg";
                attachable.ContentType = "application/pdf";
                attachable.FileName = file.Name;
                attachable = Helper.Upload(qboContextoAuth, attachable, fs);
            }
            //Upload attachment
            byte[] uploadedByte = null;
            using (System.IO.FileStream fs = file.OpenRead())
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    uploadedByte = binaryReader.ReadBytes((int)fs.Length);
                }
            }
            //To read online file
            //using (MemoryStream fs1 = new MemoryStream())
            //{
            //    using (BinaryReader binaryReader = new BinaryReader(fs1))
            //    {
            //        uploadedByte = binaryReader.ReadBytes((int)fs1.Length);
            //    }
            //}

            //Dowload Attachment
            byte[] responseByte = Helper.Download(qboContextoAuth, attachable);


        }
        #endregion

        #region  FindAll Operations

        
        public void AttachableFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            AttachableAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Attachable using FindAll
            List<Attachable> attachables = Helper.FindAll<Attachable>(qboContextoAuth, new Attachable(), 1, 500);
            
        }

        #endregion

        #region  FindbyId Operations

        
        public void AttachableFindbyIdTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Adding
            Attachable attachable = QBOHelper.CreateAttachable(qboContextoAuth);
            //Adding the Attachable
            Attachable added = Helper.Add<Attachable>(qboContextoAuth, attachable);
            Attachable found = Helper.FindById<Attachable>(qboContextoAuth, added);

        }

        #endregion

        #region  Update Operations

        
        public void AttachableUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Adding
            Attachable attachable = QBOHelper.CreateAttachable(qboContextoAuth);
            //Adding the Attachable
            Attachable added = Helper.Add<Attachable>(qboContextoAuth, attachable);
            //Change the data of added entity
            Attachable changed = QBOHelper.UpdateAttachable(qboContextoAuth, added);
            //Update the returned entity data
            Attachable updated = Helper.Update<Attachable>(qboContextoAuth, changed);//Verify the updated Attachable

        }

        
        public void AttachableSparseUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Adding
            Attachable attachable = QBOHelper.CreateAttachable(qboContextoAuth);
            //Adding the Attachable
            Attachable added = Helper.Add<Attachable>(qboContextoAuth, attachable);
            //Change the data of added entity
            Attachable changed = QBOHelper.SparseUpdateAttachable(qboContextoAuth, added.Id, added.SyncToken);
            //Update the returned entity data
            Attachable updated = Helper.Update<Attachable>(qboContextoAuth, changed);//Verify the updated Attachable
    
        }

        #endregion

        #region  Delete Operations

        
        public void AttachableDeleteTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Adding
            Attachable attachable = QBOHelper.CreateAttachable(qboContextoAuth);
            //Adding the Attachable
            Attachable added = Helper.Add<Attachable>(qboContextoAuth, attachable);
            //Delete the returned entity
            try
            {
                Attachable deleted = Helper.Delete<Attachable>(qboContextoAuth, added);
              
            }
            catch (IdsException ex)
            {
        
            }
        }

        
      

        #endregion

        #region  CDC Operations

        
        public void AttachableCDCTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            AttachableAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Attachable using CDC
            List<Attachable> entities = Helper.CDC(qboContextoAuth, new Attachable(), DateTime.Today.AddDays(-1));

        }

        #endregion

        #region  Batch

        
        public void AttachableBatchUsingoAuth(ServiceContext qboContextoAuth)
        {
            Dictionary<OperationEnum, object> batchEntries = new Dictionary<OperationEnum, object>();

            Attachable existing = Helper.FindOrAdd(qboContextoAuth, new Attachable());

            batchEntries.Add(OperationEnum.create, QBOHelper.CreateAttachable(qboContextoAuth));

            batchEntries.Add(OperationEnum.update, QBOHelper.UpdateAttachable(qboContextoAuth, existing));

            batchEntries.Add(OperationEnum.query, "select * from Attachable");

            batchEntries.Add(OperationEnum.delete, existing);

            ReadOnlyCollection<IntuitBatchResponse> batchResponses = Helper.Batch<Attachable>(qboContextoAuth, batchEntries);

           
        }

        #endregion

        #region  Query
        
        public void AttachableQueryUsingoAuth(ServiceContext qboContextoAuth)//Nimisha verify
        {
            QueryService<Attachable> entityQuery = new QueryService<Attachable>(qboContextoAuth);
            Attachable existing = Helper.FindOrAdd<Attachable>(qboContextoAuth, new Attachable());
            List<Attachable> pref = entityQuery.ExecuteIdsQuery("SELECT * FROM Attachable where Id='" + existing.Id+"'").ToList<Attachable>();

        }

        #endregion

        #endregion

        #region ASync Methods

        #region  Add Operation

        
        public void AttachableAddAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Add
            Attachable entity = QBOHelper.CreateAttachable(qboContextoAuth);

            Attachable added = Helper.AddAsync<Attachable>(qboContextoAuth, entity);

        }

        #endregion

        #region  FindAll Operation

        
        public void AttachableRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Making sure that at least one entity is already present
            AttachableAddTestUsingoAuth( qboContextoAuth);

            //Retrieving the Attachable using FindAll
     
        }

        #endregion

        #region  FindById Operation

        
        public void AttachableFindByIdAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Adding
            Attachable entity = QBOHelper.CreateAttachable(qboContextoAuth);
            //Adding the Attachable
            Attachable added = Helper.Add<Attachable>(qboContextoAuth, entity);

         
        }

        #endregion

        #region  Update Operation

        
        public void AttachableUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Adding
            Attachable entity = QBOHelper.CreateAttachable(qboContextoAuth);
            //Adding the Attachable
            Attachable added = Helper.Add<Attachable>(qboContextoAuth, entity);

            //Update the Attachable
            Attachable updated = QBOHelper.UpdateAttachable(qboContextoAuth, added);
            //Call the service
            Attachable updatedReturned = Helper.UpdateAsync<Attachable>(qboContextoAuth, updated);
           
        }

        #endregion

        #region  Delete Operation

        
        public void AttachableDeleteAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            //Creating the Attachable for Adding
            Attachable entity = QBOHelper.CreateAttachable(qboContextoAuth);
            //Adding the Attachable
            Attachable added = Helper.Add<Attachable>(qboContextoAuth, entity);

            Helper.DeleteAsync<Attachable>(qboContextoAuth, added);
        }

        #endregion


        #endregion

    }
}