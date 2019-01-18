using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Web;

namespace MyService
{
    // based on https://leastprivilege.com/2008/03/19/using-identitymodel-adding-asp-net-support-part-1-authentication-based-claims/
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {

        public CustomAuthorizationPolicy()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }

        public string Id { get; }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            try
            {             

                X509Certificate2 cert = ((X509CertificateClaimSet)evaluationContext.ClaimSets[0]).X509Certificate;
                string thumbPrint = cert.Thumbprint;
                string acct = System.Configuration.ConfigurationManager.AppSettings[thumbPrint];


                using (var winId = new System.Security.Principal.WindowsIdentity(acct))
                {

                    using (var wClaimSet = new WindowsClaimSet(winId))
                    {
                        evaluationContext.Properties["Principal"] = new WindowsPrincipal(winId);

                        evaluationContext.AddClaimSet(this, wClaimSet);
                    }

                }


                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }

        }


    }
}