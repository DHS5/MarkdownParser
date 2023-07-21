using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Markdown
{
    public class MarkdownDisplayer : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject title1Prefab;
        [SerializeField] private GameObject title2Prefab;
        [SerializeField] private GameObject title3Prefab;
        [SerializeField] private GameObject title4Prefab;
        [SerializeField] private GameObject title5Prefab;
        [SerializeField] private GameObject listPrefab;
        [SerializeField] private GameObject numberListPrefab;
        [SerializeField] private GameObject textPrefab;
        [SerializeField] private GameObject emptyPrefab;
        [SerializeField] private GameObject photoPrefab;
        [SerializeField] private GameObject videoPrefab;


        public void SetUpMardownPage(MarkdownPage page, TextAsset markdownFile)
        {
            RectTransform rect;

            List<MarkdownObject> markdownObjects = MarkdownReader.ParseMarkdownFile(markdownFile);

            foreach (MarkdownObject markdownObject in markdownObjects)
            {
                rect = CreateMarkdownObject(markdownObject, page);

                if (rect != null) page.AddMarkdownObject(rect);
            }

            page.Complete();
        }

        private RectTransform CreateMarkdownObject(MarkdownObject mdObj, MarkdownPage page)
        {
            GameObject obj;

            switch (mdObj.tag)
            {
                case TextTag.NULL: 
                    obj = Instantiate(emptyPrefab);
                    return obj.transform as RectTransform;
                case TextTag.TITLE1: 
                    obj = Instantiate(title1Prefab);
                    break;
                case TextTag.TITLE2: 
                    obj = Instantiate(title2Prefab);
                    break;
                case TextTag.TITLE3: 
                    obj = Instantiate(title3Prefab);
                    break;
                case TextTag.TITLE4: 
                    obj = Instantiate(title4Prefab);
                    break;
                case TextTag.TITLE5: 
                    obj = Instantiate(title5Prefab);
                    break;
                case TextTag.TEXT: 
                    obj = Instantiate(textPrefab);
                    break;
                case TextTag.LIST: 
                    obj = Instantiate(listPrefab);
                    break;
                case TextTag.NUMBER_LIST: 
                    obj = Instantiate(numberListPrefab);
                    break;
                case TextTag.PHOTO: 
                    obj = Instantiate(photoPrefab);
                    break;
                case TextTag.VIDEO: 
                    obj = Instantiate(videoPrefab);
                    break;
                default:
                    obj = Instantiate(emptyPrefab);
                    return obj.transform as RectTransform;
            }

            // Text
            if (mdObj.tag == TextTag.TITLE1 || mdObj.tag == TextTag.TITLE2 || mdObj.tag == TextTag.TITLE3
                || mdObj.tag == TextTag.TITLE4 || mdObj.tag == TextTag.TITLE5 || mdObj.tag == TextTag.TEXT
                || mdObj.tag == TextTag.LIST || mdObj.tag == TextTag.NUMBER_LIST)
            {
                MarkdownText mdText = obj.GetComponent<MarkdownText>();
                
                if (mdText != null)
                {
                    if (mdObj.tag == TextTag.NUMBER_LIST)
                    {
                        mdText.SetTextAndNumber(mdObj.text, mdObj.number);
                    }
                    else
                    {
                        mdText.SetText(mdObj.text);
                    }

                    return mdText.Rect;
                }
                return null;
            }

            // Photo
            if (mdObj.tag == TextTag.PHOTO)
            {
                MarkdownImage mdImage = obj.GetComponent<MarkdownImage>();

                if (mdImage != null)
                {
                    mdImage.SetImage(mdObj.text);
                    return mdImage.Rect;
                }

                return null;
            }

            // Video
            if (mdObj.tag == TextTag.VIDEO)
            {
                MarkdownVideo mdVideo = obj.GetComponent<MarkdownVideo>();

                if (mdVideo != null)
                {
                    mdVideo.SetVideo(mdObj.text, page);
                    return mdVideo.Rect;
                }

                return null;
            }

            return null;
        }
    }
}
