using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConusModel : IConusModel
{
    int scale;

    int type;

    Vector3 vectorMove;

    Transform transform;

    IConusModel parrent;
    IConusModel lastChild;

    public event Action<int> ChangedType;
    public event Action<Vector3> ChangedVectorMove;
    public event Action<int> ChangedScale;
    public event Action DestroedModel;

    public void SetTypeConus(int type) {

        this.type = type;
        ChangedType?.Invoke(type);
        
    }

    public void SetScaleConus(int scale)
    {
        if (scale < 50)
        {
            this.scale = scale;
            ChangedScale?.Invoke(scale);
        }
        else if (this.scale<50) {
            this.scale = 50;
            ChangedScale?.Invoke(50);
        }
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

    public void DestroyModel()
    {
        DestroedModel?.Invoke();
    }

    public void SetParent(IConusModel parent)
    {
        this.parrent = parent;
    }

    public IConusModel GetParent()
    {
        if (parrent == null|| parrent == this)
            return this;
        return parrent;
    }

    public void SetLastChild(IConusModel lastChild)
    {
        this.lastChild = lastChild;
    }

    public IConusModel GetLastChild()
    {
        if (lastChild == null|| lastChild == this)
            return this;
        return lastChild;
    }


    public IConusModel GetMainConus()
    {
        if (parrent == null|| parrent== this)
            return this;
        else
            return parrent.GetMainConus();


    }


    public Transform GetTransform()
    {
        return transform;
    }
    public void SetTransform(Transform transform)
    {
        this.transform = transform;
    }


}
