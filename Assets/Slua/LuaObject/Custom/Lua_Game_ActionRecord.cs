using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Game_ActionRecord : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			Game.ActionRecord o;
			System.String a1;
			checkType(l,2,out a1);
			o=new Game.ActionRecord(a1);
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteActions(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			var ret=self.WriteActions();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteProc(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			self.WriteProc();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int delete(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			var ret=self.delete();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int openWrite(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Boolean a1;
			var ret=self.openWrite(out a1);
			pushValue(l,ret);
			pushValue(l,a1);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int openAppend(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			var ret=self.openAppend();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int closeWrite(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			self.closeWrite();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int openRead(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			var ret=self.openRead();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int closeRead(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			self.closeRead();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int calcActionOffset(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			self.calcActionOffset();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int readHead(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.String a1;
			System.Int64 a2;
			System.String a3;
			System.Boolean a4;
			var ret=self.readHead(out a1,out a2,out a3,out a4);
			pushValue(l,ret);
			pushValue(l,a1);
			pushValue(l,a2);
			pushValue(l,a3);
			pushValue(l,a4);
			return 5;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int writeHead(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Int64 a2;
			checkType(l,3,out a2);
			System.String a3;
			checkType(l,4,out a3);
			var ret=self.writeHead(a1,a2,a3);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int writeFinishFlag(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			var ret=self.writeFinishFlag();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int readFinishFlag(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			var ret=self.readFinishFlag();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int readActionCount(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			var ret=self.readActionCount();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int readAction(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Byte[] a1;
			System.Int32 a2;
			checkType(l,3,out a2);
			System.Int32 a3;
			var ret=self.readAction(out a1,a2,out a3);
			pushValue(l,ret);
			pushValue(l,a1);
			pushValue(l,a3);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int writeAction(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Byte[] a1;
			checkType(l,2,out a1);
			var ret=self.writeAction(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int pushAction_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			Game.ActionRecord.pushAction(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int stopRecord_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			Game.ActionRecord.stopRecord(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int isCombatFinish_s(IntPtr l) {
		try {
			var ret=Game.ActionRecord.isCombatFinish();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setPid_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			Game.ActionRecord.setPid(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int startRecord_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.String a2;
			checkType(l,2,out a2);
			System.Int64 a3;
			checkType(l,3,out a3);
			System.String a4;
			checkType(l,4,out a4);
			Game.ActionRecord.startRecord(a1,a2,a3,a4);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int removeRecord_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			Game.ActionRecord.removeRecord(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int startRead_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=Game.ActionRecord.startRead(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int stopRead_s(IntPtr l) {
		try {
			Game.ActionRecord.stopRead();
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getHead_s(IntPtr l) {
		try {
			System.String a1;
			System.Int64 a2;
			System.String a3;
			System.Boolean a4;
			Game.ActionRecord.getHead(out a1,out a2,out a3,out a4);
			pushValue(l,a1);
			pushValue(l,a2);
			pushValue(l,a3);
			pushValue(l,a4);
			return 4;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getFrameCount_s(IntPtr l) {
		try {
			System.Int32 a1;
			Game.ActionRecord.getFrameCount(out a1);
			pushValue(l,a1);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int popAction_s(IntPtr l) {
		try {
			System.Byte[] a1;
			Game.ActionRecord.popAction(out a1);
			pushValue(l,a1);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int bytesToString_s(IntPtr l) {
		try {
			System.Byte[] a1;
			checkType(l,1,out a1);
			var ret=Game.ActionRecord.bytesToString(a1);
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int setKeepReplayCount_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			Game.ActionRecord.setKeepReplayCount(a1);
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int getAllReplays_s(IntPtr l) {
		try {
			var ret=Game.ActionRecord.getAllReplays();
			pushValue(l,ret);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_arWrite(IntPtr l) {
		try {
			pushValue(l,Game.ActionRecord.arWrite);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_arWrite(IntPtr l) {
		try {
			Game.ActionRecord v;
			checkType(l,2,out v);
			Game.ActionRecord.arWrite=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_arRead(IntPtr l) {
		try {
			pushValue(l,Game.ActionRecord.arRead);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_arRead(IntPtr l) {
		try {
			Game.ActionRecord v;
			checkType(l,2,out v);
			Game.ActionRecord.arRead=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_keepCount(IntPtr l) {
		try {
			pushValue(l,Game.ActionRecord.keepCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_keepCount(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			Game.ActionRecord.keepCount=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pid(IntPtr l) {
		try {
			pushValue(l,Game.ActionRecord.pid);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pid(IntPtr l) {
		try {
			System.String v;
			checkType(l,2,out v);
			Game.ActionRecord.pid=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_actionOffset(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.actionOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_actionOffset(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.actionOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_readOffset(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.readOffset);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_readOffset(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.readOffset=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_readCount(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.readCount);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_readCount(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.readCount=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_readIndex(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.readIndex);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_readIndex(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.readIndex=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_writeThread(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.writeThread);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_writeThread(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Threading.Thread v;
			checkType(l,2,out v);
			self.writeThread=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_exitEvent(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.exitEvent);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_exitEvent(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Threading.AutoResetEvent v;
			checkType(l,2,out v);
			self.exitEvent=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_waitTime(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.waitTime);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_waitTime(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.waitTime=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_locker(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.locker);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_locker(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Object v;
			checkType(l,2,out v);
			self.locker=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_actions(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.actions);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_actions(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Collections.Generic.List<System.Byte[]> v;
			checkType(l,2,out v);
			self.actions=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_combatFinish(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.combatFinish);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_combatFinish(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.combatFinish=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FileName(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.FileName);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FileName(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.FileName=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_UserDataPath(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			pushValue(l,self.UserDataPath);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_UserDataPath(IntPtr l) {
		try {
			Game.ActionRecord self=(Game.ActionRecord)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.UserDataPath=v;
			return 0;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Game.ActionRecord");
		addMember(l,WriteActions);
		addMember(l,WriteProc);
		addMember(l,delete);
		addMember(l,openWrite);
		addMember(l,openAppend);
		addMember(l,closeWrite);
		addMember(l,openRead);
		addMember(l,closeRead);
		addMember(l,calcActionOffset);
		addMember(l,readHead);
		addMember(l,writeHead);
		addMember(l,writeFinishFlag);
		addMember(l,readFinishFlag);
		addMember(l,readActionCount);
		addMember(l,readAction);
		addMember(l,writeAction);
		addMember(l,pushAction_s);
		addMember(l,stopRecord_s);
		addMember(l,isCombatFinish_s);
		addMember(l,setPid_s);
		addMember(l,startRecord_s);
		addMember(l,removeRecord_s);
		addMember(l,startRead_s);
		addMember(l,stopRead_s);
		addMember(l,getHead_s);
		addMember(l,getFrameCount_s);
		addMember(l,popAction_s);
		addMember(l,bytesToString_s);
		addMember(l,setKeepReplayCount_s);
		addMember(l,getAllReplays_s);
		addMember(l,"arWrite",get_arWrite,set_arWrite,false);
		addMember(l,"arRead",get_arRead,set_arRead,false);
		addMember(l,"keepCount",get_keepCount,set_keepCount,false);
		addMember(l,"pid",get_pid,set_pid,false);
		addMember(l,"actionOffset",get_actionOffset,set_actionOffset,true);
		addMember(l,"readOffset",get_readOffset,set_readOffset,true);
		addMember(l,"readCount",get_readCount,set_readCount,true);
		addMember(l,"readIndex",get_readIndex,set_readIndex,true);
		addMember(l,"writeThread",get_writeThread,set_writeThread,true);
		addMember(l,"exitEvent",get_exitEvent,set_exitEvent,true);
		addMember(l,"waitTime",get_waitTime,set_waitTime,true);
		addMember(l,"locker",get_locker,set_locker,true);
		addMember(l,"actions",get_actions,set_actions,true);
		addMember(l,"combatFinish",get_combatFinish,set_combatFinish,true);
		addMember(l,"FileName",get_FileName,set_FileName,true);
		addMember(l,"UserDataPath",get_UserDataPath,set_UserDataPath,true);
		createTypeMetatable(l,constructor, typeof(Game.ActionRecord));
	}
}
