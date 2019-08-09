using UnityEngine;
using System.Collections;
using UnityEditor;

public class CPPreviewer : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float animNormal = 0f;

    float prevLength=1f;
    float slider2 = 1f;

    float prevSpeed = 0.001f;

    Vector2 scr1;


    public Object character;
    public Object particleParent;

    GameObject charG;
    GameObject parG;

    bool showProgress = true;
    bool showSpec = false;

    bool playing = false;

    int currentID = 0;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Tools/AnimationPreviwer")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        CPPreviewer window = (CPPreviewer)EditorWindow.GetWindow(typeof(CPPreviewer));
    }


    void Update()
    {
        Repaint();
    }

    void OnGUI()
    {
        GUILayout.Label("角色-特效同步预览工具", EditorStyles.boldLabel);

        GUILayout.Space(20);

        GUILayout.Label("拖放Hierarchy中角色物件(animation组件所在物体)到下栏");

        //EditorGUILayout.ObjectField(
        //myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);

        character = EditorGUILayout.ObjectField("角色:", character,typeof(GameObject));

        GUILayout.BeginHorizontal();
        particleParent = EditorGUILayout.ObjectField("粒子(父)物体:", particleParent, typeof(GameObject));

        GUILayout.EndHorizontal();
        
        if (character != null)
        {
            charG = character as GameObject;

            if (charG.GetComponent<Animation>() == null)
            {
                GUI.color = Color.yellow;
                GUILayout.Label("[错误:角色动画组件不在此物体上!]");
                GUI.color = Color.white;
            }
            else
            {
                GUILayout.Space(10);


                scr1 = GUILayout.BeginScrollView(scr1,GUILayout.Height(200));

                int i = 0;
                foreach (AnimationClip ani in AnimationUtility.GetAnimationClips(charG.GetComponent<Animation>()))
                {
                    if (currentID == i)
                    { GUI.color = Color.yellow; }
                    
                    if (GUILayout.Button(ani.name,GUILayout.Height(25)))
                    {

                        charG.GetComponent<Animation>().clip = ani;

                        currentID = i;
                    }

                    GUI.color = Color.white;

                    i++;
                }

                GUILayout.EndScrollView();

                GUILayout.Space(15);

                showProgress = !showSpec;

                showProgress = EditorGUILayout.BeginToggleGroup("按动画长度预览", showProgress);
                
                //GUILayout.BeginHorizontal();
                animNormal = EditorGUILayout.Slider("动画进度:("+(animNormal*100).ToString("0")+"%)", animNormal, 0, 1f);
                GUILayout.Label("动画时间:" + (charG.GetComponent<Animation>()[charG.GetComponent<Animation>().clip.name].length * animNormal).ToString("0.000") + "秒");


                EditorGUILayout.EndToggleGroup();

                EditorGUILayout.Separator();

                showSpec = !showProgress;

                showSpec = EditorGUILayout.BeginToggleGroup("设定时长预览", showSpec);


                prevLength = EditorGUILayout.FloatField("指定时长预览(秒)", prevLength);
                slider2 = EditorGUILayout.Slider("当前时间(秒):", slider2, 0, prevLength);

                EditorGUILayout.EndToggleGroup();


                EditorGUILayout.Separator();

                if (!playing)
                {
                    if (GUILayout.Button("循环播放",GUILayout.Height(25)))
                    {
                        playing = true;
                    }


                    
                }
                else
                {
					GUI.color=Color.yellow;
                    if (GUILayout.Button("停止播放", GUILayout.Height(25)))
                    {
                        playing = false;
                    }

                    animNormal += prevSpeed;
                    if (animNormal >= 1) { animNormal = 0; }

                    slider2 += prevSpeed;
                    if (slider2 >= prevLength) { slider2 = 0; }

                }
				
				GUI.color=Color.white;

                prevSpeed = EditorGUILayout.Slider("播放速度:", prevSpeed, 0, 0.016f);


                AnimationState state = charG.GetComponent<Animation>()[charG.GetComponent<Animation>().clip.name];

                if (!charG.GetComponent<Animation>().IsPlaying(charG.GetComponent<Animation>().clip.name))
                {
                    charG.GetComponent<Animation>().wrapMode = WrapMode.Loop;
                    charG.GetComponent<Animation>().Play(charG.GetComponent<Animation>().clip.name);
                }

                if (showProgress)
                {
                    state.normalizedTime = animNormal;
                }
                else
                {
                    state.time = slider2;
                }

                state.enabled = true;
                charG.GetComponent<Animation>().Sample();
                state.enabled = false;

               
            }
        }


        if (particleParent != null)
        {
            parG = particleParent as GameObject;

            if (parG != null)
            {
                ParticleSystem[] ps = parG.GetComponentsInChildren<ParticleSystem>();

                foreach (ParticleSystem p in ps)
                {
                    if (showProgress)
                    {
                        p.Simulate(animNormal);
                    }
                    else
                    {
                        p.Simulate(slider2);
                    }
                }
            }
        }
        
    }

    void OnDisable()
    {
		if(charG!=null&&charG.GetComponent<Animation>()!=null)
		{
         AnimationState state = charG.GetComponent<Animation>()[charG.GetComponent<Animation>().clip.name];

         state.normalizedTime = 0;
         state.enabled = true;
         charG.GetComponent<Animation>().Sample();
         state.enabled = false;
		}
    }
}