using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dhs5.AdvancedUI;

namespace Dhs5.Markdown
{
    public class MarkdownImage : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private RectTransform rect;
        [SerializeField] private URLImage urlImage;

        public RectTransform Rect => rect;

        public void SetImage(string url)
        {
            urlImage.SetTexture(url);
        }

        // When image ready =>  page.Complete();
    }
}
