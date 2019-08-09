using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UI3D : MonoBehaviour
{
    public static int gid = 0;

    [MenuItem("GameObject/UI/3DUI")]
    public static void Add3DUI()
    {
        GameObject goActive = Selection.activeGameObject;
        if (goActive == null)
            return;

        GameObject goRoot = new GameObject();
        Game.UI3D ui = goRoot.AddComponent<Game.UI3D>();
        goRoot.name = "3DUI_root_" + gid;
        gid += 1;

        ui.rawImg = goRoot.AddComponent<RawImage>();
        goRoot.transform.SetParent(goActive.transform);
        RectTransform rectTran = goRoot.GetComponent<RectTransform>();
        Rect rc = rectTran.rect;
        rectTran.rect.Set(rc.x, rc.y, 512, 512);

        GameObject goCamera = new GameObject();
        goCamera.transform.SetParent(goRoot.transform);
        goCamera.transform.position = new Vector3(0, 0, 0);


        Camera camera = goCamera.AddComponent<Camera>();
        ui.camera = camera;
        camera.name = "3DUI_Camera";
        camera.cullingMask = 1 << 17; //cull mask: 3DUI
        //camera.renderingPath = RenderingPath.VertexLit;
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color(0, 0, 0, 0);

        GameObject goScenery = new GameObject();
        goScenery.name = "3DUI_Scenery";
        goScenery.transform.SetParent(goRoot.transform);
        goScenery.transform.position = new Vector3(0, 0, 0);
        ui.goScenery = goScenery;
    }
}
