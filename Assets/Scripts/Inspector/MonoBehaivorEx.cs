using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour がついているとリスト内では内部の変数が表示されない
// （値は他のGameObjectにアタッチされているはずであり、リスト内は参照だけ）
public class MonoBehaivorEx : MonoBehaviour
{
    [field: SerializeField]
    public int Num { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
