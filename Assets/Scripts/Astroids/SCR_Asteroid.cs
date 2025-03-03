using NUnit.Framework;
using UnityEngine;


public class SCR_Asteroid : SCR_PooledObject
{
    [SerializeField] private int _maxHealth;
    private int _health;
    private float _spinSpeed;
    private float _moveSpeed;
    [Header("Set Up Variables")]
    [SerializeField] private float _minMoveSpeed;
    [SerializeField] private float _highMoveSpeed;
    [SerializeField] private float _minScale, _highScale;
    [SerializeField] private float _minSpinSpeed, _highSpinSpeed;
    protected Vector3 _moveVector;
    private Rigidbody2D _rb2d;


    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        Respawn(transform.position, Quaternion.identity);
    }


    // void Update()
    // {
    //     UpdateAstroid();
    // }


    public override void UpdatePooledObject()
    {
        SpinObject();
        MoveObject();
    }


    private void SpinObject() => transform.Rotate(_spinSpeed * Time.deltaTime * Vector3.forward);


    private void MoveObject()
    {
        if (_rb2d == null) return;

        _rb2d.linearVelocity = _moveVector * _moveSpeed;
    }


    public void TakeDamage(int someDamage)
    {
        _health -= someDamage;

        if(_health <= 0) Despawn();
    }


    protected virtual Vector3 GetMoveDirection() // TODO - Add random offset to the player pos and a random pos that can happen
    {
        Vector3 dir = SCR_GameManager.Instance.playerTransform.position - transform.position;

        return dir.normalized;
    }


    public override void Respawn(Vector3 spawnPos, Quaternion spawnRotation)
    {
        Debug.Log("Secound test");
        _health = _maxHealth;

        _moveSpeed = Random.Range(_minMoveSpeed, _highMoveSpeed);
        transform.localScale = new(Random.Range(_minScale, _highScale), Random.Range(_minScale, _highScale), 1);

        int spinDirection;
        if (Random.Range(0, 1) == 1) spinDirection = 1;
        else spinDirection = -1;

        _spinSpeed = Random.Range(_minSpinSpeed, _highSpinSpeed) * spinDirection;

        base.Respawn(spawnPos, spawnRotation);
    }
}