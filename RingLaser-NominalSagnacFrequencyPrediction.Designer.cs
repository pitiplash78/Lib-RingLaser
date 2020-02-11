namespace RingLaser
{
    partial class RingLaser_NominalSagnacFrequencyPrediction
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RingLaser_NominalSagnacFrequencyPrediction));
            this.buttonClose = new System.Windows.Forms.Button();
            this.radioButtonSquared = new System.Windows.Forms.RadioButton();
            this.labelDipHint = new System.Windows.Forms.Label();
            this.radioButtonTriangular = new System.Windows.Forms.RadioButton();
            this.labelAzimuthHint = new System.Windows.Forms.Label();
            this.labelShape = new System.Windows.Forms.Label();
            this.labelDip = new System.Windows.Forms.Label();
            this.nUD_Azimuth = new System.Windows.Forms.NumericUpDown();
            this.nUD_Dip = new System.Windows.Forms.NumericUpDown();
            this.labelAzimuth = new System.Windows.Forms.Label();
            this.checkBoxRotateAroundVertical = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panelProperties = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.userControl_RingLaserOrientation1 = new PreAnalyseExtended.UserControl_RingLaserOrientation();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.nUD_Lambda = new System.Windows.Forms.NumericUpDown();
            this.labelLambda = new System.Windows.Forms.Label();
            this.nUD_SideLength = new System.Windows.Forms.NumericUpDown();
            this.labelSideLength = new System.Windows.Forms.Label();
            this.userControl_StationOrganiseMain1 = new PreAnalyseExtended.UserControl_StationOrganiseMain();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Azimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Dip)).BeginInit();
            this.panelProperties.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Lambda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_SideLength)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.Location = new System.Drawing.Point(778, 607);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 84;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // radioButtonSquared
            // 
            this.radioButtonSquared.AutoSize = true;
            this.radioButtonSquared.Checked = true;
            this.radioButtonSquared.Location = new System.Drawing.Point(112, 57);
            this.radioButtonSquared.Name = "radioButtonSquared";
            this.radioButtonSquared.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSquared.TabIndex = 79;
            this.radioButtonSquared.TabStop = true;
            this.radioButtonSquared.Text = "squared";
            this.radioButtonSquared.UseVisualStyleBackColor = true;
            this.radioButtonSquared.CheckedChanged += new System.EventHandler(this.radioButtonShape_CheckedChanged);
            // 
            // labelDipHint
            // 
            this.labelDipHint.AutoSize = true;
            this.labelDipHint.Location = new System.Drawing.Point(175, 33);
            this.labelDipHint.Name = "labelDipHint";
            this.labelDipHint.Size = new System.Drawing.Size(195, 13);
            this.labelDipHint.TabIndex = 78;
            this.labelDipHint.Text = "Counts from vertical, for normal direction";
            // 
            // radioButtonTriangular
            // 
            this.radioButtonTriangular.AutoSize = true;
            this.radioButtonTriangular.Location = new System.Drawing.Point(181, 57);
            this.radioButtonTriangular.Name = "radioButtonTriangular";
            this.radioButtonTriangular.Size = new System.Drawing.Size(68, 17);
            this.radioButtonTriangular.TabIndex = 80;
            this.radioButtonTriangular.TabStop = true;
            this.radioButtonTriangular.Text = "triangular";
            this.radioButtonTriangular.UseVisualStyleBackColor = true;
            this.radioButtonTriangular.CheckedChanged += new System.EventHandler(this.radioButtonShape_CheckedChanged);
            // 
            // labelAzimuthHint
            // 
            this.labelAzimuthHint.AutoSize = true;
            this.labelAzimuthHint.Location = new System.Drawing.Point(175, 7);
            this.labelAzimuthHint.Name = "labelAzimuthHint";
            this.labelAzimuthHint.Size = new System.Drawing.Size(110, 13);
            this.labelAzimuthHint.TabIndex = 77;
            this.labelAzimuthHint.Text = "Clock wise from North";
            // 
            // labelShape
            // 
            this.labelShape.AutoSize = true;
            this.labelShape.Location = new System.Drawing.Point(-3, 59);
            this.labelShape.Name = "labelShape";
            this.labelShape.Size = new System.Drawing.Size(73, 13);
            this.labelShape.TabIndex = 81;
            this.labelShape.Text = "Shape of ring:";
            // 
            // labelDip
            // 
            this.labelDip.AutoSize = true;
            this.labelDip.Location = new System.Drawing.Point(-3, 33);
            this.labelDip.Name = "labelDip";
            this.labelDip.Size = new System.Drawing.Size(39, 13);
            this.labelDip.TabIndex = 74;
            this.labelDip.Text = "Dip [°]:";
            // 
            // nUD_Azimuth
            // 
            this.nUD_Azimuth.DecimalPlaces = 2;
            this.nUD_Azimuth.Location = new System.Drawing.Point(112, 5);
            this.nUD_Azimuth.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nUD_Azimuth.Name = "nUD_Azimuth";
            this.nUD_Azimuth.Size = new System.Drawing.Size(60, 20);
            this.nUD_Azimuth.TabIndex = 71;
            this.nUD_Azimuth.ValueChanged += new System.EventHandler(this.nUD_Azimuth_ValueChanged);
            // 
            // nUD_Dip
            // 
            this.nUD_Dip.DecimalPlaces = 2;
            this.nUD_Dip.Location = new System.Drawing.Point(112, 31);
            this.nUD_Dip.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nUD_Dip.Name = "nUD_Dip";
            this.nUD_Dip.Size = new System.Drawing.Size(60, 20);
            this.nUD_Dip.TabIndex = 72;
            this.nUD_Dip.ValueChanged += new System.EventHandler(this.nUD_Dip_ValueChanged);
            // 
            // labelAzimuth
            // 
            this.labelAzimuth.AutoSize = true;
            this.labelAzimuth.Location = new System.Drawing.Point(-3, 7);
            this.labelAzimuth.Name = "labelAzimuth";
            this.labelAzimuth.Size = new System.Drawing.Size(54, 13);
            this.labelAzimuth.TabIndex = 75;
            this.labelAzimuth.Text = "Azimut [°]:";
            // 
            // checkBoxRotateAroundVertical
            // 
            this.checkBoxRotateAroundVertical.AutoSize = true;
            this.checkBoxRotateAroundVertical.Checked = true;
            this.checkBoxRotateAroundVertical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRotateAroundVertical.Location = new System.Drawing.Point(380, 6);
            this.checkBoxRotateAroundVertical.Name = "checkBoxRotateAroundVertical";
            this.checkBoxRotateAroundVertical.Size = new System.Drawing.Size(285, 17);
            this.checkBoxRotateAroundVertical.TabIndex = 84;
            this.checkBoxRotateAroundVertical.Text = "Rotate Ringlaser around the vertical in the local system";
            this.checkBoxRotateAroundVertical.UseVisualStyleBackColor = true;
            this.checkBoxRotateAroundVertical.CheckedChanged += new System.EventHandler(this.checkBoxRotateAroundVertical_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 132);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(370, 365);
            this.richTextBox1.TabIndex = 85;
            this.richTextBox1.Text = "";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.EditModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(457, 366);
            this.zedGraphControl1.TabIndex = 88;
            // 
            // panelProperties
            // 
            this.panelProperties.Controls.Add(this.tabControl1);
            this.panelProperties.Controls.Add(this.buttonSave);
            this.panelProperties.Controls.Add(this.buttonPrint);
            this.panelProperties.Controls.Add(this.nUD_Lambda);
            this.panelProperties.Controls.Add(this.labelLambda);
            this.panelProperties.Controls.Add(this.richTextBox1);
            this.panelProperties.Controls.Add(this.checkBoxRotateAroundVertical);
            this.panelProperties.Controls.Add(this.labelAzimuth);
            this.panelProperties.Controls.Add(this.nUD_Dip);
            this.panelProperties.Controls.Add(this.nUD_SideLength);
            this.panelProperties.Controls.Add(this.nUD_Azimuth);
            this.panelProperties.Controls.Add(this.labelSideLength);
            this.panelProperties.Controls.Add(this.labelDip);
            this.panelProperties.Controls.Add(this.labelShape);
            this.panelProperties.Controls.Add(this.labelAzimuthHint);
            this.panelProperties.Controls.Add(this.radioButtonTriangular);
            this.panelProperties.Controls.Add(this.labelDipHint);
            this.panelProperties.Controls.Add(this.radioButtonSquared);
            this.panelProperties.Location = new System.Drawing.Point(12, 101);
            this.panelProperties.Name = "panelProperties";
            this.panelProperties.Size = new System.Drawing.Size(841, 529);
            this.panelProperties.TabIndex = 85;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(376, 108);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 392);
            this.tabControl1.TabIndex = 91;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zedGraphControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(457, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Calculated Sagnac Frequency";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zedGraphControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Coordinate path of the normal vector";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(457, 366);
            this.zedGraphControl2.TabIndex = 92;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.userControl_RingLaserOrientation1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(457, 366);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Instrument orientation";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // userControl_RingLaserOrientation1
            // 
            this.userControl_RingLaserOrientation1.BackColor = System.Drawing.Color.White;
            this.userControl_RingLaserOrientation1.Location = new System.Drawing.Point(3, 3);
            this.userControl_RingLaserOrientation1.Name = "userControl_RingLaserOrientation1";
            this.userControl_RingLaserOrientation1.NormalVector = null;
            this.userControl_RingLaserOrientation1.SiteLocation = null;
            this.userControl_RingLaserOrientation1.Size = new System.Drawing.Size(451, 360);
            this.userControl_RingLaserOrientation1.TabIndex = 92;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(214, 503);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 90;
            this.buttonSave.Text = "Save ...";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(295, 503);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 89;
            this.buttonPrint.Text = "Print ...";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // nUD_Lambda
            // 
            this.nUD_Lambda.DecimalPlaces = 3;
            this.nUD_Lambda.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUD_Lambda.Location = new System.Drawing.Point(112, 106);
            this.nUD_Lambda.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.nUD_Lambda.Name = "nUD_Lambda";
            this.nUD_Lambda.Size = new System.Drawing.Size(82, 20);
            this.nUD_Lambda.TabIndex = 87;
            this.nUD_Lambda.ValueChanged += new System.EventHandler(this.nUD_Lambda_ValueChanged);
            // 
            // labelLambda
            // 
            this.labelLambda.AutoSize = true;
            this.labelLambda.Location = new System.Drawing.Point(-3, 108);
            this.labelLambda.Name = "labelLambda";
            this.labelLambda.Size = new System.Drawing.Size(109, 13);
            this.labelLambda.TabIndex = 86;
            this.labelLambda.Text = "Laser frequency [nm]:";
            // 
            // nUD_SideLength
            // 
            this.nUD_SideLength.DecimalPlaces = 3;
            this.nUD_SideLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nUD_SideLength.Location = new System.Drawing.Point(112, 80);
            this.nUD_SideLength.Name = "nUD_SideLength";
            this.nUD_SideLength.Size = new System.Drawing.Size(82, 20);
            this.nUD_SideLength.TabIndex = 83;
            this.nUD_SideLength.ValueChanged += new System.EventHandler(this.nUD_SideLength_ValueChanged);
            // 
            // labelSideLength
            // 
            this.labelSideLength.AutoSize = true;
            this.labelSideLength.Location = new System.Drawing.Point(-3, 82);
            this.labelSideLength.Name = "labelSideLength";
            this.labelSideLength.Size = new System.Drawing.Size(80, 13);
            this.labelSideLength.TabIndex = 82;
            this.labelSideLength.Text = "Side length [m]:";
            // 
            // userControl_StationOrganiseMain1
            // 
            this.userControl_StationOrganiseMain1.BackColor = System.Drawing.SystemColors.Info;
            this.userControl_StationOrganiseMain1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userControl_StationOrganiseMain1.Location = new System.Drawing.Point(12, 12);
            this.userControl_StationOrganiseMain1.Name = "userControl_StationOrganiseMain1";
            this.userControl_StationOrganiseMain1.Sensor1 = null;
            this.userControl_StationOrganiseMain1.Sensor2 = null;
            this.userControl_StationOrganiseMain1.SensorEnabled1 = true;
            this.userControl_StationOrganiseMain1.SensorEnabled2 = true;
            this.userControl_StationOrganiseMain1.SensorIndex1 = -1;
            this.userControl_StationOrganiseMain1.SensorIndex2 = -1;
            this.userControl_StationOrganiseMain1.Sensors = PreAnalyseExtended.UserControl_StationOrganiseMain.SensorsUsed.One;
            this.userControl_StationOrganiseMain1.SensorType1 = PreAnalyseExtended.SensorTypes.Type.Undefined;
            this.userControl_StationOrganiseMain1.SensorType2 = PreAnalyseExtended.SensorTypes.Type.Undefined;
            this.userControl_StationOrganiseMain1.Size = new System.Drawing.Size(841, 83);
            this.userControl_StationOrganiseMain1.Station = null;
            this.userControl_StationOrganiseMain1.TabIndex = 87;
            // 
            // RingLaser_NominalSagnacFrequencyPrediction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 642);
            this.Controls.Add(this.userControl_StationOrganiseMain1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.panelProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RingLaser_NominalSagnacFrequencyPrediction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PreAnalyseExtended - Ring Laser - Nominal Sagnac-Frequency Prediction ";
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Azimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Dip)).EndInit();
            this.panelProperties.ResumeLayout(false);
            this.panelProperties.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Lambda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_SideLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RadioButton radioButtonSquared;
        private System.Windows.Forms.Label labelDipHint;
        private System.Windows.Forms.RadioButton radioButtonTriangular;
        private System.Windows.Forms.Label labelAzimuthHint;
        private System.Windows.Forms.Label labelShape;
        private System.Windows.Forms.Label labelDip;
        private System.Windows.Forms.NumericUpDown nUD_Azimuth;
        private System.Windows.Forms.NumericUpDown nUD_Dip;
        private System.Windows.Forms.Label labelAzimuth;
        private System.Windows.Forms.CheckBox checkBoxRotateAroundVertical;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel panelProperties;
        private System.Windows.Forms.NumericUpDown nUD_Lambda;
        private System.Windows.Forms.Label labelLambda;
        private System.Windows.Forms.NumericUpDown nUD_SideLength;
        private System.Windows.Forms.Label labelSideLength;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private PreAnalyseExtended.UserControl_RingLaserOrientation userControl_RingLaserOrientation1;
        private System.Windows.Forms.TabPage tabPage3;
        private PreAnalyseExtended.UserControl_StationOrganiseMain userControl_StationOrganiseMain1;
    }
}

