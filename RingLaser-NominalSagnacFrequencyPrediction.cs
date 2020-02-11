using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using PreAnalyseExtended;


namespace RingLaser
{
    public partial class RingLaser_NominalSagnacFrequencyPrediction : Form
    {
        public Station Station
        {
            get
            {
                return _Station;
            }
            set
            {
                this._Station = value;
                this.StationName = _Station.Name;

                userControl_StationOrganiseMain1.Station = _Station;
                userControl_RingLaserOrientation1.SiteLocation = new UserControl_RingLaserOrientation.Coordinates(_Station.Location.Latitude, _Station.Location.Longitude);
                userControl_StationOrganiseMain1.SensorIndex1 = selectedIDInstrument;

                fillParamerter();
            }
        }
        public Station _Station = null;
        private string StationName = null;

        private int selectedIDInstrument = -1;
        private Station.SensorEntry Sensor = null;

        private ZedGraph.GraphPane myPane1 = null;
        private ZedGraph.GraphPane myPane2 = null;

        public RingLaser_NominalSagnacFrequencyPrediction()
        {
            if (StationName != null)
            {
                _Station = Station.deserialisieren(FilePathEnvironment.pathStations + StationName);
                Sensor = _Station.SensorDataItems[selectedIDInstrument];
            }

            InitializeComponent();

            // Set the titles and axis labels
            myPane1 = zedGraphControl1.GraphPane;

            myPane1.Title.Text = "";
            myPane1.XAxis.Title.Text = "alpha [°]";
            myPane1.XAxis.MajorGrid.IsVisible = true;
            myPane1.XAxis.MajorGrid.Color = Color.LightGray;
            myPane1.XAxis.MajorGrid.DashOn = 10;
            myPane1.XAxis.MajorGrid.DashOff = 0;
            myPane1.XAxis.MinorGrid.IsVisible = true;
            myPane1.XAxis.MinorGrid.Color = Color.LightGray;
            myPane1.XAxis.MinorGrid.DashOn = 10;
            myPane1.XAxis.MinorGrid.DashOff = 0;
            myPane1.XAxis.Scale.Min = 0;
            myPane1.XAxis.Scale.Max = 360;
            myPane1.XAxis.Scale.MajorStep = 60;

            myPane1.YAxis.Title.Text = "Sagnac-frequency [Hz]";
            myPane1.YAxis.MajorGrid.IsVisible = true;
            myPane1.YAxis.MajorGrid.Color = Color.LightGray;
            myPane1.YAxis.MajorGrid.DashOn = 10;
            myPane1.YAxis.MajorGrid.DashOff = 0;
            myPane1.YAxis.MinorGrid.IsVisible = true;
            myPane1.YAxis.MinorGrid.Color = Color.LightGray;
            myPane1.YAxis.MinorGrid.DashOn = 10;
            myPane1.YAxis.MinorGrid.DashOff = 0;
            myPane1.YAxis.Scale.Min = 0;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            myPane2 = zedGraphControl2.GraphPane;

            myPane2.Title.Text = "";
            myPane2.XAxis.Title.Text = "Longitude [°]";
            myPane2.XAxis.MajorGrid.IsVisible = true;
            myPane2.XAxis.MajorGrid.Color = Color.LightGray;
            myPane2.XAxis.MajorGrid.DashOn = 10;
            myPane2.XAxis.MajorGrid.DashOff = 0;
            myPane2.XAxis.MinorGrid.IsVisible = true;
            myPane2.XAxis.MinorGrid.Color = Color.LightGray;
            myPane2.XAxis.MinorGrid.DashOn = 10;
            myPane2.XAxis.MinorGrid.DashOff = 0;
            myPane2.XAxis.Scale.Min = 0;
            myPane2.XAxis.Scale.Max = 360;
            myPane2.XAxis.Scale.MajorStep = 60;

            myPane2.YAxis.Title.Text = "Latitude [°]";
            myPane2.YAxis.MajorGrid.IsVisible = true;
            myPane2.YAxis.MajorGrid.Color = Color.LightGray;
            myPane2.YAxis.MajorGrid.DashOn = 10;
            myPane2.YAxis.MajorGrid.DashOff = 0;
            myPane2.YAxis.MinorGrid.IsVisible = true;
            myPane2.YAxis.MinorGrid.Color = Color.LightGray;
            myPane2.YAxis.MinorGrid.DashOn = 10;
            myPane2.YAxis.MinorGrid.DashOff = 0;
            myPane2.YAxis.Scale.Min = -90;
            myPane2.YAxis.Scale.Max = 90;

            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();

            userControl_StationOrganiseMain1.SensorType1 = SensorTypes.Type.SagnacFrequency;

            userControl_StationOrganiseMain1.StationChanged += new UserControl_StationOrganiseMain.StationChangedHandler(UserControl_Station_StationChanged);
            userControl_StationOrganiseMain1.SensorChanged += new UserControl_StationOrganiseMain.SensorChangedHandler(UserControl_Station_SensorChanged);

            userControl_StationOrganiseMain1.Station = _Station;
            userControl_StationOrganiseMain1.SensorIndex1 = selectedIDInstrument;

            fillParamerter();
        }

