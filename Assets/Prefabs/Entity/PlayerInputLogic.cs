using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInputLogic : MonoBehaviour, IEntityIntelligence
{
    [SerializeField]
    private Vector3 _input = new Vector3(0f, 0f, 0f);
  

    [SerializeField][Tooltip("The angle the camera is rotated around the Y-axis in degrees. 0deg for top down, 45deg for isometric")]
    float _perspectiveAngleOffset;

	public Vector3 MoveDirectionOutput 
    { 
        get
        { 
            Vector3 inputVector = RotateVector(_input, _perspectiveAngleOffset);
            return inputVector;
        }
        set{ _input = value;}
    }

    Rigidbody _rigidBody;
    [SerializeField][Tooltip("Adds the functionality to move the entity.")]
    EntityMovementComponent _movementComponent;




    void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        if (_movementComponent != null) _movementComponent.MoveBody(MoveDirectionOutput);
    }

    Vector3 RotateVector(Vector3 vector, float angle)
    {
        // Rotates vector by angle
        Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * vector;
        return rotatedVector;
    }


    public void OnMove(InputValue value) => _input = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
}
