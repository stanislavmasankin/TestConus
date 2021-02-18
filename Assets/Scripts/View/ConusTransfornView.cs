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
    void Start() {
        EndVecorMove?.Invoke();
        _rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Move();
        if ((transform.position - vectorMove).sqrMagnitude <= 1) {
            EndVecorMove?.Invoke();
        }
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, vectorMove, Time.fixedDeltaTime * speed);
        //_rigidbody.AddForce(vectorMove,ForceMode.Acceleration);
    }
    public void SetVectorMove(Vector3 vectorMove) {
        this.vectorMove = vectorMove;
    }

    public void Rotate()
    {
        transform.LookAt(vectorMove);
    }

    public void SetScale(int scale)
    {
        transform.localScale = Vector3.one * (1+scale/10f);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
