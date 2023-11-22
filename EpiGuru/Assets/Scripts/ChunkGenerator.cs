using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Chunk[] chunksPrefabs;
    [SerializeField] private Chunk chunkStart;

    private float distanceDrawings = 10;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    void Start()
    {
        spawnedChunks.Clear();
        spawnedChunks.Add(chunkStart);
        if(spawnedChunks.Count < distanceDrawings)
        {
            for(int i = 1; i < distanceDrawings; i++)
            SpawnChunk();
        }
    }

    void Update()
    {
        if (playerPosition != null)
        {
            if (playerPosition.position.z > spawnedChunks[1].endChunk.position.z && spawnedChunks.Count <= distanceDrawings)
            {
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(chunksPrefabs[Random.Range(0, chunksPrefabs.Length)]);
        newChunk.transform.position= spawnedChunks[spawnedChunks.Count-1].endChunk.position-newChunk.beginChunk.position;
        spawnedChunks.Add(newChunk);

        if(spawnedChunks.Count > distanceDrawings)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
}
