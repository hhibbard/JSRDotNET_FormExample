﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSRDotNETSDK;

namespace Holly_s_JSRDotNET_FormExample
{
    /// <summary>
    /// An example of a Form-based application which can communicate with any combination of
    /// JSR Ultrasonics Pulser Receivers for which there is a DLL for. This application handles
    /// dynamic attach and re-attach of USB pulser receivers.
    /// </summary>
    public partial class FormExample : Form
    {

        #region String Constants
        //The following string constants are the names of properties in the DPR plugin which are not
        //in the IPulserReceiver interface.

        const string PRPropertyNamePulserModel = "PulserModel";
        const string PRPropertyNameReceiverModel = "ReceiverModel";
        const string PRPropertyNameIsPulserPresent = "IsPulserPresent";

        /// <summary>The name of the plugin which provides simulated instruments. </summary>
        const string PLUGIN_NAME_PRSIM = "JSRDotNET_DiagLib";

        /// <summary>The name of the plugin for DPR500 and DPR300.</summary>
        const string PLUGIN_NAME_DPR = "JSRDotNET_DPR";

        /// <summary>The plugin name USB PureView Board.</summary>
        const string PLUGIN_NAME_USB_PUREVIEW_BOARD = "JSRDotNET_PureViewBrd";

        #endregion

        #region Local Variables
        /// <summary>The path to the JSRDotNETSDK Instrument Plugins</summary>
        string PROGRAM_PLUGIN_PATH = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Plugins";

        /// <summary>The JSRDotNETManager object handles loading the plugins, as well as communicating
        /// with the instruments.</summary>
        JSRDotNETManager m_jsrManager;

        /// <summary> This is set to true when the controls are being updated, so we can tell the difference
        /// between a user manipulated control versus normal programmatic changes.</summary>
        bool m_bLoadingControls;

        #endregion

        #region Local Definitions and Consts
        /// <summary>
        /// A PR list box item
        /// <seealso cref="System.ThrowHelper:System.IEquatable{JSRDotNET_FormExample.FormExample.PRListBoxItem}"/>
        /// </summary>
        /// 
        class PRListBoxItem: IEquatable<PRListBoxItem>
        {
            public string ModelName { get; set; }
            public string SerialNum { get; set; }
            public int Index { get; set; }
            public string PulserModel { get; set; }

            ///
            /// <summary>Constructor</summary>
            /// 
            public PRListBoxItem(string modelName, string serialNum, int index = 0, string pulserModel = "")
            {
                ModelName = modelName;
                SerialNum = serialNum;
                Index = index;
                PulserModel = pulserModel;
            }

            ///<summary>Returns a string that represents the current object.</summary>
            ///<returns>A string that represents the current object.</returns>
            ///<seealso cref="ModelName:System.Object.ToString()"/>
            ///
            public override string ToString()
            {
                string strRet = ModelName + (Index == 0 ? " ChA " : " ChB ");
                if (ModelName.ToUpper().StartsWith("DPR500")) strRet += " " + PulserModel;
                strRet += " SN: " + SerialNum;
                return strRet;
            }

            ///<summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the 
            ///current <see cref="T:System.Object"/>.</summary>
            ///<param name="obj">The object to compare with the current object.</param>
            ///<returns>True if the spcified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; 
            ///otherwise false.</returns>
            ///<seealso cref="M:System.Object.Equals(object)"/>
            ///
            public override bool Equals(object obj)
            {
                bool bRet = null != obj;
                if (bRet)
                {
                    bRet = obj is PRListBoxItem;
                }
                if (bRet)
                {
                    PRListBoxItem other = obj as PRListBoxItem;
                    bRet = Equals(other);
                }
                return bRet;
            }

            /// <summary>Tests if this PRListBoxItem is considered equal to another.</summary>
            /// <param name="other">The PR list box item to compare this object to.</param>
            /// <returns>True if the objects are considered equal, false if they are not.</returns>
            /// 
            public bool Equals(PRListBoxItem other)
            {
                bool bRet = null != other;
                if (bRet)
                {
                    bRet = (ModelName.ToUpperInvariant() == other.ModelName.ToUpperInvariant()) &&
                        (SerialNum.ToUpperInvariant() == other.SerialNum.ToUpperInvariant()) && (Index == other.Index);
                }
                return bRet;
            }


            /// <summary>
            /// Query if this item has a matching model number, serial number, and channel index.
            /// </summary>
            /// <param name="modelName">Name of the model</param>
            /// <param name="serialNumber">The serial number</param>
            /// <param name="prIndex">Zero-based index of the PR</param>
            /// <returns>True if there is a match, false if not</returns>
            public bool IsMatch(string modelName, string serialNumber, int prIndex)
            {
                return (modelName == ModelName) && (SerialNum == serialNumber) && (Index == prIndex);
            }


