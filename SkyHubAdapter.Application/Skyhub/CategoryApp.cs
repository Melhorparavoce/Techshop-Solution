using System.Security;
using SkyHubAdapter.Application.Interfaces;
using SkyHubAdapter.Domain.AbsModels;
using SkyHubAdapter.Domain.SkyHub;

namespace SkyHubAdapter.Application
{
    public class CategoryApp : IGenericType<Category>
    {
        private const string Uri = "categories";

        public ResultProcessing Post(Category newModel)
        {
            return ClientHelper.Post(newModel, Uri);
        }

        public ResultProcessing Put(Category model)
        {
            return ClientHelper.Put(model, Uri + "/" + model.code);
        }

        public ResultProcessing Get(string code = "")
        {
            return ClientHelper.Get<Category>(Uri, "", true);
        }

        public ResultProcessing Delete(string code)
        {
            return ClientHelper.Delete(Uri, code);
        }

    }
}
