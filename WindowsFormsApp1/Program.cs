using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                      
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }

        static string GetInfo(ref string Textinfo)
        {
            // leer los datos actuales y mostrarlos
            Textinfo += "Recogiendo datos...\n";
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true) { Textinfo += "  Red conectada\n"; } else { Textinfo += "  Red NO conectada\n"; } // test interface
            string current_hostname = Dns.GetHostName(); // recoge nombre de equipo
            string current_IP = Dns.GetHostByName(current_hostname).AddressList[0].ToString(); // recoge IP
            // no funciona string current_nmsk = UnicastIPAddressInformation.IPv4Mask();
            string current_domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            // no funciona string current_gateway = System.Net.NetworkInformation.GatewayIPAddressInformationCollection;
            Textinfo += "  Hostname: " + current_hostname + "\n";
            Textinfo += "  IP: " + current_IP + "\n";
            //richTextBox1.Text += "  Netmask: " + current_netmask + "\n";
            //richTextBox1.Text += "  Gateway: "+current_gatewat+"\n";
            Textinfo += "  Domain: " + current_domain + "\n";
            return Textinfo;
            
        }
    }
}
