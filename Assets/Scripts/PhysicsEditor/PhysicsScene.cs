using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PhysicsScene : MonoBehaviour {

    List<GameObject> physicsEntities;

    public List<GameObject> PhysicsEntities
    {
        get
        {
            return physicsEntities;
        }

        set
        {
            physicsEntities = value;
        }
    }

	private void Awake()
	{
        PhysicsEntities = new List<GameObject>();
    }

    private void Start()
    {

    }
}
