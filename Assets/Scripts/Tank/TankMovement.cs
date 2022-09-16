using UnityEngine;
using Photon.Pun;

public class TankMovement : MonoBehaviour
{
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public AudioSource m_MovementAudio;
    public AudioClip m_EngineIdling;
    public AudioClip m_EngineDriving;

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private PhotonView view;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        view = GetComponent<PhotonView>();
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";
    }

    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.

        if (Mathf.Abs(m_MovementInputValue) < 0.1f)
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.Play();
            }
        }
        else
        {
            if (Mathf.Abs(m_MovementInputValue) > 0.1f)
            {
                if (m_MovementAudio.clip == m_EngineIdling)
                {
                    m_MovementAudio.clip = m_EngineDriving;
                    m_MovementAudio.Play();
                }
            }
        }
    }


    void FixedUpdate()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        if (view.IsMine)
        {
            m_MovementInputValue = Input.GetAxis(m_MovementAxisName);

            if (m_MovementInputValue >= 0)
            {
                m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
            }
            else
            {
                m_TurnInputValue = Input.GetAxis(m_TurnAxisName) * -1;
            }

            EngineAudio();
        }

        if (!view.IsMine)
        {
            Camera camera = transform.parent.GetChild(1).GetComponent<Camera>();
            camera.enabled = false;
        }

        Move();
        Turn();

    }


    void Move()
    {
        // Adjust the position of the tank based on the player's input.
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

}
