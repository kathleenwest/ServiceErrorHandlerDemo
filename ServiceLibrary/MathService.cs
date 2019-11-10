using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SharedLibrary;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace ServiceLibrary
{
    /// <summary>
    /// MathService
    /// Implements the IMathService method contracts
    /// Inherits from a ServiceErrorHandler to allow generic
    /// exceptions on the service to be handled and communicated 
    /// as faults to the client callers
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MathService : ServiceErrorHandler, IMathService
    {
        /// <summary>
        /// Add
        /// Adds two values
        /// Errors: Generic
        /// </summary>
        /// <param name="a">first value (int)</param>
        /// <param name="b">second value (int)</param>
        /// <returns>the sum of the two values (int)</returns>
        public int Add(int a, int b)
        {
            try
            {
                checked
                {
                    return a + b;
                }               
            }
            catch (Exception)
            {
                throw;
            }

        } // end of method

        /// <summary>
        /// Divide
        /// Divides the two values
        /// Errors: DivideByZero, Generic
        /// </summary>
        /// <param name="a">first value (int)</param>
        /// <param name="b">second value (int)</param>
        /// <returns>the result of the division</returns>
        public int Divide(int a, int b)
        {
            try
            {
                checked
                {
                    return a / b;
                }               
            }
            catch(DivideByZeroException)
            {
                // Create new Fault Object
                DivideByZeroFault fault = new DivideByZeroFault()
                {
                    Reason = "Cannot divide by zero!"
                };
                // Throw the Fault Exception object to client
                // Note: You need to do this format otherwise you will get the general message below:
                // The creator of this fault did not specify a Reason" exception. 
                throw new FaultException<DivideByZeroFault>(fault, new FaultReason(fault.Reason));
            }
            catch (Exception)
            {
                throw;
            }
        } // end of method

        /// <summary>
        /// Multiply
        /// Multiplies the two values
        /// Errors: Generic
        /// </summary>
        /// <param name="a">first value (int)</param>
        /// <param name="b">second value (int)</param>
        /// <returns>the multiplication result</returns>
        public int Multiply(int a, int b)
        {
            try
            {
                checked
                {
                    return a * b;
                }               
            }
            catch (Exception)
            {
                throw;
            }
        } // end of method

        /// <summary>
        /// Subtract
        /// Subtracts the two values
        /// Errors: Generic
        /// </summary>
        /// <param name="a">first value (int)</param>
        /// <param name="b">second value (int)</param>
        /// <returns>the result of subtracting two values</returns>
        public int Subtract(int a, int b)
        {
            try
            {
                checked
                {
                    return a - b;
                }               
            }
            catch (Exception)
            {
                throw;
            }
        } // end of method

    } // end of class
} // end of namespace
