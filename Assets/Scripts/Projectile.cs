using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int maxBouncesCount = 5;
    [SerializeField] private Rigidbody rb;
    public bool shotByPlayer2;

    public UnityEvent OnDestroyEvent;

    private int bouncesCount = 0;

    private void Start() {
        Destroy(gameObject, lifeTime);
    }

    public void SubToOnDestroy(Action action){
        OnDestroyEvent.AddListener(() => action());
    }

    private void OnDestroy() {
        OnDestroyEvent.Invoke();
    }

    private void OnCollisionEnter(Collision other) {
        var normal = other.contacts[0].normal;
        //Vector3.Reflect(rb.velocity.normalized, normal);
        var reflectVector = Vector3.Reflect(rb.velocity.normalized, normal);
        //reflectVector =rb.transform.InverseTransformDirection(reflectVector);
        rb.AddForce( normal * 50, ForceMode.Impulse);

        var health = other.gameObject.GetComponentInParent<PlayerHealth>();
        if(health){
            if(shotByPlayer2 && health.IsPlayer2) return;
            if(!shotByPlayer2 && !health.IsPlayer2) return;
            health.Explode();
            Destroy(gameObject);
        }

        bouncesCount++;
        if(bouncesCount >= maxBouncesCount){
           // Destroy(gameObject);
        }
    }
}
