﻿using MySql.Data.MySqlClient;
using StatsUpdate_win_Service;
//using DemoWinService;2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatsUpdate_win_Service
{
    public partial class StatsUpdate_win_service : ServiceBase
    {

        shortenurlEntities dc = new shortenurlEntities();
        System.Threading.Timer _timer;
        public StatsUpdate_win_service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MSYNC();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = new TimeSpan(1, 0, 0, 0).TotalMilliseconds;
            //timer.Interval = 1000;
            //timer.Interval = 60000 * 60;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            // _timer.Change(0, 2000);
        }

        protected void timer_Elapsed(object source, System.Timers.ElapsedEventArgs aa)
        {
            MSYNC();
        }
        protected override void OnStop()
        {
        }
        public void MSYNC()
        {
            try
            {

                List<stat_counts> stat_list1 = dc.stat_counts.Select(x => x).ToList();
                //List<Camp_stat_sp> camp_stat_lst = getcamp_stat(stat_list1);
                List<stat_counts> stat_list2 = new List<stat_counts>();
                stat_list2 = stat_list1;
                DateTime todaysDate = DateTime.UtcNow.Date;
                int daysinmonth = DateTime.DaysInMonth(todaysDate.Year, todaysDate.Month);
                stat_list1 = (from st1 in stat_list1
                              //join cmp in camp_stat_lst on st1.FK_Rid equals cmp.Fk_rid
                              select new stat_counts()
                              {
                                  
                                  
                                  UniqueUsersLast7days = ((st1.DaysCount_Week < 2) ? (st1.UniqueUsersYesterday + st1.UniqueUsersToday) : 0)
                                                        + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.UniqueUsersLast7days + st1.UniqueUsersYesterday + st1.UniqueUsersToday) : 0),
                                  UsersLast7days = ((st1.DaysCount_Week < 2) ? (st1.UsersYesterday + st1.UsersToday) : 0)
                                                  + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.UsersLast7days + st1.UsersYesterday + st1.UsersToday) : 0),
                                  UniqueUsersYesterday = st1.UniqueUsersToday,
                                  UsersYesterday = st1.UsersToday,
                                  
                                  //UniqueUsersToday = 0,
                                  //UsersToday = 0,
                                  // UniqueUsersLast7days=st1.UniqueUsersLast7days,
                                  //UsersLast7days = st1.UsersLast7days,
                                  
                                  
                                  UniqueVisitsLast7day = ((st1.DaysCount_Week < 2) ? (st1.UniqueVisitsYesterday + st1.UniqueVisitsToday) : 0)
                                                        + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.UniqueVisitsLast7day + st1.UniqueVisitsYesterday + st1.UniqueVisitsToday) : 0),
                                  VisitsLast7days = ((st1.DaysCount_Week < 2) ? (st1.VisitsYesterday + st1.VisitsToday) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.VisitsLast7days + st1.VisitsYesterday + st1.VisitsToday) : 0),
                                  UniqueVisits = st1.UniqueVisits,
                                  VisitsYesterday = st1.VisitsToday,
                                  UniqueVisitsYesterday = st1.UniqueVisitsToday,
                                  
                                  RevisitsTotal_Yesterday = st1.RevisitsTotal_Today,
                                  NoVisitsTotal_Yesterday = st1.NoVisitsTotal_Today,
                                  //VisitsToday = 0,
                                  //UniqueVisitsToday = 0,
                                  //UniqueVisitsLast7day = st1.UniqueVisitsLast7day,
                                  //VisitsLast7days = st1.VisitsLast7days,
                                  CampaignsLast7days = (st1.DaysCount_Week < 7) ? (st1.CampaignsLast7days) : 0,
                                  

                                  

                                  UrlTotal_Week = ((st1.DaysCount_Week < 2) ? (st1.UrlTotal_Today) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.UrlTotal_Week + st1.UrlTotal_Today):0),
                                  UrlPercent_Week = ((st1.DaysCount_Week < 2) ? (st1.UrlPercent_Today) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.UrlPercent_Week + st1.UrlPercent_Today) : 0),
                                  VisitsTotal_Week = ((st1.DaysCount_Week < 2) ? (st1.VisitsTotal_Today) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.VisitsTotal_Week + st1.VisitsTotal_Today) : 0),
                                  VisitsPercent_Week = ((st1.DaysCount_Week < 2) ? (st1.VisitsPercent_Today) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.VisitsPercent_Week + st1.VisitsPercent_Today) : 0),
                                  RevisitsTotal_Week = ((st1.DaysCount_Week < 2) ? (st1.RevisitsTotal_Today) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.RevisitsTotal_Week + st1.RevisitsTotal_Today) : 0),
                                  RevisitsPercent_Week = ((st1.DaysCount_Week < 2) ? (st1.RevisitsPercent_Today) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.RevisitsPercent_Week + st1.RevisitsPercent_Today) : 0),
                                  NoVisitsTotal_Week = ((st1.DaysCount_Week < 2) ? (st1.NoVisitsTotal_Today) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.NoVisitsTotal_Week + st1.NoVisitsTotal_Today) : 0),
                                  NoVisitsPercent_Week = ((st1.DaysCount_Week < 2) ? (st1.NoVisitsPercent_Today) : 0)
                                                    + ((st1.DaysCount_Week >= 2 && st1.DaysCount_Week < 7) ? (st1.NoVisitsTotal_Week + st1.NoVisitsPercent_Today) : 0),

                                  CampaignsMonth = (st1.DaysCount_Month < daysinmonth) ? (st1.CampaignsMonth) : 0,
                                  UrlTotal_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.UrlTotal_Month + st1.UrlTotal_Week) : 0,
                                  UrlTotalPercent_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.UrlTotalPercent_Month + st1.UrlPercent_Week) : 0,
                                  VisitsTotal_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.VisitsTotal_Month + st1.VisitsTotal_Week) : 0,
                                  VisitsPercent_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.VisitsPercent_Month + st1.VisitsPercent_Week) : 0,
                                  RevisitsTotal_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.RevisitsTotal_Month + st1.RevisitsTotal_Week) : 0,
                                  RevisitsPercent_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.RevisitsPercent_Month + st1.RevisitsPercent_Week) : 0,
                                  NoVisitsTotal_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.NoVisitsTotal_Month + st1.NoVisitsTotal_Week) : 0,
                                  NoVisitsPercent_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.NoVisitsPercent_Month + st1.NoVisitsPercent_Week) : 0,
                                  
                                  UrlTotal_Today = 0,
                                  UrlPercent_Today = 0,
                                  VisitsTotal_Today = 0,
                                  VisitsPercent_Today = 0,
                                  RevisitsTotal_Today = 0,
                                  RevisitsPercent_Today = 0,
                                  NoVisitsTotal_Today = 0,
                                  NoVisitsPercent_Today = 0,

                                  UniqueUsersToday = 0,
                                  UsersToday = 0,
                                  VisitsToday = 0,
                                  UniqueVisitsToday = 0,
                                  //UrlTotal_Today = st1.UrlTotal_Today,
                                  //UrlPercent_Today = st1.UrlPercent_Today,
                                  //VisitsTotal_Today = st1.VisitsTotal_Today,
                                  //VisitsPercent_Today = st1.VisitsPercent_Today,
                                  //RevisitsTotal_Today = st1.RevisitsTotal_Today,
                                  //RevisitsTotal_Yesterday=st1.RevisitsTotal_Today,
                                  //RevisitsPercent_Today = st1.RevisitsPercent_Today,
                                  //NoVisitsTotal_Today = st1.NoVisitsTotal_Today,
                                  //NoVisitsTotal_Yesterday=st1.NoVisitsTotal_Today,
                                  //NoVisitsPercent_Today = st1.NoVisitsPercent_Today,
                                  

                                  DaysCount_Week = (st1.DaysCount_Week < 7) ? (st1.DaysCount_Week + 1) : 0,
                                  DaysCount_Month = (st1.DaysCount_Month < daysinmonth) ? (st1.DaysCount_Month + 1) : 0,
                                  FK_Rid=st1.FK_Rid,
                                  FK_ClientID=st1.FK_ClientID
                              }
                ).ToList();
                //dc.SaveChanges();
                int rec = 0;
                foreach (stat_counts st in stat_list2)
                {
                    st.UniqueUsersToday = stat_list1[rec].UniqueUsersToday;
                    st.UsersToday = stat_list1[rec].UsersToday;
                    st.UniqueUsersYesterday = stat_list1[rec].UniqueUsersYesterday;
                    st.UsersYesterday = stat_list1[rec].UsersYesterday;
                    st.UniqueUsersLast7days = stat_list1[rec].UniqueUsersLast7days;
                    st.UsersLast7days = stat_list1[rec].UsersLast7days;
                    st.VisitsToday = stat_list1[rec].VisitsToday;
                    st.UniqueVisits = stat_list1[rec].UniqueVisits;
                    st.UniqueVisitsToday = stat_list1[rec].UniqueVisitsToday;
                    st.VisitsYesterday = stat_list1[rec].VisitsYesterday;
                    st.UniqueVisitsYesterday = stat_list1[rec].UniqueVisitsYesterday;
                    st.UniqueVisitsLast7day = stat_list1[rec].UniqueVisitsLast7day;
                    st.VisitsLast7days = stat_list1[rec].VisitsLast7days;
                    st.CampaignsLast7days = stat_list1[rec].CampaignsLast7days;
                    st.CampaignsMonth = stat_list1[rec].CampaignsMonth;
                    st.UrlTotal_Today = stat_list1[rec].UrlTotal_Today;
                    st.UrlPercent_Today = stat_list1[rec].UrlPercent_Today;
                    st.VisitsTotal_Today = stat_list1[rec].VisitsTotal_Today;
                    st.VisitsPercent_Today = stat_list1[rec].VisitsPercent_Today;
                    st.RevisitsTotal_Today = stat_list1[rec].RevisitsTotal_Today;
                    st.RevisitsPercent_Today = stat_list1[rec].RevisitsPercent_Today;
                    st.NoVisitsTotal_Today = stat_list1[rec].NoVisitsTotal_Today;
                    st.NoVisitsPercent_Today = stat_list1[rec].NoVisitsPercent_Today;
                    st.RevisitsTotal_Yesterday = stat_list1[rec].RevisitsTotal_Yesterday;
                    st.NoVisitsTotal_Yesterday = stat_list1[rec].NoVisitsTotal_Yesterday;

                    st.UrlTotal_Week = stat_list1[rec].UrlTotal_Week;
                    st.UrlPercent_Week = stat_list1[rec].UrlPercent_Week;
                    st.VisitsTotal_Week = stat_list1[rec].VisitsTotal_Week;
                    st.VisitsPercent_Week = stat_list1[rec].VisitsPercent_Week;
                    st.RevisitsTotal_Week = stat_list1[rec].RevisitsTotal_Week;
                    st.RevisitsPercent_Week = stat_list1[rec].RevisitsPercent_Week;
                    st.NoVisitsTotal_Week = stat_list1[rec].NoVisitsTotal_Week;
                    st.NoVisitsPercent_Week = stat_list1[rec].NoVisitsPercent_Week;

                    st.UrlTotal_Month = stat_list1[rec].UrlTotal_Month;
                    st.UrlTotalPercent_Month = stat_list1[rec].UrlTotalPercent_Month;
                    st.VisitsTotal_Month = stat_list1[rec].VisitsTotal_Month;
                    st.VisitsPercent_Month = stat_list1[rec].VisitsPercent_Month;
                    st.RevisitsTotal_Month = stat_list1[rec].RevisitsTotal_Month;
                    st.RevisitsPercent_Month = stat_list1[rec].RevisitsPercent_Month;
                    st.NoVisitsTotal_Month = stat_list1[rec].NoVisitsTotal_Month;
                    st.NoVisitsPercent_Month = stat_list1[rec].NoVisitsPercent_Month;

                    st.DaysCount_Week = stat_list1[rec].DaysCount_Week;
                    st.DaysCount_Month = stat_list1[rec].DaysCount_Month;
                    rec = rec + 1;
                }
                dc.SaveChanges();
            }


            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
            }
        }

        public List<Camp_stat_sp> getcamp_stat(List<stat_counts> lst_stat_count)
        {
            shortenurlEntities dc = new shortenurlEntities();
            MySqlConnection lSQLConn = null;
            MySqlCommand lSQLCmd = new MySqlCommand();
            List<Camp_stat_sp> lst_camp = new List<Camp_stat_sp>();
            foreach (stat_counts st in lst_stat_count)
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ConnectionString;

                // create and open a connection object
                lSQLConn = new MySqlConnection(connStr);
                lSQLCmd.Parameters.Clear();
                MySqlDataReader myReader;
                lSQLConn.Open();
                lSQLCmd.CommandType = CommandType.StoredProcedure;
                lSQLCmd.CommandTimeout = 600;
                if (st.FK_Rid != 0)
                {
                    lSQLCmd.CommandText = "spGetCampaignStats";
                    lSQLCmd.Parameters.Add(new MySqlParameter("@rid", st.FK_Rid));
                }
                else
                {
                    lSQLCmd.CommandText = "spGetDashBoardStats";
                    lSQLCmd.Parameters.Add(new MySqlParameter("@FkClientId", "0"));
                }
                lSQLCmd.Connection = lSQLConn;
                myReader = lSQLCmd.ExecuteReader();


                uniqueUsersToday1 uniqueUsersToday = ((IObjectContextAdapter)dc)
                  .ObjectContext
                  .Translate<uniqueUsersToday1>(myReader, "shorturldatas", MergeOption.AppendOnly).SingleOrDefault();
                myReader.NextResult();
                uniqueVisits1 uniqueVisits = ((IObjectContextAdapter)dc)
                     .ObjectContext
                     .Translate<uniqueVisits1>(myReader, "shorturldatas", MergeOption.AppendOnly).SingleOrDefault();
                myReader.NextResult();
                List<uniqueVisitsToday1> uniqueVisitsToday = ((IObjectContextAdapter)dc)
                     .ObjectContext
                     .Translate<uniqueVisitsToday1>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();
                myReader.NextResult();
                //uniqueVisitsLast7day1 uniqueVisitsLast7day = ((IObjectContextAdapter)dc)
                //            .ObjectContext
                //            .Translate<uniqueVisitsLast7day1>(myReader, "shorturldatas", MergeOption.AppendOnly).SingleOrDefault();
                //myReader.NextResult();
                //visitsLast7days1 visitsLast7days = ((IObjectContextAdapter)dc)
                //    .ObjectContext
                //    .Translate<visitsLast7days1>(myReader, "shorturldatas", MergeOption.AppendOnly).SingleOrDefault();
                //myReader.NextResult();
                // List<recentCampaigns1> recentCampaigns = ((IObjectContextAdapter)dc)
                //.ObjectContext
                //.Translate<recentCampaigns1>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();
                // myReader.NextResult();
                if (st.FK_Rid == 0)
                    myReader.NextResult();
                today1 today1 = ((IObjectContextAdapter)dc)
               .ObjectContext
               .Translate<today1>(myReader, "shorturldatas", MergeOption.AppendOnly).SingleOrDefault();
                Camp_stat_sp cmp = new Camp_stat_sp();
                cmp.UniqueUsersToday = (uniqueUsersToday != null) ? (uniqueUsersToday.uniqueUsersToday) : 0;
                cmp.UniqueVisits = (uniqueVisits != null) ? (uniqueVisits.uniqueVisits) : 0;
                cmp.UniqueVisitsToday = (uniqueVisitsToday != null) ? (uniqueVisitsToday.Sum(x => x.uniqueVisitsToday)) : 0;
                //cmp.uniqueVisitsLast7day = (uniqueVisitsLast7day != null) ? (uniqueVisitsLast7day.uniqueVisitsLast7day) : 0;
                //cmp.visitsLast7days = (visitsLast7days != null) ? (visitsLast7days.visitsLast7days) : 0;
                cmp.RevisitsTotal_Today = (today1 != null) ? (today1.revisitsTotal) : 0;
                cmp.RevisitsPercent_Today = (today1 != null) ? (today1.revisitsPercent) : 0;
                cmp.NoVisitsTotal_Today = (today1 != null) ? (today1.noVisitsTotal) : 0;
                cmp.NoVisitsPercent_Today = (today1 != null) ? (today1.noVisitsPercent) : 0;
                cmp.Fk_rid = st.FK_Rid;
                lst_camp.Add(cmp);

                st.UniqueUsersToday = (st.UniqueUsersToday < cmp.UniqueUsersToday) ? cmp.UniqueUsersToday : st.UniqueUsersToday;
                st.UniqueVisits = cmp.UniqueVisits;
                st.UniqueVisitsToday = (st.UniqueVisitsToday < cmp.UniqueVisitsToday) ? cmp.UniqueVisitsToday : st.UniqueVisitsToday;
                st.RevisitsTotal_Today = (st.RevisitsTotal_Today < cmp.RevisitsTotal_Today) ? cmp.RevisitsTotal_Today : st.RevisitsTotal_Today;
                st.RevisitsPercent_Today =(st.RevisitsPercent_Today<cmp.RevisitsPercent_Today) ?cmp.RevisitsPercent_Today:st.RevisitsPercent_Today;
                st.NoVisitsTotal_Today = (st.NoVisitsTotal_Today < cmp.NoVisitsTotal_Today) ? cmp.NoVisitsTotal_Today : st.NoVisitsTotal_Today;
                st.NoVisitsPercent_Today = (st.NoVisitsPercent_Today < cmp.NoVisitsPercent_Today) ? cmp.NoVisitsPercent_Today : st.NoVisitsPercent_Today;
                dc.SaveChanges();
            }
            return lst_camp;
        }
   
    }
}