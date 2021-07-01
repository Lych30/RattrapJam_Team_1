using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    #region Variables
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    [SerializeField] private float parallaxEffectMultiplier;
    #endregion

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
}
