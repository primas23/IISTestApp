using System.Collections.Generic;
namespace IISTA.Common.Contracts
{
    public interface IHttpRoute
    {
        string GetActionControler();

        string GetActionMethod();
        
        Dictionary<object, object> GetFieldsOfQueryString();
    }
}
