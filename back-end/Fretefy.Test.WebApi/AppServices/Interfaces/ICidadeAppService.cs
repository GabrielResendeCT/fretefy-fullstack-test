using Fretefy.Test.WebApi.DTOs;
using System;
using System.Collections.Generic;

namespace Fretefy.Test.WebApi.AppServices.Interfaces
{
    public interface ICidadeAppService
    {
        CidadeDTO Get(Guid id);
        IEnumerable<CidadeDTO> List();
        IEnumerable<CidadeDTO> ListByUf(string uf);
        IEnumerable<CidadeDTO> Query(string terms);
    }
}