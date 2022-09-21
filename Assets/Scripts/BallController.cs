using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocity = 5f;

    private Vector2[] velocities = new Vector2[4];

    private float xLimit = 12f;

    public AudioClip boingClip;

    public Transform cameraTransform;

    public float startDelay = 2f;

    private bool started = false;

    void Start()
    {
        buildVelocityOptions();
    }


    void Update()
    {

        startDelay = startDelay - Time.deltaTime;


        if (startDelay <= 0 && !started)
        {
            int direction = Random.Range(0, 4);
            var randomVelocity = velocities[direction];

            rb.velocity = randomVelocity;
            
            started = true;
        }

        handleGameOver();
    }

    void handleGameOver()
    {
        if (transform.position.x > xLimit || transform.position.x < -xLimit)
        {
            SceneManager.LoadScene("Game");
        }
    }

    void buildVelocityOptions()
    {
        velocities[0] = new Vector2(-velocity, velocity);
        velocities[1] = new Vector2(-velocity, -velocity);
        velocities[2] = new Vector2(velocity, velocity);
        velocities[3] = new Vector2(velocity, -velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boingClip, cameraTransform.position);
    }
}
