using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class serviceConnection : MonoBehaviour {
    public string requestList = "{\"username\":\"" + "ysyucel" + "\"}";

    
    // Use this for initialization
	void Start () {

        StartCoroutine(PostRequest("http://localhost/mobileservice/MobileService.svc/getTraining", requestList));
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    IEnumerator PostRequest(string url, string bodyJsonString)
    {

        bool requestErrorOccurred=false;
        if (requestErrorOccurred)
        {
            yield return new WaitForSeconds(30f);
        }
        bool requestFinished = false;
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = new System.Text.UnicodeEncoding().GetBytes(bodyJsonString.ToCharArray());
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = 30;
        yield return request.Send();

        if (request.isNetworkError)
        {
            requestErrorOccurred = true;
        }
        Debug.Log("Response: " + request.downloadHandler.text);
        if (request.responseCode == 200)
        {
            Debug.Log(request.downloadHandler.text);
        }
        else if (request.responseCode == 401)
        {
            Debug.Log("Error 401: Unauthorized. Resubmitted request!");
        }
        else
        {
            Debug.Log("Request failed (status:" + request.responseCode + ").");
        }
        if (requestErrorOccurred)
        {
                Debug.Log("request Error Count: ");
             
        }
        if (!requestErrorOccurred)
        {
            yield return null;
        }

    }
}
