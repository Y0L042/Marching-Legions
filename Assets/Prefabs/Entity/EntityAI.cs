using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAI : MonoBehaviour, IEntityIntelligence
{
    Vector3 _movementDirection;


    [SerializeField][Tooltip("Adds the functionality to move the entity.")]
    EntityMovementComponent _movementComponent;
    EntityVisionComponent _visionComponent;

    void FixedUpdate()
    {
        if (_movementComponent != null) _movementComponent.MoveBody(_movementDirection);
    }

    Vector3 RandomWander()
    {

        return Vector3.zero;
    }


    // void Raycast()
    // {
    //     Ray ray = new Ray(transform.position, transform.forward);
    //     RaycastHit hit;
    //     if (Physics.Raycast(ray, out hit, raycastLength))
    //     {
    //         Vector3 avoidDirection = (transform.position - hit.point).normalized;
    //         transform.position += avoidDirection * avoidForce * Time.fixedDeltaTime;
    //     }
    // }
    
}
