using Assets.App.Components;
using TMPro;
using UnityEngine;

namespace App
{
    public class DebugPrinter : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        [SerializeField]
        private DebugComponent _debug;

        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_text != null)
            {
                _text.text = string.Format("Horizontal: {0}\nVertical: {1}", _debug.Value.Horizontal, _debug.Value.Vertical);
            }
        }
    }
}