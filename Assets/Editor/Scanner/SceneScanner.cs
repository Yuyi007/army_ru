//
// SceneScanner.cs
//
// Author:
//       duwenjie
//

//
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

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
using LBootEditor;

public class QuestAreaConfig
{
    public class Position
    {
        public double x;
        public double y;
        public double z;

        public void FromVector3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
    }

    public class Area
    {
        public Position p = new Position();

        public Area()
        {
        }

        public Area(Vector3 pos)
        {
            p.FromVector3(pos);
        }

    }

    public class Trigger
    {
        public string name;
        public Dictionary<string, Area> areas = new Dictionary<string, Area>();

        public Trigger()
        {
        }

        public Trigger(string name)
        {
            this.name = name;
        }

        public void Add(string name, Vector3 pos)
        {
            areas[name] = new Area(pos);
        }
    }

    public Dictionary<string, Trigger> triggers = new Dictionary<string, Trigger>();

    public void AddTrigger(Trigger trigger)
    {
        triggers[trigger.name] = trigger;
    }

    public string ToJson()
    {
        return LitJson.JsonMapper.ToJson(triggers);
    }
}

public class InvestigateConfig : QuestAreaConfig {}

public class NpcConfig
{
    public class Position
    {
        public double x;
        public double y;
        public double z;

        public void FromVector3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
    }

    public class Npc
    {
        public Position p = new Position();

        public Npc()
        {
        }

        public Npc(Vector3 pos)
        {
            p.FromVector3(pos);
        }

    }

    public class Trigger
    {
        public string name;
        public Dictionary<string, Npc> npcs = new Dictionary<string, Npc>();

        public Trigger()
        {
        }

        public Trigger(string name)
        {
            this.name = name;
        }

        public void Add(string name, Vector3 pos)
        {
            npcs[name] = new Npc(pos);
        }
    }

    public Dictionary<string, Trigger> triggers = new Dictionary<string, Trigger>();

    public void AddTrigger(Trigger trigger)
    {
        triggers[trigger.name] = trigger;
    }

    public string ToJson()
    {
        return LitJson.JsonMapper.ToJson(triggers);
    }
}

public class FacilityConfig
{
    public class Position
    {
        public double x;
        public double y;
        public double z;

        public void FromVector3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
    }

    public class Facility
    {
        public Position p = new Position();

        public Facility()
        {
        }

        public Facility(Vector3 pos)
        {
            p.FromVector3(pos);
        }

    }

    public class Trigger
    {
        public string name;
        public Dictionary<string, Facility> facilities = new Dictionary<string, Facility>();

        public Trigger()
        {
        }

        public Trigger(string name)
        {
            this.name = name;
        }

        public void Add(string name, Vector3 pos)
        {
            facilities[name] = new Facility(pos);
        }
    }

    public Dictionary<string, Trigger> triggers = new Dictionary<string, Trigger>();

    public void AddTrigger(Trigger trigger)
    {
        triggers[trigger.name] = trigger;
    }

    public string ToJson()
    {
        return LitJson.JsonMapper.ToJson(triggers);
    }
}

public class TranConfig
{
    public class Position
    {
        public double x;
        public double y;
        public double z;

        public void FromVector3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
    }

    public class Transfer
    {
        public Position p = new Position();
        public bool teleport = false;

        public Transfer()
        {
        }

        public Transfer(Vector3 pos, bool teleport)
        {
            this.teleport = teleport;
            p.FromVector3(pos);
        }

    }

    public class Trigger
    {
        public string name;
        public Dictionary<string, Transfer> transfers = new Dictionary<string, Transfer>();

        public Trigger()
        {
        }

        public Trigger(string name)
        {
            this.name = name;
        }

        public void Add(string name, Vector3 pos, bool teleport = false)
        {
            transfers[name] = new Transfer(pos, teleport);
        }
    }

    public Dictionary<string, Trigger> triggers = new Dictionary<string, Trigger>();

    public void AddTrigger(Trigger trigger)
    {
        triggers[trigger.name] = trigger;
    }

    public string ToJson()
    {
        return LitJson.JsonMapper.ToJson(triggers);
    }
}

public class SceneConfig
{
    public class Position
    {
        public double x;
        public double y;
        public double z;

        public void FromVector3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
    }

    public class Ground
    {
        public Position min = new Position();
        public Position max = new Position();

        public Ground()
        {
        }

        public Ground(Bounds bound)
        {
            min.FromVector3(bound.min);
            max.FromVector3(bound.max);
            max.y += 1; // tolerance 1
        }
    }

    public class Wall
    {
        public Position center = new Position();
        public Position size = new Position();

        public Wall()
        {
        }

        public Wall(Bounds bounds)
        {
            center.FromVector3(bounds.center);
            size.FromVector3(bounds.size);
        }
    }

    public class Obstacle : Wall 
    {
        public Obstacle(Bounds bounds)
        {
            center.FromVector3(bounds.center);
            size.FromVector3(bounds.size);
        }
    }

    public class Portal
    {
        public Position pos = new Position();
        public string id = "";
    }

    public class Street
    {
        public string name;
        public List<Ground> grounds = new List<Ground>();
        public List<Wall> walls = new List<Wall>();
        public List<Obstacle> obstacles = new List<Obstacle>();
        public Dictionary<string, Portal> portals = new Dictionary<string, Portal>();

        public Street()
        {
        }

        public Street(string name)
        {
            this.name = name;
        }

        public void AddGround(Ground ground)
        {
            grounds.Add(ground);
        }

        public void AddWall(Wall wall)
        {
            walls.Add(wall);
        }

