using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.Reflection.PortableExecutable;

namespace WebApplication2.Pages.Archive
{
    public class EditModel : PageModel
    {
        public Archiveinfo archiveinfo = new Archiveinfo();

        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
            string QRCode = Request.Query["QRCode"];

            try
            {
                string query = "SELECT * FROM Table_Wiss WHERE QRCode = @QRCode";

                using (SqlConnection cn = new SqlConnection(@"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@QRCode", QRCode);
                    cn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            archiveinfo.QRCode = reader.GetString(0);
                            archiveinfo.Rework = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            archiveinfo.State_WS10 = reader.GetString(2);
                            archiveinfo.Time_In_WS10 = reader.GetDateTime(3);
                            archiveinfo.Time_In_WS20 = reader.GetDateTime(4);
                            archiveinfo.Force_outil1 = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            archiveinfo.Force_outil2 = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                            archiveinfo.Position_Outil1 = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                            archiveinfo.Position_Outil2 = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                            archiveinfo.Status_Code_WS10 = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                            //**************************************************************************
                            archiveinfo.State_WS20 = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                            archiveinfo.Time_In_WS20 = reader.IsDBNull(11) ? DateTime.MinValue : reader.GetDateTime(11);
                            archiveinfo.Time_Out_WS20 = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12);
                            archiveinfo.Orifice1_A = reader.IsDBNull(13) ? string.Empty : reader.GetString(13);
                            archiveinfo.Orifice1_Nm = reader.IsDBNull(14) ? string.Empty : reader.GetString(14);
                            archiveinfo.Orifice2_A = reader.IsDBNull(15) ? string.Empty : reader.GetString(15);
                            archiveinfo.Orifice2_Nm = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                            archiveinfo.Orifice3_A = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                            archiveinfo.Orifice3_Nm = reader.IsDBNull(18) ? string.Empty : reader.GetString(18);
                            archiveinfo.Capot_Nm = reader.IsDBNull(19) ? string.Empty : reader.GetString(19);
                            archiveinfo.Capot_A = reader.IsDBNull(20) ? string.Empty : reader.GetString(20);
                            archiveinfo.Purge_Valve1_Nm = reader.IsDBNull(21) ? string.Empty : reader.GetString(21);
                            archiveinfo.Purge_Valve1_A = reader.IsDBNull(22) ? string.Empty : reader.GetString(22);
                            archiveinfo.Purge_Valve2_Nm = reader.IsDBNull(23) ? string.Empty : reader.GetString(23);
                            archiveinfo.Purge_Valve2_A = reader.IsDBNull(24) ? string.Empty : reader.GetString(24);
                            archiveinfo.Anti_Drain_Tube1_Nm = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);
                            archiveinfo.Anti_Drain_Tube1_A = reader.IsDBNull(26) ? string.Empty : reader.GetString(26);
                            archiveinfo.Anti_Drain_Tube2_Nm = reader.IsDBNull(27) ? string.Empty : reader.GetString(27);
                            archiveinfo.Anti_Drain_Tube2_A = reader.IsDBNull(28) ? string.Empty : reader.GetString(28);
                            archiveinfo.Pump_Nm = reader.IsDBNull(29) ? string.Empty : reader.GetString(29);
                            archiveinfo.Pump_A = reader.IsDBNull(30) ? string.Empty : reader.GetString(30);
                            archiveinfo.Capot_Valve_Nm = reader.IsDBNull(31) ? string.Empty : reader.GetString(31);
                            archiveinfo.Capot_Valve_A = reader.IsDBNull(32) ? string.Empty : reader.GetString(32);
                            archiveinfo.Status_Code_WS20 = reader.IsDBNull(33) ? 0 : reader.GetInt32(33);
                            //************************************************************************************
                            archiveinfo.State_WS30 = reader.IsDBNull(34) ? string.Empty : reader.GetString(34);
                            archiveinfo.Time_In_WS30 = reader.IsDBNull(35) ? DateTime.MinValue : reader.GetDateTime(35);
                            archiveinfo.Time_Out_WS30 = reader.IsDBNull(36) ? DateTime.MinValue : reader.GetDateTime(36);
                            archiveinfo.Torque_Quick_Connector = reader.IsDBNull(37) ? string.Empty : reader.GetString(37);
                            archiveinfo.Angle_Quick_Connector = reader.IsDBNull(38) ? string.Empty : reader.GetString(38);
                            archiveinfo.Torque_CAP_1 = reader.IsDBNull(39) ? string.Empty : reader.GetString(39);
                            archiveinfo.Angle_CAP_1 = reader.IsDBNull(40) ? string.Empty : reader.GetString(40);
                            archiveinfo.Torque_CAP_2 = reader.IsDBNull(41) ? string.Empty : reader.GetString(41);
                            archiveinfo.Angle_CAP_2 = reader.IsDBNull(42) ? string.Empty : reader.GetString(42);
                            archiveinfo.Torque_Connector_2 = reader.IsDBNull(43) ? string.Empty : reader.GetString(43);
                            archiveinfo.Angle_Connector_2 = reader.IsDBNull(44) ? string.Empty : reader.GetString(44);
                            archiveinfo.Force_Therom_Valve = reader.IsDBNull(45) ? string.Empty : reader.GetString(45);
                            archiveinfo.Statut_code_WS30 = reader.IsDBNull(46) ? 0 : reader.GetInt32(46);
                            //*******************************************************************************************
                            archiveinfo.State_WS40 = reader.IsDBNull(47) ? string.Empty : reader.GetString(47);
                            archiveinfo.Time_In_WS40 = reader.IsDBNull(48) ? DateTime.MinValue : reader.GetDateTime(48);

                            archiveinfo.Time_Out_WS40 = reader.IsDBNull(49) ? DateTime.MinValue : reader.GetDateTime(49);
                            archiveinfo.Torque_Viss_1 = reader.IsDBNull(50) ? string.Empty : reader.GetString(50);
                            archiveinfo.Angle_Viss_1 = reader.IsDBNull(51) ? string.Empty : reader.GetString(51);

