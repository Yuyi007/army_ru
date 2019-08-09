using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

using System.Linq;
using System.ComponentModel;
using Game;



#if UNITY_EDITOR
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using UnityEditor;

public class SkillTesterByConfig : MonoBehaviour
{
    public GameObject effect;
    //public Vector3 testVelocity = Vector3.zero;

    [HideInInspector]
    public GameObject effect_nf;
    [HideInInspector]
    public GameObject effect_f;
    [HideInInspector]
    public bool simulateHitPause = false;
    [HideInInspector]
	public ISheet skillSheet = null;
	[HideInInspector]
	public ISheet boxesSheet = null;
    [HideInInspector]
    public List<string> skillIds = null;
	[HideInInspector]
	public AnimatorStorable storable = null;
	[HideInInspector]
	public int maxChannels = 3;


    private Vector2 scrollPosition;
    private Animator animator;
    private UnityEditor.Animations.AnimatorController controller;
    private AnimationClip sampledClip;
    private AnimatorOverrideController overrideController;

    private string preState = "";
    private float animTimeVal = 0;
    private float preATV = 0;
    private float timer = 0;
	private float animLen = 0;
	private int _curClipIndex = 0;


	private GoTweenChain gtc = null;
	private GoTweenChain audioGtc = null;

    private List<bool> colliderEnableList = new List<bool>();
    private List<BoxCollider> colliderList = new List<BoxCollider>();
    private List<float> delayList = new List<float>();


	private Dictionary<string, string> _skillData = null;
	private List<Dictionary<string, string> > _boxDataDict = null;
	private List<KeyValuePair<string, int> > _sounds = null;

	private bool inited = false;

    void Start()
    {
        if (LBoot.LBootApp.Running)
        {
            this.enabled = false;
            return;
        }
        
		DoInit ();
    }

	public void DoInit()
	{
		if (inited)
			return;

		this.animator = GetComponent<Animator>();
		this.controller = this.animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;

		overrideController = new AnimatorOverrideController();
		overrideController.runtimeAnimatorController = this.animator.runtimeAnimatorController;

		if (effect != null)
		{
			effect.SetActive(false);
		}

		for (int i = 1; i <= 10; ++i)
		{
			var colGO = gameObject.transform.Find("AttackCollider_" + i.ToString());
			colliderEnableList.Add(false);
			colliderList.Add(colGO.GetComponent<BoxCollider>());
		}

		inited = true;
	}

    void clearColliders()
    {
        for (int i = 0; i < colliderEnableList.Count; ++i)
        {
            colliderEnableList[i] = false;
        }
        delayList.Clear();
    }

    void Update()
    {
        if (LBoot.LBootApp.Running)
            return;
        
        AnimatorClipInfo[] acis = this.animator.GetCurrentAnimatorClipInfo(0);
        float length = 0;
        if (acis.Length > 0)
        {
            length = acis[0].clip.length;
        }

        if (animTimeVal > 0 && !animTimeVal.Equals(preATV) && !preState.Equals(""))
        {
            this.animator.speed = 0.0f;
            this.animator.Play(preState, 0, animTimeVal);

            UpdateEfx(effect, length);
            UpdateEfx(effect_f, length);
            UpdateEfx(effect_nf, length);

            preATV = animTimeVal;
        }

        timer += Time.deltaTime;
        //AnimatorStateInfo asi = this.animator.GetCurrentAnimatorStateInfo (0);
        //timer = asi.normalizedTime * length;

        if (simulateHitPause)
            UpdateColliders();
    }

    void UpdateColliders()
    {
        var maxCnt = delayList.Count;
        for (int i = 0; i < maxCnt; ++i)
        {
            if (!colliderEnableList[i] && colliderList[i].enabled)
            {
                this.animator.speed = 0;
                colliderEnableList[i] = true;
                LBoot.GlobalScheduler.Schedule(delayList[i], 1, delegate(int obj)
                    {
                        this.animator.speed = 1;
                    });
            }
        }
    }

    void UpdateEfx(GameObject efx, float length)
    {
        if (efx != null)
        {
            ParticleSystem[] ps = efx.GetComponentsInChildren<ParticleSystem>(true);
            foreach (ParticleSystem p in ps)
            {
                p.Stop();
                p.Play();
                p.Pause();
                p.Simulate(animTimeVal * length, false, false);
            }
        }
    }

