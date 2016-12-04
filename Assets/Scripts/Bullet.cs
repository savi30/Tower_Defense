﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude<=distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectInst=(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 1f);

        if(explosionRadius>0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void Explode()
    {
        Collider[] colliders=Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        
    }

}