                            archiveinfo.Torque_Viss_2 = reader.IsDBNull(52) ? string.Empty : reader.GetString(52);
                            archiveinfo.Angle_Viss_2 = reader.IsDBNull(53) ? string.Empty : reader.GetString(53);
                            archiveinfo.Torque_Viss_3 = reader.IsDBNull(54) ? string.Empty : reader.GetString(54);
                            archiveinfo.Angle_Viss_3 = reader.IsDBNull(55) ? string.Empty : reader.GetString(55);
                            archiveinfo.Torque_WD_1 = reader.IsDBNull(56) ? string.Empty : reader.GetString(56);
                            archiveinfo.Angle_WD_1 = reader.IsDBNull(57) ? string.Empty : reader.GetString(57);
                            archiveinfo.Torque_WD_2 = reader.IsDBNull(58) ? string.Empty : reader.GetString(58);
                            archiveinfo.Angle_WD_2 = reader.IsDBNull(59) ? string.Empty : reader.GetString(59);
                            archiveinfo.Torque_WD_3 = reader.IsDBNull(60) ? string.Empty : reader.GetString(60);
                            archiveinfo.Angle_WD_3 = reader.IsDBNull(61) ? string.Empty : reader.GetString(61);
                            archiveinfo.Angle_Bush1 = reader.IsDBNull(62) ? string.Empty : reader.GetString(62);
                            archiveinfo.Torque_Bush1 = reader.IsDBNull(63) ? string.Empty : reader.GetString(63);
                            archiveinfo.Torque_Bush2 = reader.IsDBNull(64) ? string.Empty : reader.GetString(64);
                            archiveinfo.Angle_Bush2 = reader.IsDBNull(65) ? string.Empty : reader.GetString(65);
                            archiveinfo.Torque_Drain = reader.IsDBNull(66) ? string.Empty : reader.GetString(66);
                            archiveinfo.Angle_Drain = reader.IsDBNull(67) ? string.Empty : reader.GetString(67);
                            archiveinfo.Status_code_WS40 = reader.IsDBNull(68) ? 0 : reader.GetInt32(68);
                            //***************************************************************************************
                            archiveinfo.State_WS50 = reader.IsDBNull(69) ? string.Empty : reader.GetString(69);
                            archiveinfo.Time_In_WS50 = reader.IsDBNull(70) ? DateTime.MinValue : reader.GetDateTime(70);

                            archiveinfo.Time_Out_WS50 = reader.IsDBNull(71) ? DateTime.MinValue : reader.GetDateTime(71);

                            archiveinfo.Pression_Inlet = reader.IsDBNull(72) ? 0 : reader.GetInt32(72);
                            archiveinfo.Pression_Outlet = reader.IsDBNull(73) ? 0 : reader.GetInt32(73);
                            archiveinfo.Status_Code_WS50 = reader.IsDBNull(74) ? 0 : reader.GetInt32(74);
                            //*******************************************************************************************
                            archiveinfo.State_WS60 = reader.IsDBNull(75) ? string.Empty : reader.GetString(75);

                            archiveinfo.Time_In_WS60 = reader.IsDBNull(76) ? DateTime.MinValue : reader.GetDateTime(76);
                            archiveinfo.Time_Out_WS60 = reader.IsDBNull(77) ? DateTime.MinValue : reader.GetDateTime(77);
                            archiveinfo.Sensor_F28_Nm = reader.IsDBNull(78) ? string.Empty : reader.GetString(78);
                            archiveinfo.Sensor_F28_A = reader.IsDBNull(79) ? string.Empty : reader.GetString(79);
                            archiveinfo.Conector_F28_Nm = reader.IsDBNull(80) ? string.Empty : reader.GetString(80);

