using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AnimationClipの1キーフレームの情報
/// </summary>
public class AnimationKeyframe
{
    [SerializeField]
    public float testvalue;

    public float Time { get; set; }
    public Vector3Data Position { get; set; }
    public Vector3Data Rotation { get; set; }
    public Vector3Data Scale { get; set; }

    public AnimationKeyframe(){}

    public AnimationKeyframe(float time, Vector3Data position, Vector3Data rotation, Vector3Data scale)
    {
        this.Time = time;
        this.Position = position;
        this.Rotation = rotation;
        this.Scale = scale;
    }
}
