namespace Tizen.NUI.BaseComponents.MutableMarkup
{
    public class FontTag : IMarkupTag
    {

        private string          familyName;
        private FontWeightType      weight;
        private FontWidthType       width;
        private FontSlantType       slant;
        private float  fontSize;


        private bool familyNameDefined;
        private bool weightDefined;
        private bool widthDefined;
        private bool slantDefined;
        private bool fontSizeDefined;


        private FontTag()
        {
            familyNameDefined= false;
            weightDefined= false;
            widthDefined= false;
            slantDefined= false;
            fontSizeDefined= false;
        }

        public string FamilyName
        {
            get
            {
                return familyName;
            }

            private set
            {
                familyName = value;
            }

        }


        private bool FamilyNameDefined
        {
            get
            {
                return familyNameDefined;
            }

            set
            {
                familyNameDefined = value ;
            }
        }

        public FontWeightType Weight
        {
            get
            {
                return weight;
            }

            private set
            {
                weight = value;
            }

        }

        private bool WeightDefined
        {
            get
            {
                return weightDefined;
            }

            set
            {
                weightDefined = value ;
            }
        }

        public FontWidthType Width
        {
            get
            {
                return width;
            }

            private set
            {
                width = value;
            }

        }

        private bool WidthDefined
        {
            get
            {
                return widthDefined;
            }

            set
            {
                widthDefined = value ;
            }
        }

        public FontSlantType Slant
        {
            get
            {
                return slant;
            }

            private set
            {
                slant = value;
            }

        }


        private bool SlantDefined
        {
            get
            {
                return slantDefined;
            }

            set
            {
                slantDefined = value ;
            }
        }

        public float FontSize
        {
            get
            {
                return fontSize;
            }

            private set
            {
                fontSize = value;
            }

        }


        private bool FontSizeDefined
        {
            get
            {
                return fontSizeDefined;
            }

            set
            {
                fontSizeDefined = value ;
            }
        }


        public static FontTag New()
        {
            return new FontTag();
        }

        public static FontTag.Builder Initialize()
        {
            return new FontTag.Builder();
        }

        public string GetTagName()
        {
            return "font";
        }
        public PropertyMap GetAttributes()
        {
            PropertyMap attributes = new PropertyMap();

            if(FamilyNameDefined)
            {
                attributes.Add("family", FamilyName);
            }

            if(WeightDefined)
            {
                attributes.Add("weight", Weight);
            }

            if(SlantDefined)
            {
                attributes.Add("slant", Slant);
            }

            if(WidthDefined)
            {
                attributes.Add("width", Width);
            }

            if(FontSizeDefined)
            {
                attributes.Add("size", FontSize);
            }


            return attributes;
        }


        public class Builder : IMarkupTagBuilder<FontTag>
        {
            private FontTag  fontTag;
            internal Builder( )
            {
                this.fontTag= new FontTag();
            }

            private Builder(FontTag fontTag )
            {
                this.fontTag = fontTag;
            }

            public Builder WithFamilyName(string familyName)
            {
                this.fontTag.FamilyName = familyName;
                this.fontTag.FamilyNameDefined = true;

                return this;
            }

            public Builder WithWeight(FontWeightType weight)
            {
                this.fontTag.Weight = weight;
                this.fontTag.WeightDefined = true;

                return this;
            }

            public Builder WithSlant(FontSlantType slant)
            {
                this.fontTag.Slant = slant;
                this.fontTag.SlantDefined = true;

                return this;
            }

            public Builder WithWidth(FontWidthType width)
            {
                this.fontTag.Width = width;
                this.fontTag.WidthDefined = true;

                return this;
            }

            public Builder WithFontSize(float fontSize)
            {
                this.fontTag.FontSize = fontSize;
                this.fontTag.FontSizeDefined = true;

                return this;
            }


            public FontTag Create() => this.fontTag;


        }

    }
}