                            archiveinfo.Conector_F28_A = reader.IsDBNull(81) ? string.Empty : reader.GetString(81);
                            archiveinfo.Heater_Conector_F28_Nm = reader.IsDBNull(82) ? string.Empty : reader.GetString(82);
                            archiveinfo.Heater_Conector_F28_A = reader.IsDBNull(83) ? string.Empty : reader.GetString(83);
                            archiveinfo.Thread_Conector_F28_Nm = reader.IsDBNull(84) ? string.Empty : reader.GetString(84);
                            archiveinfo.Thread_Conector_F28_A = reader.IsDBNull(85) ? string.Empty : reader.GetString(85);
                            archiveinfo.Conector1_XC13_Nm = reader.IsDBNull(86) ? string.Empty : reader.GetString(86);
                            archiveinfo.Conector1_XC13_A = reader.IsDBNull(87) ? string.Empty : reader.GetString(87);
                            archiveinfo.Conector2_XC13_Nm = reader.IsDBNull(88) ? string.Empty : reader.GetString(88);
                            archiveinfo.Conector2_XC13_A = reader.IsDBNull(89) ? string.Empty : reader.GetString(89);
                            archiveinfo.Conector3_XC13_Nm = reader.IsDBNull(90) ? string.Empty : reader.GetString(90);
                            archiveinfo.Conector3_XC13_A = reader.IsDBNull(91) ? string.Empty : reader.GetString(91);
                            archiveinfo.Conector4_XC13_Nm = reader.IsDBNull(92) ? string.Empty : reader.GetString(92);
                            archiveinfo.Conector4_XC13_A = reader.IsDBNull(93) ? string.Empty : reader.GetString(93);
                            archiveinfo.Metal_Plug_XC13_Nm = reader.IsDBNull(94) ? string.Empty : reader.GetString(94);
                            archiveinfo.Metal_Plug_XC13_A = reader.IsDBNull(95) ? string.Empty : reader.GetString(95);
                            archiveinfo.P_Sensor_XC13_Nm = reader.IsDBNull(96) ? string.Empty : reader.GetString(96);
                            archiveinfo.P_Sensor_XC13_A = reader.IsDBNull(97) ? string.Empty : reader.GetString(97);
                            archiveinfo.P_and_T_Sensor_XC13_Nm = reader.IsDBNull(98) ? string.Empty : reader.GetString(98);
                            archiveinfo.P_and_T_Sensor_XC13_A = reader.IsDBNull(99) ? string.Empty : reader.GetString(99);
                            archiveinfo.Status_Code_WS60 = reader.IsDBNull(100) ? 0 : reader.GetInt32(100);
                            //********************************************************************************************
                            archiveinfo.State_WS70 = reader.IsDBNull(101) ? string.Empty : reader.GetString(101);
                            archiveinfo.Time_In_WS70 = reader.IsDBNull(102) ? DateTime.MinValue : reader.GetDateTime(102);
                            archiveinfo.Time_Out_WS70 = reader.IsDBNull(103) ? DateTime.MinValue : reader.GetDateTime(103);
                            archiveinfo.Pression_Pre_Filter = reader.IsDBNull(104) ? string.Empty : reader.GetString(104);
                            archiveinfo.Pression_Filter = reader.IsDBNull(105) ? string.Empty : reader.GetString(105);
                            archiveinfo.Status_code_WS70 = reader.IsDBNull(106) ? 0 : reader.GetInt32(106);
                            //********************************************************************************************
                            archiveinfo.State_WS80 = reader.IsDBNull(107) ? string.Empty : reader.GetString(107);
                            archiveinfo.Time_In_WS80 = reader.IsDBNull(108) ? DateTime.MinValue : reader.GetDateTime(108);
                            archiveinfo.Time_Out_WS80 = reader.IsDBNull(109) ? DateTime.MinValue : reader.GetDateTime(109);
                            archiveinfo.Temp_Sensor_Ohm_AG = reader.IsDBNull(110) ? string.Empty : reader.GetString(110);
                            archiveinfo.Heater_Ohm_AG = reader.IsDBNull(111) ? string.Empty : reader.GetString(111);
                            archiveinfo.Temp_Senso_Ohm_CE = reader.IsDBNull(112) ? string.Empty : reader.GetString(112);
                            archiveinfo.P_T_sensor_XC13 = reader.IsDBNull(113) ? string.Empty : reader.GetString(113);
                            archiveinfo.WD_TEMP_XC13 = reader.IsDBNull(114) ? string.Empty : reader.GetString(114);
                            archiveinfo.WD_SOLENOID_XC13 = reader.IsDBNull(115) ? string.Empty : reader.GetString(115);
                            archiveinfo.VOLTAGE_P_XC13 = reader.IsDBNull(116) ? string.Empty : reader.GetString(116);
                            archiveinfo.VOLTAGE_P_T_XC13 = reader.IsDBNull(117) ? string.Empty : reader.GetString(117);
                            archiveinfo.Status_code_WS80 = reader.IsDBNull(118) ? 0 : reader.GetInt32(118);
                        }
                    }
                }

                successMessage = "Data retrieved successfully!";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            archiveinfo.QRCode = Request.Form["QRCode"];
            archiveinfo.State_WS10 = Request.Form["State_WS10"];
            archiveinfo.State_WS20 = Request.Form["State_WS20"];
            archiveinfo.State_WS30 = Request.Form["State_WS30"];
            archiveinfo.State_WS40 = Request.Form["State_WS40"];
            archiveinfo.State_WS50 = Request.Form["State_WS50"];
            archiveinfo.State_WS60 = Request.Form["State_WS60"];
            archiveinfo.State_WS70 = Request.Form["State_WS70"];
            archiveinfo.State_WS80 = Request.Form["State_WS80"];

          


            archiveinfo.Position_Outil1 = Request.Form["Position_Outil1"];
            archiveinfo.Position_Outil2 = Request.Form["Position_Outil2"];

    
            archiveinfo.Orifice1_A = Request.Form["Orifice1_A"];
            archiveinfo.Orifice1_Nm = Request.Form["Orifice1_Nm"];
            archiveinfo.Orifice2_A = Request.Form["Orifice2_A"];
            archiveinfo.Orifice2_Nm = Request.Form["Orifice2_Nm"];
            archiveinfo.Orifice3_A = Request.Form["Orifice3_A"];
            archiveinfo.Orifice3_Nm = Request.Form["Orifice3_Nm"];
            archiveinfo.Capot_Nm = Request.Form["Capot_Nm"];
            archiveinfo.Capot_A = Request.Form["Capot_A"];
            archiveinfo.Purge_Valve1_Nm = Request.Form["Purge_Valve1_Nm"];
            archiveinfo.Purge_Valve1_A = Request.Form["Purge_Valve1_A"];
            archiveinfo.Purge_Valve2_Nm = Request.Form["Purge_Valve2_Nm"];
            archiveinfo.Purge_Valve2_A = Request.Form["Purge_Valve2_A"];
            archiveinfo.Anti_Drain_Tube1_Nm = Request.Form["Anti_Drain_Tube1_Nm"];
            archiveinfo.Anti_Drain_Tube1_A = Request.Form["Anti_Drain_Tube1_A"];
            archiveinfo.Anti_Drain_Tube2_Nm = Request.Form["Anti_Drain_Tube2_Nm"];
            archiveinfo.Anti_Drain_Tube2_A = Request.Form["Anti_Drain_Tube2_A"];
            archiveinfo.Pump_Nm = Request.Form["Pump_Nm"];
            archiveinfo.Pump_A = Request.Form["Pump_A"];
            archiveinfo.Capot_Valve_Nm = Request.Form["Capot_Valve_Nm"];
            archiveinfo.Capot_Valve_A = Request.Form["Capot_Valve_A"];

         

            archiveinfo.Torque_Quick_Connector = Request.Form["Torque_Quick_Connector"];
            archiveinfo.Angle_Quick_Connector = Request.Form["Angle_Quick_Connector"];
            archiveinfo.Torque_CAP_1 = Request.Form["Torque_CAP_1"];
            archiveinfo.Angle_CAP_1 = Request.Form["Angle_CAP_1"];
            archiveinfo.Torque_CAP_2 = Request.Form["Torque_CAP_2"];
            archiveinfo.Angle_CAP_2 = Request.Form["Angle_CAP_2"];
            archiveinfo.Torque_Connector_2 = Request.Form["Torque_Connector_2"];
            archiveinfo.Angle_Connector_2 = Request.Form["Angle_Connector_2"];
            archiveinfo.Force_Therom_Valve = Request.Form["Force_Therom_Valve"];

            

            archiveinfo.Torque_Viss_1 = Request.Form["Torque_Viss_1"];
            archiveinfo.Angle_Viss_1 = Request.Form["Angle_Viss_1"];

            archiveinfo.Torque_Viss_2 = Request.Form["Torque_Viss_2"];
            archiveinfo.Angle_Viss_2 = Request.Form["Angle_Viss_2"];
            archiveinfo.Torque_Viss_3 = Request.Form["Torque_Viss_3"];
            archiveinfo.Angle_Viss_3 = Request.Form["Angle_Viss_3"];
            archiveinfo.Torque_WD_1 = Request.Form["Torque_WD_1"];
            archiveinfo.Angle_WD_1 = Request.Form["Angle_WD_1"];
            archiveinfo.Torque_WD_2 = Request.Form["Torque_WD_2"];
            archiveinfo.Angle_WD_2 = Request.Form["Angle_WD_2"];
            archiveinfo.Torque_WD_3 = Request.Form["Torque_WD_3"];
            archiveinfo.Angle_WD_3 = Request.Form["Angle_WD_3"];
            archiveinfo.Angle_Bush1 = Request.Form["Angle_Bush1"];
            archiveinfo.Torque_Bush1 = Request.Form["Torque_Bush1"];
            archiveinfo.Torque_Bush2 = Request.Form["Torque_Bush2"];
            archiveinfo.Angle_Bush2 = Request.Form["Angle_Bush2"];
            archiveinfo.Torque_Drain = Request.Form["Torque_Drain"];
            archiveinfo.Angle_Drain = Request.Form["Angle_Drain"];
         

            archiveinfo.Sensor_F28_Nm = Request.Form["Sensor_F28_Nm"];
            archiveinfo.Sensor_F28_A = Request.Form["Sensor_F28_A"];
            archiveinfo.Conector_F28_Nm = Request.Form["Conector_F28_Nm"];
            archiveinfo.Conector_F28_A = Request.Form["Conector_F28_A"];
            archiveinfo.Heater_Conector_F28_Nm = Request.Form["Heater_Conector_F28_Nm"];
            archiveinfo.Heater_Conector_F28_A = Request.Form["Heater_Conector_F28_A"];
            archiveinfo.Thread_Conector_F28_Nm = Request.Form["Thread_Conector_F28_Nm"];
            archiveinfo.Thread_Conector_F28_A = Request.Form["Thread_Conector_F28_A"];
            archiveinfo.Conector1_XC13_Nm = Request.Form["Conector1_XC13_Nm"];
            archiveinfo.Conector1_XC13_A = Request.Form["Conector1_XC13_A"];
            archiveinfo.Conector2_XC13_Nm = Request.Form["Conector2_XC13_Nm"];
            archiveinfo.Conector2_XC13_A = Request.Form["Conector2_XC13_A"];
            archiveinfo.Conector3_XC13_Nm = Request.Form["Conector3_XC13_Nm"];
            archiveinfo.Conector3_XC13_A = Request.Form["Conector3_XC13_A"];
            archiveinfo.Conector4_XC13_Nm = Request.Form["Conector4_XC13_Nm"];
            archiveinfo.Conector4_XC13_A = Request.Form["Conector4_XC13_A"];
            archiveinfo.Metal_Plug_XC13_Nm = Request.Form["Metal_Plug_XC13_Nm"];
            archiveinfo.Metal_Plug_XC13_A = Request.Form["Metal_Plug_XC13_A"];
            archiveinfo.P_Sensor_XC13_Nm = Request.Form["P_Sensor_XC13_Nm"];
            archiveinfo.P_Sensor_XC13_A = Request.Form["P_Sensor_XC13_A"];
            archiveinfo.P_and_T_Sensor_XC13_Nm = Request.Form["P_and_T_Sensor_XC13_Nm"];
            archiveinfo.P_and_T_Sensor_XC13_A = Request.Form["P_and_T_Sensor_XC13_A"];
        
      


            archiveinfo.Pression_Pre_Filter = Request.Form["Pression_Pre_Filter"];
            archiveinfo.Pression_Filter = Request.Form["Pression_Filter"];



            archiveinfo.Temp_Sensor_Ohm_AG = Request.Form["Temp_Sensor_Ohm_AG"];
            archiveinfo.Heater_Ohm_AG = Request.Form["Heater_Ohm_AG"];
            archiveinfo.Temp_Senso_Ohm_CE = Request.Form["Temp_Senso_Ohm_CE"];
            archiveinfo.P_T_sensor_XC13 = Request.Form["P_T_sensor_XC13"];
            archiveinfo.WD_TEMP_XC13 = Request.Form["WD_TEMP_XC13"];
            archiveinfo.WD_SOLENOID_XC13 = Request.Form["WD_SOLENOID_XC13"];
            archiveinfo.VOLTAGE_P_XC13 = Request.Form["VOLTAGE_P_XC13"];
            archiveinfo.VOLTAGE_P_T_XC13 = Request.Form["VOLTAGE_P_T_XC13"];


            //******************************************  TypeInt  ****************************************************************************
            string reworkValue = Request.Form["Rework"];
            if (!string.IsNullOrEmpty(reworkValue))
            {
                archiveinfo.Rework = int.Parse(reworkValue);
            }

            string Force_outil1_ = Request.Form["Force_outil1"];
            if (!string.IsNullOrEmpty(Force_outil1_))
            {
                archiveinfo.Force_outil1 = int.Parse(Force_outil1_);
            }

            string Force_outil22 = Request.Form["Force_outil2"];
            if (!string.IsNullOrEmpty(Force_outil22))
            {
                archiveinfo.Force_outil2 = int.Parse(Force_outil22);
            }
            string Status_Code_WS10_ = Request.Form["Status_Code_WS10"];
            if (!string.IsNullOrEmpty(Status_Code_WS10_))
            {
                archiveinfo.Status_Code_WS10 = int.Parse(Status_Code_WS10_);
            }

            string Status_Code_WS20_ = Request.Form["Status_Code_WS20"];
            if (!string.IsNullOrEmpty(Status_Code_WS20_))
            {
                archiveinfo.Status_Code_WS20 = int.Parse(Status_Code_WS20_);
            }
            string Status_Code_WS30_ = Request.Form["Statut_code_WS30"];
            if (!string.IsNullOrEmpty(Status_Code_WS30_))
            {
                archiveinfo.Statut_code_WS30 = int.Parse(Status_Code_WS30_);
            }
            string Status_Code_WS40_ = Request.Form["Status_code_WS40"];
            if (!string.IsNullOrEmpty(Status_Code_WS40_))
            {
                archiveinfo.Status_code_WS40 = int.Parse(Status_Code_WS40_);
            }
            string Status_Code_WS50_ = Request.Form["Status_Code_WS50"];
            if (!string.IsNullOrEmpty(Status_Code_WS50_))
            {
                archiveinfo.Status_Code_WS50 = int.Parse(Status_Code_WS50_);
            }

            string Status_Code_WS60_ = Request.Form["Status_Code_WS60"];
            if (!string.IsNullOrEmpty(Status_Code_WS60_))
            {
                archiveinfo.Status_Code_WS60 = int.Parse(Status_Code_WS60_);
            }


            string Status_Code_WS70_ = Request.Form["Status_code_WS70"];
            if (!string.IsNullOrEmpty(Status_Code_WS70_))
            {
                archiveinfo.Status_code_WS70 = int.Parse(Status_Code_WS70_);
            }

            string Status_Code_WS80_ = Request.Form["Status_code_WS80"];
            if (!string.IsNullOrEmpty(Status_Code_WS80_))
            {
                archiveinfo.Status_code_WS80 = int.Parse(Status_Code_WS80_);
            }

            string Pression_Inlet_ = Request.Form["Pression_Inlet"];
            if (!string.IsNullOrEmpty(Pression_Inlet_))
            {
                archiveinfo.Pression_Inlet = int.Parse(Pression_Inlet_);
            }
            string Pression_Outlet_ = Request.Form["Pression_Outlet"];
            if (!string.IsNullOrEmpty(Pression_Outlet_))
            {
                archiveinfo.Pression_Outlet = int.Parse(Pression_Outlet_);
            }

            //******************************************  DateTime  ****************************************************************************

            archiveinfo.Time_In_WS10 = DateTime.Parse(Request.Form["Time_In_WS10"]);
            archiveinfo.Time_Out_WS10 = DateTime.Parse(Request.Form["Time_Out_WS10"]);

            archiveinfo.Time_In_WS20 = DateTime.Parse(Request.Form["Time_In_WS20"]);
            archiveinfo.Time_Out_WS20 = DateTime.Parse(Request.Form["Time_Out_WS20"]);

            archiveinfo.Time_In_WS30 = DateTime.Parse(Request.Form["Time_In_WS30"]);
            archiveinfo.Time_Out_WS30 = DateTime.Parse(Request.Form["Time_Out_WS30"]);

            archiveinfo.Time_In_WS40 = DateTime.Parse(Request.Form["Time_In_WS40"]);
            archiveinfo.Time_Out_WS40 = DateTime.Parse(Request.Form["Time_Out_WS40"]);

            archiveinfo.Time_In_WS50 = DateTime.Parse(Request.Form["Time_In_WS50"]);
            archiveinfo.Time_Out_WS50 = DateTime.Parse(Request.Form["Time_Out_WS50"]);

            archiveinfo.Time_In_WS60 = DateTime.Parse(Request.Form["Time_In_WS60"]);
            archiveinfo.Time_Out_WS60 = DateTime.Parse(Request.Form["Time_Out_WS60"]);

            archiveinfo.Time_In_WS70 = DateTime.Parse(Request.Form["Time_In_WS70"]);
            archiveinfo.Time_Out_WS70 = DateTime.Parse(Request.Form["Time_Out_WS70"]);

            archiveinfo.Time_In_WS80 = DateTime.Parse(Request.Form["Time_In_WS80"]);
            archiveinfo.Time_Out_WS80 = DateTime.Parse(Request.Form["Time_Out_WS80"]);



            //************************************************************************************************************************************************
            try
            {

                    string query = "UPDATE Table_Wiss SET Rework = @Rework, Time_In_WS10 = @Time_In_WS10, Time_OUT_WS10 = @Time_Out_WS10, State_WS10 = @State_WS10,"+
            "Force_outil1 = @force1, Force_outil2 = @force2, Position_Outil1 = @position1, Position_Outil2 = @position2, " +
            "Status_Code_WS10 = @Status_Code , State_WS20 = @State_WS20, Time_In_WS20 = @Time_In_WS20, Time_Out_WS20 = @Time_Out_WS20, " +
            "Orifice1_Nm = @Orifice1_Nm, Orifice1_A = @Orifice1_A, Orifice2_Nm = @Orifice2_Nm, Orifice2_A = @Orifice2_A, " +
            "Orifice3_Nm = @Orifice3_Nm, Orifice3_A = @Orifice3_A, Capot_Nm = @Capot_Nm, Capot_A = @Capot_A, " +
            "Purge_Valve1_Nm = @Purge_Valve1_Nm, Purge_Valve1_A = @Purge_Valve1_A, Purge_Valve2_Nm = @Purge_Valve2_Nm, Purge_Valve2_A = @Purge_Valve2_A, " +
            "Anti_Drain_Tube1_Nm = @Anti_Drain_Tube1_Nm, Anti_Drain_Tube1_A = @Anti_Drain_Tube1_A, Anti_Drain_Tube2_Nm = @Anti_Drain_Tube2_Nm, Anti_Drain_Tube2_A = @Anti_Drain_Tube2_A, " +
            "Pump_Nm = @Pump_Nm, Pump_A = @Pump_A, Capot_Valve_Nm = @Capot_Valve_Nm, Capot_Valve_A = @Capot_Valve_A, " +
            " State_WS30 = @State_WS30, Time_In_WS30 = @Time_In_WS30, Time_Out_WS30 = @Time_Out_WS30, Torque_Quick_Connector = @Torque_Quick_Connector, Angle_Quick_Connector = @Angle_Quick_Connector, " +
            "Torque_CAP_1 = @Torque_CAP_1, Angle_CAP_1 = @Angle_CAP_1, Torque_CAP_2 = @Torque_CAP_2, Angle_CAP_2 = @Angle_CAP_2, " +
            "Torque_Connector_2 = @Torque_Connector_2, Angle_Connector_2 = @Angle_Connector_2, Force_Therom_Valve = @Force_Therom_Valve, Statut_code_WS30 = @Statut_code_WS30, " +
            "State_WS40 = @State_WS40, Time_In_WS40 = @Time_In_WS40, Time_Out_WS40 = @Time_Out_WS40, Torque_Viss_1 = @Torque_Viss_1, Angle_Viss_1 = @Angle_Viss_1, " +
            "Torque_Viss_2 = @Torque_Viss_2, Angle_Viss_2 = @Angle_Viss_2, Torque_Viss_3 = @Torque_Viss_3, Angle_Viss_3 = @Angle_Viss_3, " +
            "Torque_WD_1 = @Torque_WD_1, Angle_WD_1 = @Angle_WD_1, Torque_WD_2 = @Torque_WD_2, Angle_WD_2 = @Angle_WD_2, " +
            "Torque_WD_3 = @Torque_WD_3, Angle_WD_3 = @Angle_WD_3, Angle_Bush1 = @Angle_Bush1, Torque_Bush1 = @Torque_Bush1," +
            "Torque_Bush2 = @Torque_Bush2, Angle_Bush2 = @Angle_Bush2, Torque_Drain = @Torque_Drain, Angle_Drain = @Angle_Drain, " +
            "Status_code_WS40 = @Status_code_WS40," +
             "State_WS50 = @State_WS50, Time_In_WS50 = @Time_In_WS50, Time_Out_WS50 = @Time_Out_WS50, " +
            "Pression_Inlet = @Pression_Inlet, Pression_Outlet = @Pression_Outlet, Status_Code_WS50 = @Status_Code_WS50," +
            " State_WS60 = @State_WS60, " +
            "Time_In_WS60 = @Time_In_WS60, Time_Out_WS60 = @Time_Out_WS60, Sensor_F28_Nm = @Sensor_F28_Nm, Sensor_F28_A = @Sensor_F28_A, " +
            "Conector_F28_Nm = @Conector_F28_Nm, Conector_F28_A = @Conector_F28_A, Heater_Conector_F28_Nm = @Heater_Conector_F28_Nm, Heater_Conector_F28_A = @Heater_Conector_F28_A, " +
            "Thread_Conector_F28_Nm = @Thread_Conector_F28_Nm, Thread_Conector_F28_A = @Thread_Conector_F28_A, Conector1_XC13_Nm = @Conector1_XC13_Nm, Conector1_XC13_A = @Conector1_XC13_A, " +
            "Conector2_XC13_Nm = @Conector2_XC13_Nm, Conector2_XC13_A = @Conector2_XC13_A, Conector3_XC13_Nm = @Conector3_XC13_Nm, Conector3_XC13_A = @Conector3_XC13_A, " +
            "Conector4_XC13_Nm = @Conector4_XC13_Nm, Conector4_XC13_A = @Conector4_XC13_A, Metal_Plug_XC13_Nm = @Metal_Plug_XC13_Nm, Metal_Plug_XC13_A = @Metal_Plug_XC13_A, " +
            "P_Sensor_XC13_Nm = @P_Sensor_XC13_Nm, P_Sensor_XC13_A = @P_Sensor_XC13_A, P_and_T_Sensor_XC13_Nm = @P_and_T_Sensor_XC13_Nm, P_and_T_Sensor_XC13_A = @P_and_T_Sensor_XC13_A, " +
            "Status_Code_WS60 = @Status_Code_WS60, State_WS70 = @State_WS70, Time_In_WS70 = @Time_In_WS70, Time_Out_WS70 = @Time_Out_WS70, " +
            "Pression_Pre_Filter = @Pression_Pre_Filter, Pression_Filter = @Pression_Filter, Status_code_WS70 = @Status_code_WS70, State_WS80 = @State_WS80, " +
            "Time_In_WS80 = @Time_In_WS80, Time_Out_WS80 = @Time_Out_WS80, Temp_Sensor_Ohm_AG = @Temp_Sensor_Ohm_AG, Heater_Ohm_AG = @Heater_Ohm_AG, " +
            "Temp_Senso_Ohm_CE = @Temp_Senso_Ohm_CE, P_T_sensor_XC13 = @P_T_sensor_XC13, WD_TEMP_XC13 = @WD_TEMP_XC13, WD_SOLENOID_XC13 = @WD_SOLENOID_XC13, " +
            "VOLTAGE_P_XC13 = @VOLTAGE_P_XC13, VOLTAGE_P_T_XC13 = @VOLTAGE_P_T_XC13, Status_code_WS80 = @Status_code_WS80, " +

            "Status_Code_WS20 = @Status_Code_WS20 WHERE QRCode = @QRCode";
         
                using (SqlConnection cn = new SqlConnection(@"Data Source=WISSAL\WINCC;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;"))
                
                
                using (SqlCommand command= new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@QRCode", archiveinfo.QRCode);
                    command.Parameters.AddWithValue("@State_WS10", archiveinfo.State_WS10);
                    command.Parameters.AddWithValue("@Rework", archiveinfo.Rework);
                    command.Parameters.AddWithValue("@Time_In_WS10", archiveinfo.Time_In_WS10);
                    command.Parameters.AddWithValue("@Time_Out_WS10", archiveinfo.Time_Out_WS10);
                    command.Parameters.AddWithValue("@force1", archiveinfo.Force_outil1);
                    command.Parameters.AddWithValue("@force2", archiveinfo.Force_outil1);
                    command.Parameters.AddWithValue("@position1", archiveinfo.Position_Outil1);
                    command.Parameters.AddWithValue("@position2", archiveinfo.Position_Outil2);
                    command.Parameters.AddWithValue("@Status_Code", archiveinfo.Status_Code_WS10);
                    //*************** WS20 ******************************************************
                    command.Parameters.AddWithValue("@State_WS20", archiveinfo.State_WS20);
                    command.Parameters.AddWithValue("@Time_In_WS20", archiveinfo.Time_In_WS20);
                    command.Parameters.AddWithValue("@Time_Out_WS20", archiveinfo.Time_Out_WS20);
                    command.Parameters.AddWithValue("@Orifice1_Nm", archiveinfo.Orifice1_Nm);
                    command.Parameters.AddWithValue("@Orifice1_A", archiveinfo.Orifice1_A);
                    
                    command.Parameters.AddWithValue("@Orifice2_Nm", archiveinfo.Orifice2_Nm);
                    command.Parameters.AddWithValue("@Orifice2_A", archiveinfo.Orifice2_A);
                    command.Parameters.AddWithValue("@Orifice3_Nm", archiveinfo.Orifice3_Nm);
                    command.Parameters.AddWithValue("@Orifice3_A", archiveinfo.Orifice3_A);
                    command.Parameters.AddWithValue("@Capot_Nm", archiveinfo.Capot_Nm);
                    command.Parameters.AddWithValue("@Capot_A", archiveinfo.Capot_A);
                    command.Parameters.AddWithValue("@Purge_Valve1_Nm", archiveinfo.Purge_Valve1_Nm);
                    command.Parameters.AddWithValue("@Purge_Valve1_A", archiveinfo.Purge_Valve1_A);
                    command.Parameters.AddWithValue("@Purge_Valve2_Nm", archiveinfo.Purge_Valve2_Nm);
                    command.Parameters.AddWithValue("@Purge_Valve2_A", archiveinfo.Purge_Valve2_A);
                    command.Parameters.AddWithValue("@Anti_Drain_Tube1_Nm", archiveinfo.Anti_Drain_Tube1_Nm);
                    command.Parameters.AddWithValue("@Anti_Drain_Tube1_A", archiveinfo.Anti_Drain_Tube1_A);
                    command.Parameters.AddWithValue("@Anti_Drain_Tube2_Nm", archiveinfo.Anti_Drain_Tube2_Nm);
                    command.Parameters.AddWithValue("@Anti_Drain_Tube2_A", archiveinfo.Anti_Drain_Tube2_A);
                    command.Parameters.AddWithValue("@Pump_A", archiveinfo.Pump_A);
                    command.Parameters.AddWithValue("@Capot_Valve_Nm", archiveinfo.Capot_Valve_Nm);
                    command.Parameters.AddWithValue("@Pump_Nm", archiveinfo.Pump_Nm);
                    command.Parameters.AddWithValue("@Capot_Valve_A", archiveinfo.Capot_Valve_A);

                    command.Parameters.AddWithValue("@Status_Code_WS20", archiveinfo.Status_Code_WS20);

                    //**************************************************************************
                    command.Parameters.AddWithValue("@State_WS30", archiveinfo.State_WS30);
                    command.Parameters.AddWithValue("@Time_In_WS30", archiveinfo.Time_In_WS30);
                    command.Parameters.AddWithValue("@Time_Out_WS30", archiveinfo.Time_Out_WS30);
                    command.Parameters.AddWithValue("@Torque_Quick_Connector", archiveinfo.Torque_Quick_Connector);
                    command.Parameters.AddWithValue("@Angle_Quick_Connector", archiveinfo.Angle_Quick_Connector);
                    command.Parameters.AddWithValue("@Torque_CAP_1", archiveinfo.Torque_CAP_1);
                    command.Parameters.AddWithValue("@Angle_CAP_1", archiveinfo.Angle_CAP_1);
                    command.Parameters.AddWithValue("@Torque_CAP_2", archiveinfo.Torque_CAP_2);
                    command.Parameters.AddWithValue("@Angle_CAP_2", archiveinfo.Angle_CAP_2);
                    command.Parameters.AddWithValue("@Torque_Connector_2", archiveinfo.Torque_Connector_2);
                    command.Parameters.AddWithValue("@Angle_Connector_2", archiveinfo.Angle_Connector_2);
                    command.Parameters.AddWithValue("@Force_Therom_Valve", archiveinfo.Force_Therom_Valve);
                    command.Parameters.AddWithValue("@Statut_code_WS30", archiveinfo.Statut_code_WS30);

                    //********************
                    command.Parameters.AddWithValue("@State_WS40", archiveinfo.State_WS40);
                    command.Parameters.AddWithValue("@Time_In_WS40", archiveinfo.Time_In_WS40);
                    command.Parameters.AddWithValue("@Time_Out_WS40", archiveinfo.Time_Out_WS40);
                    command.Parameters.AddWithValue("@Torque_Viss_1", archiveinfo.Torque_Viss_1);
                    command.Parameters.AddWithValue("@Angle_Viss_1", archiveinfo.Angle_Viss_1);
                    command.Parameters.AddWithValue("@Torque_Viss_2", archiveinfo.Torque_Viss_2);
                    command.Parameters.AddWithValue("@Angle_Viss_2", archiveinfo.Angle_Viss_2);
                    command.Parameters.AddWithValue("@Torque_Viss_3", archiveinfo.Torque_Viss_3);
                    command.Parameters.AddWithValue("@Angle_Viss_3", archiveinfo.Angle_Viss_3);
                    command.Parameters.AddWithValue("@Torque_WD_1", archiveinfo.Torque_WD_1);
                    command.Parameters.AddWithValue("@Angle_WD_1", archiveinfo.Angle_WD_1);
                    command.Parameters.AddWithValue("@Torque_WD_2", archiveinfo.Torque_WD_2);
                    command.Parameters.AddWithValue("@Angle_WD_2", archiveinfo.Angle_WD_2);
                    command.Parameters.AddWithValue("@Torque_WD_3", archiveinfo.Torque_WD_3);
                    command.Parameters.AddWithValue("@Angle_WD_3", archiveinfo.Angle_WD_3);
                    command.Parameters.AddWithValue("@Angle_Bush1", archiveinfo.Angle_Bush1);
                    command.Parameters.AddWithValue("@Torque_Bush1", archiveinfo.Torque_Bush1);
                    command.Parameters.AddWithValue("@Torque_Bush2", archiveinfo.Torque_Bush2);
                    command.Parameters.AddWithValue("@Angle_Bush2", archiveinfo.Angle_Bush2);
                    command.Parameters.AddWithValue("@Torque_Drain", archiveinfo.Torque_Drain);
                    command.Parameters.AddWithValue("@Angle_Drain", archiveinfo.Angle_Drain);
                    //******************************************************
                    command.Parameters.AddWithValue("@Status_code_WS40", archiveinfo.Status_code_WS40);
                    command.Parameters.AddWithValue("@State_WS50", archiveinfo.State_WS50);
                    command.Parameters.AddWithValue("@Time_In_WS50", archiveinfo.Time_In_WS50);
                    command.Parameters.AddWithValue("@Time_Out_WS50", archiveinfo.Time_Out_WS50);
                    command.Parameters.AddWithValue("@Pression_Inlet", archiveinfo.Pression_Inlet);
                    command.Parameters.AddWithValue("@Pression_Outlet", archiveinfo.Pression_Outlet);
                    command.Parameters.AddWithValue("@Status_Code_WS50", archiveinfo.Status_Code_WS50);
                    //**********************************
                    command.Parameters.AddWithValue("@State_WS60", archiveinfo.State_WS60);
                    command.Parameters.AddWithValue("@Time_In_WS60", archiveinfo.Time_In_WS60);
                    command.Parameters.AddWithValue("@Time_Out_WS60", archiveinfo.Time_Out_WS60);
                    command.Parameters.AddWithValue("@Sensor_F28_Nm", archiveinfo.Sensor_F28_Nm);
                    command.Parameters.AddWithValue("@Sensor_F28_A", archiveinfo.Sensor_F28_A);
                    command.Parameters.AddWithValue("@Conector_F28_Nm", archiveinfo.Conector_F28_Nm);
                    command.Parameters.AddWithValue("@Conector_F28_A", archiveinfo.Conector_F28_A);
                    command.Parameters.AddWithValue("@Heater_Conector_F28_Nm", archiveinfo.Heater_Conector_F28_Nm);
                    command.Parameters.AddWithValue("@Heater_Conector_F28_A", archiveinfo.Heater_Conector_F28_A);
                    command.Parameters.AddWithValue("@Thread_Conector_F28_Nm", archiveinfo.Thread_Conector_F28_Nm);
                    command.Parameters.AddWithValue("@Thread_Conector_F28_A", archiveinfo.Thread_Conector_F28_A);
                    command.Parameters.AddWithValue("@Conector1_XC13_Nm", archiveinfo.Conector1_XC13_Nm);
                    command.Parameters.AddWithValue("@Conector1_XC13_A", archiveinfo.Conector1_XC13_A);
                    command.Parameters.AddWithValue("@Conector2_XC13_Nm", archiveinfo.Conector2_XC13_Nm);
                    command.Parameters.AddWithValue("@Conector2_XC13_A", archiveinfo.Conector2_XC13_A);
                    command.Parameters.AddWithValue("@Conector3_XC13_Nm", archiveinfo.Conector3_XC13_Nm);
                    command.Parameters.AddWithValue("@Conector3_XC13_A", archiveinfo.Conector3_XC13_A);
                    command.Parameters.AddWithValue("@Conector4_XC13_Nm", archiveinfo.Conector4_XC13_Nm);
                    command.Parameters.AddWithValue("@Conector4_XC13_A", archiveinfo.Conector4_XC13_A);
                    command.Parameters.AddWithValue("@Metal_Plug_XC13_Nm", archiveinfo.Metal_Plug_XC13_Nm);
                    command.Parameters.AddWithValue("@Metal_Plug_XC13_A", archiveinfo.Metal_Plug_XC13_A);
                    command.Parameters.AddWithValue("@P_Sensor_XC13_Nm", archiveinfo.P_Sensor_XC13_Nm);
                    command.Parameters.AddWithValue("@P_Sensor_XC13_A", archiveinfo.P_Sensor_XC13_A);
                    command.Parameters.AddWithValue("@P_and_T_Sensor_XC13_Nm", archiveinfo.P_and_T_Sensor_XC13_Nm);
                    command.Parameters.AddWithValue("@P_and_T_Sensor_XC13_A", archiveinfo.P_and_T_Sensor_XC13_A);
                    command.Parameters.AddWithValue("@Status_Code_WS60", archiveinfo.Status_Code_WS60);
                    //****************************************************************************************************
                    command.Parameters.AddWithValue("@State_WS70", archiveinfo.State_WS70);
                    command.Parameters.AddWithValue("@Time_In_WS70", archiveinfo.Time_In_WS70);
                    command.Parameters.AddWithValue("@Time_Out_WS70", archiveinfo.Time_Out_WS70);
                    command.Parameters.AddWithValue("@Pression_Pre_Filter", archiveinfo.Pression_Pre_Filter);
                    command.Parameters.AddWithValue("@Pression_Filter", archiveinfo.Pression_Filter);
                    command.Parameters.AddWithValue("@Status_code_WS70", archiveinfo.Status_code_WS70);
                    command.Parameters.AddWithValue("@State_WS80", archiveinfo.State_WS80);
                    //********************************************************************************************
                    command.Parameters.AddWithValue("@Time_In_WS80", archiveinfo.Time_In_WS80);
                    command.Parameters.AddWithValue("@Time_Out_WS80", archiveinfo.Time_Out_WS80);
                    command.Parameters.AddWithValue("@Temp_Sensor_Ohm_AG", archiveinfo.Temp_Sensor_Ohm_AG);
                    command.Parameters.AddWithValue("@Heater_Ohm_AG", archiveinfo.Heater_Ohm_AG);
                    command.Parameters.AddWithValue("@Temp_Senso_Ohm_CE", archiveinfo.Temp_Senso_Ohm_CE);
                    command.Parameters.AddWithValue("@P_T_sensor_XC13", archiveinfo.P_T_sensor_XC13);
                    command.Parameters.AddWithValue("@WD_TEMP_XC13", archiveinfo.WD_TEMP_XC13);
                    command.Parameters.AddWithValue("@WD_SOLENOID_XC13", archiveinfo.WD_SOLENOID_XC13);
                    command.Parameters.AddWithValue("@VOLTAGE_P_XC13", archiveinfo.VOLTAGE_P_XC13);
                    command.Parameters.AddWithValue("@VOLTAGE_P_T_XC13", archiveinfo.VOLTAGE_P_T_XC13);
                    command.Parameters.AddWithValue("@Status_code_WS80", archiveinfo.Status_code_WS80);

                    cn.Open();
                    command.ExecuteNonQuery();
                }

                successMessage = "Data updated successfully!";
               
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }


    }
}