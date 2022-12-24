using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using Scripts.Network;
using System.Threading.Tasks;
 
public class GetImages : MonoBehaviour
{
    public RawImage Texture;
    private Texture2D _getTexture;
    void Start()
    {
        GetTexture();
    }
    public async Task<Texture2D> GetTexture()
    {
        var request = UnityWebRequestTexture.GetTexture(AddressImages.AddressImag);
        var call = request.SendWebRequest();
        while (!call.isDone)
        {
            await Task.Yield();
        }
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(request);
            _getTexture = texture;
        }
        //Texture.texture = _getTexture;
        return _getTexture;
    }

    private void TextureSSS()
    {
        Texture = GetImages.GetTexture();
    }
}