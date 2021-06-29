using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progression : MonoBehaviour
{
    private Transform End;
    private Transform player;
    private Slider slider;
    float initialDistance;
    // Start is called before the first frame update
    void Start()
    {
        End = GameObject.Find("End").transform;
        player = GameObject.Find("Player").transform;
        slider = GetComponent<Slider>();
        initialDistance = Mathf.Abs(End.position.x - player.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = 1 -(Mathf.Abs(End.position.x - player.position.x)/ initialDistance);
        //Debug.Log(1 - (Mathf.Abs(End.position.x - player.position.x))/initialDistance);
    }
}
