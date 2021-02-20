using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConusCollisiomView : MonoBehaviour,IConusCollisiomView
{
    public event Action<IConusModel> Collision;

    float radius;
    IConusModel conusModel;

    public void  Init(float radius, IConusModel conusModel)
    {
        this.radius = radius;
        GetComponent<SphereCollider>().radius *= radius;
        this.conusModel = conusModel;
    }

    void OnMouseDown() {
        //CameraModel.cameraModel.SetConus(gameObject);
    }
    float timeLastCol;
    float deltaTimeToCol = 0.3f;
    public void FixedUpdate()
    {
        if (timeLastCol >= 0) {
            timeLastCol -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (timeLastCol <= 0) {
            timeLastCol = deltaTimeToCol;
            Collision?.Invoke(collision.gameObject.GetComponent<ConusCollisiomView>().conusModel);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (timeLastCol <= 0)
        {
            timeLastCol = deltaTimeToCol;
            Collision?.Invoke(other.gameObject.GetComponent<ConusCollisiomView>().conusModel);
        }
    }

    public IConusModel GetTypeConus()
    {
        return conusModel;
    }
}
