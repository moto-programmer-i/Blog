using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SerializableがないとInspectorに表示されない
// MonoBehaviourを継承するとリストにいれたとき、Inspectorに表示されない
[System.Serializable]
public class ItemSetting
{
    // .select-itemとすると対応しないので注意
    public const string GroupClassName = "select-item";

    [field: SerializeField]
    public string Name { get; set; }
    
    [field: SerializeField]
    public Texture2D Icon { get; set; }

    // [field: SerializeField]
    public GameObject Item { get; set; }
}
