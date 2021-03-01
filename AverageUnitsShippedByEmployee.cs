// Author:  Chantel Romard
// Prof:    Kyle Chapman
// Date:    Feb 28, 2021
// Desc:    Lab 3 - Allow entries for 3 employees, 7 days each, and output the average for each 
//              employee and the overall average for that week.

/*  THIS CODE IS INCOMPLETE  */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_Romard_AverageUnitsShippedExtended
{
    public partial class formAverageUnitsShippedByEmployee : Form
    {
        #region "Declarations and Initializations"

        // Constants
        const int NumberOfEmployees = 3;
        const int NumberOfDays = 7;

        // Variables
        int employee = 1;
        int day = 1;

        // Arrays
        int[,] inputArray = new int[NumberOfEmployees, NumberOfDays];
        TextBox[] employeeEntries;
        Label[] employeeAverages;

        /// <summary>
        /// Initialize Arrays and set defaults.
        /// </summary>
        public formAverageUnitsShippedByEmployee()
        {
            InitializeComponent();

            employeeEntries = new TextBox[] { textBoxEntriesEmployee1, textBoxEntriesEmployee2, textBoxEntriesEmployee3 };
            employeeAverages = new Label[] { labelAverageUnitsEmployee1, labelAverageUnitsEmployee2, labelAverageUnitsEmployee3 };
            SetDefaults();
        }

        /// <summary>
        /// Load the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formAverageUnitsShippedByEmployee_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Event Handlers"

        private void ButtonEnterClick(object sender, EventArgs e)
        {
            // Declarations and initializations.
            const int MinimumUnits = 0;
            const int MaximumUnits = 5000;

            // Validate input is a whole number
            if (int.TryParse(textBoxInputUnitsShipped.Text, out inputArray[employee - 1, day - 1]))
            {
                // Validate that input is between 0 and 5000
                if (inputArray[employee - 1, day - 1] >= MinimumUnits &&
                    inputArray[employee - 1, day - 1] <= MaximumUnits)
                {
                    // Enter current valid entry into curCrent employee textbox.
                    employeeEntries[employee - 1].Text += inputArray[employee - 1, day - 1] + "\r\n";

                    // Check if Day 7 has been entered.
                    if (day >= NumberOfDays)
                    {
                        int employeeTotal = 0;
                        
                        // Calculate and display each employee's average.
                        for (int days = 0; days < NumberOfDays; days++)
                        {
                            employeeTotal += inputArray[employee -1, days];
                        }

                        employeeAverages[employee - 1].Text = "Average: " + Math.Round((double)employeeTotal / NumberOfDays, 2);
                        
                        // Day 7 has been entered, go to next employee.
                        day = 0;
                        employee++;
                    }

                    // Check if all employees data has been entered.
                    if (employee >= NumberOfEmployees)
                    {
                        int overallTotal = 0;
                        day = 1;
                        employee = 1;

                        

                        //labelTotalAverageUnitsPerDay.Text = "Average this week: " + Math.Round((double)overallTotal / NumberOfEmployees, 2);

                        // Disable input controls and set focus.
                        textBoxInputUnitsShipped.Enabled = false;
                        buttonEnter.Enabled = false;
                        buttonReset.Focus();
                    }

                    day++;

                    // Set day counter.
                    labelDay.Text = "Day " + day;
                }
                else
                {
                    // Value entered is not within range of 0 and 5000.
                    MessageBox.Show("Enter a value between " + MinimumUnits + " and " + MaximumUnits + ".", "Invalid Input!");
                    textBoxInputUnitsShipped.SelectAll();
                    textBoxInputUnitsShipped.Focus();
                }
            }
            else
            {
                // Value entered is not an integer.
                MessageBox.Show("Input must be a numeric value.", "Invalid Input!");
                textBoxInputUnitsShipped.SelectAll();
                textBoxInputUnitsShipped.Focus();
            }
        }
        /// <summary>
        /// Clear all form fields and re-enable controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonResetClick(object sender, EventArgs e)
        {
            SetDefaults();
        }
        /// <summary>
        /// Close the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExitClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region "Functions"

        /// <summary>
        /// Resets the form to it's default state, clearing the input and output fields
        /// and setting focus for ease of new input.
        /// </summary>
        private void SetDefaults()
        {
            // Clear Input and Output fields.
            textBoxInputUnitsShipped.Clear();
            textBoxEntriesEmployee1.Clear();
            textBoxEntriesEmployee2.Clear();
            textBoxEntriesEmployee3.Clear();
            labelAverageUnitsEmployee1.Text = String.Empty;
            labelAverageUnitsEmployee2.Text = String.Empty;
            labelAverageUnitsEmployee3.Text = String.Empty;
            labelTotalAverageUnitsPerDay.Text = String.Empty;

            // Reset global variables.
            day = 1;
            employee = 1;
            labelDay.Text = "Day " + day;

            // Reset fonts to default states.
            labelEmployee1.Font = new Font(this.Font, FontStyle.Bold);
            labelEmployee2.Font = new Font(this.Font, FontStyle.Regular);
            labelEmployee3.Font = new Font(this.Font, FontStyle.Regular);

            // Re-enable controls.
            textBoxInputUnitsShipped.Enabled = true;
            buttonEnter.Enabled = true;

            // Set Focus for ease of new entries.
            textBoxInputUnitsShipped.Focus();
        }

        #endregion
    }
}
