using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static void CheckPermission(string grp)
        {

            // We get the allowed windows account who is authorized to call this WCF method from configuration file

            PrincipalPermission ppAdmin = new PrincipalPermission(null, grp);
            ppAdmin.Demand();

        }


        //[PrincipalPermission(SecurityAction.Demand, Role = "ServiceGroup")]
        public string GetData(int value)
        {
            CheckPermission(System.Configuration.ConfigurationManager.AppSettings["GetDataGroup"]);

            return string.Format("You entered: {0}", value);
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
