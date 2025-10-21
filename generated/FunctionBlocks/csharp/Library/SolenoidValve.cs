// ==============================================================================
// SolenoidValve - Function Block
// ==============================================================================
// Generated from Open Process Library specification
// Template: csharp
// ==============================================================================

using System;

namespace OpenProcessLibrary
{
    /// <summary>
    /// SolenoidValve function block
    /// Flattened implementation including MonBinVlv interface
    /// </summary>
    public class SolenoidValve
    {
        // ======================================================================
        // MTP Interface Variables (from MonBinVlv)
        // ======================================================================
        // Input Variables
        [Tag] public bool StateChannel;
        [Tag] public bool StateOffAut;
        [Tag] public bool StateOpAut;
        [Tag] public bool StateAutAut;
        [Tag] public bool PermEn;
        [Tag] public bool IntlEn;
        [Tag] public bool ProtEn;
        [Tag] public bool Permit;
        [Tag] public bool Interlock;
        [Tag] public bool Protect;
        [Tag] public byte WQC;
        [Tag] public byte OSLevel;
        [Tag] public bool SafePos;
        [Tag] public bool SafePosEn;
        [Tag] public bool OpenAut;
        [Tag] public bool CloseAut;
        [Tag] public bool OpenFbkCalc;
        [Tag] public bool CloseFbkCalc;
        [Tag] public bool OpenFbk;
        [Tag] public bool CloseFbk;
        [Tag] public bool MonSafePos;
        [Tag] public double MonStatTi = 5;
        [Tag] public double MonDynTi = 2;
        [Tag] public bool ResetAut;
        // Output Variables
        [Tag] public bool StateOpAct;
        [Tag] public bool StateAutAct;
        [Tag] public bool StateOffAct;
        [Tag] public bool SafePosAct;
        [Tag] public bool Ctrl;
        [Tag] public bool MonStatErr;
        [Tag] public bool MonDynErr;
        [Tag] public int OperationMode;
        // Local Variables
        [Tag] private bool StateOffOp;
        [Tag] private bool StateOpOp;
        [Tag] private bool StateAutOp;
        [Tag] private bool OpenOp;
        [Tag] private bool CloseOp;
        [Tag] private bool ResetOp;
        [Tag] private bool MonEn;
        [Tag] private bool OpenedState;
        [Tag] private bool ClosedState;

        // ======================================================================
        // Extended Variables (OPL additions)
        // ======================================================================
        // Input Variables
        [Tag] public int id;
        [Tag] public bool open;
        [Tag] public bool close;
        [Tag] public bool outsideOpen;
        [Tag] public bool outsideClose;
        [Tag] public bool feedbackOpen = true;
        [Tag] public bool feedbackClose = true;
        [Tag] public bool hasFbOpen;
        [Tag] public bool hasFbClose;
        [Tag] public bool safeOpen;
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
        [Tag] public bool externalFault;
        [Tag] public bool surpressAlarms;
        [Tag] public bool setAuto;
        [Tag] public bool setManual;
        [Tag] public bool setOutside;
        // Output Variables
        [Tag] public bool openCommand;
        [Tag] public bool pulseOpen;
        [Tag] public bool pulseClose;
        [Tag] public bool remote;
        [Tag] public bool operatorMode;
        [Tag] public bool automaticMode;
        [Tag] public bool offlineMode;
        [Tag] public bool outside;
        [Tag] public bool error;
        [Tag] public bool opened;
        [Tag] public bool closed;
        [Tag] public bool forceActive;
        [Tag] public bool surpressed;
        // Local Variables
        [Tag] private bool fbOpenSimulated;
        [Tag] private bool fbCloseSimulated;

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
        public SolenoidValve()
        {
            // Initialize default values
            this.MonStatTi = 5;
            this.MonDynTi = 2;
            this.feedbackOpen = true;
            this.feedbackClose = true;
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
            // MTP Interface Functionality (from MonBinVlv)
            // ======================================================================


    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

            // ======================================================================
            // Extended Functionality (OPL additions)
            // ======================================================================

            WQC = 0xFF;
            remote = StateChannel;
            operatorMode = StateOpAct;
            automaticMode = StateAutAct;
            offlineMode = StateOffAct;
            PermEn = true;
            IntlEn = true;
            ProtEn = true;
            Permit = permitIn;
            Interlock = ! interlockIn;
            Protect = ! protectIn;
            SafePos = safeOpen;
            MonSafePos = safeOpen;
            SafePosEn = safeHold;
            OpenAut = open;
            CloseAut = close;
            OpenFbkCalc = simulate || ! hasFbOpen;
            CloseFbkCalc = simulate || ! hasFbClose;
            DelayTimer1.Execute(OpenFbkCalc && Ctrl, TimeSpan.FromSeconds(simulateDelay));
            fbOpenSimulated = DelayTimer1.Q;
            DelayTimer2.Execute(CloseFbkCalc && ! Ctrl, TimeSpan.FromSeconds(simulateDelay));
            fbCloseSimulated = DelayTimer2.Q;
            OpenFbk = (feedbackOpen && ! OpenFbkCalc) || (fbOpenSimulated && OpenFbkCalc);
            CloseFbk = (feedbackClose && ! CloseFbkCalc) || (fbCloseSimulated && CloseFbkCalc);
            opened = Ctrl && OpenFbk;
            closed = ! Ctrl && CloseFbk;
            ResetAut = reset;
            MonEn = monitor;
            MonStatTi = staticTimeout;
            MonDynTi = dynamicTimeout;
            reset = false;
        }
    }
}
