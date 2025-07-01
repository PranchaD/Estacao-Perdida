using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public EnemySpawn playerScript;
    public bool monsterDeath = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            if(!monsterDeath) {
                playerScript.inArea = true;
            }
            else {
                GameObject enemy = GameObject.FindWithTag("Enemy");
                if(enemy != null)
                    Destroy(enemy);
            }
        }

        if(monsterDeath) {
            if(other.tag == "Enemy") {
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.name == "Player") {
            if(!monsterDeath) {
                playerScript.inArea = true;
            }
            else {
                GameObject enemy = GameObject.FindWithTag("Enemy");
                if(enemy != null)
                    Destroy(enemy);
            }
        }

        if(monsterDeath) {
            if(other.tag == "Enemy") {
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.name == "Player") {
            playerScript.inArea = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
