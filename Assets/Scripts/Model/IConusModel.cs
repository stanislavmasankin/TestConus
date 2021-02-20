using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConusModel 
{
    
    event Action<int> ChangedType;
    event Action<int> ChangedScale;
    event Action<Vector3> ChangedVectorMove;
    event Action DestroedModel;


    void DestroyModel();

    void SetParent(IConusModel parent);
    IConusModel GetParent();
    void SetLastChild(IConusModel lastChild);
    IConusModel GetLastChild();

    IConusModel GetMainConus();
    Transform GetTransform();
    void SetTransform(Transform transform);

    void SetTypeConus(int type);
    int GetTypeConus();

    int GetScaleConus();
    void SetScaleConus(int scale);

    void SetVectorMove(Vector3 vectorMove);
    Vector3 GetVectorMove();



}

