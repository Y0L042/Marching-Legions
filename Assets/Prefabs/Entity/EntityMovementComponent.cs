using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovementComponent : MonoBehaviour
{
    
    [SerializeField] 
    float _acceleration = 15f;
    [SerializeField] 
    float _maxSpeed = 20f;
    private Vector3 _velocity;
    public Vector3 Velocity
    {
        get { return _velocity; }
        set 
        { 
            _velocity = Vector3.ClampMagnitude(value, _maxSpeed); 
            // _velocity.x = Mathf.Clamp(_velocity.x, -_maxSpeed, _maxSpeed);
            // _velocity.z = Mathf.Clamp(_velocity.z, -_maxSpeed, _maxSpeed);
        }
    }

	private Vector3 _smoothInputVelocity;



    [SerializeField]
    IEntityIntelligence _entityIntelligence;
    Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null) Debug.Log("Rigidbody is empty: " + gameObject);
    }



    public void MoveBody(Vector3 input)
    {
        if (_rb == null) return;

        Vector3 targetVelocity = (_maxSpeed * input) - Velocity;
        Velocity = Vector3.SmoothDamp(Velocity, targetVelocity, ref _smoothInputVelocity, 1/_acceleration);
        Vector3 newPosition =  transform.position + Velocity * Time.deltaTime;
        _rb.MovePosition(newPosition);  
    }
}
