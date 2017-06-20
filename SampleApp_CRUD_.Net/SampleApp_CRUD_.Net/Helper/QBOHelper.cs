using System;
using System.Collections.Generic;
using Intuit.Ipp.Core;
using Intuit.Ipp.Data;



namespace SampleApp_CRUD_DotNet
{

    public class QBOHelper
    {
        #region Create Helper Methods

        internal static TaxAgency CreateTaxAgency(ServiceContext context)
        {
            TaxAgency taxAgency = new TaxAgency();
            taxAgency.DisplayName = "Name" + Helper.GetGuid().Substring(0, 5);
            
            return taxAgency;
        }




        internal static Invoice CreateInvoice(ServiceContext context)
        {
            //US Invoice
            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            TaxCode taxCode = Helper.FindOrAdd<TaxCode>(context, new TaxCode());
            Account account = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsReceivable, AccountClassificationEnum.Liability);

            Invoice invoice = new Invoice();
            invoice.Deposit = new Decimal(0.00);
            invoice.DepositSpecified = true;
         
            
            invoice.CustomerRef = new ReferenceType()
            {
                name = customer.DisplayName,
                Value = customer.Id
            };
            
            invoice.DueDate = DateTime.UtcNow.Date;
            invoice.DueDateSpecified = true;
            

            invoice.TotalAmt = new Decimal(10.00);
            invoice.TotalAmtSpecified = true;
           
            invoice.ApplyTaxAfterDiscount = false;
            invoice.ApplyTaxAfterDiscountSpecified = true;
          
            invoice.PrintStatus = PrintStatusEnum.NotSet;
            invoice.PrintStatusSpecified = true;
            invoice.EmailStatus = EmailStatusEnum.NotSet;
            invoice.EmailStatusSpecified = true;

            EmailAddress billEmail = new EmailAddress();
            billEmail.Address = @"abc@gmail.com";
            billEmail.Default = true;
            billEmail.DefaultSpecified = true;
            billEmail.Tag = "Tag";
            invoice.BillEmail = billEmail;

            EmailAddress billEmailcc = new EmailAddress();
            billEmailcc.Address = @"def@gmail.com";
            billEmailcc.Default = true;
            billEmailcc.DefaultSpecified = true;
            billEmailcc.Tag = "Tag";
            invoice.BillEmailCc = billEmailcc;

            EmailAddress billEmailbcc = new EmailAddress();
            billEmailbcc.Address = @"xyz@gmail.com";
            billEmailbcc.Default = true;
            billEmailbcc.DefaultSpecified = true;
            billEmailbcc.Tag = "Tag";
            invoice.BillEmailBcc = billEmailbcc;


            invoice.Balance = new Decimal(10.00);
            invoice.BalanceSpecified = true;
            
            invoice.TxnDate = DateTime.UtcNow.Date;
            invoice.TxnDateSpecified = true;
            

            List<Line> lineList = new List<Line>();
            Line line = new Line();
            //line.LineNum = "LineNum";
            line.Description = "Description";
            line.Amount = new Decimal(100.00);
            line.AmountSpecified = true;

            
            line.DetailType = LineDetailTypeEnum.DescriptionOnly;
            line.DetailTypeSpecified = true;
            

            lineList.Add(line);
            invoice.Line = lineList.ToArray();
            invoice.TxnTaxDetail = new TxnTaxDetail()
            {
                TotalTax = Convert.ToDecimal(10),
                TotalTaxSpecified = true
            };



            
            return invoice;



            //Global invoice

            //Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            //TaxCode taxCode = Helper.FindOrAdd<TaxCode>(context, new TaxCode());
            //Account account = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsReceivable, AccountClassificationEnum.Liability);
            //Item item = Helper.FindOrAddItem(context, ItemTypeEnum.Service);

            //Invoice invoice = new Invoice();
   
            //invoice.AutoDocNumber = true;
            //invoice.AutoDocNumberSpecified = true;

            //invoice.CustomerRef = new ReferenceType()
            //{
            //    name = customer.DisplayName,
            //    Value = customer.Id
            //};

            //invoice.DueDate = DateTime.UtcNow.Date;
            //invoice.DueDateSpecified = true;

            //invoice.TotalAmt = Convert.ToDecimal(20);
            //invoice.TotalAmtSpecified = true;

            //invoice.ApplyTaxAfterDiscount = false;
            //invoice.ApplyTaxAfterDiscountSpecified = true;

            //invoice.PrintStatus = PrintStatusEnum.NotSet;
            //invoice.PrintStatusSpecified = true;
            //invoice.EmailStatus = EmailStatusEnum.NotSet;
            //invoice.EmailStatusSpecified = true;

            //EmailAddress billEmail = new EmailAddress();
            //billEmail.Address = @"abc@gmail.com";
            //billEmail.Default = true;
            //billEmail.DefaultSpecified = true;
            //billEmail.Tag = "Tag";
            //invoice.BillEmail = billEmail;

            //EmailAddress billEmailcc = new EmailAddress();
            //billEmailcc.Address = @"def@gmail.com";
            //billEmailcc.Default = true;
            //billEmailcc.DefaultSpecified = true;
            //billEmailcc.Tag = "Tag";
            //invoice.BillEmailCc = billEmailcc;

            //EmailAddress billEmailbcc = new EmailAddress();
            //billEmailbcc.Address = @"xyz@gmail.com";
            //billEmailbcc.Default = true;
            //billEmailbcc.DefaultSpecified = true;
            //billEmailbcc.Tag = "Tag";
            //invoice.BillEmailBcc = billEmailbcc;

  
            //invoice.Balance = Convert.ToDecimal(20);
            //invoice.BalanceSpecified = true;
            //invoice.TxnDate = DateTime.UtcNow.Date;
            //invoice.TxnDateSpecified = true;

            //invoice.CurrencyRef = new ReferenceType()
            //{
            //    Value = "GBP" //Currency of txn should be same as Customer's currency
            //};
            //invoice.ExchangeRate = 0.798467m;
            //invoice.ExchangeRateSpecified = true;







            //List<Line> lineList = new List<Line>();
            //Line line = new Line();
            //line.Id = "1";
            //line.LineNum = "1";
            //line.Description = "Priced Product";
            //line.Amount = Convert.ToDecimal(10);
            //line.AmountSpecified = true;
            //line.DetailType = LineDetailTypeEnum.SalesItemLineDetail;
            //line.DetailTypeSpecified = true;



         
            //line.AnyIntuitObject = new SalesItemLineDetail()
            //{
            //    Qty = 1,
            //    QtySpecified = true,

            //    AnyIntuitObject = Convert.ToDecimal(10),
            //    ItemElementName = ItemChoiceType.UnitPrice,

            //    ItemRef = new ReferenceType()
            //    {
            //        name = item.Name,
            //        Value = item.Id
            //    },
            //    TaxCodeRef = new ReferenceType()
            //    {
            //        name = taxCode.Name,
            //        Value = taxCode.Id //US has TAX or NON. Global needs actual TaxCode Id
            //    }
            //};

      

            //lineList.Add(line);
            //invoice.Line = lineList.ToArray();

            //invoice.TxnTaxDetail = new TxnTaxDetail()
            //{
            //    TotalTax = Convert.ToDecimal(10),
            //    TotalTaxSpecified = true
            //};


            //invoice.GlobalTaxCalculation = GlobalTaxCalculationEnum.TaxExcluded;
            //invoice.GlobalTaxCalculationSpecified = true;

            

            //return invoice;
        }



        internal static Invoice UpdateInvoice(ServiceContext context, Invoice entity)
        {
            //update the properties of entity
            entity.DocNumber = "updated" + Helper.GetGuid().Substring(0, 3);

            return entity;
        }


        internal static Invoice SparseUpdateInvoice(ServiceContext context, string Id, string syncToken)
        {
            Invoice entity = new Invoice();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.DocNumber = "sparseupdated" + Helper.GetGuid().Substring(0, 3);
            return entity;
        }



        internal static SalesReceipt CreateSalesReceipt(ServiceContext context)
        {
            SalesReceipt salesReceipt = new SalesReceipt();
            
            salesReceipt.TotalAmt = new Decimal(100.00);
            salesReceipt.TotalAmtSpecified = true;
            
            salesReceipt.ApplyTaxAfterDiscount = false;
            salesReceipt.ApplyTaxAfterDiscountSpecified = true;
            
            salesReceipt.PrintStatus = PrintStatusEnum.NeedToPrint;
            salesReceipt.PrintStatusSpecified = true;
            salesReceipt.EmailStatus = EmailStatusEnum.NotSet;
            salesReceipt.EmailStatusSpecified = true;
            
            salesReceipt.Balance = new Decimal(0.00);
            salesReceipt.BalanceSpecified = true;
            
            Account account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Liability);
            salesReceipt.DepositToAccountRef = new ReferenceType()
            {
                name = account.Name,
                Value = account.Id
            };
            salesReceipt.DocNumber = "1003";
            salesReceipt.TxnDate = DateTime.UtcNow.Date;
            salesReceipt.TxnDateSpecified = true;
            

            List<Line> lineList = new List<Line>();
            Line line = new Line();
            line.LineNum = "1";
            line.Description = "Description";
            line.Amount = new Decimal(100.00);
            line.AmountSpecified = true;

            
            line.DetailType = LineDetailTypeEnum.SalesItemLineDetail;
            line.DetailTypeSpecified = true;
            Item item = Helper.FindOrAdd<Item>(context, new Item());
            TaxCode findOrAddResult = Helper.FindOrAdd<TaxCode>(context, new TaxCode());
            TaxCode taxCode = Helper.FindAll<TaxCode>(context, new TaxCode())[0];
            line.AnyIntuitObject = new SalesItemLineDetail()
            {
                Qty = 1,
                QtySpecified = true,

                ItemRef = new ReferenceType()
                {
                    name = item.Name,
                    Value = item.Id
                },
                TaxCodeRef = new ReferenceType()
                {
                    name = taxCode.Name,
                    Value = taxCode.Id
                }
            };

            
            lineList.Add(line);
            salesReceipt.Line = lineList.ToArray();
            
