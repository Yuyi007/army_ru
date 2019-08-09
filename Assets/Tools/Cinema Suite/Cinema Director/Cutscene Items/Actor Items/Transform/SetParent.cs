using UnityEngine;
using CinemaDirector.Helpers;
using System.Collections.Generic;

namespace CinemaDirector
{
    /// <summary>
    /// Attaches actor as child of target in hierarchy
    /// </summary>
    [CutsceneItemAttribute("Transform", "Set Parent", CutsceneItemGenre.ActorItem)]
	public class SetParent : CinemaActorEvent, IRevertable
    {
		// Options for reverting in editor.
		[SerializeField]
		private RevertMode editorRevertMode = RevertMode.Revert;

		// Options for reverting during runtime.
		[SerializeField]
		private RevertMode runtimeRevertMode = RevertMode.Revert;

        public GameObject parent;
		private GameObject orgParent = null;
        public override void Trigger(GameObject actor)
        {
            if (actor != null && parent != null)
            {
				orgParent = actor.transform.parent.gameObject;
                actor.transform.SetParent(parent.transform);
            }
        }

        public override void Reverse(GameObject actor)
        {
			if (actor != null && orgParent != null) {
                actor.transform.SetParent(orgParent.transform);
			}
        }

		public RevertInfo[] CacheState()
		{
			List<Transform> actors = new List<Transform>(GetActors());
			List<RevertInfo> reverts = new List<RevertInfo>();
			foreach (Transform go in actors)
			{
				if (go != null)
				{
					reverts.Add(new RevertInfo(this, go.gameObject.transform, "SetParent", go.gameObject.transform.parent));
				}
			}

			return reverts.ToArray();
		}

		/// <summary>
		/// Option for choosing when this Event will Revert to initial state in Editor.
		/// </summary>
		public RevertMode EditorRevertMode
		{
			get { return editorRevertMode; }
			set { editorRevertMode = value; }
		}

		/// <summary>
		/// Option for choosing when this Event will Revert to initial state in Runtime.
		/// </summary>
		public RevertMode RuntimeRevertMode
		{
			get { return runtimeRevertMode; }
			set { runtimeRevertMode = value; }
		}
    }
}