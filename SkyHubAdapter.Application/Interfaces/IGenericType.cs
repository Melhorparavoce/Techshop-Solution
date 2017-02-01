using SkyHubAdapter.Domain.AbsModels;

namespace SkyHubAdapter.Application.Interfaces
{
    public interface IGenericType<in T>
    {
        
        ResultProcessing Post(T newModel);

        ResultProcessing Put(T model);

        ResultProcessing Get(string code = "");

        ResultProcessing Delete(string code);
    }
}
