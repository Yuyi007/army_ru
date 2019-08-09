using UnityEngine;
using System.Collections;

namespace CinemaDirector
{
    [CutsceneItemAttribute("Animator", "Set Face Emotion", CutsceneItemGenre.ActorItem, CutsceneItemGenre.MecanimItem)]
    public class SetFaceEmotionEvent : CinemaActorEvent
    {
        public enum FaceEmotion {
            Normal = 0,
            Laugh,
            Closed,
            Angry,
        };
        public FaceEmotion faceEmotion = FaceEmotion.Normal;

        private Vector2[] offsets = new [] {
            new Vector2(0, 0),								// normal
            new Vector2(0, -0.5f),							// laugh
            new Vector2(0.5f, 0),							// shut
            new Vector2(0.5f, -0.5f),						// angry
        };
        
        public override void Trigger(GameObject actor)
        {
            var mat = RefreshMaterial(actor);
            mat.mainTextureOffset = offsets [(int)faceEmotion];
        }

        private Material RefreshMaterial(GameObject actor)
        {
            var root = actor.transform.Find("skin");
            var part = root.Find("face");
            SkinnedMeshRenderer orgSMR = part.GetComponent<SkinnedMeshRenderer>();
			Material res = orgSMR.sharedMaterial;


            SkinnedMeshRenderer combineSMR = actor.GetComponent<SkinnedMeshRenderer>();
            if (combineSMR != null)
            {
				foreach(Material mat in combineSMR.sharedMaterials)
                {
                    string n1 = mat.name;
                    string n2 = res.name;
                    int s1 = n1.IndexOf("(Instance)");
                    int s2 = n2.IndexOf("(Instance)");
                    if (s1 > 0)
                        n1 = n1.Substring(0, s1 - 2);
                    if (s2 > 0)
                        n2 = n2.Substring(0, s2 - 2);
                    if (n1 == n2)
                    {
                        res = mat;
                        break;
                    }
                }
            }
            return res;
        }

    }
}