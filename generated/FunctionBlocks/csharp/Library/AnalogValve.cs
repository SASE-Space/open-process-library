// ==============================================================================
// AnalogValve - Function Block
// ==============================================================================
// Generated from Open Process Library specification
// Template: csharp
// ==============================================================================

using System;

namespace OpenProcessLibrary
{
    /// <summary>
    /// AnalogValve function block
    /// Flattened implementation including MonAnaVlv interface
    /// </summary>
    public class AnalogValve
    {
        // ======================================================================
        // MTP Interface Variables (from MonAnaVlv)
        // ======================================================================

        [Tag] public string Name;
        [Tag] public string Type = "AnalogValve";
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
        [Tag] public bool SafePosEn;
        [Tag] public bool OpenAut;
        [Tag] public bool CloseAut;
        [Tag] public double PosSclMin;
        [Tag] public double PosSclMax;
        [Tag] public int PosUnit;
        [Tag] public double PosMin;
        [Tag] public double PosMax;
        [Tag] public double PosInt;
        [Tag] public bool OpenFbkCalc;
        [Tag] public bool OpenFbk;
        [Tag] public bool CloseFbkCalc;
        [Tag] public bool CloseFbk;
        [Tag] public bool PosFbkCalc;
        [Tag] public double PosFbk;
        [Tag] public bool ResetAut;
        // Output Variables
        [Tag] public bool StateOpAct;
        [Tag] public bool StateAutAct;
        [Tag] public bool StateOffAct;
        [Tag] public bool SrcIntAct;
        [Tag] public bool SrcManAct;
        [Tag] public bool SafePosAct;
        [Tag] public bool OpenAct;
        [Tag] public bool CloseAct;
        [Tag] public double Pos;
        // Local Variables
        [Tag] private bool StateOffOp;
        [Tag] private bool StateOpOp;
        [Tag] private bool StateAutOp;
        [Tag] private bool SrcIntOp;
        [Tag] private bool SrcManOp;
        [Tag] private bool OpenOp;
        [Tag] private bool CloseOp;
        [Tag] private double PosMan;
        [Tag] private double PosRbk;
        [Tag] private bool ResetOp;

        // ======================================================================
        // Extended Variables (OPL additions)
        // ======================================================================
        // Input Variables
        [Tag] public int id;
        [Tag] public bool activateManualSource;
        [Tag] public bool activateDynamicSource;
        [Tag] public bool activateFixedSource;
        [Tag] public double dynamicSource;
        [Tag] public double fixedSource;
        [Tag] public ushort feedbackPosition;
        [Tag] public double scaleMin = 0;
        [Tag] public double scaleMax = 100;
        [Tag] public bool feedbackOpen;
        [Tag] public bool feedbackClose;
        [Tag] public bool hasFbOpen;
        [Tag] public bool hasFbClose;
        [Tag] public bool safeOpen;
        [Tag] public bool enableSafePos;
        [Tag] public bool simulate;
        [Tag] public double simulateDelay = 1;
        [Tag] public bool interlockIn;
        [Tag] public bool permitIn = true;
        [Tag] public bool protectIn;
        [Tag] public bool reset;
        // Output Variables
        [Tag] public ushort positionOutDevice;
        [Tag] public double positionOut;
        [Tag] public bool remote;
        [Tag] public bool operatorMode;
        [Tag] public bool automaticMode;
        [Tag] public bool offlineMode;
        [Tag] public bool error;
        [Tag] public bool opened;
        [Tag] public bool closed;
        [Tag] public bool programSelectsSource;
        [Tag] public bool operatorSelectsSource;
        [Tag] public bool manualSourceAct;
        [Tag] public bool internalSourceAct;
        [Tag] public bool dynamicSourceAct;
        [Tag] public bool fixedSourceAct;
        // Local Variables
        [Tag] private bool fbOpenSimulated;
        [Tag] private bool fbCloseSimulated;
        [Tag] private double selectedPosition;

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
        public AnalogValve(string InstanceName)
        {
            this.Name = InstanceName;

            // Initialize default values
            this.scaleMin = 0;
            this.scaleMax = 100;
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
            // MTP Interface Functionality (from MonAnaVlv)
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
            programSelectsSource = SrcChannel;
            operatorSelectsSource = ! SrcChannel;
            internalSourceAct = SrcIntAct;
            manualSourceAct = SrcManAct;
            SrcManAut = activateManualSource;
            SrcIntAut = activateDynamicSource || activateFixedSource;
            if (activateFixedSource)
            {
                fixedSourceAct = true;
            }
            if (activateDynamicSource)
            {
                fixedSourceAct = false;
            }
            dynamicSourceAct = ! fixedSourceAct;
            PermEn = true;
            IntlEn = true;
            ProtEn = true;
            Permit = permitIn;
            Interlock = ! interlockIn;
            Protect = ! protectIn;
            SafePos = safeOpen;
            SafePosEn = enableSafePos;
            selectedPosition = (PosInt * BOOL_TO_REAL(SrcIntAct)) + (PosMan * BOOL_TO_REAL(SrcManAct));
            OpenAut = selectedPosition > 0;
            CloseAut = ! OpenAut;
            OpenFbkCalc = simulate || ! hasFbOpen;
            CloseFbkCalc = simulate || ! hasFbClose;
            PosFbkCalc = simulate;
            DelayTimer1.Execute(OpenFbkCalc && OpenAut, TimeSpan.FromSeconds(simulateDelay));
            fbOpenSimulated = DelayTimer1.Q;
            DelayTimer2.Execute(CloseFbkCalc && ! OpenAut, TimeSpan.FromSeconds(simulateDelay));
            fbCloseSimulated = DelayTimer2.Q;
            OpenFbk = (feedbackOpen && ! OpenFbkCalc) || (fbOpenSimulated && OpenFbkCalc);
            CloseFbk = (feedbackClose && ! CloseFbkCalc) || (fbCloseSimulated && CloseFbkCalc);
            opened = OpenFbk;
            closed = CloseFbk;
            ResetAut = reset;
            PosSclMin = scaleMin;
            PosSclMax = scaleMax;
            PosUnit = 0;
            PosMin = PosSclMin;
            PosMax = PosSclMax;
            PosInt = (dynamicSource * BOOL_TO_REAL(dynamicSourceAct)) + (fixedSource * BOOL_TO_REAL(fixedSourceAct));
            PosFbk = (positionOut * BOOL_TO_REAL(simulate)) + (feedbackPosition * BOOL_TO_REAL(simulate));
            positionOut = Pos;
            reset = false;
            activateManualSource = false;
            activateDynamicSource = false;
            activateFixedSource = false;
        }
    }
}
