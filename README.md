# BetterVisualCues

BetterVisualCues is a visual enhancement mod for PEAK animations for tem usage through model switching.
I AM NOT AN ANIMATOR, this is the best I could do without adding new fully fleshed out animations

**Networked Animations require all clients to have the same/similar assets folder**

### Supported Items

The following items currently have visual support:

- Airline Food
- Anti-Zooka
- All Berrynana variants
- Mushrooms
- Cooked Bird
- Clusterberries
- Cure All
- Eggs (Yolk)
- Frog Legs
- Granola Bar
- Lollipop
- Prickleberries
- Shroomberries
- Aloevera
- Antidote
- BalloonBunch
- All Crispberries
- Energy Drink
- Half Coconut
- Honeycomb
- Both hotdog variants
- All Kingberries
- Marshmallow
- Medicinal Root
- Medkit
- Napberry
- Pandora's lunchbox
- Rope Cannons
- Scorchberry
- Sports drink
- Trail Mix
- Winterberries

<details>
<summary>Custom Animations</summary>

All Animations are stored in assets/animations as json files and can be edited while the game is running

The default key for reloading is End, this can be changed in [ModConfig](https://thunderstore.io/c/peak/p/PEAKModding/ModConfig/)

**The following are required for any animations to work**
- ItemName
- Objects (Can be Empty)
- ThirdPersonUseAnim (Usually 'A_Scout_Use_Item')
- Every Action Parameter when calling an action like 'SetMesh' (With the exception of 'SetOriginalMesh' with an optional Tag)

Lollipop.json is a good starting point for most animations, use that as the base

**Valid Animation Actions**
| Action Name | Parameters | 
| --- | --- |
| ClearMaterials | Object(string) |
| SetMaterialSlot | Object(string), Slot(int), Material(string) |
| SetRandomPosition | Object(string), MaxOffset(float) |
| SetObjectPosition | Object(string), X(float), Y(float), Z(float) |
| SetObjectRotation | Object(string), X(float), Y(float), Z(float) |
| SetObjectActive | Object(string), Enabled(bool) |
| SetOriginalMesh, SetOriginalSkinnedMesh | Object(string), Tag(string, optional) |
| SetMesh, SetSkinnedMesh | Object(string),  Mesh(string) |
| LoadMaterial | Item(string, name of item in Peak's files),  Material(string, exact name of material) |

To load new meshes you must create an assetbundle in unity and package every model without their materials (Mesh->Materials->Material Creation Mode->None). Then a mod with BetterVisualCues as a dependency can call 

```csharp
MeshRegistry.LoadMeshes("assets/");
```

with the name of the assetbundle after the / on startup

To create an animation without the traditional actions you must create an AnimationOverride class on startup

```csharp
public class AntiZookaCodeOverride : BaseCodeOverride
{

}
```

To access specific actions you can override
- Created(string ItemName, Item item)
- BeingUsed(string ItemName, Item item, float progress)
- UsedFinished(string ItemName, Item item)
- SecondaryUsedFinished(string ItemName, Item item)
- UseCanceled(string ItemName, Item item)
- ItemDataUpdated(string ItemName, ItemInstanceData instanceData, Item item)

To register the override call

```csharp
AnimationHandler.registerCodeOverride("Anti-Zooka", new AntiZookaCodeOverride());
```

Replacing the 1st parameter wit the name and the second with the OverrideClass. To use it add

```json
"CodeOverride": "Anti-Zooka"
```

Replacing the name to match your override
</details>

## Feedback & Bug Reports

Found a bug or have an idea for a new visual effect?

Feel free to open an issue on the GitHub repository or dm me at @superkeithvr!