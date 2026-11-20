using System.Collections.Generic;

public class AnimationStep
{
    public Dictionary<string, AnimationAction_SetMesh>? SetMesh { get; set; }
    public Dictionary<string, string>? SetOriginalMesh { get; set; }
}
