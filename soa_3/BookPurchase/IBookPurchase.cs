using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Security;

namespace BookPurchase {

    [ServiceContract]
    public interface IBookPurchase {

        [OperationContract]
        BookPurchaseResponse PurchaseBooks(BookPurchaseInfo info);
    }

    [MessageContract]
    public class BookPurchaseInfo {
        
        [MessageBodyMember(Order = 1, ProtectionLevel = ProtectionLevel.None)]
        public float budget { get; set; }

        [MessageBodyMember(Order = 2, ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        public Dictionary<int, int> items { get; set; }
    }

    [MessageContract]
    public class BookPurchaseResponse {

        [MessageBodyMember(Order = 1, ProtectionLevel = ProtectionLevel.None)]
        public bool result { get; set; }

        [MessageBodyMember(Order = 2, ProtectionLevel = ProtectionLevel.None)]
        public string response { get; set; }
    }
}
