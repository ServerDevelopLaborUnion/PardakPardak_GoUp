using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSetting : Data
{
    public Vector2Int resolution;
    public float Volume;

    public override void Generate()
    {
        this.resolution = new Vector2Int(1920, 1080);
        this.Volume = 0.5f;
    }

    public override bool IsNull()
    {
        return this.resolution == Vector2Int.zero;
    }

    public override void Save()
    {
        
    }
}