            /// <summary>
            /// Serves as a hash function for a particular type.
            /// </summary>
            /// <returns>A hash code for the current <see cref="T:System.Object"/></returns>
            /// <seealso cref="M:System.Object.GetHashCode()"/>
            public override int GetHashCode()
            {
                return ModelName.GetHashCode() ^ SerialNum.GetHashCode() ^ Index;
            }
        }
        /// <summary>
        /// A helper class to act as combo box items for floating point values.
        /// </summary>
        public class DoubleValue
        {
            /// <summary> The value </summary>
            public double value;
            /// <summary> The value as a string. </summary>
            public string sValue;
                        
            /// <summary> Constructor. </summary>
            /// <param name="_value">The value</param>
            public DoubleValue(double _value)
            {
                value = _value;
                sValue = value.ToString("F1");
            }

            /// <summary> Retuns a string that represents the current object. </summary>
            /// <returns>A string that represents the current object.</returns>
            /// <seealso cref="M:System.Object.ToString()"/>
            public override string ToString()
            {
                return sValue;
            }
        }



        #endregion

        #region Constructors
        public FormExample()
        {
            m_bLoadingControls = false;
            m_jsrManager = new JSRDotNETManager();
            try
            {
                //Load the plugins, which means finding all the plugins in the plugins folder and reading the metadata.
                //The classes in the plugin are not instantiated at this point, and no code from the plugins is being executed.
                //This step is simply to find out more information about what we can open.
                m_jsrManager.PluginPath = PROGRAM_PLUGIN_PATH;
                m_jsrManager.LoadPlugins();
            }
            catch (ExceptionJSRDotNET exJsr)
            {
                MessageBox.Show(this, exJsr.GetType().ToString() + " occurred: " + ((exJsr.Message != null) ? exJsr.Message : "(no msg"));
                Application.Exit();
            }

            //Now run through the list of plugin names and tell the manager we want to use them with the AddManagedPlugin() method.
            //If we don't add the plugins to the Manager, then the classes in that plugin will never be instantiated, and none of
            //those devices will be discovered.
            //This is a good time to specify open options for each plugin. Below we look for a specific plugin name, and tell
            //it to not automatically connect to the simulated pulser-receivers. We also do not want to see the simulator windows displayed.
            foreach (string pluginName in m_jsrManager.GetPluginNames())
            {
                m_jsrManager.AddManagedPlugin(pluginName);
                switch (pluginName)
                {
                    //For the simulator plugin, we indicate that it should not automatically connect upon startup. The simulator(s)
                    //will exist, but will not be discovered by this application until the user clicks on the attach checkbox on
                    //the simulator window. In addition, the option is set that makes the simulator windows visible upon startup.
                    case PLUGIN_NAME_PRSIM:
                        m_jsrManager.AddPluginOpenOption(PLUGIN_NAME_PRSIM, InstrumentOpenCriteria.CONNECT_ON_OPEN, "NO");
                        m_jsrManager.AddPluginOpenOption(PLUGIN_NAME_PRSIM, InstrumentOpenCriteria.SHOW_SIMULATOR_WINDOWS, "YES");
                        break;

                    //For the DPR instrument plugin, we specify that the device should continuously query to see if a remote pulser
                    //has been removed or attached. If so, property change notifications will be set to notify this application
                    case PLUGIN_NAME_DPR:
                        m_jsrManager.AddPluginOpenOption(PLUGIN_NAME_DPR, "DPR500_POLL", "ENABLE");
                        m_jsrManager.AddPluginOpenOption(PLUGIN_NAME_DPR, "SERIAL_PORT_LOG", "DISABLE");
                        break;

                    //There are presently no open options for PureView
                    case PLUGIN_NAME_USB_PUREVIEW_BOARD:
                        break;

                    default:
                        break;
                
                
                }
            }

            //If there weren't any plugins, let the user know
            if(0 >= m_jsrManager.GetPluginNames().Length)
            {
                MessageBox.Show(this, "Plugin\nPath: " +
                    m_jsrManager.PluginPath,
                    "No instrument plugins found. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Here we register to receive notification events from the Manager. These events tell us when devices get discovered,
            //when one is disconnected, or if a property has changed.
            m_jsrManager.NotifyEventHandler += HandleManagerNotifyEvents;

            InitializeComponent();
        }
        #endregion

        #region Form Helper Methods
        /// <summary>
        /// Gets a value indicating whether the currently selected pulser is ready.
        /// </summary>
        /// <returns>True if the currently selected pulser is ready, false if not</returns>
        bool CurrentlySelectedPulserIsReady
        {
            get
            {
                bool bRet = (null != m_jsrManager) && (0 <= listBoxPulserSelect.SelectedIndex);
                if (bRet)
                {
                    //Make sure the manager thinks a pulser is selected
                    bRet = m_jsrManager.IsPulserReceiverSelected;
                }
                if (bRet)
                {
                    IPulserReceiverIdentity id = m_jsrManager.Id;
                    if (id.InstrumentId.ModelName.ToUpperInvariant().StartsWith("DPR500"))
                    {
                        //If it's a DPR500, read the custom property "PulserPresent" to verify the remote pulser is still attached
                        bRet = (bool)m_jsrManager.GetPulserReceiver(id).GetPulserPropertyValue(PRPropertyNameIsPulserPresent);
                    }
                }
                return bRet;
            }
        }



        /// <summary>
        /// When no pulser receiver is selected, the form's controls should be disabled.
        /// </summary>
        /// <param name="bEnable">True to enable, false to disable.</param>
        void SetControlsEnable(bool bEnable)
        {
            cboxGain.Enabled = bEnable;
            cboxTrigSrc.Enabled = bEnable;
            ckboxTriggerEnable.Enabled = bEnable;
            cbLEDBlink.Enabled = bEnable;
            //Added receiver mode check box
            cbReceiverMode.Enabled = bEnable;
            if (!bEnable)
            {
                cbLEDBlink.Items.Clear();
                cboxGain.Items.Clear();
                cboxTrigSrc.Items.Clear();
                ckboxTriggerEnable.Checked = false;
            }
        }

        /// <summary>
        /// Sets controls default content.
        /// </summary>
        void SetControlsDefaultContent()
        {
            cboxTrigSrc.Items.Clear();
            cboxTrigSrc.Items.Add("Internal");
            cboxTrigSrc.Items.Add("External");
        }


        /// <summary>
        /// Refreshes the controls on the form with values read from the pulser receiver.
        /// This will occur if the currently selected pulser receiver changes.
        /// </summary>
        void setControlsFromPulser()
        {
            bool TrigSrcEnabled = false;
            bool bGainIndexSupported = true;
            SetControlsDefaultContent();

            SetModelandSerial(m_jsrManager.Id.InstrumentId.ModelName, 
                m_jsrManager.Id.InstrumentId.SerialNum);
            UpdateBlinkControl();

            if (CurrentlySelectedPulserIsReady)
            {
                //Lock out event handlers from responding while we programmatically change controls
                m_bLoadingControls = true;
                SetControlsEnable(true);
                
                try
                {
                    //Added the cbReceiverMode code to load the supported receiver modes into the application
                    cbReceiverMode.Enabled = true;
                    cbReceiverMode.Items.Clear();
                    if (m_jsrManager.ReceiverModeBothSupported)
                    {
                        cbReceiverMode.Items.Add("Echo");
                        cbReceiverMode.Items.Add("Through");
                        cbReceiverMode.Items.Add("Both");
                    }
                    else if (m_jsrManager.ReceiverModeEchoSupported)
                    {
                        cbReceiverMode.Items.Add("Echo");
                    }
                    else
                    {
                        cbReceiverMode.Items.Add("Through");
                    }
                    cbReceiverMode.SelectedIndex = (int)m_jsrManager.ReceiverMode;

                    //Added the low pass filter code in order to set this property for the PR
                    if (m_jsrManager.LowPassFilterIndexSupported)
                    {
                        cbLowPassFilter.Enabled = true;
                        cbLowPassFilter.Items.Clear();
                        foreach (double lowPassFilterValue in m_jsrManager.LowPassFilterValues)
                        {
                            cbLowPassFilter.Items.Add(lowPassFilterValue);
                        }
                        cbLowPassFilter.SelectedIndex = m_jsrManager.LowPassFilterIndex;
                    }


                    //Added the high pass filter code in order to set this property for the PR
                    if (m_jsrManager.HighPassFilterIndexSupported)
                    {
                        cbHighPassFilter.Enabled = true;
                        cbHighPassFilter.Items.Clear();
                        foreach (double highPassFilterValue in m_jsrManager.HighPassFilterValues)
                        {
                            cbHighPassFilter.Items.Add(highPassFilterValue);
                        }
                        cbHighPassFilter.SelectedIndex = m_jsrManager.HighPassFilterIndex;
                    }

                    //Added the Pulser Voltage Supply Enable feature
                    if (m_jsrManager.HVSupplyEnableSupported)
                    {
                        ckboxVoltageSupplyEnable.Enabled = true;
                        ckboxVoltageSupplyEnable.Checked = m_jsrManager.HVSupplyEnable;
                    }

                    ////Added Pulser Voltage combo box feature in order to support selected index change (50-300 volts) - see what index is then stop at max
                    cbPulserVoltage.Enabled = true;
                    cbPulserVoltage.Items.Clear();
                    for (double i = m_jsrManager.HVSupplyMin; i <= m_jsrManager.HVSupplyMax; i++)
                    {
                        cbPulserVoltage.Items.Add(i);
                    }
                    cbPulserVoltage.SelectedIndex = (int)m_jsrManager.HVSupply - 50;

                    //Added Pulser Energy to load the metadata into the application
                    cbPulserEnergy.Enabled = true;
                    cbPulserEnergy.Items.Clear();
                    if (m_jsrManager.PulseEnergyIndexSupported)
                    {
                        foreach (string pulseEnergyValueName in m_jsrManager.PulseEnergyValueNames)
                        {
                            cbPulserEnergy.Items.Add(pulseEnergyValueName);
                        }
                    }
                    cbPulserEnergy.SelectedIndex = m_jsrManager.PulseEnergyIndex;
                    tbEnergyPerPulse.Text = m_jsrManager.EnergyPerPulse.ToString();

                    //Added Damping
                    cbDamping.Enabled = true;
                    cbDamping.Items.Clear();
                    if (m_jsrManager.DampingIndexSupported)
                    {
                        foreach (double dampingValue in m_jsrManager.DampingValues)
                        {
                            cbDamping.Items.Add(dampingValue);
                        }
                    }
                    cbDamping.SelectedIndex = m_jsrManager.DampingIndex;

                    //Added Impedance
                    cbTriggerInputImpedance.Enabled = true;
                    cbTriggerInputImpedance.Items.Clear();
                    if (m_jsrManager.TriggerImpedanceSupported)
                    {
                        cbTriggerInputImpedance.Items.Add("50 Ohms");
                        cbTriggerInputImpedance.Items.Add("High Z");
                    }
                    cbTriggerInputImpedance.SelectedIndex = (int)m_jsrManager.TriggerImpedance;

                    //Added Trigger Edge Polarity
                    cbTriggerEdgePolarity.Enabled = true;
                    cbTriggerEdgePolarity.Items.Clear();
                    if (m_jsrManager.TriggerEdgePolaritySupported)
                    {
                        cbTriggerEdgePolarity.Items.Add("Rising");
                        cbTriggerEdgePolarity.Items.Add("Falling");
                    }
                    cbTriggerEdgePolarity.SelectedIndex = (int)m_jsrManager.TriggerEdgePolarity;


                    //Added Trackbar
                    trackbarPRF.Enabled = true;
                    trackbarPRF.Minimum = (int)m_jsrManager.PulseRepetitionFrequencyMin;
                    trackbarPRF.Maximum = (int)m_jsrManager.PulseRepetitionFrequencyMax;
                    tbPRF.Text = m_jsrManager.PulseRepetitionFrequencyMin.ToString();


                    //Power Limit Status
                    //should only show the red indicator when the power limit status has exceeded, otherwise grey
                    //which variables contribute to an overloaded power limit? PRF and Energy Per Pulse
                    PowerLimitStatusReached();


                    //Original method - added the Pulsing section after the trigger enable check box and trigger source properties
                    //have been updated from the currently selected pulser (if the pulsing method is included before this, the
                    //properties will not be updated to reflect whether the pulser is actively pulsing)
                    ckboxTriggerEnable.Enabled = true;
                    ckboxTriggerEnable.Checked = m_jsrManager.TriggerEnable;

                    if (m_jsrManager.TriggerSourceInternalSupported)
                    {
                        TrigSrcEnabled = m_jsrManager.TriggerSourceInternalSupported;
                        cboxTrigSrc.Enabled = TrigSrcEnabled;
                    }
                    int iTrigSrc = (int)m_jsrManager.TriggerSource;
                    cboxTrigSrc.SelectedIndex = iTrigSrc;


                    //Pulsing
                    IsPulserPulsing();

                    bGainIndexSupported = m_jsrManager.GainIndexSupported;
                    if (bGainIndexSupported)
                    {
                        cboxGain.Enabled = true;
                        cboxGain.Items.Clear();
                        double[] gains = m_jsrManager.GainValues;
                        foreach (double gain in gains)
                        {
                            cboxGain.Items.Add(new DoubleValue(gain));
                        }
                        cboxGain.SelectedIndex = m_jsrManager.GainIndex;
                    }
                    else if (m_jsrManager.GainStepSizeSupported)
                    {
                        double gmin = m_jsrManager.GainMin;
                        double gmax = m_jsrManager.GainMax;
                        double stepsz = m_jsrManager.GainStepSize;
                        int i = 0;
                        double gain = gmin;
                        while (gain <= gmax)
                        {
                            cboxGain.Items.Add(new DoubleValue(gain));
                            i++;
                            gain = gmin + (i * stepsz);
                        }
                        cboxGain.SelectedItem = findClosestItem(cboxGain, m_jsrManager.Gain);
                    }
                    else
                    {
                        //If the step size is not regular, and we don't have a list of gains, we need to get more creative
                        //For this demo we will not handle it since all of the current products fit into one of the two cases
                    }
                    ckboxTriggerEnable.Checked = m_jsrManager.TriggerEnable;
                }
                catch (ExceptionJSRDotNET eJSR)
                {
                    MessageBox.Show(eJSR.Message, "Error initiating controls", MessageBoxButtons.OK);
                }
                m_bLoadingControls = false;
            }
            else
            {
                SetControlsEnable(false);
            }
        }

        /// <summary>
        /// Sets model and serial number to be displayed in the form.
        /// </summary>
        /// <param name="strModel">The model.</param>
        /// <param name="strSerial">The serial number.</param>
        void SetModelandSerial(string strModel = "", string strSerial = "")
        {
            tbModel.Text = strModel;
            tbSerialNum.Text = strSerial;
        }




        /// <summary>
        /// Updates the blink control.
        /// </summary>
        private void UpdateBlinkControl()
        {
            cbLEDBlink.SelectedIndex = -1;
            cbLEDBlink.Items.Clear();

            if ((m_jsrManager.IsPulserReceiverSelected) && 
                (m_jsrManager.LEDBlinkModeIndexSupported))
            {
                cbLEDBlink.Enabled = true;
                foreach (string blinkVal in m_jsrManager.LEDBlinkModeValues)
                {
                    cbLEDBlink.Items.Add(blinkVal);
                }
                //get a copy of the value to prevent it from being set
                cbLEDBlink.SelectedIndex = m_jsrManager.LEDBlinkModeIndex;
            }
            else
            {
                cbLEDBlink.Enabled = false;
            }
        }

        /// <summary>
        /// This method checks whether the pulser is actively pulsing. If the pulser source is internal
        /// and the trigger enable box is checked, the pulser is actively pusling and we display the redPulsingImage.
        /// If the pulser receiver is not actively pusling, the grey image is displayed.
        /// </summary>
        private void IsPulserPulsing()
        {
            if (ckboxTriggerEnable.Checked && m_jsrManager.TriggerSource == TRIGGER_SOURCE.INTERNAL)
            {
                redPulsingImage.Visible = true;
            }
            else
            {
                redPulsingImage.Visible = false;
            }
        }

        /// <summary>
        /// Pulser power limit status is based on (PRF * Energy per pulse).
        /// If the pulser receiver exceeds the power limit, the redPowerLimitStatusImage is shown.
        /// Otherwise, the green image is displayed, indicating the pulser power limit is satisfactory.
        /// </summary>
        /// <returns></returns>
        private void PowerLimitStatusReached()
        {
            if (m_jsrManager.PulserPowerLimitStatus == POWER_LIMIT.OVER_LIMIT)
            {
                redPowerLimitStatusImage.Visible = true;   
            }
        }

        #endregion

        #region Helper Methods
        
        /// <summary>
        /// Searches for the nearest item.
        /// </summary>
        /// <param name="cb">The combo box.</param>
        /// <param name="enteredValue">The entered value</param>
        /// <returns>The closest found item.</returns>
        private DoubleValue findClosestItem(ComboBox cb, double enteredValue)
        {
            DoubleValue selectedItem = null;
            double smallestDiff = double.MaxValue;
            foreach (DoubleValue item in cb.Items)
            {
                double diff = item.value - enteredValue;
                if (0.0 > diff) diff = -diff;
                if (diff < smallestDiff)
                {
                    selectedItem = item;
                    smallestDiff = diff;
                }
            }
            return selectedItem;
        }


        /// <summary>
        /// For DPR500s, this helper method gets the remote pulser model, which is different from the instrument model.
        /// </summary>
        /// <param name="infoArray">Array of information.</param>
        /// <returns>The pulser model</returns>
        private string getPulserName(string[] infoArray)
        {
            string strRet = string.Empty;
            int i;
            for (i = 0; i < infoArray.ToArray().Length; i+=2)
            {
                string name = infoArray[i];
                string value = infoArray[i + 1];
                if (name == "PulserModel")
                {
                    strRet = value;
                    break;
                }
            }
            return strRet;
        }


        #endregion

        #region JSRDotNETManager Event Handlers

        /// <summary>
        /// Handles the manager notify events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="args">The arguments.</param>
        private void HandleManagerNotifyEvents(object sender, EventArgsManagerNotify args)
        {
            //This part is critical! The manager will typically call your handler from a non-gui thread.
            //You can not directly call most methods of controls.
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgsManagerNotify>(HandleManagerNotifyEvents), new object[] { sender, args });
            }
            else
            {
                string model = string.Empty;
                string serialNum = string.Empty;
                int prevSelectedIndex;
                PRListBoxItem item;
                prevSelectedIndex = listBoxPulserSelect.SelectedIndex;
                switch(args.NotifyType)
                {
                    case NOTIFY_TYPE.PULSER_RCVR_DISCOVERED:
                        HandlePulserReceiverDiscoveryNotification(args);
                        break;
                    case NOTIFY_TYPE.CURRENT_PULSER_RCVR_CHANGED:
                        setControlsFromPulser();
                        break;
                    case NOTIFY_TYPE.PROPERTY_CHANGE:
                        HandlePropertyChangeNotifications(args);
                        break;
                    case NOTIFY_TYPE.PULSER_RCVR_DETACH:
                        item = new PRListBoxItem(args.Model, args.Serial, args.PRIndex);
                        //Search the iems in the listBox for a pulser with the same model, serial number, and pulser index as the one that is now removed
                        for (int i = 0; i < listBoxPulserSelect.Items.Count; i++)
                        {
                            if (listBoxPulserSelect.Items[i] is PRListBoxItem)
                            {
                                if (item.Equals(listBoxPulserSelect.Items[i] as PRListBoxItem))
                                {
                                    //Remove it from the list
                                    listBoxPulserSelect.Items.Remove(listBoxPulserSelect.Items[i]);
                                    labelInstrumentsList.Text = "Instruments (" + listBoxPulserSelect.Items.Count + " connected )";
                                    //If the one we just reoved was the currently selected one, select the first one on the list or nothing if the list is empty.
                                    if (i == prevSelectedIndex)
                                    {
                                        listBoxPulserSelect.SelectedIndex = (0 < listBoxPulserSelect.Items.Count) ? 0 : -1;
                                    }
                                    break;
                                }
                            }
                        }
                        break;
                    case NOTIFY_TYPE.ERROR:
                        MessageBox.Show(args.ErrorMsg, args.ExceptionTypeInfo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }                
            }
        }


        /// <summary>
        /// Handles the pulser receiver discovery notification described by args.
        /// </summary>
        /// <param name="args">The arguments.</param>
        void HandlePulserReceiverDiscoveryNotification(EventArgsManagerNotify args)
        {
            string model = string.Empty;
            string serialNum = string.Empty;
            int idxPR = 0;
            int prevSelectedIndex;
            int newListBoxIndex;
            PRListBoxItem item;
            bool isDPR500 = args.PulserReceiverId.InstrumentId.ModelName.ToUpperInvariant().StartsWith("DPR500");
            prevSelectedIndex = listBoxPulserSelect.SelectedIndex;

            model = args.Model;
            serialNum = args.Serial;
            idxPR = args.PRIndex;
            if (string.Empty != model)
            {
                //Here we are making a string to display in the pulser selection list.
                //Because the DPR500 has multiple remote pulsers with may different models, we need to
                //put the model number of the remote pulser in the string as well.
                if (model.ToUpper().StartsWith("DPR500"))
                {
                    item = new PRListBoxItem(model, serialNum, idxPR, getPulserName(args.Info));
                }
                else
                {
                    item = new PRListBoxItem(model, serialNum, idxPR);
                }

                //Now we add the item to the list box. If it is the first pulser discovered, we make
                //the current selection.
                newListBoxIndex = listBoxPulserSelect.Items.Add(item);
                labelInstrumentsList.Text = "Instruments ( " + listBoxPulserSelect.Items.Count + " connected )";
                if (0 > prevSelectedIndex) listBoxPulserSelect.SelectedIndex = newListBoxIndex;

                //To support the DPR500's hotswap of remot pulser, we'll need to receive some notification
                //indicating when a pulser is removed or attached, and also get the pulser modelname. Therefore
                //we create a filter. This filter specifies which pulser receiver properties we wish to receive
                //change notifications for.
                IPulserReceiver pulser = m_jsrManager.GetPulserReceiver(args.PulserReceiverId);
                if (null != pulser)
                {
                    PropertyChangeEventCriteria pcec;
                    if (isDPR500)
                    {
                        pcec = new PropertyChangeEventCriteria(new string[] {
                            PRPropertyNameIsPulserPresent,
                            PRPropertyNamePulserModel
                        });
                    }
                    else
                    {
                        pcec = new PropertyChangeEventCriteria();
                    }
                    pulser.StatusChangePropertyCriteria = pcec;
                }
            }
            else
            {
                string strPluginName = args.PluginName;
                string friendlyName = string.Empty;
                if((strPluginName != null) && (0 < strPluginName.Length))
                {
                    friendlyName = m_jsrManager.GetPluginLibraryMetadata(strPluginName).FriendlyName;
                }
                MessageBox.Show(friendlyName + " : No instruments found.");
            }
        }

        /// <summary>
        /// Query if the 'modelName' is the currently selected pulser.
        /// </summary>
        /// <param name="modelName">The name of the model.</param>
        /// <param name="serialNum">The serial number.</param>
        /// <param name="prIndex">Zero-based index of the pulser receiver.</param>
        /// <returns> True if this is the currently selected pulser, false if not.</returns>
        bool isThisTheCurrentlySelectedPulser(string modelName, string serialNum, int prIndex)
        {
            bool bRet = false;
            if (0 <= listBoxPulserSelect.SelectedIndex)
            {
                PRListBoxItem item = listBoxPulserSelect.SelectedItem as PRListBoxItem;
                if (null != item)
                {
                    bRet = (item.ModelName == modelName) && (item.SerialNum == serialNum) && (item.Index == prIndex);
                }
            }
            return bRet;
        }

        /// <summary>
        /// Handles the property change notifications. This is to support DPR500 "How Swap" of
        /// remote pulsers.
        /// </summary>
        /// <param name="args">The arguments.</param>
        void HandlePropertyChangeNotifications(EventArgsManagerNotify args)
        {
            bool bRefreshControls = false;
            if ((null != m_jsrManager) && (null != args.PropertyName) && (null != args.NewValue))
            {
                //If the DPR500 pulser model has changed because one was detached or attached, the
                //pulser model name will change. We need to update the controls on the form.
                if (args.PropertyName == PRPropertyNamePulserModel)
                {
                    HandleDPR500_PulserModelNameChange(args, (string)args.NewValue);
                }
                else if (args.PropertyName == PRPropertyNameIsPulserPresent)
                {
                    //If the DPR500 'PulserIsPresent' property changes, we need to refresh the controls.
                    bRefreshControls = isThisTheCurrentlySelectedPulser(args.Model, args.Serial, args.PRIndex);
                }
            }
            if (bRefreshControls)
            {
                setControlsFromPulser();
            }
        }


        /// <summary>
        /// If a DPR500 remote pulser is attached or detached, the pulser model name will change,
        /// forcing us to update that line in the pulser selected listbox.
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <param name="newPulserModelName">Name of the new pulser model.</param>
        void HandleDPR500_PulserModelNameChange(EventArgsManagerNotify args, string newPulserModelName)
        {
            string modelName = args.PulserReceiverId.InstrumentId.ModelName;
            string serialNum = args.PulserReceiverId.InstrumentId.SerialNum;
            int prIndex = args.PulserReceiverId.PulserReceiverIndex;
            if (null != newPulserModelName)
            {
                for (int i = 0; i < listBoxPulserSelect.Items.Count; i++)
                {
                    PRListBoxItem item = listBoxPulserSelect.Items[i] as PRListBoxItem;
                    if (null != item)
                    {
                        if (item.IsMatch(modelName, serialNum, prIndex))
                        {
                            item.PulserModel = newPulserModelName;
                            (listBoxPulserSelect as RefreshableListBox).RefreshOneItem(i);
                        }
                    }
                }
            }
        }

        #endregion

        #region Form Event Handlers

        /// <summary>
        /// Event handle. Called by FormExample for load events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string assemblyVerShorter = assemblyVersion;
            int idxLastDot = assemblyVersion.LastIndexOf(".");
            if (idxLastDot > 2)
            {
                assemblyVerShorter = assemblyVersion.Remove(idxLastDot);
            }
            Text = string.Format(" JSR .NET Simple Form Example (Ver: {0})", assemblyVerShorter);
            MessageBox.Show("This simple example program will discover real hardware or simulated instruments.  " +
                "Click on the 'Attach Instrument' checkbox of any of the simulators to attach the pulser receiver to the application.", "FormExample Usage");
            SetControlsEnable(false);
            UpdateBlinkControl();
            SetModelandSerial();
            m_jsrManager.SetDiscoveryEnable(true);
            Thread.Sleep(500);
        }


