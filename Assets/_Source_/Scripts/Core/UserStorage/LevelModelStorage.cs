using System;
using UnityEngine.Scripting;

[Serializable]
public class LevelModelStorage
{
    [field: Preserve] public LevelModel[] Levels;
}