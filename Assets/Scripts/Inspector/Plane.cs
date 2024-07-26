using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 何もつけないクラスだと、ListにいれてもInspectorに表示されず、エラーになる
// NullReferenceException: SerializedObject of SerializedProperty has been Disposed.
// Unity内ですごい勢いエラーが増えるのでマネしないこと
public class Plane
{
    [field: SerializeField]
    public int Num { get; set; }
}
