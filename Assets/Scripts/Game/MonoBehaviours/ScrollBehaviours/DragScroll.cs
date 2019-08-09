using UnityEngine;
using SLua;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{ 

[CustomLuaClassAttribute]
public class DragScroll :MonoBehaviour,IBeginDragHandler, IEndDragHandler{

    private LuaFunction hDragStart;
    private LuaFunction hDrageEnd;
	public bool isDrag=false;

	
    public void registDragStart(LuaFunction func)
    {
        hDragStart = func;
    }

    public void registDragEnd(LuaFunction func)
    {
        hDrageEnd = func;
    }

    public void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData){
		isDrag=true;
        if(hDragStart != null)
        {
            hDragStart.call(eventData);
        }
	}


	public  void OnEndDrag (UnityEngine.EventSystems.PointerEventData eventData){
		isDrag=false;
        if (hDragStart != null)
        {
            hDrageEnd.call(eventData);
        }
    }

             




    }
}