            return salesReceipt;
        }



        internal static SalesReceipt UpdateSalesReceipt(ServiceContext context, SalesReceipt entity)
        {
            entity.PrintStatus = PrintStatusEnum.NeedToPrint;
            entity.PrintStatusSpecified = true;
            entity.EmailStatus = EmailStatusEnum.NeedToSend;
            entity.EmailStatusSpecified = true;
            entity.BillEmail = new EmailAddress() { Address = "address@email.com" };
            return entity;
        }


        internal static SalesReceipt SparseUpdateSalesReceipt(ServiceContext context, string Id, string syncToken)
        {
            SalesReceipt entity = new SalesReceipt();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.PrintStatus = PrintStatusEnum.PrintComplete;
            entity.PrintStatusSpecified = true;
            return entity;
        }



        internal static Estimate CreateEstimate(ServiceContext context)
        {
            Estimate estimate = new Estimate();
            estimate.ExpirationDate = DateTime.UtcNow.Date.AddDays(15);
            estimate.ExpirationDateSpecified = true;
            estimate.TxnDate = DateTime.UtcNow.Date;
            estimate.TxnDateSpecified = true;
            
            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            estimate.CustomerRef = new ReferenceType()
            {
                name = customer.DisplayName,
                Value = customer.Id
            };
            
            estimate.TotalAmt = new Decimal(100.00);
            estimate.TotalAmtSpecified = true;
            
            Account depositAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            estimate.DepositToAccountRef = new ReferenceType()
            {
                name = depositAccount.Name,
                Value = depositAccount.Id
            };
            
            Item item = Helper.FindOrAdd<Item>(context, new Item());

            estimate.TotalAmt = new Decimal(100.00);
            TaxCode findOrAddResult = Helper.FindOrAdd<TaxCode>(context, new TaxCode());
            TaxCode taxcode = Helper.FindAll<TaxCode>(context, new TaxCode())[0];
            if (taxcode.SalesTaxRateList != null)
            {
                TaxRate taxRateToFind = new TaxRate();
                taxRateToFind.Id = taxcode.SalesTaxRateList.TaxRateDetail[0].TaxRateRef.Value;
                TaxRate taxRate = Helper.FindById<TaxRate>(context, taxRateToFind);
                estimate.TotalAmt += estimate.TotalAmt * (taxRate.RateValue / 100);
            }
            estimate.TotalAmtSpecified = true;

            List<Line> lineList = new List<Line>();
            Line line = new Line();
            line.LineNum = "1";
            line.Description = "Description";
            line.Amount = new Decimal(100.00);
            line.AmountSpecified = true;

            
            line.DetailType = LineDetailTypeEnum.SalesItemLineDetail;
            line.DetailTypeSpecified = true;
            line.AnyIntuitObject = new SalesItemLineDetail()
            {
                ItemRef = new ReferenceType() { name = item.Name, Value = item.Id },
                TaxCodeRef = new ReferenceType() { name = taxcode.Name, Value = taxcode.Id }
            };
            lineList.Add(line);
            estimate.Line = lineList.ToArray();

            return estimate;
        }



        internal static Estimate UpdateEstimate(ServiceContext context, Estimate entity)
        {
            //update the properties of entity
            entity.ExpirationDate = DateTime.UtcNow.Date.AddDays(15);
            entity.ExpirationDateSpecified = true;
            entity.TxnDate = DateTime.UtcNow.Date;
            entity.TxnDateSpecified = true;
            return entity;
        }


        internal static ExchangeRate UpdateExchangeRate(ServiceContext context, ExchangeRate entity)
        {
            //update the ExchangeRate
            //TargetCurrencyCode defaults to Home Currency if not supplied.
            //Setting exchange rate to anything other than 1 for a case where SourceCurrencyCode = TargetCurrencyCode results in the exchange rate set to 1.
            //Setting an exchange rate for the home currency, that is, where SourceCurrencyCode is set to the home currency results in a validation error.
            entity.SourceCurrencyCode = "INR";
            entity.TargetCurrencyCode = "USD";
            entity.Rate = 4;
            entity.RateSpecified = true;
            entity.AsOfDate = new DateTime(2015, 08, 14);
            entity.AsOfDateSpecified = true;

            return entity;
        }


        internal static CompanyCurrency UpdateCompanyCurrency(ServiceContext context, CompanyCurrency entity)
        {
            entity.Active = false;      

            return entity;
        }


        internal static Estimate SparseUpdateEstimate(ServiceContext context, string Id, string syncToken)
        {
            Estimate entity = new Estimate();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.ExpirationDate = DateTime.UtcNow.Date.AddDays(15);
            entity.ExpirationDateSpecified = true;
            entity.TxnDate = DateTime.UtcNow.Date;
            entity.TxnDateSpecified = true;
            return entity;
        }

        


        internal static Account CreateAccount(ServiceContext context, AccountTypeEnum accountType, AccountClassificationEnum classification)
        {
            Account account = new Account();

            String guid = Helper.GetGuid();
            account.Name = "Name_" + guid;
            
            account.FullyQualifiedName = account.Name;
            
            account.Classification = classification;
            account.ClassificationSpecified = true;
            account.AccountType = accountType;
            account.AccountTypeSpecified = true;
            
            if (accountType != AccountTypeEnum.Expense && accountType != AccountTypeEnum.AccountsPayable && accountType != AccountTypeEnum.AccountsReceivable)
            {
                
            }
            
            account.CurrencyRef = new ReferenceType()
            {
                name = "United States Dollar",
                Value = "USD"
            };
            
            return account;
        }

        


        internal static Account UpdateAccount(ServiceContext context, Account entity)
        {
            //update the properties of entity
            entity.Name = "Name_" + Helper.GetGuid().Substring(0, 5);
            entity.FullyQualifiedName = entity.Name;
            return entity;
        }


        internal static Account SparseUpdateAccount(ServiceContext context, string Id, string syncToken)
        {
            Account entity = new Account();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Name = "Update Name_" + Helper.GetGuid().Substring(0, 5);
            entity.FullyQualifiedName = entity.Name;
            return entity;
        }



        internal static Purchase CreatePurchase(ServiceContext context, PaymentTypeEnum paymentType)
        {
            Purchase purchase = new Purchase();

            Account account = null;

            switch (paymentType)
            {
                case PaymentTypeEnum.Cash:
                    account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Expense);
                    break;
                case PaymentTypeEnum.Check:
                    account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Expense);
                    break;
                case PaymentTypeEnum.CreditCard:
                    account = Helper.FindOrAddAccount(context, AccountTypeEnum.CreditCard, AccountClassificationEnum.Expense);
                    break;
                case PaymentTypeEnum.Other:
                    break;
                default:
                    break;
            }

            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());

            purchase.AccountRef = new ReferenceType()
            {
                
                name = account.Name,
                Value = account.Id
            };
            
            purchase.PaymentType = paymentType;
            purchase.PaymentTypeSpecified = true;
            
            purchase.EntityRef = new ReferenceType()
            {
                name = customer.DisplayName,
                type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Customer),
                Value = customer.Id
            };
            if (paymentType == PaymentTypeEnum.CreditCard || paymentType == PaymentTypeEnum.Cash)
            {
                purchase.Credit = false;
                purchase.CreditSpecified = true;
            }
            
            purchase.TotalAmt = new Decimal(1000.00);
            purchase.TotalAmtSpecified = true;
           
            if (paymentType != PaymentTypeEnum.CreditCard)
            {
                purchase.PrintStatus = PrintStatusEnum.NotSet;
                purchase.PrintStatusSpecified = true;
            }
            

            
            purchase.TxnDate = DateTime.UtcNow.Date;
            purchase.TxnDateSpecified = true;
            

            List<Line> lineList = new List<Line>();
            Line line = new Line();
            //line.LineNum = "LineNum";
            line.Description = "Description for Line";
            line.Amount = new Decimal(1000.00);
            line.AmountSpecified = true;

            
            line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail;
            line.DetailTypeSpecified = true;
            AccountBasedExpenseLineDetail lineDetail = new AccountBasedExpenseLineDetail();
            Account lineAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense);
            lineDetail.AccountRef = new ReferenceType { type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Account), name = lineAccount.Name, Value = lineAccount.Id };
            lineDetail.BillableStatus = BillableStatusEnum.NotBillable;
            lineDetail.TaxAmount = new Decimal(10.00);
            lineDetail.TaxAmountSpecified = true;
            line.AnyIntuitObject = lineDetail;

            
 
            lineList.Add(line);
            purchase.Line = lineList.ToArray();
            
            return purchase;
        }



        internal static Purchase UpdatePurchase(ServiceContext context, Purchase entity)
        {
            //update the properties of entity
            Line[] line = entity.Line;
            line[0].Amount = new Decimal(1001.00);

            entity.TotalAmt = new Decimal(1001.00);
            return entity;
        }


        internal static Purchase SparseUpdatePurchase(ServiceContext context, string Id, PaymentTypeEnum paymentType, string syncToken)
        {
            Purchase entity = new Purchase();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.PaymentType = paymentType;
            entity.PaymentTypeSpecified = true;

            List<Line> lineList = new List<Line>();
            Line line = new Line();
            line.Description = "Sparse Update Desc";
            line.Amount = new Decimal(1002.00);
            line.AmountSpecified = true;

            line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail;
            line.DetailTypeSpecified = true;

            AccountBasedExpenseLineDetail lineDetail = new AccountBasedExpenseLineDetail();
            Account lineAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense);
            lineDetail.AccountRef = new ReferenceType { type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Account), name = lineAccount.Name, Value = lineAccount.Id };
            lineDetail.BillableStatus = BillableStatusEnum.NotBillable;
            lineDetail.TaxAmount = new Decimal(10.00);
            lineDetail.TaxAmountSpecified = true;
            line.AnyIntuitObject = lineDetail;

            lineList.Add(line);
            entity.Line = lineList.ToArray();

            entity.TotalAmt = new Decimal(1002.00);
            entity.TotalAmtSpecified = true;
            return entity;
        }



        


        internal static Bill CreateBill(ServiceContext context)
        {

            Vendor vendors = Helper.FindOrAdd<Vendor>(context, new Vendor());
            Account account = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsPayable, AccountClassificationEnum.Liability);
            Account accountExpense = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense);
            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());

            Bill bill = new Bill();
            
            bill.DueDate = DateTime.UtcNow.Date;
            bill.DueDateSpecified = true;
            
            bill.VendorRef = new ReferenceType()
            {
                
                name = vendors.DisplayName,
                Value = vendors.Id
            };
            bill.APAccountRef = new ReferenceType()
            {
                
                name = account.Name,
                Value = account.Id
            };
            bill.TotalAmt = new Decimal(100.00);
            bill.TotalAmtSpecified = true;
            bill.Balance = new Decimal(100.00);
            bill.BalanceSpecified = true;
            
            bill.TxnDate = DateTime.UtcNow.Date;
            bill.TxnDateSpecified = true;
            

            List<Line> lineList = new List<Line>();
            Line line = new Line();
            //line.LineNum = "LineNum";
            line.Description = "Description";
            line.Amount = new Decimal(100.00);
            line.AmountSpecified = true;

            
            line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail;
            line.DetailTypeSpecified = true;

            AccountBasedExpenseLineDetail detail = new AccountBasedExpenseLineDetail();
            detail.CustomerRef = new ReferenceType { type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Customer), name = customer.DisplayName, Value = customer.Id };
            detail.AccountRef = new ReferenceType { type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Account), name = accountExpense.Name, Value = accountExpense.Id };
            detail.BillableStatus = BillableStatusEnum.NotBillable;

            line.AnyIntuitObject = detail;

            
            lineList.Add(line);
            bill.Line = lineList.ToArray();
            
            return bill;
        }



        internal static Bill UpdateBill(ServiceContext context, Bill entity)
        {
            //update the properties of entity
            entity.DocNumber = "docNo" + Helper.GetGuid().Substring(0, 5);
            return entity;
        }

        internal static Bill UpdateBillSparse(ServiceContext context, string Id, string SyncToken)
        {
            //update the properties of entity
            Bill entity = new Bill();
            entity.Id = Id;
            entity.SyncToken = SyncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.DocNumber = "docNo" + Helper.GetGuid().Substring(0, 5);

            Vendor vendors = Helper.FindOrAdd<Vendor>(context, new Vendor());
            entity.VendorRef = new ReferenceType()
            {
                name = vendors.DisplayName,
                Value = vendors.Id
            };
            return entity;
        }



        internal static VendorCredit CreateVendorCredit(ServiceContext context)
        {
            VendorCredit vendorCredit = new VendorCredit();
            
            Vendor vendor = Helper.FindOrAdd<Vendor>(context, new Vendor());
            vendorCredit.VendorRef = new ReferenceType()
            {
                name = vendor.DisplayName,
                Value = vendor.Id
            };
            Account liabilityAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsPayable, AccountClassificationEnum.Asset);
            vendorCredit.APAccountRef = new ReferenceType()
            {
                name = liabilityAccount.Name,
                Value = liabilityAccount.Id
            };

            vendorCredit.TotalAmt = new Decimal(50.00);
            vendorCredit.TotalAmtSpecified = true;
            
            vendorCredit.TxnDate = DateTime.UtcNow.Date;
            vendorCredit.TxnDateSpecified = true;
            

            List<Line> lineList = new List<Line>();
            Line line = new Line();
            
            line.Description = "Description";
            line.Amount = new Decimal(50.00);
            line.AmountSpecified = true;

            
            line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail;
            line.DetailTypeSpecified = true;


            
            Account expenseAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense);
            line.AnyIntuitObject = new AccountBasedExpenseLineDetail()
            {
                AccountRef = new ReferenceType() { name = expenseAccount.Name, Value = expenseAccount.Id }
            };

            
            lineList.Add(line);
            vendorCredit.Line = lineList.ToArray();
            
            return vendorCredit;
        }



        internal static VendorCredit UpdateVendorCredit(ServiceContext context, VendorCredit entity)
        {
            //update the properties of entity
            entity.TxnDate = DateTime.UtcNow.Date.AddDays(2);
            entity.TxnDateSpecified = true;
            entity.PrivateNote = "UpdatedPrivateNote";
            return entity;
        }

        internal static VendorCredit UpdateVendorCreditSparse(ServiceContext context, string id, string syncToken, ReferenceType vendorRef)
        {
            VendorCredit entity = new VendorCredit();
            entity.Id = id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.TxnDate = DateTime.UtcNow.Date.AddDays(2);
            entity.TxnDateSpecified = true;
            entity.PrivateNote = "UpdatedPrivateNote";
            entity.VendorRef = vendorRef; //Required for sparse update
            return entity;
        }

        

        internal static Class CreateClass(ServiceContext context)
        {
            Class class1 = new Class();
            class1.Name = "ClassName" + Helper.GetGuid().Substring(0, 20);
            class1.SubClass = true;
            class1.SubClassSpecified = true;
            
            class1.FullyQualifiedName = class1.Name;
            class1.Active = true;
            class1.ActiveSpecified = true;
           
            return class1;
        }



        internal static Class UpdateClass(ServiceContext context, Class entity)
        {
            entity.Name = "UpdatedName" + Helper.GetGuid().Substring(0, 16);
            entity.FullyQualifiedName = entity.Name;
            return entity;
        }


        internal static Class SparseUpdateClass(ServiceContext context, string Id, string syncToken)
        {
            Class entity = new Class();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Name = "UpdatedName" + Helper.GetGuid().Substring(0, 16);
            entity.FullyQualifiedName = entity.Name;
            return entity;
        }

        internal static Payment CreatePaymentCheck(ServiceContext context)
        {
            Payment payment = new Payment();
            payment.TxnDate = DateTime.UtcNow.Date;
            payment.TxnDateSpecified = true;
            Account depositAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            payment.DepositToAccountRef = new ReferenceType()
            {
                name = depositAccount.Name,
                Value = depositAccount.Id
            };
            PaymentMethod paymentMethod = Helper.FindOrAdd<PaymentMethod>(context, new PaymentMethod());
            payment.PaymentMethodRef = new ReferenceType()
            {
                name = paymentMethod.Name,
                Value = paymentMethod.Id
            };
            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            payment.CustomerRef = new ReferenceType()
            {
                name = customer.DisplayName,
                Value = customer.Id
            };

            payment.PaymentType = PaymentTypeEnum.Check;
            CheckPayment checkPayment = new CheckPayment();
            checkPayment.AcctNum = "Acctnum" + Helper.GetGuid().Substring(0, 5);
            checkPayment.BankName = "BankName" + Helper.GetGuid().Substring(0, 5);
            checkPayment.CheckNum = "CheckNum" + Helper.GetGuid().Substring(0, 5);
            checkPayment.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5);
            checkPayment.Status = "Status" + Helper.GetGuid().Substring(0, 5);
            payment.AnyIntuitObject = checkPayment;

            payment.TotalAmt = new Decimal(100.00);
            payment.TotalAmtSpecified = true;
            payment.UnappliedAmt = new Decimal(100.00);
            payment.UnappliedAmtSpecified = true;
            return payment;
        }

        internal static Payment CreatePaymentCreditCard(ServiceContext context)
        {
            Payment payment = new Payment();
            payment.TxnDate = DateTime.UtcNow.Date;
            payment.TxnDateSpecified = true;
            Account depositAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            payment.DepositToAccountRef = new ReferenceType()
            {
                name = depositAccount.Name,
                Value = depositAccount.Id
            };
            PaymentMethod paymentMethod = Helper.FindOrAdd<PaymentMethod>(context, new PaymentMethod());
            payment.PaymentMethodRef = new ReferenceType()
            {
                name = paymentMethod.Name,
                Value = paymentMethod.Id
            };
            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            payment.CustomerRef = new ReferenceType()
            {
                name = customer.DisplayName,
                Value = customer.Id
            };

            payment.PaymentType = PaymentTypeEnum.CreditCard;

            CreditCardPayment creditCardPayment = new CreditCardPayment();
            CreditChargeInfo creditChargeInfo = new CreditChargeInfo();
            creditChargeInfo.BillAddrStreet = "BillAddrStreet" + Helper.GetGuid().Substring(0, 5);
            creditChargeInfo.CcExpiryMonth = 10;
            creditChargeInfo.CcExpiryMonthSpecified = true;
            creditChargeInfo.CcExpiryYear = DateTime.Today.Year;
            creditChargeInfo.CcExpiryYearSpecified = true;
            creditChargeInfo.CCTxnMode = CCTxnModeEnum.CardNotPresent;
            creditChargeInfo.CCTxnModeSpecified = true;
            creditChargeInfo.CCTxnType = CCTxnTypeEnum.Charge;
            creditChargeInfo.CCTxnTypeSpecified = true;
            creditChargeInfo.CommercialCardCode = "Cardcode" + Helper.GetGuid().Substring(0, 5);
            creditChargeInfo.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5);
            creditChargeInfo.Number = Helper.GetGuid().Substring(0, 5);
            creditChargeInfo.PostalCode = Helper.GetGuid().Substring(0, 5);
            creditCardPayment.CreditChargeInfo = creditChargeInfo;

            payment.AnyIntuitObject = creditCardPayment;
            payment.TotalAmt = new Decimal(100.00);
            payment.TotalAmtSpecified = true;
            payment.UnappliedAmt = new Decimal(100.00);
            payment.UnappliedAmtSpecified = true;
            return payment;
        }

        internal static Payment CreatePayment(ServiceContext context)
        {
            Payment payment = new Payment();
            payment.TxnDate = DateTime.UtcNow.Date;
            payment.TxnDateSpecified = true;

            Account ARAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.AccountsReceivable, AccountClassificationEnum.Asset);
            payment.ARAccountRef = new ReferenceType()
            {
                name = ARAccount.Name,
                Value = ARAccount.Id
            };

            Account depositAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            payment.DepositToAccountRef = new ReferenceType()
            {
                name = depositAccount.Name,
                Value = depositAccount.Id
            };
            PaymentMethod paymentMethod = Helper.FindOrAdd<PaymentMethod>(context, new PaymentMethod());
            payment.PaymentMethodRef = new ReferenceType()
            {
                name = paymentMethod.Name,
                Value = paymentMethod.Id
            };
            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            payment.CustomerRef = new ReferenceType()
            {
                name = customer.DisplayName,
                Value = customer.Id
            };

            payment.PaymentType = PaymentTypeEnum.Check;
            CheckPayment checkPayment = new CheckPayment();
            checkPayment.AcctNum = "Acctnum" + Helper.GetGuid().Substring(0, 5);
            checkPayment.BankName = "BankName" + Helper.GetGuid().Substring(0, 5);
            checkPayment.CheckNum = "CheckNum" + Helper.GetGuid().Substring(0, 5);
            checkPayment.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5);
            checkPayment.Status = "Status" + Helper.GetGuid().Substring(0, 5);
            checkPayment.CheckPaymentEx = new IntuitAnyType();
            payment.AnyIntuitObject = checkPayment;

            payment.TotalAmt = new Decimal(100.00);
            payment.TotalAmtSpecified = true;
            payment.UnappliedAmt = new Decimal(100.00);
            payment.UnappliedAmtSpecified = true;
            return payment;
        }



        internal static Payment UpdatePayment(ServiceContext context, Payment entity)
        {
            //update the properties of entity
            entity.TxnDate = DateTime.UtcNow.Date.AddDays(10);
            entity.TxnDateSpecified = true;
            return entity;
        }

        internal static Payment SparseUpdatePayment(ServiceContext context, string Id, string syncToken)
        {
            Payment entity = new Payment();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.PrivateNote = "updated Private Note";
            return entity;
        }


        internal static PaymentMethod CreatePaymentMethod(ServiceContext context)
        {
            PaymentMethod paymentMethod = new PaymentMethod();
            paymentMethod.Name = "CreditCard" + Helper.GetGuid().Substring(0, 13);
            paymentMethod.Active = true;
            paymentMethod.ActiveSpecified = true;
            paymentMethod.Type = "CREDIT_CARD"; //Need to be replaced by PaymentTypeEnum
           
            return paymentMethod;
        }



        internal static PaymentMethod UpdatePaymentMethod(ServiceContext context, PaymentMethod entity)
        {
            entity.Name = "Cash" + Helper.GetGuid().Substring(0, 13);
            entity.Type = "NON_CREDIT_CARD";
            return entity;
        }



        internal static PaymentMethod SparseUpdatePaymentMethod(ServiceContext context, string Id, string syncToken)
        {
            PaymentMethod entity = new PaymentMethod();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Name = "Sparse Cash" + Helper.GetGuid().Substring(0, 13);
            entity.Type = "NON_CREDIT_CARD";
            return entity;
        }



        internal static Department CreateDepartment(ServiceContext context)
        {
            Department department = new Department();
            department.Name = "DeptName" + Helper.GetGuid().Substring(0, 13);
            department.SubDepartment = true;
            department.SubDepartmentSpecified = true;
            
            department.FullyQualifiedName = department.Name;
            department.Active = true;
            department.ActiveSpecified = true;
          
            return department;
        }



        internal static Department UpdateDepartment(ServiceContext context, Department entity)
        {
            entity.Name = "DeptName" + Helper.GetGuid().Substring(0, 13);
            entity.FullyQualifiedName = entity.Name;
            return entity;
        }


        internal static Department UpdateDepartmentSparse(ServiceContext context, string Id, string SyncToken)
        {
            Department entity = new Department();
            entity.Id = Id;
            entity.SyncToken = SyncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Name = "DeptName" + Helper.GetGuid().Substring(0, 13);
            entity.FullyQualifiedName = entity.Name;
            return entity;
        }


        internal static Item CreateItem(ServiceContext context)
        {

            Item item = new Item();


            item.Name = "Name" + Helper.GetGuid().Substring(0, 5); ;
            item.Description = "Description";
            item.Type = ItemTypeEnum.NonInventory;
            item.TypeSpecified = true;

            item.Active = true;
            item.ActiveSpecified = true;

            
            item.Taxable = false;
            item.TaxableSpecified = true;
            
            item.UnitPrice = new Decimal(100.00);
            item.UnitPriceSpecified = true;
            
            Account incomeAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Income, AccountClassificationEnum.Revenue);
            item.IncomeAccountRef = new ReferenceType()
            {
                name = incomeAccount.Name,
                Value = incomeAccount.Id
            };
            
            item.PurchaseCost = new Decimal(100.00);
            item.PurchaseCostSpecified = true;
            Account expenseAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense);
            item.ExpenseAccountRef = new ReferenceType()
            {
                name = expenseAccount.Name,
                Value = expenseAccount.Id
            };
           
            item.TrackQtyOnHand = false;
            item.TrackQtyOnHandSpecified = true;
            

            return item;

        }

        

        internal static Item UpdateItem(ServiceContext context, Item entity)
        {
            //update the properties of entity
            entity.Name = "updatedName" + Helper.GetGuid().Substring(0, 5);
            entity.Description = "updatedDescription";
            return entity;
        }


       


        internal static Item SparseUpdateItem(ServiceContext context, string Id, string syncToken)
        {
            Item entity = new Item();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Name = "sparseupdatedName" + Helper.GetGuid().Substring(0, 5);
            entity.Description = "sparseupdatedDescription";
            return entity;
        }


        internal static Term CreateTerm(ServiceContext context)
        {
            Term term = new Term();
            term.Name = "Name" + Helper.GetGuid().Substring(0, 15);
            term.Active = true;
            term.ActiveSpecified = true;
            term.Type = "STANDARD";
            term.DiscountPercent = new Decimal(50.00);
            term.DiscountPercentSpecified = true;
            term.AnyIntuitObjects = new Object[] { 10 };
            term.ItemsElementName = new ItemsChoiceType[] { ItemsChoiceType.DueDays };
            return term;
        }


        internal static Term UpdateTerm(ServiceContext context, Term entity)
        {
            entity.Name = "UpdateName" + Helper.GetGuid().Substring(0, 15);
            entity.Active = true;
            entity.ActiveSpecified = true;
            return entity;
        }


        internal static Term SparseUpdateTerm(ServiceContext context, string Id, string syncToken)
        {
            Term entity = new Term();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Name = "SparseUpdateName" + Helper.GetGuid().Substring(0, 15);
            entity.Active = true;
            entity.ActiveSpecified = true;
            return entity;
        }


        internal static BillPayment CreateBillPaymentCheck(ServiceContext context)
        {
            BillPayment billPayment = new BillPayment();
            VendorCredit vendorCredit = Helper.Add(context, QBOHelper.CreateVendorCredit(context));
            billPayment.PayType = BillPaymentTypeEnum.Check;
            billPayment.PayTypeSpecified = true;
            
            billPayment.TotalAmt = vendorCredit.TotalAmt;
            billPayment.TotalAmtSpecified = true;
          
            billPayment.TxnDate = DateTime.UtcNow.Date;
            billPayment.TxnDateSpecified = true;
           
            billPayment.PrivateNote = "PrivateNote";
            

            Vendor vendor = Helper.FindOrAdd<Vendor>(context, new Vendor());
            billPayment.VendorRef = new ReferenceType()
            {
                name = vendor.DisplayName,
                type = "Vendor",
                Value = vendor.Id
            };

            Account bankAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            BillPaymentCheck billPaymentCheck = new BillPaymentCheck();
            billPaymentCheck.BankAccountRef = new ReferenceType()
            {
                name = bankAccount.Name,
                Value = bankAccount.Id
            };

            CheckPayment checkPayment = new CheckPayment();
            checkPayment.AcctNum = "AcctNum" + Helper.GetGuid().Substring(0, 5);
            checkPayment.BankName = "BankName" + Helper.GetGuid().Substring(0, 5);
            checkPayment.CheckNum = "CheckNum" + Helper.GetGuid().Substring(0, 5);
            checkPayment.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5);
            checkPayment.Status = "Status" + Helper.GetGuid().Substring(0, 5);
            billPaymentCheck.CheckDetail = checkPayment;

            PhysicalAddress payeeAddr = new PhysicalAddress();
            payeeAddr.Line1 = "Line 1";
            payeeAddr.Line2 = "Line 2";
            payeeAddr.City = "Mountain View";
            payeeAddr.CountrySubDivisionCode = "CA";
            payeeAddr.PostalCode = "94043";
            billPaymentCheck.PayeeAddr = payeeAddr;
            billPaymentCheck.PrintStatus = PrintStatusEnum.NeedToPrint;
            billPaymentCheck.PrintStatusSpecified = true;
            billPayment.AnyIntuitObject = billPaymentCheck;

            List<Line> lineList = new List<Line>();

            Line line1 = new Line();
            

            Bill bill = Helper.Add<Bill>(context, QBOHelper.CreateBill(context));
            line1.Amount = bill.TotalAmt;
            line1.AmountSpecified = true;
            List<LinkedTxn> LinkedTxnList1 = new List<LinkedTxn>();
            LinkedTxn linkedTxn1 = new LinkedTxn();
            linkedTxn1.TxnId = bill.Id;
            linkedTxn1.TxnType = TxnTypeEnum.Bill.ToString();
            LinkedTxnList1.Add(linkedTxn1);
            line1.LinkedTxn = LinkedTxnList1.ToArray();

            lineList.Add(line1);

            Line line = new Line();
           

            line.Amount = vendorCredit.TotalAmt;
            line.AmountSpecified = true;

            List<LinkedTxn> LinkedTxnList = new List<LinkedTxn>();
            LinkedTxn linkedTxn = new LinkedTxn();
            linkedTxn.TxnId = vendorCredit.Id;
            linkedTxn.TxnType = TxnTypeEnum.VendorCredit.ToString();
            LinkedTxnList.Add(linkedTxn);
            line.LinkedTxn = LinkedTxnList.ToArray();

            lineList.Add(line);

            billPayment.Line = lineList.ToArray();

            return billPayment;
        }

        internal static BillPayment CreateBillPaymentCreditCard(ServiceContext context)
        {
            BillPayment billPayment = new BillPayment();
            VendorCredit vendorCredit = Helper.Add(context, QBOHelper.CreateVendorCredit(context));
            billPayment.PayType = BillPaymentTypeEnum.Check;
            billPayment.PayTypeSpecified = true;
           
            billPayment.TotalAmt = vendorCredit.TotalAmt;
            billPayment.TotalAmtSpecified = true;
         
            billPayment.TxnDate = DateTime.UtcNow.Date;
            billPayment.TxnDateSpecified = true;
            
            billPayment.PrivateNote = "PrivateNote";
            
            Vendor vendor = Helper.FindOrAdd<Vendor>(context, new Vendor());
            billPayment.VendorRef = new ReferenceType()
            {
                name = vendor.DisplayName,
                type = "Vendor",
                Value = vendor.Id
            };

            Account bankAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.CreditCard, AccountClassificationEnum.Expense);
            BillPaymentCreditCard billPaymentCreditCard = new BillPaymentCreditCard();
            billPaymentCreditCard.CCAccountRef = new ReferenceType()
            {
                name = bankAccount.Name,
                Value = bankAccount.Id
            };

            CreditCardPayment creditCardPayment = new CreditCardPayment();
            creditCardPayment.CreditChargeInfo = new CreditChargeInfo()
            {
                Amount = new Decimal(10.00),
                AmountSpecified = true,
                Number = "124124124",
                NameOnAcct = bankAccount.Name,
                CcExpiryMonth = 10,
                CcExpiryMonthSpecified = true,
                CcExpiryYear = 2015,
                CcExpiryYearSpecified = true,
                BillAddrStreet = "BillAddrStreetba7cca47",
                PostalCode = "560045",
                CommercialCardCode = "CardCodeba7cca47",
                CCTxnMode = CCTxnModeEnum.CardPresent,
                CCTxnType = CCTxnTypeEnum.Charge
            };

            billPaymentCreditCard.CCDetail = creditCardPayment;
            billPayment.AnyIntuitObject = billPaymentCreditCard;

            List<Line> lineList = new List<Line>();

            Line line1 = new Line();
          
            Bill bill = Helper.Add<Bill>(context, QBOHelper.CreateBill(context));
            line1.Amount = bill.TotalAmt;
            line1.AmountSpecified = true;
            List<LinkedTxn> LinkedTxnList1 = new List<LinkedTxn>();
            LinkedTxn linkedTxn1 = new LinkedTxn();
            linkedTxn1.TxnId = bill.Id;
            linkedTxn1.TxnType = TxnTypeEnum.Bill.ToString();
            LinkedTxnList1.Add(linkedTxn1);
            line1.LinkedTxn = LinkedTxnList1.ToArray();

            lineList.Add(line1);

            Line line = new Line();
          

            line.Amount = vendorCredit.TotalAmt;
            line.AmountSpecified = true;

            List<LinkedTxn> LinkedTxnList = new List<LinkedTxn>();
            LinkedTxn linkedTxn = new LinkedTxn();
            linkedTxn.TxnId = vendorCredit.Id;
            linkedTxn.TxnType = TxnTypeEnum.VendorCredit.ToString();
            LinkedTxnList.Add(linkedTxn);
            line.LinkedTxn = LinkedTxnList.ToArray();

            lineList.Add(line);

            billPayment.Line = lineList.ToArray();

            return billPayment;
        }

        internal static BillPayment UpdateBillPayment(ServiceContext context, BillPayment entity)
        {
            //update the properties of entity
            entity.PrivateNote = "Updated PrivateNote";

            Account bankAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            BillPaymentCheck billPaymentCheck = new BillPaymentCheck();
            billPaymentCheck.BankAccountRef = new ReferenceType()
            {
                name = bankAccount.Name,
                Value = bankAccount.Id
            };

            CheckPayment checkPayment = new CheckPayment();
            checkPayment.AcctNum = "AcctNum" + Helper.GetGuid().Substring(0, 5);
            checkPayment.BankName = "BankName" + Helper.GetGuid().Substring(0, 5);
            checkPayment.CheckNum = "CheckNum" + Helper.GetGuid().Substring(0, 5);
            checkPayment.NameOnAcct = "Name" + Helper.GetGuid().Substring(0, 5);
            checkPayment.Status = "Status" + Helper.GetGuid().Substring(0, 5);
            billPaymentCheck.CheckDetail = checkPayment;

            PhysicalAddress payeeAddr = new PhysicalAddress();
            payeeAddr.Line1 = "Line 1";
            payeeAddr.Line2 = "Line 2";
            payeeAddr.City = "Mountain View";
            payeeAddr.CountrySubDivisionCode = "CA";
            payeeAddr.PostalCode = "94043";
            billPaymentCheck.PayeeAddr = payeeAddr;
            billPaymentCheck.PrintStatus = PrintStatusEnum.NeedToPrint;
            billPaymentCheck.PrintStatusSpecified = true;
            entity.AnyIntuitObject = billPaymentCheck;
            return entity;
        }

        internal static BillPayment UpdateBillPaymentSparse(ServiceContext context, string id, string syncToken)
        {
            BillPayment entity = new BillPayment();
            entity.Id = id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.PrivateNote = "Updated PrivateNote";
            return entity;
        }

        internal static Deposit CreateDeposit(ServiceContext context)
        {
            Deposit deposit = new Deposit();
            Account bankAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            deposit.DepositToAccountRef = new ReferenceType()
            {
                name = bankAccount.Name,
                Value = bankAccount.Id
            };

            deposit.TotalAmt = new Decimal(100.00);
            deposit.TotalAmtSpecified = true;

            deposit.TxnDate = DateTime.UtcNow.Date;
            deposit.TxnDateSpecified = true;
            
            deposit.ExchangeRate = new Decimal(1.00);
            deposit.ExchangeRateSpecified = true;
            deposit.PrivateNote = "PrivateNote" + Helper.GetGuid().Substring(0, 8); ;
            

            List<Line> lineList = new List<Line>();
            Line line = new Line();
            //line.LineNum = "LineNum";
            line.Description = "Description";
            line.Amount = new Decimal(100.00);
            line.AmountSpecified = true;

            line.DetailType = LineDetailTypeEnum.DepositLineDetail;
            line.DetailTypeSpecified = true;

            DepositLineDetail lineDepositLineDetail = new DepositLineDetail();

            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            lineDepositLineDetail.Entity = new ReferenceType()
            {
                //add customer/job detail
                name = customer.DisplayName,
                Value = customer.Id
            };

            Account incomeAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Income, AccountClassificationEnum.Revenue);
            lineDepositLineDetail.AccountRef = new ReferenceType()
            {
                //add account detail
                name = incomeAccount.Name,
                Value = incomeAccount.Id
            };

            PaymentMethod paymentMethod = Helper.FindOrAddPaymentMethod(context, PaymentMethodEnum.Cash.ToString());
            lineDepositLineDetail.PaymentMethodRef = new ReferenceType()
            {
                //add paymentMethod 
                name = paymentMethod.Name,
                Value = paymentMethod.Id

            };

            line.AnyIntuitObject = lineDepositLineDetail;
            lineList.Add(line);
            deposit.Line = lineList.ToArray();

            

            return deposit;
        }



        internal static Deposit UpdateDeposit(ServiceContext context, Deposit entity)
        {
            //update the properties of entity
            entity.PrivateNote = "upd_Note" + Helper.GetGuid().Substring(0, 8);

            return entity;
        }


        internal static Deposit UpdateDepositSparse(ServiceContext context, string id, string syncToken)
        {
            Deposit entity = new Deposit();
            entity.Id = id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.PrivateNote = "spa_Note" + Helper.GetGuid().Substring(0, 8);
            Account bankAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            entity.DepositToAccountRef = new ReferenceType()
            {
                name = bankAccount.Name,
                Value = bankAccount.Id
            };


            return entity;
        }

        internal static Transfer CreateTransfer(ServiceContext context)
        {
            Transfer transfer = new Transfer();
            Account depositAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            transfer.FromAccountRef = new ReferenceType()
            {
                name = depositAccount.Name,
                Value = depositAccount.Id
            };
            Account creditAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.CreditCard, AccountClassificationEnum.Liability);
            transfer.ToAccountRef = new ReferenceType()
            {
                name = creditAccount.Name,
                Value = creditAccount.Id
            };
            transfer.Amount = new Decimal(100.00);
            transfer.AmountSpecified = true;
            
            return transfer;
        }



        internal static Transfer UpdateTransfer(ServiceContext context, Transfer entity)
        {
            //update the properties of entity
            entity.Amount = new Decimal(200.00);
            entity.AmountSpecified = true;

            return entity;
        }

        internal static Transfer UpdateTransferSparse(ServiceContext context, string id, string syncToken)
        {
            Transfer entity = new Transfer();
            entity.Id = id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Amount = new Decimal(200.00);
            entity.AmountSpecified = true;

            return entity;
        }



        internal static PurchaseOrder CreatePurchaseOrder(ServiceContext context)
        {
            Vendor vendors = Helper.FindOrAdd<Vendor>(context, new Vendor());
            Account accountsForDetail = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense);

            PurchaseOrder purchaseOrder = new PurchaseOrder();
            

            purchaseOrder.VendorRef = new ReferenceType()
            {
                
                name = vendors.DisplayName,
                Value = vendors.Id
            };
            
            purchaseOrder.TotalAmt = new Decimal(10.00);
            purchaseOrder.TotalAmtSpecified = true;
            
            purchaseOrder.TxnDate = DateTime.UtcNow.Date;
            purchaseOrder.TxnDateSpecified = true;
            
            List<Line> lineList = new List<Line>();
            Line line = new Line();
            line.LineNum = "1";
            
            line.Amount = new Decimal(10.00);
            line.AmountSpecified = true;

            
            line.DetailType = LineDetailTypeEnum.AccountBasedExpenseLineDetail;
            line.DetailTypeSpecified = true;
            AccountBasedExpenseLineDetail accountBasedExpenseDetails = new AccountBasedExpenseLineDetail();
            accountBasedExpenseDetails.AccountRef = new ReferenceType { type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Account), name = accountsForDetail.Name, Value = accountsForDetail.Id };

            line.AnyIntuitObject = accountBasedExpenseDetails;

            
            lineList.Add(line);
            purchaseOrder.Line = lineList.ToArray();

            //purchaseOrder.POStatus = PurchaseOrderStatusEnum.Open;
            //purchaseOrder.POStatusSpecified = true;
            
            return purchaseOrder;
        }



        internal static PurchaseOrder UpdatePurchaseOrder(ServiceContext context, PurchaseOrder entity)
        {
            //update the properties of entity
            entity.DocNumber = Helper.GetGuid().Substring(0, 13);
            return entity;
        }

        internal static PurchaseOrder UpdatePurchaseOrderSparse(ServiceContext context, string Id, string SyncToken)
        {
            PurchaseOrder entity = new PurchaseOrder();
            entity.Id = Id;
            entity.SyncToken = SyncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.DocNumber = Helper.GetGuid().Substring(0, 13);
            return entity;
        }


        
        internal static CreditMemo CreateCreditMemo(ServiceContext context)
        {
            CreditMemo creditMemo = new CreditMemo();
       
            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            creditMemo.CustomerRef = new ReferenceType()
            {
                name = customer.DisplayName,
                Value = customer.Id
            };
            
            creditMemo.TotalAmt = new Decimal(100.00);
            creditMemo.TotalAmtSpecified = true;
         
            creditMemo.ApplyTaxAfterDiscount = true;
            creditMemo.ApplyTaxAfterDiscountSpecified = true;
            
            Account depositAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Asset);
            creditMemo.DepositToAccountRef = new ReferenceType()
            {
                name = depositAccount.Name,
                Value = depositAccount.Id
            };
            creditMemo.DocNumber = "DocNumber" + Helper.GetGuid().Substring(0, 3); ;
            creditMemo.TxnDate = DateTime.UtcNow.Date;
            creditMemo.TxnDateSpecified = true;
            

            List<Line> lineList = new List<Line>();
            Line line1 = new Line();
            line1.LineNum = "1";
            line1.Description = "Description";
            line1.Amount = new Decimal(100.00);
            line1.AmountSpecified = true;

          
            line1.DetailType = LineDetailTypeEnum.SalesItemLineDetail;
            line1.DetailTypeSpecified = true;
            Item item = Helper.FindOrAdd<Item>(context, new Item());
            TaxCode taxcode = Helper.FindOrAdd<TaxCode>(context, new TaxCode());
            line1.AnyIntuitObject = new SalesItemLineDetail()
            {
                ItemRef = new ReferenceType() { name = item.Name, Value = item.Id },
                TaxCodeRef = new ReferenceType() { name = taxcode.Name, Value = taxcode.Id }
            };

            
            Line line2 = new Line();
            line2.Amount = new Decimal(100.00);
            line2.DetailType = LineDetailTypeEnum.SubTotalLineDetail;
            line2.DetailTypeSpecified = true;
            lineList.Add(line1);
            lineList.Add(line2);
            creditMemo.Line = lineList.ToArray();
            
            return creditMemo;
        }

        internal static CreditMemo UpdateCreditMemo(ServiceContext context, CreditMemo entity)
        {
            //update the properties of entity
            entity.DocNumber = "UpdatedDocNum" + Helper.GetGuid().Substring(0, 3); ;
            entity.TxnDate = DateTime.UtcNow.Date.AddDays(2);
            entity.TxnDateSpecified = true;
            return entity;
        }

        internal static CreditMemo UpdateCreditMemoSparse(ServiceContext context, string Id, string SyncToken)
        {
            //update the properties of entity
            CreditMemo entity = new CreditMemo();
            entity.Id = Id;
            entity.SyncToken = SyncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.DocNumber = "UpdatedDocNum" + Helper.GetGuid().Substring(0, 3); ;
            entity.TxnDate = DateTime.UtcNow.Date.AddDays(2);
            entity.TxnDateSpecified = true;
            return entity;
        }

        internal static RefundReceipt CreateRefundReceipt(ServiceContext context)
        {
            RefundReceipt refundReceipt = new RefundReceipt();
           
            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            refundReceipt.CustomerRef = new ReferenceType()
            {
                name = customer.DisplayName,
                type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Customer),
                Value = customer.Id
            };
            
            refundReceipt.ApplyTaxAfterDiscount = true;
            refundReceipt.ApplyTaxAfterDiscountSpecified = true;
            
            refundReceipt.PrintStatus = PrintStatusEnum.NotSet;
            refundReceipt.PrintStatusSpecified = true;
            
            EmailAddress billEmail = new EmailAddress();
            billEmail.Address = "Address@Intuit.com";
            billEmail.Default = true;
            billEmail.DefaultSpecified = true;
            billEmail.Tag = "Tag";
            refundReceipt.BillEmail = billEmail;
            
            refundReceipt.BalanceSpecified = true;
            
            refundReceipt.PaymentRefNum = "PaymentRefNum";
            refundReceipt.PaymentType = PaymentTypeEnum.CreditCard;
            refundReceipt.PaymentTypeSpecified = true;
            
            refundReceipt.DocNumber = "DocNumber";
            refundReceipt.TxnDate = DateTime.UtcNow.Date;
            refundReceipt.TxnDateSpecified = true;
            
            refundReceipt.PrivateNote = "PrivateNote";
            
            List<Line> lineList = new List<Line>();
            Line line = new Line();

            line.Description = "Description12";
            line.Amount = new Decimal(100.00);
            line.AmountSpecified = true;

            
            line.DetailType = LineDetailTypeEnum.SalesItemLineDetail;
            line.DetailTypeSpecified = true;
            Item item = Helper.FindOrAdd<Item>(context, new Item());
            TaxCode taxCode = Helper.FindOrAdd<TaxCode>(context, new TaxCode());
            line.AnyIntuitObject = new SalesItemLineDetail()
            {
                ItemRef = new ReferenceType()
                {
                    name = item.Name,
                    Value = item.Id
                },
                TaxCodeRef = new ReferenceType()
                {
                    name = taxCode.Name,
                    Value = taxCode.Id
                }
            };
            Line line2 = new Line();
            line2.Amount = new Decimal(100.00);
            line2.DetailType = LineDetailTypeEnum.SubTotalLineDetail;
            line2.DetailTypeSpecified = true;
            line2.AnyIntuitObject = new SubTotalLineDetail()
            {
            };

            TxnTaxDetail txnTaxDetail = new TxnTaxDetail();
            txnTaxDetail.TxnTaxCodeRef = new ReferenceType()
            {
                name = taxCode.Name,
                Value = taxCode.Id

            };
            txnTaxDetail.TotalTax = new Decimal(100.00);
            txnTaxDetail.TotalTaxSpecified = true;


            
            lineList.Add(line);
            refundReceipt.Line = lineList.ToArray();


            Account account = Helper.FindOrAddAccount(context, AccountTypeEnum.Bank, AccountClassificationEnum.Liability);
            refundReceipt.DepositToAccountRef = new ReferenceType()
            {
                name = account.Name,
                Value = account.Id
            };
            
            return refundReceipt;
        }



        internal static RefundReceipt UpdateRefundReceipt(ServiceContext context, RefundReceipt entity)
        {
            entity.PrintStatus = PrintStatusEnum.NeedToPrint;
            entity.PrintStatusSpecified = true;
          
            return entity;
        }


        internal static RefundReceipt UpdateRefundReceiptSparse(ServiceContext context, string id, string syncToken)
        {
            RefundReceipt entity = new RefundReceipt();
            entity.Id = id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.PrintStatus = PrintStatusEnum.NeedToPrint;
            entity.PrintStatusSpecified = true;
            
            return entity;
        }


        internal static CompanyCurrency CreateCompanyCurrency(ServiceContext context)
        {
            CompanyCurrency currency = new CompanyCurrency();
           
            currency.Active = true;
            currency.ActiveSpecified = true;
            currency.Code ="AMD";  
          
           
     
            return currency;
        }



      
        

       

        internal static JournalCode CreateJournalCode(ServiceContext context, JournalCodeTypeEnum journalCodeType)
        {
            JournalCode journalCode = new JournalCode();
            journalCode.Name = "JC" + Helper.GetGuid().Substring(0, 5);
            
            journalCode.Type = journalCodeType.ToString();

            return journalCode;
        }



        internal static JournalEntry CreateJournalEntry(ServiceContext context)
        {
            JournalEntry journalEntry = new JournalEntry();
            journalEntry.Adjustment = true;
            journalEntry.AdjustmentSpecified = true;
            
            journalEntry.DocNumber = "DocNumber" + Helper.GetGuid().Substring(0, 5);
            journalEntry.TxnDate = DateTime.UtcNow.Date;
            journalEntry.TxnDateSpecified = true;
            

            List<Line> lineList = new List<Line>();

            Line debitLine = new Line();
            debitLine.Description = "nov portion of rider insurance";
            debitLine.Amount = new Decimal(100.00);
            debitLine.AmountSpecified = true;
            debitLine.DetailType = LineDetailTypeEnum.JournalEntryLineDetail;
            debitLine.DetailTypeSpecified = true;
            JournalEntryLineDetail journalEntryLineDetail = new JournalEntryLineDetail();
            journalEntryLineDetail.PostingType = PostingTypeEnum.Debit;
            journalEntryLineDetail.PostingTypeSpecified = true;
            Account expenseAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.Expense, AccountClassificationEnum.Expense);
            journalEntryLineDetail.AccountRef = new ReferenceType() { type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Account), name = expenseAccount.Name, Value = expenseAccount.Id };
            debitLine.AnyIntuitObject = journalEntryLineDetail;
            lineList.Add(debitLine);

            Line creditLine = new Line();
            creditLine.Description = "nov portion of rider insurance";
            creditLine.Amount = new Decimal(100.00);
            creditLine.AmountSpecified = true;
            creditLine.DetailType = LineDetailTypeEnum.JournalEntryLineDetail;
            creditLine.DetailTypeSpecified = true;
            JournalEntryLineDetail journalEntryLineDetailCredit = new JournalEntryLineDetail();
            journalEntryLineDetailCredit.PostingType = PostingTypeEnum.Credit;
            journalEntryLineDetailCredit.PostingTypeSpecified = true;
            Account assetAccount = Helper.FindOrAddAccount(context, AccountTypeEnum.OtherCurrentAsset, AccountClassificationEnum.Asset);
            journalEntryLineDetailCredit.AccountRef = new ReferenceType() { type = Enum.GetName(typeof(objectNameEnumType), objectNameEnumType.Account), name = assetAccount.Name, Value = assetAccount.Id };
            creditLine.AnyIntuitObject = journalEntryLineDetailCredit;
            lineList.Add(creditLine);

            journalEntry.Line = lineList.ToArray();
            
            return journalEntry;
        }


        internal static JournalCode UpdateJournalCode(ServiceContext context, JournalCode journalCode)
        {
            //update the properties of JournalCode
            journalCode.Description = "Updated" + Helper.GetGuid().Substring(0, 5);

            return journalCode;
        }

        internal static JournalCode UpdateJournalCodeSparse(ServiceContext context, string id, string syncToken)
        {
            JournalCode entity = new JournalCode();
            entity.Id = id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Name = "JC_Sparse" + Helper.GetGuid().Substring(0, 5);
            entity.Description = "sparseupdated" + Helper.GetGuid().Substring(0, 5);

            return entity;
        }



        internal static JournalEntry UpdateJournalEntry(ServiceContext context, JournalEntry entity)
        {
            //update the properties of entity
            entity.DocNumber = "udpated" + Helper.GetGuid().Substring(0, 5);

            return entity;
        }


        internal static JournalEntry UpdateJournalEntrySparse(ServiceContext context, string id, string syncToken)
        {
            JournalEntry entity = new JournalEntry();
            entity.Id = id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.DocNumber = "sparseudpated" + Helper.GetGuid().Substring(0, 5);

            return entity;
        }




        internal static TimeActivity CreateTimeActivity(ServiceContext context)
        {
            TimeActivity timeActivity = new TimeActivity();
          
            timeActivity.TxnDate = DateTime.UtcNow.Date;
            timeActivity.TxnDateSpecified = true;
            timeActivity.NameOf = TimeActivityTypeEnum.Vendor;
            timeActivity.NameOfSpecified = true;
            
            Vendor vendor = Helper.FindOrAdd(context, new Vendor());

            timeActivity.AnyIntuitObject = new ReferenceType() { name = vendor.DisplayName, Value = vendor.Id };
            timeActivity.ItemElementName = ItemChoiceType5.VendorRef;

            Customer cust = Helper.FindOrAdd(context, new Customer());
            timeActivity.CustomerRef = new ReferenceType()
            {
                name = cust.DisplayName,
                Value = cust.Id
            };

            Item item = Helper.FindOrAdd(context, new Item());
            timeActivity.ItemRef = new ReferenceType()
            {
                name = item.Name,
                Value = item.Id
            };
            
            timeActivity.BillableStatus = BillableStatusEnum.NotBillable;
            timeActivity.BillableStatusSpecified = true;
            timeActivity.Taxable = false;
            timeActivity.TaxableSpecified = true;
            timeActivity.HourlyRate = new Decimal(0.00);
            timeActivity.HourlyRateSpecified = true;
            timeActivity.Hours = 10;

            timeActivity.HoursSpecified = true;
            timeActivity.Minutes = 0;

            timeActivity.MinutesSpecified = true;
            
            timeActivity.Description = "Description" + Helper.GetGuid().Substring(0, 5);
            
            return timeActivity;
        }



        internal static TimeActivity UpdateTimeActivity(ServiceContext context, TimeActivity entity)
        {
            //update the properties of entity
            entity.Description = "UpdatedDesc" + Helper.GetGuid().Substring(0, 3);
            return entity;
        }

        internal static TimeActivity UpdateTimeActivitySparse(ServiceContext context, string Id, string syncToken)
        {
            //update the properties of entity
            TimeActivity entity = new TimeActivity();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.Description = "UpdatedDesc" + Helper.GetGuid().Substring(0, 3);
            return entity;
        }

        

       

        internal static Preferences UpdatePreferences(ServiceContext context, Preferences entity)
        {
            //update the properties of entity
            SalesFormsPrefs salesFormsPrefs = new SalesFormsPrefs();
            salesFormsPrefs.UsingProgressInvoicing = true;
            salesFormsPrefs.UsingProgressInvoicingSpecified = true;


            salesFormsPrefs.CustomTxnNumbers = false;
            salesFormsPrefs.CustomTxnNumbersSpecified = true;
            salesFormsPrefs.AllowDeposit = false;
            salesFormsPrefs.AllowDepositSpecified = true;
            salesFormsPrefs.AllowDiscount = false;
            salesFormsPrefs.AllowDiscountSpecified = true;
            salesFormsPrefs.AllowEstimates = true;
            salesFormsPrefs.AllowEstimatesSpecified = true;
            salesFormsPrefs.IPNSupportEnabled = false;
            salesFormsPrefs.IPNSupportEnabledSpecified = true;

            entity.SalesFormsPrefs = salesFormsPrefs;

            //Output only field.  Need to set to null for Update operation.
            entity.OtherPrefs = null;

            return entity;
        }



      

        internal static Attachable CreateAttachable(ServiceContext context)
        {
            Attachable attachable = new Attachable();
       
            attachable.Lat = "25.293112341223";
            attachable.Long = "-21.3253249834";
            attachable.PlaceName = "Fake Place";
            attachable.Note = "Attachable note " + Helper.GetGuid().Substring(0, 5); ;
            attachable.Tag = "Attachable tag " + Helper.GetGuid().Substring(0, 5); ;
            

            Customer customer = Helper.FindOrAdd<Customer>(context, new Customer());
            ReferenceType customerRef = new ReferenceType();
            customerRef.name = customer.DisplayName;
            customerRef.Value = customer.Id;
            customerRef.type = "Customer";

            Vendor vendor = Helper.FindOrAdd<Vendor>(context, new Vendor());
            ReferenceType vendorRef = new ReferenceType();
            vendorRef.name = vendor.DisplayName;
            vendorRef.Value = vendor.Id;
            vendorRef.type = "Vendor";

            AttachableRef attachableRef1 = new AttachableRef();
            attachableRef1.EntityRef = customerRef;
            AttachableRef attachableRef2 = new AttachableRef();
            attachableRef2.EntityRef = vendorRef;

            List<AttachableRef> list = new List<AttachableRef>();
            list.Add(attachableRef1);
            list.Add(attachableRef2);

            attachable.AttachableRef = list.ToArray();
            return attachable;
        }

        internal static Attachable CreateAttachableUpload(ServiceContext context)
        {
            Attachable attachable = new Attachable();
            
            attachable.Lat = "25.293112341223";
            attachable.Long = "-21.3253249834";
            attachable.PlaceName = "Fake Place";
            attachable.Note = "Attachable note " + Helper.GetGuid().Substring(0, 5); 
            attachable.Tag = "Attachable tag " + Helper.GetGuid().Substring(0, 5);

            //For attaching to Invoice or Bill or any Txn entity, Uncomment and replace the Id and type of the Txn in below code
            AttachableRef[] attachments = new AttachableRef[1];
            AttachableRef ar = new AttachableRef();
            ar.EntityRef = new ReferenceType();
            ar.EntityRef.type = objectNameEnumType.Invoice.ToString();
            ar.EntityRef.name = objectNameEnumType.Invoice.ToString();
            ar.EntityRef.Value = "3535"; //Add the Id of your invoice here
            ////ar.EntityRef.type = objectNameEnumType.Bill.ToString();
            ////ar.EntityRef.name = objectNameEnumType.Bill.ToString();
            ////ar.EntityRef.Value = "1484";
            attachments[0] = ar;
            attachable.AttachableRef = attachments;

            return attachable;
        }


        internal static Attachable UpdateAttachable(ServiceContext context, Attachable entity)
        {
            //update the properties of entity
            entity.Note = "Attachable note " + Helper.GetGuid().Substring(0, 5); ;
            entity.Tag = "Attachable tag " + Helper.GetGuid().Substring(0, 5); ;

            return entity;
        }


        internal static Attachable SparseUpdateAttachable(ServiceContext context, string Id, string syncToken)
        {
            Attachable entity = new Attachable();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.Note = "Sparse Attachable note " + Helper.GetGuid().Substring(0, 5); ;
            entity.Tag = "Sparse Attachable tag " + Helper.GetGuid().Substring(0, 5); ;

            return entity;
        }


 


        internal static Customer CreateCustomer(ServiceContext context)
        {

            String guid = Helper.GetGuid();
            Customer customer = new Customer();
            customer.Taxable = false;
            customer.TaxableSpecified = true;
            PhysicalAddress billAddr = new PhysicalAddress();
            billAddr.Line1 = "Line1";
            billAddr.Line2 = "Line2";
            billAddr.Line3 = "Line3";
            billAddr.Line4 = "Line4";
            billAddr.Line5 = "Line5";
            billAddr.City = "City";
            billAddr.Country = "Country";
   
            billAddr.CountrySubDivisionCode = "CountrySubDivisionCode";
            billAddr.PostalCode = "PostalCode";
            
            customer.BillAddr = billAddr;
            PhysicalAddress shipAddr = new PhysicalAddress();
            shipAddr.Line1 = "Line1";
            shipAddr.Line2 = "Line2";
            shipAddr.Line3 = "Line3";
            shipAddr.Line4 = "Line4";
            shipAddr.Line5 = "Line5";
            shipAddr.City = "City";
            shipAddr.Country = "Country";
        
            shipAddr.CountrySubDivisionCode = "CountrySubDivisionCode";
            shipAddr.PostalCode = "PostalCode";
        
            customer.ShipAddr = shipAddr;

            List<PhysicalAddress> otherAddrList = new List<PhysicalAddress>();
            PhysicalAddress otherAddr = new PhysicalAddress();
            otherAddr.Line1 = "Line1";
            otherAddr.Line2 = "Line2";
            otherAddr.Line3 = "Line3";
            otherAddr.Line4 = "Line4";
            otherAddr.Line5 = "Line5";
            otherAddr.City = "City";
            otherAddr.Country = "Country";
            
            otherAddr.CountrySubDivisionCode = "CountrySubDivisionCode";
            otherAddr.PostalCode = "PostalCode";
            
            otherAddrList.Add(otherAddr);
            customer.OtherAddr = otherAddrList.ToArray();
            
            customer.Notes = "Notes";
            customer.Job = false;
            customer.JobSpecified = true;
            customer.BillWithParent = false;
            customer.BillWithParentSpecified = true;
            
            customer.Balance = new Decimal(100.00);
            customer.BalanceSpecified = true;
            

            customer.BalanceWithJobs = new Decimal(100.00);
            customer.BalanceWithJobsSpecified = true;
            
            customer.PreferredDeliveryMethod = "Print";
            customer.ResaleNum = "ResaleNum";
            
            customer.Title = "Title";
            customer.GivenName = "GivenName";
            customer.MiddleName = "MiddleName";
            customer.FamilyName = "FamilyName";
            customer.Suffix = "Suffix";
            customer.FullyQualifiedName = "Name_" + guid;
            customer.CompanyName = "CompanyName";
            customer.DisplayName = "Name_" + guid;
            customer.PrintOnCheckName = "PrintOnCheckName";
            
            customer.Active = true;
            customer.ActiveSpecified = true;
            TelephoneNumber primaryPhone = new TelephoneNumber();
            
            primaryPhone.FreeFormNumber = "FreeFormNumber";
            
            customer.PrimaryPhone = primaryPhone;
            TelephoneNumber alternatePhone = new TelephoneNumber();
            
            alternatePhone.FreeFormNumber = "FreeFormNumber";
           
            customer.AlternatePhone = alternatePhone;
            TelephoneNumber mobile = new TelephoneNumber();
            
            mobile.FreeFormNumber = "FreeFormNumber";
          
            customer.Mobile = mobile;
            TelephoneNumber fax = new TelephoneNumber();
            
            fax.FreeFormNumber = "FreeFormNumber";
            
            customer.Fax = fax;
            EmailAddress primaryEmailAddr = new EmailAddress();
            primaryEmailAddr.Address = "test@tesing.com";
            
            customer.PrimaryEmailAddr = primaryEmailAddr;
            WebSiteAddress webAddr = new WebSiteAddress();
            webAddr.URI = "http://uri.com";
            
            customer.WebAddr = webAddr;

            return customer;
        }



        internal static Customer UpdateCustomer(ServiceContext context, Customer entity)
        {
            //update the properties of entity
            entity.GivenName = "ChangedName";
            return entity;
        }


    
        internal static Customer SparseUpdateCustomer(ServiceContext context, string Id, string syncToken)
        {
            Customer entity = new Customer();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.MiddleName = "Sparse" + Helper.GetGuid().Substring(0, 5);
            return entity;
        }


       

        internal static Vendor CreateVendor(ServiceContext context)
        {
            Vendor vendor = new Vendor();

            PhysicalAddress billAddr = new PhysicalAddress();
            billAddr.Line1 = "Line1";
            billAddr.Line2 = "Line2";
            billAddr.Line3 = "Line3";
            billAddr.Line4 = "Line4";
            billAddr.Line5 = "Line5";
            billAddr.City = "City";
            billAddr.Country = "Country";
            
            billAddr.CountrySubDivisionCode = "CountrySubDivisionCode";
            billAddr.PostalCode = "PostalCode";
           
            vendor.BillAddr = billAddr;
            
            vendor.TaxIdentifier = "TaxIdentifier";
            
            vendor.Balance = new Decimal(100.00);
            vendor.BalanceSpecified = true;
            vendor.OpenBalanceDate = DateTime.UtcNow.Date;
            vendor.OpenBalanceDateSpecified = true;
            
            vendor.AcctNum = "AcctNum";
            vendor.Vendor1099 = true;
            vendor.Vendor1099Specified = true;
            
            vendor.Title = "Title";
            vendor.GivenName = "GivenName";
            vendor.MiddleName = "MiddleName";
            vendor.FamilyName = "FamilyName";
            vendor.Suffix = "Suffix";
            

            vendor.CompanyName = "CompanyName";
            vendor.DisplayName = "DisplayName_" + Helper.GetGuid();
            vendor.PrintOnCheckName = "PrintOnCheckName";
            
            vendor.Active = true;
            vendor.ActiveSpecified = true;
            TelephoneNumber primaryPhone = new TelephoneNumber();
            
            primaryPhone.FreeFormNumber = "FreeFormNumber";
            
            vendor.PrimaryPhone = primaryPhone;
            TelephoneNumber alternatePhone = new TelephoneNumber();
            
            alternatePhone.FreeFormNumber = "FreeFormNumber";
            
            vendor.AlternatePhone = alternatePhone;
            TelephoneNumber mobile = new TelephoneNumber();
            
            mobile.FreeFormNumber = "FreeFormNumber";
            
            vendor.Mobile = mobile;
            TelephoneNumber fax = new TelephoneNumber();
            
            fax.FreeFormNumber = "FreeFormNumber";
            
            vendor.Fax = fax;
            EmailAddress primaryEmailAddr = new EmailAddress();
            primaryEmailAddr.Address = "Address@add.com";
            
            vendor.PrimaryEmailAddr = primaryEmailAddr;
            WebSiteAddress webAddr = new WebSiteAddress();
            webAddr.URI = "http://site.com";
    
            vendor.WebAddr = webAddr;

            return vendor;
        }


       

        internal static Vendor UpdateVendor(ServiceContext context, Vendor entity)
        {
            entity.Title = "Title updated";
            entity.GivenName = "GivenName updated";
            entity.MiddleName = "MiddleName updated";
            entity.FamilyName = "FamilyName updated";
            entity.Suffix = "Mr.";
            return entity;
        }





        internal static Vendor SparseUpdateVendor(ServiceContext context, string id, string syncToken)
        {
            Vendor entity = new Vendor();
            entity.Id = id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.GivenName = "sparse" + Helper.GetGuid().Substring(0, 5);
            entity.MiddleName = "sparse" + Helper.GetGuid().Substring(0, 5);
            entity.FamilyName = "sparse" + Helper.GetGuid().Substring(0, 5);
            return entity;
        }



       

        internal static Employee CreateEmployee(ServiceContext context)
        {
            Employee employee = new Employee();
            employee.EmployeeType = EmployeeTypeEnum.Regular.ToString();
            employee.EmployeeNumber = "ENO" + Helper.GetGuid().Substring(0, 6);
            employee.SSN = "111-22-3333";
            
            employee.BirthDate = DateTime.UtcNow.Date;
            employee.BirthDateSpecified = true;
            employee.Gender = gender.Male;


            employee.GenderSpecified = true;
            employee.HiredDate = DateTime.UtcNow.Date;
            employee.HiredDateSpecified = true;
            employee.ReleasedDate = DateTime.UtcNow.Date;
            employee.ReleasedDateSpecified = true;
            employee.UseTimeEntry = TimeEntryUsedForPaychecksEnum.UseTimeEntry;
          
            employee.Organization = true;
            employee.OrganizationSpecified = true;
            employee.Title = "Title";
            employee.GivenName = "GivenName" + Helper.GetGuid().Substring(0, 8);
            employee.MiddleName = "MiddleName" + Helper.GetGuid().Substring(0, 8);
            employee.FamilyName = "FamilyName" + Helper.GetGuid().Substring(0, 8);
            employee.CompanyName = "CompanyName" + Helper.GetGuid().Substring(0, 8);
            employee.DisplayName = "DisplayName" + Helper.GetGuid().Substring(0, 8);
            employee.PrintOnCheckName = "PrintOnCheckName" + Helper.GetGuid().Substring(0, 8); ;
            employee.UserId = "UserId" + Helper.GetGuid().Substring(0, 8); ;
            employee.Active = true;
            employee.ActiveSpecified = true;
            
            return employee;
        }



        internal static Employee UpdateEmployee(ServiceContext context, Employee entity)
        {
            //update the properties of entity
            entity.GivenName = "updated" + Helper.GetGuid().Substring(0, 8);
            entity.MiddleName = "updated" + Helper.GetGuid().Substring(0, 8);
            entity.FamilyName = "updated" + Helper.GetGuid().Substring(0, 8);
            entity.CompanyName = "updated" + Helper.GetGuid().Substring(0, 8);
            return entity;
        }


        internal static Employee SparseUpdateEmployee(ServiceContext context, string Id, string syncToken)
        {
            Employee entity = new Employee();
            entity.Id = Id;
            entity.SyncToken = syncToken;
            entity.sparse = true;
            entity.sparseSpecified = true;
            entity.GivenName = "sparseupdated" + Helper.GetGuid().Substring(0, 8);
            return entity;
        }


        


        #endregion

       

    }
}