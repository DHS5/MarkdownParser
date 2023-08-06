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

        private List<MarkdownObject> markdownObjects;

        public bool Loaded { get; private set; }

        public void Begin()
        {
            markdownObjects = new();
        }
        public void AddMarkdownObject(MarkdownObject mdObject)
        {
            markdownObjects.Add(mdObject);
            mdObject.Rect.SetParent(mainLayout);
        }

        public void Complete()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(mainLayout);
            LayoutRebuilder.ForceRebuildLayoutImmediate(mainLayout);
        }
        public void Rebuild()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(mainLayout);
        }

        public void Load()
        {
            if (Loaded) return;

            foreach (MarkdownObject mdObject in markdownObjects)
                mdObject.LoadObject();
            Loaded = true;
        }
    }
}
