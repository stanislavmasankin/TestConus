using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionConus 
{
    public static void ChangeParent(IConusModel mainConus, IConusModel conus) {

        int type = mainConus.GetTypeConus();

        IConusModel next = conus.GetLastChild();

        int i = 0;
        while (next.GetTypeConus() != type)
        {
            next.SetTypeConus(type);
            next = next.GetParent();
            i++;
            if (i > 10)
                break;
        }

        conus.SetParent(mainConus.GetLastChild());

        mainConus.SetLastChild(conus.GetLastChild());

    }



    public static void DestroyMode(IConusModel mainConus,IConusModel conus)
    {
        mainConus.SetScaleConus(mainConus.GetScaleConus() + 1 + (int)(conus.GetScaleConus() / 2));
        conus.DestroyModel();

    }
}
