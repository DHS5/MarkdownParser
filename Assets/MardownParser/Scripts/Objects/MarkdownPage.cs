using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dhs5.Markdown
{
    public class MarkdownPage : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private RectTransform mainLayout;

        public void AddMarkdownObject(RectTransform objectRect)
        {
            objectRect.SetParent(mainLayout);
        }

        public void Complete()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(mainLayout);
            LayoutRebuilder.ForceRebuildLayoutImmediate(mainLayout);
        }
    }
}
