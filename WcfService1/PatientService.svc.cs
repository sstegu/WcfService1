using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IPatientService
    {
        public Hospital GetHospital()
        {
            Hospital h = new Hospital()
            {
                HospitalAddress = "2 some st.",
                HospitalName = "some hospital",
                InPatient = GetPatient(5)
            };



            return h;
        }

        public Patient GetPatient(int id)
        {
            return new Patient()
            {
                MedicareNumber = "5555",
                PatientId = id,
                PatientName = "TestPatient"
            };
        }


    }

    public class Event : System.Web.Management.WebBaseEvent
    {

        public Event(string message, Object eventSource, int eventCode)
            : base(message, eventSource, eventCode)
        {
            DateTime eventStamp = DateTime.Now;
        }
    }
}
