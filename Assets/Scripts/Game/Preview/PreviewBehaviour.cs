using System;
using UnityEngine;
using LBoot;
using LBootEditor;
using System.Collections.Generic;

[AddComponentMenu("Preview/Preview Controller")]
public class PreviewBehaviour : MonoBehaviour
{
    public enum CameraMode
    {
        City = 0,
        Combat = 1,
    }

    public CameraMode cameraMode = CameraMode.Combat;

    public float PlayerInitPosx;
    public float PlayerInitPosy;
    public float PlayerInitPosz;


    public bool useConfig = true;

    public bool useHighVisual = false;

    public float CameraInitY;
    public float CameraInitZ;
    public float CameraMaxY;
    public float CameraMinY;
    public float sensitivity;
    public float rotHorizonMult = 0.2f;
    public float rotVerticalMult = 0.2f;
    public float minDist;
    public float runSpeed = 5;

    public bool showColliderBox = false;

    protected float CameraRotSpeed;
    protected GameConfig config;
    private Vector2 lastPoint;
    private bool isTracking;
    public float cameraObstacleDist = 300f;
    public float lodObstacleDist = 80f;
    public float lodObstacle120Dist = 120f;

    private static float crossHight = 0.3f;

    private bool isShowCollider = false;

    private CameraMode curCameraMode;

    public GameConfig Config
    {
        get { return config; }
        set { config = value; }
    }

#if UNITY_EDITOR
    GameObject go;
    GameObject root;
    Vector2 mDir;

    Camera mainCamera;

    float combatCameraZOffset;

    [NonSerialized]
    public GameObject previewGo;

    Vector3 originPos;
    bool running = true;
    bool oldUseConfig = false;

    bool oldUseHighVisual = true;

    private int layerPlayer = 13;
    private int layerGround = 10;
    private int layerCameraObstacle = 22;
    private int layerDefault = 0;

    private string[] maskLayer = { "Default", "Ground", "Barrel", "Obstacles", "CameraObstacle", "LodObstacle", "LodObstacle120" };

    private LayerMask playerMask;

    private Transform playerHead;

    private float playerHeadHeight = 1.6f;

    public CameraMode recommendCameraMode = CameraMode.City;



    //	private static Vector3 colliderBox = new Vector3 (0.5f, 1.8f, 0.5f) * 1.5f;

    void Start()
    {
        if (LBootApp.Running)
            return;

        playerMask = LayerMask.GetMask(maskLayer);

        Physics.IgnoreLayerCollision(layerPlayer, layerGround, false);
        Physics.IgnoreLayerCollision(layerPlayer, layerCameraObstacle, false);
        Physics.IgnoreLayerCollision(layerPlayer, layerDefault, false);
        if (previewGo)
            go = GameObject.Instantiate(previewGo);
        else
            go = BundleHelper.LoadAndCreate("prefab/characters/daoshi001_rda001", -1);

        var shadow = BundleHelper.LoadAndCreate("prefab/ui/fighter_shadow_ui", -1);
        go.AddComponent<Rigidbody>();

        go.transform.localScale = new Vector3(1, 1, 1);
        shadow.transform.SetParent(go.transform);

        shadow.transform.localPosition = new Vector3(0, 0.01f, 0);
        shadow.transform.localScale = new Vector3(0.035f, 0.035f, 0.035f);
        shadow.transform.eulerAngles = new Vector3(90, 0, 0);

//        go.transform.SetParent(GameObject.Find("/playerContenter").transform);
//        if (PlayerInitPosx == null)
//            PlayerInitPosx = 0;
//        if (PlayerInitPosy == null)
//            PlayerInitPosy = 0;
//        if (PlayerInitPosz == null)
//            PlayerInitPosz = -20;

        //this.config = GameConfig.Create();
        //if (CameraInitY == null)
        //  CameraInitY = Convert.ToSingle(this.config.common.main_camera_y);
        //if (CameraInitZ == -1000)
        //  CameraInitZ = Convert.ToSingle(this.config.common.main_camera_z);

        go.transform.position = new Vector3(PlayerInitPosx, PlayerInitPosy, PlayerInitPosz);
        var box = go.AddComponent<BoxCollider>();
        box.size = new Vector3(0.5f, 1.8f, 0.5f);
        box.center = new Vector3(0f, 0.9f, 0f);

        var rigidbody = go.GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
        rigidbody.isKinematic = true;

        curCameraMode = cameraMode = recommendCameraMode;

        InitCamera();

        PlayIdle();
    }



