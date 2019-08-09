using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using BTEditor.control;
using LitJson;
using System.Reflection;
using System.Diagnostics;
using LBoot;

namespace BTEditor.app
{

    public class BTEditorDialog : EditorWindow
    {
        public Dialog root = null;
        public static BTEditorDialog window = null;

        private Texture _appIcon = null;
        private Scrollview _scrollView = null;
        private Scrollview _controllList = null;

        private List<string> _lstProjects = new List<string>();
        private List<string> _lstAgents = new List<string>();
        private Textfield _tfFileName;
        public DropdownList<string> DDLAgent;

        public static Dictionary<string, string> MapNodeClass = null;

        [MenuItem("Tools/AI/Tree Editor")]
        static void Init()
        {
            window = EditorWindow.GetWindow<BTEditor.app.BTEditorDialog>("BTFEditor", true);
        }

        BTEditorDialog()
        {
           
        }

        void OnEnable()
        {
            // Initialization should be in constructor for the window to be persistent
            // across recompile and restart of unity
            if (BTEditorDialog.MapNodeClass == null)
            {
                BTEditorDialog.MapNodeClass = new Dictionary<string, string>();
                BTEditorDialog.MapNodeClass.Add("entry", "BTEntry");
                BTEditorDialog.MapNodeClass.Add("task", "TaskNode");
                BTEditorDialog.MapNodeClass.Add("priority", "PriorityNode");
                BTEditorDialog.MapNodeClass.Add("sequence", "SequenceNode");
                BTEditorDialog.MapNodeClass.Add("parallel", "ParallelNode");
                BTEditorDialog.MapNodeClass.Add("randomselector", "RandomSelectorNode");
                BTEditorDialog.MapNodeClass.Add("weightselector", "WeightSelectorNode");
                BTEditorDialog.MapNodeClass.Add("conditionselector", "ConditionSelectorNode");
                BTEditorDialog.MapNodeClass.Add("loop", "LoopNode");
                BTEditorDialog.MapNodeClass.Add("logic", "LogicNode");
                BTEditorDialog.MapNodeClass.Add("monitor", "MonitorNode");
                BTEditorDialog.MapNodeClass.Add("inverter", "InverterNode");
                BTEditorDialog.MapNodeClass.Add("retfail", "RetfailNode");
                BTEditorDialog.MapNodeClass.Add("retsuccess", "RetsuccessNode");
                BTEditorDialog.MapNodeClass.Add("utlfail", "UtlfailNode");
                BTEditorDialog.MapNodeClass.Add("utlsuccess", "UtlsuccessNode");
                BTEditorDialog.MapNodeClass.Add("subtree", "SubTreeNode");
                BTEditorDialog.MapNodeClass.Add("randomsequence", "RandomSequenceNode");
                BTEditorDialog.MapNodeClass.Add("loopuntil", "LoopUntilNode");
                BTEditorDialog.MapNodeClass.Add("persistwhile", "PersistWhileNode");
                BTEditorDialog.MapNodeClass.Add("countlimit", "CountLimitNode");
                BTEditorDialog.MapNodeClass.Add("retrunning", "RetrunningNode");
            }

            this._lstAgents.Add("Player");
            this._lstAgents.Add("Enemy");

            this.Initialize();
        }

        [MenuItem("Tools/AI/Edit/Modify Current Node")]
        static void ModifyCurrentNode()
        {
            BTNode n = window.root.currentControl as BTNode;
            if (n == null)
                return;

            n.BeginEditMode();
        }

        [MenuItem("Tools/AI/Edit/Remove Current Node")]
        static void RemoveCurrentNode()
        {
            BTNode n = window.root.currentControl as BTNode;
            if (n == null)
                return;

            n.parent.RemoveChild(n);
            window.root.currentControl = null;

            BTEntry en = n as BTEntry;
            if (en != null)
            {
                window.DDLAgent.enabled = true;
            }
        }

