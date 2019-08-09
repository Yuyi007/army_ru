using UnityEngine;
using CinemaDirector.Helpers;
using System.Collections.Generic;

namespace CinemaDirector
{
    /// <summary>
    /// Detaches all children in hierarchy from this Parent.
    /// </summary>
    [CutsceneItemAttribute("Transform", "Set Rotation", CutsceneItemGenre.ActorItem)]
	public class SetRotationEvent : CinemaActorEvent, IRevertable
    {
        public Vector3 Rotation;
		public Quaternion orgRotation;

		// Options for reverting in editor.
		[SerializeField]
		private RevertMode editorRevertMode = RevertMode.Revert;

		// Options for reverting during runtime.
		[SerializeField]
		private RevertMode runtimeRevertMode = RevertMode.Revert;
        
        public override void Trigger(GameObject actor)
        {
            if (actor != null)
            {
				orgRotation = actor.transform.localRotation;
                actor.transform.localRotation = Quaternion.Euler(Rotation);
            }
        }
        
        public override void Reverse(GameObject actor)
        {
			if (actor != null)
			{
				actor.transform.localRotation = orgRotation;
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
					reverts.Add(new RevertInfo(this, go.gameObject.transform, "localRotation", go.gameObject.transform.localRotation));
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