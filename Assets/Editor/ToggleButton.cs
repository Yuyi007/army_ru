using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Game;


public class ToggleButtonEditor : MonoBehaviour
{
	
    [MenuItem("GameObject/UI/ToggleButton")]
    public static void AddToggleButton()
    {
        GameObject goActive = Selection.activeGameObject;
        if (goActive == null)
            return;

        GameObject goContainer = new GameObject("container");
        goContainer.transform.SetParent(goActive.transform);
        goContainer.AddComponent<RectTransform>();

        //img
        GameObject goNromal = new GameObject("normal");
        goNromal.transform.SetParent(goContainer.transform);
        goNromal.AddComponent<CanvasRenderer>();
        goNromal.AddComponent<Image>();
        CanvasGroup cg = goNromal.AddComponent<CanvasGroup>();
        cg.blocksRaycasts = false;

        GameObject goCheck = new GameObject("check");
        goCheck.transform.SetParent(goContainer.transform);
        goCheck.AddComponent<CanvasRenderer>();
        goCheck.AddComponent<Image>();
        cg = goCheck.AddComponent<CanvasGroup>();
        cg.blocksRaycasts = false;

        //btn
        GameObject goBtn = new GameObject("b_btn");
        goBtn.transform.SetParent(goContainer.transform);
        goBtn.AddComponent<RectTransform>();
        Button btn = goBtn.AddComponent<Button>();
        btn.transition = Selectable.Transition.None;

        //text
        GameObject goText = new GameObject("Text");
        goText.transform.SetParent(goBtn.transform);
        goText.AddComponent<RectTransform>();
        goText.AddComponent<Text>();

        ToggleButton btnToggle = goBtn.AddComponent<ToggleButton>();
        btnToggle.normal = goNromal;
        btnToggle.check = goCheck;
    }
}
