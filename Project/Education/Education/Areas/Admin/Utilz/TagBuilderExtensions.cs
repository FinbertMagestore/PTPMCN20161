using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace Education.Areas.Admin.Utilz
{
    internal static class TagBuilderExtensions
    {
        internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode = TagRenderMode.Normal)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
}