using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// System.Serializable がついているとList内なら内部の変数が表示される
// （MonoBehaviourがないので単体ではGameObjectにつけられない）
[System.Serializable]
public class Serializable
{
    // field: をつけるとプロパティでもInspectorで表示されるようになる
    // 参考 https://waken.hatenablog.com/entry/2022/03/17/151205
    [field: SerializeField]
    public int Num { get; set; }
}
