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
        /*
            // 20180827 created the DescriptionFor html helper //
         * this will get the model's display description attribute and insert it into a label tag
         * it will create the string of html that will render the label using the display description
         * instead of having to be limited to using the display name
        */
        public static string DescriptionFor<TModel, TValue>(
            this HtmlHelper<TModel> self,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes
        )
        {
            var builder = new TagBuilder("label");
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);

            builder.InnerHtml = metadata.Description;
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return builder.ToString();
        }
    }
}