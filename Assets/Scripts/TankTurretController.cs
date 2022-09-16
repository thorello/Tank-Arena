using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TankTurretController : MonoBehaviour
{

        private PhotonView view;
        private float angleDegrees;
        private float angleRadians;
        private Vector2 Delta;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();        
    }

    void Update(){
            if (!view.IsMine){
                return;
            }



            Vector2 mouseVector;
            Vector3 mousePos = Input.mousePosition;
            mousePos.x -= Screen.width/2;
            mousePos.y -= Screen.height/2 - Screen.height/2 - Screen.height/2;        
            //Debug.Log("x:" + mousePos.x + "/ y:" + mousePos.y);
            mouseVector = new Vector2(mousePos.x , mousePos.y);
            //Debug.Log(mouseVector.normalized);
            Delta = mouseVector.normalized - Vector2.zero;
            //use atan2 to get the angle; Atan2 returns radians
            angleRadians = Mathf.Atan2(Delta.y, Delta.x);
            //convert to degrees
            angleDegrees = angleRadians * Mathf.Rad2Deg;
    
            //angleDegrees will be in the range (-180,180].
            //I like normalizing to [0,360) myself, but this is optional..
            //  if (angleDegrees < 0){
            //      angleDegrees += 360;
            //  }

            //Debug.Log(angleDegrees);
             if (view.IsMine){
                transform.eulerAngles = new Vector3(0,-1*(angleDegrees -90 - transform.parent.eulerAngles.y),0);
            }
            


    }

    // Update is called once per frame
  




}
