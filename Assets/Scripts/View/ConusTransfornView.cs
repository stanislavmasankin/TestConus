using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConusTransfornView : MonoBehaviour, IConusTransfornView
{
    float speed = 2;
    protected Vector3 vectorMove;

    public event Action EndVecorMove;
    Rigidbody _rigidbody;

    IConusModel conus;
    void Start() {
        EndVecorMove?.Invoke();
        _rigidbody = GetComponent<Rigidbody>();
    }
    float time = 0;
    void FixedUpdate()
    {
        time+=Time.fixedDeltaTime;
        if (time >= 1)
            time = 0;
        Move();
        if (conus.GetParent()== conus)
        {

            if (conus.GetVectorMove()==Vector3.zero)
                conus.SetVectorMove(transform.position);
            vectorMove = GenerateNewVecorMove.GenerateVecor(conus, time);
            conus.SetVectorMove(vectorMove);

            /*if ((transform.position - vectorMove).sqrMagnitude <= 1)
            {
                EndVecorMove?.Invoke();
            }
            */
        }
        else {
            vectorMove = GenerateNewVecorMove.GenerateVecorParent(conus);
            conus.SetVectorMove(vectorMove);
        }

        Rotate();

    }
    void Move()
    {
        //transform.position = Vector3.MoveTowards(transform.position, vectorMove, Time.fixedDeltaTime * speed);
        _rigidbody.position = Vector3.MoveTowards(transform.position, vectorMove, Time.fixedDeltaTime * speed);
    }
    public void SetVectorMove(Vector3 vectorMove) {
        this.vectorMove = vectorMove;
    }

    public void Rotate()
    {
        Quaternion target = Quaternion.LookRotation(transform.position- vectorMove);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.fixedDeltaTime * speed/2);
    }

    public void SetScale(int scale)
    {
        transform.localScale = Vector3.one * (1+scale/10f);
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void SetConus(IConusModel conusModel)
    {
        conus = conusModel;
    }
}
