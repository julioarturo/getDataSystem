using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Management;
namespace dataSystem
{
    public class getDataSystem
    {
        public String getNamePC()
        {
            string NamePC = Environment.UserName;
            return NamePC;
        }

        public String getManufacturer()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    String Manufacturer = mo["Manufacturer"].ToString();
                    return Manufacturer;
                }
            }
            return "No se pudo obtener la marca ";
        }

        public String getModel()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    String Model = mo["Model"].ToString();
                    return Model;
                }
            }
            return "No se pudo obtener el modelo";
        }

        public String getnumberSerie()
        {
            ManagementClass mc = new ManagementClass("Win32_SystemEnclosure");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    String Model = mo["SerialNumber"].ToString();
                    return Model;
                }
            }
            return "No se pudo obtener el modelo";
        }

        public String getSOVersion()
        {
            ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    String SO = "Windows: " + mo["Version"].ToString();
                    return SO;
                }
            }
            return "No se pudo obtener el sistema operativo";
        }

        public String getRAM()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    String RAM = mo["TotalPhysicalMemory"].ToString();
                    return RAM;
                }
            }
            return "No se pudo obtener la ram";
        }

        public String getIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "No se pudo obtener la ip";
        }

        public String getHostName()
        {
            string domainNamePC = Environment.UserDomainName;
            return domainNamePC;

        }

        public String getSftwareInstall()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            foreach (ManagementObject mo in mos.Get())
            {
                string lista = "Nombre: " + mo["Name"].ToString() + "\n   Verion: " + mo["Version"] + "\n   Vendor: " + mo["Vendor"];
                return lista;
            }
            return "No se pudo obtener la lista de softwares";
        }

        public String getEspaceDis()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == "C:\\")
                {
                    long EspacioDisponible = drive.AvailableFreeSpace;
                    long EspacioDisponible2 = (EspacioDisponible / 1262485504);
                    return EspacioDisponible2.ToString() + "GB Aproximadamente";
                }
            }
            return "No se pudo obtner el espacio disponible";
        }
    }
}
