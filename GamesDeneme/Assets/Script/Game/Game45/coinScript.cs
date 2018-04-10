using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {
    
    public GameObject topBarCoin,Gm;
	// Use this for initialization
	void Start () {
        topBarCoin = GameObject.Find("Coin");
        Gm = GameObject.Find("Gm");

        Gm.GetComponent<Game1>().scoreIncreaser();
        Debug.Log("scoreIncreaser");
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("coinDestroyer", 2.0f);

	}
    void coinDestroyer() {
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
