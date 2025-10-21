// ==============================================================================
// Interlock4 - Function Block
// ==============================================================================
// Generated from Open Process Library specification
// Template: csharp
// ==============================================================================

using System;

namespace OpenProcessLibrary
{
    /// <summary>
    /// Interlock4 function block
    /// </summary>
    public class Interlock4
    {
        // ======================================================================
        // InOut Variables
        // ======================================================================

        // ======================================================================
        // Input Variables
        // ======================================================================

        // ======================================================================
        // Output Variables
        // ======================================================================

        // ======================================================================
        // Local Variables
        // ======================================================================
        private bool first_scan = true;
        private bool second_scan = false;
        // Temporary variables for MTP base interface access
        // Helper variables for sync detection

        // ======================================================================
        // Constructor
        // ======================================================================
        public Interlock4()
        {
            // Initialize default values
        }

        // ======================================================================
        // Helper Methods - PLC-style type conversions
        // ======================================================================
        /// <summary>
        /// Converts a WORD (ushort) to REAL (double)
        /// </summary>
        private static double WORD_TO_REAL(ushort value)
        {
            return (double)value;
        }

        /// <summary>
        /// Converts a BOOL (bool) to REAL (double)
        /// Returns 1.0 for true, 0.0 for false
        /// </summary>
        private static double BOOL_TO_REAL(bool value)
        {
            return value ? 1.0 : 0.0;
        }

        // ======================================================================
        // Execute - Main function block logic
        // ======================================================================
        public void Execute()
        {
            // STARTUP - SECOND SCAN
            if (second_scan)
            {
                // end second scan
                second_scan = false;
            }

            // STARTUP - FIRST SCAN
            if (first_scan)
            {
                // prepare second scan
                first_scan = false;
                second_scan = true;
            }
            // sync variables with MTPBase
            // - a variable on MTPBase that can be changed from the HMI
            // - an input on the wrapper block
            // how: store the variable from the MTPBase on a helper variable, and then compare each cycle if the operator has changed it
            // if yes then copy it to the input on the wrapper block
            // if not then copy the wrapper block input to the MTPBase variable

            // copy from and to the MTPBase
            // there is no need to execute the MTPBase block here because it gets executed as part of the auto-generated MTP code

            // Functionality

        }
    }
}
