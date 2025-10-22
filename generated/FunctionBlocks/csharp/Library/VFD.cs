// ==============================================================================
// VFD - Function Block
// ==============================================================================
// Generated from Open Process Library specification
// Template: csharp
// ==============================================================================

using System;

namespace OpenProcessLibrary
{
    /// <summary>
    /// VFD function block
    /// Flattened implementation including MonAnaDrv interface
    /// </summary>
    public class VFD
    {
        // ======================================================================
        // MTP Interface Variables (from MonAnaDrv)
        // ======================================================================

        [Tag] public string Name;
        [Tag] public string Type = "VFD";
        // Input Variables
        [Tag] public bool StateChannel;
        [Tag] public bool StateOffAut;
        [Tag] public bool StateOpAut;
        [Tag] public bool StateAutAut;
        [Tag] public bool SrcChannel;
        [Tag] public bool SrcManAut;
        [Tag] public bool SrcIntAut;
        [Tag] public bool PermEn;
        [Tag] public bool Permit;
        [Tag] public bool IntlEn;
        [Tag] public bool Interlock;
        [Tag] public bool ProtEn;
        [Tag] public bool Protect;
        [Tag] public byte WQC;
        [Tag] public byte OSLevel;
        [Tag] public bool SafePos;
        [Tag] public bool FwdEn;
        [Tag] public bool RevEn;
        [Tag] public bool StopAut;
        [Tag] public bool FwdAut;
        [Tag] public bool RevAut;
        [Tag] public double RpmSclMin;
        [Tag] public double RpmSclMax;
        [Tag] public int RpmUnit;
        [Tag] public double RpmMin;
        [Tag] public double RpmMax;
        [Tag] public double RpmInt;
        [Tag] public bool RevFbkCalc;
        [Tag] public bool RevFbk;
        [Tag] public bool FwdFbkCalc;
        [Tag] public bool FwdFbk;
        [Tag] public bool RpmFbkCalc;
        [Tag] public double RpmFbk;
        [Tag] public bool Trip;
        [Tag] public bool ResetAut;
        [Tag] public bool MonSafePos;
        [Tag] public double MonStatTi;
        [Tag] public double MonDynTi;
        // Output Variables
        [Tag] public bool StateOpAct;
        [Tag] public bool StateAutAct;
        [Tag] public bool StateOffAct;
        [Tag] public bool SrcIntAct;
        [Tag] public bool SrcManAct;
        [Tag] public bool SafePosAct;
        [Tag] public bool FwdCtrl;
        [Tag] public bool RevCtrl;
        [Tag] public double Rpm;
        [Tag] public bool MonStatErr;
        [Tag] public bool MonDynErr;
        // Local Variables
        [Tag] private bool StateOffOp;
        [Tag] private bool StateOpOp;
        [Tag] private bool StateAutOp;
        [Tag] private bool SrcIntOp;
        [Tag] private bool SrcManOp;
        [Tag] private bool StopOp;
        [Tag] private bool FwdOp;
        [Tag] private bool RevOp;
        [Tag] private double RpmMan;
        [Tag] private double RpmRbk;
        [Tag] private bool ResetOp;
        [Tag] private bool MonEn;

