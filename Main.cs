﻿using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimMapsConnect
{
    public partial class Main : Form
    {

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        // User-defined win32 event
        const int WM_USER_SIMCONNECT = 0x0402;

        // SimConnect object
        SimConnect simconnect = null;

        bool isRequesting;

        enum DEFINITIONS
        {
            Struct1,
        }

        enum DATA_REQUESTS
        {
            REQUEST_1,
        };

        // this is how you declare a data structure so that
        // simconnect knows how to fill it/read it.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct Struct1
        {
            // this is how you declare a fixed size string
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String title;
            public double latitude;
            public double longitude;
            public double altitude;
            public double altitudeAboveGround;
            public double heading;
        };

        public Main()
        {
            InitializeComponent();

            cbRequestInterval.SelectedIndex = 3;
            cbZoom.SelectedIndex = 14;
            cbMap.SelectedIndex = 0;

            setButtons(true, false, false, false, false);
            myTimer.Tick += TimerEventProcessor;
        }
        // Simconnect client will send a win32 message when there is
        // a packet to process. ReceiveMessage must be called to
        // trigger the events. This model keeps simconnect processing on the main thread.

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simconnect != null)
                {
                    simconnect.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void setButtons(bool bConnect, bool bGet, bool bDisconnect, bool bRequest, bool bUpdate)
        {
            buttonConnect.Enabled = bConnect;
            buttonRequestData.Enabled = bGet;
            buttonDisconnect.Enabled = bDisconnect;
            chkRequestData.Enabled = bRequest;
            chkUpdateMaps.Enabled = bUpdate;
        }

        private void closeConnection()
        {
            if (simconnect != null)
            {
                // Dispose serves the same purpose as SimConnect_Close()
                simconnect.Dispose();
                simconnect = null;
                displayText("Connection closed");
            }
        }

        // Set up all the SimConnect related data definitions and event handlers
        private void initDataRequest()
        {
            try
            {
                // listen to connect and quit msgs
                simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(simconnect_OnRecvOpen);
                simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simconnect_OnRecvQuit);

                // listen to exceptions
                simconnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simconnect_OnRecvException);

                // define a data structure
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Title", null, SIMCONNECT_DATATYPE.STRING256, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Plane Latitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Plane Longitude", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Plane Alt Above Ground", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                simconnect.AddToDataDefinition(DEFINITIONS.Struct1, "Plane Heading Degrees Gyro", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);


                // IMPORTANT: register it with the simconnect managed wrapper marshaller
                // if you skip this step, you will only receive a uint in the .dwData field.
                simconnect.RegisterDataDefineStruct<Struct1>(DEFINITIONS.Struct1);

                // catch a simobject data request
                simconnect.OnRecvSimobjectDataBytype += new SimConnect.RecvSimobjectDataBytypeEventHandler(simconnect_OnRecvSimobjectDataBytype);
            }
            catch (COMException ex)
            {
                displayText(ex.Message);
            }
        }

        void simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            displayText("Connected to FS");
        }

        // The case where the user closes FSX
        void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            displayText("FS has exited");
            closeConnection();
        }

        void simconnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            displayText("Exception received: " + data.dwException);
        }

        // The case where the user closes the client
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeConnection();
        }

        void simconnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            output.Clear();
            switch ((DATA_REQUESTS)data.dwRequestID)
            {
                case DATA_REQUESTS.REQUEST_1:
                    Struct1 s1 = (Struct1)data.dwData[0];

                    if (chkShowValues.Checked)
                    {
                        displayText("Lat:   " + s1.latitude);
                        displayText("Lon:   " + s1.longitude);
                        displayText("AltAboveGround:  " + s1.altitudeAboveGround);
                        displayText("Heading: " + s1.heading);
                    }
                    if(chkUpdateMaps.Checked)
                    {
                        string zoomString = "";
                        if(chkZoom.Checked)
                        {
                            zoomString = $"lvl={20 - Math.Ceiling(s1.altitudeAboveGround / 1000)}";
                        }
                        else
                        {
                            zoomString = $"lvl={cbZoom.SelectedItem}";
                        }

                        string mapString = "sty=";
                        switch(cbMap.SelectedItem)
                        {
                            case "Road": mapString += "r";break;
                            //case "3D": mapString += "3d";break;
                            default: mapString += "a"; break;
                        }

                        var gpsString = $"bingmaps:?cp={s1.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}~{s1.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}&{zoomString}&{mapString}&hdg={(int)s1.heading}";
                        //var gpsString = $"bingmaps:?cp={s1.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}~{s1.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}&lvl={cbZoom.SelectedItem}&sty=h&sp=point.{s1.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}_{s1.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}_{System.Net.WebUtility.UrlEncode("Tobi")}";
                        //var gpsString = $"bingmaps:?rtp=pos.{s1.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}_{s1.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}~pos.{s1.latitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}_{s1.longitude.ToString(CultureInfo.InvariantCulture.NumberFormat)}&lvl={cbZoom.SelectedItem}&sty=a";
                        Process.Start(gpsString);

                        Process.Start("ActivateFS.exe");

                    }

                    break;

                default:
                    displayText("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (simconnect == null)
            {
                try
                {
                    // the constructor is similar to SimConnect_Open in the native API
                    simconnect = new SimConnect("Managed Data Request", this.Handle, WM_USER_SIMCONNECT, null, 0);
                    setButtons(false, true, true, true, true);

                    initDataRequest();

                }
                catch (COMException ex)
                {
                    displayText("Unable to connect to FSX");
                }
            }
            else
            {
                displayText("Error - try again");
                closeConnection();

                setButtons(true, false, false, false, false);
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            myTimer.Stop();
            myTimer.Enabled = false;
            closeConnection();
            setButtons(true, false, false, false, false);
        }

        private void buttonRequestData_Click(object sender, EventArgs e)
        {
            // The following call returns identical information to:
            // simconnect.RequestDataOnSimObject(DATA_REQUESTS.REQUEST_1, DEFINITIONS.Struct1, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.ONCE);

            simconnect.RequestDataOnSimObjectType(DATA_REQUESTS.REQUEST_1, DEFINITIONS.Struct1, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);

        }

        // Response number
        int response = 1;

        // Output text - display a maximum of 10 lines
        StringBuilder output = new StringBuilder();

        void displayText(string s)
        {
            output.AppendLine(s);
            // display it
            richResponse.Text = output.ToString();
        }

        private void chkRequestData_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRequestData.Checked)
            {
                buttonRequestData.Enabled = false;
                myTimer.Interval = int.Parse(cbRequestInterval.SelectedItem.ToString()) * 1000;
                myTimer.Enabled = true;
                myTimer.Start();
            }
            else
            {
                buttonRequestData.Enabled = true;
                myTimer.Stop();
                myTimer.Enabled = false;
            }
        }

        // This is the method to run when the timer is raised.
        private void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            if(!isRequesting)
            {
                isRequesting = true;
                simconnect.RequestDataOnSimObjectType(DATA_REQUESTS.REQUEST_1, DEFINITIONS.Struct1, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                isRequesting = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chkZoom.Checked)
            {
                cbZoom.Enabled = false;
            }
            else
            {
                cbZoom.Enabled = true;
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);



        /*private List<SimVarRequest> requests = new List<SimVarRequest>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            requests.Add(new SimVarRequest()
            {

            })
        }*/
    }
}