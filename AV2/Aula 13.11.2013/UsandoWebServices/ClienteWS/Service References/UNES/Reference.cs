﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClienteWS.UNES {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Produto", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Produto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeField;
        
        private decimal PrecoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((this.CodigoField.Equals(value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Nome {
            get {
                return this.NomeField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeField, value) != true)) {
                    this.NomeField = value;
                    this.RaisePropertyChanged("Nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal Preco {
            get {
                return this.PrecoField;
            }
            set {
                if ((this.PrecoField.Equals(value) != true)) {
                    this.PrecoField = value;
                    this.RaisePropertyChanged("Preco");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UNES.ServicesSoap")]
    public interface ServicesSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObterValor", ReplyAction="*")]
        decimal ObterValor(int codigoProduto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObterValor", ReplyAction="*")]
        System.Threading.Tasks.Task<decimal> ObterValorAsync(int codigoProduto);
        
        // CODEGEN: Generating message contract since element name ObterProdutoResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObterProduto", ReplyAction="*")]
        ClienteWS.UNES.ObterProdutoResponse ObterProduto(ClienteWS.UNES.ObterProdutoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObterProduto", ReplyAction="*")]
        System.Threading.Tasks.Task<ClienteWS.UNES.ObterProdutoResponse> ObterProdutoAsync(ClienteWS.UNES.ObterProdutoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObterProdutoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObterProduto", Namespace="http://tempuri.org/", Order=0)]
        public ClienteWS.UNES.ObterProdutoRequestBody Body;
        
        public ObterProdutoRequest() {
        }
        
        public ObterProdutoRequest(ClienteWS.UNES.ObterProdutoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObterProdutoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int codigoProduto;
        
        public ObterProdutoRequestBody() {
        }
        
        public ObterProdutoRequestBody(int codigoProduto) {
            this.codigoProduto = codigoProduto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObterProdutoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObterProdutoResponse", Namespace="http://tempuri.org/", Order=0)]
        public ClienteWS.UNES.ObterProdutoResponseBody Body;
        
        public ObterProdutoResponse() {
        }
        
        public ObterProdutoResponse(ClienteWS.UNES.ObterProdutoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObterProdutoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ClienteWS.UNES.Produto ObterProdutoResult;
        
        public ObterProdutoResponseBody() {
        }
        
        public ObterProdutoResponseBody(ClienteWS.UNES.Produto ObterProdutoResult) {
            this.ObterProdutoResult = ObterProdutoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServicesSoapChannel : ClienteWS.UNES.ServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicesSoapClient : System.ServiceModel.ClientBase<ClienteWS.UNES.ServicesSoap>, ClienteWS.UNES.ServicesSoap {
        
        public ServicesSoapClient() {
        }
        
        public ServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public decimal ObterValor(int codigoProduto) {
            return base.Channel.ObterValor(codigoProduto);
        }
        
        public System.Threading.Tasks.Task<decimal> ObterValorAsync(int codigoProduto) {
            return base.Channel.ObterValorAsync(codigoProduto);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClienteWS.UNES.ObterProdutoResponse ClienteWS.UNES.ServicesSoap.ObterProduto(ClienteWS.UNES.ObterProdutoRequest request) {
            return base.Channel.ObterProduto(request);
        }
        
        public ClienteWS.UNES.Produto ObterProduto(int codigoProduto) {
            ClienteWS.UNES.ObterProdutoRequest inValue = new ClienteWS.UNES.ObterProdutoRequest();
            inValue.Body = new ClienteWS.UNES.ObterProdutoRequestBody();
            inValue.Body.codigoProduto = codigoProduto;
            ClienteWS.UNES.ObterProdutoResponse retVal = ((ClienteWS.UNES.ServicesSoap)(this)).ObterProduto(inValue);
            return retVal.Body.ObterProdutoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClienteWS.UNES.ObterProdutoResponse> ClienteWS.UNES.ServicesSoap.ObterProdutoAsync(ClienteWS.UNES.ObterProdutoRequest request) {
            return base.Channel.ObterProdutoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClienteWS.UNES.ObterProdutoResponse> ObterProdutoAsync(int codigoProduto) {
            ClienteWS.UNES.ObterProdutoRequest inValue = new ClienteWS.UNES.ObterProdutoRequest();
            inValue.Body = new ClienteWS.UNES.ObterProdutoRequestBody();
            inValue.Body.codigoProduto = codigoProduto;
            return ((ClienteWS.UNES.ServicesSoap)(this)).ObterProdutoAsync(inValue);
        }
    }
}
