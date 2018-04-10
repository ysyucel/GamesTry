using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game01WindowAnimation : MonoBehaviour {
    public RectTransform rectWindow;
    public GameObject gameObjectWindow, gameObjectCharacterSprite;
    public Sprite[] windowSpriteOpen;
    public Sprite[] windowSpriteClose;
	// Use this for initialization
	void Start () {
        openWindow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openWindow() {

        LeanTween.play(rectWindow, windowSpriteOpen).setFrameRate(12f).setRepeat(1).setOnComplete(closeWindow).setDelay(2f);
    }
    public void closeWindow() {
        Debug.Log("asd");
        LeanTween.play(rectWindow, windowSpriteClose).setFrameRate(12f).setRepeat(1).setOnComplete(openWindow).setDelay(2f);
    }
}
