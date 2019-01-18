using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPatientService
    {

        [OperationContract]
        Patient GetPatient(int id);
        // TODO: Add your service operations here

        [OperationContract]
        Hospital GetHospital();
    }


    [DataContract]
    public class Patient
    {
        [DataMember]
        public int PatientId { get; set; }
        [DataMember]
        public string PatientName { get; set; }
        [DataMember]
        public string MedicareNumber { get; set; }
    }

    [MessageContract]
    public class Hospital
    {

        [MessageHeader]
        public string HospitalName { get; set; }

        [MessageHeader]
        public string HospitalAddress { get; set; }

        [MessageBodyMember]
        public Patient InPatient { get; set; }

        [MessageBodyMember]
        public Patient OutPatient { get; set; }
    }
}
