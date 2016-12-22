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
    public class PreferencesCRUD
    {
        #region Sync Methods


        #region FindAll Operations


        public void PreferencesFindAllTestUsingoAuth(ServiceContext qboContextoAuth)
        {

            //Retrieving the Preferences using FindAll
            List<Preferences> preferences = Helper.FindAll<Preferences>(qboContextoAuth, new Preferences(), 1, 500);
           
        }

        #endregion

       

        #region  Update Operations


        public void PreferencesUpdateTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            
            List<Preferences> foundall = Helper.FindAll<Preferences>(qboContextoAuth, new Preferences());

    

            foreach (Preferences found in foundall)
            {
                Preferences changed = QBOHelper.UpdatePreferences(qboContextoAuth, found);
                //Update the returned entity data
                Preferences updated = Helper.Update<Preferences>(qboContextoAuth, changed);//Verify the updated Preferences

            }

        }

        

        #endregion
           
      

        #region  Query


        public void PreferencesQueryUsingoAuth(ServiceContext qboContextoAuth)
        {
            QueryService<Preferences> entityQuery = new QueryService<Preferences>(qboContextoAuth);
            List<Preferences> pref = entityQuery.ExecuteIdsQuery("SELECT * FROM Preferences").ToList<Preferences>();

        }

        #endregion

        #endregion


        #region ASync Methods

       

        #region FindAll Operation

      
        public void PreferencesRetrieveAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
           

            //Retrieving the Preferences using FindAll
            Helper.FindAllAsync<Preferences>(qboContextoAuth, new Preferences());
        }

        #endregion



        #region  Update Operation


        public void PreferencesUpdatedAsyncTestsUsingoAuth(ServiceContext qboContextoAuth)
        {
            
            //Change the data of added entity
            List<Preferences> foundall = Helper.FindAll<Preferences>(qboContextoAuth, new Preferences());

  

            foreach (Preferences found in foundall)
            {
                Preferences changed = QBOHelper.UpdatePreferences(qboContextoAuth, found);
                //Update the returned entity data
                Preferences updated = Helper.UpdateAsync<Preferences>(qboContextoAuth, changed);//Verify the updated Preferences
              
            }
        }

        #endregion

        

        #endregion
    }
}