using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 9, -7);
    public bool anchorX = true;
    public bool anchorY = true;
    public bool anchorZ = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player)
        {
            transform.position = new Vector3(
                anchorX ? player.transform.position.x + this.offset.x : transform.position.x,
                anchorY ? player.transform.position.y + this.offset.y : transform.position.y,
                anchorZ ? player.transform.position.z + this.offset.z : transform.position.z
            );
        }
    }
}
