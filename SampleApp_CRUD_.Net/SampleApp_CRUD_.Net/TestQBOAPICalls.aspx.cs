using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intuit.Ipp.Core;

namespace SampleApp_CRUD_DotNet
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        



            ServiceContext qboContextoAuth = QBOServiceInitializer.InitializeQBOServiceContextUsingoAuth();

            //For each request use a unique RequestId so that server diff between diff requests and does not creates duplicates
            //qboContextoAuth.RequestId = Helper.GetGuid();


            //To use minorversion which depicts latest schema used by service
            //Check docs on developer.intuit.com to use latest minorversion

            qboContextoAuth.IppConfiguration.MinorVersion.Qbo = "8";

            //To enable logging in text files 
            //qboContextoAuth.IppConfiguration.Logger.RequestLog.EnableRequestResponseLogging = true;
            //qboContextoAuth.IppConfiguration.Logger.RequestLog.ServiceRequestLoggingLocation = @"C:\IdsLogs";
            //OR
            //To check request/response logs along with url and headers, use Fiddler tool- https://www.telerik.com/download/fiddler
            //Download fiddler from google.Run it alongside your code to log raw request and response along with url and headers.
            //When you download fiddler> open it->just go to Tools->Fiddler Option->Enable(Tick Mark) Capture HTTPS connects->Enable Decrypt Https trafficThat is it.No other setting needs to be done.Dotnet localhost is by default captured in fiddler.So, after you enabled https traffic in fiddler.Just run your code.(Fiddler should be open)You will see request response getting logged in Fiddler.
            //You should 'decode the raw request body' by clicking on the yellow bar in fiddle.Then go to File menu on top->Save all session-> Save the fiddler session. A.saz file is created.Zip that.saz file and attach to this ticket


            #region DataService and QueryService tests

            #region Name list entities sample tests


            #region account tests

            #region sync tests
            AccountCRUD accountTest = new AccountCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AddBankAccountTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            accountTest.AccountUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion



#endregion

            #region budget tests

            #region sync tests
            BudgetCRUD budgetTest = new BudgetCRUD();


            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            budgetTest.BudgetQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #endregion

            #region class tests

            #region sync tests
            ClassCRUD classTest = new ClassCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            classTest.ClassUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region department tests

            #region sync tests
            DepartmentCRUD departmentTest = new DepartmentCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            departmentTest.DepartmentUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region customer tests

            #region sync tests
            CustomerCRUD customerTest = new CustomerCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            customerTest.CustomerUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region employee tests

            #region sync tests
            EmployeeCRUD employeeTest = new EmployeeCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            employeeTest.EmployeeUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion







            #endregion

            #region item tests

            #region sync tests
            ItemCRUD itemTest = new ItemCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            itemTest.ItemUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region journalCode tests for FR only

            #region sync tests
            JournalCodeCRUD journalCodeTest = new JournalCodeCRUD();


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalCodeTest.JournalCodeFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalCodeTest.JournalCodeUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalCodeTest.JournalCodeSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalCodeTest.JournalCodeBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalCodeTest.JournalCodeQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalCodeTest.JournalCodeAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalCodeTest.JournalCodeFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalCodeTest.JournalCodeUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region paymentMethod tests

            #region sync tests
            PaymentMethodCRUD paymentMethodTest = new PaymentMethodCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentMethodTest.PaymentMethodUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion
            #endregion

            #region taxAgency tests

            #region sync tests
            TaxAgencyCRUD taxAgencyTest = new TaxAgencyCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            taxAgencyTest.TaxAgencyAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            taxAgencyTest.TaxAgencyFindbyIdTestUsingoAuth(qboContextoAuth);



            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            taxAgencyTest.TaxAgencyQueryUsingoAuth(qboContextoAuth);



            #endregion


            #endregion

            #region taxRate tests

            #region sync tests
            TaxRateCRUD taxRateTest = new TaxRateCRUD();

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            taxRateTest.TaxRateQueryUsingoAuth(qboContextoAuth);



            #endregion




            #endregion

            #region taxCode tests

            #region sync tests
            TaxCodeCRUD taxCodeTest = new TaxCodeCRUD();

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            taxCodeTest.TaxCodeQueryUsingoAuth(qboContextoAuth);



            #endregion




            #endregion

            #region term tests

            #region sync tests
            TermCRUD termTest = new TermCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            termTest.TermUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion
            #endregion

            #region vendor tests

            #region sync tests
            VendorCRUD vendorTest = new VendorCRUD();

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorFindbyIdTestUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorUpdateTestUsingoAuth(qboContextoAuth);


            //Sparse Update 
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorSparseUpdateTestUsingoAuth(qboContextoAuth);

            //Change Data Capture(Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorBatchUsingoAuth(qboContextoAuth);

            //Query
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorQueryUsingoAuth(qboContextoAuth);


            //Delete is soft delete- Update with Active=false
            #endregion

            #region async tests




            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorAddAsyncTestsUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Full Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorTest.VendorUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion
            #endregion


