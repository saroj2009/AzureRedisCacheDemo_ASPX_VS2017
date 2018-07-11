using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using StackExchange.Redis;
using StackExchange.Redis.DataTypes;
using AzureRedisCacheDemo.Services;
using AzureRedisCacheDemo.Common;

namespace AzureRedisCacheDemo.Managers
{
    //public class CacheManager
    //{
    //}
    public class CacheManager
    {

        private static List<Fruit> GetFruitListFromDB()
        {
            var list = new List<Fruit>();
            //Pretending we are getting from database
            list.Add(new Fruit { FruitID = 1, Color = "Yellow", FruitName = "Banana" });
            list.Add(new Fruit { FruitID = 2, Color = "Purple", FruitName = "Grape" });
            list.Add(new Fruit { FruitID = 3, Color = "Red", FruitName = "Apple" });

            return list;
        }
        private static List<Company> GetCompanyFromDB()
        {
            var list = new List<Company>();
            //Pretending we are getting from database
            list.Add(new Company { Id = 1, CompanyName = "Microsoft", CountryHQ = "USA", CompanyRank=1 });
            list.Add(new Company { Id = 1, CompanyName = "Microsoft", CountryHQ = "USA", CompanyRank = 1 });
            list.Add(new Company { Id = 2, CompanyName = "Oracle", CountryHQ = "USA", CompanyRank = 2 });
            list.Add(new Company { Id = 3, CompanyName = "IBM", CountryHQ = "USA", CompanyRank = 3 });
            list.Add(new Company { Id = 4, CompanyName = "SAP", CountryHQ = "Germany", CompanyRank = 4 });
            list.Add(new Company { Id = 5, CompanyName = "Symantec", CountryHQ = "USA", CompanyRank = 5 });
            list.Add(new Company { Id = 6, CompanyName = "EMC", CountryHQ = "USA", CompanyRank = 6 });
            list.Add(new Company { Id = 7, CompanyName = "VMware", CountryHQ = "USA", CompanyRank = 7 });
            list.Add(new Company { Id = 8, CompanyName = "HP", CountryHQ = "USA", CompanyRank = 8 });
            list.Add(new Company { Id = 9, CompanyName = "Salesforce.com", CountryHQ = "USA", CompanyRank = 9 });
            list.Add(new Company { Id = 10, CompanyName = "Intuit", CountryHQ = "USA", CompanyRank = 10 });
            list.Add(new Company { Id = 11, CompanyName = "Intel", CountryHQ = "USA", CompanyRank = 25 });
            list.Add(new Company { Id = 12, CompanyName = "Cisco", CountryHQ = "USA", CompanyRank = 14 });
            list.Add(new Company { Id = 13, CompanyName = "Optum*", CountryHQ = "USA", CompanyRank = 54 });
            list.Add(new Company { Id = 14, CompanyName = "Fujitsu", CountryHQ = "Japan", CompanyRank = 17 });
            list.Add(new Company { Id = 15, CompanyName = "Oracle", CountryHQ = "USA", CompanyRank = 2 });
            list.Add(new Company { Id = 16, CompanyName = "Schneider Electric", CountryHQ = "France", CompanyRank = 55 });
            list.Add(new Company { Id = 17, CompanyName = "NEC", CountryHQ = "Japan", CompanyRank = 33 });
            list.Add(new Company { Id = 18, CompanyName = "EMC", CountryHQ = "USA", CompanyRank = 6 });
            list.Add(new Company { Id = 19, CompanyName = "SAP", CountryHQ = "Germany", CompanyRank = 4 });
            list.Add(new Company { Id = 20, CompanyName = "GE Healthcare", CountryHQ = "UK", CompanyRank = 60 });
            list.Add(new Company { Id = 21, CompanyName = "ADP", CountryHQ = "USA", CompanyRank = 28 });
            list.Add(new Company { Id = 22, CompanyName = "Symantec", CountryHQ = "USA", CompanyRank = 5 });
            list.Add(new Company { Id = 23, CompanyName = "NCR", CountryHQ = "USA", CompanyRank = 39 });
            list.Add(new Company { Id = 24, CompanyName = "NetApp", CountryHQ = "USA", CompanyRank = 38 });
            list.Add(new Company { Id = 25, CompanyName = "FIS", CountryHQ = "USA", CompanyRank = 68 });
            list.Add(new Company { Id = 26, CompanyName = "VMware", CountryHQ = "USA", CompanyRank = 7 });
            list.Add(new Company { Id = 27, CompanyName = "Salesforce.com", CountryHQ = "USA", CompanyRank = 9 });
            list.Add(new Company { Id = 28, CompanyName = "Fiserv", CountryHQ = "USA", CompanyRank = 56 });
            list.Add(new Company { Id = 29, CompanyName = "Wolters Kluwer", CountryHQ = "The Netherlands", CompanyRank = 29 });
            list.Add(new Company { Id = 30, CompanyName = "Intuit", CountryHQ = "USA", CompanyRank = 10 });
            list.Add(new Company { Id = 31, CompanyName = "Avaya", CountryHQ = "USA", CompanyRank = 57 });
            list.Add(new Company { Id = 32, CompanyName = "Adobe", CountryHQ = "USA", CompanyRank = 11 });
            list.Add(new Company { Id = 33, CompanyName = "Pitney Bowes", CountryHQ = "USA", CompanyRank = 97 });
            list.Add(new Company { Id = 34, CompanyName = "Hexagon", CountryHQ = "UK", CompanyRank = 35 });
            list.Add(new Company { Id = 35, CompanyName = "Cerner", CountryHQ = "USA", CompanyRank = 49 });
            list.Add(new Company { Id = 36, CompanyName = "Wincor Nixdorf", CountryHQ = "Germany", CompanyRank = 66 });
            list.Add(new Company { Id = 37, CompanyName = "Citrix", CountryHQ = "USA", CompanyRank = 19 });
            list.Add(new Company { Id = 38, CompanyName = "SAS*", CountryHQ = "USA", CompanyRank = 13 });
            list.Add(new Company { Id = 39, CompanyName = "Dassault Systemes", CountryHQ = "France", CompanyRank = 15 });
            list.Add(new Company { Id = 40, CompanyName = "Convergys", CountryHQ = "USA", CompanyRank = 79 });
            list.Add(new Company { Id = 41, CompanyName = "Infor", CountryHQ = "USA", CompanyRank = 23 });
            list.Add(new Company { Id = 42, CompanyName = "SunGard*", CountryHQ = "USA", CompanyRank = 32 });
            list.Add(new Company { Id = 43, CompanyName = "Teradata", CountryHQ = "USA", CompanyRank = 37 });
            list.Add(new Company { Id = 44, CompanyName = "Autodesk", CountryHQ = "USA", CompanyRank = 18 });
            list.Add(new Company { Id = 45, CompanyName = "Synopsys", CountryHQ = "USA", CompanyRank = 24 });
            list.Add(new Company { Id = 46, CompanyName = "BMC", CountryHQ = "USA", CompanyRank = 26 });
            list.Add(new Company { Id = 47, CompanyName = "Nuance Communications", CountryHQ = "USA", CompanyRank = 46 });
            list.Add(new Company { Id = 48, CompanyName = "OpenText", CountryHQ = "Canada", CompanyRank = 31 });
            list.Add(new Company { Id = 49, CompanyName = "Epic Systems*", CountryHQ = "USA", CompanyRank = 40 });
            list.Add(new Company { Id = 50, CompanyName = "Sage", CountryHQ = "UK", CompanyRank = 27 });
            list.Add(new Company { Id = 51, CompanyName = "Red Hat", CountryHQ = "USA", CompanyRank = 30 });
            list.Add(new Company { Id = 52, CompanyName = "Cadence Design Systems", CountryHQ = "USA", CompanyRank = 34 });
            list.Add(new Company { Id = 53, CompanyName = "Allscripts", CountryHQ = "USA", CompanyRank = 88 });
            list.Add(new Company { Id = 54, CompanyName = "PTC", CountryHQ = "USA", CompanyRank = 44 });
            list.Add(new Company { Id = 55, CompanyName = "Neusoft", CountryHQ = "China", CompanyRank = 80 });
            list.Add(new Company { Id = 56, CompanyName = "Mentor Graphics", CountryHQ = "USA", CompanyRank = 43 });
            list.Add(new Company { Id = 57, CompanyName = "Constellation Software", CountryHQ = "Canada", CompanyRank = 41 });
            list.Add(new Company { Id = 58, CompanyName = "Software AG", CountryHQ = "Germany", CompanyRank = 53 });
            list.Add(new Company { Id = 59, CompanyName = "Esri*", CountryHQ = "USA", CompanyRank = 48 });
            list.Add(new Company { Id = 60, CompanyName = "Visma", CountryHQ = "Norway", CompanyRank = 81 });
            list.Add(new Company { Id = 61, CompanyName = "DATEV*", CountryHQ = "Germany", CompanyRank = 47 });
            list.Add(new Company { Id = 62, CompanyName = "Verint Systems", CountryHQ = "USA", CompanyRank = 62 });
            list.Add(new Company { Id = 63, CompanyName = "Trend Micro", CountryHQ = "Japan", CompanyRank = 45 });
            list.Add(new Company { Id = 64, CompanyName = "Kronos*", CountryHQ = "USA", CompanyRank = 58 });
            list.Add(new Company { Id = 65, CompanyName = "Informatica", CountryHQ = "USA", CompanyRank = 51 });
            list.Add(new Company { Id = 66, CompanyName = "TIBCO*", CountryHQ = "USA", CompanyRank = 52 });
            list.Add(new Company { Id = 67, CompanyName = "ACI Worldwide", CountryHQ = "USA", CompanyRank = 84 });
            list.Add(new Company { Id = 68, CompanyName = "NICE SYSTEMS", CountryHQ = "Israel", CompanyRank = 75 });
            list.Add(new Company { Id = 69, CompanyName = "JDA Software*", CountryHQ = "USA", CompanyRank = 70 });
            list.Add(new Company { Id = 70, CompanyName = "Epicor Software", CountryHQ = "USA", CompanyRank = 61 });
            list.Add(new Company { Id = 71, CompanyName = "ANSYS", CountryHQ = "USA", CompanyRank = 50 });
            list.Add(new Company { Id = 72, CompanyName = "Micros Systems", CountryHQ = "USA", CompanyRank = 92 });
            list.Add(new Company { Id = 73, CompanyName = "Misys*", CountryHQ = "UK", CompanyRank = 69 });
            list.Add(new Company { Id = 74, CompanyName = "The Attachmate Group*", CountryHQ = "USA", CompanyRank = 59 });
            list.Add(new Company { Id = 75, CompanyName = "Genesys Telecommunications Laboratories*", CountryHQ = "USA", CompanyRank = 73 });
            list.Add(new Company { Id = 76, CompanyName = "FICO", CountryHQ = "USA", CompanyRank = 67 });
            list.Add(new Company { Id = 77, CompanyName = "SWIFT", CountryHQ = "Belgium", CompanyRank = 71 });
            list.Add(new Company { Id = 78, CompanyName = "Workday", CountryHQ = "USA", CompanyRank = 72 });
            list.Add(new Company { Id = 79, CompanyName = "Athenahealth", CountryHQ = "USA", CompanyRank = 64 });
            list.Add(new Company { Id = 80, CompanyName = "TOTVS", CountryHQ = "Brazil", CompanyRank = 74 });
            list.Add(new Company { Id = 81, CompanyName = "Concur Technologies", CountryHQ = "USA", CompanyRank = 63 });
            list.Add(new Company { Id = 82, CompanyName = "Kaspersky Lab*", CountryHQ = "Russia", CompanyRank = 65 });
            list.Add(new Company { Id = 83, CompanyName = "Unit4", CountryHQ = "The Netherlands", CompanyRank = 87 });
            list.Add(new Company { Id = 84, CompanyName = "ServiceNow", CountryHQ = "USA", CompanyRank = 76 });
            list.Add(new Company { Id = 85, CompanyName = "Blackboard*", CountryHQ = "USA", CompanyRank = 90 });
            list.Add(new Company { Id = 86, CompanyName = "Bentley Systems*", CountryHQ = "USA", CompanyRank = 78 });
            list.Add(new Company { Id = 87, CompanyName = "CommVault", CountryHQ = "USA", CompanyRank = 77 });
            list.Add(new Company { Id = 88, CompanyName = "Pegasystems", CountryHQ = "USA", CompanyRank = 93 });
            list.Add(new Company { Id = 89, CompanyName = "MicroStrategy", CountryHQ = "USA", CompanyRank = 95 });
            list.Add(new Company { Id = 90, CompanyName = "Palantir*", CountryHQ = "USA", CompanyRank = 86 });
            list.Add(new Company { Id = 91, CompanyName = "NetSuite", CountryHQ = "USA", CompanyRank = 94 });
            list.Add(new Company { Id = 92, CompanyName = "Micro Focus", CountryHQ = "UK", CompanyRank = 83 });
            list.Add(new Company { Id = 93, CompanyName = "MEDITECH", CountryHQ = "USA", CompanyRank = 89 });
            list.Add(new Company { Id = 94, CompanyName = "Ultimate Software", CountryHQ = "USA", CompanyRank = 99 });
            list.Add(new Company { Id = 95, CompanyName = "Qlik", CountryHQ = "USA", CompanyRank = 82 });
            list.Add(new Company { Id = 96, CompanyName = "InterSystems*", CountryHQ = "USA", CompanyRank = 85 });
            list.Add(new Company { Id = 97, CompanyName = "ESET*", CountryHQ = "Slovakia", CompanyRank = 96 });
            list.Add(new Company { Id = 98, CompanyName = "Splunk", CountryHQ = "USA", CompanyRank = 100 });
            list.Add(new Company { Id = 99, CompanyName = "SolarWinds", CountryHQ = "USA", CompanyRank = 98 });

            return list;
        }


