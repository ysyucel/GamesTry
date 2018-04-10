using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game03BallAnimation : MonoBehaviour {
    public RectTransform[] rectBall;
    public GameObject[] ball;
    public RectTransform targetTop,targetMiddle,targetBottom;
    public GameObject gameObjectFile,filePart2,fileImage2;
    public Sprite fileSpriteTouch, fileSpriteDefault;
    int i=0;
	// Use this for initialization
	void Start () {
        ballThrow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ballThrow() {

        LeanTween.rotateAround(rectBall[i], new Vector3(0.0f, 0f, 360.0f), 360.0f, 1.0f).setLoopPingPong();
        LeanTween.move(rectBall[i], targetTop.transform.localPosition, 0.8f).setEase(LeanTweenType.easeInQuad).setOnComplete(ballDown);
        LeanTween.scale(rectBall[i], rectBall[i].transform.localScale - new Vector3(0.4f, 0.4f, 0.0f), 0.8f).setEase(LeanTweenType.easeInQuad);
    }
    public void ballDown(){
        filePart2.SetActive(true);
        fileImage2.SetActive(true);
        LeanTween.move(rectBall[i], targetMiddle.transform.localPosition, 0.4f).setEase(LeanTweenType.easeInQuad).setOnComplete(ballDown2);
       
    }
    public void ballDown2(){
        fileImage2.GetComponent<Image>().sprite = fileSpriteTouch;
        gameObjectFile.GetComponent<Image>().sprite = fileSpriteTouch;
        Invoke("fileDefault", 0.1f);
        ball[i].transform.SetAsFirstSibling();
        LeanTween.alpha(rectBall[i], 0.7f, 1f);
        LeanTween.move(rectBall[i], targetBottom.transform.localPosition, 0.9f).setEase(LeanTweenType.easeInQuad).setOnComplete(newBall);
    }
    public void fileDefault() {
        fileImage2.GetComponent<Image>().sprite = fileSpriteDefault;
        gameObjectFile.GetComponent<Image>().sprite = fileSpriteDefault;
    }
    public void newBall() {
        if (i < 2)
        {
            filePart2.SetActive(false);
            fileImage2.SetActive(false);
            i++;
            ballThrow();
        }
    }
}
