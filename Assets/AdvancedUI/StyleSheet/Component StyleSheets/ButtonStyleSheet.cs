using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Dhs5.AdvancedUI
{
    [System.Serializable]
    public class ButtonStyleSheet : BaseStyleSheet
    {
        public bool backgroundActive = true;
        public StylePicker backgroundStylePicker;
        [Space, Space]
        public bool iconActive = true;
        public float iconScale = 1;
        public StylePicker iconStylePicker;
        [Space, Space]
        public bool textActive = false;
        public StylePicker textStylePicker;

        public ImageStyleSheet BackgroundStyleSheet => backgroundStylePicker.StyleSheet as ImageStyleSheet;
        public ImageStyleSheet IconStyleSheet => iconStylePicker.StyleSheet as ImageStyleSheet;
        public TextStyleSheet TextStyleSheet => textStylePicker.StyleSheet as TextStyleSheet;

        public override void SetUp(StyleSheetContainer _container)
        {
            base.SetUp(_container);

            backgroundStylePicker?.SetUp(container, StyleSheetType.BACKGROUND_IMAGE, "Background");
            iconStylePicker?.SetUp(container, StyleSheetType.ICON_IMAGE, "Icon");
            textStylePicker?.SetUp(container, StyleSheetType.TEXT, "Text type");
        }

        public override List<StyleSheetPlaceholder> GetDependencies()
        {
            return new List<StyleSheetPlaceholder>()
            {
                backgroundStylePicker.Placeholder,
                iconStylePicker.Placeholder,
                textStylePicker.Placeholder
            };
        }

        protected override void CopyStyleSheet(BaseStyleSheet s)
        {
            if (s is ButtonStyleSheet b)
            {
                backgroundStylePicker.ForceSet(b.backgroundStylePicker);
                iconStylePicker.ForceSet(b.iconStylePicker);
                textStylePicker.ForceSet(b.textStylePicker);

                backgroundActive = b.backgroundActive;
                iconActive = b.iconActive;
                textActive = b.textActive;
                iconScale = b.iconScale;

            }
        }
    }
}
