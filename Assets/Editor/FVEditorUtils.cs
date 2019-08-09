using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;

public class FVEditorUtils
{
    static public string ShowOpenFileDialog(string title, string ext)
    {
        string path = EditorUtility.OpenFilePanel(title, "", ext);
        if (path == null || path == "")
        {
            return "";
        }
        string extension = System.IO.Path.GetExtension(path);
        if (extension != "." + ext)
        {
            return "";
        }
        return path;
    }
}
