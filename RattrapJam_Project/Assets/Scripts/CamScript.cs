using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    #region Variables
    private float initX;
    private float initY;
    private float initZ;
    private Vector2 refvel;

    GameObject player;
    #endregion

    void Start()
    {
        player = GameObject.Find("Player");
        initX = transform.position.x - player.transform.position.x;
        initY = transform.position.y - player.transform.position.y ;
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x + initX, playerPosition.y + initY, -10);

        /*transform.position = Vector2.SmoothDamp((Vector2)transform.position, new Vector2(player.transform.position.x,transform.position.y), ref refvel, 0.25f, 10);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);*/
    }
}