        /// <summary>
        /// Getting a Fruit List from the Redis Cache
        /// </summary>
        /// <param name="IsRefreshCache">Optional to get fresh data from the datasource</param>
        /// <returns></returns>
        public static List<Fruit> GetFruitListFromCache(bool? IsRefreshCache = false)
        {
            bool IsRefresh = Convert.ToBoolean(IsRefreshCache);
            string cachename = "Common.FruitList";

            var list = new List<Fruit>();
            try
            {
                var cache = new CacheService();

                if (cache.IsAlive())
                {
                    if (cache.Exists(cachename))
                    {

                        if (IsRefresh)
                        {
                            list = GetFruitListFromDB();
                            if (list.Count > 0)
                            {
                                SaveToCache(cache, cachename, list);
                            }
                        }
                        else
                        {
                            list = RetrieveCacheByCacheName<Fruit>(cachename, cache);
                        }
                    }
                    else
                    {
                        list = GetFruitListFromDB();
                        if (list.Count > 0)
                        {
                            SaveToCache(cache, cachename, list);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                //TO DO if cache failed
                Console.Write(ex.Message);
            }

            return list;
        }

        public static List<Company> GetCompanyFromCache(bool? IsRefreshCache = false)
        {
            bool IsRefresh = Convert.ToBoolean(IsRefreshCache);
            string cachename = "Common.CompanyList";

            var list = new List<Company>();
            try
            {
                var cache = new CacheService();

                if (cache.IsAlive())
                {
                    if (cache.Exists(cachename))
                    {

                        if (IsRefresh)
                        {
                            list = GetCompanyFromDB();
                            if (list.Count > 0)
                            {
                                SaveToCache(cache, cachename, list);
                            }
                        }
                        else
                        {
                            list = RetrieveCacheByCacheName<Company>(cachename, cache);
                        }
                    }
                    else
                    {
                        list = GetCompanyFromDB();
                        if (list.Count > 0)
                        {
                            SaveToCache(cache, cachename, list);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                //TO DO if cache failed
                Console.Write(ex.Message);
            }

            return list;
        }
        public static void DeleteFruitList()
        {
            string cachename = "Common.FruitList";
            try
            {
                var cache = new CacheService();

                if (cache.IsAlive())
                {
                    if (cache.Exists(cachename))
                    {
                        cache.Remove(cachename);
                    }

                    #region purpose: quick checking if the cache is deleted
                    //if (cache.Exists(cachename))
                    //{
                    //    Console.Write("still exist");
                    //}
                    //else
                    //{
                    //    Console.Write("deleted");
                    //}
                    #endregion
                }


            }
            catch (Exception ex)
            {
                //TO DO if delete failed
                Console.Write(ex.Message);
            }

        }


        #region cache operations

        private static List<T> RetrieveCacheByCacheName<T>(string cachename, CacheService cache)
        {
            var genList = new List<T>();

            if (cache.IsAlive())
            {
                if (cache.Exists(cachename))
                {
                    var deserializeObj = cache.Get(cachename);

                    genList = JsonConvert.DeserializeObject<List<T>>(deserializeObj);
                }
            }
            return genList;
        }

        private static void SaveToCache<T>(CacheService cache, string cachename, T t)
        {
            string serializeObj = Serialize(t);
            cache.Save(cachename, serializeObj, new TimeSpan(23, 55, 0));
        }


        #endregion

        #region supports

        private static string Serialize(object o)
        {
            string s = string.Empty;

            s = JsonConvert.SerializeObject(o);

            return s;
        }

        #endregion
    }
}