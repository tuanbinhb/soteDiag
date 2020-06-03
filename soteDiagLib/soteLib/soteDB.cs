// Decompiled with JetBrains decompiler
// Type: soteLib.soteDB
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace soteLib
{
  public class soteDB
  {
    private static string conn = "Data Source=irvsqlsote;Initial Catalog=dBUx;User ID=svcsoteprod01;Password=$0tePr0Dsvca33t";
    public static string errMsg;

    public static void setDevelopment()
    {
      soteDB.conn = "Data Source=irvsql69;Initial Catalog=dBUx;User ID=svcsoteprod01;Password=$0tePr0Dsvca34t";
    }

    public static string connectionString
    {
      get
      {
        return soteDB.conn;
      }
    }

    public static DataSet QueryData(string strQuery)
    {
      soteDB.errMsg = "";
      DataSet dataSet = new DataSet();
      try
      {
        SqlConnection selectConnection = new SqlConnection(soteDB.connectionString);
        new SqlDataAdapter(strQuery, selectConnection).Fill(dataSet);
      }
      catch (Exception ex)
      {
        soteDB.errMsg = ex.Message;
      }
      return dataSet;
    }

    public static int InsertData(string strInsert)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(soteDB.connectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = strInsert + ";SELECT CAST(scope_identity() AS int)";
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        int num = (int) sqlCommand.ExecuteScalar();
        sqlConnection.Close();
        return num;
      }
      catch (Exception ex)
      {
        soteDB.errMsg = ex.Message;
      }
      return 0;
    }

    public static int UpdateData(string strUpdate)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(soteDB.connectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.CommandText = strUpdate;
        sqlCommand.Connection = sqlConnection;
        sqlConnection.Open();
        int num = sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return num;
      }
      catch (Exception ex)
      {
        soteDB.errMsg = ex.Message;
      }
      return 0;
    }

    public static string database
    {
      get
      {
        return new SqlConnection(soteDB.connectionString).DataSource;
      }
    }

    public static bool verifyValidTemplate(string table, DataTable dt, out string fieldnames)
    {
      string[] fieldNames = soteDB.getFieldNames(table);
      fieldnames = "";
      for (int index = 0; index < dt.Columns.Count; ++index)
      {
        if (!((IEnumerable<string>) fieldNames).Contains<string>(dt.Columns[index].ToString().ToUpper()))
        {
          soteDB.errMsg = string.Format("ERROR(ReadFile): INVALID TEMPLATE [{0}]", (object) dt.Columns[index].ToString());
          return false;
        }
        fieldnames += string.Format("[{0}]", (object) dt.Columns[index].ToString().ToUpper());
        if (index < dt.Columns.Count - 1)
          fieldnames += ",";
      }
      return true;
    }

    private static string[] getFieldNames(string table)
    {
      DataSet dataSet = soteDB.QueryData(string.Format("select column_name from information_schema.columns where table_name = '{0}'", (object) table));
      if (dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
        return (string[]) null;
      string[] strArray = new string[dataSet.Tables[0].Rows.Count];
      for (int index = 0; index < dataSet.Tables[0].Rows.Count; ++index)
        strArray[index] = dataSet.Tables[0].Rows[index]["column_name"].ToString().ToUpper();
      return strArray;
    }

    public static DataTable csvParseFile(string fn)
    {
      if (!File.Exists(fn))
        return (DataTable) null;
      DataTable dataTable = new DataTable();
      using (StreamReader streamReader = File.OpenText(fn))
      {
        string str1 = streamReader.ReadLine();
        char[] chArray = new char[1]{ ',' };
        foreach (string columnName in str1.Split(chArray))
        {
          if (columnName != "")
          {
            DataColumn column = new DataColumn(columnName, typeof (string));
            dataTable.Columns.Add(column);
          }
        }
        string str2;
        while ((str2 = streamReader.ReadLine()) != null)
        {
          string[] source = str2.Split(',');
          dataTable.Rows.Add(soteDB.CopyRowData(source, dataTable.NewRow()));
        }
      }
      dataTable.AcceptChanges();
      return dataTable;
    }

    private static DataRow CopyRowData(string[] source, DataRow target)
    {
      try
      {
        for (int index = 0; index < source.Length; ++index)
          target[index] = (object) source[index];
      }
      catch (IndexOutOfRangeException ex)
      {
        return target;
      }
      return target;
    }
  }
}
