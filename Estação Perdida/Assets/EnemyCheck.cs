using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
            Follow script = other.GetComponent<Follow>();
            script.jump = true;
        }
    }
}
