/*
    Copyright (C) 2017  github.com/cxgrillo/UpdateNTAG213

    This file is part of UpdateNTAG213.

    NfcKey is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    NfcKey is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with NfcKey.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace UpdateNTAG
{
    public partial class UpdateNTAG : Form
    {
        private byte[] bCardUIDBytes = new byte[7];
        private byte[] bPasswordBytes;
        private byte[] bPackBytes;
        private bool bXYZFormattedCard;

        private string[] sVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');

        private const string csNoCardFound = "No Card found";
        private const string csOK = "OK";
        private const string csNotaNTAG = "Not a NTAG213 card!";
        private const string csSuccess = "Success";
        private const string csFail = "Fail";
        private const string csFailed = "Failed!";
        private const string cs0Response = "CGrillo:";

        private SerialPort spSerialPort;

        public UpdateNTAG()
        {
            InitializeComponent();
            DisableSetData();

            if (sVersion.Length >= 1)
                this.Text += String.Format(" - v{0}", sVersion[0]);
            if (sVersion.Length >= 2 && sVersion[1] != "0")
                this.Text += String.Format(".{0}", sVersion[1]);

            Size sz = new Size(this.Width, this.Height);
            this.MaximumSize = sz;
            this.MinimumSize = sz;

            buttonConnect.Enabled = true;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            labelConnect.Text = "Searching...";
            this.Invalidate();
            this.Refresh();
            ClearLabels();
            DisableSetData();
            labelGetCard.Text = "";

            if (buttonConnect.Text == "Disconnect")
            {
                spSerialPort.Close();
                spSerialPort.Dispose();
                buttonConnect.Text = "Connect";
                labelConnect.Text = "disconnected";
                buttonGetCard.Enabled = false;
            }
            else
            {
                string sSerialPort = GetSerialPortNo();

                if (sSerialPort.Length > 0)
                {
                    spSerialPort = new SerialPort(sSerialPort);

                    SetUpAndOpenSerialPort(spSerialPort);

                    string str = WriteToArduinoAndRead("0");

                    if (str.Contains(cs0Response))
                    {
                        labelConnect.Text = str.Replace(cs0Response, "Arduino : ");
                        buttonConnect.Text = "Disconnect";
                        buttonGetCard.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong with Serial Port opening");
                    }
                }
                else
                {
                    labelConnect.Text = "No Arduino found!";
                }
            }
            
        }

        private void SetUpAndOpenSerialPort(SerialPort spSerialPort)
        {
            spSerialPort.NewLine = "\r\n";
            spSerialPort.ReadTimeout = 5000;
            spSerialPort.BaudRate = 9600;
            spSerialPort.Open();
        }

        private string WriteToArduinoAndRead(string sToSend)
        {

            if (bXYZFormattedCard && sToSend.StartsWith("3,"))
            {
                WriteToArduinoAndRead("9");
                WriteToArduinoAndRead(string.Format("10,{0},{1},{2},{3}", bPasswordBytes[0], bPasswordBytes[1], bPasswordBytes[2], bPasswordBytes[3]));
            }

            if (sToSend == "") sToSend = "0";
            string sRet = "";
            spSerialPort.WriteLine(sToSend);
            try
            {
                sRet = spSerialPort.ReadLine().Trim();
            }
            catch (Exception)
            {
                return "Err";
            }

            if (sRet.StartsWith("ERROR"))
            {
                string sErrNo = sRet.Substring(6);

                if (sErrNo == "99")
                    return "No Card found";
                else
                    return sRet;
            }
            else
            {
                return sRet;
            }
        }

        private string GetSerialPortNo()
        {
            string[] portNames = SerialPort.GetPortNames();

            // try ports 3 times..
            for (int iLoop = 0; iLoop <= 2; iLoop++)
            {
                foreach (string portName in portNames)
                {
                    try
                    {
                        using (SerialPort serialPort = new SerialPort(portName))
                        {
                            SetUpAndOpenSerialPort(serialPort);

                            serialPort.WriteLine("0");
                            string str = serialPort.ReadLine().Trim();

                            if (str.Contains(cs0Response))
                            {
                                return portName;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                Thread.Sleep(1000);
            }

            return "";
        }

        private string HexStringFromBytes(byte[] bBytes, string sPadding = "")
        {
            StringBuilder sb = new StringBuilder();

            foreach(byte b in bBytes)
            {
                string sHex = string.Format("{0:X}", b);
                if (sHex.Length == 1)
                    sb.Append("0");
                sb.Append(sHex);
                if (sPadding != "")
                    sb.Append(sPadding);
            }

            if (sPadding == "")
            {
                return sb.ToString();
            }
            else
            {
                return sb.ToString().Substring(0, sb.Length - 1);
            }
        }

        private void buttonGetCard_Click(object sender, EventArgs e)
        {
            ClearLabels();
            DisableSetData();

            string sUID = "";
            bool bNTAG213 = GetUID(" ",  ref sUID);

            if (!bNTAG213)
            {
                ClearLabels();
                textBoxCardDetails.Text = sUID;
                return;
            }

            textBoxUID.Text = sUID;
            GetCardUIDBytes();
            bPasswordBytes = NfcHack.NfcKey.GetKey(bCardUIDBytes);
            bPackBytes = NfcHack.NfcKey.GetPack(bCardUIDBytes);

            labelPassword.Text = HexStringFromBytes(bPasswordBytes, " ");
            labelPack.Text = HexStringFromBytes(bPackBytes, " ");

            // So are we a new blank ntag card or a XYZ ntag card to be refilled?
            // Read Page 9 as thatshoudl be locked if it's a XYZ card
            string sReturned = WriteToArduinoAndRead("2,9");

            if (sReturned.StartsWith("ERROR"))
            {
                bXYZFormattedCard = true;
                // XYZ card - need to authenticate
                textBoxCardDetails.AppendText("XYZ formatted card detected\r\nNeed to authenticate and unlock.\r\n\r\n");
                sReturned = WriteToArduinoAndRead("9"); // This resets the card reader session..
                // Authenticate the card..
                sReturned = WriteToArduinoAndRead(string.Format("10,{0},{1},{2},{3}", bPasswordBytes[0], bPasswordBytes[1], bPasswordBytes[2], bPasswordBytes[3]));

                if (!sReturned.Equals(HexStringFromBytes(bPackBytes,",")))
                {
                    textBoxCardDetails.AppendText("PACK Code returned does not match!!\r\nCannot continue!");
                    return;
                }

            }
            else
            {
                bXYZFormattedCard = false;
                // Blank card to fill
                textBoxCardDetails.AppendText("Blank NTAG detected\r\nPassword and Pack will be set as above\r\n");

                textBoxPage9Byte0.Text = "00";
                textBoxPage9Byte1.Text = "35";
                textBoxPage9Byte2.Text = "36";
                textBoxPage9Byte3.Text = "37";
            }


            if (bXYZFormattedCard)
            {

                GetAndSetLength();
                GetAndSetTemp();
                GetAndSetPage9Data();


                long lSpoolLength = GetSpoolLength();

                if (lSpoolLength >= 0)
                {
                    textBoxCardDetails.AppendText(String.Format("Spool Length : {0:#,##0.0} m", lSpoolLength / 1000));
                    textBoxCardDetails.AppendText("\r\n");
                }

                long lLengthRemaining = GetRemainingLength();

                if (lLengthRemaining >= 0)
                {
                    textBoxCardDetails.AppendText(String.Format("Length Remaining: {0:#,##0.0} m", lLengthRemaining / 1000));
                    textBoxCardDetails.AppendText("\r\n");
                }
            }

            EnableSetData();
            textBoxCardDetails.AppendText("\r\nDetails read ok.\r\nSet the card length, temp etc on the next tab");

        }
        
        private void ClearLabels()
        {
            textBoxCardDetails.Text = labelPassword.Text = labelPack.Text = textBoxUID.Text = "";
            textBoxPage9Byte0.Text = textBoxPage9Byte1.Text = textBoxPage9Byte2.Text = textBoxPage9Byte3.Text = "";
            labelGetCard.Text = "";
            textBoxSetData.Text = "";
            this.Refresh();
        }

        private void GetCardUIDBytes()
        {
            StringBuilder sbNewCardUID = new StringBuilder();
            int iLen = textBoxUID.TextLength;

            for (int iChar = 0; iChar < iLen; iChar++)
            {
                if (ValidHexChar(textBoxUID.Text.Substring(iChar, 1)))
                    sbNewCardUID.Append(textBoxUID.Text.Substring(iChar, 1).ToUpper());
            }

            // Page 0
            bCardUIDBytes[0] = byte.Parse(sbNewCardUID.ToString().Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            bCardUIDBytes[1] = byte.Parse(sbNewCardUID.ToString().Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            bCardUIDBytes[2] = byte.Parse(sbNewCardUID.ToString().Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            // Page 1
            bCardUIDBytes[3] = byte.Parse(sbNewCardUID.ToString().Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            bCardUIDBytes[4] = byte.Parse(sbNewCardUID.ToString().Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
            bCardUIDBytes[5] = byte.Parse(sbNewCardUID.ToString().Substring(10, 2), System.Globalization.NumberStyles.HexNumber);
            bCardUIDBytes[6] = byte.Parse(sbNewCardUID.ToString().Substring(12, 2), System.Globalization.NumberStyles.HexNumber);
        }

        private bool ValidHexChar(string sPassed)
        {
            if (sPassed.Length != 1)
                return false;
            else
            {
                byte[] toBytes = Encoding.ASCII.GetBytes(sPassed.ToUpper());

                if (toBytes[0] >= 65 && toBytes[0] <= 70)
                    return true;
                else if (toBytes[0] >= 48 && toBytes[0] <= 57)
                    return true;
                else
                    return false;
            }
        }

        private void EnableSetData()
        {
            buttonSetData.Enabled = true;
            groupBoxLength.Enabled = true;
            groupBoxTemp.Enabled = true;
            groupBoxPage9Data.Enabled = true;
        }

        private void DisableSetData()
        {
            buttonSetData.Enabled = false;
            groupBoxLength.Enabled = false;
            groupBoxTemp.Enabled = false;
            groupBoxPage9Data.Enabled = false;
        }

        private bool GetUID(string sDelimiter, ref string sUID)
        {
            string sReturned = WriteToArduinoAndRead("1");
            bool bRet = false;
            // NTAG213 ?
            if (sReturned.Equals(csNoCardFound))
            {
                sUID = csNoCardFound;
            }
            else if (sReturned.EndsWith(",OK"))
            {
                sUID = String.Format("{0}{7}{1}{7}{2}{7}{3}{7}{4}{7}{5}{7}{6}",
                    sReturned.Substring(0, 2), sReturned.Substring(2, 2), sReturned.Substring(4, 2), sReturned.Substring(6, 2),
                    sReturned.Substring(8, 2), sReturned.Substring(10, 2), sReturned.Substring(12, 2), sDelimiter);
                bRet = true;
            }
            else
            {
                int iPos = sReturned.LastIndexOf(",");
                sUID = sReturned.Substring(iPos + 1);
            }

            if (bRet)
            {
                sReturned = WriteToArduinoAndRead("11");
                if (!sReturned.Equals("4,15"))
                {
                    bRet = false;
                    sUID = "NOT an NTAG213";
                }
            }

            return bRet;
        }

        private long GetSpoolLength()
        {
            string sReturned = WriteToArduinoAndRead("2,10");

            if (sReturned.Length != 11)
                return 0;
            else
            {
                string sHexValue = string.Format("{0}{1}{2}{3}", sReturned.Substring(9, 2), sReturned.Substring(6, 2), sReturned.Substring(3, 2), sReturned.Substring(0, 2));
                long lLength = long.Parse(sHexValue, System.Globalization.NumberStyles.HexNumber);
                return lLength;
            }
            
        }

        private void GetAndSetLength()
        {
            if (GetSpoolLength() == 200000)
                radioButton200m.Checked = true;
            else
                radioButton300m.Checked = true;
        }

        private int GetTemp()
        {
            string sReturned = WriteToArduinoAndRead("2,8");
            if (sReturned.EndsWith(",32,00")
             || sReturned.EndsWith(",45,00")
             || sReturned.EndsWith(",4C,00")
             || sReturned.EndsWith(",4F,00")
             || sReturned.EndsWith(",5A,00"))
                return 190;
            else if(sReturned.EndsWith(",4B,00"))
                return 200;
            else
                return 210;
        }

        private void GetAndSetTemp()
        {
            int iTemp = GetTemp();

            if (iTemp == 190)
                radioButton190deg.Checked = true;
            else if (iTemp == 200)
                radioButton200deg.Checked = true;
            else
                radioButton210deg.Checked = true;
        }

        private void GetAndSetPage9Data()
        {
            try
            {
                string sReturned = WriteToArduinoAndRead("2,9");
                if (sReturned.Length == 11)
                {
                    textBoxPage9Byte0.Text = sReturned.Substring(0, 2);

                    if (sReturned.Substring(3, 2).Equals("00"))
                        textBoxPage9Byte1.Text = "35";
                    else
                        textBoxPage9Byte1.Text = sReturned.Substring(3, 2);

                    if (sReturned.Substring(6, 2).Equals("00"))
                        textBoxPage9Byte2.Text = "36";
                    else
                        textBoxPage9Byte2.Text = sReturned.Substring(6, 2);

                    if (sReturned.Substring(9, 2).Equals("00"))
                        textBoxPage9Byte3.Text = "37";
                    else
                        textBoxPage9Byte3.Text = sReturned.Substring(9, 2);
                }
                else
                {
                    textBoxPage9Byte0.Text = "E";
                    textBoxPage9Byte1.Text = "rr";
                    textBoxPage9Byte2.Text = "or";
                    textBoxPage9Byte3.Text = "";
                }
            }
            catch (Exception)
            {
                textBoxPage9Byte0.Text = "E";
                textBoxPage9Byte1.Text = "rr";
                textBoxPage9Byte2.Text = "or";
                textBoxPage9Byte3.Text = ".";
            }
        }

        private long GetRemainingLength()
        {
            try
            {
                string sReturned = WriteToArduinoAndRead("2,20");
                if (sReturned.Length == 11)
                {
                    string sHexLength = string.Format("{0}{1}{2}{3}", sReturned.Substring(9, 2), sReturned.Substring(6, 2), sReturned.Substring(3, 2), sReturned.Substring(0, 2));
                    long lLengthRemaining = long.Parse(sHexLength, System.Globalization.NumberStyles.HexNumber);
                    return lLengthRemaining;
                    //labelLengthRemaining.Text = String.Format("{0:#,##0.0} m", lLengthRemaining / 1000);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private bool WriteAllData()
        {

            bool bSuccess  =true;

            // Page 9 stuff
            int iPage9Byte0 = int.Parse(textBoxPage9Byte0.Text, System.Globalization.NumberStyles.HexNumber);
            int iPage9Byte1 = int.Parse(textBoxPage9Byte1.Text, System.Globalization.NumberStyles.HexNumber);
            int iPage9Byte2 = int.Parse(textBoxPage9Byte2.Text, System.Globalization.NumberStyles.HexNumber);
            int iPage9Byte3 = int.Parse(textBoxPage9Byte3.Text, System.Globalization.NumberStyles.HexNumber);

            string sPage9 = WriteToArduinoAndRead(String.Format("3,9,{0},{1},{2},{3}", iPage9Byte0, iPage9Byte1, iPage9Byte2, iPage9Byte3));

            bSuccess = bSuccess && sPage9.Equals(csOK);

            // Lengh data and checksums

            string sPage10, sPage11, sPage20, sPage21, sPage22, sPage23;

            if (radioButton200m.Checked)
            {
                sPage10 = WriteToArduinoAndRead("3,10,64,13,3,0");
                sPage11 = WriteToArduinoAndRead("3,11,64,13,3,0");
                sPage20 = WriteToArduinoAndRead("3,20,64,13,3,0");

                sPage21 = WriteToArduinoAndRead("3,21,8,31,49,84");
                sPage22 = WriteToArduinoAndRead("3,22,80,177,224,206");
                sPage23 = WriteToArduinoAndRead("3,23,82,231,79,118");
            }
            else //  (radioButton300m.Checked)
            {
                sPage10 = WriteToArduinoAndRead("3,10,224,147,4,0");
                sPage11 = WriteToArduinoAndRead("3,11,224,147,4,0");
                sPage20 = WriteToArduinoAndRead("3,20,224,147,4,0");

                sPage21 = WriteToArduinoAndRead("3,21,220,249,49,84");
                sPage22 = WriteToArduinoAndRead("3,22,12,151,239,206");
                sPage23 = WriteToArduinoAndRead("3,23,166,198,78,118");
            }
            bSuccess = bSuccess && sPage10.Equals(csOK) && sPage11.Equals(csOK) && sPage20.Equals(csOK) && sPage21.Equals(csOK) && sPage22.Equals(csOK) && sPage23.Equals(csOK);


            // Temp / Colour
            string sPage7;

            if (radioButton190deg.Checked)
                sPage7 = WriteToArduinoAndRead("3,8,90,80,79,0");
            else if (radioButton200deg.Checked)
                sPage7 = WriteToArduinoAndRead("3,8,90,80,75,0"); // Black 200 deg (?)
            else // (210 deg)
                sPage7 = WriteToArduinoAndRead("3,8,90,80,80,0");

            bSuccess = bSuccess && sPage7.Equals(csOK);

            // Configuration pages
            string sPage41 = WriteToArduinoAndRead("3,41,7,0,0,8");
            string sPage42 = WriteToArduinoAndRead("3,42,128,5,0,0"); 
            bSuccess = bSuccess && sPage41.Equals(csOK) && sPage42.Equals(csOK);

            // Misc pages
            string sPage12 = WriteToArduinoAndRead("3,12,210,0,45,0");
            string sPage13 = WriteToArduinoAndRead("3,13,84,72,71,66");
            string sPage14 = WriteToArduinoAndRead("3,14,48,51,53,53");
            string sPage17 = WriteToArduinoAndRead("3,17,52,0,0,0");

            bSuccess = bSuccess && sPage12.Equals(csOK) && sPage13.Equals(csOK) && sPage14.Equals(csOK) && sPage17.Equals(csOK);

            string sRetPACK = WriteToArduinoAndRead(String.Format("3,44,{0},{1},0,0", bPackBytes[0], bPackBytes[1]));
            bSuccess = bSuccess && sRetPACK.Equals(csOK);

            string sRetPassword = WriteToArduinoAndRead(string.Format("3,43,{0},{1},{2},{3}", bPasswordBytes[0], bPasswordBytes[1], bPasswordBytes[2], bPasswordBytes[3]));
            bSuccess = bSuccess && sRetPassword.Equals(csOK);

            textBoxSetData.AppendText("Data set.");
            
            // Now to check if it all worked!!

            //WriteToArduinoAndRead("9");
            //string sUID = "";
            //GetUID("", ref sUID);

            //DisableSetData();

            return bSuccess;
        }

        private void buttonSetData_Click(object sender, EventArgs e)
        {
            // Are we still unlocked?
            if (bXYZFormattedCard)
            {
                // Try and read page 9
                string sReturned = WriteToArduinoAndRead("2,9");

                if (sReturned.StartsWith("ERROR"))
                {
                    DisableSetData();
                    textBoxSetData.AppendText("Do not remove the card between reading the card details and setting them.\r\n\r\nPlease start again.");
                    return;
                }
            }

            string sUID = "";
            bool bNTAG213 = GetUID(" ", ref sUID);

            if (!bNTAG213 || !textBoxUID.Text.Equals(sUID))
            {
                // Should never get here as the check above should catch issues.
                textBoxSetData.AppendText("Do not change cards.\r\n\r\nPlease start again.");
                return;

            }

            if ((textBoxPage9Byte0.Text + textBoxPage9Byte1.Text + textBoxPage9Byte2.Text + textBoxPage9Byte3.Text).Length != 8)
            {
                textBoxSetData.AppendText("Please check you have entered Page 9 (2 chars each).\r\n\r\nPlease start again.");
                return;
            }


            long lCheck;
            if (!long.TryParse(textBoxPage9Byte0.Text + textBoxPage9Byte1.Text + textBoxPage9Byte2.Text + textBoxPage9Byte3.Text, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out lCheck))
            {
                textBoxSetData.AppendText("Page 9 data does not seem to be hex.\r\n\r\nPlease start again.");
                return;
            }


            WriteAllData();

        }
    }

}
