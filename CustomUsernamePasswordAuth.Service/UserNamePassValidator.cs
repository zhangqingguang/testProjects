using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace CustomUsernamePasswordAuth.Service
{
    public class UserNamePassValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }
            if(!(userName == "admin" && password == "password01!"))
            {
                throw new FaultException("Incorrect Username or Password"); 
            }
        }
    }
}