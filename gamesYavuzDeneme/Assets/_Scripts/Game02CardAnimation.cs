using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game02CardAnimation : MonoBehaviour {
    public RectTransform rectCard;
    public GameObject gameObjectCard,gameObjectSprite;
    public Sprite cardBack, cardFront, imageSprite;
    public float scaleTime, rotateTime;
    void Start() {
        cardUp();
    }

    public void cardUp() {
        LeanTween.scale(rectCard, rectCard.transform.localScale + new Vector3(0.3f, 0.3f, 0.0f), scaleTime).setEase(LeanTweenType.easeInQuad).setOnComplete(cardTurn).setDelay(1.0f);
    }
    public void cardTurn() {
        LeanTween.rotateAround(gameObjectCard, new Vector3(0.0f, 90f, 0.0f), 90.0f, rotateTime).setOnComplete(cardOpen);
    }
    public void cardOpen()
    {   
        
        gameObjectCard.GetComponent<Image>().sprite = cardFront;
        gameObjectSprite.GetComponent<Image>().sprite = imageSprite;
        gameObjectSprite.SetActive(true);
        LeanTween.rotateAround(gameObjectCard, new Vector3(0f, 90f, 0.0f), 90.0f, rotateTime).setOnComplete(cardDown);
    }
    public void cardDown()
    {
            gameObjectSprite.SetActive(true);
            LeanTween.scale(rectCard, rectCard.transform.localScale + new Vector3(-0.3f, -0.3f, 0.0f), scaleTime).setEase(LeanTweenType.easeInQuad);
    }


    public void cardBackUp(){
          LeanTween.scale(rectCard, rectCard.transform.localScale + new Vector3(0.3f, 0.3f, 0.0f), scaleTime).setEase(LeanTweenType.easeInQuad).setOnComplete(cardBackMove).setDelay(1.0f);
    }
    public void cardBackMove(){
        LeanTween.rotateAround(gameObjectCard, new Vector3(0.0f, 90f, 0.0f), 90.0f, rotateTime).setOnComplete(cardSetDefault);
    }
    public void cardSetDefault(){
        gameObjectSprite.SetActive(false);
        gameObjectCard.GetComponent<Image>().sprite = cardBack;
        LeanTween.rotateAround(gameObjectCard, new Vector3(0.0f, 90f, 0.0f), 90.0f, rotateTime).setOnComplete(turnCardUp);
        
        
    }
    public void turnCardUp() {
        LeanTween.scale(rectCard, rectCard.transform.localScale + new Vector3(-0.3f, -0.3f, 0.0f), scaleTime).setEase(LeanTweenType.easeInQuad);
        
    }
    

}


        
