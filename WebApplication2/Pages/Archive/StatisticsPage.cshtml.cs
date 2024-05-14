using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Globalization;
using PdfSharp.Charting;
using PdfSharp.Pdf.IO;
using Microsoft.EntityFrameworkCore;


namespace WebApplication2.Pages.Archive
{

    public class StatisticsPageModel : PageModel
    {

        public List<string> Months { get; set; } = new List<string>
        {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        public class MonthlyPieceCount
        {
            public string MonthYear { get; set; }
            public int OkPieces { get; set; }
            public int NokPieces { get; set; }
        }

        public List<MonthlyPieceCount> MonthlyPieceCounts { get; set; }
        public int OkPiecesCount { get; set; }



   
        public void OnGet()
            {

            try
            {
                string query = "SELECT COUNT(*) FROM Table_Wiss WHERE State_WS80 = 'OK'";

                using (SqlConnection cn = new SqlConnection(@"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cn.Open();
                    OkPiecesCount = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data from SQL: " + ex.Message);
            }
        
        // PopulateMonthlyPieceCounts();
    }



        public class ArchiveModel
        {
            public DateTime Time_In_WS10 { get; set; }
            public string State_WS80 { get; set; }
        }

        public class ChartData
        {
            public List<string> MonthLabels { get; set; }
            public List<double> DefectivesPercentageByMonth { get; set; }
        }

      




        /*     public void PopulateMonthlyPieceCounts()
             {
                 MonthlyPieceCounts = new List<MonthlyPieceCount>();

                 try
                 {
                     using (SqlConnection cn = new SqlConnection(@"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;"))
                     {
                         cn.Open();
                         foreach (string month in Months)
                         {
                             string queryOk = $"SELECT COUNT(*) FROM Table_Wiss WHERE State_WS80 = 'OK' AND MONTH(Time_In_WS10) = MONTH('{month}-01')";
                             SqlCommand cmdOk = new SqlCommand(queryOk, cn);
                             int okCount = (int)cmdOk.ExecuteScalar();

                             string queryNok = $"SELECT COUNT(*) FROM Table_Wiss WHERE State_WS80 = 'NOK' AND MONTH(Time_In_WS10) = MONTH('{month}-01')";
                             SqlCommand cmdNok = new SqlCommand(queryNok, cn);
                             int nokCount = (int)cmdNok.ExecuteScalar();

                             MonthlyPieceCounts.Add(new MonthlyPieceCount
                             {
                                 MonthYear = month,
                                 OkPieces = okCount,
                                 NokPieces = nokCount
                             });
                         }
                     }
                 }
                 catch (Exception ex)
                 {
                     throw new Exception("Error fetching data from SQL: " + ex.Message);
                 }
             }

             */
    }
    public class ArchiveModel
    {
        public DateTime Time_In_WS10 { get; set; }
        public string State_WS80 { get; set; }
    }
    public class MonthlyPieceCount
    {
        public string MonthYear { get; set; }
        public int OkPieces { get; set; }
        public int NokPieces { get; set; }
    }

}



