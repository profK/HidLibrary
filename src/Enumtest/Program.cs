// See https://aka.ms/new-console-template for more information

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HidLibrary;

namespace Enumtest
{
    class Program
    {
        static void Main(string[] argv)
        {
            foreach (var dev in HidDevices.Enumerate())
            {
                byte[] name = new byte[64];
                dev.ReadProduct(out name);
                Console.WriteLine(Encoding.Unicode.GetString(name));
                var capabilities = dev.Capabilities;
                byte[] featureData = new byte[capabilities.FeatureReportByteLength];
                dev.ReadFeatureData(out featureData);
                Console.WriteLine(featureData);
                ParseFeatureData()
            }
        }
    }
}