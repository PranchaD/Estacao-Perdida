using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public List<string> Keys;
    public bool generatorOn = false;
    public bool[] ligherOn = new bool[2];

    public void Start() {
        Keys.Add("NoKey");
    }

    public bool getKey(string keyName) {
        foreach (string s in Keys) {
            if(s == keyName) {
                return true;
            }
        }
        return false;
    }

    public void addKey(string keyName) {
        Keys.Add(keyName);
    }

    public void Update() {
        if(ligherOn[0] && ligherOn[1]) {
            if (!getKey("Office")) {
                addKey("Office");
            }
        }
    }
}
