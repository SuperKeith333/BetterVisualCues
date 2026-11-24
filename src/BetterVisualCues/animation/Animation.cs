using System;
using System.Collections.Generic;

public class Animation
{
    public required string ItemName { get; set; }
    public required Dictionary<string, string> Objects { get; set; }
    public required string ThirdPersonUseAnim { get; set; }
    public float? PrimaryUseTime { get; set; }
    public float? SecondaryUseTime { get; set; }
    public string? OriginalMesh { get; set; }
    public string? CodeOverride { get; set; }
    public List<AnimationStep>? LoadMaterials { get; set; }
    public List<AnimationStep>? Created { get; set; }
    public List<AnimationStep>? UseAnimation { get; set; }
    public List<AnimationStep>? CancelUseAnimation { get; set; }
    public List<AnimationStep>? SecondaryUseAnimation { get; set; }
    public List<AnimationStep>? CancelSecondaryUseAnimation { get; set; }
}
