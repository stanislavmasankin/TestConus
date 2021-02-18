using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConusPresenter
{
    IConusModel  _conusModel;
    IConusColorView _conusColorView;
    IConusTransfornView _conusTransfornView;
    IConusCollisiomView _conusCollisiomView;


    public ConusPresenter(IConusModel conusModel, IConusColorView conusColorView, 
        IConusTransfornView conusTransfornView, IConusCollisiomView conusCollisiomView)
    {
        _conusModel = conusModel;
        _conusColorView = conusColorView;
        _conusTransfornView = conusTransfornView;
        _conusCollisiomView = conusCollisiomView;


        _conusModel.ChangedVectorMove += SetVectorMove;
        _conusModel.ChangedType += SetType;
        _conusModel.ChangedScale += SetScale;

        _conusTransfornView.EndVecorMove += GenerateNewVectorMove;

        _conusCollisiomView.Collision += Collision;


    }

    void Collision(GameObject gameObject) {
        IConusModel conusModel = gameObject.GetComponent<ConusCollisiomView>().GetTypeConus();

        if (_conusModel.GetTypeConus() != conusModel.GetTypeConus()) {
            if (_conusModel.GetScaleConus() < conusModel.GetScaleConus()) {
                if (conusModel.isMainObjectConus()) {
                    if (_conusModel.isMainObjectConus()&& _conusModel.GetCountList()>0)
                    {
                        //что за бесолпзеные неправильные куски кода
                        //Стас, иди поспи
                        /*

                        for (int i = 0;i< _conusModel.GetCountList();i++) {
                            _conusModel.GetList()[i].SetIsMainObjectConus(false);
                            _conusModel.GetList()[i].SetParent(gameObject);
                            _conusModel.GetList()[i].SetType(conusModel.GetTypeConus());
                            //_conusModel.GetList()[i].SetVectorMove(gameObject.transform.position);
                            //conusModel.AddConus(_conusModel);
                            
                        }
                        */
                        
                    }


                    _conusModel.SetIsMainObjectConus(false);
                    _conusModel.SetParent(gameObject);
                    _conusModel.SetType(conusModel.GetTypeConus());
                    _conusModel.SetVectorMove(gameObject.transform.position);
                    conusModel.AddConus(_conusModel);

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
            _conusTransfornView.Rotate();

    }

    void GenerateNewVectorMove()
    {
        if (_conusModel.isMainObjectConus())
        {
            _conusModel.SetVectorMove(GenerateNewVecorMove.GenerateVecor(_conusModel.GetVectorMove()));
        }
        else
        {

            _conusModel.SetVectorMove(GenerateNewVecorMove.GenerateVecor(_conusModel.GetParent().transform.position, _conusModel.GetVectorMove(),_conusModel.GetConusS()));
        }
    }
}
