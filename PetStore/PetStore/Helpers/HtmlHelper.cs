using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Routing;

namespace PetStore.Helpers
{
    public static class HtmlHelper
    {
        // this will output the property's display description as an html label 
        public static string DescriptionFor<TModel, TValue>(
            this HtmlHelper<TModel> self,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes)
        {
            var builder = new TagBuilder("label");
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);

            builder.InnerHtml = metadata.Description;
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return builder.ToString();
        }
    }
}