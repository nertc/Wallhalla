using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 20f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((from contact in collision.contacts select contact.otherCollider.gameObject).Contains(player))
        {
            Destroy(player);
            Debug.Log("YOU LOST!");
        }
    }
}
