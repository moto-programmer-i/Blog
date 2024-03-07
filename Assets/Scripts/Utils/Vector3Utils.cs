using System;
using UnityEngine;

public static class Vector3Utils {
    /// <summary>
    /// 一般の角度計算（なぜかVector3.Angleが度数法で角度を返すため用意）
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns>角度（ラジアン）</returns>
    // なぜかVector3.Angleが度数法で角度を返すので、内部を拝借
    // 公式にラジアンで返すメソッドができたら修正
    // https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Math/Vector3.cs#L324
    public static float Angle(Vector3 from, Vector3 to)
        {
            // sqrt(a) * sqrt(b) = sqrt(a * b) -- valid for real numbers
            float denominator = (float)Math.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
            if (denominator < Vector3.kEpsilonNormalSqrt)
                return 0F;

            float dot = Mathf.Clamp(Vector3.Dot(from, to) / denominator, -1F, 1F);

            // 元のソースでなぜか度数法にしているので、ラジアンで返す
            // return ((float)Math.Acos(dot)) * Mathf.Rad2Deg;
            return MathF.Acos(dot);
        }
}