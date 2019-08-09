using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoInstance : MonoBehaviour
{
    // defaults used for all tweens/properties that are not explicitly set
    public GoEaseType defaultEaseType = GoEaseType.Linear;
    public GoLoopType defaultLoopType = GoLoopType.RestartFromBeginning;
    public GoUpdateType defaultUpdateType = GoUpdateType.Update;

    // defines what we should do in the event that a TweenProperty is added and an already existing tween has the same
    // property and target
    public GoDuplicatePropertyRuleType duplicatePropertyRule = GoDuplicatePropertyRuleType.None;
    public  GoLogLevel logLevel = GoLogLevel.None;

    // validates that the target object still exists each tick of the tween. NOTE: it is recommended
    // that you just properly remove your tweens before destroying any objects even though this might destroy them for you
    public bool validateTargetObjectsEachTick = true;

    // Used to stop instances being created while the application is quitting
    private bool _applicationIsQuitting = false;

    private  List<AbstractGoTween> _tweens = new List<AbstractGoTween>();
    // contains Tweens, TweenChains and TweenFlows
    private bool _timeScaleIndependentUpdateIsRunning;

    private GoInstance _instance = null;

    /// <summary>
    /// loops through all the Tweens and updates any that are of updateType. If any Tweens are complete
    /// (the update call will return true) they are removed.
    /// </summary>
    private void handleUpdateOfType(GoUpdateType updateType, float deltaTime)
    {
        // loop backwards so we can remove completed tweens
        for (var i = _tweens.Count - 1; i >= 0; --i)
        {
            var t = _tweens[i];

            if (t.state == GoTweenState.Destroyed)
            {
                // destroy method has been called
                removeTween(t);
            }
            else
            {
                // only process tweens with our update type that are running
                if (t.updateType == updateType && t.state == GoTweenState.Running && t.update(deltaTime * t.timeScale))
                {
                    // tween is complete if we get here. if destroyed or set to auto remove kill it
                    if (t.state == GoTweenState.Destroyed || t.autoRemoveOnComplete)
                    {
                        removeTween(t);
                        t.destroy();
                    }
                }
            }
        }
    }

    private void Awake()
    {
        _instance = this;
    }


    #region Monobehaviour

    private void Update()
    {
        if (_tweens.Count == 0)
            return;

        handleUpdateOfType(GoUpdateType.Update, Time.deltaTime);
    }


    private void LateUpdate()
    {
        if (_tweens.Count == 0)
            return;

        handleUpdateOfType(GoUpdateType.LateUpdate, Time.deltaTime);
    }


    private void FixedUpdate()
    {
        if (_tweens.Count == 0)
            return;

        handleUpdateOfType(GoUpdateType.FixedUpdate, Time.deltaTime);
    }


    private void OnApplicationQuit()
    {
        _instance = null;
        Destroy(gameObject);
        _applicationIsQuitting = true;
    }

    #endregion


    /// <summary>
    /// this only runs as needed and handles time scale independent Tweens
    /// </summary>
    private IEnumerator timeScaleIndependentUpdate()
    {
        _timeScaleIndependentUpdateIsRunning = true;
        var time = Time.realtimeSinceStartup;

        while (_tweens.Count > 0)
        {
            var elapsed = Time.realtimeSinceStartup - time;
            time = Time.realtimeSinceStartup;

            // update tweens
            handleUpdateOfType(GoUpdateType.TimeScaleIndependentUpdate, elapsed);

            yield return null;
        }

        _timeScaleIndependentUpdateIsRunning = false;
    }


    /// <summary>
    /// checks for duplicate properties. if one is found and the DuplicatePropertyRuleType is set to
    /// DontAddCurrentProperty it will return true indicating that the tween should not be added.
    /// this only checks tweens that are not part of an AbstractTweenCollection
    /// </summary>
    private bool handleDuplicatePropertiesInTween(GoTween tween)
    {
        // first fetch all the current tweens with the same target object as this one
        var allTweensWithTarget = tweensWithTarget(tween.target);

        // store a list of all the properties in the tween
        var allProperties = tween.allTweenProperties();

        // TODO: perhaps only perform the check on running Tweens?

        // loop through all the tweens with the same target
        for (int k = 0; k < allTweensWithTarget.Count; ++k)
        {
            GoTween tweenWithTarget = allTweensWithTarget[k];

            // loop through all the properties in the tween and see if there are any dupes
            for (int z = 0; z < allProperties.Count; ++z)
            {
                AbstractTweenProperty tweenProp = allProperties[z];

                // check for a matched property
                if (tweenWithTarget.containsTweenProperty(tweenProp))
                {
                    warn("found duplicate TweenProperty {0} in tween {1}", tweenProp, tween);

                    // handle the different duplicate property rules
                    if (duplicatePropertyRule == GoDuplicatePropertyRuleType.DontAddCurrentProperty)
                    {
                        return true;
                    }
                    else if (duplicatePropertyRule == GoDuplicatePropertyRuleType.RemoveRunningProperty)
                    {
                        // TODO: perhaps check if the Tween has any properties left and remove it if it doesnt?
                        tweenWithTarget.removeTweenProperty(tweenProp);
                    }

                    return false;
                }
            }
        }

        return false;
    }


    #region Logging

    /// <summary>
    /// logging should only occur in the editor so we use a conditional
    /// </summary>
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    private void log(object format, params object[] paramList)
    {
        if (format is string)
            Debug.Log(string.Format(format as string, paramList));
        else
            Debug.Log(format);
    }


    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public void warn(object format, params object[] paramList)
    {
        if (logLevel == GoLogLevel.None || logLevel == GoLogLevel.Info)
            return;

        if (format is string)
            Debug.LogWarning(string.Format(format as string, paramList));
        else
            Debug.LogWarning(format);
    }


    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public  void error(object format, params object[] paramList)
    {
        if (logLevel == GoLogLevel.None || logLevel == GoLogLevel.Info || logLevel == GoLogLevel.Warn)
            return;

        if (format is string)
            Debug.LogError(string.Format(format as string, paramList));
        else
            Debug.LogError(format);
    }

    #endregion


    #region public API

    /// <summary>
    /// helper function that creates a "to" Tween and adds it to the pool
    /// </summary>
    public GoTween to(object target, float duration, GoTweenConfig config)
    {
        config.setIsTo();
        var tween = new GoTween(target, duration, config);
        addTween(tween);

        return tween;
    }

    public GoTween to(object target, GoSpline path, float speed, GoTweenConfig config)
    {
        config.setIsTo();
        path.buildPath();
        float duration = path.pathLength / speed;
        var tween = new GoTween(target, duration, config);
        addTween(tween);

        return tween;
    }

    /// <summary>
    /// helper function that creates a "from" Tween and adds it to the pool
    /// </summary>
    public GoTween from(object target, float duration, GoTweenConfig config)
    {
        config.setIsFrom();
        var tween = new GoTween(target, duration, config);
        addTween(tween);

        return tween;
    }


    public GoTween from(object target, GoSpline path, float speed, GoTweenConfig config)
    {
        config.setIsFrom();
        path.buildPath();
        float duration = path.pathLength / speed;
        var tween = new GoTween(target, duration, config);
        addTween(tween);

        return tween;
    }

    /// <summary>
    /// adds an AbstractTween (Tween, TweenChain or TweenFlow) to the current list of running Tweens
    /// </summary>
    public void addTween(AbstractGoTween tween)
    {

        if(_instance == null) {
            _instance = this;
        }


        // early out for invalid items
        if (!tween.isValid())
            return;

        // dont add the same tween twice
        if (_tweens.Contains(tween))
            return;

        // check for dupes and handle them before adding the tween. we only need to check for Tweens
        if (duplicatePropertyRule != GoDuplicatePropertyRuleType.None && tween is GoTween)
        {
            // if handleDuplicatePropertiesInTween returns true it indicates we should not add this tween
            if (handleDuplicatePropertiesInTween(tween as GoTween))
                return;

            // if we became invalid after handling dupes dont add the tween
            if (!tween.isValid())
                return;
        }

        _tweens.Add(tween);

        // enable ourself if we are not enabled
        if (!_instance.enabled) // purposely using the static instace property just once for initialization
            _instance.enabled = true;

        // if the Tween isn't paused and it is a "from" tween jump directly to the start position
        if (tween is GoTween && ((GoTween)tween).isFrom && tween.state != GoTweenState.Paused)
            tween.update(0);

        // should we start up the time scale independent update?
        if (!_instance._timeScaleIndependentUpdateIsRunning && tween.updateType == GoUpdateType.TimeScaleIndependentUpdate)
            _instance.StartCoroutine(_instance.timeScaleIndependentUpdate());

        #if UNITY_EDITOR
//        _instance.gameObject.name = string.Format("GoKit ({0} tweens)", _tweens.Count);
        #endif
    }


    /// <summary>
    /// removes the Tween returning true if it was removed or false if it was not found
    /// </summary>
    public bool removeTween(AbstractGoTween tween)
    {
        if (_tweens.Contains(tween))
        {
            _tweens.Remove(tween);

            #if UNITY_EDITOR
//            if (_instance != null && _tweens != null)
//                _instance.gameObject.name = string.Format("GoKit ({0} tweens)", _tweens.Count);
            #endif

            if (_instance != null && _tweens.Count == 0)
            {
                // disable ourself if we have no more tweens
                _instance.enabled = false;
            }

            return true;
        }

        return false;
    }

    /// <summary>
    /// removes the Tween with specific tag
    /// </summary>
    public void removeTweenWithTag(string tag)
    {
        List<AbstractGoTween> tweenList = tweensWithTag(tag);
        if (tweenList != null)
        {
            foreach (var tween in tweenList)
            {
                removeTween(tween);
            }
        }
    }

    /// <summary>
    /// returns a list of all Tweens, TweenChains and TweenFlows with the given tag
    /// </summary>
    public List<AbstractGoTween> tweensWithTag(string tag)
    {
        List<AbstractGoTween> list = null;
        foreach (var tween in _tweens)
        {
            if (tween.tag == tag)
            {
                if (list == null)
                    list = new List<AbstractGoTween>();
                list.Add(tween);
            }
        }

        return list;
    }

    /// <summary>
    /// returns a list of all Tweens, TweenChains and TweenFlows with the given id
    /// </summary>
    public List<AbstractGoTween> tweensWithId(int id)
    {
        List<AbstractGoTween> list = null;

        for (int k = 0; k < _tweens.Count; ++k)
        {
            AbstractGoTween tween = _tweens[k];

            if (tween.id == id)
            {
                if (list == null)
                    list = new List<AbstractGoTween>();
                list.Add(tween);
            }
        }

        return list;
    }


    /// <summary>
    /// returns a list of all Tweens with the given target. TweenChains and TweenFlows can optionally
    /// be traversed and matching Tweens returned as well.
    /// </summary>
    public List<GoTween> tweensWithTarget(object target, bool traverseCollections = false)
    {
        List<GoTween> list = new List<GoTween>();

        for (int k = 0; k < _tweens.Count; ++k)
        {
            AbstractGoTween item = _tweens[k];
            // we always check Tweens so handle them first
            var tween = item as GoTween;
            if (tween != null && tween.target == target)
                list.Add(tween);

            // optionally check TweenChains and TweenFlows. if tween is null we have a collection
            if (traverseCollections && tween == null)
            {
                var tweenCollection = item as AbstractGoTweenCollection;
                if (tweenCollection != null)
                {
                    var tweensInCollection = tweenCollection.tweensWithTarget(target);
                    if (tweensInCollection.Count > 0)
                        list.AddRange(tweensInCollection);
                }
            }
        }

        return list;
    }


    /// <summary>
    /// kills all tweens with the given target by calling the destroy method on each one
    /// </summary>
    public void killAllTweensWithTarget(object target)
    {
        List<GoTween> items = tweensWithTarget(target, true);

        for (int k = 0; k < items.Count; ++k)
        {
            GoTween tween = items[k];
            tween.destroy();
        }
    }

    #endregion

}

