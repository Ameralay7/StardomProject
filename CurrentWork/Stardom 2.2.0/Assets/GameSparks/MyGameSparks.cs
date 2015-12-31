using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
	public class LogEventRequest_BidOnUser : GSTypedRequest<LogEventRequest_BidOnUser, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_BidOnUser() : base("LogEventRequest"){
			request.AddString("eventKey", "BidOnUser");
		}
		
		public LogEventRequest_BidOnUser Set_id( string value )
		{
			request.AddString("id", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_BidOnUser : GSTypedRequest<LogChallengeEventRequest_BidOnUser, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_BidOnUser() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "BidOnUser");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_BidOnUser SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_BidOnUser Set_id( string value )
		{
			request.AddString("id", value);
			return this;
		}
	}
	
	public class LogEventRequest_GetMarketUsers : GSTypedRequest<LogEventRequest_GetMarketUsers, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_GetMarketUsers() : base("LogEventRequest"){
			request.AddString("eventKey", "GetMarketUsers");
		}
		public LogEventRequest_GetMarketUsers Set_pageSize( long value )
		{
			request.AddNumber("pageSize", value);
			return this;
		}			
		public LogEventRequest_GetMarketUsers Set_page( long value )
		{
			request.AddNumber("page", value);
			return this;
		}			
		public LogEventRequest_GetMarketUsers Set_online( long value )
		{
			request.AddNumber("online", value);
			return this;
		}			
		public LogEventRequest_GetMarketUsers Set_recentlyJoined( long value )
		{
			request.AddNumber("recentlyJoined", value);
			return this;
		}			
		
		public LogEventRequest_GetMarketUsers Set_gender( string value )
		{
			request.AddString("gender", value);
			return this;
		}
		public LogEventRequest_GetMarketUsers Set_minPrice( long value )
		{
			request.AddNumber("minPrice", value);
			return this;
		}			
		public LogEventRequest_GetMarketUsers Set_maxPrice( long value )
		{
			request.AddNumber("maxPrice", value);
			return this;
		}			
		public LogEventRequest_GetMarketUsers Set_minRemainingLockTime( long value )
		{
			request.AddNumber("minRemainingLockTime", value);
			return this;
		}			
		public LogEventRequest_GetMarketUsers Set_maxRemainingLockTime( long value )
		{
			request.AddNumber("maxRemainingLockTime", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_GetMarketUsers : GSTypedRequest<LogChallengeEventRequest_GetMarketUsers, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_GetMarketUsers() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "GetMarketUsers");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_GetMarketUsers SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_GetMarketUsers Set_pageSize( long value )
		{
			request.AddNumber("pageSize", value);
			return this;
		}			
		public LogChallengeEventRequest_GetMarketUsers Set_page( long value )
		{
			request.AddNumber("page", value);
			return this;
		}			
		public LogChallengeEventRequest_GetMarketUsers Set_online( long value )
		{
			request.AddNumber("online", value);
			return this;
		}			
		public LogChallengeEventRequest_GetMarketUsers Set_recentlyJoined( long value )
		{
			request.AddNumber("recentlyJoined", value);
			return this;
		}			
		public LogChallengeEventRequest_GetMarketUsers Set_gender( string value )
		{
			request.AddString("gender", value);
			return this;
		}
		public LogChallengeEventRequest_GetMarketUsers Set_minPrice( long value )
		{
			request.AddNumber("minPrice", value);
			return this;
		}			
		public LogChallengeEventRequest_GetMarketUsers Set_maxPrice( long value )
		{
			request.AddNumber("maxPrice", value);
			return this;
		}			
		public LogChallengeEventRequest_GetMarketUsers Set_minRemainingLockTime( long value )
		{
			request.AddNumber("minRemainingLockTime", value);
			return this;
		}			
		public LogChallengeEventRequest_GetMarketUsers Set_maxRemainingLockTime( long value )
		{
			request.AddNumber("maxRemainingLockTime", value);
			return this;
		}			
	}
	
	public class LogEventRequest_GetServerTime : GSTypedRequest<LogEventRequest_GetServerTime, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_GetServerTime() : base("LogEventRequest"){
			request.AddString("eventKey", "GetServerTime");
		}
	}
	
	public class LogChallengeEventRequest_GetServerTime : GSTypedRequest<LogChallengeEventRequest_GetServerTime, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_GetServerTime() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "GetServerTime");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_GetServerTime SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_GetUserProfile : GSTypedRequest<LogEventRequest_GetUserProfile, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_GetUserProfile() : base("LogEventRequest"){
			request.AddString("eventKey", "GetUserProfile");
		}
		
		public LogEventRequest_GetUserProfile Set_id( string value )
		{
			request.AddString("id", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_GetUserProfile : GSTypedRequest<LogChallengeEventRequest_GetUserProfile, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_GetUserProfile() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "GetUserProfile");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_GetUserProfile SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_GetUserProfile Set_id( string value )
		{
			request.AddString("id", value);
			return this;
		}
	}
	
	public class LogEventRequest_UpdateFacebookInfo : GSTypedRequest<LogEventRequest_UpdateFacebookInfo, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_UpdateFacebookInfo() : base("LogEventRequest"){
			request.AddString("eventKey", "UpdateFacebookInfo");
		}
		
		public LogEventRequest_UpdateFacebookInfo Set_gender( string value )
		{
			request.AddString("gender", value);
			return this;
		}
		public LogEventRequest_UpdateFacebookInfo Set_birthdate( long value )
		{
			request.AddNumber("birthdate", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_UpdateFacebookInfo : GSTypedRequest<LogChallengeEventRequest_UpdateFacebookInfo, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_UpdateFacebookInfo() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "UpdateFacebookInfo");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_UpdateFacebookInfo SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_UpdateFacebookInfo Set_gender( string value )
		{
			request.AddString("gender", value);
			return this;
		}
		public LogChallengeEventRequest_UpdateFacebookInfo Set_birthdate( long value )
		{
			request.AddNumber("birthdate", value);
			return this;
		}			
	}
	
}
	

namespace GameSparks.Api.Messages {


}
