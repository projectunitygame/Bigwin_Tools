using CMS_Tools.Lib;
using CMS_Tools.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CMS_Tools.Apis
{
    /// <summary>
    /// Summary description for Categories
    /// </summary>
    public class Categories : IHttpHandler, IRequiresSessionState
    {
        UserInfo accountInfo;
        ResultCategory result = new ResultCategory();
        ManagerDAO manageDao = new ManagerDAO();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=utf-8";
            #region CHECK ACCOUNT LOGIN
            accountInfo = Account.GetAccountInfo(context);
            if (accountInfo == null)
            {
                result.status = (int)Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN;
                result.msg = Constants.NUMBER_CODE.ACCOUNT_NOT_LOGIN.ToString();
                context.Response.Write(JsonConvert.SerializeObject(result));
                return;
            }
            #endregion

            Constants.REQUEST_TYPE requestType = (Constants.REQUEST_TYPE)int.Parse(context.Request.Form["type"]);
            switch (requestType)
            {
                case Constants.REQUEST_TYPE.ADD_CATEGORY:
                    ADD_CATEGORY(context);
                    break;
                case Constants.REQUEST_TYPE.UPDATE_CATEGORY:
                    UPDATE_CATEGORY(context);
                    break;
                case Constants.REQUEST_TYPE.REMOVE_CATEGORY:
                    REMOVE_CATEGORY(context);
                    break;
                case Constants.REQUEST_TYPE.GET_CATEGORIES_TAGS:
                    GET_CATEGORIES_TAGS(context);
                    break;
                default:
                    result.status = (int)Constants.NUMBER_CODE.REQUEST_NOT_FOUND;
                    result.msg = Constants.NUMBER_CODE.REQUEST_NOT_FOUND.ToString();
                    break;
            }
        }

        private void GET_CATEGORIES_TAGS(HttpContext context)
        {
            try
            {
                string tagType = context.Request.Unvalidated.Form["tagtype"];
                if (!string.IsNullOrEmpty(tagType))
                {
                    var data = manageDao.CategoryModel.GetCategoryTags(accountInfo.PublisherID, tagType);
                    result.data = data;
                    result.status = data.Rows.Count;
                }
                else
                {
                    result.status = (int)Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Dữ liệu không hợp lệ!";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR GET_CATEGORIES_TAGS: " + ex);
                result.status = (int)Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void REMOVE_CATEGORY(HttpContext context)
        {
            try
            {
                string categoryID = context.Request.Unvalidated.Form["id"];
                if (!string.IsNullOrEmpty(categoryID))
                {
                    string msg = "";
                    int code = manageDao.CategoryModel.RemoveCategory(int.Parse(categoryID), ref msg);
                    result.status = code;
                    result.msg = msg;
                }
                else
                {
                    result.status = (int)Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Dữ liệu không hợp lệ!";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR REMOVE_CATEGORY: " + ex);
                result.status = (int)Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void UPDATE_CATEGORY(HttpContext context)
        {
            try
            {
                string json = context.Request.Unvalidated.Form["json"];
                if (!string.IsNullOrEmpty(json))
                {
                    var d = JsonConvert.DeserializeObject<Entity.Categories>(json);
                    d.accountId = accountInfo.AccountId;
                    d.publisherId = accountInfo.PublisherID;
                    int code = manageDao.CategoryModel.UpdateCategory(d);
                    if(code == 0)
                    {
                        if (!string.IsNullOrEmpty(d.categoryTags))
                        {
                            int r = manageDao.CategoryModel.AddCategoryTags(new Entity.CategoryTags()
                            {
                                AccountId = accountInfo.AccountId,
                                CategoryID = d.categoryId,
                                PublisherId = accountInfo.PublisherID,
                                Tags = d.categoryTags,
                                TagType = "catagorytags"
                            });
                        }

                        if (!string.IsNullOrEmpty(d.actionTags))
                        {
                            int r = manageDao.CategoryModel.AddCategoryTags(new Entity.CategoryTags()
                            {
                                AccountId = accountInfo.AccountId,
                                CategoryID = d.categoryId,
                                PublisherId = accountInfo.PublisherID,
                                Tags = d.actionTags,
                                TagType = "actiontags"
                            });
                        }
                    }
                    result.status = code;
                    result.msg = d.msg;
                }
                else
                {
                    result.status = (int)Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Dữ liệu không hợp lệ!";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR UPDATE_CATEGORY: " + ex);
                result.status = (int)Constants.NUMBER_CODE.ERROR_EX;
                result.msg = "Lỗi hệ thống không thể cập nhật !";
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        private void ADD_CATEGORY(HttpContext context)
        {
            try
            {
                string json = context.Request.Unvalidated.Form["json"];
                if (!string.IsNullOrEmpty(json))
                {
                    var d = JsonConvert.DeserializeObject<Entity.Categories>(json);
                    d.accountId = accountInfo.AccountId;
                    d.publisherId = accountInfo.PublisherID;
                    int code = manageDao.CategoryModel.AddCategory(d);
                    if(code > 0)
                    {
                        if (!string.IsNullOrEmpty(d.categoryTags))
                        {
                            int r = manageDao.CategoryModel.AddCategoryTags(new Entity.CategoryTags()
                            {
                                AccountId = accountInfo.AccountId,
                                CategoryID = d.categoryId,
                                PublisherId = accountInfo.PublisherID,
                                Tags = d.categoryTags,
                                TagType = "catagorytags"
                            });
                        }
                        if (!string.IsNullOrEmpty(d.actionTags))
                        {
                            int r = manageDao.CategoryModel.AddCategoryTags(new Entity.CategoryTags()
                            {
                                AccountId = accountInfo.AccountId,
                                CategoryID = d.categoryId,
                                PublisherId = accountInfo.PublisherID,
                                Tags = d.actionTags,
                                TagType = "actiontags"
                            });
                        }
                    }
                    result.status = code;
                    result.msg = d.msg;
                }
                else
                {
                    result.status = (int)Constants.NUMBER_CODE.DATA_NULL;
                    result.msg = "Dữ liệu không hợp lệ!";
                }
            }
            catch (Exception ex)
            {
                Logs.SaveError("ERROR ADD_CATEGORY: " + ex);
                result.status = (int)Constants.NUMBER_CODE.ERROR_EX;
                result.msg = Constants.NUMBER_CODE.ERROR_EX.ToString();
            }
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class ResultCategory
    {
        public int status { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }
}