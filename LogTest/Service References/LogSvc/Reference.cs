﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogTest.LogSvc {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LogType", Namespace="http://schemas.datacontract.org/2004/07/ITGB.UIS.Log.BLL")]
    public enum LogType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Info = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Alert = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Expired = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Error = 100,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LogSvc.ILogger")]
    public interface ILogger {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogger/Log", ReplyAction="http://tempuri.org/ILogger/LogResponse")]
        void Log(string companyCode, LogTest.LogSvc.LogType type, int systemId, string userId, string action, string description, System.Xml.Linq.XElement clientInfo, System.Xml.Linq.XElement otherInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogger/Log", ReplyAction="http://tempuri.org/ILogger/LogResponse")]
        System.Threading.Tasks.Task LogAsync(string companyCode, LogTest.LogSvc.LogType type, int systemId, string userId, string action, string description, System.Xml.Linq.XElement clientInfo, System.Xml.Linq.XElement otherInfo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoggerChannel : LogTest.LogSvc.ILogger, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoggerClient : System.ServiceModel.ClientBase<LogTest.LogSvc.ILogger>, LogTest.LogSvc.ILogger {
        
        public LoggerClient() {
        }
        
        public LoggerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoggerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoggerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoggerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Log(string companyCode, LogTest.LogSvc.LogType type, int systemId, string userId, string action, string description, System.Xml.Linq.XElement clientInfo, System.Xml.Linq.XElement otherInfo) {
            base.Channel.Log(companyCode, type, systemId, userId, action, description, clientInfo, otherInfo);
        }
        
        public System.Threading.Tasks.Task LogAsync(string companyCode, LogTest.LogSvc.LogType type, int systemId, string userId, string action, string description, System.Xml.Linq.XElement clientInfo, System.Xml.Linq.XElement otherInfo) {
            return base.Channel.LogAsync(companyCode, type, systemId, userId, action, description, clientInfo, otherInfo);
        }
    }
}
