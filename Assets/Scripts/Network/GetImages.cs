using System;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using Scripts.Network;
using System.Threading.Tasks;

namespace Scripts
{
    public class GetImages : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private RawImage _texture;
        [SerializeField] private GameObject _card;
        [SerializeField] private CardAnimation _animation;
        private Texture2D _getTexture;

        public static event Action<int> EndGetImage;
        private void OnEnable()
        {
            RequestGetTexture();
        }

        private void OnDisable()
        {
            _card.SetActive(false);
        }

        public async Task RequestGetTexture()
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
            _texture.texture = _getTexture;
            await Task.Yield();
            EndGetImage?.Invoke(_index);
        }
        public void ActiveCard()
        {
            _card.SetActive(true);
            _animation.StartAnimatiom();
        }
    }
}