    void OnGUI()
    {
		if (LBoot.LBootApp.Running || skillSheet == null || boxesSheet == null || skillIds == null)
            return;
        
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        EditorGUILayout.BeginHorizontal();

		EditorGUILayout.BeginVertical(EditorStyles.boldLabel);

		Color orgColor = GUI.contentColor;

		GUI.contentColor = Color.black;

		GUILayout.Label("play time: " + timer.ToString());
		if (animTimeVal > 0) {
			GUILayout.Label ("frame time: " + ((int)(animLen * animTimeVal * 24.0f)).ToString ());
		} else {
			GUILayout.Label ("frame time: " + ((int)(timer * 24.0f)).ToString ());
		}

		GUI.contentColor = orgColor;

        animTimeVal = GUILayout.HorizontalSlider(animTimeVal, 0.0f, 1.0f, GUILayout.Width(300));
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
    }


	public void onBtnSkill(string skillId)
	{
		preATV = 0;
		timer = 0;
		TryShowSkill(skillId);
	}


	public Dictionary<string, string> GetSkillData(string skillId)
	{
		if (!(skillSheet != null && boxesSheet != null && skillId != null && skillId != ""))
		{
			return null;
		}

		string trimmedSid = skillId.Trim();
		IRow skillRow = XlsUtil.findRow(skillSheet, trimmedSid);
		if (skillRow == null)
		{
			return null;
		}

		IRow skillRefRow = skillSheet.GetRow(2);
		IRow boxesRefRow = boxesSheet.GetRow(2);

		Dictionary<string, string> skillData = XlsUtil.getValueDict(skillRow, skillRefRow);
		return skillData;
	}

    public void TryShowSkill(string skillId)
    {
        //var rigidBody = gameObject.GetComponent<Rigidbody> ();
        //rigidBody.velocity = testVelocity;

        if (!(skillSheet != null && boxesSheet != null && skillId != null && skillId != ""))
        {
            return;
        }

        string trimmedSid = skillId.Trim();
        IRow skillRow = XlsUtil.findRow(skillSheet, trimmedSid);
        if (skillRow == null)
        {
            return;
        }

        IRow skillRefRow = skillSheet.GetRow(2);
        IRow boxesRefRow = boxesSheet.GetRow(2);

		Dictionary<string, string> skillData = XlsUtil.getValueDict(skillRow, skillRefRow);

		List<string> boxIdList = new List<string> ();
        for (int i = 1; i <= 10; ++i)
        {
			string key = "box" + i.ToString ();
			if (skillData.ContainsKey (key)) {
				boxIdList.Add (skillData [key]);
			}
        }

        List<Dictionary<string, string> > boxDataDict = new List<Dictionary<string, string> >();
        foreach (string boxId in boxIdList)
        {
            IRow boxRow = XlsUtil.findRow(boxesSheet, boxId);
            if (boxRow != null)
            {
				Dictionary<string, string> boxData = XlsUtil.getValueDict(boxRow, boxesRefRow);
                boxDataDict.Add(boxData);
            }
        }

        // clear colliders for simulate hit pause
        clearColliders();
        foreach (var boxData in boxDataDict)
        {
            if (boxData.ContainsKey("shake_tm"))
            {
                delayList.Add(Single.Parse(boxData["shake_tm"]) / 24);
            }
            else
            {
                delayList.Add(0.0f);
            }
        }

		// play sounds
		List<KeyValuePair<string, int> > sounds = new List<KeyValuePair<string, int>>();
		if (skillData.ContainsKey ("sound1")) {
			string sounds_str = skillData ["sound1"];
			string frames_str = "";
			if (skillData.ContainsKey ("sound_frame1")) {
				frames_str = skillData ["sound_frame1"];
			}
			string[] all_sounds = sounds_str.Split (',');
			string[] all_frames = frames_str.Split (',');

			for (int i = 0; i < all_sounds.Length; ++i) {
				string sound = all_sounds[i].Trim();
				int frame = 0;
				if (all_frames.Length > i) {
					frame = Convert.ToInt32 (all_frames [i]);
				}
				sounds.Add (new KeyValuePair<string, int>(sound, frame));
			}
		}

        if (gtc != null)
        {
            gtc.destroy();
            gtc = null;
        }

		if (audioGtc != null)
		{
			audioGtc.destroy();
			audioGtc = null;
		}
		_sounds = sounds;
		_skillData = skillData;
		_boxDataDict = boxDataDict;
	
        var config = LBootEditor.GameConfig.Get();

        animLen = config.getClipLength(this.animator.runtimeAnimatorController.name, skillData["anim_type"]);

//		StartCoroutine ("loadSounds");
		loadSounds();
    }

