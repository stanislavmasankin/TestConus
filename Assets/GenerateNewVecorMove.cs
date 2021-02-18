using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerateNewVecorMove 
{

    public static Vector3 GenerateVecor(Vector3 newVectorMove) {


        if (newVectorMove == Vector3.zero)
        {
            newVectorMove.x = Random.RandomRange(-LvlGenerator.singletonWorldSize.x, LvlGenerator.singletonWorldSize.x);
            newVectorMove.y = Random.RandomRange(-LvlGenerator.singletonWorldSize.y, LvlGenerator.singletonWorldSize.y);
            newVectorMove.z = Random.RandomRange(-LvlGenerator.singletonWorldSize.z, LvlGenerator.singletonWorldSize.z);
        }
        Vector3 deltaPosition = new Vector3();
        deltaPosition.x = Random.RandomRange(-LvlGenerator.singletonWorldSize.x / 10, LvlGenerator.singletonWorldSize.x/10);
        deltaPosition.y = Random.RandomRange(-LvlGenerator.singletonWorldSize.y / 10, LvlGenerator.singletonWorldSize.y / 10);
        deltaPosition.z = Random.RandomRange(-LvlGenerator.singletonWorldSize.z / 10, LvlGenerator.singletonWorldSize.z / 10);
        newVectorMove += deltaPosition;
        //newVectorMove = Quaternion.AngleAxis(Random.Range(0, 45) - 90, Vector3.forward) * newVectorMove;
        //newVectorMove = Quaternion.AngleAxis(Random.Range(0, 90) - 180, Vector3.left) * newVectorMove;
        //newVectorMove *= Random.Range(1,1+ LvlGenerator.singletonWorldSize.magnitude / 10f);


        if (newVectorMove.x > LvlGenerator.singletonWorldSize.x || newVectorMove.x < -LvlGenerator.singletonWorldSize.x)
        {
            newVectorMove.x = -deltaPosition.x * 2;
        }
        if (newVectorMove.y > LvlGenerator.singletonWorldSize.y || newVectorMove.y < -LvlGenerator.singletonWorldSize.y)
        {
            newVectorMove.y = -deltaPosition.y * 2;
        }
        if (newVectorMove.z > LvlGenerator.singletonWorldSize.z || newVectorMove.z < -LvlGenerator.singletonWorldSize.z)
        {
            newVectorMove.z = -deltaPosition.z * 2;
        }
        
        return newVectorMove;
    }
    public static Vector3 GenerateVecor(Vector3 parentPosition, Vector3 parentVectorMove,int Col)
    {


        Vector3 newVectorMove = parentPosition - (parentVectorMove - parentPosition).normalized *3*(1+Col); 

        return newVectorMove;
    }
}
