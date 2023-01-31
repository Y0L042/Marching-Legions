using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAI : MonoBehaviour, IEntityIntelligence
{
	public Vector3 MoveDirectionOutput 
    { 
        get;
        set; 
    }

    [SerializeField][Tooltip("Adds the functionality to move the entity.")]
    EntityMovementComponent _movementComponent;


    
}