    void InitCamera()
    {
        this.root = GameObject.Find("/CameraRoot");
        if (this.root == null)
        {
            this.root = new GameObject("CameraRoot");
        }

        var camera = gameObject.GetComponent<Camera>();
        mainCamera = camera;

        if (cameraMode == CameraMode.City)
        {
            initCityCamera();
        }
        else
        {
            initCombatCamera();
        }
    }

    void initCityCamera()
    {
        var camera = gameObject.GetComponent<Camera>();

        var layerDistances = new float[32];
        layerDistances[LayerMask.NameToLayer("LodObstacle")] = lodObstacleDist;
        layerDistances[LayerMask.NameToLayer("CameraObstacle")] = cameraObstacleDist;
        layerDistances[LayerMask.NameToLayer("LodObstacle120")] = lodObstacle120Dist;
        camera.layerCullSpherical = true;
        camera.layerCullDistances = layerDistances;
        // var recvCamera = transform.Find("SceneReceiver");
        // var recvCam = recvCamera.GetComponent<Camera>();
        // recvCam.layerCullSpherical = true;
        // recvCam.layerCullDistances = layerDistances;
        this.config = GameConfig.Get();
        setCameraParam();

        this.transform.SetParent(this.root.transform);
        this.transform.parent.position = go.transform.position;
        this.transform.localPosition = new Vector3(0, CameraInitY, CameraInitZ);
        this.transform.LookAt(go.transform);
        this.originPos = this.transform.localPosition;

    }

    void initCombatCamera()
    {
        var camera = gameObject.GetComponent<Camera>();
        var cameraTransform = camera.transform;

        this.root.transform.rotation = Quaternion.Euler(0, 0, 0);


        Vector3 cameraPos = new Vector3(0, 2.67f, -13.32f);

        var rotation = Quaternion.Euler(5.14f, 0, 0);
        cameraTransform.localPosition = cameraPos;

        cameraTransform.rotation = rotation;
        combatCameraZOffset = cameraTransform.localPosition.z;

        camera.fieldOfView = 25.0f;

        var headt = go.transform.GetComponentsInChildren<Transform>();
        foreach (var t in headt)
        {
            if (t.name == "Head")
            {
                playerHead = t;
                Debug.Log("find head");
                break;
            }
        }
        if (playerHead)
        {
            playerHeadHeight = playerHead.position.y;

        }


//		Debug.LogFormat ("init combat camera pos  x = {0}  y={1}  z={2}", cameraPos.x, cameraPos.y, cameraPos.z);
    }

    private Vector3 LookAtPos
    {
        get
        {
            return go.transform.position + Vector3.up * 1.6f;
        }
    }

    void setCameraParam()
    {
        if (useConfig)
        {
            if (useHighVisual)
            {
                this.CameraInitY = Convert.ToSingle(this.config.common.main_camera_high_y);
                this.CameraInitZ = Convert.ToSingle(this.config.common.main_camera_high_z);
            }
            else
            {
                this.CameraInitY = Convert.ToSingle(this.config.common.main_camera_y);
                this.CameraInitZ = Convert.ToSingle(this.config.common.main_camera_z);
            }
            this.CameraRotSpeed = Convert.ToSingle(this.config.common.main_camera_rotate_speed);
            this.CameraMaxY = Convert.ToSingle(this.config.common.main_camera_max_y);
            this.CameraMinY = Convert.ToSingle(this.config.common.main_camera_min_y);
            this.sensitivity = Convert.ToSingle(this.config.common.main_camera_sensitivity);
            // this.sensitivity = 0;
            this.rotHorizonMult = Convert.ToSingle(this.config.common.main_camera_speed_horizon);
            this.rotVerticalMult = Convert.ToSingle(this.config.common.main_camera_speed_vertical);
            this.minDist = Convert.ToSingle(this.config.common.main_camera_min_dist);
        }
        else
        {
            this.CameraRotSpeed = Convert.ToSingle(this.config.common.main_camera_rotate_speed);
        }
    }