	void loadSounds()
	{
		List<KeyValuePair<string, int> > sounds = _sounds;

		List<KeyValuePair<string, int> > sortedSounds = sounds.OrderBy (o => o.Value).ToList ();
		List<AudioClip> clips = new List<AudioClip> ();
		foreach (var sd in sortedSounds) {
//			string path = Application.dataPath + "/sounds/efx/" + sd.Key + ".mp3";
//			WWW www = new WWW ("file://" + path);
//			yield return www;
//			var ac = www.GetAudioClip (false, false);

			string path = "Assets/sounds/efx/" + sd.Key + ".mp3";
			var ac = AssetDatabase.LoadAssetAtPath<AudioClip> (path);
			clips.Add (ac);
		}
		playSounds (sortedSounds, clips);
		playAnimation (_skillData, _boxDataDict);
	}

	void playSounds(List<KeyValuePair<string, int> > sortedSounds, List<AudioClip> clips)
	{	
		AudioSource[] src = this.gameObject.GetComponents<AudioSource> ();

		audioGtc = new GoTweenChain ();
		audioGtc.autoRemoveOnComplete = true;
		float accTime = 0;
		_curClipIndex = 0;
		for (int i = 0; i < sortedSounds.Count; ++i ) {
			var sd = sortedSounds [i];
			float delay = sd.Value / 24.0f - accTime;
			if (delay > 0) {
				audioGtc.appendDelay(delay);
			}
			var cbcon = new GoTweenConfig ();
			audioGtc.append (new GoTween (
				gameObject.transform,
				0.01f,
				cbcon.onComplete (delegate(AbstractGoTween obj) {
					int ri = _curClipIndex % maxChannels;
					src [ri].clip = clips [_curClipIndex];
					src [ri].loop = false;
					src [ri].spatialBlend = 0;
					src [ri].Play ();
					++_curClipIndex;
				})
			));
			accTime += delay;
		}

		// for some reason the last play callback 
		// is not invoked, so I add one more tween
		// to ensure the last sound is played.
		audioGtc.appendDelay(0.5f);
		GoTweenConfig gtcfg = new GoTweenConfig ();
		audioGtc.append (new GoTween (
			gameObject.transform,
			0.01f,
			gtcfg.onComplete (delegate(AbstractGoTween obj) {
			})
		));

		audioGtc.play ();
	}

	void playAnimation(Dictionary<string, string> skillData, List<Dictionary<string, string> > boxDataDict)
	{
		animTimeVal = 0;
		preATV = 0;
		preState = skillData["anim_type"];
		gameObject.transform.position = Vector3.zero;
		this.animator.Play(preState, 0, 0);
		this.animator.enabled = true;
		this.animator.speed = 1.0f;

		DestroyEfx();
		if (skillData.ContainsKey("self_eff"))
		{
			effect_nf = MakeEfx(skillData["self_eff"]);
		}
		if (skillData.ContainsKey("self_eff_follow"))
		{
			effect_f = MakeEfx(skillData["self_eff_follow"]);
		}

		if (effect_f != null)
		{
			effect_f.transform.SetParent(gameObject.transform, true);
			effect_f.name = skillData["self_eff_follow"] + "efx";
		}
		if (effect_nf != null)
		{
			effect_nf.transform.position = gameObject.transform.position;
			effect_nf.name = skillData["self_eff"] + "efx";
		}

		if (skillData["is_jump_skill"] == "是")
		{
			applyJumpSkillMove(boxDataDict);
		}
		else
		{
			applyNonJumpSkillMove(boxDataDict);
		}
	}

