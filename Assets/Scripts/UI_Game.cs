using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_Game : MonoBehaviour
{
     LvlGenerator lvlGenerator;

    public InputField x;
    public InputField y;
    public InputField z;

    public InputField colObj;
    public InputField copType;

    public InputField size;
    public InputField radius;
    public InputField speed;

    public Toggle mode;
    public Toggle rand;

    public GameObject lvl;
    public void Start()
    {
        lvlGenerator = lvl.GetComponent<LvlGenerator>();
    }

    public void StartGame() {

        if (rand.isOn)
        {
            lvlGenerator.worldSize.x = Random.Range(0, 50);
            lvlGenerator.worldSize.y = Random.Range(0, 50);
            lvlGenerator.worldSize.z = Random.Range(0, 50);

            lvlGenerator.colObject = (ushort)(Random.Range(10, 1000)+ lvlGenerator.worldSize.x+ lvlGenerator.worldSize.y+ lvlGenerator.worldSize.z);
            lvlGenerator.colType = (ushort)Random.Range(2, 100);

            lvlGenerator.maxSizeObject = (ushort)Random.Range(2, 30);
            lvlGenerator.rObject = (ushort)Random.Range(1, 5);
            lvlGenerator.speedObject = (ushort)Random.Range(2, 10);

            lvlGenerator.modeGame = Random.Range(0, 1);
        }
        else {
            lvlGenerator.worldSize.x = Convert.ToInt32(x.text);
            lvlGenerator.worldSize.y = Convert.ToInt32(y.text);
            lvlGenerator.worldSize.z = Convert.ToInt32(z.text);

            lvlGenerator.colObject = (ushort)Convert.ToInt32(colObj.text);
            lvlGenerator.colType = (ushort)Convert.ToInt32(copType.text);

            lvlGenerator.maxSizeObject = (ushort)Convert.ToInt32(size.text);
            lvlGenerator.rObject = (ushort)Convert.ToInt32(radius.text);
            lvlGenerator.speedObject = (ushort)Convert.ToInt32(speed.text);

            if (mode.isOn)
                lvlGenerator.modeGame = 2;
            else
                lvlGenerator.modeGame = 1;

        }
        gameObject.SetActive(false);

        lvlGenerator.StartGame();

    }
}