    void mayResetParams()
    {
        if (oldUseConfig != useConfig || oldUseHighVisual != useHighVisual)
        {
            go.transform.position = new Vector3(PlayerInitPosx, PlayerInitPosy, PlayerInitPosz);
            InitCamera();
            oldUseConfig = useConfig;
            oldUseHighVisual = useHighVisual;
        }
    }


    void Update()
    {
        if (LBootApp.Running || this.root == null)
            return;
        mayResetParams();


        if (isShowCollider != showColliderBox)
        {
            GameObject walls = GameObject.Find("/scenery/fightBoundary");
            BoxCollider[] renders = walls.GetComponentsInChildren <BoxCollider>(false);

            foreach (BoxCollider bc in renders)
            {
                MeshRenderer mr = bc.gameObject.GetComponent<MeshRenderer>();
                if (mr)
                    mr.enabled = showColliderBox;
            }

            isShowCollider = showColliderBox;
        }
        checkPlayerMove();

        if (curCameraMode != cameraMode)
        {
            InitCamera();
            go.transform.rotation = Quaternion.Euler(0, 90, 0);
            curCameraMode = cameraMode;
        }

        if (cameraMode == CameraMode.City)
        {
            checkCameraMove();
            checkCameraRayCastConflict();
            this.transform.LookAt(LookAtPos);
        }
        else
        {
            updateCombatCamera();
            if (playerHead)
            {
                var cameraLookAtPos = go.transform.position;
                cameraLookAtPos.y = cameraLookAtPos.y + playerHeadHeight;
                this.transform.LookAt(cameraLookAtPos);
            }
            else
            {
                this.transform.LookAt(LookAtPos);
            }

        }




//		Debug.Log(LayerMask.NameToLayer("Player"));
    }

    void updateCombatCamera()
    {
//		initCombatCamera ();
        var playerPos = go.transform.position;
        var cameraPos = mainCamera.transform.position;

        cameraPos.x = playerPos.x;

        cameraPos.z = playerPos.z + combatCameraZOffset;

        mainCamera.transform.position = cameraPos;

//		Debug.LogFormat ("new camera pos  x = {0}  y={1}  z={2}", mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);

    }



    private Vector3 rayHight = new Vector3(0, crossHight, 0);

