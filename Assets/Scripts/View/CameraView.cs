using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LvlGenerator.singletonWorld!=null)
            transform.position = new Vector3(0, 0, -(LvlGenerator.singletonWorld.worldSize.x + LvlGenerator.singletonWorld.worldSize.y)*1.2f);
    }
}
