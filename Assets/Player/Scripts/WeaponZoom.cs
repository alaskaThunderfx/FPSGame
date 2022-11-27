using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    RigidbodyFirstPersonController mainController;

    [SerializeField]
    float amountToZoom = 10f;

    [SerializeField]
    float zoomInSensitivity = .5f;

    float originalZoom;
    float originalXSensitivity;
    float originalYSensitivity;

    void Start()
    {
        SetZoomOutValues();
    }

    void SetZoomOutValues()
    {
        originalZoom = mainCamera.fieldOfView;
        originalXSensitivity = mainController.mouseLook.XSensitivity;
        originalYSensitivity = mainController.mouseLook.YSensitivity;
    }

    void Update()
    {
        Zoom();
    }

    void Zoom()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        mainCamera.fieldOfView = amountToZoom;
        mainController.mouseLook.XSensitivity = zoomInSensitivity;
        mainController.mouseLook.YSensitivity = zoomInSensitivity;
    }

    void ZoomOut()
    {
        mainCamera.fieldOfView = originalZoom;
        mainController.mouseLook.XSensitivity = originalXSensitivity;
        mainController.mouseLook.YSensitivity = originalYSensitivity;
    }

    void OnDisable()
    {
        ZoomOut();
    }
}
