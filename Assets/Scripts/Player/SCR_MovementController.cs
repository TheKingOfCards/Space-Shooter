using System.IO.Compression;
using UnityEngine;

public class SCR_MovementController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _cappedVelocity;
    [SerializeField] private float _dampingAmount;
    private Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
    }


    public void FixedUpdateMovement()
    {
        Movement();
        RotateToMouse();
    }


    void Movement()
    {
        Vector2 movement = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();

        if (movement.magnitude <= 0) SlowDownPlayer();
        else _rb2d.linearDamping = 0;

        _rb2d.AddForce(movement * _speed, ForceMode2D.Impulse);

        CappingSpeed();
    }


    void CappingSpeed()
    {
        if (_rb2d.linearVelocityX > _cappedVelocity || _rb2d.linearVelocityX < -_cappedVelocity)
        {
            if (_rb2d.linearVelocityX > 0) _rb2d.linearVelocityX = _cappedVelocity;
            else _rb2d.linearVelocityX = -_cappedVelocity;
        }

        if (_rb2d.linearVelocityY > _cappedVelocity || _rb2d.linearVelocityY < -_cappedVelocity)
        {
            if (_rb2d.linearVelocityY > 0) _rb2d.linearVelocityY = _cappedVelocity;
            else _rb2d.linearVelocityY = -_cappedVelocity;
        }
    }


    void SlowDownPlayer()
    {
        _rb2d.linearDamping += _dampingAmount * Time.deltaTime;
    }


    void RotateToMouse()
    {
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        lookPos -= transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }


    public void StopPlayerMovement() => _rb2d.linearVelocity = new(0, 0);
}
