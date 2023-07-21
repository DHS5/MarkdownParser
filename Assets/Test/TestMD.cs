using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dhs5.Markdown;

public class TestMD : MonoBehaviour
{
    public TextAsset text;
    public MarkdownPage page;
    public MarkdownDisplayer displayer;

    void Start()
    {
        //foreach (var item in MarkdownReader.ParseMarkdownFile(text))
        //{
        //    Debug.Log(item);
        //}

        displayer.SetUpMardownPage(page, text);
    }
}
