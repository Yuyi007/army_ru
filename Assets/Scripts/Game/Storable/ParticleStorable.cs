using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{

    [SLua.CustomLuaClass]
    /// <summary>
    /// stores relevant information about particles
    /// </summary>
    public class ParticleStorable : MonoBehaviour
    {
        public float duration;
        public GameObject characterEmitterRoot;
    }
}