        /// <summary>
        /// Event handler. Called by FormExample for form closing events.
        /// </summary>
        /// <param name="sender">Source of the event</param>
        /// <param name="e">Form closing event information</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetControlsEnable(false);
            SetModelandSerial();
            m_jsrManager.Shutdown();
        }

        /// <summary>
        /// Event handler. Called  by listBoxPulserSelect for selected index change events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information</param>
        private void listBoxPulserSelect_SelectedIndexChanged(object sender, EventArgs e)
        { //Nothing changed in this method, but it is the one throwing the error. Line 921 SetCurrentPulserReceiver() timing out
            if (!m_bLoadingControls)
            {
                if (0 > listBoxPulserSelect.SelectedIndex)
                {
                    SetControlsEnable(false);
                    SetModelandSerial();
                }
                else
                {
                    SetControlsEnable(true);
                    PRListBoxItem item = listBoxPulserSelect.SelectedItem as PRListBoxItem;
                    if (null != item)
                    {
                        m_jsrManager.SetCurrentPulserReceiver(new PulserReceiverIdentity(new InstrumentIdentity(item.ModelName, item.SerialNum), item.Index));
                    }
                }
            }
        }

        /// <summary>
        /// Event handler. Called by ckboxTriggerEnable for checked change events. 
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void ckboxTriggerEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                try
                {
                    m_jsrManager.TriggerEnable = ckboxTriggerEnable.Checked;
                }
                catch (ExceptionJSRDotNET eJSR)
                {
                    MessageBox.Show(eJSR.Message);
                }

