using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    Color cor;
    void Start(){
        cor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {

        gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.black, cor, Mathf.PingPong(Time.time, 1f));
    }
}