        private void UserControl_Station_StationChanged(object sender, UserControl_StationOrganiseMain.StationChangedEventArgs e)
        {
            if (e.Status == UserControl_StationOrganiseMain.StationChangedEvent.New ||
                e.Status == UserControl_StationOrganiseMain.StationChangedEvent.Change)
            {
                _Station = userControl_StationOrganiseMain1.Station;
                userControl_RingLaserOrientation1.SiteLocation = new UserControl_RingLaserOrientation.Coordinates(_Station.Location.Latitude, _Station.Location.Longitude);

                Sensor = null;
                selectedIDInstrument = -1;

                fillParamerter();

                richTextBox1.Clear();
            }
            else if (e.Status == UserControl_StationOrganiseMain.StationChangedEvent.Modify)
            {
                _Station = userControl_StationOrganiseMain1.Station;
                userControl_RingLaserOrientation1.SiteLocation = new UserControl_RingLaserOrientation.Coordinates(_Station.Location.Latitude, _Station.Location.Longitude);

                fillParamerter();
            }
        }

        private void UserControl_Station_SensorChanged(object sender, UserControl_StationOrganiseMain.SensorChangedEventArgs e)
        {
            if (e.SensorNumber == UserControl_StationOrganiseMain.SensorChangedEvent.One)
            {
                Sensor = userControl_StationOrganiseMain1.Sensor1;
                selectedIDInstrument = userControl_StationOrganiseMain1.SensorIndex1;

                fillParamerter();
            }
        }

        private void fillParamerter()
        {
            if (Sensor == null)
            {
                panelProperties.Enabled = false;
                nUD_Azimuth.Value = 0m;
                nUD_Dip.Value = 0m;
                checkBoxRotateAroundVertical.Checked = false;
                nUD_SideLength.Value = 0m;
                nUD_Lambda.Value = 0m;
            }
            else
            {
                panelProperties.Enabled = true;
                nUD_Azimuth.Value = (decimal)Sensor.Azimut;
                nUD_Dip.Value = (decimal)Sensor.Dip;

                if (Sensor.Dip == 0.0)
                    checkBoxRotateAroundVertical.Enabled = false;
                else
                    checkBoxRotateAroundVertical.Enabled = true;

                if (Sensor.RingLaser == null)
                    Sensor.RingLaser = new Station.SensorEntry.Ringlaser();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                if (Sensor.RingLaser.Shape == RingLaserShape.Triangular)
                    radioButtonTriangular.Checked = true;
                else if (Sensor.RingLaser.Shape == RingLaserShape.Squared)
                    radioButtonSquared.Checked = true;

                nUD_SideLength.Value = (decimal)Sensor.RingLaser.SideLength;
                nUD_Lambda.Value = (decimal)Sensor.RingLaser.Lambda;

                calculation();
            }
        }

