using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowComponent : MonoBehaviour
{
    [SerializeField]
    int _size = 1;
    public int Size
    {
        get{    return _size;}
        private set
        {
            _size = value;
            SetScale(Size);
        }
    }

    void SetScale(int newScale)
    {
        float scale = (float)Mathf.Log(newScale, 3f);
        transform.localScale += new Vector3(scale, 1, scale);
    }


    public void GrowBy(int growSize)
    {
        Size += growSize;
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
