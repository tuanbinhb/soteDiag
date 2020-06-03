// Decompiled with JetBrains decompiler
// Type: soteDiag.soteDiag
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using Be.Windows.Forms;
using Dln;
using Dln.Gpio;
using soteDiag.Default;
using soteLib;
using soteLib.soteSFIS2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Util;

namespace soteDiag
{
  public class soteDiag : Form
  {
    public static string cmPN = (string) null;
    public static string label_prefix = (string) null;
    public static int mac_addr = 0;
    public static string bin_template = (string) null;
    public static string text_template = (string) null;
    public static int mac_count = 0;
    public static int mac_increment = 0;
    public static int sn_addr = 0;
    public static int sn_addr1 = 0;
    public static int sn_addr2 = 0;
    public static int sn_len = 0;
    public static int mac_addr1 = 0;
    public static int mac_addr2 = 0;
    public static int mac_addr3 = 0;
    public static int mac_addr4 = 0;
    public static int mac_addr5 = 0;
    public static int mac_addr6 = 0;
    public static int pn_addr = 0;
    public static int pn_len = 0;
    public static int hi_sn_addr = 0;
    public static int hi_sn_len = 0;
    public static string appName = Application.ProductName;
    public static string appVersion = Application.ProductVersion;
    public static string appPath = Directory.GetCurrentDirectory();
    public static string appConfig = soteDiag.soteDiag.appPath + "\\" + soteDiag.soteDiag.appName + ".ini";
    public static string appMonitor = soteDiag.soteDiag.appPath + "\\" + soteDiag.soteDiag.appName + "Monitor.ini";
    public static string appGoldenSample = soteDiag.soteDiag.appPath + "\\" + soteDiag.soteDiag.appName + "GoldenSample.ini";
    public static string appFwCheck = soteDiag.soteDiag.appPath + "\\" + soteDiag.soteDiag.appName + "FwCheck.ini";
    public static string appRMAConfig = soteDiag.soteDiag.appPath + "\\" + soteDiag.soteDiag.appName + "RMA.ini";
    public static string appTMPCheckConfig = soteDiag.soteDiag.appPath + "\\" + soteDiag.soteDiag.appName + "TMPCheck.ini";
    public static string appESR = (string) null;
    public static string appLog = soteDiag.soteDiag.appPath + "\\" + soteDiag.soteDiag.appName + ".log";
    public static string appData = soteDiag.soteDiag.appPath + "\\";
    public static string sfisLog = soteDiag.soteDiag.appPath + "\\sfis.log";
    public static string i2cDevice = (string) null;
    public static string method = (string) null;
    public static string i2cAddress = (string) null;
    public static string i2cAddr = (string) null;
    public static int pageSize = 0;
    public static int deviceMemorySize = 0;
    public static string padText = (string) null;
    private static readonly byte[] ReflectTable = new byte[256]
    {
      (byte) 0,
      (byte) 128,
      (byte) 64,
      (byte) 192,
      (byte) 32,
      (byte) 160,
      (byte) 96,
      (byte) 224,
      (byte) 16,
      (byte) 144,
      (byte) 80,
      (byte) 208,
      (byte) 48,
      (byte) 176,
      (byte) 112,
      (byte) 240,
      (byte) 8,
      (byte) 136,
      (byte) 72,
      (byte) 200,
      (byte) 40,
      (byte) 168,
      (byte) 104,
      (byte) 232,
      (byte) 24,
      (byte) 152,
      (byte) 88,
      (byte) 216,
      (byte) 56,
      (byte) 184,
      (byte) 120,
      (byte) 248,
      (byte) 4,
      (byte) 132,
      (byte) 68,
      (byte) 196,
      (byte) 36,
      (byte) 164,
      (byte) 100,
      (byte) 228,
      (byte) 20,
      (byte) 148,
      (byte) 84,
      (byte) 212,
      (byte) 52,
      (byte) 180,
      (byte) 116,
      (byte) 244,
      (byte) 12,
      (byte) 140,
      (byte) 76,
      (byte) 204,
      (byte) 44,
      (byte) 172,
      (byte) 108,
      (byte) 236,
      (byte) 28,
      (byte) 156,
      (byte) 92,
      (byte) 220,
      (byte) 60,
      (byte) 188,
      (byte) 124,
      (byte) 252,
      (byte) 2,
      (byte) 130,
      (byte) 66,
      (byte) 194,
      (byte) 34,
      (byte) 162,
      (byte) 98,
      (byte) 226,
      (byte) 18,
      (byte) 146,
      (byte) 82,
      (byte) 210,
      (byte) 50,
      (byte) 178,
      (byte) 114,
      (byte) 242,
      (byte) 10,
      (byte) 138,
      (byte) 74,
      (byte) 202,
      (byte) 42,
      (byte) 170,
      (byte) 106,
      (byte) 234,
      (byte) 26,
      (byte) 154,
      (byte) 90,
      (byte) 218,
      (byte) 58,
      (byte) 186,
      (byte) 122,
      (byte) 250,
      (byte) 6,
      (byte) 134,
      (byte) 70,
      (byte) 198,
      (byte) 38,
      (byte) 166,
      (byte) 102,
      (byte) 230,
      (byte) 22,
      (byte) 150,
      (byte) 86,
      (byte) 214,
      (byte) 54,
      (byte) 182,
      (byte) 118,
      (byte) 246,
      (byte) 14,
      (byte) 142,
      (byte) 78,
      (byte) 206,
      (byte) 46,
      (byte) 174,
      (byte) 110,
      (byte) 238,
      (byte) 30,
      (byte) 158,
      (byte) 94,
      (byte) 222,
      (byte) 62,
      (byte) 190,
      (byte) 126,
      (byte) 254,
      (byte) 1,
      (byte) 129,
      (byte) 65,
      (byte) 193,
      (byte) 33,
      (byte) 161,
      (byte) 97,
      (byte) 225,
      (byte) 17,
      (byte) 145,
      (byte) 81,
      (byte) 209,
      (byte) 49,
      (byte) 177,
      (byte) 113,
      (byte) 241,
      (byte) 9,
      (byte) 137,
      (byte) 73,
      (byte) 201,
      (byte) 41,
      (byte) 169,
      (byte) 105,
      (byte) 233,
      (byte) 25,
      (byte) 153,
      (byte) 89,
      (byte) 217,
      (byte) 57,
      (byte) 185,
      (byte) 121,
      (byte) 249,
      (byte) 5,
      (byte) 133,
      (byte) 69,
      (byte) 197,
      (byte) 37,
      (byte) 165,
      (byte) 101,
      (byte) 229,
      (byte) 21,
      (byte) 149,
      (byte) 85,
      (byte) 213,
      (byte) 53,
      (byte) 181,
      (byte) 117,
      (byte) 245,
      (byte) 13,
      (byte) 141,
      (byte) 77,
      (byte) 205,
      (byte) 45,
      (byte) 173,
      (byte) 109,
      (byte) 237,
      (byte) 29,
      (byte) 157,
      (byte) 93,
      (byte) 221,
      (byte) 61,
      (byte) 189,
      (byte) 125,
      (byte) 253,
      (byte) 3,
      (byte) 131,
      (byte) 67,
      (byte) 195,
      (byte) 35,
      (byte) 163,
      (byte) 99,
      (byte) 227,
      (byte) 19,
      (byte) 147,
      (byte) 83,
      (byte) 211,
      (byte) 51,
      (byte) 179,
      (byte) 115,
      (byte) 243,
      (byte) 11,
      (byte) 139,
      (byte) 75,
      (byte) 203,
      (byte) 43,
      (byte) 171,
      (byte) 107,
      (byte) 235,
      (byte) 27,
      (byte) 155,
      (byte) 91,
      (byte) 219,
      (byte) 59,
      (byte) 187,
      (byte) 123,
      (byte) 251,
      (byte) 7,
      (byte) 135,
      (byte) 71,
      (byte) 199,
      (byte) 39,
      (byte) 167,
      (byte) 103,
      (byte) 231,
      (byte) 23,
      (byte) 151,
      (byte) 87,
      (byte) 215,
      (byte) 55,
      (byte) 183,
      (byte) 119,
      (byte) 247,
      (byte) 15,
      (byte) 143,
      (byte) 79,
      (byte) 207,
      (byte) 47,
      (byte) 175,
      (byte) 111,
      (byte) 239,
      (byte) 31,
      (byte) 159,
      (byte) 95,
      (byte) 223,
      (byte) 63,
      (byte) 191,
      (byte) 127,
      byte.MaxValue
    };
    private static readonly byte[] PolyTable = new byte[1024]
    {
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 4,
      (byte) 193,
      (byte) 29,
      (byte) 183,
      (byte) 9,
      (byte) 130,
      (byte) 59,
      (byte) 110,
      (byte) 13,
      (byte) 67,
      (byte) 38,
      (byte) 217,
      (byte) 19,
      (byte) 4,
      (byte) 118,
      (byte) 220,
      (byte) 23,
      (byte) 197,
      (byte) 107,
      (byte) 107,
      (byte) 26,
      (byte) 134,
      (byte) 77,
      (byte) 178,
      (byte) 30,
      (byte) 71,
      (byte) 80,
      (byte) 5,
      (byte) 38,
      (byte) 8,
      (byte) 237,
      (byte) 184,
      (byte) 34,
      (byte) 201,
      (byte) 240,
      (byte) 15,
      (byte) 47,
      (byte) 138,
      (byte) 214,
      (byte) 214,
      (byte) 43,
      (byte) 75,
      (byte) 203,
      (byte) 97,
      (byte) 53,
      (byte) 12,
      (byte) 155,
      (byte) 100,
      (byte) 49,
      (byte) 205,
      (byte) 134,
      (byte) 211,
      (byte) 60,
      (byte) 142,
      (byte) 160,
      (byte) 10,
      (byte) 56,
      (byte) 79,
      (byte) 189,
      (byte) 189,
      (byte) 76,
      (byte) 17,
      (byte) 219,
      (byte) 112,
      (byte) 72,
      (byte) 208,
      (byte) 198,
      (byte) 199,
      (byte) 69,
      (byte) 147,
      (byte) 224,
      (byte) 30,
      (byte) 65,
      (byte) 82,
      (byte) 253,
      (byte) 169,
      (byte) 95,
      (byte) 21,
      (byte) 173,
      (byte) 172,
      (byte) 91,
      (byte) 212,
      (byte) 176,
      (byte) 27,
      (byte) 86,
      (byte) 151,
      (byte) 150,
      (byte) 194,
      (byte) 82,
      (byte) 86,
      (byte) 139,
      (byte) 117,
      (byte) 106,
      (byte) 25,
      (byte) 54,
      (byte) 200,
      (byte) 110,
      (byte) 216,
      (byte) 43,
      (byte) 127,
      (byte) 99,
      (byte) 155,
      (byte) 13,
      (byte) 166,
      (byte) 103,
      (byte) 90,
      (byte) 16,
      (byte) 17,
      (byte) 121,
      (byte) 29,
      (byte) 64,
      (byte) 20,
      (byte) 125,
      (byte) 220,
      (byte) 93,
      (byte) 163,
      (byte) 112,
      (byte) 159,
      (byte) 123,
      (byte) 122,
      (byte) 116,
      (byte) 94,
      (byte) 102,
      (byte) 205,
      (byte) 152,
      (byte) 35,
      (byte) 182,
      (byte) 224,
      (byte) 156,
      (byte) 226,
      (byte) 171,
      (byte) 87,
      (byte) 145,
      (byte) 161,
      (byte) 141,
      (byte) 142,
      (byte) 149,
      (byte) 96,
      (byte) 144,
      (byte) 57,
      (byte) 139,
      (byte) 39,
      (byte) 192,
      (byte) 60,
      (byte) 143,
      (byte) 230,
      (byte) 221,
      (byte) 139,
      (byte) 130,
      (byte) 165,
      (byte) 251,
      (byte) 82,
      (byte) 134,
      (byte) 100,
      (byte) 230,
      (byte) 229,
      (byte) 190,
      (byte) 43,
      (byte) 91,
      (byte) 88,
      (byte) 186,
      (byte) 234,
      (byte) 70,
      (byte) 239,
      (byte) 183,
      (byte) 169,
      (byte) 96,
      (byte) 54,
      (byte) 179,
      (byte) 104,
      (byte) 125,
      (byte) 129,
      (byte) 173,
      (byte) 47,
      (byte) 45,
      (byte) 132,
      (byte) 169,
      (byte) 238,
      (byte) 48,
      (byte) 51,
      (byte) 164,
      (byte) 173,
      (byte) 22,
      (byte) 234,
      (byte) 160,
      (byte) 108,
      (byte) 11,
      (byte) 93,
      (byte) 212,
      (byte) 50,
      (byte) 109,
      (byte) 144,
      (byte) 208,
      (byte) 243,
      (byte) 112,
      (byte) 39,
      (byte) 221,
      (byte) 176,
      (byte) 86,
      (byte) 254,
      (byte) 217,
      (byte) 113,
      (byte) 75,
      (byte) 73,
      (byte) 199,
      (byte) 54,
      (byte) 27,
      (byte) 76,
      (byte) 195,
      (byte) 247,
      (byte) 6,
      (byte) 251,
      (byte) 206,
      (byte) 180,
      (byte) 32,
      (byte) 34,
      (byte) 202,
      (byte) 117,
      (byte) 61,
      (byte) 149,
      (byte) 242,
      (byte) 58,
      (byte) 128,
      (byte) 40,
      (byte) 246,
      (byte) 251,
      (byte) 157,
      (byte) 159,
      (byte) 251,
      (byte) 184,
      (byte) 187,
      (byte) 70,
      byte.MaxValue,
      (byte) 121,
      (byte) 166,
      (byte) 241,
      (byte) 225,
      (byte) 62,
      (byte) 246,
      (byte) 244,
      (byte) 229,
      byte.MaxValue,
      (byte) 235,
      (byte) 67,
      (byte) 232,
      (byte) 188,
      (byte) 205,
      (byte) 154,
      (byte) 236,
      (byte) 125,
      (byte) 208,
      (byte) 45,
      (byte) 52,
      (byte) 134,
      (byte) 112,
      (byte) 119,
      (byte) 48,
      (byte) 71,
      (byte) 109,
      (byte) 192,
      (byte) 61,
      (byte) 4,
      (byte) 75,
      (byte) 25,
      (byte) 57,
      (byte) 197,
      (byte) 86,
      (byte) 174,
      (byte) 39,
      (byte) 130,
      (byte) 6,
      (byte) 171,
      (byte) 35,
      (byte) 67,
      (byte) 27,
      (byte) 28,
      (byte) 46,
      (byte) 0,
      (byte) 61,
      (byte) 197,
      (byte) 42,
      (byte) 193,
      (byte) 32,
      (byte) 114,
      (byte) 18,
      (byte) 142,
      (byte) 157,
      (byte) 207,
      (byte) 22,
      (byte) 79,
      (byte) 128,
      (byte) 120,
      (byte) 27,
      (byte) 12,
      (byte) 166,
      (byte) 161,
      (byte) 31,
      (byte) 205,
      (byte) 187,
      (byte) 22,
      (byte) 1,
      (byte) 138,
      (byte) 235,
      (byte) 19,
      (byte) 5,
      (byte) 75,
      (byte) 246,
      (byte) 164,
      (byte) 8,
      (byte) 8,
      (byte) 208,
      (byte) 125,
      (byte) 12,
      (byte) 201,
      (byte) 205,
      (byte) 202,
      (byte) 120,
      (byte) 151,
      (byte) 171,
      (byte) 7,
      (byte) 124,
      (byte) 86,
      (byte) 182,
      (byte) 176,
      (byte) 113,
      (byte) 21,
      (byte) 144,
      (byte) 105,
      (byte) 117,
      (byte) 212,
      (byte) 141,
      (byte) 222,
      (byte) 107,
      (byte) 147,
      (byte) 221,
      (byte) 219,
      (byte) 111,
      (byte) 82,
      (byte) 192,
      (byte) 108,
      (byte) 98,
      (byte) 17,
      (byte) 230,
      (byte) 181,
      (byte) 102,
      (byte) 208,
      (byte) 251,
      (byte) 2,
      (byte) 94,
      (byte) 159,
      (byte) 70,
      (byte) 191,
      (byte) 90,
      (byte) 94,
      (byte) 91,
      (byte) 8,
      (byte) 87,
      (byte) 29,
      (byte) 125,
      (byte) 209,
      (byte) 83,
      (byte) 220,
      (byte) 96,
      (byte) 102,
      (byte) 77,
      (byte) 155,
      (byte) 48,
      (byte) 99,
      (byte) 73,
      (byte) 90,
      (byte) 45,
      (byte) 212,
      (byte) 68,
      (byte) 25,
      (byte) 11,
      (byte) 13,
      (byte) 64,
      (byte) 216,
      (byte) 22,
      (byte) 186,
      (byte) 172,
      (byte) 165,
      (byte) 198,
      (byte) 151,
      (byte) 168,
      (byte) 100,
      (byte) 219,
      (byte) 32,
      (byte) 165,
      (byte) 39,
      (byte) 253,
      (byte) 249,
      (byte) 161,
      (byte) 230,
      (byte) 224,
      (byte) 78,
      (byte) 191,
      (byte) 161,
      (byte) 176,
      (byte) 75,
      (byte) 187,
      (byte) 96,
      (byte) 173,
      (byte) 252,
      (byte) 182,
      (byte) 35,
      (byte) 139,
      (byte) 37,
      (byte) 178,
      (byte) 226,
      (byte) 150,
      (byte) 146,
      (byte) 138,
      (byte) 173,
      (byte) 43,
      (byte) 47,
      (byte) 142,
      (byte) 108,
      (byte) 54,
      (byte) 152,
      (byte) 131,
      (byte) 47,
      (byte) 16,
      (byte) 65,
      (byte) 135,
      (byte) 238,
      (byte) 13,
      (byte) 246,
      (byte) 153,
      (byte) 169,
      (byte) 93,
      (byte) 243,
      (byte) 157,
      (byte) 104,
      (byte) 64,
      (byte) 68,
      (byte) 144,
      (byte) 43,
      (byte) 102,
      (byte) 157,
      (byte) 148,
      (byte) 234,
      (byte) 123,
      (byte) 42,
      (byte) 224,
      (byte) 180,
      (byte) 29,
      (byte) 231,
      (byte) 228,
      (byte) 117,
      (byte) 0,
      (byte) 80,
      (byte) 233,
      (byte) 54,
      (byte) 38,
      (byte) 137,
      (byte) 237,
      (byte) 247,
      (byte) 59,
      (byte) 62,
      (byte) 243,
      (byte) 176,
      (byte) 107,
      (byte) 59,
      (byte) 247,
      (byte) 113,
      (byte) 118,
      (byte) 140,
      (byte) 250,
      (byte) 50,
      (byte) 80,
      (byte) 85,
      (byte) 254,
      (byte) 243,
      (byte) 77,
      (byte) 226,
      (byte) 198,
      (byte) 188,
      (byte) 240,
      (byte) 95,
      (byte) 194,
      (byte) 125,
      (byte) 237,
      (byte) 232,
      (byte) 207,
      (byte) 62,
      (byte) 203,
      (byte) 49,
      (byte) 203,
      byte.MaxValue,
      (byte) 214,
      (byte) 134,
      (byte) 213,
      (byte) 184,
      (byte) 134,
      (byte) 131,
      (byte) 209,
      (byte) 121,
      (byte) 155,
      (byte) 52,
      (byte) 220,
      (byte) 58,
      (byte) 189,
      (byte) 237,
      (byte) 216,
      (byte) 251,
      (byte) 160,
      (byte) 90,
      (byte) 105,
      (byte) 12,
      (byte) 224,
      (byte) 238,
      (byte) 109,
      (byte) 205,
      (byte) 253,
      (byte) 89,
      (byte) 96,
      (byte) 142,
      (byte) 219,
      (byte) 128,
      (byte) 100,
      (byte) 79,
      (byte) 198,
      (byte) 55,
      (byte) 122,
      (byte) 8,
      (byte) 150,
      (byte) 50,
      (byte) 126,
      (byte) 201,
      (byte) 139,
      (byte) 133,
      (byte) 115,
      (byte) 138,
      (byte) 173,
      (byte) 92,
      (byte) 119,
      (byte) 75,
      (byte) 176,
      (byte) 235,
      (byte) 79,
      (byte) 4,
      (byte) 13,
      (byte) 86,
      (byte) 75,
      (byte) 197,
      (byte) 16,
      (byte) 225,
      (byte) 70,
      (byte) 134,
      (byte) 54,
      (byte) 56,
      (byte) 66,
      (byte) 71,
      (byte) 43,
      (byte) 143,
      (byte) 92,
      (byte) 0,
      (byte) 123,
      (byte) 138,
      (byte) 88,
      (byte) 193,
      (byte) 102,
      (byte) 61,
      (byte) 85,
      (byte) 130,
      (byte) 64,
      (byte) 228,
      (byte) 81,
      (byte) 67,
      (byte) 93,
      (byte) 83,
      (byte) 37,
      (byte) 29,
      (byte) 59,
      (byte) 158,
      (byte) 33,
      (byte) 220,
      (byte) 38,
      (byte) 41,
      (byte) 44,
      (byte) 159,
      (byte) 0,
      (byte) 240,
      (byte) 40,
      (byte) 94,
      (byte) 29,
      (byte) 71,
      (byte) 54,
      (byte) 25,
      (byte) 77,
      (byte) 66,
      (byte) 50,
      (byte) 216,
      (byte) 80,
      (byte) 245,
      (byte) 63,
      (byte) 155,
      (byte) 118,
      (byte) 44,
      (byte) 59,
      (byte) 90,
      (byte) 107,
      (byte) 155,
      (byte) 3,
      (byte) 21,
      (byte) 214,
      (byte) 38,
      (byte) 7,
      (byte) 212,
      (byte) 203,
      (byte) 145,
      (byte) 10,
      (byte) 151,
      (byte) 237,
      (byte) 72,
      (byte) 14,
      (byte) 86,
      (byte) 240,
      byte.MaxValue,
      (byte) 16,
      (byte) 17,
      (byte) 160,
      (byte) 250,
      (byte) 20,
      (byte) 208,
      (byte) 189,
      (byte) 77,
      (byte) 25,
      (byte) 147,
      (byte) 155,
      (byte) 148,
      (byte) 29,
      (byte) 82,
      (byte) 134,
      (byte) 35,
      (byte) 241,
      (byte) 47,
      (byte) 86,
      (byte) 14,
      (byte) 245,
      (byte) 238,
      (byte) 75,
      (byte) 185,
      (byte) 248,
      (byte) 173,
      (byte) 109,
      (byte) 96,
      (byte) 252,
      (byte) 108,
      (byte) 112,
      (byte) 215,
      (byte) 226,
      (byte) 43,
      (byte) 32,
      (byte) 210,
      (byte) 230,
      (byte) 234,
      (byte) 61,
      (byte) 101,
      (byte) 235,
      (byte) 169,
      (byte) 27,
      (byte) 188,
      (byte) 239,
      (byte) 104,
      (byte) 6,
      (byte) 11,
      (byte) 215,
      (byte) 39,
      (byte) 187,
      (byte) 182,
      (byte) 211,
      (byte) 230,
      (byte) 166,
      (byte) 1,
      (byte) 222,
      (byte) 165,
      (byte) 128,
      (byte) 216,
      (byte) 218,
      (byte) 100,
      (byte) 157,
      (byte) 111,
      (byte) 196,
      (byte) 35,
      (byte) 205,
      (byte) 106,
      (byte) 192,
      (byte) 226,
      (byte) 208,
      (byte) 221,
      (byte) 205,
      (byte) 161,
      (byte) 246,
      (byte) 4,
      (byte) 201,
      (byte) 96,
      (byte) 235,
      (byte) 179,
      (byte) 189,
      (byte) 62,
      (byte) 141,
      (byte) 126,
      (byte) 185,
      byte.MaxValue,
      (byte) 144,
      (byte) 201,
      (byte) 180,
      (byte) 188,
      (byte) 182,
      (byte) 16,
      (byte) 176,
      (byte) 125,
      (byte) 171,
      (byte) 167,
      (byte) 174,
      (byte) 58,
      (byte) 251,
      (byte) 162,
      (byte) 170,
      (byte) 251,
      (byte) 230,
      (byte) 21,
      (byte) 167,
      (byte) 184,
      (byte) 192,
      (byte) 204,
      (byte) 163,
      (byte) 121,
      (byte) 221,
      (byte) 123,
      (byte) 155,
      (byte) 54,
      (byte) 96,
      (byte) 198,
      (byte) 159,
      (byte) 247,
      (byte) 125,
      (byte) 113,
      (byte) 146,
      (byte) 180,
      (byte) 91,
      (byte) 168,
      (byte) 150,
      (byte) 117,
      (byte) 70,
      (byte) 31,
      (byte) 136,
      (byte) 50,
      (byte) 22,
      (byte) 26,
      (byte) 140,
      (byte) 243,
      (byte) 11,
      (byte) 173,
      (byte) 129,
      (byte) 176,
      (byte) 45,
      (byte) 116,
      (byte) 133,
      (byte) 113,
      (byte) 48,
      (byte) 195,
      (byte) 93,
      (byte) 138,
      (byte) 144,
      (byte) 153,
      (byte) 89,
      (byte) 75,
      (byte) 141,
      (byte) 46,
      (byte) 84,
      (byte) 8,
      (byte) 171,
      (byte) 247,
      (byte) 80,
      (byte) 201,
      (byte) 182,
      (byte) 64,
      (byte) 78,
      (byte) 142,
      (byte) 230,
      (byte) 69,
      (byte) 74,
      (byte) 79,
      (byte) 251,
      (byte) 242,
      (byte) 71,
      (byte) 12,
      (byte) 221,
      (byte) 43,
      (byte) 67,
      (byte) 205,
      (byte) 192,
      (byte) 156,
      (byte) 123,
      (byte) 130,
      (byte) 125,
      (byte) 33,
      (byte) 127,
      (byte) 67,
      (byte) 96,
      (byte) 150,
      (byte) 114,
      (byte) 0,
      (byte) 70,
      (byte) 79,
      (byte) 118,
      (byte) 193,
      (byte) 91,
      (byte) 248,
      (byte) 104,
      (byte) 134,
      (byte) 11,
      (byte) 253,
      (byte) 108,
      (byte) 71,
      (byte) 22,
      (byte) 74,
      (byte) 97,
      (byte) 4,
      (byte) 48,
      (byte) 147,
      (byte) 101,
      (byte) 197,
      (byte) 45,
      (byte) 36,
      (byte) 17,
      (byte) 155,
      (byte) 75,
      (byte) 233,
      (byte) 21,
      (byte) 90,
      (byte) 86,
      (byte) 94,
      (byte) 24,
      (byte) 25,
      (byte) 112,
      (byte) 135,
      (byte) 28,
      (byte) 216,
      (byte) 109,
      (byte) 48,
      (byte) 2,
      (byte) 159,
      (byte) 61,
      (byte) 53,
      (byte) 6,
      (byte) 94,
      (byte) 32,
      (byte) 130,
      (byte) 11,
      (byte) 29,
      (byte) 6,
      (byte) 91,
      (byte) 15,
      (byte) 220,
      (byte) 27,
      (byte) 236,
      (byte) 55,
      (byte) 147,
      (byte) 166,
      (byte) 81,
      (byte) 51,
      (byte) 82,
      (byte) 187,
      (byte) 230,
      (byte) 62,
      (byte) 17,
      (byte) 157,
      (byte) 63,
      (byte) 58,
      (byte) 208,
      (byte) 128,
      (byte) 136,
      (byte) 36,
      (byte) 151,
      (byte) 208,
      (byte) 141,
      (byte) 32,
      (byte) 86,
      (byte) 205,
      (byte) 58,
      (byte) 45,
      (byte) 21,
      (byte) 235,
      (byte) 227,
      (byte) 41,
      (byte) 212,
      (byte) 246,
      (byte) 84,
      (byte) 197,
      (byte) 169,
      (byte) 38,
      (byte) 121,
      (byte) 193,
      (byte) 104,
      (byte) 59,
      (byte) 206,
      (byte) 204,
      (byte) 43,
      (byte) 29,
      (byte) 23,
      (byte) 200,
      (byte) 234,
      (byte) 0,
      (byte) 160,
      (byte) 214,
      (byte) 173,
      (byte) 80,
      (byte) 165,
      (byte) 210,
      (byte) 108,
      (byte) 77,
      (byte) 18,
      (byte) 223,
      (byte) 47,
      (byte) 107,
      (byte) 203,
      (byte) 219,
      (byte) 238,
      (byte) 118,
      (byte) 124,
      (byte) 227,
      (byte) 161,
      (byte) 203,
      (byte) 193,
      (byte) 231,
      (byte) 96,
      (byte) 214,
      (byte) 118,
      (byte) 234,
      (byte) 35,
      (byte) 240,
      (byte) 175,
      (byte) 238,
      (byte) 226,
      (byte) 237,
      (byte) 24,
      (byte) 240,
      (byte) 165,
      (byte) 189,
      (byte) 29,
      (byte) 244,
      (byte) 100,
      (byte) 160,
      (byte) 170,
      (byte) 249,
      (byte) 39,
      (byte) 134,
      (byte) 115,
      (byte) 253,
      (byte) 230,
      (byte) 155,
      (byte) 196,
      (byte) 137,
      (byte) 184,
      (byte) 253,
      (byte) 9,
      (byte) 141,
      (byte) 121,
      (byte) 224,
      (byte) 190,
      (byte) 128,
      (byte) 58,
      (byte) 198,
      (byte) 103,
      (byte) 132,
      (byte) 251,
      (byte) 219,
      (byte) 208,
      (byte) 154,
      (byte) 188,
      (byte) 139,
      (byte) 213,
      (byte) 158,
      (byte) 125,
      (byte) 150,
      (byte) 98,
      (byte) 147,
      (byte) 62,
      (byte) 176,
      (byte) 187,
      (byte) 151,
      byte.MaxValue,
      (byte) 173,
      (byte) 12,
      (byte) 175,
      (byte) 176,
      (byte) 16,
      (byte) 177,
      (byte) 171,
      (byte) 113,
      (byte) 13,
      (byte) 6,
      (byte) 166,
      (byte) 50,
      (byte) 43,
      (byte) 223,
      (byte) 162,
      (byte) 243,
      (byte) 54,
      (byte) 104,
      (byte) 188,
      (byte) 180,
      (byte) 102,
      (byte) 109,
      (byte) 184,
      (byte) 117,
      (byte) 123,
      (byte) 218,
      (byte) 181,
      (byte) 54,
      (byte) 93,
      (byte) 3,
      (byte) 177,
      (byte) 247,
      (byte) 64,
      (byte) 180
    };
    private static readonly uint[] CRCTable = new uint[256]
    {
      0U,
      1996959894U,
      3993919788U,
      2567524794U,
      124634137U,
      1886057615U,
      3915621685U,
      2657392035U,
      249268274U,
      2044508324U,
      3772115230U,
      2547177864U,
      162941995U,
      2125561021U,
      3887607047U,
      2428444049U,
      498536548U,
      1789927666U,
      4089016648U,
      2227061214U,
      450548861U,
      1843258603U,
      4107580753U,
      2211677639U,
      325883990U,
      1684777152U,
      4251122042U,
      2321926636U,
      335633487U,
      1661365465U,
      4195302755U,
      2366115317U,
      997073096U,
      1281953886U,
      3579855332U,
      2724688242U,
      1006888145U,
      1258607687U,
      3524101629U,
      2768942443U,
      901097722U,
      1119000684U,
      3686517206U,
      2898065728U,
      853044451U,
      1172266101U,
      3705015759U,
      2882616665U,
      651767980U,
      1373503546U,
      3369554304U,
      3218104598U,
      565507253U,
      1454621731U,
      3485111705U,
      3099436303U,
      671266974U,
      1594198024U,
      3322730930U,
      2970347812U,
      795835527U,
      1483230225U,
      3244367275U,
      3060149565U,
      1994146192U,
      31158534U,
      2563907772U,
      4023717930U,
      1907459465U,
      112637215U,
      2680153253U,
      3904427059U,
      2013776290U,
      251722036U,
      2517215374U,
      3775830040U,
      2137656763U,
      141376813U,
      2439277719U,
      3865271297U,
      1802195444U,
      476864866U,
      2238001368U,
      4066508878U,
      1812370925U,
      453092731U,
      2181625025U,
      4111451223U,
      1706088902U,
      314042704U,
      2344532202U,
      4240017532U,
      1658658271U,
      366619977U,
      2362670323U,
      4224994405U,
      1303535960U,
      984961486U,
      2747007092U,
      3569037538U,
      1256170817U,
      1037604311U,
      2765210733U,
      3554079995U,
      1131014506U,
      879679996U,
      2909243462U,
      3663771856U,
      1141124467U,
      855842277U,
      2852801631U,
      3708648649U,
      1342533948U,
      654459306U,
      3188396048U,
      3373015174U,
      1466479909U,
      544179635U,
      3110523913U,
      3462522015U,
      1591671054U,
      702138776U,
      2966460450U,
      3352799412U,
      1504918807U,
      783551873U,
      3082640443U,
      3233442989U,
      3988292384U,
      2596254646U,
      62317068U,
      1957810842U,
      3939845945U,
      2647816111U,
      81470997U,
      1943803523U,
      3814918930U,
      2489596804U,
      225274430U,
      2053790376U,
      3826175755U,
      2466906013U,
      167816743U,
      2097651377U,
      4027552580U,
      2265490386U,
      503444072U,
      1762050814U,
      4150417245U,
      2154129355U,
      426522225U,
      1852507879U,
      4275313526U,
      2312317920U,
      282753626U,
      1742555852U,
      4189708143U,
      2394877945U,
      397917763U,
      1622183637U,
      3604390888U,
      2714866558U,
      953729732U,
      1340076626U,
      3518719985U,
      2797360999U,
      1068828381U,
      1219638859U,
      3624741850U,
      2936675148U,
      906185462U,
      1090812512U,
      3747672003U,
      2825379669U,
      829329135U,
      1181335161U,
      3412177804U,
      3160834842U,
      628085408U,
      1382605366U,
      3423369109U,
      3138078467U,
      570562233U,
      1426400815U,
      3317316542U,
      2998733608U,
      733239954U,
      1555261956U,
      3268935591U,
      3050360625U,
      752459403U,
      1541320221U,
      2607071920U,
      3965973030U,
      1969922972U,
      40735498U,
      2617837225U,
      3943577151U,
      1913087877U,
      83908371U,
      2512341634U,
      3803740692U,
      2075208622U,
      213261112U,
      2463272603U,
      3855990285U,
      2094854071U,
      198958881U,
      2262029012U,
      4057260610U,
      1759359992U,
      534414190U,
      2176718541U,
      4139329115U,
      1873836001U,
      414664567U,
      2282248934U,
      4279200368U,
      1711684554U,
      285281116U,
      2405801727U,
      4167216745U,
      1634467795U,
      376229701U,
      2685067896U,
      3608007406U,
      1308918612U,
      956543938U,
      2808555105U,
      3495958263U,
      1231636301U,
      1047427035U,
      2932959818U,
      3654703836U,
      1088359270U,
      936918000U,
      2847714899U,
      3736837829U,
      1202900863U,
      817233897U,
      3183342108U,
      3401237130U,
      1404277552U,
      615818150U,
      3134207493U,
      3453421203U,
      1423857449U,
      601450431U,
      3009837614U,
      3294710456U,
      1567103746U,
      711928724U,
      3020668471U,
      3272380065U,
      1510334235U,
      755167117U
    };
    private IContainer components = (IContainer) null;
    private BackgroundWorker worker = (BackgroundWorker) null;
    public string I2CAdapterType = (string) null;
    public string logDir = (string) null;
    private string sfis_cm = (string) null;
    private string sfis_ip = (string) null;
    private int sfis_port = 0;
    private string fixture_id = (string) null;
    private string line = (string) null;
    private string logDefault = (string) null;
    private int comPort = 1;
    public byte[] tBufferAll = (byte[]) null;
    public byte[] rBufferA2 = new byte[256];
    public byte[] rBufferA0 = new byte[256];
    public byte[] tBufferFBWrite = (byte[]) null;
    public byte[] tBufferFBRead = new byte[256];
    private string customFormatNow = "yyyyMMddHHmmss";
    private string customFormatToday = "yyyyMMdd";
    public string hw_type = (string) null;
    private bool m_bTestStarted = false;
    private bool m_bDLN2Connected = false;
    private bool m_bFCTTestStarted = false;
    private bool m_bFCTTestLogCopied = false;
    private bool m_bTestSummarySection = false;
    private bool m_bNVRAMVerifyTestStarted = false;
    private bool m_bNVRAMVerifyTestLogCopied = false;
    private bool m_bSerialReadFormattingEnabled = true;
    private string m_dutport = (string) null;
    private string m_usbdioport1 = (string) null;
    private string m_usbdioport2 = (string) null;
    private string m_usbrelayport = (string) null;
    private string m_hostport = (string) null;
    private string m_baudrate = "115200";
    private string m_databits = "8";
    private string m_parity = Parity.None.ToString();
    private string m_stopbits = StopBits.One.ToString();
    private string m_flowcontrol = Handshake.None.ToString();
    private string m_esr_b57Engineering_Diagnostics = "N/A";
    private string m_b57APE_Firmware = "N/A";
    private string m_b57BootCode = "N/A";
    private string m_b57CCM = "N/A";
    private string m_b57PXE = "N/A";
    private string m_b57EFI = "N/A";
    private string m_b57iSCSI_Boot = "N/A";
    private string m_b57iSCSI_CFG = "N/A";
    private string m_b57iSCSI_CFG_1 = "N/A";
    private string m_b57iSCSI_CFG_2 = "N/A";
    private string m_b57iSCSI_CFG_3 = "N/A";
    private string m_esr_Engineering_Diagnostics = "N/A";
    private string m_BootCode = "N/A";
    private string m_PXE = "N/A";
    private string m_EFI = "N/A";
    private string m_APE_Firmware = "N/A";
    private string m_iSCSI_Boot = "N/A";
    private string m_iSCSI_CFG = "N/A";
    private string m_iSCSI_CFG_1 = "N/A";
    private string m_iSCSI_CFG_2 = "N/A";
    private string m_iSCSI_CFG_3 = "N/A";
    private string m_CCM = "N/A";
    private string m_DEV0_CFG = "N/A";
    private string m_DEV1_CFG = "N/A";
    private string m_DEV2_CFG = "N/A";
    private string m_DEV3_CFG = "N/A";
    private string m_FW_Version = "N/A";
    private string m_CFW = "N/A";
    private string m_CFW2 = "N/A";
    private string m_CFWP = "N/A";
    private string m_BFW = "N/A";
    private string m_PCIE = "N/A";
    private string m_MBA = "N/A";
    private string m_PCFG00 = "N/A";
    private string m_PCFG01 = "N/A";
    private string m_FCFG00 = "N/A";
    private string m_FCFG01 = "N/A";
    private string m_SCFG = "N/A";
    private string m_MBA_CHKSUM = "N/A";
    private string m_CCM_CHKSUM = "N/A";
    private string m_CFW_CHKSUM = "N/A";
    private string m_CFW2_CHKSUM = "N/A";
    private string m_CFWP_CHKSUM = "N/A";
    private string m_AFW_CHKSUM = "N/A";
    private string m_BFW_CHKSUM = "N/A";
    private string m_TSCF_CHKSUM = "N/A";
    private string m_IBOOT_CHKSUM = "N/A";
    private string m_IBCFG00_CHKSUM = "N/A";
    private string m_IBCFG01_CHKSUM = "N/A";
    private double m_MIN_Consumable_Threshold = 0.7;
    private double m_MID_Consumable_Threshold = 0.8;
    private double m_MAX_Consumable_Threshold = 0.9;
    private bool m_bTMPCheckVerify = false;
    private double m_dMax_Temperature_Threshold = 0.0;
    private int m_nRMATestLoop = 8;
    private bool m_bRMAMACSNVerify = false;
    private bool m_bRMAStopOnFailure = true;
    private bool m_bRMAEraseNVRAM = false;
    private bool m_bRMAProgramNVRAM = false;
    private bool m_bRMAFCT = true;
    private bool m_bRMAProgramFRU = false;
    private bool m_bRMANVRAMVerify = true;
    private bool m_bRMAFRUVerify = true;
    private bool m_bRMANCSI = false;
    private bool m_bRMAOverallTestResults = true;
    private bool m_bRMAContinueTest = false;
    private bool m_bRetry = false;
    private int m_nPowerupRetry = 0;
    private int m_TestLoop = 1;
    private int m_TestMode = 1;
    private int m_DOSPC_BOOTUP_TIMER = 60;
    public int m_sfis_type = 91;
    private string m_sTestMode = (string) null;
    private string m_sDefaultTestMode = (string) null;
    private bool m_usbdioenable = false;
    private bool m_usbdiodual = false;
    private bool m_builtin_BIE = false;
    private bool m_usbrelayenable = false;
    private bool m_userabort = false;
    private bool m_ready = false;
    private bool m_bLoadConfig = true;
    private bool m_bInvalidPassword = false;
    private bool m_sfis_enabled = false;
    private bool m_esr_sfis_enabled = false;
    private bool m_ConsumableTracking_enabled = false;
    private bool m_YieldTracking_enabled = false;
    private bool m_bStopOnFail = false;
    private bool m_bStopOnFail_poweron = false;
    private bool m_bFCTEnabled = true;
    private bool m_bERASENVRAMEnabled = true;
    private bool m_bLOOPBACKEnabled = true;
    private bool m_bProgramFRUEnabled = true;
    private bool m_bNVRAMVerifyEnabled = true;
    private bool m_bFRUVerifyEnabled = true;
    private bool m_bNCSIEnabled = true;
    private bool m_bDUTPCPowerON = false;
    private bool m_bUploadTestLog = false;
    private bool m_esr_bNPAR = false;
    private int m_nTotalFilesUploaded = 0;
    private int m_nTotalIniFileUploaded = 0;
    private string m_txtPassword = "Brcm123*";
    private string m_fixture_id = (string) null;
    private string m_line = (string) null;
    private string m_network_adapter = (string) null;
    private string m_duttype = (string) null;
    private string m_emp_number = (string) null;
    private string m_test_station = (string) null;
    private string m_sfis_log_dir = (string) null;
    private string m_esr_sfis_log_dir = (string) null;
    private string m_esr_pid = (string) null;
    private string m_esr_assy_number = (string) null;
    private string m_esr_employee = (string) null;
    private string m_esr_email = (string) null;
    private string m_esr_comments = (string) null;
    private string m_esr_customer = (string) null;
    private string m_esr_chipnumber = (string) null;
    private string m_esr_chiprev = (string) null;
    private string m_esr_chipid = (string) null;
    private string m_esr_requester = (string) null;
    private string m_esr_assyrev = (string) null;
    private string m_esr_tester = (string) null;
    private string m_sfis_log_path = (string) null;
    private string m_esr_sfis_log_path = (string) null;
    private DateTime m_timestamp = DateTime.Now;
    private string m_results = (string) null;
    private string m_commands = (string) null;
    private string m_data = (string) null;
    private string m_sfcmsg = (string) null;
    private string m_badge = (string) null;
    private string m_label = (string) null;
    private string m_SNLabel = (string) null;
    private string m_MACLabel = (string) null;
    private string m_software = (string) null;
    private string m_firmware = (string) null;
    private string m_configuration = (string) null;
    private string m_logFileName = (string) null;
    private string m_traceLog = (string) null;
    private string m_traceLogFileName = (string) null;
    private string m_ProgramFRUFileName = (string) null;
    private string m_VerifyFRUFileName = (string) null;
    private string m_TestSummaryFileName = (string) null;
    private string m_TestLogSN = (string) null;
    private string m_TestLogSNFileName = (string) null;
    private string m_txtOverallTestResult = (string) null;
    private string m_txtOverallErrorDescription = (string) null;
    private int m_OverlTestErrorCode = 0;
    private int m_esr_Stride = 0;
    private int m_esr_Ports = 0;
    private string m_esr_BC = (string) null;
    private string m_esr_ImgFile = (string) null;
    private string m_esr_LogFile = (string) null;
    private bool m_ProgramFRUTestResult = false;
    private string m_FCTErrorCode = (string) null;
    private string m_FCTErrorDescription = (string) null;
    private string m_LOOPBACKErrorDescription = (string) null;
    private string m_NVRAMVerifyErrorDescription = (string) null;
    private string m_LABELErrorDescription = (string) null;
    private string m_ProgramFRUErrorDescription = (string) null;
    private string m_FRUVerifyErrorDescription = (string) null;
    private string m_NCSIErrorDescription = (string) null;
    private int m_Retry = 0;
    private Settings settings = new Settings();
    private Dictionary<string, string> info = new Dictionary<string, string>();
    private const int ERROR_FILE_NOT_FOUND = 2;
    private const int ERROR_ACCESS_DENIED = 5;
    private const string LABEL_PREFIX_11S = "11S";
    private const string LABEL_PREFIX_8S = "8S";
    private const int ERR_FRU_READ_ERROR = 1000;
    private const int ERR_FRU_WRITE_ERROR = 2000;
    private const int ERR_FRU_DIOLAN_NO_CONNECT = 3000;
    private const int ERR_FRU_NO_FILE = 4000;
    private const int ERR_FRU_INVALID_BUFFER_SIZE = 5000;
    private const int ERR_FRU_VERIFY_FAILED = 6000;
    private const int ERR_PRETEST_LABEL_MISTMATCH = 20000;
    private const int ERR_POSTTEST_LABEL_MISTMATCH = 21000;
    private const int ERR_COPYFILE_TO_MAPPED_DRIVE = 22000;
    private const int ERR_NCSITEST_FAIL = 34000;
    private const int ERR_NVRAM_VERIFY_FAILED = 10000;
    private const int ERR_FCT_NO_ACK_FROM_DUT = 300;
    private const int ERR_FCT_FAIL_AUTOREBOOT = 301;
    private const int ERR_FCT_PREFWCHECK_FAILED = 302;
    private const int ERR_FCT_TEMPERATURE_READING_MISSING = 998;
    private const int ERR_FCT_TEMPERATURE_CHECK_FAILED = 999;
    private const int ERR_FRU_NO_FAILURE = 0;
    private const int ERR_FCT_NO_FAILURE = 0;
    private const int ERR_NVRAM_VERIFY_NO_FAILURE = 0;
    private const int ERR_FRU_VERIFY_NO_FAILURE = 0;
    private const string DLN_1 = "DLN-1";
    private const string DLN_2 = "DLN-2";
    private const int builtin_BIE_gpio_pin = 30;
    private const int FRU_MAC_ADDRESS = 113;
    private const int FRU_HI_SN_ADDRESS = 52;
    private const int FRU_HI_SN_LEN = 12;
    private const int FRU_PN_ADDRESS = 65;
    private const int FRU_PN_LEN = 9;
    private const int FRU_SN_ADDRESS = 50;
    private const int FRU_SN_LEN = 2;
    private const int VPD_MAC_ADDRESS = 111;
    private const int VPD_HI_SN_ADDRESS = 90;
    private const int VPD_HI_SN_LEN = 6;
    private const int VPD_PN_ADDRESS = 60;
    private const int VPD_PN_LEN = 12;
    private const int VPD_SN_ADDRESS = 84;
    private const int VPD_SN_LEN = 6;
    private const int VPD_SN_LEN_Lenovo = 11;
    private const int A1913G_TEMPLATE_SIZE = 541;
    private const int A1904GH_TEMPLATE_SIZE = 1028;
    private const int BUBBLES_TEMPLATE_SIZE = 586;
    private const int CASPIAN_TEMPLATE_SIZE = 421;
    private const int ARAL_TEMPLATE_SIZE = 461;
    private const int A2003GH_TEMPLATE_SIZE = 512;
    private const int A1905GD_TEMPLATE_SIZE = 4096;
    private const int A1904GD_TEMPLATE_SIZE = 4096;
    private const int A2003GD_TEMPLATE_SIZE = 4096;
    private const int PAULI_TEMPLATE_SIZE = 4096;
    private const int HERTZ_TEMPLATE_SIZE = 4096;
    private const int GAUSS_TEMPLATE_SIZE = 4096;
    private const int P225ED_TEMPLATE_SIZE = 4096;
    private const int P225EPD_TEMPLATE_SIZE = 4096;
    private const int P210ED_TEMPLATE_SIZE = 4096;
    private const int P210EPD_TEMPLATE_SIZE = 4096;
    private const int P210TED_TEMPLATE_SIZE = 4096;
    private const int P210TEPD_TEMPLATE_SIZE = 4096;
    private const int P225EDLP_TEMPLATE_SIZE = 4096;
    private const int P225EPDLP_TEMPLATE_SIZE = 4096;
    private const int P210EDLP_TEMPLATE_SIZE = 4096;
    private const int P210EPDLP_TEMPLATE_SIZE = 4096;
    private const int P210TEDLP_TEMPLATE_SIZE = 4096;
    private const int P210TEPDLP_TEMPLATE_SIZE = 4096;
    private const int BOAR_TEMPLATE_SIZE = 566;
    private const int BANDICOOT_TEMPLATE_SIZE = 540;
    private const int BOBCAT_TEMPLATE_SIZE = 558;
    private const int BOBOLINK_TEMPLATE_SIZE = 524;
    private const int M2004G_TEMPLATE_SIZE = 4096;
    private const int N2004_TEMPLATE_SIZE = 4096;
    private const int AD2000DC_TEMPLATE_SIZE = 4096;
    private const int A1913G_TEMPLATE_CHKSUM = 188;
    private const int A1904GH_TEMPLATE_CHKSUM = 249;
    private const int BUBBLES_TEMPLATE_CHKSUM = 106;
    private const int CASPIAN_TEMPLATE_CHKSUM = 240;
    private const int ARAL_TEMPLATE_CHKSUM = 17;
    private const int A2003GH_TEMPLATE_CHKSUM = 195;
    private const int BOAR_TEMPLATE_CHKSUM = 222;
    private const int BANDICOOT_TEMPLATE_CHKSUM = 67;
    private const int BOBCAT_TEMPLATE_CHKSUM = 138;
    private const int BOBOLINK_TEMPLATE_CHKSUM = 172;
    private const int A1905GD_TEMPLATE_CHKSUM = 30;
    private const int A1905GD_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int A1904GD_TEMPLATE_CHKSUM = 32;
    private const int A1904GD_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int A2003GD_TEMPLATE_CHKSUM = 108;
    private const int A2003GD_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int PAULI_TEMPLATE_CHKSUM = 247;
    private const int PAULI_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int HERTZ_TEMPLATE_CHKSUM = 10;
    private const int HERTZ_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int GAUSS_TEMPLATE_CHKSUM = 247;
    private const int GAUSS_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P225ED_TEMPLATE_CHKSUM = 78;
    private const int P225ED_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P225EPD_TEMPLATE_CHKSUM = 34;
    private const int P225EPD_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P210ED_TEMPLATE_CHKSUM = 78;
    private const int P210ED_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P210EPD_TEMPLATE_CHKSUM = 34;
    private const int P210EPD_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P210TED_TEMPLATE_CHKSUM = 78;
    private const int P210TED_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P210TEPD_TEMPLATE_CHKSUM = 34;
    private const int P210TEPD_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P225EDLP_TEMPLATE_CHKSUM = 78;
    private const int P225EDLP_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P225EPDLP_TEMPLATE_CHKSUM = 34;
    private const int P225EPDLP_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P210EDLP_TEMPLATE_CHKSUM = 78;
    private const int P210EDLP_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P210EPDLP_TEMPLATE_CHKSUM = 34;
    private const int P210EPDLP_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P210TEDLP_TEMPLATE_CHKSUM = 78;
    private const int P210TEDLP_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int P210TEPDLP_TEMPLATE_CHKSUM = 34;
    private const int P210TEPDLP_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int M2004G_TEMPLATE_CHKSUM = 207;
    private const int M2004G_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int N2004_TEMPLATE_CHKSUM = 119;
    private const int N2004_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int AD2000DC_TEMPLATE_CHKSUM = 32;
    private const int AD2000DC_TEMPLATE_CHKSUM_OFFSET = 0;
    private const int MUSTANG_TEMPLATE_SIZE = 65536;
    private const int MUSTANG_TEMPLATE_CHKSUM = 24;
    private const int M4161_TEMPLATE_SIZE = 1024;
    private const int M4161_TEMPLATE_CHKSUM = 172;
    private const int M150PM_TEMPLATE_SIZE = 256;
    private const int M150PM_TEMPLATE_CHKSUM = 176;
    private const int FRUA1913G_SN_LEN = 10;
    private const int FRUA1913G_SN_ADDRESS1 = 56;
    private const int FRUA1913G_SN_ADDRESS2 = 163;
    private const int FRUA1913G_MAC_ADDRESS1 = 366;
    private const int FRUA1913G_MAC_ADDRESS2 = 372;
    private const int FRUA1913G_MAC_ADDRESS3 = 378;
    private const int FRUA1913G_MAC_ADDRESS4 = 384;
    private const int FRUA1904G_H_SN_LEN = 10;
    private const int FRUA1904G_H_SN_ADDRESS1 = 54;
    private const int FRUA1904G_H_SN_ADDRESS2 = 161;
    private const int FRUA1904G_H_MAC_ADDRESS1 = 358;
    private const int FRUA1904G_H_MAC_ADDRESS2 = 364;
    private const int FRUA1904G_H_MAC_ADDRESS3 = 370;
    private const int FRUA1904G_H_MAC_ADDRESS4 = 376;
    private const int FRU_BUBBLES_SN_LEN = 10;
    private const int FRU_BUBBLES_SN_ADDRESS1 = 50;
    private const int FRU_BUBBLES_SN_ADDRESS2 = 157;
    private const int FRU_BUBBLES_MAC_ADDRESS1 = 411;
    private const int FRU_BUBBLES_MAC_ADDRESS2 = 417;
    private const int FRU_BUBBLES_MAC_ADDRESS3 = 423;
    private const int FRU_BUBBLES_MAC_ADDRESS4 = 429;
    private const int FRU_CASPIAN_SN_LEN = 11;
    private const int FRU_CASPIAN_SN_ADDRESS1 = 188;
    private const int FRU_CASPIAN_SN_ADDRESS2 = 325;
    private const int FRU_ARAL_SN_LEN = 11;
    private const int FRU_ARAL_SN_ADDRESS1 = 200;
    private const int FRU_ARAL_SN_ADDRESS2 = 345;
    private const int FRUA2003G_H_SN_LEN = 10;
    private const int FRUA2003G_H_SN_ADDRESS1 = 54;
    private const int FRUA2003G_H_SN_ADDRESS2 = 161;
    private const int FRUA2003G_H_MAC_ADDRESS1 = 294;
    private const int FRUA2003G_H_MAC_ADDRESS2 = 300;
    private const int FRU_A1904GD_MAC_ADDRESS1 = 265;
    private const int FRU_A1904GD_MAC_ADDRESS2 = 285;
    private const int FRU_A1904GD_MAC_ADDRESS3 = 305;
    private const int FRU_A1904GD_MAC_ADDRESS4 = 325;
    private const int FRU_A1905GD_MAC_ADDRESS1 = 265;
    private const int FRU_A1905GD_MAC_ADDRESS2 = 285;
    private const int FRU_A1905GD_MAC_ADDRESS3 = 305;
    private const int FRU_A1905GD_MAC_ADDRESS4 = 325;
    private const int FRU_A2003GD_MAC_ADDRESS1 = 265;
    private const int FRU_A2003GD_MAC_ADDRESS2 = 285;
    private const int FRU_M2004G_MAC_ADDRESS1 = 265;
    private const int FRU_M2004G_MAC_ADDRESS2 = 285;
    private const int FRU_M2004G_MAC_ADDRESS3 = 305;
    private const int FRU_M2004G_MAC_ADDRESS4 = 325;
    private const int FRU_PAULI_MAC_ADDRESS1 = 269;
    private const int FRU_PAULI_MAC_ADDRESS2 = 289;
    private const int FRU_PAULI_MAC_ADDRESS3 = 309;
    private const int FRU_PAULI_MAC_ADDRESS4 = 469;
    private const int FRU_HERTZ_MAC_ADDRESS1 = 269;
    private const int FRU_HERTZ_MAC_ADDRESS2 = 429;
    private const int FRU_GAUSS_MAC_ADDRESS1 = 269;
    private const int FRU_GAUSS_MAC_ADDRESS2 = 289;
    private const int FRU_GAUSS_MAC_ADDRESS3 = 309;
    private const int FRU_GAUSS_MAC_ADDRESS4 = 469;
    private const int FRU_P225ED_MAC_ADDRESS1 = 265;
    private const int FRU_P225ED_MAC_ADDRESS2 = 285;
    private const int FRU_P225EDLP_MAC_ADDRESS1 = 265;
    private const int FRU_P225EDLP_MAC_ADDRESS2 = 285;
    private const int FRU_P225EPD_MAC_ADDRESS1 = 269;
    private const int FRU_P225EPD_MAC_ADDRESS2 = 429;
    private const int FRU_P225EPDLP_MAC_ADDRESS1 = 269;
    private const int FRU_P225EPDLP_MAC_ADDRESS2 = 429;
    private const int FRU_P210TED_MAC_ADDRESS1 = 265;
    private const int FRU_P210TED_MAC_ADDRESS2 = 285;
    private const int FRU_P210TEDLP_MAC_ADDRESS1 = 265;
    private const int FRU_P210TEDLP_MAC_ADDRESS2 = 285;
    private const int FRU_P210TEPD_MAC_ADDRESS1 = 269;
    private const int FRU_P210TEPD_MAC_ADDRESS2 = 429;
    private const int FRU_P210TEPDLP_MAC_ADDRESS1 = 269;
    private const int FRU_P210TEPDLP_MAC_ADDRESS2 = 429;
    private const int FRU_P210ED_MAC_ADDRESS1 = 265;
    private const int FRU_P210ED_MAC_ADDRESS2 = 285;
    private const int FRU_P210EDLP_MAC_ADDRESS1 = 265;
    private const int FRU_P210EDLP_MAC_ADDRESS2 = 285;
    private const int FRU_P210EPD_MAC_ADDRESS1 = 269;
    private const int FRU_P210EPD_MAC_ADDRESS2 = 429;
    private const int FRU_P210EPDLP_MAC_ADDRESS1 = 269;
    private const int FRU_P210EPDLP_MAC_ADDRESS2 = 429;
    private const int FRU_AD2000DC_MAC_ADDRESS1 = 265;
    private const int FRU_AD2000DC_MAC_ADDRESS2 = 285;
    private const int FRU_AD2000DC_MAC_ADDRESS3 = 305;
    private const int FRU_AD2000DC_MAC_ADDRESS4 = 325;
    private const int FRU_BOAR_SN_LEN = 10;
    private const int FRU_BOAR_SN_ADDRESS1 = 53;
    private const int FRU_BOAR_SN_ADDRESS2 = 150;
    private const int FRU_BOAR_MAC_ADDRESS1 = 286;
    private const int FRU_BOAR_MAC_ADDRESS2 = 454;
    private const int FRU_BOAR_MAC_ADDRESS3 = 292;
    private const int FRU_BOAR_MAC_ADDRESS4 = 460;
    private const int FRU_BOAR_MAC_ADDRESS5 = 470;
    private const int FRU_BOAR_MAC_ADDRESS6 = 478;
    private const int FRU_BANDICOOT_SN_LEN = 10;
    private const int FRU_BANDICOOT_SN_ADDRESS1 = 57;
    private const int FRU_BANDICOOT_SN_ADDRESS2 = 164;
    private const int FRU_BANDICOOT_MAC_ADDRESS1 = 302;
    private const int FRU_BANDICOOT_MAC_ADDRESS2 = 481;
    private const int FRU_BANDICOOT_MAC_ADDRESS3 = 308;
    private const int FRU_BANDICOOT_MAC_ADDRESS4 = 487;
    private const int FRU_BANDICOOT_MAC_ADDRESS5 = 497;
    private const int FRU_BANDICOOT_MAC_ADDRESS6 = 505;
    private const int FRU_BOBCAT_SN_LEN = 10;
    private const int FRU_BOBCAT_SN_ADDRESS1 = 46;
    private const int FRU_BOBCAT_SN_ADDRESS2 = 143;
    private const int FRU_BOBCAT_MAC_ADDRESS1 = 278;
    private const int FRU_BOBCAT_MAC_ADDRESS2 = 446;
    private const int FRU_BOBCAT_MAC_ADDRESS3 = 284;
    private const int FRU_BOBCAT_MAC_ADDRESS4 = 452;
    private const int FRU_BOBCAT_MAC_ADDRESS5 = 462;
    private const int FRU_BOBCAT_MAC_ADDRESS6 = 470;
    private const int FRU_BOBOLINK_SN_LEN = 10;
    private const int FRU_BOBOLINK_SN_ADDRESS1 = 50;
    private const int FRU_BOBOLINK_SN_ADDRESS2 = 149;
    private const int FRU_BOBOLINK_MAC_ADDRESS1 = 286;
    private const int FRU_BOBOLINK_MAC_ADDRESS2 = 465;
    private const int FRU_BOBOLINK_MAC_ADDRESS3 = 292;
    private const int FRU_BOBOLINK_MAC_ADDRESS4 = 471;
    private const int FRU_BOBOLINK_MAC_ADDRESS5 = 481;
    private const int FRU_BOBOLINK_MAC_ADDRESS6 = 489;
    private const int FRU_M150PM_SN_LEN = 16;
    private const int FRU_M150PM_SN_ADDRESS1 = 51;
    private const int FRU_M150PM_SN_ADDRESS2 = 142;
    private const int FRU_sn_addrESS = 50;
    private const int FRU_sn_len = 2;
    private const int FRU_I2C_ADDRESS = 82;
    private const int FRU_I2C_ADDRESS_56H = 86;
    private const int THERMAL_I2C_ADDRESS = 94;
    private const int REGISTER_06_VALUE_M2004G = 251;
    private const int REGISTER_0E_VALUE_M2004G = 0;
    private const int REGISTER_06_VALUE_N2004 = 251;
    private const int REGISTER_0E_VALUE_N2004 = 0;
    private const int REGISTER_06_VALUE_AD2000DC = 0;
    private const int REGISTER_0E_VALUE_AD2000DC = 0;
    private const int REGISTER_06_VALUE_A1904GD = 255;
    private const int REGISTER_0E_VALUE_A1904GD = 255;
    private const int REGISTER_06_VALUE_A1905GD = 255;
    private const int REGISTER_0E_VALUE_A1905GD = 252;
    private const int REGISTER_06_VALUE_A2003GD = 0;
    private const int REGISTER_0E_VALUE_A2003GD = 0;
    private const int REGISTER_06_VALUE_PAULI = 254;
    private const int REGISTER_0E_VALUE_PAULI = 0;
    private const int REGISTER_06_VALUE_HERTZ = 254;
    private const int REGISTER_0E_VALUE_HERTZ = 0;
    private const int REGISTER_06_VALUE_GAUSS = 254;
    private const int REGISTER_0E_VALUE_GAUSS = 0;
    private const int REGISTER_06_VALUE_P225ED = 2;
    private const int REGISTER_0E_VALUE_P225ED = 255;
    private const int REGISTER_06_VALUE_P225EPD = 2;
    private const int REGISTER_0E_VALUE_P225EPD = 255;
    private const int REGISTER_06_VALUE_P210ED = 2;
    private const int REGISTER_0E_VALUE_P210ED = 255;
    private const int REGISTER_06_VALUE_P210EPD = 2;
    private const int REGISTER_0E_VALUE_P210EPD = 255;
    private const int REGISTER_06_VALUE_P210TED = 1;
    private const int REGISTER_0E_VALUE_P210TED = 255;
    private const int REGISTER_06_VALUE_P210TEPD = 1;
    private const int REGISTER_0E_VALUE_P210TEPD = 255;
    private const int REGISTER_06_VALUE_P225EDLP = 2;
    private const int REGISTER_0E_VALUE_P225EDLP = 255;
    private const int REGISTER_06_VALUE_P225EPDLP = 2;
    private const int REGISTER_0E_VALUE_P225EPDLP = 255;
    private const int REGISTER_06_VALUE_P210EDLP = 2;
    private const int REGISTER_0E_VALUE_P210EDLP = 255;
    private const int REGISTER_06_VALUE_P210EPDLP = 2;
    private const int REGISTER_0E_VALUE_P210EPDLP = 255;
    private const int REGISTER_06_VALUE_P210TEDLP = 1;
    private const int REGISTER_0E_VALUE_P210TEDLP = 255;
    private const int REGISTER_06_VALUE_P210TEPDLP = 1;
    private const int REGISTER_0E_VALUE_P210TEPDLP = 255;
    private const int REGISTER_6D_VALUE_PAULI = 240;
    private const int REGISTER_6D_VALUE_HERTZ = 240;
    private const int REGISTER_6D_VALUE_GAUSS = 240;
    private const int REGISTER_6D_VALUE_P225ED = 176;
    private const int REGISTER_6D_VALUE_P225EPD = 176;
    private const int REGISTER_6D_VALUE_P210ED = 176;
    private const int REGISTER_6D_VALUE_P210EPD = 176;
    private const int REGISTER_6D_VALUE_P210TED = 176;
    private const int REGISTER_6D_VALUE_P210TEPD = 176;
    private const int REGISTER_6D_VALUE_P225EDLP = 176;
    private const int REGISTER_6D_VALUE_P225EPDLP = 176;
    private const int REGISTER_6D_VALUE_P210EDLP = 176;
    private const int REGISTER_6D_VALUE_P210EPDLP = 176;
    private const int REGISTER_6D_VALUE_P210TEDLP = 176;
    private const int REGISTER_6D_VALUE_P210TEPDLP = 176;
    private const int VPD_sn_address = 84;
    private const int VPD_sn_len = 6;
    private const int VPD_MAC_ADDRESS_MUSTANG = 1600;
    private const string PN_Boerne = "PBQSA";
    private const string PN_Putnam = "PBYWT";
    private const string PN_BUBBLES = "PWVQV";
    private const string PN_CASPIAN = "SN37A28236";
    private const string PN_ARAL = "SN37A28240";
    private const string PN_Woodville = "PBKRQ";
    private const string PN_BOAR = "PFDMD";
    private const string PN_BANDICOOT = "PFDMB";
    private const string PN_BOBCAT = "PFCJK";
    private const string PN_BOBOLINK = "PFDME";
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
    private const string HW_BOAR = "BOAR";
    private const string HW_BANDICOOT = "BANDICOOT";
    private const string HW_BOBCAT = "BOBCAT";
    private const string HW_BOBOLINK = "BOBOLINK";
    private const string HW_Woodville = "WOODVILLE";
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
    private const int PRODUCTION = 1;
    private const int OBA = 2;
    private const int FCT = 3;
    private const int LOOPBACK = 31;
    private const int CSV = 32;
    private const int NVRAMVerify = 4;
    private const int STRESS = 5;
    private const int STRESS_STOPONFAIL = 51;
    private const int STRESS_STOPONFIL_POWERON = 52;
    private const int FAI = 6;
    private const int GOLDENSAMPLE = 7;
    private const int GOLDENSAMPLE_LOG = 71;
    private const int GOLDENSAMPLE_CFG = 72;
    private const int GOLDENSAMPLE_IMG = 73;
    private const int RMA = 8;
    private const int PRODUCTION_ERASENVRAM = 9;
    private const int ESR_GENERIC = 10;
    private const int ESR = 90;
    private const int CM = 91;
    private const int FCT_UNKNOWN = 254;
    private const int NVRAMVerify_UNKNOWN = 255;
    private TextBox txtTerminal;
    private GroupBox groupTest;
    private StatusStrip statusStrip1;
    private ToolStrip toolStrip1;
    private ToolStripLabel lblTestStation;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripLabel lblTestDate;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuFile;
    private ToolStripMenuItem mnuOpenConfig;
    private ToolStripMenuItem mnuExit;
    private ToolStripMenuItem mnuOptions;
    private Button btnAbort;
    private Button btnStart;
    private ToolStripStatusLabel lblStatus;
    private DataGridView dataGrid;
    private ToolStripLabel toolStripLabel1;
    private ToolStripComboBox cboDiagPort;
    private GroupBox groupUUT;
    private Label label2;
    private TextBox txtLabel;
    private TextBox txtMAC;
    private Label label1;
    private TextBox txtSend;
    private Button btnSend;
    private CheckBox chkSFIS;
    private Button btnOK;
    private ToolStripLabel lblHardwareType;
    private ToolStripSeparator toolStripSeparator2;
    private HexBox hexBox1;
    private ToolStripLabel lblTestMode;
    private ToolStripStatusLabel lblStatus2;
    private Label label3;
    private TextBox txtBadge;
    private TextBox TextSFISMessage;
    private TextBox TextSFISLog;
    private Label LabelSFISLinkStatus;
    private Label label4;
    private ToolStripLabel lblPartNumber;
    private ProgressBar progressBar;
    private GroupBox groupBox1;
    private TextBox textDiolan;
    private Label labelDiolan;
    private TextBox textMB;
    private Label labelMB;
    private TextBox textRiserCard;
    private Label labelRiserCard;
    private TextBox textTestJigWA;
    private Label labelTestJigWA;
    private TextBox textBIE;
    private Label LabelBIE;
    private TextBox textTestJig;
    private Label LabelTestJig;
    private TextBox textTotalTestThreshold;
    private TextBox textTotalPassed;
    private TextBox textTotalFailed;
    private TextBox textLastError;
    private Label lblTotalTestThreshold;
    private Label lblTotalPassed;
    private Label lblLastError;
    private Label lblTotalFailed;
    private GroupBox groupBox2;
    private ToolStripLabel lblTestYield;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripMenuItem openMonitorConfigFileToolStripMenuItem;
    private ToolStripMenuItem openGoldenSampleConfigFileToolStripMenuItem;
    private ToolStripButton ButtonPowerON;
    private ToolStripButton ButtonPowerOFF;
    private ToolStripButton ButtonBADGE;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripLabel lblTestTime;
    private ToolStripMenuItem goldenSampleModeToolStripMenuItem;
    private ToolStripMenuItem uploadTestLogsToolStripMenuItem;
    private ToolStripMenuItem openRMAConfigFileToolStripMenuItem;
    private ToolStripMenuItem openTemperatureCheckConfigFileToolStripMenuItem;
    public static devices deviceInfo;
    public byte lastErrCode;
    private string todayDate;
    private string todayNow;
    public static byte register_06_value;
    public static byte register_0E_value;
    public static byte register_6D_value;
    private int m_dutcomVal;
    private bool m_bFirsttime;
    private bool m_bHotSwapped;
    private bool m_bResultSentToSFIS;
    private CommPort m_commport;
    private int m_TestJig_WearOut_Adapter_Current_Count;
    private int m_TestJig_WearOut_Adapter_Lifecycle;
    private int m_TestJig_Current_Count;
    private int m_TestJig_Lifecycle;
    private int m_RiserCard_Current_Count;
    private int m_RiserCard_Lifecycle;
    private int m_BIE_Current_Count;
    private int m_BIE_Lifecycle;
    private int m_MB_Current_Count;
    private int m_MB_Lifecycle;
    private int m_Diolan_Current_Count;
    private int m_Diolan_Lifecycle;
    private int m_Total_FW_Check;
    private int m_Total_Passed;
    private int m_Total_Failed;
    private int m_Errorcode_Last;
    private int m_Failed_Count;
    private int m_Failed_Count_Max_Allowed;
    private int m_Total_Test_Threshold;
    private double m_TestYield;
    private double m_TestYield_Expected;
    private int m_Golden_Samples;
    private int m_Loop;
    private int m_DefaultTestMode;
    private string[] m_MAC;
    private Thread threadRunTest;
    private int m_iFCTErrorCode;
    private int m_iLOOPBACKErrorCode;
    private int m_iNVRAMVerifyErrorCode;
    private int m_iLABELErrorCode;
    private int m_iProgramFRUErrorCode;
    private int m_iFRUVerifyErrorCode;
    private int m_iNCSIErrorCode;
    private byte[] fruDataProgrammed;
    private byte[] fruWriteBuffer;
    private byte[] fruDataRead;
    private IsoteSFIS2 FxcnSfcListenerSMO;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (soteDiag.soteDiag));
      this.txtTerminal = new TextBox();
      this.groupTest = new GroupBox();
      this.label4 = new Label();
      this.LabelSFISLinkStatus = new Label();
      this.TextSFISLog = new TextBox();
      this.TextSFISMessage = new TextBox();
      this.chkSFIS = new CheckBox();
      this.txtSend = new TextBox();
      this.btnSend = new Button();
      this.btnStart = new Button();
      this.btnAbort = new Button();
      this.statusStrip1 = new StatusStrip();
      this.lblStatus = new ToolStripStatusLabel();
      this.lblStatus2 = new ToolStripStatusLabel();
      this.toolStrip1 = new ToolStrip();
      this.toolStripLabel1 = new ToolStripLabel();
      this.lblTestDate = new ToolStripLabel();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.lblTestStation = new ToolStripLabel();
      this.cboDiagPort = new ToolStripComboBox();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.lblHardwareType = new ToolStripLabel();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.lblPartNumber = new ToolStripLabel();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.lblTestMode = new ToolStripLabel();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.lblTestYield = new ToolStripLabel();
      this.ButtonPowerON = new ToolStripButton();
      this.ButtonPowerOFF = new ToolStripButton();
      this.ButtonBADGE = new ToolStripButton();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.lblTestTime = new ToolStripLabel();
      this.menuStrip1 = new MenuStrip();
      this.mnuFile = new ToolStripMenuItem();
      this.mnuOpenConfig = new ToolStripMenuItem();
      this.openMonitorConfigFileToolStripMenuItem = new ToolStripMenuItem();
      this.openGoldenSampleConfigFileToolStripMenuItem = new ToolStripMenuItem();
      this.mnuExit = new ToolStripMenuItem();
      this.mnuOptions = new ToolStripMenuItem();
      this.goldenSampleModeToolStripMenuItem = new ToolStripMenuItem();
      this.uploadTestLogsToolStripMenuItem = new ToolStripMenuItem();
      this.dataGrid = new DataGridView();
      this.groupUUT = new GroupBox();
      this.label3 = new Label();
      this.txtBadge = new TextBox();
      this.btnOK = new Button();
      this.txtMAC = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.txtLabel = new TextBox();
      this.hexBox1 = new HexBox();
      this.progressBar = new ProgressBar();
      this.groupBox1 = new GroupBox();
      this.textDiolan = new TextBox();
      this.labelDiolan = new Label();
      this.textMB = new TextBox();
      this.labelMB = new Label();
      this.textRiserCard = new TextBox();
      this.labelRiserCard = new Label();
      this.textTestJigWA = new TextBox();
      this.labelTestJigWA = new Label();
      this.textBIE = new TextBox();
      this.LabelBIE = new Label();
      this.textTestJig = new TextBox();
      this.LabelTestJig = new Label();
      this.textTotalTestThreshold = new TextBox();
      this.textTotalPassed = new TextBox();
      this.textTotalFailed = new TextBox();
      this.textLastError = new TextBox();
      this.lblTotalTestThreshold = new Label();
      this.lblTotalPassed = new Label();
      this.lblLastError = new Label();
      this.lblTotalFailed = new Label();
      this.groupBox2 = new GroupBox();
      this.openRMAConfigFileToolStripMenuItem = new ToolStripMenuItem();
      this.openTemperatureCheckConfigFileToolStripMenuItem = new ToolStripMenuItem();
      this.groupTest.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      ((ISupportInitialize) this.dataGrid).BeginInit();
      this.groupUUT.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.txtTerminal.Location = new Point(345, 60);
      this.txtTerminal.Multiline = true;
      this.txtTerminal.Name = "txtTerminal";
      this.txtTerminal.ReadOnly = true;
      this.txtTerminal.ScrollBars = ScrollBars.Both;
      this.txtTerminal.Size = new Size(901, 203);
      this.txtTerminal.TabIndex = 3;
      this.groupTest.Controls.Add((Control) this.label4);
      this.groupTest.Controls.Add((Control) this.LabelSFISLinkStatus);
      this.groupTest.Controls.Add((Control) this.TextSFISLog);
      this.groupTest.Controls.Add((Control) this.TextSFISMessage);
      this.groupTest.Controls.Add((Control) this.chkSFIS);
      this.groupTest.Controls.Add((Control) this.txtSend);
      this.groupTest.Controls.Add((Control) this.btnSend);
      this.groupTest.Controls.Add((Control) this.btnStart);
      this.groupTest.Location = new Point(5, 52);
      this.groupTest.Name = "groupTest";
      this.groupTest.Size = new Size(334, 211);
      this.groupTest.TabIndex = 0;
      this.groupTest.TabStop = false;
      this.groupTest.Text = "SFIS";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(4, 42);
      this.label4.Name = "label4";
      this.label4.Size = new Size(76, 13);
      this.label4.TabIndex = 18;
      this.label4.Text = "SFIS Message";
      this.LabelSFISLinkStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.LabelSFISLinkStatus.AutoSize = true;
      this.LabelSFISLinkStatus.Location = new Point(102, 188);
      this.LabelSFISLinkStatus.Name = "LabelSFISLinkStatus";
      this.LabelSFISLinkStatus.Size = new Size(78, 13);
      this.LabelSFISLinkStatus.TabIndex = 17;
      this.LabelSFISLinkStatus.Text = "No Connection";
      this.TextSFISLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TextSFISLog.BackColor = SystemColors.Window;
      this.TextSFISLog.Location = new Point(2, 63);
      this.TextSFISLog.Multiline = true;
      this.TextSFISLog.Name = "TextSFISLog";
      this.TextSFISLog.ReadOnly = true;
      this.TextSFISLog.ScrollBars = ScrollBars.Both;
      this.TextSFISLog.Size = new Size(332, 119);
      this.TextSFISLog.TabIndex = 16;
      this.TextSFISLog.TabStop = false;
      this.TextSFISMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.TextSFISMessage.Enabled = false;
      this.TextSFISMessage.Location = new Point(2, 19);
      this.TextSFISMessage.Name = "TextSFISMessage";
      this.TextSFISMessage.Size = new Size(330, 20);
      this.TextSFISMessage.TabIndex = 15;
      this.chkSFIS.AutoSize = true;
      this.chkSFIS.Location = new Point(7, 188);
      this.chkSFIS.Name = "chkSFIS";
      this.chkSFIS.Size = new Size(91, 17);
      this.chkSFIS.TabIndex = 1;
      this.chkSFIS.Text = "SFIS Enabled";
      this.chkSFIS.UseVisualStyleBackColor = true;
      this.chkSFIS.CheckedChanged += new EventHandler(this.chkSFIS_CheckedChanged);
      this.txtSend.Location = new Point(105, 124);
      this.txtSend.Name = "txtSend";
      this.txtSend.Size = new Size(41, 20);
      this.txtSend.TabIndex = 14;
      this.txtSend.Visible = false;
      this.btnSend.Location = new Point(152, 124);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new Size(53, 20);
      this.btnSend.TabIndex = 13;
      this.btnSend.Text = "SEND";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Visible = false;
      this.btnSend.Click += new EventHandler(this.btnSend_Click);
      this.btnStart.Location = new Point(211, 125);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new Size(66, 20);
      this.btnStart.TabIndex = 3;
      this.btnStart.Text = "START";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Visible = false;
      this.btnStart.Click += new EventHandler(this.btnStart_Click);
      this.btnAbort.Location = new Point(196, 150);
      this.btnAbort.Name = "btnAbort";
      this.btnAbort.Size = new Size(70, 23);
      this.btnAbort.TabIndex = 4;
      this.btnAbort.Text = "EXIT";
      this.btnAbort.UseVisualStyleBackColor = true;
      this.btnAbort.Click += new EventHandler(this.btnAbort_Click);
      this.statusStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.lblStatus,
        (ToolStripItem) this.lblStatus2
      });
      this.statusStrip1.Location = new Point(0, 619);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(1246, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      this.lblStatus.ImageAlign = ContentAlignment.MiddleLeft;
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new Size(38, 17);
      this.lblStatus.Text = "status";
      this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;
      this.lblStatus2.ImageAlign = ContentAlignment.MiddleRight;
      this.lblStatus2.Name = "lblStatus2";
      this.lblStatus2.RightToLeft = RightToLeft.No;
      this.lblStatus2.Size = new Size(44, 17);
      this.lblStatus2.Text = "status2";
      this.lblStatus2.TextAlign = ContentAlignment.MiddleRight;
      this.toolStrip1.Items.AddRange(new ToolStripItem[18]
      {
        (ToolStripItem) this.toolStripLabel1,
        (ToolStripItem) this.lblTestDate,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.lblTestStation,
        (ToolStripItem) this.cboDiagPort,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.lblHardwareType,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.lblPartNumber,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.lblTestMode,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.lblTestYield,
        (ToolStripItem) this.ButtonPowerON,
        (ToolStripItem) this.ButtonPowerOFF,
        (ToolStripItem) this.ButtonBADGE,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.lblTestTime
      });
      this.toolStrip1.Location = new Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1246, 25);
      this.toolStrip1.TabIndex = 3;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new Size(61, 22);
      this.toolStripLabel1.Text = "DiagPORT";
      this.lblTestDate.Alignment = ToolStripItemAlignment.Right;
      this.lblTestDate.ForeColor = Color.Fuchsia;
      this.lblTestDate.Name = "lblTestDate";
      this.lblTestDate.Size = new Size(30, 22);
      this.lblTestDate.Text = "date";
      this.toolStripSeparator1.Alignment = ToolStripItemAlignment.Right;
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.lblTestStation.Alignment = ToolStripItemAlignment.Right;
      this.lblTestStation.ForeColor = Color.Fuchsia;
      this.lblTestStation.Name = "lblTestStation";
      this.lblTestStation.Size = new Size(65, 22);
      this.lblTestStation.Text = "test station";
      this.cboDiagPort.Name = "cboDiagPort";
      this.cboDiagPort.Size = new Size(121, 25);
      this.cboDiagPort.Sorted = true;
      this.cboDiagPort.Click += new EventHandler(this.cboDiagPort_Click);
      this.toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.lblHardwareType.Alignment = ToolStripItemAlignment.Right;
      this.lblHardwareType.ForeColor = Color.Fuchsia;
      this.lblHardwareType.Name = "lblHardwareType";
      this.lblHardwareType.Size = new Size(82, 22);
      this.lblHardwareType.Text = "hardware type";
      this.toolStripSeparator3.Alignment = ToolStripItemAlignment.Right;
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 25);
      this.lblPartNumber.Alignment = ToolStripItemAlignment.Right;
      this.lblPartNumber.ForeColor = Color.Fuchsia;
      this.lblPartNumber.Name = "lblPartNumber";
      this.lblPartNumber.Size = new Size(73, 22);
      this.lblPartNumber.Text = "part number";
      this.toolStripSeparator4.Alignment = ToolStripItemAlignment.Right;
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(6, 25);
      this.lblTestMode.Alignment = ToolStripItemAlignment.Right;
      this.lblTestMode.ForeColor = Color.Fuchsia;
      this.lblTestMode.Name = "lblTestMode";
      this.lblTestMode.Size = new Size(60, 22);
      this.lblTestMode.Text = "test mode";
      this.toolStripSeparator5.Alignment = ToolStripItemAlignment.Right;
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(6, 25);
      this.lblTestYield.Alignment = ToolStripItemAlignment.Right;
      this.lblTestYield.ForeColor = Color.Fuchsia;
      this.lblTestYield.Name = "lblTestYield";
      this.lblTestYield.Size = new Size(54, 22);
      this.lblTestYield.Text = "test yield";
      this.ButtonPowerON.ForeColor = SystemColors.HotTrack;
      this.ButtonPowerON.Image = (Image) componentResourceManager.GetObject("ButtonPowerON.Image");
      this.ButtonPowerON.ImageTransparentColor = Color.Magenta;
      this.ButtonPowerON.Name = "ButtonPowerON";
      this.ButtonPowerON.Size = new Size(78, 22);
      this.ButtonPowerON.Text = "PowerON";
      this.ButtonPowerON.Click += new EventHandler(this.ButtonPowerON_Click);
      this.ButtonPowerOFF.ForeColor = SystemColors.HotTrack;
      this.ButtonPowerOFF.Image = (Image) componentResourceManager.GetObject("ButtonPowerOFF.Image");
      this.ButtonPowerOFF.ImageTransparentColor = Color.Magenta;
      this.ButtonPowerOFF.Name = "ButtonPowerOFF";
      this.ButtonPowerOFF.Size = new Size(81, 22);
      this.ButtonPowerOFF.Text = "PowerOFF";
      this.ButtonPowerOFF.Click += new EventHandler(this.ButtonPowerOFF_Click);
      this.ButtonBADGE.ForeColor = SystemColors.HotTrack;
      this.ButtonBADGE.Image = (Image) componentResourceManager.GetObject("ButtonBADGE.Image");
      this.ButtonBADGE.ImageTransparentColor = Color.Magenta;
      this.ButtonBADGE.Name = "ButtonBADGE";
      this.ButtonBADGE.Size = new Size(64, 22);
      this.ButtonBADGE.Text = "BADGE";
      this.ButtonBADGE.Click += new EventHandler(this.ButtonBADGE_Click);
      this.toolStripSeparator7.Alignment = ToolStripItemAlignment.Right;
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(6, 25);
      this.lblTestTime.Alignment = ToolStripItemAlignment.Right;
      this.lblTestTime.ForeColor = Color.Fuchsia;
      this.lblTestTime.Name = "lblTestTime";
      this.lblTestTime.Size = new Size(53, 22);
      this.lblTestTime.Text = "test time";
      this.menuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.mnuFile,
        (ToolStripItem) this.mnuOptions
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(1246, 24);
      this.menuStrip1.TabIndex = 4;
      this.menuStrip1.Text = "menuStrip1";
      this.mnuFile.DropDownItems.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.mnuOpenConfig,
        (ToolStripItem) this.openRMAConfigFileToolStripMenuItem,
        (ToolStripItem) this.openMonitorConfigFileToolStripMenuItem,
        (ToolStripItem) this.openGoldenSampleConfigFileToolStripMenuItem,
        (ToolStripItem) this.openTemperatureCheckConfigFileToolStripMenuItem,
        (ToolStripItem) this.mnuExit
      });
      this.mnuFile.Name = "mnuFile";
      this.mnuFile.Size = new Size(37, 20);
      this.mnuFile.Text = "&File";
      this.mnuOpenConfig.Name = "mnuOpenConfig";
      this.mnuOpenConfig.Size = new Size(270, 22);
      this.mnuOpenConfig.Text = "Open &Config File";
      this.mnuOpenConfig.Click += new EventHandler(this.mnuOpenConfig_Click);
      this.openMonitorConfigFileToolStripMenuItem.Name = "openMonitorConfigFileToolStripMenuItem";
      this.openMonitorConfigFileToolStripMenuItem.Size = new Size(270, 22);
      this.openMonitorConfigFileToolStripMenuItem.Text = "Open &Monitor Config File";
      this.openMonitorConfigFileToolStripMenuItem.Click += new EventHandler(this.openMonitorConfigFileToolStripMenuItem_Click);
      this.openGoldenSampleConfigFileToolStripMenuItem.Name = "openGoldenSampleConfigFileToolStripMenuItem";
      this.openGoldenSampleConfigFileToolStripMenuItem.Size = new Size(270, 22);
      this.openGoldenSampleConfigFileToolStripMenuItem.Text = "Open &Golden Sample Config File";
      this.openGoldenSampleConfigFileToolStripMenuItem.Click += new EventHandler(this.openGoldenSampleConfigFileToolStripMenuItem_Click);
      this.mnuExit.Name = "mnuExit";
      this.mnuExit.Size = new Size(270, 22);
      this.mnuExit.Text = "E&xit";
      this.mnuOptions.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.goldenSampleModeToolStripMenuItem,
        (ToolStripItem) this.uploadTestLogsToolStripMenuItem
      });
      this.mnuOptions.Name = "mnuOptions";
      this.mnuOptions.Size = new Size(61, 20);
      this.mnuOptions.Text = "Options";
      this.goldenSampleModeToolStripMenuItem.Name = "goldenSampleModeToolStripMenuItem";
      this.goldenSampleModeToolStripMenuItem.Size = new Size(188, 22);
      this.goldenSampleModeToolStripMenuItem.Text = "Golden Sample Mode";
      this.goldenSampleModeToolStripMenuItem.Click += new EventHandler(this.goldenSampleModeToolStripMenuItem_Click);
      this.uploadTestLogsToolStripMenuItem.Name = "uploadTestLogsToolStripMenuItem";
      this.uploadTestLogsToolStripMenuItem.Size = new Size(188, 22);
      this.uploadTestLogsToolStripMenuItem.Text = "Upload Test Logs";
      this.uploadTestLogsToolStripMenuItem.Click += new EventHandler(this.uploadTestLogsToolStripMenuItem_Click);
      this.dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGrid.Location = new Point(5, 454);
      this.dataGrid.Name = "dataGrid";
      this.dataGrid.ReadOnly = true;
      this.dataGrid.Size = new Size(1241, 141);
      this.dataGrid.TabIndex = 6;
      this.groupUUT.Controls.Add((Control) this.label3);
      this.groupUUT.Controls.Add((Control) this.txtBadge);
      this.groupUUT.Controls.Add((Control) this.btnOK);
      this.groupUUT.Controls.Add((Control) this.btnAbort);
      this.groupUUT.Controls.Add((Control) this.txtMAC);
      this.groupUUT.Controls.Add((Control) this.label1);
      this.groupUUT.Controls.Add((Control) this.label2);
      this.groupUUT.Controls.Add((Control) this.txtLabel);
      this.groupUUT.Location = new Point(7, 269);
      this.groupUUT.Name = "groupUUT";
      this.groupUUT.Size = new Size(279, 179);
      this.groupUUT.TabIndex = 1;
      this.groupUUT.TabStop = false;
      this.groupUUT.Text = "UUT";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(1, 27);
      this.label3.Name = "label3";
      this.label3.Size = new Size(44, 13);
      this.label3.TabIndex = 20;
      this.label3.Text = "BADGE";
      this.txtBadge.Location = new Point(48, 27);
      this.txtBadge.Name = "txtBadge";
      this.txtBadge.Size = new Size(217, 20);
      this.txtBadge.TabIndex = 13;
      this.txtBadge.KeyPress += new KeyPressEventHandler(this.txtBadge_KeyPress);
      this.txtBadge.Leave += new EventHandler(this.txtBadge_Leave);
      this.btnOK.Location = new Point(196, 86);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(69, 36);
      this.btnOK.TabIndex = 12;
      this.btnOK.Text = "START TEST";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.txtMAC.Location = new Point(48, 86);
      this.txtMAC.Multiline = true;
      this.txtMAC.Name = "txtMAC";
      this.txtMAC.ScrollBars = ScrollBars.Vertical;
      this.txtMAC.Size = new Size(139, 87);
      this.txtMAC.TabIndex = 6;
      this.txtMAC.KeyPress += new KeyPressEventHandler(this.txtMAC_KeyPress);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(15, 86);
      this.label1.Name = "label1";
      this.label1.Size = new Size(30, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "MAC";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 63);
      this.label2.Name = "label2";
      this.label2.Size = new Size(40, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "LABEL";
      this.txtLabel.Location = new Point(48, 56);
      this.txtLabel.Name = "txtLabel";
      this.txtLabel.Size = new Size(218, 20);
      this.txtLabel.TabIndex = 5;
      this.txtLabel.KeyPress += new KeyPressEventHandler(this.txtLabel_KeyPress);
      this.txtLabel.Leave += new EventHandler(this.txtLabel_Leave);
      this.hexBox1.Font = new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.hexBox1.LineInfoForeColor = Color.Empty;
      this.hexBox1.LineInfoVisible = true;
      this.hexBox1.Location = new Point(596, 269);
      this.hexBox1.Name = "hexBox1";
      this.hexBox1.ShadowSelectionColor = Color.FromArgb(100, 60, 188, (int) byte.MaxValue);
      this.hexBox1.Size = new Size(650, 179);
      this.hexBox1.StringViewVisible = true;
      this.hexBox1.TabIndex = 7;
      this.hexBox1.UseFixedBytesPerLine = true;
      this.hexBox1.VScrollBarVisible = true;
      this.progressBar.Location = new Point(5, 601);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new Size(1241, 15);
      this.progressBar.TabIndex = 22;
      this.groupBox1.Controls.Add((Control) this.textDiolan);
      this.groupBox1.Controls.Add((Control) this.labelDiolan);
      this.groupBox1.Controls.Add((Control) this.textMB);
      this.groupBox1.Controls.Add((Control) this.labelMB);
      this.groupBox1.Controls.Add((Control) this.textRiserCard);
      this.groupBox1.Controls.Add((Control) this.labelRiserCard);
      this.groupBox1.Controls.Add((Control) this.textTestJigWA);
      this.groupBox1.Controls.Add((Control) this.labelTestJigWA);
      this.groupBox1.Controls.Add((Control) this.textBIE);
      this.groupBox1.Controls.Add((Control) this.LabelBIE);
      this.groupBox1.Controls.Add((Control) this.textTestJig);
      this.groupBox1.Controls.Add((Control) this.LabelTestJig);
      this.groupBox1.ForeColor = SystemColors.ControlText;
      this.groupBox1.Location = new Point(295, 351);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(295, 97);
      this.groupBox1.TabIndex = 37;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "CONSUMABLES";
      this.textDiolan.Location = new Point(229, 71);
      this.textDiolan.Name = "textDiolan";
      this.textDiolan.Size = new Size(60, 20);
      this.textDiolan.TabIndex = 37;
      this.labelDiolan.AutoSize = true;
      this.labelDiolan.Location = new Point(186, 76);
      this.labelDiolan.Name = "labelDiolan";
      this.labelDiolan.Size = new Size(37, 13);
      this.labelDiolan.TabIndex = 36;
      this.labelDiolan.Text = "Diolan";
      this.textMB.Location = new Point(76, 71);
      this.textMB.Name = "textMB";
      this.textMB.Size = new Size(60, 20);
      this.textMB.TabIndex = 35;
      this.labelMB.AutoSize = true;
      this.labelMB.Location = new Point(46, 76);
      this.labelMB.Name = "labelMB";
      this.labelMB.Size = new Size(23, 13);
      this.labelMB.TabIndex = 34;
      this.labelMB.Text = "MB";
      this.textRiserCard.Location = new Point(229, 45);
      this.textRiserCard.Name = "textRiserCard";
      this.textRiserCard.Size = new Size(60, 20);
      this.textRiserCard.TabIndex = 32;
      this.labelRiserCard.AutoSize = true;
      this.labelRiserCard.Location = new Point(167, 52);
      this.labelRiserCard.Name = "labelRiserCard";
      this.labelRiserCard.Size = new Size(56, 13);
      this.labelRiserCard.TabIndex = 31;
      this.labelRiserCard.Text = "Riser Card";
      this.textTestJigWA.Location = new Point(229, 20);
      this.textTestJigWA.Name = "textTestJigWA";
      this.textTestJigWA.Size = new Size(60, 20);
      this.textTestJigWA.TabIndex = 30;
      this.labelTestJigWA.AutoSize = true;
      this.labelTestJigWA.Location = new Point(164, 23);
      this.labelTestJigWA.Name = "labelTestJigWA";
      this.labelTestJigWA.Size = new Size(59, 13);
      this.labelTestJigWA.TabIndex = 27;
      this.labelTestJigWA.Text = "TestJigWA";
      this.textBIE.Location = new Point(76, 45);
      this.textBIE.Name = "textBIE";
      this.textBIE.Size = new Size(60, 20);
      this.textBIE.TabIndex = 23;
      this.LabelBIE.AutoSize = true;
      this.LabelBIE.Location = new Point(46, 52);
      this.LabelBIE.Name = "LabelBIE";
      this.LabelBIE.Size = new Size(24, 13);
      this.LabelBIE.TabIndex = 22;
      this.LabelBIE.Text = "BIE";
      this.textTestJig.Location = new Point(76, 20);
      this.textTestJig.Name = "textTestJig";
      this.textTestJig.Size = new Size(60, 20);
      this.textTestJig.TabIndex = 10;
      this.LabelTestJig.AutoSize = true;
      this.LabelTestJig.Location = new Point(26, 23);
      this.LabelTestJig.Name = "LabelTestJig";
      this.LabelTestJig.Size = new Size(44, 13);
      this.LabelTestJig.TabIndex = 9;
      this.LabelTestJig.Text = "Test Jig";
      this.textTotalTestThreshold.Location = new Point(110, 20);
      this.textTotalTestThreshold.Name = "textTotalTestThreshold";
      this.textTotalTestThreshold.Size = new Size(61, 20);
      this.textTotalTestThreshold.TabIndex = 38;
      this.textTotalPassed.Location = new Point(77, 49);
      this.textTotalPassed.Name = "textTotalPassed";
      this.textTotalPassed.Size = new Size(60, 20);
      this.textTotalPassed.TabIndex = 39;
      this.textTotalFailed.Location = new Point(228, 49);
      this.textTotalFailed.Name = "textTotalFailed";
      this.textTotalFailed.Size = new Size(61, 20);
      this.textTotalFailed.TabIndex = 40;
      this.textLastError.Location = new Point(229, 20);
      this.textLastError.Name = "textLastError";
      this.textLastError.Size = new Size(60, 20);
      this.textLastError.TabIndex = 41;
      this.lblTotalTestThreshold.AutoSize = true;
      this.lblTotalTestThreshold.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblTotalTestThreshold.Location = new Point(6, 26);
      this.lblTotalTestThreshold.Name = "lblTotalTestThreshold";
      this.lblTotalTestThreshold.Size = new Size(105, 13);
      this.lblTotalTestThreshold.TabIndex = 43;
      this.lblTotalTestThreshold.Text = "Total Test Threshold";
      this.lblTotalPassed.AutoSize = true;
      this.lblTotalPassed.Location = new Point(6, 55);
      this.lblTotalPassed.Name = "lblTotalPassed";
      this.lblTotalPassed.Size = new Size(69, 13);
      this.lblTotalPassed.TabIndex = 44;
      this.lblTotalPassed.Text = "Total Passed";
      this.lblLastError.AutoSize = true;
      this.lblLastError.Location = new Point(170, 26);
      this.lblLastError.Name = "lblLastError";
      this.lblLastError.Size = new Size(52, 13);
      this.lblLastError.TabIndex = 45;
      this.lblLastError.Text = "Last Error";
      this.lblTotalFailed.AutoSize = true;
      this.lblTotalFailed.Location = new Point(160, 55);
      this.lblTotalFailed.Name = "lblTotalFailed";
      this.lblTotalFailed.Size = new Size(62, 13);
      this.lblTotalFailed.TabIndex = 46;
      this.lblTotalFailed.Text = "Total Failed";
      this.groupBox2.Controls.Add((Control) this.lblTotalTestThreshold);
      this.groupBox2.Controls.Add((Control) this.textTotalPassed);
      this.groupBox2.Controls.Add((Control) this.lblTotalFailed);
      this.groupBox2.Controls.Add((Control) this.lblTotalPassed);
      this.groupBox2.Controls.Add((Control) this.textLastError);
      this.groupBox2.Controls.Add((Control) this.lblLastError);
      this.groupBox2.Controls.Add((Control) this.textTotalTestThreshold);
      this.groupBox2.Controls.Add((Control) this.textTotalFailed);
      this.groupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.groupBox2.Location = new Point(295, 265);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(295, 80);
      this.groupBox2.TabIndex = 48;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "TEST YIELD";
      this.openRMAConfigFileToolStripMenuItem.Name = "openRMAConfigFileToolStripMenuItem";
      this.openRMAConfigFileToolStripMenuItem.Size = new Size(270, 22);
      this.openRMAConfigFileToolStripMenuItem.Text = "Open &RMA Config File";
      this.openRMAConfigFileToolStripMenuItem.Click += new EventHandler(this.openRMAConfigFileToolStripMenuItem_Click);
      this.openTemperatureCheckConfigFileToolStripMenuItem.Name = "openTemperatureCheckConfigFileToolStripMenuItem";
      this.openTemperatureCheckConfigFileToolStripMenuItem.Size = new Size(270, 22);
      this.openTemperatureCheckConfigFileToolStripMenuItem.Text = "Open &Temperature Check Config File";
      this.openTemperatureCheckConfigFileToolStripMenuItem.Click += new EventHandler(this.openTemperatureCheckConfigFileToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1246, 641);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.progressBar);
      this.Controls.Add((Control) this.hexBox1);
      this.Controls.Add((Control) this.groupUUT);
      this.Controls.Add((Control) this.dataGrid);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.txtTerminal);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.menuStrip1);
      this.Controls.Add((Control) this.groupTest);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = nameof (soteDiag);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (soteDiag);
      this.FormClosing += new FormClosingEventHandler(this.soteDiag_FormClosing);
      this.Load += new EventHandler(this.soteDiag_Load);
      this.groupTest.ResumeLayout(false);
      this.groupTest.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((ISupportInitialize) this.dataGrid).EndInit();
      this.groupUUT.ResumeLayout(false);
      this.groupUUT.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public soteDiag()
    {
      if (!this.DesignMode)
      {
        string executablePath = Application.ExecutablePath;
        string path = executablePath.Substring(0, executablePath.Length - 4) + ".ini";
        if (File.Exists(path))
          IniFile.FileName = path;
      }
      this.InitializeComponent();
      this.goldenSampleModeToolStripMenuItem.Checked = false;
      this.uploadTestLogsToolStripMenuItem.Enabled = false;
      this.FxcnSfcListenerSMO = soteLib.soteSFIS2.soteSFIS2.Create();
      this.FxcnSfcListenerSMO.Connected += new SfisConnectionChanged(this.FxcnSfcListenerSMO_OnConnected);
      this.FxcnSfcListenerSMO.Disconnected += new SfisConnectionChanged(this.FxcnSfcListenerSMO_OnDisconnected);
      this.FxcnSfcListenerSMO.SfisLog += new SfisLog(this.FxcnSfcListenerSMO_OnLog);
    }

    public static void tolog(string fn, string msg)
    {
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(fn))
          streamWriter.Write(msg);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void FxcnSfcListenerSMO_OnConnected(IsoteSFIS2 obj)
    {
      this.Invoke((Delegate) (() =>
      {
        Color lime = Color.Lime;
        if (obj.GetType() == typeof (soteSFIS2Fxcn))
          this.LabelSFISLinkStatus.Text = "Connected from " + ((soteSFIS2Fxcn) obj).RemoteEndPoint.ToString();
        else
          this.LabelSFISLinkStatus.Text = "Connected";
        this.TextSFISMessage.Enabled = true;
      }));
    }

    private void FxcnSfcListenerSMO_OnDisconnected(IsoteSFIS2 obj)
    {
      this.Invoke((Delegate) (() =>
      {
        if (this.FxcnSfcListenerSMO.GetType() == typeof (soteSFIS2Fxcn))
          this.LabelSFISLinkStatus.Text = "Waiting for connection on port " + (object) ((soteSFIS2Fxcn) this.FxcnSfcListenerSMO).Port + " ...";
        else
          this.LabelSFISLinkStatus.Text = "Disconnected";
        this.TextSFISMessage.Enabled = false;
      }));
    }

    private void FxcnSfcListenerSMO_OnLog(IsoteSFIS2 obj, string rawMessage, string displayMessage)
    {
      if (this.TextSFISLog.InvokeRequired)
        this.Invoke((Delegate) (() => this.TextSFISLog.AppendText(displayMessage + Environment.NewLine)));
      else
        this.TextSFISLog.AppendText(displayMessage + Environment.NewLine);
    }

    private void cboDiagPort_Click(object sender, EventArgs e)
    {
      string[] strArray = this.m_commport.AvailablePorts();
      this.cboDiagPort.Items.Clear();
      for (int index = 0; index < strArray.Length; ++index)
        this.cboDiagPort.Items.Add((object) strArray[index]);
      if (this.cboDiagPort.Items.Count != 0)
        return;
      soteDiag.soteDiag.showFailMsgDlg("COMM PORT NOT AVAILABLE");
    }

    private void soteDiag_Load(object sender, EventArgs e)
    {
      this.lblTestStation.Text = Environment.MachineName;
      this.lblTestDate.Text = DateTime.Now.ToShortDateString();
      this.lblHardwareType.Text = "Ethernet";
      this.Text = soteDiag.soteDiag.appName + " V" + soteDiag.soteDiag.appVersion;
      this.m_commport = new CommPort();
      this.cboDiagPort_Click(sender, e);
      if (this.cboDiagPort.Items.Count > 0)
        this.cboDiagPort.SelectedIndex = 0;
      this.cbButtonPowerON(true);
      this.cbButtonPowerOFF(true);
      this.cbButtonBADGE(true);
      if (!this.loadConfig())
      {
        Application.Exit();
      }
      else
      {
        this.dataGrid.TopLeftHeaderCell.Value = (object) "#";
        this.dataGrid.RowHeadersWidth = 40;
        this.dataGrid.Columns.Add("colDate", "DATE");
        this.dataGrid.Columns["colDate"].Width = 65;
        this.dataGrid.Columns.Add("colSerial", "SN #");
        this.dataGrid.Columns["colSerial"].Width = 170;
        this.dataGrid.Columns.Add("colStatus", "P/F");
        this.dataGrid.Columns["colStatus"].Width = 40;
        this.dataGrid.Columns.Add("colErrorCode", "ERROR #");
        this.dataGrid.Columns["colErrorCode"].Width = 70;
        this.dataGrid.Columns.Add("colErrorDescription", "TEST SUMMARY");
        this.dataGrid.Columns["colErrorDescription"].Width = 855;
        this.cbUUTGroup(false);
        this.cbChkSFIS(false);
        IniFile.FileName = soteDiag.soteDiag.appConfig;
        this.btnAbort.Enabled = false;
        this.Refresh();
        this.info["Retest"] = (string) null;
        this.info["MO_Number"] = (string) null;
        if (this.FxcnSfcListenerSMO.GetType() == typeof (soteSFIS2Fxcn))
          this.LabelSFISLinkStatus.Text = "Waiting for connection on port " + (object) ((soteSFIS2Fxcn) this.FxcnSfcListenerSMO).Port + " ...";
        this.FxcnSfcListenerSMO.Open();
        this.btnStart_Click(sender, e);
      }
    }

    private bool loadConfig()
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      this.m_bFirsttime = true;
      if (IniFile.GetProfile("TEST SETUP", "TestMode") == "PRODUCTION")
      {
        this.m_TestMode = 1;
        this.m_sTestMode = "PRODUCTION";
        this.cblblTestMode("PRODUCTION");
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "PRODUCTION_ERASENVRAM")
      {
        this.m_TestMode = 9;
        this.m_sTestMode = "PRODUCTION_ERASENVRAM";
        this.cblblTestMode("PRODUCTION_ERASENVRAM");
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "OBA")
      {
        this.m_TestMode = 2;
        this.m_sTestMode = "OBA";
        this.cblblTestMode("OBA");
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "FAI")
      {
        this.m_TestMode = 6;
        this.m_sTestMode = "FAI";
        this.cblblTestMode("FAI");
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "GOLDENSAMPLE")
      {
        this.m_TestMode = 7;
        this.m_sTestMode = "GOLDENSAMPLE";
        this.cblblTestMode("GOLDENSAMPLE");
        this.goldenSampleModeToolStripMenuItem.Checked = true;
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "STRESS")
      {
        this.m_TestMode = 5;
        this.m_sTestMode = "STRESS";
        this.cblblTestMode("STRESS");
        this.m_TestLoop = Convert.ToInt32(IniFile.GetProfile("TEST SETUP", "TestLoop", "1"));
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "STRESS_STOPONFAIL")
      {
        this.m_bStopOnFail = true;
        this.m_TestMode = 5;
        this.m_sTestMode = "STRESS";
        this.cblblTestMode("STRESS_STOPONFAIL");
        this.m_TestLoop = Convert.ToInt32(IniFile.GetProfile("TEST SETUP", "TestLoop", "1"));
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "STRESS_STOPONFAIL_POWERON")
      {
        this.m_bStopOnFail = true;
        this.m_bStopOnFail_poweron = true;
        this.m_TestMode = 5;
        this.m_sTestMode = "STRESS";
        this.cblblTestMode("STRESS_STOPONFAIL_POWERON");
        this.m_TestLoop = Convert.ToInt32(IniFile.GetProfile("TEST SETUP", "TestLoop", "1"));
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "RMA")
      {
        this.m_TestMode = 8;
        this.m_sTestMode = "RMA";
        this.cblblTestMode("RMA");
        this.m_sfis_enabled = false;
      }
      else if (IniFile.GetProfile("TEST SETUP", "TestMode") == "ESR_GENERIC")
      {
        this.m_TestMode = 10;
        this.m_sTestMode = "ESR_GENERIC";
        this.cblblTestMode("ESR_GENERIC");
      }
      this.m_DefaultTestMode = this.m_TestMode;
      this.m_sDefaultTestMode = this.m_sTestMode;
      if (IniFile.GetProfile("STRESS TEST OPTION", "ERASENVRAM") == "DISABLED")
        this.m_bERASENVRAMEnabled = false;
      if (IniFile.GetProfile("STRESS TEST OPTION", "FCT") == "DISABLED")
        this.m_bFCTEnabled = false;
      if (IniFile.GetProfile("STRESS TEST OPTION", "LOOPBACK") == "DISABLED")
        this.m_bLOOPBACKEnabled = false;
      if (IniFile.GetProfile("STRESS TEST OPTION", "PROGRAMFRU") == "DISABLED")
        this.m_bProgramFRUEnabled = false;
      if (IniFile.GetProfile("STRESS TEST OPTION", "NVRAMVERIFY") == "DISABLED")
        this.m_bNVRAMVerifyEnabled = false;
      if (IniFile.GetProfile("STRESS TEST OPTION", "FRUVERIFY") == "DISABLED")
        this.m_bFRUVerifyEnabled = false;
      if (IniFile.GetProfile("STRESS TEST OPTION", "NCSI") == "DISABLED")
        this.m_bNCSIEnabled = false;
      this.logDir = IniFile.GetProfile("TEST SETUP", "LOG_DIR", Directory.GetCurrentDirectory());
      this.logDefault = IniFile.GetProfile("TEST SETUP", "LOG_DIR", Directory.GetCurrentDirectory());
      if (!this.logDir.EndsWith("\\"))
        this.logDir += "\\";
      if (!this.logDefault.EndsWith("\\"))
        this.logDefault += "\\";
      if (IniFile.GetProfile("TEST SETUP", "USBDIOENABLE") == "TRUE")
        this.m_usbdioenable = true;
      if (IniFile.GetProfile("TEST SETUP", "DUALUSBDIO") == "TRUE")
        this.m_usbdiodual = true;
      if (IniFile.GetProfile("TEST SETUP", "BUILTIN_BIE") == "TRUE")
        this.m_builtin_BIE = true;
      this.m_dutport = IniFile.GetProfile("TEST SETUP", "DUT_PORT");
      this.m_dutcomVal = (int) Convert.ToInt16(this.m_dutport.Substring(3, this.m_dutport.Length - 3), 16);
      if (IniFile.GetProfile("TEST SETUP", "SFIS_TYPE") == "ESR")
      {
        this.m_sfis_type = 90;
        this.TextSFISLog.Enabled = false;
        this.TextSFISMessage.Enabled = false;
        this.LabelSFISLinkStatus.Enabled = false;
        this.uploadTestLogsToolStripMenuItem.Enabled = true;
      }
      if (IniFile.GetProfile("TEST SETUP", "USBRELAYENABLE") == "TRUE")
        this.m_usbrelayenable = true;
      this.m_usbdioport1 = IniFile.GetProfile("TEST SETUP", "USBDIO_PORT1");
      this.m_usbdioport2 = IniFile.GetProfile("TEST SETUP", "USBDIO_PORT2");
      this.m_usbrelayport = IniFile.GetProfile("TEST SETUP", "USBRELAY_PORT");
      string profile = IniFile.GetProfile("TEST SETUP", "HOST_PORT");
      if (this.cboDiagPort.Items.Contains((object) profile))
      {
        this.cboDiagPort.Text = profile;
        this.cboDiagPort.Enabled = false;
        this.m_network_adapter = IniFile.GetProfile("TEST SETUP", "NETWORK_ADAPTER");
        this.m_duttype = IniFile.GetProfile("TEST SETUP", "DUT_TYPE");
        this.m_DOSPC_BOOTUP_TIMER = Convert.ToInt32(IniFile.GetProfile("TEST SETUP", "DOSPC_BOOTUP_TIMER", "60"));
        this.I2CAdapterType = IniFile.GetProfile("FRU SETUP", "I2CMODE");
        this.comPort = (int) Convert.ToInt16(IniFile.GetProfile("FRU SETUP", "COM_PORT", "1"));
        this.m_esr_sfis_log_dir = IniFile.GetProfile("ESR SHOPFLOOR", "SFIS_LOG_DIR");
        if (this.m_sfis_type == 90)
        {
          this.m_esr_pid = IniFile.GetProfile("ESR SHOPFLOOR", "PID");
          this.m_esr_tester = IniFile.GetProfile("ESR SHOPFLOOR", "TESTER");
          this.m_esr_assy_number = IniFile.GetProfile("ESR SHOPFLOOR", "ASSY_NUMBER");
          this.m_esr_employee = IniFile.GetProfile("ESR SHOPFLOOR", "EMPLOYEE");
          this.m_esr_email = IniFile.GetProfile("ESR SHOPFLOOR", "EMAIL");
          this.m_esr_comments = IniFile.GetProfile("ESR SHOPFLOOR", "COMMENTS");
          this.m_esr_customer = IniFile.GetProfile("ESR SHOPFLOOR", "CUSTOMER");
          this.m_esr_chipnumber = IniFile.GetProfile("ESR SHOPFLOOR", "CHIPNUMBER");
          this.m_esr_chiprev = IniFile.GetProfile("ESR SHOPFLOOR", "CHIPREV");
          this.m_esr_chipid = IniFile.GetProfile("ESR SHOPFLOOR", "CHIPID");
          this.m_esr_requester = IniFile.GetProfile("ESR SHOPFLOOR", "REQUESTER");
          this.m_esr_assyrev = IniFile.GetProfile("ESR SHOPFLOOR", "ASSYREV");
          this.m_esr_BC = IniFile.GetProfile("ESR SHOPFLOOR", "BC");
          this.m_esr_Engineering_Diagnostics = IniFile.GetProfile("ESR SHOPFLOOR", "TESTAPP");
          this.m_esr_Stride = (int) Convert.ToInt16(IniFile.GetProfile("ESR SHOPFLOOR", "STRIDE", "1"));
          this.m_esr_Ports = (int) Convert.ToInt16(IniFile.GetProfile("ESR SHOPFLOOR", "PORT_COUNT", "1"));
          this.m_esr_LogFile = IniFile.GetProfile("ESR SHOPFLOOR", "LOG_FILE");
          this.m_esr_ImgFile = IniFile.GetProfile("ESR SHOPFLOOR", "IMG_FILE");
          if (IniFile.GetProfile("ESR SHOPFLOOR", "NPAR") == "TRUE")
            this.m_esr_bNPAR = true;
          if (this.m_esr_ImgFile.Length > 12)
          {
            soteDiag.soteDiag.showFailMsgDlg(string.Format("The NVRAM IMAGE filename {0} is too long! \n\nRename the filename to be 8 characters the max\n\n", (object) this.m_esr_ImgFile));
            return false;
          }
          if (IniFile.GetProfile("ESR SHOPFLOOR", "SFIS_ENABLE") == "TRUE")
          {
            this.m_esr_sfis_enabled = true;
            this.chkSFIS.Checked = true;
            soteDiag.soteDiag.appESR = soteDiag.soteDiag.appPath + "\\" + this.m_esr_pid + ".ini";
            this.createPIDFile(soteDiag.soteDiag.appESR);
          }
          else
          {
            this.m_esr_sfis_enabled = false;
            this.chkSFIS.Checked = false;
            this.txtBadge.Enabled = false;
          }
        }
        else if (IniFile.GetProfile("SHOPFLOOR", "SFIS_ENABLE") == "TRUE" && this.m_TestMode != 8)
        {
          this.chkSFIS.Checked = true;
          this.TextSFISLog.Enabled = true;
          this.TextSFISMessage.Enabled = true;
          this.LabelSFISLinkStatus.Enabled = true;
          this.m_fixture_id = IniFile.GetProfile("SHOPFLOOR", "FIXTURE_ID");
          this.m_line = IniFile.GetProfile("SHOPFLOOR", "LINE");
          this.m_sfis_log_dir = IniFile.GetProfile("SHOPFLOOR", "SFIS_LOG_DIR");
          this.m_test_station = IniFile.GetProfile("SHOPFLOOR", "Test_Station");
          this.m_emp_number = IniFile.GetProfile("SHOPFLOOR", "EMP_NUMBER");
          if (this.m_emp_number != "SCAN")
          {
            this.txtBadge.Text = this.m_emp_number;
            this.txtBadge.Enabled = false;
          }
        }
        else
        {
          this.chkSFIS.Checked = false;
          this.TextSFISLog.Enabled = false;
          this.TextSFISMessage.Enabled = false;
          this.LabelSFISLinkStatus.Enabled = false;
          this.txtBadge.Enabled = false;
        }
        if (this.m_TestMode == 10)
        {
          if (this.m_duttype.Length < 14)
          {
            soteDiag.soteDiag.showFailMsgDlg(string.Format(string.Format("Invalid DUT_TYPE!  Set DUT_TYPE=BCM9#", (object) true)));
            return false;
          }
          this.m_duttype = this.m_duttype.Substring(9, 5);
          if (this.m_sfis_type != 90)
          {
            soteDiag.soteDiag.showFailMsgDlg(string.Format(string.Format("Invalid SFIS_TYPE!  Set SFIS_TYPE=ESR", (object) true)));
            return false;
          }
          if (!this.m_esr_sfis_enabled)
          {
            soteDiag.soteDiag.showFailMsgDlg(string.Format(string.Format("ESR_SHOPFLOOR is NOT enabled!  Set SFIS_ENABLE=TRUE", (object) true)));
            return false;
          }
        }
        bool flag1;
        if (!(flag1 = this.loadConsumableConfig()))
          return flag1;
        bool flag2;
        if (!(flag2 = this.loadYieldTrackingConfig()))
          return flag2;
        bool flag3;
        if (this.m_TestMode == 8 && !(flag3 = this.loadRMAConfig()))
          return flag3;
        bool flag4;
        return !(flag4 = this.loadTMPCheckConfig()) ? flag4 : flag4;
      }
      soteDiag.soteDiag.showFailMsgDlg(string.Format("Invalid COMPORT selected {0}", (object) profile));
      return false;
    }

    private bool loadRMAConfig()
    {
      bool flag = true;
      IniFile.FileName = soteDiag.soteDiag.appRMAConfig;
      this.m_nRMATestLoop = Convert.ToInt32(IniFile.GetProfile("RMA TEST OPTION", "TESTLOOP", "1"));
      this.m_bRMAMACSNVerify = !(IniFile.GetProfile("RMA TEST OPTION", "MACSNVERIFY") == "DISABLED");
      this.m_bRMAStopOnFailure = !(IniFile.GetProfile("RMA TEST OPTION", "STOPONFAILURE") == "DISABLED");
      this.m_bRMAFCT = !(IniFile.GetProfile("RMA TEST OPTION", "FCT") == "DISABLED");
      this.m_bRMAEraseNVRAM = !(IniFile.GetProfile("RMA TEST OPTION", "ERASENVRAM") == "DISABLED");
      this.m_bRMAProgramNVRAM = !(IniFile.GetProfile("RMA TEST OPTION", "PROGRAMNVRAM") == "DISABLED");
      this.m_bRMANVRAMVerify = !(IniFile.GetProfile("RMA TEST OPTION", "NVRAMVERIFY") == "DISABLED");
      this.m_bRMAProgramFRU = !(IniFile.GetProfile("RMA TEST OPTION", "PROGRAMFRU") == "DISABLED");
      this.m_bRMAFRUVerify = !(IniFile.GetProfile("RMA TEST OPTION", "FRUVERIFY") == "DISABLED");
      this.m_bRMANCSI = !(IniFile.GetProfile("RMA TEST OPTION", "NCSI") == "DISABLED");
      this.m_sfis_enabled = false;
      return flag;
    }

    private bool loadTMPCheckConfig()
    {
      bool flag = true;
      IniFile.FileName = soteDiag.soteDiag.appTMPCheckConfig;
      this.m_bTMPCheckVerify = IniFile.GetProfile("TEMPERATURE CHECK OPTION", "TEMPERATURE_CHECK_ENABLED") == "TRUE";
      this.m_dMax_Temperature_Threshold = Convert.ToDouble(IniFile.GetProfile("TEMPERATURE CHECK OPTION", "TEMPERATURE_MAX_THRESHOLD", "0.0"));
      return flag;
    }

    private bool loadFwCheckConfig(string hw_type)
    {
      bool flag = true;
      IniFile.FileName = soteDiag.soteDiag.appFwCheck;
      this.m_Total_FW_Check = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "TOTAL_FW_CHECK", "0"));
      this.m_esr_Engineering_Diagnostics = IniFile.GetProfile(hw_type, "Engineering_Diagnostics");
      this.m_esr_b57Engineering_Diagnostics = IniFile.GetProfile(hw_type, "b57Engineering_Diagnostics");
      this.m_b57BootCode = IniFile.GetProfile(hw_type, "b57BootCode");
      this.m_b57APE_Firmware = IniFile.GetProfile(hw_type, "b57APE_Firmware");
      this.m_b57CCM = IniFile.GetProfile(hw_type, "b57CCM");
      this.m_b57PXE = IniFile.GetProfile(hw_type, "b57PXE ");
      this.m_b57EFI = IniFile.GetProfile(hw_type, "b57EFI");
      this.m_b57iSCSI_Boot = IniFile.GetProfile(hw_type, "b57iSCSI_Boot");
      this.m_b57iSCSI_CFG = IniFile.GetProfile(hw_type, "b57iSCSI_CFG");
      this.m_b57iSCSI_CFG_1 = IniFile.GetProfile(hw_type, "b57iSCSI_CFG_1");
      this.m_b57iSCSI_CFG_2 = IniFile.GetProfile(hw_type, "b57iSCSI_CFG_2");
      this.m_b57iSCSI_CFG_3 = IniFile.GetProfile(hw_type, "b57iSCSI_CFG_3");
      this.m_BootCode = IniFile.GetProfile(hw_type, "BootCode");
      this.m_PXE = IniFile.GetProfile(hw_type, "PXE ");
      this.m_EFI = IniFile.GetProfile(hw_type, "EFI");
      this.m_APE_Firmware = IniFile.GetProfile(hw_type, "APE_Firmware");
      this.m_iSCSI_Boot = IniFile.GetProfile(hw_type, "iSCSI_Boot");
      this.m_iSCSI_CFG = IniFile.GetProfile(hw_type, "iSCSI_CFG");
      this.m_iSCSI_CFG_1 = IniFile.GetProfile(hw_type, "iSCSI_CFG_1");
      this.m_iSCSI_CFG_2 = IniFile.GetProfile(hw_type, "iSCSI_CFG_2");
      this.m_iSCSI_CFG_3 = IniFile.GetProfile(hw_type, "iSCSI_CFG_3");
      this.m_CCM = IniFile.GetProfile(hw_type, "CCM");
      this.m_CFW = IniFile.GetProfile(hw_type, "CFW");
      this.m_CFW2 = IniFile.GetProfile(hw_type, "CFW2");
      this.m_CFWP = IniFile.GetProfile(hw_type, "CFWP");
      this.m_BFW = IniFile.GetProfile(hw_type, "BFW");
      this.m_PCIE = IniFile.GetProfile(hw_type, "PCIE").ToUpper();
      this.m_MBA = IniFile.GetProfile(hw_type, "MBA");
      this.m_PCFG00 = IniFile.GetProfile(hw_type, "PCFG00").ToUpper();
      this.m_PCFG01 = IniFile.GetProfile(hw_type, "PCFG01").ToUpper();
      this.m_FCFG00 = IniFile.GetProfile(hw_type, "FCFG00").ToUpper();
      this.m_FCFG01 = IniFile.GetProfile(hw_type, "FCFG01").ToUpper();
      this.m_SCFG = IniFile.GetProfile(hw_type, "SCFG").ToUpper();
      this.m_DEV0_CFG = IniFile.GetProfile(hw_type + "-PreProgramFWCheck", "DEV0CFG");
      this.m_DEV1_CFG = IniFile.GetProfile(hw_type + "-PreProgramFWCheck", "DEV1CFG");
      this.m_DEV2_CFG = IniFile.GetProfile(hw_type + "-PreProgramFWCheck", "DEV2CFG");
      this.m_DEV3_CFG = IniFile.GetProfile(hw_type + "-PreProgramFWCheck", "DEV3CFG");
      this.m_FW_Version = IniFile.GetProfile(hw_type + "-PreProgramFWCheck", "FWVersion");
      this.m_MBA_CHKSUM = IniFile.GetProfile(hw_type, "MBACHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "MBACHKSUM").ToUpper() : "N/A";
      this.m_CCM_CHKSUM = IniFile.GetProfile(hw_type, "CCMCHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "CCMCHKSUM").ToUpper() : "N/A";
      this.m_CFW_CHKSUM = IniFile.GetProfile(hw_type, "CFWCHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "CFWCHKSUM").ToUpper() : "N/A";
      this.m_CFW2_CHKSUM = IniFile.GetProfile(hw_type, "CFW2CHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "CFW2CHKSUM").ToUpper() : "N/A";
      this.m_CFWP_CHKSUM = IniFile.GetProfile(hw_type, "CFWPCHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "CFWPCHKSUM").ToUpper() : "N/A";
      this.m_AFW_CHKSUM = IniFile.GetProfile(hw_type, "AFWCHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "AFWCHKSUM").ToUpper() : "N/A";
      this.m_BFW_CHKSUM = IniFile.GetProfile(hw_type, "BFWCHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "BFWCHKSUM").ToUpper() : "N/A";
      this.m_TSCF_CHKSUM = IniFile.GetProfile(hw_type, "TSCFCHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "TSCFCHKSUM").ToUpper() : "N/A";
      this.m_IBOOT_CHKSUM = IniFile.GetProfile(hw_type, "IBOOTCHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "IBOOTCHKSUM").ToUpper() : "N/A";
      this.m_IBCFG00_CHKSUM = IniFile.GetProfile(hw_type, "IBCFG00CHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "IBCFG00CHKSUM").ToUpper() : "N/A";
      this.m_IBCFG01_CHKSUM = IniFile.GetProfile(hw_type, "IBCFG01CHKSUM").ToUpper() != "" ? IniFile.GetProfile(hw_type, "IBCFG01CHKSUM").ToUpper() : "N/A";
      return flag;
    }

    private bool loadConsumableConfig()
    {
      bool flag = true;
      IniFile.FileName = soteDiag.soteDiag.appMonitor;
      if (IniFile.GetProfile("CONSUMABLE TRACKING", "CONSUMABLE_TRACKING_ENABLED") == "TRUE")
        this.m_ConsumableTracking_enabled = true;
      this.m_TestJig_Current_Count = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "TESTJIG_CURRENT_COUNT", "0"));
      this.m_TestJig_Lifecycle = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "TESTJIG_LIFECYCLE", "0"));
      this.cbtextTestJig(Convert.ToString(this.m_TestJig_Current_Count));
      Color foreColor;
      Color backColor;
      this.UpdateDisplayColor(this.m_TestJig_Current_Count, this.m_TestJig_Lifecycle, out foreColor, out backColor);
      this.cbtextTestJigColor(this.ForeColor, this.BackColor);
      this.m_BIE_Current_Count = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "BIE_CURRENT_COUNT", "0"));
      this.m_BIE_Lifecycle = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "BIE_LIFECYCLE", "0"));
      this.cbtextBIE(Convert.ToString(this.m_BIE_Current_Count));
      this.UpdateDisplayColor(this.m_BIE_Current_Count, this.m_BIE_Lifecycle, out foreColor, out backColor);
      this.cbtextBIEColor(this.ForeColor, this.BackColor);
      this.m_TestJig_WearOut_Adapter_Current_Count = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "TESTJIG_WEAROUT_ADAPTER_CURRENT_COUNT", "0"));
      this.m_TestJig_WearOut_Adapter_Lifecycle = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "TESTJIG_WEAROUT_ADAPTER_LIFECYCLE", "0"));
      this.cbtextTestJigWA(Convert.ToString(this.m_TestJig_WearOut_Adapter_Current_Count));
      this.UpdateDisplayColor(this.m_TestJig_WearOut_Adapter_Current_Count, this.m_TestJig_WearOut_Adapter_Lifecycle, out foreColor, out backColor);
      this.cbtextTestJigWAColor(this.ForeColor, this.BackColor);
      this.m_RiserCard_Current_Count = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "RISERCARD_CURRENT_COUNT", "0"));
      this.m_RiserCard_Lifecycle = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "RISERCARD_LIFECYCLE", "0"));
      this.cbtextRiserCard(Convert.ToString(this.m_RiserCard_Current_Count));
      this.UpdateDisplayColor(this.m_RiserCard_Current_Count, this.m_RiserCard_Lifecycle, out foreColor, out backColor);
      this.cbtextRiserCardColor(this.ForeColor, this.BackColor);
      this.m_MB_Current_Count = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "MOTHERBOARD_CURRENT_COUNT", "0"));
      this.m_MB_Lifecycle = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "MOTHERBOARD_LIFECYCLE", "0"));
      this.cbtextMB(Convert.ToString(this.m_MB_Current_Count));
      this.UpdateDisplayColor(this.m_MB_Current_Count, this.m_MB_Lifecycle, out foreColor, out backColor);
      this.cbtextMBColor(this.ForeColor, this.BackColor);
      this.m_Diolan_Current_Count = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "DIOLAN_CURRENT_COUNT", "0"));
      this.m_Diolan_Lifecycle = Convert.ToInt32(IniFile.GetProfile("CONSUMABLE TRACKING", "DIOLAN_LIFECYCLE", "0"));
      if (this.I2CAdapterType != "DLN-2")
      {
        this.cbtextDiolan("N/A");
        this.cbtextDiolanColor(Color.Black, Color.White);
      }
      else
      {
        this.cbtextDiolan(Convert.ToString(this.m_Diolan_Current_Count));
        this.UpdateDisplayColor(this.m_Diolan_Current_Count, this.m_Diolan_Lifecycle, out foreColor, out backColor);
        this.cbtextDiolanColor(this.ForeColor, this.BackColor);
      }
      if (this.m_ConsumableTracking_enabled)
      {
        if (this.m_TestJig_WearOut_Adapter_Current_Count >= this.m_TestJig_WearOut_Adapter_Lifecycle)
        {
          int num = (int) new frmFail()
          {
            Message = string.Format("Test Jig WearOut Adapter has reached\nits life cycle of {0} times.!\n\nPlease replace with a new test Jig\nWearOut Adapter!", (object) this.m_TestJig_WearOut_Adapter_Lifecycle)
          }.ShowDialog();
          this.m_userabort = true;
          return false;
        }
        if (this.m_RiserCard_Current_Count >= this.m_RiserCard_Lifecycle)
        {
          int num = (int) new frmFail()
          {
            Message = string.Format("Riser Card has reached its life cycle\nof {0} times.!\n\nPlease replace with a new Riser Card!", (object) this.m_RiserCard_Lifecycle)
          }.ShowDialog();
          this.m_userabort = true;
          return false;
        }
      }
      return flag;
    }

    private bool loadYieldTrackingConfig()
    {
      bool flag = true;
      IniFile.FileName = soteDiag.soteDiag.appMonitor;
      if (IniFile.GetProfile(this.m_sTestMode + " MODE YIELD TRACKING", this.m_sTestMode + "_YIELD_TRACKING_ENABLED") == "TRUE")
        this.m_YieldTracking_enabled = true;
      this.m_TestYield_Expected = Convert.ToDouble(IniFile.GetProfile(this.m_sTestMode + " MODE YIELD TRACKING", this.m_sTestMode + "_TEST_YIELD_THRESHOLD", "0"));
      this.m_Total_Test_Threshold = Convert.ToInt32(IniFile.GetProfile(this.m_sTestMode + " MODE YIELD TRACKING", this.m_sTestMode + "_TOTAL_TEST_THRESHOLD", "0"));
      this.cbtextTotalTestThreshold(Convert.ToString(this.m_Total_Test_Threshold));
      this.cbtextTotalTestThresholdColor(Color.Black, Color.LightGreen);
      this.m_Total_Passed = Convert.ToInt32(IniFile.GetProfile(this.m_sTestMode + " MODE YIELD TRACKING", this.m_sTestMode + "_TOTAL_PASSED", "0"));
      this.cbtextTotalPassed(Convert.ToString(this.m_Total_Passed));
      this.cbtextTotalPassedColor(Color.Black, Color.LightGreen);
      this.m_Total_Failed = Convert.ToInt32(IniFile.GetProfile(this.m_sTestMode + " MODE YIELD TRACKING", this.m_sTestMode + "_TOTAL_FAILED", "0"));
      this.cbtextTotalFailed(Convert.ToString(this.m_Total_Failed));
      if (this.m_Total_Failed == 0)
        this.cbtextTotalFailedColor(Color.Black, Color.LightGreen);
      else
        this.cbtextTotalFailedColor(Color.White, Color.Red);
      this.m_Failed_Count = Convert.ToInt32(IniFile.GetProfile(this.m_sTestMode + " MODE YIELD TRACKING", this.m_sTestMode + "_FAILED_COUNT", "0"));
      this.m_Failed_Count_Max_Allowed = Convert.ToInt32(IniFile.GetProfile(this.m_sTestMode + " MODE YIELD TRACKING", this.m_sTestMode + "_FAILED_COUNT_MAX_ALLOWED", "0"));
      if (this.m_Total_Passed + this.m_Total_Failed == 0)
      {
        this.cblblTestYield(this.m_TestYield.ToString("N/A"));
      }
      else
      {
        this.m_TestYield = (double) this.m_Total_Passed / (double) (this.m_Total_Passed + this.m_Total_Failed);
        this.cblblTestYield(this.m_TestYield.ToString("P"));
      }
      this.m_Errorcode_Last = Convert.ToInt32(IniFile.GetProfile(this.m_sTestMode + " MODE YIELD TRACKING", this.m_sTestMode + "_ERRORCODE_LAST", "0"));
      this.cbtextLastError(this.m_Errorcode_Last.ToString("D6"));
      if (this.m_Failed_Count == 0)
        this.cbtextLastErrorColor(Color.Black, Color.LightGreen);
      else if (this.m_Failed_Count == 1)
        this.cbtextLastErrorColor(Color.Black, Color.Yellow);
      else if (this.m_Failed_Count == 2)
        this.cbtextLastErrorColor(Color.Black, Color.Orange);
      else
        this.cbtextLastErrorColor(Color.White, Color.Red);
      if (this.m_YieldTracking_enabled && this.m_Total_Passed + this.m_Total_Failed >= this.m_Total_Test_Threshold && this.m_TestYield < this.m_TestYield_Expected)
      {
        frmFail frmFail = new frmFail();
        string str = string.Format("Actual Test Yield of {0} is below\nExpected Test Yield of {1}.\n\nTest Can't be run!\nPlease Close the app!", (object) this.m_TestYield.ToString("P"), (object) this.m_TestYield_Expected.ToString("P"));
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str;
        frmFail.Message = str;
        int num = (int) frmFail.ShowDialog();
        this.RaiseUserAbortEvent();
        flag = false;
      }
      if (this.m_YieldTracking_enabled && this.m_Failed_Count >= this.m_Failed_Count_Max_Allowed)
      {
        frmFail frmFail = new frmFail();
        string str = string.Format("Failed with the ERROR code, {0}\n{1} times consecutively!\n\nTest Can't be run.\nPlease Close the app!", (object) this.m_Errorcode_Last, (object) this.m_Failed_Count);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str;
        frmFail.Message = str;
        int num = (int) frmFail.ShowDialog();
        this.RaiseUserAbortEvent();
        flag = false;
      }
      return flag;
    }

    private void mnuOpenConfig_Click(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(soteDiag.soteDiag.appConfig))
          throw new Exception(2.ToString());
        Process.Start("notepad", soteDiag.soteDiag.appConfig);
      }
      catch (Exception ex)
      {
        if (ex.Message.Equals(2.ToString()))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found: \n\n" + soteDiag.soteDiag.appConfig);
        }
        else
        {
          if (!ex.Message.Equals((object) 5))
            return;
          soteDiag.soteDiag.showFailMsgDlg("Access denied: \n\n" + soteDiag.soteDiag.appConfig);
        }
      }
    }

    private static void showFailMsgDlg(string message)
    {
      int num = (int) new frmFail() { Message = message }.ShowDialog();
    }

    public event soteDiag.soteDiag.DisposeEventDelegate DisposeEvent;

    private void cbRaiseSerialDisposedEvent()
    {
      if (this.DisposeEvent == null)
        return;
      this.DisposeEvent((object) this, new EventArgs());
    }

    public void SerialDisposedEventHandler(object sender, EventArgs e)
    {
      this.btnAbort_Click(sender, e);
    }

    private void cbSerialRead(string msg)
    {
      if (this.m_userabort)
        return;
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateSerialRead(this.cbSerialRead), (object) msg);
      }
      else
      {
        if (this.txtTerminal.TextLength > this.txtTerminal.MaxLength / 2)
          this.txtTerminal.Text = "";
        msg = Regex.Replace(msg, "[^\\u0008-\\u000A\\u000D\\u0020-\\u007F]", string.Empty);
        this.m_results += msg;
        this.m_commands += msg;
        this.m_data += msg;
        if (this.m_bSerialReadFormattingEnabled)
        {
          int num;
          while ((num = this.m_results.IndexOf('\b')) > -1)
          {
            if (num > 0 && this.m_results.Length > num)
              this.m_results = this.m_results.Remove(num - 1, 2);
          }
          this.m_results = this.m_results.Replace("\r\n\r", "\r\n");
          this.m_results = this.m_results.Replace("\r\n\n", "\r\n");
          this.m_results = this.m_results.Replace("\n\r", "\r\n");
          this.m_results = this.m_results.Replace("[s", "");
          this.m_results = this.m_results.Replace("[u", "");
          this.m_results = this.m_results.Replace("[0m", "");
          this.m_results = this.m_results.Replace("[31m", "");
          this.m_results = this.m_results.Replace("[32m", "");
          this.m_results = this.m_results.Replace("[36m", "");
          this.m_results = this.m_results.Replace("[37m", "");
        }
        this.txtTerminal.Text = this.m_results;
        this.m_timestamp = DateTime.Now;
        this.txtTerminal.SelectionStart = this.txtTerminal.TextLength;
        this.txtTerminal.ScrollToCaret();
      }
    }

    private void cbSerialWrite(string msg)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateSerialWrite(this.cbSerialWrite), (object) msg);
      }
      else
      {
        if (this.txtTerminal.TextLength > this.txtTerminal.MaxLength / 2)
          this.txtTerminal.Text = "";
        this.txtTerminal.Text += msg;
        this.txtTerminal.SelectionStart = this.txtTerminal.TextLength;
        this.txtTerminal.ScrollToCaret();
      }
    }

    private void cbgroupTest(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegategroupTest(this.cbgroupTest), (object) enable);
      else
        this.groupTest.Enabled = enable;
    }

    private void cbbtnOK(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatebtnOK(this.cbbtnOK), (object) enable);
      else
        this.btnOK.Enabled = enable;
    }

    private void cbgoldenSampleMode(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegategoldenSampleModeToolStripMenuItem(this.cbgoldenSampleMode), (object) enable);
      else
        this.goldenSampleModeToolStripMenuItem.Enabled = enable;
    }

    private void cbtxtBadge(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetxtBadge(this.cbtxtBadge), (object) enable);
      else
        this.txtBadge.Enabled = enable;
    }

    private void cbtxtLabel(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetxtLabel(this.cbtxtLabel), (object) enable);
      else
        this.txtLabel.Enabled = enable;
    }

    private void cbtxtMAC(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetxtMAC(this.cbtxtMAC), (object) enable);
      else
        this.txtMAC.Enabled = enable;
    }

    private void cbUUTGroup(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateUUTGroup(this.cbUUTGroup), (object) enable);
      else
        this.groupUUT.Enabled = enable;
    }

    private void cbChkSFIS(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateChkSFIS(this.cbChkSFIS), (object) enable);
      else
        this.chkSFIS.Enabled = enable;
    }

    private void cbButtonPowerON(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateButtonPowerON(this.cbButtonPowerON), (object) enable);
      else
        this.ButtonPowerON.Enabled = enable;
    }

    private void cbButtonPowerOFF(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateButtonPowerOFF(this.cbButtonPowerOFF), (object) enable);
      else
        this.ButtonPowerOFF.Enabled = enable;
    }

    private void cbButtonBADGE(bool enable)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateButtonBADGE(this.cbButtonBADGE), (object) enable);
      else
        this.ButtonBADGE.Enabled = enable;
    }

    private bool SendSFIS(bool status, string version, string errorcode)
    {
      string msg1 = "";
      string profile1 = IniFile.GetProfile("SHOPFLOOR", "SFIS");
      string label = this.m_label;
      if (profile1 == "SOTESFIS")
      {
        string profile2 = IniFile.GetProfile("SOTESFIS", "PID");
        string profile3 = IniFile.GetProfile("SOTESFIS", "TESTTYPE");
        string profile4 = IniFile.GetProfile("SOTESFIS", "BCMNUMBER");
        string profile5 = IniFile.GetProfile("SOTESFIS", "ASSYNUMBER");
        string profile6 = IniFile.GetProfile("SOTESFIS", "ASSYREV");
        string profile7 = IniFile.GetProfile("SOTESFIS", "PRODUCTTYPE");
        string profile8 = IniFile.GetProfile("SOTESFIS", "SOTESFISSERVER");
        string profile9 = IniFile.GetProfile("SOTESFIS", "CHIPNUMBER");
        string profile10 = IniFile.GetProfile("SOTESFIS", "CHIPREV");
        string profile11 = IniFile.GetProfile("SOTESFIS", "COMMENTS");
        string profile12 = IniFile.GetProfile("SOTESFIS", "CUSTOMER");
        string profile13 = IniFile.GetProfile("SOTESFIS", "REQUESTER");
        string profile14 = IniFile.GetProfile("SOTESFIS", "WEBCA");
        string msg2 = "testDate,pid,productType,bcmNumber,assyNumber,assyRev,testType,employee,serialNumber,testStatus,macAddress,software,firmware,configuration,chipNumber,chipRev,comments,customer,requester,webCA";
        soteDiag.soteDiag.appData = soteDiag.soteDiag.appData + this.m_badge + "@Enterprise.csv";
        if (!File.Exists(soteDiag.soteDiag.appData))
          soteUtils.log2file(soteDiag.soteDiag.appData, msg2);
        msg1 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},\"{13}\",{14},{15},{16},{17},{18},{19}", (object) DateTime.Now.ToShortDateString(), (object) profile2, (object) profile7, (object) profile4, (object) profile5, (object) profile6, (object) profile3, (object) this.m_badge, (object) label, (object) status, (object) this.m_MAC[0], (object) this.m_software, (object) this.m_firmware, (object) this.m_configuration, (object) profile9, (object) profile10, (object) profile11, (object) profile12, (object) profile13, (object) profile14);
        do
          ;
        while (!soteUtils.log2file(soteDiag.soteDiag.appData, msg1) && MessageBox.Show(soteDB.errMsg, "LOG TO FILE", MessageBoxButtons.RetryCancel) != DialogResult.Cancel);
        string appData = soteDiag.soteDiag.appData;
        string destFileName = profile8 + "\\" + this.m_badge + "@Enterprise.csv";
        File.Copy(appData, destFileName, true);
        File.Delete(appData);
      }
      if (!profile1.StartsWith("COM"))
        ;
      if (profile1.Contains(".") && profile1.Contains(":") && !profile1.Contains("\\"))
      {
        string[] strArray = profile1.Split(':');
        if (strArray.Length < 2)
        {
          int num = (int) new NewMessageBox()
          {
            Message = "INVALID SFIS IP/PORT SETTING [SFIS=ip:port]"
          }.ShowDialog();
          return false;
        }
        string ip = strArray[0];
        int int16;
        try
        {
          int16 = (int) Convert.ToInt16(strArray[1]);
        }
        catch (Exception ex)
        {
          int num = (int) new NewMessageBox()
          {
            Message = string.Format("INVALID PORT NUMBER: " + ex.Message)
          }.ShowDialog();
          return false;
        }
        string usi = soteSFIS.SendReceiveUSI(ip, int16, this.m_fixture_id, label, this.m_badge, this.m_line, this.m_MAC, status ? "PASS" : "FAIL", errorcode, version, out msg1);
        soteUtils.log2file(soteDiag.soteDiag.sfisLog, msg1);
        this.cbTerminal("\r\nSFIS Tx: " + msg1);
        this.cbTerminal("\r\nSFIS Rx: " + usi + "\r\n");
      }
      if (profile1.Contains("\\") && profile1.Contains(":") && profile1.Contains("."))
      {
        string liteOn = soteSFIS.SendReceiveLiteOn(profile1, this.m_label, this.m_MAC, status ? "PASS" : "FAIL", errorcode, out msg1);
        soteUtils.log2file(soteDiag.soteDiag.sfisLog, msg1);
        soteSFIS.LiteOnShopFloorControl();
        this.cbTerminal("\r\nSFIS Tx: " + msg1);
        this.cbTerminal("\r\nSFIS Rx: " + liteOn + "\r\n");
      }
      return true;
    }

    private void SendSerialPortCommand(string txtCommandLine)
    {
      try
      {
        int num1 = 0;
        bool flag = false;
        while (num1 < 6)
        {
          this.cbStatusColor(Color.Maroon);
          this.cbStatusText(string.Format("...Sending  Command ({0} attempt)...Sending  Command ({0} attempt)...Sending  Command ({0} attempt)...Sending  Command ({0} attempt)...", (object) (num1 + 1)));
          this.m_commands = "";
          Thread.Sleep(500);
          this.m_commport.WriteByte(Convert.ToByte((object) ConsoleKey.Enter));
          Thread.Sleep(1000);
          this.m_commport.WriteByte(Convert.ToByte((object) ConsoleKey.Enter));
          Thread.Sleep(2000);
          for (int index = 0; index < txtCommandLine.Length; ++index)
          {
            this.m_commport.WriteByte(Convert.ToByte(txtCommandLine[index]));
            Thread.Sleep(50);
          }
          this.cbStatusColor(Color.Maroon);
          this.cbStatusText(string.Format("...Waiting  for  Command  Response ({0} attempt)...Waiting  for  Command  Response ({0} attempt)......Waiting  for  Command  Response ({0} attempt)...", (object) (num1 + 1)));
          Thread.Sleep(3000);
          if (this.m_commands.Contains("General failure reading device COM") || this.m_commands.Contains("Abort"))
          {
            Thread.Sleep(1000);
            this.m_commport.WriteByte(Convert.ToByte((object) ConsoleKey.A));
            Thread.Sleep(1000);
            ++num1;
          }
          else if (this.m_commands.Contains("Bad command") || this.m_commands.Contains("invalid command") || this.m_commands.Contains("ERROR: no serial port specified") || this.m_commands.Contains("syntax:"))
          {
            Thread.Sleep(1000);
            ++num1;
          }
          else
          {
            if (this.m_commands.Contains(">" + txtCommandLine))
            {
              flag = true;
              break;
            }
            if (this.m_commands == "")
            {
              ++num1;
              Thread.Sleep(1000);
            }
            else
            {
              Thread.Sleep(1000);
              ++num1;
            }
          }
          if (this.m_usbrelayenable && !flag && num1 >= 4)
            this.rebootDOSPC();
        }
        if (flag || this.m_userabort)
          return;
        frmFail frmFail = new frmFail();
        string str = !this.m_usbrelayenable ? string.Format("Failed to establish the communication\nlink with the DUT after {0} retries\n\nClose the app and reboot DOS PC!", (object) (num1 - 1)) : string.Format("Failed to establish the communication\nlink with the DUT after {0} retries\n\nClose the app and restart the test!", (object) (num1 - 1));
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str;
        frmFail.Message = str;
        int num2 = (int) frmFail.ShowDialog();
        this.RaiseUserAbortEvent();
      }
      catch (Exception ex)
      {
        if (this.m_userabort)
          return;
        soteDiag.soteDiag soteDiag1 = this;
        soteDiag1.m_results = soteDiag1.m_results + "\nSendSerialPortCommand: " + ex.Message;
        frmFail frmFail = new frmFail();
        string str = "SendSerialPortCommand: \nException encountered!";
        soteDiag.soteDiag soteDiag2 = this;
        soteDiag2.m_results = soteDiag2.m_results + "\r\n" + str;
        frmFail.Message = str;
        int num = (int) frmFail.ShowDialog();
        this.RaiseUserAbortEvent();
      }
    }

    private void UpdateDisplayColor(
      int iCurrentCount,
      int iMaxCount,
      out Color foreColor,
      out Color backColor)
    {
      foreColor = Color.Black;
      backColor = Color.LightGreen;
      if ((double) iCurrentCount < (double) iMaxCount * this.m_MIN_Consumable_Threshold)
      {
        foreColor = Color.Black;
        backColor = Color.LightGreen;
      }
      else if ((double) iCurrentCount < (double) iMaxCount * this.m_MID_Consumable_Threshold)
      {
        foreColor = Color.Black;
        backColor = Color.Yellow;
      }
      else if ((double) iCurrentCount < (double) iMaxCount * this.m_MAX_Consumable_Threshold)
      {
        foreColor = Color.Black;
        backColor = Color.Orange;
      }
      else
      {
        foreColor = Color.White;
        backColor = Color.Red;
      }
    }

    private void InitializeTestResults()
    {
      this.m_Retry = 0;
      this.m_bRetry = false;
      this.m_bResultSentToSFIS = false;
      this.m_bTestStarted = false;
      this.m_bFCTTestStarted = false;
      this.m_bFCTTestLogCopied = false;
      this.m_bNVRAMVerifyTestStarted = false;
      this.m_bNVRAMVerifyTestLogCopied = false;
      this.m_ProgramFRUTestResult = false;
      this.m_FCTErrorCode = (string) null;
      this.m_logFileName = (string) null;
      this.m_traceLog = (string) null;
      this.m_traceLogFileName = (string) null;
      this.m_ProgramFRUFileName = (string) null;
      this.m_VerifyFRUFileName = (string) null;
      if (this.m_TestMode == 8 && this.m_Loop == 1)
        this.m_bRMAOverallTestResults = true;
      this.m_FCTErrorDescription = "FCT:Not/Run";
      this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Not/Run";
      this.m_LABELErrorDescription = this.m_TestMode != 5 && this.m_TestMode != 8 ? "LABELVerify:Not/Run" : "LABELVerify:N/A";
      this.m_ProgramFRUErrorDescription = clsUUT.bFRU ? (this.m_TestMode != 1 && this.m_TestMode != 9 && (this.m_TestMode != 5 && this.m_TestMode != 8) && this.m_TestMode != 6 && this.m_TestMode != 7 ? "ProgramFRU:N/A" : "ProgramFRU:Not/Run") : "ProgramFRU:N/A";
      this.m_FRUVerifyErrorDescription = clsUUT.bFRU ? "FRUVerify:Not/Run" : "FRUVerify:N/A";
      this.m_txtOverallTestResult = "FAIL";
      this.m_iFCTErrorCode = 100000;
      if (clsUUT.hw_type == "OBRIEN")
      {
        this.m_iLOOPBACKErrorCode = 0;
        this.m_LOOPBACKErrorDescription = "LOOPBACK:N/A";
        this.m_NCSIErrorDescription = "NCSI:Not/Run";
        this.m_iNCSIErrorCode = 100000;
        this.m_txtOverallErrorDescription = this.m_FCTErrorDescription + this.m_NVRAMVerifyErrorDescription + this.m_ProgramFRUErrorDescription + this.m_FRUVerifyErrorDescription + this.m_LABELErrorDescription + this.m_NCSIErrorDescription;
      }
      else
      {
        this.m_iLOOPBACKErrorCode = 0;
        this.m_LOOPBACKErrorDescription = "LOOPBACK:N/A";
        this.m_txtOverallErrorDescription = this.m_FCTErrorDescription + this.m_NVRAMVerifyErrorDescription + this.m_ProgramFRUErrorDescription + this.m_FRUVerifyErrorDescription + this.m_LABELErrorDescription;
      }
      this.m_iNVRAMVerifyErrorCode = 100000;
      this.m_iLABELErrorCode = this.m_TestMode != 5 && this.m_TestMode != 8 ? 100000 : 0;
      this.m_iProgramFRUErrorCode = clsUUT.bFRU ? (this.m_TestMode != 1 && this.m_TestMode != 9 && (this.m_TestMode != 5 && this.m_TestMode != 8) && this.m_TestMode != 6 && this.m_TestMode != 7 ? 0 : 100000) : 0;
      this.m_iFRUVerifyErrorCode = clsUUT.bFRU ? 100000 : 0;
      if (this.m_TestMode == 5)
      {
        if (!this.m_bFCTEnabled)
        {
          this.m_iFCTErrorCode = 0;
          if (!this.m_FCTErrorDescription.Contains("FCT:N/A"))
            this.m_FCTErrorDescription = "FCT:DISABLED";
        }
        if (!this.m_bLOOPBACKEnabled)
        {
          this.m_iLOOPBACKErrorCode = 0;
          if (!this.m_LOOPBACKErrorDescription.Contains("LOOPBACK:N/A"))
            this.m_LOOPBACKErrorDescription = "LOOPBACK:DISABLED";
        }
        if (!this.m_bProgramFRUEnabled)
        {
          this.m_iProgramFRUErrorCode = 0;
          if (!this.m_ProgramFRUErrorDescription.Contains("ProgramFRU:N/A"))
            this.m_ProgramFRUErrorDescription = "ProgramFRU:DISABLED";
        }
        if (!this.m_bNVRAMVerifyEnabled)
        {
          this.m_iNVRAMVerifyErrorCode = 0;
          if (!this.m_NVRAMVerifyErrorDescription.Contains("NVRAMVerify:N/A"))
            this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:DISABLED";
        }
        if (!this.m_bFRUVerifyEnabled)
        {
          this.m_iFRUVerifyErrorCode = 0;
          if (!this.m_FRUVerifyErrorDescription.Contains("FRUVerify:N/A"))
            this.m_FRUVerifyErrorDescription = "FRUVerify:DISABLED";
        }
        if (!this.m_bNCSIEnabled && clsUUT.hw_type == "OBRIEN")
        {
          this.m_iNCSIErrorCode = 0;
          if (!this.m_NCSIErrorDescription.Contains("NCSI:N/A"))
            this.m_NCSIErrorDescription = "NCSI:DISABLED";
        }
      }
      if (this.m_TestMode != 8)
        return;
      if (!this.m_bRMAFCT && !this.m_bRMAProgramNVRAM)
      {
        this.m_iFCTErrorCode = 0;
        if (!this.m_FCTErrorDescription.Contains("FCT:N/A"))
          this.m_FCTErrorDescription = "FCT:DISABLED";
      }
      if (!this.m_bRMAProgramFRU)
      {
        this.m_iProgramFRUErrorCode = 0;
        if (!this.m_ProgramFRUErrorDescription.Contains("ProgramFRU:N/A"))
          this.m_ProgramFRUErrorDescription = "ProgramFRU:DISABLED";
      }
      if (!this.m_bRMANVRAMVerify)
      {
        this.m_iNVRAMVerifyErrorCode = 0;
        if (!this.m_NVRAMVerifyErrorDescription.Contains("NVRAMVerify:N/A"))
          this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:DISABLED";
      }
      if (!this.m_bRMAFRUVerify)
      {
        this.m_iFRUVerifyErrorCode = 0;
        if (!this.m_FRUVerifyErrorDescription.Contains("FRUVerify:N/A"))
          this.m_FRUVerifyErrorDescription = "FRUVerify:DISABLED";
      }
      if (!this.m_bRMANCSI && clsUUT.hw_type == "OBRIEN")
      {
        this.m_iNCSIErrorCode = 0;
        if (!this.m_NCSIErrorDescription.Contains("NCSI:N/A"))
          this.m_NCSIErrorDescription = "NCSI:DISABLED";
      }
    }

    private void copyFile2MappedNetworkDrive(string srcFilePath, string dstFilePath)
    {
      try
      {
        File.Copy(srcFilePath, dstFilePath, true);
      }
      catch (Exception ex)
      {
        frmFail frmFail = new frmFail();
        string str = string.Format("Failed to copy file from\n{0}\nto\n{1}\n\n{2}", (object) srcFilePath, (object) dstFilePath, (object) ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str;
        frmFail.Message = str;
        int num = (int) frmFail.ShowDialog();
        this.RaiseUserAbortEvent();
      }
    }

    private void UpdateTextFile(string scrFilePath, string txtLine2Replace, string txtLine2Write)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string readAllLine in File.ReadAllLines(scrFilePath))
      {
        if (readAllLine.Contains(txtLine2Replace))
        {
          string str = readAllLine.Replace(txtLine2Replace, txtLine2Write);
          stringBuilder.Append(str + "\r\n");
        }
        else
          stringBuilder.Append(readAllLine + "\r\n");
      }
      File.WriteAllText(scrFilePath, stringBuilder.ToString());
    }

    private void createPIDFile(string PIDfilename)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(PIDfilename, false);
        streamWriter.WriteLine("[ESR]");
        streamWriter.WriteLine("ASSY_NUMBER={0}", (object) this.m_esr_assy_number);
        streamWriter.WriteLine("ASSYREV={0}", (object) this.m_esr_assyrev);
        streamWriter.WriteLine("CHIPNUMBER={0}", (object) this.m_esr_chipnumber);
        streamWriter.WriteLine("CHIPREV={0}", (object) this.m_esr_chiprev);
        streamWriter.WriteLine("CHIPID={0}", (object) this.m_esr_chipid);
        streamWriter.WriteLine("TEST_TYPE=Test:FCT");
        streamWriter.WriteLine("EMPLOYEE={0}", (object) this.m_esr_employee);
        streamWriter.WriteLine("EMAIL={0}", (object) this.m_esr_email);
        streamWriter.WriteLine("TESTAPP={0}", (object) this.m_esr_Engineering_Diagnostics);
        streamWriter.WriteLine("WEBCA=BC{0}", (object) this.m_esr_BC);
        streamWriter.WriteLine("MAC={0}", (object) this.m_esr_Stride);
        streamWriter.WriteLine("MAC_CHECK=TRUE");
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void log2SNFile(string SNfilename, string serialNo)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(SNfilename, true);
        streamWriter.WriteLine(serialNo);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void cbProgressBar(ProgressChangedEventArgs e)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatecbProgressBar(this.cbProgressBar), (object) e);
      else
        this.progressBar.Value = e.ProgressPercentage;
    }

    private void cbSetProgressBarMaximum(int max)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatecbSetProgressBarMaximum(this.cbSetProgressBarMaximum), (object) max);
      else
        this.progressBar.Maximum = max;
    }

    private void cbDisableProgressBar()
    {
      if (!this.InvokeRequired)
        return;
      this.Invoke((Delegate) new soteDiag.soteDiag.delegatecbDisableProgressBar(this.cbDisableProgressBar), new object[0]);
    }

    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.cbProgressBar(e);
      this.cblblTestTime(string.Format("{0} Sec", (object) ((double) this.progressBar.Value * 0.5)));
    }

    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
      int max = 0;
      switch (this.m_TestMode)
      {
        case 1:
        case 6:
          max = !(clsUUT.hw_type == "WOODVILLE") && !(clsUUT.hw_type == "BASHIR") && !(clsUUT.hw_type == "SHARKNADO2") ? (!(clsUUT.hw_type == "CORAK") && !(clsUUT.hw_type == "N1905") ? (!(clsUUT.hw_type == "CARDASSIA") && !(clsUUT.hw_type == "PUTNAM") && (!(clsUUT.hw_type == "BOERNE") && !(clsUUT.hw_type == "SHARKNADO4")) && (!(clsUUT.hw_type == "BUBBLES") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "OBRIEN") ? (!(clsUUT.hw_type == "MERCURY") ? (!(clsUUT.hw_type == "PLUTO") ? (!(clsUUT.hw_type == "P150C") ? (!(clsUUT.hw_type == "P150P") && !(clsUUT.hw_type == "P225P") && (!(clsUUT.hw_type == "M225P") && !(clsUUT.hw_type == "M125P")) && (!(clsUUT.hw_type == "M210P") && !(clsUUT.hw_type == "P210P")) && !(clsUUT.hw_type == "P210C") ? (!(clsUUT.hw_type == "M150PM") && !(clsUUT.hw_type == "P1100P") && (!(clsUUT.hw_type == "M1100PM") && !(clsUUT.hw_type == "PS150")) && (!(clsUUT.hw_type == "MS150") && !(clsUUT.hw_type == "M150P") && !(clsUUT.hw_type == "M210TP")) && !(clsUUT.hw_type == "M225PQ") ? (!(clsUUT.hw_type == "P225PO") ? (!(clsUUT.hw_type == "P225C") && !(clsUUT.hw_type == "P225CA") && !(clsUUT.hw_type == "P225CO") && !(clsUUT.hw_type == "P225E") ? (!(clsUUT.hw_type == "P225ED") && !(clsUUT.hw_type == "P225EPD") && (!(clsUUT.hw_type == "P210ED") && !(clsUUT.hw_type == "P210EPD")) && !(clsUUT.hw_type == "P210TED") && !(clsUUT.hw_type == "P210TEPD") ? (!(clsUUT.hw_type == "P225EDLP") && !(clsUUT.hw_type == "P225EPDLP") && (!(clsUUT.hw_type == "P210EDLP") && !(clsUUT.hw_type == "P210EPDLP")) && !(clsUUT.hw_type == "P210TEDLP") && !(clsUUT.hw_type == "P210TEPDLP") ? (!(clsUUT.hw_type == "BOAR") && !(clsUUT.hw_type == "BANDICOOT") && !(clsUUT.hw_type == "BOBOLINK") && !(clsUUT.hw_type == "BOBCAT") ? (!(clsUUT.hw_type == "HERTZ") ? (!(clsUUT.hw_type == "GAUSS") && !(clsUUT.hw_type == "PAULI") && !(clsUUT.hw_type == "N2004") ? (!(clsUUT.hw_type == "P210TE") ? (!(clsUUT.hw_type == "P210TEP") ? (!(clsUUT.hw_type == "M150C") ? (!(clsUUT.hw_type == "M225C") && !(clsUUT.hw_type == "M225CD") && !(clsUUT.hw_type == "M225PD") ? (!(clsUUT.hw_type == "M125C") ? (!(clsUUT.hw_type == "M125CP") && !(clsUUT.hw_type == "M125CLP") && !(clsUUT.hw_type == "P125C") ? (!(clsUUT.hw_type == "M125CHF") && !(clsUUT.hw_type == "M125CLPHF") ? (!(clsUUT.hw_type == "A3120L") && !(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A4160L") ? (!(clsUUT.hw_type == "M210C") ? 425 : 620) : 900) : 600) : 550) : 660) : 650) : 525) : 550) : 550) : 980) : 700) : 900) : 700) : 700) : 480) : 1250) : 700) : 700) : 475) : 335) : 470) : 600) : 510) : 530) : 380;
          break;
        case 2:
          max = !(clsUUT.hw_type == "WOODVILLE") && !(clsUUT.hw_type == "BASHIR") && !(clsUUT.hw_type == "SHARKNADO2") ? (!(clsUUT.hw_type == "CORAK") && !(clsUUT.hw_type == "N1905") ? (!(clsUUT.hw_type == "CARDASSIA") && !(clsUUT.hw_type == "PUTNAM") && (!(clsUUT.hw_type == "BOERNE") && !(clsUUT.hw_type == "SHARKNADO4")) && (!(clsUUT.hw_type == "BUBBLES") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "OBRIEN") ? (!(clsUUT.hw_type == "MERCURY") ? (!(clsUUT.hw_type == "PLUTO") ? (!(clsUUT.hw_type == "P150C") ? (!(clsUUT.hw_type == "P150P") && !(clsUUT.hw_type == "P225P") && (!(clsUUT.hw_type == "M225P") && !(clsUUT.hw_type == "M125P")) && (!(clsUUT.hw_type == "M210P") && !(clsUUT.hw_type == "P210P")) && !(clsUUT.hw_type == "P210C") ? (!(clsUUT.hw_type == "M150PM") && !(clsUUT.hw_type == "P1100P") && (!(clsUUT.hw_type == "M1100PM") && !(clsUUT.hw_type == "PS150")) && (!(clsUUT.hw_type == "MS150") && !(clsUUT.hw_type == "M150P") && !(clsUUT.hw_type == "M210TP")) && !(clsUUT.hw_type == "M225PQ") ? (!(clsUUT.hw_type == "P225PO") ? (!(clsUUT.hw_type == "P225C") && !(clsUUT.hw_type == "P225CA") && !(clsUUT.hw_type == "P225CO") && !(clsUUT.hw_type == "P225E") ? (!(clsUUT.hw_type == "P225ED") && !(clsUUT.hw_type == "P225EPD") && (!(clsUUT.hw_type == "P210ED") && !(clsUUT.hw_type == "P210EPD")) && !(clsUUT.hw_type == "P210TED") && !(clsUUT.hw_type == "P210TEPD") ? (!(clsUUT.hw_type == "P225EDLP") && !(clsUUT.hw_type == "P225EPDLP") && (!(clsUUT.hw_type == "P210EDLP") && !(clsUUT.hw_type == "P210EPDLP")) && !(clsUUT.hw_type == "P210TEDLP") && !(clsUUT.hw_type == "P210TEPDLP") ? (!(clsUUT.hw_type == "BOAR") && !(clsUUT.hw_type == "BANDICOOT") && !(clsUUT.hw_type == "BOBOLINK") && !(clsUUT.hw_type == "BOBCAT") ? (!(clsUUT.hw_type == "HERTZ") ? (!(clsUUT.hw_type == "GAUSS") && !(clsUUT.hw_type == "PAULI") && !(clsUUT.hw_type == "N2004") ? (!(clsUUT.hw_type == "P210TE") ? (!(clsUUT.hw_type == "P210TEP") ? (!(clsUUT.hw_type == "M150C") ? (!(clsUUT.hw_type == "M225C") && !(clsUUT.hw_type == "M225CD") && !(clsUUT.hw_type == "M225PD") ? (!(clsUUT.hw_type == "M125C") ? (!(clsUUT.hw_type == "M125CP") && !(clsUUT.hw_type == "M125CLP") && !(clsUUT.hw_type == "P125C") ? (!(clsUUT.hw_type == "M125CHF") && !(clsUUT.hw_type == "M125CLPHF") ? (!(clsUUT.hw_type == "A3120L") && !(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A4160L") ? (!(clsUUT.hw_type == "M210C") ? 428 : 450) : 750) : 450) : 550) : 660) : 750) : 525) : 400) : 400) : 800) : 600) : 650) : 650) : 650) : 480) : 1150) : 600) : 600) : 475) : 235) : 345) : 560) : 405) : 410) : 285;
          break;
        case 5:
          max = !(clsUUT.hw_type == "WOODVILLE") && !(clsUUT.hw_type == "BASHIR") && !(clsUUT.hw_type == "SHARKNADO2") ? (!(clsUUT.hw_type == "CORAK") && !(clsUUT.hw_type == "N1905") ? (!(clsUUT.hw_type == "CARDASSIA") && !(clsUUT.hw_type == "PUTNAM") && (!(clsUUT.hw_type == "BOERNE") && !(clsUUT.hw_type == "SHARKNADO4")) && (!(clsUUT.hw_type == "BUBBLES") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "OBRIEN") ? (!(clsUUT.hw_type == "MERCURY") ? (!(clsUUT.hw_type == "PLUTO") ? (!(clsUUT.hw_type == "P150C") ? (!(clsUUT.hw_type == "P150P") && !(clsUUT.hw_type == "P225P") && (!(clsUUT.hw_type == "M225P") && !(clsUUT.hw_type == "M125P")) && (!(clsUUT.hw_type == "M210P") && !(clsUUT.hw_type == "P210P")) && !(clsUUT.hw_type == "P210C") ? (!(clsUUT.hw_type == "M150PM") && !(clsUUT.hw_type == "P1100P") && (!(clsUUT.hw_type == "M1100PM") && !(clsUUT.hw_type == "PS150")) && (!(clsUUT.hw_type == "MS150") && !(clsUUT.hw_type == "M150P") && !(clsUUT.hw_type == "M210TP")) && !(clsUUT.hw_type == "M225PQ") ? (!(clsUUT.hw_type == "P225PO") ? (!(clsUUT.hw_type == "P225C") && !(clsUUT.hw_type == "P225CA") && !(clsUUT.hw_type == "P225CO") && !(clsUUT.hw_type == "P225E") ? (!(clsUUT.hw_type == "P225ED") && !(clsUUT.hw_type == "P225EPD") && (!(clsUUT.hw_type == "P210ED") && !(clsUUT.hw_type == "P210EPD")) && !(clsUUT.hw_type == "P210TED") && !(clsUUT.hw_type == "P210TEPD") ? (!(clsUUT.hw_type == "P225EDLP") && !(clsUUT.hw_type == "P225EPDLP") && (!(clsUUT.hw_type == "P210EDLP") && !(clsUUT.hw_type == "P210EPDLP")) && !(clsUUT.hw_type == "P210TEDLP") && !(clsUUT.hw_type == "P210TEPDLP") ? (!(clsUUT.hw_type == "BOAR") && !(clsUUT.hw_type == "BANDICOOT") && !(clsUUT.hw_type == "BOBOLINK") && !(clsUUT.hw_type == "BOBCAT") ? (!(clsUUT.hw_type == "HERTZ") ? (!(clsUUT.hw_type == "GAUSS") && !(clsUUT.hw_type == "PAULI") && !(clsUUT.hw_type == "N2004") ? (!(clsUUT.hw_type == "P210TE") ? (!(clsUUT.hw_type == "P210TEP") ? (!(clsUUT.hw_type == "M150C") ? (!(clsUUT.hw_type == "M225C") && !(clsUUT.hw_type == "M225CD") && !(clsUUT.hw_type == "M225PD") ? (!(clsUUT.hw_type == "M125C") ? (!(clsUUT.hw_type == "M125CP") && !(clsUUT.hw_type == "M125CLP") && !(clsUUT.hw_type == "P125C") ? (!(clsUUT.hw_type == "M125CHF") && !(clsUUT.hw_type == "M125CLPHF") ? (!(clsUUT.hw_type == "A3120L") && !(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A4160L") ? (!(clsUUT.hw_type == "M210C") ? 423 * this.m_TestLoop : 620 * this.m_TestLoop) : 900 * this.m_TestLoop) : 600 * this.m_TestLoop) : 550 * this.m_TestLoop) : 660 * this.m_TestLoop) : 650 * this.m_TestLoop) : 525 * this.m_TestLoop) : 460 * this.m_TestLoop) : 460 * this.m_TestLoop) : 980 * this.m_TestLoop) : 700 * this.m_TestLoop) : 900 * this.m_TestLoop) : 700 * this.m_TestLoop) : 700 * this.m_TestLoop) : 480 * this.m_TestLoop) : 1250 * this.m_TestLoop) : 700 * this.m_TestLoop) : 700 * this.m_TestLoop) : 475 * this.m_TestLoop) : 333 * this.m_TestLoop) : 465 * this.m_TestLoop) : 600 * this.m_TestLoop) : 505 * this.m_TestLoop) : 525 * this.m_TestLoop) : 375 * this.m_TestLoop;
          break;
        case 7:
          max = !(clsUUT.hw_type == "WOODVILLE") && !(clsUUT.hw_type == "BASHIR") && !(clsUUT.hw_type == "SHARKNADO2") ? (!(clsUUT.hw_type == "CORAK") && !(clsUUT.hw_type == "N1905") ? (!(clsUUT.hw_type == "CARDASSIA") && !(clsUUT.hw_type == "PUTNAM") && (!(clsUUT.hw_type == "BOERNE") && !(clsUUT.hw_type == "SHARKNADO4")) && (!(clsUUT.hw_type == "BUBBLES") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "OBRIEN") ? (!(clsUUT.hw_type == "MERCURY") ? (!(clsUUT.hw_type == "PLUTO") ? (!(clsUUT.hw_type == "P150C") ? (!(clsUUT.hw_type == "P150P") && !(clsUUT.hw_type == "P225P") && (!(clsUUT.hw_type == "M225P") && !(clsUUT.hw_type == "M125P")) && (!(clsUUT.hw_type == "M210P") && !(clsUUT.hw_type == "P210P")) && !(clsUUT.hw_type == "P210C") ? (!(clsUUT.hw_type == "M150PM") && !(clsUUT.hw_type == "P1100P") && (!(clsUUT.hw_type == "M1100PM") && !(clsUUT.hw_type == "PS150")) && (!(clsUUT.hw_type == "MS150") && !(clsUUT.hw_type == "M150P") && !(clsUUT.hw_type == "M210TP")) && !(clsUUT.hw_type == "M225PQ") ? (!(clsUUT.hw_type == "P225PO") ? (!(clsUUT.hw_type == "P225C") && !(clsUUT.hw_type == "P225CA") && !(clsUUT.hw_type == "P225CO") && !(clsUUT.hw_type == "P225E") ? (!(clsUUT.hw_type == "P225ED") && !(clsUUT.hw_type == "P225EPD") && (!(clsUUT.hw_type == "P210ED") && !(clsUUT.hw_type == "P210EPD")) && !(clsUUT.hw_type == "P210TED") && !(clsUUT.hw_type == "P210TEPD") ? (!(clsUUT.hw_type == "P225EDLP") && !(clsUUT.hw_type == "P225EPDLP") && (!(clsUUT.hw_type == "P210EDLP") && !(clsUUT.hw_type == "P210EPDLP")) && !(clsUUT.hw_type == "P210TEDLP") && !(clsUUT.hw_type == "P210TEPDLP") ? (!(clsUUT.hw_type == "BOAR") && !(clsUUT.hw_type == "BANDICOOT") && !(clsUUT.hw_type == "BOBOLINK") && !(clsUUT.hw_type == "BOBCAT") ? (!(clsUUT.hw_type == "HERTZ") ? (!(clsUUT.hw_type == "GAUSS") && !(clsUUT.hw_type == "PAULI") && !(clsUUT.hw_type == "N2004") ? (!(clsUUT.hw_type == "P210TE") ? (!(clsUUT.hw_type == "P210TEP") ? (!(clsUUT.hw_type == "M150C") ? (!(clsUUT.hw_type == "M225C") && !(clsUUT.hw_type == "M225CD") && !(clsUUT.hw_type == "M225PD") ? (!(clsUUT.hw_type == "M125C") ? (!(clsUUT.hw_type == "M125CP") && !(clsUUT.hw_type == "M125CLP") && !(clsUUT.hw_type == "P125C") ? (!(clsUUT.hw_type == "M125CHF") && !(clsUUT.hw_type == "M125CLPHF") ? (!(clsUUT.hw_type == "A3120L") && !(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A4160L") ? (!(clsUUT.hw_type == "M210C") ? 678 : 750) : 1000) : 850) : 800) : 910) : 850) : 725) : 650) : 650) : 1190) : 900) : 850) : 900) : 900) : 680) : 1450) : 900) : 900) : 675) : 530) : 695) : 1150) : 695) : 745) : 545;
          break;
        case 8:
          max = !(clsUUT.hw_type == "WOODVILLE") && !(clsUUT.hw_type == "BASHIR") && !(clsUUT.hw_type == "SHARKNADO2") ? (!(clsUUT.hw_type == "CORAK") && !(clsUUT.hw_type == "N1905") ? (!(clsUUT.hw_type == "CARDASSIA") && !(clsUUT.hw_type == "PUTNAM") && (!(clsUUT.hw_type == "BOERNE") && !(clsUUT.hw_type == "SHARKNADO4")) && (!(clsUUT.hw_type == "BUBBLES") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "OBRIEN") ? (!(clsUUT.hw_type == "MERCURY") ? (!(clsUUT.hw_type == "PLUTO") ? (!(clsUUT.hw_type == "P150C") ? (!(clsUUT.hw_type == "P150P") && !(clsUUT.hw_type == "P225P") && (!(clsUUT.hw_type == "M225P") && !(clsUUT.hw_type == "M125P")) && (!(clsUUT.hw_type == "M210P") && !(clsUUT.hw_type == "P210P")) && !(clsUUT.hw_type == "P210C") ? (!(clsUUT.hw_type == "M150PM") && !(clsUUT.hw_type == "P1100P") && (!(clsUUT.hw_type == "M1100PM") && !(clsUUT.hw_type == "PS150")) && (!(clsUUT.hw_type == "MS150") && !(clsUUT.hw_type == "M150P") && !(clsUUT.hw_type == "M210TP")) && !(clsUUT.hw_type == "M225PQ") ? (!(clsUUT.hw_type == "P225PO") ? (!(clsUUT.hw_type == "P225C") && !(clsUUT.hw_type == "P225CA") && !(clsUUT.hw_type == "P225CO") && !(clsUUT.hw_type == "P225E") ? (!(clsUUT.hw_type == "P225ED") && !(clsUUT.hw_type == "P225EPD") && (!(clsUUT.hw_type == "P210ED") && !(clsUUT.hw_type == "P210EPD")) && !(clsUUT.hw_type == "P210TED") && !(clsUUT.hw_type == "P210TEPD") ? (!(clsUUT.hw_type == "P225EDLP") && !(clsUUT.hw_type == "P225EPDLP") && (!(clsUUT.hw_type == "P210EDLP") && !(clsUUT.hw_type == "P210EPDLP")) && !(clsUUT.hw_type == "P210TEDLP") && !(clsUUT.hw_type == "P210TEPDLP") ? (!(clsUUT.hw_type == "BOAR") && !(clsUUT.hw_type == "BANDICOOT") && !(clsUUT.hw_type == "BOBOLINK") && !(clsUUT.hw_type == "BOBCAT") ? (!(clsUUT.hw_type == "HERTZ") ? (!(clsUUT.hw_type == "GAUSS") && !(clsUUT.hw_type == "PAULI") && !(clsUUT.hw_type == "N2004") ? (!(clsUUT.hw_type == "P210TE") ? (!(clsUUT.hw_type == "P210TEP") ? (!(clsUUT.hw_type == "M150C") ? (!(clsUUT.hw_type == "M225C") && !(clsUUT.hw_type == "M225CD") && !(clsUUT.hw_type == "M225PD") ? (!(clsUUT.hw_type == "M125C") ? (!(clsUUT.hw_type == "M125CP") && !(clsUUT.hw_type == "M125CLP") && !(clsUUT.hw_type == "P125C") ? (!(clsUUT.hw_type == "M125CHF") && !(clsUUT.hw_type == "M125CLPHF") ? (!(clsUUT.hw_type == "A3120L") && !(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A4160L") ? (!(clsUUT.hw_type == "M210C") ? 428 * this.m_nRMATestLoop : 450) : 750) : 600 * this.m_nRMATestLoop) : 550 * this.m_nRMATestLoop) : 660 * this.m_nRMATestLoop) : 650 * this.m_nRMATestLoop) : 525 * this.m_nRMATestLoop) : 525 * this.m_nRMATestLoop) : 525 * this.m_nRMATestLoop) : 800 * this.m_nRMATestLoop) : 600 * this.m_nRMATestLoop) : 650 * this.m_nRMATestLoop) : 650 * this.m_nRMATestLoop) : 650 * this.m_nRMATestLoop) : 480 * this.m_nRMATestLoop) : 1150 * this.m_nRMATestLoop) : 600 * this.m_nRMATestLoop) : 600 * this.m_nRMATestLoop) : 475 * this.m_nRMATestLoop) : 235 * this.m_nRMATestLoop) : 345 * this.m_nRMATestLoop) : 560 * this.m_nRMATestLoop) : 405 * this.m_nRMATestLoop) : 410 * this.m_nRMATestLoop) : 285 * this.m_nRMATestLoop;
          break;
        case 9:
          max = !(clsUUT.hw_type == "WOODVILLE") && !(clsUUT.hw_type == "BASHIR") && !(clsUUT.hw_type == "SHARKNADO2") ? (!(clsUUT.hw_type == "CORAK") && !(clsUUT.hw_type == "N1905") ? (!(clsUUT.hw_type == "CARDASSIA") && !(clsUUT.hw_type == "PUTNAM") && (!(clsUUT.hw_type == "BOERNE") && !(clsUUT.hw_type == "SHARKNADO4")) && (!(clsUUT.hw_type == "BUBBLES") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "OBRIEN") ? (!(clsUUT.hw_type == "MERCURY") ? (!(clsUUT.hw_type == "PLUTO") ? (!(clsUUT.hw_type == "P150C") ? (!(clsUUT.hw_type == "P150P") && !(clsUUT.hw_type == "P225P") && (!(clsUUT.hw_type == "M225P") && !(clsUUT.hw_type == "M125P")) && (!(clsUUT.hw_type == "M210P") && !(clsUUT.hw_type == "P210P")) && !(clsUUT.hw_type == "P210C") ? (!(clsUUT.hw_type == "M150PM") && !(clsUUT.hw_type == "P1100P") && (!(clsUUT.hw_type == "M1100PM") && !(clsUUT.hw_type == "PS150")) && (!(clsUUT.hw_type == "MS150") && !(clsUUT.hw_type == "M150P") && !(clsUUT.hw_type == "M210TP")) && !(clsUUT.hw_type == "M225PQ") ? (!(clsUUT.hw_type == "P225PO") ? (!(clsUUT.hw_type == "P225C") && !(clsUUT.hw_type == "P225CA") && !(clsUUT.hw_type == "P225CO") && !(clsUUT.hw_type == "P225E") ? (!(clsUUT.hw_type == "P225ED") && !(clsUUT.hw_type == "P225EPD") && (!(clsUUT.hw_type == "P210ED") && !(clsUUT.hw_type == "P210EPD")) && !(clsUUT.hw_type == "P210TED") && !(clsUUT.hw_type == "P210TEPD") ? (!(clsUUT.hw_type == "P225EDLP") && !(clsUUT.hw_type == "P225EPDLP") && (!(clsUUT.hw_type == "P210EDLP") && !(clsUUT.hw_type == "P210EPDLP")) && !(clsUUT.hw_type == "P210TEDLP") && !(clsUUT.hw_type == "P210TEPDLP") ? (!(clsUUT.hw_type == "BOAR") && !(clsUUT.hw_type == "BANDICOOT") && !(clsUUT.hw_type == "BOBOLINK") && !(clsUUT.hw_type == "BOBCAT") ? (!(clsUUT.hw_type == "HERTZ") ? (!(clsUUT.hw_type == "GAUSS") && !(clsUUT.hw_type == "PAULI") && !(clsUUT.hw_type == "N2004") ? (!(clsUUT.hw_type == "P210TE") ? (!(clsUUT.hw_type == "P210TEP") ? (!(clsUUT.hw_type == "M150C") ? (!(clsUUT.hw_type == "M225C") && !(clsUUT.hw_type == "M225CD") && !(clsUUT.hw_type == "M225PD") ? (!(clsUUT.hw_type == "M125C") ? (!(clsUUT.hw_type == "M125CP") && !(clsUUT.hw_type == "M125CLP") && !(clsUUT.hw_type == "P125C") ? (!(clsUUT.hw_type == "M125CHF") && !(clsUUT.hw_type == "M125CLPHF") ? (!(clsUUT.hw_type == "A3120L") && !(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A4160L") ? (!(clsUUT.hw_type == "M210C") ? 533 : 750) : 1000) : 750) : 700) : 810) : 750) : 625) : 640) : 640) : 1090) : 800) : 880) : 800) : 800) : 600) : 1370) : 820) : 820) : 575) : 425) : 560) : 850) : 560) : 560) : 450;
          break;
        case 10:
          max = 350 + 100 * (this.m_esr_Ports - 1);
          break;
      }
      this.cbSetProgressBarMaximum(max);
      for (int percentProgress = 0; percentProgress <= this.progressBar.Maximum; ++percentProgress)
      {
        Thread.Sleep(500);
        if (this.worker == null)
          break;
        this.worker.ReportProgress(percentProgress);
      }
    }

    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    }

    private void DisplayTestProgress()
    {
      if (this.worker == null)
      {
        this.worker = new BackgroundWorker();
        this.worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
        this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
        this.worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
        this.worker.WorkerReportsProgress = true;
        this.worker.WorkerSupportsCancellation = true;
      }
      if (this.worker.IsBusy)
        return;
      this.worker.RunWorkerAsync();
    }

    private void CancelTestProgressDisplay()
    {
      if (this.worker == null)
        return;
      this.worker.CancelAsync();
      this.worker = (BackgroundWorker) null;
      this.cbSetProgressBarMaximum(0);
    }

    private void RunTestThread()
    {
      try
      {
        string str1 = (string) null;
        string str2 = (string) null;
        this.m_bHotSwapped = false;
        this.m_Loop = 1;
        while (!this.m_userabort)
        {
          if (!this.m_bHotSwapped && this.m_Loop == 1)
          {
            this.m_ready = false;
            this.cbChkSFIS(true);
            this.cbUUTGroup(true);
            this.cbUUTLabelFocus();
            Color c = Color.Red;
            while (!this.m_userabort && !this.m_ready)
            {
              this.cbbtnOK(true);
              this.cbStatus2Text("");
              this.cbStatusText("Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......");
              c = c == Color.Red ? Color.Green : Color.Red;
              this.cbStatusColor(c);
              Thread.Sleep(500);
            }
            if (!this.m_usbrelayenable)
            {
              this.cbStatusColor(Color.Black);
              this.cbStatusText("");
            }
            this.InitializeTestResults();
          }
          if (!this.m_userabort)
          {
            this.DisplayTestProgress();
            if (this.m_TestMode == 5)
            {
              this.InitializeTestResults();
              if (this.m_bStopOnFail && !this.m_bStopOnFail_poweron)
                this.cblblTestMode("STRESS_STOPONFAIL" + string.Format("-Loop #{0}", (object) this.m_Loop));
              else if (this.m_bStopOnFail && this.m_bStopOnFail_poweron)
                this.cblblTestMode("STRESS_STOPONFAIL_POWERON" + string.Format("-Loop #{0}", (object) this.m_Loop));
              else
                this.cblblTestMode("STRESS" + string.Format("-Loop #{0}", (object) this.m_Loop));
              if (this.m_Loop == 1)
              {
                ++this.m_TestJig_Current_Count;
                ++this.m_TestJig_WearOut_Adapter_Current_Count;
                ++this.m_BIE_Current_Count;
                ++this.m_RiserCard_Current_Count;
                ++this.m_MB_Current_Count;
                ++this.m_Diolan_Current_Count;
              }
            }
            else if (this.m_TestMode == 8)
            {
              this.InitializeTestResults();
              if (this.m_bRMAStopOnFailure)
                this.cblblTestMode("RMA_STOPONFAILURE" + string.Format("-Loop #{0}", (object) this.m_Loop));
              else
                this.cblblTestMode("RMA" + string.Format("-Loop #{0}", (object) this.m_Loop));
              if (this.m_Loop == 1)
              {
                ++this.m_TestJig_Current_Count;
                ++this.m_TestJig_WearOut_Adapter_Current_Count;
                ++this.m_BIE_Current_Count;
                ++this.m_RiserCard_Current_Count;
                ++this.m_MB_Current_Count;
                ++this.m_Diolan_Current_Count;
              }
            }
            else
            {
              ++this.m_TestJig_Current_Count;
              ++this.m_TestJig_WearOut_Adapter_Current_Count;
              ++this.m_BIE_Current_Count;
              ++this.m_RiserCard_Current_Count;
              ++this.m_MB_Current_Count;
              ++this.m_Diolan_Current_Count;
            }
            string txtLine2Replace1 = string.Format("TESTJIG_CURRENT_COUNT = {0}", (object) (this.m_TestJig_Current_Count - 1));
            string txtLine2Write1 = string.Format("TESTJIG_CURRENT_COUNT = {0}", (object) this.m_TestJig_Current_Count);
            this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace1, txtLine2Write1);
            Color foreColor;
            Color backColor;
            this.UpdateDisplayColor(this.m_TestJig_Current_Count, this.m_TestJig_Lifecycle, out foreColor, out backColor);
            this.cbtextTestJig(Convert.ToString(this.m_TestJig_Current_Count));
            this.cbtextTestJigColor(foreColor, backColor);
            string txtLine2Replace2 = string.Format("TESTJIG_WEAROUT_ADAPTER_CURRENT_COUNT = {0}", (object) (this.m_TestJig_WearOut_Adapter_Current_Count - 1));
            string txtLine2Write2 = string.Format("TESTJIG_WEAROUT_ADAPTER_CURRENT_COUNT = {0}", (object) this.m_TestJig_WearOut_Adapter_Current_Count);
            this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace2, txtLine2Write2);
            this.UpdateDisplayColor(this.m_TestJig_WearOut_Adapter_Current_Count, this.m_TestJig_WearOut_Adapter_Lifecycle, out foreColor, out backColor);
            this.cbtextTestJigWA(Convert.ToString(this.m_TestJig_WearOut_Adapter_Current_Count));
            this.cbtextTestJigWAColor(foreColor, backColor);
            string txtLine2Replace3 = string.Format("RISERCARD_CURRENT_COUNT = {0}", (object) (this.m_RiserCard_Current_Count - 1));
            string txtLine2Write3 = string.Format("RISERCARD_CURRENT_COUNT = {0}", (object) this.m_RiserCard_Current_Count);
            this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace3, txtLine2Write3);
            this.UpdateDisplayColor(this.m_RiserCard_Current_Count, this.m_RiserCard_Lifecycle, out foreColor, out backColor);
            this.cbtextRiserCard(Convert.ToString(this.m_RiserCard_Current_Count));
            this.cbtextRiserCardColor(foreColor, backColor);
            string txtLine2Replace4 = string.Format("BIE_CURRENT_COUNT = {0}", (object) (this.m_BIE_Current_Count - 1));
            string txtLine2Write4 = string.Format("BIE_CURRENT_COUNT = {0}", (object) this.m_BIE_Current_Count);
            this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace4, txtLine2Write4);
            this.UpdateDisplayColor(this.m_BIE_Current_Count, this.m_BIE_Lifecycle, out foreColor, out backColor);
            this.cbtextBIE(Convert.ToString(this.m_BIE_Current_Count));
            this.cbtextBIEColor(foreColor, backColor);
            string txtLine2Replace5 = string.Format("MOTHERBOARD_CURRENT_COUNT = {0}", (object) (this.m_MB_Current_Count - 1));
            string txtLine2Write5 = string.Format("MOTHERBOARD_CURRENT_COUNT = {0}", (object) this.m_MB_Current_Count);
            this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace5, txtLine2Write5);
            this.UpdateDisplayColor(this.m_MB_Current_Count, this.m_MB_Lifecycle, out foreColor, out backColor);
            this.cbtextMB(Convert.ToString(this.m_MB_Current_Count));
            this.cbtextMBColor(foreColor, backColor);
            if (this.I2CAdapterType != "DLN-2")
            {
              this.cbtextDiolan("N/A");
              this.cbtextDiolanColor(Color.Black, Color.White);
            }
            else
            {
              string txtLine2Replace6 = string.Format("DIOLAN_CURRENT_COUNT = {0}", (object) (this.m_Diolan_Current_Count - 1));
              string txtLine2Write6 = string.Format("DIOLAN_CURRENT_COUNT = {0}", (object) this.m_Diolan_Current_Count);
              this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace6, txtLine2Write6);
              this.UpdateDisplayColor(this.m_Diolan_Current_Count, this.m_Diolan_Lifecycle, out foreColor, out backColor);
              this.cbtextDiolan(Convert.ToString(this.m_Diolan_Current_Count));
              this.cbtextDiolanColor(foreColor, backColor);
            }
            if (this.m_ConsumableTracking_enabled)
            {
              if (this.m_TestJig_WearOut_Adapter_Current_Count > this.m_TestJig_WearOut_Adapter_Lifecycle)
              {
                frmFail frmFail = new frmFail();
                string str3 = string.Format("Test Jig WearOut Adapter has reached\nits life cycle of {0} times.!\n\nPlease replace with a new test Jig\nWearOut Adapter!", (object) this.m_TestJig_WearOut_Adapter_Lifecycle);
                soteDiag.soteDiag soteDiag = this;
                soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str3;
                frmFail.Message = str3;
                int num = (int) frmFail.ShowDialog();
                this.RaiseUserAbortEvent();
              }
              if (this.m_RiserCard_Current_Count > this.m_RiserCard_Lifecycle)
              {
                frmFail frmFail = new frmFail();
                string str3 = string.Format("Riser Card has reached its life cycle\nof {0} times.!\n\nPlease replace with a new Riser Card!", (object) this.m_RiserCard_Lifecycle);
                soteDiag.soteDiag soteDiag = this;
                soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str3;
                frmFail.Message = str3;
                int num = (int) frmFail.ShowDialog();
                this.RaiseUserAbortEvent();
              }
            }
            DateTime now = DateTime.Now;
            this.todayDate = now.ToString(this.customFormatToday);
            if (this.m_TestMode == 6)
              this.logDir = this.logDefault + clsUUT.hw_type + "-" + this.todayDate + "-FAI\\";
            else if (this.m_TestMode == 7)
              this.logDir = this.logDefault + clsUUT.hw_type + "-" + this.todayDate + "-GOLDENSAMPLE\\";
            else if (this.m_esr_sfis_enabled && this.m_sfis_type == 90)
              this.logDir = this.logDefault + clsUUT.hw_type + "-" + this.m_esr_tester + "-" + this.m_esr_pid + "\\";
            else
              this.logDir = this.logDefault + clsUUT.hw_type + "-" + this.todayDate + "\\";
            if (!Directory.Exists(this.logDir))
              Directory.CreateDirectory(this.logDir);
            now = DateTime.Now;
            this.todayNow = now.ToString(this.customFormatNow);
            if (this.m_TestMode == 5)
            {
              this.m_traceLog = this.logDir + clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + "-Loop" + (object) this.m_Loop + ".trc";
              this.m_traceLogFileName = clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + "-Loop" + (object) this.m_Loop + ".trc";
              this.m_logFileName = clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + "-Loop" + (object) this.m_Loop;
              if (this.m_Loop == 1)
                this.m_TestSummaryFileName = this.logDir + clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + "-STRESS-TestSummary.csv";
            }
            else if (this.m_TestMode == 8)
            {
              this.m_traceLog = this.logDir + clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + "-Loop" + (object) this.m_Loop + ".trc";
              this.m_traceLogFileName = clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + "-Loop" + (object) this.m_Loop + ".trc";
              this.m_logFileName = clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + "-Loop" + (object) this.m_Loop;
              if (this.m_Loop == 1)
                this.m_TestSummaryFileName = this.logDir + clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + "-RMA-TestSummary.csv";
            }
            else
            {
              if (this.m_sfis_type == 90 && this.m_TestMode == 10)
              {
                this.m_traceLog = this.logDir + clsUUT.esrLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + ".trc";
                this.m_traceLogFileName = clsUUT.esrLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + ".trc";
                this.m_logFileName = clsUUT.esrLabel + "-" + this.m_MAC[0] + "-" + this.todayNow;
              }
              else
              {
                this.m_traceLog = this.logDir + clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + ".trc";
                this.m_traceLogFileName = clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + ".trc";
                this.m_logFileName = clsUUT.scanLabel + "-" + this.m_MAC[0] + "-" + this.todayNow;
              }
              if (this.m_sfis_type == 90)
                this.m_TestSummaryFileName = this.logDir + clsUUT.hw_type + "-" + this.m_esr_tester + "-" + this.m_esr_pid + "-ESR-TestSummary.csv";
            }
            this.m_results = "";
            this.m_timestamp = DateTime.Now;
            soteDiag.soteDiag soteDiag1 = this;
            soteDiag1.m_results = soteDiag1.m_results + "\r\nCurrent Win7 DateTime:" + (object) this.m_timestamp + "\r\n";
            this.cbChkSFIS(false);
            this.cbUUTGroup(false);
            this.m_commport.EnablePort();
            this.m_bTestStarted = true;
            if (this.m_bFirsttime)
            {
              this.rebootDOSPC();
              this.setDateTime();
              this.m_bFirsttime = false;
            }
            if (this.m_TestMode != 2)
              this.generateMACfile(clsUUT.hw_type);
            if (this.m_TestMode != 2)
              this.generateSerialNumberfile(clsUUT.hw_type);
            if (this.m_TestMode == 7 || this.m_TestMode == 9 || this.m_TestMode == 8 && this.m_bRMAEraseNVRAM || this.m_TestMode == 5 && this.m_bERASENVRAMEnabled)
            {
              this.eraseNVRAM(this.hw_type);
              this.rebootDOSPC();
            }
            this.runFCTtest(clsUUT.hw_type);
            this.programFRU(clsUUT.hw_type);
            if (!this.m_ProgramFRUTestResult)
            {
              this.m_results += "\r\n<FRU> Failed to program FRU ...\r\n ";
              this.m_results += "\r\n<FRU> Retrying to program FRU again...\r\n ";
              this.rebootDOSPC();
              this.programFRU(clsUUT.hw_type);
            }
            if (clsUUT.hw_type == "N2004" || clsUUT.hw_type == "BUBBLES" || clsUUT.hw_type == "CASPIAN")
              this.SendSerialPortCommand(string.Format("GPIO10 {0}\r\n", (object) this.m_dutcomVal));
            while (!this.m_userabort)
            {
              Thread.Sleep(500);
              if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
              {
                this.cbTerminal("TIMEOUT");
                frmFail frmFail = new frmFail();
                string str3 = !this.m_usbrelayenable ? "Failed to detect the device\n\nClose the app and reboot DOS PC!" : "Failed to detect the device\n\nClose the app and restart the test!";
                soteDiag.soteDiag soteDiag2 = this;
                soteDiag2.m_results = soteDiag2.m_results + "\r\nFAIL: " + str3;
                frmFail.Message = str3;
                int num = (int) frmFail.ShowDialog();
                this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                this.m_iFCTErrorCode = 300;
                this.RaiseUserAbortEvent();
              }
              if (this.m_TestMode == 8 && (!this.m_bRMAFCT || !this.m_bRMAProgramNVRAM) && (this.m_results.Contains("Result = PASS") && !this.m_results.Contains("Result = FAIL")) || clsUUT.bCdiagB57diag && this.m_results.Contains("b57diag test completed") && (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result = PASS")) && (!this.m_results.Contains("Result = FAIL") && this.m_results.Contains("Total test time =") && this.m_results.Contains("Total summary:")) || (clsUUT.bCdiag && !clsUUT.bB57diag && (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result = PASS")) && (!this.m_results.Contains("Result = FAIL") && this.m_results.Contains("Total summary:")) || clsUUT.bB57diag && !clsUUT.bCdiag && (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result = PASS")) && (!this.m_results.Contains("fail") && !this.m_results.Contains("Fail") && this.m_results.Contains("Total test time ="))) || this.m_TestMode == 8 && !this.m_bRMAFCT || this.m_TestMode == 5 && !this.m_bFCTEnabled)
              {
                if (this.m_results.Contains("Result = PASS"))
                  this.m_bTestSummarySection = true;
                Thread.Sleep(1000);
                if ((this.m_TestMode != 5 || this.m_bFCTEnabled) && (this.m_TestMode != 8 || this.m_bRMAFCT || this.m_bRMAProgramNVRAM))
                {
                  this.SendSerialPortCommand(string.Format("copy DIAG.txt com{0}: \r\n", (object) this.m_dutcomVal));
                  this.m_bFCTTestLogCopied = true;
                  if (clsUUT.bCdiagB57diag)
                    Thread.Sleep(10000);
                  else
                    Thread.Sleep(5000);
                  if (this.m_TestMode == 8)
                    this.SendSerialPortCommand(string.Format("del DIAG.txt\r\n"));
                }
                this.cbStatusColor(Color.Red);
                this.cbStatusText("");
                if (!this.m_ProgramFRUTestResult)
                {
                  soteUtils.log2file(this.m_traceLog, this.m_results);
                  this.m_results = "";
                  if (this.m_TestMode == 2)
                  {
                    this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".oba", clsUUT.scanMAC[0], 3);
                    if (this.m_bTestSummarySection)
                    {
                      if (clsUUT.bCdiagB57diag)
                        this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                      else
                        this.ParseTestSummary(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    }
                    else
                      this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                    if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                    {
                      this.m_FCTErrorDescription = "FCT:PASS";
                      B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".oba", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-OBA-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                    }
                    else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                      this.m_FCTErrorDescription = "FCT:PASS";
                    else if (!clsUUT.bCdiagB57diag)
                      B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".oba", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-OBA-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
                  {
                    this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".sts", clsUUT.scanMAC[0], 3);
                    if (this.m_bTestSummarySection)
                    {
                      if (clsUUT.bCdiagB57diag)
                        this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                      else
                        this.ParseTestSummary(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    }
                    else
                      this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                    if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                    {
                      this.m_FCTErrorDescription = "FCT:PASS";
                      B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-STS-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                    }
                    else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                      this.m_FCTErrorDescription = "FCT:PASS";
                    else if (!clsUUT.bCdiagB57diag)
                      B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-STS-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_TestMode == 8 && (this.m_bRMAProgramNVRAM || this.m_bRMAFCT))
                  {
                    this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".rma", clsUUT.scanMAC[0], 3);
                    if (this.m_bTestSummarySection)
                    {
                      if (clsUUT.bCdiagB57diag)
                        this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                      else
                        this.ParseTestSummary(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    }
                    else
                      this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                    if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                    {
                      this.m_FCTErrorDescription = "FCT:PASS";
                      B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".rma", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-RMA-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                    }
                    else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                      this.m_FCTErrorDescription = "FCT:PASS";
                    else if (!clsUUT.bCdiagB57diag)
                      B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".rma", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-RMA-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_TestMode != 5 && this.m_TestMode != 8)
                  {
                    this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".fct", clsUUT.scanMAC[0], 3);
                    if (this.m_bTestSummarySection)
                    {
                      if (clsUUT.bCdiagB57diag)
                        this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                      else
                        this.ParseTestSummary(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    }
                    else
                      this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                    if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                    {
                      this.m_FCTErrorDescription = "FCT:PASS";
                      B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".fct", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                    }
                    else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                      this.m_FCTErrorDescription = "FCT:PASS";
                    else if (!clsUUT.bCdiagB57diag)
                      B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".fct", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  if (this.m_TestMode == 7)
                    this.runNVRAMlog(clsUUT.hw_type);
                  if (this.m_TestMode != 5 && this.m_TestMode != 8)
                    this.PowerOFF();
                  if (this.m_TestMode != 5 && this.m_TestMode != 8)
                    this.CancelTestProgressDisplay();
                  if (this.m_TestMode != 5 && (this.m_TestMode != 8 && !this.m_bRMAMACSNVerify))
                  {
                    int num1 = 0;
                    bool flag = false;
                    for (; num1 < 5 || str1 == "" || str2 == ""; ++num1)
                    {
                      frmSNMAC frmSnmac = new frmSNMAC(this.m_sfis_type, this.m_TestMode);
                      int num2 = (int) frmSnmac.ShowDialog();
                      str1 = this.m_sfis_type != 90 || this.m_TestMode == 10 || !frmSnmac.SerialNumber.Substring(0, 6).Contains("000AF7") && !frmSnmac.SerialNumber.Substring(0, 6).Contains("001018") ? frmSnmac.SerialNumber : frmSnmac.SerialNumber.Substring(4, frmSnmac.SerialNumber.Length - 4);
                      str2 = !(clsUUT.hw_type == "SHARKNADO4") && !(clsUUT.hw_type == "SHARKNADO2") && (!(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A3120L")) && (!(clsUUT.hw_type == "A4160L") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "M150PM") && !clsUUT.bOCP30 ? frmSnmac.MACAddress : frmSnmac.MACAddress.Substring(0, 12)) : frmSnmac.MACAddress.Substring(3, 12);
                      this.m_SNLabel = frmSnmac.SerialNumber;
                      this.m_MACLabel = frmSnmac.MACAddress;
                      frmSnmac.Dispose();
                      if (this.m_sfis_type == 90 && str1 == clsUUT.esrLabel + clsUUT.scanLabel && str2 == clsUUT.scanMAC[0])
                      {
                        flag = true;
                        break;
                      }
                      if (this.m_sfis_type != 90 && str1 == clsUUT.scanLabel && str2 == clsUUT.scanMAC[0])
                      {
                        flag = true;
                        break;
                      }
                    }
                    if (!flag)
                    {
                      this.m_results += "\r\n\r\nLABELVerify:SN/MAC doesn't match pre/post test";
                      if (this.m_sfis_type == 90)
                        this.m_results += string.Format("\r\nPreTestScannedSNLabel: {0}", (object) (clsUUT.esrLabel + clsUUT.scanLabel));
                      else
                        this.m_results += string.Format("\r\nPreTestScannedSNLabel: {0}", (object) clsUUT.scanLabel);
                      this.m_results += string.Format("\r\nPosTestScannedSNLabel: {0}", (object) str1);
                      this.m_results += string.Format("\r\nPreTestScannedMACLabel: {0}", (object) clsUUT.scanMAC[0]);
                      this.m_results += string.Format("\r\nPosTestScannedMACLabel: {0}", (object) str2);
                      soteUtils.log2file(this.m_traceLog, this.m_results);
                      this.m_results = "";
                      soteDiag.soteDiag.showFailMsgDlg("SN/MAC doesn't match pre/post test!");
                      this.m_iLABELErrorCode = 21000;
                      this.m_LABELErrorDescription = "LABELVerify:SN/MAC doesn't match pre/post test";
                    }
                    else
                    {
                      this.m_iLABELErrorCode = 0;
                      this.m_LABELErrorDescription = "LABELVerify:PASS";
                    }
                    this.SendPostResult(clsUUT.scanLabel, clsUUT.scanMAC[0], (uint) clsUUT.mac_count, (uint) clsUUT.mac_increment);
                    this.m_bHotSwapped = true;
                    if (this.m_txtOverallTestResult.Contains("PASS"))
                    {
                      int num3 = (int) new frmPass()
                      {
                        Message = "Continue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing...!"
                      }.ShowDialog();
                    }
                    else
                    {
                      int num4 = (int) new frmFail()
                      {
                        Message = (this.m_txtOverallErrorDescription.Replace("; ", "\r\n") + "\n\nContinue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing...!")
                      }.ShowDialog();
                    }
                    if (this.m_bHotSwapped)
                    {
                      this.InitializeTestResults();
                      this.m_ready = false;
                      this.cbChkSFIS(true);
                      this.cbUUTGroup(true);
                      this.cbUUTLabelFocus();
                      Color c = Color.Red;
                      this.cbgoldenSampleMode(true);
                      while (!this.m_userabort && !this.m_ready)
                      {
                        this.cbbtnOK(true);
                        this.cbButtonBADGE(true);
                        this.cbStatus2Text("");
                        this.cbStatusText("Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......");
                        c = c == Color.Red ? Color.Green : Color.Red;
                        this.cbStatusColor(c);
                        Thread.Sleep(500);
                      }
                      this.cbStatusColor(Color.Black);
                      this.cbStatusText("");
                    }
                  }
                  this.cbButtonBADGE(false);
                  if (this.m_TestMode != 5 && this.m_TestMode != 8)
                    this.DisplayTestProgress();
                  else if (this.m_TestMode == 5 && this.m_Loop == this.m_TestLoop || this.m_TestMode == 8 && this.m_Loop == this.m_nRMATestLoop)
                    break;
                  this.rebootDOSPC();
                  break;
                }
                if ((this.m_TestMode != 5 || this.m_bNVRAMVerifyEnabled || this.m_bFRUVerifyEnabled) && (this.m_TestMode != 8 || this.m_bRMANVRAMVerify || this.m_bRMAFRUVerify) && (this.m_TestMode != 8 || this.m_bRMAFCT))
                  this.rebootDOSPC();
                this.runNVRAMverify(clsUUT.hw_type);
                this.verifyFRU(clsUUT.hw_type);
                while (!this.m_userabort)
                {
                  if (this.m_results.Contains("logfile closed at") || this.m_TestMode == 5 && !this.m_bNVRAMVerifyEnabled || this.m_TestMode == 8 && !this.m_bRMANVRAMVerify || this.m_results.Contains("NVRAM verify test completed"))
                  {
                    Thread.Sleep(1000);
                    break;
                  }
                  if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                  {
                    this.cbTerminal("TIMEOUT");
                    frmFail frmFail = new frmFail();
                    string str3 = !this.m_usbrelayenable ? "Failed to detect the device\n\nClose the app and reboot DOS PC!" : "Failed to detect the device\n\nClose the app and restart the test!";
                    soteDiag.soteDiag soteDiag2 = this;
                    soteDiag2.m_results = soteDiag2.m_results + "\r\nFAIL: TIMEOUT" + str3;
                    frmFail.Message = str3;
                    int num = (int) frmFail.ShowDialog();
                    this.m_FCTErrorDescription = "NVRAMVerify:No ACK from the DUT";
                    this.m_iFCTErrorCode = 300;
                    this.RaiseUserAbortEvent();
                  }
                }
                if ((this.m_TestMode != 5 || this.m_bNVRAMVerifyEnabled) && (this.m_TestMode != 8 || this.m_bRMANVRAMVerify))
                {
                  this.SendSerialPortCommand(string.Format("copy READMAC.txt com{0}: \r\n", (object) this.m_dutcomVal));
                  this.m_bNVRAMVerifyTestStarted = false;
                  this.m_bNVRAMVerifyTestLogCopied = true;
                  Thread.Sleep(3000);
                  this.cbStatusColor(Color.Black);
                  this.cbStatusText("");
                }
                if (clsUUT.hw_type == "OBRIEN" && (this.m_TestMode != 5 || this.m_bNCSIEnabled || (this.m_TestMode != 8 || this.m_bRMANCSI)))
                {
                  this.runNCSITest();
                  this.verifyNCSITest(this.logDir + this.m_logFileName + ".ncsi");
                }
                soteUtils.log2file(this.m_traceLog, this.m_results);
                this.m_results = "";
                if (this.m_TestMode == 2)
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".oba", clsUUT.scanMAC[0], 3);
                  if (this.m_bTestSummarySection)
                  {
                    if (clsUUT.bCdiagB57diag)
                      this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    else
                      this.ParseTestSummary(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  }
                  else
                    this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                  if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                  {
                    this.m_FCTErrorDescription = "FCT:PASS";
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".oba", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-OBA-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                    this.m_FCTErrorDescription = "FCT:PASS";
                  else if (!clsUUT.bCdiagB57diag)
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".oba", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-OBA-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                }
                else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".sts", clsUUT.scanMAC[0], 3);
                  if (this.m_bTestSummarySection)
                  {
                    if (clsUUT.bCdiagB57diag)
                      this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    else
                      this.ParseTestSummary(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  }
                  else
                    this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                  if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                  {
                    this.m_FCTErrorDescription = "FCT:PASS";
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-STS-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                    this.m_FCTErrorDescription = "FCT:PASS";
                  else if (!clsUUT.bCdiagB57diag)
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-STS-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                }
                else if (this.m_TestMode == 8 && (this.m_bRMAFCT || this.m_bRMAProgramNVRAM))
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".rma", clsUUT.scanMAC[0], 3);
                  if (this.m_bTestSummarySection)
                  {
                    if (clsUUT.bCdiagB57diag)
                      this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    else
                      this.ParseTestSummary(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  }
                  else
                    this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                  if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                  {
                    this.m_FCTErrorDescription = "FCT:PASS";
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".rma", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-RMA-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                    this.m_FCTErrorDescription = "FCT:PASS";
                  else if (!clsUUT.bCdiagB57diag)
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".rma", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-RMA-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                }
                else if (this.m_TestMode != 5 && this.m_TestMode != 8)
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".fct", clsUUT.scanMAC[0], 3);
                  if (this.m_bTestSummarySection)
                  {
                    if (clsUUT.bCdiagB57diag)
                      this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    else
                      this.ParseTestSummary(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  }
                  else
                    this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                  if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                  {
                    this.m_FCTErrorDescription = "FCT:PASS";
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".fct", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                    this.m_FCTErrorDescription = "FCT:PASS";
                  else if (!clsUUT.bCdiagB57diag)
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".fct", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                }
                if ((this.m_TestMode != 5 || this.m_bNVRAMVerifyEnabled) && (this.m_TestMode != 8 || this.m_bRMANVRAMVerify))
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".ver", clsUUT.scanMAC[0], 4);
                  if (clsUUT.bCdiag && !clsUUT.bCdiagB57diag)
                    this.verifyNVRAMCdiag(clsUUT.hw_type, this.logDir + this.m_logFileName + ".ver", clsUUT.scanMAC[0], clsUUT.mac_count);
                  else if (clsUUT.bCdiagB57diag)
                    this.verifyNVRAMCdiagB57diag(clsUUT.hw_type, this.logDir + this.m_logFileName + ".ver", clsUUT.scanMAC[0], clsUUT.mac_count);
                  else
                    this.verifyNVRAM(clsUUT.hw_type, this.logDir + this.m_logFileName + ".ver", clsUUT.scanMAC[0], clsUUT.mac_count);
                }
                if (this.m_TestMode == 7)
                  this.runNVRAMlog(clsUUT.hw_type);
                if (this.m_TestMode != 5 && this.m_TestMode != 8)
                  this.PowerOFF();
                if (this.m_TestMode != 5 && this.m_TestMode != 8)
                  this.CancelTestProgressDisplay();
                if (this.m_TestMode != 5 && (this.m_TestMode != 8 && !this.m_bRMAMACSNVerify))
                {
                  int num1 = 0;
                  bool flag = false;
                  for (; num1 < 5 || str1 == "" || str2 == ""; ++num1)
                  {
                    frmSNMAC frmSnmac = new frmSNMAC(this.m_sfis_type, this.m_TestMode);
                    int num2 = (int) frmSnmac.ShowDialog();
                    str1 = this.m_sfis_type != 90 || this.m_TestMode == 10 || !frmSnmac.SerialNumber.Substring(0, 6).Contains("000AF7") && !frmSnmac.SerialNumber.Substring(0, 6).Contains("001018") ? frmSnmac.SerialNumber : frmSnmac.SerialNumber.Substring(4, frmSnmac.SerialNumber.Length - 4);
                    str2 = !(clsUUT.hw_type == "SHARKNADO4") && !(clsUUT.hw_type == "SHARKNADO2") && (!(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A3120L")) && (!(clsUUT.hw_type == "A4160L") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "M150PM") && !clsUUT.bOCP30 ? frmSnmac.MACAddress : frmSnmac.MACAddress.Substring(0, 12)) : frmSnmac.MACAddress.Substring(3, 12);
                    this.m_SNLabel = frmSnmac.SerialNumber;
                    this.m_MACLabel = frmSnmac.MACAddress;
                    frmSnmac.Dispose();
                    if (this.m_sfis_type == 90 && str1 == clsUUT.esrLabel + clsUUT.scanLabel && str2 == clsUUT.scanMAC[0])
                    {
                      flag = true;
                      break;
                    }
                    if (this.m_sfis_type != 90 && str1 == clsUUT.scanLabel && str2 == clsUUT.scanMAC[0])
                    {
                      flag = true;
                      break;
                    }
                  }
                  if (!flag)
                  {
                    soteDiag.soteDiag.showFailMsgDlg("SN/MAC doesn't match pre/post test!");
                    this.m_results += "\r\n\r\nLABELVerify:SN/MAC doesn't match pre/post test";
                    if (this.m_sfis_type == 90)
                      this.m_results += string.Format("\r\nPreTestScannedSNLabel: {0}", (object) (clsUUT.esrLabel + clsUUT.scanLabel));
                    else
                      this.m_results += string.Format("\r\nPreTestScannedSNLabel: {0}", (object) clsUUT.scanLabel);
                    this.m_results += string.Format("\r\nPosTestScannedSNLabel: {0}", (object) str1);
                    this.m_results += string.Format("\r\nPreTestScannedMACLabel: {0}", (object) clsUUT.scanMAC[0]);
                    this.m_results += string.Format("\r\nPosTestScannedMACLabel: {0}", (object) str2);
                    soteUtils.log2file(this.m_traceLog, this.m_results);
                    this.m_results = "";
                    this.m_LABELErrorDescription = "LABELVerify:SN/MAC doesn't match pre/post test";
                    this.m_iLABELErrorCode = 21000;
                  }
                  else
                  {
                    this.m_iLABELErrorCode = 0;
                    this.m_LABELErrorDescription = "LABELVerify:PASS";
                  }
                  this.m_bHotSwapped = true;
                  this.SendPostResult(clsUUT.scanLabel, clsUUT.scanMAC[0], (uint) clsUUT.mac_count, (uint) clsUUT.mac_increment);
                  if (this.m_txtOverallTestResult.Contains("PASS"))
                  {
                    int num3 = (int) new frmPass()
                    {
                      Message = "Continue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing...!"
                    }.ShowDialog();
                  }
                  else
                  {
                    int num4 = (int) new frmFail()
                    {
                      Message = (this.m_txtOverallErrorDescription.Replace("; ", "\r\n") + "\n\nContinue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing...")
                    }.ShowDialog();
                  }
                  if (this.m_bHotSwapped)
                  {
                    this.InitializeTestResults();
                    this.m_ready = false;
                    this.cbChkSFIS(true);
                    this.cbUUTGroup(true);
                    this.cbUUTLabelFocus();
                    this.cbgoldenSampleMode(true);
                    Color c = Color.Red;
                    while (!this.m_userabort && !this.m_ready)
                    {
                      this.cbbtnOK(true);
                      this.cbButtonBADGE(true);
                      this.cbStatus2Text("");
                      this.cbStatusText("Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......");
                      c = c == Color.Red ? Color.Green : Color.Red;
                      this.cbStatusColor(c);
                      Thread.Sleep(500);
                    }
                    this.cbStatusColor(Color.Black);
                    this.cbStatusText("");
                  }
                }
                this.cbButtonBADGE(false);
                if (this.m_TestMode != 5 && this.m_TestMode != 8)
                  this.DisplayTestProgress();
                else if (this.m_TestMode == 5 && this.m_Loop == this.m_TestLoop || this.m_TestMode == 8 && this.m_Loop == this.m_nRMATestLoop)
                  break;
                this.rebootDOSPC();
                break;
              }
              if (clsUUT.bCdiagB57diag && this.m_results.Contains("b57diag NVRAM program completed") && this.m_results.Contains("FCT NVRAM program completed") && (this.m_results.Contains("Result = FAIL") || this.m_results.Contains("Total test time =") || this.m_results.Contains("Total summary:")) || clsUUT.bCdiag && !clsUUT.bB57diag && this.m_results.Contains("FCT NVRAM program completed") && (this.m_results.Contains("Result = FAIL") || this.m_results.Contains("Total summary:")) || (clsUUT.bCdiagB57diag && this.m_results.Contains("b57diag test completed") && this.m_results.Contains("FCT test completed") && (this.m_results.Contains("Result = FAIL") || this.m_results.Contains("Total test time =") || this.m_results.Contains("Total summary:")) || clsUUT.bCdiag && !clsUUT.bB57diag && this.m_results.Contains("FCT test completed") && (this.m_results.Contains("Result = FAIL") || this.m_results.Contains("Total summary:"))) || !clsUUT.bCdiag && clsUUT.bB57diag && this.m_results.Contains("FCT test completed") && (this.m_results.Contains("Result = FAIL") || this.m_results.Contains("fail") || this.m_results.Contains("Fail") || this.m_results.Contains("Total test time =")))
              {
                this.cbStatusColor(Color.Red);
                this.cbStatusText("......FCT test Failed......FCT test Failed......FCT test Failed......FCT test Failed......FCT test Failed......");
                if (this.m_results.Contains("Result = FAIL"))
                  this.m_bTestSummarySection = true;
                Thread.Sleep(1000);
                if ((this.m_TestMode != 5 || this.m_bFCTEnabled) && (this.m_TestMode != 8 || this.m_bRMAFCT || this.m_bRMAProgramNVRAM))
                {
                  this.SendSerialPortCommand(string.Format("copy DIAG.txt com{0}: \r\n", (object) this.m_dutcomVal));
                  this.m_bFCTTestLogCopied = true;
                  if (clsUUT.bCdiagB57diag)
                    Thread.Sleep(10000);
                  else
                    Thread.Sleep(5000);
                  if (this.m_TestMode == 8)
                    this.SendSerialPortCommand(string.Format("del DIAG.txt\r\n"));
                }
                soteDiag.soteDiag soteDiag2 = this;
                soteDiag2.m_results = soteDiag2.m_results + "\r\nCurrent Win7 DateTime:" + (object) this.m_timestamp + "\r\n";
                soteUtils.log2file(this.m_traceLog, this.m_results);
                this.m_results = "";
                if (this.m_TestMode == 2)
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".oba", clsUUT.scanMAC[0], 3);
                  if (this.m_bTestSummarySection)
                  {
                    if (clsUUT.bCdiagB57diag)
                      this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    else
                      this.ParseTestSummary(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  }
                  else
                    this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                  if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                  {
                    this.m_FCTErrorDescription = "FCT:PASS";
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".oba", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                    this.m_FCTErrorDescription = "FCT:PASS";
                  else if (!clsUUT.bCdiagB57diag)
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".oba", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                }
                else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".sts", clsUUT.scanMAC[0], 3);
                  if (this.m_bTestSummarySection)
                  {
                    if (clsUUT.bCdiagB57diag)
                      this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    else
                      this.ParseTestSummary(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  }
                  else
                    this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                  if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                  {
                    this.m_FCTErrorDescription = "FCT:PASS";
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-STS-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                    this.m_FCTErrorDescription = "FCT:PASS";
                  else if (!clsUUT.bCdiagB57diag)
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-STS-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                }
                else if (this.m_TestMode == 8 && (this.m_bRMAFCT || this.m_bRMAProgramNVRAM))
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".rma", clsUUT.scanMAC[0], 3);
                  if (this.m_bTestSummarySection)
                  {
                    if (clsUUT.bCdiagB57diag)
                      this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    else
                      this.ParseTestSummary(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  }
                  else
                    this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                  if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                  {
                    this.m_FCTErrorDescription = "FCT:PASS";
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".rma", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-RMA-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                    this.m_FCTErrorDescription = "FCT:PASS";
                  else if (!clsUUT.bCdiagB57diag)
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".rma", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-RMA-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                }
                else if (this.m_TestMode != 5 && this.m_TestMode != 8)
                {
                  this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".fct", clsUUT.scanMAC[0], 3);
                  if (this.m_bTestSummarySection)
                  {
                    if (clsUUT.bCdiagB57diag)
                      this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                    else
                      this.ParseTestSummary(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  }
                  else
                    this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
                  this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
                  if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
                  {
                    this.m_FCTErrorDescription = "FCT:PASS";
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".fct", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                  }
                  else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
                    this.m_FCTErrorDescription = "FCT:PASS";
                  else if (!clsUUT.bCdiagB57diag)
                    B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".fct", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
                }
                if (this.m_TestMode == 7)
                  this.runNVRAMlog(clsUUT.hw_type);
                if (this.m_TestMode != 5 && this.m_TestMode != 8)
                  this.PowerOFF();
                if (this.m_TestMode != 5 && this.m_TestMode != 8)
                  this.CancelTestProgressDisplay();
                if (this.m_TestMode != 5 && (this.m_TestMode != 8 && !this.m_bRMAMACSNVerify))
                {
                  int num1 = 0;
                  bool flag = false;
                  for (; num1 < 5 || str1 == "" || str2 == ""; ++num1)
                  {
                    frmSNMAC frmSnmac = new frmSNMAC(this.m_sfis_type, this.m_TestMode);
                    int num2 = (int) frmSnmac.ShowDialog();
                    str1 = this.m_sfis_type != 90 || this.m_TestMode == 10 || !frmSnmac.SerialNumber.Substring(0, 6).Contains("000AF7") && !frmSnmac.SerialNumber.Substring(0, 6).Contains("001018") ? frmSnmac.SerialNumber : frmSnmac.SerialNumber.Substring(4, frmSnmac.SerialNumber.Length - 4);
                    str2 = !(clsUUT.hw_type == "SHARKNADO4") && !(clsUUT.hw_type == "SHARKNADO2") && (!(clsUUT.hw_type == "M4161") && !(clsUUT.hw_type == "A3120L")) && (!(clsUUT.hw_type == "A4160L") && !(clsUUT.hw_type == "CASPIAN")) && !(clsUUT.hw_type == "ARAL") ? (!(clsUUT.hw_type == "M150PM") && !clsUUT.bOCP30 ? frmSnmac.MACAddress : frmSnmac.MACAddress.Substring(0, 12)) : frmSnmac.MACAddress.Substring(3, 12);
                    this.m_SNLabel = frmSnmac.SerialNumber;
                    this.m_MACLabel = frmSnmac.MACAddress;
                    frmSnmac.Dispose();
                    if (this.m_sfis_type == 90 && str1 == clsUUT.esrLabel + clsUUT.scanLabel && str2 == clsUUT.scanMAC[0])
                    {
                      flag = true;
                      break;
                    }
                    if (this.m_sfis_type != 90 && str1 == clsUUT.scanLabel && str2 == clsUUT.scanMAC[0])
                    {
                      flag = true;
                      break;
                    }
                  }
                  if (!flag)
                  {
                    soteDiag.soteDiag.showFailMsgDlg("SN/MAC doesn't match pre/post test!");
                    this.m_results += "\r\n\r\n\nLABELVerify:SN/MAC doesn't match pre/post test";
                    if (this.m_sfis_type == 90)
                      this.m_results += string.Format("\r\nPreTestScannedSNLabel: {0}", (object) (clsUUT.esrLabel + clsUUT.scanLabel));
                    else
                      this.m_results += string.Format("\r\nPreTestScannedSNLabel: {0}", (object) clsUUT.scanLabel);
                    this.m_results += string.Format("\r\nPosTestScannedSNLabel: {0}", (object) str1);
                    this.m_results += string.Format("\r\nPreTestScannedMACLabel: {0}", (object) clsUUT.scanMAC[0]);
                    this.m_results += string.Format("\r\nPosTestScannedMACLabel: {0}", (object) str2);
                    soteUtils.log2file(this.m_traceLog, this.m_results);
                    this.m_results = "";
                    this.m_LABELErrorDescription = "LABELVerify:SN/MAC doesn't match pre/post test";
                    this.m_iLABELErrorCode = 21000;
                  }
                  else
                  {
                    this.m_iLABELErrorCode = 0;
                    this.m_LABELErrorDescription = "LABELVerify:PASS";
                  }
                  this.SendPostResult(clsUUT.scanLabel, clsUUT.scanMAC[0], (uint) clsUUT.mac_count, (uint) clsUUT.mac_increment);
                  this.m_bHotSwapped = true;
                  if (this.m_txtOverallTestResult.Contains("PASS"))
                  {
                    int num3 = (int) new frmPass()
                    {
                      Message = "Continue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing..."
                    }.ShowDialog();
                  }
                  else
                  {
                    int num4 = (int) new frmFail()
                    {
                      Message = (this.m_txtOverallErrorDescription.Replace("; ", "\r\n") + "\n\nContinue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing...")
                    }.ShowDialog();
                  }
                  if (this.m_bHotSwapped)
                  {
                    this.InitializeTestResults();
                    this.m_ready = false;
                    this.cbChkSFIS(true);
                    this.cbUUTGroup(true);
                    this.cbUUTLabelFocus();
                    this.cbgoldenSampleMode(true);
                    Color c = Color.Red;
                    while (!this.m_userabort && !this.m_ready)
                    {
                      this.cbbtnOK(true);
                      this.cbButtonBADGE(true);
                      this.cbStatus2Text("");
                      this.cbStatusText("Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......Please scan in LABEL and MAC to start test......or Hit 'X' to exit test......");
                      c = c == Color.Red ? Color.Green : Color.Red;
                      this.cbStatusColor(c);
                      Thread.Sleep(500);
                    }
                    this.cbStatusColor(Color.Black);
                    this.cbStatusText("");
                  }
                }
                this.cbButtonBADGE(false);
                if (this.m_TestMode != 5 && this.m_TestMode != 8)
                  this.DisplayTestProgress();
                else if (this.m_TestMode == 5 && this.m_Loop == this.m_TestLoop || this.m_TestMode == 8 && this.m_Loop == this.m_nRMATestLoop)
                  break;
                if (!this.m_bStopOnFail_poweron)
                {
                  this.rebootDOSPC();
                  break;
                }
                break;
              }
            }
            this.cbChkSFIS(true);
            this.cbUUTGroup(true);
            this.cbgoldenSampleMode(true);
            this.m_commport.DisablePort();
            if (this.m_TestMode == 5 || this.m_TestMode == 8)
            {
              this.SendPostResult(clsUUT.scanLabel, clsUUT.scanMAC[0], (uint) clsUUT.mac_count, (uint) clsUUT.mac_increment);
              ++this.m_Loop;
            }
            if (this.m_TestMode == 8 && this.m_txtOverallTestResult.Contains("FAIL"))
              this.m_bRMAOverallTestResults = false;
            if (this.m_TestMode == 5 && this.m_Loop > this.m_TestLoop)
            {
              this.cbStatusColor(Color.BlueViolet);
              this.CancelTestProgressDisplay();
              this.PowerOFF();
              this.cbtxtLabel(false);
              this.cbtxtMAC(false);
              this.cbbtnOK(false);
              this.cbgoldenSampleMode(false);
              this.cbStatusText("STRESS Test Completed!");
              int num = (int) new NewMessageBox()
              {
                Message = "STRESS Test Completed!  \n\nPlease click 'EXIT' to Stop Testing!"
              }.ShowDialog();
              break;
            }
            if (this.m_TestMode == 8 && this.m_Loop > this.m_nRMATestLoop)
            {
              this.cbStatusColor(Color.BlueViolet);
              this.CancelTestProgressDisplay();
              this.PowerOFF();
              if (!this.m_bRMAOverallTestResults)
              {
                this.cbStatusText("RMA Test Completed with Failure!");
                int num = (int) new frmFail()
                {
                  Message = "RMA Test FAILED!...\n\nContinue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing...!"
                }.ShowDialog();
              }
              else
              {
                this.cbStatusText("RMA Test Completed!");
                int num = (int) new frmPass()
                {
                  Message = "RMA Test PASSED!...\n\nContinue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing...!"
                }.ShowDialog();
              }
              this.m_bHotSwapped = false;
              this.m_Loop = 1;
              this.cbbtnOK(true);
              this.m_bFirsttime = true;
              this.m_bRMAContinueTest = true;
            }
            else
            {
              if (this.m_TestMode == 5 && this.m_bStopOnFail && this.m_txtOverallTestResult.Contains("FAIL"))
              {
                this.cbStatusColor(Color.BlueViolet);
                this.CancelTestProgressDisplay();
                if (!this.m_bStopOnFail_poweron)
                  this.PowerOFF();
                this.cbtxtLabel(false);
                this.cbtxtMAC(false);
                this.cbbtnOK(false);
                this.cbgoldenSampleMode(false);
                this.cbStatusText("STRESS Test Aborted!");
                soteDiag.soteDiag.showFailMsgDlg("STRESS Test Aborted!  \n\nPlease click 'EXIT' to Stop Testing!");
                break;
              }
              if (this.m_TestMode == 8 && this.m_bRMAStopOnFailure && this.m_txtOverallTestResult.Contains("FAIL"))
              {
                this.cbStatusColor(Color.BlueViolet);
                this.CancelTestProgressDisplay();
                this.PowerOFF();
                this.cbtxtLabel(false);
                this.cbtxtMAC(false);
                this.cbbtnOK(false);
                this.cbgoldenSampleMode(false);
                this.cbStatusText("RMA Test Aborted with FAILURE!");
                int num = (int) new frmFail()
                {
                  Message = "RMA Test Aborted with FAILURE!...\n\nContinue testing...Please scan the SN and\nMAC labels of the next DUT!\n\nOr\n\nClick 'EXIT' to Stop testing...!"
                }.ShowDialog();
                break;
              }
            }
          }
          else
            break;
        }
      }
      catch (Exception ex)
      {
        if (ex.Message.Contains("Thread was being aborted") || this.m_userabort)
          return;
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nRunTestThread: " + ex.Message;
        if (ex.Message.Contains("Object reference not set to an instance of an object") && this.m_nPowerupRetry < 1)
        {
          ++this.m_nPowerupRetry;
          this.rebootDOSPC();
        }
        else if (ex.Message.Contains("Object reference not set to an instance of an object") && this.m_nPowerupRetry >= 1)
        {
          int num = (int) new frmFail()
          {
            Message = "Failed to establish serial communication!\n\nCheck COM port connection!"
          }.ShowDialog();
          this.RaiseUserAbortEvent();
        }
        else
        {
          int num = (int) new frmFail()
          {
            Message = "RunTestThread: Exception encountered!"
          }.ShowDialog();
          this.RaiseUserAbortEvent();
        }
      }
    }

    public void verifyNCSITest(string filenamepath)
    {
      TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(filenamepath, FileMode.Open));
      string str;
      while ((str = textReader.ReadLine()) != null)
      {
        if (str.Contains("RESULT: PASS"))
        {
          this.m_iNCSIErrorCode = 0;
          this.m_NCSIErrorDescription = "NCSI:PASS";
          this.cbStatusColor(Color.Green);
          this.cbStatusText("...NCSI Test Passed...NCSI Test Passed...NCSI Test Passed...NCSI Test Passed...NCSI Test Passed...NCSI Test Passed...");
          break;
        }
        if (str.Contains("RESULT: FAIL"))
        {
          this.m_iNCSIErrorCode = 34000;
          this.m_NCSIErrorDescription = "NCSI:FAIL";
          this.cbStatusColor(Color.Red);
          this.cbStatusText("...NCSI Test Failed...NCSI Test Failed...NCSI Test Failed...NCSI Test Failed...NCSI Test Failed...NCSI Test Failed...");
          break;
        }
      }
      textReader.Close();
    }

    public bool verifyFWVersion(string hw_type, string filenamepath)
    {
      bool flag1 = true;
      bool flag2;
      if (!(flag2 = this.loadFwCheckConfig(hw_type)))
        return flag2;
      TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(filenamepath, FileMode.Open));
      int num1 = 0;
      int num2 = 0;
      string str;
      while ((str = textReader.ReadLine()) != null)
      {
        ++num1;
        if (str.Contains("0 5720 PA0") && str.Contains(this.m_FW_Version) && str.Contains(this.m_DEV0_CFG))
          ++num2;
        else if (str.Contains("1 5720 SA0") && str.Contains(this.m_FW_Version) && str.Contains(this.m_DEV1_CFG))
          ++num2;
        else if (str.Contains("2 5720 PA0") && str.Contains(this.m_FW_Version) && str.Contains(this.m_DEV2_CFG))
          ++num2;
        else if (str.Contains("3 5720 SA0") && str.Contains(this.m_FW_Version) && str.Contains(this.m_DEV3_CFG))
          ++num2;
      }
      textReader.Close();
      if (num2 != 8)
      {
        this.m_results += "\r\n***Preprogrammed FW Version doesn't match!; Need to reprogram the FW images***";
        flag1 = false;
      }
      else
        this.m_results += "\r\n***Preprogrammed FW Version matched; No need to reprogram the FW images***";
      return flag1;
    }

    public bool parseCdiagNVRAMLog(string hw_type, string filenamepath)
    {
      bool flag = false;
      try
      {
        if (!File.Exists(filenamepath))
        {
          soteDiag.soteDiag.showFailMsgDlg("Missing NVRAM log file: \n\n" + filenamepath);
          return false;
        }
        TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(filenamepath, FileMode.Open));
        string str;
        while ((str = textReader.ReadLine()) != null)
        {
          if (str.Contains("Type  Ordinal NVM Offset    Image Len   Content  Computed  Result"))
            flag = true;
          if (!flag)
          {
            if (str.Contains("CFW "))
            {
              this.m_CFW = str.Substring(str.Length - 11, 11).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("CFW2 "))
            {
              this.m_CFW2 = str.Substring(str.Length - 11, 11).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("CFWP "))
            {
              this.m_CFWP = str.Substring(str.Length - 11, 11).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("BFW "))
            {
              this.m_BFW = str.Substring(str.Length - 11, 11).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("MBA "))
            {
              this.m_MBA = str.Substring(str.Length - 22, 11).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("CCM "))
            {
              this.m_CCM = str.Substring(str.Length - 11, 11).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("IBOOT "))
            {
              this.m_iSCSI_Boot = str.Substring(str.Length - 21, 11).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("AFW "))
            {
              this.m_APE_Firmware = str.Substring(str.Length - 11, 11).ToUpper();
              ++this.m_Total_FW_Check;
            }
          }
          if (flag)
          {
            if (str.Contains("PCIE "))
            {
              this.m_PCIE = str.Substring(str.Length - 11, 8).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("PCFG   00 "))
            {
              this.m_PCFG00 = str.Substring(str.Length - 9, 8).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("PCFG   01 "))
            {
              this.m_PCFG01 = str.Substring(str.Length - 9, 8).ToUpper();
              ++this.m_Total_FW_Check;
            }
            else if (str.Contains("SCFG "))
            {
              this.m_SCFG = str.Substring(str.Length - 9, 8).ToUpper();
              ++this.m_Total_FW_Check;
            }
          }
          if (flag && str.Contains("Log close"))
            flag = false;
          if (flag && str.Contains("Reading temperature...."))
            flag = false;
        }
        textReader.Close();
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nparseCdiagNVRAMlog: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("parseCdiagNVRAMlog: \n" + ex.Message);
        return false;
      }
      return true;
    }

    public bool verifyNVRAMCdiag(
      string hw_type,
      string filenamepath,
      string firstMAC,
      int maccount)
    {
      bool flag1 = true;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      try
      {
        string str1 = (string) null;
        if (this.m_TestMode == 10)
        {
          this.m_Total_FW_Check = 1;
          bool cdiagNvramLog;
          if (!(cdiagNvramLog = this.parseCdiagNVRAMLog(clsUUT.hw_type, soteDiag.soteDiag.appPath + "\\" + this.m_esr_LogFile)))
          {
            this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Missing NVRAM log file: " + this.m_esr_LogFile;
            this.m_iNVRAMVerifyErrorCode = 10000;
            soteDiag.soteDiag soteDiag = this;
            soteDiag.m_results = soteDiag.m_results + "\r\nNVRAMVerify:Missing NVRAM log file: " + soteDiag.soteDiag.appPath + "\\" + this.m_esr_LogFile;
            soteUtils.log2file(this.m_traceLog, this.m_results);
            this.m_results = "";
            return cdiagNvramLog;
          }
        }
        else
        {
          bool flag6;
          if (!(flag6 = this.loadFwCheckConfig(hw_type)))
          {
            this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Failed to load FW check config file!";
            this.m_iNVRAMVerifyErrorCode = 10000;
            return flag6;
          }
        }
        TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(filenamepath, FileMode.Open));
        int count = maccount;
        string[] strArray1 = new string[count];
        string str2 = "";
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        double num5 = 0.0;
        double num6 = 0.0;
        this.m_results += "\r\n******FW Check Test Results******\r\n";
        string str3;
        while ((str3 = textReader.ReadLine()) != null)
        {
          string[] strArray2 = str3.Split(' ');
          ++num2;
          foreach (string str4 in strArray2)
          {
            if (num2 >= 3 && num2 <= 5 + maccount && (str4.Length == 12 && !str4.Contains(":")) && !str4.Contains("."))
              strArray1[num1++] = str4;
            if (str4.Length == 2 && str3.Contains("SN Serial Number"))
              str2 = str3.Substring(26, 10);
          }
          if (str3.Contains("Type  Ordinal NVM Offset    Image Len   Content  Computed  Result"))
            flag2 = true;
          if (flag2 && str3.Contains("Log close"))
            flag2 = false;
          if (flag2 && str3.Contains("Reading temperature...."))
          {
            flag2 = false;
            flag3 = true;
          }
          if (this.m_bTMPCheckVerify && !flag2 && flag3)
          {
            if (flag3 && str3.Contains("PortMacro"))
            {
              string[] strArray3 = str3.Split(' ');
              num5 = Convert.ToDouble(strArray3[strArray3.Length - 1]);
            }
            if (flag3 && str3.Contains("PCIE"))
            {
              string[] strArray3 = str3.Split(' ');
              num6 = Convert.ToDouble(strArray3[strArray3.Length - 1]);
              flag4 = true;
            }
            if (flag4)
            {
              this.m_results += "\r\n\r\n\r\n******PortMacro and PCIE Temperature Check Results******";
              this.m_results += "\r\n\r\n------soteDiagTMPCheck.ini------";
              soteDiag.soteDiag soteDiag1 = this;
              soteDiag1.m_results = soteDiag1.m_results + "\r\nTEMPERATURE_CHECK_ENABLED = " + (this.m_bTMPCheckVerify ? "TRUE" : "FALSE");
              soteDiag.soteDiag soteDiag2 = this;
              soteDiag2.m_results = soteDiag2.m_results + "\r\nMAX_TEMPERATURE_THRESHOLD = " + (object) this.m_dMax_Temperature_Threshold;
              if (num5 > this.m_dMax_Temperature_Threshold || num6 > this.m_dMax_Temperature_Threshold)
              {
                this.m_iFCTErrorCode = 999;
                this.m_FCTErrorDescription = "FCT:Temperature is Too High";
                this.m_results += "\r\n\r\n---------Cdiag reported---------";
                soteDiag.soteDiag soteDiag3 = this;
                soteDiag3.m_results = soteDiag3.m_results + "\r\nPortMacro Temperature = " + (object) num5;
                soteDiag.soteDiag soteDiag4 = this;
                soteDiag4.m_results = soteDiag4.m_results + "\r\nPCIE Temperature = " + (object) num6;
                this.m_results += "\r\n\r\n----------Test Summary----------";
                this.m_results += "\r\nTEMPERATURE Check FAILED!!!";
              }
              else
              {
                this.m_results += "\r\n\r\n---------Cdiag reported---------";
                soteDiag.soteDiag soteDiag3 = this;
                soteDiag3.m_results = soteDiag3.m_results + "\r\nPortMacro Temperature = " + (object) num5;
                soteDiag.soteDiag soteDiag4 = this;
                soteDiag4.m_results = soteDiag4.m_results + "\r\nPCIE Temperature = " + (object) num6;
                this.m_results += "\r\n\r\n----------Test Summary----------";
                this.m_results += "\r\nTEMPERATURE Check PASSED!!!";
              }
              flag3 = false;
              flag5 = true;
            }
          }
          else if (!this.m_bTMPCheckVerify && !flag2 && flag3)
          {
            this.m_results += "\r\n\r\n\r\n******PortMacro and PCIE Temperature Check Results******";
            this.m_results += "\r\n\r\n------soteDiagTMPCheck.ini------";
            soteDiag.soteDiag soteDiag1 = this;
            soteDiag1.m_results = soteDiag1.m_results + "\r\nTEMPERATURE_CHECK_ENABLED = " + (this.m_bTMPCheckVerify ? "TRUE" : "FALSE");
            soteDiag.soteDiag soteDiag2 = this;
            soteDiag2.m_results = soteDiag2.m_results + "\r\nMAX_TEMPERATURE_THRESHOLD = " + (object) this.m_dMax_Temperature_Threshold;
            this.m_results += "\r\n\r\n----------Test Summary----------";
            this.m_results += "\r\nTEMPERATURE Check Feature is DISABLED.";
            this.m_results += "\r\nTEMPERATURE IS NOT Checked!!!";
            flag3 = false;
          }
          if (str3.Contains("Cdiag version"))
          {
            if (str3.Contains(this.m_esr_Engineering_Diagnostics))
            {
              this.m_results += "\r\nEngineering Diagnostics version matched.";
              ++num3;
            }
            else if (this.m_esr_Engineering_Diagnostics == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of Engineering Diagnostics in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nEngineering Diagnostics version doesn't match!";
          }
          else if (str3.Contains(" BootCode ") && !flag2)
          {
            if (str3.Contains(this.m_BootCode))
            {
              this.m_results += "\r\nBootCode version matched.";
              ++num3;
            }
            else if (this.m_BootCode == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of BootCode version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nBootCode version doesn't match!";
          }
          else if (str3.Contains(" PXE ") && !flag2)
          {
            if (str3.Contains(this.m_PXE))
            {
              this.m_results += "\r\nPXE version matched.";
              ++num3;
            }
            else if (this.m_PXE == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of PXE in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nPXE version doesn't match!";
          }
          else if (str3.Contains(" EFI ") && !flag2)
          {
            if (str3.Contains(this.m_EFI))
            {
              this.m_results += "\r\nEFI version matched.";
              ++num3;
            }
            else if (this.m_EFI == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of EFI version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nEFI version doesn't match!";
          }
          else if (str3.Contains(" AFW ") && !flag2)
          {
            if (str3.Contains(this.m_APE_Firmware))
            {
              this.m_results += "\r\nAPE Firmware version matched.";
              ++num3;
            }
            else if (this.m_APE_Firmware == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of APE Firmware version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nAPE Firmware version doesn't match!";
          }
          else if (str3.Contains(" IBOOT ") && !flag2)
          {
            if (str3.Contains(this.m_iSCSI_Boot))
            {
              this.m_results += "\r\niSCSI Boot version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_Boot == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI Boot version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI Boot version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 1 ") && !flag2)
          {
            if (str3.Contains(this.m_iSCSI_CFG_1))
            {
              this.m_results += "\r\niSCSI CFG 1 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_1 == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 1 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI CFG 1 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 2 ") && !flag2)
          {
            if (str3.Contains(this.m_iSCSI_CFG_2))
            {
              this.m_results += "\r\niSCSI CFG 2 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_2 == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 2 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI CFG 2 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 3 ") && !flag2)
          {
            if (str3.Contains(this.m_iSCSI_CFG_3))
            {
              this.m_results += "\r\niSCSI CFG 3 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_3 == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 3  version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI CFG 3 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG ") && !flag2)
          {
            if (str3.Contains(this.m_iSCSI_CFG))
            {
              this.m_results += "\r\niSCSI CFG version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI CFG version didn't match!";
          }
          else if (str3.Contains(" CCM ") && !flag2)
          {
            if (str3.Contains(this.m_CCM))
            {
              this.m_results += "\r\nCCM version matched.";
              ++num3;
            }
            else if (this.m_CCM == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of CCM version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nCCM version doesn't match!";
          }
          else if (str3.Contains(" CFW ") && !flag2)
          {
            if (str3.Contains(this.m_CFW))
            {
              this.m_results += "\r\nCFW version matched.";
              ++num3;
            }
            else if (this.m_CFW == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of CFW version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nCFW version doesn't match!";
          }
          else if (str3.Contains(" CFW2 ") && !flag2)
          {
            if (str3.Contains(this.m_CFW2))
            {
              this.m_results += "\r\nCFW2 version matched.";
              ++num3;
            }
            else if (this.m_CFW2 == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of CFW2 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nCFW2 version doesn't match!";
          }
          else if (str3.Contains(" CFWP ") && !flag2)
          {
            if (str3.Contains(this.m_CFWP))
            {
              this.m_results += "\r\nCFWP version matched.";
              ++num3;
            }
            else if (this.m_CFWP == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of CFWP version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nCFWP version doesn't match!";
          }
          else if (str3.Contains(" BFW ") && !flag2)
          {
            if (str3.Contains(this.m_BFW))
            {
              this.m_results += "\r\nBFW version matched.";
              ++num3;
            }
            else if (this.m_BFW == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of BFW version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nBFW version doesn't match!";
          }
          else if (str3.Contains(" MBA ") && !flag2)
          {
            if (str3.Contains(this.m_MBA))
            {
              this.m_results += "\r\nMBA version matched.";
              ++num3;
            }
            else if (this.m_MBA == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of MBA version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nMBA version doesn't match!";
          }
          else if (str3.Contains(" PCIE "))
          {
            if (str3.ToUpper().Contains(this.m_PCIE))
            {
              this.m_results += "\r\nPCIE checksum matched.";
              ++num3;
            }
            else if (this.m_PCIE == "N/A" && flag2)
            {
              this.m_results += "\r\nNeed to add check of PCIE checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (flag2)
              this.m_results += "\r\nPCIE checksum doesn't match!";
          }
          else if (str3.Contains(" PCFG   00 ") && !this.m_esr_Engineering_Diagnostics.Contains("1.0.18"))
          {
            if (str3.ToUpper().Contains(this.m_PCFG00))
            {
              this.m_results += "\r\nPCFG00 checksum matched.";
              ++num3;
            }
            else if (this.m_PCFG00 == "N/A" && flag2)
            {
              this.m_results += "\r\nNeed to add check of PCFG 00 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (flag2)
              this.m_results += "\r\nPCFG 00 checksum doesn't match!";
          }
          else if (str3.Contains(" PCFG   01 ") && !this.m_esr_Engineering_Diagnostics.Contains("1.0.18"))
          {
            if (str3.ToUpper().Contains(this.m_PCFG01))
            {
              this.m_results += "\r\nPCFG01 checksum matched.";
              ++num3;
            }
            else if (this.m_PCFG01 == "N/A" && flag2)
            {
              this.m_results += "\r\nNeed to add check of PCFG 01 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (flag2)
              this.m_results += "\r\nPCFG 01 checksum doesn't match!";
          }
          else if (str3.Contains(" SCFG ") && !this.m_esr_Engineering_Diagnostics.Contains("1.0.18"))
          {
            if (str3.ToUpper().Contains(this.m_SCFG))
            {
              this.m_results += "\r\nSCFG checksum matched.";
              ++num3;
            }
            else if (this.m_SCFG == "N/A" && flag2)
            {
              this.m_results += "\r\nNeed to add check of SCFG checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (flag2)
              this.m_results += "\r\nSCFG checksum doesn't match!";
          }
          else if (str3.Contains(" MBA ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_MBA_CHKSUM))
            {
              this.m_results += "\r\nMBA checksum matched.";
              ++num3;
            }
            else if (this.m_MBA_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of MBA checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nMBA checksum doesn't match!";
          }
          else if (str3.Contains(" CCM ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_CCM_CHKSUM))
            {
              this.m_results += "\r\nCCM checksum matched.";
              ++num3;
            }
            else if (this.m_CCM_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of CCM checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nCCM checksum doesn't match!";
          }
          else if (str3.Contains(" CFW ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_CFW_CHKSUM))
            {
              this.m_results += "\r\nCFW checksum matched.";
              ++num3;
            }
            else if (this.m_CFW_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of CFW checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nCFW checksum doesn't match!";
          }
          else if (str3.Contains(" CFW2 ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_CFW2_CHKSUM))
            {
              this.m_results += "\r\nCFW2 checksum matched.";
              ++num3;
            }
            else if (this.m_CFW2_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of CFW2 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nCFW2 checksum doesn't match!";
          }
          else if (str3.Contains(" CFWP ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_CFWP_CHKSUM))
            {
              this.m_results += "\r\nCFWP checksum matched.";
              ++num3;
            }
            else if (this.m_CFWP_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of CFWP checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nCFWP checksum doesn't match!";
          }
          else if (str3.Contains(" AFW ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_AFW_CHKSUM))
            {
              this.m_results += "\r\nAFW checksum matched.";
              ++num3;
            }
            else if (this.m_AFW_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of AFW checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nAFW checksum doesn't match!";
          }
          else if (str3.Contains(" BFW ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_BFW_CHKSUM))
            {
              this.m_results += "\r\nBFW checksum matched.";
              ++num3;
            }
            else if (this.m_BFW_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of BFW checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nBFW checksum doesn't match!";
          }
          else if (str3.Contains(" TSCF ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_TSCF_CHKSUM))
            {
              this.m_results += "\r\nTSCF checksum matched.";
              ++num3;
            }
            else if (this.m_TSCF_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of TSCF checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nTSCF checksum doesn't match!";
          }
          else if (str3.Contains(" IBOOT ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_IBOOT_CHKSUM))
            {
              this.m_results += "\r\nIBOOT checksum matched.";
              ++num3;
            }
            else if (this.m_IBOOT_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of IBOOT checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nIBOOT checksum doesn't match!";
          }
          else if (str3.Contains(" IB_CFG 00 ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_IBCFG00_CHKSUM))
            {
              this.m_results += "\r\nIB_CFG 00 checksum matched.";
              ++num3;
            }
            else if (this.m_IBCFG00_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of IB_CFG 00 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nIB_CFG 00 checksum doesn't match!";
          }
          else if (str3.Contains(" IB_CFG 01 ") && flag2)
          {
            if (str3.ToUpper().Contains(this.m_IBCFG01_CHKSUM))
            {
              this.m_results += "\r\nIB_CFG 01 checksum matched.";
              ++num3;
            }
            else if (this.m_IBCFG01_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of IB_CFG 01 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nIB_CFG 01 checksum doesn't match!";
          }
          if ((str3.Contains(" fail") || str3.Contains(" Fail") || str3.Contains(" Mismatch")) && flag2)
          {
            bool flag6 = false;
            this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Checksum verify failed!";
            this.m_iNVRAMVerifyErrorCode = 10000;
            textReader.Close();
            return flag6;
          }
        }
        textReader.Close();
        soteUtils.log2file(this.m_traceLog, this.m_results);
        this.m_results = "";
        if (hw_type == "BOAR" || hw_type == "BANDICOOT" || hw_type == "BOBCAT" || hw_type == "BOBOLINK")
          count = 1;
        if (clsUUT.scanMAC != null)
        {
          soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], count, 1);
          for (int index = 0; index < count; ++index)
          {
            str1 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
            if (clsUUT.scanMAC[index] != strArray1[index])
            {
              bool flag6 = false;
              this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:MAC address doesn't match!";
              this.m_iNVRAMVerifyErrorCode = 10000;
              this.m_results += string.Format("\nMAC address doesn't match! Expected: {0}  Actual: {1}", (object) clsUUT.scanMAC[index], (object) strArray1[index]);
              soteUtils.log2file(this.m_traceLog, this.m_results);
              this.m_results = "";
              return flag6;
            }
          }
        }
        if (num3 != this.m_Total_FW_Check || num4 > 0)
        {
          bool flag6 = false;
          this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:FW/Diag revision doesn't match!";
          this.m_iNVRAMVerifyErrorCode = 10000;
          this.m_results += string.Format("\r\nFAIL-Total # of FW versions to be checked: {0};  Total # of FW versions matched: {1};  Total # of FW mischecked in soteDiagFWCheck.ini: {2}", (object) this.m_Total_FW_Check, (object) num3, (object) num4);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          return flag6;
        }
        if (this.m_bTMPCheckVerify && !flag5)
        {
          this.m_iFCTErrorCode = 998;
          this.m_FCTErrorDescription = "FCT:Temperature Reading is Missing";
          this.m_results += "\r\n\r\n\r\n******PortMacro and PCIE Temperature Check Results******";
          this.m_results += "\r\n\r\n------soteDiagTMPCheck.ini------";
          soteDiag.soteDiag soteDiag1 = this;
          soteDiag1.m_results = soteDiag1.m_results + "\r\nTEMPERATURE_CHECK_ENABLED = " + (this.m_bTMPCheckVerify ? "TRUE" : "FALSE");
          soteDiag.soteDiag soteDiag2 = this;
          soteDiag2.m_results = soteDiag2.m_results + "\r\nMAX_TEMPERATURE_THRESHOLD = " + (object) this.m_dMax_Temperature_Threshold;
          this.m_results += "\r\n\r\n----------Test Summary----------";
          this.m_results += "\r\nTEMPERATURE Reading is Missing (check READMAC.TCL)!!!";
          this.m_results += "\r\nTEMPERATURE Check FAILED!!!";
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nVerifyNVRAM: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("VerifyNVRAM: \n" + ex.Message);
        flag1 = false;
        this.m_iNVRAMVerifyErrorCode = 10000;
        this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:ExceptionError";
      }
      this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:PASS";
      this.m_iNVRAMVerifyErrorCode = 0;
      return flag1;
    }

    public bool verifyNVRAMCdiagB57diag(
      string hw_type,
      string filenamepath,
      string firstMAC,
      int maccount)
    {
      bool flag1 = true;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      bool flag5 = false;
      bool flag6 = false;
      bool flag7 = false;
      bool flag8 = false;
      try
      {
        string str1 = (string) null;
        if (this.m_TestMode == 10)
        {
          this.m_Total_FW_Check = 1;
          bool cdiagNvramLog;
          if (!(cdiagNvramLog = this.parseCdiagNVRAMLog(clsUUT.hw_type, soteDiag.soteDiag.appPath + "\\" + this.m_esr_LogFile)))
          {
            this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Missing NVRAM log file: " + this.m_esr_LogFile;
            this.m_iNVRAMVerifyErrorCode = 10000;
            soteDiag.soteDiag soteDiag = this;
            soteDiag.m_results = soteDiag.m_results + "\r\nNVRAMVerify:Missing NVRAM log file: " + soteDiag.soteDiag.appPath + "\\" + this.m_esr_LogFile;
            soteUtils.log2file(this.m_traceLog, this.m_results);
            this.m_results = "";
            return cdiagNvramLog;
          }
        }
        else
        {
          bool flag9;
          if (!(flag9 = this.loadFwCheckConfig(hw_type)))
          {
            this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Failed to load FW check config file!";
            this.m_iNVRAMVerifyErrorCode = 10000;
            return flag9;
          }
        }
        TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(filenamepath, FileMode.Open));
        int count = maccount;
        string[] strArray1 = new string[count];
        string str2 = "";
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        double num5 = 0.0;
        double num6 = 0.0;
        this.m_results += "\r\n******FW Check Test Results******\r\n";
        string str3;
        while ((str3 = textReader.ReadLine()) != null)
        {
          string[] strArray2 = str3.Split(' ');
          ++num2;
          foreach (string str4 in strArray2)
          {
            if (num2 >= 6 && num2 <= 6 + maccount && str4.Length == 12 && !str4.Contains(":"))
              strArray1[num1++] = str4;
            if (str4.Length == 2 && str3.Contains("SN Serial Number"))
              str2 = str3.Substring(26, 10);
          }
          if (str3.Contains("Log open time:"))
          {
            flag3 = false;
            flag5 = false;
            flag2 = true;
            flag4 = false;
          }
          if (str3.Contains("Type  Ordinal NVM Offset    Image Len   Content  Computed  Result"))
          {
            flag4 = true;
            flag2 = false;
            flag5 = false;
            flag3 = false;
          }
          if (flag4 && str3.Contains("Log close time:"))
          {
            flag4 = false;
            flag2 = false;
            flag5 = false;
            flag3 = false;
          }
          if (str3.Contains("Log file created by Broadcom NetXtreme/NetLink Engineering Diagnostics"))
          {
            flag3 = true;
            flag5 = false;
            flag2 = false;
            flag4 = false;
          }
          if (str3.Contains("Region           Address Range     Content  Checksum Status"))
          {
            flag5 = true;
            flag3 = false;
            flag4 = false;
            flag2 = false;
          }
          if (flag5 && str3.Contains("logfile closed at"))
          {
            flag5 = false;
            flag3 = false;
            flag4 = false;
            flag2 = false;
          }
          if (flag4 && str3.Contains("Reading temperature...."))
          {
            flag4 = false;
            flag6 = true;
          }
          if (flag6 && str3.Contains("PortMacro"))
          {
            string[] strArray3 = str3.Split(' ');
            num5 = Convert.ToDouble(strArray3[strArray3.Length - 1]);
          }
          if (flag6 && str3.Contains("PCIE"))
          {
            string[] strArray3 = str3.Split(' ');
            num6 = Convert.ToDouble(strArray3[strArray3.Length - 1]);
          }
          if (this.m_bTMPCheckVerify && !flag4 && flag6)
          {
            if (flag6 && str3.Contains("PortMacro"))
            {
              string[] strArray3 = str3.Split(' ');
              num5 = Convert.ToDouble(strArray3[strArray3.Length - 1]);
            }
            if (flag6 && str3.Contains("PCIE"))
            {
              string[] strArray3 = str3.Split(' ');
              num6 = Convert.ToDouble(strArray3[strArray3.Length - 1]);
              flag7 = true;
            }
            if (flag7)
            {
              this.m_results += "\r\n\r\n\r\n******PortMacro and PCIE Temperature Check Results******";
              this.m_results += "\r\n\r\n------soteDiagTMPCheck.ini------";
              soteDiag.soteDiag soteDiag1 = this;
              soteDiag1.m_results = soteDiag1.m_results + "\r\nTEMPERATURE_CHECK_ENABLED = " + (this.m_bTMPCheckVerify ? "TRUE" : "FALSE");
              soteDiag.soteDiag soteDiag2 = this;
              soteDiag2.m_results = soteDiag2.m_results + "\r\nMAX_TEMPERATURE_THRESHOLD = " + (object) this.m_dMax_Temperature_Threshold;
              if (num5 > this.m_dMax_Temperature_Threshold || num6 > this.m_dMax_Temperature_Threshold)
              {
                this.m_iFCTErrorCode = 999;
                this.m_FCTErrorDescription = "FCT:Temperature is Too High";
                this.m_results += "\r\n\r\n---------Cdiag reported---------";
                soteDiag.soteDiag soteDiag3 = this;
                soteDiag3.m_results = soteDiag3.m_results + "\r\nPortMacro Temperature = " + (object) num5;
                soteDiag.soteDiag soteDiag4 = this;
                soteDiag4.m_results = soteDiag4.m_results + "\r\nPCIE Temperature = " + (object) num6;
                this.m_results += "\r\n\r\n----------Test Summary----------";
                this.m_results += "\r\nTEMPERATURE Check FAILED!!!";
              }
              else
              {
                this.m_results += "\r\n\r\n---------Cdiag reported---------";
                soteDiag.soteDiag soteDiag3 = this;
                soteDiag3.m_results = soteDiag3.m_results + "\r\nPortMacro Temperature = " + (object) num5;
                soteDiag.soteDiag soteDiag4 = this;
                soteDiag4.m_results = soteDiag4.m_results + "\r\nPCIE Temperature = " + (object) num6;
                this.m_results += "\r\n\r\n----------Test Summary----------";
                this.m_results += "\r\nTEMPERATURE Check PASSED!!!";
              }
              flag6 = false;
              flag8 = true;
            }
          }
          else if (!this.m_bTMPCheckVerify && !flag4 && flag6)
          {
            this.m_results += "\r\n\r\n\r\n******PortMacro and PCIE Temperature Check Results******";
            this.m_results += "\r\n\r\n------soteDiagTMPCheck.ini------";
            soteDiag.soteDiag soteDiag1 = this;
            soteDiag1.m_results = soteDiag1.m_results + "\r\nTEMPERATURE_CHECK_ENABLED = " + (this.m_bTMPCheckVerify ? "TRUE" : "FALSE");
            soteDiag.soteDiag soteDiag2 = this;
            soteDiag2.m_results = soteDiag2.m_results + "\r\nMAX_TEMPERATURE_THRESHOLD = " + (object) this.m_dMax_Temperature_Threshold;
            this.m_results += "\r\n\r\n----------Test Summary----------";
            this.m_results += "\r\nTEMPERATURE Check Feature is DISABLED.";
            this.m_results += "\r\nTEMPERATURE IS NOT Checked!!!";
            flag6 = false;
          }
          if (str3.Contains("Cdiag version") && flag2)
          {
            if (str3.Contains(this.m_esr_Engineering_Diagnostics))
            {
              this.m_results += "\r\nEngineering Diagnostics version matched.";
              ++num3;
            }
            else if (this.m_esr_Engineering_Diagnostics == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of Engineering Diagnostics in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nEngineering Diagnostics version doesn't match!";
          }
          else if (str3.Contains(" BootCode ") && flag2)
          {
            if (str3.Contains(this.m_BootCode))
            {
              this.m_results += "\r\nBootCode version matched.";
              ++num3;
            }
            else if (this.m_BootCode == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of BootCode version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nBootCode version doesn't match!";
          }
          else if (str3.Contains(" PXE ") && flag2)
          {
            if (str3.Contains(this.m_PXE))
            {
              this.m_results += "\r\nPXE version matched.";
              ++num3;
            }
            else if (this.m_PXE == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of PXE in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nPXE version doesn't match!";
          }
          else if (str3.Contains(" EFI ") && flag2)
          {
            if (str3.Contains(this.m_EFI))
            {
              this.m_results += "\r\nEFI version matched.";
              ++num3;
            }
            else if (this.m_EFI == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of EFI version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nEFI version doesn't match!";
          }
          else if (str3.Contains(" AFW ") && flag2)
          {
            if (str3.Contains(this.m_APE_Firmware))
            {
              this.m_results += "\r\nAPE Firmware version matched.";
              ++num3;
            }
            else if (this.m_APE_Firmware == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of APE Firmware version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nAPE Firmware version doesn't match!";
          }
          else if (str3.Contains(" IBOOT ") && flag2)
          {
            if (str3.Contains(this.m_iSCSI_Boot))
            {
              this.m_results += "\r\niSCSI Boot version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_Boot == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of iSCSI Boot version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\niSCSI Boot version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 1 ") && flag2)
          {
            if (str3.Contains(this.m_iSCSI_CFG_1))
            {
              this.m_results += "\r\niSCSI CFG 1 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_1 == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 1 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\niSCSI CFG 1 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 2 ") && flag2)
          {
            if (str3.Contains(this.m_iSCSI_CFG_2))
            {
              this.m_results += "\r\niSCSI CFG 2 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_2 == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 2 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\niSCSI CFG 2 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 3 ") && flag2)
          {
            if (str3.Contains(this.m_iSCSI_CFG_3))
            {
              this.m_results += "\r\niSCSI CFG 3 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_3 == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 3  version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\niSCSI CFG 3 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG ") && flag2)
          {
            if (str3.Contains(this.m_iSCSI_CFG))
            {
              this.m_results += "\r\niSCSI CFG version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\niSCSI CFG version didn't match!";
          }
          else if (str3.Contains(" CCM ") && flag2)
          {
            if (str3.Contains(this.m_CCM))
            {
              this.m_results += "\r\nCCM version matched.";
              ++num3;
            }
            else if (this.m_CCM == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of CCM version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nCCM version doesn't match!";
          }
          else if (str3.Contains(" CFW ") && flag2)
          {
            if (str3.Contains(this.m_CFW))
            {
              this.m_results += "\r\nCFW version matched.";
              ++num3;
            }
            else if (this.m_CFW == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of CFW version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nCFW version doesn't match!";
          }
          else if (str3.Contains(" CFW2 ") && flag2)
          {
            if (str3.Contains(this.m_CFW2))
            {
              this.m_results += "\r\nCFW2 version matched.";
              ++num3;
            }
            else if (this.m_CFW2 == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of CFW2 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nCFW2 version doesn't match!";
          }
          else if (str3.Contains(" CFWP ") && flag2)
          {
            if (str3.Contains(this.m_CFWP))
            {
              this.m_results += "\r\nCFWP version matched.";
              ++num3;
            }
            else if (this.m_CFWP == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of CFWP version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nCFWP version doesn't match!";
          }
          else if (str3.Contains(" BFW ") && flag2)
          {
            if (str3.Contains(this.m_BFW))
            {
              this.m_results += "\r\nBFW version matched.";
              ++num3;
            }
            else if (this.m_BFW == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of BFW version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nBFW version doesn't match!";
          }
          else if (str3.Contains(" MBA ") && flag2)
          {
            if (str3.Contains(this.m_MBA))
            {
              this.m_results += "\r\nMBA version matched.";
              ++num3;
            }
            else if (this.m_MBA == "N/A" && !flag4)
            {
              this.m_results += "\r\nNeed to add check of MBA version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag4)
              this.m_results += "\r\nMBA version doesn't match!";
          }
          else if (str3.Contains(" PCIE ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_PCIE))
            {
              this.m_results += "\r\nPCIE checksum matched.";
              ++num3;
            }
            else if (this.m_PCIE == "N/A" && flag4)
            {
              this.m_results += "\r\nNeed to add check of PCIE checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (flag4)
              this.m_results += "\r\nPCIE checksum doesn't match!";
          }
          else if (str3.Contains(" PCFG   00 ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_PCFG00))
            {
              this.m_results += "\r\nPCFG00 checksum matched.";
              ++num3;
            }
            else if (this.m_PCFG00 == "N/A" && flag4)
            {
              this.m_results += "\r\nNeed to add check of PCFG 00 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (flag4)
              this.m_results += "\r\nPCFG 00 checksum doesn't match!";
          }
          else if (str3.Contains(" PCFG   01 ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_PCFG01))
            {
              this.m_results += "\r\nPCFG01 checksum matched.";
              ++num3;
            }
            else if (this.m_PCFG01 == "N/A" && flag4)
            {
              this.m_results += "\r\nNeed to add check of PCFG 01 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (flag4 && flag2)
              this.m_results += "\r\nPCFG 01 checksum doesn't match!";
          }
          else if (str3.Contains(" SCFG ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_SCFG))
            {
              this.m_results += "\r\nSCFG checksum matched.";
              ++num3;
            }
            else if (this.m_SCFG == "N/A" && flag4)
            {
              this.m_results += "\r\nNeed to add check of SCFG checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (flag4)
              this.m_results += "\r\nSCFG checksum doesn't match!";
          }
          else if (str3.Contains(" MBA ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_MBA_CHKSUM))
            {
              this.m_results += "\r\nMBA checksum matched.";
              ++num3;
            }
            else if (this.m_MBA_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of MBA checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nMBA checksum doesn't match!";
          }
          else if (str3.Contains(" CCM ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_CCM_CHKSUM))
            {
              this.m_results += "\r\nCCM checksum matched.";
              ++num3;
            }
            else if (this.m_CCM_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of CCM checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nCCM checksum doesn't match!";
          }
          else if (str3.Contains(" CFW ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_CFW_CHKSUM))
            {
              this.m_results += "\r\nCFW checksum matched.";
              ++num3;
            }
            else if (this.m_CFW_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of CFW checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nCFW checksum doesn't match!";
          }
          else if (str3.Contains(" CFW2 ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_CFW2_CHKSUM))
            {
              this.m_results += "\r\nCFW2 checksum matched.";
              ++num3;
            }
            else if (this.m_CFW2_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of CFW2 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nCFW2 checksum doesn't match!";
          }
          else if (str3.Contains(" CFWP ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_CFWP_CHKSUM))
            {
              this.m_results += "\r\nCFWP checksum matched.";
              ++num3;
            }
            else if (this.m_CFWP_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of CFWP checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nCFWP checksum doesn't match!";
          }
          else if (str3.Contains(" AFW ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_AFW_CHKSUM))
            {
              this.m_results += "\r\nAFW checksum matched.";
              ++num3;
            }
            else if (this.m_AFW_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of AFW checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nAFW checksum doesn't match!";
          }
          else if (str3.Contains(" BFW ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_BFW_CHKSUM))
            {
              this.m_results += "\r\nBFW checksum matched.";
              ++num3;
            }
            else if (this.m_BFW_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of BFW checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nBFW checksum doesn't match!";
          }
          else if (str3.Contains(" TSCF ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_TSCF_CHKSUM))
            {
              this.m_results += "\r\nTSCF checksum matched.";
              ++num3;
            }
            else if (this.m_TSCF_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of TSCF checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nTSCF checksum doesn't match!";
          }
          else if (str3.Contains(" IBOOT ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_IBOOT_CHKSUM))
            {
              this.m_results += "\r\nIBOOT checksum matched.";
              ++num3;
            }
            else if (this.m_IBOOT_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of IBOOT checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nIBOOT checksum doesn't match!";
          }
          else if (str3.Contains(" IB_CFG 00 ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_IBCFG00_CHKSUM))
            {
              this.m_results += "\r\nIB_CFG 00 checksum matched.";
              ++num3;
            }
            else if (this.m_IBCFG00_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of IB_CFG 00 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nIB_CFG 00 checksum doesn't match!";
          }
          else if (str3.Contains(" IB_CFG 01 ") && flag4)
          {
            if (str3.ToUpper().Contains(this.m_IBCFG01_CHKSUM))
            {
              this.m_results += "\r\nIB_CFG 01 checksum matched.";
              ++num3;
            }
            else if (this.m_IBCFG01_CHKSUM == "N/A")
            {
              this.m_results += "\r\nNeed to add check of IB_CFG 01 checksum in soteDiagFWCheck.ini!";
              ++num4;
            }
            else
              this.m_results += "\r\nIB_CFG 01 checksum doesn't match!";
          }
          if (str3.Contains(" NetXtreme/NetLink Engineering Diagnostics ") && flag3)
          {
            if (str3.Contains(this.m_esr_b57Engineering_Diagnostics))
            {
              this.m_results += "\r\nB57 Engineering Diagnostics version matched.";
              ++num3;
            }
            else if (this.m_esr_b57Engineering_Diagnostics == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 Engineering Diagnostics in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 Engineering Diagnostics version doesn't match!";
          }
          else if (str3.Contains(" BootCode ") && flag3)
          {
            if (str3.Contains(this.m_b57BootCode))
            {
              this.m_results += "\r\nB57 BootCode version matched.";
              ++num3;
            }
            else if (this.m_b57BootCode == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 BootCode version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 BootCode version doesn't match!";
          }
          else if (str3.Contains(" PXE ") && flag3)
          {
            if (str3.Contains(this.m_b57PXE))
            {
              this.m_results += "\r\nB57 PXE version matched.";
              ++num3;
            }
            else if (this.m_PXE == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 PXE in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 PXE version doesn't match!";
          }
          else if (str3.Contains(" EFI ") && flag3)
          {
            if (str3.Contains(this.m_b57EFI))
            {
              this.m_results += "\r\nB57 EFI version matched.";
              ++num3;
            }
            else if (this.m_EFI == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 EFI version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 EFI version doesn't match!";
          }
          else if (str3.Contains(" APE Firmware ") && flag3)
          {
            if (str3.Contains(this.m_b57APE_Firmware))
            {
              this.m_results += "\r\nB57 APE Firmware version matched.";
              ++num3;
            }
            else if (this.m_b57APE_Firmware == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 APE Firmware version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 APE Firmware version doesn't match!";
          }
          else if (str3.Contains(" iSCSI Boot ") && flag3)
          {
            if (str3.Contains(this.m_b57iSCSI_Boot))
            {
              this.m_results += "\r\nB57 iSCSI Boot version matched.";
              ++num3;
            }
            else if (this.m_b57iSCSI_Boot == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 iSCSI Boot version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nb57 iSCSI Boot version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 1 ") && flag3)
          {
            if (str3.Contains(this.m_b57iSCSI_CFG_1))
            {
              this.m_results += "\r\nB57 iSCSI CFG 1 version matched.";
              ++num3;
            }
            else if (this.m_b57iSCSI_CFG_1 == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 iSCSI CFG 1 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 iSCSI CFG 1 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 2 ") && flag3)
          {
            if (str3.Contains(this.m_b57iSCSI_CFG_2))
            {
              this.m_results += "\r\nB57 iSCSI CFG 2 version matched.";
              ++num3;
            }
            else if (this.m_b57iSCSI_CFG_2 == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 iSCSI CFG 2 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 iSCSI CFG 2 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 3 ") && flag3)
          {
            if (str3.Contains(this.m_b57iSCSI_CFG_3))
            {
              this.m_results += "\r\nB57 iSCSI CFG 3 version matched.";
              ++num3;
            }
            else if (this.m_b57iSCSI_CFG_3 == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 iSCSI CFG 3  version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 iSCSI CFG 3 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG ") && flag3)
          {
            if (str3.Contains(this.m_b57iSCSI_CFG))
            {
              this.m_results += "\r\nB57 iSCSI CFG version matched.";
              ++num3;
            }
            else if (this.m_b57iSCSI_CFG == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 iSCSI CFG version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5)
              this.m_results += "\r\nB57 iSCSI CFG version didn't match!";
          }
          else if (str3.Contains(" CCM ") && flag3)
          {
            if (str3.Contains(this.m_b57CCM))
            {
              this.m_results += "\r\nB57 CCM version matched.";
              ++num3;
            }
            else if (this.m_b57CCM == "N/A" && !flag5)
            {
              this.m_results += "\r\nNeed to add check of B57 CCM version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag5 && flag3)
              this.m_results += "\r\nB57 CCM version doesn't match!";
          }
          if ((str3.Contains(" fail") || str3.Contains(" Fail") || str3.Contains(" Mismatch")) && (flag4 || flag5))
          {
            bool flag9 = false;
            this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Checksum verify failed!";
            this.m_iNVRAMVerifyErrorCode = 10000;
            textReader.Close();
            return flag9;
          }
        }
        textReader.Close();
        soteUtils.log2file(this.m_traceLog, this.m_results);
        this.m_results = "";
        if (clsUUT.scanMAC != null)
        {
          soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], count, 1);
          for (int index = 0; index < count; ++index)
          {
            str1 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
            if (clsUUT.scanMAC[index] != strArray1[index])
            {
              bool flag9 = false;
              this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:MAC address doesn't match!";
              this.m_iNVRAMVerifyErrorCode = 10000;
              this.m_results += string.Format("\nMAC address doesn't match! Expected: {0}  Actual: {1}", (object) clsUUT.scanMAC[index], (object) strArray1[index]);
              soteUtils.log2file(this.m_traceLog, this.m_results);
              this.m_results = "";
              return flag9;
            }
          }
        }
        if (num3 != this.m_Total_FW_Check || num4 > 0)
        {
          bool flag9 = false;
          this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:FW/Diag revision doesn't match!";
          this.m_iNVRAMVerifyErrorCode = 10000;
          this.m_results += string.Format("\r\nFAIL-Total # of FW versions to be checked: {0};  Total # of FW versions matched: {1};  Total # of FW mischecked in soteDiagFWCheck.ini: {2}", (object) this.m_Total_FW_Check, (object) num3, (object) num4);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          return flag9;
        }
        if (this.m_bTMPCheckVerify && !flag8)
        {
          this.m_iFCTErrorCode = 998;
          this.m_FCTErrorDescription = "FCT:Temperature Reading is Missing";
          this.m_results += "\r\n\r\n\r\n******PortMacro and PCIE Temperature Check Results******";
          this.m_results += "\r\n\r\n------soteDiagTMPCheck.ini------";
          soteDiag.soteDiag soteDiag1 = this;
          soteDiag1.m_results = soteDiag1.m_results + "\r\nTEMPERATURE_CHECK_ENABLED = " + (this.m_bTMPCheckVerify ? "TRUE" : "FALSE");
          soteDiag.soteDiag soteDiag2 = this;
          soteDiag2.m_results = soteDiag2.m_results + "\r\nMAX_TEMPERATURE_THRESHOLD = " + (object) this.m_dMax_Temperature_Threshold;
          this.m_results += "\r\n\r\n----------Test Summary----------";
          this.m_results += "\r\nTEMPERATURE Reading is Missing (check READMAC.TCL)!!!";
          this.m_results += "\r\nTEMPERATURE Check FAILED!!!";
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nVerifyNVRAM: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("VerifyNVRAM: \n" + ex.Message);
        flag1 = false;
        this.m_iNVRAMVerifyErrorCode = 10000;
        this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:ExceptionError";
      }
      this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:PASS";
      this.m_iNVRAMVerifyErrorCode = 0;
      return flag1;
    }

    public bool verifyNVRAM(string hw_type, string filenamepath, string firstMAC, int maccount)
    {
      bool flag1 = true;
      bool flag2 = false;
      try
      {
        string str1 = (string) null;
        bool flag3;
        if (!(flag3 = this.loadFwCheckConfig(hw_type)))
        {
          this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Failed to load FW check config file!";
          this.m_iNVRAMVerifyErrorCode = 10000;
          return flag3;
        }
        TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(filenamepath, FileMode.Open));
        int count = maccount;
        string[] strArray1 = new string[count];
        string str2 = "";
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        this.m_results += "\r\n******FW Check Test Results******\r\n";
        string str3;
        while ((str3 = textReader.ReadLine()) != null)
        {
          string[] strArray2 = str3.Split(' ');
          ++num2;
          foreach (string str4 in strArray2)
          {
            if (num2 >= 6 && num2 <= 6 + maccount && str4.Length == 12)
              strArray1[num1++] = str4;
            if (str4.Length == 2 && str3.Contains("SN Serial Number") && clsUUT.bHPE)
              str2 = str3.Substring(26, 10);
          }
          if (str3.Contains("Region           Address Range     Content  Checksum Status"))
            flag2 = true;
          if (str3.Contains(" Engineering Diagnostics "))
          {
            if (str3.Contains(this.m_esr_Engineering_Diagnostics))
            {
              this.m_results += "\r\nEngineering Diagnostics version matched.";
              ++num3;
            }
            else if (this.m_esr_Engineering_Diagnostics == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of Engineering Diagnostics in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nEngineering Diagnostics version doesn't match!";
          }
          else if (str3.Contains(" BootCode "))
          {
            if (str3.Contains(this.m_BootCode))
            {
              this.m_results += "\r\nBootCode version matched.";
              ++num3;
            }
            else if (this.m_BootCode == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of BootCode version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nBootCode version doesn't match!";
          }
          else if (str3.Contains(" PXE "))
          {
            if (str3.Contains(this.m_PXE))
            {
              this.m_results += "\r\nPXE version matched.";
              ++num3;
            }
            else if (this.m_PXE == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of PXE in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nPXE version doesn't match!";
          }
          else if (str3.Contains(" EFI "))
          {
            if (str3.Contains(this.m_EFI))
            {
              this.m_results += "\r\nEFI version matched.";
              ++num3;
            }
            else if (this.m_EFI == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of EFI version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nEFI version doesn't match!";
          }
          else if (str3.Contains(" APE Firmware "))
          {
            if (str3.Contains(this.m_APE_Firmware))
            {
              this.m_results += "\r\nAPE Firmware version matched.";
              ++num3;
            }
            else if (this.m_APE_Firmware == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of APE Firmware version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nAPE Firmware version doesn't match!";
          }
          else if (str3.Contains(" iSCSI Boot "))
          {
            if (str3.Contains(this.m_iSCSI_Boot))
            {
              this.m_results += "\r\niSCSI Boot version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_Boot == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI Boot version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI Boot version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 1 "))
          {
            if (str3.Contains(this.m_iSCSI_CFG_1))
            {
              this.m_results += "\r\niSCSI CFG 1 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_1 == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 1 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI CFG 1 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 2 "))
          {
            if (str3.Contains(this.m_iSCSI_CFG_2))
            {
              this.m_results += "\r\niSCSI CFG 2 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_2 == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 2 version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI CFG 2 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG 3 "))
          {
            if (str3.Contains(this.m_iSCSI_CFG_3))
            {
              this.m_results += "\r\niSCSI CFG 3 version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG_3 == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG 3  version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI CFG 3 version doesn't match!";
          }
          else if (str3.Contains(" iSCSI CFG "))
          {
            if (str3.Contains(this.m_iSCSI_CFG))
            {
              this.m_results += "\r\niSCSI CFG version matched.";
              ++num3;
            }
            else if (this.m_iSCSI_CFG == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of iSCSI CFG version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\niSCSI CFG version didn't match!";
          }
          else if (str3.Contains(" CCM "))
          {
            if (str3.Contains(this.m_CCM))
            {
              this.m_results += "\r\nCCM version matched.";
              ++num3;
            }
            else if (this.m_CCM == "N/A" && !flag2)
            {
              this.m_results += "\r\nNeed to add check of CCM version in soteDiagFWCheck.ini!";
              ++num4;
            }
            else if (!flag2)
              this.m_results += "\r\nCCM version doesn't match!";
          }
          else if (str3.Contains("0 5720 PA0 ") && clsUUT.hw_type == "OBRIEN")
          {
            if (str3.Contains(this.m_FW_Version) && str3.Contains(this.m_DEV0_CFG))
            {
              this.m_results += "\r\nFW version and DEV0CFG matched.";
              ++num3;
            }
            else
              this.m_results += "\r\nFW version or DEV0CFG doesn't match!";
          }
          else if (str3.Contains("1 5720 SA0 ") && clsUUT.hw_type == "OBRIEN")
          {
            if (str3.Contains(this.m_FW_Version) && str3.Contains(this.m_DEV1_CFG))
            {
              this.m_results += "\r\nFW version and DEV1CFG matched.";
              ++num3;
            }
            else
              this.m_results += "\r\nFW version or DEV1CFG doesn't match!";
          }
          else if (str3.Contains("2 5720 PA0 ") && clsUUT.hw_type == "OBRIEN")
          {
            if (str3.Contains(this.m_FW_Version) && str3.Contains(this.m_DEV2_CFG))
            {
              this.m_results += "\r\nFW version and DEV2CFG matched.";
              ++num3;
            }
            else
              this.m_results += "\r\nFW version or DEV2CFG doesn't match!";
          }
          else if (str3.Contains("3 5720 SA0 ") && clsUUT.hw_type == "OBRIEN")
          {
            if (str3.Contains(this.m_FW_Version) && str3.Contains(this.m_DEV3_CFG))
            {
              this.m_results += "\r\nFW version and DEV3CFG matched.";
              ++num3;
            }
            else
              this.m_results += "\r\nFW version or DEV3CFG doesn't match!";
          }
          else if (str3.Contains(" 3 V0 ") && clsUUT.hw_type == "OBRIEN")
          {
            if (str3.Contains(this.m_FW_Version))
            {
              this.m_results += "\r\nFW version matched.";
              ++num3;
            }
            else
              this.m_results += "\r\nFW version doesn't match!";
          }
          if ((str3.Contains(" fail") || str3.Contains(" Fail")) && flag2)
          {
            bool flag4 = false;
            this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:Checksum verify failed!";
            this.m_iNVRAMVerifyErrorCode = 10000;
            textReader.Close();
            return flag4;
          }
        }
        textReader.Close();
        soteUtils.log2file(this.m_traceLog, this.m_results);
        this.m_results = "";
        if ((hw_type == "BOERNE" || hw_type == "PUTNAM" || hw_type == "WOODVILLE" || clsUUT.hw_type == "BUBBLES") && clsUUT.scanLabel.Substring(14, 10) != str2)
        {
          bool flag4 = false;
          this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:SN label doesn't match!";
          this.m_iNVRAMVerifyErrorCode = 10000;
          return flag4;
        }
        if (clsUUT.scanMAC != null)
        {
          soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], count, 1);
          for (int index = 0; index < count; ++index)
          {
            str1 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
            if (clsUUT.scanMAC[index] != strArray1[index])
            {
              bool flag4 = false;
              this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:MAC address doesn't match!";
              this.m_iNVRAMVerifyErrorCode = 10000;
              return flag4;
            }
          }
        }
        if ((num3 != this.m_Total_FW_Check || num4 > 0) && clsUUT.hw_type != "OBRIEN")
        {
          bool flag4 = false;
          this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:FW/Diag revision doesn't match!";
          this.m_iNVRAMVerifyErrorCode = 10000;
          this.m_results += string.Format("\r\nFAIL-Total # of FW versions to be checked: {0};  Total # of FW versions matched: {1};  Total # of FW mischecked in soteDiagFWCheck.ini: {2}", (object) this.m_Total_FW_Check, (object) num3, (object) num4);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          return flag4;
        }
        if ((num3 != this.m_Total_FW_Check + 5 || num4 > 0) && clsUUT.hw_type == "OBRIEN")
        {
          bool flag4 = false;
          this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:FW/Diag revision doesn't match!";
          this.m_iNVRAMVerifyErrorCode = 10000;
          this.m_results += string.Format("\r\nFAIL-Total # of FW versions to be checked: {0};  Total # of FW versions matched: {1};  Total # of FW mischecked in soteDiagFWCheck.ini: {2}", (object) (this.m_Total_FW_Check + 5), (object) num3, (object) num4);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          return flag4;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nVerifyNVRAM: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("VerifyNVRAM: \n" + ex.Message);
        flag1 = false;
        this.m_iNVRAMVerifyErrorCode = 10000;
        this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:ExceptionError";
      }
      this.m_NVRAMVerifyErrorDescription = "NVRAMVerify:PASS";
      this.m_iNVRAMVerifyErrorCode = 0;
      return flag1;
    }

    private bool ParseTestLog(string srcFile, string dstFile, string macAddress, int logType)
    {
      StreamReader streamReader = new StreamReader(srcFile);
      StreamWriter streamWriter = new StreamWriter(dstFile, true);
      string str1;
      while ((str1 = streamReader.ReadLine()) != null)
      {
        switch (logType)
        {
          case 4:
            if (!str1.Contains("copy READMAC.txt"))
              break;
            goto label_15;
          case 32:
            string str2 = string.Format("copy DIAG.csv");
            if (!str1.Contains(str2))
              break;
            goto label_15;
          case 71:
            if (!str1.Contains(string.Format("copy {0}.log", (object) macAddress)))
              break;
            goto label_15;
          case 72:
            if (!str1.Contains(string.Format("copy {0}.txt", (object) macAddress)))
              break;
            goto label_15;
          case 254:
            if (str1.Contains("******"))
            {
              streamWriter.WriteLine(str1);
              goto label_15;
            }
            else
              break;
          case (int) byte.MaxValue:
            if (!str1.Contains("-rc READMAC.tcl"))
              break;
            goto label_15;
          default:
            string str3 = string.Format("copy DIAG.txt");
            if (!str1.Contains(str3))
              break;
            goto label_15;
        }
      }
label_15:
      string str4;
      while ((str4 = streamReader.ReadLine()) != null && (!str4.Contains("file(s) copied") || str4.Contains(",")))
      {
        if (str4.Contains("file(s) copied") && str4.Contains(","))
        {
          streamWriter.WriteLine(str4.Substring(0, str4.Length - 18));
          break;
        }
        streamWriter.WriteLine(str4);
      }
      streamReader.Close();
      streamWriter.Close();
      return true;
    }

    private void ParseTestSummaryWOTestSummarySection(
      string srcFile,
      int logType,
      out string txtErrorCode,
      out string txtErrorDescription)
    {
      string str1 = (string) null;
      string str2 = (string) null;
      if (this.m_TestMode == 5 && !this.m_bFCTEnabled && (logType == 3 || logType == 2))
      {
        txtErrorCode = "0";
        txtErrorDescription = "";
      }
      else if (this.m_TestMode == 5 && !this.m_bLOOPBACKEnabled && logType == 31)
      {
        txtErrorCode = "0";
        txtErrorDescription = "";
      }
      else if (this.m_TestMode == 8 && !this.m_bRMAFCT && !this.m_bRMAProgramNVRAM)
      {
        txtErrorCode = "0";
        txtErrorDescription = "";
      }
      else
      {
        StreamReader streamReader = new StreamReader(srcFile);
        string str3;
        while ((str3 = streamReader.ReadLine()) != null)
        {
          if (str3.Contains("Error #:"))
            str1 = str3;
          else if (str3.Contains("Msg:"))
            str2 = str3;
          else if (str3.Contains("Total test time ="))
          {
            str1 = "Error #: 0 ";
            str2 = "Msg: ";
          }
          if (str1 != null && str2 != null)
            break;
        }
        if (str1 == null && str2 == null)
        {
          str1 = "Error #: 254 ";
          str2 = "Msg: Failed to detect device/Unknown error ";
        }
        streamReader.Close();
        txtErrorCode = str1 == null ? (logType != 31 ? this.m_iFCTErrorCode.ToString() : this.m_iLOOPBACKErrorCode.ToString()) : str1.Substring("Error #: ".Length, str1.Length - "Error #: ".Length);
        if (logType == 31)
        {
          if (str2 != null)
            txtErrorDescription = "LOOPBACK:" + str2.Substring("Msg: ".Length, str2.Length - "Msg: ".Length);
          else
            txtErrorDescription = this.m_LOOPBACKErrorDescription;
        }
        else
          txtErrorDescription = str2 == null ? this.m_FCTErrorDescription : "FCT:" + str2.Substring("Msg: ".Length, str2.Length - "Msg: ".Length);
      }
    }

    private void ParseTestSummary(
      string srcFile,
      int logType,
      out string txtErrorCode,
      out string txtErrorDescription)
    {
      string str1 = (string) null;
      string str2 = (string) null;
      bool flag = false;
      if (this.m_TestMode == 5 && !this.m_bFCTEnabled && (logType == 3 || logType == 2))
      {
        txtErrorCode = "0";
        txtErrorDescription = "";
      }
      else if (this.m_TestMode == 5 && !this.m_bLOOPBACKEnabled && logType == 31)
      {
        txtErrorCode = "0";
        txtErrorDescription = "";
      }
      else if (this.m_TestMode == 8 && !this.m_bRMAFCT && !this.m_bRMAProgramNVRAM)
      {
        txtErrorCode = "0";
        txtErrorDescription = "";
      }
      else
      {
        StreamReader streamReader = new StreamReader(srcFile);
        string str3;
        while ((str3 = streamReader.ReadLine()) != null)
        {
          if (str3.Contains("Result = FAIL"))
            flag = true;
          if (str3.Contains("Result = PASS"))
            flag = false;
          if (str3.Contains("Errorcode ="))
            str1 = str3;
          else if (str3.Contains("ErrorDescription ="))
            str2 = str3;
          else if (str3.Contains("Result = PASS") && !flag)
          {
            str1 = "Errorcode = 0";
            str2 = "ErrorDescription = ";
          }
        }
        streamReader.Close();
        txtErrorCode = str1 == null ? (logType != 31 ? this.m_iFCTErrorCode.ToString() : this.m_iLOOPBACKErrorCode.ToString()) : str1.Substring("Errorcode = ".Length, str1.Length - "Errorcode = ".Length);
        if (logType == 31)
        {
          if (str2 != null)
            txtErrorDescription = "LOOPBACK:" + str2.Substring("ErrorDescription = ".Length, str2.Length - "ErrorDescription = ".Length);
          else
            txtErrorDescription = this.m_LOOPBACKErrorDescription;
        }
        else
          txtErrorDescription = str2 == null ? this.m_FCTErrorDescription : "FCT:" + str2.Substring("ErrorDescription = ".Length, str2.Length - "ErrorDescription = ".Length);
      }
    }

    private void ParseTestSummaryCdiagB57diag(
      string srcFile,
      int logType,
      out string txtErrorCode,
      out string txtErrorDescription)
    {
      string str1 = (string) null;
      string str2 = (string) null;
      string str3 = (string) null;
      string str4 = (string) null;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      bool flag4 = false;
      txtErrorCode = "0";
      txtErrorDescription = "";
      if (this.m_TestMode == 5 && !this.m_bFCTEnabled && (logType == 3 || logType == 2) || this.m_TestMode == 5 && !this.m_bLOOPBACKEnabled && logType == 31 || this.m_TestMode == 8 && !this.m_bRMAFCT && !this.m_bRMAProgramNVRAM)
        return;
      StreamReader streamReader = new StreamReader(srcFile);
      string str5;
      while ((str5 = streamReader.ReadLine()) != null)
      {
        if (str5.Contains("Broadcom NetXtreme"))
        {
          flag3 = true;
          flag4 = false;
        }
        if (str5.Contains("Cdiag -- Broadcom"))
        {
          flag3 = false;
          flag4 = true;
        }
        if (str5.Contains("Result = FAIL") && flag4)
          flag1 = true;
        if (str5.Contains("Result = PASS") && flag4)
          flag1 = false;
        if (str5.Contains("Result = FAIL") && flag3)
          flag2 = true;
        if (str5.Contains("Errorcode =") && flag4)
          str1 = str5;
        if (str5.Contains("ErrorDescription =") && flag4)
          str2 = str5;
        if (str5.Contains("Result = PASS") && !flag1 && flag4)
        {
          str1 = "Errorcode = 0";
          str2 = "ErrorDescription = ";
        }
        if (str5.Contains("Errorcode =") && flag3)
          str3 = str5;
        if (str5.Contains("ErrorDescription =") && flag3)
          str4 = str5;
        if (str5.Contains("Result = PASS") && !flag2 && flag3)
        {
          str3 = "Errorcode = 0";
          str4 = "ErrorDescription = ";
        }
      }
      streamReader.Close();
      if (str1 != null && str3 != null)
      {
        if (flag2 && !flag1)
          txtErrorCode = str3.Substring("Errorcode = ".Length, str3.Length - "Errorcode = ".Length);
        else if (!flag2 && flag1)
          txtErrorCode = str1.Substring("Errorcode = ".Length, str1.Length - "Errorcode = ".Length);
        else if (flag2 && flag1)
        {
          int int32_1 = Convert.ToInt32(str3.Substring("Errorcode = ".Length, str3.Length - "Errorcode = ".Length));
          int int32_2 = Convert.ToInt32(str1.Substring("Errorcode = ".Length, str1.Length - "Errorcode = ".Length));
          txtErrorCode = (int32_1 + int32_2).ToString();
        }
      }
      else
        txtErrorCode = str3 == null ? (str1 == null ? this.m_iFCTErrorCode.ToString() : str1.Substring("Errorcode = ".Length, str1.Length - "Errorcode = ".Length)) : str3.Substring("Errorcode = ".Length, str3.Length - "Errorcode = ".Length);
      if (str2 != null && str4 != null)
      {
        txtErrorDescription = !flag2 ? "FCT:(5720)PASS" : "FCT:(5720)" + str4.Substring("ErrorDescription = ".Length, str4.Length - "ErrorDescription = ".Length);
        if (flag1)
        {
          if (clsUUT.hw_type == "PAULI")
          {
            ref string local = ref txtErrorDescription;
            local = local + ";(57412)" + str2.Substring("ErrorDescription = ".Length, str2.Length - "ErrorDescription = ".Length);
          }
          else
          {
            ref string local = ref txtErrorDescription;
            local = local + ";(57416)" + str2.Substring("ErrorDescription = ".Length, str2.Length - "ErrorDescription = ".Length);
          }
        }
        else if (clsUUT.hw_type == "PAULI")
          txtErrorDescription += ";(57412)PASS";
        else
          txtErrorDescription += ";(57416)PASS";
      }
      else if (str2 != null)
      {
        if (clsUUT.hw_type == "PAULI")
          txtErrorDescription = "FCT:(57412)" + str2.Substring("ErrorDescription = ".Length, str2.Length - "ErrorDescription = ".Length);
        else
          txtErrorDescription = "FCT:(57416)" + str2.Substring("ErrorDescription = ".Length, str2.Length - "ErrorDescription = ".Length);
      }
      else if (str4 != null)
        txtErrorDescription = "FCT:(5720)" + str4.Substring("ErrorDescription = ".Length, str4.Length - "ErrorDescription = ".Length);
      else
        txtErrorDescription = this.m_FCTErrorDescription;
    }

    private void PowerON()
    {
      Device device = (Device) null;
      if (this.m_builtin_BIE)
      {
        this.m_results += "\r\nTurn ON Built-in BIE";
        try
        {
          if (this.I2CAdapterType == "DLN-2" && !this.m_bDLN2Connected)
          {
            Library.Connect("localhost", Connection.DefaultPort);
            if (Device.Count() == 0U)
            {
              int num = (int) MessageBox.Show("No DLN-2 adapters have been detected in BUILTIN_BIE.", (string) null, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              this.m_results += "\r\nNo DLN-2 adapters have been detected in BUILTIN_BIE.";
              this.RaiseUserAbortEvent();
            }
            device = Device.Open();
          }
          Pin pin = device.Gpio.Pins[30];
          pin.PullupEnabled = true;
          pin.Enabled = true;
          pin.Direction = 1;
          pin.OutputValue = 1;
          if (this.I2CAdapterType == "DLN-2" && this.m_bDLN2Connected)
          {
            Library.DisconnectAll();
            this.m_bDLN2Connected = false;
          }
        }
        catch (Exception ex)
        {
          soteDiag.soteDiag.showFailMsgDlg("DLN-2 device/BUILTIN_BIE: \n" + ex.Message);
          return;
        }
      }
      else if (this.m_usbdioenable && !this.m_usbdiodual)
      {
        this.m_results += "\r\nTurn ON USBDio";
        try
        {
          SerialPort serialPort = new SerialPort(this.m_usbdioport1, 9600, Parity.None, 8, StopBits.One);
          serialPort.Open();
          serialPort.Write(new byte[4]
          {
            byte.MaxValue,
            (byte) 1,
            (byte) 0,
            (byte) 0
          }, 0, 4);
          serialPort.Close();
        }
        catch (Exception ex)
        {
          soteDiag.soteDiag.showFailMsgDlg("USBDio device: \n" + ex.Message);
          return;
        }
      }
      else if (this.m_usbdioenable && this.m_usbdiodual)
      {
        this.m_results += "\r\nTurn ON USBDio";
        try
        {
          SerialPort serialPort1 = new SerialPort(this.m_usbdioport1, 9600, Parity.None, 8, StopBits.One);
          serialPort1.Open();
          serialPort1.Write(new byte[4]
          {
            byte.MaxValue,
            (byte) 1,
            (byte) 0,
            (byte) 0
          }, 0, 4);
          serialPort1.Close();
          SerialPort serialPort2 = new SerialPort(this.m_usbdioport2, 9600, Parity.None, 8, StopBits.One);
          serialPort2.Open();
          serialPort2.Write(new byte[4]
          {
            byte.MaxValue,
            (byte) 1,
            (byte) 0,
            (byte) 0
          }, 0, 4);
          serialPort2.Close();
        }
        catch (Exception ex)
        {
          soteDiag.soteDiag.showFailMsgDlg("USBDio device: \n" + ex.Message);
          return;
        }
      }
      else if (this.m_usbrelayenable)
      {
        this.m_results += "\r\n...Power ON DOS PC using USB relay";
        if (this.m_commport != null)
          this.m_commport.DisablePort();
        this.USBRelayON();
        this.USBRelayOFF();
        Thread.Sleep(2000);
        this.USBRelayON();
        this.USBRelayOFF();
        if (this.m_bFirsttime)
          Thread.Sleep(30000);
        else
          Thread.Sleep(0);
        if (this.m_commport != null)
          this.m_commport.EnablePort();
      }
      Thread.Sleep(1000);
    }

    private void PowerOFF()
    {
      Device device = (Device) null;
      if (this.m_builtin_BIE)
      {
        this.m_results += "\r\nTurn OFF Built-in BIE";
        try
        {
          if (this.I2CAdapterType == "DLN-2" && !this.m_bDLN2Connected)
          {
            Library.Connect("localhost", Connection.DefaultPort);
            if (Device.Count() == 0U)
            {
              int num = (int) MessageBox.Show("No DLN-2 adapters have been detected in BUILTIN_BIE.", (string) null, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              this.m_results += "\r\nNo DLN-2 adapters have been detected in BUILTIN_BIE.";
              this.RaiseUserAbortEvent();
            }
            device = Device.Open();
          }
          Pin pin = device.Gpio.Pins[30];
          pin.PullupEnabled = true;
          pin.Enabled = true;
          pin.Direction = 1;
          pin.OutputValue = 0;
          if (!(this.I2CAdapterType == "DLN-2") || !this.m_bDLN2Connected)
            return;
          Library.DisconnectAll();
          this.m_bDLN2Connected = false;
        }
        catch (Exception ex)
        {
          soteDiag.soteDiag.showFailMsgDlg("DLN-2 device/BUILTIN_BIE: \n" + ex.Message);
        }
      }
      else if (this.m_usbdioenable && !this.m_usbdiodual)
      {
        this.m_results += "\r\nTurn OFF USBDio";
        try
        {
          SerialPort serialPort = new SerialPort(this.m_usbdioport1, 9600, Parity.None, 8, StopBits.One);
          serialPort.Open();
          serialPort.Write(new byte[4]
          {
            byte.MaxValue,
            (byte) 1,
            (byte) 1,
            (byte) 0
          }, 0, 4);
          serialPort.Close();
        }
        catch (Exception ex)
        {
          soteDiag.soteDiag.showFailMsgDlg("USBDio device: \n" + ex.Message);
        }
      }
      else if (this.m_usbdioenable && this.m_usbdiodual)
      {
        this.m_results += "\r\nTurn OFF USBDio";
        try
        {
          SerialPort serialPort1 = new SerialPort(this.m_usbdioport1, 9600, Parity.None, 8, StopBits.One);
          serialPort1.Open();
          serialPort1.Write(new byte[4]
          {
            byte.MaxValue,
            (byte) 1,
            (byte) 1,
            (byte) 0
          }, 0, 4);
          serialPort1.Close();
          SerialPort serialPort2 = new SerialPort(this.m_usbdioport2, 9600, Parity.None, 8, StopBits.One);
          serialPort2.Open();
          serialPort2.Write(new byte[4]
          {
            byte.MaxValue,
            (byte) 1,
            (byte) 1,
            (byte) 0
          }, 0, 4);
          serialPort2.Close();
        }
        catch (Exception ex)
        {
          soteDiag.soteDiag.showFailMsgDlg("USBDio device: \n" + ex.Message);
        }
      }
      else
      {
        if (!this.m_usbrelayenable || !this.m_bDUTPCPowerON)
          return;
        this.m_results += "\r\n...Power OFF DOS PC using USB relay";
        this.m_commport.DisablePort();
        this.USBRelayON();
        this.USBRelayOFF();
        this.m_bDUTPCPowerON = false;
      }
    }

    private void USBRelayON()
    {
      if (!this.m_usbrelayenable)
        return;
      try
      {
        SerialPort serialPort = new SerialPort(this.m_usbrelayport, 9600, Parity.None, 8, StopBits.One);
        serialPort.Open();
        this.m_results += "\r\n...Enable pin 1 - USB relay";
        serialPort.Write(new byte[3]
        {
          byte.MaxValue,
          (byte) 1,
          (byte) 1
        }, 0, 3);
        serialPort.Close();
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("USBRelay device: \n" + ex.Message);
        return;
      }
      Thread.Sleep(1000);
    }

    private void USBRelayOFF()
    {
      if (!this.m_usbrelayenable)
        return;
      try
      {
        SerialPort serialPort = new SerialPort(this.m_usbrelayport, 9600, Parity.None, 8, StopBits.One);
        serialPort.Open();
        this.m_results += "\r\n...Disable pin 1 - USB relay\r\n";
        serialPort.Write(new byte[3]
        {
          byte.MaxValue,
          (byte) 1,
          (byte) 0
        }, 0, 3);
        serialPort.Close();
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("USBRelay device: \n" + ex.Message);
      }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      this.m_userabort = false;
      this.lblStatus.Text = "";
      this.InitializeTestResults();
      try
      {
        this.UserAbortEvent += new soteDiag.soteDiag.UserAbortDelegate(this.UserAbortEventHandler);
        if (this.chkSFIS.Checked)
        {
          if (this.m_sfis_type == 91)
            this.m_sfis_enabled = true;
          else if (this.m_sfis_type == 90)
            this.m_esr_sfis_enabled = true;
        }
        if ((this.m_sfis_enabled || this.m_esr_sfis_enabled) && this.txtBadge.Text == "")
        {
          int num = (int) new NewMessageBox()
          {
            Message = "Please scan EMPLOYEE BADGE, SN, MAC labels to begin the test!"
          }.ShowDialog();
          this.txtBadge.Enabled = true;
        }
        else if (this.m_bFirsttime)
        {
          int num1 = (int) new NewMessageBox()
          {
            Message = "Please scan SN and MAC labels and Click 'START TEST' to begin the test!"
          }.ShowDialog();
        }
        this.DisposeEvent += new soteDiag.soteDiag.DisposeEventDelegate(this.SerialDisposedEventHandler);
        this.m_hostport = this.cboDiagPort.Text;
        if (this.m_commport.Install(this.m_hostport, Convert.ToInt32(this.m_baudrate), (int) Convert.ToInt16(this.m_databits), this.m_parity, this.m_stopbits, this.m_flowcontrol, new CommPort.delegateSerialRead(this.cbSerialRead)))
        {
          this.btnStart.Enabled = false;
          this.btnAbort.Enabled = false;
          this.txtTerminal.Text = "";
          this.m_commport.DisablePort();
          this.threadRunTest = new Thread(new ThreadStart(this.RunTestThread));
          this.threadRunTest.Start();
        }
        else
        {
          this.TextSFISLog.Enabled = false;
          this.TextSFISMessage.Enabled = false;
          soteDiag.soteDiag.showFailMsgDlg("Failed to establish serial communication!\n\nCheck COM port connection!");
          this.RaiseUserAbortEvent();
          Application.Exit();
        }
        this.m_label = "";
        this.m_MAC = (string[]) null;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nSTART: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("START: Exception encountered!\n\nFailed to establish serial communication!\n\nCheck COM port connection!");
        this.RaiseUserAbortEvent();
        Application.Exit();
      }
    }

    private void btnAbort_Click(object sender, EventArgs e)
    {
      this.CancelTestProgressDisplay();
      this.m_userabort = true;
      this.threadRunTest.Abort();
      this.threadRunTest = (Thread) null;
      this.cbStatusColor(Color.Red);
      this.lblStatus.Text = " Test Aborted!        Click 'X' to CLOSE the App!";
      this.txtLabel.Text = "";
      this.txtMAC.Text = "";
      this.txtBadge.Enabled = true;
      this.btnStart.Enabled = true;
      this.btnAbort.Enabled = false;
      this.groupUUT.Enabled = false;
      this.cbgoldenSampleMode(true);
      if (this.I2CAdapterType == "DLN-2" && this.m_bDLN2Connected)
      {
        DiolanU2C.DLN2Disconnect();
        this.m_bDLN2Connected = false;
      }
      if (this.m_traceLog != null)
      {
        soteUtils.log2file(this.m_traceLog, this.m_results);
        this.m_results = "";
      }
      if (this.m_traceLog != null && this.m_bFCTTestStarted && !this.m_bFCTTestLogCopied)
      {
        if (this.m_TestMode == 2)
        {
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".oba", clsUUT.scanMAC[0], 254);
          if (this.m_bTestSummarySection)
          {
            if (clsUUT.bCdiagB57diag)
              this.ParseTestSummary(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
            else
              this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
          }
          else
            this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".oba", 2, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
          this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
          if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
          {
            this.m_FCTErrorDescription = "FCT:PASS";
            B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".oba", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-OBA-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
          }
          else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
            this.m_FCTErrorDescription = "FCT:PASS";
          else if (!clsUUT.bCdiagB57diag)
            B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".oba", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-OBA-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
        }
        else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
        {
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".sts", clsUUT.scanMAC[0], 254);
          if (this.m_bTestSummarySection)
          {
            if (clsUUT.bCdiagB57diag)
              this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
            else
              this.ParseTestSummary(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
          }
          else
            this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".sts", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
          this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
          if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
          {
            this.m_FCTErrorDescription = "FCT:PASS";
            B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-STS-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
          }
          else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
            this.m_FCTErrorDescription = "FCT:PASS";
          else if (!clsUUT.bCdiagB57diag)
            B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-STS-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
        }
        else if (this.m_TestMode == 8 && (this.m_bRMAFCT || this.m_bRMAProgramNVRAM))
        {
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".rma", clsUUT.scanMAC[0], 254);
          if (this.m_bTestSummarySection)
          {
            if (clsUUT.bCdiagB57diag)
              this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
            else
              this.ParseTestSummary(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
          }
          else
            this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".rma", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
          this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
          if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
          {
            this.m_FCTErrorDescription = "FCT:PASS";
            B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-RMA-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
          }
          else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
            this.m_FCTErrorDescription = "FCT:PASS";
          else if (!clsUUT.bCdiagB57diag)
            B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".sts", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-RMA-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
        }
        else if (this.m_TestMode != 5 || this.m_bFCTEnabled || (this.m_TestMode != 8 || this.m_bRMAFCT || this.m_bRMAProgramNVRAM))
        {
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".fct", clsUUT.scanMAC[0], 254);
          if (this.m_bTestSummarySection)
          {
            if (clsUUT.bCdiagB57diag)
              this.ParseTestSummaryCdiagB57diag(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
            else
              this.ParseTestSummary(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
          }
          else
            this.ParseTestSummaryWOTestSummarySection(this.logDir + this.m_logFileName + ".fct", 3, out this.m_FCTErrorCode, out this.m_FCTErrorDescription);
          this.m_iFCTErrorCode = Convert.ToInt32(this.m_FCTErrorCode);
          if (this.m_iFCTErrorCode == 0 && !clsUUT.bCdiagB57diag)
          {
            this.m_FCTErrorDescription = "FCT:PASS";
            B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".fct", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
          }
          else if (this.m_iFCTErrorCode == 0 && clsUUT.bCdiagB57diag)
            this.m_FCTErrorDescription = "FCT:PASS";
          else if (!clsUUT.bCdiagB57diag)
            B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".fct", B57diagLogParser.LogFileType.FCT, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-FCT-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
        }
        this.m_bFCTTestLogCopied = true;
      }
      if (this.m_traceLog != null && this.m_bNVRAMVerifyTestStarted && !this.m_bNVRAMVerifyTestLogCopied && ((this.m_TestMode != 5 || this.m_bNVRAMVerifyEnabled) && (this.m_TestMode != 8 || this.m_bRMANVRAMVerify)))
      {
        this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + ".ver", clsUUT.scanMAC[0], (int) byte.MaxValue);
        if (clsUUT.bCdiag && !clsUUT.bCdiagB57diag)
          this.verifyNVRAMCdiag(clsUUT.hw_type, this.logDir + this.m_logFileName + ".ver", clsUUT.scanMAC[0], clsUUT.mac_count);
        else if (clsUUT.bCdiagB57diag)
          this.verifyNVRAMCdiagB57diag(clsUUT.hw_type, this.logDir + this.m_logFileName + ".ver", clsUUT.scanMAC[0], clsUUT.mac_count);
        else
          this.verifyNVRAM(clsUUT.hw_type, this.logDir + this.m_logFileName + ".ver", clsUUT.scanMAC[0], clsUUT.mac_count);
        if (this.m_iNVRAMVerifyErrorCode == 0 && !clsUUT.bCdiagB57diag)
          B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".ver", B57diagLogParser.LogFileType.NVRAM_Verify, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-NVRAMVerify-PASS.csv", B57diagLogParser.OutputFileType.CSV, this.info);
        else if (!clsUUT.bCdiagB57diag)
          B57diagLogParser.Parse(this.logDir + this.m_logFileName + ".ver", B57diagLogParser.LogFileType.NVRAM_Verify, (B57diagLogParser.TestResult[]) null, this.logDir + this.m_logFileName + "-NVRAMVerify-FAIL.csv", B57diagLogParser.OutputFileType.CSV, this.info);
        this.m_bNVRAMVerifyTestLogCopied = true;
      }
      if (!this.m_bResultSentToSFIS && this.m_bTestStarted && this.m_TestMode != 5 && this.m_TestMode != 8)
      {
        this.SendPostResult(clsUUT.scanLabel, clsUUT.scanMAC[0], (uint) clsUUT.mac_count, (uint) clsUUT.mac_increment);
        this.m_bResultSentToSFIS = true;
      }
      if (this.m_commport != null)
        this.m_commport.DisablePort();
      if (!this.m_bStopOnFail_poweron)
        this.PowerOFF();
      int num = (int) new NewMessageBox()
      {
        Message = (!this.m_usbrelayenable ? "Please remove the DUT and reboot the PC!" : "Please remove the DUT and restart the app!")
      }.ShowDialog();
      this.cbButtonPowerON(true);
      this.cbButtonPowerOFF(true);
      this.cbButtonBADGE(false);
    }

    public event soteDiag.soteDiag.UserAbortDelegate UserAbortEvent;

    private void RaiseUserAbortEvent()
    {
      if (this.m_commport != null)
      {
        this.m_commport.Uninstall();
        this.m_commport = (CommPort) null;
      }
      if (this.UserAbortEvent == null)
        return;
      this.UserAbortEvent((object) this, new EventArgs());
    }

    public void UserAbortEventHandler(object sender, EventArgs e)
    {
      this.cbAbort();
    }

    private void cbAbort()
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateAbort(this.cbAbort), new object[0]);
      else
        this.btnAbort_Click((object) this, new EventArgs());
    }

    private void cbTerminal(string msg)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateTerminal(this.cbTerminal), (object) msg);
      }
      else
      {
        this.txtTerminal.Text += msg;
        this.txtTerminal.SelectionStart = this.txtTerminal.TextLength;
        this.txtTerminal.ScrollToCaret();
      }
    }

    private void cbUUTLabelFocus()
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateUUTLabelFocus(this.cbUUTLabelFocus), new object[0]);
      else if ((this.m_sfis_enabled || this.m_esr_sfis_enabled) && this.txtBadge.Text == "")
        this.txtBadge.Focus();
      else
        this.txtLabel.Focus();
    }

    private void cbStatusColor(Color c)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateStatusColor(this.cbStatusColor), (object) c);
      else
        this.lblStatus.ForeColor = c;
    }

    private void cbStatusText(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateStatusText(this.cbStatusText), (object) msg);
      else
        this.lblStatus.Text = msg;
    }

    private void cblblTestTime(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatelblTestTime(this.cblblTestTime), (object) msg);
      else
        this.lblTestTime.Text = msg;
    }

    private void cblblTestMode(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatelblTestMode(this.cblblTestMode), (object) msg);
      else
        this.lblTestMode.Text = msg;
    }

    private void cblblTestYield(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatelblTestYield(this.cblblTestYield), (object) msg);
      else
        this.lblTestYield.Text = msg;
    }

    private void cbtextTestJig(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTestJig(this.cbtextTestJig), (object) msg);
      else
        this.textTestJig.Text = msg;
    }

    private void cbtextTestJigColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTestJigColor(this.cbtextTestJigColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textTestJig.ForeColor = foreColor;
        this.textTestJig.BackColor = backColor;
      }
    }

    private void cbtextTestJigWA(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTestJigWA(this.cbtextTestJigWA), (object) msg);
      else
        this.textTestJigWA.Text = msg;
    }

    private void cbtextTestJigWAColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTestJigWAColor(this.cbtextTestJigWAColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textTestJigWA.ForeColor = foreColor;
        this.textTestJigWA.BackColor = backColor;
      }
    }

    private void cbtextBIE(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextBIE(this.cbtextBIE), (object) msg);
      else
        this.textBIE.Text = msg;
    }

    private void cbtextBIEColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextBIEColor(this.cbtextBIEColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textBIE.ForeColor = foreColor;
        this.textBIE.BackColor = backColor;
      }
    }

    private void cbtextRiserCard(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextRiserCard(this.cbtextRiserCard), (object) msg);
      else
        this.textRiserCard.Text = msg;
    }

    private void cbtextRiserCardColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextRiserCardColor(this.cbtextRiserCardColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textRiserCard.ForeColor = foreColor;
        this.textRiserCard.BackColor = backColor;
      }
    }

    private void cbtextMB(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextMB(this.cbtextMB), (object) msg);
      else
        this.textMB.Text = msg;
    }

    private void cbtextMBColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextMBColor(this.cbtextMBColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textMB.ForeColor = foreColor;
        this.textMB.BackColor = backColor;
      }
    }

    private void cbtextDiolan(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextDiolan(this.cbtextDiolan), (object) msg);
      else
        this.textDiolan.Text = msg;
    }

    private void cbtextDiolanColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextDiolanColor(this.cbtextDiolanColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textDiolan.ForeColor = foreColor;
        this.textDiolan.BackColor = backColor;
      }
    }

    private void cbtextTotalTestThreshold(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTotalTestThreshold(this.cbtextTotalTestThreshold), (object) msg);
      else
        this.textTotalTestThreshold.Text = msg;
    }

    private void cbtextTotalTestThresholdColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTotalTestThresholdColor(this.cbtextTotalTestThresholdColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textTotalTestThreshold.ForeColor = foreColor;
        this.textTotalTestThreshold.BackColor = backColor;
      }
    }

    private void cbtextTotalPassed(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTotalPassed(this.cbtextTotalPassed), (object) msg);
      else
        this.textTotalPassed.Text = msg;
    }

    private void cbtextTotalPassedColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTotalPassedColor(this.cbtextTotalPassedColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textTotalPassed.ForeColor = foreColor;
        this.textTotalPassed.BackColor = backColor;
      }
    }

    private void cbtextTotalFailed(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTotalFailed(this.cbtextTotalFailed), (object) msg);
      else
        this.textTotalFailed.Text = msg;
    }

    private void cbtextTotalFailedColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextTotalFailedColor(this.cbtextTotalFailedColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textTotalFailed.ForeColor = foreColor;
        this.textTotalFailed.BackColor = backColor;
      }
    }

    private void cbtextLastError(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextLastError(this.cbtextLastError), (object) msg);
      else
        this.textLastError.Text = msg;
    }

    private void cbtextLastErrorColor(Color foreColor, Color backColor)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegatetextLastErrorColor(this.cbtextLastErrorColor), (object) foreColor, (object) backColor);
      }
      else
      {
        this.textLastError.ForeColor = foreColor;
        this.textLastError.BackColor = backColor;
      }
    }

    private void cbStatus2Color(Color c)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateStatus2Color(this.cbStatus2Color), (object) c);
      else
        this.lblStatus2.ForeColor = c;
    }

    private void cbStatus2Text(string msg)
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateStatus2Text(this.cbStatus2Text), (object) msg);
      else
        this.lblStatus2.Text = msg;
    }

    private void cbGrid(
      string timestamp,
      string sn,
      string status,
      string errorCode,
      string errorDescription)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateGrid(this.cbGrid), (object) timestamp, (object) sn, (object) status, (object) errorCode, (object) errorDescription);
      }
      else
      {
        this.dataGrid.Rows.Add();
        int index = this.dataGrid.RowCount - 2;
        this.dataGrid.Rows[index].HeaderCell.Value = (object) (index + 1).ToString();
        this.dataGrid.Rows[index].Cells["colDate"].Value = (object) timestamp;
        this.dataGrid.Rows[index].Cells["colSerial"].Value = (object) sn;
        this.dataGrid.Rows[index].Cells["colStatus"].Value = (object) status;
        this.dataGrid.Rows[index].Cells["colErrorCode"].Value = (object) errorCode;
        this.dataGrid.Rows[index].Cells["colErrorDescription"].Value = (object) errorDescription;
        this.dataGrid.CurrentCell = this.dataGrid.Rows[index].Cells[0];
        this.dataGrid.Refresh();
      }
    }

    private void cbHexBox1(byte[] tBuffer)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new soteDiag.soteDiag.delegateHexBox1(this.cbHexBox1), (object) tBuffer);
      }
      else
      {
        this.hexBox1.ByteProvider = (IByteProvider) new DynamicByteProvider(tBuffer);
        this.hexBox1.Refresh();
      }
    }

    private void soteDiag_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!this.btnStart.Enabled)
      {
        if (!this.groupUUT.Enabled)
        {
          e.Cancel = true;
          soteDiag.soteDiag.showFailMsgDlg("Test running... cannot close test.");
        }
        else
        {
          if ((this.m_sfis_enabled || this.m_esr_sfis_enabled) && this.m_badge == null)
          {
            this.txtBadge.Text = "DefaultOperator";
            this.txtBadge_Leave(sender, (EventArgs) e);
          }
          this.btnAbort_Click(sender, (EventArgs) e);
        }
      }
      this.LabelSFISLinkStatus.Text = "No Connection";
      if (this.FxcnSfcListenerSMO == null)
        return;
      this.FxcnSfcListenerSMO.Close();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      if (this.txtSend.Text == "esc")
        this.m_commport.WriteByte(Convert.ToByte((object) ConsoleKey.Escape));
      else
        this.m_commport.WriteLine(this.txtSend.Text);
    }

    private void txtLabel_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.txtMAC.Focus();
      this.txtMAC.Multiline = false;
      this.txtMAC.Clear();
      this.txtMAC.Multiline = true;
    }

    private void txtLabel_Leave(object sender, EventArgs e)
    {
      string text = this.txtLabel.Text;
      if (this.m_sfis_type == 90 && text.Length >= 7 && this.m_TestMode != 10)
      {
        if (this.txtLabel.Text.Length == 7)
          this.txtLabel.Focus();
        else if (this.txtLabel.Text.Substring(0, 1).Contains("C") && this.txtLabel.Text.Length == 8)
        {
          this.txtLabel.Focus();
        }
        else
        {
          if (!this.txtLabel.Text.Substring(0, 6).Contains("000AF7") && !this.txtLabel.Text.Substring(0, 6).Contains("001018") || this.txtLabel.Text.Length != 12)
            return;
          this.txtLabel.Focus();
        }
      }
      else if (this.txtLabel.Text.StartsWith("PBQSA"))
      {
        if (this.txtLabel.Text.Length != 14)
          return;
        this.txtLabel.Focus();
      }
      else if (this.txtLabel.Text.StartsWith("PBYWT"))
      {
        if (this.txtLabel.Text.Length != 14)
          return;
        this.txtLabel.Focus();
      }
      else if (this.txtLabel.Text.StartsWith("PWVQV"))
      {
        if (this.txtLabel.Text.Length != 14)
          return;
        this.txtLabel.Focus();
      }
      else if (this.txtLabel.Text.StartsWith("PBKRQ"))
      {
        if (this.txtLabel.Text.Length != 14)
          return;
        this.txtLabel.Focus();
      }
      else if (this.txtLabel.Text.StartsWith("PFDMD"))
      {
        if (this.txtLabel.Text.Length != 14)
          return;
        this.txtLabel.Focus();
      }
      else if (this.txtLabel.Text.StartsWith("PFDMB"))
      {
        if (this.txtLabel.Text.Length != 14)
          return;
        this.txtLabel.Focus();
      }
      else if (this.txtLabel.Text.StartsWith("PFCJK"))
      {
        if (this.txtLabel.Text.Length != 14)
          return;
        this.txtLabel.Focus();
      }
      else
      {
        if (!this.txtLabel.Text.StartsWith("PFDME") || this.txtLabel.Text.Length != 14)
          return;
        this.txtLabel.Focus();
      }
    }

    private bool VerifyLabel()
    {
      if (!clsUUT.verifyLabel(this.txtLabel.Text, this.m_sfis_type, this.m_duttype))
      {
        this.txtLabel.Text = "";
        this.txtLabel.Focus();
        this.txtMAC.Text = "";
        return false;
      }
      this.m_label = this.txtLabel.Text;
      return true;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.chkSFIS.Checked)
      {
        if (this.m_sfis_type == 91)
          this.m_sfis_enabled = true;
        else if (this.m_sfis_type == 90)
          this.m_esr_sfis_enabled = true;
      }
      else if (this.m_sfis_type == 91)
        this.m_sfis_enabled = false;
      else if (this.m_sfis_type == 90)
        this.m_esr_sfis_enabled = false;
      if ((this.m_sfis_enabled || this.m_esr_sfis_enabled) && this.m_badge == "")
      {
        this.txtLabel.Text = "";
        this.txtMAC.Text = "";
        soteDiag.soteDiag.showFailMsgDlg("Missing EMPLOYEE BADGE");
        this.txtBadge.Focus();
      }
      else
      {
        bool flag = true;
        while (flag)
        {
          if (this.txtLabel.Text == "")
          {
            if (this.m_Retry == 0)
            {
              soteDiag.soteDiag.showFailMsgDlg("Missing LABEL");
            }
            else
            {
              this.m_iLABELErrorCode = 20000;
              if (this.m_TestMode == 7)
              {
                this.m_LABELErrorDescription = "LABELVerify:Failed Golden Sample SN/MAC check";
                soteDiag.soteDiag.showFailMsgDlg("Golden Sample SN/MAC mismatched!\n\nRescan the labels!");
                this.m_results = "Failed Golden Sample SN/MAC check!  No test was run!";
              }
              else
              {
                this.m_LABELErrorDescription = "LABELVerify:Failed PreTestCheck";
                soteDiag.soteDiag.showFailMsgDlg("PreTestCheck Failed!\n\nRescan the labels!");
                this.m_results = "Failed PreTestCheck!  No test was run!";
              }
              this.SendPostResult(clsUUT.scanLabel, clsUUT.scanMAC[0], 4U, 1U);
              this.CancelTestProgressDisplay();
            }
            this.txtLabel.Focus();
            return;
          }
          if (!this.VerifyLabel())
            return;
          this.m_MAC = clsUUT.verifyMAC(this.txtMAC.Text, this.m_sfis_type, this.m_esr_Stride, this.m_duttype);
          if (this.m_MAC == null)
          {
            this.txtMAC.Multiline = false;
            this.txtMAC.Clear();
            this.txtMAC.Multiline = true;
            return;
          }
          if (clsUUT.hw_type != this.m_duttype && clsUUT.hw_type != "GENERIC")
          {
            this.m_iLABELErrorCode = 20000;
            this.m_LABELErrorDescription = "LABELVerify:Failed PreTestCheck";
            soteDiag.soteDiag.showFailMsgDlg("Invalid Label!\n\nIt doesn't match the DUT_TYPE\nspecified in soteDiag.ini!");
            this.m_results = "Failed PreTestCheck!  No test was run!";
            this.SendPostResult(clsUUT.scanLabel, clsUUT.scanMAC[0], 4U, 1U);
            this.CancelTestProgressDisplay();
            this.txtLabel.Text = "";
            this.txtMAC.Text = "";
            this.cbChkSFIS(true);
            this.cbUUTGroup(true);
            this.cbUUTLabelFocus();
            return;
          }
          if ((this.m_sfis_enabled || this.m_TestMode == 6) && this.m_TestMode != 7)
          {
            string ppid = clsUUT.scanLabel;
            string mac1st = clsUUT.scanMAC[0];
            string sn = (string) null;
            if (clsUUT.hw_type == "PUTNAM" || clsUUT.hw_type == "WOODVILLE" || (clsUUT.hw_type == "BOERNE" || clsUUT.hw_type == "BOAR") || (clsUUT.hw_type == "BANDICOOT" || clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BOBOLINK") || clsUUT.hw_type == "BUBBLES")
            {
              sn = clsUUT.scanLabel.Substring(14, 10);
              ppid = clsUUT.scanLabel.Substring(0, 14);
            }
            if (this.FxcnSfcListenerSMO.PreTestCheck(ref ppid, ref sn, ref mac1st, (uint) clsUUT.mac_count, (uint) clsUUT.mac_increment, this.info))
            {
              this.TextSFISMessage.Text = mac1st + "," + ppid + ",PASS";
              flag = false;
            }
            else
            {
              this.TextSFISMessage.Text = mac1st + "," + ppid + ",FAIL";
              flag = true;
              this.txtLabel.Text = "";
              this.txtMAC.Text = "";
              this.cbChkSFIS(true);
              this.cbUUTGroup(true);
              this.cbUUTLabelFocus();
              ++this.m_Retry;
            }
          }
          else if (this.m_TestMode == 7)
          {
            if (!this.CheckGoldenSampleSNMAC(clsUUT.scanLabel, clsUUT.scanMAC[0]))
            {
              flag = true;
              this.txtLabel.Text = "";
              this.txtMAC.Text = "";
              this.cbChkSFIS(true);
              this.cbUUTGroup(true);
              this.cbUUTLabelFocus();
              ++this.m_Retry;
            }
            else
              flag = false;
          }
          else
            flag = false;
        }
        if (this.m_bFirsttime)
        {
          if (this.m_TestMode == 8 && this.m_bRMAContinueTest)
          {
            int num = (int) new NewMessageBox()
            {
              Message = "Please install the DUT and Click 'OK' to start the test!"
            }.ShowDialog();
            Thread.Sleep(1000);
          }
          else
          {
            int num = (int) new NewMessageBox()
            {
              Message = (!this.m_usbrelayenable ? "Please install the DUT and reboot the DOS PC!  Click 'OK' after the DOS PC is ready!" : "Please install the DUT!  Click 'OK' after the DUT is installed!")
            }.ShowDialog();
            Thread.Sleep(1000);
            if (this.m_usbrelayenable && !this.m_bDUTPCPowerON)
            {
              this.cbStatusColor(Color.Red);
              this.cbStatusText("Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC..........Please WAIT!............");
              this.cbbtnOK(false);
            }
          }
        }
        if (this.m_bHotSwapped)
        {
          this.cbbtnOK(false);
          int num = (int) new NewMessageBox()
          {
            Message = "Install the new DUT!  Click 'OK' after the new DUT is installed!"
          }.ShowDialog();
        }
        this.cbChkSFIS(false);
        this.cbUUTGroup(false);
        this.m_ready = true;
        this.cbButtonPowerON(false);
        this.cbButtonPowerOFF(false);
        this.cbButtonBADGE(false);
        this.txtLabel.Text = "";
        this.txtMAC.Text = "";
        this.btnAbort.Enabled = true;
        this.txtBadge.Enabled = false;
        this.cbgoldenSampleMode(false);
        this.lblHardwareType.Text = clsUUT.hw_type;
        if (clsUUT.hw_type == "GENERIC")
          this.lblPartNumber.Text = this.m_duttype;
        else
          this.lblPartNumber.Text = clsUUT.cm_PartNumber;
      }
    }

    private bool CheckGoldenSampleSNMAC(string SN, string MAC)
    {
      bool flag = false;
      IniFile.FileName = soteDiag.soteDiag.appGoldenSample;
      this.m_Golden_Samples = (int) Convert.ToInt16(IniFile.GetProfile("GOLDEN SAMPLE", "NUMBER_OF_GOLDEN_SAMPLES", "0"));
      string[] strArray1 = new string[this.m_Golden_Samples];
      string[] strArray2 = new string[this.m_Golden_Samples];
      for (int index = 0; index < this.m_Golden_Samples; ++index)
      {
        strArray1[index] = IniFile.GetProfile("GOLDEN SAMPLE", nameof (SN) + (object) (index + 1));
        strArray2[index] = IniFile.GetProfile("GOLDEN SAMPLE", nameof (MAC) + (object) (index + 1));
      }
      for (int index = 0; index < this.m_Golden_Samples; ++index)
      {
        if (SN == strArray1[index] && MAC == strArray2[index])
        {
          flag = true;
          break;
        }
      }
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      return flag;
    }

    private void log2TestSummary(string csvfilename, bool bWriteHeader)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(csvfilename, true);
        if (bWriteHeader)
          streamWriter.WriteLine("All-in-one version,Date,SN Label,1st MAC,MAC counts,MAC increment,Test Mode,Test Loop,Test Results,Error Code,Test Summary");
        if (this.m_sfis_type == 90)
          streamWriter.WriteLine("v" + soteDiag.soteDiag.appVersion + "," + this.todayNow + "," + clsUUT.esrLabel + "," + clsUUT.scanMAC[0] + "," + (object) this.m_esr_Stride + "," + (object) clsUUT.mac_increment + "," + this.m_sTestMode + "," + (object) this.m_Loop + "," + this.m_txtOverallTestResult + "," + this.m_OverlTestErrorCode.ToString("D6") + "," + this.m_txtOverallErrorDescription);
        else
          streamWriter.WriteLine("v" + soteDiag.soteDiag.appVersion + "," + this.todayDate + "," + clsUUT.scanLabel + "," + clsUUT.scanMAC[0] + "," + (object) clsUUT.mac_count + "," + (object) clsUUT.mac_increment + "," + this.m_sTestMode + "," + (object) this.m_Loop + "," + this.m_txtOverallTestResult + "," + this.m_OverlTestErrorCode.ToString("D6") + "," + this.m_txtOverallErrorDescription);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void SendPostResult(string ppid, string mac1st, uint macCount, uint macIncrement)
    {
      string sn1 = (string) null;
      string str1 = Assembly.GetExecutingAssembly().GetName().Version.ToString();
      string errorDescription;
      if (clsUUT.hw_type == "PUTNAM" || clsUUT.hw_type == "BOERNE" || clsUUT.hw_type == "BUBBLES")
      {
        errorDescription = this.m_FCTErrorDescription + "; " + this.m_NVRAMVerifyErrorDescription + "; " + this.m_ProgramFRUErrorDescription + "; " + this.m_FRUVerifyErrorDescription + "; " + this.m_LABELErrorDescription + "; " + this.m_LOOPBACKErrorDescription;
        this.m_OverlTestErrorCode = this.m_iFCTErrorCode + this.m_iNVRAMVerifyErrorCode + this.m_iProgramFRUErrorCode + this.m_iFRUVerifyErrorCode + this.m_iLABELErrorCode + this.m_iLOOPBACKErrorCode;
      }
      else if (clsUUT.hw_type == "OBRIEN")
      {
        errorDescription = this.m_FCTErrorDescription + "; " + this.m_NVRAMVerifyErrorDescription + "; " + this.m_ProgramFRUErrorDescription + "; " + this.m_FRUVerifyErrorDescription + "; " + this.m_LABELErrorDescription + "; " + this.m_NCSIErrorDescription;
        this.m_OverlTestErrorCode = this.m_iFCTErrorCode + this.m_iNVRAMVerifyErrorCode + this.m_iProgramFRUErrorCode + this.m_iFRUVerifyErrorCode + this.m_iLABELErrorCode + this.m_iNCSIErrorCode;
      }
      else
      {
        errorDescription = this.m_FCTErrorDescription + "; " + this.m_NVRAMVerifyErrorDescription + "; " + this.m_ProgramFRUErrorDescription + "; " + this.m_FRUVerifyErrorDescription + "; " + this.m_LABELErrorDescription;
        this.m_OverlTestErrorCode = this.m_iFCTErrorCode + this.m_iNVRAMVerifyErrorCode + this.m_iProgramFRUErrorCode + this.m_iFRUVerifyErrorCode + this.m_iLABELErrorCode;
      }
      if (clsUUT.hw_type == "PUTNAM" || clsUUT.hw_type == "WOODVILLE" || (clsUUT.hw_type == "BOERNE" || clsUUT.hw_type == "BANDICOOT") || (clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BOBOLINK" || clsUUT.hw_type == "BOAR") || clsUUT.hw_type == "BUBBLES")
      {
        sn1 = ppid.Substring(14, 10);
        ppid = ppid.Substring(0, 14);
      }
      bool isPass;
      string status;
      if (this.m_OverlTestErrorCode == 0)
      {
        isPass = true;
        status = "PASS";
        if (this.m_Total_Passed + this.m_Total_Failed >= this.m_Total_Test_Threshold && this.m_Total_Passed < this.m_Total_Test_Threshold)
        {
          ++this.m_Total_Passed;
          --this.m_Total_Failed;
          this.cbtextTotalFailed(Convert.ToString(this.m_Total_Failed));
          if (this.m_Total_Failed == 0)
            this.cbtextTotalFailedColor(Color.Black, Color.LightGreen);
          else
            this.cbtextTotalFailedColor(Color.White, Color.Red);
          string txtLine2Replace1 = string.Format("{0}_TOTAL_FAILED = {1}", (object) this.m_sTestMode, (object) (this.m_Total_Failed + 1));
          string txtLine2Write1 = string.Format("{0}_TOTAL_FAILED = {1}", (object) this.m_sTestMode, (object) this.m_Total_Failed);
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace1, txtLine2Write1);
          this.cbtextTotalPassed(Convert.ToString(this.m_Total_Passed));
          string txtLine2Replace2 = string.Format("{0}_TOTAL_PASSED = {1}", (object) this.m_sTestMode, (object) (this.m_Total_Passed - 1));
          string txtLine2Write2 = string.Format("{0}_TOTAL_PASSED = {1}", (object) this.m_sTestMode, (object) this.m_Total_Passed);
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace2, txtLine2Write2);
        }
        else if (this.m_Total_Passed + this.m_Total_Failed < this.m_Total_Test_Threshold && this.m_Total_Passed < this.m_Total_Test_Threshold)
        {
          ++this.m_Total_Passed;
          this.cbtextTotalPassed(Convert.ToString(this.m_Total_Passed));
          string txtLine2Replace = string.Format("{0}_TOTAL_PASSED = {1}", (object) this.m_sTestMode, (object) (this.m_Total_Passed - 1));
          string txtLine2Write = string.Format("{0}_TOTAL_PASSED = {1}", (object) this.m_sTestMode, (object) this.m_Total_Passed);
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace, txtLine2Write);
        }
        string txtLine2Replace3 = string.Format("{0}_FAILED_COUNT = {1}", (object) this.m_sTestMode, (object) this.m_Failed_Count);
        this.m_Failed_Count = 0;
        string txtLine2Write3 = string.Format("{0}_FAILED_COUNT = {1}", (object) this.m_sTestMode, (object) this.m_Failed_Count);
        this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace3, txtLine2Write3);
        string txtLine2Replace4 = string.Format("{0}_ERRORCODE_LAST = {1}", (object) this.m_sTestMode, (object) this.m_Errorcode_Last.ToString("D6"));
        this.m_Errorcode_Last = this.m_OverlTestErrorCode;
        if (this.m_Failed_Count == 0)
          this.cbtextLastErrorColor(Color.Black, Color.LightGreen);
        else if (this.m_Failed_Count == 1)
          this.cbtextLastErrorColor(Color.Black, Color.Yellow);
        else if (this.m_Failed_Count == 2)
          this.cbtextLastErrorColor(Color.Black, Color.Orange);
        else
          this.cbtextLastErrorColor(Color.White, Color.Red);
        this.cbtextLastError(this.m_Errorcode_Last.ToString("D6"));
        string txtLine2Write4 = string.Format("{0}_ERRORCODE_LAST = {1}", (object) this.m_sTestMode, (object) this.m_Errorcode_Last.ToString("D6"));
        this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace4, txtLine2Write4);
      }
      else
      {
        isPass = false;
        status = "FAIL";
        if (this.m_Total_Passed + this.m_Total_Failed >= this.m_Total_Test_Threshold && this.m_Total_Failed < this.m_Total_Test_Threshold)
        {
          ++this.m_Total_Failed;
          --this.m_Total_Passed;
          this.cbtextTotalPassed(Convert.ToString(this.m_Total_Passed));
          if (this.m_Total_Failed == 0)
            this.cbtextTotalFailedColor(Color.Black, Color.LightGreen);
          else
            this.cbtextTotalFailedColor(Color.White, Color.Red);
          string txtLine2Replace1 = string.Format("{0}_TOTAL_PASSED = {1}", (object) this.m_sTestMode, (object) (this.m_Total_Passed + 1));
          string txtLine2Write1 = string.Format("{0}_TOTAL_PASSED = {1}", (object) this.m_sTestMode, (object) this.m_Total_Passed);
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace1, txtLine2Write1);
          this.cbtextTotalFailed(Convert.ToString(this.m_Total_Failed));
          string txtLine2Replace2 = string.Format("{0}_TOTAL_FAILED = {1}", (object) this.m_sTestMode, (object) (this.m_Total_Failed - 1));
          string txtLine2Write2 = string.Format("{0}_TOTAL_FAILED = {1}", (object) this.m_sTestMode, (object) this.m_Total_Failed);
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace2, txtLine2Write2);
        }
        else if (this.m_Total_Passed + this.m_Total_Failed < this.m_Total_Test_Threshold && this.m_Total_Failed < this.m_Total_Test_Threshold)
        {
          ++this.m_Total_Failed;
          this.cbtextTotalFailed(Convert.ToString(this.m_Total_Failed));
          if (this.m_Total_Failed == 0)
            this.cbtextTotalFailedColor(Color.Black, Color.LightGreen);
          else
            this.cbtextTotalFailedColor(Color.White, Color.Red);
          string txtLine2Replace = string.Format("{0}_TOTAL_FAILED = {1}", (object) this.m_sTestMode, (object) (this.m_Total_Failed - 1));
          string txtLine2Write = string.Format("{0}_TOTAL_FAILED = {1}", (object) this.m_sTestMode, (object) this.m_Total_Failed);
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace, txtLine2Write);
        }
        if (this.m_Errorcode_Last == this.m_OverlTestErrorCode)
        {
          string txtLine2Replace = string.Format("{0}_FAILED_COUNT = {1}", (object) this.m_sTestMode, (object) this.m_Failed_Count);
          ++this.m_Failed_Count;
          string txtLine2Write = string.Format("{0}_FAILED_COUNT = {1}", (object) this.m_sTestMode, (object) this.m_Failed_Count);
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace, txtLine2Write);
          if (this.m_Failed_Count == 0)
            this.cbtextLastErrorColor(Color.Black, Color.LightGreen);
          else if (this.m_Failed_Count == 1)
            this.cbtextLastErrorColor(Color.Black, Color.Yellow);
          else if (this.m_Failed_Count == 2)
            this.cbtextLastErrorColor(Color.Black, Color.Orange);
          else
            this.cbtextLastErrorColor(Color.White, Color.Red);
        }
        else
        {
          string txtLine2Replace1 = string.Format("{0}_FAILED_COUNT = {1}", (object) this.m_sTestMode, (object) this.m_Failed_Count);
          this.m_Failed_Count = 1;
          string txtLine2Write1 = string.Format("{0}_FAILED_COUNT = {1}", (object) this.m_sTestMode, (object) this.m_Failed_Count);
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace1, txtLine2Write1);
          string txtLine2Replace2 = string.Format("{0}_ERRORCODE_LAST = {1}", (object) this.m_sTestMode, (object) this.m_Errorcode_Last.ToString("D6"));
          this.m_Errorcode_Last = this.m_OverlTestErrorCode;
          if (this.m_Failed_Count == 0)
            this.cbtextLastErrorColor(Color.Black, Color.LightGreen);
          else if (this.m_Failed_Count == 1)
            this.cbtextLastErrorColor(Color.Black, Color.Yellow);
          else if (this.m_Failed_Count == 2)
            this.cbtextLastErrorColor(Color.Black, Color.Orange);
          else
            this.cbtextLastErrorColor(Color.White, Color.Red);
          this.cbtextLastError(this.m_Errorcode_Last.ToString("D6"));
          string txtLine2Write2 = string.Format("{0}_ERRORCODE_LAST = {1}", (object) this.m_sTestMode, (object) this.m_Errorcode_Last.ToString("D6"));
          this.UpdateTextFile(soteDiag.soteDiag.appMonitor, txtLine2Replace2, txtLine2Write2);
        }
      }
      if (this.m_Total_Passed + this.m_Total_Failed == 0)
      {
        this.cblblTestYield(this.m_TestYield.ToString("N/A"));
      }
      else
      {
        this.m_TestYield = (double) this.m_Total_Passed / (double) (this.m_Total_Passed + this.m_Total_Failed);
        this.cblblTestYield(this.m_TestYield.ToString("P"));
      }
      this.m_txtOverallTestResult = status;
      this.m_txtOverallErrorDescription = errorDescription;
      string errorCode = this.m_OverlTestErrorCode.ToString("D6");
      if (this.m_sfis_enabled && this.m_sfis_type != 90 && (this.m_bTestStarted && this.m_TestMode != 6) && this.m_TestMode != 7)
      {
        if (this.m_OverlTestErrorCode == 0)
        {
          if (this.m_TestMode == 1)
            this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\PRODUCTION\\" + this.todayDate + "\\PASS";
          else if (this.m_TestMode == 9)
            this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\PRODUCTION_ERASENVRAM\\" + this.todayDate + "\\PASS";
          else if (this.m_TestMode == 2)
            this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\OBA\\" + this.todayDate + "\\PASS";
          else if (this.m_TestMode == 5)
            this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\STRESS\\" + this.todayDate + "\\PASS";
          else if (this.m_TestMode == 8)
            this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\RMA\\" + this.todayDate + "\\PASS";
          else
            this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\NULL\\" + this.todayDate + "\\PASS";
        }
        else if (this.m_TestMode == 1)
          this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\PRODUCTION\\" + this.todayDate + "\\FAIL";
        else if (this.m_TestMode == 9)
          this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\PRODUCTION_ERASENVRAM\\" + this.todayDate + "\\FAIL";
        else if (this.m_TestMode == 2)
          this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\OBA\\" + this.todayDate + "\\FAIL";
        else if (this.m_TestMode == 5)
          this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\STRESS\\" + this.todayDate + "\\FAIL";
        else if (this.m_TestMode == 8)
          this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\RMA\\" + this.todayDate + "\\FAIL";
        else
          this.m_sfis_log_path = this.m_sfis_log_dir + "\\" + clsUUT.cm_PartNumber + "\\" + this.m_test_station + "\\" + this.m_fixture_id + "\\NULL\\" + this.todayDate + "\\FAIL";
        if (!Directory.Exists(this.m_sfis_log_path))
        {
          try
          {
            Directory.CreateDirectory(this.m_sfis_log_path);
          }
          catch
          {
            int num = (int) new frmFail()
            {
              Message = string.Format("Failed to create SFIS directory under\n\n{0}\n\nPlease check the setting of\nSFIS_LOG_DIR = in soteDiag.ini.", (object) this.m_sfis_log_dir)
            }.ShowDialog();
            this.m_results += string.Format("\r\nFailed to create SFIS directory under {0}. Please check the setting of SFIS_LOG_DIR = in soteDiag.ini.", (object) this.m_sfis_log_dir);
            isPass = false;
            this.m_OverlTestErrorCode += 22000;
            errorCode = this.m_OverlTestErrorCode.ToString("D6");
            errorDescription += "; CopyFile: Failed to create the mapped SFIS directory";
            status = "FAIL";
            this.m_txtOverallTestResult = status;
            this.m_txtOverallErrorDescription = errorDescription;
            this.m_bResultSentToSFIS = true;
            if (this.m_iLABELErrorCode == 21000)
            {
              string ppid1 = this.m_SNLabel;
              string macLabel = this.m_MACLabel;
              string sn2 = (string) null;
              if (clsUUT.hw_type == "PUTNAM" || clsUUT.hw_type == "WOODVILLE" || (clsUUT.hw_type == "BOERNE" || clsUUT.hw_type == "BANDICOOT") || (clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BOBOLINK" || clsUUT.hw_type == "BOAR") || clsUUT.hw_type == "BUBBLES")
              {
                if (ppid1.Length < 14)
                {
                  sn2 = ppid1;
                }
                else
                {
                  sn2 = ppid1.Substring(14, 10);
                  ppid1 = ppid1.Substring(0, 14);
                }
              }
              this.FxcnSfcListenerSMO.PostTestResult(ppid1, sn2, macLabel, macCount, macIncrement, false, "LOCK01");
            }
            else
              this.FxcnSfcListenerSMO.PostTestResult(ppid, sn1, mac1st, macCount, macIncrement, isPass, errorCode);
          }
        }
      }
      if (this.m_iLABELErrorCode == 20000)
        this.todayDate = DateTime.Now.ToString(this.customFormatToday);
      if (this.m_sfis_type == 90 && clsUUT.hw_type == "GENERIC")
        this.cbGrid(this.todayDate, clsUUT.esrLabel, status, errorCode, errorDescription);
      else if (this.m_sfis_type == 90 && clsUUT.hw_type != "GENERIC")
        this.cbGrid(this.todayDate, clsUUT.esrLabel + "-" + clsUUT.scanLabel, status, errorCode, errorDescription);
      else
        this.cbGrid(this.todayDate, clsUUT.scanLabel, status, errorCode, errorDescription);
      this.m_sfcmsg = (string) null;
      if (clsUUT.hw_type == "GENERIC")
        macCount = (uint) this.m_esr_Stride;
      this.m_sfcmsg = "Test Result: All-in-one v" + str1 + "," + this.todayDate + "," + clsUUT.scanLabel + "," + clsUUT.scanMAC[0] + "," + (object) macCount + "," + (object) macIncrement + "," + this.m_sTestMode + "," + status + "," + errorCode + "," + errorDescription;
      if (this.m_iLABELErrorCode == 20000)
      {
        if (this.m_TestMode == 6)
          this.logDir = this.logDefault + clsUUT.hw_type + "-" + this.todayDate + "-FAI\\";
        else if (this.m_TestMode == 7)
          this.logDir = this.logDefault + clsUUT.hw_type + "-" + this.todayDate + "-GOLDENSAMPLE\\";
        else
          this.logDir = this.logDefault + clsUUT.hw_type + "-" + this.todayDate + "\\";
        if (!Directory.Exists(this.logDir))
          Directory.CreateDirectory(this.logDir);
        this.todayNow = DateTime.Now.ToString(this.customFormatNow);
        this.m_traceLog = this.logDir + clsUUT.scanLabel + "-" + clsUUT.scanMAC[0] + "-" + this.todayNow + ".trc";
        soteUtils.log2file(this.m_traceLog, this.m_results);
        this.m_results = "";
        soteUtils.log2file(this.logDir + clsUUT.scanLabel + "-" + clsUUT.scanMAC[0] + "-" + this.todayNow + ".txt", this.m_sfcmsg);
      }
      else
      {
        soteUtils.log2file(this.logDir + this.m_logFileName + ".txt", this.m_sfcmsg);
        if ((this.m_TestMode == 5 || this.m_TestMode == 8) && this.m_Loop == 1)
          this.log2TestSummary(this.m_TestSummaryFileName, true);
        else if (this.m_TestMode == 5 && this.m_Loop > 1 && this.m_Loop <= this.m_TestLoop || this.m_TestMode == 8 && this.m_Loop > 1 && this.m_Loop <= this.m_nRMATestLoop)
          this.log2TestSummary(this.m_TestSummaryFileName, false);
        else if (this.m_TestMode == 10)
        {
          if (!File.Exists(this.m_TestSummaryFileName))
            this.log2TestSummary(this.m_TestSummaryFileName, true);
          else
            this.log2TestSummary(this.m_TestSummaryFileName, false);
        }
      }
      if (this.m_TestMode == 2)
      {
        if (File.Exists(this.logDir + this.m_logFileName + ".oba"))
        {
          if (this.m_iFCTErrorCode == 0)
            File.Move(this.logDir + this.m_logFileName + ".oba", this.logDir + this.m_logFileName + "-PASS.oba");
          else
            File.Move(this.logDir + this.m_logFileName + ".oba", this.logDir + this.m_logFileName + "-FAIL.oba");
        }
      }
      else if (this.m_TestMode == 5)
      {
        if (File.Exists(this.logDir + this.m_logFileName + ".sts"))
        {
          if (this.m_iFCTErrorCode == 0)
            File.Move(this.logDir + this.m_logFileName + ".sts", this.logDir + this.m_logFileName + "-PASS.sts");
          else
            File.Move(this.logDir + this.m_logFileName + ".sts", this.logDir + this.m_logFileName + "-FAIL.sts");
        }
      }
      else if (this.m_TestMode == 8)
      {
        if (File.Exists(this.logDir + this.m_logFileName + ".rma"))
        {
          if (this.m_iFCTErrorCode == 0)
            File.Move(this.logDir + this.m_logFileName + ".rma", this.logDir + this.m_logFileName + "-PASS.rma");
          else
            File.Move(this.logDir + this.m_logFileName + ".rma", this.logDir + this.m_logFileName + "-FAIL.rma");
        }
      }
      else if (File.Exists(this.logDir + this.m_logFileName + ".fct"))
      {
        if (this.m_esr_sfis_enabled && this.m_sfis_type == 90)
        {
          File.Copy(this.logDir + this.m_logFileName + ".fct", this.logDir + clsUUT.esrLabel + "-" + this.m_MAC[0] + "-" + this.todayNow + ".pid", true);
          if (File.Exists(soteDiag.soteDiag.appESR))
            File.Copy(soteDiag.soteDiag.appESR, this.logDir + "\\" + this.m_esr_pid + ".ini", true);
        }
        if (this.m_iFCTErrorCode == 0)
          File.Move(this.logDir + this.m_logFileName + ".fct", this.logDir + this.m_logFileName + "-PASS.fct");
        else
          File.Move(this.logDir + this.m_logFileName + ".fct", this.logDir + this.m_logFileName + "-FAIL.fct");
      }
      if (File.Exists(this.logDir + this.m_logFileName + ".ver"))
      {
        if (this.m_iNVRAMVerifyErrorCode == 0)
          File.Move(this.logDir + this.m_logFileName + ".ver", this.logDir + this.m_logFileName + "-PASS.ver");
        else
          File.Move(this.logDir + this.m_logFileName + ".ver", this.logDir + this.m_logFileName + "-FAIL.ver");
      }
      if (File.Exists(this.logDir + this.m_logFileName + ".ncsi"))
      {
        if (this.m_iNCSIErrorCode == 0)
          File.Move(this.logDir + this.m_logFileName + ".ncsi", this.logDir + this.m_logFileName + "-PASS.ncsi");
        else
          File.Move(this.logDir + this.m_logFileName + ".ncsi", this.logDir + this.m_logFileName + "-FAIL.ncsi");
      }
      if (this.m_sfis_enabled && this.m_sfis_type != 90 && (this.m_bTestStarted && this.m_TestMode != 6) && this.m_TestMode != 7)
      {
        if (errorDescription.Contains("Failed to create the mapped SFIS directory"))
        {
          this.RaiseUserAbortEvent();
        }
        else
        {
          try
          {
            if (File.Exists(this.m_traceLog))
              this.copyFile2MappedNetworkDrive(this.m_traceLog, this.m_sfis_log_path + "\\" + this.m_traceLogFileName);
            if (File.Exists(this.logDir + this.m_ProgramFRUFileName))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_ProgramFRUFileName, this.m_sfis_log_path + "\\" + this.m_ProgramFRUFileName);
            if (File.Exists(this.logDir + this.m_VerifyFRUFileName))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_VerifyFRUFileName, this.m_sfis_log_path + "\\" + this.m_VerifyFRUFileName);
            if (File.Exists(this.logDir + this.m_logFileName + ".txt"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + ".txt", this.m_sfis_log_path + "\\" + this.m_logFileName + ".txt");
            if (File.Exists(this.logDir + this.m_logFileName + "-PASS.fct"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-PASS.fct", this.m_sfis_log_path + "\\" + this.m_logFileName + "-PASS.fct");
            if (File.Exists(this.logDir + this.m_logFileName + "-FAIL.fct"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-FAIL.fct", this.m_sfis_log_path + "\\" + this.m_logFileName + "-FAIL.fct");
            if (File.Exists(this.logDir + this.m_logFileName + "-PASS.oba"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-PASS.oba", this.m_sfis_log_path + "\\" + this.m_logFileName + "-PASS.oba");
            if (File.Exists(this.logDir + this.m_logFileName + "-FAIL.oba"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-FAIL.oba", this.m_sfis_log_path + "\\" + this.m_logFileName + "-FAIL.oba");
            if (File.Exists(this.logDir + this.m_logFileName + "-PASS.sts"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-PASS.sts", this.m_sfis_log_path + "\\" + this.m_logFileName + "-PASS.sts");
            if (File.Exists(this.logDir + this.m_logFileName + "-FAIL.sts"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-FAIL.sts", this.m_sfis_log_path + "\\" + this.m_logFileName + "-FAIL.sts");
            if (File.Exists(this.logDir + this.m_logFileName + "-PASS.ver"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-PASS.ver", this.m_sfis_log_path + "\\" + this.m_logFileName + "-PASS.ver");
            if (File.Exists(this.logDir + this.m_logFileName + "-FAIL.ver"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-FAIL.ver", this.m_sfis_log_path + "\\" + this.m_logFileName + "-FAIL.ver");
            if (File.Exists(this.logDir + this.m_logFileName + "-PASS.ncsi"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-PASS.ncsi", this.m_sfis_log_path + "\\" + this.m_logFileName + "-PASS.ncsi");
            if (File.Exists(this.logDir + this.m_logFileName + "-FAIL.ncsi"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-FAIL.ncsi", this.m_sfis_log_path + "\\" + this.m_logFileName + "-FAIL.ncsi");
            if (File.Exists(this.logDir + this.m_logFileName + "-FCT-PASS.csv"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-FCT-PASS.csv", this.m_sfis_log_path + "\\" + this.m_logFileName + "-FCT-PASS.csv");
            if (File.Exists(this.logDir + this.m_logFileName + "-FCT-FAIL.csv"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-FCT-FAIL.csv", this.m_sfis_log_path + "\\" + this.m_logFileName + "-FCT-FAIL.csv");
            if (File.Exists(this.logDir + this.m_logFileName + "-OBA-PASS.csv"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-OBA-PASS.csv", this.m_sfis_log_path + "\\" + this.m_logFileName + "-OBA-PASS.csv");
            if (File.Exists(this.logDir + this.m_logFileName + "-OBA-FAIL.csv"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-OBA-FAIL.csv", this.m_sfis_log_path + "\\" + this.m_logFileName + "-OBA-FAIL.csv");
            if (File.Exists(this.logDir + this.m_logFileName + "-STS-PASS.csv"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-STS-PASS.csv", this.m_sfis_log_path + "\\" + this.m_logFileName + "-STS-PASS.csv");
            if (File.Exists(this.logDir + this.m_logFileName + "-STS-FAIL.csv"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-STS-FAIL.csv", this.m_sfis_log_path + "\\" + this.m_logFileName + "-STS-FAIL.csv");
            if (File.Exists(this.logDir + this.m_logFileName + "-NVRAMVerify-PASS.csv"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-NVRAMVerify-PASS.csv", this.m_sfis_log_path + "\\" + this.m_logFileName + "-NVRAMVerify-PASS.csv");
            if (File.Exists(this.logDir + this.m_logFileName + "-NVRAMVerify-FAIL.csv"))
              this.copyFile2MappedNetworkDrive(this.logDir + this.m_logFileName + "-NVRAMVerify-FAIL.csv", this.m_sfis_log_path + "\\" + this.m_logFileName + "-NVRAMVerify-FAIL.csv");
          }
          catch (Exception ex)
          {
            frmFail frmFail = new frmFail();
            string str2 = string.Format("Failed to copy file: {0}", (object) ex.Message);
            soteDiag.soteDiag soteDiag = this;
            soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str2;
            frmFail.Message = str2;
            int num = (int) frmFail.ShowDialog();
            isPass = false;
            this.m_OverlTestErrorCode += 22000;
            errorCode = this.m_OverlTestErrorCode.ToString("D6");
            if (this.m_iLABELErrorCode == 21000)
            {
              string ppid1 = this.m_SNLabel;
              string macLabel = this.m_MACLabel;
              string sn2 = (string) null;
              if (clsUUT.hw_type == "PUTNAM" || clsUUT.hw_type == "WOODVILLE" || (clsUUT.hw_type == "BOERNE" || clsUUT.hw_type == "BANDICOOT") || (clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BOBOLINK" || clsUUT.hw_type == "BOAR") || clsUUT.hw_type == "BUBBLES")
              {
                if (ppid1.Length < 14)
                {
                  sn2 = ppid1;
                }
                else
                {
                  sn2 = ppid1.Substring(14, 10);
                  ppid1 = ppid1.Substring(0, 14);
                }
              }
              this.FxcnSfcListenerSMO.PostTestResult(ppid1, sn2, macLabel, macCount, macIncrement, false, "LOCK01");
            }
            else
              this.FxcnSfcListenerSMO.PostTestResult(ppid, sn1, mac1st, macCount, macIncrement, isPass, errorCode);
            this.m_bResultSentToSFIS = true;
            string str3 = "FAIL";
            this.m_txtOverallTestResult = str3;
            this.m_txtOverallErrorDescription = errorDescription;
            this.UpdateTextFile(this.logDir + this.m_logFileName + ".txt", this.m_sfcmsg, "Test Result: All-in-one v" + str1 + "," + this.todayDate + "," + clsUUT.scanLabel + "," + clsUUT.scanMAC[0] + "," + (object) macCount + "," + (object) macIncrement + "," + this.m_sTestMode + "," + str3 + "," + errorCode + "," + errorDescription);
            this.RaiseUserAbortEvent();
          }
        }
        if (this.m_iLABELErrorCode == 21000)
        {
          string ppid1 = this.m_SNLabel;
          string macLabel = this.m_MACLabel;
          string sn2 = (string) null;
          if (clsUUT.hw_type == "PUTNAM" || clsUUT.hw_type == "WOODVILLE" || (clsUUT.hw_type == "BOERNE" || clsUUT.hw_type == "BANDICOOT") || (clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BOBOLINK" || clsUUT.hw_type == "BOAR") || clsUUT.hw_type == "BUBBLES")
          {
            if (ppid1.Length < 14)
            {
              sn2 = ppid1;
            }
            else
            {
              sn2 = ppid1.Substring(14, 10);
              ppid1 = ppid1.Substring(0, 14);
            }
          }
          this.FxcnSfcListenerSMO.PostTestResult(ppid1, sn2, macLabel, macCount, macIncrement, false, "LOCK01");
        }
        else
          this.FxcnSfcListenerSMO.PostTestResult(ppid, sn1, mac1st, macCount, macIncrement, isPass, errorCode);
        this.m_bResultSentToSFIS = true;
        this.m_bTestStarted = false;
      }
      else if (this.m_TestMode == 6 || this.m_TestMode == 7)
      {
        this.m_bResultSentToSFIS = true;
        this.m_bTestStarted = false;
      }
      if (this.m_YieldTracking_enabled && this.m_Total_Passed + this.m_Total_Failed >= this.m_Total_Test_Threshold && this.m_TestYield < this.m_TestYield_Expected)
      {
        frmFail frmFail = new frmFail();
        string str2 = string.Format("Actual Test Yield of {0} is below\nExpected Test Yield of {1}.\n\nTest Can't be run!\nPlease Close the app!", (object) this.m_TestYield.ToString("P"), (object) this.m_TestYield_Expected.ToString("P"));
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\r\n" + str2;
        frmFail.Message = str2;
        int num = (int) frmFail.ShowDialog();
        this.RaiseUserAbortEvent();
      }
      if (!this.m_YieldTracking_enabled || this.m_Failed_Count < this.m_Failed_Count_Max_Allowed)
        return;
      frmFail frmFail1 = new frmFail();
      string str4 = string.Format("Failed with the ERROR code, {0}\n{1} times consecutively!\n\nTest Can't be run!\nPlease Close the app!", (object) this.m_Errorcode_Last, (object) this.m_Failed_Count);
      soteDiag.soteDiag soteDiag1 = this;
      soteDiag1.m_results = soteDiag1.m_results + "\r\n" + str4;
      frmFail1.Message = str4;
      int num1 = (int) frmFail1.ShowDialog();
      this.RaiseUserAbortEvent();
    }

    private void txtBadge_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.txtLabel.Focus();
    }

    private void txtBadge_Leave(object sender, EventArgs e)
    {
      this.m_badge = this.txtBadge.Text;
      if (this.m_badge == "")
      {
        this.m_badge = "DefaultOperator";
        this.txtBadge.Text = "DefaultOperator";
      }
      this.FxcnSfcListenerSMO.OperatorId = this.m_badge;
      this.txtBadge.Enabled = false;
      this.txtLabel.Focus();
    }

    private void txtMAC_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '\r')
        return;
      this.cbbtnOK(false);
      this.btnOK_Click(sender, (EventArgs) e);
    }

    private bool readINI_Boerne(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 10;
        soteDiag.soteDiag.sn_addr1 = 56;
        soteDiag.soteDiag.sn_addr2 = 163;
        soteDiag.soteDiag.mac_addr1 = 366;
        soteDiag.soteDiag.mac_addr2 = 372;
        soteDiag.soteDiag.mac_addr3 = 378;
        soteDiag.soteDiag.mac_addr4 = 384;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile("BOERNE", "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile("BOERNE", "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_Boerne: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_Boerne: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_Putnam(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 10;
        soteDiag.soteDiag.sn_addr1 = 54;
        soteDiag.soteDiag.sn_addr2 = 161;
        soteDiag.soteDiag.mac_addr1 = 358;
        soteDiag.soteDiag.mac_addr2 = 364;
        soteDiag.soteDiag.mac_addr3 = 370;
        soteDiag.soteDiag.mac_addr4 = 376;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_Putnam: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_Putnam: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_BUBBLES(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 10;
        soteDiag.soteDiag.sn_addr1 = 50;
        soteDiag.soteDiag.sn_addr2 = 157;
        soteDiag.soteDiag.mac_addr1 = 411;
        soteDiag.soteDiag.mac_addr2 = 417;
        soteDiag.soteDiag.mac_addr3 = 423;
        soteDiag.soteDiag.mac_addr4 = 429;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_BUBBLES: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_BUBBLES: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_ARAL(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 11;
        soteDiag.soteDiag.sn_addr1 = 200;
        soteDiag.soteDiag.sn_addr2 = 345;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_ARAL: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_ARAL: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_CASPIAN(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 11;
        soteDiag.soteDiag.sn_addr1 = 188;
        soteDiag.soteDiag.sn_addr2 = 325;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_CASPIAN: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_CASPIAN: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_Woodville(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 10;
        soteDiag.soteDiag.sn_addr1 = 54;
        soteDiag.soteDiag.sn_addr2 = 161;
        soteDiag.soteDiag.mac_addr1 = 294;
        soteDiag.soteDiag.mac_addr2 = 300;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_Woodville: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_Woodville: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_Mustang(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.label_prefix = "11S";
        soteDiag.soteDiag.pn_len = 12;
        soteDiag.soteDiag.pn_addr = 60;
        soteDiag.soteDiag.sn_addr = 84;
        soteDiag.soteDiag.hi_sn_addr = 90;
        soteDiag.soteDiag.sn_len = 6;
        soteDiag.soteDiag.hi_sn_len = 6;
        soteDiag.soteDiag.mac_addr = 1600;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadIniVPD: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readIniVPD: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_M4161(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.label_prefix = "8S";
        soteDiag.soteDiag.pn_len = 12;
        soteDiag.soteDiag.pn_addr = 60;
        soteDiag.soteDiag.sn_addr = 84;
        soteDiag.soteDiag.hi_sn_addr = 90;
        soteDiag.soteDiag.sn_len = 11;
        soteDiag.soteDiag.hi_sn_len = 6;
        soteDiag.soteDiag.mac_addr = 111;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadIniVPD: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readIniVPD: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_Cardassia(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.mac_addr3 = 305;
        soteDiag.soteDiag.mac_addr4 = 325;
        soteDiag.soteDiag.register_06_value = byte.MaxValue;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadIniFRU: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readIniFRU: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_Bashir(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.register_06_value = (byte) 0;
        soteDiag.soteDiag.register_0E_value = (byte) 0;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_Bashir: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_Bashir: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_BANDICOOT(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 10;
        soteDiag.soteDiag.sn_addr1 = 57;
        soteDiag.soteDiag.sn_addr2 = 164;
        soteDiag.soteDiag.mac_addr1 = 302;
        soteDiag.soteDiag.mac_addr2 = 481;
        soteDiag.soteDiag.mac_addr3 = 308;
        soteDiag.soteDiag.mac_addr4 = 487;
        soteDiag.soteDiag.mac_addr5 = 497;
        soteDiag.soteDiag.mac_addr6 = 505;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_BANDICOOT: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_BANDICOOT: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_BOBCAT(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 10;
        soteDiag.soteDiag.sn_addr1 = 46;
        soteDiag.soteDiag.sn_addr2 = 143;
        soteDiag.soteDiag.mac_addr1 = 278;
        soteDiag.soteDiag.mac_addr2 = 446;
        soteDiag.soteDiag.mac_addr3 = 284;
        soteDiag.soteDiag.mac_addr4 = 452;
        soteDiag.soteDiag.mac_addr5 = 462;
        soteDiag.soteDiag.mac_addr6 = 470;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_BOBCAT: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_BOBCAT: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_BOBOLINK(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 10;
        soteDiag.soteDiag.sn_addr1 = 50;
        soteDiag.soteDiag.sn_addr2 = 149;
        soteDiag.soteDiag.mac_addr1 = 286;
        soteDiag.soteDiag.mac_addr2 = 465;
        soteDiag.soteDiag.mac_addr3 = 292;
        soteDiag.soteDiag.mac_addr4 = 471;
        soteDiag.soteDiag.mac_addr5 = 481;
        soteDiag.soteDiag.mac_addr6 = 489;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_BOBOLINK: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_BOBOLINK: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_M150PM(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 16;
        soteDiag.soteDiag.sn_addr1 = 51;
        soteDiag.soteDiag.sn_addr2 = 142;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_M150PM: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_M150PM: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_BOAR(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.sn_len = 10;
        soteDiag.soteDiag.sn_addr1 = 53;
        soteDiag.soteDiag.sn_addr2 = 150;
        soteDiag.soteDiag.mac_addr1 = 286;
        soteDiag.soteDiag.mac_addr2 = 454;
        soteDiag.soteDiag.mac_addr3 = 292;
        soteDiag.soteDiag.mac_addr4 = 460;
        soteDiag.soteDiag.mac_addr5 = 470;
        soteDiag.soteDiag.mac_addr6 = 478;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_BOAR: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_BOAR: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_PAULI(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 289;
        soteDiag.soteDiag.mac_addr3 = 309;
        soteDiag.soteDiag.mac_addr4 = 469;
        soteDiag.soteDiag.register_06_value = (byte) 254;
        soteDiag.soteDiag.register_0E_value = (byte) 0;
        soteDiag.soteDiag.register_6D_value = (byte) 240;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_PAULI: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_PAULI: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_HERTZ(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 429;
        soteDiag.soteDiag.register_06_value = (byte) 254;
        soteDiag.soteDiag.register_0E_value = (byte) 0;
        soteDiag.soteDiag.register_6D_value = (byte) 240;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_HERTZ: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_HERTZ: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_GAUSS(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 289;
        soteDiag.soteDiag.mac_addr3 = 309;
        soteDiag.soteDiag.mac_addr4 = 469;
        soteDiag.soteDiag.register_06_value = (byte) 254;
        soteDiag.soteDiag.register_0E_value = (byte) 0;
        soteDiag.soteDiag.register_6D_value = (byte) 240;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_GAUSS: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_GAUSS: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P225ED(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.register_06_value = (byte) 2;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P225ED: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P225ED: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P225EDLP(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.register_06_value = (byte) 2;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P225EDLP: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P225EDLP: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P225EPD(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 429;
        soteDiag.soteDiag.register_06_value = (byte) 2;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P225EPD: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P225EPD: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P225EPDLP(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 429;
        soteDiag.soteDiag.register_06_value = (byte) 2;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P225EPDLP: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P225EPDLP: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P210ED(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.register_06_value = (byte) 2;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P210ED: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P210ED: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P210EDLP(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.register_06_value = (byte) 2;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P210EDLP: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P210EDLP: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P210EPD(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 429;
        soteDiag.soteDiag.register_06_value = (byte) 2;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P210EPD: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P210EPD: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P210EPDLP(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 429;
        soteDiag.soteDiag.register_06_value = (byte) 2;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P210EPDLP: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P210EPDLP: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P210TED(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.register_06_value = (byte) 1;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P210TED: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P210TED: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P210TEDLP(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.register_06_value = (byte) 1;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P210TEDLP: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P210TEDLP: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P210TEPD(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 429;
        soteDiag.soteDiag.register_06_value = (byte) 1;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P210TEPD: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P210TEPD: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_P210TEPDLP(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 269;
        soteDiag.soteDiag.mac_addr2 = 429;
        soteDiag.soteDiag.register_06_value = (byte) 1;
        soteDiag.soteDiag.register_0E_value = byte.MaxValue;
        soteDiag.soteDiag.register_6D_value = (byte) 176;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_P210TEPDLP: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_P210TEPDLP: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_Corak(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.mac_addr3 = 305;
        soteDiag.soteDiag.mac_addr4 = 325;
        soteDiag.soteDiag.register_06_value = byte.MaxValue;
        soteDiag.soteDiag.register_0E_value = (byte) 252;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_Corak: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_Corak: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_Gamma(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.mac_addr3 = 305;
        soteDiag.soteDiag.mac_addr4 = 325;
        soteDiag.soteDiag.register_06_value = (byte) 251;
        soteDiag.soteDiag.register_0E_value = (byte) 0;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        soteDiag.soteDiag.cmPN = IniFile.GetProfile(hw_type, "PN");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_Gamma: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_Gamma: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_N2004(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 67;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 52;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 54;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.register_06_value = (byte) 251;
        soteDiag.soteDiag.register_0E_value = (byte) 0;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        soteDiag.soteDiag.cmPN = IniFile.GetProfile(hw_type, "PN");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_N2004: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_N2004: Excepton encountered!");
        return false;
      }
      return true;
    }

    public bool readINI_Obrien(string hw_type)
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      try
      {
        soteDiag.soteDiag.pn_addr = 65;
        soteDiag.soteDiag.pn_len = 9;
        soteDiag.soteDiag.sn_addr = 50;
        soteDiag.soteDiag.sn_len = 2;
        soteDiag.soteDiag.hi_sn_addr = 52;
        soteDiag.soteDiag.hi_sn_len = 12;
        soteDiag.soteDiag.mac_addr1 = 265;
        soteDiag.soteDiag.mac_addr2 = 285;
        soteDiag.soteDiag.mac_addr3 = 305;
        soteDiag.soteDiag.mac_addr4 = 325;
        soteDiag.soteDiag.register_06_value = (byte) 0;
        soteDiag.soteDiag.register_0E_value = (byte) 0;
        soteDiag.soteDiag.mac_count = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_COUNT"));
        soteDiag.soteDiag.mac_increment = (int) Convert.ToInt16(IniFile.GetProfile(hw_type, "MAC_INCREMENT"));
        soteDiag.soteDiag.bin_template = IniFile.GetProfile(hw_type, "BIN_TEMPLATE");
        soteDiag.soteDiag.text_template = IniFile.GetProfile(hw_type, "TEXT_TEMPLATE");
        soteDiag.soteDiag.padText = IniFile.GetProfile(hw_type, "EEPROM_PADDING");
        soteDiag.soteDiag.cmPN = IniFile.GetProfile(hw_type, "PN");
        this.m_network_adapter = IniFile.GetProfile(hw_type, "NETWORK_ADAPTER");
        if (soteDiag.soteDiag.bin_template == "")
        {
          soteDiag.soteDiag.showFailMsgDlg("BIN_TEMPLATE missing");
          return false;
        }
        soteDiag.soteDiag.bin_template = Directory.GetCurrentDirectory() + "\\" + soteDiag.soteDiag.bin_template;
        if (!File.Exists(soteDiag.soteDiag.bin_template))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.bin_template);
          return false;
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\nreadINI_Obrien: " + ex.Message;
        soteDiag.soteDiag.showFailMsgDlg("readINI_Obrien: Excepton encountered!");
        return false;
      }
      return true;
    }

    private byte ChksumFB(byte[] buffWorking, int start, int end, int pos)
    {
      buffWorking[pos] = (byte) 0;
      int num = 0;
      for (int index = start; index < end; ++index)
        num += (int) buffWorking[index];
      return (byte) (-num & (int) byte.MaxValue);
    }

    private byte Chksum(byte[] buffWorking, int start, int end, int pos)
    {
      buffWorking[pos] = (byte) 0;
      int num = 0;
      for (int index = start; index < end; ++index)
        num += (int) buffWorking[index];
      return (byte) ((~num & (int) byte.MaxValue) + 1);
    }

    public byte ChksumTemplate(byte[] buffWorking, int start, int end)
    {
      int num = 0;
      for (int index = start; index < end; ++index)
        num += (int) buffWorking[index];
      return (byte) ((~num & (int) byte.MaxValue) + 1);
    }

    public static void VerifyChksum(int chksum, int expectedChksum)
    {
      if (chksum == expectedChksum)
        return;
      int num = (int) new frmFail()
      {
        Message = "Checksum Miscompared - Invalid Template!"
      }.ShowDialog();
      Application.Exit();
    }

    public static void VerifyProgrammedChksum(int chksum, int expectedChksum)
    {
      if (chksum == expectedChksum)
        return;
      int num = (int) new frmFail()
      {
        Message = "Checksum Miscalculated!"
      }.ShowDialog();
      Application.Exit();
    }

    public static byte ChksumVerification(byte[] buffWorking, string hw_type)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      switch (hw_type)
      {
        case "CORAK":
        case "CARDASSIA":
        case "BASHIR":
        case "GAMMA":
        case "OBRIEN":
        case "P225ED":
        case "P225EPD":
        case "P210ED":
        case "P210EPD":
        case "P210TED":
        case "P210TEPD":
        case "PAULI":
        case "HERTZ":
        case "GAUSS":
          for (int index = 11; index <= 13; ++index)
            num1 += (int) buffWorking[index];
          for (int index = 50; index <= 63; ++index)
            num2 += (int) buffWorking[index];
          for (int index = 65; index <= 73; ++index)
            num3 += (int) buffWorking[index];
          int num5 = (int) buffWorking[79];
          num4 = num1 + num2 + num3 + num5 & (int) byte.MaxValue;
          break;
        case "N2004":
          for (int index = 11; index <= 13; ++index)
            num1 += (int) buffWorking[index];
          for (int index = 52; index <= 65; ++index)
            num2 += (int) buffWorking[index];
          for (int index = 67; index <= 75; ++index)
            num3 += (int) buffWorking[index];
          int num6 = (int) buffWorking[79];
          num4 = num1 + num2 + num3 + num6 & (int) byte.MaxValue;
          break;
      }
      return (byte) num4;
    }

    public static void VerifyFilesize(string fileName, long fileSize)
    {
      long length = new FileInfo(fileName).Length;
      if (fileSize == length)
        return;
      int num = (int) new frmFail()
      {
        Message = "Filesize Miscompared - Invalid Template!"
      }.ShowDialog();
      Application.Exit();
    }

    public static void SetBoardInfoAreaFRUA1913G(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(14, 10).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[56 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[163 + index] = bytes[index];
    }

    public static void SetBoardInfoAreaFRUA1904GH(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(14, 10).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[54 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[161 + index] = bytes[index];
    }

    public static void SetBoardInfoAreaFRUBUBBLES(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(14, 10).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[50 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[157 + index] = bytes[index];
    }

    public static void SetBoardInfoAreaFRUCASPIAN(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[115] = (byte) totalMinutes;
      buffWorking[116] = (byte) (totalMinutes >> 8);
      buffWorking[117] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(12, 11).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[325 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[188 + index] = bytes[index];
    }

    public static void SetBoardInfoAreaFRUARAL(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[115] = (byte) totalMinutes;
      buffWorking[116] = (byte) (totalMinutes >> 8);
      buffWorking[117] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(12, 11).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[200 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[345 + index] = bytes[index];
    }

    public static void SetBoardInfoAreaFRUA2003GH(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(14, 10).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[54 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[161 + index] = bytes[index];
    }

    public void SetBoardInfoAreaFRUA1905GD(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 112, 94);
      buffWorking[115] = this.Chksum(buffWorking, 112, 115, 115);
    }

    public void SetBoardInfoAreaFRUA1904GD(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 112, 94);
      buffWorking[115] = this.Chksum(buffWorking, 112, 115, 115);
    }

    public void SetBoardInfoAreaFRUA2003GD(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 112, 94);
      buffWorking[115] = this.Chksum(buffWorking, 112, 115, 115);
    }

    public void SetBoardInfoAreaFRUBOAR(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(14, 10).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[53 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[150 + index] = bytes[index];
    }

    public void SetBoardInfoAreaFRUBANDICOOT(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(14, 10).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[57 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[164 + index] = bytes[index];
    }

    public void SetBoardInfoAreaFRUBOBCAT(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(14, 10).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[46 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[143 + index] = bytes[index];
    }

    public void SetBoardInfoAreaFRUBOBOLINK(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(14, 10).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[50 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[149 + index] = bytes[index];
    }

    public void SetBoardInfoAreaFRUM150PM(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 16).ToUpper());
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[soteDiag.soteDiag.sn_addr1 + index] = bytes[index];
      for (int index = 0; index < bytes.Length; ++index)
        buffWorking[soteDiag.soteDiag.sn_addr2 + index] = bytes[index];
    }

    public void SetBoardInfoAreaFRUPAULI(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUHERTZ(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUGAUSS(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP225ED(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP225EDLP(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP225EPD(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP225EPDLP(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP210ED(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP210EDLP(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP210EPD(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP210EPDLP(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP210TED(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP210TEDLP(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP210TEPD(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUP210TEPDLP(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUM2004G(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    public void SetBoardInfoAreaFRUN2004(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      long totalMinutes = (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) totalMinutes;
      buffWorking[12] = (byte) (totalMinutes >> 8);
      buffWorking[13] = (byte) (totalMinutes >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[52 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[67 + index] = bytes2[index];
    }

    public void SetBoardInfoAreaFRUAD2000DC(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      bool flag = true;
      int num1 = (int) Convert.ToChar(clsUUT.scanLabel.Substring(14, 1));
      if (49 <= num1 && num1 <= 57)
        num1 -= 48;
      else if (65 <= num1 && num1 <= 67)
        num1 -= 55;
      else
        flag = false;
      int num2 = (int) Convert.ToChar(clsUUT.scanLabel.Substring(15, 1));
      if (49 <= num2 && num2 <= 57)
        num2 -= 48;
      else if (65 <= num2 && num2 <= 86)
        num2 -= 55;
      else
        flag = false;
      int num3 = (int) Convert.ToChar(clsUUT.scanLabel.Substring(13, 1));
      if (48 <= num3 && num3 <= 57)
        num3 -= 48;
      else
        flag = false;
      int int16 = (int) Convert.ToInt16((DateTime.Now.Year.ToString().Substring(0, 3) + (object) num3).Substring(0, 4));
      long num4 = !flag ? (long) (DateTime.Now - Convert.ToDateTime("1/1/1996")).TotalMinutes : (long) (Convert.ToDateTime(string.Format("{0}/{1}/{2}", (object) num1, (object) num2, (object) int16)) - Convert.ToDateTime("1/1/1996")).TotalMinutes;
      buffWorking[11] = (byte) num4;
      buffWorking[12] = (byte) (num4 >> 8);
      buffWorking[13] = (byte) (num4 >> 16);
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(0, 2).ToUpper() + clsUUT.scanLabel.Substring(8, 12).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[50 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(2, 6).ToUpper() + clsUUT.scanLabel.Substring(20, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[65 + index] = bytes2[index];
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[85] = this.Chksum(buffWorking, 65, 74, 85);
      buffWorking[94] = (byte) 0;
      buffWorking[94] = this.Chksum(buffWorking, 80, 120, 94);
    }

    private bool readIniSFIS()
    {
      IniFile.FileName = soteDiag.soteDiag.appConfig;
      string profile = IniFile.GetProfile("SHOPFLOOR", "SFIS");
      if (profile == "")
        return false;
      if (profile.Contains("ESR"))
      {
        this.sfis_cm = "SysOps";
        this.sfis_ip = profile;
        return true;
      }
      if (profile.Contains("\\"))
      {
        this.sfis_cm = "LiteOn";
        this.sfis_ip = profile;
        return true;
      }
      if (profile.Contains("COM"))
      {
        this.sfis_cm = "FXCN";
        this.sfis_ip = profile;
        return true;
      }
      if (profile.Contains("FXCN-HP"))
      {
        this.sfis_cm = "FXCN-HP";
        this.sfis_ip = profile;
        return true;
      }
      if (!profile.Contains(":") || !profile.Contains("."))
      {
        int num = (int) new NewMessageBox()
        {
          Message = string.Format("Invalid SFIS format [ip:port] " + profile)
        }.ShowDialog();
        return false;
      }
      this.sfis_cm = "USI";
      this.sfis_ip = profile.Substring(0, profile.IndexOf(":"));
      this.sfis_port = (int) Convert.ToInt16(profile.Substring(profile.IndexOf(":") + 1));
      this.fixture_id = IniFile.GetProfile("SHOPFLOOR", "FIXTURE_ID").ToUpper();
      this.line = IniFile.GetProfile("SHOPFLOOR", "LINE").ToUpper();
      return true;
    }

    public static int WeekOfYear(string date)
    {
      try
      {
        if (date != "")
        {
          CultureInfo cultureInfo = new CultureInfo("en-US");
          Calendar calendar = cultureInfo.Calendar;
          CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
          DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
          return calendar.GetWeekOfYear(Convert.ToDateTime(date), calendarWeekRule, firstDayOfWeek);
        }
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("WeekOfYear:\n\n" + ex.Message);
      }
      return 0;
    }

    public static void SetBoardInfoAreaVPDMustang(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(clsUUT.scanLabel.Length - 6, 6).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[84 + index] = bytes1[index];
      int num = soteDiag.soteDiag.WeekOfYear(DateTime.Today.ToShortDateString());
      string str1 = num.ToString();
      num = DateTime.Today.Year & 15;
      string str2 = num.ToString();
      byte[] bytes2 = Encoding.ASCII.GetBytes(string.Format("{0}{1}", (object) str1.PadLeft(2, '0'), (object) str2.PadLeft(2, '0')));
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[107 + index] = bytes2[index];
    }

    public static void SetBoardInfoAreaVPDM4161(byte[] buffWorking)
    {
      if (clsUUT.scanLabel == "")
        return;
      byte[] bytes1 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(19, 4).ToUpper());
      for (int index = 0; index < bytes1.Length; ++index)
        buffWorking[91 + index] = bytes1[index];
      byte[] bytes2 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(16, 3).ToUpper());
      for (int index = 0; index < bytes2.Length; ++index)
        buffWorking[88 + index] = bytes2[index];
      byte[] bytes3 = Encoding.ASCII.GetBytes(clsUUT.scanLabel.Substring(12, 4).ToUpper());
      for (int index = 0; index < bytes3.Length; ++index)
        buffWorking[84 + index] = bytes3[index];
      byte[] bytes4 = Encoding.ASCII.GetBytes(string.Format("{0}{1}", (object) soteDiag.soteDiag.WeekOfYear(DateTime.Today.ToShortDateString()).ToString().PadLeft(2, '0'), (object) DateTime.Now.ToString("yy").PadLeft(2, '0')));
      for (int index = 0; index < bytes4.Length; ++index)
        buffWorking[107 + index] = bytes4[index];
    }

    public static void SetVPDbufMustang(byte[] buffWorking)
    {
      string[] strArray = new string[4];
      if (clsUUT.hw_type == "MUSTANG")
      {
        strArray[0] = clsUUT.scanMAC[0];
        strArray[1] = clsUUT.scanMAC[1];
        strArray[2] = clsUUT.scanMAC[2];
        strArray[3] = clsUUT.scanMAC[3];
      }
      for (int index1 = 0; index1 < 4; ++index1)
      {
        if (clsUUT.hw_type == "MUSTANG")
        {
          for (int index2 = 0; index2 < 6; ++index2)
            buffWorking[soteDiag.soteDiag.mac_addr + (index1 * 8 + index2)] = Convert.ToByte(strArray[index1].Substring(index2 * 2, 2), 16);
        }
      }
    }

    public static void SetVPDbufM4161(byte[] buffWorking)
    {
      int num = Convert.ToInt32(clsUUT.scanMAC[0].Substring(6, 6), 16) + 1;
      string str = clsUUT.scanMAC[0].Substring(0, 6) + num.ToString("X6");
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr + 6 + index] = Convert.ToByte(str.Substring(index * 2, 2), 16);
    }

    public static void SetUUIDbuf(byte[] buffWorking)
    {
      string str1 = string.Format("{0:X16}", (object) (DateTime.Now - Convert.ToDateTime("10/15/1582")).Ticks);
      string str2 = string.Format("{0:X4}", (object) (new Random().Next(1, (int) ushort.MaxValue) & 16383 | 32768));
      string str3;
      if (clsUUT.hw_type == "M4161")
        str3 = string.Format("00000000000010008000{0}", (object) clsUUT.scanMAC[0]);
      else
        str3 = string.Format("{0}{1}1{2}{3}{4}", (object) str1.Substring(str1.Length - 8, 8), (object) str1.Substring(4, 4), (object) str1.Substring(1, 3), (object) str2, (object) clsUUT.scanMAC[0]);
      for (int index = 0; index < 16; ++index)
        buffWorking[159 + index] = Convert.ToByte(str3.Substring(index * 2, 2), 16);
      if (!(clsUUT.hw_type == "MUSTANG") && !(clsUUT.hw_type == "M4161"))
        return;
      byte[] buffer = new byte[1024];
      byte[] numArray = new byte[4];
      Array.Copy((Array) buffWorking, (Array) buffer, 1020);
      ulong crc = 0;
      byte[] flexvpdcrC32 = soteDiag.soteDiag.CalculateFLEXVPDCRC32(0, 1, buffer, 1020U, crc);
      buffWorking[1020] = flexvpdcrC32[0];
      buffWorking[1021] = flexvpdcrC32[1];
      buffWorking[1022] = flexvpdcrC32[2];
      buffWorking[1023] = flexvpdcrC32[3];
    }

    public static byte[] CalculateFLEXVPDCRC32(
      int check,
      int mirror,
      byte[] buffer,
      uint length,
      ulong crc)
    {
      byte[] numArray1 = new byte[4];
      byte[] numArray2 = new byte[4];
      numArray1[0] = numArray1[1] = numArray1[2] = numArray1[3] = byte.MaxValue;
      length += 4U;
      uint num1 = length;
      if (check != 0)
      {
        length += 4U;
        numArray2[3] = (byte) (crc % 256UL);
        crc /= 256UL;
        numArray2[2] = (byte) (crc % 256UL);
        crc /= 256UL;
        numArray2[1] = (byte) (crc % 256UL);
        crc /= 256UL;
        numArray2[0] = (byte) (crc % 256UL);
      }
      int index = 0;
      for (; length > 0U; --length)
      {
        if ((int) length != (int) num1 - 2 && (int) length != (int) num1 - 3)
        {
          uint num2 = (uint) numArray1[3];
          numArray1[3] = numArray1[2];
          numArray1[2] = numArray1[1];
          numArray1[1] = numArray1[0];
          if (length >= 4U)
          {
            if (mirror == 0 || length < 8U && check != 0)
            {
              numArray1[0] = buffer[index];
              ++index;
            }
            else
            {
              numArray1[0] = soteDiag.soteDiag.ReflectTable[(int) buffer[index]];
              ++index;
            }
          }
          else
            numArray1[0] = (byte) 0;
          if (check != 0 && length == 8U)
            buffer[index] = numArray2[0];
          uint num3 = num2 * 4U;
          numArray1[3] ^= soteDiag.soteDiag.PolyTable[(IntPtr) num3];
          numArray1[2] ^= soteDiag.soteDiag.PolyTable[(IntPtr) (num3 + 1U)];
          numArray1[1] ^= soteDiag.soteDiag.PolyTable[(IntPtr) (num3 + 2U)];
          numArray1[0] ^= soteDiag.soteDiag.PolyTable[(IntPtr) (num3 + 3U)];
        }
        if ((int) length == (int) num1 - 2 || (int) length == (int) num1 - 3)
          ++index;
      }
      crc = (ulong) numArray1[3];
      crc *= 256UL;
      crc += (ulong) numArray1[2];
      crc *= 256UL;
      crc += (ulong) numArray1[1];
      crc *= 256UL;
      crc += (ulong) numArray1[0];
      crc = check == 0 ? ~crc : crc;
      return new byte[4]
      {
        (byte) (crc >> 24),
        (byte) (crc >> 16),
        (byte) (crc >> 8),
        (byte) crc
      };
    }

    public static byte[] CalculateCRC32(byte[] Value)
    {
      uint num1 = uint.MaxValue;
      for (int index = 0; index < Value.Length; ++index)
        num1 = num1 >> 8 ^ soteDiag.soteDiag.CRCTable[(IntPtr) (num1 & (uint) byte.MaxValue ^ (uint) Value[index])];
      uint num2 = num1 ^ uint.MaxValue;
      return new byte[4]
      {
        (byte) (num2 >> 24),
        (byte) (num2 >> 16),
        (byte) (num2 >> 8),
        (byte) num2
      };
    }

    public void SetElement1FRUA1905GD(byte[] buffWorking)
    {
      for (int index1 = 0; index1 < soteDiag.soteDiag.mac_count; ++index1)
      {
        for (int index2 = 0; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[index1].Substring(index2 * 2, 2), 16);
      }
      buffWorking[195] = (byte) 0;
      buffWorking[195] = this.Chksum(buffWorking, 192, 213, 195);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[355] = (byte) 0;
      buffWorking[355] = this.Chksum(buffWorking, 352, 392, 355);
      buffWorking[395] = (byte) 0;
      buffWorking[395] = this.Chksum(buffWorking, 392, 444, 395);
    }

    public void SetElement1FRUA1904GD(byte[] buffWorking)
    {
      for (int index1 = 0; index1 < soteDiag.soteDiag.mac_count; ++index1)
      {
        for (int index2 = 0; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[index1].Substring(index2 * 2, 2), 16);
      }
      buffWorking[195] = (byte) 0;
      buffWorking[195] = this.Chksum(buffWorking, 192, 213, 195);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[355] = (byte) 0;
      buffWorking[355] = this.Chksum(buffWorking, 352, 392, 355);
      buffWorking[395] = (byte) 0;
      buffWorking[395] = this.Chksum(buffWorking, 392, 444, 395);
    }

    public void SetElement1FRUA2003GD(byte[] buffWorking)
    {
      for (int index1 = 0; index1 < soteDiag.soteDiag.mac_count; ++index1)
      {
        for (int index2 = 0; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[index1].Substring(index2 * 2, 2), 16);
      }
      buffWorking[195] = (byte) 0;
      buffWorking[195] = this.Chksum(buffWorking, 192, 213, 195);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 384, 339);
    }

    public void SetElement1FRUBOAR(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
      {
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr3 + index] = Convert.ToByte(clsUUT.scanMAC[2].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr4 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr5 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr6 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
      }
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[95] = this.Chksum(buffWorking, 8, 95, 95);
      buffWorking[167] = this.Chksum(buffWorking, 96, 167, 167);
      buffWorking[171] = this.Chksum(buffWorking, 173, 298, 171);
      buffWorking[172] = this.Chksum(buffWorking, 168, 172, 172);
      buffWorking[301] = this.Chksum(buffWorking, 303, 309, 301);
      buffWorking[302] = this.Chksum(buffWorking, 298, 302, 302);
      buffWorking[312] = this.Chksum(buffWorking, 314, 323, 312);
      buffWorking[313] = this.Chksum(buffWorking, 309, 313, 313);
      buffWorking[326] = this.Chksum(buffWorking, 328, 334, 326);
      buffWorking[327] = this.Chksum(buffWorking, 323, 327, 327);
      buffWorking[337] = this.Chksum(buffWorking, 339, 423, 337);
      buffWorking[338] = this.Chksum(buffWorking, 334, 338, 338);
      buffWorking[426] = this.Chksum(buffWorking, 428, 484, 426);
      buffWorking[427] = this.Chksum(buffWorking, 423, 427, 427);
      buffWorking[487] = this.Chksum(buffWorking, 489, 495, 487);
      buffWorking[488] = this.Chksum(buffWorking, 484, 488, 488);
      buffWorking[498] = this.Chksum(buffWorking, 500, 511, 498);
      buffWorking[499] = this.Chksum(buffWorking, 495, 499, 499);
      buffWorking[514] = this.Chksum(buffWorking, 516, 553, 514);
      buffWorking[515] = this.Chksum(buffWorking, 511, 515, 515);
      buffWorking[556] = this.Chksum(buffWorking, 558, 565, 556);
      buffWorking[557] = this.Chksum(buffWorking, 553, 557, 557);
    }

    public void SetElement1FRUBANDICOOT(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
      {
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr3 + index] = Convert.ToByte(clsUUT.scanMAC[2].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr4 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr5 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr6 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
      }
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[103] = this.Chksum(buffWorking, 8, 103, 103);
      buffWorking[183] = this.Chksum(buffWorking, 104, 183, 183);
      buffWorking[187] = this.Chksum(buffWorking, 189, 314, 187);
      buffWorking[188] = this.Chksum(buffWorking, 184, 188, 188);
      buffWorking[317] = this.Chksum(buffWorking, 319, 325, 317);
      buffWorking[318] = this.Chksum(buffWorking, 314, 318, 318);
      buffWorking[328] = this.Chksum(buffWorking, 330, 339, 328);
      buffWorking[329] = this.Chksum(buffWorking, 325, 329, 329);
      buffWorking[342] = this.Chksum(buffWorking, 344, 350, 342);
      buffWorking[343] = this.Chksum(buffWorking, 339, 343, 343);
      buffWorking[353] = this.Chksum(buffWorking, 355, 361, 353);
      buffWorking[354] = this.Chksum(buffWorking, 350, 354, 354);
      buffWorking[364] = this.Chksum(buffWorking, 366, 450, 364);
      buffWorking[365] = this.Chksum(buffWorking, 361, 365, 365);
      buffWorking[453] = this.Chksum(buffWorking, 455, 511, 453);
      buffWorking[454] = this.Chksum(buffWorking, 450, 454, 454);
      buffWorking[514] = this.Chksum(buffWorking, 516, 527, 514);
      buffWorking[515] = this.Chksum(buffWorking, 511, 515, 515);
      buffWorking[530] = this.Chksum(buffWorking, 532, 539, 530);
      buffWorking[531] = this.Chksum(buffWorking, 527, 531, 531);
    }

    public void SetElement1FRUBOBCAT(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
      {
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr3 + index] = Convert.ToByte(clsUUT.scanMAC[2].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr4 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr5 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr6 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
      }
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[95] = this.Chksum(buffWorking, 8, 95, 95);
      buffWorking[159] = this.Chksum(buffWorking, 96, 159, 159);
      buffWorking[163] = this.Chksum(buffWorking, 165, 290, 163);
      buffWorking[164] = this.Chksum(buffWorking, 160, 164, 164);
      buffWorking[293] = this.Chksum(buffWorking, 295, 301, 293);
      buffWorking[294] = this.Chksum(buffWorking, 290, 294, 294);
      buffWorking[304] = this.Chksum(buffWorking, 306, 315, 304);
      buffWorking[305] = this.Chksum(buffWorking, 301, 305, 305);
      buffWorking[318] = this.Chksum(buffWorking, 320, 326, 318);
      buffWorking[319] = this.Chksum(buffWorking, 315, 319, 319);
      buffWorking[329] = this.Chksum(buffWorking, 331, 415, 329);
      buffWorking[330] = this.Chksum(buffWorking, 326, 330, 330);
      buffWorking[418] = this.Chksum(buffWorking, 420, 476, 418);
      buffWorking[419] = this.Chksum(buffWorking, 415, 419, 419);
      buffWorking[479] = this.Chksum(buffWorking, 481, 487, 479);
      buffWorking[480] = this.Chksum(buffWorking, 476, 480, 480);
      buffWorking[490] = this.Chksum(buffWorking, 492, 503, 490);
      buffWorking[491] = this.Chksum(buffWorking, 487, 491, 491);
      buffWorking[506] = this.Chksum(buffWorking, 508, 545, 506);
      buffWorking[507] = this.Chksum(buffWorking, 503, 507, 507);
      buffWorking[548] = this.Chksum(buffWorking, 550, 557, 548);
      buffWorking[549] = this.Chksum(buffWorking, 545, 549, 549);
    }

    public void SetElement1FRUBOBOLINK(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
      {
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr3 + index] = Convert.ToByte(clsUUT.scanMAC[2].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr4 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr5 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr6 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
      }
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[95] = this.Chksum(buffWorking, 8, 95, 95);
      buffWorking[167] = this.Chksum(buffWorking, 96, 167, 167);
      buffWorking[171] = this.Chksum(buffWorking, 173, 298, 171);
      buffWorking[172] = this.Chksum(buffWorking, 168, 172, 172);
      buffWorking[301] = this.Chksum(buffWorking, 303, 309, 301);
      buffWorking[302] = this.Chksum(buffWorking, 298, 302, 302);
      buffWorking[312] = this.Chksum(buffWorking, 314, 323, 312);
      buffWorking[313] = this.Chksum(buffWorking, 309, 313, 313);
      buffWorking[326] = this.Chksum(buffWorking, 328, 334, 326);
      buffWorking[327] = this.Chksum(buffWorking, 323, 327, 327);
      buffWorking[337] = this.Chksum(buffWorking, 339, 423, 337);
      buffWorking[338] = this.Chksum(buffWorking, 334, 338, 338);
      buffWorking[426] = this.Chksum(buffWorking, 428, 434, 426);
      buffWorking[427] = this.Chksum(buffWorking, 423, 427, 427);
      buffWorking[437] = this.Chksum(buffWorking, 439, 495, 437);
      buffWorking[438] = this.Chksum(buffWorking, 434, 438, 438);
      buffWorking[498] = this.Chksum(buffWorking, 500, 511, 498);
      buffWorking[499] = this.Chksum(buffWorking, 495, 499, 499);
      buffWorking[514] = this.Chksum(buffWorking, 516, 523, 514);
      buffWorking[515] = this.Chksum(buffWorking, 511, 515, 515);
    }

    public void SetElement1FRUM150PM(byte[] buffWorking)
    {
      buffWorking[7] = this.ChksumFB(buffWorking, 0, 7, 7);
      buffWorking[111] = this.ChksumFB(buffWorking, 8, 111, 111);
      buffWorking[183] = this.ChksumFB(buffWorking, 112, 183, 183);
    }

    public void SetElement1FRUPAULI(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      int int32 = Convert.ToInt32(clsUUT.scanMAC[0].Substring(6, 6), 16);
      int num1 = int32 + 1;
      for (int index1 = 0; index1 < 8; ++index1)
      {
        ++num1;
        string str = clsUUT.scanMAC[0].Substring(0, 6) + num1.ToString("X6");
        for (int index2 = 0; index2 < 3; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr3 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 3; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr3 + (index1 * 20 + index2)] = Convert.ToByte(str.Substring(index2 * 2, 2), 16);
      }
      int num2 = int32;
      for (int index1 = 0; index1 < 18; ++index1)
      {
        string str = clsUUT.scanMAC[0].Substring(0, 6) + num2.ToString("X6");
        for (int index2 = 0; index2 < 3; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr4 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 3; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr4 + (index1 * 20 + index2)] = Convert.ToByte(str.Substring(index2 * 2, 2), 16);
        ++num2;
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
    }

    public void SetElement1FRUHERTZ(byte[] buffWorking)
    {
      int int16 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(10, 2), 16);
      for (int index1 = 0; index1 < 8; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      for (int index1 = 0; index1 < 16; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
    }

    public void SetElement1FRUGAUSS(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      int int32 = Convert.ToInt32(clsUUT.scanMAC[0].Substring(6, 6), 16);
      int num1 = int32 + 1;
      for (int index1 = 0; index1 < 8; ++index1)
      {
        ++num1;
        string str = clsUUT.scanMAC[0].Substring(0, 6) + num1.ToString("X6");
        for (int index2 = 0; index2 < 3; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr3 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 3; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr3 + (index1 * 20 + index2)] = Convert.ToByte(str.Substring(index2 * 2, 2), 16);
      }
      int num2 = int32;
      for (int index1 = 0; index1 < 18; ++index1)
      {
        string str = clsUUT.scanMAC[0].Substring(0, 6) + num2.ToString("X6");
        for (int index2 = 0; index2 < 3; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr4 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 3; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr4 + (index1 * 20 + index2)] = Convert.ToByte(str.Substring(index2 * 2, 2), 16);
        ++num2;
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
    }

    public void SetElement1FRUP225ED(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP225EDLP(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP225EPD(byte[] buffWorking)
    {
      int int16 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(10, 2), 16);
      for (int index1 = 0; index1 < 8; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      for (int index1 = 0; index1 < 16; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP225EPDLP(byte[] buffWorking)
    {
      int int16 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(10, 2), 16);
      for (int index1 = 0; index1 < 8; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      for (int index1 = 0; index1 < 16; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP210ED(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP210EDLP(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP210EPD(byte[] buffWorking)
    {
      int int16 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(10, 2), 16);
      for (int index1 = 0; index1 < 8; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      for (int index1 = 0; index1 < 16; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP210EPDLP(byte[] buffWorking)
    {
      int int16 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(10, 2), 16);
      for (int index1 = 0; index1 < 8; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      for (int index1 = 0; index1 < 16; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP210TED(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP210TEDLP(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
      for (int index = 0; index < 6; ++index)
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP210TEPD(byte[] buffWorking)
    {
      int int16 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(10, 2), 16);
      for (int index1 = 0; index1 < 8; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      for (int index1 = 0; index1 < 16; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUP210TEPDLP(byte[] buffWorking)
    {
      int int16 = (int) Convert.ToInt16(clsUUT.scanMAC[0].Substring(10, 2), 16);
      for (int index1 = 0; index1 < 8; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      for (int index1 = 0; index1 < 16; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index2 * 2, 2), 16);
        for (int index2 = 5; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr2 + (index1 * 20 + index2)] = Convert.ToByte(int16 + index1);
      }
      buffWorking[123] = this.Chksum(buffWorking, 120, 123, 123);
      buffWorking[259] = this.Chksum(buffWorking, 256, 259, 259);
      buffWorking[315] = (byte) 0;
      buffWorking[315] = this.Chksum(buffWorking, 312, 336, 315);
      buffWorking[339] = (byte) 0;
      buffWorking[339] = this.Chksum(buffWorking, 336, 360, 339);
      buffWorking[363] = (byte) 0;
      buffWorking[363] = this.Chksum(buffWorking, 360, 432, 363);
      buffWorking[435] = (byte) 0;
      buffWorking[435] = this.Chksum(buffWorking, 432, 464, 435);
    }

    public void SetElement1FRUM2004G(byte[] buffWorking)
    {
      for (int index1 = 0; index1 < soteDiag.soteDiag.mac_count; ++index1)
      {
        for (int index2 = 0; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[index1].Substring(index2 * 2, 2), 16);
      }
      buffWorking[123] = (byte) 0;
      buffWorking[123] = this.Chksum(buffWorking, 120, 124, 123);
      buffWorking[259] = (byte) 0;
      buffWorking[259] = this.Chksum(buffWorking, 256, 260, 259);
      buffWorking[355] = (byte) 0;
      buffWorking[355] = this.Chksum(buffWorking, 352, 376, 355);
      buffWorking[379] = (byte) 0;
      buffWorking[379] = this.Chksum(buffWorking, 376, 416, 379);
      buffWorking[419] = (byte) 0;
      buffWorking[419] = this.Chksum(buffWorking, 416, 464, 419);
      buffWorking[467] = (byte) 0;
      buffWorking[467] = this.Chksum(buffWorking, 464, 512, 467);
    }

    public void SetElement1FRUN2004(byte[] buffWorking)
    {
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[79] = this.Chksum(buffWorking, 8, 79, 79);
      buffWorking[231] = this.Chksum(buffWorking, 80, 231, 231);
      buffWorking[235] = this.Chksum(buffWorking, 237, 365, 235);
      buffWorking[236] = this.Chksum(buffWorking, 232, 236, 236);
      buffWorking[368] = this.Chksum(buffWorking, 370, 395, 368);
      buffWorking[369] = this.Chksum(buffWorking, 365, 369, 369);
      buffWorking[398] = this.Chksum(buffWorking, 400, 415, 398);
      buffWorking[399] = this.Chksum(buffWorking, 395, 399, 399);
      buffWorking[418] = this.Chksum(buffWorking, 420, 430, 418);
      buffWorking[419] = this.Chksum(buffWorking, 415, 419, 419);
    }

    public void SetElement1FRUAD2000DC(byte[] buffWorking)
    {
      for (int index1 = 0; index1 < soteDiag.soteDiag.mac_count; ++index1)
      {
        for (int index2 = 0; index2 < 6; ++index2)
          buffWorking[soteDiag.soteDiag.mac_addr1 + (index1 * 20 + index2)] = Convert.ToByte(clsUUT.scanMAC[index1].Substring(index2 * 2, 2), 16);
      }
    }

    public void SetElement1FRUA1913G(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
      {
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr3 + index] = Convert.ToByte(clsUUT.scanMAC[2].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr4 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
      }
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[103] = this.Chksum(buffWorking, 8, 103, 103);
      buffWorking[183] = this.Chksum(buffWorking, 104, 183, 183);
      buffWorking[187] = this.Chksum(buffWorking, 189, 390, 187);
      buffWorking[188] = this.Chksum(buffWorking, 184, 188, 188);
      buffWorking[393] = this.Chksum(buffWorking, 395, 401, 393);
      buffWorking[394] = this.Chksum(buffWorking, 390, 394, 394);
      buffWorking[404] = this.Chksum(buffWorking, 406, 415, 404);
      buffWorking[405] = this.Chksum(buffWorking, 401, 405, 405);
      buffWorking[418] = this.Chksum(buffWorking, 420, 426, 418);
      buffWorking[419] = this.Chksum(buffWorking, 415, 419, 419);
      buffWorking[429] = this.Chksum(buffWorking, 431, 439, 429);
      buffWorking[430] = this.Chksum(buffWorking, 426, 430, 430);
      buffWorking[442] = this.Chksum(buffWorking, 444, 528, 442);
      buffWorking[443] = this.Chksum(buffWorking, 439, 443, 443);
      buffWorking[531] = this.Chksum(buffWorking, 533, 540, 531);
      buffWorking[532] = this.Chksum(buffWorking, 528, 532, 532);
    }

    public void SetElement1FRUA1904GH(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
      {
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr3 + index] = Convert.ToByte(clsUUT.scanMAC[2].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr4 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
      }
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[103] = this.Chksum(buffWorking, 8, 103, 103);
      buffWorking[175] = this.Chksum(buffWorking, 104, 175, 175);
      buffWorking[179] = this.Chksum(buffWorking, 181, 382, 179);
      buffWorking[180] = this.Chksum(buffWorking, 176, 180, 180);
      buffWorking[385] = this.Chksum(buffWorking, 387, 393, 385);
      buffWorking[386] = this.Chksum(buffWorking, 382, 386, 386);
      buffWorking[396] = this.Chksum(buffWorking, 398, 407, 396);
      buffWorking[397] = this.Chksum(buffWorking, 393, 397, 397);
      buffWorking[410] = this.Chksum(buffWorking, 412, 420, 410);
      buffWorking[411] = this.Chksum(buffWorking, 407, 411, 411);
      buffWorking[423] = this.Chksum(buffWorking, 425, 509, 423);
      buffWorking[424] = this.Chksum(buffWorking, 420, 424, 424);
      buffWorking[512] = this.Chksum(buffWorking, 514, 521, 512);
      buffWorking[513] = this.Chksum(buffWorking, 509, 513, 513);
    }

    public void SetElement1FRUBUBBLES(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
      {
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr3 + index] = Convert.ToByte(clsUUT.scanMAC[2].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr4 + index] = Convert.ToByte(clsUUT.scanMAC[3].Substring(index * 2, 2), 16);
        buffWorking[225] = Convert.ToByte(clsUUT.scanMAC[0].Substring(4, 2), 16);
        buffWorking[226] = Convert.ToByte(clsUUT.scanMAC[0].Substring(6, 2), 16);
        buffWorking[227] = Convert.ToByte(clsUUT.scanMAC[0].Substring(8, 2), 16);
        buffWorking[228] = Convert.ToByte(clsUUT.scanMAC[0].Substring(10, 2), 16);
      }
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[103] = this.Chksum(buffWorking, 8, 103, 103);
      buffWorking[175] = this.Chksum(buffWorking, 104, 175, 175);
      buffWorking[179] = this.Chksum(buffWorking, 181, 229, 179);
      buffWorking[180] = this.Chksum(buffWorking, 176, 180, 180);
      buffWorking[232] = this.Chksum(buffWorking, 234, 435, 232);
      buffWorking[233] = this.Chksum(buffWorking, 229, 233, 233);
      buffWorking[438] = this.Chksum(buffWorking, 440, 446, 438);
      buffWorking[439] = this.Chksum(buffWorking, 435, 439, 439);
      buffWorking[449] = this.Chksum(buffWorking, 451, 460, 449);
      buffWorking[450] = this.Chksum(buffWorking, 446, 450, 450);
      buffWorking[463] = this.Chksum(buffWorking, 465, 473, 463);
      buffWorking[464] = this.Chksum(buffWorking, 460, 464, 464);
      buffWorking[476] = this.Chksum(buffWorking, 478, 562, 476);
      buffWorking[477] = this.Chksum(buffWorking, 473, 477, 477);
      buffWorking[565] = this.Chksum(buffWorking, 567, 573, 565);
      buffWorking[566] = this.Chksum(buffWorking, 562, 566, 566);
      buffWorking[576] = this.Chksum(buffWorking, 578, 585, 576);
      buffWorking[577] = this.Chksum(buffWorking, 573, 577, 577);
    }

    public void SetElement1FRUCASPIAN(byte[] buffWorking)
    {
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[239] = this.Chksum(buffWorking, 8, 239, 239);
      buffWorking[367] = this.Chksum(buffWorking, 240, 367, 367);
      buffWorking[371] = this.Chksum(buffWorking, 373, 421, 371);
      buffWorking[372] = this.Chksum(buffWorking, 368, 372, 372);
    }

    public void SetElement1FRUARAL(byte[] buffWorking)
    {
      buffWorking[441] = Convert.ToByte(clsUUT.scanMAC[0].Substring(4, 2), 16);
      buffWorking[442] = Convert.ToByte(clsUUT.scanMAC[0].Substring(6, 2), 16);
      buffWorking[443] = Convert.ToByte(clsUUT.scanMAC[0].Substring(8, 2), 16);
      buffWorking[444] = Convert.ToByte(clsUUT.scanMAC[0].Substring(10, 2), 16);
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[247] = this.Chksum(buffWorking, 8, 247, 247);
      buffWorking[391] = this.Chksum(buffWorking, 248, 391, 391);
      buffWorking[395] = this.Chksum(buffWorking, 397, 461, 395);
      buffWorking[396] = this.Chksum(buffWorking, 392, 396, 396);
    }

    public void SetElement1FRUA2003GH(byte[] buffWorking)
    {
      for (int index = 0; index < 6; ++index)
      {
        buffWorking[soteDiag.soteDiag.mac_addr1 + index] = Convert.ToByte(clsUUT.scanMAC[0].Substring(index * 2, 2), 16);
        buffWorking[soteDiag.soteDiag.mac_addr2 + index] = Convert.ToByte(clsUUT.scanMAC[1].Substring(index * 2, 2), 16);
      }
      buffWorking[7] = this.Chksum(buffWorking, 0, 7, 7);
      buffWorking[103] = this.Chksum(buffWorking, 8, 103, 103);
      buffWorking[175] = this.Chksum(buffWorking, 104, 175, 175);
      buffWorking[179] = this.Chksum(buffWorking, 181, 306, 179);
      buffWorking[180] = this.Chksum(buffWorking, 176, 180, 180);
      buffWorking[309] = this.Chksum(buffWorking, 311, 317, 309);
      buffWorking[310] = this.Chksum(buffWorking, 306, 310, 310);
      buffWorking[320] = this.Chksum(buffWorking, 322, 331, 320);
      buffWorking[321] = this.Chksum(buffWorking, 317, 321, 321);
      buffWorking[334] = this.Chksum(buffWorking, 336, 342, 334);
      buffWorking[335] = this.Chksum(buffWorking, 331, 335, 335);
      buffWorking[345] = this.Chksum(buffWorking, 347, 431, 345);
      buffWorking[346] = this.Chksum(buffWorking, 342, 346, 346);
      buffWorking[434] = this.Chksum(buffWorking, 436, 443, 434);
      buffWorking[435] = this.Chksum(buffWorking, 431, 435, 435);
    }

    public void loadI2CSettings(string hw_type)
    {
      switch (hw_type)
      {
        case "BOERNE":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C64";
          soteDiag.soteDiag.method = "EERPOM2AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 32;
          soteDiag.soteDiag.deviceMemorySize = 8192;
          break;
        case "PUTNAM":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C64";
          soteDiag.soteDiag.method = "EERPOM2AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 32;
          soteDiag.soteDiag.deviceMemorySize = 8192;
          break;
        case "BUBBLES":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "CASPIAN":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 421;
          break;
        case "ARAL":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 461;
          break;
        case "WOODVILLE":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C64";
          soteDiag.soteDiag.method = "EERPOM2AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 32;
          soteDiag.soteDiag.deviceMemorySize = 8192;
          break;
        case "CARDASSIA":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "CORAK":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "BASHIR":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "BOAR":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C32";
          soteDiag.soteDiag.method = "EERPOM2AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 32;
          soteDiag.soteDiag.deviceMemorySize = 1024;
          break;
        case "BANDICOOT":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C32";
          soteDiag.soteDiag.method = "EERPOM2AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 32;
          soteDiag.soteDiag.deviceMemorySize = 1024;
          break;
        case "BOBCAT":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C32";
          soteDiag.soteDiag.method = "EERPOM2AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 32;
          soteDiag.soteDiag.deviceMemorySize = 1024;
          break;
        case "BOBOLINK":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C32";
          soteDiag.soteDiag.method = "EERPOM2AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 32;
          soteDiag.soteDiag.deviceMemorySize = 1024;
          break;
        case "PAULI":
        case "HERTZ":
        case "GAUSS":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "P225ED":
        case "P225EPD":
        case "P225EDLP":
        case "P225EPDLP":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "P210ED":
        case "P210EPD":
        case "P210EDLP":
        case "P210EPDLP":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "P210TED":
        case "P210TEPD":
        case "P210TEDLP":
        case "P210TEPDLP":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "GAMMA":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "N2004":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "OBRIEN":
          soteDiag.soteDiag.i2cDevice = "Atmel ATTINY84";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 4096;
          break;
        case "MUSTANG":
        case "M4161":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C32";
          soteDiag.soteDiag.method = "EERPOM2AddWord";
          soteDiag.soteDiag.i2cAddress = "A0";
          soteDiag.soteDiag.pageSize = 64;
          soteDiag.soteDiag.deviceMemorySize = 1024;
          break;
        case "M150PM":
          soteDiag.soteDiag.i2cDevice = "Atmel AT24C04";
          soteDiag.soteDiag.method = "EERPOM1AddWord";
          soteDiag.soteDiag.i2cAddress = "A2";
          soteDiag.soteDiag.pageSize = 16;
          soteDiag.soteDiag.deviceMemorySize = 256;
          break;
      }
    }

    public bool loadBinary(string fileName)
    {
      string path = fileName;
      if (File.Exists(path))
      {
        byte[] numArray1 = FileUtil.ReadBinaryFile(path);
        switch (clsUUT.hw_type)
        {
          case "CORAK":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 30);
            int expectedChksum1 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUA1905GD(numArray1);
            this.SetElement1FRUA1905GD(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum1);
            break;
          case "CARDASSIA":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 32);
            int expectedChksum2 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUA1904GD(numArray1);
            this.SetElement1FRUA1904GD(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum2);
            break;
          case "BASHIR":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 108);
            int expectedChksum3 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUA2003GD(numArray1);
            this.SetElement1FRUA2003GD(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum3);
            break;
          case "BOAR":
            soteDiag.soteDiag.VerifyFilesize(fileName, 566L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 566), 222);
            this.SetBoardInfoAreaFRUBOAR(numArray1);
            this.SetElement1FRUBOAR(numArray1);
            break;
          case "BANDICOOT":
            soteDiag.soteDiag.VerifyFilesize(fileName, 540L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 540), 67);
            this.SetBoardInfoAreaFRUBANDICOOT(numArray1);
            this.SetElement1FRUBANDICOOT(numArray1);
            break;
          case "BOBCAT":
            soteDiag.soteDiag.VerifyFilesize(fileName, 558L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 558), 138);
            this.SetBoardInfoAreaFRUBOBCAT(numArray1);
            this.SetElement1FRUBOBCAT(numArray1);
            break;
          case "BOBOLINK":
            soteDiag.soteDiag.VerifyFilesize(fileName, 524L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 524), 172);
            this.SetBoardInfoAreaFRUBOBOLINK(numArray1);
            this.SetElement1FRUBOBOLINK(numArray1);
            break;
          case "PAULI":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 247);
            int expectedChksum4 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUPAULI(numArray1);
            this.SetElement1FRUPAULI(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum4);
            break;
          case "HERTZ":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 10);
            int expectedChksum5 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUHERTZ(numArray1);
            this.SetElement1FRUHERTZ(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum5);
            break;
          case "GAUSS":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 247);
            int expectedChksum6 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUGAUSS(numArray1);
            this.SetElement1FRUGAUSS(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum6);
            break;
          case "P225ED":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 78);
            int expectedChksum7 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP225ED(numArray1);
            this.SetElement1FRUP225ED(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum7);
            break;
          case "P225EDLP":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 78);
            int expectedChksum8 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP225EDLP(numArray1);
            this.SetElement1FRUP225EDLP(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum8);
            break;
          case "P225EPD":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 34);
            int expectedChksum9 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP225EPD(numArray1);
            this.SetElement1FRUP225EPD(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum9);
            break;
          case "P225EPDLP":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 34);
            int expectedChksum10 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP225EPDLP(numArray1);
            this.SetElement1FRUP225EPDLP(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum10);
            break;
          case "P210ED":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 78);
            int expectedChksum11 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP210ED(numArray1);
            this.SetElement1FRUP210ED(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum11);
            break;
          case "P210EDLP":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 78);
            int expectedChksum12 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP210EDLP(numArray1);
            this.SetElement1FRUP210EDLP(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum12);
            break;
          case "P210EPD":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 34);
            int expectedChksum13 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP210EPD(numArray1);
            this.SetElement1FRUP210EPD(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum13);
            break;
          case "P210EPDLP":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 34);
            int expectedChksum14 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP210EPDLP(numArray1);
            this.SetElement1FRUP210EPDLP(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum14);
            break;
          case "P210TED":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 78);
            int expectedChksum15 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP210TED(numArray1);
            this.SetElement1FRUP210TED(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum15);
            break;
          case "P210TEDLP":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 78);
            int expectedChksum16 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP210TEDLP(numArray1);
            this.SetElement1FRUP210TEDLP(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum16);
            break;
          case "P210TEPD":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 34);
            int expectedChksum17 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP210TEPD(numArray1);
            this.SetElement1FRUP210TEPD(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum17);
            break;
          case "P210TEPDLP":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 34);
            int expectedChksum18 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUP210TEPDLP(numArray1);
            this.SetElement1FRUP210TEPDLP(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum18);
            break;
          case "GAMMA":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 207);
            int expectedChksum19 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUM2004G(numArray1);
            this.SetElement1FRUM2004G(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum19);
            break;
          case "N2004":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 119);
            int expectedChksum20 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUN2004(numArray1);
            this.SetElement1FRUN2004(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum20);
            break;
          case "OBRIEN":
            soteDiag.soteDiag.VerifyFilesize(fileName, 4096L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 4096), 32);
            int expectedChksum21 = (int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type);
            this.SetBoardInfoAreaFRUAD2000DC(numArray1);
            this.SetElement1FRUAD2000DC(numArray1);
            soteDiag.soteDiag.VerifyProgrammedChksum((int) soteDiag.soteDiag.ChksumVerification(numArray1, clsUUT.hw_type), expectedChksum21);
            break;
          case "BOERNE":
            soteDiag.soteDiag.VerifyFilesize(fileName, 541L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 541), 188);
            soteDiag.soteDiag.SetBoardInfoAreaFRUA1913G(numArray1);
            this.SetElement1FRUA1913G(numArray1);
            break;
          case "PUTNAM":
            soteDiag.soteDiag.VerifyFilesize(fileName, 1028L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 1028), 249);
            soteDiag.soteDiag.SetBoardInfoAreaFRUA1904GH(numArray1);
            this.SetElement1FRUA1904GH(numArray1);
            break;
          case "BUBBLES":
            soteDiag.soteDiag.VerifyFilesize(fileName, 586L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 586), 106);
            soteDiag.soteDiag.SetBoardInfoAreaFRUBUBBLES(numArray1);
            this.SetElement1FRUBUBBLES(numArray1);
            break;
          case "CASPIAN":
            soteDiag.soteDiag.VerifyFilesize(fileName, 421L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 421), 240);
            soteDiag.soteDiag.SetBoardInfoAreaFRUCASPIAN(numArray1);
            this.SetElement1FRUCASPIAN(numArray1);
            break;
          case "ARAL":
            soteDiag.soteDiag.VerifyFilesize(fileName, 461L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 461), 17);
            soteDiag.soteDiag.SetBoardInfoAreaFRUARAL(numArray1);
            this.SetElement1FRUARAL(numArray1);
            break;
          case "WOODVILLE":
            soteDiag.soteDiag.VerifyFilesize(fileName, 512L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 512), 195);
            soteDiag.soteDiag.SetBoardInfoAreaFRUA2003GH(numArray1);
            this.SetElement1FRUA2003GH(numArray1);
            break;
          case "MUSTANG":
            soteDiag.soteDiag.VerifyFilesize(fileName, 65536L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 65536), 24);
            soteDiag.soteDiag.SetBoardInfoAreaVPDMustang(numArray1);
            soteDiag.soteDiag.SetVPDbufMustang(numArray1);
            soteDiag.soteDiag.SetUUIDbuf(numArray1);
            break;
          case "M4161":
            soteDiag.soteDiag.VerifyFilesize(fileName, 1024L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 1024), 172);
            soteDiag.soteDiag.SetBoardInfoAreaVPDM4161(numArray1);
            soteDiag.soteDiag.SetVPDbufM4161(numArray1);
            soteDiag.soteDiag.SetUUIDbuf(numArray1);
            break;
          case "M150PM":
            soteDiag.soteDiag.VerifyFilesize(fileName, 256L);
            soteDiag.soteDiag.VerifyChksum((int) this.ChksumTemplate(numArray1, 0, 256), 176);
            this.SetBoardInfoAreaFRUM150PM(numArray1);
            this.SetElement1FRUM150PM(numArray1);
            break;
          default:
            soteDiag.soteDiag.showFailMsgDlg("loadBinary: Unrecognized Hardware Type");
            return false;
        }
        if (numArray1 != null)
        {
          int length = numArray1.Length;
          if (length != soteDiag.soteDiag.deviceMemorySize)
          {
            byte[] numArray2 = new byte[soteDiag.soteDiag.deviceMemorySize];
            if (length > soteDiag.soteDiag.deviceMemorySize)
            {
              for (int index = 0; index < soteDiag.soteDiag.deviceMemorySize; ++index)
                numArray2[index] = numArray1[index];
            }
            else if (length < soteDiag.soteDiag.deviceMemorySize)
            {
              numArray1.CopyTo((Array) numArray2, 0);
              for (int index = length; index < soteDiag.soteDiag.deviceMemorySize; ++index)
                numArray2[index] = Convert.ToByte(soteDiag.soteDiag.padText, 16);
            }
            numArray1 = numArray2;
          }
          this.fruWriteBuffer = ArrayUtil.SubsetArray(numArray1, 0, soteDiag.soteDiag.deviceMemorySize);
          return true;
        }
        soteDiag.soteDiag.showFailMsgDlg("loadBinary:\nInvalid Memory Buffer Size!");
        return false;
      }
      soteDiag.soteDiag.showFailMsgDlg("loadBinary:\nFailed to load FRU BIN template!");
      return false;
    }

    public bool generateMACfile(string hw_type)
    {
      if (this.m_TestMode == 5 && !this.m_bFCTEnabled || this.m_TestMode == 8 && !this.m_bRMAProgramNVRAM)
        return true;
      switch (hw_type)
      {
        case "PAULI":
        case "GAUSS":
        case "GAMMA":
        case "N2004":
        case "OBRIEN":
        case "CARDASSIA":
        case "BASHIR":
        case "CORAK":
        case "N1905":
        case "PUTNAM":
        case "BUBBLES":
        case "CASPIAN":
        case "ARAL":
        case "WOODVILLE":
        case "BOERNE":
        case "MERCURY":
        case "PLUTO":
        case "SHARKNADO2":
        case "SHARKNADO4":
          return true;
        default:
          this.m_commport.Write("echo mac_addr_pref = " + this.m_MAC[0].Substring(0, 6) + " > MACID.txt \r\n");
          Thread.Sleep(500);
          this.m_commport.Write("echo mac_addr_start = " + this.m_MAC[0].Substring(6, 6) + " >> MACID.txt \r\n");
          Thread.Sleep(500);
          int int32_1;
          if (this.m_esr_bNPAR && this.m_TestMode == 10)
          {
            int32_1 = Convert.ToInt32(Convert.ToInt32(this.m_MAC[0].Substring(this.m_MAC[0].Length - 6, 6), 16) + 16);
            this.m_commport.Write("echo mac_addr_end = " + int32_1.ToString("X6") + " >> MACID.txt \r\n");
            Thread.Sleep(500);
          }
          else if (clsUUT.bCdiag && !clsUUT.bNPAR || clsUUT.bCdiagB57diag)
          {
            int32_1 = Convert.ToInt32(Convert.ToInt32(this.m_MAC[0].Substring(this.m_MAC[0].Length - 6, 6), 16) + 2);
            this.m_commport.Write("echo mac_addr_end = " + int32_1.ToString("X6") + " >> MACID.txt \r\n");
            Thread.Sleep(500);
          }
          else if (clsUUT.bCdiag && clsUUT.bNPAR && !clsUUT.bCdiagB57diag)
          {
            int32_1 = Convert.ToInt32(Convert.ToInt32(this.m_MAC[0].Substring(this.m_MAC[0].Length - 6, 6), 16) + 16);
            this.m_commport.Write("echo mac_addr_end = " + int32_1.ToString("X6") + " >> MACID.txt \r\n");
            Thread.Sleep(500);
          }
          else
          {
            this.m_commport.Write("echo mac_addr_end = " + this.m_MAC[3].Substring(6, 6) + " >> MACID.txt \r\n");
            Thread.Sleep(500);
          }
          if (clsUUT.bCdiagB57diag && !clsUUT.bNPAR)
          {
            int int32_2 = Convert.ToInt32(this.m_MAC[0].Substring(this.m_MAC[0].Length - 6, 6), 16);
            this.m_commport.Write("echo mac_addr_pref = " + this.m_MAC[0].Substring(0, 6) + " > MACID2.txt \r\n");
            Thread.Sleep(500);
            int32_1 = Convert.ToInt32(int32_2 + 2);
            this.m_commport.Write("echo mac_addr_start = " + int32_1.ToString("X6") + " >> MACID2.txt \r\n");
            Thread.Sleep(500);
            int32_1 = Convert.ToInt32(int32_2 + 4);
            this.m_commport.Write("echo mac_addr_end = " + int32_1.ToString("X6") + " >> MACID2.txt \r\n");
            Thread.Sleep(500);
          }
          else if (clsUUT.bCdiagB57diag && clsUUT.bNPAR)
          {
            int int32_2 = Convert.ToInt32(this.m_MAC[0].Substring(this.m_MAC[0].Length - 6, 6), 16);
            this.m_commport.Write("echo mac_addr_pref = " + this.m_MAC[0].Substring(0, 6) + " > MACID2.txt \r\n");
            Thread.Sleep(500);
            int32_1 = Convert.ToInt32(int32_2 + 2);
            this.m_commport.Write("echo mac_addr_start = " + int32_1.ToString("X6") + " >> MACID2.txt \r\n");
            Thread.Sleep(500);
            int32_1 = Convert.ToInt32(int32_2 + 18);
            this.m_commport.Write("echo mac_addr_end = " + int32_1.ToString("X6") + " >> MACID2.txt \r\n");
            Thread.Sleep(500);
          }
          return true;
      }
    }

    public bool generateSerialNumberfile(string hw_type)
    {
      if (this.m_TestMode == 2 || this.m_TestMode == 5 && !this.m_bFCTEnabled || this.m_TestMode == 5 && !this.m_bRMAProgramNVRAM)
        return true;
      switch (hw_type)
      {
        case "GAMMA":
        case "N2004":
        case "OBRIEN":
        case "CARDASSIA":
        case "BASHIR":
        case "CORAK":
        case "N1905":
        case "MERCURY":
        case "PLUTO":
        case "P150C":
        case "P125C":
        case "P225C":
        case "P225CA":
        case "P225CO":
        case "P150P":
        case "P225P":
        case "M225P":
        case "M125P":
        case "M210P":
        case "P210P":
        case "P210C":
        case "P225E":
        case "PAULI":
        case "HERTZ":
        case "GAUSS":
        case "P225ED":
        case "P225EPD":
        case "P210ED":
        case "P210EPD":
        case "P210TED":
        case "P210TEPD":
        case "P225EDLP":
        case "P225EPDLP":
        case "P210EDLP":
        case "P210EPDLP":
        case "P210TEDLP":
        case "P210TEPDLP":
        case "M150C":
        case "M150PM":
        case "M1100PM":
        case "M150P":
        case "M210TP":
        case "M225PQ":
        case "PS150":
        case "MS150":
        case "P1100P":
        case "M225C":
        case "M225CD":
        case "M225PD":
        case "M210C":
        case "M125C":
        case "M125CP":
        case "M125CLP":
        case "M125CHF":
        case "M125CLPHF":
        case "P210TE":
        case "P210TEP":
          return true;
        case "PUTNAM":
        case "BUBBLES":
        case "WOODVILLE":
        case "BOERNE":
        case "BOAR":
        case "BANDICOOT":
        case "BOBCAT":
        case "BOBOLINK":
          this.SendSerialPortCommand("echo serial_number = " + clsUUT.scanLabel.Substring(14, 10) + " > SN.txt \r\n");
          break;
        case "CASPIAN":
        case "ARAL":
        case "A4160L":
        case "M4161":
        case "A3120L":
        case "SHARKNADO2":
        case "SHARKNADO4":
          this.SendSerialPortCommand("echo serial_number = " + clsUUT.scanLabel + " > SN2.txt \r\n");
          break;
        case "P225PO":
          this.SendSerialPortCommand("echo serial_number = " + clsUUT.scanLabel + " > SN3.txt \r\n");
          break;
      }
      return true;
    }

    public bool runFCTtest(string hw_type)
    {
      string txtCommandLine = "";
      string str1 = "DIAG.txt";
      string str2 = "DIAG.txt";
      string str3 = "DIAG.txt";
      string str4 = "DIAG.txt";
      bool flag1 = false;
      if (this.m_TestMode == 5 && !this.m_bFCTEnabled || this.m_TestMode == 8 && !this.m_bRMAFCT && !this.m_bRMAProgramNVRAM)
        return true;
      switch (hw_type)
      {
        case "CORAK":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("A1905G {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "N1905":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("N1905 {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "CARDASSIA":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("A1904GD {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "SHARKNADO4":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("SHARK4 {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "SHARKNADO2":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("SHARK2 {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "BASHIR":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("A2003GD {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "GAUSS":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("GAUSS {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "PAULI":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("PAULI {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "BOERNE":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("A1913G {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "PUTNAM":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("A1904GH {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "BUBBLES":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
            txtCommandLine = string.Format("BUBBLES {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 2)
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 5)
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
          this.SendSerialPortCommand(txtCommandLine);
          this.cbStatusColor(Color.Green);
          if (this.m_TestMode == 2)
            this.cbStatusText("...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...");
          else if (this.m_TestMode == 8)
            this.cbStatusText("...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...");
          else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
            this.cbStatusText("...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...");
          else if (this.m_TestMode != 5 || this.m_bFCTEnabled || (this.m_TestMode != 8 || !this.m_bRMAFCT || !this.m_bRMAProgramNVRAM))
            this.cbStatusText("...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...");
          while (!this.m_userabort)
          {
            if (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result ="))
            {
              Thread.Sleep(1000);
              break;
            }
            if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
            {
              this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
              this.m_iFCTErrorCode = 300;
              frmFail frmFail = new frmFail();
              string str5 = "\nFailed to program the NVRAM!\n\nClose the app and reboot DOS PC!";
              soteDiag.soteDiag soteDiag = this;
              soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str5;
              this.m_results += "\r\nNo more retrying programming the NVRAM!\r\n";
              frmFail.Message = str5;
              int num = (int) frmFail.ShowDialog();
              this.RaiseUserAbortEvent();
            }
          }
          this.m_bFCTTestStarted = true;
          return true;
        case "CASPIAN":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
            txtCommandLine = string.Format("CASPIAN {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 2)
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 5)
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
          this.SendSerialPortCommand(txtCommandLine);
          this.cbStatusColor(Color.Green);
          if (this.m_TestMode == 2)
            this.cbStatusText("...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...");
          else if (this.m_TestMode == 8)
            this.cbStatusText("...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...");
          else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
            this.cbStatusText("...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...");
          else if (this.m_TestMode != 5 || this.m_bFCTEnabled || (this.m_TestMode != 8 || !this.m_bRMAFCT || !this.m_bRMAProgramNVRAM))
            this.cbStatusText("...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...");
          while (!this.m_userabort)
          {
            if (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result ="))
            {
              Thread.Sleep(1000);
              break;
            }
            if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
            {
              this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
              this.m_iFCTErrorCode = 300;
              frmFail frmFail = new frmFail();
              string str5 = "\nFailed to program the NVRAM!\n\nClose the app and reboot DOS PC!";
              soteDiag.soteDiag soteDiag = this;
              soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str5;
              this.m_results += "\r\nNo more retrying programming the NVRAM!\r\n";
              frmFail.Message = str5;
              int num = (int) frmFail.ShowDialog();
              this.RaiseUserAbortEvent();
            }
          }
          this.m_bFCTTestStarted = true;
          return true;
        case "ARAL":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
            txtCommandLine = string.Format("ARAL {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 2)
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 5)
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
          this.SendSerialPortCommand(txtCommandLine);
          this.cbStatusColor(Color.Green);
          if (this.m_TestMode == 2)
            this.cbStatusText("...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...");
          else if (this.m_TestMode == 8)
            this.cbStatusText("...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...");
          else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
            this.cbStatusText("...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...");
          else if (this.m_TestMode != 5 || this.m_bFCTEnabled || (this.m_TestMode != 8 || !this.m_bRMAFCT || !this.m_bRMAProgramNVRAM))
            this.cbStatusText("...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...");
          while (!this.m_userabort)
          {
            if (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result ="))
            {
              Thread.Sleep(1000);
              break;
            }
            if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
            {
              this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
              this.m_iFCTErrorCode = 300;
              frmFail frmFail = new frmFail();
              string str5 = "\nFailed to program the NVRAM!\n\nClose the app and reboot DOS PC!";
              soteDiag.soteDiag soteDiag = this;
              soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str5;
              this.m_results += "\r\nNo more retrying programming the NVRAM!\r\n";
              frmFail.Message = str5;
              int num = (int) frmFail.ShowDialog();
              this.RaiseUserAbortEvent();
            }
          }
          this.m_bFCTTestStarted = true;
          return true;
        case "WOODVILLE":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("A2003G {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "MERCURY":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("A1904AC {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "PLUTO":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("A2003AC {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "P150C":
        case "BOAR":
        case "BANDICOOT":
        case "BOBCAT":
        case "BOBOLINK":
        case "P210TE":
        case "P210TEP":
        case "P125C":
        case "P225C":
        case "P225CA":
        case "P225CO":
        case "P225PO":
        case "P150P":
        case "P225P":
        case "M225P":
        case "M125P":
        case "M210P":
        case "P210P":
        case "P210C":
        case "HERTZ":
        case "P210ED":
        case "P210EPD":
        case "P210TED":
        case "P210TEPD":
        case "P225ED":
        case "P225EPD":
        case "P210EDLP":
        case "P210EPDLP":
        case "P210TEDLP":
        case "P210TEPDLP":
        case "P225EDLP":
        case "P225EPDLP":
        case "A3120L":
        case "A4160L":
        case "M4161":
        case "P225E":
        case "M150C":
        case "M150PM":
        case "M1100PM":
        case "M150P":
        case "M210TP":
        case "M225PQ":
        case "PS150":
        case "MS150":
        case "P1100P":
        case "M125CP":
        case "M125CLP":
        case "M125CHF":
        case "M125CLPHF":
        case "M225C":
        case "M225CD":
        case "M225PD":
        case "M210C":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            if (!flag1)
            {
              int num1 = 0;
              bool flag2 = false;
              while (num1 < 3 && !flag2)
              {
                this.SendSerialPortCommand(string.Format("FCTPRG {0}\r\n", (object) str1));
                ++num1;
                this.cbStatusColor(Color.Green);
                this.cbStatusText("...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...");
                while (!this.m_userabort)
                {
                  if (this.m_results.Contains("FCT NVRAM program completed") && this.m_results.Contains("Result ="))
                  {
                    Thread.Sleep(1000);
                    break;
                  }
                  if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                  {
                    this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                    this.m_iFCTErrorCode = 300;
                    if (num1 < 3)
                    {
                      this.m_results += "\r\n\nFAIL: Failed to program the NVRAM! No ACK from the DUT!";
                      this.m_results += "\r\nRetry programming the NVRAM again!\r\n";
                      break;
                    }
                    frmFail frmFail = new frmFail();
                    string str5 = "\nFailed to program the NVRAM!\n\nClose the app and reboot DOS PC!";
                    soteDiag.soteDiag soteDiag = this;
                    soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str5;
                    this.m_results += "\r\nNo more retrying programming the NVRAM!\r\n";
                    frmFail.Message = str5;
                    int num2 = (int) frmFail.ShowDialog();
                    this.RaiseUserAbortEvent();
                  }
                }
                if (this.m_results.Contains("Errorcode = 56") || this.m_results.Contains("Errorcode = 57") || this.m_iFCTErrorCode == 300)
                {
                  if (num1 < 3)
                  {
                    soteUtils.log2file(this.m_traceLog, this.m_results);
                    this.m_results = "";
                    this.generateMACfile(clsUUT.hw_type);
                    Thread.Sleep(2000);
                    this.m_bRetry = true;
                    this.rebootDOSPC();
                  }
                }
                else
                  flag2 = true;
              }
            }
            if (this.m_results.Contains("Result = PASS") && !this.m_results.Contains("Result = FAIL"))
            {
              soteUtils.log2file(this.m_traceLog, this.m_results);
              this.m_results = "";
              this.rebootDOSPC();
              this.SendSerialPortCommand(string.Format("FCTTEST {0}\r\n", (object) str1));
              this.cbStatusColor(Color.Green);
              this.cbStatusText("...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...");
              while (!this.m_userabort)
              {
                if (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result ="))
                {
                  Thread.Sleep(1000);
                  break;
                }
                if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                {
                  this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                  this.m_iFCTErrorCode = 300;
                  frmFail frmFail = new frmFail();
                  string str5 = "\nFailed to program the NVRAM!\n\nClose the app and reboot DOS PC!";
                  soteDiag.soteDiag soteDiag = this;
                  soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str5;
                  this.m_results += "\r\nNo more retrying programming the NVRAM!\r\n";
                  frmFail.Message = str5;
                  int num = (int) frmFail.ShowDialog();
                  this.RaiseUserAbortEvent();
                }
              }
              if (this.m_results.Contains("Errorcode = 40"))
              {
                soteUtils.log2file(this.m_traceLog, this.m_results);
                this.m_results = "";
                this.rebootDOSPC();
                txtCommandLine = string.Format("FCTTEST {0}\r\n", (object) str1);
                break;
              }
              this.m_bFCTTestStarted = true;
              return true;
            }
            this.m_bFCTTestStarted = true;
            return true;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0}\r\n", (object) str2);
            break;
          }
          if (this.m_TestMode == 5)
          {
            if (!flag1)
            {
              int num1 = 0;
              bool flag2 = false;
              while (num1 < 3 && !flag2)
              {
                this.SendSerialPortCommand(string.Format("STRESPRG {0} {1}\r\n", (object) str3, (object) 1));
                ++num1;
                this.cbStatusColor(Color.Green);
                this.cbStatusText("...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...");
                while (!this.m_userabort)
                {
                  if (this.m_results.Contains("FCT NVRAM program completed") && this.m_results.Contains("Result ="))
                  {
                    Thread.Sleep(1000);
                    break;
                  }
                  if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                  {
                    this.cbTerminal("TIMEOUT");
                    frmFail frmFail = new frmFail();
                    string str5 = "Failed to detect the device\n\nClose the app and reboot DOS PC!";
                    soteDiag.soteDiag soteDiag = this;
                    soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: TIMEOUT" + str5;
                    this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                    this.m_iFCTErrorCode = 300;
                    if (num1 >= 3)
                    {
                      frmFail.Message = str5;
                      int num2 = (int) frmFail.ShowDialog();
                      this.RaiseUserAbortEvent();
                    }
                    else
                      break;
                  }
                }
                if (this.m_results.Contains("Errorcode = 56") || this.m_results.Contains("Errorcode = 57") || this.m_iFCTErrorCode == 300)
                {
                  if (num1 < 3)
                  {
                    soteUtils.log2file(this.m_traceLog, this.m_results);
                    this.m_results = "";
                    this.generateMACfile(clsUUT.hw_type);
                    Thread.Sleep(2000);
                    this.m_bRetry = true;
                    this.rebootDOSPC();
                  }
                }
                else
                  flag2 = true;
              }
            }
            if (this.m_results.Contains("Result = PASS") && !this.m_results.Contains("Result = FAIL"))
            {
              soteUtils.log2file(this.m_traceLog, this.m_results);
              this.m_results = "";
              this.rebootDOSPC();
              txtCommandLine = string.Format("STRESTST {0} {1}\r\n", (object) str3, (object) 1);
              break;
            }
            this.m_bFCTTestStarted = true;
            return true;
          }
          if (this.m_TestMode == 8 && this.m_bRMAProgramNVRAM)
          {
            if (!flag1)
            {
              this.SendSerialPortCommand(string.Format("STRESPRG {0} {1}\r\n", (object) str4, (object) 1));
              this.cbStatusColor(Color.Green);
              this.cbStatusText("...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...");
              while (!this.m_userabort)
              {
                if (this.m_results.Contains("FCT NVRAM program completed"))
                {
                  Thread.Sleep(1000);
                  break;
                }
                if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                {
                  this.cbTerminal("TIMEOUT");
                  frmFail frmFail = new frmFail();
                  string str5 = "Failed to detect the device\n\nClose the app and reboot DOS PC!";
                  soteDiag.soteDiag soteDiag = this;
                  soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: TIMEOUT" + str5;
                  frmFail.Message = str5;
                  int num = (int) frmFail.ShowDialog();
                  this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                  this.m_iFCTErrorCode = 300;
                  this.RaiseUserAbortEvent();
                }
              }
            }
            if (this.m_results.Contains("Result = PASS") && !this.m_results.Contains("Result = FAIL") && this.m_bRMAFCT)
            {
              soteUtils.log2file(this.m_traceLog, this.m_results);
              this.m_results = "";
              this.rebootDOSPC();
              txtCommandLine = string.Format("STRESTST {0} {1}\r\n", (object) str4, (object) 1);
              break;
            }
            this.m_bFCTTestStarted = true;
            return true;
          }
          if (this.m_TestMode == 8 && !this.m_bRMAProgramNVRAM)
          {
            txtCommandLine = string.Format("STRESTST {0} {1}\r\n", (object) str4, (object) 1);
            break;
          }
          break;
        case "M125C":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            if (!flag1)
            {
              int num1 = 0;
              bool flag2 = false;
              while (num1 < 3 && !flag2)
              {
                this.SendSerialPortCommand(string.Format("FCTPRG {0}\r\n", (object) str1));
                ++num1;
                this.cbStatusColor(Color.Green);
                this.cbStatusText("...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...");
                while (!this.m_userabort)
                {
                  if (this.m_results.Contains("FCT NVRAM program completed") && this.m_results.Contains("Result ="))
                  {
                    Thread.Sleep(1000);
                    break;
                  }
                  if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                  {
                    this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                    this.m_iFCTErrorCode = 300;
                    if (num1 < 3)
                    {
                      this.m_results += "\r\n\nFAIL: Failed to program the NVRAM! No ACK from the DUT!";
                      this.m_results += "\r\nRetry programming the NVRAM again!\r\n";
                      break;
                    }
                    frmFail frmFail = new frmFail();
                    string str5 = "\nFailed to program the NVRAM!\n\nClose the app and reboot DOS PC!";
                    soteDiag.soteDiag soteDiag = this;
                    soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str5;
                    this.m_results += "\r\nNo more retrying programming the NVRAM!\r\n";
                    frmFail.Message = str5;
                    int num2 = (int) frmFail.ShowDialog();
                    this.RaiseUserAbortEvent();
                  }
                }
                if (this.m_results.Contains("Errorcode = 56") || this.m_results.Contains("Errorcode = 57") || this.m_iFCTErrorCode == 300)
                {
                  if (num1 < 3)
                  {
                    soteUtils.log2file(this.m_traceLog, this.m_results);
                    this.m_results = "";
                    this.generateMACfile(clsUUT.hw_type);
                    Thread.Sleep(2000);
                    this.m_bRetry = true;
                    this.rebootDOSPC();
                  }
                }
                else
                  flag2 = true;
              }
            }
            if (this.m_results.Contains("Result = PASS") && !this.m_results.Contains("Result = FAIL"))
            {
              soteUtils.log2file(this.m_traceLog, this.m_results);
              this.m_results = "";
              this.rebootDOSPC();
              this.SendSerialPortCommand(string.Format("FCTTEST {0}\r\n", (object) str1));
              this.cbStatusColor(Color.Green);
              this.cbStatusText("...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...");
              while (!this.m_userabort)
              {
                if (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result ="))
                {
                  Thread.Sleep(1000);
                  break;
                }
                if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                {
                  this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                  this.m_iFCTErrorCode = 300;
                  int num = (int) new frmFail()
                  {
                    Message = "\nFailed to run the FCT test!\n\nClose the app and reboot DOS PC!"
                  }.ShowDialog();
                  this.RaiseUserAbortEvent();
                }
              }
              if (this.m_results.Contains("Result = FAIL"))
              {
                this.m_bFCTTestStarted = true;
                return true;
              }
              for (int index = 0; index < clsUUT.pcie_test_loop; ++index)
              {
                soteUtils.log2file(this.m_traceLog, this.m_results);
                this.m_results = "";
                this.rebootDOSPC();
                this.SendSerialPortCommand(string.Format("PCIETEST {0}\r\n", (object) str1));
                this.cbStatusColor(Color.Green);
                this.cbStatusText("...Running PCIE test...Running PCIE test...Running PCIE test...Running PCIE test...Running PCIE test...Running PCIE test...Running PCIE test...");
                while (!this.m_userabort)
                {
                  if (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result ="))
                  {
                    Thread.Sleep(1000);
                    break;
                  }
                  if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                  {
                    this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                    this.m_iFCTErrorCode = 300;
                    int num = (int) new frmFail()
                    {
                      Message = "\nFailed to run PCIE test!\n\nClose the app and reboot DOS PC!"
                    }.ShowDialog();
                    this.RaiseUserAbortEvent();
                  }
                }
                if (this.m_results.Contains("Result = FAIL"))
                {
                  this.m_bFCTTestStarted = true;
                  return true;
                }
              }
              this.m_bFCTTestStarted = true;
              return true;
            }
            this.m_bFCTTestStarted = true;
            return true;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0}\r\n", (object) str2);
            break;
          }
          if (this.m_TestMode == 5)
          {
            if (!flag1)
            {
              int num1 = 0;
              bool flag2 = false;
              while (num1 < 3 && !flag2)
              {
                this.SendSerialPortCommand(string.Format("STRESPRG {0} {1}\r\n", (object) str3, (object) 1));
                ++num1;
                this.cbStatusColor(Color.Green);
                this.cbStatusText("...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...");
                while (!this.m_userabort)
                {
                  if (this.m_results.Contains("FCT NVRAM program completed") && this.m_results.Contains("Result ="))
                  {
                    Thread.Sleep(1000);
                    break;
                  }
                  if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                  {
                    this.cbTerminal("TIMEOUT");
                    frmFail frmFail = new frmFail();
                    string str5 = "Failed to detect the device\n\nClose the app and reboot DOS PC!";
                    soteDiag.soteDiag soteDiag = this;
                    soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: TIMEOUT" + str5;
                    this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                    this.m_iFCTErrorCode = 300;
                    if (num1 >= 3)
                    {
                      frmFail.Message = str5;
                      int num2 = (int) frmFail.ShowDialog();
                      this.RaiseUserAbortEvent();
                    }
                    else
                      break;
                  }
                }
                if (this.m_results.Contains("Errorcode = 56") || this.m_results.Contains("Errorcode = 57") || this.m_iFCTErrorCode == 300)
                {
                  if (num1 < 3)
                  {
                    soteUtils.log2file(this.m_traceLog, this.m_results);
                    this.m_results = "";
                    this.generateMACfile(clsUUT.hw_type);
                    Thread.Sleep(2000);
                    this.m_bRetry = true;
                    this.rebootDOSPC();
                  }
                }
                else
                  flag2 = true;
              }
            }
            if (this.m_results.Contains("Result = PASS") && !this.m_results.Contains("Result = FAIL"))
            {
              soteUtils.log2file(this.m_traceLog, this.m_results);
              this.m_results = "";
              this.rebootDOSPC();
              txtCommandLine = string.Format("STRESTST {0} {1}\r\n", (object) str3, (object) 1);
              break;
            }
            this.m_bFCTTestStarted = true;
            return true;
          }
          if (this.m_TestMode == 8 && this.m_bRMAProgramNVRAM)
          {
            if (!flag1)
            {
              this.SendSerialPortCommand(string.Format("STRESPRG {0} {1}\r\n", (object) str4, (object) 1));
              this.cbStatusColor(Color.Green);
              this.cbStatusText("...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...");
              while (!this.m_userabort)
              {
                if (this.m_results.Contains("FCT NVRAM program completed"))
                {
                  Thread.Sleep(1000);
                  break;
                }
                if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
                {
                  this.cbTerminal("TIMEOUT");
                  frmFail frmFail = new frmFail();
                  string str5 = "Failed to detect the device\n\nClose the app and reboot DOS PC!";
                  soteDiag.soteDiag soteDiag = this;
                  soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: TIMEOUT" + str5;
                  frmFail.Message = str5;
                  int num = (int) frmFail.ShowDialog();
                  this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                  this.m_iFCTErrorCode = 300;
                  this.RaiseUserAbortEvent();
                }
              }
            }
            if (this.m_results.Contains("Result = PASS") && !this.m_results.Contains("Result = FAIL") && this.m_bRMAFCT)
            {
              soteUtils.log2file(this.m_traceLog, this.m_results);
              this.m_results = "";
              this.rebootDOSPC();
              txtCommandLine = string.Format("STRESTST {0} {1}\r\n", (object) str4, (object) 1);
              break;
            }
            this.m_bFCTTestStarted = true;
            return true;
          }
          if (this.m_TestMode == 8 && !this.m_bRMAProgramNVRAM)
          {
            txtCommandLine = string.Format("STRESTST {0} {1}\r\n", (object) str4, (object) 1);
            break;
          }
          break;
        case "GENERIC":
          this.SendSerialPortCommand(string.Format("FCTPRG {0} {1} {2}\r\n", (object) str1, (object) this.m_esr_ImgFile, (object) this.m_esr_Stride));
          this.cbStatusColor(Color.Green);
          this.cbStatusText("...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...Programming NVRAM...");
          while (!this.m_userabort)
          {
            if (this.m_results.Contains("FCT NVRAM program completed"))
            {
              Thread.Sleep(1000);
              break;
            }
            if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
            {
              this.cbTerminal("TIMEOUT");
              frmFail frmFail = new frmFail();
              string str5 = "Failed to detect the device\n\nClose the app and reboot DOS PC!";
              soteDiag.soteDiag soteDiag = this;
              soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: TIMEOUT" + str5;
              frmFail.Message = str5;
              int num = (int) frmFail.ShowDialog();
              this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
              this.m_iFCTErrorCode = 300;
              this.RaiseUserAbortEvent();
            }
          }
          if (this.m_results.Contains("Result = PASS") && !this.m_results.Contains("Result = FAIL"))
          {
            soteUtils.log2file(this.m_traceLog, this.m_results);
            this.m_results = "";
            this.rebootDOSPC();
            txtCommandLine = string.Format("FCTTEST {0}\r\n", (object) str1);
            break;
          }
          this.m_bFCTTestStarted = true;
          return true;
        case "GAMMA":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = string.Format("M2004G {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 8)
          {
            txtCommandLine = string.Format("RMA {0} {1}\r\n", (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
        case "N2004":
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
            txtCommandLine = string.Format("N2004 {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 2)
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 8)
            txtCommandLine = string.Format("RMA {0} {1}\r\n", (object) str1, (object) this.m_dutcomVal);
          else if (this.m_TestMode == 5)
            txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
          this.SendSerialPortCommand(txtCommandLine);
          this.cbStatusColor(Color.Green);
          if (this.m_TestMode == 2)
            this.cbStatusText("...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...");
          else if (this.m_TestMode == 8)
            this.cbStatusText("...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...");
          else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
            this.cbStatusText("...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...");
          else if (this.m_TestMode != 5 || this.m_bFCTEnabled || (this.m_TestMode != 8 || !this.m_bRMAFCT || !this.m_bRMAProgramNVRAM))
            this.cbStatusText("...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...");
          while (!this.m_userabort)
          {
            if (this.m_results.Contains("FCT test completed") && this.m_results.Contains("Result ="))
            {
              Thread.Sleep(1000);
              break;
            }
            if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
            {
              this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
              this.m_iFCTErrorCode = 300;
              frmFail frmFail = new frmFail();
              string str5 = "\nFailed to program the NVRAM!\n\nClose the app and reboot DOS PC!";
              soteDiag.soteDiag soteDiag = this;
              soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str5;
              this.m_results += "\r\nNo more retrying programming the NVRAM!\r\n";
              frmFail.Message = str5;
              int num = (int) frmFail.ShowDialog();
              this.RaiseUserAbortEvent();
            }
          }
          this.m_bFCTTestStarted = true;
          return true;
        case "OBRIEN":
          if (this.m_TestMode != 2 && this.m_TestMode != 8)
          {
            this.runFWverify(clsUUT.hw_type);
            while (!this.m_userabort)
            {
              if (this.m_results.Contains("logfile closed at"))
              {
                Thread.Sleep(1000);
                break;
              }
              if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
              {
                this.cbTerminal("TIMEOUT");
                frmFail frmFail = new frmFail();
                string str5 = "Failed to detect the device\n\nClose the app and reboot DOS PC!";
                soteDiag.soteDiag soteDiag = this;
                soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: TIMEOUT" + str5;
                frmFail.Message = str5;
                int num = (int) frmFail.ShowDialog();
                this.m_FCTErrorDescription = "FCT:No ACK from the DUT";
                this.m_iFCTErrorCode = 300;
                this.RaiseUserAbortEvent();
              }
            }
            soteUtils.log2fileOverWrite("VERIFYFW.txt", this.m_results);
            flag1 = this.verifyFWVersion(clsUUT.hw_type, "VERIFYFW.txt");
          }
          if (this.m_TestMode == 1 || this.m_TestMode == 9 || this.m_TestMode == 6 || this.m_TestMode == 7)
          {
            txtCommandLine = !flag1 ? string.Format("AD2000DC {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal) : string.Format("2000TEST {0} {1} {2}\r\n", (object) clsUUT.scanMAC[0], (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 2)
          {
            txtCommandLine = string.Format("QA {0} {1}\r\n", (object) str2, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 8)
          {
            txtCommandLine = string.Format("RMA {0} {1}\r\n", (object) str1, (object) this.m_dutcomVal);
            break;
          }
          if (this.m_TestMode == 5)
          {
            if (flag1)
              txtCommandLine = string.Format("STRESSFW {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            else
              txtCommandLine = string.Format("STRESS {0} {1} {2} {3}\r\n", (object) clsUUT.scanMAC[0], (object) str3, (object) this.m_dutcomVal, (object) 1);
            break;
          }
          break;
      }
      this.SendSerialPortCommand(txtCommandLine);
      this.cbStatusColor(Color.Green);
      if (this.m_TestMode == 2)
        this.cbStatusText("...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...Running OBA test...");
      else if (this.m_TestMode == 8)
        this.cbStatusText("...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...Running RMA test...");
      else if (this.m_TestMode == 5 && this.m_bFCTEnabled)
        this.cbStatusText("...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...Running STRESS test...");
      else if (this.m_TestMode != 5 || this.m_bFCTEnabled || (this.m_TestMode != 8 || !this.m_bRMAFCT || !this.m_bRMAProgramNVRAM))
        this.cbStatusText("...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...Running FCT test...");
      this.m_bFCTTestStarted = true;
      return true;
    }

    public void rebootDOSPC()
    {
      if (this.m_usbrelayenable)
      {
        this.cbStatusColor(Color.Red);
        this.cbStatusText("Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC..........Please WAIT!............");
        this.m_results += "\r\nRebooting DOS PC";
        this.PowerON();
      }
      else
      {
        if (clsUUT.hw_type == "P225EPD" || clsUUT.hw_type == "P210EPD" || (clsUUT.hw_type == "P210TEPD" || clsUUT.hw_type == "P225EPDLP") || (clsUUT.hw_type == "P210EPDLP" || clsUUT.hw_type == "P210TEPDLP") || this.m_builtin_BIE)
        {
          if (this.m_bRetry)
          {
            this.PowerOFF();
            this.m_results += "\r\nPause for 5 seconds";
            Thread.Sleep(5000);
            this.PowerON();
            this.m_results += "\r\nPause for 5 seconds";
            Thread.Sleep(5000);
          }
          else
          {
            this.PowerON();
            this.m_results += "\r\nPause for 5 seconds";
            Thread.Sleep(5000);
          }
        }
        else
        {
          this.PowerOFF();
          this.m_results += "\r\nPause for 5 seconds";
          Thread.Sleep(5000);
          this.PowerON();
          this.m_results += "\r\nPause for 5 seconds";
          Thread.Sleep(5000);
        }
        this.SendSerialPortCommand("shutdown -r \r\n");
        this.cbStatusColor(Color.Red);
        this.cbStatusText("Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC...Rebooting DOS PC..........Please WAIT!............");
      }
      int num1 = 0;
      while (true)
      {
        if (this.m_commands != null)
        {
          if (this.m_commands.Contains("PC is ready!"))
            break;
        }
        else if (this.m_nPowerupRetry == 1)
        {
          this.m_results += "\r\nFailed to establish serial communication! Check COM port connection!";
          int num2 = (int) new frmFail()
          {
            Message = "Failed to establish serial communication!\n\nCheck COM port connection!"
          }.ShowDialog();
          this.RaiseUserAbortEvent();
        }
        else
        {
          ++this.m_nPowerupRetry;
          this.rebootDOSPC();
        }
        if (this.m_timestamp.AddSeconds((double) this.m_DOSPC_BOOTUP_TIMER) < DateTime.Now)
        {
          if (num1 <= 2)
          {
            if (this.m_usbrelayenable)
            {
              if (num1 % 2 == 0)
              {
                this.SendSerialPortCommand("echo PC is ready!");
              }
              else
              {
                this.m_results += "\r\nRETRY - Rebooting DOS PC";
                this.PowerON();
              }
            }
            else
              this.SendSerialPortCommand("echo PC is ready!");
            ++num1;
          }
          else
          {
            this.cbTerminal("TIMEOUT");
            frmFail frmFail = new frmFail();
            string str = "Failed to Auto-Reboot the DOS PC\n\nClose the app and reboot DOS PC!";
            soteDiag.soteDiag soteDiag = this;
            soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str;
            frmFail.Message = str;
            int num2 = (int) frmFail.ShowDialog();
            this.m_FCTErrorDescription = "FCT:Failed to Auto-Reboot DOS PC";
            this.m_iFCTErrorCode = 301;
            this.RaiseUserAbortEvent();
          }
        }
      }
      this.m_bDUTPCPowerON = true;
      Thread.Sleep(1000);
      if (clsUUT.hw_type == "GENERIC")
        clsUUT.dos_dir = "C:\\BC" + this.m_esr_BC;
      if (!(clsUUT.dos_dir != ""))
        return;
      this.SendSerialPortCommand(string.Format("CD {0} \r\n", (object) clsUUT.dos_dir));
    }

    public void runNCSITest()
    {
      string exename = Application.StartupPath + "\\NCSITestConsole";
      char ch = '"';
      string args = "adapter=" + (object) ch + this.m_network_adapter + (object) ch + " cidlist=" + (object) ch + "0x00 0x01 0x20 0x21" + (object) ch + " log=" + this.logDir + this.m_logFileName + ".ncsi";
      soteUtils.runCmdLine(exename, args, (soteUtils.delegateListener) null, true, true, 20000);
      soteUtils.abortCmdLine();
      this.cbStatusColor(Color.Green);
      this.cbStatusText("...Running NCSI Test...Running NCSI Test...Running NCSI Test...Running NCSI Test...Running NCSI Test...Running NCSI Test...");
    }

    public bool runFWverify(string hw_type)
    {
      if (this.m_TestMode == 2 || this.m_TestMode == 8)
        return true;
      if (clsUUT.bCdiag)
      {
        bool flag;
        if (!(flag = this.loadFwCheckConfig(hw_type)))
        {
          this.m_FCTErrorDescription = "FCT:Failed to load FW check config file!";
          this.m_iFCTErrorCode = 302;
          return flag;
        }
        this.SendSerialPortCommand(string.Format("CDIAGCHK.BAT VERIFYFW.TXT\r\n"));
      }
      else
        this.SendSerialPortCommand(string.Format("VERIFYFW.BAT {0}\r\n", (object) this.m_dutcomVal));
      this.cbStatusColor(Color.Green);
      this.cbStatusText("...Verifying FW version...Verifying FW version...Verifying FW version...Verifying FW version...Verifying FW version...Verifying FW version...");
      return true;
    }

    public bool setDateTime()
    {
      try
      {
        DateTime now = DateTime.Now;
        this.SendSerialPortCommand(string.Format("DATETIME.BAT {0} {1}\r\n", (object) string.Format("{0:D2}-{1:D2}-{2:D4}", (object) now.Month, (object) now.Day, (object) now.Year), (object) string.Format("{0:D2}:{1:D2}:{2:D2}", (object) now.Hour, (object) now.Minute, (object) now.Second)));
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "\r\nCurrent Win7 DateTime:" + (object) DateTime.Now + "\r\n";
        this.cbStatusColor(Color.Green);
        this.cbStatusText("...Setting Date/Time of DOS PC...Setting Date/Time of DOS PC...Setting Date/Time of DOS PC...Setting Date/Time of DOS PC...Setting Date/Time of DOS PC...");
      }
      catch (Exception ex)
      {
        int num = (int) new NewMessageBox()
        {
          Message = string.Format("setDateTime: " + ex.Message)
        }.ShowDialog();
        soteDiag.soteDiag.showFailMsgDlg("setDateTime: EXCEPTION encountered");
      }
      return true;
    }

    public bool runNVRAMverify(string hw_type)
    {
      if (this.m_TestMode == 5 && !this.m_bNVRAMVerifyEnabled || this.m_TestMode == 8 && !this.m_bRMANVRAMVerify)
        return true;
      this.SendSerialPortCommand(string.Format("READMAC.BAT {0}\r\n", (object) this.m_dutcomVal));
      this.cbStatusColor(Color.Green);
      this.cbStatusText("...Verifying NVRAM...Verifying NVRAM...Verifying NVRAM...Verifying NVRAM...Verifying NVRAM...Verifying NVRAM...");
      this.m_bNVRAMVerifyTestStarted = true;
      return true;
    }

    public static bool log2binaryfile(string fn, string msg)
    {
      try
      {
        BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(fn, FileMode.Create));
        binaryWriter.Write(msg);
        binaryWriter.Close();
        return true;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("log2binaryfile:\n" + ex.Message);
      }
      return false;
    }

    public void eraseNVRAM(string hw_type)
    {
      soteUtils.log2file(this.m_traceLog, this.m_results);
      this.m_results = "";
      this.SendSerialPortCommand(string.Format("NVMFILL.BAT {0}\r\n", (object) this.m_dutcomVal));
      this.cbStatusColor(Color.Green);
      this.cbStatusText("...Erasing NVRAM...Erasing NVRAM...Erasing NVRAM..Erasing NVRAM...Erasing NVRAM...Erasing NVRAM...Erasing NVRAM...");
      while (!this.m_userabort)
      {
        if (this.m_results.Contains("NVMFILL completed"))
        {
          Thread.Sleep(1000);
          break;
        }
        if (this.m_timestamp.AddSeconds(60.0) < DateTime.Now)
        {
          this.cbTerminal("TIMEOUT");
          frmFail frmFail = new frmFail();
          string str = "Failed to detect the device\n\nClose the app and reboot DOS PC!";
          soteDiag.soteDiag soteDiag = this;
          soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: " + str;
          frmFail.Message = str;
          int num = (int) frmFail.ShowDialog();
          this.m_FCTErrorDescription = "FCT/EraseNVRAM:No ACK from the DUT";
          this.m_iFCTErrorCode = 300;
          this.RaiseUserAbortEvent();
        }
      }
      soteUtils.log2file(this.m_traceLog, this.m_results);
      this.m_results = "";
    }

    public bool runNVRAMlog(string hw_type)
    {
      this.m_results = "";
      this.SendSerialPortCommand(string.Format("LOG.BAT {0}\r\n", (object) this.m_dutcomVal));
      this.cbStatusColor(Color.Green);
      this.cbStatusText("...Gathering NVRAM LOG...Gathering NVRAM LOG...Gathering NVRAM LOG...Gathering NVRAM LOG...Gathering NVRAM LOG...");
      while (!this.m_userabort)
      {
        if (this.m_results.Contains("logfile closed at"))
        {
          Thread.Sleep(1000);
          break;
        }
        if (this.m_timestamp.AddSeconds(90.0) < DateTime.Now)
        {
          this.cbTerminal("TIMEOUT");
          frmFail frmFail = new frmFail();
          string str = "Failed to detect the device\n\nClose the app and reboot DOS PC!";
          soteDiag.soteDiag soteDiag = this;
          soteDiag.m_results = soteDiag.m_results + "\r\nFAIL: TIMEOUT" + str;
          frmFail.Message = str;
          int num = (int) frmFail.ShowDialog();
          this.m_FCTErrorDescription = "FCT/NVRAMLog:No ACK from the DUT";
          this.m_iFCTErrorCode = 300;
          this.RaiseUserAbortEvent();
        }
      }
      switch (hw_type)
      {
        case "GAMMA":
          this.SendSerialPortCommand(string.Format("copy M2004G.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy M2004CFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-M2004G.log", "M2004G", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-M2004CFG.txt", "M2004CFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "N2004":
          this.SendSerialPortCommand(string.Format("copy N2004.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy N2004CFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-N2004.log", "N2004", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-N2004CFG.txt", "N2004CFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "OBRIEN":
          this.SendSerialPortCommand(string.Format("copy AD2000DC.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy D2000CFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-AD2000DC.log", "AD2000DC", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-D2000CFG.txt", "D2000CFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "PUTNAM":
          this.SendSerialPortCommand(string.Format("copy A1904GH.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy 1904HCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A1904GH.log", "A1904GH", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-1904HCFG.txt", "1904HCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "BUBBLES":
          this.SendSerialPortCommand(string.Format("copy BUBBLES.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy BUBBLES.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-BUBBLES.log", "BUBBLES", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-BUBBLES.txt", "BUBBLES", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "CASPIAN":
          this.SendSerialPortCommand(string.Format("copy CASPIAN.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy CASPIAN.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-CASPIAN.log", "CASPIAN", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-CASPIAN.txt", "CASPIAN", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "ARAL":
          this.SendSerialPortCommand(string.Format("copy ARAL.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy ARAL.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-ARAL.log", "ARAL", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-ARAL.txt", "ARAL", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "WOODVILLE":
          this.SendSerialPortCommand(string.Format("copy A2003GH.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy 2003HCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A2003GH.log", "A2003GH", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-2003HCFG.txt", "2003HCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "MERCURY":
          this.SendSerialPortCommand(string.Format("copy A1904AC.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy MERCUCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A1904AC.log", "A1904AC", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-MERCUCFG.txt", "MERCUCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "PLUTO":
          this.SendSerialPortCommand(string.Format("copy A2003AC.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy PLUTOCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A2003AC.log", "A2003AC", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-PLUTOCFG.txt", "PLUTOCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "P150C":
        case "M150C":
        case "M150PM":
        case "M1100PM":
        case "M150P":
        case "M210TP":
        case "M225PQ":
        case "PS150":
        case "MS150":
        case "P1100P":
        case "P225E":
        case "BOAR":
        case "BANDICOOT":
        case "BOBCAT":
        case "BOBOLINK":
        case "P210TE":
        case "P210TEP":
        case "P125C":
        case "P225C":
        case "P225CA":
        case "P225CO":
        case "P225PO":
        case "P150P":
        case "P225P":
        case "M225P":
        case "M125P":
        case "M210P":
        case "P210P":
        case "P210C":
        case "P210ED":
        case "P210EPD":
        case "P210TED":
        case "P210TEPD":
        case "P225ED":
        case "P225EPD":
        case "P210EDLP":
        case "P210EPDLP":
        case "P210TEDLP":
        case "P210TEPDLP":
        case "P225EDLP":
        case "P225EPDLP":
        case "M125C":
        case "M125CP":
        case "M125CLP":
        case "M125CHF":
        case "M125CLPHF":
        case "M225C":
        case "M225CD":
        case "M225PD":
        case "M210C":
          this.SendSerialPortCommand(string.Format("copy NVRAMLOG.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy NVRAMCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-NVRAMLOG.log", "NVRAMLOG", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-NVRAMCFG.txt", "NVRAMCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "BOERNE":
          this.SendSerialPortCommand(string.Format("copy A1913G.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy A1913CFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A1913G.log", "A1913G", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A1913CFG.txt", "A1913CFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "CORAK":
          this.SendSerialPortCommand(string.Format("copy A1905G.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy 1905DCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A1905G.log", "A1905G", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-1905DCFG.txt", "1905DCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "N1905":
          this.SendSerialPortCommand(string.Format("copy N1905.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy N1905CFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-N1905.log", "N1905", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-N1905CFG.txt", "N1905CFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "CARDASSIA":
          this.SendSerialPortCommand(string.Format("copy A1904GD.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy 1904DCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A1904GD.log", "A1904GD", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-1904DCFG.txt", "1904DCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "SHARKNADO4":
          this.SendSerialPortCommand(string.Format("copy SHARK4.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy SHAR4CFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-SHARK4.log", "SHARK4", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-SHAR4CFG.txt", "SHAR4CFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "SHARKNADO2":
          this.SendSerialPortCommand(string.Format("copy SHARK2.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy SHAR2CFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-SHARK2.log", "SHARK2", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-SHAR2CFG.txt", "SHAR2CFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "BASHIR":
          this.SendSerialPortCommand(string.Format("copy A2003GD.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy 2003DCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-A2003GD.log", "A2003GD", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-2003DCFG.txt", "2003DCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "GAUSS":
          this.SendSerialPortCommand(string.Format("copy GAUSS.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy GAUSSCFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-GAUSS.log", "GAUSS", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-GAUSSCFG.txt", "GAUSSCFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
        case "PAULI":
          this.SendSerialPortCommand(string.Format("copy PAULI.log com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(5000);
          this.SendSerialPortCommand(string.Format("copy PAULICFG.txt com{0}: \r\n", (object) this.m_dutcomVal));
          Thread.Sleep(4000);
          soteUtils.log2file(this.m_traceLog, this.m_results);
          this.m_results = "";
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-PAULI.log", "PAULI", 71);
          this.ParseTestLog(this.m_traceLog, this.logDir + this.m_logFileName + "-PAULICFG.txt", "PAULICFG", 72);
          this.cbStatusColor(Color.BlueViolet);
          this.cbStatusText("Golden Sample Test Completed!");
          break;
      }
      return true;
    }

    private static string[] maclist(string mac, int count, int incr)
    {
      string[] strArray = new string[count];
      ulong uint64 = Convert.ToUInt64(string.Format("{0:X}", (object) mac.Replace(":", "").Replace("-", "").Substring(0)), 16);
      for (int index = 0; index < count; ++index)
      {
        strArray[index] = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}{4:X2}{5:X2}", (object) (ulong) ((long) (uint64 >> 40) & (long) byte.MaxValue), (object) (ulong) ((long) (uint64 >> 32) & (long) byte.MaxValue), (object) (ulong) ((long) (uint64 >> 24) & (long) byte.MaxValue), (object) (ulong) ((long) (uint64 >> 16) & (long) byte.MaxValue), (object) (ulong) ((long) (uint64 >> 8) & (long) byte.MaxValue), (object) (ulong) ((long) uint64 & (long) byte.MaxValue));
        uint64 += (ulong) incr;
      }
      return strArray;
    }

    public bool readMACSNb57wdg32()
    {
      string command = Application.StartupPath + "\\b57wdg32";
      string str1 = "-rc nvramb57.tcl";
      string str2 = Application.StartupPath + "\\READMAC.txt";
      string str3 = this.logDir + "READMAC.txt";
      if (File.Exists(str2))
        File.Delete(str2);
      this.executeShellCommand(command, str1, out string _);
      File.Copy(str2, str3, true);
      return File.Exists(str3);
    }

    public bool programFRU(string hw_type)
    {
      if (this.m_TestMode == 2 || this.m_TestMode == 5 && !this.m_bProgramFRUEnabled || this.m_TestMode == 8 && !this.m_bRMAProgramFRU || !clsUUT.bFRU)
      {
        this.m_ProgramFRUTestResult = true;
        return true;
      }
      switch (hw_type)
      {
        case "BOERNE":
          this.readINI_Boerne(hw_type);
          break;
        case "PUTNAM":
          this.readINI_Putnam(hw_type);
          break;
        case "BUBBLES":
          this.readINI_BUBBLES(hw_type);
          this.SendSerialPortCommand(string.Format("GPIO11 {0}\r\n", (object) this.m_dutcomVal));
          this.SendSerialPortCommand(string.Format("B {0}\r\n", (object) this.m_dutcomVal));
          Thread.Sleep(20000);
          break;
        case "CASPIAN":
          this.readINI_CASPIAN(hw_type);
          this.SendSerialPortCommand(string.Format("GPIO11 {0}\r\n", (object) this.m_dutcomVal));
          this.SendSerialPortCommand(string.Format("B {0}\r\n", (object) this.m_dutcomVal));
          Thread.Sleep(20000);
          break;
        case "ARAL":
          this.readINI_ARAL(hw_type);
          break;
        case "WOODVILLE":
          this.readINI_Woodville(hw_type);
          break;
        case "GAMMA":
          this.readINI_Gamma(hw_type);
          break;
        case "N2004":
          this.readINI_N2004(hw_type);
          this.SendSerialPortCommand(string.Format("GPIO11 {0}\r\n", (object) this.m_dutcomVal));
          this.SendSerialPortCommand(string.Format("B {0}\r\n", (object) this.m_dutcomVal));
          Thread.Sleep(20000);
          break;
        case "OBRIEN":
          this.readINI_Obrien(hw_type);
          break;
        case "CARDASSIA":
          this.readINI_Cardassia(hw_type);
          break;
        case "BASHIR":
          this.readINI_Bashir(hw_type);
          break;
        case "CORAK":
          this.readINI_Corak(hw_type);
          break;
        case "PAULI":
          this.readINI_PAULI(hw_type);
          break;
        case "HERTZ":
          this.readINI_HERTZ(hw_type);
          break;
        case "GAUSS":
          this.readINI_GAUSS(hw_type);
          break;
        case "P225ED":
          this.readINI_P225ED(hw_type);
          break;
        case "P225EDLP":
          this.readINI_P225EDLP(hw_type);
          break;
        case "P225EPD":
          this.readINI_P225EPD(hw_type);
          break;
        case "P225EPDLP":
          this.readINI_P225EPDLP(hw_type);
          break;
        case "P210ED":
          this.readINI_P210ED(hw_type);
          break;
        case "P210EDLP":
          this.readINI_P210EDLP(hw_type);
          break;
        case "P210EPD":
          this.readINI_P210EPD(hw_type);
          break;
        case "P210EPDLP":
          this.readINI_P210EPDLP(hw_type);
          break;
        case "P210TED":
          this.readINI_P210TED(hw_type);
          break;
        case "P210TEDLP":
          this.readINI_P210TEDLP(hw_type);
          break;
        case "P210TEPD":
          this.readINI_P210TEPD(hw_type);
          break;
        case "P210TEPDLP":
          this.readINI_P210TEPDLP(hw_type);
          break;
        case "BOAR":
          this.readINI_BOAR(hw_type);
          break;
        case "BANDICOOT":
          this.readINI_BANDICOOT(hw_type);
          break;
        case "BOBCAT":
          this.readINI_BOBCAT(hw_type);
          break;
        case "BOBOLINK":
          this.readINI_BOBOLINK(hw_type);
          break;
        case "MUSTANG":
          this.readINI_Mustang(hw_type);
          break;
        case "M4161":
          this.readINI_M4161(hw_type);
          break;
        case "M150PM":
          this.readINI_M150PM(hw_type);
          break;
        default:
          this.m_ProgramFRUTestResult = true;
          return true;
      }
      this.m_ProgramFRUTestResult = false;
      this.loadI2CSettings(hw_type);
      this.loadBinary(soteDiag.soteDiag.bin_template);
      if (this.fruWriteBuffer == null)
      {
        this.m_ProgramFRUTestResult = false;
        this.m_ProgramFRUErrorDescription = "ProgramFRU:Failed to write I2C device";
        this.m_iProgramFRUErrorCode = 2000;
        return false;
      }
      Application.DoEvents();
      this.cbStatus2Color(Color.MediumBlue);
      this.cbStatus2Text("...Programming FRU...Programming FRU...Programming FRU...Programming FRU...Programming FRU...Programming FRU...");
      this.m_results += "\r\n<FRU> Program FRU...\r\n ";
      if (this.I2CAdapterType == "DLN-2" && !this.m_bDLN2Connected)
      {
        int num1 = 0;
        bool flag = false;
        for (; num1 < 3; ++num1)
        {
          if (DiolanU2C.DLN2Connect() == 0)
          {
            Thread.Sleep(1000);
          }
          else
          {
            flag = true;
            this.m_bDLN2Connected = true;
            break;
          }
        }
        if (!flag)
        {
          this.m_ProgramFRUTestResult = false;
          this.m_ProgramFRUErrorDescription = "ProgramFRU:Can't connect to Diolan DLN-2 adapter";
          this.m_iProgramFRUErrorCode = 3000;
          this.cbStatus2Color(Color.Red);
          this.cbStatus2Text("...Failed to program FRU...Failed to program FRU...Failed to program FRU...Failed to program FRU...Failed to program FRU...");
          int num2 = (int) new frmFail()
          {
            Message = "Can't connect to Diolan DLN-2 adapter"
          }.ShowDialog();
          return false;
        }
      }
      byte[] numArray1 = new byte[this.fruWriteBuffer.Length];
      for (int index = 0; index < this.fruWriteBuffer.Length; ++index)
        numArray1[index] = this.fruWriteBuffer[index];
      if (this.fruWriteBuffer.Length < soteDiag.soteDiag.deviceMemorySize)
      {
        byte[] numArray2 = new byte[soteDiag.soteDiag.deviceMemorySize];
        numArray1.CopyTo((Array) numArray2, 0);
        for (int length = this.fruWriteBuffer.Length; length < soteDiag.soteDiag.deviceMemorySize; ++length)
          numArray2[length] = Convert.ToByte(soteDiag.soteDiag.padText, 16);
        numArray1 = numArray2;
      }
      if (this.fruWriteBuffer.Length > soteDiag.soteDiag.deviceMemorySize)
      {
        this.lastErrCode = (byte) 1;
        if (MessageBox.Show("Buffer size is larger than memory size. Continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
        {
          this.m_ProgramFRUTestResult = false;
          this.m_ProgramFRUErrorDescription = "ProgramFRU:Buffer size is larger than memory size";
          this.m_iProgramFRUErrorCode = 5000;
          this.cbStatus2Color(Color.Red);
          this.cbStatus2Text("...Failed to program FRU...Failed to program FRU...Failed to program FRU...Failed to program FRU...Failed to program FRU...");
          return false;
        }
      }
      this.cbHexBox1(numArray1);
      this.fruDataProgrammed = ArrayUtil.SubsetArray(numArray1, 0, soteDiag.soteDiag.deviceMemorySize);
      bool flag1 = this.writeBuffer(1, soteDiag.soteDiag.i2cDevice, numArray1, this.comPort);
      if (!flag1)
      {
        if (this.I2CAdapterType == "DLN-2" && this.m_bDLN2Connected)
        {
          DiolanU2C.DLN2Disconnect();
          this.m_bDLN2Connected = false;
        }
        this.m_ProgramFRUTestResult = false;
        this.m_ProgramFRUErrorDescription = "ProgramFRU:Failed to write I2C device";
        this.m_iProgramFRUErrorCode = 2000;
        this.cbStatus2Color(Color.Red);
        this.cbStatus2Text("...Failed to program FRU...Failed to program FRU...Failed to program FRU...Failed to program FRU...Failed to program FRU...");
        return false;
      }
      string str = !this.m_sfis_enabled || !(this.sfis_cm == "SysOps") ? clsUUT.scanLabel : clsUUT.scanLabel;
      if (str == "")
      {
        this.m_ProgramFRUTestResult = false;
        this.m_ProgramFRUErrorDescription = "ProgramFRU:No file specifiled for saving program FRU image";
        this.m_iProgramFRUErrorCode = 4000;
        this.cbStatus2Color(Color.Red);
        this.cbStatus2Text("...Failed to program FRU...Failed to program FRU...Failed to program FRU...Failed to program FRU..Failed to program FRU...");
        return false;
      }
      string path;
      if (this.m_TestMode == 5 || this.m_TestMode == 8)
      {
        this.m_ProgramFRUFileName = str + "_program_" + this.todayNow + "-Loop" + (object) this.m_Loop + ".bin";
        path = this.logDir + str + "_program_" + this.todayNow + "-Loop" + (object) this.m_Loop + ".bin";
      }
      else
      {
        this.m_ProgramFRUFileName = str + "_program_" + this.todayNow + ".bin";
        path = this.logDir + str + "_program_" + this.todayNow + ".bin";
      }
      FileUtil.WriteBinaryFile(numArray1, path);
      if (!this.m_sfis_enabled || flag1)
        ;
      this.cbStatus2Color(Color.Black);
      this.cbStatus2Text("");
      this.m_ProgramFRUTestResult = true;
      this.m_ProgramFRUErrorDescription = "ProgramFRU:PASS";
      this.m_iProgramFRUErrorCode = 0;
      return flag1;
    }

    public bool verifyFRU(string hw_type)
    {
      if (this.m_TestMode == 5 && !this.m_bFRUVerifyEnabled || (this.m_TestMode == 8 && !this.m_bRMAFRUVerify || !clsUUT.bFRU))
        return true;
      switch (hw_type)
      {
        case "BOERNE":
          this.readINI_Boerne(hw_type);
          break;
        case "PUTNAM":
          this.readINI_Putnam(hw_type);
          break;
        case "BUBBLES":
          this.readINI_BUBBLES(hw_type);
          break;
        case "CASPIAN":
          this.readINI_CASPIAN(hw_type);
          break;
        case "ARAL":
          this.readINI_ARAL(hw_type);
          break;
        case "WOODVILLE":
          this.readINI_Woodville(hw_type);
          break;
        case "GAMMA":
          this.readINI_Gamma(hw_type);
          break;
        case "N2004":
          this.readINI_N2004(hw_type);
          break;
        case "OBRIEN":
          this.readINI_Obrien(hw_type);
          break;
        case "CARDASSIA":
          this.readINI_Cardassia(hw_type);
          break;
        case "BASHIR":
          this.readINI_Bashir(hw_type);
          break;
        case "CORAK":
          this.readINI_Corak(hw_type);
          break;
        case "PAULI":
          this.readINI_PAULI(hw_type);
          break;
        case "HERTZ":
          this.readINI_HERTZ(hw_type);
          break;
        case "GAUSS":
          this.readINI_GAUSS(hw_type);
          break;
        case "P225ED":
          this.readINI_P225ED(hw_type);
          break;
        case "P225EDLP":
          this.readINI_P225EDLP(hw_type);
          break;
        case "P225EPD":
          this.readINI_P225EPD(hw_type);
          break;
        case "P225EPDLP":
          this.readINI_P225EPDLP(hw_type);
          break;
        case "P210ED":
          this.readINI_P210ED(hw_type);
          break;
        case "P210EDLP":
          this.readINI_P210EDLP(hw_type);
          break;
        case "P210EPD":
          this.readINI_P210EPD(hw_type);
          break;
        case "P210EPDLP":
          this.readINI_P210EPDLP(hw_type);
          break;
        case "P210TED":
          this.readINI_P210TED(hw_type);
          break;
        case "P210TEDLP":
          this.readINI_P210TEDLP(hw_type);
          break;
        case "P210TEPD":
          this.readINI_P210TEPD(hw_type);
          break;
        case "P210TEPDLP":
          this.readINI_P210TEPDLP(hw_type);
          break;
        case "BOAR":
          this.readINI_BOAR(hw_type);
          break;
        case "BANDICOOT":
          this.readINI_BANDICOOT(hw_type);
          break;
        case "BOBCAT":
          this.readINI_BOBCAT(hw_type);
          break;
        case "BOBOLINK":
          this.readINI_BOBOLINK(hw_type);
          break;
        case "MUSTANG":
          this.readINI_Mustang(hw_type);
          break;
        case "M4161":
          this.readINI_M4161(hw_type);
          break;
        case "M150PM":
          this.readINI_M150PM(hw_type);
          break;
        default:
          return true;
      }
      this.loadI2CSettings(hw_type);
      byte[] numArray = new byte[soteDiag.soteDiag.deviceMemorySize];
      if (this.I2CAdapterType == "DLN-2" && !this.m_bDLN2Connected)
      {
        int num1 = 0;
        bool flag = false;
        for (; num1 < 3; ++num1)
        {
          if (DiolanU2C.DLN2Connect() == 0)
          {
            Thread.Sleep(1000);
          }
          else
          {
            flag = true;
            this.m_bDLN2Connected = true;
            break;
          }
        }
        if (!flag)
        {
          this.m_FRUVerifyErrorDescription = "FRUVerify:Can't connect to Diolan DLN-2 adapter";
          this.m_iFRUVerifyErrorCode = 3000;
          this.cbStatus2Color(Color.Red);
          this.cbStatus2Text("...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...");
          int num2 = (int) new frmFail()
          {
            Message = "Can't connect to Diolan DLN-2 adapter"
          }.ShowDialog();
          return false;
        }
      }
      this.cbStatus2Color(Color.MediumBlue);
      this.cbStatus2Text("...Verifying FRU...Verifying FRU...Verifying FRU...Verifying FRU...Verifying FRU...Verifying FRU...");
      bool flag1 = this.readBuffer(1, soteDiag.soteDiag.i2cDevice, numArray, this.comPort);
      this.cbHexBox1(numArray);
      this.fruDataRead = ArrayUtil.SubsetArray(numArray, 0, soteDiag.soteDiag.deviceMemorySize);
      if (!flag1)
      {
        this.m_FRUVerifyErrorDescription = "FRUVerify:Can't read I2C device";
        this.m_iFRUVerifyErrorCode = 1000;
        this.cbStatus2Color(Color.Red);
        this.cbStatus2Text("...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...");
        if (this.I2CAdapterType == "DLN-2" && this.m_bDLN2Connected)
        {
          DiolanU2C.DLN2Disconnect();
          this.m_bDLN2Connected = false;
        }
        return false;
      }
      string scanLabel1;
      string scanLabel2;
      if (this.m_sfis_enabled && this.sfis_cm == "SysOps")
      {
        scanLabel1 = clsUUT.scanLabel;
        scanLabel2 = clsUUT.scanLabel;
      }
      else
      {
        scanLabel1 = clsUUT.scanLabel;
        scanLabel2 = clsUUT.scanLabel;
      }
      if (scanLabel1 == "")
      {
        this.m_FRUVerifyErrorDescription = "FRUVerify:No file specifiled for saving FRU verify image";
        this.m_iFRUVerifyErrorCode = 4000;
        this.cbStatus2Color(Color.Red);
        this.cbStatus2Text("...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...");
        return false;
      }
      bool flag2 = this.verifyFRUInfo(clsUUT.hw_type, numArray, this.m_sfis_enabled, this.m_badge);
      if (!flag2)
      {
        this.cbStatus2Color(Color.Red);
        this.cbStatus2Text("...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...Failed to verify FRU...");
      }
      string path1;
      if (this.m_TestMode == 5 || this.m_TestMode == 8)
      {
        this.m_VerifyFRUFileName = scanLabel1 + "_verify_" + this.todayNow + "_" + (flag2 ? (object) "PASS" : (object) "FAIL") + "-Loop" + (object) this.m_Loop + ".bin";
        path1 = this.logDir + scanLabel1 + "_verify_" + this.todayNow + "_" + (flag2 ? (object) "PASS" : (object) "FAIL") + "-Loop" + (object) this.m_Loop + ".bin";
      }
      else
      {
        this.m_VerifyFRUFileName = scanLabel1 + "_verify_" + this.todayNow + "_" + (flag2 ? "PASS" : "FAIL") + ".bin";
        path1 = this.logDir + scanLabel1 + "_verify_" + this.todayNow + "_" + (flag2 ? "PASS" : "FAIL") + ".bin";
      }
      FileUtil.WriteBinaryFile(numArray, path1);
      if (clsUUT.hw_type == "M150PM")
      {
        string path2;
        if (this.m_TestMode == 5 || this.m_TestMode == 8)
          path2 = this.logDir + scanLabel2 + "_verify2_" + this.todayNow + "_" + (flag2 ? (object) "PASS" : (object) "FAIL") + "-Loop" + (object) this.m_Loop + ".bin";
        else
          path2 = this.logDir + scanLabel2 + "_verify2_" + this.todayNow + "_" + (flag2 ? "PASS" : "FAIL") + ".bin";
        FileUtil.WriteBinaryFile(this.tBufferFBRead, path2);
      }
      this.fruDataProgrammed = (byte[]) null;
      this.cbStatus2Color(Color.Black);
      this.cbStatus2Text("");
      return flag2;
    }

    public bool verifyFRUInfo(string hw_type, byte[] tBuffer, bool sfis, string emp)
    {
      switch (hw_type)
      {
        case "BOERNE":
          return this.verifyFRUA1913G(tBuffer, sfis, emp);
        case "GAMMA":
          return this.verifyFRUM2004G_DELL(tBuffer, sfis, emp);
        case "N2004":
          return this.verifyFRUN2004_DELL(tBuffer, sfis, emp);
        case "OBRIEN":
          return this.verifyFRUAD2000DC_DELL(tBuffer, sfis, emp);
        case "PUTNAM":
          return this.verifyFRUA1904G_HP(tBuffer, sfis, emp);
        case "BUBBLES":
          return this.verifyFRUBUBBLES_HP(tBuffer, sfis, emp);
        case "CASPIAN":
          return this.verifyFRUCASPIAN(tBuffer, sfis, emp);
        case "ARAL":
          return this.verifyFRUARAL(tBuffer, sfis, emp);
        case "WOODVILLE":
          return this.verifyFRUA2003G_HP(tBuffer, sfis, emp);
        case "BOAR":
          return this.verifyFRUBOAR_HP(tBuffer, sfis, emp);
        case "BANDICOOT":
          return this.verifyFRUBANDICOOT_HP(tBuffer, sfis, emp);
        case "BOBCAT":
          return this.verifyFRUBOBCAT_HP(tBuffer, sfis, emp);
        case "BOBOLINK":
          return this.verifyFRUBOBOLINK_HP(tBuffer, sfis, emp);
        case "CORAK":
          return this.verifyFRUA1905G_DELL(tBuffer, sfis, emp);
        case "CARDASSIA":
          return this.verifyFRUA1904G_DELL(tBuffer, sfis, emp);
        case "BASHIR":
          return this.verifyFRUA2003G_DELL(tBuffer, sfis, emp);
        case "PAULI":
          return this.verifyFRUPAULI_DELL(tBuffer, sfis, emp);
        case "HERTZ":
          return this.verifyFRUHERTZ_DELL(tBuffer, sfis, emp);
        case "GAUSS":
          return this.verifyFRUGAUSS_DELL(tBuffer, sfis, emp);
        case "P225ED":
          return this.verifyFRUP225ED_DELL(tBuffer, sfis, emp);
        case "P225EDLP":
          return this.verifyFRUP225EDLP_DELL(tBuffer, sfis, emp);
        case "P225EPD":
          return this.verifyFRUP225EPD_DELL(tBuffer, sfis, emp);
        case "P225EPDLP":
          return this.verifyFRUP225EPDLP_DELL(tBuffer, sfis, emp);
        case "P210ED":
          return this.verifyFRUP210ED_DELL(tBuffer, sfis, emp);
        case "P210EDLP":
          return this.verifyFRUP210EDLP_DELL(tBuffer, sfis, emp);
        case "P210EPD":
          return this.verifyFRUP210EPD_DELL(tBuffer, sfis, emp);
        case "P210EPDLP":
          return this.verifyFRUP210EPDLP_DELL(tBuffer, sfis, emp);
        case "P210TED":
          return this.verifyFRUP210TED_DELL(tBuffer, sfis, emp);
        case "P210TEDLP":
          return this.verifyFRUP210TEDLP_DELL(tBuffer, sfis, emp);
        case "P210TEPD":
          return this.verifyFRUP210TEPD_DELL(tBuffer, sfis, emp);
        case "P210TEPDLP":
          return this.verifyFRUP210TEPDLP_DELL(tBuffer, sfis, emp);
        case "M4161":
          return this.verifyVPDM4161_Lenovo(tBuffer, sfis, emp);
        case "M150PM":
          return this.verifyFRUM150PM_FB(tBuffer, sfis, emp);
        default:
          return false;
      }
    }

    public bool verifyFRUA1913G(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          string str2 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          int macCount = soteDiag.soteDiag.mac_count;
          string[] array = new string[macCount];
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[0] = stringBuilder3.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) array[0]);
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[1] = stringBuilder4.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) array[1]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[2] = stringBuilder5.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) array[2]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[3] = stringBuilder6.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) array[3]);
          Array.Sort<string>(array);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(14, 10) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(14, 10) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != array[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUA1913G: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUA1913G: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUA1904G_HP(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          string str2 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          int macCount = soteDiag.soteDiag.mac_count;
          string[] array = new string[macCount];
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[0] = stringBuilder3.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) array[0]);
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[1] = stringBuilder4.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) array[1]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[2] = stringBuilder5.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) array[2]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[3] = stringBuilder6.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) array[3]);
          Array.Sort<string>(array);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(14, 10) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(14, 10) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != array[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUA1904G_HP: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUA1904G_HP: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUBUBBLES_HP(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          string str2 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          int macCount = soteDiag.soteDiag.mac_count;
          string[] array = new string[macCount];
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[0] = stringBuilder3.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) array[0]);
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[1] = stringBuilder4.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) array[1]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[2] = stringBuilder5.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) array[2]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[3] = stringBuilder6.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) array[3]);
          Array.Sort<string>(array);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(14, 10) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(14, 10) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != array[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUBUBBLES_HP: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUBUBBLES_HP: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUCASPIAN(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        string str2 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          str1 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          str2 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(12, 11) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(12, 11) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (this.m_TestMode != 2)
          {
            string str3 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str3);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str3))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUCASPIAN: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUCASPIAN: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUARAL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        string str2 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          str1 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          str2 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(12, 11) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(12, 11) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (this.m_TestMode != 2)
          {
            string str3 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str3);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str3))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUARAL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUARAL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUA2003G_HP(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          string str2 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder3.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder4.ToString();
          str1 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str4 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(14, 10) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(14, 10) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str4 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str5 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str5);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str5))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUA2003G_HP: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRU2003G_HP: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUBOAR_HP(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          string str2 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder3.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder4.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[2] = stringBuilder5.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) strArray[2]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[3] = stringBuilder6.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) strArray[3]);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(14, 10) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(14, 10) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUBOAR_HP: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUBOAR_HP: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUBANDICOOT_HP(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          string str2 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder3.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder4.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[2] = stringBuilder5.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) strArray[2]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[3] = stringBuilder6.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) strArray[3]);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(14, 10) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(14, 10) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUBANDICOOT_HP: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUBANDICOOT_HP: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUBOBCAT_HP(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          string str2 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder3.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder4.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[2] = stringBuilder5.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) strArray[2]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[3] = stringBuilder6.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) strArray[3]);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(14, 10) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(14, 10) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUBOBCAT_HP: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUBOBCAT_HP: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUBOBOLINK_HP(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          string str2 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder3.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder4.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[2] = stringBuilder5.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) strArray[2]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[3] = stringBuilder6.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) strArray[3]);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(14, 10) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(14, 10) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUBOBOLINK_HP: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUBOBOLINK_HP: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUM150PM_FB(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        string str2 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr1 = soteDiag.soteDiag.sn_addr1; snAddr1 < soteDiag.soteDiag.sn_addr1 + soteDiag.soteDiag.sn_len; ++snAddr1)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr1]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr2 = soteDiag.soteDiag.sn_addr2; snAddr2 < soteDiag.soteDiag.sn_addr2 + soteDiag.soteDiag.sn_len; ++snAddr2)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr2]));
          str1 = string.Format(" Stored Label(1): {0}\n", (object) stringBuilder1.ToString()) + string.Format(" Stored Label(2): {0}\n", (object) stringBuilder2.ToString());
          str2 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(0, 16) != stringBuilder1.ToString() || clsUUT.scanLabel.Substring(0, 16) != stringBuilder2.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (this.m_TestMode != 2)
          {
            string str3 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str3);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str3))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUM150PM_FB: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUM150PM_FB: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public static bool CompareFiles(string fileName1, string fileName2)
    {
      FileInfo fileInfo1 = new FileInfo(fileName1);
      FileInfo fileInfo2 = new FileInfo(fileName2);
      bool flag = fileInfo1.Length == fileInfo2.Length;
      if (flag)
      {
        using (FileStream fileStream1 = fileInfo1.OpenRead())
        {
          using (FileStream fileStream2 = fileInfo2.OpenRead())
          {
            using (BufferedStream bufferedStream1 = new BufferedStream((Stream) fileStream1))
            {
              using (BufferedStream bufferedStream2 = new BufferedStream((Stream) fileStream2))
              {
                for (long index = 0; index < fileInfo1.Length; ++index)
                {
                  if (bufferedStream1.ReadByte() != bufferedStream2.ReadByte())
                  {
                    flag = false;
                    break;
                  }
                }
              }
            }
          }
        }
      }
      return flag;
    }

    public bool verifyFRUM2004G_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] array = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) array[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[1] = stringBuilder5.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) array[1]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[2] = stringBuilder6.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) array[2]);
          StringBuilder stringBuilder7 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder7.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[3] = stringBuilder7.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) array[3]);
          Array.Sort<string>(array);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != array[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUM2004G_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUM2004G_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUN2004_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        string str2 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          str1 = string.Format(" Stored Label: {0}\n", (object) upper);
          str2 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (this.m_TestMode != 2)
          {
            string str3 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str3);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str3))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUN2004_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUMN2004_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUAD2000DC_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] array = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) array[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[1] = stringBuilder5.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) array[1]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[2] = stringBuilder6.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) array[2]);
          StringBuilder stringBuilder7 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder7.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[3] = stringBuilder7.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) array[3]);
          Array.Sort<string>(array);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != array[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUAD2000DC_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUAD2000DC_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUA1905G_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] array = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) array[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[1] = stringBuilder5.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) array[1]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[2] = stringBuilder6.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) array[2]);
          StringBuilder stringBuilder7 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder7.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[3] = stringBuilder7.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) array[3]);
          Array.Sort<string>(array);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != array[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUA1905G_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUA1905G_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUA1904G_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] array = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) array[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[1] = stringBuilder5.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) array[1]);
          StringBuilder stringBuilder6 = new StringBuilder(12);
          int macAddr3 = soteDiag.soteDiag.mac_addr3;
          for (int index = macAddr3; index < macAddr3 + 6; ++index)
            stringBuilder6.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[2] = stringBuilder6.ToString();
          string str5 = str4 + string.Format("         MAC{0}: {1}\n", (object) 2, (object) array[2]);
          StringBuilder stringBuilder7 = new StringBuilder(12);
          int macAddr4 = soteDiag.soteDiag.mac_addr4;
          for (int index = macAddr4; index < macAddr4 + 6; ++index)
            stringBuilder7.AppendFormat("{0:X2}", (object) tBuffer[index]);
          array[3] = stringBuilder7.ToString();
          str1 = str5 + string.Format("         MAC{0}: {1}\n", (object) 3, (object) array[3]);
          Array.Sort<string>(array);
          string str6 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str6 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != array[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str7 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str7);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str7))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUA1904G_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUA1904G_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUA2003G_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder5.ToString();
          str1 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str4 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str4 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str5 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str5);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str5))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUA2003G_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUA2003G_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP225ED_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder5.ToString();
          str1 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str4 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str4 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str5 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str5);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str5))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP225ED_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP225ED_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP225EDLP_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder5.ToString();
          str1 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str4 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str4 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str5 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str5);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str5))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP225EDLP_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP225EDLP_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP210ED_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder5.ToString();
          str1 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str4 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str4 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str5 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str5);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str5))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP210ED_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP210ED_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP210EDLP_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder5.ToString();
          str1 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str4 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str4 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str5 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str5);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str5))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP210EDLP_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP210EDLP_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP210TED_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder5.ToString();
          str1 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str4 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str4 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str5 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str5);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str5))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP210TED_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP210TED_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP210TEDLP_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          int macCount = soteDiag.soteDiag.mac_count;
          string[] strArray = new string[macCount];
          StringBuilder stringBuilder4 = new StringBuilder(12);
          int macAddr1 = soteDiag.soteDiag.mac_addr1;
          for (int index = macAddr1; index < macAddr1 + 6; ++index)
            stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder4.ToString();
          string str3 = str2 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder5 = new StringBuilder(12);
          int macAddr2 = soteDiag.soteDiag.mac_addr2;
          for (int index = macAddr2; index < macAddr2 + 6; ++index)
            stringBuilder5.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder5.ToString();
          str1 = str3 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str4 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], macCount, 1);
            for (int index = 0; index < macCount; ++index)
            {
              str4 += string.Format("         MAC{0}: {1}\n", (object) index, (object) clsUUT.scanMAC[index]);
              if (clsUUT.scanMAC[index] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str5 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str5);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str5))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP210TEDLP_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP210TEDLP_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP225EPD_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if ((index == 0 || index == 8) && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP225EPD_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP225EPD_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP225EPDLP_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if ((index == 0 || index == 8) && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP225EPDLP_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP225EPDLP_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP210EPD_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if ((index == 0 || index == 8) && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP210EPD_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP210EPD_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP210EPDLP_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if ((index == 0 || index == 8) && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP210EPDLP_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP210EPDLP_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP210TEPD_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if ((index == 0 || index == 8) && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP210TEPD_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP210TEPD_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUP210TEPDLP_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if ((index == 0 || index == 8) && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUP210TEPDLP_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUP210TEPDLP_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUPAULI_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if (index == 0 && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUPAULI_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUPAULI_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUHERTZ_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if ((index == 0 || index == 8) && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUHERTZ_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUHERTZ_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyFRUGAUSS_DELL(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.pn_len * 2);
          for (int pnAddr = soteDiag.soteDiag.pn_addr; pnAddr < soteDiag.soteDiag.pn_addr + soteDiag.soteDiag.pn_len; ++pnAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[pnAddr]));
          StringBuilder stringBuilder2 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder2.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          StringBuilder stringBuilder3 = new StringBuilder(soteDiag.soteDiag.hi_sn_len * 2);
          for (int hiSnAddr = soteDiag.soteDiag.hi_sn_addr; hiSnAddr < soteDiag.soteDiag.hi_sn_addr + soteDiag.soteDiag.hi_sn_len; ++hiSnAddr)
            stringBuilder3.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[hiSnAddr]));
          string upper = (stringBuilder2.ToString().Trim() + stringBuilder1.ToString().Substring(0, 6) + stringBuilder3.ToString().Trim() + stringBuilder1.ToString().Substring(6, 3)).ToUpper();
          string str2 = string.Format(" Stored Label: {0}\n", (object) upper);
          string[] strArray = new string[soteDiag.soteDiag.mac_count * 24];
          for (int index1 = 0; index1 < 24; ++index1)
          {
            StringBuilder stringBuilder4 = new StringBuilder(12);
            int num = soteDiag.soteDiag.mac_addr1 + index1 * 20;
            for (int index2 = num; index2 < num + 6; ++index2)
              stringBuilder4.AppendFormat("{0:X2}", (object) tBuffer[index2]);
            strArray[index1] = stringBuilder4.ToString();
            switch (index1)
            {
              case 8:
              case 11:
              case 14:
              case 17:
              case 20:
              case 23:
                str2 += string.Format("{1}", (object) index1, (object) strArray[index1]);
                break;
              case 9:
              case 12:
              case 15:
              case 18:
              case 21:
                str2 += string.Format("  {1}", (object) index1, (object) strArray[index1]);
                break;
              case 10:
              case 13:
              case 16:
              case 19:
              case 22:
                str2 += string.Format("  {1}\n", (object) index1, (object) strArray[index1]);
                break;
            }
          }
          string str3 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel != soteDiag.soteDiag.label_prefix + upper)
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PPID label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            for (int index = 0; index < 24; ++index)
            {
              str3 += string.Format("MAC{0}: {1}", (object) index, (object) clsUUT.scanMAC[0]);
              if (index == 0 && clsUUT.scanMAC[0] != strArray[index])
              {
                this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
                this.m_iFRUVerifyErrorCode = 6000;
                return false;
              }
            }
          }
          if (this.m_TestMode != 2)
          {
            string str4 = "FRUVerifyFile.bin";
            FileUtil.WriteBinaryFile(tBuffer, str4);
            if (!soteDiag.soteDiag.FileEquals(this.logDir + this.m_ProgramFRUFileName, str4))
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:FAIL";
              this.m_iFRUVerifyErrorCode = 6000;
              flag = false;
            }
            else
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
              this.m_iFRUVerifyErrorCode = 0;
            }
          }
          else
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
            this.m_iFRUVerifyErrorCode = 0;
          }
          return flag;
        }
        str1 = "CANNOT READ I2C FRU DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyFRUGAUSS_DELL: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyFRUGAUSS_DELL: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool verifyVPDM4161_Lenovo(byte[] tBuffer, bool sfis, string emp)
    {
      try
      {
        string str1 = "";
        string str2 = "";
        bool flag = true;
        if (tBuffer != null)
        {
          StringBuilder stringBuilder1 = new StringBuilder(soteDiag.soteDiag.sn_len * 2);
          for (int snAddr = soteDiag.soteDiag.sn_addr; snAddr < soteDiag.soteDiag.sn_addr + soteDiag.soteDiag.sn_len; ++snAddr)
            stringBuilder1.AppendFormat("{0}", (object) Convert.ToChar(tBuffer[snAddr]));
          string str3 = string.Format(" Stored Label: {0}\n", (object) stringBuilder1.ToString());
          int count = soteDiag.soteDiag.mac_count + 1;
          string[] strArray = new string[count];
          StringBuilder stringBuilder2 = new StringBuilder(12);
          int macAddr = soteDiag.soteDiag.mac_addr;
          for (int index = macAddr; index < macAddr + 6; ++index)
            stringBuilder2.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[0] = stringBuilder2.ToString();
          string str4 = str3 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) strArray[0]);
          StringBuilder stringBuilder3 = new StringBuilder(12);
          int num1 = soteDiag.soteDiag.mac_addr + 6;
          for (int index = num1; index < num1 + 6; ++index)
            stringBuilder3.AppendFormat("{0:X2}", (object) tBuffer[index]);
          strArray[1] = stringBuilder3.ToString();
          str1 = str4 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) strArray[1]);
          string str5 = string.Format("Scanned Label: {0}\n", (object) clsUUT.scanLabel);
          if (clsUUT.scanLabel.Substring(12, 11) != stringBuilder1.ToString())
          {
            this.m_FRUVerifyErrorDescription = "FRUVerify:SN label doesn't match!";
            this.m_iFRUVerifyErrorCode = 6000;
            return false;
          }
          if (clsUUT.scanMAC != null)
          {
            soteDiag.soteDiag.maclist(clsUUT.scanMAC[0], count, 1);
            string str6 = str5 + string.Format("         MAC{0}: {1}\n", (object) 0, (object) clsUUT.scanMAC[0]);
            if (clsUUT.scanMAC[0] != strArray[0])
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
              this.m_iFRUVerifyErrorCode = 6000;
              return false;
            }
            int num2 = Convert.ToInt32(clsUUT.scanMAC[0].Substring(6, 6), 16) + 1;
            string str7 = clsUUT.scanMAC[0].Substring(0, 6) + num2.ToString("X6");
            str2 = str6 + string.Format("         MAC{0}: {1}\n", (object) 1, (object) str7);
            if (str7 != strArray[1])
            {
              this.m_FRUVerifyErrorDescription = "FRUVerify:MAC address doesn't match!";
              this.m_iFRUVerifyErrorCode = 6000;
              return false;
            }
          }
          this.m_FRUVerifyErrorDescription = "FRUVerify:PASS";
          this.m_iFRUVerifyErrorCode = 0;
          return flag;
        }
        str1 = "CANNOT READ I2C VPD DEVICE";
        this.m_FRUVerifyErrorDescription = "FRUVerify:CANNOT READ DEVICE!";
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
      catch (Exception ex)
      {
        soteDiag.soteDiag.showFailMsgDlg("verifyVPDM4161_Lenovo: EXCEPTION encountered!\n\n" + ex.Message);
        soteDiag.soteDiag soteDiag = this;
        soteDiag.m_results = soteDiag.m_results + "verifyVPDM4161_Lenovo: EXCEPTION encountered!\r\n " + ex.Message;
        this.m_FRUVerifyErrorDescription = "EXCEPTION: " + ex.Message;
        this.m_iFRUVerifyErrorCode = 6000;
        return false;
      }
    }

    public bool readBuffer(int vpd, string device, byte[] tBuffer, int comport)
    {
      if (clsUUT.hw_type == "MUSTANG" || clsUUT.hw_type == "M4161" || (clsUUT.hw_type == "BOERNE" || clsUUT.hw_type == "PUTNAM") || (clsUUT.hw_type == "WOODVILLE" || clsUUT.hw_type == "BANDICOOT" || (clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BOBOLINK")) || (clsUUT.hw_type == "BOAR" || clsUUT.hw_type == "BUBBLES" || (clsUUT.hw_type == "CASPIAN" || clsUUT.hw_type == "N2004")) || clsUUT.hw_type == "ARAL")
      {
        ulong uint32 = (ulong) Convert.ToUInt32(IniFile.GetProfile("FRU SETUP", "VPD" + vpd.ToString(), "0"));
        if (this.I2CAdapterType == "DLN-2")
        {
          if (DiolanU2C.DLN2Init(uint32) == 0 || !DiolanU2C.DLN2Read((byte) 80, device, tBuffer, (byte) 2))
            return false;
          DiolanU2C.DLN2Close();
        }
        else
        {
          if (DiolanU2C.DiolanInit(uint32) == 0 || !DiolanU2C.DiolanRead((byte) 80, device, tBuffer))
            return false;
          DiolanU2C.DiolanClose();
        }
      }
      else if (clsUUT.hw_type == "M150PM")
      {
        ulong uint32 = (ulong) Convert.ToUInt32(IniFile.GetProfile("FRU SETUP", "VPD" + vpd.ToString(), "0"));
        if (this.I2CAdapterType == "DLN-2")
        {
          if (DiolanU2C.DLN2Init(uint32) == 0 || !DiolanU2C.DLN2Read((byte) 81, device, tBuffer, (byte) 1) || !DiolanU2C.DLN2Read((byte) 80, device, this.tBufferFBRead, (byte) 1))
            return false;
          DiolanU2C.DLN2Close();
        }
        else
        {
          if (DiolanU2C.DiolanInit(uint32) == 0 || !DiolanU2C.DiolanRead((byte) 82, device, tBuffer))
            return false;
          DiolanU2C.DiolanClose();
        }
      }
      else
      {
        if (clsUUT.hw_type == "OBRIEN" && this.I2CAdapterType == "013P0V")
        {
          string str1 = "tmpReadFRUFile.txt";
          bool flag = this.readDellFRUProgrammer(comport, str1);
          if (flag)
          {
            TextReader textReader = (TextReader) new StreamReader((Stream) new FileStream(str1, FileMode.Open));
            string str2;
            while ((str2 = textReader.ReadLine()) != null)
            {
              for (int index = 0; index < str2.Length / 2; ++index)
                tBuffer[index] = Convert.ToByte(Convert.ToChar(int.Parse(str2.Substring(index * 2, 2), NumberStyles.HexNumber)));
            }
          }
          return flag;
        }
        if (clsUUT.hw_type == "CORAK" || clsUUT.hw_type == "BASHIR" || (clsUUT.hw_type == "CARDASSIA" || clsUUT.hw_type == "GAMMA") || (clsUUT.hw_type == "OBRIEN" || clsUUT.hw_type == "P225ED" || (clsUUT.hw_type == "P225EPD" || clsUUT.hw_type == "P210ED")) || (clsUUT.hw_type == "P210EPD" || clsUUT.hw_type == "P210TED" || (clsUUT.hw_type == "P210TEPD" || clsUUT.hw_type == "P225EDLP") || (clsUUT.hw_type == "P225EPDLP" || clsUUT.hw_type == "P210EDLP" || (clsUUT.hw_type == "P210EPDLP" || clsUUT.hw_type == "P210TEDLP"))) || (clsUUT.hw_type == "P210TEPDLP" || clsUUT.hw_type == "PAULI" || clsUUT.hw_type == "HERTZ") || clsUUT.hw_type == "GAUSS")
        {
          if (this.I2CAdapterType == "A3BU")
          {
            if (!this.writeXplain(1, new byte[1]
            {
              (byte) 19
            }, 0, 1, 0, 7, 94, comport))
              return false;
            if (vpd == 3)
            {
              byte[] outbuff = new byte[32];
              this.readXplain(32, 2, 0, 0, 94, comport, out outbuff);
              if (outbuff == null)
                return false;
              tBuffer[0] = outbuff[0];
            }
            else
            {
              byte[] outbuff = new byte[32];
              for (int index1 = 0; index1 < tBuffer.Length; index1 += 32)
              {
                int hiAddr = index1 >> 8 & (int) byte.MaxValue;
                int loAddr = index1 & (int) byte.MaxValue;
                this.readXplain(tBuffer.Length - index1 < 32 ? tBuffer.Length - index1 : 32, 2, hiAddr, loAddr, 82, comport, out outbuff);
                if (outbuff == null)
                  return false;
                for (int index2 = 0; index2 < 32; ++index2)
                  tBuffer[index1 / 32 * 32 + index2] = outbuff[index2];
              }
            }
          }
          else if (this.I2CAdapterType == "DLN-2")
          {
            ulong uint32 = (ulong) Convert.ToUInt32(IniFile.GetProfile("FRU SETUP", "VPD" + vpd.ToString(), "0"));
            Thread.Sleep(5000);
            if (DiolanU2C.DLN2InitDell(uint32) == 0 || !DiolanU2C.DLN2WriteByte((byte) 94, 7, (byte) 19, (byte) 1))
              return false;
            if (vpd == 3)
            {
              byte[] tbuffer = new byte[32];
              if (!DiolanU2C.DLN2Read((byte) 94, device, tbuffer, (byte) 2) || tbuffer == null)
                return false;
              tBuffer[0] = tbuffer[0];
            }
            else if (!DiolanU2C.DLN2Read((byte) 82, device, tBuffer, (byte) 2))
              return false;
            DiolanU2C.DLN2Close();
          }
        }
        else
        {
          ulong uint32 = (ulong) Convert.ToUInt32(IniFile.GetProfile("FRU SETUP", "VPD" + vpd.ToString(), "0"));
          if (this.I2CAdapterType == "DLN-2")
          {
            if (DiolanU2C.DLN2Init(uint32) == 0 || !DiolanU2C.DLN2Read(device, tBuffer, (byte) 2))
              return false;
            DiolanU2C.DLN2Close();
          }
          else
          {
            if (DiolanU2C.DiolanInit(uint32) == 0 || !DiolanU2C.DiolanRead(device, tBuffer))
              return false;
            DiolanU2C.DiolanClose();
          }
        }
      }
      return true;
    }

    public static string ByteArrayToString(byte[] ba)
    {
      StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
      foreach (byte num in ba)
        stringBuilder.AppendFormat("{0:x2}", (object) num);
      return stringBuilder.ToString();
    }

    public bool writeBuffer(int vpd, string device, byte[] tBuffer, int comport)
    {
      if (clsUUT.hw_type == "MUSTANG" || clsUUT.hw_type == "M4161" || (clsUUT.hw_type == "BOERNE" || clsUUT.hw_type == "PUTNAM") || (clsUUT.hw_type == "WOODVILLE" || clsUUT.hw_type == "BANDICOOT" || (clsUUT.hw_type == "BOBCAT" || clsUUT.hw_type == "BOBOLINK")) || (clsUUT.hw_type == "BOAR" || clsUUT.hw_type == "BUBBLES" || (clsUUT.hw_type == "CASPIAN" || clsUUT.hw_type == "N2004")) || clsUUT.hw_type == "ARAL")
      {
        ulong uint32 = (ulong) Convert.ToUInt32(IniFile.GetProfile("FRU SETUP", "VPD" + vpd.ToString(), "0"));
        if (this.I2CAdapterType == "DLN-2")
        {
          if (DiolanU2C.DLN2Init(uint32) == 0 || !DiolanU2C.DLN2Write((byte) 80, device, tBuffer, (byte) 2))
            return false;
          DiolanU2C.DLN2Close();
        }
        else
        {
          if (DiolanU2C.DiolanInit(uint32) == 0 || !DiolanU2C.DiolanWrite((byte) 80, device, tBuffer))
            return false;
          DiolanU2C.DiolanClose();
        }
      }
      else if (clsUUT.hw_type == "M150PM")
      {
        ulong uint32 = (ulong) Convert.ToUInt32(IniFile.GetProfile("FRU SETUP", "VPD" + vpd.ToString(), "0"));
        if (this.I2CAdapterType == "DLN-2")
        {
          Thread.Sleep(5000);
          if (DiolanU2C.DLN2Init(uint32) == 0 || !DiolanU2C.DLN2Write((byte) 81, device, tBuffer, (byte) 1))
            return false;
          byte[] tbuffer = new byte[256];
          for (int index = 0; index < 256; ++index)
            tbuffer[index] = (byte) 0;
          if (!DiolanU2C.DLN2Write((byte) 80, device, tbuffer, (byte) 1))
            return false;
          DiolanU2C.DLN2Close();
        }
        else
        {
          if (DiolanU2C.DiolanInit(uint32) == 0 || !DiolanU2C.DiolanWrite((byte) 82, device, tBuffer))
            return false;
          DiolanU2C.DiolanClose();
        }
      }
      else
      {
        if (clsUUT.hw_type == "OBRIEN" && this.I2CAdapterType == "013P0V")
          return this.writeDellFRUProgrammer(comport, soteDiag.soteDiag.text_template);
        if (clsUUT.hw_type == "CORAK" || clsUUT.hw_type == "BASHIR" || (clsUUT.hw_type == "CARDASSIA" || clsUUT.hw_type == "GAMMA") || (clsUUT.hw_type == "OBRIEN" || clsUUT.hw_type == "P225ED" || (clsUUT.hw_type == "P225EPD" || clsUUT.hw_type == "P210ED")) || (clsUUT.hw_type == "P210EPD" || clsUUT.hw_type == "P210TED" || (clsUUT.hw_type == "P210TEPD" || clsUUT.hw_type == "P225EDLP") || (clsUUT.hw_type == "P225EPDLP" || clsUUT.hw_type == "P210EDLP" || (clsUUT.hw_type == "P210EPDLP" || clsUUT.hw_type == "P210TEDLP"))) || (clsUUT.hw_type == "P210TEPDLP" || clsUUT.hw_type == "PAULI" || clsUUT.hw_type == "HERTZ") || clsUUT.hw_type == "GAUSS")
        {
          if (this.I2CAdapterType == "A3BU")
          {
            byte[] buffer = new byte[1]{ (byte) 19 };
            if (!this.writeXplain(1, buffer, 0, 1, 0, 7, 94, comport))
              return false;
            buffer[0] = (byte) 27;
            if (!this.writeXplain(1, buffer, 0, 2, 0, 7, 94, comport))
              return false;
            buffer[0] = soteDiag.soteDiag.register_06_value;
            if (!this.writeXplain(1, buffer, 0, 2, 0, 6, 94, comport))
              return false;
            buffer[0] = (byte) 27;
            if (!this.writeXplain(1, buffer, 0, 2, 0, 7, 94, comport))
              return false;
            buffer[0] = soteDiag.soteDiag.register_0E_value;
            if (!this.writeXplain(1, buffer, 0, 2, 0, 14, 94, comport))
              return false;
            if (clsUUT.hw_type == "P225ED" || clsUUT.hw_type == "P225EPD" || (clsUUT.hw_type == "P210ED" || clsUUT.hw_type == "P210EPD") || (clsUUT.hw_type == "P210TED" || clsUUT.hw_type == "P210TEPD" || (clsUUT.hw_type == "P225EDLP" || clsUUT.hw_type == "P225EPDLP")) || (clsUUT.hw_type == "P210EDLP" || clsUUT.hw_type == "P210EPDLP" || (clsUUT.hw_type == "P210TEDLP" || clsUUT.hw_type == "P210TEPDLP") || (clsUUT.hw_type == "PAULI" || clsUUT.hw_type == "HERTZ")) || clsUUT.hw_type == "GAUSS")
            {
              buffer[0] = (byte) 27;
              if (!this.writeXplain(1, buffer, 0, 2, 0, 7, 94, comport))
                return false;
              buffer[0] = soteDiag.soteDiag.register_6D_value;
              if (!this.writeXplain(1, buffer, 0, 2, 0, 109, 94, comport))
                return false;
            }
            byte[] outbuff = new byte[32];
            this.readXplain(32, 2, 0, 0, 94, comport, out outbuff);
            if (outbuff == null)
              return false;
            if ((int) outbuff[6] != (int) soteDiag.soteDiag.register_06_value)
            {
              soteDiag.soteDiag.showFailMsgDlg("Invalid value in internal temperature\noffset register 0x06: " + (object) outbuff[6]);
              return false;
            }
            if ((int) outbuff[14] != (int) soteDiag.soteDiag.register_0E_value)
            {
              soteDiag.soteDiag.showFailMsgDlg("Invalid value in internal temperature\noffset register 0x0E: " + (object) outbuff[14]);
              return false;
            }
            if (clsUUT.hw_type == "P225ED" || clsUUT.hw_type == "P225EPD" || (clsUUT.hw_type == "P210ED" || clsUUT.hw_type == "P210EPD") || (clsUUT.hw_type == "P210TED" || clsUUT.hw_type == "P210TEPD" || (clsUUT.hw_type == "P225EDLP" || clsUUT.hw_type == "P225EPDLP")) || (clsUUT.hw_type == "P210EDLP" || clsUUT.hw_type == "P210EPDLP" || (clsUUT.hw_type == "P210TEDLP" || clsUUT.hw_type == "P210TEPDLP") || (clsUUT.hw_type == "PAULI" || clsUUT.hw_type == "HERTZ")) || clsUUT.hw_type == "GAUSS")
            {
              this.readXplain(32, 2, 0, 96, 94, comport, out outbuff);
              if (outbuff == null)
                return false;
              if ((int) outbuff[13] != (int) soteDiag.soteDiag.register_6D_value)
              {
                soteDiag.soteDiag.showFailMsgDlg("Invalid value in TFRU profile register 0x6D: " + (object) outbuff[13]);
                return false;
              }
            }
            for (int buffOffset = 0; buffOffset < tBuffer.Length; buffOffset += 16)
            {
              int hiAddr = buffOffset >> 8 & (int) byte.MaxValue;
              int loAddr = buffOffset & (int) byte.MaxValue;
              if (!this.writeXplain(tBuffer.Length - buffOffset < 16 ? tBuffer.Length - buffOffset : 16, tBuffer, buffOffset, 2, hiAddr, loAddr, 82, comport))
                return false;
            }
            this.clearQueue();
          }
          else if (this.I2CAdapterType == "DLN-2")
          {
            ulong uint32 = (ulong) Convert.ToUInt32(IniFile.GetProfile("FRU SETUP", "VPD" + vpd.ToString(), "0"));
            Thread.Sleep(5000);
            if (DiolanU2C.DLN2InitDell(uint32) == 0 || !DiolanU2C.DLN2WriteByte((byte) 94, 7, (byte) 19, (byte) 1) || (!DiolanU2C.DLN2WriteByte((byte) 94, 7, (byte) 27, (byte) 2) || !DiolanU2C.DLN2WriteByte((byte) 94, 6, soteDiag.soteDiag.register_06_value, (byte) 2)) || (!DiolanU2C.DLN2WriteByte((byte) 94, 7, (byte) 27, (byte) 2) || !DiolanU2C.DLN2WriteByte((byte) 94, 14, soteDiag.soteDiag.register_0E_value, (byte) 2)) || (clsUUT.hw_type == "P225ED" || clsUUT.hw_type == "P225EPD" || (clsUUT.hw_type == "P210ED" || clsUUT.hw_type == "P210EPD") || (clsUUT.hw_type == "P210TED" || clsUUT.hw_type == "P210TEPD" || (clsUUT.hw_type == "P225EDLP" || clsUUT.hw_type == "P225EPDLP")) || (clsUUT.hw_type == "P210EDLP" || clsUUT.hw_type == "P210EPDLP" || (clsUUT.hw_type == "P210TEDLP" || clsUUT.hw_type == "P210TEPDLP") || (clsUUT.hw_type == "PAULI" || clsUUT.hw_type == "HERTZ")) || clsUUT.hw_type == "GAUSS") && (!DiolanU2C.DLN2WriteByte((byte) 94, 7, (byte) 27, (byte) 2) || !DiolanU2C.DLN2WriteByte((byte) 94, 109, soteDiag.soteDiag.register_6D_value, (byte) 2)))
              return false;
            byte[] tbuffer = new byte[256];
            if (!DiolanU2C.DLN2Read((byte) 94, device, tbuffer, (byte) 2) || tbuffer == null)
              return false;
            if ((int) tbuffer[6] != (int) soteDiag.soteDiag.register_06_value)
            {
              soteDiag.soteDiag.showFailMsgDlg("Invalid value in internal temperature\noffset register 0x06: " + (object) tbuffer[6]);
              return false;
            }
            if ((int) tbuffer[14] != (int) soteDiag.soteDiag.register_0E_value)
            {
              soteDiag.soteDiag.showFailMsgDlg("Invalid value in internal temperature\noffset register 0x0E: " + (object) tbuffer[14]);
              return false;
            }
            if ((clsUUT.hw_type == "P225ED" || clsUUT.hw_type == "P225EPD" || (clsUUT.hw_type == "P210ED" || clsUUT.hw_type == "P210EPD") || (clsUUT.hw_type == "P210TED" || clsUUT.hw_type == "P210TEPD" || (clsUUT.hw_type == "P225EDLP" || clsUUT.hw_type == "P225EPDLP")) || (clsUUT.hw_type == "P210EDLP" || clsUUT.hw_type == "P210EPDLP" || (clsUUT.hw_type == "P210TEDLP" || clsUUT.hw_type == "P210TEPDLP") || (clsUUT.hw_type == "PAULI" || clsUUT.hw_type == "HERTZ")) || clsUUT.hw_type == "GAUSS") && (int) tbuffer[109] != (int) soteDiag.soteDiag.register_6D_value)
            {
              soteDiag.soteDiag.showFailMsgDlg("Invalid value in TFRU profile register 0x6D: " + (object) tbuffer[109]);
              return false;
            }
            if (!DiolanU2C.DLN2Write((byte) 82, device, tBuffer, (byte) 2))
              return false;
            DiolanU2C.DLN2Close();
          }
        }
        else
        {
          ulong uint32 = (ulong) Convert.ToUInt32(IniFile.GetProfile("FRU SETUP", "VPD" + vpd.ToString(), "0"));
          if (this.I2CAdapterType == "DLN-2")
          {
            if (DiolanU2C.DLN2Init(uint32) == 0 || !DiolanU2C.DLN2Write(device, tBuffer, (byte) 2))
              return false;
            DiolanU2C.DLN2Close();
          }
          else
          {
            if (DiolanU2C.DiolanInit(uint32) == 0 || !DiolanU2C.DiolanWrite(device, tBuffer))
              return false;
            DiolanU2C.DiolanClose();
          }
        }
      }
      return true;
    }

    public void readXplain(
      int nBytes,
      int addrMode,
      int hiAddr,
      int loAddr,
      int slaveID,
      int nComport,
      out byte[] outbuff)
    {
      string command = Application.StartupPath + "\\iicgen";
      string result = "";
      string str1 = "-r " + (object) nBytes + " ";
      string str2;
      if (addrMode == 1)
        str2 = str1 + "-a " + (object) addrMode + " 0x" + string.Format("{0:X2}", (object) loAddr) + " -s 0x" + string.Format("{0:X2}", (object) slaveID) + " -p " + (object) nComport;
      else
        str2 = str1 + "-a " + (object) addrMode + " 0x" + string.Format("{0:X2}", (object) hiAddr) + " 0x" + string.Format("{0:X2}", (object) loAddr) + " -s 0x" + string.Format("{0:X2}", (object) slaveID) + " -p " + (object) nComport;
      for (int index = 3; index > 0; --index)
      {
        this.executeShellCommand(command, str2, out result);
        if (result.Contains("Failed to initialize the COM port"))
          Thread.Sleep(1000);
        else
          break;
      }
      if (result.Contains("Read operation failed!"))
      {
        outbuff = (byte[]) null;
      }
      else
      {
        string str3 = result.Replace("\n", "").Replace("\r", "").Replace("Read operation complete!", "").Replace(" ", "");
        outbuff = new byte[str3.Length / 2];
        int index = 0;
        try
        {
          for (index = 0; index < str3.Length / 2; ++index)
            outbuff[index] = Convert.ToByte(str3.Substring(index * 2, 2), 16);
        }
        catch (FormatException ex)
        {
          File.WriteAllText("read_exception.log", ex.ToString() + Environment.NewLine + Environment.NewLine + ex.StackTrace + Environment.NewLine + Environment.NewLine + "Raise at i = " + (object) index + Environment.NewLine + Environment.NewLine + result);
          throw;
        }
      }
    }

    public bool readDellFRUProgrammer(int nComport, string readFRUFile)
    {
      string str1 = Application.StartupPath + "\\Readfru.bat";
      string args = "";
      string str2 = "";
      bool flag = false;
      this.CreateFRUBatchFile(str1, "read", readFRUFile);
      int num;
      for (num = 0; num < 3; ++num)
      {
        soteUtils.runCmdLine(str1, args, (soteUtils.delegateListener) null, true, true, 20000);
        soteUtils.abortCmdLine();
        try
        {
          foreach (Process process in Process.GetProcessesByName("ndc_fru"))
            process.Kill();
        }
        catch (Exception ex)
        {
          soteDiag.soteDiag soteDiag = this;
          soteDiag.m_results = soteDiag.m_results + "\nreadDellFRUProgrammer: " + ex.Message;
          soteDiag.soteDiag.showFailMsgDlg("readDellFRUProgrammer: \n\nException encountered!");
        }
        str2 = soteUtils.cmdLineOutput.ToString();
        string str3 = "";
        if (str2.Length >= 5)
          str3 = str2.Substring(str2.Length - 5, 4);
        if (str3.Contains("PASS"))
        {
          flag = true;
          break;
        }
        flag = false;
        Thread.Sleep(1000);
      }
      if (!flag)
        File.AppendAllText("ndc_fru_read_error.log", "\r\ntime: " + this.todayNow + "\r\nrety_count: " + (object) num + "\r\ncmdOutputString: " + str2);
      return flag;
    }

    public bool writeXplain(
      int nBytes,
      byte[] buffer,
      int buffOffset,
      int addrMode,
      int hiAddr,
      int loAddr,
      int slaveID,
      int nComport)
    {
      string command = Application.StartupPath + "\\iicgen";
      string result = "";
      string str1 = "-w " + (object) nBytes + " 0x" + string.Format("{0:X2}", (object) buffer[buffOffset]) + " ";
      for (int index = 1; index < nBytes; ++index)
        str1 = str1 + "0x" + string.Format("{0:X2}", (object) buffer[index + buffOffset]) + " ";
      string str2;
      if (addrMode == 1)
        str2 = str1 + "-a " + (object) addrMode + " 0x" + string.Format("{0:X2}", (object) loAddr) + " -s 0x" + string.Format("{0:X2}", (object) slaveID) + " -p " + (object) nComport + " -d 10";
      else
        str2 = str1 + "-a " + (object) addrMode + " 0x" + string.Format("{0:X2}", (object) hiAddr) + " 0x" + string.Format("{0:X2}", (object) loAddr) + " -s 0x" + string.Format("{0:X2}", (object) slaveID) + " -p " + (object) nComport + " -d 10";
      for (int index = 3; index > 0; --index)
      {
        this.executeShellCommand(command, str2, out result);
        if (result.Contains("Failed to initialize the COM port"))
          Thread.Sleep(1000);
        else
          break;
      }
      return result.Contains("Write operation complete!");
    }

    public void CreateFRUBatchFile(string batchfilename, string filetype, string tmpFRUfile)
    {
      string str = (string) null;
      if (filetype == "read")
        str = string.Format("ndc_fru -comport com{0} -dump -file {1}\r\nif errorlevel 1 echo FAIL\r\nif errorlevel 0 echo PASS", (object) this.comPort, (object) tmpFRUfile);
      if (filetype == "write")
        str = string.Format("ndc_fru -comport com{0} -file {1} -ppid {2} -mac {3} -con true\r\nif errorlevel 1 echo FAIL\r\nif errorlevel 0 echo PASS", (object) this.comPort, (object) soteDiag.soteDiag.text_template, (object) clsUUT.scanLabel, (object) clsUUT.scanMAC[0]);
      StreamWriter streamWriter = new StreamWriter(batchfilename);
      streamWriter.WriteLine(str);
      streamWriter.Close();
    }

    private static void m_cbListener(string msg)
    {
      Console.WriteLine("parsing: " + msg);
    }

    public bool writeDellFRUProgrammer(int nComport, string writeFRUTemplate)
    {
      string str1 = Application.StartupPath + "\\Programfru.bat";
      string args = "";
      string str2 = "";
      bool flag = false;
      this.CreateFRUBatchFile(str1, "write", (string) null);
      int num;
      for (num = 0; num < 3; ++num)
      {
        soteUtils.runCmdLine(str1, args, (soteUtils.delegateListener) null, true, true, 90000);
        soteUtils.abortCmdLine();
        try
        {
          foreach (Process process in Process.GetProcessesByName("ndc_fru"))
            process.Kill();
        }
        catch (Exception ex)
        {
          soteDiag.soteDiag soteDiag = this;
          soteDiag.m_results = soteDiag.m_results + "\nwriteDellFRUProgrammer: " + ex.Message;
          soteDiag.soteDiag.showFailMsgDlg("writeDellFRUProgrammer: \n\nException encountered!");
        }
        str2 = soteUtils.cmdLineOutput.ToString();
        string str3 = "";
        if (str2.Length >= 5)
          str3 = str2.Substring(str2.Length - 5, 4);
        if (str3.Contains("PASS"))
        {
          flag = true;
          break;
        }
        flag = false;
        Thread.Sleep(1000);
      }
      if (!flag)
        File.AppendAllText("ndc_fru_write_error.log", "\r\ntime: " + this.todayNow + "\r\nrety_count: " + (object) num + "\r\ncmdOutputString: " + str2);
      return flag;
    }

    public void clearQueue()
    {
      this.executeShellCommand(Application.StartupPath + "\\iicgen", "-x -p 4", out string _);
    }

    public void executeShellCommand(string command, string argument, out string result)
    {
      string str1 = command;
      string str2 = argument;
      Process process = new Process();
      process.StartInfo.FileName = str1;
      process.StartInfo.Arguments = str2;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.Start();
      process.WaitForExit();
      result = process.StandardOutput.ReadToEnd();
      process.Close();
    }

    private void openMonitorConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(soteDiag.soteDiag.appMonitor))
          throw new Exception(2.ToString());
        Process.Start("notepad", soteDiag.soteDiag.appMonitor);
      }
      catch (Exception ex)
      {
        if (ex.Message.Equals(2.ToString()))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.appMonitor);
        }
        else
        {
          if (!ex.Message.Equals((object) 5))
            return;
          soteDiag.soteDiag.showFailMsgDlg("Access denied:\n\n" + soteDiag.soteDiag.appMonitor);
        }
      }
    }

    private void openGoldenSampleConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(soteDiag.soteDiag.appGoldenSample))
          throw new Exception(2.ToString());
        Process.Start("notepad", soteDiag.soteDiag.appGoldenSample);
      }
      catch (Exception ex)
      {
        if (ex.Message.Equals(2.ToString()))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.appGoldenSample);
        }
        else
        {
          if (!ex.Message.Equals((object) 5))
            return;
          soteDiag.soteDiag.showFailMsgDlg("Access denied:\n\n" + soteDiag.soteDiag.appGoldenSample);
        }
      }
    }

    private void ButtonPowerON_Click(object sender, EventArgs e)
    {
      if (this.m_usbrelayenable && this.m_bDUTPCPowerON)
      {
        this.USBRelayON();
        this.USBRelayOFF();
        Thread.Sleep(2000);
        this.USBRelayON();
        this.USBRelayOFF();
        this.m_bDUTPCPowerON = true;
      }
      else if (this.m_usbrelayenable && !this.m_bDUTPCPowerON)
      {
        this.USBRelayON();
        this.USBRelayOFF();
        this.m_bDUTPCPowerON = true;
      }
      else
        this.PowerON();
    }

    private void ButtonPowerOFF_Click(object sender, EventArgs e)
    {
      if (this.m_usbrelayenable && this.m_bDUTPCPowerON)
      {
        this.USBRelayON();
        this.USBRelayOFF();
        this.m_bDUTPCPowerON = false;
      }
      else
        this.PowerOFF();
    }

    private void ButtonBADGE_Click(object sender, EventArgs e)
    {
      int num = (int) new NewMessageBox()
      {
        Message = "Enter EMPLOYEE BADGE!"
      }.ShowDialog();
      this.txtBadge.Enabled = true;
      this.txtBadge.Focus();
      this.txtBadge.Text = "";
    }

    private void chkSFIS_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_bLoadConfig || this.m_bInvalidPassword)
      {
        if (this.m_bLoadConfig)
          this.m_bLoadConfig = !this.m_bLoadConfig;
        if (!this.m_bInvalidPassword)
          return;
        this.m_bInvalidPassword = !this.m_bInvalidPassword;
      }
      else
      {
        frmPassword frmPassword = new frmPassword();
        int num1 = (int) frmPassword.ShowDialog();
        string txtPassword = frmPassword.txtPassword;
        frmPassword.Dispose();
        if (txtPassword != this.m_txtPassword)
        {
          this.m_bInvalidPassword = true;
          int num2 = (int) new NewMessageBox()
          {
            Message = "Invalid Password!"
          }.ShowDialog();
          this.chkSFIS.Checked = !this.chkSFIS.Checked;
        }
        else
        {
          this.m_bInvalidPassword = false;
          if (this.m_sfis_type == 91)
          {
            if (this.chkSFIS.Checked)
              this.m_sfis_enabled = true;
            else
              this.m_sfis_enabled = false;
          }
          else
          {
            if (this.m_sfis_type != 90)
              return;
            this.m_esr_sfis_enabled = this.chkSFIS.Checked;
          }
        }
      }
    }

    private void goldenSampleModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmPassword frmPassword = new frmPassword();
      int num1 = (int) frmPassword.ShowDialog();
      string txtPassword = frmPassword.txtPassword;
      frmPassword.Dispose();
      if (txtPassword != this.m_txtPassword)
      {
        int num2 = (int) new NewMessageBox()
        {
          Message = "Invalid Password!"
        }.ShowDialog();
      }
      else if (this.m_TestMode != 7)
      {
        this.m_TestMode = 7;
        this.m_sTestMode = "GOLDENSAMPLE";
        this.cblblTestMode(this.m_sTestMode);
        this.goldenSampleModeToolStripMenuItem.Checked = true;
      }
      else
      {
        this.m_TestMode = this.m_DefaultTestMode;
        this.m_sTestMode = this.m_sDefaultTestMode;
        this.cblblTestMode(this.m_sTestMode);
        this.goldenSampleModeToolStripMenuItem.Checked = this.m_TestMode == 7;
      }
    }

    public void ProcessDirectory(
      string targetDirectory,
      string duttype,
      string tester,
      string PID)
    {
      foreach (string file in Directory.GetFiles(targetDirectory))
        this.ProcessFile(file, duttype, tester, PID);
      foreach (string directory in Directory.GetDirectories(targetDirectory))
        this.ProcessDirectory(directory, duttype, tester, PID);
    }

    public void ProcessFile(string path, string duttype, string tester, string PID)
    {
      if (path.Contains(".ini"))
      {
        this.copyFile2MappedNetworkDrive(path, this.m_esr_sfis_log_dir + "\\" + tester + "\\" + PID + "\\" + PID + ".ini");
        ++this.m_nTotalIniFileUploaded;
      }
      else
      {
        if (!path.Contains(".pid") && !path.Contains(".rst"))
          return;
        string str1 = this.logDefault + duttype + "-" + tester + "-" + PID + "\\";
        string str2 = !path.Contains(".pid") ? path.Replace(".rst", ".log") : path.Replace(".pid", ".txt");
        int startIndex = str2.LastIndexOf("\\");
        string str3 = str2.Substring(startIndex, str2.Length - startIndex);
        path.Substring(0, str1.Length);
        this.copyFile2MappedNetworkDrive(path, this.m_esr_sfis_log_dir + "\\" + tester + "\\" + PID + "\\" + str3);
        int num = str3.IndexOf("-");
        string serialNo = str3.Substring(1, num - 1);
        if (serialNo != this.m_TestLogSN)
        {
          this.log2SNFile(this.m_TestLogSNFileName, serialNo);
          this.m_TestLogSN = serialNo;
        }
        ++this.m_nTotalFilesUploaded;
      }
    }

    private void uploadTestLogsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.m_TestMode == 10)
        this.m_duttype = "GENERIC";
      frmUploadTestLog frmUploadTestLog = new frmUploadTestLog(this.m_esr_pid, this.m_duttype, this.m_esr_tester);
      int num1 = (int) frmUploadTestLog.ShowDialog();
      this.m_nTotalFilesUploaded = 0;
      this.m_nTotalIniFileUploaded = 0;
      this.m_bUploadTestLog = true;
      if (!frmUploadTestLog.cancel)
      {
        string txtPid = frmUploadTestLog.txtPID;
        string txtDutType = frmUploadTestLog.txtDUTType;
        string txtTester = frmUploadTestLog.txtTester;
        this.m_esr_sfis_log_path = this.m_esr_sfis_log_dir + "\\" + txtTester + "\\" + txtPid;
        this.todayNow = DateTime.Now.ToString(this.customFormatNow);
        this.m_TestLogSNFileName = this.logDefault + txtDutType + "-" + txtTester + "-" + txtPid + "\\" + txtPid + "-SN-" + this.todayNow + ".txt";
        if (!Directory.Exists(this.m_esr_sfis_log_path))
        {
          try
          {
            Directory.CreateDirectory(this.m_esr_sfis_log_path);
          }
          catch (Exception ex)
          {
            soteDiag.soteDiag soteDiag = this;
            soteDiag.m_results = soteDiag.m_results + "\nfrmUploadTestLog: " + ex.Message;
            soteDiag.soteDiag.showFailMsgDlg("frmUploadTestLog: Exception encountered!");
            this.m_bUploadTestLog = false;
          }
        }
        try
        {
          string str = this.logDefault + txtDutType + "-" + txtTester + "-" + txtPid + "\\";
          if (Directory.Exists(str))
          {
            this.ProcessDirectory(str, txtDutType, txtTester, txtPid);
          }
          else
          {
            this.m_bUploadTestLog = false;
            soteDiag.soteDiag.showFailMsgDlg("Log directory not found!\n\n" + str);
            return;
          }
        }
        catch (Exception ex)
        {
          this.m_bUploadTestLog = false;
          soteDiag.soteDiag soteDiag = this;
          soteDiag.m_results = soteDiag.m_results + "\nfrmUploadTestLog: " + ex.Message;
          soteDiag.soteDiag.showFailMsgDlg("frmUploadTestLog: Exception encountered!");
        }
        if (this.m_bUploadTestLog)
        {
          if (this.m_nTotalIniFileUploaded == 0)
          {
            int num2 = (int) new frmFail()
            {
              Message = string.Format("Missing PID .ini file!")
            }.ShowDialog();
          }
          else
          {
            int num3 = (int) new frmPass()
            {
              Message = string.Format("Total of {0} test log(s) uploaded!", (object) this.m_nTotalFilesUploaded)
            }.ShowDialog();
          }
        }
      }
      frmUploadTestLog.Dispose();
      if (this.m_bUploadTestLog)
        return;
      int num4 = (int) new frmFail()
      {
        Message = "Failed to upload test logs!"
      }.ShowDialog();
    }

    private void openRMAConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(soteDiag.soteDiag.appRMAConfig))
          throw new Exception(2.ToString());
        Process.Start("notepad", soteDiag.soteDiag.appRMAConfig);
      }
      catch (Exception ex)
      {
        if (ex.Message.Equals(2.ToString()))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.appRMAConfig);
        }
        else
        {
          if (!ex.Message.Equals((object) 5))
            return;
          soteDiag.soteDiag.showFailMsgDlg("Access denied:\n\n" + soteDiag.soteDiag.appRMAConfig);
        }
      }
    }

    private void openTemperatureCheckConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        if (!File.Exists(soteDiag.soteDiag.appTMPCheckConfig))
          throw new Exception(2.ToString());
        Process.Start("notepad", soteDiag.soteDiag.appTMPCheckConfig);
      }
      catch (Exception ex)
      {
        if (ex.Message.Equals(2.ToString()))
        {
          soteDiag.soteDiag.showFailMsgDlg("File not found:\n\n" + soteDiag.soteDiag.appTMPCheckConfig);
        }
        else
        {
          if (!ex.Message.Equals((object) 5))
            return;
          soteDiag.soteDiag.showFailMsgDlg("Access denied:\n\n" + soteDiag.soteDiag.appTMPCheckConfig);
        }
      }
    }

    private static bool FileEquals(string fileName1, string fileName2)
    {
      using (FileStream fileStream1 = new FileStream(fileName1, FileMode.Open))
      {
        using (FileStream fileStream2 = new FileStream(fileName2, FileMode.Open))
          return soteDiag.soteDiag.FileStreamEquals((Stream) fileStream1, (Stream) fileStream2);
      }
    }

    private static bool FileStreamEquals(Stream stream1, Stream stream2)
    {
      byte[] buffer1 = new byte[4096];
      byte[] buffer2 = new byte[4096];
      int count1;
      int count2;
      do
      {
        count1 = stream1.Read(buffer1, 0, 4096);
        count2 = stream2.Read(buffer2, 0, 4096);
        if (count1 == count2)
        {
          if (count1 == 0)
            goto label_3;
        }
        else
          goto label_1;
      }
      while (((IEnumerable<byte>) buffer1).Take<byte>(count1).SequenceEqual<byte>(((IEnumerable<byte>) buffer2).Take<byte>(count2)));
      goto label_5;
label_1:
      return false;
label_3:
      return true;
label_5:
      return false;
    }

    public delegate void DisposeEventDelegate(object sender, EventArgs e);

    public delegate void delegateSerialRead(string msg);

    public delegate void delegateSerialWrite(string msg);

    public delegate void delegategroupTest(bool enable);

    public delegate void delegatebtnOK(bool enable);

    public delegate void delegategoldenSampleModeToolStripMenuItem(bool enable);

    public delegate void delegatetxtBadge(bool enable);

    public delegate void delegatetxtLabel(bool enable);

    public delegate void delegatetxtMAC(bool enable);

    public delegate void delegateUUTGroup(bool enable);

    public delegate void delegateChkSFIS(bool enable);

    public delegate void delegateButtonPowerON(bool enable);

    public delegate void delegateButtonPowerOFF(bool enable);

    public delegate void delegateButtonBADGE(bool enable);

    private delegate void delegatecbProgressBar(ProgressChangedEventArgs e);

    private delegate void delegatecbSetProgressBarMaximum(int max);

    private delegate void delegatecbDisableProgressBar();

    public delegate void UserAbortDelegate(object sender, EventArgs e);

    public delegate void delegateAbort();

    public delegate void delegateTerminal(string msg);

    public delegate void delegateUUTLabelFocus();

    public delegate void delegateStatusColor(Color c);

    public delegate void delegateStatusText(string msg);

    public delegate void delegatelblTestTime(string msg);

    public delegate void delegatelblTestMode(string msg);

    public delegate void delegatelblTestYield(string msg);

    public delegate void delegatetextTestJig(string msg);

    public delegate void delegatetextTestJigColor(Color foreColor, Color backColor);

    public delegate void delegatetextTestJigWA(string msg);

    public delegate void delegatetextTestJigWAColor(Color foreColor, Color backColor);

    public delegate void delegatetextBIE(string msg);

    public delegate void delegatetextBIEColor(Color foreColor, Color backColor);

    public delegate void delegatetextRiserCard(string msg);

    public delegate void delegatetextRiserCardColor(Color foreColor, Color backColor);

    public delegate void delegatetextMB(string msg);

    public delegate void delegatetextMBColor(Color foreColor, Color backColor);

    public delegate void delegatetextDiolan(string msg);

    public delegate void delegatetextDiolanColor(Color foreColor, Color backColor);

    public delegate void delegatetextTotalTestThreshold(string msg);

    public delegate void delegatetextTotalTestThresholdColor(Color foreColor, Color backColor);

    public delegate void delegatetextTotalPassed(string msg);

    public delegate void delegatetextTotalPassedColor(Color foreColor, Color backColor);

    public delegate void delegatetextTotalFailed(string msg);

    public delegate void delegatetextTotalFailedColor(Color foreColor, Color backColor);

    public delegate void delegatetextLastError(string msg);

    public delegate void delegatetextLastErrorColor(Color foreColor, Color backColor);

    public delegate void delegateStatus2Color(Color c);

    public delegate void delegateStatus2Text(string msg);

    public delegate void delegateGrid(
      string timestamp,
      string sn,
      string status,
      string errorCode,
      string errorDescription);

    public delegate void delegateHexBox1(byte[] tBuffer);

    public delegate void delegateListener(string msg);
  }
}