        /*[MenuItem("Tools/AI/Copy config")]
		static void CopyOutputs()
		{
			BTEditorDialog.processCommand ("open", "copy.sh",Application.dataPath+ "Assets/Editor/BTEditor/App/");
		}

		private static void processCommand(string command, string argument, string dir){
			ProcessStartInfo start = new ProcessStartInfo();
			start.FileName = command;
			start.Arguments = argument;
			start.WorkingDirectory = dir;
			start.CreateNoWindow = true;
			start.WindowStyle = ProcessWindowStyle.Minimized;

			if(start.UseShellExecute){
				start.RedirectStandardOutput = false;
				start.RedirectStandardError = false;
				start.RedirectStandardInput = false;
			} else{
				start.RedirectStandardOutput = true;
				start.RedirectStandardError = true;
				start.RedirectStandardInput = true;
				start.StandardOutputEncoding = System.Text.UTF8Encoding.UTF8;
				start.StandardErrorEncoding = System.Text.UTF8Encoding.UTF8;
			}

			Process p = Process.Start(start);

			if(!start.UseShellExecute){
				LogUtil.Debug(p.StandardOutput);
				LogUtil.Debug(p.StandardError);
			}

			p.WaitForExit();
			p.Close();
		}
		*/

        private void _initBase()
        {
            this.root = new Dialog(this, new Rect(0, 0, Screen.width, Screen.height));
            this.name = "BTEditor";
            this.wantsMouseMove = true;
            this._appIcon = AssetDatabase.LoadAssetAtPath("Assets/Editor/BTEditor/Assets/icon.png", typeof(Texture)) as Texture;
            this.titleContent = new GUIContent(this.name, _appIcon);
            this.maxSize = new Vector2(1500, 800);
            this.minSize = new Vector2(200, 400);
        }

        public bool OnSelProjChange(string dir)
        {
            this._scrollView.RemoveAllChildren();
            this._loadProject(dir);
            return true;
        }

        public void OnBtnSaveClick()
        {
            if (this._tfFileName.text != "")
            {
                this._saveProject();
                this._saveOutput();
            }
        }

        public void OnBtnCreateClick()
        {
            this._tfFileName.text = "";
            this._scrollView.RemoveAllChildren();
            this.DDLAgent.enabled = true;
        }

        public void OnBtnEntryClick()
        {
            BTNode node = this.FindEntry() as BTNode;
            if (node == null)
            {
                node = this._instantiate("entry");
                string strCategory = this.DDLAgent.selectItem;
                BTEntry en = node as BTEntry;
                en.SetAngentCategory(strCategory); 

                //initialize method define
                MethodDefine.AgentCategory = strCategory;
                MethodDefine.initMethodDefine();
                //initialize subtree define
                SubTreeDefine.AgentCategory = strCategory;
                SubTreeDefine.initSubTreeDefine();
                LogUtil.Debug(">>>>>Category:" + MethodDefine.AgentCategory);
                //disable category ddl
                this.DDLAgent.enabled = false;

                this._scrollView.AddChild(node);
            }
        }

        public void OnBtnSequenceClick()
        {
            BTNode node = this._instantiate("sequence");
            this._scrollView.AddChild(node);
        }

        public void OnBtnPriorityClick()
        {
            BTNode node = this._instantiate("priority");
            this._scrollView.AddChild(node);
        }

        public void OnBtnParallelClick()
        {
            BTNode node = this._instantiate("parallel");
            this._scrollView.AddChild(node);
        }

        public void OnBtnRandomClick()
        {
            BTNode node = this._instantiate("randomselector");
            this._scrollView.AddChild(node);
        }

        public void OnBtnWeightClick()
        {
            BTNode node = this._instantiate("weightselector");
            this._scrollView.AddChild(node);
        }

        public void OnBtnConditionClick()
        {
            BTNode node = this._instantiate("conditionselector");
            this._scrollView.AddChild(node);
        }

