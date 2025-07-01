using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public int Timer = 240;
    public string Text = "Get inside office and collect evidences";

    public void createText(string _text) {
        Text = _text;
        Timer = 240;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(--Timer <= 0) {
            Text = "";
            Timer = 0;
        }

        TMP_Text _mesh = GetComponent<TMP_Text>();
        _mesh.text = Text;
    }
}
