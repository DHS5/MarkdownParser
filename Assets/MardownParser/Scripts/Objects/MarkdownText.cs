using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dhs5.Markdown
{
    public class MarkdownText : MarkdownObject
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private TextMeshProUGUI numberText;

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
