using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections;

public class EnemyTankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public AudioSource m_ShootingAudio;
    public AudioClip m_FireClip;
    private string m_FireButton;
    public float launchForce;
    private float cooldown = 0.5f;
    private float cooldownTimer;


    private void Update()
    {
        Fire();
    }


    private void Fire()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.GetComponent<Rigidbody>().velocity = launchForce * m_FireTransform.forward;
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

    }


}