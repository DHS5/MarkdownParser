using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dhs5.AdvancedUI;
using System;

namespace Dhs5.Markdown
{
    public class MarkdownImage : MarkdownObject
    {
        [Header("References")]
        [SerializeField] private URLImage urlImage;

        public event Action OnNeedToRebuildLayout
        { add { urlImage.onSetRatio += value; } remove { urlImage.onSetRatio -= value; } }

        private string url;

        public void SetImage(string _url, MarkdownPage page)
        {
            url = _url;
            OnNeedToRebuildLayout += page.Rebuild;
        }

        public override void LoadObject()
        {
            urlImage.SetTexture(url);
        }

        // When image ready =>  page.Complete();
    }
}
