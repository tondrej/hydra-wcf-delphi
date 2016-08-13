using RemObjects.Hydra.CrossPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WcfService1ClientPluginModule
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CompositeType
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool BoolValue;
        [MarshalAs(UnmanagedType.BStr)]
        public string StringValue;
    }

    [Guid("8BFEBD21-EBE2-4519-B744-5231219E1BED")]
    public interface IService1Client : IHYCrossPlatformInterface
    {
        string GetData(int value);

        CompositeType GetDataUsingDataContract(ref CompositeType composite);

        string Hello(string name);
    }
}