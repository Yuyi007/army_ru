using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class FindReferences
{
  
    [MenuItem("Assets/Refrence/Find References", false, 10)]
    static private void Find()
    {
        EditorSettings.serializationMode = SerializationMode.ForceText;
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (!string.IsNullOrEmpty(path))
        {
            string guid = AssetDatabase.AssetPathToGUID(path);
            string withoutExtensions = "*.prefab*.unity*.mat*.asset*.a*.so*.bundle";
            string[] files = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories)
                .Where(s => withoutExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();
            int startIndex = 0;

            EditorApplication.update = delegate()
            {
                string file = files[startIndex];
                if( !(  file.EndsWith(".a") ||
                        file.EndsWith(".so") ||
                        file.EndsWith(".bundle"))
                  )
                {
                    bool isCancel = EditorUtility.DisplayCancelableProgressBar("匹配资源中", file, (float)startIndex / (float)files.Length);

                    if (Regex.IsMatch(File.ReadAllText(file), guid))
                    {
                        Debug.Log(file, AssetDatabase.LoadAssetAtPath<Object>(GetRelativeAssetsPath(file)));
                    }

                    startIndex++;
                    if (isCancel || startIndex >= files.Length)
                    {
                        EditorUtility.ClearProgressBar();
                        EditorApplication.update = null;
                        startIndex = 0;
                        Debug.Log("匹配结束");
                    }
                }
                else
                {
                    startIndex++;
                    if (startIndex >= files.Length)
                    {
                        EditorUtility.ClearProgressBar();
                        EditorApplication.update = null;
                        startIndex = 0;
                        Debug.Log("匹配结束");
                    }
                }
            };
        }
    }

    [MenuItem("Assets/Refrence/Find References", true)]
    static private bool VFind()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        return (!string.IsNullOrEmpty(path));
    }

    static private string GetRelativeAssetsPath(string path)
    {
        return "Assets" + Path.GetFullPath(path).Replace(Path.GetFullPath(Application.dataPath), "").Replace('\\', '/');
    }

    [MenuItem("Assets/Refrence/Find Dependences")]
    static private void FindDependences()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        string [] pathes = AssetDatabase.GetDependencies(path);
        foreach(var p in pathes)
        {
            Debug.Log(p);
        }
    }
}