using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{

    public static LvlGenerator singletonWorld { get; set; }

    public Vector3 worldSize;
    public ushort colObject;
    public ushort colType;
    public ushort maxSizeObject;
    public ushort rObject;
    public float speedObject;

    [Range(1,2)]
    public int modeGame;

    List<Transform> typeParrent;

    public void StartGame()
    {
        if (worldSize == Vector3.zero)
            worldSize = new Vector3(5, 5, 5);
        if (colObject == 0)
            colObject = 10;
        if (colType == 0)
            colType = 10;
        if (speedObject <= 0)
            speedObject = 1;
        if (rObject == 0)
            rObject = 1;
        if (maxSizeObject == 0)
            maxSizeObject = 1;
        if (modeGame <= 0)
            modeGame = 1;


        typeParrent = new List<Transform>();

        singletonWorld = this;

        GenerateWorld();


    }

    void GenerateWorld() {
        for (int i = 0; i < colType; i++) {
            GameObject parrentObg = new GameObject();
            parrentObg.name = i + "type";
            typeParrent.Add(parrentObg.transform);
        }
        for (int i = 0; i < colObject; i++) {
            Vector3 posSpawn = new Vector3(Random.Range(-worldSize.x, worldSize.x), Random.Range(-worldSize.y, worldSize.y), Random.Range(-worldSize.z, worldSize.z));
            GameObject gb = Instantiate(Resources.Load("conusNew"), posSpawn, Quaternion.identity) as GameObject;

            IConusModel _conusModel = new ConusModel();

            IConusTransfornView _conusTransfornView = gb.GetComponent<ConusTransfornView>();

            IConusColorView _conusColorView = gb.GetComponent<ConusColorView>();

            IConusCollisiomView _conusCollisiomView = gb.GetComponent<ConusCollisiomView>();

            IConusCollisiomView conusCollisiomView = gb.GetComponent<ConusCollisiomView>();

            IDebugConusView debugConusView = gb.GetComponent<DbugConusView>();

            conusCollisiomView.Init(rObject, _conusModel);
            debugConusView.SetConus(_conusModel);

            ConusPresenter _conusPresenter = new ConusPresenter(_conusModel, _conusColorView, _conusTransfornView, conusCollisiomView, debugConusView);


            int type = Random.Range(0, colType);

            _conusModel.SetVectorMove(transform.position);
            _conusModel.SetTypeConus(type);
            _conusModel.SetScaleConus(Random.Range(1, maxSizeObject));
            
            gb.transform.SetParent(typeParrent[type]);
        }
        

    }

}
