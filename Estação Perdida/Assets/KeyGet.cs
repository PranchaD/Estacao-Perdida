using UnityEngine;

public class KeyGet : MonoBehaviour
{
    public string keyName = "Generator";
    private PlayerInventory playerInventory;
    private Camera playerCam;
    private TextManager UIText;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject Text = GameObject.Find("Text (TMP)");
        UIText = Text.GetComponent<TextManager>();
        playerCam = player.GetComponentInChildren<Camera>();
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    void OnMouseDown()
    {
        if(this.enabled) {
            float distance = Vector3.Distance(playerCam.transform.position, transform.position);
            print(distance);
            if (Mathf.Abs(distance) <= 4f)
            {
                GetComponent<AudioSource>().Play();
                UIText.createText("Collected " + keyName + " Key");
                playerInventory.addKey(keyName);
                Destroy(gameObject.GetComponentInChildren<MeshRenderer>());
                this.enabled = false;
            }
        }
    }
}
