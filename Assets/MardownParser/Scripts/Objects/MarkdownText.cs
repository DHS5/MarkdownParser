using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dhs5.Markdown
{
    public class MarkdownText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private RectTransform rect;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI numberText;

        public RectTransform Rect => rect;

        public void SetText(string t)
        {
            text.text = t;
        }
        public void SetTextAndNumber(string t, int num)
        {
            text.text = t;
            numberText.text = num + ".";
        }
    }
}
