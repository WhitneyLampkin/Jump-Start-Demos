using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SimpleRestService
{
    [ServiceContract]
    public class MyService
    {
        // To return JSON
        [OperationContract]
        [WebGet(UriTemplate = "/json/{number}", ResponseFormat = WebMessageFormat.Json)]
        public Data GetMultipleJson(string number)
        {
            return new Data(int.Parse(number));
        }

        // To return XML
        [OperationContract]
        [WebGet(UriTemplate = "/xml/{number}", ResponseFormat = WebMessageFormat.Xml)]
        public Data GetMultipleXml(string number)
        {
            return new Data(int.Parse(number));
        }
    }

    [DataContract]
    public class Data
    {
        public Data(int number)
        {
            var list = Enumerable.Range(1, 100);
            this.Multiples = list.Where(x => x % number == 0).ToArray();
        }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public int[] Multiples { get; set; }
    }
}
