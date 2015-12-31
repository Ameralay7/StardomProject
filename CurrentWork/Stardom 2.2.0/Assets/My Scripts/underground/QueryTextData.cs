using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class QueryTextData : MonoBehaviour {


	public static string[] SEARCH_TEXT_LIST = new string[]    {
		"1000-1500", 
		"1500-3000", 
		"3000-5000",
		"Male", 
		"Female", 
		"Online", 
		"Offline", 
		"Recently Joined"};



    //public static KiiClause EQ_CLAUSE_ONLINE = KiiClause.Equals("onlineNow", 1);
    //public static KiiClause EQ_CLAUSE_OFFLINE = KiiClause.Equals("onlineNow", 0);

    //public static KiiClause EQ_CLAUSE_MALE = KiiClause.Equals("gender", "male");
    //public static KiiClause EQ_CLAUSE_FEMALE = KiiClause.Equals("gender", "female");

    //public static KiiClause EQ_CLAUSE_PRICE1 = KiiClause.And(
    //    KiiClause.GreaterThanOrEqual("price", 1000),
    //    KiiClause.LessThanOrEqual("price", 1500));

    //public static KiiClause EQ_CLAUSE_PRICE2 = KiiClause.And(
    //    KiiClause.GreaterThanOrEqual("price", 150),
    //    KiiClause.LessThanOrEqual("price", 3000));

    //public static KiiClause EQ_CLAUSE_PRICE3 = KiiClause.And(
    //    KiiClause.GreaterThanOrEqual("price", 3000),
    //    KiiClause.LessThanOrEqual("price", 5000));

    //public static KiiClause EQ_CLAUSE_RECENTLY_JOIND = KiiClause.Equals("recentlyJoined", 1);
	

    //public static KiiClause[] CLAUSES_LIST = new KiiClause[] {
    //    EQ_CLAUSE_PRICE1,
    //    EQ_CLAUSE_PRICE2, 
    //    EQ_CLAUSE_PRICE3, 
    //    EQ_CLAUSE_MALE, 
    //    EQ_CLAUSE_FEMALE, 
    //    EQ_CLAUSE_ONLINE, 
    //    EQ_CLAUSE_OFFLINE,
    //    EQ_CLAUSE_RECENTLY_JOIND};





}
