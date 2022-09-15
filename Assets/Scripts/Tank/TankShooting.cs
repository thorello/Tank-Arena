using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections;

public class TankShooting : MonoBehaviour
{     
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;         
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;     
    private string m_FireButton;         
    public float launchForce;
    public float delayInSeconds = 1;        
    private bool canShoot = true;
    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>(); 
    }

    private void Update()
    {

        if(view.IsMine){

            if (Input.GetMouseButtonUp(0)){
                view.RPC("Fire", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    private void Fire()
    {        
        if (canShoot){
            canShoot = false;
            Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            shellInstance.GetComponent<Rigidbody>().velocity = launchForce * m_FireTransform.forward;
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
   {     
     yield return new WaitForSeconds(delayInSeconds);
     canShoot = true;
   }
}