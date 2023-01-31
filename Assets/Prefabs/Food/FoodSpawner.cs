using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    Transform _foodObjectsParent;
    [SerializeField]
    GameObject[] _objectsToSpawn;
    [SerializeField]
    Transform _spawnTargetSurface;

    [SerializeField]
    float _spawnInterval = 1f;
    [SerializeField]
    int _maxObjects = 100;

    float _spawnTimer;
    float _spawnedObjectsCount;

    void FixedUpdate()
    {
        SpawnObject();
    }


    void SpawnObject()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval && _spawnedObjectsCount < _maxObjects)
        {
            _spawnTimer = 0f;
  
            // Get the half bounds of the surface (on the XZ plane)
            float halfBoundX = _spawnTargetSurface.localScale.x * _spawnTargetSurface.localScale.x /2;
            float halfBoundZ = _spawnTargetSurface.localScale.z * _spawnTargetSurface.localScale.z /2;
            // Get a random position within the bounds of the surface
            float posX = Random.Range(_spawnTargetSurface.position.x - halfBoundX, _spawnTargetSurface.position.x + halfBoundX);
            float posY = _spawnTargetSurface.position.y;
            float posz = Random.Range(_spawnTargetSurface.position.z - halfBoundZ, _spawnTargetSurface.position.z + halfBoundZ);
            Vector3 randomPosition = new Vector3(posX, posY, posz);

            int randomFoodObjectIndex = Random.Range(0, _objectsToSpawn.Length);
            // Spawn random food object. Set Parent if != null
            GameObject randomItem = _objectsToSpawn[randomFoodObjectIndex];
            GameObject spawnedObject = Instantiate(randomItem, randomPosition, Quaternion.identity);
            if (_foodObjectsParent != null) spawnedObject.transform.SetParent(_foodObjectsParent);

            _spawnedObjectsCount++;
        }
    }

}        
