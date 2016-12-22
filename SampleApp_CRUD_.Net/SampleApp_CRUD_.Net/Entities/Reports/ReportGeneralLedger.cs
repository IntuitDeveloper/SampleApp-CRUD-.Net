using System;
using System.Collections.Generic;
using Intuit.Ipp.Data;
using Intuit.Ipp.Core;
using Intuit.Ipp.ReportService;

namespace SampleApp_CRUD_DotNet
{
    public class ReportGeneralLedgerTest
    {
        #region reportservice test
        public void ReportGeneralLedgerTestUsingoAuth(ServiceContext qboContextoAuth)
        {
            ReportService reportService = new ReportService(qboContextoAuth);
            reportService.date_macro = "This Fiscal Year-to-date";
            reportService.accounting_method = "Accrual";
            reportService.summarize_column_by = "Month";
            //Check query parameters section of each report for querying on specific cols
            List<String> columndata = new List<String>();
            columndata.Add("tx_date");
            columndata.Add("tx_type");//The value odf this col has the txnId
            string coldata = String.Join(",", columndata);
            reportService.columns = coldata;
            Report report = reportService.ExecuteReport("GeneralLedger");



        }
        #endregion
    }
}