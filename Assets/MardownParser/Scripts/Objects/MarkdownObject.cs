using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Markdown
{
    public class MarkdownObject : MonoBehaviour
    {
        [SerializeField] private RectTransform rect;

        public RectTransform Rect => rect;

        public virtual void LoadObject() { }
    }
}
