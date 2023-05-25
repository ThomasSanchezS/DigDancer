using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BlocksPool : MonoBehaviour
{
    public string typeOfPooledBlocks;

    [SerializeField]
    private GameObject BlockToSpawn;

    private List<GameObject> pooledBlocks = new List<GameObject>();
    private int amountToPool = 5;

    void Awake()
    {
     InitializePool();
    }

    private void InitializePool()
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
        return InstantiateNewBlock();
    }

    private GameObject InstantiateNewBlock()
    {
        GameObject obj = Instantiate(BlockToSpawn);
        obj.SetActive(false);
        pooledBlocks.Add(obj);
        return obj;
    }
}
