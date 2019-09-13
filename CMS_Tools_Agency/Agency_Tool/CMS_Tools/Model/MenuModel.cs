using CMS_Tools.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS_Tools.Model
{
    public class MenuModel
    {
        private static MenuModel instance = null;
        private static readonly object padlock = new object();
        public static MenuModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MenuModel();
                        }
                    }
                }
                return instance;
            }
        }

        //ConnectionDB connectString;
        string connectString = ConnectionDB.GetConnectionDB(Constants.STR_CONNECT_IDENTITY + "ManamentCMSTools_DB");

        public void SetConnectString(string name)
        {
            connectString = ConnectionDB.GetConnectionDB(name);
        }

        /// <summary>
        /// AddArticleTags
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="tags"></param>
        /// <param name="accountId"></param>
        /// <param name="publisherId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int AddArticleTags(string tags, int accountId, int publisherId, byte type)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_AddArticleTags";
                        cmd.Parameters.Add("@Tags", SqlDbType.VarChar, 250);
                        cmd.Parameters["@Tags"].Value = tags;
                        cmd.Parameters.Add("@PublisherId", SqlDbType.Int);
                        cmd.Parameters["@PublisherId"].Value = publisherId;
                        cmd.Parameters.Add("@AccountId", SqlDbType.Int);
                        cmd.Parameters["@AccountId"].Value = accountId;
                        cmd.Parameters.Add("@TagType", SqlDbType.TinyInt);
                        cmd.Parameters["@TagType"].Value = type;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR AddArticleTags: " + ex);
                throw new Exception("lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// UpdateArticle
        /// </summary>
        /// <param name="aricle"></param>
        /// <returns></returns>
        public int UpdateArticle(Entity.Article aricle)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_UpdateArticle";
                        cmd.Parameters.Add("@ArticleId", SqlDbType.BigInt);
                        cmd.Parameters["@ArticleId"].Value = aricle.id;
                        cmd.Parameters.Add("@CategoryTags", SqlDbType.VarChar, 250);
                        cmd.Parameters["@CategoryTags"].Value = aricle.categoriesTags;
                        cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@Title"].Value = aricle.title;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 1000);
                        cmd.Parameters["@Description"].Value = aricle.description;
                        cmd.Parameters.Add("@Product_Specifications", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@Product_Specifications"].Value = aricle.product_Specifications;
                        cmd.Parameters.Add("@Body", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@Body"].Value = aricle.body;
                        cmd.Parameters.Add("@ProductId", SqlDbType.VarChar, 50);
                        cmd.Parameters["@ProductId"].Value = aricle.productCode;
                        cmd.Parameters.Add("@Images", SqlDbType.VarChar, 4000);
                        cmd.Parameters["@Images"].Value = aricle.images;
                        cmd.Parameters.Add("@Videos", SqlDbType.VarChar, 4000);
                        cmd.Parameters["@Videos"].Value = aricle.videos;
                        cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Author"].Value = aricle.author;
                        cmd.Parameters.Add("@Quote", SqlDbType.NVarChar, 100);
                        cmd.Parameters["@Quote"].Value = aricle.quote;
                        cmd.Parameters.Add("@Tags", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@Tags"].Value = aricle.tags;
                        cmd.Parameters.Add("@Link", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Link"].Value = aricle.link != null ? aricle.link : "";
                        cmd.Parameters.Add("@MetaKeywords", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@MetaKeywords"].Value = aricle.metaKeyword;
                        cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@MetaDescription"].Value = aricle.metaDescription;
                        cmd.Parameters.Add("@DatePublish", SqlDbType.NVarChar, 20);
                        cmd.Parameters["@DatePublish"].Value = aricle.datePublish;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = aricle.status;
                        cmd.Parameters.Add("@AccountId", SqlDbType.Int);
                        cmd.Parameters["@AccountId"].Value = aricle.accountId;
                        cmd.Parameters.Add("@PublisherId", SqlDbType.Int);
                        cmd.Parameters["@PublisherId"].Value = aricle.publisherId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR UpdateArticle: " + ex);
                throw new Exception("lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// GetRuleUser
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="menuId"></param>
        /// <param name="menuRules"></param>
        /// <returns></returns>
        public int GetRuleUser(int accountId, ref string menuId, ref string menuRules)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetRuleByUser";
                        cmd.Parameters.Add("@AccountId", SqlDbType.Int);
                        cmd.Parameters["@AccountId"].Value = accountId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MenuId", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@MenuId"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MenuRule", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@MenuRule"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        menuId = cmd.Parameters["@MenuId"].Value.ToString();
                        menuRules = cmd.Parameters["@MenuRule"].Value.ToString();
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR GetGroupRuleByID: " + ex);
                throw new Exception("lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// UpdateGroupRule
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="menuId"></param>
        /// <param name="menuRules"></param>
        /// <returns></returns>
        public int UpdateGroupRule(int groupId, string menuId, string menuRules)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_UpdateGroupRule";
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = groupId;
                        cmd.Parameters.Add("@MenuId", SqlDbType.VarChar, -1);
                        cmd.Parameters["@MenuId"].Value = menuId;
                        cmd.Parameters.Add("@MenuRule", SqlDbType.VarChar, -1);
                        cmd.Parameters["@MenuRule"].Value = menuRules;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR GetGroupRuleByID: " + ex);
                throw new Exception("lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// GetAllMenu
        /// </summary>
        /// <param name="publisherId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetAllMenu(int publisherId, ref int code)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetAllMenu";
                        cmd.Parameters.Add("@PublisherId", SqlDbType.Int);
                        cmd.Parameters["@PublisherId"].Value = publisherId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetGroupRuleByID
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetGroupRuleByID(int groupID, ref int code)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetGroupRuleByID";
                        cmd.Parameters.Add("@GroupRuleID", SqlDbType.Int);
                        cmd.Parameters["@GroupRuleID"].Value = groupID;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("ERROR GetMenuUserRules: " + ex);
                return null;
            }
        }

        /// <summary>
        /// GetMenuUsers
        /// </summary>
        /// <returns></returns>
        public List<Entity.MenuPage> GetMenuUser(int accountId, ref int code)
        {
            List<Entity.MenuPage> listMenu = new List<Entity.MenuPage>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetMenuByUser";
                        cmd.Parameters.Add("@AccountId", SqlDbType.Int);
                        cmd.Parameters["@AccountId"].Value = accountId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        DataTable dt = new DataTable();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        //MenuID, ParentID, MenuName, Icon, Onclick, DisplayIndex	
                        foreach (DataRow item in dt.Rows)
                        {
                            listMenu.Add(new Entity.MenuPage()
                            {
                                MenuId = int.Parse(item[0].ToString()),
                                ParentID = int.Parse(item[1].ToString()),
                                MenuName = item[2].ToString(),
                                Icon = item[3].ToString(),
                                Onclick = item[4].ToString(),
                                DisplayIndex = int.Parse(item[5].ToString())
                            });
                        }
                    }
                }
                return listMenu;
            }
            catch (Exception)
            {
                code = (int)Lib.Constants.NUMBER_CODE.ERROR_EX;
                return new List<Entity.MenuPage>();               
            }
        }

        /// <summary>
        /// RemoveMenu
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public int RemoveMenu(string menuID)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Menu_Remove";
                        cmd.Parameters.Add("@MenuID", SqlDbType.VarChar, 500);
                        cmd.Parameters["@MenuID"].Value = menuID;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// CloneMenu
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int CloneMenu(string menuID, int userId)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Menu_Clone";
                        cmd.Parameters.Add("@MenuID", SqlDbType.VarChar, 500);
                        cmd.Parameters["@MenuID"].Value = menuID;
                        cmd.Parameters.Add("@Creator", SqlDbType.Int);
                        cmd.Parameters["@Creator"].Value = userId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetMenuByPublisher
        /// </summary>
        /// <param name="publisherId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetMenuByPublisher(int publisherId,int parentId, ref int code)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetMenuByPublisher";
                        cmd.Parameters.Add("@PublisherId", SqlDbType.Int);
                        cmd.Parameters["@PublisherId"].Value = publisherId;
                        cmd.Parameters.Add("@ParentId", SqlDbType.Int);
                        cmd.Parameters["@ParentId"].Value = parentId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetMenuByID
        /// [MenuID]
        /// [ParentID]
        /// [MenuName]
        /// [Description]
        /// [Icon]
        /// [Onclick]
        /// [DisplayIndex]
        /// [Status]
        /// [DateCreate]
        /// [Creator]
        /// [CSS]
        /// [HTML]
        /// [JS]
        /// [DatabaseID]
        /// SQL_Query
        /// SQL_DataType
        /// [TypeQuery]
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetMenuByID(int menuID, ref int code)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_GetMenuByID";
                        cmd.Parameters.Add("@MenuID", SqlDbType.Int);
                        cmd.Parameters["@MenuID"].Value = menuID;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(dr);
                        }
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="sql_query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string db, int sqlType, string sql_query, List<string> param) {
            try
            {
                string strConnection = Model.ConnectionDB.GetConnectionDB(db);
                DataTable table = new DataTable();
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        if (sqlType == 2)
                        {
                            var d = sql_query.Split('|').ToList();
                            string sp = d[0];
                            List<string> i_param = d.Count() > 1 ? d[1].Split(',').ToList() : null;
                            cmd.CommandText = sp;
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (i_param != null)
                            {
                                for (int i = 0; i < i_param.Count(); i++)
                                {
                                    cmd.Parameters.AddWithValue(i_param[i], param[i]);
                                }
                            }
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                table = new DataTable();
                                table.Load(dr);
                            }
                        }
                        else
                        {
                            cmd.CommandText = sql_query;
                            cmd.CommandType = CommandType.Text;
                            if (sql_query.Split('@').Count() > 1)
                            {
                                for (int k = 0; k < param.Count; k++)
                                {
                                    sql_query = sql_query.Replace("@@" + k, param[k].Trim());
                                }
                                cmd.CommandText = sql_query;//update sql_query
                                for (int j = 0; j < param.Count; j++)
                                {
                                    cmd.Parameters.AddWithValue("@" + j, param[j].Trim());
                                }
                            }
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                table = new DataTable();
                                table.Load(dr);
                            }
                        }
                    }
                }
                return table;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error GetDataTable: sqlType " + sqlType +
                    "\r\nsql_query: " + sql_query + 
                    "\r\nparam: " + string.Join(",", param), ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// CreateMenu
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int CreateMenu(Entity.Menu m)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Menu_Create";

                        cmd.Parameters.Add("@ParentID", SqlDbType.Int);
                        cmd.Parameters["@ParentID"].Value = m.parentId;
                        cmd.Parameters.Add("@MenuName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@MenuName"].Value = m.menuName;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Description"].Value = m.description;
                        cmd.Parameters.Add("@Icon", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Icon"].Value = m.icon;
                        cmd.Parameters.Add("@Onclick", SqlDbType.VarChar, 1000);
                        cmd.Parameters["@Onclick"].Value = m.onclick;
                        cmd.Parameters.Add("@DisplayIndex", SqlDbType.Int);
                        cmd.Parameters["@DisplayIndex"].Value = m.dislayIndex;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = m.status;
                        cmd.Parameters.Add("@Creator", SqlDbType.BigInt);
                        cmd.Parameters["@Creator"].Value = m.creator;
                        cmd.Parameters.Add("@CSS", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@CSS"].Value = m.css;
                        cmd.Parameters.Add("@JS", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@JS"].Value = m.js;
                        cmd.Parameters.Add("@HTML", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@HTML"].Value = m.html;
                        cmd.Parameters.Add("@DatabaseID", SqlDbType.VarChar, 100);
                        cmd.Parameters["@DatabaseID"].Value = m.databaseId;
                        cmd.Parameters.Add("@SQL_Query", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@SQL_Query"].Value = m.sql_query;
                        cmd.Parameters.Add("@SQL_DataType", SqlDbType.VarChar, 2000);
                        cmd.Parameters["@SQL_DataType"].Value = m.sql_dataType;
                        cmd.Parameters.Add("@Type_Query", SqlDbType.TinyInt);
                        cmd.Parameters["@Type_Query"].Value = m.type_query;
                        cmd.Parameters.Add("@PublisherID", SqlDbType.Int);
                        cmd.Parameters["@PublisherID"].Value = m.publisherId;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@MenuId", SqlDbType.Int);
                        cmd.Parameters["@MenuId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        m.menuId = int.Parse(cmd.Parameters["@MenuId"].Value.ToString());
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error CreateMenu", ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UpdateMenu
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int UpdateMenu(Entity.Menu m)
        {
            try
            {
                int code = -1;
                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandTimeout = Constants.TIMOUT_CONNECT_SQL;
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_Menu_Update";

                        cmd.Parameters.Add("@MenuId", SqlDbType.Int);
                        cmd.Parameters["@MenuId"].Value = m.menuId;
                        cmd.Parameters.Add("@MenuName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@MenuName"].Value = m.menuName;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Description"].Value = m.description;
                        cmd.Parameters.Add("@Icon", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Icon"].Value = m.icon;
                        cmd.Parameters.Add("@Onclick", SqlDbType.VarChar, 1000);
                        cmd.Parameters["@Onclick"].Value = m.onclick;
                        cmd.Parameters.Add("@DisplayIndex", SqlDbType.Int);
                        cmd.Parameters["@DisplayIndex"].Value = m.dislayIndex;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = m.status;
                        cmd.Parameters.Add("@Creator", SqlDbType.BigInt);
                        cmd.Parameters["@Creator"].Value = m.creator;
                        cmd.Parameters.Add("@CSS", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@CSS"].Value = m.css;
                        cmd.Parameters.Add("@JS", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@JS"].Value = m.js;
                        cmd.Parameters.Add("@HTML", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@HTML"].Value = m.html;
                        cmd.Parameters.Add("@DatabaseID", SqlDbType.VarChar, 100);
                        cmd.Parameters["@DatabaseID"].Value = m.databaseId != null ? m.databaseId : "";
                        cmd.Parameters.Add("@SQL_Query", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@SQL_Query"].Value = m.sql_query;
                        cmd.Parameters.Add("@SQL_DataType", SqlDbType.VarChar, 2000);
                        cmd.Parameters["@SQL_DataType"].Value = m.sql_dataType;
                        cmd.Parameters.Add("@Type_Query", SqlDbType.TinyInt);
                        cmd.Parameters["@Type_Query"].Value = m.type_query;
                        cmd.Parameters.Add("@Key", SqlDbType.VarChar, 100);
                        cmd.Parameters["@Key"].Value = Lib.Constants.KEY_SQL;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                    }
                }
                return code;
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error UpdateMenu", ex);
                throw new Exception(ex.Message);
            }
        }
    }
}