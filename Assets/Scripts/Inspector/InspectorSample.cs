using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorSample : MonoBehaviour
{
    // 内部の変数も表示される
    [SerializeField]
    private List<Serializable> serializables = new();


    // 他への参照となり、内部の変数は表示されない
    [SerializeField]
    private List<MonoBehaivorEx> monoBehaivorEx = new();


    // エラー
    [SerializeField]
    private List<Plane> planes = new();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
