using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game06Istaka : MonoBehaviour {
    /*public Transform target;
    public Transform istaka;
    float z;
    Vector3 imgRot;
    Vector3 camLook;*/
	// Use this for initialization
    public RectTransform rectRaket, rectLeft, rectRight;
    public RectTransform targetTop;
    public RectTransform[] rectBall;
    float axis;
    public int i = 0;
	void Start () {
        racketShoot();
	}
	
	// Update is called once per frame
	void Update () {
        /*camLook = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        imgRot.x = 0f;
        imgRot.y = 0f;
        imgRot.z = -35f + (camLook.x*70f);

        istaka.position = new Vector3(((camLook.x*Screen.width)), istaka.position.y, istaka.position.z);
        istaka.rotation = Quaternion.Euler(imgRot);*/
	}

    public void racketShoot()
    {
        LeanTween.move(rectRaket, rectBall[i].transform.localPosition-new Vector3(0f,300f,0f), 0.4f).setDelay(0.3f).setOnComplete(() =>
        {
            LeanTween.move(rectRaket, rectBall[i].transform.localPosition, 0.2f).setOnComplete(() =>
            {
                
                LeanTween.move(rectBall[i], targetTop.transform.localPosition, 0.5f).setOnComplete(() =>
                {
                    LeanTween.alpha(rectBall[i], 0.0f, 0.01f);
                    LeanTween.scale(rectBall[i], rectBall[i].transform.localScale + new Vector3(0.2f, 0.2f, 0.0f), 0.1f).setEase(LeanTweenType.easeInQuad).setDelay(1f).setOnComplete(newBall);
                });
                LeanTween.scale(rectBall[i], rectBall[i].transform.localScale - new Vector3(0.2f, 0.2f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
             });
        });
        if (rectBall[i].position.x < 0)
        {
            axis = -(rectBall[i].position.x / rectLeft.position.x) * 35f;

        }
        else
        {
            axis = (rectBall[i].position.x / rectRight.position.x) * 35f;
        }
        
        Debug.Log(axis);
        LeanTween.rotate(rectRaket, new Vector3(0.0f, 0f, axis), 1.0f);
        //LeanTween.rotateAround(rectRaket, new Vector3(0.0f, 0f, rectRaket.rotation.z), axis, 1.0f);
    }
    public void newBall() {
        if (i < 5)
        {
            i++;
            racketShoot();
        }
    }
}
