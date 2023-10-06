using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class AnimationClipLoader
{

    // https://docs.unity3d.com/ja/2020.3/ScriptReference/AnimationClip.SetCurve.html
    // Transform.localPosition のようにTransformの変数一覧がキーになるらしい
    /// <summary>
    /// 相対x座標をSetCurveする場合のキー
    /// </summary>
    const string LOCAL_POSITION_X_KEY = "localPosition.x";
    /// <summary>
    /// 相対y座標をSetCurveする場合のキー
    /// </summary>
    const string LOCAL_POSITION_Y_KEY = "localPosition.y";
    /// <summary>
    /// 相対z座標をSetCurveする場合のキー
    /// </summary>
    const string LOCAL_POSITION_Z_KEY = "localPosition.z";

    /// <summary>
    /// 回転x成分をSetCurveする場合のキー
    /// </summary>
    const string ROTATION_X_KEY = "localRotation.x";
    /// <summary>
    /// 回転y成分をSetCurveする場合のキー
    /// </summary>
    const string ROTATION_Y_KEY = "localRotation.y";
    /// <summary>
    /// 回転z成分をSetCurveする場合のキー
    /// </summary>
    const string ROTATION_Z_KEY = "localRotation.z";
    /// <summary>
    /// 回転w成分をSetCurveする場合のキー
    /// </summary>
    const string ROTATION_W_KEY = "localRotation.w";

    
    /// <summary>
    /// 拡大x成分をSetCurveする場合のキー
    /// </summary>
    const string SCALE_X_KEY = "localScale.x";
    /// <summary>
    /// 拡大y成分をSetCurveする場合のキー
    /// </summary>
    const string SCALE_Y_KEY = "localScale.y";
    /// <summary>
    /// 拡大z成分をSetCurveする場合のキー
    /// </summary>
    const string SCALE_Z_KEY = "localScale.z";
    

    /// <summary>
    /// AnimationClipをAnimatorに設定
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="clipname">置換するアニメーションクリップの名前</param>
    /// <param name="anim"></param>
    public static void setClip(AnimationClip clip, string clipname, Animator animator)
    {

        clip.name = clipname;

        // AnimationClipを変更（AnimatorOverrideControllerを経由しないと動かない）
		AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        animatorOverrideController[clip.name] = clip;
    }

    /// <summary>
    /// JsonからAnimationClipに変換
    /// </summary>
    /// <param name="curve"></param>
    /// <returns></returns>
    public static AnimationClip convertToAnimationClip(AnimationCurveData curve)
    {
        if (curve == null || ListUtils.IsEmpty(curve.Keyframes)) {
            return null;
        }

        AnimationClip clip = new AnimationClip();

        // Positionの成分ごとのカーブを作成
        // 参考
        // https://im0039kp.jp/%E3%80%90unity%E3%80%91animationclip%E3%82%92%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%97%E3%83%88%E3%81%8B%E3%82%89%E7%94%9F%E6%88%90/
        AnimationCurve xPositionCurve = new AnimationCurve();
        AnimationCurve yPositionCurve = new AnimationCurve();
        AnimationCurve zPositionCurve = new AnimationCurve();

        AnimationCurve xRotationCurve = new AnimationCurve();
        AnimationCurve yRotationCurve = new AnimationCurve();
        AnimationCurve zRotationCurve = new AnimationCurve();
        AnimationCurve wRotationCurve = new AnimationCurve(); // rotationはw成分もあるので注意

        AnimationCurve xScaleCurve = new AnimationCurve();
        AnimationCurve yScaleCurve = new AnimationCurve();
        AnimationCurve zScaleCurve = new AnimationCurve();

        // 各キーフレームの情報を成分ごとにカーブに追加していく
        foreach(var keyframe in curve.Keyframes) {
            if (keyframe.Position != null) {
                xPositionCurve.AddKey(keyframe.Time, keyframe.Position.X);
                yPositionCurve.AddKey(keyframe.Time, keyframe.Position.Y);
                zPositionCurve.AddKey(keyframe.Time, keyframe.Position.Z);
            }
            
            if (keyframe.Rotation != null) {
                // rotationは一度変換が必要
                // 参考 https://monaski.hatenablog.com/entry/2015/11/15/172907
                Quaternion rotation = Quaternion.Euler(keyframe.Rotation.X, keyframe.Rotation.Y, keyframe.Rotation.Z);
                
                xRotationCurve.AddKey(keyframe.Time, rotation.x);
                yRotationCurve.AddKey(keyframe.Time, rotation.y);
                zRotationCurve.AddKey(keyframe.Time, rotation.z);
                wRotationCurve.AddKey(keyframe.Time, rotation.w);
            }

            if (keyframe.Scale != null) {
                xScaleCurve.AddKey(keyframe.Time, keyframe.Scale.X);
                yScaleCurve.AddKey(keyframe.Time, keyframe.Scale.Y);
                zScaleCurve.AddKey(keyframe.Time, keyframe.Scale.Z);
            }
        }

        // AnimationClipにカーブを設定
        clip.SetCurve("", typeof(Transform), LOCAL_POSITION_X_KEY, xPositionCurve);
        clip.SetCurve("", typeof(Transform), LOCAL_POSITION_Y_KEY, yPositionCurve);
        clip.SetCurve("", typeof(Transform), LOCAL_POSITION_Z_KEY, zPositionCurve);

        clip.SetCurve("", typeof(Transform), ROTATION_X_KEY, xRotationCurve);
        clip.SetCurve("", typeof(Transform), ROTATION_Y_KEY, yRotationCurve);
        clip.SetCurve("", typeof(Transform), ROTATION_Z_KEY, zRotationCurve);
        clip.SetCurve("", typeof(Transform), ROTATION_W_KEY, wRotationCurve);

        clip.SetCurve("", typeof(Transform), SCALE_X_KEY, xScaleCurve);
        clip.SetCurve("", typeof(Transform), SCALE_Y_KEY, yScaleCurve);
        clip.SetCurve("", typeof(Transform), SCALE_Z_KEY, zScaleCurve);

        return clip;
    }
}