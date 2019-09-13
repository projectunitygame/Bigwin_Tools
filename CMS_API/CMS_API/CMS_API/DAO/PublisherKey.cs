using api_cms.common;
using api_cms.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_cms.DAO
{
    public class PublisherKey
    {
        private static Dictionary<string, Entity.PublisherKey> LIST_PUBLISHER_KEY = new Dictionary<string, Entity.PublisherKey>();
        private static readonly object _lock = new object();

        private Entity.PublisherKey GetPublisherInfo(string key, string serverIP,short serviceID)
        {
            try
            {
                lock (_lock)
                {
                    if (LIST_PUBLISHER_KEY == null)
                        LIST_PUBLISHER_KEY = new Dictionary<string, Entity.PublisherKey>();

                    if (!string.IsNullOrEmpty(key) && LIST_PUBLISHER_KEY.ContainsKey(key))
                    {
                        Entity.PublisherKey p;
                        LIST_PUBLISHER_KEY.TryGetValue(key, out p);
                        return p;
                    }
                    else
                    {
                        Models.ManagerModel managerModel = new Models.ManagerModel();
                        int code = -1;
                        var p = managerModel.CustomerModel.GetPublisherKey(key, serviceID, serverIP, ref code);
                        if (p != null && p.Rows.Count > 0 && code == 0)
                        {
                            if (!LIST_PUBLISHER_KEY.ContainsKey(key))
                            {
                                Entity.PublisherKey publisherInfo = new Entity.PublisherKey();
                                publisherInfo.publisherID = int.Parse(p.Rows[0]["PublisherID"].ToString());
                                publisherInfo.publickey = key;
                                publisherInfo.secretkey = p.Rows[0]["Secretkey"].ToString();
                                publisherInfo.serverIP = p.Rows[0]["ServerIP"].ToString();
                                publisherInfo.serviceID = short.Parse(p.Rows[0]["ServiceID"].ToString());
                                publisherInfo.version = p.Rows[0]["Version"].ToString();
                                LIST_PUBLISHER_KEY.Add(key, publisherInfo);
                                LogClass.SaveLog("Cache Publisher: " + JsonConvert.SerializeObject(publisherInfo));
                            }
                            return LIST_PUBLISHER_KEY[key];
                        }
                        else
                            return new Entity.PublisherKey();
                    }
                }
            }
            catch (Exception ex)
            {
                LogClass.SaveError("Error GetPublisherInfo: " + ex.ToString(), ex, true);
                return new Entity.PublisherKey();
            }
        }

        public ResultApi CheckPublickey(PayloadApi p, string currentVersion) {
            ResultApi result = new ResultApi();
            try
            {
                if (p == null)
                {
                    result.status = (int)ERROR_CODDE.DATA_NULL;
                    result.msg = ERROR_CODDE.DATA_NULL.ToString();
                }
                else if (string.IsNullOrEmpty(p.data) || string.IsNullOrEmpty(p.clientIP) || string.IsNullOrEmpty(p.sign)
                    || string.IsNullOrEmpty(p.publickey))
                {
                    result.status = (int)ERROR_CODDE.DATA_INVALID;
                    result.msg = ERROR_CODDE.DATA_INVALID.ToString();
                }
                else
                {
                    if (p.sign == p.signServer)
                    {
                        string serverIP = UtilClass.GetIPAddress();
                        var publisherInfo = GetPublisherInfo(p.publickey, serverIP, p.serviceID);
                        if (!string.IsNullOrEmpty(publisherInfo.publickey))
                        {
                            if (publisherInfo.version == currentVersion)
                            {
                                string decryptData = Encryptor.DecryptString(p.data, publisherInfo.secretkey);
                                if (decryptData != "")
                                {
                                    result.data = decryptData;
                                    result.status = (int)ERROR_CODDE.SUCCESS;
                                    result.secreckey = publisherInfo.secretkey;
                                }
                                else
                                {
                                    result.status = (int)ERROR_CODDE.DATA_ENCRYPT_INVALID;
                                    result.msg = ERROR_CODDE.DATA_ENCRYPT_INVALID.ToString();
                                }
                            }
                            else
                            {
                                result.status = (int)ERROR_CODDE.VERSION_INVALID;
                                result.msg = ERROR_CODDE.VERSION_INVALID.ToString();
                            }
                        }
                        else
                        {
                            result.status = (int)ERROR_CODDE.PUBLICKEY_NOT_FOUND;
                            result.msg = ERROR_CODDE.PUBLICKEY_NOT_FOUND.ToString();
                        }
                    }
                    else
                    {
                        result.status = (int)ERROR_CODDE.SIGN_WRONG;
                        result.msg = ERROR_CODDE.SIGN_WRONG.ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogClass.SaveError("ERROR CheckPublickey: " + JsonConvert.SerializeObject(p), ex, true);
                result.status = (int)ERROR_CODDE.ERROR_EX;
                result.msg = ex.Message;
            }
            return result;
        }
    }
}