    void checkPlayerMove()
    {
        Vector3 speed = new Vector3(0, 0, 0);
        var rotationY = this.root.transform.eulerAngles.y;
        bool run = false;
        Quaternion rotation = go.transform.rotation;
        bool resetRotation = false;
        if (Input.GetKey(KeyCode.W))
        {
            run = true;
            go.transform.rotation = Quaternion.Euler(0, rotationY, 0);
            if (cameraMode == CameraMode.Combat)
                resetRotation = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            run = true;
            go.transform.rotation = Quaternion.Euler(0, 180 + rotationY, 0);
            if (cameraMode == CameraMode.Combat)
                resetRotation = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            run = true;
            go.transform.rotation = Quaternion.Euler(0, 270 + rotationY, 0);
            resetRotation = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            run = true;
            go.transform.rotation = Quaternion.Euler(0, 90 + rotationY, 0);
            resetRotation = false;
        }

        if (run)
        {
			
            speed = go.transform.forward * runSpeed;

            Vector3 dis = speed * Time.deltaTime;


            Vector3 origin = go.transform.position + rayHight;

//			Vector3 pos = origin + dis;

//			Debug.DrawLine (origin, pos + dis * 10);

//			Vector3 boxDis = go.transform.forward * 0.5f;

//			Debug.LogFormat ("forward {0} pos1 {1} pos2 {2}", go.transform.forward, go.transform.position, boxDis);

//			boxTransform.Translate(boxTransform.forward,


            if (!Physics.Raycast(origin, go.transform.forward, dis.magnitude + 0.2f, playerMask.value))
            {
                go.transform.position += dis;

//				Debug.LogFormat ("forward {0}  dis {1}", go.transform.forward, go.transform.forward * colliderBox);

//				change y
                RaycastHit info;
                if (Physics.Raycast(origin, -go.transform.up, out info, Mathf.Infinity, playerMask.value))
                {
//					Debug.LogFormat ("Ground name {0}, dis {1} ", info.collider.name, info.distance - crossHight);

                    go.transform.position += new Vector3(0, (crossHight - info.distance), 0);
                }

                this.root.transform.position = go.transform.position;
            }

            if (resetRotation)
                go.transform.rotation = rotation;


            PlayRun();
        }
        else
        {
            PlayIdle();
        }
    }
    /*
  Vector3 fixSpeedAndRot(Vector3 origSpeed, Vector3 origRot)
  {
    //go.transform.rotation = self.parent.transform.rotation * origRot;
    Vector3 dir = new Vector3(origRot.x, 0, origRot.y);
    dir = self.parent.transform.rotation * dir;
    Vector2 dir2 = new Vector2(dir.x, dir.y);
    float magnitude = origSpeed.magnitude;
    float dirIndex = MathUtils.decideDirection(dir2);
  }
*/
    void checkCameraMove()
    {
//        bool rotting = false;
//        Vector3 rot = new Vector3(0, 0, 0);
        if (Input.GetButtonDown("Fire1"))
        {
            var mouse = Input.mousePosition;
            var screenPos = new Vector2(mouse.x, mouse.y);
            lastPoint = screenPos;
            isTracking = true;

        }

        if (Input.GetButton("Fire1") && isTracking)
        {
            var mouse = Input.mousePosition;
            var screenPos = new Vector2(mouse.x, mouse.y);
            var delta = screenPos - lastPoint;
            OnCameraMoved(delta);
            lastPoint = screenPos;
            isTracking = true;
        }

        if (Input.GetButtonUp("Fire1") && isTracking)
        {
            isTracking = false;
            lastPoint = Vector2.zero;
        }

    }

    void OnCameraMoved(Vector2 offset)
    {
        var resolution = Screen.currentResolution;
        var x = offset.x;
        var y = offset.y;
        var xp = x / resolution.width;
        var yp = y / resolution.height;

        var angle = root.transform.eulerAngles;
        var newAngle = angle + Vector3.up * (xp * 1200 * rotHorizonMult);
        root.transform.eulerAngles = newAngle;

        if (!useHighVisual)
        {
            this.originPos.y = Mathf.Clamp(originPos.y - yp * 60 * rotVerticalMult, CameraMinY, CameraMaxY);
        }
    }

    void checkCameraRayCastConflict()
    {
        int layer = LayerMask.NameToLayer("CameraObstacle");
        int mask = 1 << layer;
        Vector3 srcPos = LookAtPos;
        Vector3 dir = fixedWorldPos() - srcPos;
        Ray ray = new Ray(srcPos, dir);
        RaycastHit hit;
        float dist = dir.magnitude;
        bool ok = Physics.Raycast(ray, out hit, dist, mask);
        var pos = this.originPos;
        if (ok)
        {
            var p = hit.point;
            if (Vector3.Distance(p, srcPos) > minDist)
            {
                pos = this.root.transform.InverseTransformPoint(p);
            }
            else
            {
                var p2 = fixedWorldPos();
                p.y = p2.y;
                pos = this.root.transform.InverseTransformPoint(p);
                dir = p - srcPos;
                dist = dir.magnitude;
                ok = Physics.Raycast(srcPos, dir, out hit, dist, mask);
                if (ok)
                {
                    pos = this.root.transform.InverseTransformPoint(hit.point);
                }
            }
        }

        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, pos, Time.deltaTime * 10f);
    }

    Vector3 fixedWorldPos()
    {
        return this.root.transform.TransformPoint(this.originPos);
    }

    void PlayRun()
    {
        if (!running)
        {
            running = true;
            Animator animator = go.GetComponent(typeof(Animator)) as Animator;
            animator.Play("Base Layer.run", 0, 0);
        }
    }

    void PlayIdle()
    {
        if (running)
        {
            running = false;
            Animator animator = go.GetComponent(typeof(Animator)) as Animator;
            animator.Play("Base Layer.idle_idle", 0, 0);
        }
    }
#endif
}

