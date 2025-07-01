using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private PlayerInventory playerInventory;
    public GameObject obj;
    public int Timer = 5;
    private GameObject instance;
    public bool inArea = true;
    public bool Front = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(inArea) {
            if(instance == null) {
                if(--Timer == 0) {
                    instance = Instantiate(obj);
                    if(Front)
                        instance.transform.position = new Vector3(transform.position.x + (transform.forward.x * 12f), transform.position.y, transform.position.z + (transform.forward.z * 12f));
                    else
                        instance.transform.position = new Vector3(transform.position.x - (transform.forward.x * 10f), transform.position.y, transform.position.z - (transform.forward.z * 10f));
                    
                    //Front = false;
                    Timer = Random.Range(60 * 3, 60 * 4 );
                }
            }
        }
    }
}
