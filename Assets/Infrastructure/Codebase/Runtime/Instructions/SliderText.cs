using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orbitality.Client.Runtime
{
    public sealed class SliderText : MonoBehaviour
    {
        [SerializeField] private Slider _slider = default;
        [SerializeField] private TextMeshProUGUI _text = default; 

        public void Start()
        {
            _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }

        public void ValueChangeCheck()
        {
            _text.text = _slider.value.ToString();
        }
    }
}