        private void nUD_Azimuth_ValueChanged(object sender, EventArgs e)
        {
            if (Sensor == null)
                return;

            Sensor.Azimut = (double)nUD_Azimuth.Value;
            userControl_StationOrganiseMain1.Sensor1 = Sensor;
            calculation();
        }

        private void nUD_Dip_ValueChanged(object sender, EventArgs e)
        {
            if (Sensor == null)
                return;

            Sensor.Dip = (double)nUD_Dip.Value;
            userControl_StationOrganiseMain1.Sensor1 = Sensor;
            if (Sensor.Dip == 0.0)
                checkBoxRotateAroundVertical.Enabled = false;
            else
                checkBoxRotateAroundVertical.Enabled = true;

            calculation();
        }

        private void checkBoxRotateAroundVertical_CheckedChanged(object sender, EventArgs e)
        {
            if (_Station == null)
                return;

            calculation();
        }

        private void radioButtonShape_CheckedChanged(object sender, EventArgs e)
        {
            if (Sensor == null)
                return;

            if (((RadioButton)sender).Name == radioButtonSquared.Name)
                Sensor.RingLaser.Shape = RingLaserShape.Squared;
            else if (((RadioButton)sender).Name == radioButtonTriangular.Name)
                Sensor.RingLaser.Shape = RingLaserShape.Triangular;
            
            calculation();
        }

        private void nUD_SideLength_ValueChanged(object sender, EventArgs e)
        {
            if (Sensor == null)
                return;

            Sensor.RingLaser.SideLength = (double)nUD_SideLength.Value;
            userControl_StationOrganiseMain1.Sensor1 = Sensor;
            calculation();
        }

        private void nUD_Lambda_ValueChanged(object sender, EventArgs e)
        {
            if (Sensor == null)
                return;

            Sensor.RingLaser.Lambda = (double)nUD_Lambda.Value;
            userControl_StationOrganiseMain1.Sensor1 = Sensor;
            calculation();
        }

