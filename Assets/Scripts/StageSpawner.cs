using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public GameObject stage;
    public GameObject player;
    private LinkedList<GameObject> stages = new LinkedList<GameObject>();
    private float targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = -stage.transform.localScale.z / 2f;
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (player && player.transform.position.z > targetPosition)
        {
            spawn();
        }

        while (player && stages.First.Value.transform.position.z < player.transform.position.z - stage.transform.localScale.z)
        {
            Destroy(stages.First.Value);
            stages.RemoveFirst();
        }
    }

    private void spawn()
    {
        Vector3 position = new Vector3(0, 0, stages.First != null ? stages.First.Value.transform.position.z + 200 : 0);
        GameObject spawnedStage = Instantiate(stage, position, Quaternion.identity);
        stages.AddLast(spawnedStage);
        targetPosition += stage.transform.localScale.z;
    }
}
