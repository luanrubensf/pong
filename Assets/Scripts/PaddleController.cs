using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float velocity = 8f;
    private Vector3 position;
    private float yLimit = 3.5f;

    public bool isPlayer1 = false;
    public bool automatic = false;

    public Transform ballTransform;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = position;

        if (!automatic)
        {
            handleManualPaddle();
        } else
        {
            handleAutomaticPaddle();
        }

        handleLimits();
    }

    void handleManualPaddle()
    {
        if (isPlayer1)
        {
            handleKeysPlayer1();
        }
        else
        {
            handleKeysPlayer2();
        }

        if (!isPlayer1)
        {
            handleChangeToAutomaticMode();
        }
    }

    void handleChangeToAutomaticMode()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            automatic = true;
        }
    }

    void handleAutomaticPaddle()
    {
        position.y = Mathf.Lerp(position.y, ballTransform.position.y, (2f * Time.deltaTime));
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            automatic = false;
        }
    }

    void handleLimits()
    {
        if (position.y < -yLimit)
        {
            position.y = -yLimit;
        }

        if (position.y > yLimit)
        {
            position.y = yLimit;
        }
    }

    void handleKeysPlayer1()
    {
        if (Input.GetKey(KeyCode.W))
        {
            handleUp();
        }

        if (Input.GetKey(KeyCode.S)) {
            handleDown();
        }
    }

    void handleKeysPlayer2()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            handleUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            handleDown();
        }
    }

    void handleUp()
    {
        position.y = position.y + velocity * Time.deltaTime;
    }

    void handleDown()
    {
        position.y = position.y - velocity * Time.deltaTime;
    }
}
