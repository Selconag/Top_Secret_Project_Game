using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class insert : MonoBehaviour {
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
	void Start () {
        conn = "URI=file:" + Application.dataPath + "/Plugins/Makinalar.s3db";
        Updatevalue("Abkant",2,4,1);//sýrasýyla name / mail / address / id
        readers();
	}
    private void insertvalue(string tur, int no, int miktar)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into Usersinfo (Tur, No, Mal_Miktar) values (\"{0}\",\"{1}\",\"{2}\")",tur,no,miktar);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    private void Deletvalue(int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("Delete from Makinalar WHERE ID=\"{0}\"", id);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    private void Updatevalue(string tur, int no, int miktar,int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Makinalar set Tur=\"{0}\", No=\"{1}\", Mal_Miktar=\"{2}\" WHERE ID=\"{3}\" ", tur, no, miktar, id);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    private void readers()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM Makinalar";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string tur = reader.GetString(1);
                int no = reader.GetInt32(2);
                int miktar = reader.GetInt32(3);
                Debug.Log("value= " + id + "  Tur =" + tur + "  No =" + no + "   Mal Miktarý" + miktar);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }
    public void Makina_Veri()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM Makinalar";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string tur = reader.GetString(1);
                int no = reader.GetInt32(2);
                int miktar = reader.GetInt32(3);
                miktar++;
                Debug.Log("value= " + id + "  Tur =" + tur + "  No =" + no + "   Mal Miktarý" + miktar);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }

    }
}
