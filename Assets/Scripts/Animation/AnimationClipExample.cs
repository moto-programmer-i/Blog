using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClipExample : MonoBehaviour
{
    /// <summary>
    /// 置換するAnimationClipの名前
    /// </summary>
    [SerializeField]
    private string targetClipname;

    /// <summary>
    /// AnimationClipを置換するためのAnimator
    /// </summary>
    [SerializeField]
    private Animator targetAnimator;
    
    void Start()
    {
        // 適当に置換するアニメーションを用意
        AnimationCurveData curveData = new();
        curveData.Keyframes.Add(new AnimationKeyframe(0, new Vector3Data(0, 0, 0), new Vector3Data(0, 0, 0), new Vector3Data(1, 1, 1)));
        curveData.Keyframes.Add(new AnimationKeyframe(10, new Vector3Data(1, 2, 3), new Vector3Data(30, 60, 90), new Vector3Data(11, 12, 13)));

        // AnimationClipに変換
        AnimationClip newClip = AnimationClipLoader.convertToAnimationClip(curveData);

        // AnimationClipを置換する
        AnimationClipLoader.setClip(newClip, targetClipname, targetAnimator);
    }
}
