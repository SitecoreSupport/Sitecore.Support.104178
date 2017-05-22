

namespace Sitecore.Support.Buckets.Pipelines.UI.AddFromTemplate
{
    using Sitecore.Buckets.Managers;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Web.UI.Sheer;

    public class SelectItem
    {
        public void Execute([NotNull] ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (!args.HasResult)
            {
                return;
            }

            Item item = (Context.ContentDatabase ?? Context.Database).GetItem(args.Result);
            if (item != null && BucketManager.IsItemContainedWithinBucket(item))
            {
                Context.ClientPage.ClientResponse.Eval("setTimeout(function(){ scForm.invoke(\"item:load(id=" + item.ID + ")\"); }, 0)");
            }
        }
    }
}