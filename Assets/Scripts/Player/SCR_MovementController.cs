using UnityEngine;

public class SCR_MovementController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float cappedVelocity;
    [SerializeField] float dampingAmount;
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
    }


    public void FixedUpdatePlayerController()
    {
        Movement();
        RotateToMouse();
    }


    void Movement()
    {
        Vector2 movement = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();

        if (movement.magnitude <= 0) SlowDownPlayer();
        else rb2d.linearDamping = 0;

        rb2d.AddForce(movement * speed, ForceMode2D.Impulse);

        CappingSpeed();
    }


    void CappingSpeed()
    {
        if (rb2d.linearVelocityX > cappedVelocity || rb2d.linearVelocityX < -cappedVelocity)
        {
            if (rb2d.linearVelocityX > 0) rb2d.linearVelocityX = cappedVelocity;
            else rb2d.linearVelocityX = -cappedVelocity;
        }

        if (rb2d.linearVelocityY > cappedVelocity || rb2d.linearVelocityY < -cappedVelocity)
        {
            if (rb2d.linearVelocityY > 0) rb2d.linearVelocityY = cappedVelocity;
            else rb2d.linearVelocityY = -cappedVelocity;
        }
    }


    void SlowDownPlayer()
    {
        rb2d.linearDamping += dampingAmount * Time.deltaTime;
    }


    void RotateToMouse()
    {
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        lookPos -= transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