#endregion

            #region Transaction entities sample tests

            #region bill tests

            #region sync tests

            BillCRUD billTest = new BillCRUD();

            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillUpdateTestUsingoAuth(qboContextoAuth);

            //Sparse Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillSparseUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillDeleteTestUsingoAuth(qboContextoAuth);


            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //Sparse Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillSparseUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            //FindAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            billTest.BillRetrieveAsyncTestsUsingoAuth(qboContextoAuth);
            #endregion

            #endregion

            #region billPayment tests

            #region sync tests

            BillPaymentCRUD billpaymentTest = new BillPaymentCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentCheckAddTestUsingoAuth(qboContextoAuth);
            billpaymentTest.BillPaymentCreditCardAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentDeleteTestUsingoAuth(qboContextoAuth);

            //Void
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentVoidTestUsingoAuth(qboContextoAuth);

            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            billpaymentTest.BillPaymentRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region creditMemo tests

            #region sync tests

            CreditMemoCRUD creditMemoTest = new CreditMemoCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoDeleteTestUsingoAuth(qboContextoAuth);


            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            creditMemoTest.CreditMemoRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region deposit tests

            #region sync tests

            DepositCRUD depositTest = new DepositCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositAddTestUsingoAuth(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositDeleteTestUsingoAuth(qboContextoAuth);


            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            depositTest.DepositRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region estimate tests

            #region sync tests

            EstimateCRUD estimateTest = new EstimateCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateDeleteTestUsingoAuth(qboContextoAuth);


            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateUpdatedAsyncTestsUsingoAuth(qboContextoAuth);

            //Delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateDeleteAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            estimateTest.EstimateRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region invoice tests

            #region sync tests

            InvoiceCRUD invoiceTest = new InvoiceCRUD();

            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceUpdateTestUsingoAuth(qboContextoAuth);

            //Sparse Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceSparseUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceQueryTestUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceDeleteTestUsingoAuth(qboContextoAuth);

            //Void
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceVoidTestUsingoAuth(qboContextoAuth);

            ////Linked Payment to Invoice
            #endregion

            #region async tests



            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceUpdateAsyncTestsUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            invoiceTest.InvoiceDeleteAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region journalEntry tests

            #region sync tests

            JournalEntryCRUD journalEntryTest = new JournalEntryCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryDeleteTestUsingoAuth(qboContextoAuth);

            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            journalEntryTest.JournalEntryRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region payment tests

            #region sync tests

            PaymentCRUD paymentTest = new PaymentCRUD();

            //Link Payment to Invoice. Check sample code in PaymentCRUD class

            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentAddTestUsingCheck(qboContextoAuth);
            paymentTest.PaymentAddTestUsingCreditCard(qboContextoAuth);


            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentUpdateTestUsingoAuth(qboContextoAuth);

            //Sparse Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentSparseUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentDeleteTestUsingoAuth(qboContextoAuth);

            //Void
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentVoidTestUsingoAuth(qboContextoAuth);

            ////Linked Payment to Invoice
            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentDeleteAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //Find All(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            paymentTest.PaymentRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region purchase tests

            #region sync tests

            PurchaseCRUD purchaseTest = new PurchaseCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseTest.CashPurchaseAddTestUsingoAuth(qboContextoAuth);
            purchaseTest.CreditCardPurchaseAddTestUsingoAuth(qboContextoAuth);
            purchaseTest.CheckPurchaseAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseTest.CashPurchaseFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseTest.CashPurchaseUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseTest.CashPurchaseCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseTest.PurchaseBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseTest.CashPurchaseQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseTest.CashPurchaseDeleteTestUsingoAuth(qboContextoAuth);



            #endregion



            #endregion

            #region purchaseOrder tests

            #region sync tests

            PurchaseOrderCRUD purchaseOrderTest = new PurchaseOrderCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderDeleteTestUsingoAuth(qboContextoAuth);



            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            purchaseOrderTest.PurchaseOrderRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region refundReceipt tests

            #region sync tests

            RefundReceiptCRUD refundReceiptTest = new RefundReceiptCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptDeleteTestUsingoAuth(qboContextoAuth);



            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            refundReceiptTest.RefundReceiptRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region salesReceipt tests

            #region sync tests

            SalesReceiptCRUD salesReceiptTest = new SalesReceiptCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptDeleteTestUsingoAuth(qboContextoAuth);



            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            salesReceiptTest.SalesReceiptRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region timeActivity tests

            #region sync tests

            TimeActivityCRUD timeActivityTest = new TimeActivityCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityUpdateTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityDeleteTestUsingoAuth(qboContextoAuth);



            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            timeActivityTest.TimeActivityRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region transfer tests

            #region sync tests

            TransferCRUD transferTest = new TransferCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferDeleteTestUsingoAuth(qboContextoAuth);



            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            transferTest.TransferRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region vendorCredit tests

            #region sync tests

            VendorCreditCRUD vendorCreditTest = new VendorCreditCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditDeleteTestUsingoAuth(qboContextoAuth);



            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            vendorCreditTest.VendorCreditRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion


            #endregion

            #region Supporting Entities

            #region Attachable tests


            #region sync tests

            AttachableCRUD attachableTest = new AttachableCRUD();
            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableAddTestUsingoAuth(qboContextoAuth);

            //Upload
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableUploadDownloadAddTestUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableFindbyIdTestUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableUpdateTestUsingoAuth(qboContextoAuth);


            //Change Data Capture (Consider using Webhooks instead)
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableCDCTestUsingoAuth(qboContextoAuth);

            //Batch
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableBatchUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableQueryUsingoAuth(qboContextoAuth);


            //Delete is Hard delete
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableDeleteTestUsingoAuth(qboContextoAuth);



            #endregion

            #region async tests


            //Add
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableAddAsyncTestsUsingoAuth(qboContextoAuth);

            //Find By Id
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableFindByIdAsyncTestsUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            attachableTest.AttachableRetrieveAsyncTestsUsingoAuth(qboContextoAuth);

            #endregion

            #endregion

            #region CompanyInfo tests


            #region sync tests

            CompanyInfoCRUD companyInfoTest = new CompanyInfoCRUD();

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            companyInfoTest.CompanyInfoQueryUsingoAuth(qboContextoAuth);


            #endregion




            #endregion

            #region Preferences tests

            #region sync tests

            PreferencesCRUD preferencesTest = new PreferencesCRUD();


            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            preferencesTest.PreferencesUpdateTestUsingoAuth(qboContextoAuth);


            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            preferencesTest.PreferencesQueryUsingoAuth(qboContextoAuth);






            #endregion

            #region async tests


            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            preferencesTest.PreferencesUpdatedAsyncTestsUsingoAuth(qboContextoAuth);


            //FindAll(internally uses Query)
            qboContextoAuth.RequestId = Helper.GetGuid();
            preferencesTest.PreferencesRetrieveAsyncTestsUsingoAuth(qboContextoAuth);



            #endregion


            #endregion

            #region CompanyCurrency tests


            //MultiCurrency should be enabled in Company Settings->Advanced Settings for this to work
            CompanyCurrencyCRUD companyCurrencyTest = new CompanyCurrencyCRUD();

            //Add a currency to the active currency list
            qboContextoAuth.RequestId = Helper.GetGuid();
            companyCurrencyTest.CompanyCurrencyAddTestUsingoAuth(qboContextoAuth);

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            companyCurrencyTest.CompanyCurrencyQueryUsingoAuth(qboContextoAuth);

            //Delete is Update with Active=false
            qboContextoAuth.RequestId = Helper.GetGuid();
            companyCurrencyTest.CompanyCurrencyUpdateTestUsingoAuth(qboContextoAuth);

            


            #endregion

            #region ExchangeRate tests


            #region sync tests

            ExchangeRateCRUD exchangRateTest = new ExchangeRateCRUD();

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            exchangRateTest.ExchangeRateQueryUsingoAuth(qboContextoAuth);

            //Update
            qboContextoAuth.RequestId = Helper.GetGuid();
            exchangRateTest.ExchangeRateUpdateTestUsingoAuth(qboContextoAuth);

            #endregion


            #endregion

            #endregion


            #endregion

            #region GlobalTaxService tests

            //DataService TaxCode and TaxRate entities can used only for Read/Query. 
            //Use GlobalTaxService(TaxService endpoint) for creating TaxCodes/TaxRates

            GlobalTaxServiceCRUD globalTaxServiceTest = new GlobalTaxServiceCRUD();

            //Query solves same purpose as ReadAll
            qboContextoAuth.RequestId = Helper.GetGuid();
            globalTaxServiceTest.TaxCodeAddTestUsingoAuth(qboContextoAuth);



            #endregion

            #region ReportService tests
            ReportGeneralLedgerTest reportTest = new ReportGeneralLedgerTest();
            reportTest.ReportGeneralLedgerTestUsingoAuth(qboContextoAuth);

            #endregion

            #region WebhooksService tests

            //Refer sample app for Webhooks here- https://github.com/IntuitDeveloper

            #endregion

        

    }
    }
}