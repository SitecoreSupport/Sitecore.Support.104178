
namespace Sitecore.Support.Buckets.Pipelines.UI
{
    using System;
    using Sitecore.Buckets.Managers;
    using Sitecore.Data.Events;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;

    [Serializable]
    public class AddMaster : Shell.Framework.Commands.AddMaster
    {
        public AddMaster()
        {
            this.ItemCreated += OnItemCreated;
        }

        private void OnItemCreated([NotNull] object sender, [NotNull] ItemCreatedEventArgs args)
        {
            Assert.ArgumentNotNull(sender, "sender");
            Assert.ArgumentNotNull(args, "args");

            Item item = args.Item;
            if (item != null && BucketManager.IsItemContainedWithinBucket(item))
            {
                Context.ClientPage.ClientResponse.Eval("setTimeout(function(){ scForm.invoke(\"item:load(id=" + item.ID + ")\"); }, 0)");
            }
        }
    }
}