using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game45Button : MonoBehaviour {
    public GameObject gm;
    public bool done = false;
	// Use this for initialization
	void Start () {
        gm = GameObject.Find("Gm");
        GameObject gmoTmp = this.gameObject;
        this.GetComponent<Button>().onClick.AddListener(() => gameButton(gmoTmp));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void gameButton(GameObject bt)
    {
        Debug.Log("hoohoho");
        if (!done&&gm.GetComponent<Game45>().isButtonClickable)
        {
            gm.GetComponent<Game45>().buttonActionElement(int.Parse(this.transform.GetChild(0).GetComponent<Text>().text.ToString()));
            done = true;
        }
    }
}
