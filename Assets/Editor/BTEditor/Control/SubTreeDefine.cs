using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using LBoot;

namespace BTEditor.control{

	public class SubTreeDefine {
		public string strName;
		public static string AgentCategory;

		public static List<SubTreeDefine> LstSubTrees = null;

		public override string ToString ()
		{
			return this.strName;
		}

		public static string[] SplitWithString(string sourceString, string splitString){  
			List<string> arrayList = new List<string>();    
			string s = string.Empty;    
			while (sourceString.IndexOf(splitString) > -1)  //分割  
			{    
				s = sourceString.Substring(0, sourceString.IndexOf(splitString));    
				sourceString = sourceString.Substring(sourceString.IndexOf(splitString) + splitString.Length);    
				arrayList.Add(s);    
			}   
			arrayList.Add(sourceString);   
			return arrayList.ToArray();    
		}

		public static bool FitCategory(string strFile){
      LogUtil.Debug(strFile);
			string strPath = "Assets/Editor/BTEditor/Projects/"+strFile+".json";
			StreamReader r = File.OpenText(strPath);
			string strCfg = r.ReadToEnd();
      r.Close();
			JsonData d = JsonMapper.ToObject(strCfg);
			string strCat = (string)(d["agentcategory"]);

			return strCat == SubTreeDefine.AgentCategory;
		}

        public static void initSubTreeDefine()
        {
            SubTreeDefine.LstSubTrees = new List<SubTreeDefine> ();
            string[] directoryEntries = System.IO.Directory.GetFileSystemEntries("Assets/Editor/BTEditor/Outputs/"); 
            for(int i = 0; i < directoryEntries.Length ; i ++){    
                string p = directoryEntries[i];  

                string[] tempPaths = SubTreeDefine.SplitWithString(p,"Assets/Editor/BTEditor/Outputs/");  
                if(!tempPaths[1].EndsWith(".json"))  
                    continue;  

                string[] pathSplit = SubTreeDefine.SplitWithString(tempPaths[1],".");
                if(pathSplit.Length <= 1) 
                    continue;

                if(!FitCategory(pathSplit[0]))
                    continue;

                SubTreeDefine sd = new SubTreeDefine();
                sd.strName = pathSplit[0];
                LogUtil.Debug(pathSplit[0]);
                SubTreeDefine.LstSubTrees.Add(sd);
            }

        }

		public static List<SubTreeDefine> getSubTreeDefine(){
            return SubTreeDefine.LstSubTrees;
		}
	}
}