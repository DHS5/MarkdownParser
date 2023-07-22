using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;

namespace Dhs5.Markdown
{
    public enum TextTag
    {
        NULL,
        TEXT,
        TITLE1,
        TITLE2,
        TITLE3,
        TITLE4,
        TITLE5,
        LIST,
        NUMBER_LIST,
        PHOTO,
        VIDEO
    }

    public struct MarkdownObjectInfo
    {
        public MarkdownObjectInfo(TextTag _tag, string _text, int _number)
        {
            tag = _tag;
            text = _text;
            number = _number;
        }
        public MarkdownObjectInfo(TextTag _tag = TextTag.NULL)
        {
            tag = TextTag.NULL;
            text = null;
            number = 0;
        }

        public TextTag tag;
        public string text;
        public int number;

        public override string ToString()
        {
            return tag.ToString() + " : " + text + " " + number;
        }
    }

    public static class MarkdownReader
    {
        public static List<MarkdownObjectInfo> ParseMarkdownFile(TextAsset markdownFile)
        {
            return ParseMarkdownLines(GetMarkdownTextLines(ReadMarkdownFile(markdownFile)));
        }

        private static string ReadMarkdownFile(TextAsset markdownFile)
        {
            return markdownFile.text;
        }

        private static List<string> GetMarkdownTextLines(string markdownText)
        {
            string[] temp = Regex.Split(markdownText, "\n");//|\r|\r\n

            return new List<string>(temp);
        }

        private static List<MarkdownObjectInfo> ParseMarkdownLines(List<string> lines)
        {
            List<MarkdownObjectInfo> result = new();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    result.Add(new MarkdownObjectInfo());
                }
                else
                {
                    result.Add(ParseMarkdownLine(line));
                }
            }

            return result;
        }

        private static MarkdownObjectInfo ParseMarkdownLine(string line)
        {
            line = line.Trim();
            TextTag tag = GetTag(line, out int number);
            string text = ParseText(ExtractText(line, tag));

            MarkdownObjectInfo result = new(tag, text, number);

            return result;
        }

        private static TextTag GetTag(string line, out int number)
        {
            number = 0;
            // Titles and lists
            TextTag result = line.StartsWith("#####") ? TextTag.TITLE5 :
                line.StartsWith("####") ? TextTag.TITLE4 :
                line.StartsWith("###") ? TextTag.TITLE3 :
                line.StartsWith("##") ? TextTag.TITLE2 :
                line.StartsWith("#") ? TextTag.TITLE1 :
                line.StartsWith("*") ? TextTag.LIST :
                line.StartsWith("-") ? TextTag.LIST : TextTag.TEXT;

            if (result == TextTag.TEXT)
            {
                if (Regex.IsMatch(line, "^([0-9]+\\.)"))
                {
                    result = TextTag.NUMBER_LIST;
                    number = int.Parse(line.Substring(0, line.IndexOf('.')));
                }
                if (line.StartsWith("![")) result = TextTag.PHOTO;
                if (line.StartsWith("https://") && (line.EndsWith(".mp4") || line.EndsWith(".mov"))) result = TextTag.VIDEO;
            }

            return result;
        }
        private static string ExtractText(string line, TextTag tag)
        {
            line = line.Trim();
            switch (tag)
            {
                case TextTag.TEXT: return line;
                case TextTag.TITLE1: return line.Remove(line.IndexOf("#"), 1).Trim();
                case TextTag.TITLE2: return line.Remove(line.IndexOf("##"), 2).Trim();
                case TextTag.TITLE3: return line.Remove(line.IndexOf("###"), 3).Trim();
                case TextTag.TITLE4: return line.Remove(line.IndexOf("####"), 4).Trim();
                case TextTag.TITLE5: return line.Remove(line.IndexOf("#####"), 5).Trim();
                case TextTag.LIST: return line.Remove(0, 1).Trim();
                case TextTag.NUMBER_LIST: return line.Remove(0, line.IndexOf('.') + 1).Trim();
                case TextTag.PHOTO: return line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1).Trim();
                case TextTag.VIDEO: return line;
                default: return line;
            }
        }
        private static string ParseText(string lineWOTag)
        {
            // Bold & Italic
            string result = Regex.Replace(lineWOTag, " \\*\\*\\*", " <b><i>");
            result = Regex.Replace(result, "\\*\\*\\* ", "</i></b> ");
            result = Regex.Replace(result, "\\*\\*\\*", "</i></b>");
            
            // Bold
            result = Regex.Replace(result, " \\*\\*", " <b>");
            result = Regex.Replace(result, "\\*\\* ", "</b> ");
            result = Regex.Replace(result, "\\*\\*", "</b>");
            
            // Italic
            result = Regex.Replace(result, " \\*", " <i>");
            result = Regex.Replace(result, "\\* ", "</i> ");
            result = Regex.Replace(result, "\\*", "</i>");

            // Line pass
            result = result.TrimEnd('\\');

            return result;
        }
    }
}
