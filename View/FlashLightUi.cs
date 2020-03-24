using UnityEngine;
using UnityEngine.UI;


namespace Geekbrains
{
    public sealed class FlashLightUi : MonoBehaviour
    {
        private Text   _text;
        private Image _image;

        private void Awake()
        {
            _text  = GetComponentInChildren<Text> ();
            _image = GetComponentInChildren<Image>();
        }

        public float Text
        {
            set => _text.text = $"{value:0.0}";                 
        }

        
        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);     
        }
        
        public float ProgressAmount
        {
            set => _image.fillAmount = value / 10;
        }
    }
}
