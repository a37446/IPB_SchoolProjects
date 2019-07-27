using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreBloodBank.Classes;

namespace EFCoreBloodBank
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext efcontx = new MyDbContext();
            //select all department
            List<User> U1 = efcontx.User.ToList();
            User U = new User() { Email_address = "a37446@alunos.ipb.pt", Login_Name = "mANS", Password = "ratoragat19", Medical_Report = "bla bla bla", Address = "Rua de ouro", Telephone = "9635827" };
            efcontx.User.Add(U);
            efcontx.SaveChanges();
            
            }
    }
}
