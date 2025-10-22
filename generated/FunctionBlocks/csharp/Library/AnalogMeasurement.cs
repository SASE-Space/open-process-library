// ==============================================================================
// AnalogMeasurement - Function Block
// ==============================================================================
// Generated from Open Process Library specification
// Template: csharp
// ==============================================================================

using System;

namespace OpenProcessLibrary
{
    /// <summary>
    /// AnalogMeasurement function block
    /// Flattened implementation including AnaMon interface
    /// </summary>
    public class AnalogMeasurement
    {
        // ======================================================================
        // MTP Interface Variables (from AnaMon)
        // ======================================================================

        [Tag] public string Name;
        [Tag] public string Type = "AnalogMeasurement";
        // Input Variables
        [Tag] public byte WQC;
        [Tag] public byte OSLevel;
        [Tag] public double V;
        [Tag] public double VSclMin;
        [Tag] public double VSclMax;
        [Tag] public int VUnit;
        [Tag] public bool VAHEn;
        [Tag] public bool VWHEn;
        [Tag] public bool VTHEn;
        [Tag] public bool VTLEn;
        [Tag] public bool VWLEn;
        [Tag] public bool VALEn;
        // Output Variables
        [Tag] public bool VAHAct;
        [Tag] public bool VWHAct;
        [Tag] public bool VTHAct;
        [Tag] public bool VTLAct;
        [Tag] public bool VWLAct;
        [Tag] public bool VALAct;
        // Local Variables
        [Tag] private double VAHLim;
        [Tag] private double VWHLim;
        [Tag] private double VTHLim;
        [Tag] private double VTLLim;
        [Tag] private double VWLLim;
        [Tag] private double VALLim;

        // ======================================================================
        // Extended Variables (OPL additions)
        // ======================================================================
        // Input Variables
        [Tag] public int id;
        [Tag] public ushort rawValue;
        [Tag] public int valueUnit;
        [Tag] public double scaleMin = 0;
        [Tag] public double scaleMax = 100;
        [Tag] public double alarmHigh = 90;
        [Tag] public double warningHigh = 80;
        [Tag] public double toleranceHigh = 60;
        [Tag] public double toleranceLow = 40;
        [Tag] public double warningLow = 20;
        [Tag] public double alarmLow = 10;
        [Tag] public bool alarmHighEn = true;
        [Tag] public bool warningHighEn = true;
        [Tag] public bool toleranceHighEn = true;
        [Tag] public bool toleranceLowEn = true;
        [Tag] public bool warningLowEn = true;
        [Tag] public bool alarmLowEn = true;
        [Tag] public double deadband;
        [Tag] public bool externalFault;
        // Output Variables
        [Tag] public double vOut;
        [Tag] public bool error;
        [Tag] public bool alarmHighStatus;
        [Tag] public bool warningHighStatus;
        [Tag] public bool toleranceHighStatus;
        [Tag] public bool toleranceLowStatus;
        [Tag] public bool warningLowStatus;
        [Tag] public bool alarmLowStatus;

        // Control Variables
        private bool first_scan = true;
        private bool second_scan = false;
        // Helper variables for sync detection
        private double VAHLimLast;
        private double VWHLimLast;
        private double VTHLimLast;
        private double VTLLimLast;
        private double VWLLimLast;
        private double VALLimLast;

        // ======================================================================
        // Constructor
        // ======================================================================
        public AnalogMeasurement(string InstanceName)
        {
            this.Name = InstanceName;

            // Initialize default values
            this.scaleMin = 0;
            this.scaleMax = 100;
            this.alarmHigh = 90;
            this.warningHigh = 80;
            this.toleranceHigh = 60;
            this.toleranceLow = 40;
            this.warningLow = 20;
            this.alarmLow = 10;
            this.alarmHighEn = true;
            this.warningHighEn = true;
            this.toleranceHighEn = true;
            this.toleranceLowEn = true;
            this.warningLowEn = true;
            this.alarmLowEn = true;
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
            // MTP Interface Functionality (from AnaMon)
            // ======================================================================

            VAHAct = vOut >= alarmHigh;
            VWHAct = vOut >= warningHigh;
            VTHAct = vOut >= toleranceHigh;
            VTLAct = vOut <= toleranceLow;
            VWLAct = vOut <= warningLow;
            VALAct = vOut <= alarmLow;

            // ======================================================================
            // Extended Functionality (OPL additions)
            // ======================================================================

            WQC = 0xFF;
            OSLevel = 0x00;
            V = VSclMin + (WORD_TO_REAL(rawValue) / 27648.0) * (VSclMax - VSclMin);
            vOut = V;
            VSclMin = scaleMin;
            VSclMax = scaleMax;
            VUnit = valueUnit;
            VAHEn = alarmHighEn;
            VWHEn = warningHighEn;
            VTHEn = toleranceHighEn;
            VTLEn = toleranceLowEn;
            VWLEn = warningLowEn;
            VALEn = alarmLowEn;
        }
    }
}
