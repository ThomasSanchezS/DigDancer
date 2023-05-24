using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BlocksSpawner : MonoBehaviour
{
    [SerializeField]
    private int distanceToMove = 1, numberOfBlocksSpawnPerWave =20; 

    [SerializeField]
    private List<BlocksPool> BlockPools = new List<BlocksPool>();

    private bool theGameIsStarting;

    void Start()
    {
        theGameIsStarting = true;
        SpawnBlocksInWave();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnBlocksInWave();
        }
    }

    private void SpawnBlocksInWave()
    {
        for (int i = 0; i < numberOfBlocksSpawnPerWave; i++)
        {
            Spawn();
        }
    }

    //Spawn a block
    private void Spawn()
    {
        int typeOfBlock;

        if (theGameIsStarting) 
        {
            typeOfBlock = Random.Range(0, 3);
        }

        else 
        {
            typeOfBlock = Random.Range(0, 7);
        }

        GameObject block = null;

        block = BlockPools[typeOfBlock].GetPooledObject();
        block.transform.position = transform.position;
        block.SetActive(true);

        //move after spawn
        Move();
    }

    //to move after spawn
    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + distanceToMove);
    }

    public void AdvanceTheGame()
    {
        theGameIsStarting = false;
    }
}
