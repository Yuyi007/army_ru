using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LitJson;
using LBootEditor;
using UnityEditor;
using UnityEngine;

public class ModifyBox : ModifyBase
{
    public ModifyBox(ModifyModel cm) : base(cm)
    {
    }

    public IEnumerator BackupBoxTimeline()
    {
        return BoxEditorHelper.BackupBoxTimeline(this.Skeleton, this.Clips);
    }

    public IEnumerator RemoveBoxTimeline()
    {
        return BoxEditorHelper.RemoveBoxTimeline(this.Skeleton, this.Clips);
    }

    public IEnumerator RemoveWrongBoxTimeline()
    {
        return BoxEditorHelper.RemoveWrongBoxTimeline(this.Skeleton, this.Clips);
    }

    public IEnumerator ApplyBoxTimeline()
    {
        return BoxEditorHelper.ApplyBoxTimeline(this.Skeleton, this.Clips);
    }
}

