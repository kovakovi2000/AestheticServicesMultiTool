using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace AestheticServicesMultiTool.Lib
{
    internal static class LocalSecurity
    {
        internal static bool IsVPNConnected()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface Interface in interfaces)
                {
                    if (Interface.OperationalStatus == OperationalStatus.Up)
                    {
                        if ((Interface.NetworkInterfaceType == NetworkInterfaceType.Ppp) && (Interface.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        internal static bool IsVirtualMachine()
        {
            using (var searcher = new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                using (var items = searcher.Get())
                {
                    foreach (var item in items)
                    {
                        string manufacturer = item["Manufacturer"].ToString().ToLower();
                        if ((manufacturer == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL"))
                            || manufacturer.Contains("vmware")
                            || item["Model"].ToString() == "VirtualBox")
                        {
                            return true;
                        }
                    }
                }
            }

            if (VirtualMachineDetector.Assert())
                return true;

            return false;
        }

        internal static class FingerPrint
        {
            private static string fingerPrint = string.Empty;
            private static bool success = true;
            internal static string Value(out bool success)
            {
                if (string.IsNullOrEmpty(fingerPrint))
                {
                    fingerPrint += IsEmpty(cpuId(), FingerPrint.success, out FingerPrint.success) + ";"; // CPU
                    fingerPrint += IsEmpty(cpu(), FingerPrint.success, out FingerPrint.success) + ";"; // CPU 2nd method
                    fingerPrint += IsEmpty(baseId(), FingerPrint.success, out FingerPrint.success) + ";"; // motherboard
                    fingerPrint += IsEmpty(motherboard(), FingerPrint.success, out FingerPrint.success) + ";"; // motherboard 2nd method
                    fingerPrint += IsEmpty(diskId(), FingerPrint.success, out FingerPrint.success) + ";"; // c drive
                    fingerPrint += IsEmpty(disk(), FingerPrint.success, out FingerPrint.success) + ";";  // c drive 2nd method
                    fingerPrint += IsEmpty(macId(), FingerPrint.success, out FingerPrint.success); //MAC
                }

                success = FingerPrint.success;

                return fingerPrint;
            }

            private static string IsEmpty(string input, bool NotEmpty, out bool OutNotEmpty)
            {
                if (NotEmpty == false || input == "")
                    OutNotEmpty = false;
                else
                    OutNotEmpty = true;

                return input;
            }

            #region Original Device ID Getting Code
            //Return a hardware identifier
            private static string identifier
            (string wmiClass, string wmiProperty, string wmiMustBeTrue)
            {
                string result = "";
                System.Management.ManagementClass mc =
            new System.Management.ManagementClass(wmiClass);
                System.Management.ManagementObjectCollection moc = mc.GetInstances();
                foreach (System.Management.ManagementObject mo in moc)
                {
                    if (mo[wmiMustBeTrue].ToString() == "True")
                    {
                        //Only get the first one
                        if (result == "")
                        {
                            try
                            {
                                result = mo[wmiProperty].ToString();
                                break;
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                return result;
            }
            //Return a hardware identifier
            private static string identifier(string wmiClass, string wmiProperty)
            {
                string result = "";
                System.Management.ManagementClass mc =
            new System.Management.ManagementClass(wmiClass);
                System.Management.ManagementObjectCollection moc = mc.GetInstances();
                foreach (System.Management.ManagementObject mo in moc)
                {
                    //Only get the first one
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
                return result;
            }
            private static string cpu()
            {
                ManagementObjectCollection mbsList = null;
                ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
                mbsList = mbs.Get();
                string id = "";
                foreach (ManagementObject mo in mbsList)
                {
                    id += mo["ProcessorID"].ToString();
                }
                return id;
            }

            private static string disk()
            {
                ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
                dsk.Get();
                return dsk["VolumeSerialNumber"].ToString();
            }

            private static string motherboard()
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();
                string serial = "";
                foreach (ManagementObject mo in moc)
                {
                    serial = (string)mo["SerialNumber"];
                }
                return serial;
            }
            private static string cpuId()
            {
                //Uses first CPU identifier available in order of preference
                //Don't get all identifiers, as it is very time consuming
                string retVal = identifier("Win32_Processor", "UniqueId");
                if (retVal == "") //If no UniqueID, use ProcessorID
                    retVal = identifier("Win32_Processor", "ProcessorId");

                return retVal;
            }
            //BIOS Identifier
            private static string biosId()
            {
                return 
                //  identifier("Win32_BIOS", "Manufacturer")
                //+ identifier("Win32_BIOS", "SMBIOSBIOSVersion")
                identifier("Win32_BIOS", "IdentificationCode")
                //+ identifier("Win32_BIOS", "SerialNumber")
                //+ identifier("Win32_BIOS", "ReleaseDate")
                //+ identifier("Win32_BIOS", "Version")
                ;
            }
            //Main physical hard drive ID
            private static string diskId()
            {
                return 
                    //identifier("Win32_DiskDrive", "Model")
                //+ identifier("Win32_DiskDrive", "Manufacturer")
                 identifier("Win32_DiskDrive", "Signature")
                //identifier("Win32_DiskDrive", "TotalHeads")
                ;
            }
            //Motherboard ID
            private static string baseId()
            {
                return 
                    //identifier("Win32_BaseBoard", "Model")
                //+ identifier("Win32_BaseBoard", "Manufacturer")
                //+ identifier("Win32_BaseBoard", "Name")
                 identifier("Win32_BaseBoard", "SerialNumber");
            }
            //Primary video controller ID
            private static string videoId()
            {
                return identifier("Win32_VideoController", "DriverVersion")
                + identifier("Win32_VideoController", "Name");
            }
            //First enabled network card ID
            private static string macId()
            {
                return identifier("Win32_NetworkAdapterConfiguration",
                    "MACAddress", "IPEnabled");
            }
            #endregion
        }
    }
}
