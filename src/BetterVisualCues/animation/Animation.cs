using System;
using System.Collections.Generic;

public class Animation
{
    public required string ItemName { get; set; }
    public required Dictionary<String, AnimationObject> Objects { get; set; }
    public string? FirstPersonUseAnim { get; set; }
    public string? ThirdPersonUseAnim { get; set; }
    public float? PrimaryUseTime { get; set; }
    public float? SecondaryUseTime { get; set; }
    public string? OriginalMesh { get; set; }
    public AnimationStep? UseAnimation { get; set; }
    public AnimationStep? CancelUseAnimation { get; set; }
}
