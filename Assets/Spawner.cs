using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnTransforms;
    public float movementPerSecond = 1f;
    public int ballChecker = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementAxis = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform randomTransform = spawnTransforms[Random.Range(0, spawnTransforms.Length)];
            GameObject instance = Instantiate(ballPrefab);

            instance.transform.position = randomTransform.position;
        }
    }
}