        public void OnBtnLoopClick()
        {
            BTNode node = this._instantiate("loop");
            this._scrollView.AddChild(node);
        }

        public void OnBtnLogicClick()
        {
            BTNode node = this._instantiate("logic");
            this._scrollView.AddChild(node);
        }

        public void OnBtnMonitorClick()
        {
            BTNode node = this._instantiate("monitor");
            this._scrollView.AddChild(node);
        }

        public void OnBtnInverterClick()
        {
            BTNode node = this._instantiate("inverter");
            this._scrollView.AddChild(node);
        }

        public void OnBtnFailClick()
        {
            BTNode node = this._instantiate("retfail");
            this._scrollView.AddChild(node);
        }

        public void OnBtnSuccessClick()
        {
            BTNode node = this._instantiate("retsuccess");
            this._scrollView.AddChild(node);
        }

        public void OnBtnUtilFailClick()
        {
            BTNode node = this._instantiate("utlfail");
            this._scrollView.AddChild(node);
        }

        public void OnBtnUtilSucClick()
        {
            BTNode node = this._instantiate("utlsuccess");
            this._scrollView.AddChild(node);
        }

        public void OnBtnTaskClick()
        {
            BTNode node = this._instantiate("task");
            this._scrollView.AddChild(node);
        }

        public void OnBtnSubTreeClick()
        {
            BTNode node = this._instantiate("subtree");
            this._scrollView.AddChild(node);
        }

        public void OnBtnRandomSequenceClick()
        {
            BTNode node = this._instantiate("randomsequence");
            this._scrollView.AddChild(node);
        }

        public void OnBtnLoopUntilClick()
        {
            BTNode node = this._instantiate("loopuntil");
            this._scrollView.AddChild(node);
        }

        public void OnBtnPersistWhileClick()
        {
            BTNode node = this._instantiate("persistwhile");
            this._scrollView.AddChild(node);
        }

        public void OnBtnCountLimitClick()
        {
            BTNode node = this._instantiate("countlimit");
            this._scrollView.AddChild(node);
        }

        public void OnBtnRetrunningClick()
        {
            BTNode node = this._instantiate("retrunning");
            this._scrollView.AddChild(node);
        }

        private void _loadProject(string projCfg)
        {
            StreamReader r = File.OpenText(projCfg);
            string strCfg = r.ReadToEnd();
            r.Close();
            JsonData d = JsonMapper.ToObject(strCfg);

            this._loadNode(d, null);

            string strFileName = Path.GetFileName(projCfg);
            this._tfFileName.text = strFileName;

            //agent category
            BTEntry en = this.FindEntry();
            int nIndex = this._lstAgents.FindIndex(x => x == en.AgentCategory);
            this.DDLAgent.popup = nIndex;
            this.DDLAgent.enabled = false;

            //initialize method define
            MethodDefine.AgentCategory = en.AgentCategory;
            MethodDefine.initMethodDefine();
            //initialize subtree define
            SubTreeDefine.AgentCategory = en.AgentCategory;
            SubTreeDefine.initSubTreeDefine();
        }

        private BTNode _instantiate(string strKind)
        {
            string clsname = "BTEditor.control." + BTEditorDialog.MapNodeClass[strKind];
            BTNode node = Assembly.GetExecutingAssembly().CreateInstance(clsname, false) as BTNode;
            node.Initialize(this, new Rect(150, 150, 100, 30), this._scrollView);
            return node;
        }

        private BTNode _loadNode(JsonData cfg, BTNode parent = null)
        {
            string strKind = (string)cfg["kind"];
            BTNode node = this._instantiate(strKind);
            node.LoadConfig(cfg, parent);

            if (node != null)
            {
                if (cfg.Keys.Contains("nodes"))
                {
                    JsonData d = cfg["nodes"];
                    for (int i = 0; i < d.Count; i++)
                    {
                        JsonData nd = d[i];
                        this._loadNode(nd, node);

                    }
                }

                if (cfg.Keys.Contains("node"))
                {
                    JsonData nd = cfg["node"];
                    this._loadNode(nd, node);
                }
            }

            if (node != null)
                this._scrollView.AddChild(node);

            return node;
        }

