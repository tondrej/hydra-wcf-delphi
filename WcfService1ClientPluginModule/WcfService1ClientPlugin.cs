using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using RemObjects.Hydra;


namespace WcfService1ClientPluginModule
{
    [Plugin, NonVisualPlugin]
    public partial class WcfService1ClientPlugin : NonVisualPlugin, IService1Client
    {
        private WcfService1Client.WcfService1Reference.Service1Client client;
        public WcfService1ClientPlugin()
        {
            InitializeComponent();
            client = new WcfService1Client.WcfService1Reference.Service1Client("BasicHttpBinding_IService1");
        }

        public WcfService1ClientPlugin(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string GetData(int value)
        {
            return client.GetData(value);
        }

        public CompositeType GetDataUsingDataContract(ref CompositeType composite)
        {
            WcfService1Client.WcfService1Reference.CompositeType tmp = new WcfService1Client.WcfService1Reference.CompositeType();
            tmp.BoolValue = composite.BoolValue;
            tmp.StringValue = composite.StringValue;

            tmp = client.GetDataUsingDataContract(tmp);

            CompositeType ret = new CompositeType();
            ret.BoolValue = tmp.BoolValue;
            ret.StringValue = tmp.StringValue;
            return ret;
        }

        public string Hello(string name)
        {
            return client.Hello(name);
        }
    }
}
