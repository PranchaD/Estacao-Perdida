using UnityEngine;

public class LighterCheck : MonoBehaviour
{
    public Light lighter;

    // Update is called once per frame
    void Update()
    {
        if(lighter.color == Color.purple)
            GetComponent<MeshRenderer>().enabled = true;
    }
}