    void applyNonJumpSkillMove(List<Dictionary<string, string> > boxDataDict)
    {
        gtc = new GoTweenChain();
        gtc.autoRemoveOnComplete = true;

        List<Dictionary<string, float> > atkOffsets = new List<Dictionary<string, float> >();

        int bi = 0;
        foreach (var boxData in boxDataDict)
        {
            if (boxData["self_aff"] != "位移")
            {
                break;
            }

            char[] delimiterChars = { ',' };
            string[] sdata = boxData["self_param"].Split(delimiterChars);

            if (sdata.Length < 3)
            {
                break;
            }

            List<float> fdata = new List<float>();
            foreach (string s in sdata)
            {
                fdata.Add(Convert.ToSingle(s));
            }
            float startTime = fdata[0] / 24;
            float speed = fdata[1];
            float dist = fdata[2];
            float duration = Mathf.Abs(dist / speed);

            speed = dist / duration;

            Dictionary<string, float> offsetData = new Dictionary<string, float>();
            offsetData["startTime"] = startTime;
            offsetData["endTime"] = startTime + duration;
            offsetData["curTime"] = 0;
            offsetData["totalTime"] = duration;
            offsetData["speed"] = speed;
            atkOffsets.Add(offsetData);

            if (bi >= 1)
            {
                var preData = atkOffsets[bi - 1];
                if (preData["endTime"] > startTime)
                {
                    preData["endTime"] = startTime;
                    preData["totalTime"] = startTime - preData["startTime"];
                }
                else
                {
                    preData["delay"] = startTime - preData["endTime"];
                }
            }
            else
            {
                var curData = atkOffsets[bi];
                if (startTime > 0)
                {
                    curData["delay"] = startTime;
                }
            }

            ++bi;
        }

        foreach (var v in atkOffsets)
        {
            if (v.ContainsKey("delay"))
            {
                gtc.appendDelay(v["delay"]);
            }

            var gtconfig = new GoTweenConfig();
            if (v["totalTime"] > 0)
            {
                var dirInc = new Vector3(v["speed"] * v["totalTime"], 0, 0);
                gtc.append(new GoTween(
                        gameObject.transform,
                        v["totalTime"],
                        gtconfig.position(dirInc, true).setEaseType(GoEaseType.Linear).setUpdateType(GoUpdateType.FixedUpdate)
                    ));
            }
        }



        var cbcon = new GoTweenConfig();
        gtc.append(new GoTween(
                gameObject.transform,
                0.01f,
                cbcon.onComplete(delegate(AbstractGoTween obj)
                    {
                        //DestroyEfx ();
                    })
            ));

        gtc.appendDelay(2.0f);
        var con = new GoTweenConfig();
        gtc.append(new GoTween(
                gameObject.transform,
                0.01f,
                con.position(Vector3.zero, false).setEaseType(GoEaseType.Linear).setUpdateType(GoUpdateType.FixedUpdate)
            ));
        gtc.play();
    }

    void applyJumpSkillMove(List<Dictionary<string, string> > boxDataDict)
    {
        var rigidBody = gameObject.GetComponent<Rigidbody>();
        //rigidBody.velocity = testVelocity;

        gtc = new GoTweenChain();
        gtc.autoRemoveOnComplete = true;

        List<Dictionary<string, float> > atkOffsets = new List<Dictionary<string, float> >();

        int bi = 0;
        foreach (var boxData in boxDataDict)
        {
            if (boxData["self_aff"] != "跳跃")
            {
                break;
            }

            char[] delimiterChars = { ',' };
            string[] sdata = boxData["self_param"].Split(delimiterChars);

            if (sdata.Length < 3)
            {
                break;
            }

            List<float> fdata = new List<float>();
            foreach (string s in sdata)
            {
                fdata.Add(Convert.ToSingle(s));
            }
            float startTime = fdata[0];
            float angle = fdata[1];
            float speed = fdata[2];

            float vx = speed * Mathf.Cos(Mathf.Deg2Rad * angle);
            float vy = speed * Mathf.Sin(Mathf.Deg2Rad * angle);

            Dictionary<string, float> offsetData = new Dictionary<string, float>();
            offsetData["startTime"] = startTime;
            offsetData["velocityX"] = vx;
            offsetData["velocityY"] = vy;
            atkOffsets.Add(offsetData);

            var curData = atkOffsets[bi];
            if (bi >= 1)
            {
                var preData = atkOffsets[bi - 1];
                curData["delay"] = startTime - preData["startTime"];
            }
            else
            {
                if (startTime > 0)
                {
                    curData["delay"] = startTime;
                }
            }
            ++bi;
        }

        foreach (var v in atkOffsets)
        {
            if (v.ContainsKey("delay"))
            {
                var gtconfig = new GoTweenConfig();
                gtc.append(new GoTween(
                        gameObject.transform,
                        v["delay"],
                        gtconfig.onComplete(delegate(AbstractGoTween obj)
                            {
                                rigidBody.velocity = new Vector3(v["velocityX"], v["velocityY"], 0.0f);
                            })
                    ));
            }
        }

        var cbcon = new GoTweenConfig();
        gtc.append(new GoTween(
                gameObject.transform,
                0.01f,
                cbcon.onComplete(delegate(AbstractGoTween obj)
                    {
                        //DestroyEfx ();
                    })
            ));

        gtc.appendDelay(2.0f);
        var con = new GoTweenConfig();
        gtc.append(new GoTween(
                gameObject.transform,
                0.01f,
                con.position(Vector3.zero, false).setEaseType(GoEaseType.Linear).setUpdateType(GoUpdateType.FixedUpdate)
            ));
        gtc.play();
    }

    void DestroyEfx()
    {
        if (effect_f != null)
        {
            GameObject.Destroy(effect_f);
            effect_f = null;
        }
        if (effect_nf != null)
        {
            GameObject.Destroy(effect_nf);
            effect_nf = null;
        }
    }

    GameObject MakeEfx(string name)
    {
        GameObject go = LBoot.BundleHelper.LoadAndCreate("prefab/misc/" + name, -1);
        return go;
    }
}
#endif