        // ======================================================================
        // Extended Variables (OPL additions)
        // ======================================================================
        // Input Variables
        [Tag] public int id;
        [Tag] public bool forward;
        [Tag] public bool reverse;
        [Tag] public double speed;
        [Tag] public int speedUnit;
        [Tag] public double speedMin = 0;
        [Tag] public double speedMax = 100;
        [Tag] public bool forwardFeedback;
        [Tag] public bool reverseFeedback;
        [Tag] public ushort speedFeedback;
        [Tag] public double speedScaleMin;
        [Tag] public double speedScaleMax;
        [Tag] public bool hasFwdFeedback = true;
        [Tag] public bool hasRevFeedback = true;
        [Tag] public bool enableForward;
        [Tag] public bool enableReverse;
        [Tag] public bool trip = true;
        [Tag] public bool safeHold;
        [Tag] public bool monitor = true;
        [Tag] public double staticTimeout = 2;
        [Tag] public double dynamicTimeout = 5;
        [Tag] public bool simulate;
        [Tag] public double simulateDelay = 1;
        [Tag] public bool interlockIn;
        [Tag] public bool permitIn = true;
        [Tag] public bool protectIn;
        [Tag] public bool reset;
        // Output Variables
        [Tag] public bool fwdCommand;
        [Tag] public bool revCommand;
        [Tag] public bool forwardActive;
        [Tag] public bool reverseActive;
        [Tag] public double actualSpeed;
        [Tag] public bool remote;
        [Tag] public bool operatorMode;
        [Tag] public bool automaticMode;
        [Tag] public bool offlineMode;
        [Tag] public bool remoteSource;
        [Tag] public bool internalSourceAct;
        [Tag] public bool manualSourceAct;
        // Local Variables
        [Tag] private bool fwdFbkSimulated;
        [Tag] private bool revFbkSimulated;

        // Control Variables
        private bool first_scan = true;
        private bool second_scan = false;
        // Delay timers
        private TON DelayTimer1 = new TON();
        private TON DelayTimer2 = new TON();
        // Helper variables for sync detection

        // ======================================================================
        // Constructor
        // ======================================================================
        public VFD(string InstanceName)
        {
            this.Name = InstanceName;

            // Initialize default values
            this.speedMin = 0;
            this.speedMax = 100;
            this.hasFwdFeedback = true;
            this.hasRevFeedback = true;
            this.trip = true;
            this.monitor = true;
            this.staticTimeout = 2;
            this.dynamicTimeout = 5;
            this.simulateDelay = 1;
            this.permitIn = true;
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
                // switch control mode back to operator
                StateChannel = false;
                // reset command to switch to auto mode
                StateAutAut = false;
                // end second scan
                second_scan = false;
            }

            // STARTUP - FIRST SCAN
            if (first_scan)
            {
                // allow program control for the mode
                StateChannel = true;
                // switch to auto mode
                StateAutAut = true;
                // send a reset (will be reset automatically) (TODO: why is this needed?)
                reset = true;
                // prepare second scan
                first_scan = false;
                second_scan = true;
            }
            // ======================================================================
            // MTP Interface Functionality (from MonAnaDrv)
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
            remoteSource = SrcChannel;
            internalSourceAct = SrcIntAct;
            manualSourceAct = SrcManAct;
            PermEn = true;
            IntlEn = true;
            ProtEn = true;
            Permit = permitIn;
            Interlock = ! interlockIn;
            Protect = ! protectIn;
            SafePos = false;
            FwdAut = forward;
            RevAut = reverse;
            fwdCommand = FwdCtrl;
            revCommand = RevCtrl;
            FwdFbkCalc = simulate || ! hasFwdFeedback;
            RevFbkCalc = simulate || ! hasRevFeedback;
            DelayTimer1.Execute((simulate || ! hasFwdFeedback) && fwdCommand, TimeSpan.FromSeconds(simulateDelay));
            fwdFbkSimulated = DelayTimer1.Q;
            DelayTimer2.Execute((simulate || ! hasRevFeedback) && ! revCommand, TimeSpan.FromSeconds(simulateDelay));
            revFbkSimulated = DelayTimer2.Q;
            FwdFbk = (forwardFeedback && ! FwdFbkCalc) || (fwdFbkSimulated && FwdFbkCalc);
            RevFbk = (reverseFeedback && ! RevFbkCalc) || (revFbkSimulated && RevFbkCalc);
            Trip = trip;
            ResetAut = reset;
            RpmSclMin = speedMin;
            RpmSclMax = speedMax;
            RpmUnit = speedUnit;
            RpmMin = speedMin;
            RpmMax = speedMax;
            RpmRbk = speedFeedback;
            actualSpeed = Rpm;
            reset = false;
            MonSafePos = safeHold;
            MonStatTi = staticTimeout;
            MonDynTi = dynamicTimeout;
        }
    }
}
