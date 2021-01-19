using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class db : MonoBehaviour {
	void Start () {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/Makinalar.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * " + "FROM Makinalar";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string tur = reader.GetString(1);
            int no = reader.GetInt32(2);
            int mal = reader.GetInt32(3);
            Debug.Log("ID= " + id + "  Makina Turu =" + tur + "  Makina Numarası =" + no + "  Giren Mal Miktarı =" + mal);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
	}
}
