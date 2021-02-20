using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbugConusView : MonoBehaviour,IDebugConusView
{
    IConusModel conusModel;
    IConusModel parentModel;

    void Update()
    {
        if (parentModel == null )
            Debug.DrawLine(gameObject.transform.position, conusModel.GetVectorMove(), Color.red);
        else {
            Debug.DrawLine(gameObject.transform.position, parentModel.GetTransform().position, Color.blue);
            Debug.DrawLine(gameObject.transform.position, conusModel.GetVectorMove(), Color.green);
        }
           
    }

    public void SetConus(IConusModel conusModel) {
        this.conusModel = conusModel;
    }

    public void UpdateParent()
    {
        this.parentModel = conusModel.GetParent();
    }
}
