using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using System.IO;
using System.Threading;
using System.Management;
using Microsoft.Win32;

namespace SystroniX1
{
    class Program
    {
        readonly static string _reportFileName = "lastDebugInfo_" + DateTime.UtcNow.Year +"-"+ DateTime.UtcNow.Month+"-" + DateTime.UtcNow.Day+"_"+ + DateTime.UtcNow.Hour+"-"+ DateTime.UtcNow.Minute+ ".inf";
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }
        static string GetCpuInfo()
        {
            string result = "";
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.CPUEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType != null)// == SensorType.Temperature)
                                result += Environment.NewLine + computer.Hardware[i].Sensors[j].Name + ":" + computer.Hardware[i].Sensors[j].Value.ToString() + " [" +computer.Hardware[i].Sensors[j].Min+","+computer.Hardware[i].Sensors[j].Max+ "]" + "\r";
                        }
                    }
                }
                computer.Close();
            }
            catch { result += Environment.NewLine + "!> Error on getting cpu info"; }
            return result;
        }
        static string GetMainBoardInfo()
        {
            string result = "";
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.MainboardEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.Mainboard)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                                result += Environment.NewLine + computer.Hardware[i].Sensors[j].Name + ":" + computer.Hardware[i].Sensors[j].Value.ToString() + "\r";
                        }
                    }
                }
                computer.Close();
            }
            catch { result += Environment.NewLine + "!> Error on getting cpu info"; }
            return result;
        }
        static string GetGpuNVInfo()
        {
            string result = "";
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.GPUEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.GpuNvidia)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                                result += Environment.NewLine + computer.Hardware[i].Sensors[j].Name + ":" + computer.Hardware[i].Sensors[j].Value.ToString() + "\r";
                        }
                    }
                }
                computer.Close();
            }
            catch { result += Environment.NewLine + "!> Error on getting cpu info"; }
            return result;
        }
        static string GetGpuAtiInfo()
        {
            string result = "";
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.GPUEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.GpuAti)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                                result += Environment.NewLine + computer.Hardware[i].Sensors[j].Name + ":" + computer.Hardware[i].Sensors[j].Value.ToString() + "\r";
                        }
                    }
                }
                computer.Close();
            }
            catch { result += Environment.NewLine + "!> Error on getting cpu info"; }
            return result;
        }
        static string GetHDDInfo()
        {
            string result = "";
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.HDDEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.HDD)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                                result += Environment.NewLine + computer.Hardware[i].Sensors[j].Name + ":" + computer.Hardware[i].Sensors[j].Value.ToString() + "\r";
                        }
                    }
                }
                computer.Close();
            }
            catch { result += Environment.NewLine + "!> Error on getting cpu info"; }
            return result;
        }
        static string GetRAMInfo()
        {
            string result = "";
            try
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.Open();
                computer.RAMEnabled = true;
                computer.Accept(updateVisitor);
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.RAM)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                                result += Environment.NewLine + computer.Hardware[i].Sensors[j].Name + ":" + computer.Hardware[i].Sensors[j].Value.ToString() + "\r";
                        }
                    }
                }
                computer.Close();
            }
            catch { result += Environment.NewLine + "!> Error on getting cpu info"; }
            return result;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Write(">> MBKH SystroniX [v.1.02004] is initiating electronic systems report");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\t\tplease wait..");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Beep();
            try
            {
                while (true)
                {
                    string WriteLine =(">> MBKH SystroniX v.1.02004 electronic systems report:");
                    // Create a Timer object that knows to call our TimerCallback
                    // method once every 1000 milliseconds.
                    Timer t = new Timer(TimerCallback, null, 0, 1000);
                    WriteLine+=("\t\t\t[" + DateTime.UtcNow.ToLongTimeString() + "]");

                    string cpuInfo = GetCpuInfo();
                    if (!string.IsNullOrEmpty(cpuInfo.Trim()))
                    {
                        WriteLine += Environment.NewLine + ("\n\t VVV CPU Information VVV");
                        WriteLine += (cpuInfo);
                    }
                    else
                        WriteLine += Environment.NewLine + ("\t !> CPU data not found.");

                    string mainBoard = GetMainBoardInfo();
                    if (!string.IsNullOrEmpty(mainBoard.Trim()))
                    {
                        WriteLine += Environment.NewLine + ("\n\t VVV Main board Information VVV");
                        WriteLine += (mainBoard);
                    }
                    else
                        WriteLine += Environment.NewLine + ("\t !> Main board data not found.");

                    string gpuNV = GetGpuNVInfo();
                    if (!string.IsNullOrEmpty(gpuNV.Trim()))
                    {
                        WriteLine += Environment.NewLine + ("\n\t VVV GPU Nvidia Information VVV");
                        WriteLine += (gpuNV);
                    }
                    else
                        WriteLine += Environment.NewLine + ("\t !> GPU Nvidia data not found.");

                    string gpuAti = GetGpuAtiInfo();
                    if (!string.IsNullOrEmpty(gpuAti.Trim()))
                    {
                        WriteLine += Environment.NewLine + ("\n\t VVV GPU ATI Information VVV");
                        WriteLine += (gpuAti);
                    }
                    else
                        WriteLine += Environment.NewLine + ("\t !> GPU ATI data not found.");

                    string hDD = GetHDDInfo();
                    if (!string.IsNullOrEmpty(hDD.Trim()))
                    {
                        WriteLine += Environment.NewLine + ("\n\t VVV Hard disk Information VVV");
                        WriteLine += (hDD);
                    }
                    else
                        WriteLine += Environment.NewLine + ("\t !> Hard disk data not found.");

                    string ram = GetRAMInfo();
                    if (!string.IsNullOrEmpty(ram.Trim()))
                    {
                        WriteLine += Environment.NewLine + ("\n\t VVV Ram Information VVV");
                        WriteLine += (ram);
                    }
                    else
                        WriteLine += Environment.NewLine + ("\t !> Ram data not found.");

                    string cpuTemp = "\n\t VVV " + CPUTemperature.GetTemperatures_autoTerminal+" VVV";
                    WriteLine += Environment.NewLine + cpuTemp;

                    string procInfo = "\n\t VVV " + SystemInfo.getProcessorInfo_autoTerminal() + " VVV";
                    WriteLine += Environment.NewLine + procInfo;

                    string operInfo = "\n\t VVV" + SystemInfo.getOperatingSystemInfo_autoTerminal() + " VVV";
                    WriteLine += Environment.NewLine + operInfo;

                    try
                    {
                        // Write file using StreamWriter  
                        string reportPath = AppDomain.CurrentDomain.BaseDirectory + @"\" + _reportFileName;
                        using (StreamWriter writer = File.AppendText(reportPath))
                        {
                            writer.WriteLine(WriteLine);
                            writer.WriteLine("^******************* B R E A K L I N E ********************^\n\n");
                            writer.Close();
                        }

                        Console.Clear();              //Refresh the screen
                        Console.WriteLine(WriteLine); //Displays all info together..
                        Console.WriteLine("\n\n>> Full report file address: \n\t" + reportPath);
                        Console.WriteLine("^******************* B R E A K L I N E ********************^\n\n");
                    }
                    catch { Console.WriteLine("\n\n\t!>\tFatal error. (E40X)"); }
                }
            }
            catch { Console.WriteLine("\n\n\t!>\tDll files not found, please reinstall the neccesary files[OpenHardwareMonitorLib.dll]. (E100)"); }
        }
        private static void TimerCallback(Object o)
        {
            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }
    }
    public class CPUTemperature
    {
        public double CurrentValue { get; set; }
        public string InstanceName { get; set; }
        public static string GetTemperatures_autoTerminal
        {
            get
            {
                string result = "Active thermal sensors values: ";
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        Double temp = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                        temp = (temp - 2732) / 10.0;
                        result += Environment.NewLine + (" InstanceName = " + obj["InstanceName"] + " CurrentValue = " + temp);
                    }
                }
                catch { result += Environment.NewLine + ("\t !> Error on getting active thermal sensors list"); result += Environment.NewLine + " !> Error on getting active thermal sensors list"; }
                return result;
            }
        }
    }
    public class SystemInfo
    {
        public static string getOperatingSystemInfo_autoTerminal()
        {
            string result ="Operating system info:";
            try
            {
                //Create an object of ManagementObjectSearcher class and pass query as parameter.
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject managementObject in mos.Get())
                {
                    if (managementObject["Caption"] != null)
                    {
                        result += Environment.NewLine + ("Operating System Name  :  " + managementObject["Caption"].ToString());   //Display operating system caption
                    }
                    if (managementObject["OSArchitecture"] != null)
                    {
                        result += Environment.NewLine + "Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString();
                    }
                    if (managementObject["CSDVersion"] != null)
                    {
                        result += Environment.NewLine + "Operating System Service Pack   :  " + managementObject["CSDVersion"].ToString();
                    }
                }
            }
            catch { result += Environment.NewLine + ("\t !> Error on getting operating system info"); result += Environment.NewLine + " !> Error on getting operating system info"; }
            return result;
        }

        public static string getProcessorInfo_autoTerminal()
        {
            string result =("Displaying Processor Name....");
            try
            {
                RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

                if (processor_name != null)
                {
                    if (processor_name.GetValue("ProcessorNameString") != null)
                    {
                        result += Environment.NewLine + (processor_name.GetValue("ProcessorNameString"));   //Display processor ingo.
                        result+= (Environment.NewLine + "Active Processor Name String: " + processor_name.GetValue("ProcessorNameString").ToString());
                        return result;
                    }
                }
            }
            catch { result += Environment.NewLine + ("\t !> Error on getting processor data"); return Environment.NewLine + " !> Error on getting processor data"; }
            return result;
        }
    }

}
