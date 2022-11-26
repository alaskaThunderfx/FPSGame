using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    float amountToZoom = 10f;

    float originalZoom;

    void Start()
    {
        originalZoom = mainCamera.fieldOfView;
    }

    void Update()
    {
        Zoom();
    }

    public void Zoom()
    {
        if (Input.GetMouseButton(1))
        {
            mainCamera.fieldOfView = amountToZoom;
        }
        else
        {
            mainCamera.fieldOfView = originalZoom;
        }
    }
}
