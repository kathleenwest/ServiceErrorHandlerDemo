using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    /// <summary>
    /// IMathService
    /// Interface definitions for the math service
    /// </summary>
    [ServiceContract]
    public interface IMathService
    {
        /// <summary>
        /// Add
        /// Math addition
        /// of two value types
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>a value of the same type</returns>
		[FaultContract(typeof(GenericFault))]
        [OperationContract]
        int Add(int a, int b);

        /// <summary>
        /// Subtract
        /// Math subtraction
        /// of two value types
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>a value of the same type</returns>
		[FaultContract(typeof(GenericFault))]
        [OperationContract]
        int Subtract(int a, int b);

        /// <summary>
        /// Subtract
        /// Math multiplication
        /// of two value types
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>a value of the same type</returns>
		[FaultContract(typeof(GenericFault))]
        [OperationContract]
        int Multiply(int a, int b);

        /// <summary>
        /// Divide
        /// Math division
        /// of two value types
        /// </summary>
        /// <param name="a">first value</param>
        /// <param name="b">second value</param>
        /// <returns>a value of the same type</returns>
		[FaultContract(typeof(GenericFault))]
        [FaultContract(typeof(DivideByZeroFault))]
        [OperationContract]
        int Divide(int a, int b);

    } // end of class
} // end of namespace
