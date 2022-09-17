using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroMoveEspinhosController : MonoBehaviour
{
    public float velocidadeRotacao = 90;

    void Update()
    {

       transform.Rotate (0,0, velocidadeRotacao * Time.deltaTime);
        
    }

}
