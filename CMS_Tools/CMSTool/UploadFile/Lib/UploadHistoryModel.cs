using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UploadFile.Lib
{
    public class UploadHistoryModel
    {
        const string KEY_SQL = "48dc695d5f6203fd54b85c93b022ffe5";
        ConnectionDB connectString;
        public UploadHistoryModel()
        {
            connectString = new ConnectionDB("ManamentCMSTools_DB");
        }

        public void AddUploadHistory(picture pic) {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 3000;
                connectString.conn.Open();
                cmd.Connection = connectString.conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_AddUploadHistory";
                cmd.Parameters.Add("@FileName", SqlDbType.VarChar, 50);
                cmd.Parameters["@FileName"].Value = pic.fileName;
                cmd.Parameters.Add("@Url", SqlDbType.VarChar, 250);
                cmd.Parameters["@Url"].Value = pic.urlWeb;
                cmd.Parameters.Add("@Size", SqlDbType.VarChar, 20);
                cmd.Parameters["@Size"].Value = pic.sizeWeb;
                cmd.Parameters.Add("@UploadType", SqlDbType.TinyInt);
                cmd.Parameters["@UploadType"].Value = pic.uploadType;
                cmd.Parameters.Add("@IP", SqlDbType.VarChar, 40);
                cmd.Parameters["@IP"].Value = pic.ip;
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Value = 1;
                cmd.Parameters.Add("@UserId", SqlDbType.Int);
                cmd.Parameters["@UserId"].Value = pic.userId;
                cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                cmd.Parameters["@Key"].Value = KEY_SQL;
                cmd.Parameters.Add("@Code", SqlDbType.BigInt);
                cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                long code = long.Parse(cmd.Parameters["@Code"].Value.ToString());
                pic.id = code;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR AddUploadHistory: " + ex);
                pic.id = -1;
            }
            finally
            {
                connectString.conn.Close();
            }
        }
    }
}