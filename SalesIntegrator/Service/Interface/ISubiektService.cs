using InsERT;
using SalesIntegrator.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesIntegrator.Service.Interface
{
    public interface ISubiektService
    {
        void CloseSubiekt();
        void EnterData(Order order);
        SuDokument DodajZamowienie(Order order, KontrahentJednorazowy kontrahent);
        KontrahentJednorazowy DodajKontrahenta(Order order);
        void StartSubiekt(DBConnectionModel dbUser, InsertUserModel insertUser);
        void ProcessOrders(IEnumerable<Order> newOrders);

    }
}
