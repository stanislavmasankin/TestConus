using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConusPresenter
{
    IConusModel  _conusModel;
    IConusColorView _conusColorView;
    IConusTransfornView _conusTransfornView;
    IConusCollisiomView _conusCollisiomView;
    IDebugConusView _debugConusView;


    public ConusPresenter(IConusModel conusModel, IConusColorView conusColorView, 
        IConusTransfornView conusTransfornView, IConusCollisiomView conusCollisiomView,
        IDebugConusView debugConusView)
    {
        _conusModel = conusModel;
        _conusColorView = conusColorView;
        _conusTransfornView = conusTransfornView;
        _conusCollisiomView = conusCollisiomView;
        _debugConusView = debugConusView;


        _conusModel.ChangedVectorMove += SetVectorMove;
        _conusModel.ChangedType += SetType;
        _conusModel.ChangedScale += SetScale;
        _conusModel.DestroedModel += DestroyAll;


        _conusTransfornView.EndVecorMove += GenerateNewVectorMove;

        _conusCollisiomView.Collision += Collision;

        _conusModel.SetTransform(_conusTransfornView.GetTransform());
        _conusTransfornView.SetConus(_conusModel);

    }
    void DestroyAll() {
        _conusTransfornView.DestroyGameObject();
    }

    void Collision(IConusModel conusModel) {


        if (_conusModel.GetTypeConus() != conusModel.GetTypeConus()) {
            if (_conusModel.GetScaleConus() < conusModel.GetScaleConus()) {

                int modeGame = LvlGenerator.singletonWorld.modeGame;
                if (modeGame == 1)
                {
                    if (conusModel.GetParent() == conusModel && _conusModel.GetParent() == _conusModel)
                    {
                        CollisionConus.ChangeParent(conusModel, _conusModel);
                        GenerateNewVectorMove();
                        _debugConusView.UpdateParent();
                    }
                }
                if (modeGame  == 2)
                {
                    CollisionConus.DestroyMode(conusModel, _conusModel);
                }


            }
        }

    }

    void SetType(int type) {
        _conusColorView.SetColor(type);        
    }
    void SetScale(int scale)
    {
        _conusTransfornView.SetScale(scale);
    }
    void SetVectorMove(Vector3 vectorMove) {

            _conusTransfornView.SetVectorMove(vectorMove);
            //_conusTransfornView.Rotate();

    }

    void GenerateNewVectorMove()
    {
        /*
        if(_conusModel.GetParent() == _conusModel)
            _conusModel.SetVectorMove(GenerateNewVecorMove.PlavniiVecotr(_conusModel));
        else
            _conusModel.SetVectorMove(GenerateNewVecorMove.GenerateVecorParent(_conusModel));
            */
    }
}
