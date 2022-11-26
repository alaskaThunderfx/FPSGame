﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Camera FPCamera;

    [SerializeField]
    float range = 100f;

    [SerializeField]
    float damage = 30f;

    [SerializeField]
    ParticleSystem muzzleFlash;

    [SerializeField]
    GameObject hitEffect;

    [SerializeField]
    Ammo ammoSlot;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammoSlot.CurrentAmmo > 0)
        {
            ammoSlot.CurrentAmmo -= 1;
            PlayMuzzleFlash();
            ProcessRaycast();
        }
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play(true);
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (
            Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)
        )
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
                return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
