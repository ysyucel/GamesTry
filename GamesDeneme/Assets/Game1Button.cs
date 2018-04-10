using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonActionGame(int buttonIndex) {
        this.gameObject.GetComponent<Game1>().buttonHandler(buttonIndex);
    }
}
