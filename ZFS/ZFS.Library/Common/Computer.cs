using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.MqttClient.Common
{
    /// <summary>
    ///Computer 的摘要说明
    /// </summary>
    public class Computer
    {
        private string _CpuID;
        private string _MacAddress;
        private string _DiskID;
        private string _IpAddress;
        private string _LoginUserName;
        private string _ComputerName;
        private string _SystemType;
        private string _TotalPhysicalMemory; //单位：M 

        /// <summary>
        /// Cpu地址
        /// </summary>
        public string CpuID { get { return _CpuID; } }

        /// <summary>
        /// MAC地址
        /// </summary>
        public string MacAddress { get { return _MacAddress; } }

        /// <summary>
        /// 硬盘ID 
        /// </summary>
        public string DiskID { get { return _DiskID; } }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get { return _IpAddress; } }

        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        public string LoginUserName { get { return _LoginUserName; } }

        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        public string ComputerName { get { return _ComputerName; } }

        /// <summary>
        /// PC类型 
        /// </summary>
        public string SystemType { get { return _SystemType; } }

        /// <summary>
        /// 物理内存
        /// </summary>
        public string TotalPhysicalMemory { get { return _TotalPhysicalMemory; } }


        private static Computer _instance;
        public static Computer Instance()
        {
            if (_instance == null)
                _instance = new Computer();
            return _instance;
        }

        public Computer()
        {
            _CpuID = GetCpuID();
            _MacAddress = GetMacAddress();
            _DiskID = GetDiskID();
            _IpAddress = GetIPAddress();
            _LoginUserName = GetUserName();
            _SystemType = GetSystemType();
            _TotalPhysicalMemory = GetTotalPhysicalMemory();
            _ComputerName = GetComputerName();
        }

        /// <summary>
        /// 获取CPU序列号代码
        /// </summary>
        /// <returns></returns>
        private string GetCpuID()
        {
            try
            {
                string cpuInfo = "";
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }

        /// <summary>
        /// 获取网卡硬件地址 
        /// </summary>
        /// <returns></returns>
        private string GetMacAddress()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return mac;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }

        /// <summary>
        /// 获取IP地址 
        /// </summary>
        /// <returns></returns>
        private string GetIPAddress()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        //st=mo["IpAddress"].ToString(); 
                        System.Array ar;
                        ar = (System.Array)(mo.Properties["IpAddress"].Value);
                        st = ar.GetValue(0).ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }

        /// <summary>
        /// 获取硬盘ID 
        /// </summary>
        /// <returns></returns>
        private string GetDiskID()
        {
            try
            {
                String HDid = "";
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    HDid = (string)mo.Properties["Model"].Value;
                }
                moc = null;
                mc = null;
                return HDid;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }

        /// <summary> 
        /// 操作系统的登录用户名 
        /// </summary> 
        /// <returns></returns> 
        private string GetUserName()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    st = mo["UserName"].ToString();

                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }


        /// <summary> 
        /// PC类型 
        /// </summary> 
        /// <returns></returns> 
        private string GetSystemType()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    st = mo["SystemType"].ToString();

                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }

        }

        /// <summary> 
        /// 物理内存 
        /// </summary> 
        /// <returns></returns> 
        private string GetTotalPhysicalMemory()
        {
            try
            {

                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    st = mo["TotalPhysicalMemory"].ToString();

                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
        }
        /// <summary> 
        ///  
        /// </summary> 
        /// <returns></returns> 
        private string GetComputerName()
        {
            try
            {
                return System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
        }
    }
}