        private void calculation()
        {
            if (_Station == null || Sensor == null)
            {
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl2.GraphPane.CurveList.Clear();

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();

                zedGraphControl2.AxisChange();
                zedGraphControl2.Invalidate();

                if (_Station == null)
                    userControl_RingLaserOrientation1.SiteLocation = null;

                if (Sensor == null)
                    userControl_RingLaserOrientation1.NormalVector = null;

                return;
            }

            myPane1.CurveList.Clear();
            myPane2.CurveList.Clear();

            richTextBox1.Clear();
            richTextBox1.Text = "Location        : " + StationName + Environment.NewLine;
            richTextBox1.Text += " Longitude [°]  : " + _Station.Location.Longitude.ToString("0.000", PreAnalyseExtended.Constants.NumberFormatEN) + Environment.NewLine;
            richTextBox1.Text += " Latitude  [°]  : " + _Station.Location.Latitude.ToString("0.000", PreAnalyseExtended.Constants.NumberFormatEN) + Environment.NewLine + Environment.NewLine;

            richTextBox1.Text += "Instrument      : " + Sensor.Name + Environment.NewLine;
            richTextBox1.Text += " Azimuth     [°]: " + Sensor.Azimut.ToString("0.000", PreAnalyseExtended.Constants.NumberFormatEN) + Environment.NewLine;
            richTextBox1.Text += " Dip         [°]: " + Sensor.Dip.ToString("0.000", PreAnalyseExtended.Constants.NumberFormatEN) + Environment.NewLine;
            richTextBox1.Text += " Side length [m]: " + Sensor.RingLaser.SideLength.ToString("0.000", PreAnalyseExtended.Constants.NumberFormatEN) + Environment.NewLine;
            richTextBox1.Text += " Shape          : " + Sensor.RingLaser.Shape.ToString() + Environment.NewLine;
            richTextBox1.Text += " Lambda     [Hz]: " + Sensor.RingLaser.Lambda.ToString("0.0000", PreAnalyseExtended.Constants.NumberFormatEN) + Environment.NewLine + Environment.NewLine;

            richTextBox1.Text += "Calculations    :" + Environment.NewLine;

            // -------------------------------------------------------------------------------------------------
            RingLaserPrediction rlg = new RingLaserPrediction()
            {
                SiteLocation = new RingLaserPrediction.Location(_Station.Name,
                                                                _Station.Location.Longitude,
                                                                _Station.Location.Latitude,
                                                                _Station.Location.Height),
                SideLength = Sensor.RingLaser.SideLength,
                Lambda = (Sensor.RingLaser.Lambda * 1e-9),
            };

            userControl_RingLaserOrientation1.NormalVector = new UserControl_RingLaserOrientation.Vector_AzimuthDip(Sensor.Azimut, Sensor.Dip);

            if (radioButtonTriangular.Checked)
                rlg.ScaleFactor = rlg.ScaleFactorTriangle();
            else if (radioButtonSquared.Checked)
                rlg.ScaleFactor = rlg.ScaleFactorSquare();

            richTextBox1.Text += " Scale factor   : " + rlg.ScaleFactor.ToString("0.000000", PreAnalyseExtended.Constants.NumberFormatEN) + Environment.NewLine;

            /* ************************************************************
             * **** Test calculation / validation for "G" *****************
             * Steps:
             *  1. Definition of the orientation in local Coordinate System. 
             *     x = to South direction
             *     y = to East direction
             *     z = opposite to g-vector, parallel to Earth radius
             * Loop over the azimuth:
             *  2. Transformation from sperical to cartesian coordinates.  
             *  3. Rotation of the local coordinate system around z-axis
             *     (vertical-axis) adjusting the local orientation against
             *     North.
             *  4. Rotation of the local coordinate system around y-axis
             *     with the co-latutude of the location into the global 
             *     system.
             *  5. Rotation of the glogal system to the right latitude of
             *     the location.
             *  6. Calculation of the nominal Sagnac-frequency of the 
             *     triangular ring, using the given parameter. 
             * ************************************************************/

            // Definition of the orientation of "G" within the local coordinate system, normal vector parallel to z-axis
            RingLaserPrediction.Coordinate_Sperical RL_LocalOrientationSperical = new RingLaserPrediction.Coordinate_Sperical()
            {
                R = 1,
                Theta = RingLaserPrediction.RAD(90.0 - Sensor.Dip),
                Phi = RingLaserPrediction.RAD(Sensor.Azimut + 180.0),
            };

            // Conversion from sperical to cartesien coordinates
            RingLaserPrediction.Coordinate_Cartesian RL_LocalOrientationCartesien = rlg.CoordinateTransformation_SphericalToCartesion(RL_LocalOrientationSperical);

            if (checkBoxRotateAroundVertical.Checked && checkBoxRotateAroundVertical.Enabled)
            {
                string tmp = Environment.NewLine;
                tmp += "        Lobal orientation" + Environment.NewLine;
                tmp += "             of normal " + Environment.NewLine;
                tmp += "Alpha   Latitude  Longitude  Sagnac-frequency" + Environment.NewLine;
                tmp += "  [°]        [°]        [°]              [Hz]" + Environment.NewLine;

                ZedGraph.PointPairList calcsSagnac = new ZedGraph.PointPairList();
                ZedGraph.PointPairList calcsCoords = new ZedGraph.PointPairList();

                for (double alpha = 0; alpha < 360.0; alpha++)
                {
                    // Locale Rotation arround the vertical for azimuth of rings
                    RingLaserPrediction.Coordinate_Cartesian RL_GlobalOrientationCartesien = rlg.CoordinateRotation(RL_LocalOrientationCartesien, RingLaserPrediction.RAD(alpha), RingLaserPrediction.RotationAround.Z);

                    // Rotation around co-latitude
                    RL_GlobalOrientationCartesien = rlg.CoordinateRotation(RL_GlobalOrientationCartesien, RingLaserPrediction.RAD(90.0 - rlg.SiteLocation.Latitude), RingLaserPrediction.RotationAround.Y);

                    // Rotation around longitude - Not nesseccary, but well for proofing
                    RL_GlobalOrientationCartesien = rlg.CoordinateRotation(RL_GlobalOrientationCartesien, RingLaserPrediction.RAD(-rlg.SiteLocation.Longitude), RingLaserPrediction.RotationAround.Z);

                    // Conversion from cartesien to sperical coordinates
                    RingLaserPrediction.Coordinate_Sperical RL_GlobalOrientationSperical = rlg.CoordinateTransformation_CartesionToSpherical(RL_GlobalOrientationCartesien);

                    // Calculation of Sagnac-frequency of "G": 'Scale factor' * 'Earth rotation' * Cos('co-latitude of normal vector within the global coordinate system')
                    double Sagnac = (rlg.ScaleFactor * RingLaserPrediction.EarthRotationIERS * Math.Abs(Math.Cos(RingLaserPrediction.RAD(90.0) - RL_GlobalOrientationSperical.Theta)));

                    // Output
                    tmp += String.Format(PreAnalyseExtended.Constants.NumberFormatEN,
                                                       "{0,5:0} {1,10:0.0000} {2,10:0.0000} {3,17:0.000}" + Environment.NewLine,
                                                       alpha,
                                                       RingLaserPrediction.DEG(RL_GlobalOrientationSperical.Phi),
                                                       RingLaserPrediction.DEG(RL_GlobalOrientationSperical.Theta),
                                                       Sagnac);

                    calcsSagnac.Add(alpha, Sagnac);
                    calcsCoords.Add(RingLaserPrediction.DEG(RL_GlobalOrientationSperical.Phi), RingLaserPrediction.DEG(RL_GlobalOrientationSperical.Theta));
                }

                ZedGraph.LineItem myCurve1 = myPane1.AddCurve(null, calcsSagnac, Color.Red, ZedGraph.SymbolType.None);
                ZedGraph.LineItem myCurve2 = myPane2.AddCurve("Coordinate path of normal vector", calcsCoords, Color.Red, ZedGraph.SymbolType.Diamond);
                myCurve2.Line.IsVisible = false;

                calcsCoords = new ZedGraph.PointPairList();
                if (rlg.SiteLocation.Longitude > 0)
                    calcsCoords.Add(rlg.SiteLocation.Longitude, rlg.SiteLocation.Latitude);
                else
                    calcsCoords.Add(360 + rlg.SiteLocation.Longitude, rlg.SiteLocation.Latitude);

                myCurve2 = myPane2.AddCurve("Site location", calcsCoords, Color.Blue, ZedGraph.SymbolType.XCross);
                myCurve2.Line.IsVisible = false;

                richTextBox1.Text += tmp;
            }
            else
            {
                // Rotation around co-latitude
                RingLaserPrediction.Coordinate_Cartesian RL_GlobalOrientationCartesien = rlg.CoordinateRotation(RL_LocalOrientationCartesien, RingLaserPrediction.RAD(90.0 - rlg.SiteLocation.Latitude), RingLaserPrediction.RotationAround.Y);

                // Rotation around longitude - Not nesseccary, but well for proofing
                RL_GlobalOrientationCartesien = rlg.CoordinateRotation(RL_GlobalOrientationCartesien, RingLaserPrediction.RAD(-rlg.SiteLocation.Longitude), RingLaserPrediction.RotationAround.Z);

                // Conversion from cartesien to sperical coordinates
                RingLaserPrediction.Coordinate_Sperical RL_GlobalOrientationSperical = rlg.CoordinateTransformation_CartesionToSpherical(RL_GlobalOrientationCartesien);

                // Calculation of Sagnac-frewquency of "G": 'Scale factor' * 'Earth rotation' * Cos('co-latitude of normal vector within the global coordinate system')
                double Sagnac = (rlg.ScaleFactor * RingLaserPrediction.EarthRotationIERS * Math.Abs(Math.Cos(RingLaserPrediction.RAD(90.0) - RL_GlobalOrientationSperical.Theta)));

                // Output
                richTextBox1.Text += String.Format(PreAnalyseExtended.Constants.NumberFormatEN,
                                                   " Global orientation of ring laser normal: " + Environment.NewLine +
                                                   "  Longitude: {1,7:0.0000}" + Environment.NewLine +
                                                   "  Latitude : {0,7:0.0000}" + Environment.NewLine,
                    RingLaserPrediction.DEG(RL_GlobalOrientationSperical.Theta),
                    RingLaserPrediction.DEG(RL_GlobalOrientationSperical.Phi));
                richTextBox1.Text += String.Format(PreAnalyseExtended.Constants.NumberFormatEN, "Nominal Sagnac-frequency [Hz]: {0,10:0.000}", Sagnac) + Environment.NewLine;

                ZedGraph.LineItem myCurve2 = myPane2.AddCurve("Coordinate path of normal vector", null, Color.Red, ZedGraph.SymbolType.Diamond);
                myCurve2.Line.IsVisible = false;
                ZedGraph.PointPairList calcsCoords = new ZedGraph.PointPairList();
                if (rlg.SiteLocation.Longitude > 0)
                    calcsCoords.Add(rlg.SiteLocation.Longitude, rlg.SiteLocation.Latitude);
                else
                    calcsCoords.Add(360 + rlg.SiteLocation.Longitude, rlg.SiteLocation.Latitude);

                myCurve2 = myPane2.AddCurve("Site location", calcsCoords, Color.Blue, ZedGraph.SymbolType.XCross);
                myCurve2.Line.IsVisible = false;
            }

            // Calculate the Axis Scale Ranges
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (_Station != null)
                Station.serialisieren(_Station, FilePathEnvironment.pathStations + _Station.Name);
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.FileName = "Sagnac-Prediction.txt";

            if (sdlg.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sdlg.FileName, richTextBox1.Text, System.Text.Encoding.GetEncoding(28591));
        }

