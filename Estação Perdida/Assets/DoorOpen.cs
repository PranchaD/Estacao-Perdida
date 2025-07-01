using UnityEngine;
using UnityEngine.InputSystem;

public class DoorOpen : MonoBehaviour
{
    public string keyRequired = "Generator";
    public bool isOpen = false;
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
        if(!isOpen) {
            if(playerInventory.getKey(keyRequired)) {
                float distance = Vector3.Distance(playerCam.transform.position, transform.position);
                print(distance);
                if (Mathf.Abs(distance) <= 4f)
                {
                    Animator door = GetComponent<Animator>();
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.Play();
                    door.Play("Open");
                    isOpen = true;
                }
            }
            else {
                if(keyRequired == "Office") {
                    UIText.createText("I need to find the door code");
                }
                else {
                    UIText.createText("I don't have " + keyRequired + " key");
                }
            }
        }
    }
}
