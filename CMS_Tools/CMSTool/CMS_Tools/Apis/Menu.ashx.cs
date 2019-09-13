using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CMS_Tools.Apis
{
    /// <summary>
    /// Summary description for Menu
    /// </summary>
    public class Menu : IHttpHandler, IRequiresSessionState
    {
        Result result = new Result();
        UserInfo accountInfo;
        List<Constants.USER_PERMISSTIONS> uSER_RULEs = new List<Constants.USER_PERMISSTIONS>();
        Model.ManagerDAO manageDao = new Model.ManagerDAO();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=utf-8";
            try
            {
                #region CHECK ACCOUNT LOGIN
                accountInfo = Account.GetAccountInfo(context);
                if (accountInfo == null)
                {
                    result.status = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN;
                    result.msg = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN.ToString();
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                #endregion

                #region PROCESS REQUEST TYPE
                Constants.REQUEST_TYPE requestType = (Constants.REQUEST_TYPE)int.Parse(context.Request.Form["type"]);
                switch (requestType)
                {
                    case Constants.REQUEST_TYPE.UPDATE_ARTICLE:
                        UPDATE_ARTICLE(context);
                        break;
                    case Constants.REQUEST_TYPE.UPDATE_GROUP_PERMISSIONS:
                        UPDATE_GROUP_PERMISSIONS(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_ALL_MENU:
                        GET_ALL_MENU(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_ACCOUNT_GROUP_BY_ID:
                        GET_GROUP_RULE_BY_ID(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_PERMISSIONS:
                        GET_PERMISSION(context);
                        break;
                    case Constants.REQUEST_TYPE.DELETE_DATATABLE:
                        DELETE_DATATABLE(context);
                        break;
                    case Constants.REQUEST_TYPE.UPDATE_DATATABLE:
                        UPDATE_DATATABLE(context);
                        break;
                    case Constants.REQUEST_TYPE.INSERT_DATATABLE:
                        INSERT_DATATABLE(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_LIST_DATABASE:
                        GET_LIST_DATABASE(context);
                        break;
                    case Constants.REQUEST_TYPE.REMOVE_MENU:
                        REMOVE_MENU(context);
                        break;
                    case Constants.REQUEST_TYPE.CLONE_MENU:
                        CLONE_MENU(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_MENU_DETAIL:
                        GET_MENU_DETAIL(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_MENU:
                        GET_MENU(context);
                        break;
                    case Constants.REQUEST_TYPE.UPDATE_MENU:
                        UPDATE_MENU(context);
                        break;
                    case Constants.REQUEST_TYPE.CREATE_MENU:
                        CREATE_MENU(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_DATA_BY_MENU:
                        GET_DATA_BY_MENU(context);
                        break;
                    case Constants.REQUEST_TYPE.GET_DATA_BY_QUERY:
                        GET_DATA_BY_QUERY(context);
                        break;
                    default:
                        result.status = Constants.NUMBER_CODE.REQUEST_NOT_FOUND;
                        result.msg = Constants.NUMBER_CODE.REQUEST_NOT_FOUND.ToString();
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        private void UPDATE_ARTICLE(HttpContext context)
        {
            try
            {
                string json = context.Request.Unvalidated.Form["json"];
                string body = context.Request.Unvalidated.Form["body"];
                //string menuId = "19";
                if (!string.IsNullOrEmpty(json))
                {
                    var d = JsonConvert.DeserializeObject<Entity.Article>(json);

                    DateTime pubDate;
                    if(!DateTime.TryParse(d.datePublish, out pubDate))
                    {
                        result.status = Constants.NUMBER_CODE.DATE_INVALID;
                        result.msg = "Nhập ngày không đúng!";
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }

                    d.body = body;
                    d.accountId = accountInfo.AccountId;
                    d.publisherId = accountInfo.PublisherID;
                    int code = manageDao.MenuModel.UpdateArticle(d);
                    if(code == 0 && d.tags != "")
                    {
                        //string sign = Encryptor.MD5Hash(menuId + "#####");
                        //Global.taskList.Add(Constants.PING_URL + "?sign=" + sign + "&p=" + menuId);
                        manageDao.MenuModel.AddArticleTags(d.tags, d.accountId, d.publisherId, 0);
                    }
                    result.status = (Constants.NUMBER_CODE)code;
                    result.msg = result.status.ToString();
                }
                else
                {
                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = result.status.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR UPDATE_ARTICLE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void GET_DATA_BY_QUERY(HttpContext context)
        {
            try
            {
                try
                {
                    string menuID = context.Request.Form["mid"];
                    string p = context.Request.Form["p"];
                    List<string> param = new List<string>();
                    if (string.IsNullOrEmpty(menuID))
                    {
                        result.msg = Constants.NUMBER_CODE.MENU_ID_IS_NULL.ToString();
                        result.status = Constants.NUMBER_CODE.MENU_ID_IS_NULL;
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    if (!string.IsNullOrEmpty(p))
                        param = JsonConvert.DeserializeObject<List<string>>(p);
                    int code = 0;
                    var menuInfo = GET_MENU_INFO(menuID, ref code);
                    string db = Constants.STR_CONNECT_IDENTITY + menuInfo.Rows[0][13].ToString();
                    string query = menuInfo.Rows[0][14].ToString();
                    string data_Type = menuInfo.Rows[0][15].ToString();
                    int sql_Type = int.Parse(menuInfo.Rows[0][16].ToString());

                    ManagerDAO manage = new ManagerDAO();
                    var table = manage.MenuModel.GetDataTable(db, sql_Type, query, param);
                    result.data = table;
                    result.status = table.Rows.Count >= 0 ? Constants.NUMBER_CODE.SUCCESS : Constants.NUMBER_CODE.ERROR;
                    result.msg = result.status.ToString();
                }
                catch (Exception ex)
                {
                    Logs.SaveError("ERROR GET_DATA_BY_MENU", ex);
                    result.msg = ex.Message;
                    result.status = Constants.NUMBER_CODE.ERROR_EX;
                }
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_DATA_BY_QUERY: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        private void UPDATE_GROUP_PERMISSIONS(HttpContext context)
        {
            try
            {
                int id = int.Parse(context.Request.Form["id"]);
                string listMenuId = context.Request.Form["listMenu"];
                string listPermissions = context.Request.Form["listPermissions"];
                result.status = (Constants.NUMBER_CODE)manageDao.MenuModel.UpdateGroupRule(id, listMenuId, listPermissions);
                result.msg = result.status.ToString();
                if(result.status == 0)
                {
                    context.Session["menu"] = null;
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR SET_GROUP_PERMISSIONS: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = "Lỗi: " + ex.Message;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void GET_ALL_MENU(HttpContext context)
        {
            try
            {
                int publisherID = accountInfo.PublisherID; 
                int code = 0;
                var dt = manageDao.MenuModel.GetAllMenu(publisherID, ref code);
                result.data = dt;
                result.msg = Constants.NUMBER_CODE.SUCCESS.ToString();
                result.status = (Constants.NUMBER_CODE)code;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_ACCOUNT_GROUP_BY_ID: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = "Lỗi: " + ex.Message;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void GET_GROUP_RULE_BY_ID(HttpContext context)
        {
            try
            {
                int id = int.Parse(context.Request.Form["id"]);
                int code = 0;
                var dt = manageDao.MenuModel.GetGroupRuleByID(id, ref code);
                var obj = new
                {
                    id = int.Parse(dt.Rows[0][0].ToString()),
                    name = dt.Rows[0][1].ToString(),
                    menuID = dt.Rows[0][2].ToString(),
                    menuPermissions = dt.Rows[0][3].ToString()
                };
                result.data = obj;
                result.msg = code == 0 ? Constants.NUMBER_CODE.SUCCESS.ToString() : "";
                result.status = (Constants.NUMBER_CODE)code;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_ACCOUNT_GROUP_BY_ID: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = "Lỗi: " + ex.Message;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void GET_PERMISSION(HttpContext context)
        {
            try
            {
                List<MenuPermissions> listPermissions = new List<MenuPermissions>();
                var d = Constants.GET_PERMISSTIONS();
                for (int i = 0; i < d.Count; i++)
                {
                    listPermissions.Add(new MenuPermissions()
                    {
                        id = (int)d[i],
                        name = d[i].ToString()
                    });
                }
                result.data = listPermissions;
                result.msg = Constants.NUMBER_CODE.SUCCESS.ToString();
                result.status = Constants.NUMBER_CODE.SUCCESS;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_PERMISSION: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = "Lỗi: " + ex.Message;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void DELETE_DATATABLE(HttpContext context)
        {
            try
            {
                string menuId = context.Request.Form["menuId"];
                if (string.IsNullOrEmpty(menuId))
                {
                    result.status = Constants.NUMBER_CODE.MENU_ID_IS_NULL;
                    result.msg = "error";
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                int code = 0;
                var menuInfo = manageDao.MenuModel.GetMenuByID(int.Parse(menuId), ref code);
                if (code <= 0)
                {
                    result.status = Constants.NUMBER_CODE.MENU_ID_IS_NULL;
                    result.msg = "error";
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                string db = Constants.STR_CONNECT_IDENTITY + menuInfo.Rows[0][13].ToString();
                string query = menuInfo.Rows[0][14].ToString();
                string tableName = "";
                var param = GetColumnNameTable(db, query, ref tableName);
                string id = context.Request.Form["id"];
                string updateSQL;
                updateSQL = "DELETE FROM " + tableName;
                updateSQL += " WHERE " + param[0] + "=@" + param[0];
                Logs.SaveLog(updateSQL);
                ConnectionDB connectString = new ConnectionDB(db);
                SqlCommand cmd = new SqlCommand(updateSQL, connectString.conn);
                cmd.Parameters.AddWithValue("@" + param[0], id);
                try
                {
                    connectString.conn.Open();
                    int added = cmd.ExecuteNonQuery();
                    result.msg = added > 0 ? Constants.NUMBER_CODE.SUCCESS.ToString() : Constants.NUMBER_CODE.INSERT_DATATABLE_FAILD.ToString();
                    result.status = added > 0 ? Constants.NUMBER_CODE.SUCCESS : Constants.NUMBER_CODE.INSERT_DATATABLE_FAILD;
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                catch (Exception ex)
                {
                    result.status = Constants.NUMBER_CODE.ERROR_EX;
                    result.msg = "Lỗi: " + ex.Message;
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                finally
                {
                    connectString.conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR DELETE_DATATABLE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = "Lỗi: " + ex.Message;
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        private void UPDATE_DATATABLE(HttpContext context)
        {
            try
            {
                string menuId = context.Request.Form["menuId"];
                if (string.IsNullOrEmpty(menuId))
                {
                    result.status = Constants.NUMBER_CODE.MENU_ID_IS_NULL;
                    result.msg = "error";
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                int code = 0;
                var menuInfo = manageDao.MenuModel.GetMenuByID(int.Parse(menuId), ref code);

                if (code <= 0)
                {
                    result.status = Constants.NUMBER_CODE.MENU_ID_IS_NULL;
                    result.msg = "error";
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                string db = Constants.STR_CONNECT_IDENTITY + menuInfo.Rows[0][13].ToString();
                string query = menuInfo.Rows[0][14].ToString();
                string data_Type = menuInfo.Rows[0][15].ToString();
                int sql_Type = int.Parse(menuInfo.Rows[0][16].ToString());
                string tableName = "";
                var param = GetColumnNameTable(db, query, ref tableName);
                var listDataType = JsonConvert.DeserializeObject<List<DataType>>(data_Type);
                string sql = "";
                for (int j = 0; j < param.Count; j++)
                {
                    if (listDataType[j].type.ToLower() != "hidden" || listDataType[j].type.ToLower() != "disable" || !string.IsNullOrEmpty(listDataType[j].default_value))
                    {
                        if (j > 0)
                            sql += param[j] + "=@" + param[j] + ",";
                    }
                }
                List<string> data = new List<string>();
                try
                {
                    data = JsonConvert.DeserializeObject<List<string>>(context.Request.Form["data"]);
                }
                catch (Exception)
                {
                    data = context.Request.Form["data"].Split(',').ToList();
                }

                string updateSQL;
                updateSQL = "UPDATE " + tableName + " SET ";
                updateSQL += sql.Substring(0, sql.Length - 1);
                updateSQL += " WHERE " + param[0] + "= @" + param[0];
                Logs.SaveLog(updateSQL);
                Model.ConnectionDB connectString = new Model.ConnectionDB(db);
                SqlCommand cmd = new SqlCommand(updateSQL, connectString.conn);
                for (int k = 0; k < param.Count; k++)
                {
                    if (listDataType[k].type != "disable")
                    {
                        if (listDataType[k].default_value.ToLower() == "datetime")
                            cmd.Parameters.AddWithValue(param[k], DateTime.Now);
                        else if (listDataType[k].default_value.ToLower() == "uniqueidentifier")
                            cmd.Parameters.AddWithValue(param[k], Guid.NewGuid());
                        else if (listDataType[k].default_value.ToLower() == "accountcreate")
                            cmd.Parameters.AddWithValue(param[k], accountInfo.AccountId.ToString());
                        else
                            cmd.Parameters.AddWithValue(param[k], data[k]);
                    }
                    //if (listDataType[k].type != "hidden" || k == 0)
                    //{
                    //    if (listDataType[k].default_value.ToLower() == "datetime")
                    //        cmd.Parameters.AddWithValue(param[k], DateTime.Now);
                    //    else if (listDataType[k].default_value.ToLower() == "uniqueidentifier")
                    //        cmd.Parameters.AddWithValue(param[k], Guid.NewGuid());
                    //    else
                    //        cmd.Parameters.AddWithValue(param[k], data[k]);
                    //}
                    //else
                    //{
                    //    if (listDataType[k].default_value.ToLower() == "datetime")
                    //        cmd.Parameters.AddWithValue(param[k], DateTime.Now);
                    //    else if (listDataType[k].default_value.ToLower() == "accountcreate")
                    //        cmd.Parameters.AddWithValue(param[k], accountInfo.Rows[0][0].ToString());
                    //}
                }
                try
                {
                    connectString.conn.Open();
                    int added = cmd.ExecuteNonQuery();
                    result.msg = added > 0 ? Constants.NUMBER_CODE.SUCCESS.ToString() : Constants.NUMBER_CODE.INSERT_DATATABLE_FAILD.ToString();
                    result.status = added > 0 ? Constants.NUMBER_CODE.SUCCESS : Constants.NUMBER_CODE.INSERT_DATATABLE_FAILD;
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    //if(menuId == "12")
                    //{
                    //    string sign = Encryptor.MD5Hash(menuId + "#####");
                    //    if(Constants.SERVER_TYPE == "REAL")
                    //        Global.taskList.Add(Constants.PING_URL + "?sign=" + sign + "&p=" + menuId);
                    //    else
                    //        Global.taskList.Add("http://localhost:51810/ping.aspx?sign=" + sign + "&p=");
                    //}
                    return;
                }
                catch (Exception ex)
                {
                    result.status = Constants.NUMBER_CODE.ERROR_EX;
                    result.msg = "Lỗi: " + ex.Message;
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                finally
                {
                    connectString.conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR UPDATE_DATATABLE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = "Lỗi: " + ex.Message;
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        private void INSERT_DATATABLE(HttpContext context)
        {
            try
            {
                string menuId = context.Request.Form["menuId"];
                if (string.IsNullOrEmpty(menuId))
                {
                    result.status = Constants.NUMBER_CODE.MENU_ID_IS_NULL;
                    result.msg = "error";
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                int code = 0;
                var menuInfo = manageDao.MenuModel.GetMenuByID(int.Parse(menuId), ref code);

                if (code <= 0) {
                    result.status = Constants.NUMBER_CODE.MENU_ID_IS_NULL;
                    result.msg = "error";
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                string db = Constants.STR_CONNECT_IDENTITY + menuInfo.Rows[0][13].ToString();
                string query = menuInfo.Rows[0][14].ToString();
                string data_Type = menuInfo.Rows[0][15].ToString();
                int sql_Type = int.Parse(menuInfo.Rows[0][16].ToString());
                if (sql_Type == 1)
                {
                    string tableName = "";
                    var param = GetColumnNameTable(db, query, ref tableName);// column name table
                    var listDataType = JsonConvert.DeserializeObject<List<DataType>>(data_Type);
                    if (listDataType[0].type.ToLower() == "hidden")
                    {
                        listDataType.RemoveAt(0);
                        param.RemoveAt(0);
                    }
                    string sql = "";
                    for (int j = 0; j < param.Count; j++)
                    {
                        if (listDataType[j].type.ToLower() != "hidden" || !string.IsNullOrEmpty(listDataType[j].default_value))
                        {
                            param[j] = "@" + param[j];
                            sql += param[j] + ",";
                        }
                    }
                    List<string> data = new List<string>();
                    try
                    {
                        data = JsonConvert.DeserializeObject<List<string>>(context.Request.Form["data"]);
                        if (data.Count > param.Count)
                            data.RemoveAt(0);
                    }
                    catch (Exception)
                    {
                        data = context.Request.Form["data"].Split(',').ToList();
                    }
                    string insertSQL;
                    insertSQL = "INSERT INTO " + tableName + " (";
                    insertSQL += sql.Substring(0, sql.Length - 1).Replace("@", "") + ") ";
                    insertSQL += "VALUES (";
                    insertSQL += sql.Substring(0, sql.Length - 1) + ")";
                    Logs.SaveLog(insertSQL);
                    ConnectionDB connectString = new ConnectionDB(db);
                    SqlCommand cmd = new SqlCommand(insertSQL, connectString.conn);
                    for (int k = 0; k < param.Count; k++)
                    {
                        if (listDataType[k].default_value.ToLower() == "datetime")
                            cmd.Parameters.AddWithValue(param[k], DateTime.Now);
                        else if (listDataType[k].default_value.ToLower() == "uniqueidentifier")
                            cmd.Parameters.AddWithValue(param[k], Guid.NewGuid());
                        else if (listDataType[k].default_value.ToLower() == "accountcreate")
                            cmd.Parameters.AddWithValue(param[k], accountInfo.AccountId.ToString());
                        else if (param[k].Contains("@"))
                            cmd.Parameters.AddWithValue(param[k], data[k]);                        
                    }
                    try
                    {
                        connectString.conn.Open();
                        int added = cmd.ExecuteNonQuery();
                        result.msg = added > 0 ? Constants.NUMBER_CODE.SUCCESS.ToString() : Constants.NUMBER_CODE.INSERT_DATATABLE_FAILD.ToString();
                        result.status = added > 0 ? Constants.NUMBER_CODE.SUCCESS: Constants.NUMBER_CODE.INSERT_DATATABLE_FAILD;
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    catch (Exception ex)
                    {
                        result.status = Constants.NUMBER_CODE.ERROR_EX;
                        result.msg = "Lỗi: " + ex.Message;
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                    finally
                    {
                        connectString.conn.Close();
                    }
                }
                else {
                    result.status = Constants.NUMBER_CODE.MENU_NOT_ALLOW_INSERT;
                    result.msg = "Không thể thêm data!!!";
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR INSERT_DATATABLE: " + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = "Lỗi: " + ex.Message;
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        /// <summary>
        /// GET_LIST_DATABASE
        /// </summary>
        /// <param name="context"></param>
        private void GET_LIST_DATABASE(HttpContext context)
        {
            try
            {
                List<string> db = new List<string>();
                foreach (ConnectionStringSettings c in ConfigurationManager.ConnectionStrings)
                {
                    db.Add(c.Name.Replace(Constants.STR_CONNECT_IDENTITY, ""));
                }
                db.RemoveAt(0);
                db.Remove("LocalMySqlServer");
                result.data = db;
                result.msg = Constants.NUMBER_CODE.SUCCESS.ToString();
                result.status = Constants.NUMBER_CODE.SUCCESS;
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_LIST_DATABASE" + ex);
                result.status = Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }

        /// <summary>
        /// REMOVE_MENU
        /// </summary>
        /// <param name="context"></param>
        private void REMOVE_MENU(HttpContext context)
        {
            try
            {
                string menuId = context.Request.Form["menuId"];
                if (!string.IsNullOrEmpty(menuId))
                {
                    Model.ManagerDAO managerDao = new Model.ManagerDAO();
                    int code = managerDao.MenuModel.RemoveMenu(menuId);
                    if (code == 0)
                    {
                        result.msg = "Xóa " + code + " menu thành công";
                        result.status = Constants.NUMBER_CODE.SUCCESS;
                    }
                    else
                    {
                        result.msg = "Lỗi [" + code + "] clone menu thất bại!";
                        result.status = Constants.NUMBER_CODE.CLONE_MENU_ERROR;
                    }
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
                result.status = Constants.NUMBER_CODE.DATA_NULL;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR UPDATE_MENU", ex);
                result.msg = ex.Message;
                result.status = Constants.NUMBER_CODE.ERROR_EX;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// CLONE_MENU
        /// </summary>
        /// <param name="context"></param>
        private void CLONE_MENU(HttpContext context)
        {
            try
            {
                string menuId = context.Request.Form["menuId"];
                if (!string.IsNullOrEmpty(menuId))
                {
                    Model.ManagerDAO managerDao = new Model.ManagerDAO();
                    int code = managerDao.MenuModel.CloneMenu(menuId, int.Parse(accountInfo.AccountId.ToString()));
                    if (code > 0)
                    {
                        result.msg = "Clone " + code + " menu thành công";
                        result.status = Constants.NUMBER_CODE.SUCCESS;
                    }
                    else
                    {
                        result.msg = "Lỗi [" + code + "] clone menu thất bại!";
                        result.status = Constants.NUMBER_CODE.CLONE_MENU_ERROR;
                    }
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
                result.status = Constants.NUMBER_CODE.DATA_NULL;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR UPDATE_MENU", ex);
                result.msg = ex.Message;
                result.status = Constants.NUMBER_CODE.ERROR_EX;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// UPDATE_MENU
        /// </summary>
        /// <param name="context"></param>
        private void UPDATE_MENU(HttpContext context)
        {
            try
            {
                string json = context.Request.Unvalidated.Form["json"];
                if (!string.IsNullOrEmpty(json))
                {
                    var jsonData = JsonConvert.DeserializeObject<Entity.Menu>(json);
                    if (jsonData != null && !string.IsNullOrEmpty(jsonData.menuName))
                    {
                        jsonData.creator = accountInfo.AccountId;
                        Model.ManagerDAO managerDao = new Model.ManagerDAO();
                        int code = managerDao.MenuModel.UpdateMenu(jsonData);
                        if (code == 0)
                        {
                            result.msg = "Cập nhập menu thành công";
                            result.status = Constants.NUMBER_CODE.SUCCESS;
                            context.Session["menu"] = null;
                        }
                        else
                        {
                            result.msg = "Lỗi [" + code + "] cập nhật menu thất bại!";
                            result.status = Constants.NUMBER_CODE.UPDATE_MENU_ERROR;
                        }
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                }
                result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
                result.status = Constants.NUMBER_CODE.DATA_NULL;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR UPDATE_MENU", ex);
                result.msg = ex.Message;
                result.status = Constants.NUMBER_CODE.ERROR_EX;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// GET_MENU_DETAIL
        /// </summary>
        /// <param name="context"></param>
        private void GET_MENU_DETAIL(HttpContext context)
        {
            try
            {
                string p = context.Request.Form["p"];
                p = Encryptor.DecryptString(p, accountInfo.Token);
                if (string.IsNullOrEmpty(p))
                {
                    result.msg = "Bạn không có quyền truy cập trang này vào lúc này!!!";
                    result.status = Constants.NUMBER_CODE.DATA_NULL;
                }
                else {
                    var d = p.Split('#');
                    int menuId = int.Parse(d[0]);
                    int menuRule = int.Parse(d[1]);
                    string token = d[2];
                    if(token == accountInfo.Token)
                    {
                        if (menuId > 0)
                        {
                            Model.ManagerDAO manage = new Model.ManagerDAO();
                            int code = 0;
                            var menuData = manage.MenuModel.GetMenuByID(menuId, ref code);
                            if (code > 0)
                            {
                                result.data = menuData;
                                result.msg = Constants.NUMBER_CODE.SUCCESS.ToString();
                                result.status = Constants.NUMBER_CODE.SUCCESS;
                            }
                            else
                            {
                                result.msg = "Lỗi menu không tồn tại!!!";
                                result.status = Constants.NUMBER_CODE.MENU_NOT_FOUND;
                                result.data = null;
                            }
                        }
                        else
                        {
                            result.data = string.Empty;
                            result.msg = Constants.NUMBER_CODE.SUCCESS.ToString();
                            result.status = Constants.NUMBER_CODE.SUCCESS;
                        }
                    }
                    else
                    {
                        result.msg = "Bạn không có quyền truy cập trang này vào lúc này!!!";
                        result.status = Constants.NUMBER_CODE.TOKEN_WRONG;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_MENU", ex);
                result.msg = ex.Message;
                result.status = Constants.NUMBER_CODE.ERROR_EX;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// GET_MENU
        /// </summary>
        /// <param name="context"></param>
        private void GET_MENU(HttpContext context)
        {
            Menu_List result = new Menu_List();
            try
            {
                string dataType = context.Request.Form["dataType"];
                string parentId = context.Request.Form["parentId"];
                int code = 0;
                int publisherId = int.Parse(accountInfo.PublisherID.ToString());
                string d = Encryptor.DecryptString(parentId, accountInfo.Token);
                if (d == "")
                {
                    result.msg = "Lỗi data không hợp lệ!!!";
                    result.status = Constants.NUMBER_CODE.PARENT_ID_INVALID;
                }
                else
                {
                    int _parentID = int.Parse(d.Split('#')[0]);
                    string token = d.Split('#')[2];
                    Constants.USER_PERMISSTIONS rule = (Constants.USER_PERMISSTIONS)int.Parse(d.Split('#')[1]);
                    if (token == accountInfo.Token)
                    {
                        Model.ManagerDAO m = new Model.ManagerDAO();
                        var menuData = m.MenuModel.GetMenuByPublisher(publisherId, _parentID, ref code);
                        result.msg = Constants.NUMBER_CODE.SUCCESS.ToString();
                        result.status = code > 0 ? Constants.NUMBER_CODE.SUCCESS : Constants.NUMBER_CODE.DATA_NULL;
                        result.columnName = (from dc in menuData.Columns.Cast<DataColumn>()
                                             select dc.ColumnName).ToArray();
                        if (string.IsNullOrEmpty(dataType))
                            result.data = menuData;
                        else
                        {
                            if (dataType == "1")
                                result.data = Helper.DataTableToArray(menuData);
                        }
                    }
                    else
                    {
                        result.msg = "Lỗi token hết hạn không thể truy cập vào lúc này!!!";
                        result.status = Constants.NUMBER_CODE.TOKEN_EXPIRE;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_MENU", ex);
                result.msg = ex.Message;
                result.status = Constants.NUMBER_CODE.ERROR_EX;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Get data by menuID
        /// </summary>
        /// <param name="context"></param>
        private void GET_DATA_BY_MENU(HttpContext context)
        {
            Data_table result = new Data_table();
            try
            {
                string menuID = context.Request.Form["mid"];
                string p = context.Request.Form["p"];
                List<string> param = new List<string>();
                if (string.IsNullOrEmpty(menuID))
                {
                    result.msg = Constants.NUMBER_CODE.MENU_ID_IS_NULL.ToString();
                    result.status = (int)Constants.NUMBER_CODE.MENU_ID_IS_NULL;
                    context.Response.Write(JsonConvert.SerializeObject(result));
                    return;
                }
                if (!string.IsNullOrEmpty(p))
                    param = JsonConvert.DeserializeObject<List<string>>(p);
                int code = 0;
                var menuInfo = GET_MENU_INFO(menuID, ref code);
                string db = Constants.STR_CONNECT_IDENTITY + menuInfo.Rows[0][13].ToString();
                string query = menuInfo.Rows[0][14].ToString();               
                string data_Type = menuInfo.Rows[0][15].ToString();
                int sql_Type = int.Parse(menuInfo.Rows[0][16].ToString());
                
                ManagerDAO manage = new ManagerDAO();
                //manageDao.MenuModel.SetConnectString(menuInfo.Rows[0]["DatabaseID"].ToString());
                query = query.Replace("##USERID##", accountInfo.AccountId.ToString());
                var table = manage.MenuModel.GetDataTable(db, sql_Type, query, param);
                string[] columnNames = (from dc in table.Columns.Cast<DataColumn>()
                                        select dc.ColumnName).ToArray();
                if (columnNames.Count() > 0)
                {                    
                    Array.Resize(ref columnNames, columnNames.Count() + 1);
                    columnNames[columnNames.Count() - 1] = "Edit";
                    result.columnName = columnNames;
                    List<string[]> d = new List<string[]>();
                    foreach (DataRow row in table.Rows)
                    {
                        string[] g = new string[table.Columns.Count];
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            g[j] = row[j].ToString();
                        }
                        Array.Resize(ref g, g.Count() + 1);

                        if (uSER_RULEs.Count > 0)
                        {
                            foreach (var item in uSER_RULEs)
                            {
                                g[table.Columns.Count] += " <a class='" + item.ToString() + " btn btn-xs blue' href='javascript:;'> " + item.ToString() + "</a>";
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(data_Type))
                            {
                                g[table.Columns.Count] += " <a class='edit btn btn-xs blue' href='javascript:;'>Edit</a>";
                                g[table.Columns.Count] += " <a class='delete btn btn-xs red' href='javascript:;'>Remove</a>";
                            }
                            if (menuID == "4")
                                g[table.Columns.Count] += " <a class='setrule btn btn-xs purple' href='javascript:;'>Set Rule</a>";
                            if(menuID == "3")
                            {
                                g[table.Columns.Count] = " <a class='edit btn btn-xs blue' href='javascript:;'>Edit</a>";
                            }
                            if (menuID == "19")
                                g[table.Columns.Count] += " <a class='updateArticle btn btn-xs purple' href='javascript:;'>Edit</a>";
                            if(menuID == "12")
                            {
                                g[table.Columns.Count] += " <a class='viewSub btn btn-xs purple' href='javascript:;'>View</a>";
                            }
                        }
                        d.Add(g);
                    }
                    if (!string.IsNullOrEmpty(data_Type))
                    {
                        var dataType = JsonConvert.DeserializeObject<List<DataType>>(data_Type);
                        List<DataType> _d = new List<DataType>();
                        foreach (var item in dataType)
                        {
                            if (!string.IsNullOrEmpty(item.query) && !string.IsNullOrEmpty(item.database))
                            {
                                ConnectionDB connectString;
                                connectString = new ConnectionDB(Constants.STR_CONNECT_IDENTITY + item.database);
                                if (item.query.Split('@').Count() > 1)
                                {
                                    for (int j = 0; j < param.Count(); j++)
                                    {
                                        item.query = item.query.Replace("@" + j, param[j]);
                                    }
                                }
                                SqlCommand cmd = new SqlCommand(item.query, connectString.conn);
                                SqlDataAdapter adapter = new SqlDataAdapter();
                                DataTable dt = new DataTable();
                                adapter.SelectCommand = cmd;
                                adapter.Fill(dt);
                                item.data = (from DataRow row in dt.AsEnumerable() select row).Select(x => new Value()
                                {
                                    name = x["name"].ToString(),
                                    value = x["value"].ToString()
                                }).ToList();
                            }
                            _d.Add(item);
                        }
                        result.dataType = JsonConvert.SerializeObject(_d);
                    }
                    result.data = d;
                    result.draw = 1;
                    result.columnTotal = table.Columns.Count;
                    result.recordsTotal = d.Count;
                    result.recordsFiltered = d.Count;
                    result.status = 0;
                    result.msg = "success";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_DATA_BY_MENU", ex);
                result.msg = ex.Message;
                result.status = (int)Constants.NUMBER_CODE.ERROR_EX;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Create new Menu
        /// </summary>
        /// <param name="context"></param>
        private void CREATE_MENU(HttpContext context)
        {
            try
            {
                string json = context.Request.Unvalidated.Form["json"];
                if (!string.IsNullOrEmpty(json))
                {
                    var jsonData = JsonConvert.DeserializeObject<Entity.Menu>(json);
                    if(jsonData != null && !string.IsNullOrEmpty(jsonData.menuName))
                    {
                        jsonData.creator = accountInfo.AccountId;
                        jsonData.publisherId = accountInfo.PublisherID;
                        ManagerDAO managerDao = new ManagerDAO();
                        int code = managerDao.MenuModel.CreateMenu(jsonData);
                        if(code == 0)
                        {
                            result.msg = "Tạo menu thành công";
                            result.status = Constants.NUMBER_CODE.SUCCESS;
                            result.data = jsonData.menuId;
                        }
                        else
                        {
                            result.msg = "Lỗi ["+ code + "] tạo menu thất bại!";
                            result.status = Constants.NUMBER_CODE.CREATE_MENU_ERROR;
                        }
                        context.Response.Write(JsonConvert.SerializeObject(result));
                        return;
                    }
                }
                result.msg = Constants.NUMBER_CODE.DATA_NULL.ToString();
                result.status = Constants.NUMBER_CODE.DATA_NULL;                
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR CREATE_MENU", ex);
                result.msg = ex.Message;
                result.status = Constants.NUMBER_CODE.ERROR_EX;
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// GET_MENU_INFO
        /// [MenuID] ,[ParentID] ,[MenuName] ,[Description] ,[Icon] ,[Onclick] ,[DisplayIndex] ,[Status] ,[DateCreate] ,[Creator] ,[CSS] ,[HTML] ,[JS] ,[DatabaseID] ,SQL_Query ,SQL_DataType ,[TypeQuery]
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="menuData"></param>
        /// <returns></returns>
        private DataTable GET_MENU_INFO(string menuID, ref int code)
        {
            try
            {
                if (string.IsNullOrEmpty(menuID))
                {
                    throw new Exception(Constants.NUMBER_CODE.MENU_ID_IS_NULL.ToString());
                }
                Model.ManagerDAO m = new Model.ManagerDAO();
                var menuData = m.MenuModel.GetMenuByID(int.Parse(menuID), ref code);
                if (code <= 0)
                    throw new Exception(Constants.NUMBER_CODE.MENU_ID_IS_NULL.ToString());
                return menuData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetColumnNameTable(string db, string query,ref string tableName)
        {
            try
            {
                query = query.ToLower();
                string sql_query = "";
                if (query.Contains("where"))
                {
                    sql_query = query.Substring(0, query.IndexOf("where")).Replace("select", "");
                }
                else
                {
                    sql_query = query.Replace("select", "");
                }
                if(sql_query.Contains("top"))
                    sql_query = "select " + sql_query;
                else
                    sql_query = "select top 1 " + sql_query;
                var table = manageDao.MenuModel.GetDataTable(db, 1, sql_query, new List<string>());
                int i = sql_query.IndexOf("from");
                var a = sql_query.Substring(i + 4, sql_query.Length - (i + 4)).Trim();
                tableName = a.Split(' ')[0];
                var columnNames = (from dc in table.Columns.Cast<DataColumn>()
                                   select dc.ColumnName).ToList();
                return columnNames;
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GetColumnNameTable: " + ex);
                throw new Exception(ex.Message);
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Menu_List
    {
        public Constants.NUMBER_CODE status { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public string[] columnName { get; set; }
    }

    public class Data_table
    {
        public Data_table()
        {
            data = new List<string[]>();
            dataType = "[]";
        }
        public List<string[]> data { get; set; }
        public int draw { get; set; }
        public int columnTotal { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string[] columnName { get; set; }
        public string dataType { get; set; }
        public int status { get; set; }
        public string msg { get; set; }
    }

    public class DataType
    {
        public DataType()
        {
            data = new List<Value>();
            default_value = "";
            type = "";
            query = "";
            database = "";
            attr = "";
        }
        public string type { get; set; }
        public string query { get; set; }
        public string database { get; set; }
        public List<Value> data { get; set; }
        public string attr { get; set; }
        public string default_value { get; set; }
    }

    public class Value
    {
        public string value { get; set; }
        public string name { get; set; }
    }

    public class MenuPermissions
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}