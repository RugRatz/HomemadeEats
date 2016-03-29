using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace System.Web.Mvc.Html //HE.WebApp.UserInterface.Helpers
{
    public static class LabelExtensions
    {
        /// <summary>
        /// Custom LabelWithSpan Html helper.
        /// Creates html that looks like this (space before the text and semicolon after):
        /// <label class="col-md-2" for="mealTypeLbl">
        ///     <span class="glyphicon glyphicon-cutlery"></span> Meal Type:
        /// </label>
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="spanHtmlAttributes"></param>
        /// <param name="space"></param>
        /// <param name="semicolon"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TValue>> expression, 
            object spanHtmlAttributes,
            bool space)
        {
            return LabelFor(html, 
                expression, 
                new RouteValueDictionary(spanHtmlAttributes),
                space);
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TValue>> expression, 
            IDictionary<string, object> spanHtmlAttributes,
            bool space)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            var innerText = labelText;
            if (space)
                innerText = " " + innerText;

            TagBuilder span = new TagBuilder("span");
            span.MergeAttributes(spanHtmlAttributes);
            
            // assign <span> to <label> inner html AND tack on the label text here because this overwrites tag.SetInnerText
            tag.InnerHtml = span.ToString(TagRenderMode.Normal) + innerText;

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}