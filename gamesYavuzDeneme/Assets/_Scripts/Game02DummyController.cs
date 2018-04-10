using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game02DummyController : MonoBehaviour {
    public GameObject contentGroup,question;
    public GameObject[] contentChild;
    public int childIndex=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void buttonClick1() {
        question.SetActive(false);
        contentGroup.SetActive(true);

        for (int i = 0; i < 9; i++) { 
            float waitTime=i*0.4f;
            Invoke("childSetActive",waitTime);
        }
    }
    public void buttonClick2()
    {
        question.SetActive(false);
        contentGroup.SetActive(true);
        for (int i = 0; i < 9; i++)
        {
            float waitTime = i * 0.4f;
            Invoke("childSetFalse", waitTime);
        }
    }
    public void buttonClick3()
    {
        for (int i = 0; i < 9; i++)
        {
            contentChild[i].SetActive(false);
        }
        question.SetActive(true);
        question.GetComponent<Game02CardAnimation>().cardBackUp();
    }
    public void buttonClick4()
    {
        for (int i = 0; i < 9; i++)
        {
            contentChild[i].SetActive(false);
        }
        question.SetActive(true);
        question.GetComponent<Game02CardAnimation>().cardUp();
    }
    public void childSetActive(){

        contentChild[childIndex].SetActive(true);
        childIndex++;

    }
    public void childSetFalse()
    {
        if (childIndex == 9) {
            childIndex--;
        }
        contentChild[childIndex].GetComponent<Game02CardAnimation>().cardBackUp();
        childIndex--;
       
    }
}
