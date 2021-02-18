using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConusTransfornView 
{
    event Action EndVecorMove;
    void SetVectorMove(Vector3 vectorMove);
    void Rotate();

    void SetScale(int scale);

    Vector3 GetPosition();
}
