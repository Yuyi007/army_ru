using cn.sharesdk.unity3d;
using SLua;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{	
	/// <summary>
	/// Authorize Login
	/// </summary>
	[CustomLuaClassAttribute]
	public class AuthLogin : MonoBehaviour {
		public ShareSDK ssdk;
		private LuaFunction hAuthResult;
		private LuaFunction hGetUserInfoResult;


		// Use this for initialization
		void Start () {
			ssdk = gameObject.GetComponent<ShareSDK>();
			ssdk.authHandler = OnAuthResultHandler;
			ssdk.showUserHandler = OnGetUserInfoResultHandler;
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void registAuthResult(LuaFunction func){
		 	hAuthResult = func;
		}

		public void registGetUserInfoResult(LuaFunction func){
		 	hGetUserInfoResult = func;
		}

		public void authorize(int platformType){
			switch(platformType){
				case 1:
					ssdk.Authorize(PlatformType.QQ);
				 	break;
				case 2:
					ssdk.Authorize(PlatformType.WeChat);
					break;
				default : 
				 	break; 	
			}
		}

		public void getUserInfo(int platformType){
			switch(platformType){
				case 1:
					ssdk.GetUserInfo(PlatformType.QQ);
				 	break;
				case 2:
					ssdk.GetUserInfo(PlatformType.WeChat);
					break;
				default : 
				 	break; 	
			}
		}

		void OnAuthResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result)
		{	
			if (hAuthResult!=null){
				hAuthResult.call(state,type,result);
			}

		}

		void OnGetUserInfoResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result)
		{	
			if (hGetUserInfoResult!=null)
			{
				if (state == ResponseState.Success)
				{
					hGetUserInfoResult.call(state,type,ssdk.GetAuthInfo(type));
				}else{
					hGetUserInfoResult.call(state,type,result);
				}
			}
		}
	}
}
