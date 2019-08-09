//
// MapScanner.cs
//
// Author:
//       duwenjie
//

//
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System;
using LBoot;
using System.Linq;
using System.Text.RegularExpressions;
using LitJson;
using System.Text;

public class MapScanner
{
    JsonMapWriter writer = null;

    public MapScanner()
    {
    }

    public void ScanCurrentScene()
    {
        var plane = GameObject.Find("/Plane");
        var width = (int)plane.transform.localScale.x * 10;
        var height = (int)plane.transform.localScale.z * 10;

        this.writer = new JsonMapWriter();

        this.writer.WriteObjectStart();
        this.writer.WriteMapDimension(width, height);
        this.writer.WritePropertyName("obstacles");
        this.writer.WriteArrayStart();

        var obstacles = GameObject.Find("/obstacles");
        if (obstacles != null)
        {
            foreach (Transform t in obstacles.transform)
            {
                if (t != obstacles.transform && t.gameObject.activeInHierarchy)
                {
                    this.writer.WriteObstacle(t.position, SizeOfEntity(t));
                }
            }
        }

        var buildings = GameObject.Find("/buildings");
        if (buildings != null)
        {
            foreach (Transform t in buildings.transform)
            {
                if (t != obstacles.transform && t.gameObject.activeInHierarchy)
                {
                    Match match = Regex.Match(t.name, @"([A-Za-z0-9_\-]+)([12])$");
                    if (match.Success)
                    {
                        string type = match.Groups[1].Value;
                        int side = Int32.Parse(match.Groups[2].Value);
                        var pos = t.position;
                        this.writer.WriteBuilding(t.position, SizeOfEntity(t), side, type);
                    }
                    else
                    {
                        throw new Exception("illegal building name: " + t.name);
                    }
                }
            }
        }

        this.writer.WriteArrayEnd();
        this.writer.WriteObjectEnd();
    }

    public string OutputString()
    {
        return this.writer.OutputString();
    }

    public void OutputToFile(string filename)
    {
        string s = this.writer.OutputString();
        File.WriteAllText(filename, s);
    }

    private Vector3 SizeOfEntity(Transform t)
    {
        var go = t.gameObject;
        var size = Vector3.zero;
        var collider = go.GetComponent<Collider>();
        if (collider != null)
        {
            size = collider.bounds.size;
        } 
        else
        {
            var renderer = go.GetComponent<Renderer>();
            if (renderer != null)
                size = renderer.bounds.size;
        }

        if (size != Vector3.zero)
        {
//            size = size * 0.8f;            
        }

        return size;
    }
}

public class JsonMapWriter
{
    StringBuilder sb = null;
    JsonWriter writer = null;

    public JsonMapWriter()
    {
        this.sb = new StringBuilder();
        this.writer = new JsonWriter(sb);
        this.writer.PrettyPrint = true;
    }

    public void WriteObjectStart()
    {
        this.writer.WriteObjectStart();
    }

    public void WriteObjectEnd()
    {
        this.writer.WriteObjectEnd();
    }

    public void WritePropertyName(string name)
    {
        this.writer.WritePropertyName(name);
    }

    public void WriteArrayStart()
    {
        this.writer.WriteArrayStart();
    }

    public void WriteArrayEnd()
    {
        this.writer.WriteArrayEnd();
    }

    public void WriteMapDimension(int width, int height)
    {
        this.writer.WritePropertyName("width");
        this.writer.Write(width);
        this.writer.WritePropertyName("height");
        this.writer.Write(height);
    }

    public void WriteObstacle(Vector3 pos, Vector3 size)
    {
        this.writer.WriteObjectStart();
        this.writer.WritePropertyName("pos");
        this.WriteVector3(pos);
        this.writer.WritePropertyName("size");
        this.WriteVector3(size);
        this.writer.WritePropertyName("type");
        this.writer.Write("ob");
        this.writer.WriteObjectEnd();
    }

    public void WriteBuilding(Vector3 pos, Vector3 size, int side, string type)
    {
        this.writer.WriteObjectStart();
        this.writer.WritePropertyName("pos");

        this.WriteVector3(pos);
        this.writer.WritePropertyName("size");
        this.WriteVector3(size);
        this.writer.WritePropertyName("side");
        this.writer.Write(side);
        this.writer.WritePropertyName("type");
        this.writer.Write(type);
        this.writer.WriteObjectEnd();
    }

    private void WriteVector3(Vector3 vec)
    {
        this.writer.WriteArrayStart();
        this.writer.Write(Mathf.Round(vec.x));
        this.writer.Write(Mathf.Round(vec.z));
        this.writer.WriteArrayEnd();
    }

    public string OutputString()
    {
        return this.sb.ToString();
    }
}
