using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawGizmosTest : MonoBehaviour {

    Vector2Int size;
    Vector3 v;
    private Vector3Int gridSize;
    private Vector2Int toolSize;

    public int[,] a;
    public Color color = Color.red;

    public bool getBrush;
    public bool getEraser;
    public bool none;
    public bool beginOperate;
    public string gridDataName;

    [Delayed]
    public Vector2Int mSize = new Vector2Int(800, 300);
    [Delayed]
    public Vector3Int mGridSize = new Vector3Int(2, 1, 2);
    //计算显示范围
    Vector3 leftUp;
    Vector3 rightDown;

    public Vector2Int Size
    {
        get
        {
            return size;
        }

        set
        {
            if (size != value)
            {
                size = value;

                if (Size.x <= 0 || Size.y <= 0)
                {
                    size.x = 800;
                    size.y = 300;
                }

                ResetArray();
            }
        }
    }

    public Vector3Int GridSize
    {
        get
        {
            return gridSize;
        }

        set
        {
            if (gridSize != value)
            {
                gridSize = value;

                if (GridSize.x <= 0 || GridSize.z <= 0)
                {
                    gridSize = new Vector3Int(2, 1, 2);
                    //gridSize = Vector3Int.one;
                }

                ResetArray();
            }
        }
    }

    public Vector2Int ToolSize
    {
        get
        {
            return toolSize;
        }

        set
        {
            if (value.x >= 0 && value.y >= 0)
            {
                toolSize = value;
            }
        }
    }

    // Use this for initialization
    void Awake () {
        //v = new Vector3(-(width / 2f), 0, -(heigth / 2f));
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnDrawGizmos()
    {
        Size = mSize;
        GridSize = mGridSize;
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        if (mr != null)
        {
            mr.enabled = true;
        }

        if ((Size.x <= GridSize.x && Size.y <= GridSize.z) || (Size.x % 2) != 0 || (Size.y % 2) != 0)
        {
            size.x = 800;
            size.y = 300;
            //gridSize = Vector3Int.one;
            gridSize = new Vector3Int(2, 1, 2);
        }

        if (a == null)
        {
            ResetArray();
        }

        //相机显示边界
        leftUp = Camera.current.ScreenToWorldPoint(new Vector3(0,
            Camera.current.pixelHeight, Camera.current.transform.position.y));

        rightDown = Camera.current.ScreenToWorldPoint(new Vector3(Camera.current.pixelWidth,
            0, Camera.current.transform.position.y));

        DrawGizmosMethod();
    }

    public void ResetArray()
    {
        if (Size.x % GridSize.x != 0 || Size.y % GridSize.z != 0)
        {
            size.x = 800;
            size.y = 300;
            gridSize = new Vector3Int(2, 1, 2);
        }
        a = new int[Size.x / GridSize.x, Size.y / GridSize.z];
    }

    public void SetArray(int num_1, int num_2)
    {
        a = new int[num_1, num_2];
    }

    public void SetMapSize(int num_1, int num_2)
    {
        size = new Vector2Int(num_1, num_2);
    }

    public void SetGridSize(int num_1, int num_2, int num_3)
    {
        gridSize = new Vector3Int(num_1, num_2, num_3);
    }

    public string SetName()
    {
        if (gridDataName != gameObject.name)
        {
            gridDataName = gameObject.name;
        }
        return gridDataName;
    }

    public void DrawGizmosMethod()
    {
        for (int i = 0; i < (Size.y / GridSize.z); i++)
        {
            for (int j = 0; j < (Size.x / GridSize.x); j++)
            {
                v = new Vector3(j * GridSize.x + GridSize.x / 2f - Size.x / 2f, 0, i * GridSize.z + GridSize.z / 2f - Size.y / 2f);

                if (v.x < rightDown.x && v.x > leftUp.x && v.z < leftUp.z && v.z > rightDown.z)
                {
                    if (a[j, i] == 1)
                    {
                        Gizmos.color = color;
                        Gizmos.DrawCube(v, GridSize);
                    }
                    else
                    {
                        if (beginOperate)
                            Gizmos.color = Color.green;
                        else
                            Gizmos.color = Color.white;

                        Gizmos.DrawWireCube(v, GridSize);
                    }
                }

                Gizmos.color = Color.white;
            }
        }
    }
}
