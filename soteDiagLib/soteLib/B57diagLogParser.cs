// Decompiled with JetBrains decompiler
// Type: soteLib.B57diagLogParser
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace soteLib
{
  public class B57diagLogParser
  {
    protected TestLog TestLogFile;

    public B57diagLogParser()
    {
    }

    public B57diagLogParser(string logFile, Dictionary<string, string> extraInfo = null)
    {
      this.Parse(logFile, extraInfo);
    }

    protected static bool ParseBanner(
      ref string lastString,
      ref StringReader logFileReader,
      ref TestLog testLogFile)
    {
      if (lastString.TrimStart().StartsWith("Log file created by Broadcom NetXtreme/NetLink Engineering Diagnostics", true, (CultureInfo) null))
      {
        testLogFile.Diag_Type = TestLog.DiagType.B57diag;
        testLogFile.Test_App_Version = ((IEnumerable<string>) lastString.TrimEnd().Split()).Last<string>();
        lastString = logFileReader.ReadLine();
        if (lastString != null && lastString.TrimStart().StartsWith("on: ", true, (CultureInfo) null))
        {
          StringBuilder stringBuilder = new StringBuilder(lastString.Substring(4));
          if (stringBuilder[8] == ' ')
            stringBuilder[8] = '0';
          DateTime exact = DateTime.ParseExact(stringBuilder.ToString(), "ddd MMM dd HH:mm:ss yyyy", (IFormatProvider) CultureInfo.InvariantCulture);
          testLogFile.Date = exact.ToString("MM/dd/yyyy");
          testLogFile.Time = exact.ToString("HH:mm:ss");
          lastString = (string) null;
        }
        return true;
      }
      if (lastString.TrimStart().StartsWith("Log open time:", true, (CultureInfo) null))
      {
        testLogFile.Diag_Type = TestLog.DiagType.Cdiag;
        StringBuilder stringBuilder = new StringBuilder(lastString.Substring(15));
        if (stringBuilder[8] == ' ')
          stringBuilder[8] = '0';
        DateTime exact = DateTime.ParseExact(stringBuilder.ToString(), "ddd MMM dd HH:mm:ss yyyy", (IFormatProvider) CultureInfo.InvariantCulture);
        testLogFile.Date = exact.ToString("MM/dd/yyyy");
        testLogFile.Time = exact.ToString("HH:mm:ss");
        lastString = (string) null;
        return true;
      }
      if (!lastString.Trim().StartsWith("Cdiag version", true, (CultureInfo) null))
        return false;
      testLogFile.Diag_Type = TestLog.DiagType.Cdiag;
      testLogFile.Test_App_Version = ((IEnumerable<string>) lastString.TrimEnd().Split()).Last<string>();
      lastString = (string) null;
      return true;
    }

    protected static bool ParseDeviceList(
      ref string lastString,
      ref StringReader logFileReader,
      ref TestLog testLogFile)
    {
      string[] strArray1 = new string[6]
      {
        "C Brd   Rv   Bus   PCI Spd Base Irq NVM(avl/max)   MAC       Boot Code  Config",
        "C Brd   Rv   Bus   PCI Spd Base Irq NVM(avl/max)   MAC        FamVer    Config",
        "C Brd   Rv VID  DID  SVID SDID      MAC      Boot Code  PXE PXESp WOL MGT  MBA",
        "C Brd   Rv VID  DID  SVID SDID  MBA  PXE PXESpd PXE VERSION BOND REV",
        "C :   Brd:Rv    Bus       PCI    Spd Base   IRQ      MAC     FmwVer  Config.",
        "C :   Brd:Rv    Bus       PCI    Spd Base   IRQ      MAC     FamVer   Config."
      };
      int index = 0;
      while (index < strArray1.Length && !Regex.Replace(lastString, "\\s+", "").StartsWith(Regex.Replace(strArray1[index], "\\s+", ""), true, (CultureInfo) null))
        ++index;
      if (index >= strArray1.Length)
        return false;
      lastString = logFileReader.ReadLine();
      if (testLogFile.Diag_Type == TestLog.DiagType.B57diag)
        lastString = logFileReader.ReadLine();
      switch (index)
      {
        case 0:
        case 1:
          testLogFile.NumberOfPorts = 0;
          testLogFile.Pcie_Lanes = (string) null;
          testLogFile.Pcie_Speed = (string) null;
          testLogFile.MAC_ID_1st = (string) null;
          testLogFile.Bootcode_Version = (string) null;
          testLogFile.Test_Configuration = (string) null;
          while (lastString != null && lastString.Trim().Length > 0 && char.IsDigit(lastString[0]))
          {
            string str = lastString;
            lastString = logFileReader.ReadLine();
            if (lastString != null && lastString.StartsWith("** Error:"))
            {
              while (lastString != null && lastString.StartsWith("** Error:"))
                lastString = logFileReader.ReadLine();
              str += lastString;
              lastString = logFileReader.ReadLine();
            }
            if (lastString != null && lastString.Trim().Length != 0 && lastString[0] <= ' ')
            {
              str += lastString.Trim();
              lastString = logFileReader.ReadLine();
            }
            ++testLogFile.NumberOfPorts;
            if (testLogFile.Pcie_Lanes == null)
              testLogFile.Pcie_Lanes = str.Substring(19, 3);
            if (testLogFile.Pcie_Speed == null)
              testLogFile.Pcie_Speed = str.Substring(23, 3);
            if (str.IndexOf("Invalid", StringComparison.InvariantCultureIgnoreCase) == -1)
            {
              if (testLogFile.MAC_ID_1st == null && str.Length >= 59)
                testLogFile.MAC_ID_1st = str.Substring(47, 12);
              if (index == 0 && testLogFile.Bootcode_Version == null && str.Length >= 71)
                testLogFile.Bootcode_Version = str.Substring(60, 11).Trim();
              if (testLogFile.Test_Configuration == null && str.Length > 72)
                testLogFile.Test_Configuration = str.Substring(72).Trim();
            }
          }
          if (testLogFile.MAC_Count == null && testLogFile.NumberOfPorts > 0)
            testLogFile.MAC_Count = testLogFile.NumberOfPorts.ToString();
          return true;
        case 2:
          testLogFile.NumberOfPorts = 0;
          testLogFile.MAC_ID_1st = (string) null;
          testLogFile.Bootcode_Version = (string) null;
          while (lastString != null && lastString.Trim().Length > 0 && char.IsDigit(lastString[0]))
          {
            string str = lastString;
            lastString = logFileReader.ReadLine();
            ++testLogFile.NumberOfPorts;
            if (testLogFile.MAC_ID_1st == null && str.Length >= 43)
              testLogFile.MAC_ID_1st = str.Substring(31, 12);
            if (testLogFile.Bootcode_Version == null && str.Length >= 55)
              testLogFile.Bootcode_Version = str.Substring(44, 11).Trim();
          }
          if (testLogFile.MAC_Count == null && testLogFile.NumberOfPorts > 0)
            testLogFile.MAC_Count = testLogFile.NumberOfPorts.ToString();
          return true;
        case 3:
          if (testLogFile.MBA_Version == null && lastString != null && (lastString.Trim().Length >= 43 && lastString[0] == '0') && lastString.Substring(31, 3) == "yes")
          {
            string[] strArray2 = lastString.Substring(42).TrimStart().Split(new char[1]
            {
              ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            if (strArray2.Length > 0)
              testLogFile.MBA_Version = strArray2[0];
          }
          return true;
        case 4:
        case 5:
          testLogFile.NumberOfPorts = 0;
          testLogFile.Pcie_Lanes = (string) null;
          testLogFile.Pcie_Speed = (string) null;
          testLogFile.MAC_ID_1st = (string) null;
          testLogFile.Test_Configuration = (string) null;
          while (lastString != null)
          {
            if (lastString.Trim().Length == 0 || lastString.TrimStart().StartsWith(strArray1[index], true, (CultureInfo) null))
              lastString = logFileReader.ReadLine();
            else if (char.IsDigit(lastString[0]) && lastString[2] == ':')
            {
              string str1 = lastString;
              string str2 = (string) null;
              lastString = logFileReader.ReadLine();
              if (lastString != null && lastString.Trim().Length != 0 && lastString[0] <= ' ')
              {
                str2 = lastString;
                lastString = logFileReader.ReadLine();
              }
              ++testLogFile.NumberOfPorts;
              if (testLogFile.Pcie_Lanes == null)
                testLogFile.Pcie_Lanes = str1.Substring(25, 7);
              if (testLogFile.Pcie_Speed == null)
                testLogFile.Pcie_Speed = str1.Substring(33, 3);
              if (str1.IndexOf("Invalid", StringComparison.InvariantCultureIgnoreCase) == -1)
              {
                if (testLogFile.MAC_ID_1st == null && str1.Length >= 60)
                  testLogFile.MAC_ID_1st = str1.Substring(48, 12);
                if (index == 4 && testLogFile.Bootcode_Version == null && str1.Length >= 66)
                  testLogFile.Bootcode_Version = str1.Substring(60).Trim().Split()[0];
                if (testLogFile.Test_Configuration == null && str1.Length > 68)
                {
                  testLogFile.Test_Configuration = str1.Substring(68).Trim();
                  if (str2 != null & str2.Length > 68)
                    testLogFile.Test_Configuration += str2.Substring(68).Trim();
                }
              }
            }
            else
              break;
          }
          if (testLogFile.MAC_Count == null && testLogFile.NumberOfPorts > 0)
            testLogFile.MAC_Count = testLogFile.NumberOfPorts.ToString();
          return true;
        default:
          return false;
      }
    }

    private static void SearchTestTextPattern(
      ref string lastString,
      ref StringReader logFileReader,
      ref TestIteration iteration,
      ref TestLog testLogFile)
    {
      switch (testLogFile.Diag_Type)
      {
        case TestLog.DiagType.B57diag:
          TestNicPort testNicPort1 = (TestNicPort) null;
          TestItem testItem1 = (TestItem) null;
          int index1 = -1;
          do
          {
            if (lastString.TrimStart().StartsWith("Testing Device:", true, (CultureInfo) null))
            {
              lastString = logFileReader.ReadLine();
              if (lastString != null)
              {
                index1 = int.Parse(lastString[0].ToString());
                if (index1 < 0 || index1 >= iteration.Ports.Length)
                  throw new InvalidOperationException("Expect number of ports - " + (object) iteration.Ports.Length + ": \"Testing Device: " + lastString + "\"");
                testNicPort1 = iteration.Ports[index1];
                if (testNicPort1 == null)
                {
                  iteration.Ports[index1] = testNicPort1 = new TestNicPort();
                  testNicPort1.TestItems = new List<TestItem>();
                }
              }
              else
                goto label_55;
            }
            else
            {
              if (lastString.TrimStart().StartsWith("Total test time", true, (CultureInfo) null))
              {
                lastString = (string) null;
                return;
              }
              if (lastString.StartsWith("Checking IRQ."))
              {
                testItem1 = new TestItem();
                testNicPort1.TestItems.Add(testItem1);
                testItem1.ING_Test_Name = "Checking IRQ";
                testItem1.ING_Test_Number = "Special 1";
                testItem1.ING_Port_Number = index1.ToString();
                if (lastString.IndexOf("pass", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                  testItem1.ING_Pass_Fail = "Pass";
                  testItem1 = (TestItem) null;
                }
                else if (lastString.IndexOf("Fail", StringComparison.InvariantCultureIgnoreCase) != -1)
                  testItem1.ING_Pass_Fail = "Fail";
                else
                  testItem1 = (TestItem) null;
              }
              else if (lastString.StartsWith("Checking NVRAM Content."))
              {
                testItem1 = (TestItem) null;
                foreach (TestItem testItem2 in testNicPort1.TestItems)
                {
                  if (string.Compare(testItem2.ING_Test_Name, "Checking NVRAM Content") == 0)
                  {
                    testItem1 = testItem2;
                    break;
                  }
                }
                if (testItem1 == null)
                {
                  testItem1 = new TestItem();
                  testNicPort1.TestItems.Add(testItem1);
                }
                testItem1.ING_Test_Name = "Checking NVRAM Content";
                testItem1.ING_Test_Number = "Special 2";
                testItem1.ING_Port_Number = index1.ToString();
                if (lastString.IndexOf("pass", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                  testItem1.ING_Pass_Fail = "Pass";
                  testItem1 = (TestItem) null;
                }
                else if (lastString.IndexOf("Fail", StringComparison.InvariantCultureIgnoreCase) != -1)
                  testItem1.ING_Pass_Fail = "Fail";
                else
                  testItem1 = (TestItem) null;
              }
              else if (lastString.StartsWith("Serial Number."))
                testLogFile.Serial_No = ((IEnumerable<string>) lastString.Split(':')).Last<string>().Trim();
              else if (lastString.Length > 3 && lastString[0] == ' ' && (lastString[1] >= 'A' && lastString[1] <= 'Z') && (lastString[2] >= '0' && lastString[2] <= '9') && lastString.IndexOf('.', 3) != -1)
              {
                string[] strArray = lastString.Split('.');
                testItem1 = new TestItem();
                testNicPort1.TestItems.Add(testItem1);
                testItem1.ING_Test_Name = strArray[1].Trim();
                testItem1.ING_Test_Number = strArray[0].Trim();
                testItem1.ING_Port_Number = index1.ToString();
                if (lastString.IndexOf("passed (Time", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                  testItem1.ING_Pass_Fail = "Pass";
                  testItem1.ING_Test_Time = ((IEnumerable<string>) lastString.TrimEnd().Split()).Last<string>().Replace(")", string.Empty);
                  testItem1 = (TestItem) null;
                }
              }
              else if (lastString.IndexOf("passed (Time", StringComparison.InvariantCultureIgnoreCase) != -1)
              {
                if (testItem1 == null)
                {
                  if (lastString.IndexOf(".: ") != -1 && !lastString.TrimStart().StartsWith("Loading NVRAM content", true, (CultureInfo) null) && !lastString.TrimStart().StartsWith("Programming NVRAM", true, (CultureInfo) null))
                    throw new InvalidOperationException("Test name is not found: " + lastString);
                }
                else
                {
                  testItem1.ING_Pass_Fail = "Pass";
                  testItem1.ING_Test_Time = ((IEnumerable<string>) lastString.TrimEnd().Split()).Last<string>().Replace(")", string.Empty);
                  testItem1 = (TestItem) null;
                }
              }
              else if (lastString.IndexOf("Failed", StringComparison.InvariantCultureIgnoreCase) != -1)
              {
                if (testItem1 == null)
                {
                  testItem1 = new TestItem();
                  testNicPort1.TestItems.Add(testItem1);
                  testItem1.ING_Port_Number = index1.ToString();
                  testItem1.ING_Pass_Fail = "Fail";
                  if (lastString.IndexOf(".: ") != -1)
                  {
                    string[] strArray = lastString.Split('.');
                    testItem1.ING_Test_Name = strArray[0].Trim();
                  }
                  else
                  {
                    testItem1.ING_Test_Name = "Unexpected Failure";
                    testItem1 = (TestItem) null;
                  }
                }
                else
                {
                  testItem1.ING_Pass_Fail = "Fail";
                  iteration.Functional_Test_Pass_Fail = iteration.Overall_Test_Pass_Fail = "FAIL";
                  while (lastString != null)
                  {
                    string str = lastString.Trim();
                    if (str.Length != 0 && !str.EndsWith("Failed", true, (CultureInfo) null) && !str.StartsWith("Failed", true, (CultureInfo) null))
                    {
                      if (str.StartsWith("Error #:", true, (CultureInfo) null))
                        iteration.Error_Code = ((IEnumerable<string>) lastString.Split(':')).Last<string>().Trim();
                      else if (str.StartsWith("Msg:", true, (CultureInfo) null))
                      {
                        iteration.Error_Description = ((IEnumerable<string>) lastString.Split(':')).Last<string>().Trim();
                      }
                      else
                      {
                        if (str.StartsWith("(Time ", true, (CultureInfo) null))
                        {
                          testItem1.ING_Test_Time = ((IEnumerable<string>) str.Split()).Last<string>().Replace(")", string.Empty);
                          lastString = logFileReader.ReadLine();
                          break;
                        }
                        if (str.IndexOf(':') < 0)
                          break;
                      }
                    }
                    lastString = logFileReader.ReadLine();
                  }
                  testItem1 = (TestItem) null;
                }
              }
            }
            lastString = logFileReader.ReadLine();
          }
          while (lastString != null);
          goto label_62;
label_55:
          break;
label_62:
          break;
        case TestLog.DiagType.Cdiag:
          TestNicPort testNicPort2 = (TestNicPort) null;
          TestItem testItem3 = (TestItem) null;
          int index2 = -1;
          do
          {
            if (lastString.TrimStart().StartsWith("Test is running iteration", true, (CultureInfo) null))
            {
              index2 = int.Parse(((IEnumerable<string>) lastString.Trim().Split()).Last<string>()) - 1;
              if (iteration.Ports == null)
                iteration.Ports = new TestNicPort[testLogFile.NumberOfPorts];
              if (index2 < 0 || index2 >= iteration.Ports.Length)
                throw new InvalidOperationException("Expect number of ports - " + (object) iteration.Ports.Length + ": \"Testing Device: " + lastString + "\"");
              testNicPort2 = iteration.Ports[index2];
              if (testNicPort2 == null)
              {
                iteration.Ports[index2] = testNicPort2 = new TestNicPort();
                testNicPort2.TestItems = new List<TestItem>();
              }
            }
            else
            {
              if (lastString.TrimStart().StartsWith("Nictest completed with", true, (CultureInfo) null))
              {
                lastString = (string) null;
                break;
              }
              if (lastString.TrimStart().StartsWith("Total test time", true, (CultureInfo) null))
              {
                lastString = (string) null;
                break;
              }
              if (lastString.Length > 6 && lastString.StartsWith("   ") && (lastString[3] >= 'A' && lastString[3] <= 'Z') && (lastString[4] >= '0' && lastString[4] <= '9') && lastString.IndexOf('.', 5) != -1)
              {
                string[] strArray = lastString.Split('.', ':');
                string str = ((IEnumerable<string>) strArray).Last<string>().Trim();
                TestItem testItem2 = new TestItem();
                testItem2.ING_Test_Type = "Cdiag";
                testNicPort2.TestItems.Add(testItem2);
                testItem2.ING_Test_Name = strArray[1].Trim();
                testItem2.ING_Test_Number = strArray[0].Trim();
                testItem2.ING_Port_Number = index2.ToString();
                if (str.StartsWith("pass", true, (CultureInfo) null))
                {
                  testItem2.ING_Pass_Fail = "Pass";
                  testItem2.ING_Test_Time = ((IEnumerable<string>) str.Split()).Last<string>().Replace(")", string.Empty).Replace("(", string.Empty);
                  testItem3 = (TestItem) null;
                }
                else if (str.StartsWith("fail", true, (CultureInfo) null))
                {
                  testItem2.ING_Pass_Fail = "Fail";
                  iteration.Functional_Test_Pass_Fail = iteration.Overall_Test_Pass_Fail = "FAIL";
                  testItem2.ING_Test_Time = ((IEnumerable<string>) str.Split()).Last<string>().Replace(")", string.Empty).Replace("(", string.Empty);
                  testItem3 = (TestItem) null;
                }
              }
            }
            lastString = logFileReader.ReadLine();
          }
          while (lastString != null);
          break;
      }
    }

    protected static bool ParseTestDevices(
      ref string lastString,
      ref StringReader logFileReader,
      ref TestLog testLogFile)
    {
      TestIteration testIteration1;
      switch (testLogFile.Diag_Type)
      {
        case TestLog.DiagType.B57diag:
          if (lastString.Trim().StartsWith("Iteration ", true, (CultureInfo) null))
          {
            TestIteration testIteration2 = new TestIteration();
            testIteration2.Ports = new TestNicPort[testLogFile.NumberOfPorts];
            if (testLogFile.TestIterrations == null)
              testLogFile.TestIterrations = new List<TestIteration>();
            testLogFile.TestIterrations.Add(testIteration2);
            lastString = (string) null;
            return true;
          }
          if (lastString.Trim().StartsWith("Testing Device:", true, (CultureInfo) null))
          {
            testIteration1 = (TestIteration) null;
            TestIteration iteration;
            if (testLogFile.TestIterrations == null)
            {
              testLogFile.TestIterrations = new List<TestIteration>();
              iteration = new TestIteration();
              iteration.Ports = new TestNicPort[testLogFile.NumberOfPorts];
              testLogFile.TestIterrations.Add(iteration);
            }
            else
              iteration = testLogFile.TestIterrations.Last<TestIteration>();
            B57diagLogParser.SearchTestTextPattern(ref lastString, ref logFileReader, ref iteration, ref testLogFile);
            return true;
          }
          break;
        case TestLog.DiagType.Cdiag:
          if (lastString.Trim().StartsWith("Test is running iteration", true, (CultureInfo) null))
          {
            testIteration1 = (TestIteration) null;
            int index = int.Parse(((IEnumerable<string>) lastString.Substring(25).Trim().Split()).First<string>()) - 1;
            if (testLogFile.TestIterrations == null)
              testLogFile.TestIterrations = new List<TestIteration>();
            TestIteration iteration;
            if (index < testLogFile.TestIterrations.Count)
            {
              iteration = testLogFile.TestIterrations[index];
            }
            else
            {
              iteration = new TestIteration();
              iteration.Ports = new TestNicPort[testLogFile.NumberOfPorts];
              testLogFile.TestIterrations.Add(iteration);
            }
            B57diagLogParser.SearchTestTextPattern(ref lastString, ref logFileReader, ref iteration, ref testLogFile);
            return true;
          }
          break;
      }
      return false;
    }

    protected static bool ParseIterationResult(
      ref string lastString,
      ref StringReader logFileReader,
      ref TestLog testLogFile)
    {
      if (!lastString.TrimStart().StartsWith("Result = ", true, (CultureInfo) null))
        return false;
      TestIteration testIteration;
      if (testLogFile.TestIterrations == null)
      {
        testLogFile.TestIterrations = new List<TestIteration>();
        testIteration = new TestIteration();
        testLogFile.TestIterrations.Add(testIteration);
      }
      else
        testIteration = testLogFile.TestIterrations.Last<TestIteration>();
      if (((IEnumerable<string>) lastString.Trim().Split()).Last<string>().StartsWith("PASS", true, (CultureInfo) null))
      {
        testIteration.Functional_Test_Pass_Fail = "PASS";
        if (testIteration.Overall_Test_Pass_Fail == null)
          testIteration.Overall_Test_Pass_Fail = "PASS";
      }
      else
        testIteration.Functional_Test_Pass_Fail = testIteration.Overall_Test_Pass_Fail = "FAIL";
      lastString = logFileReader.ReadLine();
      while (lastString != null)
      {
        string str1 = lastString.Trim();
        int num = str1.IndexOf('=');
        if (num != -1)
        {
          string str2 = str1.Substring(num + 1).TrimStart();
          if (str1.StartsWith("Errorcode =", true, (CultureInfo) null))
            testIteration.Error_Code = str2;
          else if (str1.StartsWith("ErrorDescription =", true, (CultureInfo) null))
            testIteration.Error_Description = str2;
          else if (str1.StartsWith("SN =", true, (CultureInfo) null))
          {
            if (testLogFile.Serial_No == null)
              testLogFile.Serial_No = str2;
          }
          else if (!str1.StartsWith("Total_MAC =", true, (CultureInfo) null))
          {
            if (str1.StartsWith("MAC0 =", true, (CultureInfo) null))
              testLogFile.MAC_ID_1st = str2;
            else
              break;
          }
          lastString = logFileReader.ReadLine();
        }
        else
          break;
      }
      return true;
    }

    protected static bool ParseNvmDir(
      ref string lastString,
      ref StringReader logFileReader,
      ref TestLog testLogFile)
    {
      switch (testLogFile.Diag_Type)
      {
        case TestLog.DiagType.B57diag:
          if (lastString.TrimStart().StartsWith("Entry Type             RAM Addr  NVM Offset  Length  Execute Version", true, (CultureInfo) null))
          {
            char[] separator = new char[1]{ ' ' };
            lastString = logFileReader.ReadLine();
            lastString = logFileReader.ReadLine();
            while (lastString != null)
            {
              string str = lastString;
              uint result = 0;
              if (str.Trim().Length > 0)
              {
                if (str.IndexOf("BootCode", StringComparison.InvariantCultureIgnoreCase) >= 0)
                  testLogFile.Bootcode_Version = ((IEnumerable<string>) str.Split(separator, StringSplitOptions.RemoveEmptyEntries)).Last<string>();
                else if (str.IndexOf("MBA") >= 0)
                  testLogFile.MBA_Version = ((IEnumerable<string>) str.Split(separator, StringSplitOptions.RemoveEmptyEntries)).Last<string>();
                else if (str.IndexOf("EFI") >= 0)
                  testLogFile.EFI_Version = ((IEnumerable<string>) str.Split(separator, StringSplitOptions.RemoveEmptyEntries)).Last<string>();
                else if (str.IndexOf("APE") >= 0)
                  testLogFile.APE_Version = str.Length <= 61 ? ((IEnumerable<string>) str.Split(separator, StringSplitOptions.RemoveEmptyEntries)).Last<string>() : str.Substring(61).Trim();
                else if (str.IndexOf("iSCSI Boot", StringComparison.InvariantCultureIgnoreCase) >= 0)
                  testLogFile.ISCSI_Version = ((IEnumerable<string>) str.Split(separator, StringSplitOptions.RemoveEmptyEntries)).Last<string>();
                else if (str.IndexOf("CCM") >= 0)
                  testLogFile.CCM_Version = ((IEnumerable<string>) str.Split(separator, StringSplitOptions.RemoveEmptyEntries)).Last<string>();
                else if (!str.TrimStart().StartsWith("Extended Directory", true, (CultureInfo) null) && !uint.TryParse(str.Split(separator, StringSplitOptions.RemoveEmptyEntries)[0], out result))
                  break;
              }
              lastString = logFileReader.ReadLine();
            }
            return true;
          }
          break;
        case TestLog.DiagType.Cdiag:
          if (lastString.TrimStart().StartsWith("Type   Ordinal NVM Offset   Image Len      Version     Host Attr", true, (CultureInfo) null))
          {
            lastString = logFileReader.ReadLine();
            lastString = logFileReader.ReadLine();
            while (lastString != null && char.IsDigit(lastString[1]))
            {
              string[] strArray = lastString.Split(new char[1]
              {
                ' '
              }, StringSplitOptions.RemoveEmptyEntries);
              if (strArray.Length > 5)
              {
                if (strArray[1] == "MBA")
                  testLogFile.MBA_Version = lastString.Substring(45, 11).Trim().Replace(" ", string.Empty);
                else if (strArray[1] == "CFW")
                  testLogFile.Bootcode_Version = lastString.Substring(45, 11).Trim().Replace(" ", string.Empty);
                else if (strArray[1] == "CCM")
                  testLogFile.CCM_Version = lastString.Substring(45, 11).Trim().Replace(" ", string.Empty);
                else if (strArray[1] == "IBOOT")
                  testLogFile.ISCSI_Version = lastString.Substring(45, 11).Trim().Replace(" ", string.Empty);
              }
              lastString = logFileReader.ReadLine();
            }
            break;
          }
          break;
      }
      return false;
    }

    protected static bool ParseNvmChecksum(
      ref string lastString,
      ref StringReader logFileReader,
      ref TestLog testLogFile)
    {
      TestIteration testIteration1;
      switch (testLogFile.Diag_Type)
      {
        case TestLog.DiagType.B57diag:
          if (lastString.TrimStart().StartsWith("Region           Address Range     Content  Checksum Status", true, (CultureInfo) null))
          {
            string str1 = (string) null;
            string strA = (string) null;
            bool flag = false;
            lastString = logFileReader.ReadLine();
            lastString = logFileReader.ReadLine();
            while (lastString != null && lastString.Trim().Length > 0 && char.IsLetterOrDigit(lastString[0]))
            {
              string str2 = lastString;
              lastString = logFileReader.ReadLine();
              str1 = str2.Length < 17 ? str2.Trim() : str2.Substring(0, 17).Trim();
              if (str2.Length > 53)
                strA = str2.Substring(53).Trim();
              if (string.IsNullOrEmpty(strA) || string.Compare(strA, "ok", true) != 0)
              {
                flag = true;
                break;
              }
            }
            if (str1 != null)
            {
              testIteration1 = (TestIteration) null;
              TestIteration testIteration2;
              if (testLogFile.TestIterrations == null)
              {
                testLogFile.TestIterrations = new List<TestIteration>();
                testIteration2 = new TestIteration();
                testLogFile.TestIterrations.Add(testIteration2);
              }
              else
                testIteration2 = testLogFile.TestIterrations.Last<TestIteration>();
              if (!flag)
              {
                testIteration2.NvramVerify_Test_Pass_Fail = "PASS";
                if (testIteration2.Overall_Test_Pass_Fail == null)
                  testIteration2.Overall_Test_Pass_Fail = "PASS";
              }
              else
              {
                testIteration2.NvramVerify_Test_Pass_Fail = testIteration2.Overall_Test_Pass_Fail = "FAIL";
                testIteration2.Error_Code = "38";
                testIteration2.Error_Description = "Checksum Error - region \"" + str1 + "\"";
              }
            }
            return true;
          }
          break;
        case TestLog.DiagType.Cdiag:
          if (lastString.TrimStart().StartsWith("Type  Ordinal NVM Offset    Image Len   Content  Computed  Result", true, (CultureInfo) null))
          {
            string str = (string) null;
            bool flag = false;
            lastString = logFileReader.ReadLine();
            lastString = logFileReader.ReadLine();
            while (lastString != null && lastString.Trim().Length > 0 && char.IsDigit(lastString[1]))
            {
              string[] strArray = lastString.Split();
              lastString = logFileReader.ReadLine();
              str = strArray[1];
              if (!((IEnumerable<string>) strArray).Last<string>().TrimStart().StartsWith("OK", true, (CultureInfo) null))
              {
                flag = true;
                break;
              }
            }
            if (str != null)
            {
              testIteration1 = (TestIteration) null;
              TestIteration testIteration2;
              if (testLogFile.TestIterrations == null)
              {
                testLogFile.TestIterrations = new List<TestIteration>();
                testIteration2 = new TestIteration();
                testLogFile.TestIterrations.Add(testIteration2);
              }
              else
                testIteration2 = testLogFile.TestIterrations.Last<TestIteration>();
              if (!flag)
              {
                testIteration2.NvramVerify_Test_Pass_Fail = "PASS";
                if (testIteration2.Overall_Test_Pass_Fail == null)
                  testIteration2.Overall_Test_Pass_Fail = "PASS";
              }
              else
              {
                testIteration2.NvramVerify_Test_Pass_Fail = testIteration2.Overall_Test_Pass_Fail = "FAIL";
                testIteration2.Error_Code = "38";
                testIteration2.Error_Description = "Checksum Error - region \"" + str + "\"";
              }
            }
            return true;
          }
          if (lastString.TrimStart().StartsWith("Get Dir Header failed.", true, (CultureInfo) null))
          {
            testIteration1 = (TestIteration) null;
            TestIteration testIteration2;
            if (testLogFile.TestIterrations == null)
            {
              testLogFile.TestIterrations = new List<TestIteration>();
              testIteration2 = new TestIteration();
              testLogFile.TestIterrations.Add(testIteration2);
            }
            else
              testIteration2 = testLogFile.TestIterrations.Last<TestIteration>();
            testIteration2.NvramVerify_Test_Pass_Fail = testIteration2.Overall_Test_Pass_Fail = "FAIL";
            testIteration2.Error_Description = lastString.Trim();
            break;
          }
          break;
      }
      return false;
    }

    protected static bool ParseDummy(
      ref string lastString,
      ref StringReader logFileReader,
      ref TestLog testLogFile)
    {
      lastString = (string) null;
      return true;
    }

    public void Parse(string logFile, Dictionary<string, string> extraInfo = null)
    {
      this.TestLogFile = new TestLog();
      logFile = Regex.Replace(logFile, "[^\\u0009\\u000A\\u000D\\u0020-\\u007F]", string.Empty);
      this.TestLogFile.RawLogFile = logFile;
      B57diagLogParser.RefFunc[] refFuncArray = new B57diagLogParser.RefFunc[7]
      {
        new B57diagLogParser.RefFunc(B57diagLogParser.ParseBanner),
        new B57diagLogParser.RefFunc(B57diagLogParser.ParseDeviceList),
        new B57diagLogParser.RefFunc(B57diagLogParser.ParseTestDevices),
        new B57diagLogParser.RefFunc(B57diagLogParser.ParseIterationResult),
        new B57diagLogParser.RefFunc(B57diagLogParser.ParseNvmDir),
        new B57diagLogParser.RefFunc(B57diagLogParser.ParseNvmChecksum),
        new B57diagLogParser.RefFunc(B57diagLogParser.ParseDummy)
      };
      StringReader stringReader = new StringReader(logFile);
      string str1 = stringReader.ReadLine();
      while (str1 != null)
      {
        foreach (B57diagLogParser.RefFunc refFunc in refFuncArray)
        {
          string str2 = str1;
          if (!refFunc(ref str1, ref stringReader, ref this.TestLogFile))
          {
            if (str1 == null)
              throw new InvalidOperationException("Get null after delegate " + refFunc.Method.Name + "(" + str2 + ")");
          }
          else
            break;
        }
        if (str1 == null)
          str1 = stringReader.ReadLine();
      }
      if (extraInfo.ContainsKey("Retest"))
        this.TestLogFile.SFIS_Retest = extraInfo["Retest"];
      if (!extraInfo.ContainsKey("MO_Number"))
        return;
      this.TestLogFile.Work_Order_Number = extraInfo["MO_Number"];
    }

    public static void Parse(
      string logFilePathname,
      B57diagLogParser.LogFileType logFileType,
      B57diagLogParser.TestResult[] results,
      string outputFilePathname,
      B57diagLogParser.OutputFileType outputFileType,
      Dictionary<string, string> extraInfo = null)
    {
      StreamReader streamReader = new StreamReader(logFilePathname);
      B57diagLogParser b57diagLogParser = new B57diagLogParser(streamReader.ReadToEnd(), extraInfo);
      streamReader.Close();
      if (b57diagLogParser.TestLogFile.TestIterrations != null && results != null && results.Length != 0)
      {
        int index = 0;
        foreach (TestIteration testIterration in b57diagLogParser.TestLogFile.TestIterrations)
        {
          if (index < results.Length)
          {
            string str = results[index].IsPass ? "PASS" : "FAIL";
            switch (logFileType)
            {
              case B57diagLogParser.LogFileType.FCT:
                testIterration.Functional_Test_Pass_Fail = str;
                break;
              case B57diagLogParser.LogFileType.NVRAM_Verify:
                testIterration.NvramVerify_Test_Pass_Fail = str;
                break;
              case B57diagLogParser.LogFileType.FRU_Program:
                testIterration.FRUVPD_Test_Pass_Fail = str;
                break;
              case B57diagLogParser.LogFileType.FRU_Verify:
                testIterration.FRUVerify_Test_Pass_Fail = str;
                break;
            }
            if (!results[index].IsPass)
            {
              testIterration.Overall_Test_Pass_Fail = "FAIL";
              testIterration.Error_Code = results[index].ErrorCode;
              testIterration.Error_Description = results[index].ErrorDescription;
            }
          }
        }
      }
      if (outputFileType == B57diagLogParser.OutputFileType.XML)
        b57diagLogParser.ToXML(outputFilePathname);
      else
        b57diagLogParser.ToCSV(outputFilePathname);
    }

    public void ToXML(string xmlFilePathname)
    {
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.NewLineHandling = NewLineHandling.Entitize;
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (TestLog));
      XmlWriter xmlWriter = XmlWriter.Create(xmlFilePathname, settings);
      xmlSerializer.Serialize(xmlWriter, (object) this.TestLogFile);
      xmlWriter.Close();
    }

    public void ToCSV(string csvFilePathname)
    {
      StreamWriter streamWriter = new StreamWriter(csvFilePathname);
      string str1 = (string) null;
      string str2 = (string) null;
      List<string> source = new List<string>();
      foreach (FieldInfo fieldInfo in ((IEnumerable<FieldInfo>) this.TestLogFile.GetType().GetFields()).Where<FieldInfo>((Func<FieldInfo, bool>) (a => a.FieldType == typeof (string) && a.Name != "Template_Version" && a.Name != "RawLogFile")))
      {
        str1 = !string.IsNullOrEmpty(str1) ? str1 + "," + fieldInfo.Name : "Template_Version,Test_Iteration," + fieldInfo.Name;
        string str3 = (string) fieldInfo.GetValue((object) this.TestLogFile);
        if (string.IsNullOrEmpty(str3))
          str3 = "n/a";
        else if (str3.IndexOf(',') != -1)
          str3 = '"'.ToString() + str3 + (object) '"';
        str2 = !string.IsNullOrEmpty(str2) ? str2 + (object) ',' + str3 : str3;
      }
      foreach (FieldInfo fieldInfo in ((IEnumerable<FieldInfo>) typeof (TestIteration).GetFields()).Where<FieldInfo>((Func<FieldInfo, bool>) (a => a.FieldType == typeof (string))))
        str1 = str1 + (object) ',' + fieldInfo.Name;
      if (this.TestLogFile.TestIterrations != null)
      {
        StringDictionary stringDictionary = new StringDictionary();
        foreach (TestIteration testIterration in this.TestLogFile.TestIterrations)
        {
          string str3 = (string) null;
          foreach (FieldInfo fieldInfo in ((IEnumerable<FieldInfo>) typeof (TestIteration).GetFields()).Where<FieldInfo>((Func<FieldInfo, bool>) (a => a.FieldType == typeof (string))))
          {
            string str4 = (string) fieldInfo.GetValue((object) testIterration);
            if (string.IsNullOrEmpty(str4))
              str4 = "n/a";
            else if (str4.IndexOf(',') != -1)
              str4 = '"'.ToString() + str4 + (object) '"';
            str3 = !string.IsNullOrEmpty(str3) ? str3 + (object) ',' + str4 : str4;
          }
          if (testIterration.Ports != null)
          {
            foreach (TestNicPort port in testIterration.Ports)
            {
              if (port != null)
              {
                foreach (TestItem testItem in port.TestItems)
                {
                  if (!stringDictionary.ContainsKey(testItem.ING_Test_Number))
                    stringDictionary.Add(testItem.ING_Test_Number, (stringDictionary.Count + 1).ToString("D3"));
                  foreach (FieldInfo field in testItem.GetType().GetFields())
                  {
                    if (!source.Any<string>())
                      str1 = str1 + "," + field.Name + "_TC" + stringDictionary[testItem.ING_Test_Number];
                    string str4 = (string) field.GetValue((object) testItem);
                    if (string.IsNullOrEmpty(str4))
                      str4 = "n/a";
                    else if (str4.IndexOf(',') != -1)
                      str4 = '"'.ToString() + str4 + (object) '"';
                    str3 = !string.IsNullOrEmpty(str3) ? str3 + (object) ',' + str4 : str4;
                  }
                }
              }
            }
          }
          source.Add(this.TestLogFile.Template_Version + (object) ',' + (object) (testIterration.Test_Iteration + 1) + (object) ',' + str2 + (object) ',' + str3);
        }
      }
      else
        source.Add(this.TestLogFile.Template_Version + ",1," + str2);
      streamWriter.WriteLine(str1);
      foreach (string str3 in source)
        streamWriter.WriteLine(str3);
      streamWriter.Close();
    }

    public delegate bool RefFunc(ref string obj1, ref StringReader obj2, ref TestLog obj3);

    public enum LogFileType
    {
      FCT,
      NVRAM_Verify,
      FRU_Program,
      FRU_Verify,
    }

    public enum OutputFileType
    {
      CSV,
      XML,
    }

    public class TestResult
    {
      public bool IsPass;
      public string ErrorCode;
      public string ErrorDescription;

      public TestResult(bool isPass, string errorCode, string errorDescription)
      {
        this.IsPass = isPass;
        this.ErrorCode = errorCode;
        this.ErrorDescription = errorDescription;
      }
    }
  }
}