        public void AddObstacle(Obstacle obstacle)
        {
            obstacles.Add(obstacle);
        }

        public void AddPortal(Portal portal)
        {
            portals[portal.id] = portal;
        }

        public void AddPortal(Transform portalTrans)
        {
            var portal = new Portal();
            portal.pos.FromVector3(portalTrans.position);
            portal.id = portalTrans.name;
            AddPortal(portal);
        }

        public void AddGround(Bounds bound)
        {
            var ground = new Ground(bound);
            AddGround(ground);
        }
    }

    public Dictionary<string, Street> streets = new Dictionary<string, Street>();

    public string ToJson()
    {
        return LitJson.JsonMapper.ToJson(streets);
    }

    public void AddStreet(Street street)
    {
        streets[street.name] = street;
    }
}

public class SceneScanner
{
    SceneConfig.Street street = null;
    TranConfig.Trigger ttran = null;
    FacilityConfig.Trigger tfacility = null;
    NpcConfig.Trigger tnpc = null;
    QuestAreaConfig.Trigger tquest = null;
    InvestigateConfig.Trigger tinvestigate = null;

    public SceneScanner(SceneConfig.Street street,
                        TranConfig.Trigger ttran,
                        FacilityConfig.Trigger tfacility,
                        NpcConfig.Trigger tnpc,
                        QuestAreaConfig.Trigger tquest,
                        InvestigateConfig.Trigger tinvestigate)
    {
        this.street = street;
        this.ttran = ttran;
        this.tfacility = tfacility;
        this.tnpc = tnpc;
        this.tquest = tquest;
        this.tinvestigate = tinvestigate;
    }


    public void ScanCurrentScene(string sceneName)
    {
        var groundRoot = GameObject.Find("/scenery/fightBoundary/Grounds");
        if (groundRoot == null)
        {
            LogUtil.Error("cannot find ground");
        }
        else
        {
            var bounds = new Bounds();
            for (var i = 0; i < groundRoot.transform.childCount; i++)
            {
                var ground = groundRoot.transform.GetChild(i);
                var box = ground.GetComponent<BoxCollider>();
                if (box != null)
                {
                    var bound = box.bounds;
                    bounds.Encapsulate(bound);
                }
            }
            var g = new SceneConfig.Ground(bounds);
            this.street.AddGround(g);
        }

        if (sceneName.StartsWith("trs"))
        {
            var wallRoot = GameObject.Find("/scenery/fightBoundary/Walls");
            if (wallRoot == null)
            {
                LogUtil.Error("cannot find walls");
            }
            else
            {
                for (var i = 0; i < wallRoot.transform.childCount; i++)
                {
                    var wall = wallRoot.transform.GetChild(i);
                    var box = wall.GetComponent<BoxCollider>();
                    if (box != null)
                    {
                        var bounds = box.bounds;
                        this.street.AddWall(new SceneConfig.Wall(bounds));
                    }
                }
            }
        }

        // obstacles not used at the moment
        if (false) 
        {
            var obstaclesRoot = GameObject.Find("/scenery/fightBoundary/Obstacles");
            if (obstaclesRoot == null)
            {
                LogUtil.Error("cannot find obstacles");
            }
            else
            {
                for (var i = 0; i < obstaclesRoot.transform.childCount; i++)
                {
                    var obstacle = obstaclesRoot.transform.GetChild(i);
                    var box = obstacle.GetComponent<BoxCollider>();
                    if (box != null)
                    {
                        var bounds = box.bounds;
                        this.street.AddObstacle(new SceneConfig.Obstacle(bounds));
                    }
                }
            }
        }

        var portalRoot = GameObject.Find("levelRoot/portalRoot");
        if (portalRoot != null)
        {
            for (var i = 0; i < portalRoot.transform.childCount; i++)
            {
                var p = portalRoot.transform.GetChild(i);
                this.street.AddPortal(p);
                this.ttran.Add(p.gameObject.name, p.position, true);
            }
        }

        var transRoot = GameObject.Find("levelRoot/transRoot");
        if (transRoot != null)
        {
            for (var i = 0; i < transRoot.transform.childCount; i++)
            {
                var tran = transRoot.transform.GetChild(i);
                this.ttran.Add(tran.gameObject.name, tran.position);
            }
        }

        var facilityRoot = GameObject.Find("levelRoot/facilityRoot");
        if (facilityRoot != null)
        {
            for (var i = 0; i < facilityRoot.transform.childCount; i++)
            {
                var facility = facilityRoot.transform.GetChild(i);
                this.tfacility.Add(facility.gameObject.name, facility.position);
            }
        }

        var npcRoot = GameObject.Find("levelRoot/npcRoot");
        if (npcRoot != null)
        {
            for (var i = 0; i < npcRoot.transform.childCount; i++)
            {
                var npc = npcRoot.transform.GetChild(i);
                this.tnpc.Add(npc.gameObject.name, npc.position);
            }
        }

        var questRoot = GameObject.Find("levelRoot/questsRoot");
        if(questRoot != null)
        {
            for(var i = 0; i < questRoot.transform.childCount; i++)
            {
                var quest = questRoot.transform.GetChild(i);
                this.tquest.Add(quest.name, quest.position);
            }
        }

        var investigateRoot = GameObject.Find("levelRoot/investigateRoot");
        if(investigateRoot != null)
        {
            for(var i = 0; i < investigateRoot.transform.childCount; i++)
            {
                var investigate = investigateRoot.transform.GetChild(i);
                this.tinvestigate.Add(investigate.name, investigate.position);
            }
        }
    }

}


