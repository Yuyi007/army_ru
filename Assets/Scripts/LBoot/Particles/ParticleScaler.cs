
using UnityEngine;
using System.Collections.Generic;
using SLua;

[CustomLuaClass]
public static class ParticleScaler
{
    [CustomLuaClass]
    public struct InitScale
    {
        public Vector3 scale;
        public float gravity;
        public float curveScalar;
        public float constantMin;
        public float constantMax;
        public float startSize;
        public float startSpeed;
        public float radius;
        public Vector3 localPosition;
        public Vector3 box;
        public ParticleSystem.MinMaxCurve[] velocity;
        public ParticleSystem.MinMaxCurve[] limitVelocity;
        public ParticleSystem.MinMaxCurve[] force;
    }

    public static void Clear()
    {
        initScaleDict.Clear();
    }

    private static ParticleScalerOptions defaultOptions = new ParticleScalerOptions();
    private static Dictionary<int, InitScale> initScaleDict = new Dictionary<int, InitScale>();

    static public void ScaleByTransform(ParticleSystem particle, float scale)
    {
        var transform = particle.transform;
        particle.scalingMode = ParticleSystemScalingMode.Local;
        var initScale = PopulateDict(particle);
        transform.localScale = initScale.scale * scale;
    }

    static public void ScaleByTransform(GameObject root, float scale, bool includeChildren = true)
    {
        var children = root.GetComponentsInChildren<ParticleSystem>();
        for (var i = children.Length; i-- > 0;)
        {
            var particle = children[i];
            ScaleByTransform(particle, scale);
        }
    }


    static public void ScaleSystem(GameObject root, float scale, bool includeChildren = true, ParticleScalerOptions options = null)
    {
        var children = root.GetComponentsInChildren<ParticleSystem>();
        for (var i = children.Length; i-- > 0;)
        {
            ScaleSystem(children[i], scale, true, options);
        }
    }


    private static InitScale PopulateDict(ParticleSystem particle)
    {
        var transform = particle.transform;
        var id = transform.GetInstanceID();
        InitScale initScale;
        if (initScaleDict.TryGetValue(id, out initScale))
        {
            return initScale;
        }
        var shape = particle.shape;
        initScale.scale = transform.localScale;
        initScale.gravity = particle.gravityModifier;
        initScale.box = shape.scale;
        initScale.radius = shape.radius;
        initScale.startSize = particle.startSize;
        initScale.startSpeed = particle.startSpeed;
        initScale.localPosition = transform.localPosition;
        initScale.velocity = new ParticleSystem.MinMaxCurve[] { particle.velocityOverLifetime.x, particle.velocityOverLifetime.y, particle.velocityOverLifetime.z };
        initScale.force = new ParticleSystem.MinMaxCurve[] { particle.forceOverLifetime.x, particle.forceOverLifetime.y, particle.forceOverLifetime.z };
        initScale.limitVelocity = new ParticleSystem.MinMaxCurve[] { particle.limitVelocityOverLifetime.limitX, particle.limitVelocityOverLifetime.limitY, particle.limitVelocityOverLifetime.limitZ };

        initScaleDict[id] = initScale;
        return initScale;
    }

    private static InitScale PopulateDict(Transform particle)
    {
        var transform = particle;
        var id = transform.GetInstanceID();
        InitScale initScale;
        if (initScaleDict.TryGetValue(id, out initScale))
        {
            return initScale;
        }
        initScale.scale = transform.localScale;
        initScale.localPosition = transform.localPosition;
        initScaleDict[id] = initScale;
        return initScale;
    }

    private static void ScaleSystem(ParticleSystem particles, float scale, bool scalePosition, ParticleScalerOptions options = null)
    {
        if (options == null)
        {
            options = defaultOptions;
        }


        var id = particles.GetInstanceID();
        var initScale = PopulateDict(particles);

        particles.startSize = initScale.startSize * Mathf.Abs(scale);
        particles.gravityModifier = initScale.gravity * Mathf.Abs(scale);
        particles.startSpeed = initScale.startSpeed * Mathf.Abs(scale);

      
        var shape = particles.shape;
        shape.radius = initScale.radius * Mathf.Abs(scale);
        shape.scale = initScale.box * Mathf.Abs(scale);
        if (!particles.velocityOverLifetime.enabled && !particles.forceOverLifetime.enabled && !particles.limitVelocityOverLifetime.enabled)
        {
            ScaleByTransform(particles, scale);
            particles.transform.localPosition = initScale.localPosition * scale;
        }


        if (options.velocity)
        {
            var vel = particles.velocityOverLifetime;
            var x = initScale.velocity[0];
            var y = initScale.velocity[1];
            var z = initScale.velocity[2];

            vel.x = ScaleMinMaxCurve2(x, scale);
            vel.y = ScaleMinMaxCurve2(y, scale);
            vel.z = ScaleMinMaxCurve2(z, scale);
        }

        if (options.clampVelocity)
        {
            var clampVel = particles.limitVelocityOverLifetime;
            var x = initScale.limitVelocity[0];
            var y = initScale.limitVelocity[1];
            var z = initScale.limitVelocity[2];
            clampVel.limitX = ScaleMinMaxCurve2(x, scale);
            clampVel.limitY = ScaleMinMaxCurve2(y, scale);
            clampVel.limitZ = ScaleMinMaxCurve2(z, scale);
        }

        if (options.force)
        {
            var force = particles.forceOverLifetime;
            var x = initScale.force[0];
            var y = initScale.force[1];
            var z = initScale.force[2];
            force.x = ScaleMinMaxCurve2(x, scale);
            force.y = ScaleMinMaxCurve2(y, scale);
            force.z = ScaleMinMaxCurve2(z, scale);
        }
    }

    private static ParticleSystem.MinMaxCurve ScaleMinMaxCurve2(ParticleSystem.MinMaxCurve curve, float scale)
    {
        var nex = default(ParticleSystem.MinMaxCurve);
        nex.curveMultiplier = curve.curveMultiplier * scale;
        nex.constantMin = curve.constantMin * scale;
        nex.constantMax = curve.constantMax * scale;
        return nex;
    }

    private static ParticleSystem.MinMaxCurve ScaleMinMaxCurve(ParticleSystem.MinMaxCurve curve, float scale)
    {
        curve.curveMultiplier *= scale;
        curve.constantMin *= scale;
        curve.constantMax *= scale;
        ScaleCurve(curve.curveMin, scale);
        ScaleCurve(curve.curveMax, scale);
        return curve;
    }

    private static void ScaleCurve(AnimationCurve curve, float scale)
    {
        if (curve == null)
        {
            return;
        }
        for (int i = 0; i < curve.keys.Length; i++)
        {
            curve.keys[i].value *= scale;
        }
    }
}

public class ParticleScalerOptions
{
    public bool shape = true;
    public bool velocity = true;
    public bool clampVelocity = true;
    public bool force = true;
}