using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
public class javascriptDeneme : MonoBehaviour {
    /*public GameObject textPlugin;
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);




    [DllImport("__Internal")]
    private static extern void setCookie(string x);
    [DllImport("__Internal")]
    private static extern string getCookie();
    [DllImport("__Internal")]*/
    private static extern void getNewPage(string y);
    void Start()
    {
        /*Hello();

        HelloString("This is a string.");

        setCookie("lol");
        textPlugin.GetComponent<Text>().text = getCookie();*/
    }
    public void buttonActionNewPage() {
        
        getNewPage("https://www.mentalup.net/Application/MentalUP/game/game45?username=ysyucel&password=123456&gameid=45&level=5&fromdailytraining=0");
    }
	
}
