using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace HE.WebApp.UserInterface.Helpers
{
    public static class LabelExtensions
    {
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TValue>> expression, 
            object htmlAttributes)
        {
            return LabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TValue>> expression, 
            IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            TagBuilder span = new TagBuilder("span");
            span.SetInnerText(labelText);

            // assign <span> to <label> inner html
            tag.InnerHtml = span.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}