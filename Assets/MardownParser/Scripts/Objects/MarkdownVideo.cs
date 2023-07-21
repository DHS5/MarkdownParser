using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dhs5.AdvancedUI;

namespace Dhs5.Markdown
{
    public class MarkdownVideo : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private RectTransform rect;
        [SerializeField] private URLVideoPlayer urlVideoPlayer;

        public RectTransform Rect => rect;

        public void SetVideo(string url, MarkdownPage page)
        {
            urlVideoPlayer.SetURL(url);
        }

        // When Video ready => page.Complete();
    }
}
