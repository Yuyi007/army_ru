using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;
using System.Text.RegularExpressions;

[CustomEditor(typeof(DrawGizmosTest))]
public class DrawGizmosEditorTest : Editor {

    DrawGizmosTest model;
    Vector2Int value;
    List<Vector2Int> list = new List<Vector2Int>();
    string mapPrefix = "";

    public void OnEnable()
    {
        model = target as DrawGizmosTest;
    }

    //GUI界面
    public override void OnInspectorGUI()
    {
        //设置地图尺寸
        //model.Size = EditorGUILayout.Vector2IntField("MapSize", model.Size, GUILayout.Width(370));

        //model.GridSize = EditorGUILayout.Vector3IntField("GridSize", model.GridSize, GUILayout.Width(370));

        model.mSize = EditorGUILayout.Vector2IntField("MapSize", model.mSize, GUILayout.Width(370));
        model.mGridSize = EditorGUILayout.Vector3IntField("GridSize", model.mGridSize, GUILayout.Width(370));

        model.ToolSize = EditorGUILayout.Vector2IntField("ToolSize", model.ToolSize, GUILayout.Width(370));

        if (GUILayout.Button("Open Color Window", GUILayout.Width(255)))
        {
            GizmosColorWindow window = (GizmosColorWindow)EditorWindow.GetWindow(typeof(GizmosColorWindow));
            window.Init();
        }

        //开始绘制
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Begin Draw", GUILayout.Width(125)))
        {
            SceneView.onSceneGUIDelegate += GridUpdate;
            model.beginOperate = false;
        }

        //结束绘制
        if (GUILayout.Button("End Draw", GUILayout.Width(125)))
        {
            model.beginOperate = false;

            RemoveDelegate();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        #region //保存绘制好的地图格子信息
        if (GUILayout.Button("Save GridData", GUILayout.Width(125)))
        {
            string str = SaveGridData();

            string name = model.SetName();

            string file = SaveOrExportHelper(".txt", name);

            File.WriteAllText(file, str, Encoding.UTF8);

            AssetDatabase.Refresh();

            string msg = string.Format("GridData 保存成功!");
            UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
        }
        #endregion

        //读取存储的地图格子信息
        if (GUILayout.Button("Load GridData", GUILayout.Width(125)))
        {
            ReadGridData();
        }
        GUILayout.EndHorizontal();

        #region 暂时无用
        if (GUILayout.Button("Export GridData(.lua)", GUILayout.Width(255)))
        {
            string str = ExportGridDataToLua();

            //string name = model.SetName();
            string suffix = ".lua";
            //string file = SaveOrExportHelper(".lua", "MapGridData");
            string file = Application.dataPath + "/Editor/Helper/" + "MapGridData" + suffix;

            File.WriteAllText(file, str, Encoding.ASCII);

            AssetDatabase.Refresh();

            string msg = string.Format("GridData 导出成功!");
            UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
        } 
        #endregion

        //导出（格子0或1的lua table）
        GUILayout.BeginHorizontal();
        #region 导出
        if (GUILayout.Button("Export GridDataCar", GUILayout.Width(125)))
        {
            if (mapPrefix == "")
            {
                EditorUtility.DisplayDialog("提示",
                                                     "请输入地图前缀：\n",
                                                     "yes");
                return;
            }
            
            string str = ExportGridDataToLua();

            //string name = model.SetName();
            string suffix = ".lua";
            //string file = SaveOrExportHelper(".lua", "MapGridData");
            string file = Application.dataPath + "/Editor/Helper/" + mapPrefix + "_MapGridDataCar" + suffix;

            File.WriteAllText(file, str, Encoding.ASCII);

            AssetDatabase.Refresh();

            string msg = string.Format("GridData 导出成功!");
            UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
        }
        if (GUILayout.Button("Export GridDataBall", GUILayout.Width(125)))
        {
            if (mapPrefix == "")
            {
                EditorUtility.DisplayDialog("提示",
                                                     "请输入地图前缀：\n",
                                                     "yes");
                return;
            }

            string str = ExportGridDataToLua();

            //string name = model.SetName();
            string suffix = ".lua";
            //string file = SaveOrExportHelper(".lua", "MapGridData");
            string file = Application.dataPath + "/Editor/Helper/" + mapPrefix + "_MapGridDataBall" + suffix;

            File.WriteAllText(file, str, Encoding.ASCII);

            AssetDatabase.Refresh();

            string msg = string.Format("GridData 导出成功!");
            UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
        } 
        #endregion
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        #region //导出(判断车是否在可行走范围的lua table)
        if (GUILayout.Button("Export Car Range", GUILayout.Width(125)))
        {
            if (mapPrefix == "")
            {
                EditorUtility.DisplayDialog("提示",
                                                     "请输入地图前缀：\n",
                                                     "yes");
                return;
            }

            string str_ = SaveNearestPlace("NearestPlace");

            string suffix = ".lua";

            string file_ = Application.dataPath + "/Editor/Helper/" + mapPrefix + "_RangeOfCar" + suffix;

            File.WriteAllText(file_, str_, Encoding.ASCII);

            AssetDatabase.Refresh();

            string msg = string.Format("Range of Car 导出成功!");
            UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
        } 
        #endregion

        #region //导出(判断球是否在可行走范围的lua table)
        if (GUILayout.Button("Export Ball Range", GUILayout.Width(125)))
        {
            if (mapPrefix == "")
            {
                EditorUtility.DisplayDialog("提示",
                                                     "请输入地图前缀：\n",
                                                     "yes");
                return;
            }

            string str_ = SaveNearestPlace("NearestPlaceOfBall");

            string suffix = ".lua";

            string file_ = Application.dataPath + "/Editor/Helper/" + mapPrefix + "_RangeOfBall" + suffix;

            File.WriteAllText(file_, str_, Encoding.ASCII);

            AssetDatabase.Refresh();

            string msg = string.Format("Range of Ball 导出成功!");
            UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
        } 
        #endregion
        GUILayout.EndHorizontal();

        mapPrefix = GUILayout.TextField(mapPrefix, GUILayout.Width(255));

        //同步
        if (GUILayout.Button("Synchronous", GUILayout.Width(255)))
        {
            CopyAndMoveFile();
        }

        #region //获取画笔或橡皮擦工具
        if (EditorGUILayout.Toggle("Brush", model.getBrush))
        {
            model.getEraser = false;
            model.getBrush = true;
            model.none = false;
        }
        if (EditorGUILayout.Toggle("Eraser", model.getEraser))
        {
            model.getBrush = false;
            model.getEraser = true;
            model.none = false;
        }
        if (EditorGUILayout.Toggle("None", model.none))
        {
            model.getBrush = false;
            model.getEraser = false;
            model.none = true;
        } 
        #endregion

        SceneView.RepaintAll();
    }

    //Update监控输入
    void GridUpdate(SceneView sceneView)
    {
        Event e = Event.current;

        Vector3 gridPosition = Camera.current.ScreenToWorldPoint(new Vector3(e.mousePosition.x, 
            Camera.current.pixelHeight - e.mousePosition.y, Camera.current.transform.position.y));

        Vector3Int aligned = new Vector3Int((int)(Mathf.Floor((gridPosition.x + model.Size.x / 2f) / model.GridSize.x)), 0,
                (int)(Mathf.Floor((gridPosition.z + model.Size.y / 2f) / model.GridSize.z)));

        //地图边界
        Vector3Int outsideSpace = new Vector3Int(aligned.x * model.GridSize.x, 0, aligned.z * model.GridSize.z);

        Vector2Int leftDown = new Vector2Int(Mathf.Clamp(aligned.x - model.ToolSize.x, 0, (model.Size.x / model.GridSize.x) - 1),
                Mathf.Clamp(aligned.z - model.ToolSize.y, 0, (model.Size.y / model.GridSize.z) - 1));
        Vector2Int rightUp = new Vector2Int(Mathf.Clamp(aligned.x + model.ToolSize.x, 0, (model.Size.x / model.GridSize.x) - 1),
                Mathf.Clamp(aligned.z + model.ToolSize.y, 0, (model.Size.y / model.GridSize.z) - 1));

        //单机鼠标左键开始操作
        //if (e.isMouse && e.type == EventType.MouseDown && e.button == 0 && model.none == false)
        //{
        //    if (model.beginOperate == false)
        //        model.beginOperate = true;
        //    else if (model.beginOperate == true)
        //        model.beginOperate = false;
        //}

        //F1、F2切换工具
        if (e.isKey && e.keyCode == KeyCode.F1)
        {
            model.getEraser = false;
            model.getBrush = true;
            model.none = false;
            model.beginOperate = true;
        }
        else if (e.isKey && e.keyCode == KeyCode.F2)
        {
            model.getBrush = false;
            model.getEraser = true;
            model.none = false;
            model.beginOperate = true;
        }
        else if (e.isKey && e.keyCode == KeyCode.F3)
        {
            model.getBrush = false;
            model.getEraser = false;
            model.none = true;
            model.beginOperate = false;
        }

        //绘制
        if (model.getBrush && !model.getEraser && model.beginOperate)
        {
            if (outsideSpace.x < 0 || outsideSpace.x >= model.Size.x || outsideSpace.z < 0 || outsideSpace.z >= model.Size.y)
            {
                return;
            }

            for (int i = leftDown.y; i <= rightUp.y; i++)
            {
                for (int j = leftDown.x; j <= rightUp.x; j++)
                {
                    if (model.a[j, i] != 1)
                    {
                        model.a[j, i] = 1;
                    }
                }
            }
        }
        //擦除
        else if (!model.getBrush && model.getEraser && model.beginOperate)
        {
            if (outsideSpace.x < 0 || outsideSpace.x >= model.Size.x || outsideSpace.z < 0 || outsideSpace.z >= model.Size.y)
            {
                return;
            }

            for (int i = leftDown.y; i <= rightUp.y; i++)
            {
                for (int j = leftDown.x; j <= rightUp.x; j++)
                {
                    if (model.a[j, i] == 1)
                    {
                        model.a[j, i] = 0;
                    }
                }
            }
        }
    }

    //保存绘制的格子数据（txt）
    string SaveGridData()
    {
        string str = "";

        int horizontal = model.Size.x / model.GridSize.x;
        int vertical = model.Size.y / model.GridSize.z;

        str += (horizontal.ToString() + "_" + vertical.ToString() + "\n");
        str += ((model.GridSize.x).ToString() + "_" + (model.GridSize.y).ToString() + "_" + (model.GridSize.z).ToString() + "\n");

        for (int i = 0; i < vertical; i++)
        {
            for (int j = 0; j < horizontal; j++)
            {
                if (j != horizontal - 1)
                    str += (model.a[j, i].ToString() + "_");
                else
                {
                    if (i == vertical - 1)
                        str += (model.a[j, i].ToString());
                    else
                        str += (model.a[j, i].ToString() + "\n");
                }
            }
        }

        return str;
    }

    //读取txt数据并绘制
    void ReadGridData()
    {
        string path = Application.dataPath + "/Editor/Helper/";
        string selectFile = EditorUtility.OpenFilePanel("请选择要读取的文件", path, "txt");

        if (selectFile == "")
        {
            return;
        }

        StreamReader sr = new StreamReader(selectFile);
        string str = sr.ReadToEnd();
        List<string> eachLine = new List<string>();
        eachLine.AddRange(str.Split('\n'));

        string[] mapSize = new string[2];
        mapSize = eachLine[0].Split('_');

        string[] gridSize = new string[3];
        gridSize = eachLine[1].Split('_');

        int a = int.Parse(mapSize[0]);
        int b = int.Parse(mapSize[1]);
        int[,] spaces = new int[a, b];
        for (int i = 2; i < eachLine.Count; i++)
        {
            string s = eachLine[i];
            string[] ss = new string[a];
            ss = s.Split('_');
            for (int j = 0; j < a; j++)
            {
                spaces[j, i - 2] = int.Parse(ss[j]);
            }
        }

        model.mGridSize = new Vector3Int(int.Parse(gridSize[0]), int.Parse(gridSize[1]), int.Parse(gridSize[2]));
        //model.SetGridSize(int.Parse(gridSize[0]), int.Parse(gridSize[1]), int.Parse(gridSize[2]));
        model.mSize = new Vector2Int(a * (int.Parse(gridSize[0])), b * (int.Parse(gridSize[2])));
        //model.SetMapSize(a * (int.Parse(gridSize[0])), b * (int.Parse(gridSize[2])));
        model.SetArray(a, b);
        for (int i = 0; i < b; i++)
        {
            for (int j = 0; j < a; j++)
            {
                model.a[j, i] = spaces[j, i];
            }
        }

        sr.Close();
        model.beginOperate = false;
    }

    //将绘制的格子数据导出成lua
    string ExportGridDataToLua()
    {
        string str = "";
        str += "return {" + "\n" + "{";

        int horizontal = model.Size.x / model.GridSize.x;
        int vertical = model.Size.y / model.GridSize.z;

        for (int i = 0; i < vertical; i++)
        {
            for (int j = 0; j < horizontal; j++)
            {
                if (j != horizontal - 1)
                    str += (model.a[j, i].ToString() + ", ");
                else
                {
                    if (i == vertical - 1)
                        str += (model.a[j, i].ToString() + "}}");
                    else
                        str += (model.a[j, i].ToString() + "}," + "\n" + "{");
                }
            }
        }

        return str;
    }

    //找到距离每个值为0的格子最近的值为1的格子
    string SaveNearestPlace(string className)
    {
        string str = "";
        str += "return {" + "\n" + "{";

        int horizontal = model.Size.x / model.GridSize.x;
        int vertical = model.Size.y / model.GridSize.z;

        for (int i = 0; i < vertical; i++)
        {
            for (int j = 0; j < horizontal; j++)
            {
                if (j != horizontal - 1)
                {
                    if (model.a[j, i] == 0)
                    {
                        CalculateNearestPlace(j, i, 1);
                        string str_x = AddSpace(value.x);
                        string str_y = AddSpace(value.y);
                        str += "{" + str_x + value.x.ToString() + ", " + str_y + value.y.ToString() + "}, ";
                    }
                    else
                    {
                        str += ("{ -1,  -1}" + ", ");
                    }
                }
                else
                {
                    if (i == vertical - 1)
                    {
                        if (model.a[j, i] == 0)
                        {
                            CalculateNearestPlace(j, i, 1);
                            string str_x = AddSpace(value.x);
                            string str_y = AddSpace(value.y);
                            str += "{" + str_x + value.x.ToString() + ", " + str_y + value.y.ToString() + "}}}";
                        }
                        else
                        {
                            str += "{ -1,  -1}}}";
                        }
                    }
                    else
                    {
                        if (model.a[j, i] == 0)
                        {
                            CalculateNearestPlace(j, i, 1);
                            string str_x = AddSpace(value.x);
                            string str_y = AddSpace(value.y);
                            str += "{" + str_x + value.x.ToString() + ", " + str_y + value.y.ToString() + "}}," + "\n" + "{";
                        }
                        else
                        {
                            str += ("{ -1,  -1}}," + "\n" + "{");
                        }
                    }
                }
            }
        }

        return str;
    }

    void CalculateNearestPlace(int j, int i, int round)
    {
        int leftDown_tempX = j;  //左右  x
        int leftDown_tempY = i;  //上下  y
        int rightUp_tempX = j;
        int rightUp_tempY = i;

        leftDown_tempX = Mathf.Clamp(j - round, 0, (model.Size.x / model.GridSize.x) - 1);
        leftDown_tempY = Mathf.Clamp(i - round, 0, (model.Size.y / model.GridSize.z) - 1);
        rightUp_tempX = Mathf.Clamp(j + round, 0, (model.Size.x / model.GridSize.x) - 1);
        rightUp_tempY = Mathf.Clamp(i + round, 0, (model.Size.y / model.GridSize.z) - 1);
        Vector2Int leftDown = new Vector2Int(leftDown_tempX, leftDown_tempY);
        Vector2Int rightUp = new Vector2Int(rightUp_tempX, rightUp_tempY);

        if (model.a[leftDown_tempX, i] == 1)  //左
        {
            value = new Vector2Int(leftDown_tempX, i);
            return;
        }
        else if (model.a[j, leftDown_tempY] == 1)  //下
        {
            value = new Vector2Int(j, leftDown_tempY);
            return;
        }
        else if (model.a[j, rightUp_tempY] == 1)  //上
        {
            value = new Vector2Int(j, rightUp_tempY);
            return;
        }
        else if (model.a[rightUp_tempX, i] == 1)  //右
        {
            value = new Vector2Int(rightUp_tempX, i);
            return;
        }

        //if (VertiCirculation(i, 1, 0, leftDown, rightUp))
        //    return;
        //if (VertiCirculation(i, -1, 0, leftDown, rightUp))
        //    return;
        //if (HoriCirculation(j, 1, 1, leftDown, rightUp))
        //    return;
        //if (HoriCirculation(j, -1, 1, leftDown, rightUp))
        //    return;
        //if (VertiCirculation(i, 1, 1, leftDown, rightUp))
        //    return;
        //if (VertiCirculation(i, -1, 1, leftDown, rightUp))
        //    return;
        //if (HoriCirculation(j, 1, 0, leftDown, rightUp))
        //    return;
        //if (HoriCirculation(j, -1, 0, leftDown, rightUp))
        //    return;

        VertiCirculationTest(i, 1, 0, leftDown, rightUp);
        VertiCirculationTest(i, -1, 0, leftDown, rightUp);
        HoriCirculationTest(j, 1, 1, leftDown, rightUp);
        HoriCirculationTest(j, -1, 1, leftDown, rightUp);
        VertiCirculationTest(i, 1, 1, leftDown, rightUp);
        VertiCirculationTest(i, -1, 1, leftDown, rightUp);
        HoriCirculationTest(j, 1, 0, leftDown, rightUp);
        HoriCirculationTest(j, -1, 0, leftDown, rightUp);

        if (list.Count > 0)
        {
            CalculateInList(j, i);
            return;
        }

        round++;
        CalculateNearestPlace(j, i, round);
    }

    bool HoriCirculation(int j, int dir, int upOrDown, Vector2Int leftDown, Vector2Int rightUp)
    {
        Vector2Int tempValue = Vector2Int.zero;
        if (upOrDown == 1)
            tempValue.y = rightUp.y;
        else
            tempValue.y = leftDown.y;

        if (dir == 1)
        {
            for (int x = j + dir; x <= rightUp.x; x += dir)  //横向循环向右
            {
                tempValue.x = x;
                if (model.a[tempValue.x, tempValue.y] == 1)
                {
                    value = tempValue;
                    return true;
                }
            }
        }
        else
        {
            for (int x = j + dir; x >= leftDown.x; x += dir)  //横向循环向左
            {
                tempValue.x = x;
                if (model.a[tempValue.x, tempValue.y] == 1)
                {
                    value = tempValue;
                    return true;
                }
            }
        }

        return false;
    }

    bool VertiCirculation(int i, int dir, int leftOrRight, Vector2Int leftDown, Vector2Int rightUp)
    {
        Vector2Int tempValue = Vector2Int.zero;
        if (leftOrRight == 1)
            tempValue.x = rightUp.x;
        else
            tempValue.x = leftDown.x;

        if (dir == 1)
        {
            for (int y = i + dir; y <= rightUp.y; y += dir)   //纵向循环向上
            {
                tempValue.y = y;
                if (model.a[tempValue.x, tempValue.y] == 1)
                {
                    value = tempValue;
                    return true;
                }
            }
        }
        else
        {
            for (int y = i + dir; y >= leftDown.y; y += dir)   //纵向循环向下
            {
                tempValue.y = y;
                if (model.a[tempValue.x, tempValue.y] == 1)
                {
                    value = tempValue;
                    return true;
                }
            }
        }
        return false;
    }

    void HoriCirculationTest(int j, int dir, int upOrDown, Vector2Int leftDown, Vector2Int rightUp)
    {
        Vector2Int tempValue = Vector2Int.zero;
        if (upOrDown == 1)
            tempValue.y = rightUp.y;
        else
            tempValue.y = leftDown.y;

        if (dir == 1)
        {
            for (int x = j + dir; x <= rightUp.x; x += dir)  //横向循环向右
            {
                tempValue.x = x;
                if (model.a[tempValue.x, tempValue.y] == 1)
                    list.Add(tempValue);
            }
        }
        else
        {
            for (int x = j + dir; x >= leftDown.x; x += dir)  //横向循环向左
            {
                tempValue.x = x;
                if (model.a[tempValue.x, tempValue.y] == 1)
                    list.Add(tempValue);
            }
        }
    }

    void VertiCirculationTest(int i, int dir, int leftOrRight, Vector2Int leftDown, Vector2Int rightUp)
    {
        Vector2Int tempValue = Vector2Int.zero;
        if (leftOrRight == 1)
            tempValue.x = rightUp.x;
        else
            tempValue.x = leftDown.x;

        if (dir == 1)
        {
            for (int y = i + dir; y <= rightUp.y; y += dir)   //纵向循环向上
            {
                tempValue.y = y;
                if (model.a[tempValue.x, tempValue.y] == 1)
                    list.Add(tempValue);
            }
        }
        else
        {
            for (int y = i + dir; y >= leftDown.y; y += dir)   //纵向循环向下
            {
                tempValue.y = y;
                if (model.a[tempValue.x, tempValue.y] == 1)
                    list.Add(tempValue);
            }
        }
    }

    void CalculateInList(int j, int i)
    {
        Vector2Int temp = list[0];
        int sum = Mathf.Abs(list[0].x - j) + Mathf.Abs(list[0].y - i);
        for (int a = 0; a < list.Count; a++)
        {
            int sum_ = Mathf.Abs(list[a].x - j) + Mathf.Abs(list[a].y - i);
            if (sum_ < sum)
            {
                temp = list[a];
                sum = sum_;
            }
        }
        value = temp;
        list.Clear();
    }

    //移除每帧的监控
    void RemoveDelegate()
    {
        Delegate[] del = SceneView.onSceneGUIDelegate.GetInvocationList();
        if (del != null)
        {
            for (int i = 0; i < del.Length; i++)
            {
                SceneView.onSceneGUIDelegate -= del[i] as SceneView.OnSceneFunc;
            }
        }
    }

    //复制lua文本到rs目录下，默认不覆盖
    void CopyAndMoveFile()
    {
        string path = Application.dataPath + "/Editor/Helper/";
        string selectFile = EditorUtility.OpenFilePanel("请选择要复制并移动的文件", path, "lua");

        if (selectFile == "")
        {
            return;
        }

        //获取该脚本的绝对路径
        string[] a = Directory.GetFiles(Application.dataPath + "/Editor/Helper/");

        //拿到到Race的绝对路径
        string[] str_1 = Regex.Split(a[0], "/Race/");
        string[] str_2 = Regex.Split(a[0], str_1[str_1.Length - 1]);

        //获取源文件名，在选定的文件同一目录下复制并重命名文件
        string[] str_3 = Regex.Split(selectFile, "/Helper/");

        List<string> str_name = new List<string>();
        str_name.AddRange(str_3[str_3.Length - 1].Split('.'));
        string name = str_name[0];

        if (str_name.Count > 2)
        {
            for (int i = 0; i < str_name.Count - 2; i++)
            {
                name = name + "." + str_name[i + 1];
            }
        }

        string copyFile = name + "_copy";
        string suffix = ".lua";
        string finalCopyFile = copyFile + suffix;

        int num = 1;
        while (File.Exists(finalCopyFile))
        {
            finalCopyFile = copyFile + "(" + num + ")" + suffix;
            num++;
        }

        //File.Copy(selectFile, copyFile);
        File.Copy(selectFile, finalCopyFile, true);

        //将复制的文件转移到新目录并重命名为源文件名
        string targetPath = str_2[0] + "rs/client/scripts/game/combat/competitive_combat/mapdata/" + name;
        string finalTargetPath = targetPath + suffix;

        //int num_1 = 1;
        //while (File.Exists(finalTargetPath))
        //{
        //    finalTargetPath = targetPath + "(" + num_1 + ")" + suffix;
        //    num_1++;
        //}

        while (File.Exists(finalTargetPath))
        {
            File.Delete(finalTargetPath);
        }

        FileUtil.MoveFileOrDirectory(finalCopyFile, finalTargetPath);
        //File.Move(finalCopyFile, finalTargetPath);

        AssetDatabase.Refresh();

        string msg = string.Format("同步成功!");
        UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
    }

    //当保存和导出时出现同名文件的提示框
    string SaveOrExportHelper(string suffix, string name)
    {
        string file = Application.dataPath + "/Editor/Helper/" + name + suffix;

        if (File.Exists(file))
        {
            bool option = EditorUtility.DisplayDialog("提示",
                                                      "该目录下已经存在同名文件！是否覆盖：\n",
                                                      "yes", "no");
            switch (option)
            {
                case true:
                    break;
                case false:
                    string finalName = "";
                    int num = 1;
                    while (File.Exists(file))
                    {
                        finalName = name + "(" + num + ")";
                        file = Application.dataPath + "/Editor/Helper/" + finalName + suffix;
                        num++;
                    }
                    break;
            }
        }

        return file;
    }

    string AddSpace(int num)
    {
        if (num < 10)
            return "  ";
        else if (num < 100)
            return " ";
        else
            return "";
    }
}
