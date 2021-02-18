using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConusModel 
{
    
    event Action<int> ChangedType;
    event Action<int> ChangedScale;
    event Action<Vector3> ChangedVectorMove;

    void AddConus(IConusModel counus);
    List<IConusModel> GetList();

    GameObject GetParent();
    void SetParent(GameObject parent);

    int GetCountList();

    void SetType(int type);
    void SetScale(int scale);
    void SetIsMainObjectConus(bool isMainObject);
    int GetTypeConus();
    int GetScaleConus();
    bool isMainObjectConus();

    void SetVectorMove(Vector3 vectorMove);
    Vector3 GetVectorMove();

    void AddConusS();
    int GetConusS();
    void MinusConusS();

}

