﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bookstore.purchase {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="purchase.IBookPurchase")]
    public interface IBookPurchase {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookPurchase/PurchaseBooks", ReplyAction="http://tempuri.org/IBookPurchase/PurchaseBooksResponse")]
        Bookstore.purchase.BookPurchaseResponse PurchaseBooks(Bookstore.purchase.BookPurchaseInfo request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookPurchase/PurchaseBooks", ReplyAction="http://tempuri.org/IBookPurchase/PurchaseBooksResponse")]
        System.Threading.Tasks.Task<Bookstore.purchase.BookPurchaseResponse> PurchaseBooksAsync(Bookstore.purchase.BookPurchaseInfo request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BookPurchaseInfo", WrapperNamespace="http://tempuri.org/", IsWrapped=true, ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign)]
    public partial class BookPurchaseInfo {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Order=0)]
        public float budget;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", ProtectionLevel=System.Net.Security.ProtectionLevel.EncryptAndSign, Order=1)]
        public System.Collections.Generic.Dictionary<int, int> items;
        
        public BookPurchaseInfo() {
        }
        
        public BookPurchaseInfo(float budget, System.Collections.Generic.Dictionary<int, int> items) {
            this.budget = budget;
            this.items = items;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BookPurchaseResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class BookPurchaseResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", ProtectionLevel=System.Net.Security.ProtectionLevel.None, Order=0)]
        public bool result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", ProtectionLevel=System.Net.Security.ProtectionLevel.None, Order=1)]
        public string response;
        
        public BookPurchaseResponse() {
        }
        
        public BookPurchaseResponse(bool result, string response) {
            this.result = result;
            this.response = response;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBookPurchaseChannel : Bookstore.purchase.IBookPurchase, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookPurchaseClient : System.ServiceModel.ClientBase<Bookstore.purchase.IBookPurchase>, Bookstore.purchase.IBookPurchase {
        
        public BookPurchaseClient() {
        }
        
        public BookPurchaseClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookPurchaseClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookPurchaseClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookPurchaseClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Bookstore.purchase.BookPurchaseResponse Bookstore.purchase.IBookPurchase.PurchaseBooks(Bookstore.purchase.BookPurchaseInfo request) {
            return base.Channel.PurchaseBooks(request);
        }
        
        public bool PurchaseBooks(float budget, System.Collections.Generic.Dictionary<int, int> items, out string response) {
            Bookstore.purchase.BookPurchaseInfo inValue = new Bookstore.purchase.BookPurchaseInfo();
            inValue.budget = budget;
            inValue.items = items;
            Bookstore.purchase.BookPurchaseResponse retVal = ((Bookstore.purchase.IBookPurchase)(this)).PurchaseBooks(inValue);
            response = retVal.response;
            return retVal.result;
        }
        
        public System.Threading.Tasks.Task<Bookstore.purchase.BookPurchaseResponse> PurchaseBooksAsync(Bookstore.purchase.BookPurchaseInfo request) {
            return base.Channel.PurchaseBooksAsync(request);
        }
    }
}