        private string[] pBody;
        private int lastLinePrinted = 0;

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument documentToPrint = new PrintDocument();
            printDialog.Document = documentToPrint;

            RichTextBox rtb = richTextBox1;
            string selectedText = rtb.SelectedText;

            if (selectedText.Length > 0)
                printDialog.AllowSelection = true;
            else
                printDialog.AllowSelection = false;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                documentToPrint.PrintPage += new PrintPageEventHandler(DocumentToPrint_PrintPage);

                if (selectedText.Length > 0)
                    pBody = rtb.SelectedText.Split('\n');
                else
                    pBody = rtb.Text.Split('\n');
                lastLinePrinted = 0;

                documentToPrint.Print();
            }
        }

        private void DocumentToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            RichTextBox rtb = richTextBox1;
            Font PrintFont = new Font(rtb.Font.Name, 10f, rtb.Font.Style, rtb.Font.Unit);

            float maxLines = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);


            float LeftMargin = e.MarginBounds.Left / 2;
            float TopMargin = e.MarginBounds.Top;
            SolidBrush PrintBrush = new SolidBrush(Color.Black);


            // began where left off
            int i = lastLinePrinted + 1;
            for (; i < pBody.Length && (i - lastLinePrinted + 1) < maxLines; i++)
            {
                float yPos = TopMargin + ((i - lastLinePrinted + 1) * PrintFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(pBody[i], PrintFont, PrintBrush, LeftMargin, yPos);
            }
            if (i < pBody.Length)
            {
                lastLinePrinted = i - 1;
                e.HasMorePages = true;
            }
            else
                e.HasMorePages = false;
        }
    }
}
