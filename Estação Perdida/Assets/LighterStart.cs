using UnityEngine;

public class LighterStart : MonoBehaviour
{
    public bool isOpen = false;
    public Light lighter;
    public int lightID = 0;
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
        if(playerInventory.generatorOn) {
            if(!isOpen) {
                float distance = Vector3.Distance(playerCam.transform.position, transform.position);
                print(distance);
                if (Mathf.Abs(distance) <= 4f)
                {
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.Play();
                    playerInventory.ligherOn[lightID] = true;
                    lighter.color = Color.purple;
                    isOpen = true;
                }
            }
        }
        else {
            UIText.createText("There's no power");
        }
    }
}
