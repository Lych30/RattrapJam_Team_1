using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjects : MonoBehaviour
{
    #region Variables
    public bool isDestructible;
    public float timeToDestroy = 1.5f;
    #endregion

    private void Start()
    {
        timeToDestroy = 1.5f;
    }
}
