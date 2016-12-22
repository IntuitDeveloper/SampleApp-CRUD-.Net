using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intuit.Ipp.Security;
using Intuit.Ipp.Core;
using System.Configuration;
using System.Net;
using System.Globalization;
using System.IO;
using Intuit.Ipp.Exception;
using Intuit.Ipp.Data;

namespace SampleApp_CRUD_DotNet
{
    public class QBOServiceInitializer
    {

        private static string accessToken = string.Empty;
        private static string accessTokenSecret = string.Empty;
        private static string consumerKey = string.Empty;
        private static string consumerSecret = string.Empty;
        private static string realmId = string.Empty;

        private static void Initialize()
        {
            //accessToken = ConfigurationManager.AppSettings["accessToken"];
            //accessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"];
            //consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            //consumerKeySecret = ConfigurationManager.AppSettings["consumerSecret"];
            //realmId = ConfigurationManager.AppSettings["realmId"];


            realmId = "123145693359857";
            accessToken = "qyprdkFQEJ8luPuwyBumFhQAdmVEEi55Zgt52Em8Wyd4i7Bu";
            accessTokenSecret = "6jBqLq5rEjNMB8Freu9L4Fk7TSOl3ifo62P8xJYb";
            consumerKey = "qyprd68jMGebyWgiNFT411r4KnhmB9";
            consumerSecret = "j2QGgFRv5yYMXB5lVXUI0NBPlHAmz0drjANG1KeX";


        }

        internal static ServiceContext InitializeQBOServiceContextUsingoAuth()
        {
            Initialize();
            OAuthRequestValidator reqValidator = new OAuthRequestValidator(accessToken, accessTokenSecret, consumerKey, consumerSecret);
            ServiceContext context = new ServiceContext(realmId, IntuitServicesType.QBO, reqValidator);

            //MinorVersion represents the latest features/fields in the xsd supported by the QBO apis.
            //Read more details here- https://developer.intuit.com/docs/0100_quickbooks_online/0200_dev_guides/accounting/querying_data

            context.IppConfiguration.MinorVersion.Qbo = "8";
            return context;
        }
    }
}
