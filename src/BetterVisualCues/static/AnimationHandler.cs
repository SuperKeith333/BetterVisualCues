using System.Collections.Generic;

public static class AnimationHandler
{
    static readonly List<Animation> animations = [];
    static readonly List<string> supportedItemNames;

    public static void Init()
    {
        var anims = jsonLoader.LoadAllAnimationFiles();

        foreach (Animation animation in anims)
        {
            animations.Add(animation);
            supportedItemNames.Add(animation.ItemName);
        }
    }

    public static bool IsItemSupported(string name)
    {
        foreach (Animation anim in animations)
        {
            if (anim.ItemName.Contains(name))
                return true;
        }

        return false;
    }

    public static void PlayUsingAnimation(string ItemName, Item item)
    {
        
    }



    public static void Unload()
    {
        animations.Clear();
        supportedItemNames.Clear();
    }
}