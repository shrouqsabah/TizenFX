/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.BaseComponents.MutableMarkup
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ColorTag : Disposable, IMarkupTag
    {

        internal ColorTag(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ColorTag.DeleteColorTag(swigCPtr);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorTag() : this(Interop.ColorTag.NewColorTag(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorTag(ColorTag p) : this(Interop.ColorTag.NewColorTag(ColorTag.getCPtr(p)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color FrontColor
        {
            get
            {
                Color ret = new Color(Interop.ColorTag.FrontColorGet(SwigCPtr),true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }

            private set
            {
                Interop.ColorTag.FrontColorSet(SwigCPtr, Color.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FrontColorDefined
        {
            get
            {
                bool ret = Interop.ColorTag.FrontColorDefinedGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }

            private set
            {
                Interop.ColorTag.FrontColorDefinedSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }


        public static ColorTag New()
        {
            return new ColorTag();
        }

        public static ColorTag.Builder Initialize()
        {
            return new ColorTag.Builder();
        }

        public string GetTagName()
        {
            return "color";
        }
        public PropertyMap GetAttributes()
        {
            PropertyMap attributes = new PropertyMap();

            if(FrontColorDefined)
            {
                attributes.Insert("value", new PropertyValue(FrontColor));
            }

            return attributes;
        }


        public class Builder : IMarkupTagBuilder<ColorTag>
        {
            private ColorTag  colorTag;
            internal Builder( )
            {
                this.colorTag= new ColorTag();
            }

            private Builder(ColorTag colorTag )
            {
                this.colorTag = colorTag;
            }

            public Builder WithFrontColor(Color frontColor)
            {
                this.colorTag.FrontColor = frontColor;
                this.colorTag.FrontColorDefined = true;

                return this;
            }


            public ColorTag Create() => this.colorTag;


        }

    }
}