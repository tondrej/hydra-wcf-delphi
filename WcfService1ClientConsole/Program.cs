using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService1Client.WcfService1Reference;

namespace WcfService1ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client("BasicHttpBinding_IService1");

            int m1p1 = 42;
            string m1r = client.GetData(m1p1);
            Console.WriteLine(string.Format("GetData({0}): \"{1}\"", m1p1, m1r));

            CompositeType m2p1 = new CompositeType();
            m2p1.BoolValue = true;
            m2p1.StringValue = "Hi";
            CompositeType m2r = client.GetDataUsingDataContract(m2p1);
            Console.WriteLine(string.Format("GetDtaUsingDataContract({0}, \"{1}\"): {2}, \"{3}\"", m2p1.BoolValue, m2p1.StringValue, m2r.BoolValue, m2r.StringValue));

            string m3p1 = "world";
            string m3r = client.Hello(m3p1);
            Console.WriteLine(string.Format("Hello(\"{0}\"): \"{1}\"", m3p1, m3r));

            Console.ReadLine();
        }
    }
}