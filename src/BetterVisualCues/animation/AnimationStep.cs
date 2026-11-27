using System.Collections.Generic;

public class AnimationStep
{
    public float? Time { get; set; }
    public MaterialObj? LoadMaterial { get; set; }
    public AnimationAction_SetMesh? SetMesh { get; set; }
    public AnimationAction_SetMesh? SetSkinnedMesh { get; set;}
    public AnimationAction_SetOriginalMesh? SetOriginalSkinnedMesh { get; set;}
    public AnimationAction_SetOriginalMesh? SetOriginalMesh { get; set; }
    public AnimationAction_SetObjectActive? SetObjectActive { get; set; }
    public AnimationAction_SetObjectRotation? SetObjectRotation { get; set; }
    public AnimationAction_SetObjectPosition? SetObjectPosition { get; set; }
    public AnimationAction_SetRandomPosition? SetRandomPosition { get; set; }
    public AnimationAction_SetMaterialSlot? SetMaterialSlot { get; set; }
    public AnimationAction_ClearMaterials? ClearMaterials { get; set; }
}
