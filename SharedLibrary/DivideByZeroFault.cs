using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    /// <summary>
    /// DivideByZeroFault
    /// Fault object model
    /// for errors (Divide By Zero Exceptions) 
    /// with dividing by zero
    /// </summary>
    [DataContract]
    public class DivideByZeroFault
    {
        [DataMember]
        public string Reason { get; set; }

    } // end of class
} // end of namespace
