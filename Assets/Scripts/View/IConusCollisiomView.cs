using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConusCollisiomView 
{
    event Action<IConusModel> Collision;

    void Init(float radius, IConusModel conusModel);

    IConusModel GetTypeConus();

}
