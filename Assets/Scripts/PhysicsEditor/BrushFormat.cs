using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BrushFormat : MonoBehaviour {

    Vector3 startPoint;
    Vector3 endPoint;
    bool isCalculate;
    Vector2 cubeSize;

    

    public Vector2 CubeSize
    {
        get
        {
            return cubeSize;
        }

        set
        {
            cubeSize = value;
        }
    }

    public Vector3 StartPoint
    {
        get
        {
            return startPoint;
        }

        set
        {
            startPoint = value;
        }
    }

    public Vector3 EndPoint
    {
        get
        {
            return endPoint;
        }

        set
        {
            endPoint = value;
        }
    }

    public bool IsCalculate
    {
        get
        {
            return isCalculate;
        }

        set
        {
            isCalculate = value;
            CalculateCubeNum();
        }
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void CalculateCubeNum()
    {
        if (StartPoint == EndPoint || (CubeSize.x == 0 || CubeSize.y == 0) || (CubeSize.x > transform.localScale.x && CubeSize.y > transform.localScale.z))
        {
            return;
        }

        Vector2 v = new Vector2(Mathf.Abs(EndPoint.x - StartPoint.x) + Mathf.Abs(transform.localScale.x), Mathf.Abs(EndPoint.z - StartPoint.z) + Mathf.Abs(transform.localScale.z));

        Vector2 v_1 = new Vector2(StartPoint.x - EndPoint.x, 0);
        Vector2 v_2 = new Vector2(0, StartPoint.z - EndPoint.z);

        int horizontalNum = (int)Mathf.Ceil(v.x / CubeSize.x);
        int verticalNum = Mathf.Abs((int)Mathf.Ceil(transform.localScale.z / CubeSize.y));

        if (v_1.x == 0 || v_2.y == 0)
        {
            verticalNum = (int)Mathf.Ceil(v.y / CubeSize.y);
        }
        

        
        Debug.Log(horizontalNum);
        Debug.Log(verticalNum);

        FindStartPoint(v, v_1, v_2, transform.localScale.x, transform.localScale.z, StartPoint, horizontalNum, verticalNum, CubeSize);
    }

    void FindStartPoint(Vector2 v_all, Vector2 v_1, Vector2 v_2, float x, float z, Vector3 start, int horizontalNum, int verticalNum, Vector2 cubeSize)
    {
        Vector3 v = new Vector3();
        int dir_1 = 1;
        int dir_2 = 1;
        int dir_3 = 1;

        //z方向移动
        if (v_1.x == 0)
        {
            if (v_2.y > 0)
            {
                v.x = (start.x - x * 0.5f) + (cubeSize.x * 0.5f);
                v.z = (start.z + z * 0.5f) - (cubeSize.y * 0.5f);
                dir_1 = 1;
                dir_2 = -1;
            }
            else
            {
                v.x = (start.x - x * 0.5f) + (cubeSize.x * 0.5f);
                v.z = (start.z - z * 0.5f) + (cubeSize.y * 0.5f);
                dir_1 = 1;
                dir_2 = 1;
            }

            for (int i = 0; i < verticalNum; i++)
            {
                for (int j = 0; j < horizontalNum; j++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.localScale = new Vector3(cubeSize.x, 1, cubeSize.y);
                    cube.transform.position = new Vector3(v.x + dir_1 * j * cubeSize.x, 0, v.z + dir_2 * i * cubeSize.y);
                }
            }
        }

        //x方向移动
        else if (v_2.y == 0)
        {
            if (v_1.x > 0)
            {
                v.x = (start.x + x * 0.5f) - (cubeSize.x * 0.5f);
                v.z = (start.z - z * 0.5f) + (cubeSize.y * 0.5f);
                dir_1 = 1;
                dir_2 = -1;
            }
            else
            {
                v.x = (start.x - x * 0.5f) + (cubeSize.x * 0.5f);
                v.z = (start.z - z * 0.5f) + (cubeSize.y * 0.5f);
                dir_1 = 1;
                dir_2 = 1;
            }

            for (int i = 0; i < horizontalNum; i++)
            {
                for (int j = 0; j < verticalNum; j++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.localScale = new Vector3(cubeSize.x, 1, cubeSize.y);
                    cube.transform.position = new Vector3(v.x + dir_2 * i * cubeSize.x, 0, v.z + dir_1 * j * cubeSize.y);
                }
            }
        }

        else
        {
            if (v_1.x > 0)
            {
                v.x = (start.x + x * 0.5f) - (cubeSize.x * 0.5f);
                v.z = (start.z - z * 0.5f) + (cubeSize.y * 0.5f);
                dir_1 = 1;
                dir_2 = -1;

                float perAddNum = Mathf.Ceil(v_all.y / horizontalNum);
                if (v_2.y > 0)
                    dir_3 = -1;
                else
                    dir_3 = 1;

                for (int i = 0; i < horizontalNum; i++)
                {
                    for (int j = 0; j < verticalNum; j++)
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.localScale = new Vector3(cubeSize.x, 1, cubeSize.y);
                        cube.transform.position = new Vector3(v.x + dir_2 * i * cubeSize.x, 0, v.z + dir_1 * j * cubeSize.y + dir_3 * perAddNum * i);
                    }
                }
            }
        }
        
    }
}
