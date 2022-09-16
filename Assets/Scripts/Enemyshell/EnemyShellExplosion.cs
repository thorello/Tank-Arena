using UnityEngine;

public class EnemyShellExplosion : MonoBehaviour
{
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_ExplosionAudio;
    private bool played = false;


    private void Start()
    {
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.tag == "Player")
            Destroy(target);

        if (played == false)
        {
            m_ExplosionParticles.Play();
            m_ExplosionAudio.Play();
            ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
            played = true;
        }

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

    }

}