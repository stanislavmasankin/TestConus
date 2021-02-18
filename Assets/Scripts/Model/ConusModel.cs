using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConusModel : IConusModel
{
    bool isMainObject = true;

    int scale;

    int type;

    GameObject parent;

    Vector3 vectorMove;

    List<IConusModel> list;

    //бесполезно
    int posInList = 0;

    int conuss;


    public event Action<int> ChangedType;
    public event Action<Vector3> ChangedVectorMove;
    public event Action<int> ChangedScale;

    public void AddConus(IConusModel counus) {
        if (list != null)
        {
            list.Add(counus);
        }
        else {
            list = new List<IConusModel>();
            list.Add(counus);
        }
        AddConusS();
    }
    public List<IConusModel> GetList() {
        if (list != null)
        {
            List<IConusModel> newList = list;
            list.Clear();
            return newList;
        }
        return null;
    }
    public int GetCountList()
    {
        if (list == null) {
            return 0;
        }
        return list.Count;
    }
    public void SetType(int type) {

        this.type = type;
        ChangedType?.Invoke(type);
        
    }

    public void SetScale(int scale)
    {
        this.scale = scale;
        ChangedScale?.Invoke(scale);
    }

    public void SetIsMainObjectConus(bool isMainObject) {
        this.isMainObject = isMainObject;
    }

    public void SetVectorMove(Vector3 vectorMove)
    {
        this.vectorMove = vectorMove;
        ChangedVectorMove?.Invoke(vectorMove);
    }

    public Vector3 GetVectorMove()
    {
        return vectorMove;
    }

    public int GetTypeConus() {
        return type;
    }
    public int GetScaleConus()
    {
        return scale;
    }
    public bool isMainObjectConus()
    {
        return isMainObject;
    }

    public GameObject GetParent()
    {
        if(isMainObject|| parent==null)
            return null;
        return parent;
    }



    public void SetParent(GameObject parent)
    {
        this.parent = parent;
        isMainObject = false;
    }

    //я устал пишу не думая
    public void AddConusS()
    {
        conuss++;
    }

    public int GetConusS()
    {
        return conuss;
    }

    public void MinusConusS()
    {
        conuss--;
    }
    public void MinusConusS(int d)
    {
        conuss = conuss - d;
    }
}
