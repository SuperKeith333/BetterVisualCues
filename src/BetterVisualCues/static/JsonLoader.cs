using System;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using BetterVisualCues;
using Newtonsoft.Json;
using UnityEngine;


public static class jsonLoader
{
    public static List<Animation> LoadAllAnimationFiles()
    {
        var animations = new List<Animation>();
        string targetFolder = Path.Combine(Paths.PluginPath, "assets/animations");

        if (!Directory.Exists(targetFolder))
        {
            Directory.CreateDirectory(targetFolder);
            Plugin.Log.LogInfo($"Created directory at: {targetFolder}");
            return animations;
        }

        string[] jsonFiles = Directory.GetFiles(targetFolder, "*.json", SearchOption.TopDirectoryOnly);


        foreach (string filePath in jsonFiles)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                
                // Option A: Using Unity's built-in JsonUtility (requires [Serializable] fields)
                Animation data = JsonConvert.DeserializeObject<Animation>(jsonContent);
                
                // Option B: Using Newtonsoft.Json (if referenced in your project)
                // ItemData data = Newtonsoft.Json.JsonConvert.DeserializeObject<ItemData>(jsonContent);
                if (data != null)
                {
                    animations.Add(data);
                    Plugin.Log.LogInfo($"Loaded: {Path.GetFileName(filePath)}");
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Failed to load {Path.GetFileName(filePath)}: {ex.Message}");
            }
        }
        
        return animations;
    }
}