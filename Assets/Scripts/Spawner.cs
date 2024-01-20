using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float timerStep;
    public float minTimerStep;
    public Quaternion[] rotations = { Quaternion.Euler(0, 90, 0), Quaternion.Euler(0, -90, 0) };
    public bool distort = true;
    public float acceleration = 0;
    private float timer;
    private LinkedList<GameObject> spawnedObjects;

    // Start is called before the first frame update
    void Start()
    {
        spawnedObjects = new LinkedList<GameObject>();
        timer = timerStep;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerStep -= acceleration * Time.deltaTime;
        timerStep = Mathf.Max(minTimerStep, timerStep);
        if (timer < 0)
        {
            timer = timerStep;
            Vector3[] positions = new Vector3[]{
                new Vector3(transform.position.x - transform.localScale.x / 2f + (distort ? Random.Range(-transform.localScale.x / 10f, transform.localScale.x / 10f) : 0), transform.position.y, transform.position.z + transform.localScale.z / 2f),
                new Vector3(transform.position.x + transform.localScale.x / 2f + (distort ? Random.Range(-transform.localScale.x / 10f, transform.localScale.x / 10f) : 0), transform.position.y, transform.position.z + transform.localScale.z / 2f),
            };
            int randomPosition = Random.Range(0, 2);
            GameObject spawnedObject = Instantiate(spawnObject, positions[randomPosition], rotations[randomPosition]);
            spawnedObjects.AddLast(spawnedObject);
        }

        while (spawnedObjects.First != null && spawnedObjects.First.Value.transform.position.z < transform.position.z - transform.localScale.z / 2.0f)
        {
            Destroy(spawnedObjects.First.Value);
            spawnedObjects.RemoveFirst();
        }
    }
}
