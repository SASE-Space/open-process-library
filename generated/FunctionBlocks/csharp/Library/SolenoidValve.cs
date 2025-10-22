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

        [Tag] public string Name;
        [Tag] public string Type = "SolenoidValve";
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
        private TON DelayTimer3 = new TON();
        private TON DelayTimer4 = new TON();
        // Helper variables for sync detection

        // ======================================================================
        // Constructor
        // ======================================================================
        public SolenoidValve(string InstanceName)
        {
            this.Name = InstanceName;

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


    
            // State Machine for the OperationMode
            switch (OperationMode)
            {
                case 0: // Offline
                    if ((StateOpAut && StateChannel) || (StateOpOp && ! StateChannel))
                    {
                        OperationMode = 1;
                    }
                    break;
                case 1: // Operator
                    if ((StateOffAut && StateChannel) || (StateOffOp && ! StateChannel))
                    {
                        OperationMode = 0;
                    }
                    if ((StateAutAut && StateChannel) || (StateAutOp && ! StateChannel))
                    {
                        OperationMode = 2;
                    }
                    break;
                case 2: // Automatic
                    if ((StateOpAut && StateChannel) || (StateOpOp && ! StateChannel))
                    {
                        OperationMode = 1;
                    }
                    break;
            }

    
            // Make boolean indicators for the OperationMode State
            StateOpAct = OperationMode == 1;
            StateAutAct = OperationMode == 2;
            StateOffAct = OperationMode == 0;

    
            // 'Protect' is for interlocks that need to be reset
            if ((ResetAut && StateChannel) || (ResetOp && ! StateChannel))
            {
                Protect = false;
            }

    
            // signal indicating that the valve needs to go to the safe position
            SafePosAct = (PermEn && ! Permit) || (IntlEn && ! Interlock) || (ProtEn && ! Protect) || (MonEn && (MonStatErr || MonDynErr));

    
            // control signal to the hardware
            if ((SafePosAct && SafePos && ! SafePosEn) || (! SafePosAct && ((OpenAut && StateAutAct) || (OpenOp && StateOpAct))))
            {
                Ctrl = true;
            }
            if ((SafePosAct && ! SafePos && ! SafePosEn) || (! SafePosAct && ((CloseAut && StateAutAct) || (CloseOp && StateOpAct))))
            {
                Ctrl = false;
            }

    
            // Opened and Closed States
            if (Ctrl && OpenFbk)
            {
                OpenedState = true;
            }
            if (! Ctrl)
            {
                OpenedState = false;
            }
            if (! Ctrl && CloseFbk)
            {
                ClosedState = true;
            }
            if (Ctrl)
            {
                ClosedState = false;
            }

    
            // Static and Dynamic Monitoring
            DelayTimer1.Execute((MonEn && OpenedState && ! OpenFbk) || ( MonEn && ClosedState && ! CloseFbk), TimeSpan.FromSeconds(MonStatTi));
            if (DelayTimer1.Q)
            {
                MonStatErr = true;
            }
            if ((ResetAut && StateChannel) || (ResetOp && ! StateChannel))
            {
                MonStatErr = false;
            }
            DelayTimer2.Execute(MonEn && ((Ctrl && ! OpenFbk) || (! Ctrl && ! CloseFbk)), TimeSpan.FromSeconds(MonDynTi));
            if (DelayTimer2.Q)
            {
                MonDynErr = true;
            }
            if ((ResetAut && StateChannel) || (ResetOp && ! StateChannel))
            {
                MonDynErr = false;
            }

    
            // reset operator command
            StateOffOp = false;
            StateOpOp = false;
            StateAutOp = false;
            OpenOp = false;
            CloseOp = false;
            ResetOp = false;

    

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
            DelayTimer3.Execute(OpenFbkCalc && Ctrl, TimeSpan.FromSeconds(simulateDelay));
            fbOpenSimulated = DelayTimer3.Q;
            DelayTimer4.Execute(CloseFbkCalc && ! Ctrl, TimeSpan.FromSeconds(simulateDelay));
            fbCloseSimulated = DelayTimer4.Q;
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
