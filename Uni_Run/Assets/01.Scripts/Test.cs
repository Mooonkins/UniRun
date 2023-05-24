using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    void Start()
    {
        Test test = GetComponent<Test>();
        var test1 = new GameObject();
        test1.transform.SetParent(test.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
