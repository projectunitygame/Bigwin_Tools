using CMS_Tools.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS_Tools.Model
{
    public class CategoryModel
    {
        string connectString = ConnectionDB.GetConnectionDB(Constants.STR_CONNECT_IDENTITY + "ManamentCMSTools_DB");
        private static CategoryModel instance = null;
        private static readonly object padlock = new object();
        public static CategoryModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new CategoryModel();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Thêm danh muc site
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="loginType"></param>
        /// <returns></returns>
        public int AddCategory(Entity.Categories p)
        {
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
                        cmd.CommandText = "sp_AddArticleCategory";
                        cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CategoryName"].Value = p.categoryName;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Description"].Value = p.description;
                        cmd.Parameters.Add("@Images", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@Images"].Value = JsonConvert.SerializeObject(p.images);
                        cmd.Parameters.Add("@Link", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Link"].Value = p.link;
                        cmd.Parameters.Add("@ParentID", SqlDbType.Int);
                        cmd.Parameters["@ParentID"].Value = p.parentId;
                        cmd.Parameters.Add("@PublisherID", SqlDbType.Int);
                        cmd.Parameters["@PublisherID"].Value = p.publisherId;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = p.status;
                        cmd.Parameters.Add("@AccountId", SqlDbType.Int);
                        cmd.Parameters["@AccountId"].Value = p.accountId;
                        cmd.Parameters.Add("@IsMenu", SqlDbType.TinyInt);
                        cmd.Parameters["@IsMenu"].Value = p.isMenu;
                        cmd.Parameters.Add("@DisplayIndex", SqlDbType.SmallInt);
                        cmd.Parameters["@DisplayIndex"].Value = p.displayIndex;
                        cmd.Parameters.Add("@CategoryType", SqlDbType.TinyInt);
                        cmd.Parameters["@CategoryType"].Value = p.categoryType;
                        cmd.Parameters.Add("@LanguageCode", SqlDbType.VarChar, 50);
                        cmd.Parameters["@LanguageCode"].Value = p.languageCode;
                        cmd.Parameters.Add("@Icon", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Icon"].Value = p.icon;
                        cmd.Parameters.Add("@CSS", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@CSS"].Value = p.css;
                        cmd.Parameters.Add("@HTML", SqlDbType.NVarChar, 4000);
                        cmd.Parameters["@HTML"].Value = p.html;
                        cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@MetaDescription"].Value = p.metaDescription;
                        cmd.Parameters.Add("@MetaKeyword", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@MetaKeyword"].Value = p.metaKeyword;
                        cmd.Parameters.Add("@CategoryTags", SqlDbType.NVarChar, 1500);
                        cmd.Parameters["@CategoryTags"].Value = p.categoryTags;
                        cmd.Parameters.Add("@ActionTags", SqlDbType.NVarChar, 1500);
                        cmd.Parameters["@ActionTags"].Value = p.actionTags;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        p.msg = cmd.Parameters["@Msg"].Value.ToString();
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error AddCategory: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật danh mục site
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int UpdateCategory(Entity.Categories p)
        {
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
                        cmd.CommandText = "sp_UpdateArticleCategory";
                        cmd.Parameters.Add("@CategoryId", SqlDbType.Int);
                        cmd.Parameters["@CategoryId"].Value = p.categoryId;
                        cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 150);
                        cmd.Parameters["@CategoryName"].Value = p.categoryName;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Description"].Value = p.description;
                        cmd.Parameters.Add("@Images", SqlDbType.NVarChar, -1);
                        cmd.Parameters["@Images"].Value = JsonConvert.SerializeObject(p.images);
                        cmd.Parameters.Add("@Link", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Link"].Value = p.link;
                        cmd.Parameters.Add("@ParentID", SqlDbType.Int);
                        cmd.Parameters["@ParentID"].Value = p.parentId;
                        cmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                        cmd.Parameters["@Status"].Value = p.status;
                        cmd.Parameters.Add("@AccountId", SqlDbType.Int);
                        cmd.Parameters["@AccountId"].Value = p.accountId;
                        cmd.Parameters.Add("@IsMenu", SqlDbType.TinyInt);
                        cmd.Parameters["@IsMenu"].Value = p.isMenu;
                        cmd.Parameters.Add("@DisplayIndex", SqlDbType.SmallInt);
                        cmd.Parameters["@DisplayIndex"].Value = p.displayIndex;
                        cmd.Parameters.Add("@CategoryType", SqlDbType.TinyInt);
                        cmd.Parameters["@CategoryType"].Value = p.categoryType;
                        cmd.Parameters.Add("@Icon", SqlDbType.VarChar, 50);
                        cmd.Parameters["@Icon"].Value = p.icon;
                        cmd.Parameters.Add("@CSS", SqlDbType.NVarChar, 2000);
                        cmd.Parameters["@CSS"].Value = p.css;
                        cmd.Parameters.Add("@HTML", SqlDbType.NVarChar, 4000);
                        cmd.Parameters["@HTML"].Value = p.html;
                        cmd.Parameters.Add("@MetaDescription", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@MetaDescription"].Value = p.metaDescription;
                        cmd.Parameters.Add("@MetaKeyword", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@MetaKeyword"].Value = p.metaKeyword;
                        cmd.Parameters.Add("@CategoryTags", SqlDbType.NVarChar, 1500);
                        cmd.Parameters["@CategoryTags"].Value = p.categoryTags;
                        cmd.Parameters.Add("@ActionTags", SqlDbType.NVarChar, 1500);
                        cmd.Parameters["@ActionTags"].Value = p.actionTags;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        p.msg = cmd.Parameters["@Msg"].Value.ToString();
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error AddCategory: " + ex, ex);
                p.msg = "Lỗi hệ thống không thể cập nhật!";
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove danh muc (status = 255)
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int RemoveCategory(int categoryID, ref string msg)
        {
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
                        cmd.CommandText = "sp_RemoveArticleCategory";
                        cmd.Parameters.Add("@CategoryId", SqlDbType.Int);
                        cmd.Parameters["@CategoryId"].Value = categoryID;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        msg = cmd.Parameters["@Msg"].Value.ToString();
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error RemoveCategory: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        public int AddCategoryTags(Entity.CategoryTags p)
        {
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
                        cmd.CommandText = "sp_AddCategoryTags";
                        cmd.Parameters.Add("@Tags", SqlDbType.NVarChar, 250);
                        cmd.Parameters["@Tags"].Value = p.Tags;
                        cmd.Parameters.Add("@PublisherId", SqlDbType.Int);
                        cmd.Parameters["@PublisherId"].Value = p.PublisherId;
                        cmd.Parameters.Add("@AccountId", SqlDbType.Int);
                        cmd.Parameters["@AccountId"].Value = p.AccountId;
                        cmd.Parameters.Add("@CategoryID", SqlDbType.Int);
                        cmd.Parameters["@CategoryID"].Value = p.CategoryID;
                        cmd.Parameters.Add("@TagType", SqlDbType.VarChar, 50);
                        cmd.Parameters["@TagType"].Value = p.TagType;
                        cmd.Parameters.Add("@Code", SqlDbType.Int);
                        cmd.Parameters["@Code"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 500);
                        cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int code = int.Parse(cmd.Parameters["@Code"].Value.ToString());
                        p.Msg = cmd.Parameters["@Msg"].Value.ToString();
                        return code;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error AddCategoryTags: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetCategoryTags(int publisherID, string tagsType)
        {
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
                        cmd.CommandText = "sp_GetCategoryTags";
                        cmd.Parameters.Add("@PublisherID", SqlDbType.Int);
                        cmd.Parameters["@PublisherID"].Value = publisherID;
                        cmd.Parameters.Add("@TagType", SqlDbType.VarChar, 50);
                        cmd.Parameters["@TagType"].Value = tagsType;

                        DataTable dt = new DataTable();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(dr);
                        }
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Logs.SaveError("Error GetCategoryTags: " + ex, ex);
                throw new Exception(ex.Message);
            }
        }
    }
}