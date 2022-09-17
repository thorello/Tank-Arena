using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShellExplosion : MonoBehaviour
{
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_ExplosionAudio;
    private bool played = false;
    private float xPos;
    private float zPos;


    private void Start()
    {
        Destroy(gameObject, 2);
        xPos = Random.Range(27, 39);
        zPos = Random.Range(20, 41);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;
        if (target.tag == "Player")
        {
            target.transform.position = new Vector3(xPos, 0, zPos);
        }

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