                //Added to check if pulsing indicator needs to be updated
                IsPulserPulsing();
            }
        }

        /// <summary>
        /// Event handler. Called by cboxTrigSrc for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cboxTrigSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                try
                {
                    m_jsrManager.TriggerSource = (TRIGGER_SOURCE)cboxTrigSrc.SelectedIndex;
                }
                catch (ExceptionJSRDotNET eJSR)
                {
                    MessageBox.Show(eJSR.Message);
                }

                //Added to check whether pulsing indicator needs to be updated
                IsPulserPulsing();
            }
        }

        /// <summary>
        /// Event handler. Called by cboxGain for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                try
                {
                    if (m_jsrManager.GainIndexSupported)
                    {
                        m_jsrManager.GainIndex = cboxGain.SelectedIndex;
                    }
                    else
                    {
                        DoubleValue dvalue = cboxGain.SelectedValue as DoubleValue;
                        if (null != dvalue)
                        {
                            m_jsrManager.Gain = dvalue.value;
                        }
                    }
                }
                catch (ExceptionJSRDotNET eJSR)
                {
                    MessageBox.Show(eJSR.Message);
                }
            }
        }

        /// <summary>
        /// Event handler. Called by cbLEDBlink for selected index changed events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void cbLEDBlink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if ((0 <= cbLEDBlink.SelectedIndex) &&
                    (cbLEDBlink.SelectedIndex != m_jsrManager.LEDBlinkModeIndex))
                {
                    m_jsrManager.LEDBlinkModeIndex = cbLEDBlink.SelectedIndex;
                }
            }
        }

        //The remainder of the code has been added to support the new controls added to the application
        //Need to add the documentation, but the event handlers are fairly self explanatory

        /// <summary>
        /// Event handler. Called by cbReceiverMode for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbReceiverMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if ((cbReceiverMode.SelectedIndex >= 0) && (cbReceiverMode.SelectedIndex != (int)m_jsrManager.ReceiverMode))
                {
                    try
                    {
                        m_jsrManager.ReceiverMode = (RECEIVER_MODE)cbReceiverMode.SelectedIndex;
                    }
                    catch (ExceptionJSRDotNET eJSR)
                    {
                        MessageBox.Show(eJSR.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler. Called by cbLowPassFilter for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbLowPassFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if (cbLowPassFilter.SelectedIndex >= 0 && (cbLowPassFilter.SelectedIndex != m_jsrManager.LowPassFilterIndex))
                {
                    try
                    {
                        m_jsrManager.LowPassFilterIndex = cbLowPassFilter.SelectedIndex;
                    }
                    catch (ExceptionJSRDotNET eJSR)
                    {
                        MessageBox.Show(eJSR.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler. Called by cbHighPassFilter for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbHighPassFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if (cbHighPassFilter.SelectedIndex >= 0 && (cbHighPassFilter.SelectedIndex != m_jsrManager.HighPassFilterIndex))
                {
                    try
                    {
                        m_jsrManager.HighPassFilterIndex = cbHighPassFilter.SelectedIndex;
                    }
                    catch (ExceptionJSRDotNET eJSR)
                    {
                        MessageBox.Show(eJSR.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler. Called by cbboxVoltageSupplyEnable for checked change events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckboxVoltageSupplyEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                try
                {
                    m_jsrManager.HVSupplyEnable = ckboxVoltageSupplyEnable.Checked;
                }
                catch (ExceptionJSRDotNET eJSR)
                {
                    MessageBox.Show(eJSR.Message);
                }
            }

        }

        /// <summary>
        /// Event handler. Called by cbPulserVoltage for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPulserVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if (cbPulserVoltage.SelectedIndex >= 0 && (cbPulserVoltage.SelectedIndex != m_jsrManager.HVSupplyIndex))
                {
                    try
                    {

                        m_jsrManager.HVSupply = cbPulserVoltage.SelectedIndex + 50;
                    }
                    catch (ExceptionJSRDotNET eJSR)
                    {
                        MessageBox.Show(eJSR.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler. Called by cbPulserEnergy for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPulserEnergy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if (cbPulserEnergy.SelectedIndex >= 0 && (cbPulserEnergy.SelectedIndex != m_jsrManager.PulseEnergyIndex))
                {
                    try
                    {
                        m_jsrManager.PulseEnergyIndex = cbPulserEnergy.SelectedIndex;
                    }
                    catch (ExceptionJSRDotNET eJSR)
                    {
                        MessageBox.Show(eJSR.Message);
                    }
                    tbEnergyPerPulse.Text = m_jsrManager.EnergyPerPulse.ToString();
                }

                PowerLimitStatusReached();
            }
        }

        /// <summary>
        /// Event handler. Called by cbDamping for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDamping_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if (cbDamping.SelectedIndex >=0 && (cbDamping.SelectedIndex != m_jsrManager.DampingIndex))
                {
                    try
                    {
                        m_jsrManager.DampingIndex = cbDamping.SelectedIndex;
                    }
                    catch (ExceptionJSRDotNET eJSR)
                    {
                        MessageBox.Show(eJSR.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler. Called by cbTriggerInputImpedance for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTriggerInputImpedance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if (cbTriggerInputImpedance.SelectedIndex >= 0 && (cbTriggerInputImpedance.SelectedIndex != (int)m_jsrManager.TriggerImpedance))
                {
                    try
                    {
                        m_jsrManager.TriggerImpedance = (TRIGGER_IMPEDANCE)cbTriggerInputImpedance.SelectedIndex;
                    }
                    catch (ExceptionJSRDotNET eJSR)
                    {
                        MessageBox.Show(eJSR.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler. Called by cbTriggerEdgePolarity for selected index changed events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTriggerEdgePolarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                if (cbTriggerEdgePolarity.SelectedIndex >= 0 && (cbTriggerEdgePolarity.SelectedIndex != (int)m_jsrManager.TriggerEdgePolarity))
                {
                    try
                    {
                        m_jsrManager.TriggerEdgePolarity = (TRIGGER_POLARITY)cbTriggerEdgePolarity.SelectedIndex;
                    }
                    catch (ExceptionJSRDotNET eJSR)
                    {
                        MessageBox.Show(eJSR.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler. Called by trackbarPRF for scroll events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackbarPRF_Scroll(object sender, EventArgs e)
        {
            if (!m_bLoadingControls && m_jsrManager.IsPulserReceiverSelected)
            {
                tbPRF.Text = "" + trackbarPRF.Value;
                m_jsrManager.PulseRepetitionFrequency = trackbarPRF.Value;
            }

            PowerLimitStatusReached();
        }

        #endregion
    }
}