        private void _initGUI()
        {
            this._scrollView = new Scrollview(this, new Rect(10, 10, Screen.width - 20, Screen.height - 20), root, new Rect(0, 0, 4000, 4000));
            this._controllList = new Scrollview(this, new Rect(0, 0, 100, Screen.height - 20), root, new Rect(0, 100, 100, 800));
            this._controllList.textureBg = null;
            root.AddChild(this._controllList);
            root.AddChild(this._scrollView);

            //btn save
            Vector2 ptStart = new Vector2(10, 10);
            Button btnSave = new Button("保存", this, new Rect(ptStart.x, ptStart.y, 70, 32), this.root);
            btnSave.OnClick = new Button.ButtonDelegate(OnBtnSaveClick);
            root.AddChild(btnSave);

            //btn create
            Button btnCreate = new Button("新建", this, new Rect(ptStart.x + 100, ptStart.y, 70, 32), this.root);
            btnCreate.OnClick = new Button.ButtonDelegate(OnBtnCreateClick);
            root.AddChild(btnCreate);
            ptStart.y += 32 + 15;


            //ddl projects
            string[] directoryEntries = System.IO.Directory.GetFileSystemEntries("Assets/Editor/BTEditor/Projects");
            foreach (string str in directoryEntries)
            {
                if (str.EndsWith(".json"))
                    this._lstProjects.Add(str);
            }

            if (this._lstProjects.Count > 0)
            {
                Rect rcDDL = new Rect(ptStart.x, ptStart.y, 180, 20);
                DropdownList<string> ddlProj = new DropdownList<string>(this, rcDDL, root, this._lstProjects, 0);
                ddlProj.OnSelectChange = new DropdownList<string>.DropDownListDelegate(OnSelProjChange);
                root.AddChild(ddlProj);
                ptStart.y += 20 + 2;
            }


            //file name
            Rect rcLable = new Rect(ptStart.x, ptStart.y, 50, 20);
            root.AddChild(new Label("文件名:", this, rcLable, root));

            Rect rcFileName = new Rect(ptStart.x + 50, ptStart.y, 130, 20);
            this._tfFileName = new Textfield("", this, rcFileName, root);
            root.AddChild(this._tfFileName);
            ptStart.y += 20 + 5;

            //agent category
            Rect rcAgent = new Rect(ptStart.x, ptStart.y, 50, 20);
            root.AddChild(new Label("Agent:", this, rcAgent, root));

            Rect rcDDLAgent = new Rect(ptStart.x + 50, ptStart.y, 100, 20);
            this.DDLAgent = new DropdownList<string>(this, rcDDLAgent, root, this._lstAgents, 0);
            root.AddChild(this.DDLAgent);
            ptStart.y += 20 + 15;

            //load firest proj
            if (this._lstProjects.Count > 0)
            {
                string firstCfg = this._lstProjects[0];
                this._loadProject(firstCfg);
            }

            //entry
            Button btnEntry = new Button("入口节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnEntry.OnClick = new Button.ButtonDelegate(OnBtnEntryClick);
            _controllList.AddChild(btnEntry);
            ptStart.y += 22 + 5;


            _controllList.AddChild(new Label("动作节点:", this, new Rect(ptStart.x, ptStart.y, 150, 22), this.root));
            ptStart.y += 20;

            //task
            Button btnTask = new Button("任务节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnTask.OnClick = new Button.ButtonDelegate(OnBtnTaskClick);
            _controllList.AddChild(btnTask);
            ptStart.y += 22 + 5;
			

            _controllList.AddChild(new Label("组合节点:", this, new Rect(ptStart.x, ptStart.y, 150, 22), this.root));
            ptStart.y += 20;

            //sequenct
            Button btnSequence = new Button("顺序节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnSequence.OnClick = new Button.ButtonDelegate(OnBtnSequenceClick);
            _controllList.AddChild(btnSequence);
            ptStart.y += 22 + 5;

            //randomsequence
            Button btnRandonSequence = new Button("随机序列", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnRandonSequence.OnClick = new Button.ButtonDelegate(OnBtnRandomSequenceClick);
            _controllList.AddChild(btnRandonSequence);
            ptStart.y += 22 + 5;

            //priority
            Button btnPriority = new Button("优先节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnPriority.OnClick = new Button.ButtonDelegate(OnBtnPriorityClick);
            _controllList.AddChild(btnPriority);
            ptStart.y += 22 + 5;

            //parallel
            Button btnParallel = new Button("并行节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnParallel.OnClick = new Button.ButtonDelegate(OnBtnParallelClick);
            _controllList.AddChild(btnParallel);
            ptStart.y += 22 + 5;

            //randomselector
            Button btnRandom = new Button("随机节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnRandom.OnClick = new Button.ButtonDelegate(OnBtnRandomClick);
            _controllList.AddChild(btnRandom);
            ptStart.y += 22 + 5;

            //weightselector
            Button btnWeight = new Button("权重节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnWeight.OnClick = new Button.ButtonDelegate(OnBtnWeightClick);
            _controllList.AddChild(btnWeight);
            ptStart.y += 22 + 5;

            //conditionselector
            Button btnCondition = new Button("条件节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnCondition.OnClick = new Button.ButtonDelegate(OnBtnConditionClick);
            _controllList.AddChild(btnCondition);
            ptStart.y += 22 + 5;

            //logic
            Button btnLogic = new Button("逻辑节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnLogic.OnClick = new Button.ButtonDelegate(OnBtnLogicClick);
            _controllList.AddChild(btnLogic);
            ptStart.y += 22 + 5;

            //subtree
            Button btnTree = new Button("子树节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnTree.OnClick = new Button.ButtonDelegate(OnBtnSubTreeClick);
            _controllList.AddChild(btnTree);
            ptStart.y += 22 + 5;
			
            _controllList.AddChild(new Label("装饰:", this, new Rect(ptStart.x, ptStart.y, 150, 22), this.root));
            ptStart.y += 20;
	
            //loop
            Button btnLoop = new Button("循环节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnLoop.OnClick = new Button.ButtonDelegate(OnBtnLoopClick);
            _controllList.AddChild(btnLoop);
            ptStart.y += 22 + 5;

            //loopuntil
            Button btnLoopUtl = new Button("循环直到", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnLoopUtl.OnClick = new Button.ButtonDelegate(OnBtnLoopUntilClick);
            _controllList.AddChild(btnLoopUtl);
            ptStart.y += 22 + 5;

            //monitor
            Button btnMonitor = new Button("监控节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnMonitor.OnClick = new Button.ButtonDelegate(OnBtnMonitorClick);
            _controllList.AddChild(btnMonitor);
            ptStart.y += 22 + 5;

            //inverter
            Button btnInverter = new Button("取反节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnInverter.OnClick = new Button.ButtonDelegate(OnBtnInverterClick);
            _controllList.AddChild(btnInverter);
            ptStart.y += 22 + 5;

            //retfail
            Button btnFail = new Button("失败节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnFail.OnClick = new Button.ButtonDelegate(OnBtnFailClick);
            _controllList.AddChild(btnFail);
            ptStart.y += 22 + 5;

            //retsuccess
            Button btnSuccess = new Button("成功节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnSuccess.OnClick = new Button.ButtonDelegate(OnBtnSuccessClick);
            _controllList.AddChild(btnSuccess);
            ptStart.y += 22 + 5;

            //retrunning
            Button btnRetRunning = new Button("运行中节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnRetRunning.OnClick = new Button.ButtonDelegate(OnBtnRetrunningClick);
            _controllList.AddChild(btnRetRunning);
            ptStart.y += 22 + 5;

            //utlfail
            Button btnUtilFail = new Button("直到失败节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnUtilFail.OnClick = new Button.ButtonDelegate(OnBtnUtilFailClick);
            _controllList.AddChild(btnUtilFail);
            ptStart.y += 22 + 5;

            //utlsuccess
            Button btnUtilSuc = new Button("直到成功节点", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnUtilSuc.OnClick = new Button.ButtonDelegate(OnBtnUtilSucClick);
            _controllList.AddChild(btnUtilSuc);
            ptStart.y += 22 + 5;

            //persistwhile
            Button btnPersist = new Button("持续时间", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnPersist.OnClick = new Button.ButtonDelegate(OnBtnPersistWhileClick);
            _controllList.AddChild(btnPersist);
            ptStart.y += 22 + 5;

            //countlimit
            Button btnCountLimit = new Button("持续次数", this, new Rect(10, ptStart.y, 150, 22), this.root);
            btnCountLimit.OnClick = new Button.ButtonDelegate(OnBtnCountLimitClick);
            _controllList.AddChild(btnCountLimit);
            ptStart.y += 22 + 5;

        }

        public void Initialize()
        {
            this._initBase();
            this._initGUI();
        }


        public BTEntry FindEntry()
        {
            BTEntry entry = null;
            foreach (BaseControl ctrl in this._scrollView.children)
            {
                BTEntry n = ctrl as BTEntry;
                if (n != null)
                {
                    entry = n;
                    break;
                }
            }
            return entry;
        }

        private void _saveProject()
        {
            BTEntry entry = this.FindEntry();
            if (entry != null)
            {
                StringBuilder sb = new StringBuilder();
                JsonWriter w = new JsonWriter(sb);
                w.PrettyPrint = true;
                entry.SaveProject(w);

                string fileName = this._tfFileName.text;
                if (!this._tfFileName.text.EndsWith(".json"))
                {
                    fileName += ".json";
                }

                FileInfo t = new FileInfo("Assets/Editor/BTEditor/Projects/" + fileName);
                StreamWriter sw;
                sw = t.CreateText();
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
            }

        }

        private void _saveOutput()
        {
            BTEntry entry = this.FindEntry();
            if (entry != null)
            {
                StringBuilder sb = new StringBuilder();
                JsonWriter w = new JsonWriter(sb);
                w.PrettyPrint = true;
                entry.SaveOutput(w);

                string fileName = this._tfFileName.text;
                if (!this._tfFileName.text.EndsWith(".json"))
                {
                    fileName += ".json";
                }

                FileInfo t = new FileInfo("Assets/Editor/BTEditor/Outputs/" + fileName);
                StreamWriter sw;
                sw = t.CreateText();
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Dispose();
            }
        }

        public void OnGUI()
        {
            if (Event.current.type == EventType.MouseDrag)
            {
                this.OnMouseDrag(Event.current);
            }
            else if (Event.current.type == EventType.MouseDown)
            {
                this.OnMouseDown(Event.current);
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                this.OnMouseUp(Event.current);
            }
            if (root != null)
                root.OnRender();

            if (_scrollView != null)
                _scrollView.position = new Rect(200, 0, Screen.width - 200, Screen.height - 22);
            if (_controllList != null)
                _controllList.position = new Rect(10, 100, 180, Screen.height - 22);
			
        }

        public void OnMouseDrag(Event evt)
        {
            root.OnMouseDrag(evt);
        }

        public void OnMouseDown(Event evt)
        {
            root.OnMouseDown(evt);
        }

        public void OnMouseUp(Event evt)
        {
            root.OnMouseUp(evt);
        }

        public void OnProjectChange()
        {
        }

        public void OnHierarchyChange()
        {
        }

        public void OnInspectorUpdate()
        {
        }

        public void OnSelectionChange()
        {
        }

        //called per 0.1s
        public void Update()
        {
        }
    }
}
