// ==============================================================================
// PIDController - Function Block
// ==============================================================================
// Generated from Open Process Library specification
// Template: csharp
// ==============================================================================

using System;

namespace OpenProcessLibrary
{
    /// <summary>
    /// PIDController function block
    /// Flattened implementation including PIDCtrl interface
    /// </summary>
    public class PIDController
    {
        // ======================================================================
        // MTP Interface Variables (from PIDCtrl)
        // ======================================================================
        // Input Variables
        [Tag] public bool StateChannel;
        [Tag] public bool StateOffAut;
        [Tag] public bool StateOpAut;
        [Tag] public bool StateAutAut;
        [Tag] public bool SrcChannel;
        [Tag] public bool SrcManAut;
        [Tag] public bool SrcIntAut;
        [Tag] public byte WQC;
        [Tag] public byte OSLevel;
        [Tag] public double PV;
        [Tag] public double PVSclMin;
        [Tag] public double PVSclMax;
        [Tag] public int PVUnit;
        [Tag] public double SPInt;
        [Tag] public double SPSclMin;
        [Tag] public double SPSclMax;
        [Tag] public int SPUnit;
        [Tag] public double SPIntMin;
        [Tag] public double SPIntMax;
        [Tag] public double SPManMin;
        [Tag] public double SPManMax;
        [Tag] public double MVMin;
        [Tag] public double MVMax;
        [Tag] public int MVUnit;
        [Tag] public double MVSclMin;
        [Tag] public double MVSclMax;
        [Tag] public double P;
        [Tag] public double Ti;
        [Tag] public double Td;
        // Output Variables
        [Tag] public bool StateOpAct;
        [Tag] public bool StateAutAct;
        [Tag] public bool StateOffAct;
        [Tag] public bool SrcIntAct;
        [Tag] public bool SrcManAct;
        [Tag] public double SP;
        [Tag] public double MV;
        // Local Variables
        [Tag] private bool StateOffOp;
        [Tag] private bool StateOpOp;
        [Tag] private bool StateAutOp;
        [Tag] private bool SrcIntOp;
        [Tag] private bool SrcManOp;
        [Tag] private double SPMan;
        [Tag] private double MVMan;

        // ======================================================================
        // Extended Variables (OPL additions)
        // ======================================================================
        // Input Variables
        [Tag] public int id;
        [Tag] public bool activateManualSP;
        [Tag] public bool activateDynamicSP;
        [Tag] public bool activateFixedSP;
        [Tag] public double dynamicSP;
        [Tag] public double fixedSP;
        [Tag] public ushort rawValue;
        [Tag] public int valueUnit;
        [Tag] public int manipulatedValueUnit;
        [Tag] public double scaleMin = 0;
        [Tag] public double scaleMax = 100;
        [Tag] public double scaleMinMV = 0;
        [Tag] public double scaleMaxMV = 100;
        [Tag] public double proportional = 1.0;
        [Tag] public double integration = 0.1;
        [Tag] public double derivation = 0;
        [Tag] public double alarmHigh;
        [Tag] public double warningHigh;
        [Tag] public double toleranceHigh;
        [Tag] public double toleranceLow;
        [Tag] public double warningLow;
        [Tag] public double alarmLow;
        [Tag] public bool alarmHighEn;
        [Tag] public bool warningHighEn;
        [Tag] public bool toleranceHighEn;
        [Tag] public bool toleranceLowEn;
        [Tag] public bool warningLowEn;
        [Tag] public bool alarmLowEn;
        [Tag] public double deadband;
        [Tag] public bool externalFault;
        // Output Variables
        [Tag] public double setpointOut;
        [Tag] public double valueOut;
        [Tag] public double manipulatedValue;
        [Tag] public bool remote;
        [Tag] public bool operatorMode;
        [Tag] public bool automaticMode;
        [Tag] public bool offlineMode;
        [Tag] public bool error;
        [Tag] public bool alarmHighStatus;
        [Tag] public bool warningHighStatus;
        [Tag] public bool toleranceHighStatus;
        [Tag] public bool toleranceLowStatus;
        [Tag] public bool warningLowStatus;
        [Tag] public bool alarmLowStatus;
        [Tag] public bool programSelectsSP;
        [Tag] public bool operatorSelectsSP;
        [Tag] public bool manualSPAct;
        [Tag] public bool internalSPAct;
        [Tag] public bool dynamicSPAct;
        [Tag] public bool fixedSPAct;

        // Control Variables
        private bool first_scan = true;
        private bool second_scan = false;
        // Helper variables for sync detection
        private double PLast;
        private double TiLast;
        private double TdLast;

        // ======================================================================
        // Constructor
        // ======================================================================
        public PIDController()
        {
            // Initialize default values
            this.scaleMin = 0;
            this.scaleMax = 100;
            this.scaleMinMV = 0;
            this.scaleMaxMV = 100;
            this.proportional = 1.0;
            this.integration = 0.1;
            this.derivation = 0;
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
            // MTP Interface Functionality (from PIDCtrl)
            // ======================================================================


            // ======================================================================
            // Extended Functionality (OPL additions)
            // ======================================================================

            WQC = 0xFF;
            OSLevel = 0x00;
            remote = StateChannel;
            operatorMode = StateOpAct;
            automaticMode = StateAutAct;
            offlineMode = StateOffAct;
            programSelectsSP = SrcChannel;
            operatorSelectsSP = ! SrcChannel;
            internalSPAct = SrcIntAct;
            manualSPAct = SrcManAct;
            SrcManAut = activateManualSP;
            SrcIntAut = activateDynamicSP || activateFixedSP;
            if (activateFixedSP)
            {
                fixedSPAct = true;
            }
            if (activateDynamicSP)
            {
                fixedSPAct = false;
            }
            dynamicSPAct = ! fixedSPAct;
            PV = scaleMin + (WORD_TO_REAL(rawValue) / 27648.0) * (scaleMax - scaleMin);
            valueOut = PV;
            PVSclMin = scaleMin;
            PVSclMax = scaleMax;
            PVUnit = valueUnit;
            SPInt = (dynamicSP * BOOL_TO_REAL(dynamicSPAct)) + (fixedSP * BOOL_TO_REAL(fixedSPAct));
            SPSclMin = scaleMin;
            SPSclMax = scaleMax;
            SPUnit = valueUnit;
            SPIntMin = scaleMin;
            SPIntMax = scaleMax;
            SPManMin = scaleMin;
            SPManMax = scaleMax;
            setpointOut = SP;
            manipulatedValue = MV;
            MVMin = scaleMinMV;
            MVMax = scaleMaxMV;
            MVUnit = manipulatedValueUnit;
            MVSclMin = scaleMinMV;
            MVSclMax = scaleMaxMV;
            activateManualSP = false;
            activateDynamicSP = false;
            activateFixedSP = false;
        }
    }
}
