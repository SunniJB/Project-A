using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 3.4f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    Vector3 cameraPos;
    Rigidbody2D playerRigidbody;
    CapsuleCollider2D mainCollider;
    Transform t;

    public KeyCode leftKey, rightKey;
    [SerializeField] private Settings settings;

    void Start()
    {
        t = transform;
        playerRigidbody = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        playerRigidbody.freezeRotation = true;
        playerRigidbody.gravityScale = gravityScale;
        playerRigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        facingRight = t.localScale.x > 0;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }

        if (GameObject.Find("Settings").TryGetComponent<Settings>(out settings))
        {
            if (settings.controlScheme == 0)
            {
                leftKey = KeyCode.A;
                rightKey = KeyCode.D;
            }
            if (settings.controlScheme == 1)
            {
                leftKey = KeyCode.LeftArrow; 
                rightKey = KeyCode.RightArrow;
            }
        }
    }

    void Update()
    {
        // Movement controls
        if (Input.GetKey(leftKey) || Input.GetKey(rightKey))
        {
            moveDirection = Input.GetKey(leftKey) ? -1 : 1;
        }
        else
        {
            if (playerRigidbody.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
        }

        //Just flip the character around when you walk
        if (moveDirection != 0) 
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Apply movement velocity
        playerRigidbody.velocity = new Vector2((moveDirection) * maxSpeed, playerRigidbody.velocity.y);

        //Make the camera follow the player
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
        }

        if (Input.GetKeyUp(leftKey) || Input.GetKeyUp(rightKey))
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

}
