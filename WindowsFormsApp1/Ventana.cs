using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.IO.Compression;
using System.Management;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Xml;
using System.ServiceProcess;
using System.Xml.Linq;
using System.Reflection;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System.Configuration;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string version = "v2.0.r1", customer = "SONAE";
        public static string image_release = "SCO_R6_W10";
        public static string rangoIP = "";
        public static string Path = "C:\\scot\\logs";
        int flagerror = 0;
        string current_IP = "", current_hostname = "", current_domain = "", current_gateway = "", primerTramo ="";
        readonly string fmt = "00.##";
        int ultimoTramo = 0;    //ultimoTramo es la IP, el ultimo octeto
        string progFolder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);   //consigue la ruta de Program Files
        bool win64;  //true si es 64bits
        string winver;  //friendly OS name

        public static string keypassentered = "";
        int numLanes = 0;
        string str = "", store = "", lane = "", hostname = "", firstIp = "", ip = "", netmask = "255.255.255.0", gateway = "";
        string masterIp = "", filaUnicaIp = "";


        public static void CopiarRecurso(Assembly pAssembly, string pNombreRecurso, string pRuta)
        {
            using (Stream s = pAssembly.GetManifestResourceStream(pAssembly.GetName().Name + "." + pNombreRecurso))
            {
                if (s == null)
                {
                    throw new Exception("No se puede encontrar el recurso '" + pNombreRecurso + "'");
                }

                byte[] buffer = new byte[s.Length];
                s.Read(buffer, 0, buffer.Length);
                using (BinaryWriter sw = new BinaryWriter(File.Open(pRuta, FileMode.Create)))
                {
                    sw.Write(buffer);
                }
            }
        }

        private void checkBoxMaster_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxMaster.Checked) groupBoxMaster.Visible = false;
            else groupBoxMaster.Visible = true;
        }
        private void CheckBoxFilaUnica_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilaUnica.Checked) groupBoxFilaUnica.Visible = true;
            else groupBoxFilaUnica.Visible = false;
        }

        // Store - Only numeric characters
        private void TextBoxSTORE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        // Lane - Only numeric characters
        private void TextBoxSCO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void TextBoxSTORE_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSCO.Text.Length < 2) textBoxHOSTNAME.Text = "SCONCR-" + textBoxSTORE.Text + "-" + "0" + textBoxSCO.Text;
            else textBoxHOSTNAME.Text = "SCONCR-" + textBoxSTORE.Text + "-" + textBoxSCO.Text;
        }

        private void TextBoxSCO_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSCO.Text.Length < 2) textBoxHOSTNAME.Text = "SCONCR-" + textBoxSTORE.Text + "-" + "0" + textBoxSCO.Text;
            else textBoxHOSTNAME.Text = "SCONCR-" + textBoxSTORE.Text + "-" + textBoxSCO.Text;
        }

        // IP - Only numeric characters and '.'
        private void TextBoxIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
        }

        // NETMASK - Only numeric characters and '.'
        private void TextBoxNETMASK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
        }

        // GATEWAY - Only numeric characters and '.'
        private void TextBoxGATEWAY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
        }

        // IP MASTER - Only numeric characters and '.'
        private void TextBoxIPMaster_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
        }

        // NAME MASTER - Only numeric characters and '.'
        private void TextBoxNAmeMaster_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
        }

        // GATEWAY - Only numeric characters and '.'
        private void TextBoxFilaUnica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
        }

        string Textinfo = "";       //cuando GetInfo() pueda prescindir de esta variable, quitarla.

        public Form1()
        {
            InitializeComponent();
            groupBoxFilaUnica.Visible = false;
            this.Text = "Configurador SCO" + version;
            this.TopMost = true;                    // muéstralo en primer plano siempre  

            Addlog("Welcome!\n\nCollecting information...\n");

            win64 = Environment.Is64BitOperatingSystem;
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            winver = Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString();
            FileReg.GetHWinfo(false, out string manu, out string mod, out string SN, out string na);

            Addlog("\nInformación del equipo:\n");
            Addlog(" Manufacturer: " + manu + "\n");
            Addlog(" Model: " + mod + "\n");
            Addlog(" SN: " + SN + "\n");
            Addlog(" Name: " + na + "\n");
            if (win64) Addlog(" " + winver + " 64bits \n ");
            else Addlog(" " + winver + " 32bits \n");
            Addlog(" Ruta: " + progFolder + "\n");
            GetInfo(ref Textinfo);                  // leer los datos actuales y mostrarlos
            Addlog(Textinfo);
        }
        public void GetInfo(ref string Text)    // leer los datos actuales al iniciar el programa.
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            { Text += "  Red conectada\n"; }
            else { Text += "  Red NO conectada\n"; } // test interface
            current_hostname = Dns.GetHostName(); // recoge nombre de equipo
            current_IP = Dns.GetHostByName(current_hostname).AddressList[0].ToString(); // recoge IP

            if (NetworkManagement.GetGateway("Gigabit") == "")
            { current_gateway = NetworkManagement.GetGateway("Ethernet"); }
            else
            { current_gateway = NetworkManagement.GetGateway("Gigabit"); }         // recoge gateway
            current_domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;  // recoge dominio            

            Text += "  Hostname: " + current_hostname + "\n";
            Text += "  IP: " + current_IP + "\n";
            //Text += "  Netmask: " + current_netmask + "\n";            
            Text += "  Gateway: " + current_gateway + "\n";
            Text += "  Domain: " + current_domain + "\n";
        }

        public void ApplyConfig()    //aplica los parámetros
        {

            flagerror = (string.IsNullOrEmpty(textBoxSTORE.Text) ||
                string.IsNullOrEmpty(textBoxSCO.Text) ||
                string.IsNullOrEmpty(textBoxHOSTNAME.Text) ||
                string.IsNullOrEmpty(textBoxLanesStore.Text) ||
                string.IsNullOrEmpty(textBoxIpFirstLane.Text) ||
                string.IsNullOrEmpty(textBoxIP.Text) ||
                string.IsNullOrEmpty(textBoxNETMASK.Text) ||
                string.IsNullOrEmpty(textBoxGATEWAY.Text)) ? 1 : flagerror;

            // Checking store data (only numeric data)
            if (Regex.IsMatch(textBoxSTORE.Text, "  ^ [0-9]"))
            {
                Addlog("\nField Store only numeric data\n");
                flagerror = 1;
            }

            // Checking lane data (only numeric data)
            if (Regex.IsMatch(textBoxSCO.Text, "  ^ [0-9]"))
            {
                Addlog("\nField Lane only numeric data\n");
                flagerror = 1;
            }

            // Checking Lanes in store data (only numeric data)
            if (Regex.IsMatch(textBoxLanesStore.Text, "  ^ [0-9]"))
            {
                Addlog("\nField Store only numeric data\n");
                flagerror = 1;
            }

            // Checking fila unica data
            if (checkBoxFilaUnica.Checked && string.IsNullOrEmpty(textBoxFilaUnica.Text))
            {
                Addlog("\nYou have checked \'fila unica\' you must enter the server's IP.\n");
                flagerror = 1;
            }

            // Checking master data
            if (!checkBoxMaster.Checked)
            {
                if (string.IsNullOrEmpty(textBoxIPMaster.Text))
                {
                    Addlog("\nIt is necessary to fill in the data of the master machine.\n");
                    flagerror = 1;
                }
            }

            // Checking HW Type
            if (!cash.Checked && !cashLess.Checked && !ss90.Checked)
            {
                Addlog("\nYou must choose one in HW Type.\n");
                flagerror = 1;
            }

            if (flagerror == 1) { Addlog("***Incomplete data, cannot start.\n"); return; } //comprobar que está introducidos los datos necesarios. Sino, sal del método.

            //cerrar SCOT
            foreach (var process in Process.GetProcessesByName("CaddpopUpu")) { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("SCOTAppU")) { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("sscoui")) { process.Kill(); }
            foreach (var process in Process.GetProcessesByName("Launchpadnet")) { process.Kill(); }

            //************************************ APLICANDO CAMBIOS *************************************            
            SetDataForm();        //recoge los datos de los campos                   
            richTextBoxLog.BackColor = Color.LightGreen;
            Addlog("Variables preparadas: \n");
            Addlog("Store: " + store + "\n");
            Addlog("Pos: " + lane + "\n");
            Addlog("hostname " + hostname + "\n");
            Addlog("Ip :" + ip + "\n");
            Addlog("Netmask :" + netmask + "\n");
            Addlog("Gateway :" + gateway + "\n");
            Addlog("IP master :" + masterIp + "\n");
            Addlog("IP Fila unica :" + filaUnicaIp + "\n");

            Addlog("---------------\nAplicando configuración...\n");
            progressBar1.Value = 10;

            //*************GUARDANDO DATOS                    

            FileReg.FileRW(@"C:\scot\logs", "NCRConfigureImage.log", "[SCO: " + textBoxSCO.Text + "]", false, true);
            FileReg.FileRW(@"C:\scot\logs", "NCRConfigureImage.log", "\n____________________________INICIO CONFIG - " + DateTime.Now.ToString("MM / dd / yyyy h: mm tt") + "\n", false, true);

            //*************APLICANDO
            //HOSTNAME
            Addlog("Asignando nuevo nombre de máquina...\n");

            System.Threading.Thread.Sleep(500);

            FileReg.RegAdd("SYSTEM\\CurrentControlSet\\Control\\ComputerName", "ActiveComputerName", "ComputerName", textBoxHOSTNAME.Text);
            FileReg.RegAdd("SYSTEM\\CurrentControlSet\\Control\\ComputerName", "ComputerName", "ComputerName", textBoxHOSTNAME.Text);
            FileReg.RegAdd("SYSTEM\\CurrentControlSet\\Services\\Tcpip", "Parameters", "Hostname", textBoxHOSTNAME.Text);
            FileReg.RegAdd("SYSTEM\\CurrentControlSet\\Services\\Tcpip", "Parameters", "NV Hostname", textBoxHOSTNAME.Text);

            Addlog("Nuevo nombre de máquina: " + textBoxHOSTNAME.Text + "\n");

            progressBar1.Value = 20;

            //ASIGNAR IPv4 
            try
            {
                NetworkManagement.SetIP(ip, netmask, "vEthernet (VLAN Tagging Switch)");     //aplica la IP y máscara al adaptador que coincida con el nombre
                NetworkManagement.SetGateway(gateway, "vEthernet (VLAN Tagging Switch)");    //aplica la gateway
                Addlog("WLAN Actualizada" + "\n" + "IP: " + ip + "\n");
            }
            catch { Addlog("***ERROR: Ha fallado al aplicar algún parámetro IP\n"); }
            progressBar1.Value = 30;

            // Relleno a 3 dígitos el número de caja
            lane = RellenarCadena(lane, '0', 3, true);

            // CAMBIOS EN EL REGISTRO (CAJA, MASTER, SEGURIDAD, ETC..)
            int errreg = 0;
            if (win64)
            { //64bits
                errreg = (!Other.RAPreg("Software\\WOW6432Node\\NCR\\SCOT - ReportServer", "ObservedOptions", "StoreNumber", store)) ? 1 : errreg;   //id tienda
                errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\CurrentVersion", "SCOTAPP", "ClientName", ip)) ? 1 : errreg;
                if (checkBoxMaster.Checked)
                {
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\CurrentVersion\\SCOTAPP", "Reporting", "ReportServer", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\CurrentVersion\\SCOTAPP", "Reporting", "ReportServerName", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - CoreApplication", "ObservedOptions", "ServerName", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - CoreApplication", "ObservedOptions", "ReportServerName", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - CoreApplication", "ObservedOptions", "PersonalizationServer", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - CoreApplication", "ObservedOptions", "MessageBrokerIP", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\NCR\\SCOT - CoreApplication", "ObservedOptions", "MessageBrokerIP", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "CoreReportServer", "ReportServerName", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "CoreSecurityServer", "ServerName", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - Platform", "ObservedOptions", "SCOMaster", "Y")) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\NCR\\SCOT\\CurrentVersion\\SCOTAPP", "Reporting", "ReportServer", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\NCR\\SCOT\\CurrentVersion\\SCOTAPP", "Reporting", "ReportServer", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\NCR\\SCOT\\Installation", "CoreReportServer", "ReportServerName", ip)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SYSTEM\\CurrentControlSet\\Control\\Session Manager", "Environment", "MessageBrokerIP", ip)) ? 1 : errreg;
                }
                else
                {
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\CurrentVersion\\SCOTAPP", "Reporting", "ReportServer", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\CurrentVersion\\SCOTAPP", "Reporting", "ReportServerName", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - CoreApplication", "ObservedOptions", "ServerName", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - CoreApplication", "ObservedOptions", "ReportServerName", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - CoreApplication", "ObservedOptions", "PersonalizationServer", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - CoreApplication", "ObservedOptions", "MessageBrokerIP", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\NCR\\SCOT - CoreApplication", "ObservedOptions", "MessageBrokerIP", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "CoreReportServer", "ReportServerName", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "CoreSecurityServer", "ServerName", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\WOW6432Node\\NCR\\SCOT - Platform", "ObservedOptions", "SCOMaster", "N")) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\NCR\\SCOT\\CurrentVersion\\SCOTAPP", "Reporting", "ReportServer", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\NCR\\SCOT\\CurrentVersion\\SCOTAPP", "Reporting", "ReportServer", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SOFTWARE\\NCR\\SCOT\\Installation", "CoreReportServer", "ReportServerName", masterIp)) ? 1 : errreg;
                    errreg = (!Other.RAPreg("SYSTEM\\CurrentControlSet\\Control\\Session Manager", "Environment", "MessageBrokerIP", masterIp)) ? 1 : errreg;
                }
                string hexValue = null;
                int laneInt = Int32.Parse(lane);
                if (laneInt >=10)
                {
                    hexValue = laneInt.ToString("XX");
                }
                else
                {
                    hexValue = laneInt.ToString("X");
                }
                string hexTerminalID = "0x000000" + hexValue.ToString();
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\CurrentVersion", "SCOTTB", "TerminalNumber", lane);
                FileReg.RegAddDWORD("SOFTWARE\\WOW6432Node\\NCR", "SCOT", "TerminalIDNumber", hexTerminalID); //ojo, es DWORD
            }
            else
            { //32bits
                int laneInt = Int32.Parse(lane);

                string hexValue = laneInt.ToString("X");
                FileReg.RegAdd("SOFTWARE\\NCR\\SCOT\\CurrentVersion", "SCOTTB", "TerminalNumber", hexValue);

                string hexTerminalID = "0x000000" + hexValue.ToString();
                FileReg.RegAddDWORD("SOFTWARE\\NCR", "SCOT", "TerminalIDNumber", hexTerminalID); //ojo, es DWORD
            }

            if (errreg == 0) { Addlog("Registro modificado correctamente!\n"); } else { Addlog("***ERROR: Registro NO modificado.\n"); return; }
            progressBar1.Value = 40;

            // HW TYPE - Modificar si es Cash, Cashless o SS90

            if (cash.Checked)
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApp1.Resources.Config.CADDOptsCASH.000");
                FileStream fileStream = new FileStream("C:\\scot\\config\\CADDOpts.000", FileMode.Create);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();

                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApp1.Resources.Config.ScotoptsCash.000");
                fileStream = new FileStream("C:\\scot\\config\\Scotopts.000", FileMode.Create);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\DeviceManagerEx\\Devices\\Local\\Printer", "SCOTRec", "DefaultCharacterSet", "858");
                try
                {
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "StartADD.bat";
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occured, Run the command \"startadd.exe\" when you close the configurator: ");
                }
            }

            if (cashLess.Checked)
            {
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "CoinAcceptor", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "CreditDebitOnly", "Configure", "Yes");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "NoteCoinNote", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CashAcceptor", "ZT1000", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CashAcceptor", "ZT1000", "Order", "0");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CashChanger", "ScotCashChanger", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CashChanger", "ScotCashChanger", "Order", "0");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CoinAcceptor", "C435S", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CoinAcceptor", "C435S", "Order", "0");

                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApp1.Resources.Config.CADDOptsCASHLESS.000");
                FileStream fileStream = new FileStream("C:\\scot\\config\\CADDOpts.000", FileMode.Create);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();

                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApp1.Resources.Config.ScotoptsCashLess.000");
                fileStream = new FileStream("C:\\scot\\config\\Scotopts.000", FileMode.Create);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
                try
                {
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "StartADD.bat";
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occured, Run the command \"startadd.exe\" when you close the configurator: ");
                }
            }

            if (ss90.Checked)
            {
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "CoinAcceptor", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "CreditDebitOnly", "Configure", "Yes");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\SCOT\\Installation", "NoteCoinNote", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CashAcceptor", "ZT1000", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CashAcceptor", "ZT1000", "Order", "0");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CashChanger", "ScotCashChanger", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CashChanger", "ScotCashChanger", "Order", "0");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CoinAcceptor", "C435S", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\Device Manager\\Devices\\CoinAcceptor", "C435S", "Order", "0");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\DeviceManagerEx\\Devices\\Local\\Scale", "NCRScale.1", "Configure", "No");
                FileReg.RegAdd("SOFTWARE\\WOW6432Node\\NCR\\DeviceManagerEx\\Devices\\Local\\Scale", "NCRScale.1", "ThreadID", "0");

                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApp1.Resources.Config.CADDOptsSS90.000");
                FileStream fileStream = new FileStream("C:\\scot\\config\\CADDOpts.000", FileMode.Create);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();

                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WindowsFormsApp1.Resources.Config.ScotoptsSS90.000");
                fileStream = new FileStream("C:\\scot\\config\\Scotopts.000", FileMode.Create);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
                try
                {
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "StartADD.bat";
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occured, Run the command \"startadd.exe\" when you close the configurator: ");
                }
            }

            // CAJAS MASTER - Modificar ficheros de configuración ACTIVE MQ y Rap Server
            if (checkBoxMaster.Checked)
            {
                // Modificar RAPSERVERAMQ.EXE.CONFIG
                XDocument nodoRaiz = XDocument.Load(@"C:\scot\RapServer\config\RapServerAmq.exe.config", LoadOptions.None);
                IEnumerable<XElement> nodo = nodoRaiz.Descendants("setting");

                foreach (XElement ele in nodo)
                {
                    if (ele.Attribute("name").Value == "Host")
                    {
                        Console.WriteLine("Atributo del nodo setting: " + ele.Attribute("name").Value);
                        Console.WriteLine("Valor del nodo value: " + ele.Element("value").Value);
                        ele.Element("value").Value = ip;
                        nodoRaiz.Save(@"C:\scot\RapServer\config\RapServerAmq.exe.config");
                    }
                }

                var lineas = System.IO.File.ReadAllLines(@"C:\scot\RapServer\config\RapServerAmq.exe.config");
                System.Collections.Generic.List<string> nuevoArchivo = new System.Collections.Generic.List<string>();

                foreach (var linea in lineas)
                {
                    if (linea.Contains("<Lanes>"))
                    {
                        nuevoArchivo.Add(linea);
                        for (int i = 1; i <= numLanes; i++)
                        {
                            nuevoArchivo.Add("<add name = \"SCONCR-" + store + "-" + i.ToString(fmt) + "\" host = \"" + primerTramo + ultimoTramo + "\" groups = \"AllLanes\" />");
                            ultimoTramo++;
                        }
                    }
                    else
                    {
                        nuevoArchivo.Add(linea);
                    }
                }
                System.IO.File.WriteAllLines(@"C:\scot\RapServer\config\RapServerAmq.exe.config", nuevoArchivo);
                progressBar1.Value = 50;

                // Modificar RAPSERVEMQTTLOGGER.EXE.CONFIG
                nodoRaiz = XDocument.Load(@"C:\scot\RapServer\config\RapServerMqttLogger.exe.config", LoadOptions.None);
                nodo = nodoRaiz.Descendants("setting");

                foreach (XElement ele in nodo)
                {
                    if (ele.Attribute("name").Value == "Host")
                    {
                        Console.WriteLine("Atributo del nodo setting: " + ele.Attribute("name").Value);
                        Console.WriteLine("Valor del nodo value: " + ele.Element("value").Value);
                        ele.Element("value").Value = ip;
                        nodoRaiz.Save(@"C:\scot\RapServer\config\RapServerMqttLogger.exe.config");
                    }
                }
                progressBar1.Value = 60;
 
                // Modificar ACTIVEMQ.XML
                string path = (@"C:\scot\apache-activemq-5.16.4");
                if (!Directory.Exists(path)) UnistallActiveMQVersion();

                SetActiveMQConfig();

                progressBar1.Value = 70;
            }
            // CAMBIOS EN EL RCMCONFIG

            str = File.ReadAllText("C:\\scot\\config\\RCMConfig.000");
            str = str.Replace("LNXX", "LN" + lane);
            File.WriteAllText("C:\\scot\\config\\RCMConfig.000", str);

            // ALL LANES - Configuración fila única
            if (checkBoxFilaUnica.Checked)
            {
                str = File.ReadAllText("C:\\FilaUnicaCliente\\changeStatus_Busy.bat");
                str = str.Replace("WWW.XXX.YYY.ZZZ", filaUnicaIp);
                File.WriteAllText("C:\\FilaUnicaCliente\\changeStatus_Busy.bat", str);

                str = File.ReadAllText("C:\\FilaUnicaCliente\\changeStatus_Closed.bat");
                str = str.Replace("WWW.XXX.YYY.ZZZ", filaUnicaIp);
                File.WriteAllText("C:\\FilaUnicaCliente\\changeStatus_Closed.bat", str);

                str = File.ReadAllText("C:\\FilaUnicaCliente\\changeStatus_Free.bat");
                str = str.Replace("WWW.XXX.YYY.ZZZ", filaUnicaIp);
                File.WriteAllText("C:\\FilaUnicaCliente\\changeStatus_Free.bat", str);
            }
            progressBar1.Value = 80;
            // CAJA MASTER/ESCLAVAS - CONFIGURAR E INICIAR SERVICIOS

            string src = @"C:\install\PS\SSCOStoreServer.bat";
            string dest = @"C:\Users\scot\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\SSCOStoreServer.bat";

            if (checkBoxMaster.Checked)
            {
                Addlog("-----\nConfigurando servicios CAJA MASTER...\n");
                // Cambiar a modo auto
                int errauto = 0;

                if (!FileReg.Runcmdadmin("sc config \"ActiveMQ\" start= auto")) { Addlog("***ERROR: Habilitando ActiveMQ service.\n"); errauto = 1; };
                if (!FileReg.Runcmdadmin("sc config \"FLReportingImporter\" start= auto")) { Addlog("***ERROR: Habilitando FLReporting service.\n"); errauto = 1; };
                if (!FileReg.Runcmdadmin("sc config \"NCR RAP Service\" start= auto")) { Addlog("***ERROR: Habilitando NCR RAP Service service.\n"); errauto = 1; }
                if (!FileReg.Runcmdadmin("sc config \"SAServer\" start= auto")) { Addlog(" * **ERROR: Habilitando SAServer service.\n"); errauto = 1; }
                if (!FileReg.Runcmdadmin("sc config \"NCR-Webfront HQC Server Service\" start= auto")) { Addlog(" * **ERROR: Habilitando NCR-Webfront HQC Server Service service.\n"); errauto = 1; }
                if (!FileReg.Runcmdadmin("sc config \"NCR-WebFront HQC POS Service\" start= auto")) { Addlog(" * **ERROR: Habilitando NCR-WebFront HQC POS Service service.\n"); errauto = 1; }

                if (errauto == 0) { Addlog("Servicios caja MASTER configurados!\n"); } else { Addlog("***ERROR: Servicios NO configurados.\n"); return; }

                // Iniciar servicios
                int errena = 0;
                string prev = "", next = "";

                try
                {
                    if (File.Exists(dest)) Addlog("Programas de inicio ya existe.\n");
                    else
                    {
                        if (File.Exists(src))
                        {
                            FileInfo fi = new FileInfo(src);
                            fi.CopyTo(dest);
                            Addlog("Programas de inicio copiado.\n");
                        }
                        else
                        {
                            Addlog("***ERROR: No existe el programa de inicio en c:\\install\\PS.\n");
                            //errena = 1;
                        }
                    }
                }
                catch (Exception e)
                {
                    Addlog("***ERROR: Imposible copiar programas de inicio: {0}" + e.ToString());
                    // errena = 1;
                }
                try
                {
                    FileReg.Service_startstop("ActiveMQ", true, out prev, out next);
                    if (!next.Equals("Running") && !next.Equals("=Running")) errena = 1;
                    Addlog(">>Estado ActiveMQ: " + prev + next + "\n");
                }
                catch(Exception e)
                {
                    Addlog("***WARN: Iniciar servicio ActiveMQ manualmente" + e.ToString());
                }

                FileReg.Service_startstop("FLReportingImporter", true, out prev, out next);
                if (!next.Equals("Running") && !next.Equals("=Running")) errena = 1;
                Addlog(">>Estado FLReportingImporter: " + prev + next + "\n");

                FileReg.Service_startstop("NCR RAP Service", true, out prev, out next);
                if (!next.Equals("Running") && !next.Equals("=Running")) errena = 1;
                Addlog(">>Estado NCR RAP Service: " + prev + next + "\n");

                FileReg.Service_startstop("SAServer", true, out prev, out next);
                if (!next.Equals("Running") && !next.Equals("=Running")) errena = 0;        //cambio a 0 para que no falle si no arranca SAServer, ya lo hará en el reinicio.
                Addlog(">>Estado SAServer: " + prev + next + "\n");
 
                FileReg.Service_startstop("NCR-Webfront HQC Server Service", true, out prev, out next);
                if (!next.Equals("Running") && !next.Equals("=Running")) errena = 1;
                Addlog(">>Estado NCR-Webfront HQC Server Service: " + prev + next + "\n");

                FileReg.Service_startstop("NCR-WebFront HQC POS Service", true, out prev, out next);
                if (!next.Equals("Running") && !next.Equals("=Running")) errena = 1;
                Addlog(">>Estado NCR-WebFront HQC POS Service: " + prev + next + "\n");

                if (errena == 0) { Addlog("Servicios arrancados!\n"); } else { Addlog("***ERROR: Servicios NO arrancados.\n"); return; }
            }
            else
            {
                // Detener servicios

                int errena = 0;
                string prev = "", next = "";
 
                try
                {
                    File.Delete(dest);
                    if (File.Exists(dest))
                    {
                        Addlog("***ERROR: Imposible eliminar programas de inicio.\n");
                        errena= 1;
                    }
                    else
                    {
                        Addlog("Programas de inicio eliminado.\n");
                    }
                }
                catch (Exception e)
                {
                    Addlog("***ERROR: Imposible eliminar programas de inicio: {0}" + e.ToString());
                    errena = 1;
                }
                progressBar1.Value = 90;
                FileReg.Service_startstop("ActiveMQ", false, out prev, out next);
                if (!next.Equals("Stopped") && !next.Equals("=Stopped")) errena= 1;
                Addlog(">>Estado ActiveMQ: " + errena + prev + next + "\n");
                           //    FileReg.Service_startstop("FLReportingImporter", false, out prev, out next);
                if (!next.Equals("Stopped") && !next.Equals("=Stopped")) errena = 1;
                Addlog(">>Estado FLReport: " + errena + prev + next + "\n");

                FileReg.Service_startstop("NCR RAP Service", false, out prev, out next);
                if (!next.Equals("Stopped") && !next.Equals("=Stopped")) errena = 1;
                Addlog(">>Estado NCR RAP Service: " + errena + prev + next + "\n");

                FileReg.Service_startstop("SAServer", false, out prev, out next);
                if (!next.Equals("Stopped") && !next.Equals("=Stopped")) errena = 1;
                Addlog(">>Estado SAServer: " + errena  + prev + next + "\n");

                FileReg.Service_startstop("NCR-Webfront HQC Server Service", false, out prev, out next);
                if (!next.Equals("Stopped") && !next.Equals("=Stopped")) errena = 1;
                Addlog(">>Estado NCR-Webfront HQC Server Service: " + errena  + prev + next + "\n");

                FileReg.Service_startstop("NCR-WebFront HQC POS Service", true, out prev, out next);
                if (!next.Equals("Running") && !next.Equals("=Running")) errena = 1;
                Addlog(">>Estado NCR-WebFront HQC POS Service: " + prev + next + "\n");

                if (errena == 0) { Addlog("Servicios detenidos!\n"); } else { Addlog("***ERROR: Servicios NO detenidos.\n"); return; }

                // Desactivar servicios y activar WebFront POS

                int errauto = 0;
                if (!FileReg.Runcmdadmin("sc config \"ActiveMQ\" start= demand")) { Addlog("***ERROR: Deshabilitando ActiveMQ service.\n"); errauto = 1; };
                if (!FileReg.Runcmdadmin("sc config \"FLReportingImporter\" start= demand")) { Addlog("***ERROR: Deshabilitando FLReporting service.\n"); errauto = 1; };
                if (!FileReg.Runcmdadmin("sc config \"NCR RAP Service\" start= demand")) { Addlog("***ERROR: Deshabilitando NCR RAP Service service.\n"); errauto = 1; }
                if (!FileReg.Runcmdadmin("sc config \"SAServer\" start= demand")) { Addlog("***ERROR: Deshabilitando SAServer service.\n"); errauto = 1; }
                if (!FileReg.Runcmdadmin("sc config \"NCR-Webfront HQC Server Service\" start= demand")) { Addlog("***ERROR: Deshabilitando NCR-Webfront HQC Server Service service.\n"); errauto = 1; }
                if (!FileReg.Runcmdadmin("sc config \"NCR-WebFront HQC POS Service\" start= auto")) { Addlog(" * **ERROR: Habilitando NCR-WebFront HQC POS Service service.\n"); errauto = 1; }

                if (errauto == 0)
                {
                    Addlog("Servicios anulados!\n");
                    Addlog("Servicios caja ESCLAVA configurados!\n");
                }
                else
                {
                    Addlog("***ERROR: Servicios NO anulados.\n");
                    Addlog("***ERROR: Servicios NO configurados.\n");
                    return;
                }
            }

            progressBar1.Value = 100;

            //*********************************  FIN  **********************************

            FileReg.FileRW(@"C:\scot\logs", "NCRConfigureImage.log", richTextBoxLog.Text, false, true);
            FileReg.FileRW(@"C:\scot\logs", "NCRConfigureImage.log", "____________________________FIN CONFIG  " + DateTime.Now.ToString("MM/dd/yyyy h:mm tt"), false, true);

        } //********************* FIN DEL PROCESO. *************************************

        private void ButtonEXIT_Click(object sender, EventArgs e)
        {
            using (Exit exitform = new Exit())
            {
                DialogResult exitf = exitform.ShowDialog();
                if (exitf == DialogResult.OK)
                {
                    Process.Start("shutdown", "/r /t 0"); //reset
                }
            }
        }

        private void ButtonCONFIGURAR_Click(object sender, EventArgs e)
        {
            flagerror = 0;
            Addlog("Configurar? ");
            DialogResult result = MessageBox.Show("Make sure all the data is filled in. Do you want to proceed??", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.OK))
            {
                Addlog("SI\n");
                ApplyConfig();
            }
            else
            {
                Addlog("CANCELADO\n");
            }
        }

        private void ButtonACERCA_Click(object sender, EventArgs e)
        {
            using (Acerca acercade = new Acerca())
            {
                DialogResult dr = acercade.ShowDialog();

            }
        }       //abre el cuadro "Acerca de"

        private void ButtonOSK_Click(object sender, EventArgs e)            //abre el teclado en pantalla
        {
            Process.Start("osk.exe");   //si no muestra el teclado es que el compilador se ha puesto en 64bits. Hay que cambiarlo a 32bits para que funcione. (Propiedades del proyecto - Compilador - CPU 32bits)
        }

        public void Addlog(string txt)
        {   
            // Añade log en Pantalla
            richTextBoxLog.AppendText(txt);

            // Añade log en Fichero
            string nombre = "Configurador.txt";
            string cadena = "";

            cadena += DateTime.Now + " - " + txt + Environment.NewLine;

            StreamWriter sw = new StreamWriter(Path + "/" + nombre, true);
            sw.Write(cadena);
            sw.Close();
        }

        //muestra los parámetros avanzados o llama a autosetform.

        private void SetDataForm()    //configura todas las variables después de haber introducido los datos.
        {
            store = textBoxSTORE.Text;
            lane = textBoxSCO.Text;
            hostname = textBoxHOSTNAME.Text;
            numLanes = int.Parse(textBoxLanesStore.Text);
            firstIp = textBoxIpFirstLane.Text;
            int index = firstIp.LastIndexOf('.');
            primerTramo = firstIp.Substring(0, index + 1);
            ultimoTramo = int.Parse(firstIp.Substring(index + 1));
            ip = textBoxIP.Text;
            netmask = textBoxNETMASK.Text;
            gateway = textBoxGATEWAY.Text;
            masterIp = textBoxIPMaster.Text;
            filaUnicaIp = textBoxFilaUnica.Text;
        }

        private void UnistallActiveMQVersion() // Desinstala versión antigua y copia la nueva
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\scot\apache-activemq-5.17.2\bin\win32\UninstallService.bat");
            }

            catch (Exception e)
            {
                Addlog("***WARN: El servicio ActiveMQ ya estaba desinstalado: {0}" + e.ToString());
            }
            string extractionPath = @"c:\scot";//directorio a donde deseo mandar mis recursos.
            string zipFileActiveMQ = @".\apache-activemq-5.16.4.zip";

            if (!Directory.Exists(extractionPath))
            {
                Directory.CreateDirectory(extractionPath);
            }
            ZipFile.ExtractToDirectory(zipFileActiveMQ, extractionPath);
            
            try
            {
                System.Diagnostics.Process.Start(@"C:\scot\apache-activemq-5.16.4\bin\win32\InstallService.bat");
            }

            catch (Exception e)
            {
                Addlog("***ERROR: El servicio ActiveMQ no ha podido instalarse: {0}" + e.ToString());
            }
        }


        private void SetActiveMQConfig()    //Configura el fichero ActiveMQxml.
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\scot\apache-activemq-5.16.4\conf\activemq.xml");

            XmlNodeList xConectores = xDoc.GetElementsByTagName("transportConnectors");
            XmlNodeList xLista = ((XmlElement)xConectores[0]).GetElementsByTagName("transportConnector");

            foreach (XmlElement ele in xLista)
            {
                string xName = ele.GetAttribute("name");
                if (xName.Equals("openwire")) ele.SetAttribute("uri", "tcp://" + ip + ":6000?maximumConnections=1000&amp;wireFormat.maxFrameSize=104857600");
                if (xName.Equals("amqp")) ele.SetAttribute("uri", "amqp://" + ip + ":6001?maximumConnections=1000&amp;wireFormat.maxFrameSize=104857600");
                if (xName.Equals("stomp")) ele.SetAttribute("uri", "stomp://" + ip + ":61613?maximumConnections=1000&amp;wireFormat.maxFrameSize=104857600");
                if (xName.Equals("mqtt")) ele.SetAttribute("uri", "mqtt://" + ip + ":1883?maximumConnections=1000&amp;wireFormat.maxFrameSize=104857600");
                if (xName.Equals("ws")) ele.SetAttribute("uri", "ws://" + ip + ":61614?maximumConnections=1000&amp;wireFormat.maxFrameSize=104857600");
                xDoc.Save(@"C:\scot\apache-activemq-5.16.4\conf\activemq.xml");
            }
        }

        public string RellenarCadena(string cadenaARellenar, char caracterDeRelleno, int longitud, bool izquierda)
        {
            //dependiendo hacia donde queramos rellenar, es lo que devolvemos
            if (izquierda)
            {
                return cadenaARellenar.PadLeft(longitud, caracterDeRelleno);
            }
            else
            {
                return cadenaARellenar.PadRight(longitud, caracterDeRelleno);
            }
        }
    }

    public class NetworkManagement
    {
        public static void SetIP(string ip_address, string subnet_mask, string NIC)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if (objMO["Caption"].ToString().Contains(NIC))
                {
                    ManagementBaseObject newIP = objMO.GetMethodParameters("EnableStatic");

                    newIP["IPAddress"] = new string[] { ip_address };
                    newIP["SubnetMask"] = new string[] { subnet_mask };
                }
            }
        }
        public static void SetGateway(string gateway, string NIC)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if (objMO["Caption"].ToString().Contains(NIC))
                {
                    ManagementBaseObject newGateway =
                      objMO.GetMethodParameters("SetGateways");

                    newGateway["DefaultIPGateway"] = new string[] { gateway };
                    newGateway["GatewayCostMetric"] = new int[] { 1 };
                }
            }
        }

        public static int PrintInterfaceIndex(string adapterName)   //SIN USO me devuelve siempre 17, busque por la cadena o por el nombre completo.
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            Console.WriteLine("IPv4 interface information for {0}.{1}",
                          properties.HostName, properties.DomainName);


            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.Supports(NetworkInterfaceComponent.IPv4) == false)
                {
                    continue;
                }

                if (!adapter.Description.Contains(adapterName))
                {
                    continue;
                }
                Console.WriteLine(adapter.Description);
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPv4InterfaceProperties p = adapterProperties.GetIPv4Properties();
                if (p == null)
                {
                    Console.WriteLine("No information is available for this interface.");
                    continue;
                }
                Console.WriteLine("  Index : {0}", p.Index);
                return p.Index;
            }
            return 293;
        }

        public static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()    //SIN USO. no funciona como quiero.
        {
            var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                a => (a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

            /* var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                a => a.OperationalStatus == OperationalStatus.Up &&
                (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork")); */

            return Nic;
        }

        public static string GetGateway(string NIC)
        {
            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
                if (f.Description.Contains(NIC))
                    foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                        return d.Address.ToString();                                                   // recoge gateway
            return "";
        }
    }
    public class FileReg
    {
        public static bool FileCopy(string origin, string destination)
        {
            try
            {
                File.Copy(origin, destination, true);  //true=sobrescribir
                return true;
            }
            catch
            {
                return false;       //error en la copia
            }
        }
        public static bool WholeCopy(string sourcedir, string destinationdir)
        {
            // Create subdirectory structure in destination    
            foreach (string dir in System.IO.Directory.GetDirectories(sourcedir, "*", System.IO.SearchOption.AllDirectories))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(destinationdir, dir.Substring(sourcedir.Length + 1)));
                // substring is to remove destination_dir absolute pat.  Example  > C:\sources (and not C:\E:\sources)            
            }

            foreach (string file_name in System.IO.Directory.GetFiles(sourcedir, "*", System.IO.SearchOption.AllDirectories))
            {
                try
                {
                    System.IO.File.Copy(file_name, System.IO.Path.Combine(destinationdir, file_name.Substring(sourcedir.Length + 1)), true);
                }
                catch { return false; }
            }
            return true;        //si esto da problemas moverlo al final. Se carga antes para que si hay algún fallo en la copia no lo machaque.
        }
        public static bool FileCheck(string pathfile)
        {
            if (File.Exists(pathfile)) { return true; } else { return false; }
        }
        public static bool FileDelete(string pathfile)
        {
            if (File.Exists(pathfile)) { File.Delete(pathfile); return true; } else { return false; }
        }
        public static string FileRW(string path, string file, string add, bool READwrite, bool overwriteAPPEND)
        {
            if (!overwriteAPPEND)
                File.Delete(path + file);
            if (!READwrite && !File.Exists(path + file))
            {
                // Create a file to write to.
                if (!overwriteAPPEND)
                    using (StreamWriter sw = File.CreateText(path + file))
                    {
                        sw.WriteLine(add + "\n");
                        return "OK";
                    }
            }
            if (overwriteAPPEND)
                using (StreamWriter sw = File.AppendText(path + file))
                {
                    sw.WriteLine(add + "\n");
                    return "OK";
                }


            if (READwrite && File.Exists(path + file))
            {
                // Open the file to read from.
                string text = "";
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        text += s + "\n";
                    }
                }
                return text;
            }
            else { return "NOT EXIST"; }
        }   //Es para los logs y archivo de configuracion

        public static bool RegAdd(string cadenareg, string contenedor, string campo, string valor)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(cadenareg, true);
                RegistryKey newkey = key.CreateSubKey(contenedor, RegistryKeyPermissionCheck.ReadWriteSubTree);
                newkey.SetValue(campo, valor);
                newkey.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }   //HKLM
        public static bool RegAddDWORD(string cadenareg, string contenedor, string campo, string valor)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(cadenareg, true);
                RegistryKey newkey = key.CreateSubKey(contenedor, RegistryKeyPermissionCheck.ReadWriteSubTree);
                newkey.SetValue(campo, valor, RegistryValueKind.DWord);
                newkey.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }   //HKLM
        public static bool RegAddHex(string cadenareg, string contenedor, string campo, string valor)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(cadenareg, true);
                RegistryKey newkey = key.CreateSubKey(contenedor, RegistryKeyPermissionCheck.ReadWriteSubTree);
                newkey.SetValue(campo, valor, RegistryValueKind.Binary);
                newkey.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }   //HKLM. No vale, se utiliza byte[] y no string. Me lo llevo al main, sin uso
        public static bool RegDel(string rutareg, string campo)
        {
            try
            {
                using (RegistryKey expKey = Registry.LocalMachine.OpenSubKey(rutareg, writable: true))
                {
                    if (expKey != null) expKey.DeleteSubKeyTree(campo);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }   //HKLM.     En desuso.
        public static void ReplaceString(String filename, String search, String replace)
        {
            StreamReader sr = new StreamReader(filename);
            String[] rows = Regex.Split(sr.ReadToEnd(), "\r\n");
            sr.Close();

            StreamWriter sw = new StreamWriter(filename);
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Contains(search))
                {
                    rows[i] = rows[i].Replace(search, replace);
                }
                sw.WriteLine(rows[i]);
            }
            sw.Close();
        }  //no devuelve error.   En desuso.

        public static bool Runcmdadmin(string arguments)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/C " + arguments
                };
                process.StartInfo = startInfo;
                process.Start();
                return true;
            }
            catch { return false; }
        }

        public static bool Service_startstop(string servicename, bool start, out string prevstatus, out string statusnow)
        {

            ServiceController service = new ServiceController();
            service.ServiceName = servicename;

            prevstatus = service.Status.ToString();
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(10000); //timeout en milisegundos

                if (start == true)
                {
                    service.Refresh();
                    if (service.Status == ServiceControllerStatus.Stopped)
                    {
                        service.Start();
                        service.Refresh();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                        statusnow = service.Status.ToString();
                    }
                    else { statusnow = "=Running"; }
                }
                else
                {
                    service.Refresh();
                    if (service.Status == ServiceControllerStatus.Running)
                    {
                        service.Stop();
                        service.Refresh();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                        statusnow = service.Status.ToString();
                    }
                    else { statusnow = "=Stopped"; }
                }
                return true;
            }
            catch
            {
                statusnow = "Error";
                return false;
            }
        }
        public static bool GetHWinfo(bool moboBIOS, out string manufacturer, out string model, out string SN, out string Name)
        {
            manufacturer = model = SN = Name = "";
            // create management class object
            if (moboBIOS)
            {
                ManagementClass mc = new ManagementClass("Win32_BIOS");
                //collection to store all management objects
                ManagementObjectCollection moc = mc.GetInstances();
                if (moc.Count != 0)
                {
                    foreach (ManagementObject mo in mc.GetInstances())
                    {
                        // display general system information
                        manufacturer = mo["Manufacturer"].ToString();
                        SN = mo["SerialNumber"].ToString();
                        Name = mo["Name"].ToString();
                        model = mo["Version"].ToString();
                        return true;
                    }
                }
                return false;

            }
            else
            {
                ManagementClass mc = new ManagementClass("Win32_BaseBoard");
                ManagementObjectCollection moc = mc.GetInstances();
                if (moc.Count != 0)
                {
                    foreach (ManagementObject mo in mc.GetInstances())
                    {
                        // display general system information
                        manufacturer = mo["Manufacturer"].ToString();
                        //  model = mo["Model"].ToString();
                        SN = mo["SerialNumber"].ToString();
                        Name = mo["Name"].ToString();
                        return true;
                    }
                }
                return false;
            }
        }
    }
    public class Other
    {
        public static bool RAPreg(string ruta, string contenedor, string campo, string valor)
        {
            try
            {
                //RegistryKey key = Registry.LocalMachine.OpenSubKey(ruta, true);
                RegistryKey key = Registry.LocalMachine.OpenSubKey(ruta, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.WriteKey);
                RegistryKey newkey = key.CreateSubKey(contenedor, RegistryKeyPermissionCheck.ReadWriteSubTree);
                newkey.SetValue(campo, valor);
                newkey.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Algo fallo" + ruta + contenedor + campo + valor);
                return false;
            }
        }   //HKLM
    }
}