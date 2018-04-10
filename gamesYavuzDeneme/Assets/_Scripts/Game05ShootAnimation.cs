using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game05ShootAnimation : MonoBehaviour {
    public RectTransform rectBall, rectRaket, targetTop, targetMiddle, targetLow, rectDefaultBall, rectRacketDefault, targetType2_1, targetType2_2, targetType3_1, targetType4_1, targetType4_2, targetType4_3;
    public GameObject ball;
	// Use this for initialization
	void Start () {
        //racketShootWrong();
	}
	
    public void racketShoot() {
        LeanTween.move(rectRaket, rectDefaultBall.transform.localPosition, 0.2f).setDelay(0.3f).setOnComplete(() =>
        {
            LeanTween.move(rectBall, targetTop.transform.localPosition, 0.5f).setOnComplete(() =>
            {
                LeanTween.alpha(rectBall, 0.0f, 0.01f);
                LeanTween.move(rectRaket, rectRacketDefault.transform.localPosition, 0.2f).setDelay(0.3f);
                LeanTween.move(rectBall, rectDefaultBall.transform.localPosition, 0.01f).setDelay(1f);
                LeanTween.alpha(rectBall, 1.0f, 1f).setDelay(1.01f);
                LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.2f, 0.2f, 0.0f), 0.1f).setEase(LeanTweenType.easeInQuad).setDelay(1f);
            });
            LeanTween.scale(rectBall, rectBall.transform.localScale - new Vector3(0.2f, 0.2f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
        });
    }

    public void racketShootType2() {
        LeanTween.move(rectRaket, rectBall.transform.localPosition, 0.2f).setDelay(0.3f).setOnComplete(() =>
        {
            LeanTween.move(rectBall, targetType2_1.transform.localPosition, 0.4f).setOnComplete(() =>
            {
                LeanTween.move(rectBall, targetType2_2.transform.localPosition, 0.4f).setOnComplete(() =>
                {
                    LeanTween.alpha(rectBall, 0.0f, 0.01f);
                    LeanTween.move(rectRaket, rectRacketDefault.transform.localPosition, 0.2f).setDelay(0.3f);
                    LeanTween.move(rectBall, rectDefaultBall.transform.localPosition, 0.01f).setDelay(1f);
                    LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.01f).setEase(LeanTweenType.easeInQuad).setDelay(1f);
                    LeanTween.alpha(rectBall, 1.0f, 1f).setDelay(1.01f);
                });
                LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
            });
            LeanTween.scale(rectBall, rectBall.transform.localScale - new Vector3(0.2f, 0.2f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
        });
    }
    public void racketShootType3()
    {
        LeanTween.move(rectRaket, rectBall.transform.localPosition, 0.2f).setDelay(0.3f).setOnComplete(() =>
        {
            LeanTween.move(rectBall, targetType3_1.transform.localPosition, 0.4f).setOnComplete(() =>
            {
                LeanTween.move(rectBall, targetType2_2.transform.localPosition, 0.4f).setOnComplete(() =>
                {
                    LeanTween.alpha(rectBall, 0.0f, 0.01f);
                    LeanTween.move(rectRaket, rectRacketDefault.transform.localPosition, 0.2f).setDelay(0.3f);
                    LeanTween.move(rectBall, rectDefaultBall.transform.localPosition, 0.01f).setDelay(1f);
                    LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.01f).setEase(LeanTweenType.easeInQuad).setDelay(1f);
                    LeanTween.alpha(rectBall, 1.0f, 1f).setDelay(1.01f);
                });
                LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
            });
            LeanTween.scale(rectBall, rectBall.transform.localScale - new Vector3(0.2f, 0.2f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
        });
    }

    public void racketShootType4()
    {
        LeanTween.move(rectRaket, rectBall.transform.localPosition, 0.2f).setDelay(0.3f).setOnComplete(() =>
        {
            LeanTween.move(rectBall, targetType4_1.transform.localPosition, 0.4f).setOnComplete(() =>
            {
                LeanTween.move(rectBall, targetType4_2.transform.localPosition, 0.4f).setOnComplete(() =>
                {
                    LeanTween.move(rectBall, targetType4_3.transform.localPosition, 0.4f).setOnComplete(() =>
                    {
                        LeanTween.move(rectBall, targetType2_2.transform.localPosition, 0.4f).setOnComplete(() =>
                        {
                            LeanTween.alpha(rectBall, 0.0f, 0.01f);
                            LeanTween.move(rectRaket, rectRacketDefault.transform.localPosition, 0.2f).setDelay(0.3f);
                            LeanTween.move(rectBall, rectDefaultBall.transform.localPosition, 0.01f).setDelay(1f);
                            LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.01f).setEase(LeanTweenType.easeInQuad).setDelay(1f);
                            LeanTween.alpha(rectBall, 1.0f, 1f).setDelay(1.01f);
                        });
                    });
                });
                LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
            });
            LeanTween.scale(rectBall, rectBall.transform.localScale - new Vector3(0.2f, 0.2f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
        });
    }

    public void racketShootWrong()
    {
        LeanTween.move(rectRaket, rectBall.transform.localPosition, 0.2f).setDelay(0.3f).setOnComplete(() =>
        {
            LeanTween.move(rectBall, targetMiddle.transform.localPosition, 0.4f).setOnComplete(() =>
            {
                LeanTween.move(rectBall, targetLow.transform.localPosition, 0.4f).setOnComplete(() =>
                {
                    LeanTween.alpha(rectBall, 0.0f, 1f);
                    LeanTween.move(rectRaket, rectRacketDefault.transform.localPosition, 0.2f).setDelay(0.3f);
                    LeanTween.move(rectBall, rectDefaultBall.transform.localPosition, 0.01f).setDelay(1f);
                    LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.01f).setEase(LeanTweenType.easeInQuad).setDelay(1f);
                    LeanTween.alpha(rectBall, 1.0f, 1f).setDelay(1.01f);
                });
                LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
            });
            LeanTween.scale(rectBall, rectBall.transform.localScale - new Vector3(0.2f, 0.2f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
        });
    }







    /*public void ballShoot() {
        LeanTween.move(rectBall, targetTop.transform.localPosition, 0.5f).setOnComplete(ballSetFalse);
    }
    public void ballSetFalse() {
        LeanTween.alpha(rectBall, 0.0f, 0.1f);
        LeanTween.move(rectRaket, rectRacketDefault.transform.localPosition, 0.2f).setDelay(0.3f);
        LeanTween.move(rectBall, rectDefaultBall.transform.localPosition, 0.01f).setDelay(1f);
        LeanTween.alpha(rectBall, 1.0f, 1f).setDelay(1.01f);
    }*/
    /*
    public void ballShootWrong2()
    {
        LeanTween.move(rectBall, targetMiddle.transform.localPosition, 0.4f).setOnComplete(ballShootWrong3);
        LeanTween.scale(rectBall, rectBall.transform.localScale - new Vector3(0.2f, 0.2f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
    }
    public void ballShootWrong3()
    {
        LeanTween.move(rectBall, targetLow.transform.localPosition, 0.4f).setOnComplete(ballDisappear);
        LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.4f).setEase(LeanTweenType.easeInQuad);
    }
    public void ballDisappear() {
        LeanTween.alpha(rectBall, 0.0f, 1f);
        LeanTween.move(rectRaket, rectRacketDefault.transform.localPosition, 0.2f).setDelay(0.3f);
        LeanTween.move(rectBall, rectDefaultBall.transform.localPosition, 0.01f).setDelay(1f);
        LeanTween.scale(rectBall, rectBall.transform.localScale + new Vector3(0.1f, 0.1f, 0.0f), 0.01f).setEase(LeanTweenType.easeInQuad).setDelay(1f); ;
        LeanTween.alpha(rectBall, 1.0f, 1f).setDelay(1.01f);
    }
    */

}
