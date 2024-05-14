using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection;
using OfficeOpenXml;
using System.IO;
using static System.Collections.Specialized.BitVector32;
using System.Reflection.Metadata;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace WebApplication2.Pages
{//style="background-color: #fcfcfc
    // <a class="btn btn-danger btn-sm" href="/Archive/Delete?QRCode=@archive.QRCode">DELETE</a>
    public class ArchiveModel : PageModel
    {
        public List<Archiveinfo> ArchiveList = new List<Archiveinfo>();

        private void MapArchiveInfo(SqlDataReader reader, Archiveinfo archive)
        {
            archive.QRCode = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
            archive.Rework = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
            archive.State_WS10 = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            archive.Time_In_WS10 = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
            archive.Time_Out_WS10 = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
            archive.Force_outil1 = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
            archive.Force_outil2 = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
            archive.Position_Outil1 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
            archive.Position_Outil2 = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            archive.Status_Code_WS10 = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
            //**************************************************************************
            archive.State_WS20 = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
            archive.Time_In_WS20 = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
            archive.Time_Out_WS20 = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
            archive.Orifice1_A = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
            archive.Orifice1_Nm = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
            archive.Orifice2_A = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
            archive.Orifice2_Nm = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
            archive.Orifice3_A = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
            archive.Orifice3_Nm = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
            archive.Capot_Nm = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
            archive.Capot_A = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);
            archive.Purge_Valve1_Nm = reader.IsDBNull(21) ? string.Empty : reader.GetString(21);
            archive.Purge_Valve1_A = reader.IsDBNull(22) ? string.Empty : reader.GetString(22);
            archive.Purge_Valve2_Nm = reader.IsDBNull(23) ? string.Empty : reader.GetString(23);
            archive.Purge_Valve2_A = reader.IsDBNull(24) ? string.Empty : reader.GetString(24);
            archive.Anti_Drain_Tube1_Nm = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);
            archive.Anti_Drain_Tube1_A = reader.IsDBNull(26) ? string.Empty : reader.GetString(26);
            archive.Anti_Drain_Tube2_Nm = reader.IsDBNull(27) ? string.Empty : reader.GetString(27);
            archive.Anti_Drain_Tube2_A = reader.IsDBNull(28) ? string.Empty : reader.GetString(28);
            archive.Pump_Nm = reader.IsDBNull(29) ? string.Empty : reader.GetString(29);
            archive.Pump_A = reader.IsDBNull(30) ? string.Empty : reader.GetString(30);
            archive.Capot_Valve_Nm = reader.IsDBNull(31) ? string.Empty : reader.GetString(31);
            archive.Capot_Valve_A = reader.IsDBNull(32) ? string.Empty : reader.GetString(32);
            archive.Status_Code_WS20 = reader.IsDBNull(33) ? 0 : reader.GetInt32(33);
            //************************************************************************************
            archive.State_WS30 = reader.IsDBNull(34) ? string.Empty : reader.GetString(34);
            archive.Time_In_WS30 = reader.IsDBNull(35) ? DateTime.MinValue : reader.GetDateTime(35);
            archive.Time_Out_WS30 = reader.IsDBNull(36) ? DateTime.MinValue : reader.GetDateTime(36);
            archive.Torque_Quick_Connector = reader.IsDBNull(37) ? string.Empty : reader.GetString(37);
            archive.Angle_Quick_Connector = reader.IsDBNull(38) ? string.Empty : reader.GetString(38);
            archive.Torque_CAP_1 = reader.IsDBNull(39) ? string.Empty : reader.GetString(39);
            archive.Angle_CAP_1 = reader.IsDBNull(40) ? string.Empty : reader.GetString(40);
            archive.Torque_CAP_2 = reader.IsDBNull(41) ? string.Empty : reader.GetString(41);
            archive.Angle_CAP_2 = reader.IsDBNull(42) ? string.Empty : reader.GetString(42);
            archive.Torque_Connector_2 = reader.IsDBNull(43) ? string.Empty : reader.GetString(43);
            archive.Angle_Connector_2 = reader.IsDBNull(44) ? string.Empty : reader.GetString(44);
            archive.Force_Therom_Valve = reader.IsDBNull(45) ? string.Empty : reader.GetString(45);
            archive.Statut_code_WS30 = reader.IsDBNull(46) ? 0 : reader.GetInt32(46);
            //*******************************************************************************************
            archive.State_WS40 = reader.IsDBNull(47) ? string.Empty : reader.GetString(47);
            archive.Time_In_WS40 = reader.IsDBNull(48) ? DateTime.MinValue : reader.GetDateTime(48);

            archive.Time_Out_WS40 = reader.IsDBNull(49) ? DateTime.MinValue : reader.GetDateTime(49);
            archive.Torque_Viss_1 = reader.IsDBNull(50) ? string.Empty : reader.GetString(50);
            archive.Angle_Viss_1 = reader.IsDBNull(51) ? string.Empty : reader.GetString(51);

            archive.Torque_Viss_2 = reader.IsDBNull(52) ? string.Empty : reader.GetString(52);
            archive.Angle_Viss_2 = reader.IsDBNull(53) ? string.Empty : reader.GetString(53);
            archive.Torque_Viss_3 = reader.IsDBNull(54) ? string.Empty : reader.GetString(54);
            archive.Angle_Viss_3 = reader.IsDBNull(55) ? string.Empty : reader.GetString(55);
            archive.Torque_WD_1 = reader.IsDBNull(56) ? string.Empty : reader.GetString(56);
            archive.Angle_WD_1 = reader.IsDBNull(57) ? string.Empty : reader.GetString(57);
            archive.Torque_WD_2 = reader.IsDBNull(58) ? string.Empty : reader.GetString(58);
            archive.Angle_WD_2 = reader.IsDBNull(59) ? string.Empty : reader.GetString(59);
            archive.Torque_WD_3 = reader.IsDBNull(60) ? string.Empty : reader.GetString(60);
            archive.Angle_WD_3 = reader.IsDBNull(61) ? string.Empty : reader.GetString(61);
            archive.Angle_Bush1 = reader.IsDBNull(62) ? string.Empty : reader.GetString(62);
            archive.Torque_Bush1 = reader.IsDBNull(63) ? string.Empty : reader.GetString(63);
            archive.Torque_Bush2 = reader.IsDBNull(64) ? string.Empty : reader.GetString(64);
            archive.Angle_Bush2 = reader.IsDBNull(65) ? string.Empty : reader.GetString(65);
            archive.Torque_Drain = reader.IsDBNull(66) ? string.Empty : reader.GetString(66);
            archive.Angle_Drain = reader.IsDBNull(67) ? string.Empty : reader.GetString(67);
            archive.Status_code_WS40 = reader.IsDBNull(68) ? 0 : reader.GetInt32(68);
            archive.State_WS50 = reader.IsDBNull(69) ? string.Empty : reader.GetString(69);
            archive.Time_In_WS50 = reader.IsDBNull(70) ? DateTime.MinValue : reader.GetDateTime(70);

            archive.Time_Out_WS40 = reader.IsDBNull(71) ? DateTime.MinValue : reader.GetDateTime(71);

            archive.Pression_Inlet = reader.IsDBNull(72) ? 0 : reader.GetInt32(72);
            archive.Pression_Outlet = reader.IsDBNull(73) ? 0 : reader.GetInt32(73);
            archive.Status_Code_WS50 = reader.IsDBNull(74) ? 0 : reader.GetInt32(74);
            archive.State_WS60 = reader.IsDBNull(75) ? string.Empty : reader.GetString(75);

            archive.Time_In_WS60 = reader.IsDBNull(76) ? DateTime.MinValue : reader.GetDateTime(76);
            archive.Time_Out_WS60 = reader.IsDBNull(77) ? DateTime.MinValue : reader.GetDateTime(77);
            archive.Sensor_F28_Nm = reader.IsDBNull(78) ? string.Empty : reader.GetString(78);
            archive.Sensor_F28_A = reader.IsDBNull(79) ? string.Empty : reader.GetString(79);
            archive.Conector_F28_Nm = reader.IsDBNull(80) ? string.Empty : reader.GetString(80);

            archive.Conector_F28_A = reader.IsDBNull(81) ? string.Empty : reader.GetString(81);
            archive.Heater_Conector_F28_Nm = reader.IsDBNull(82) ? string.Empty : reader.GetString(82);
            archive.Heater_Conector_F28_A = reader.IsDBNull(83) ? string.Empty : reader.GetString(83);
            archive.Thread_Conector_F28_Nm = reader.IsDBNull(84) ? string.Empty : reader.GetString(84);
            archive.Thread_Conector_F28_A = reader.IsDBNull(85) ? string.Empty : reader.GetString(85);
            archive.Conector1_XC13_Nm = reader.IsDBNull(86) ? string.Empty : reader.GetString(86);
            archive.Conector1_XC13_A = reader.IsDBNull(87) ? string.Empty : reader.GetString(87);
            archive.Conector2_XC13_Nm = reader.IsDBNull(88) ? string.Empty : reader.GetString(88);
            archive.Conector2_XC13_A = reader.IsDBNull(89) ? string.Empty : reader.GetString(89);
            archive.Conector3_XC13_Nm = reader.IsDBNull(90) ? string.Empty : reader.GetString(90);
            archive.Conector3_XC13_A = reader.IsDBNull(91) ? string.Empty : reader.GetString(91);
            archive.Conector4_XC13_Nm = reader.IsDBNull(92) ? string.Empty : reader.GetString(92);
            archive.Conector4_XC13_A = reader.IsDBNull(93) ? string.Empty : reader.GetString(93);
            archive.Metal_Plug_XC13_Nm = reader.IsDBNull(94) ? string.Empty : reader.GetString(94);
            archive.Metal_Plug_XC13_A = reader.IsDBNull(95) ? string.Empty : reader.GetString(95);
            archive.P_Sensor_XC13_Nm = reader.IsDBNull(96) ? string.Empty : reader.GetString(96);
            archive.P_Sensor_XC13_A = reader.IsDBNull(97) ? string.Empty : reader.GetString(97);
            archive.P_and_T_Sensor_XC13_Nm = reader.IsDBNull(98) ? string.Empty : reader.GetString(98);
            archive.P_and_T_Sensor_XC13_A = reader.IsDBNull(99) ? string.Empty : reader.GetString(99);
            archive.Status_Code_WS60 = reader.IsDBNull(100) ? 0 : reader.GetInt32(100);

            archive.State_WS70 = reader.IsDBNull(101) ? string.Empty : reader.GetString(101);
            archive.Time_In_WS70 = reader.IsDBNull(102) ? DateTime.MinValue : reader.GetDateTime(102);
            archive.Time_Out_WS70 = reader.IsDBNull(103) ? DateTime.MinValue : reader.GetDateTime(103);
            archive.Pression_Pre_Filter = reader.IsDBNull(104) ? string.Empty : reader.GetString(104);
            archive.Pression_Filter = reader.IsDBNull(105) ? string.Empty : reader.GetString(105);
            archive.Status_code_WS70 = reader.IsDBNull(106) ? 0 : reader.GetInt32(106);

            archive.State_WS80 = reader.IsDBNull(107) ? string.Empty : reader.GetString(107);
            archive.Time_In_WS80 = reader.IsDBNull(108) ? DateTime.MinValue : reader.GetDateTime(108);
            archive.Time_Out_WS80 = reader.IsDBNull(109) ? DateTime.MinValue : reader.GetDateTime(109);
            archive.Temp_Sensor_Ohm_AG = reader.IsDBNull(110) ? string.Empty : reader.GetString(110);
            archive.Heater_Ohm_AG = reader.IsDBNull(111) ? string.Empty : reader.GetString(111);
            archive.Temp_Senso_Ohm_CE = reader.IsDBNull(112) ? string.Empty : reader.GetString(112);
            archive.P_T_sensor_XC13 = reader.IsDBNull(113) ? string.Empty : reader.GetString(113);
            archive.WD_TEMP_XC13 = reader.IsDBNull(114) ? string.Empty : reader.GetString(114);
            archive.WD_SOLENOID_XC13 = reader.IsDBNull(115) ? string.Empty : reader.GetString(115);
            archive.VOLTAGE_P_XC13 = reader.IsDBNull(116) ? string.Empty : reader.GetString(116);
            archive.VOLTAGE_P_T_XC13 = reader.IsDBNull(117) ? string.Empty : reader.GetString(117);
            archive.Status_code_WS80 = reader.IsDBNull(118) ? 0 : reader.GetInt32(118);
        }






    public void OnGet()
        {
            try
            {
                string query = "SELECT * FROM Table_Wiss";

                using (SqlConnection cn = new SqlConnection(@"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;"))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();


                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Archiveinfo archive = new Archiveinfo();
                                MapArchiveInfo(reader, archive);
                                ArchiveList.Add(archive);
                               
                            }
                        }
                    }
                   

                    cn.Close();
                    // Console.WriteLine("Données récupérées avec succès !");
                 

                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data from SQL: " + ex.Message);
            }
        }

        public IActionResult OnGetEdit(string QRCode)
        {
            return RedirectToPage("Archive/Edit", new { QRCode });

        }

        public async Task<IActionResult> OnPost(string filterBtn, string findBtn, string exportBtn)
        {
            if (!string.IsNullOrEmpty(findBtn))
            {
                string qrcode = Request.Form["qrcode"];
                if (!string.IsNullOrEmpty(qrcode))
                {
                    FindData(qrcode);
                }
            }
            else if (!string.IsNullOrEmpty(filterBtn) && filterBtn == "Apply Filter")
            {
                string fromDateStr = Request.Form["date1"];
                string toDateStr = Request.Form["date2"];
                string version = Request.Form["version"];

                if (DateTime.TryParse(fromDateStr, out DateTime fromDate) &&
                    DateTime.TryParse(toDateStr, out DateTime toDate))
                {
                    FilterData(fromDate, toDate, version);
                }
            }
            else if (!string.IsNullOrEmpty(exportBtn))
            {
                return await OnPostExportAsync(); 
            }

            return Page();
        }

        public async Task<IActionResult> OnPostExportAsync()
        {
            try
            {
                
                await FetchDataFromSQLAsync();

                if (ArchiveList.Count == 0)
                {
                    return BadRequest("No data available to export.");
                }

                using (var excelPackage = new ExcelPackage())
                {
                    var worksheet = excelPackage.Workbook.Worksheets.Add("Archive Data");

                   
                    int headerCol = 1;
                    foreach (var property in typeof(Archiveinfo).GetProperties())
                    {
                        worksheet.Cells[1, headerCol].Value = property.Name;
                        headerCol++;
                    }

                   
                    int dataRow = 2;
                    foreach (var archive in ArchiveList)
                    {
                        int dataCol = 1;
                        foreach (var property in typeof(Archiveinfo).GetProperties())
                        {
                            worksheet.Cells[dataRow, dataCol].Value = property.GetValue(archive);
                            dataCol++;
                        }
                        dataRow++;
                    }

                    MemoryStream stream = new MemoryStream();
                    await excelPackage.SaveAsAsync(stream); 
                    stream.Position = 0;

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ArchiveData.xlsx");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error exporting data: " + ex.Message);
            }
        }

        private async Task FetchDataFromSQLAsync()
        {
            ArchiveList.Clear(); 

            string query = "SELECT * FROM Table_Wiss";

            using (SqlConnection cn = new SqlConnection(@"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;"))
            {
                if (cn.State == ConnectionState.Closed)
                    await cn.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            
                            Archiveinfo archive = new Archiveinfo();

                            MapArchiveInfo(reader, archive);

                            ArchiveList.Add(archive);
                        }
                    }
                }

                cn.Close();
            }
        }

        private void FilterData(DateTime fromDate, DateTime toDate, string version)
        {
            try
            {
                string query = @"SELECT * FROM Table_Wiss WHERE Time_In_WS10 BETWEEN @FromDate AND @ToDate";

                
                if (version != "ALL")
                {
                    query += " AND LEFT(QRCode, 4) = @VersionPrefix";
                }

                using (SqlConnection cn = new SqlConnection(@"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;"))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);

                        // If version is not "ALL", set the VersionPrefix parameter
                        if (version != "ALL")
                        {
                            cmd.Parameters.AddWithValue("@VersionPrefix", version);
                        }

                        // Execute the query and populate ArchiveList
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            ArchiveList.Clear();
                            while (reader.Read())
                            {
                                Archiveinfo archive = new Archiveinfo();
                                archive.QRCode = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                                archive.Rework = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                archive.State_WS10 = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                archive.Time_In_WS10 = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                                archive.Time_Out_WS10 = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                                archive.Force_outil1 = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                                archive.Force_outil2 = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                                archive.Position_Outil1 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                                archive.Position_Outil2 = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                                archive.Status_Code_WS10 = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                                //**************************************************************************
                                archive.State_WS20 = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                                archive.Time_In_WS20 = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                                archive.Time_Out_WS20 = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                                archive.Orifice1_A = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                                archive.Orifice1_Nm = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                                archive.Orifice2_A = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
                                archive.Orifice2_Nm = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                                archive.Orifice3_A = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                                archive.Orifice3_Nm = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                                archive.Capot_Nm = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                                archive.Capot_A = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);
                                archive.Purge_Valve1_Nm = reader.IsDBNull(21) ? string.Empty : reader.GetString(21);
                                archive.Purge_Valve1_A = reader.IsDBNull(22) ? string.Empty : reader.GetString(22);
                                archive.Purge_Valve2_Nm = reader.IsDBNull(23) ? string.Empty : reader.GetString(23);
                                archive.Purge_Valve2_A = reader.IsDBNull(24) ? string.Empty : reader.GetString(24);
                                archive.Anti_Drain_Tube1_Nm = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);
                                archive.Anti_Drain_Tube1_A = reader.IsDBNull(26) ? string.Empty : reader.GetString(26);
                                archive.Anti_Drain_Tube2_Nm = reader.IsDBNull(27) ? string.Empty : reader.GetString(27);
                                archive.Anti_Drain_Tube2_A = reader.IsDBNull(28) ? string.Empty : reader.GetString(28);
                                archive.Pump_Nm = reader.IsDBNull(29) ? string.Empty : reader.GetString(29);
                                archive.Pump_A = reader.IsDBNull(30) ? string.Empty : reader.GetString(30);
                                archive.Capot_Valve_Nm = reader.IsDBNull(31) ? string.Empty : reader.GetString(31);
                                archive.Capot_Valve_A = reader.IsDBNull(32) ? string.Empty : reader.GetString(32);
                                archive.Status_Code_WS20 = reader.IsDBNull(33) ? 0 : reader.GetInt32(33);
                                //************************************************************************************
                                archive.State_WS30 = reader.IsDBNull(34) ? string.Empty : reader.GetString(34);
                                archive.Time_In_WS30 = reader.IsDBNull(35) ? DateTime.MinValue : reader.GetDateTime(35);
                                archive.Time_Out_WS30 = reader.IsDBNull(36) ? DateTime.MinValue : reader.GetDateTime(36);
                                archive.Torque_Quick_Connector = reader.IsDBNull(37) ? string.Empty : reader.GetString(37);
                                archive.Angle_Quick_Connector = reader.IsDBNull(38) ? string.Empty : reader.GetString(38);
                                archive.Torque_CAP_1 = reader.IsDBNull(39) ? string.Empty : reader.GetString(39);
                                archive.Angle_CAP_1 = reader.IsDBNull(40) ? string.Empty : reader.GetString(40);
                                archive.Torque_CAP_2 = reader.IsDBNull(41) ? string.Empty : reader.GetString(41);
                                archive.Angle_CAP_2 = reader.IsDBNull(42) ? string.Empty : reader.GetString(42);
                                archive.Torque_Connector_2 = reader.IsDBNull(43) ? string.Empty : reader.GetString(43);
                                archive.Angle_Connector_2 = reader.IsDBNull(44) ? string.Empty : reader.GetString(44);
                                archive.Force_Therom_Valve = reader.IsDBNull(45) ? string.Empty : reader.GetString(45);
                                archive.Statut_code_WS30 = reader.IsDBNull(46) ? 0 : reader.GetInt32(46);
                                //*******************************************************************************************
                                archive.State_WS40 = reader.IsDBNull(47) ? string.Empty : reader.GetString(47);
                                archive.Time_In_WS40 = reader.IsDBNull(48) ? DateTime.MinValue : reader.GetDateTime(48);

                                archive.Time_Out_WS40 = reader.IsDBNull(49) ? DateTime.MinValue : reader.GetDateTime(49);
                                archive.Torque_Viss_1 = reader.IsDBNull(50) ? string.Empty : reader.GetString(50);
                                archive.Angle_Viss_1 = reader.IsDBNull(51) ? string.Empty : reader.GetString(51);

                                archive.Torque_Viss_2 = reader.IsDBNull(52) ? string.Empty : reader.GetString(52);
                                archive.Angle_Viss_2 = reader.IsDBNull(53) ? string.Empty : reader.GetString(53);
                                archive.Torque_Viss_3 = reader.IsDBNull(54) ? string.Empty : reader.GetString(54);
                                archive.Angle_Viss_3 = reader.IsDBNull(55) ? string.Empty : reader.GetString(55);
                                archive.Torque_WD_1 = reader.IsDBNull(56) ? string.Empty : reader.GetString(56);
                                archive.Angle_WD_1 = reader.IsDBNull(57) ? string.Empty : reader.GetString(57);
                                archive.Torque_WD_2 = reader.IsDBNull(58) ? string.Empty : reader.GetString(58);
                                archive.Angle_WD_2 = reader.IsDBNull(59) ? string.Empty : reader.GetString(59);
                                archive.Torque_WD_3 = reader.IsDBNull(60) ? string.Empty : reader.GetString(60);
                                archive.Angle_WD_3 = reader.IsDBNull(61) ? string.Empty : reader.GetString(61);
                                archive.Angle_Bush1 = reader.IsDBNull(62) ? string.Empty : reader.GetString(62);
                                archive.Torque_Bush1 = reader.IsDBNull(63) ? string.Empty : reader.GetString(63);
                                archive.Torque_Bush2 = reader.IsDBNull(64) ? string.Empty : reader.GetString(64);
                                archive.Angle_Bush2 = reader.IsDBNull(65) ? string.Empty : reader.GetString(65);
                                archive.Torque_Drain = reader.IsDBNull(66) ? string.Empty : reader.GetString(66);
                                archive.Angle_Drain = reader.IsDBNull(67) ? string.Empty : reader.GetString(67);
                                archive.Status_code_WS40 = reader.IsDBNull(68) ? 0 : reader.GetInt32(68);
                                archive.State_WS50 = reader.IsDBNull(69) ? string.Empty : reader.GetString(69);
                                archive.Time_In_WS50 = reader.IsDBNull(70) ? DateTime.MinValue : reader.GetDateTime(70);

                                archive.Time_Out_WS40 = reader.IsDBNull(71) ? DateTime.MinValue : reader.GetDateTime(71);

                                archive.Pression_Inlet = reader.IsDBNull(72) ? 0 : reader.GetInt32(72);
                                archive.Pression_Outlet = reader.IsDBNull(73) ? 0 : reader.GetInt32(73);
                                archive.Status_Code_WS50 = reader.IsDBNull(74) ? 0 : reader.GetInt32(74);
                                archive.State_WS60 = reader.IsDBNull(75) ? string.Empty : reader.GetString(75);

                                archive.Time_In_WS60 = reader.IsDBNull(76) ? DateTime.MinValue : reader.GetDateTime(76);
                                archive.Time_Out_WS60 = reader.IsDBNull(77) ? DateTime.MinValue : reader.GetDateTime(77);
                                archive.Sensor_F28_Nm = reader.IsDBNull(78) ? string.Empty : reader.GetString(78);
                                archive.Sensor_F28_A = reader.IsDBNull(79) ? string.Empty : reader.GetString(79);
                                archive.Conector_F28_Nm = reader.IsDBNull(80) ? string.Empty : reader.GetString(80);

                                archive.Conector_F28_A = reader.IsDBNull(81) ? string.Empty : reader.GetString(81);
                                archive.Heater_Conector_F28_Nm = reader.IsDBNull(82) ? string.Empty : reader.GetString(82);
                                archive.Heater_Conector_F28_A = reader.IsDBNull(83) ? string.Empty : reader.GetString(83);
                                archive.Thread_Conector_F28_Nm = reader.IsDBNull(84) ? string.Empty : reader.GetString(84);
                                archive.Thread_Conector_F28_A = reader.IsDBNull(85) ? string.Empty : reader.GetString(85);
                                archive.Conector1_XC13_Nm = reader.IsDBNull(86) ? string.Empty : reader.GetString(86);
                                archive.Conector1_XC13_A = reader.IsDBNull(87) ? string.Empty : reader.GetString(87);
                                archive.Conector2_XC13_Nm = reader.IsDBNull(88) ? string.Empty : reader.GetString(88);
                                archive.Conector2_XC13_A = reader.IsDBNull(89) ? string.Empty : reader.GetString(89);
                                archive.Conector3_XC13_Nm = reader.IsDBNull(90) ? string.Empty : reader.GetString(90);
                                archive.Conector3_XC13_A = reader.IsDBNull(91) ? string.Empty : reader.GetString(91);
                                archive.Conector4_XC13_Nm = reader.IsDBNull(92) ? string.Empty : reader.GetString(92);
                                archive.Conector4_XC13_A = reader.IsDBNull(93) ? string.Empty : reader.GetString(93);
                                archive.Metal_Plug_XC13_Nm = reader.IsDBNull(94) ? string.Empty : reader.GetString(94);
                                archive.Metal_Plug_XC13_A = reader.IsDBNull(95) ? string.Empty : reader.GetString(95);
                                archive.P_Sensor_XC13_Nm = reader.IsDBNull(96) ? string.Empty : reader.GetString(96);
                                archive.P_Sensor_XC13_A = reader.IsDBNull(97) ? string.Empty : reader.GetString(97);
                                archive.P_and_T_Sensor_XC13_Nm = reader.IsDBNull(98) ? string.Empty : reader.GetString(98);
                                archive.P_and_T_Sensor_XC13_A = reader.IsDBNull(99) ? string.Empty : reader.GetString(99);
                                archive.Status_Code_WS60 = reader.IsDBNull(100) ? 0 : reader.GetInt32(100);

                                archive.State_WS70 = reader.IsDBNull(101) ? string.Empty : reader.GetString(101);
                                archive.Time_In_WS70 = reader.IsDBNull(102) ? DateTime.MinValue : reader.GetDateTime(102);
                                archive.Time_Out_WS70 = reader.IsDBNull(103) ? DateTime.MinValue : reader.GetDateTime(103);
                                archive.Pression_Pre_Filter = reader.IsDBNull(104) ? string.Empty : reader.GetString(104);
                                archive.Pression_Filter = reader.IsDBNull(105) ? string.Empty : reader.GetString(105);
                                archive.Status_code_WS70 = reader.IsDBNull(106) ? 0 : reader.GetInt32(106);

                                archive.State_WS80 = reader.IsDBNull(107) ? string.Empty : reader.GetString(107);
                                archive.Time_In_WS80 = reader.IsDBNull(108) ? DateTime.MinValue : reader.GetDateTime(108);
                                archive.Time_Out_WS80 = reader.IsDBNull(109) ? DateTime.MinValue : reader.GetDateTime(109);
                                archive.Temp_Sensor_Ohm_AG = reader.IsDBNull(110) ? string.Empty : reader.GetString(110);
                                archive.Heater_Ohm_AG = reader.IsDBNull(111) ? string.Empty : reader.GetString(111);
                                archive.Temp_Senso_Ohm_CE = reader.IsDBNull(112) ? string.Empty : reader.GetString(112);
                                archive.P_T_sensor_XC13 = reader.IsDBNull(113) ? string.Empty : reader.GetString(113);
                                archive.WD_TEMP_XC13 = reader.IsDBNull(114) ? string.Empty : reader.GetString(114);
                                archive.WD_SOLENOID_XC13 = reader.IsDBNull(115) ? string.Empty : reader.GetString(115);
                                archive.VOLTAGE_P_XC13 = reader.IsDBNull(116) ? string.Empty : reader.GetString(116);
                                archive.VOLTAGE_P_T_XC13 = reader.IsDBNull(117) ? string.Empty : reader.GetString(117);
                                archive.Status_code_WS80 = reader.IsDBNull(118) ? 0 : reader.GetInt32(118);
                                ArchiveList.Add(archive);
                            }
                        }
                    }


                    cn.Close();
                    // Console.WriteLine("Données récupérées avec succès !");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data from SQL: " + ex.Message);
            }
        }
        private void FindData(string qrcode)
        {
            try
            {
                string query = @"SELECT * FROM Table_Wiss WHERE QRCode = @qrcode";

              
                using (SqlConnection cn = new SqlConnection(@"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;"))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@qrcode", qrcode);
    
                        // Execute the query and populate ArchiveList
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            ArchiveList.Clear();
                            while (reader.Read())
                            {
                                Archiveinfo archive = new Archiveinfo();
                                archive.QRCode = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                                archive.Rework = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                archive.State_WS10 = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                                archive.Time_In_WS10 = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);
                                archive.Time_Out_WS10 = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
                                archive.Force_outil1 = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                                archive.Force_outil2 = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                                archive.Position_Outil1 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                                archive.Position_Outil2 = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                                archive.Status_Code_WS10 = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                                //**************************************************************************
                                archive.State_WS20 = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                                archive.Time_In_WS20 = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                                archive.Time_Out_WS20 = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                                archive.Orifice1_A = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                                archive.Orifice1_Nm = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                                archive.Orifice2_A = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
                                archive.Orifice2_Nm = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                                archive.Orifice3_A = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                                archive.Orifice3_Nm = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                                archive.Capot_Nm = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                                archive.Capot_A = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);
                                archive.Purge_Valve1_Nm = reader.IsDBNull(21) ? string.Empty : reader.GetString(21);
                                archive.Purge_Valve1_A = reader.IsDBNull(22) ? string.Empty : reader.GetString(22);
                                archive.Purge_Valve2_Nm = reader.IsDBNull(23) ? string.Empty : reader.GetString(23);
                                archive.Purge_Valve2_A = reader.IsDBNull(24) ? string.Empty : reader.GetString(24);
                                archive.Anti_Drain_Tube1_Nm = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);
                                archive.Anti_Drain_Tube1_A = reader.IsDBNull(26) ? string.Empty : reader.GetString(26);
                                archive.Anti_Drain_Tube2_Nm = reader.IsDBNull(27) ? string.Empty : reader.GetString(27);
                                archive.Anti_Drain_Tube2_A = reader.IsDBNull(28) ? string.Empty : reader.GetString(28);
                                archive.Pump_Nm = reader.IsDBNull(29) ? string.Empty : reader.GetString(29);
                                archive.Pump_A = reader.IsDBNull(30) ? string.Empty : reader.GetString(30);
                                archive.Capot_Valve_Nm = reader.IsDBNull(31) ? string.Empty : reader.GetString(31);
                                archive.Capot_Valve_A = reader.IsDBNull(32) ? string.Empty : reader.GetString(32);
                                archive.Status_Code_WS20 = reader.IsDBNull(33) ? 0 : reader.GetInt32(33);
                                //************************************************************************************
                                archive.State_WS30 = reader.IsDBNull(34) ? string.Empty : reader.GetString(34);
                                archive.Time_In_WS30 = reader.IsDBNull(35) ? DateTime.MinValue : reader.GetDateTime(35);
                                archive.Time_Out_WS30 = reader.IsDBNull(36) ? DateTime.MinValue : reader.GetDateTime(36);
                                archive.Torque_Quick_Connector = reader.IsDBNull(37) ? string.Empty : reader.GetString(37);
                                archive.Angle_Quick_Connector = reader.IsDBNull(38) ? string.Empty : reader.GetString(38);
                                archive.Torque_CAP_1 = reader.IsDBNull(39) ? string.Empty : reader.GetString(39);
                                archive.Angle_CAP_1 = reader.IsDBNull(40) ? string.Empty : reader.GetString(40);
                                archive.Torque_CAP_2 = reader.IsDBNull(41) ? string.Empty : reader.GetString(41);
                                archive.Angle_CAP_2 = reader.IsDBNull(42) ? string.Empty : reader.GetString(42);
                                archive.Torque_Connector_2 = reader.IsDBNull(43) ? string.Empty : reader.GetString(43);
                                archive.Angle_Connector_2 = reader.IsDBNull(44) ? string.Empty : reader.GetString(44);
                                archive.Force_Therom_Valve = reader.IsDBNull(45) ? string.Empty : reader.GetString(45);
                                archive.Statut_code_WS30 = reader.IsDBNull(46) ? 0 : reader.GetInt32(46);
                                //*******************************************************************************************
                                archive.State_WS40 = reader.IsDBNull(47) ? string.Empty : reader.GetString(47);
                                archive.Time_In_WS40 = reader.IsDBNull(48) ? DateTime.MinValue : reader.GetDateTime(48);

                                archive.Time_Out_WS40 = reader.IsDBNull(49) ? DateTime.MinValue : reader.GetDateTime(49);
                                archive.Torque_Viss_1 = reader.IsDBNull(50) ? string.Empty : reader.GetString(50);
                                archive.Angle_Viss_1 = reader.IsDBNull(51) ? string.Empty : reader.GetString(51);

                                archive.Torque_Viss_2 = reader.IsDBNull(52) ? string.Empty : reader.GetString(52);
                                archive.Angle_Viss_2 = reader.IsDBNull(53) ? string.Empty : reader.GetString(53);
                                archive.Torque_Viss_3 = reader.IsDBNull(54) ? string.Empty : reader.GetString(54);
                                archive.Angle_Viss_3 = reader.IsDBNull(55) ? string.Empty : reader.GetString(55);
                                archive.Torque_WD_1 = reader.IsDBNull(56) ? string.Empty : reader.GetString(56);
                                archive.Angle_WD_1 = reader.IsDBNull(57) ? string.Empty : reader.GetString(57);
                                archive.Torque_WD_2 = reader.IsDBNull(58) ? string.Empty : reader.GetString(58);
                                archive.Angle_WD_2 = reader.IsDBNull(59) ? string.Empty : reader.GetString(59);
                                archive.Torque_WD_3 = reader.IsDBNull(60) ? string.Empty : reader.GetString(60);
                                archive.Angle_WD_3 = reader.IsDBNull(61) ? string.Empty : reader.GetString(61);
                                archive.Angle_Bush1 = reader.IsDBNull(62) ? string.Empty : reader.GetString(62);
                                archive.Torque_Bush1 = reader.IsDBNull(63) ? string.Empty : reader.GetString(63);
                                archive.Torque_Bush2 = reader.IsDBNull(64) ? string.Empty : reader.GetString(64);
                                archive.Angle_Bush2 = reader.IsDBNull(65) ? string.Empty : reader.GetString(65);
                                archive.Torque_Drain = reader.IsDBNull(66) ? string.Empty : reader.GetString(66);
                                archive.Angle_Drain = reader.IsDBNull(67) ? string.Empty : reader.GetString(67);
                                archive.Status_code_WS40 = reader.IsDBNull(68) ? 0 : reader.GetInt32(68);
                                archive.State_WS50 = reader.IsDBNull(69) ? string.Empty : reader.GetString(69);
                                archive.Time_In_WS50 = reader.IsDBNull(70) ? DateTime.MinValue : reader.GetDateTime(70);

                                archive.Time_Out_WS40 = reader.IsDBNull(71) ? DateTime.MinValue : reader.GetDateTime(71);

                                archive.Pression_Inlet = reader.IsDBNull(72) ? 0 : reader.GetInt32(72);
                                archive.Pression_Outlet = reader.IsDBNull(73) ? 0 : reader.GetInt32(73);
                                archive.Status_Code_WS50 = reader.IsDBNull(74) ? 0 : reader.GetInt32(74);
                                archive.State_WS60 = reader.IsDBNull(75) ? string.Empty : reader.GetString(75);

                                archive.Time_In_WS60 = reader.IsDBNull(76) ? DateTime.MinValue : reader.GetDateTime(76);
                                archive.Time_Out_WS60 = reader.IsDBNull(77) ? DateTime.MinValue : reader.GetDateTime(77);
                                archive.Sensor_F28_Nm = reader.IsDBNull(78) ? string.Empty : reader.GetString(78);
                                archive.Sensor_F28_A = reader.IsDBNull(79) ? string.Empty : reader.GetString(79);
                                archive.Conector_F28_Nm = reader.IsDBNull(80) ? string.Empty : reader.GetString(80);

                                archive.Conector_F28_A = reader.IsDBNull(81) ? string.Empty : reader.GetString(81);
                                archive.Heater_Conector_F28_Nm = reader.IsDBNull(82) ? string.Empty : reader.GetString(82);
                                archive.Heater_Conector_F28_A = reader.IsDBNull(83) ? string.Empty : reader.GetString(83);
                                archive.Thread_Conector_F28_Nm = reader.IsDBNull(84) ? string.Empty : reader.GetString(84);
                                archive.Thread_Conector_F28_A = reader.IsDBNull(85) ? string.Empty : reader.GetString(85);
                                archive.Conector1_XC13_Nm = reader.IsDBNull(86) ? string.Empty : reader.GetString(86);
                                archive.Conector1_XC13_A = reader.IsDBNull(87) ? string.Empty : reader.GetString(87);
                                archive.Conector2_XC13_Nm = reader.IsDBNull(88) ? string.Empty : reader.GetString(88);
                                archive.Conector2_XC13_A = reader.IsDBNull(89) ? string.Empty : reader.GetString(89);
                                archive.Conector3_XC13_Nm = reader.IsDBNull(90) ? string.Empty : reader.GetString(90);
                                archive.Conector3_XC13_A = reader.IsDBNull(91) ? string.Empty : reader.GetString(91);
                                archive.Conector4_XC13_Nm = reader.IsDBNull(92) ? string.Empty : reader.GetString(92);
                                archive.Conector4_XC13_A = reader.IsDBNull(93) ? string.Empty : reader.GetString(93);
                                archive.Metal_Plug_XC13_Nm = reader.IsDBNull(94) ? string.Empty : reader.GetString(94);
                                archive.Metal_Plug_XC13_A = reader.IsDBNull(95) ? string.Empty : reader.GetString(95);
                                archive.P_Sensor_XC13_Nm = reader.IsDBNull(96) ? string.Empty : reader.GetString(96);
                                archive.P_Sensor_XC13_A = reader.IsDBNull(97) ? string.Empty : reader.GetString(97);
                                archive.P_and_T_Sensor_XC13_Nm = reader.IsDBNull(98) ? string.Empty : reader.GetString(98);
                                archive.P_and_T_Sensor_XC13_A = reader.IsDBNull(99) ? string.Empty : reader.GetString(99);
                                archive.Status_Code_WS60 = reader.IsDBNull(100) ? 0 : reader.GetInt32(100);

                                archive.State_WS70 = reader.IsDBNull(101) ? string.Empty : reader.GetString(101);
                                archive.Time_In_WS70 = reader.IsDBNull(102) ? DateTime.MinValue : reader.GetDateTime(102);
                                archive.Time_Out_WS70 = reader.IsDBNull(103) ? DateTime.MinValue : reader.GetDateTime(103);
                                archive.Pression_Pre_Filter = reader.IsDBNull(104) ? string.Empty : reader.GetString(104);
                                archive.Pression_Filter = reader.IsDBNull(105) ? string.Empty : reader.GetString(105);
                                archive.Status_code_WS70 = reader.IsDBNull(106) ? 0 : reader.GetInt32(106);

                                archive.State_WS80 = reader.IsDBNull(107) ? string.Empty : reader.GetString(107);
                                archive.Time_In_WS80 = reader.IsDBNull(108) ? DateTime.MinValue : reader.GetDateTime(108);
                                archive.Time_Out_WS80 = reader.IsDBNull(109) ? DateTime.MinValue : reader.GetDateTime(109);
                                archive.Temp_Sensor_Ohm_AG = reader.IsDBNull(110) ? string.Empty : reader.GetString(110);
                                archive.Heater_Ohm_AG = reader.IsDBNull(111) ? string.Empty : reader.GetString(111);
                                archive.Temp_Senso_Ohm_CE = reader.IsDBNull(112) ? string.Empty : reader.GetString(112);
                                archive.P_T_sensor_XC13 = reader.IsDBNull(113) ? string.Empty : reader.GetString(113);
                                archive.WD_TEMP_XC13 = reader.IsDBNull(114) ? string.Empty : reader.GetString(114);
                                archive.WD_SOLENOID_XC13 = reader.IsDBNull(115) ? string.Empty : reader.GetString(115);
                                archive.VOLTAGE_P_XC13 = reader.IsDBNull(116) ? string.Empty : reader.GetString(116);
                                archive.VOLTAGE_P_T_XC13 = reader.IsDBNull(117) ? string.Empty : reader.GetString(117);
                                archive.Status_code_WS80 = reader.IsDBNull(118) ? 0 : reader.GetInt32(118);
                                ArchiveList.Add(archive);
                            }
                        }
                    }


                    cn.Close();
                    // Console.WriteLine("Données récupérées avec succès !");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data from SQL: " + ex.Message);
            }
        }


    }
    public class Archiveinfo
    {
        public String QRCode { get; set; }
        public int Rework { get; set; }
        public String State_WS10 { get; set; }

        public DateTime Time_In_WS10 { get; set; }
        public DateTime Time_Out_WS10 { get; set; }

        public int Force_outil2 { get; set; }
        public int Force_outil1 { get; set; }

        public String Position_Outil1 { get; set; }
        public String Position_Outil2 { get; set; }

        public int Status_Code_WS10 { get; set; }

        public String State_WS20 { get; set; }
        public DateTime Time_In_WS20 { get; set; }
        public DateTime Time_Out_WS20 { get; set; }
        public String Orifice1_Nm { get; set; }
        public String Orifice1_A { get; set; }
        public String Orifice2_Nm { get; set; }
        public String Orifice2_A { get; set; }
        public String Orifice3_Nm { get; set; }
        public String Orifice3_A { get; set; }

        public String Capot_Nm { get; set; }
        public String Capot_A { get; set; }
        public String Purge_Valve1_Nm { get; set; }
        public String Purge_Valve1_A { get; set; }
        public String Purge_Valve2_Nm { get; set; }
        public String Purge_Valve2_A { get; set; }
        public String Anti_Drain_Tube1_Nm { get; set; }
        public String Anti_Drain_Tube1_A { get; set; }
        public String Anti_Drain_Tube2_Nm { get; set; }
        public String Anti_Drain_Tube2_A { get; set; }
        public String Pump_Nm { get; set; }
        public String Pump_A { get; set; }
        public String Capot_Valve_Nm { get; set; }
        public String Capot_Valve_A { get; set; }
        public int Status_Code_WS20 { get; set; }

        public String State_WS30 { get; set; }
                       
                
        public DateTime Time_In_WS30 { get; set; }
        public DateTime Time_Out_WS30 { get; set; }
        public String Torque_Quick_Connector { get; set; }
        public String Angle_Quick_Connector { get; set; }
        public String Torque_CAP_1 { get; set; }
        public String Angle_CAP_1 { get; set; }
        public String Torque_CAP_2 { get; set; }

        public String Angle_CAP_2 { get; set; }
        public String Torque_Connector_2 { get; set; }
        public String Angle_Connector_2 { get; set; }
        public String Force_Therom_Valve { get; set; }
        public int Statut_code_WS30 { get; set; }
        public String State_WS40 { get; set; }
        public DateTime Time_In_WS40 { get; set; }
        public DateTime Time_Out_WS40 { get; set; }
        public String Torque_Viss_1 { get; set; }
        public String Angle_Viss_1 { get; set; }

        public String Torque_Viss_2 { get; set; }
        public String Angle_Viss_2 { get; set; }
        public String Torque_Viss_3 { get; set; }
        public String Angle_Viss_3 { get; set; }
        public String Torque_WD_1 { get; set; }
        public String Angle_WD_1 { get; set; }
        public String Torque_WD_2 { get; set; }
        public String Angle_WD_2 { get; set; }
        public String Torque_WD_3 { get; set; }
        public String Angle_WD_3 { get; set; }
        public String Angle_Bush1 { get; set; }
        public String Torque_Bush1 { get; set; }
        public String Torque_Bush2 { get; set; }
        public String Angle_Bush2 { get; set; }
        public String Torque_Drain { get; set; }
        public String Angle_Drain { get; set; }
        public int Status_code_WS40 { get; set; }


        public String State_WS50 { get; set; }
        public DateTime Time_In_WS50 { get; set; }
        public DateTime Time_Out_WS50 { get; set; }
        public int Pression_Inlet { get; set; }
        public int Pression_Outlet { get; set; }
        public int Status_Code_WS50 { get; set; }
        public String State_WS60 { get; set; }


        public DateTime Time_In_WS60 { get; set; }
        public DateTime Time_Out_WS60 { get; set; }
        public String Sensor_F28_Nm { get; set; }
        public String Sensor_F28_A { get; set; }
        public String Conector_F28_Nm { get; set; }
        public String Conector_F28_A { get; set; }
        public String Heater_Conector_F28_Nm { get; set; }
        public String Heater_Conector_F28_A { get; set; }
        public String Thread_Conector_F28_Nm { get; set; }
        public String Thread_Conector_F28_A { get; set; }
        public String Conector1_XC13_Nm { get; set; }
        public String Conector1_XC13_A { get; set; }
        public String Conector2_XC13_Nm { get; set; }
        public String Conector2_XC13_A { get; set; }
        public String Conector3_XC13_Nm { get; set; }
        public String Conector3_XC13_A { get; set; }
        public String Conector4_XC13_Nm { get; set; }
        public String Conector4_XC13_A { get; set; }
        public String Metal_Plug_XC13_Nm { get; set; }
        public String Metal_Plug_XC13_A { get; set; }
        public String P_Sensor_XC13_Nm { get; set; }
        public String P_Sensor_XC13_A { get; set; }
        public String P_and_T_Sensor_XC13_Nm { get; set; }
        public String P_and_T_Sensor_XC13_A { get; set; }
        public int Status_Code_WS60 { get; set; }
        public String State_WS70 { get; set; }
        public DateTime Time_In_WS70 { get; set; }
        public DateTime Time_Out_WS70 { get; set; }
        public DateTime Time_In_WS80 { get; set; }
        public DateTime Time_Out_WS80 { get; set; }
        public String Pression_Pre_Filter { get; set; }
        public String Pression_Filter { get; set; }
        public int Status_code_WS70 { get; set; }

        public String State_WS80 { get; set; }
        public String Temp_Sensor_Ohm_AG { get; set; }
        public String Heater_Ohm_AG { get; set; }
        public String Temp_Senso_Ohm_CE { get; set; }
        public String P_T_sensor_XC13 {  get; set; }
        public String WD_TEMP_XC13 { get; set; }
        public String WD_SOLENOID_XC13 { get; set; }
        public String VOLTAGE_P_XC13 { get; set; } 
        public String VOLTAGE_P_T_XC13 { get; set; }
        public int Status_code_WS80 { get; set; }



    }


}
