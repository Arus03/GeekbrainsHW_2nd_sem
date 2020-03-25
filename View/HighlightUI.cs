using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{

    public sealed class HighlightUI : MonoBehaviour
    {
        private Text  _text;
        private Image _panel;

        private void Awake()
        { 
            _text  = GetComponentInChildren<Text> ();
            _panel = GetComponentInChildren<Image>();
        }

        public void SetActive(bool value)
        {
            _text.gameObject.SetActive (value);
            _panel.gameObject.SetActive(value);
        }

        public string Text 
        {
            get => _text.text;
            set => _text.text = value;
        }

    }

}