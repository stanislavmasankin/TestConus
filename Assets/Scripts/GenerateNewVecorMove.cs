using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerateNewVecorMove 
{


    public static Vector3 GenerateVecor(IConusModel conus, float f) {

        Vector3 newVectorMove = conus.GetVectorMove();

        float x = LvlGenerator.singletonWorld.worldSize.x;
        float y = LvlGenerator.singletonWorld.worldSize.y;
        float z = LvlGenerator.singletonWorld.worldSize.z;

        if (newVectorMove == Vector3.zero)
        {
            newVectorMove.x = Random.Range(-x,  x);
            newVectorMove.y = Random.Range(-y,  y);
            newVectorMove.z = Random.Range(-z,  z);
        }
        
        Vector3 deltaPosition = new Vector3();
        newVectorMove.x += Mathf.Sin(f/10) * Random.Range(-x,  x);
        newVectorMove.y += Mathf.Sin(f / 10) * Random.Range(-y,  y);
        newVectorMove.z += Mathf.Sin(f / 10) * Random.Range(-z,  z);
        newVectorMove += deltaPosition.normalized*0.01f;



        
        if (newVectorMove.x >  x || newVectorMove.x < -x)
        {
            newVectorMove.x = -deltaPosition.normalized.x * 2;
        }
        if (newVectorMove.y >  y || newVectorMove.y < -y)
        {
            newVectorMove.y =  -deltaPosition.normalized.y * 2;
        }
        if (newVectorMove.z >  z || newVectorMove.z < -z)
        {
            newVectorMove.z =  -deltaPosition.normalized.z * 2;
        }
        
        return newVectorMove;
    }
    public static Vector3 GenerateVecorParent(IConusModel conus)
    {
        IConusModel parent = conus.GetParent();
        
        

        Vector3 normalVecor = (parent.GetVectorMove() - parent.GetTransform().position).normalized* (1 + conus.GetScaleConus() / 10f);



        Vector3 newVectorMove = parent.GetTransform().position - normalVecor ;

        return newVectorMove;
    }
}
