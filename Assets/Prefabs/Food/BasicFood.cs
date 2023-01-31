using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFood : MonoBehaviour, IFood
{
    [SerializeField]
    int _growValue;
	public int GrowValue { get{ return _growValue;} private set{ _growValue = value;}}

    bool isEaten = false;


	public int EatFood()
	{   
        if (isEaten) return 0;

        isEaten = true;
        Destroy(gameObject);
        return GrowValue;
	}
}
