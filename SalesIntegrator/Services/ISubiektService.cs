using InsERT;
using SalesIntegrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesIntegrator.Services
{
    public interface ISubiektService
    {
        void CloseSubiekt();
        void EnterData(Order order);
        SuDokument DodajZamowienie(Order order, KontrahentJednorazowy kontrahent);
        KontrahentJednorazowy DodajKontrahenta(Order order);
        void StartSubiekt(DBConnectionModel dbUser, InsertUserModel insertUser);
        void PassOrders(IEnumerable<Order> newOrders);
        void ProcessOrders();

    }
}
