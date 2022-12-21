using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;

public class JSONReader : MonoBehaviour
{
    public TMP_Text axesText, typeText;

    private readonly string baseURL = "https://zion-test.s3.ap-south-1.amazonaws.com/assignment/mcw_data_1.json";

    private void Start()
    {
        axesText.text = "";
        typeText.text = "";

        StartCoroutine(GetTexture());
    }
    
    IEnumerator GetTexture()
    {
        UnityWebRequest infoRequest = UnityWebRequest.Get(baseURL);

        yield return infoRequest.SendWebRequest();

        if (infoRequest.isNetworkError || infoRequest.isHttpError)
        {
            Debug.LogError(infoRequest.error);
            yield break;
        }

        JSONNode list = JSON.Parse(infoRequest.downloadHandler.text);

        string axes = list["axes"];
        string type = list["type"];

        axesText.text = axes;
        typeText.text = type;
    }
}