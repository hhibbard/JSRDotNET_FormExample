
namespace Holly_s_JSRDotNET_FormExample
{
    partial class FormExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExample));
            this.listBoxPulserSelect = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbSerialNum = new System.Windows.Forms.TextBox();
            this.ckboxTriggerEnable = new System.Windows.Forms.CheckBox();
            this.cboxTrigSrc = new System.Windows.Forms.ComboBox();
            this.cboxGain = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLEDBlink = new System.Windows.Forms.ComboBox();
            this.labelInstrumentsList = new System.Windows.Forms.GroupBox();
            this.gb500mhzreceiver = new System.Windows.Forms.GroupBox();
            this.cbHighPassFilter = new System.Windows.Forms.ComboBox();
            this.highPassFilterLabel = new System.Windows.Forms.Label();
            this.cbLowPassFilter = new System.Windows.Forms.ComboBox();
            this.lowPassFilterLabel = new System.Windows.Forms.Label();
            this.cbReceiverMode = new System.Windows.Forms.ComboBox();
            this.labelReceiverMode = new System.Windows.Forms.Label();
            this.labelGainValues = new System.Windows.Forms.Label();
            this.gbPulser = new System.Windows.Forms.GroupBox();
            this.greenPowerLimitStatusImage = new System.Windows.Forms.PictureBox();
            this.redPulsingImage = new System.Windows.Forms.PictureBox();
            this.redPowerLimitStatusImage = new System.Windows.Forms.PictureBox();
            this.greyPulsingImage = new System.Windows.Forms.PictureBox();
            this.labelPowerLimitStatus = new System.Windows.Forms.Label();
            this.labelPulsing = new System.Windows.Forms.Label();
            this.cbTriggerEdgePolarity = new System.Windows.Forms.ComboBox();
            this.labelTriggerEdgePolarity = new System.Windows.Forms.Label();
            this.cbTriggerInputImpedance = new System.Windows.Forms.ComboBox();
            this.labelTriggerInputImpedanceUnits = new System.Windows.Forms.Label();
            this.labelTriggerInputImpedance = new System.Windows.Forms.Label();
            this.cbDamping = new System.Windows.Forms.ComboBox();
            this.labelDampingUnits = new System.Windows.Forms.Label();
            this.labelDamping = new System.Windows.Forms.Label();
            this.tbEnergyPerPulse = new System.Windows.Forms.TextBox();
            this.labelEnergyPerPulseUnits = new System.Windows.Forms.Label();
            this.labelEnergyPerPulse = new System.Windows.Forms.Label();
            this.cbPulserEnergy = new System.Windows.Forms.ComboBox();
            this.labelPulserEnergy = new System.Windows.Forms.Label();
            this.cbPulserVoltage = new System.Windows.Forms.ComboBox();
            this.labelPulserVoltageUnits = new System.Windows.Forms.Label();
            this.labelPulserVoltage = new System.Windows.Forms.Label();
            this.ckboxVoltageSupplyEnable = new System.Windows.Forms.CheckBox();
            this.tbPRF = new System.Windows.Forms.TextBox();
            this.trackbarPRF = new System.Windows.Forms.TrackBar();
            this.cbPRF = new System.Windows.Forms.ComboBox();
            this.hzLabel = new System.Windows.Forms.Label();
            this.prfLabel = new System.Windows.Forms.Label();
            this.gbInstrumentInfo = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbDiscoveryNotifications = new System.Windows.Forms.TextBox();
            this.labelInstrumentsList.SuspendLayout();
            this.gb500mhzreceiver.SuspendLayout();
            this.gbPulser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenPowerLimitStatusImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPulsingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPowerLimitStatusImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greyPulsingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarPRF)).BeginInit();
            this.gbInstrumentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxPulserSelect
            // 
            this.listBoxPulserSelect.FormattingEnabled = true;
            this.listBoxPulserSelect.ItemHeight = 16;
            this.listBoxPulserSelect.Location = new System.Drawing.Point(6, 21);
            this.listBoxPulserSelect.Name = "listBoxPulserSelect";
            this.listBoxPulserSelect.Size = new System.Drawing.Size(352, 100);
            this.listBoxPulserSelect.TabIndex = 2;
            this.listBoxPulserSelect.SelectedIndexChanged += new System.EventHandler(this.listBoxPulserSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Serial Number";
            // 
            // tbModel
            // 
            this.tbModel.BackColor = System.Drawing.SystemColors.Control;
            this.tbModel.Location = new System.Drawing.Point(232, 22);
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            this.tbModel.Size = new System.Drawing.Size(126, 22);
            this.tbModel.TabIndex = 4;
            // 
            // tbSerialNum
            // 
            this.tbSerialNum.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbSerialNum.Location = new System.Drawing.Point(232, 51);
            this.tbSerialNum.Name = "tbSerialNum";
            this.tbSerialNum.Size = new System.Drawing.Size(126, 22);
            this.tbSerialNum.TabIndex = 6;
            // 
            // ckboxTriggerEnable
            // 
            this.ckboxTriggerEnable.AutoSize = true;
            this.ckboxTriggerEnable.Location = new System.Drawing.Point(291, 79);
            this.ckboxTriggerEnable.Name = "ckboxTriggerEnable";
            this.ckboxTriggerEnable.Size = new System.Drawing.Size(124, 21);
            this.ckboxTriggerEnable.TabIndex = 7;
            this.ckboxTriggerEnable.Text = "Trigger Enable";
            this.ckboxTriggerEnable.UseVisualStyleBackColor = true;
            this.ckboxTriggerEnable.CheckedChanged += new System.EventHandler(this.ckboxTriggerEnable_CheckedChanged);
            // 
            // cboxTrigSrc
            // 
            this.cboxTrigSrc.FormattingEnabled = true;
            this.cboxTrigSrc.Location = new System.Drawing.Point(294, 106);
            this.cboxTrigSrc.Name = "cboxTrigSrc";
            this.cboxTrigSrc.Size = new System.Drawing.Size(121, 24);
            this.cboxTrigSrc.TabIndex = 9;
            this.cboxTrigSrc.SelectedIndexChanged += new System.EventHandler(this.cboxTrigSrc_SelectedIndexChanged);
            // 
            // cboxGain
            // 
            this.cboxGain.FormattingEnabled = true;
            this.cboxGain.Location = new System.Drawing.Point(232, 57);
            this.cboxGain.Name = "cboxGain";
            this.cboxGain.Size = new System.Drawing.Size(126, 24);
            this.cboxGain.TabIndex = 11;
            this.cboxGain.SelectedIndexChanged += new System.EventHandler(this.cboxGain_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Trigger Source";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Gain";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Power LED";
            // 
            // cbLEDBlink
            // 
            this.cbLEDBlink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLEDBlink.FormattingEnabled = true;
            this.cbLEDBlink.Location = new System.Drawing.Point(232, 130);
            this.cbLEDBlink.Name = "cbLEDBlink";
            this.cbLEDBlink.Size = new System.Drawing.Size(126, 24);
            this.cbLEDBlink.TabIndex = 13;
            this.cbLEDBlink.SelectedIndexChanged += new System.EventHandler(this.cbLEDBlink_SelectedIndexChanged);
            // 
            // labelInstrumentsList
            // 
            this.labelInstrumentsList.BackColor = System.Drawing.SystemColors.Control;
            this.labelInstrumentsList.Controls.Add(this.listBoxPulserSelect);
            this.labelInstrumentsList.Controls.Add(this.cbLEDBlink);
            this.labelInstrumentsList.Controls.Add(this.label6);
            this.labelInstrumentsList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelInstrumentsList.Location = new System.Drawing.Point(12, 12);
            this.labelInstrumentsList.Name = "labelInstrumentsList";
            this.labelInstrumentsList.Size = new System.Drawing.Size(364, 164);
            this.labelInstrumentsList.TabIndex = 14;
            this.labelInstrumentsList.TabStop = false;
            this.labelInstrumentsList.Text = "Instruments ( 0 connected )";
            // 
            // gb500mhzreceiver
            // 
            this.gb500mhzreceiver.Controls.Add(this.cbHighPassFilter);
            this.gb500mhzreceiver.Controls.Add(this.highPassFilterLabel);
            this.gb500mhzreceiver.Controls.Add(this.cbLowPassFilter);
            this.gb500mhzreceiver.Controls.Add(this.lowPassFilterLabel);
            this.gb500mhzreceiver.Controls.Add(this.cbReceiverMode);
            this.gb500mhzreceiver.Controls.Add(this.labelReceiverMode);
            this.gb500mhzreceiver.Controls.Add(this.labelGainValues);
            this.gb500mhzreceiver.Controls.Add(this.label5);
            this.gb500mhzreceiver.Controls.Add(this.cboxGain);
            this.gb500mhzreceiver.Location = new System.Drawing.Point(12, 282);
            this.gb500mhzreceiver.Name = "gb500mhzreceiver";
            this.gb500mhzreceiver.Size = new System.Drawing.Size(364, 152);
            this.gb500mhzreceiver.TabIndex = 15;
            this.gb500mhzreceiver.TabStop = false;
            this.gb500mhzreceiver.Text = "500 MHz Receiver";
            // 
            // cbHighPassFilter
            // 
            this.cbHighPassFilter.FormattingEnabled = true;
            this.cbHighPassFilter.Location = new System.Drawing.Point(232, 117);
            this.cbHighPassFilter.Name = "cbHighPassFilter";
            this.cbHighPassFilter.Size = new System.Drawing.Size(126, 24);
            this.cbHighPassFilter.TabIndex = 18;
            this.cbHighPassFilter.SelectedIndexChanged += new System.EventHandler(this.cbHighPassFilter_SelectedIndexChanged);
            // 
            // highPassFilterLabel
            // 
            this.highPassFilterLabel.AutoSize = true;
            this.highPassFilterLabel.Location = new System.Drawing.Point(6, 120);
            this.highPassFilterLabel.Name = "highPassFilterLabel";
            this.highPassFilterLabel.Size = new System.Drawing.Size(107, 17);
            this.highPassFilterLabel.TabIndex = 17;
            this.highPassFilterLabel.Text = "High Pass Filter";
            // 
            // cbLowPassFilter
            // 
            this.cbLowPassFilter.FormattingEnabled = true;
            this.cbLowPassFilter.Location = new System.Drawing.Point(232, 87);
            this.cbLowPassFilter.Name = "cbLowPassFilter";
            this.cbLowPassFilter.Size = new System.Drawing.Size(126, 24);
            this.cbLowPassFilter.TabIndex = 16;
            this.cbLowPassFilter.SelectedIndexChanged += new System.EventHandler(this.cbLowPassFilter_SelectedIndexChanged);
            // 
            // lowPassFilterLabel
            // 
            this.lowPassFilterLabel.AutoSize = true;
            this.lowPassFilterLabel.Location = new System.Drawing.Point(6, 90);
            this.lowPassFilterLabel.Name = "lowPassFilterLabel";
            this.lowPassFilterLabel.Size = new System.Drawing.Size(103, 17);
            this.lowPassFilterLabel.TabIndex = 15;
            this.lowPassFilterLabel.Text = "Low Pass Filter";
            // 
            // cbReceiverMode
            // 
            this.cbReceiverMode.FormattingEnabled = true;
            this.cbReceiverMode.Location = new System.Drawing.Point(232, 27);
            this.cbReceiverMode.Name = "cbReceiverMode";
            this.cbReceiverMode.Size = new System.Drawing.Size(126, 24);
            this.cbReceiverMode.TabIndex = 14;
            this.cbReceiverMode.SelectedIndexChanged += new System.EventHandler(this.cbReceiverMode_SelectedIndexChanged);
            // 
            // labelReceiverMode
            // 
            this.labelReceiverMode.AutoSize = true;
            this.labelReceiverMode.Location = new System.Drawing.Point(6, 30);
            this.labelReceiverMode.Name = "labelReceiverMode";
            this.labelReceiverMode.Size = new System.Drawing.Size(103, 17);
            this.labelReceiverMode.TabIndex = 13;
            this.labelReceiverMode.Text = "Receiver Mode";
            // 
            // labelGainValues
            // 
            this.labelGainValues.AutoSize = true;
            this.labelGainValues.Location = new System.Drawing.Point(111, 60);
            this.labelGainValues.Name = "labelGainValues";
            this.labelGainValues.Size = new System.Drawing.Size(115, 17);
            this.labelGainValues.TabIndex = 12;
            this.labelGainValues.Text = "[-12 dB to 50 dB]";
            // 
            // gbPulser
            // 
            this.gbPulser.Controls.Add(this.greenPowerLimitStatusImage);
            this.gbPulser.Controls.Add(this.redPulsingImage);
            this.gbPulser.Controls.Add(this.redPowerLimitStatusImage);
            this.gbPulser.Controls.Add(this.greyPulsingImage);
            this.gbPulser.Controls.Add(this.labelPowerLimitStatus);
            this.gbPulser.Controls.Add(this.labelPulsing);
            this.gbPulser.Controls.Add(this.cbTriggerEdgePolarity);
            this.gbPulser.Controls.Add(this.labelTriggerEdgePolarity);
            this.gbPulser.Controls.Add(this.cbTriggerInputImpedance);
            this.gbPulser.Controls.Add(this.labelTriggerInputImpedanceUnits);
            this.gbPulser.Controls.Add(this.labelTriggerInputImpedance);
            this.gbPulser.Controls.Add(this.cbDamping);
            this.gbPulser.Controls.Add(this.labelDampingUnits);
            this.gbPulser.Controls.Add(this.labelDamping);
            this.gbPulser.Controls.Add(this.tbEnergyPerPulse);
            this.gbPulser.Controls.Add(this.labelEnergyPerPulseUnits);
            this.gbPulser.Controls.Add(this.labelEnergyPerPulse);
            this.gbPulser.Controls.Add(this.cbPulserEnergy);
            this.gbPulser.Controls.Add(this.labelPulserEnergy);
            this.gbPulser.Controls.Add(this.cbPulserVoltage);
            this.gbPulser.Controls.Add(this.labelPulserVoltageUnits);
            this.gbPulser.Controls.Add(this.labelPulserVoltage);
            this.gbPulser.Controls.Add(this.ckboxVoltageSupplyEnable);
            this.gbPulser.Controls.Add(this.tbPRF);
            this.gbPulser.Controls.Add(this.trackbarPRF);
            this.gbPulser.Controls.Add(this.cbPRF);
            this.gbPulser.Controls.Add(this.hzLabel);
            this.gbPulser.Controls.Add(this.prfLabel);
            this.gbPulser.Controls.Add(this.ckboxTriggerEnable);
            this.gbPulser.Controls.Add(this.label4);
            this.gbPulser.Controls.Add(this.cboxTrigSrc);
            this.gbPulser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbPulser.Location = new System.Drawing.Point(382, 12);
            this.gbPulser.Name = "gbPulser";
            this.gbPulser.Size = new System.Drawing.Size(421, 422);
            this.gbPulser.TabIndex = 16;
            this.gbPulser.TabStop = false;
            this.gbPulser.Text = "Pulser";
            // 
            // greenPowerLimitStatusImage
            // 
            this.greenPowerLimitStatusImage.Image = ((System.Drawing.Image)(resources.GetObject("greenPowerLimitStatusImage.Image")));
            this.greenPowerLimitStatusImage.Location = new System.Drawing.Point(343, 33);
            this.greenPowerLimitStatusImage.Name = "greenPowerLimitStatusImage";
            this.greenPowerLimitStatusImage.Size = new System.Drawing.Size(56, 47);
            this.greenPowerLimitStatusImage.TabIndex = 37;
            this.greenPowerLimitStatusImage.TabStop = false;
            // 
            // redPulsingImage
            // 
            this.redPulsingImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.redPulsingImage.Image = ((System.Drawing.Image)(resources.GetObject("redPulsingImage.Image")));
            this.redPulsingImage.Location = new System.Drawing.Point(141, 33);
            this.redPulsingImage.Name = "redPulsingImage";
            this.redPulsingImage.Size = new System.Drawing.Size(58, 48);
            this.redPulsingImage.TabIndex = 36;
            this.redPulsingImage.TabStop = false;
            this.redPulsingImage.Visible = false;
            // 
            // redPowerLimitStatusImage
            // 
            this.redPowerLimitStatusImage.Image = ((System.Drawing.Image)(resources.GetObject("redPowerLimitStatusImage.Image")));
            this.redPowerLimitStatusImage.Location = new System.Drawing.Point(343, 33);
            this.redPowerLimitStatusImage.Name = "redPowerLimitStatusImage";
            this.redPowerLimitStatusImage.Size = new System.Drawing.Size(54, 48);
            this.redPowerLimitStatusImage.TabIndex = 35;
            this.redPowerLimitStatusImage.TabStop = false;
            this.redPowerLimitStatusImage.Visible = false;
            // 
            // greyPulsingImage
            // 
            this.greyPulsingImage.Image = ((System.Drawing.Image)(resources.GetObject("greyPulsingImage.Image")));
            this.greyPulsingImage.Location = new System.Drawing.Point(145, 33);
            this.greyPulsingImage.Name = "greyPulsingImage";
            this.greyPulsingImage.Size = new System.Drawing.Size(54, 48);
            this.greyPulsingImage.TabIndex = 34;
            this.greyPulsingImage.TabStop = false;
            // 
            // labelPowerLimitStatus
            // 
            this.labelPowerLimitStatus.AutoSize = true;
            this.labelPowerLimitStatus.Location = new System.Drawing.Point(213, 45);
            this.labelPowerLimitStatus.Name = "labelPowerLimitStatus";
            this.labelPowerLimitStatus.Size = new System.Drawing.Size(124, 17);
            this.labelPowerLimitStatus.TabIndex = 33;
            this.labelPowerLimitStatus.Text = "Power Limit Status";
            // 
            // labelPulsing
            // 
            this.labelPulsing.AutoSize = true;
            this.labelPulsing.Location = new System.Drawing.Point(85, 45);
            this.labelPulsing.Name = "labelPulsing";
            this.labelPulsing.Size = new System.Drawing.Size(54, 17);
            this.labelPulsing.TabIndex = 32;
            this.labelPulsing.Text = "Pulsing";
            // 
            // cbTriggerEdgePolarity
            // 
            this.cbTriggerEdgePolarity.FormattingEnabled = true;
            this.cbTriggerEdgePolarity.Location = new System.Drawing.Point(294, 387);
            this.cbTriggerEdgePolarity.Name = "cbTriggerEdgePolarity";
            this.cbTriggerEdgePolarity.Size = new System.Drawing.Size(121, 24);
            this.cbTriggerEdgePolarity.TabIndex = 31;
            this.cbTriggerEdgePolarity.SelectedIndexChanged += new System.EventHandler(this.cbTriggerEdgePolarity_SelectedIndexChanged);
            // 
            // labelTriggerEdgePolarity
            // 
            this.labelTriggerEdgePolarity.AutoSize = true;
            this.labelTriggerEdgePolarity.Location = new System.Drawing.Point(6, 390);
            this.labelTriggerEdgePolarity.Name = "labelTriggerEdgePolarity";
            this.labelTriggerEdgePolarity.Size = new System.Drawing.Size(142, 17);
            this.labelTriggerEdgePolarity.TabIndex = 30;
            this.labelTriggerEdgePolarity.Text = "Trigger Edge Polarity";
            // 
            // cbTriggerInputImpedance
            // 
            this.cbTriggerInputImpedance.FormattingEnabled = true;
            this.cbTriggerInputImpedance.Location = new System.Drawing.Point(294, 357);
            this.cbTriggerInputImpedance.Name = "cbTriggerInputImpedance";
            this.cbTriggerInputImpedance.Size = new System.Drawing.Size(121, 24);
            this.cbTriggerInputImpedance.TabIndex = 29;
            this.cbTriggerInputImpedance.SelectedIndexChanged += new System.EventHandler(this.cbTriggerInputImpedance_SelectedIndexChanged);
            // 
            // labelTriggerInputImpedanceUnits
            // 
            this.labelTriggerInputImpedanceUnits.AutoSize = true;
            this.labelTriggerInputImpedanceUnits.Location = new System.Drawing.Point(233, 360);
            this.labelTriggerInputImpedanceUnits.Name = "labelTriggerInputImpedanceUnits";
            this.labelTriggerInputImpedanceUnits.Size = new System.Drawing.Size(55, 17);
            this.labelTriggerInputImpedanceUnits.TabIndex = 28;
            this.labelTriggerInputImpedanceUnits.Text = "(Ohms)";
            // 
            // labelTriggerInputImpedance
            // 
            this.labelTriggerInputImpedance.AutoSize = true;
            this.labelTriggerInputImpedance.Location = new System.Drawing.Point(6, 360);
            this.labelTriggerInputImpedance.Name = "labelTriggerInputImpedance";
            this.labelTriggerInputImpedance.Size = new System.Drawing.Size(162, 17);
            this.labelTriggerInputImpedance.TabIndex = 27;
            this.labelTriggerInputImpedance.Text = "Trigger Input Impedance";
            // 
            // cbDamping
            // 
            this.cbDamping.FormattingEnabled = true;
            this.cbDamping.Location = new System.Drawing.Point(294, 327);
            this.cbDamping.Name = "cbDamping";
            this.cbDamping.Size = new System.Drawing.Size(121, 24);
            this.cbDamping.TabIndex = 26;
            this.cbDamping.SelectedIndexChanged += new System.EventHandler(this.cbDamping_SelectedIndexChanged);
            // 
            // labelDampingUnits
            // 
            this.labelDampingUnits.AutoSize = true;
            this.labelDampingUnits.Location = new System.Drawing.Point(233, 330);
            this.labelDampingUnits.Name = "labelDampingUnits";
            this.labelDampingUnits.Size = new System.Drawing.Size(55, 17);
            this.labelDampingUnits.TabIndex = 25;
            this.labelDampingUnits.Text = "(Ohms)";
            // 
            // labelDamping
            // 
            this.labelDamping.AutoSize = true;
            this.labelDamping.Location = new System.Drawing.Point(6, 330);
            this.labelDamping.Name = "labelDamping";
            this.labelDamping.Size = new System.Drawing.Size(64, 17);
            this.labelDamping.TabIndex = 24;
            this.labelDamping.Text = "Damping";
            // 
            // tbEnergyPerPulse
            // 
            this.tbEnergyPerPulse.Location = new System.Drawing.Point(294, 299);
            this.tbEnergyPerPulse.Name = "tbEnergyPerPulse";
            this.tbEnergyPerPulse.Size = new System.Drawing.Size(121, 22);
            this.tbEnergyPerPulse.TabIndex = 23;
            // 
            // labelEnergyPerPulseUnits
            // 
            this.labelEnergyPerPulseUnits.AutoSize = true;
            this.labelEnergyPerPulseUnits.Location = new System.Drawing.Point(229, 302);
            this.labelEnergyPerPulseUnits.Name = "labelEnergyPerPulseUnits";
            this.labelEnergyPerPulseUnits.Size = new System.Drawing.Size(59, 17);
            this.labelEnergyPerPulseUnits.TabIndex = 22;
            this.labelEnergyPerPulseUnits.Text = "(Joules)";
            // 
            // labelEnergyPerPulse
            // 
            this.labelEnergyPerPulse.AutoSize = true;
            this.labelEnergyPerPulse.Location = new System.Drawing.Point(6, 302);
            this.labelEnergyPerPulse.Name = "labelEnergyPerPulse";
            this.labelEnergyPerPulse.Size = new System.Drawing.Size(118, 17);
            this.labelEnergyPerPulse.TabIndex = 21;
            this.labelEnergyPerPulse.Text = "Energy Per Pulse";
            // 
            // cbPulserEnergy
            // 
            this.cbPulserEnergy.FormattingEnabled = true;
            this.cbPulserEnergy.Location = new System.Drawing.Point(294, 269);
            this.cbPulserEnergy.Name = "cbPulserEnergy";
            this.cbPulserEnergy.Size = new System.Drawing.Size(121, 24);
            this.cbPulserEnergy.TabIndex = 20;
            this.cbPulserEnergy.SelectedIndexChanged += new System.EventHandler(this.cbPulserEnergy_SelectedIndexChanged);
            // 
            // labelPulserEnergy
            // 
            this.labelPulserEnergy.AutoSize = true;
            this.labelPulserEnergy.Location = new System.Drawing.Point(6, 272);
            this.labelPulserEnergy.Name = "labelPulserEnergy";
            this.labelPulserEnergy.Size = new System.Drawing.Size(97, 17);
            this.labelPulserEnergy.TabIndex = 19;
            this.labelPulserEnergy.Text = "Pulser Energy";
            // 
            // cbPulserVoltage
            // 
            this.cbPulserVoltage.FormattingEnabled = true;
            this.cbPulserVoltage.Location = new System.Drawing.Point(294, 239);
            this.cbPulserVoltage.Name = "cbPulserVoltage";
            this.cbPulserVoltage.Size = new System.Drawing.Size(121, 24);
            this.cbPulserVoltage.TabIndex = 18;
            this.cbPulserVoltage.SelectedIndexChanged += new System.EventHandler(this.cbPulserVoltage_SelectedIndexChanged);
            // 
            // labelPulserVoltageUnits
            // 
            this.labelPulserVoltageUnits.AutoSize = true;
            this.labelPulserVoltageUnits.Location = new System.Drawing.Point(142, 242);
            this.labelPulserVoltageUnits.Name = "labelPulserVoltageUnits";
            this.labelPulserVoltageUnits.Size = new System.Drawing.Size(146, 17);
            this.labelPulserVoltageUnits.TabIndex = 17;
            this.labelPulserVoltageUnits.Text = "[50 Volts to 300 Volts]";
            // 
            // labelPulserVoltage
            // 
            this.labelPulserVoltage.AutoSize = true;
            this.labelPulserVoltage.Location = new System.Drawing.Point(6, 242);
            this.labelPulserVoltage.Name = "labelPulserVoltage";
            this.labelPulserVoltage.Size = new System.Drawing.Size(100, 17);
            this.labelPulserVoltage.TabIndex = 16;
            this.labelPulserVoltage.Text = "Pulser Voltage";
            // 
            // ckboxVoltageSupplyEnable
            // 
            this.ckboxVoltageSupplyEnable.AutoSize = true;
            this.ckboxVoltageSupplyEnable.Location = new System.Drawing.Point(197, 212);
            this.ckboxVoltageSupplyEnable.Name = "ckboxVoltageSupplyEnable";
            this.ckboxVoltageSupplyEnable.Size = new System.Drawing.Size(213, 21);
            this.ckboxVoltageSupplyEnable.TabIndex = 15;
            this.ckboxVoltageSupplyEnable.Text = "Pulser Volage Supply Enable";
            this.ckboxVoltageSupplyEnable.UseVisualStyleBackColor = true;
            this.ckboxVoltageSupplyEnable.CheckedChanged += new System.EventHandler(this.ckboxVoltageSupplyEnable_CheckedChanged);
            // 
            // tbPRF
            // 
            this.tbPRF.Location = new System.Drawing.Point(289, 166);
            this.tbPRF.Name = "tbPRF";
            this.tbPRF.Size = new System.Drawing.Size(121, 22);
            this.tbPRF.TabIndex = 14;
            // 
            // trackbarPRF
            // 
            this.trackbarPRF.Location = new System.Drawing.Point(9, 166);
            this.trackbarPRF.Maximum = 20000;
            this.trackbarPRF.Minimum = 1000;
            this.trackbarPRF.Name = "trackbarPRF";
            this.trackbarPRF.Size = new System.Drawing.Size(274, 56);
            this.trackbarPRF.TabIndex = 13;
            this.trackbarPRF.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackbarPRF.Value = 1000;
            this.trackbarPRF.Scroll += new System.EventHandler(this.trackbarPRF_Scroll);
            // 
            // cbPRF
            // 
            this.cbPRF.FormattingEnabled = true;
            this.cbPRF.Location = new System.Drawing.Point(294, 136);
            this.cbPRF.Name = "cbPRF";
            this.cbPRF.Size = new System.Drawing.Size(121, 24);
            this.cbPRF.TabIndex = 12;
            this.cbPRF.Visible = false;
            // 
            // hzLabel
            // 
            this.hzLabel.AutoSize = true;
            this.hzLabel.Location = new System.Drawing.Point(253, 139);
            this.hzLabel.Name = "hzLabel";
            this.hzLabel.Size = new System.Drawing.Size(35, 17);
            this.hzLabel.TabIndex = 11;
            this.hzLabel.Text = "(Hz)";
            // 
            // prfLabel
            // 
            this.prfLabel.AutoSize = true;
            this.prfLabel.Location = new System.Drawing.Point(6, 139);
            this.prfLabel.Name = "prfLabel";
            this.prfLabel.Size = new System.Drawing.Size(35, 17);
            this.prfLabel.TabIndex = 10;
            this.prfLabel.Text = "PRF";
            // 
            // gbInstrumentInfo
            // 
            this.gbInstrumentInfo.Controls.Add(this.label2);
            this.gbInstrumentInfo.Controls.Add(this.tbModel);
            this.gbInstrumentInfo.Controls.Add(this.tbSerialNum);
            this.gbInstrumentInfo.Controls.Add(this.label3);
            this.gbInstrumentInfo.Location = new System.Drawing.Point(12, 183);
            this.gbInstrumentInfo.Name = "gbInstrumentInfo";
            this.gbInstrumentInfo.Size = new System.Drawing.Size(364, 93);
            this.gbInstrumentInfo.TabIndex = 17;
            this.gbInstrumentInfo.TabStop = false;
            this.gbInstrumentInfo.Text = "Instrument Information";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Green button.png");
            this.imageList1.Images.SetKeyName(1, "Grey button.png");
            // 
            // tbDiscoveryNotifications
            // 
            this.tbDiscoveryNotifications.Location = new System.Drawing.Point(12, 438);
            this.tbDiscoveryNotifications.Name = "tbDiscoveryNotifications";
            this.tbDiscoveryNotifications.Size = new System.Drawing.Size(358, 22);
            this.tbDiscoveryNotifications.TabIndex = 18;
            this.tbDiscoveryNotifications.Text = "Discovery Started";
            // 
            // FormExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 461);
            this.Controls.Add(this.tbDiscoveryNotifications);
            this.Controls.Add(this.gbInstrumentInfo);
            this.Controls.Add(this.gbPulser);
            this.Controls.Add(this.gb500mhzreceiver);
            this.Controls.Add(this.labelInstrumentsList);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExample";
            this.Text = "JSRDotNET Simple Form Example";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.labelInstrumentsList.ResumeLayout(false);
            this.labelInstrumentsList.PerformLayout();
            this.gb500mhzreceiver.ResumeLayout(false);
            this.gb500mhzreceiver.PerformLayout();
            this.gbPulser.ResumeLayout(false);
            this.gbPulser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenPowerLimitStatusImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPulsingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redPowerLimitStatusImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greyPulsingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarPRF)).EndInit();
            this.gbInstrumentInfo.ResumeLayout(false);
            this.gbInstrumentInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPulserSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.TextBox tbSerialNum;
        private System.Windows.Forms.CheckBox ckboxTriggerEnable;
        private System.Windows.Forms.ComboBox cboxTrigSrc;
        private System.Windows.Forms.ComboBox cboxGain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLEDBlink;
        private System.Windows.Forms.GroupBox labelInstrumentsList;
        private System.Windows.Forms.GroupBox gb500mhzreceiver;
        private System.Windows.Forms.GroupBox gbPulser;
        private System.Windows.Forms.Label labelGainValues;
        private System.Windows.Forms.ComboBox cbReceiverMode;
        private System.Windows.Forms.Label labelReceiverMode;
        private System.Windows.Forms.Label lowPassFilterLabel;
        private System.Windows.Forms.Label highPassFilterLabel;
        private System.Windows.Forms.ComboBox cbLowPassFilter;
        private System.Windows.Forms.ComboBox cbHighPassFilter;
        private System.Windows.Forms.Label prfLabel;
        private System.Windows.Forms.Label hzLabel;
        private System.Windows.Forms.TrackBar trackbarPRF;
        private System.Windows.Forms.ComboBox cbPRF;
        private System.Windows.Forms.TextBox tbPRF;
        private System.Windows.Forms.CheckBox ckboxVoltageSupplyEnable;
        private System.Windows.Forms.Label labelPulserVoltage;
        private System.Windows.Forms.Label labelPulserVoltageUnits;
        private System.Windows.Forms.Label labelPulserEnergy;
        private System.Windows.Forms.ComboBox cbPulserVoltage;
        private System.Windows.Forms.ComboBox cbPulserEnergy;
        private System.Windows.Forms.Label labelEnergyPerPulse;
        private System.Windows.Forms.Label labelEnergyPerPulseUnits;
        private System.Windows.Forms.TextBox tbEnergyPerPulse;
        private System.Windows.Forms.Label labelDamping;
        private System.Windows.Forms.Label labelDampingUnits;
        private System.Windows.Forms.ComboBox cbDamping;
        private System.Windows.Forms.Label labelTriggerInputImpedance;
        private System.Windows.Forms.ComboBox cbTriggerInputImpedance;
        private System.Windows.Forms.Label labelTriggerInputImpedanceUnits;
        private System.Windows.Forms.Label labelTriggerEdgePolarity;
        private System.Windows.Forms.ComboBox cbTriggerEdgePolarity;
        private System.Windows.Forms.GroupBox gbInstrumentInfo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label labelPowerLimitStatus;
        private System.Windows.Forms.Label labelPulsing;
        private System.Windows.Forms.PictureBox redPowerLimitStatusImage;
        private System.Windows.Forms.PictureBox greyPulsingImage;
        private System.Windows.Forms.PictureBox greenPowerLimitStatusImage;
        private System.Windows.Forms.PictureBox redPulsingImage;
        private System.Windows.Forms.TextBox tbDiscoveryNotifications;
    }
}

