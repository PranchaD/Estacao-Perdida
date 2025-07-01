using UnityEngine;

public class GeneratorSwitch : MonoBehaviour
{
    public bool isOpen = false;
    public Material mat;
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
            float distance = Vector3.Distance(playerCam.transform.position, transform.position);
            if (Mathf.Abs(distance) <= 4f)
            {
                UIText.createText("Turned power on");
                Light light = GetComponent<Light>();
                MeshRenderer mesh = GetComponent<MeshRenderer>();
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                mesh.material = mat;
                light.color = Color.green;
                playerInventory.generatorOn = true;
                isOpen = true;
            }
        }
    }
}
