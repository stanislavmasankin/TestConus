using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConusColorView : MonoBehaviour,IConusColorView
{
    public GameObject form;
    Material _material;
    private void Awake()
    {
        _material = form.GetComponent<MeshRenderer>().material;
    }
    public void SetColor(int type)
    {
        _material.color = TypeToColor.GetCollor(type);
    }


}
