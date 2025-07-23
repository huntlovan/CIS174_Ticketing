namespace CIS174_Ticketing.TagHelpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("submit-button")]
    public class MySubmitButtonTagHelper : TagHelper
    {
        public string Text { get; set; } = "Submit";

        public string CssClass { get; set; } = "btn btn-primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button"; // Change <submit-button> to <button>
            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("class", CssClass);
            output.Content.SetContent(Text);
        }
    }
}
