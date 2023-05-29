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

    private int dificultyLevel;

    void Start()
    {
        dificultyLevel = 0;
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
      AdvanceTheGame();
    }

    //Spawn a block
    private void Spawn()
    {
        int typeOfBlock = CheckDificultyLevel();

        GameObject block = BlockPools[typeOfBlock].GetPooledObject();
        block.transform.position = transform.position;
        block.SetActive(true);

        //move after spawn
        Move();
    }

    //Use a diferrent range depending on the actual dificulty level, with a higher range appear more kinds of blocks
    private int CheckDificultyLevel()
    {
        int typeOfBlock;

        switch (dificultyLevel)
        {
            case 0:
                typeOfBlock = Random.Range(0, 3);
                break;
            case 1:
                typeOfBlock = Random.Range(0, 4);
                break;
            case 2:
                typeOfBlock = Random.Range(0, 5);
                break;
            default:
                typeOfBlock = Random.Range(0, 6);
                break;
        }

        return typeOfBlock;
    }

    //to move after spawn
    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + distanceToMove);
    }

    public void AdvanceTheGame()
    {
        dificultyLevel++;
    }
}
