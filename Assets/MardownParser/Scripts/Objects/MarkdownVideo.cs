using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dhs5.AdvancedUI;
using System;

namespace Dhs5.Markdown
{
    public class MarkdownVideo : MarkdownObject
    {
        [Header("References")]
        [SerializeField] private URLVideoPlayer urlVideoPlayer;

        public event Action OnNeedToRebuildLayout
        { add { urlVideoPlayer.onSetRatio += value; } remove { urlVideoPlayer.onSetRatio -= value; } }

        private string url;

        public void SetVideo(string _url, MarkdownPage page)
        {
            url = _url;
            OnNeedToRebuildLayout += page.Rebuild;
        }

        public override void LoadObject()
        {
            urlVideoPlayer.SetURL(url);
        }

        // When Video ready => page.Complete();
    }
}
