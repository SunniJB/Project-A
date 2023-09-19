using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 3.4f;
    public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    public KeyCode leftKey, rightKey;
    [SerializeField] private Settings settings;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
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

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        if (Input.GetKey(leftKey) || Input.GetKey(rightKey))
        {
            moveDirection = Input.GetKey(leftKey) ? -1 : 1;
        }
        else
        {
            if (r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
        }

        // Change facing direction
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


        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
        }
    }

}
