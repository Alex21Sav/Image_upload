using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
 
public class GetImages : MonoBehaviour
{
    public RawImage Texture;
    void Start() {
        StartCoroutine(GetTexture());
    }
 
    IEnumerator GetTexture() {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://picsum.photos/200/300");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Texture.texture = myTexture;
        }
    }
}