using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using LBoot;

namespace BTEditor.control{
	public class MethodDefine {
		public string strDisplayName;
		public string strName;
		public static string AgentCategory;
        public static string CurAgentCategory;
		public List<string> lstArgType = new List<string>();

		public MethodDefine(){
		}

		public static List<MethodDefine> LstMethods = null;

		public override string ToString ()
		{
			return this.strDisplayName;
		}

        public static void initMethodDefine()
        {
            MethodDefine.LstMethods = new List<MethodDefine>();

            string dirCfg  = "";
            LogUtil.Debug("xxxxxCategory:"+MethodDefine.AgentCategory);
            if( MethodDefine.AgentCategory == "Player")
                dirCfg = "Assets/Editor/BTEditor/Assets/methodcfg_player.json";
            else
                dirCfg = "Assets/Editor/BTEditor/Assets/methodcfg_enemy.json";

            FileInfo fi = new FileInfo(dirCfg);
            if(!fi.Exists) return;

            StreamReader r = File.OpenText(dirCfg);
            string strCfg = r.ReadToEnd();
            r.Close();

            JsonData d = JsonMapper.ToObject(strCfg);
            for(int i=0; i< d.Count; i++){
                JsonData m = d[i];

                MethodDefine md = new MethodDefine ();
                md.strName = (string)m["name"];
                md.strDisplayName = (string)m["displayname"];

                for(int j=1; j<10; j++){
                    string stra = "arg"+j.ToString();
                    string at = "";
                    if(m.Keys.Contains(stra)){
                        at = (string)m[stra];
                    }
                    if(at == "") break;

                    md.lstArgType.Add (at);
                }
                MethodDefine.LstMethods.Add(md);
            }

        }

		public static List<MethodDefine> getMethodDefine(){
			return MethodDefine.LstMethods;
		}

	}
}
