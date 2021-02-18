using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConusCollisiomView : MonoBehaviour,IConusCollisiomView
{
    public event Action<GameObject> Collision;
    float radius;
    IConusModel conusModel;

    public void  Init(float radius, IConusModel conusModel)
    {
        this.radius = radius;
        GetComponent<SphereCollider>().radius *= radius;
        this.conusModel = conusModel;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Collision?.Invoke(other.gameObject);
    }

    public IConusModel GetTypeConus()
    {
        return conusModel;
    }
}
