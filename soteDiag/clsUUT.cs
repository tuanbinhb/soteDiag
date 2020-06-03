// Decompiled with JetBrains decompiler
// Type: soteDiag.clsUUT
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using soteLib;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace soteDiag
{
  public class clsUUT
  {
    public static int mac_count = 0;
    public static int mac_increment = 0;
    public static string dos_dir = (string) null;
    public static int pcie_test_loop = 0;
    public static string[] scanMAC = (string[]) null;
    public static string scanLabel = "";
    public static string esrLabel = "";
    public static string cm_PartNumber = "";
    public static string dell_PN_rev = "";
    public static string hw_type = "";
    public static string hw_SDID = "";
    private static string[] consecMAC = (string[]) null;
    public static bool bCdiagB57diag = false;
    public static bool bCdiag = false;
    public static bool bB57diag = false;
    public static bool bFRU = false;
    public static bool bNPAR = false;
    public static bool bHPE = false;
    public static bool bOCP30 = false;
    private const string PN_Austin = "00E2872";
    private const string PN_Quadrunner = "00E2872";
    private const string PN_Dualrunner = "90Y9372";
    private const string PN_Sharknado4 = "SN30L21972";
    private const string PN_Sharknado2 = "SN30L21970";
    private const string PN_Bashir_STD = "0FCGN";
    private const string PN_Bashir_LP = "557M9";
    private const string PN_Boerne = "PEPDB";
    private const string PN_Cardassia2_STD = "HY7RM";
    private const string PN_Cardassia2_LP = "YGCV4";
    private const string PN_Corak = "22TDT";
    private const string PN_N1905 = "N1905";
    private const string PN_Gamma = "MW9RC";
    private const string PN_N2004 = "G9XC9";
    private const string PN_Obrien = "FM487";
    private const string PN_Mustang = "49Y7901";
    private const string PN_Putnam = "PBYWT";
    private const string PN_BUBBLES = "PWVQV";
    private const string PN_CASPIAN = "SN37A28236";
    private const string PN_ARAL = "SN37A28240";
    private const string PN_Woodville = "PBKRQ";
    private const string PN_BOAR = "PFDMD";
    private const string PN_BANDICOOT = "PFDMB";
    private const string PN_BOBOLINK = "PFDME";
    private const string PN_BOBCAT = "PFCJK";
    private const string PN_Mercury = "1904";
    private const string PN_Pluto = "2003";
    private const string PN_P150C = "A3040";
    private const string PN_P125C = "A3020";
    private const string PN_P225C = "A3041";
    private const string PN_P225Ca = "A3042";
    private const string PN_P225Co = "A3043";
    private const string PN_P225PO = "433551";
    private const string PN_P225P = "A4142";
    private const string PN_P150P = "A4140";
    private const string PN_M225P = "M4142";
    private const string PN_M125P = "M4122";
    private const string PN_M210P = "M4123";
    private const string PN_P210P = "A4120";
    private const string PN_P210C = "A3021";
    private const string PN_P225E = "A4040";
    private const string PN_PAULI = "NWMNX";
    private const string PN_HERTZ = "9XY73";
    private const string PN_GAUSS = "1224N";
    private const string PN_P225ED = "7M8VP";
    private const string PN_P225EPD = "CX94X";
    private const string PN_P210ED = "3KHCF";
    private const string PN_P210EPD = "GMW01";
    private const string PN_P210TED = "81V1W";
    private const string PN_P210TEPD = "3TM39";
    private const string PN_P225EDLP = "4GMN7";
    private const string PN_P225EPDLP = "24GFD";
    private const string PN_P210EDLP = "61J1X";
    private const string PN_P210EPDLP = "YR0VV";
    private const string PN_P210TEDLP = "9P1N8";
    private const string PN_P210TEPDLP = "NC5VD";
    private const string PN_M150C = "M3041";
    private const string PN_M150PM = "M4520";
    private const string PN_M1100PM = "M4540";
    private const string PN_M150P = "M4143";
    private const string PN_M210TP = "M4163";
    private const string PN_M225PQ = "M4144";
    private const string PN_PS150 = "A8020";
    private const string PN_MS150 = "M8020";
    private const string PN_P1100P = "A4540";
    private const string PN_M225C = "M3040";
    private const string PN_M225CD = "8CM81";
    private const string PN_M225PD = "930PP";
    private const string PN_M210C = "M3022";
    private const string PN_M125C = "M3020";
    private const string PN_M125CP = "M3120";
    private const string PN_M125CLP = "M3021";
    private const string PN_M125CHF = "M3023";
    private const string PN_M125CLPHF = "M3024";
    private const string PN_A4160L = "SN30L27797";
    private const string PN_M4161 = "SN30L27798";
    private const string PN_A3120L = "SN30L27799";
    private const string PN_P210TE = "A4060";
    private const string PN_P210TEP = "A4160";
    private const string HW_Generic = "GENERIC";
    private const string HW_Austin = "AUSTIN";
    private const string HW_Quadrunner = "QUADRUNNER";
    private const string HW_Dualrunner = "DUALRUNNER";
    private const string HW_Sharknado4 = "SHARKNADO4";
    private const string HW_Sharknado2 = "SHARKNADO2";
    private const string HW_Bashir = "BASHIR";
    private const string HW_Boerne = "BOERNE";
    private const string HW_Cardassia = "CARDASSIA";
    private const string HW_Corak = "CORAK";
    private const string HW_N1905 = "N1905";
    private const string HW_Gamma = "GAMMA";
    private const string HW_N2004 = "N2004";
    private const string HW_Obrien = "OBRIEN";
    private const string HW_Mustang = "MUSTANG";
    private const string HW_Putnam = "PUTNAM";
    private const string HW_BUBBLES = "BUBBLES";
    private const string HW_Woodville = "WOODVILLE";
    private const string HW_BOAR = "BOAR";
    private const string HW_BANDICOOT = "BANDICOOT";
    private const string HW_BOBCAT = "BOBCAT";
    private const string HW_BOBOLINK = "BOBOLINK";
    private const string HW_Mercury = "MERCURY";
    private const string HW_Pluto = "PLUTO";
    private const string HW_P150C = "P150C";
    private const string HW_P125C = "P125C";
    private const string HW_P225C = "P225C";
    private const string HW_P225Ca = "P225CA";
    private const string HW_P225Co = "P225CO";
    private const string HW_P225PO = "P225PO";
    private const string HW_P225P = "P225P";
    private const string HW_P150P = "P150P";
    private const string HW_M225P = "M225P";
    private const string HW_M125P = "M125P";
    private const string HW_M210P = "M210P";
    private const string HW_P210P = "P210P";
    private const string HW_P210C = "P210C";
    private const string HW_P225E = "P225E";
    private const string HW_PAULI = "PAULI";
    private const string HW_HERTZ = "HERTZ";
    private const string HW_GAUSS = "GAUSS";
    private const string HW_P225ED = "P225ED";
    private const string HW_P225EPD = "P225EPD";
    private const string HW_P210ED = "P210ED";
    private const string HW_P210EPD = "P210EPD";
    private const string HW_P210TED = "P210TED";
    private const string HW_P210TEPD = "P210TEPD";
    private const string HW_P225EDLP = "P225EDLP";
    private const string HW_P225EPDLP = "P225EPDLP";
    private const string HW_P210EDLP = "P210EDLP";
    private const string HW_P210EPDLP = "P210EPDLP";
    private const string HW_P210TEDLP = "P210TEDLP";
    private const string HW_P210TEPDLP = "P210TEPDLP";
    private const string HW_M150C = "M150C";
    private const string HW_M150PM = "M150PM";
    private const string HW_M1100PM = "M1100PM";
    private const string HW_M150P = "M150P";
    private const string HW_M210TP = "M210TP";
    private const string HW_M225PQ = "M225PQ";
    private const string HW_PS150 = "PS150";
    private const string HW_MS150 = "MS150";
    private const string HW_P1100P = "P1100P";
    private const string HW_M225C = "M225C";
    private const string HW_M225CD = "M225CD";
    private const string HW_M225PD = "M225PD";
    private const string HW_M210C = "M210C";
    private const string HW_M125C = "M125C";
    private const string HW_M125CP = "M125CP";
    private const string HW_M125CLP = "M125CLP";
    private const string HW_M125CHF = "M125CHF";
    private const string HW_M125CLPHF = "M125CLPHF";
    private const string HW_A4160L = "A4160L";
    private const string HW_M4161 = "M4161";
    private const string HW_CASPIAN = "CASPIAN";
    private const string HW_ARAL = "ARAL";
    private const string HW_A3120L = "A3120L";
    private const string HW_P210TE = "P210TE";
    private const string HW_P210TEP = "P210TEP";
    private const int ESR = 90;

    private static void readIni(string hw_type)
    {
      IniFile.FileName = Directory.GetCurrentDirectory() + "\\" + Application.ProductName + ".ini";
      try
      {
        if (hw_type == "GENERIC")
        {
          clsUUT.mac_count = 1;
          clsUUT.mac_increment = 1;
          clsUUT.cm_PartNumber = "PART_NUMBER";
          clsUUT.dos_dir = "DOS_DIR";
        }
        else
        {
          clsUUT.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
          clsUUT.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
          clsUUT.cm_PartNumber = IniFile.GetProfile(hw_type, "PART_NUMBER");
          clsUUT.dos_dir = IniFile.GetProfile(hw_type, "DOS_DIR");
          if (hw_type == "M125C")
            clsUUT.pcie_test_loop = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "PCIE_TEST_LOOP"));
          if (hw_type == "M225CD" || hw_type == "M225PD" || (hw_type == "P225ED" || hw_type == "P225EDLP") || (hw_type == "PAULI" || hw_type == "HERTZ" || (hw_type == "GAUSS" || hw_type == "P225EPD")) || (hw_type == "P225EPDLP" || hw_type == "P210ED" || (hw_type == "P210EDLP" || hw_type == "P210EPD") || (hw_type == "P210EPDLP" || hw_type == "P210TED" || (hw_type == "P210TEDLP" || hw_type == "P210TEPD"))) || hw_type == "P210TEPDLP" || hw_type == "N2004")
            clsUUT.dell_PN_rev = IniFile.GetProfile(hw_type, "PART_REV");
        }
      }
      catch (Exception ex)
      {
        int num = (int) new NewMessageBox()
        {
          Message = string.Format("readIni: " + ex.Message)
        }.ShowDialog();
        clsUUT.showFailMsgDlg("readIni: EXCEPTION encountered", true);
      }
    }

    public static string[] verifyMAC(string mac, int sfisType, int stride, string dutType)
    {
      if (clsUUT.mac_count > 0)
      {
        string str1 = mac;
        if (dutType == "SHARKNADO4" || clsUUT.hw_type == "SHARKNADO2" || (clsUUT.hw_type == "M4161" || clsUUT.hw_type == "A3120L") || (clsUUT.hw_type == "A4160L" || clsUUT.hw_type == "CASPIAN") || clsUUT.hw_type == "ARAL")
        {
          if (str1.Length != 15)
          {
            if (sfisType == 90)
              clsUUT.showFailMsgDlg(string.Format("Invalid MAC Length: {0}", (object) str1), true);
            else
              clsUUT.showFailMsgDlg(string.Format("Invalid MAC Length: {0}", (object) str1), false);
            return (string[]) null;
          }
          str1 = mac.Substring(3, 12);
        }
        if (dutType == "M150PM" || clsUUT.bOCP30)
          str1 = mac.Substring(0, 12);
        string str2 = str1.Replace(":", "").Replace("-", "").Replace("\r", "");
        if (str2 == "")
        {
          int num = (int) new NewMessageBox()
          {
            Message = "Please scan in MAC address"
          }.ShowDialog();
          return (string[]) null;
        }
        clsUUT.scanMAC = str2.Trim().Split(' ', ',', '\n');
        if (clsUUT.scanMAC[0].Length != 12)
        {
          if (sfisType == 90)
            clsUUT.showFailMsgDlg(string.Format("Invalid MAC Length: {0}", (object) clsUUT.scanMAC[0]), true);
          else
            clsUUT.showFailMsgDlg(string.Format("Invalid MAC Length: {0}", (object) clsUUT.scanMAC[0]), false);
          return (string[]) null;
        }
        int int16_1 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(clsUUT.scanMAC[0].Length - 1, 1), 16);
        string str3 = str2.Substring(0, 12);
        if (clsUUT.hw_type == "BOAR" || clsUUT.hw_type == "BOBOLINK" || clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BANDICOOT")
        {
          if (str3.Substring(11, 1).Contains("0"))
          {
            string str4 = str3.Substring(0, 12) + "\n" + str3.Substring(0, 11) + "8";
            string str5 = str4.Substring(0, 25) + "\n" + str4.Substring(0, 11) + "1";
            str3 = str5.Substring(0, 38) + "\n" + str5.Substring(0, 11) + "9";
          }
        }
        else if (clsUUT.hw_type == "P225PO")
        {
          if (str3.Substring(11, 1).Contains("0"))
            str3 = str3.Substring(0, 12) + "\n" + str3.Substring(0, 11) + "8";
        }
        else
        {
          switch (clsUUT.mac_count)
          {
            case 2:
              str3 = str3 + "\n" + str3.Substring(0, 11) + Convert.ToByte(int16_1 + 1).ToString("X");
              break;
            case 4:
              int int16_2 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(clsUUT.scanMAC[0].Length - 2, 2), 16);
              string[] strArray1 = new string[10];
              strArray1[0] = str3;
              strArray1[1] = "\n";
              strArray1[2] = str3.Substring(0, 10);
              string[] strArray2 = strArray1;
              byte num1 = Convert.ToByte(int16_2 + 1);
              string str6 = num1.ToString("X2");
              strArray2[3] = str6;
              strArray1[4] = "\n";
              strArray1[5] = str3.Substring(0, 10);
              string[] strArray3 = strArray1;
              num1 = Convert.ToByte(int16_2 + 2);
              string str7 = num1.ToString("X2");
              strArray3[6] = str7;
              strArray1[7] = "\n";
              strArray1[8] = str3.Substring(0, 10);
              string[] strArray4 = strArray1;
              num1 = Convert.ToByte(int16_2 + 3);
              string str8 = num1.ToString("X2");
              strArray4[9] = str8;
              str3 = string.Concat(strArray1);
              break;
          }
        }
        clsUUT.scanMAC = str3.Trim().Split(' ', ',', '\n');
        if (clsUUT.scanMAC.Length != clsUUT.mac_count)
        {
          if (sfisType == 90)
            clsUUT.showFailMsgDlg(string.Format("Invalid number of MAC (expecting {0})", (object) clsUUT.mac_count), true);
          else
            clsUUT.showFailMsgDlg(string.Format("Invalid number of MAC (expecting {0})", (object) clsUUT.mac_count), false);
          return (string[]) null;
        }
        for (int index = 0; index < clsUUT.scanMAC.Length; ++index)
        {
          if (!clsUUT.IsHex(clsUUT.scanMAC[index]))
          {
            clsUUT.showFailMsgDlg(string.Format("Invalid MAC Value {0}", (object) clsUUT.scanMAC[index]), false);
            return (string[]) null;
          }
          if (clsUUT.scanMAC[index].Length != 12)
          {
            if (sfisType == 90)
              clsUUT.showFailMsgDlg(string.Format("Invalid MAC Length {0}", (object) clsUUT.scanMAC[index]), true);
            else
              clsUUT.showFailMsgDlg(string.Format("Invalid MAC Length {0}", (object) clsUUT.scanMAC[index]), false);
            return (string[]) null;
          }
          if (str3.IndexOf(clsUUT.scanMAC[index]) != str3.LastIndexOf(clsUUT.scanMAC[index]))
          {
            if (sfisType == 90)
              clsUUT.showFailMsgDlg(string.Format("Found DUPLICATE MAC {0}", (object) clsUUT.scanMAC[index]), true);
            else
              clsUUT.showFailMsgDlg(string.Format("Found DUPLICATE MAC {0}", (object) clsUUT.scanMAC[index]), false);
            return (string[]) null;
          }
        }
        Array.Sort<string>(clsUUT.scanMAC);
        int int16_3 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(clsUUT.scanMAC[0].Length - 1, 1), 16);
        if (clsUUT.hw_type == "P225C" || clsUUT.hw_type == "P225CA" || (clsUUT.hw_type == "P225CO" || clsUUT.hw_type == "P150C") || (clsUUT.hw_type == "M150C" || clsUUT.hw_type == "M125C" || (clsUUT.hw_type == "M125CP" || clsUUT.hw_type == "P125C")) || (clsUUT.hw_type == "M125CHF" || clsUUT.hw_type == "M125CLPHF" || (clsUUT.hw_type == "P225ED" || clsUUT.hw_type == "P210ED") || (clsUUT.hw_type == "P210TED" || clsUUT.hw_type == "P210TE" || (clsUUT.hw_type == "M125CLP" || clsUUT.hw_type == "PAULI"))) || (clsUUT.hw_type == "GAUSS" || clsUUT.hw_type == "PS150" || (clsUUT.hw_type == "MS150" || clsUUT.hw_type == "N1905") || (clsUUT.hw_type == "N2004" || clsUUT.hw_type == "CASPIAN")) || clsUUT.hw_type == "ARAL")
        {
          if (int16_3 % 2 != 0)
          {
            if (sfisType == 90)
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by 2 {0}", (object) clsUUT.scanMAC[0]), true);
            else
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by 2 {0}", (object) clsUUT.scanMAC[0]), false);
            return (string[]) null;
          }
        }
        else if (clsUUT.hw_type == "M225C" || clsUUT.hw_type == "P210C" || (clsUUT.hw_type == "M210C" || clsUUT.hw_type == "M225CD") || clsUUT.hw_type == "M225PD" || clsUUT.hw_type == "BUBBLES")
        {
          if (int16_3 % 4 != 0)
          {
            if (sfisType == 90)
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by 4 {0}", (object) clsUUT.scanMAC[0]), true);
            else
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by 4 {0}", (object) clsUUT.scanMAC[0]), false);
            return (string[]) null;
          }
        }
        else if (clsUUT.hw_type == "M150PM")
        {
          if (int16_3 % 8 != 0)
          {
            if (sfisType == 90)
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by 8 {0}", (object) clsUUT.scanMAC[0]), true);
            else
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by 8 {0}", (object) clsUUT.scanMAC[0]), false);
            return (string[]) null;
          }
        }
        else if (clsUUT.hw_type == "P225PO" || clsUUT.hw_type == "P225P" || (clsUUT.hw_type == "P150P" || clsUUT.hw_type == "M225P") || (clsUUT.hw_type == "M125P" || clsUUT.hw_type == "M210P" || (clsUUT.hw_type == "P210P" || clsUUT.hw_type == "M150P")) || (clsUUT.hw_type == "M210TP" || clsUUT.hw_type == "M225PQ" || (clsUUT.hw_type == "BANDICOOT" || clsUUT.hw_type == "BOAR") || (clsUUT.hw_type == "BOBOLINK" || clsUUT.hw_type == "BOBCAT" || (clsUUT.hw_type == "P225E" || clsUUT.hw_type == "P225EPD"))) || (clsUUT.hw_type == "P210EPD" || clsUUT.hw_type == "P210TEPD" || (clsUUT.hw_type == "P210TEP" || clsUUT.hw_type == "P225EPDLP") || (clsUUT.hw_type == "P210EPDLP" || clsUUT.hw_type == "P210TEPDLP" || (clsUUT.hw_type == "HERTZ" || clsUUT.hw_type == "A4160L")) || (clsUUT.hw_type == "M4161" || clsUUT.hw_type == "A3120L" || clsUUT.hw_type == "P1100P")) || clsUUT.hw_type == "M1100PM")
        {
          if (int16_3 % 16 != 0)
          {
            if (sfisType == 90)
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by 16 {0}", (object) clsUUT.scanMAC[0]), true);
            else
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by 16 {0}", (object) clsUUT.scanMAC[0]), false);
            return (string[]) null;
          }
        }
        else if (clsUUT.hw_type == "GENERIC")
        {
          if (int16_3 % stride != 0)
          {
            if (sfisType == 90)
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by stride {0} {1}", (object) stride, (object) clsUUT.scanMAC[0]), true);
            else
              clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by stride {0} {1}", (object) stride, (object) clsUUT.scanMAC[0]), false);
            return (string[]) null;
          }
        }
        else if (int16_3 % clsUUT.mac_count != 0)
        {
          if (sfisType == 90)
            clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by {0} {1}", (object) clsUUT.mac_count, (object) clsUUT.scanMAC[0]), true);
          else
            clsUUT.showFailMsgDlg(string.Format("1st MAC not divisible by {0} {1}", (object) clsUUT.mac_count, (object) clsUUT.scanMAC[0]), false);
          return (string[]) null;
        }
        clsUUT.consecMAC = clsUUT.maclist(clsUUT.scanMAC[0], clsUUT.mac_count, clsUUT.mac_increment);
        if (clsUUT.hw_type == "BANDICOOT" || clsUUT.hw_type == "BOAR" || clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BOBOLINK")
        {
          ulong uint64 = Convert.ToUInt64(string.Format("{0:X}", (object) clsUUT.scanMAC[0].Substring(10, 2)), 16);
          clsUUT.consecMAC[1] = clsUUT.scanMAC[0].Substring(0, 10) + string.Format("{0:X2}", (object) (ulong) ((long) uint64 + 1L));
          clsUUT.consecMAC[2] = clsUUT.scanMAC[0].Substring(0, 10) + string.Format("{0:X2}", (object) (ulong) ((long) uint64 + 8L));
          clsUUT.consecMAC[3] = clsUUT.scanMAC[0].Substring(0, 10) + string.Format("{0:X2}", (object) (ulong) ((long) uint64 + 9L));
        }
        else if (clsUUT.hw_type == "P225PO")
        {
          ulong uint64 = Convert.ToUInt64(string.Format("{0:X}", (object) clsUUT.scanMAC[0].Substring(10, 2)), 16);
          clsUUT.consecMAC[1] = clsUUT.scanMAC[0].Substring(0, 10) + string.Format("{0:X2}", (object) (ulong) ((long) uint64 + 8L));
        }
        else
        {
          for (int index = 0; index < clsUUT.scanMAC.Length; ++index)
          {
            if (clsUUT.consecMAC[index] != clsUUT.scanMAC[index])
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg(string.Format("Found NON-CONSECUTIVE MAC: \n{0} (expecting {1})", (object) clsUUT.scanMAC[index], (object) clsUUT.consecMAC[index]), true);
              else
                clsUUT.showFailMsgDlg(string.Format("Found NON-CONSECUTIVE MAC: \n{0} (expecting {1})", (object) clsUUT.scanMAC[index], (object) clsUUT.consecMAC[index]), false);
              return (string[]) null;
            }
          }
        }
        return clsUUT.consecMAC;
      }
      if (sfisType == 90)
        clsUUT.showFailMsgDlg("Invalid MAC_COUNT 0; check config file.", true);
      else
        clsUUT.showFailMsgDlg("Invalid MAC_COUNT 0; check config file.", false);
      return (string[]) null;
    }

    public static bool verifyLabel(string strLabel, int sfisType, string dutType)
    {
      if (sfisType == 90 && strLabel.Length >= 7)
      {
        if (strLabel.Substring(0, 1).Contains("C"))
        {
          clsUUT.esrLabel = strLabel.Substring(0, 8);
          strLabel = strLabel.Substring(8, strLabel.Length - 8);
        }
        else if (strLabel.Substring(0, 6).Contains("000AF7") || strLabel.Substring(0, 6).Contains("001018"))
        {
          clsUUT.esrLabel = strLabel.Substring(4, 8);
          strLabel = strLabel.Substring(12, strLabel.Length - 12);
        }
        else
        {
          clsUUT.esrLabel = strLabel.Substring(0, 7);
          strLabel = strLabel.Substring(7, strLabel.Length - 7);
        }
      }
      if (strLabel.Length == 24)
      {
        switch (strLabel.Substring(0, 5))
        {
          case "PEPDB":
            clsUUT.hw_type = "BOERNE";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.bHPE = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "PBYWT":
            clsUUT.hw_type = "PUTNAM";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.bHPE = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "PWVQV":
            clsUUT.hw_type = "BUBBLES";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.bHPE = true;
            clsUUT.bOCP30 = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "PBKRQ":
            clsUUT.hw_type = "WOODVILLE";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.bHPE = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "PFDMD":
            clsUUT.hw_type = "BOAR";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "PFDMB":
            clsUUT.hw_type = "BANDICOOT";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "PFCJK":
            clsUUT.hw_type = "BOBCAT";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "PFDME":
            clsUUT.hw_type = "BOBOLINK";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          default:
            if (strLabel.Contains("CT"))
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid CT/SN LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid CT/SN LABEL", false);
            }
            else if (sfisType == 90)
              clsUUT.showFailMsgDlg("Invalid LABEL", true);
            else
              clsUUT.showFailMsgDlg("Invalid LABEL", false);
            return false;
        }
      }
      else if (strLabel.Length == 18)
      {
        switch (strLabel.Substring(0, 6))
        {
          case "433551":
            clsUUT.hw_type = "P225PO";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          default:
            if (sfisType == 90)
              clsUUT.showFailMsgDlg("Invalid LABEL", true);
            else
              clsUUT.showFailMsgDlg("Invalid LABEL", false);
            return false;
        }
      }
      else if (strLabel.Length == 23 && strLabel.Substring(0, 2).Contains("8S"))
      {
        switch (strLabel.Substring(2, 10))
        {
          case "SN37A28236":
            clsUUT.hw_type = "CASPIAN";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN37A28240":
            clsUUT.hw_type = "ARAL";
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN30L27797":
            clsUUT.hw_type = "A4160L";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN30L27798":
            clsUUT.hw_type = "M4161";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN30L27799":
            clsUUT.hw_type = "A3120L";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN30L21972":
            clsUUT.hw_type = "SHARKNADO4";
            clsUUT.bFRU = false;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN30L21970":
            clsUUT.hw_type = "SHARKNADO2";
            clsUUT.bFRU = false;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          default:
            if (strLabel.Contains("8S"))
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid 8S LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid 8S LABEL", false);
            }
            else if (sfisType == 90)
              clsUUT.showFailMsgDlg("Invalid LABEL", true);
            else
              clsUUT.showFailMsgDlg("Invalid LABEL", false);
            return false;
        }
      }
      else if (strLabel.Length == 23)
      {
        string str1 = strLabel.Substring(3).Substring(0, 5);
        string str2 = strLabel.Substring(20, 3);
        switch (str1)
        {
          case "MW9RC":
            clsUUT.hw_type = "GAMMA";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "G9XC9":
            clsUUT.hw_type = "N2004";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.bOCP30 = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "FM487":
            clsUUT.hw_type = "OBRIEN";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "YGCV4":
          case "HY7RM":
            clsUUT.hw_type = "CARDASSIA";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            clsUUT.cm_PartNumber = str1;
            break;
          case "557M9":
          case "0FCGN":
            clsUUT.hw_type = "BASHIR";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            clsUUT.cm_PartNumber = str1;
            break;
          case "22TDT":
            clsUUT.hw_type = "CORAK";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "8CM81":
            clsUUT.hw_type = "M225CD";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "930PP":
            clsUUT.hw_type = "M225PD";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "7M8VP":
            clsUUT.hw_type = "P225ED";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "4GMN7":
            clsUUT.hw_type = "P225EDLP";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "NWMNX":
            clsUUT.hw_type = "PAULI";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "9XY73":
            clsUUT.hw_type = "HERTZ";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "1224N":
            clsUUT.hw_type = "GAUSS";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "CX94X":
            clsUUT.hw_type = "P225EPD";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "24GFD":
            clsUUT.hw_type = "P225EPDLP";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "3KHCF":
            clsUUT.hw_type = "P210ED";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "61J1X":
            clsUUT.hw_type = "P210EDLP";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "GMW01":
            clsUUT.hw_type = "P210EPD";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "YR0VV":
            clsUUT.hw_type = "P210EPDLP";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "81V1W":
            clsUUT.hw_type = "P210TED";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "9P1N8":
            clsUUT.hw_type = "P210TEDLP";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "3TM39":
            clsUUT.hw_type = "P210TEPD";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          case "NC5VD":
            clsUUT.hw_type = "P210TEPDLP";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            if (str2 != clsUUT.dell_PN_rev)
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
              return false;
            }
            break;
          default:
            if (strLabel.Contains("CN0"))
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid PPID LABEL", false);
            }
            else if (sfisType == 90)
              clsUUT.showFailMsgDlg("Invalid LABEL", true);
            else
              clsUUT.showFailMsgDlg("Invalid LABEL", false);
            return false;
        }
      }
      else if (strLabel.Length == 22)
      {
        int startIndex = strLabel.Substring(0, 3) == "11S" ? 3 : 0;
        switch (strLabel.Substring(startIndex).Substring(0, 7))
        {
          case "00E2872":
            clsUUT.hw_type = "AUSTIN";
            clsUUT.bFRU = false;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "49Y7901":
            clsUUT.hw_type = "MUSTANG";
            clsUUT.bFRU = true;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "90Y9372":
            clsUUT.hw_type = "DUALRUNNER";
            clsUUT.bFRU = false;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          default:
            if (strLabel.Contains("11S"))
            {
              if (sfisType == 90)
                clsUUT.showFailMsgDlg("Invalid 11S LABEL", true);
              else
                clsUUT.showFailMsgDlg("Invalid 11S LABEL", false);
            }
            else if (sfisType == 90)
              clsUUT.showFailMsgDlg("Invalid LABEL", true);
            else
              clsUUT.showFailMsgDlg("Invalid LABEL", false);
            return false;
        }
      }
      else if (strLabel.Length == 15)
      {
        switch (strLabel.Substring(0, 4))
        {
          case "1904":
            clsUUT.hw_type = "MERCURY";
            clsUUT.bFRU = false;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "2003":
            clsUUT.hw_type = "PLUTO";
            clsUUT.bFRU = false;
            clsUUT.bB57diag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          default:
            if (sfisType == 90)
              clsUUT.showFailMsgDlg("Invalid LABEL", true);
            else
              clsUUT.showFailMsgDlg("Invalid LABEL", false);
            return false;
        }
      }
      else if (strLabel.Length == 16)
      {
        switch (strLabel.Substring(0, 5))
        {
          case "N1905":
            clsUUT.hw_type = "N1905";
            clsUUT.bFRU = false;
            clsUUT.bB57diag = true;
            clsUUT.bOCP30 = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "G9XC9":
            clsUUT.hw_type = "N2004";
            clsUUT.bFRU = false;
            clsUUT.bB57diag = true;
            clsUUT.bOCP30 = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A3040":
            clsUUT.hw_type = "P150C";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A3020":
            clsUUT.hw_type = "P125C";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A3041":
            clsUUT.hw_type = "P225C";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A3042":
            clsUUT.hw_type = "P225CA";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A3043":
            clsUUT.hw_type = "P225CO";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A4142":
            clsUUT.hw_type = "P225P";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A4140":
            clsUUT.hw_type = "P150P";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M4142":
            clsUUT.hw_type = "M225P";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M4122":
            clsUUT.hw_type = "M125P";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M4123":
            clsUUT.hw_type = "M210P";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A4120":
            clsUUT.hw_type = "P210P";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A3021":
            clsUUT.hw_type = "P210C";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A4040":
            clsUUT.hw_type = "P225E";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M3041":
            clsUUT.hw_type = "M150C";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M4520":
            clsUUT.hw_type = "M150PM";
            clsUUT.bFRU = true;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M4540":
            clsUUT.hw_type = "M1100PM";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M4143":
            clsUUT.hw_type = "M150P";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M4163":
            clsUUT.hw_type = "M210TP";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M4144":
            clsUUT.hw_type = "M225PQ";
            clsUUT.bFRU = false;
            clsUUT.bNPAR = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A8020":
            clsUUT.hw_type = "PS150";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M8020":
            clsUUT.hw_type = "MS150";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A4540":
            clsUUT.hw_type = "P1100P";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M3040":
            clsUUT.hw_type = "M225C";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M3022":
            clsUUT.hw_type = "M210C";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A4060":
            clsUUT.hw_type = "P210TE";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "A4160":
            clsUUT.hw_type = "P210TEP";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.bNPAR = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M3020":
            clsUUT.hw_type = "M125C";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M3120":
            clsUUT.hw_type = "M125CP";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M3021":
            clsUUT.hw_type = "M125CLP";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M3023":
            clsUUT.hw_type = "M125CHF";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "M3024":
            clsUUT.hw_type = "M125CLPHF";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN30L27797":
            clsUUT.hw_type = "A4160L";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN30L27798":
            clsUUT.hw_type = "M4161";
            clsUUT.bFRU = true;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          case "SN30L27799":
            clsUUT.hw_type = "A3120L";
            clsUUT.bFRU = false;
            clsUUT.bCdiag = true;
            clsUUT.readIni(clsUUT.hw_type);
            break;
          default:
            if (sfisType == 90)
              clsUUT.showFailMsgDlg("Invalid LABEL", true);
            else
              clsUUT.showFailMsgDlg("Invalid LABEL", false);
            return false;
        }
      }
      else
      {
        if (sfisType == 90 && strLabel.Length == 0)
        {
          clsUUT.hw_type = "GENERIC";
          clsUUT.bFRU = false;
          clsUUT.bCdiag = true;
          clsUUT.readIni(clsUUT.hw_type);
          return true;
        }
        if (sfisType == 90)
          clsUUT.showFailMsgDlg("Invalid LABEL", true);
        else
          clsUUT.showFailMsgDlg("Invalid LABEL", false);
        return false;
      }
      clsUUT.scanLabel = strLabel;
      return true;
    }

    private static void showFailMsgDlg(string message, bool bShowDlg)
    {
      if (!bShowDlg)
        return;
      int num = (int) new frmFail() { Message = message }.ShowDialog();
    }

    private static bool IsHex(string strToCheck)
    {
      return !new Regex("[^A-F0-9]").IsMatch(strToCheck);
    }

    private static string[] maclist(string mac, int count, int increment)
    {
      string[] strArray = new string[count];
      ulong uint64 = Convert.ToUInt64(string.Format("{0:X}", (object) mac.Replace(":", "").Replace("-", "").Substring(0)), 16);
      for (int index = 0; index < count; ++index)
      {
        strArray[index] = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}", (object) (ulong) ((long) (uint64 >> 40) & (long) byte.MaxValue), (object) (ulong) ((long) (uint64 >> 32) & (long) byte.MaxValue), (object) (ulong) ((long) (uint64 >> 24) & (long) byte.MaxValue), (object) (ulong) ((long) (uint64 >> 16) & (long) byte.MaxValue), (object) (ulong) ((long) (uint64 >> 8) & (long) byte.MaxValue), (object) (ulong) ((long) uint64 & (long) byte.MaxValue));
        uint64 += (ulong) increment;
      }
      return strArray;
    }
  }
}
