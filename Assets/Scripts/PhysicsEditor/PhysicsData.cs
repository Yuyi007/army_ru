using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PhysicsType
{
    PhysicsScene,
    PhysicsEntity,
    Cube,
    Sphere,
}

public enum HeadType
{
    cube,
    sphere,
}

public enum PhysicsEntityType
{
    None = 0,
    Car = 1,
    Ball = 2,
    Wall = 3,
    BallWall = 4,
    Ground = 5,
    Goal1 = 6,
    Goal2 = 7,
    Barrier = 8
}

public class BaseEntityData
{
    public double posX;
    public double posY;
    public double posZ;

}
[System.Serializable]
public class CubeData : BaseEntityData
{
    public double length;
    public double width;
    public double height;

    public double quaternionX;
    public double quaternionY;
    public double quaternionZ;
    public double quaternionW;

}

[System.Serializable]
public class SphereData : BaseEntityData
{
    public double radius;
   
}

[System.Serializable]
public class EntityData:CubeData
{
    public string name;
    public PhysicsEntityType entityType;

    public List<CubeData> cubeData;
    public List<SphereData> sphereData;
    public int headIndex;
    public HeadType headType;
    public string tid;

    public EntityData()
    {
        cubeData = new List<CubeData>();
        sphereData = new List<SphereData>();
    }
}

public class SceneData
{
    public string name;
    public List<EntityData> entities;

    public SceneData()
    {
        entities = new List<EntityData>();
    }
}

