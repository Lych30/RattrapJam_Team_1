using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    #region Variables
    private float initX;
    private float initY;
    private float initZ;

    [SerializeField] GameObject player;
    #endregion

    void Start()
    {
        initX = transform.position.x;
        initY = transform.position.y;
        initZ = transform.position.z;
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x + initX, playerPosition.y + initY, playerPosition.z + initZ);
    }
}
