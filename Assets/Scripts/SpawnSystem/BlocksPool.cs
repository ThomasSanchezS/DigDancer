using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksPool : MonoBehaviour
{
    public string typeOfPooledBlocks;

    private List<GameObject> pooledBlocks = new List<GameObject>();

    private int amountToPool = 2;

    public GameObject BlockToSpawn;

    void Awake()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(BlockToSpawn);
            obj.SetActive(false);
            pooledBlocks.Add(obj);
        }

    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledBlocks.Count; i++)
        {
            if (!pooledBlocks[i].activeInHierarchy)
            {
                return pooledBlocks[i];
            }
        }
        return null;
    }
}
