using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowComponent : MonoBehaviour
{
    [SerializeField][Tooltip("Debug View - Scales linearly")]
    int _power = 1;
    public int Power
    {
        get{    return _power;}
        private set
        {
            _power = value;
            SetScale(Power);
        }
    }
    [SerializeField][Tooltip("Debug View - Scales logarithmic")]
    float _scale = 1f;
    [SerializeField][Tooltip("Controls the coefficient for the scaling logarithm.")]
    float _scaleCoef = 7.5f;
    [SerializeField][Tooltip("Controls the base for the scaling logarithm.")]
    float _scaleCurve = 10f;


    void SetScale(int newScale)
    {
        
        _scale = _scaleCoef * (float)Mathf.Log(newScale, 10f);
        transform.localScale = new Vector3(_scale, transform.localScale.y,_scale);
    }


    public void GrowBy(int growSize)
    {
        Power += growSize;
    }

    private void OnCollisionEnter(Collision other) 
    {
        CollisionEatFood(other.gameObject);
    }


    void CollisionEatFood(GameObject otherGameObject)
    {
        var food = otherGameObject.GetComponent<IFood>();
        if (food == null) return;

        GrowBy(food.EatFood());
    }
}
