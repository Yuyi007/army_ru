using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// The ActorTrackGroup maintains an Actor and a set of tracks that affect 
    /// that actor over the course of the Cutscene.
    /// </summary>
    [TrackGroupAttribute("Actor Track Group", TimelineTrackGenre.ActorTrack)]
    public class ActorTrackGroup : TrackGroup
    {
        [SerializeField]
        private Transform actor;


        private CutsceneCast _cc = null;

        public CutsceneCast cc
        {
            get
            {
                if (_cc == null)
                {
                    _cc = this.transform.GetComponentInParent<CutsceneCast>();
                }
                return _cc;
            }
        }

        /// <summary>
        /// The Actor that this TrackGroup is focused on.
        /// </summary>
        public Transform Actor
        {
            get { return actor; }
            set
            { 
                // auto retarget the setParent when actor is dynamically replaced
                if (actor != null && value != null && Application.isPlaying && actor != value)
                {
                    var oldActor = actor;
                    var allSps = cc.GetComponentsInChildren<SetParent>();
                    var length = allSps.Length;
                    for (var i = 0; i < length; i++)
                    {
                        var sp = allSps[i];
                        if (sp.parent == null)
                            continue;

                        if (sp.parent == oldActor.gameObject)
                        {
                            sp.parent = value.gameObject;
                        }
                        else if (sp.parent.transform.IsChildOf(oldActor))
                        {
                            var pname = sp.parent.name;
                            var t = value.FindByName(pname);
                            if (t != null)
                            {
                                sp.parent = t.gameObject;
                            }
                        }
                    }
                }
                actor = value;
            }
        }
    }
}