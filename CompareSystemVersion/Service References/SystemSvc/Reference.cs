﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompareSystemVersion.SystemSvc {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SystemEntity", Namespace="http://schemas.datacontract.org/2004/07/ITGB.UIS.SSO.BLL.Entities")]
    [System.SerializableAttribute()]
    public partial class SystemEntity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HostUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SystemIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SystemNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HostUrl {
            get {
                return this.HostUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.HostUrlField, value) != true)) {
                    this.HostUrlField = value;
                    this.RaisePropertyChanged("HostUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SystemId {
            get {
                return this.SystemIdField;
            }
            set {
                if ((this.SystemIdField.Equals(value) != true)) {
                    this.SystemIdField = value;
                    this.RaisePropertyChanged("SystemId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SystemName {
            get {
                return this.SystemNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SystemNameField, value) != true)) {
                    this.SystemNameField = value;
                    this.RaisePropertyChanged("SystemName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SystemSvc.ISSOSystem")]
    public interface ISSOSystem {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISSOSystem/GetAllSystems", ReplyAction="http://tempuri.org/ISSOSystem/GetAllSystemsResponse")]
        System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity> GetAllSystems();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISSOSystem/GetAllSystems", ReplyAction="http://tempuri.org/ISSOSystem/GetAllSystemsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity>> GetAllSystemsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISSOSystem/GetAllSystem", ReplyAction="http://tempuri.org/ISSOSystem/GetAllSystemResponse")]
        System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity> GetAllSystem(string companyCode, bool isEnable);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISSOSystem/GetAllSystem", ReplyAction="http://tempuri.org/ISSOSystem/GetAllSystemResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity>> GetAllSystemAsync(string companyCode, bool isEnable);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISSOSystem/GetUserAvailableSystem", ReplyAction="http://tempuri.org/ISSOSystem/GetUserAvailableSystemResponse")]
        System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity> GetUserAvailableSystem(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISSOSystem/GetUserAvailableSystem", ReplyAction="http://tempuri.org/ISSOSystem/GetUserAvailableSystemResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity>> GetUserAvailableSystemAsync(int userId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISSOSystemChannel : CompareSystemVersion.SystemSvc.ISSOSystem, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SSOSystemClient : System.ServiceModel.ClientBase<CompareSystemVersion.SystemSvc.ISSOSystem>, CompareSystemVersion.SystemSvc.ISSOSystem {
        
        public SSOSystemClient() {
        }
        
        public SSOSystemClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SSOSystemClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SSOSystemClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SSOSystemClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity> GetAllSystems() {
            return base.Channel.GetAllSystems();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity>> GetAllSystemsAsync() {
            return base.Channel.GetAllSystemsAsync();
        }
        
        public System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity> GetAllSystem(string companyCode, bool isEnable) {
            return base.Channel.GetAllSystem(companyCode, isEnable);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity>> GetAllSystemAsync(string companyCode, bool isEnable) {
            return base.Channel.GetAllSystemAsync(companyCode, isEnable);
        }
        
        public System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity> GetUserAvailableSystem(int userId) {
            return base.Channel.GetUserAvailableSystem(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<CompareSystemVersion.SystemSvc.SystemEntity>> GetUserAvailableSystemAsync(int userId) {
            return base.Channel.GetUserAvailableSystemAsync(userId);
        }
    }
}
