using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary;
using System.ServiceModel;

namespace ClientTester
{
    public partial class frmMathClient : Form
    {
        #region fields

        private int X = default(int);
        private int Y = default(int);
        private int result = default(int);

        #endregion fields

        #region constructors

        public frmMathClient()
        {
            InitializeComponent();
        }

        #endregion constructors

        #region Events

        /// <summary>
        /// btnAdd_Click
        /// Processes the Add button click event
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate and Parse the User Text Entry
            if (!ValidateParseDataEntry())
            {
                return;
            }

            // Make a ChannelFactory Proxy to the Service
            ChannelFactory<IMathService> cf = new ChannelFactory<IMathService>("myHttp");

            cf.Open();
            IMathService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    // Call the Proxy
                    result = proxy.Add(X, Y);

                    // Update the Result on the UI
                    UpdateResult();

                } // end of try

                catch (FaultException<GenericFault> ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message, "FaultException<GenericFault> Caught");
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message: " + ex.Message, "Error");
                }

            } // end of if

            else
            {
                // Cannot Connect to Server 
                MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);

            } // end of else

        } // end of method

        /// <summary>
        /// btnSubtract
        /// Processes the Subtract button click event
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            // Validate and Parse the User Text Entry
            if (!ValidateParseDataEntry())
            {
                return;
            }

            // Make a ChannelFactory Proxy to the Service
            ChannelFactory<IMathService> cf = new ChannelFactory<IMathService>("myHttp");

            cf.Open();
            IMathService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    // Call the Proxy
                    result = proxy.Subtract(X, Y);

                    // Update the Result on the UI
                    UpdateResult();

                } // end of try

                catch (FaultException<GenericFault> ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message, "FaultException<GenericFault> Caught");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message: " + ex.Message, "Error");
                }

            } // end of if

            else
            {
                // Cannot Connect to Server 
                MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);

            } // end of else

        } // end of method

        /// <summary>
        /// btnMultiply
        /// Processes the Multiply button click event
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            // Validate and Parse the User Text Entry
            if (!ValidateParseDataEntry())
            {
                return;
            }

            // Make a ChannelFactory Proxy to the Service
            ChannelFactory<IMathService> cf = new ChannelFactory<IMathService>("myHttp");

            cf.Open();
            IMathService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    // Call the Proxy
                    result = proxy.Multiply(X, Y);

                    // Update the Result on the UI
                    UpdateResult();

                } // end of try

                catch (FaultException<GenericFault> ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message, "FaultException<GenericFault> Caught");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message: " + ex.Message, "Error");
                }

            } // end of if

            else
            {
                // Cannot Connect to Server 
                MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);

            } // end of else

        } // end of method

        /// <summary>
        /// btnDivide
        /// Processes the Divide button event
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnDivide_Click(object sender, EventArgs e)
        {
            // Validate and Parse the User Text Entry
            if (!ValidateParseDataEntry())
            {
                return;
            }

            // Make a ChannelFactory Proxy to the Service
            ChannelFactory<IMathService> cf = new ChannelFactory<IMathService>("myHttp");

            cf.Open();
            IMathService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    // Call the Proxy
                    result = proxy.Divide(X, Y);

                    // Update the Result on the UI
                    UpdateResult();

                } // end of try
                catch (FaultException<DivideByZeroFault> ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message, "FaultException<DivideByZeroFault> Caught");
                }
                catch (FaultException<GenericFault> ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message, "FaultException<GenericFault> Caught");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message: " + ex.Message, "Error");
                }

            } // end of if

            else
            {
                // Cannot Connect to Server 
                MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);

            } // end of else

        } // end of method

        #endregion Events

        #region Methods

        /// <summary>
        /// ValidateParseDataEntry
        /// Validates the user input and parses
        /// the values
        /// </summary>
        /// <returns>true if valid and parsed, false otherwise</returns>
        private bool ValidateParseDataEntry()
        {
            if (!int.TryParse(txtX.Text, out X))
            {
                MessageBox.Show("X must be a int", "Invalid Data", MessageBoxButtons.OK);
                return false;
            }

            if (!int.TryParse(txtY.Text, out Y))
            {
                MessageBox.Show("Y must be a int", "Invalid Data", MessageBoxButtons.OK);
                return false;
            }

            return true;

        } // end of method

        /// <summary>
        /// UpdateResult
        /// Updates the Math calculation result on the UI
        /// </summary>
        private void UpdateResult()
        {
            lblResult.Text = "Result: " + result.ToString();

        } // end of method

        #endregion Methods

    } // end of class
} // end of namespace
