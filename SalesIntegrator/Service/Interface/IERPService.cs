using InsERT;
using SalesIntegrator.Dto.Interface;
using SalesIntegrator.DTOs.Subiekt;
using SalesIntegrator.Model;
using SalesIntegrator.Model.Interface;
using SalesIntgrator.Dto.Subiekt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesIntegrator.Service.Interface
{
    public interface IERPService
    {
        //void CloseSubiekt();
        //void EnterData(Order order);
        //SuDokument DodajZamowienie(SuDokumentDto dto, KontrahentJednorazowy kontrahent);
        //KontrahentJednorazowy DodajKontrahenta(KontrahentJednorazowyDto dto);
        //void StartSubiekt(DBConnectionModel dbUser, InsertUserModel insertUser);
        void RegisterOrders(IEnumerable<IModel> orders);

    }
}
