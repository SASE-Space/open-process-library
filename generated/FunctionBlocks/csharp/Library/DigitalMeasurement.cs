// ==============================================================================
// DigitalMeasurement - Function Block
// ==============================================================================
// Generated from Open Process Library specification
// Template: csharp
// ==============================================================================

using System;

namespace OpenProcessLibrary
{
    /// <summary>
    /// DigitalMeasurement function block
    /// Flattened implementation including BinMon interface
    /// </summary>
    public class DigitalMeasurement
    {
        // ======================================================================
        // MTP Interface Variables (from BinMon)
        // ======================================================================
        // Input Variables
        [Tag] public byte WQC;
        [Tag] public bool V;
        [Tag] public string VState0;
        [Tag] public string VState1;
        [Tag] public byte OSLevel;
        [Tag] public bool VFlutEn;
        // Output Variables
        [Tag] public bool VFlutAct;
        // Local Variables
        [Tag] private double VFlutTi;
        [Tag] private int VFlutCnt;

        // ======================================================================
        // Extended Variables (OPL additions)
        // ======================================================================
        // Input Variables
        [Tag] public int id;
        [Tag] public bool value;
        // Output Variables
        [Tag] public bool valueOut;
        [Tag] public bool risingEdge;
        [Tag] public bool fallingEdge;
        // Local Variables
        [Tag] private bool lastValue;

        // Control Variables
        private bool first_scan = true;
        private bool second_scan = false;
        // Helper variables for sync detection

        // ======================================================================
        // Constructor
        // ======================================================================
        public DigitalMeasurement()
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
            // ======================================================================
            // MTP Interface Functionality (from BinMon)
            // ======================================================================


            // ======================================================================
            // Extended Functionality (OPL additions)
            // ======================================================================

            WQC = 0xFF;
            OSLevel = 0x00;
            V = value;
            VState0 = "False";
            VState1 = "True";
            VFlutEn = false;
            risingEdge = value != lastValue && value == true;
            fallingEdge = value != lastValue && value == false;
            lastValue = value;
        }
    }
}
