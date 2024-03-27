using Microsoft.MixedReality.WorldLocking.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLockingManager : SpacePin
{
    // Start is called before the first frame update
    public void SaveSpacePinLocation()
    {
        if (WorldLockingManager.GetInstance().ApplyAdjustment)
        {
            SetFrozenPose(ExtractModelPose());
        }
        else
        {
            SetSpongyPose(ExtractModelPose());
        }
    }
}
