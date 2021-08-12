using EducationalApp.Model.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace EducationalApp.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            Product p1 = new Product { Name = "Каяк", Description = "Одноместное судно", Category = "ВодныйСпорт", UnitPrice = 275 };
            Product p2 = new Product { Name = "Спасательный жилет", Description = "Не дает утонуть", Category = "ВодныйСпорт", UnitPrice = 48.95m };
            Product p3 = new Product { Name = "Футбольный мяч", Description = "Соответствует стандаотам ФИФА", Category = "Футбол", UnitPrice = 19.50m };
            Product p4 = new Product { Name = "Угловой флаг", Description = "Придаст вашей площадке шарм профессионализма", Category = "Футбол", UnitPrice = 34.95m };
            Product p5 = new Product { Name = "Клюшка для хоккея с мячом", Description = "Легкая и прочная профессиональная клюшка", Category = "Хоккей", UnitPrice = 4600m };
            Product p6 = new Product { Name = "Мяч для хоккея с мячом", Description = "Официальный мяч чемпионата мира в Иркутске 2021", Category = "Хоккей", UnitPrice = 1000m };
            Product p7 = new Product { Name = "Коньки хоккейные", Description = "Профессиональные коньки, чрезвычайно легкие и удобные", Category = "Хоккей", UnitPrice = 15000m };
            Product p8 = new Product { Name = "Щитки хоккейные", Description = "Профессиональные щитки защитят вас во время тренировок и игр", Category = "Хоккей", UnitPrice = 5500m };
            if (!context.Products.Any()) context.AddRange(p1, p2, p3, p4, p5, p6, p7, p8);

            Order o1 = new Order
            {
                Name = "Заказ1",
                State = "Новосибирская",
                City = "Новосибирск",
                StreetName = "Карла Маркса",
                HouseNumber = "20",
                FlatNumber = 20,
                Zip = 666123,
                Country = "Россия",
                Products = new List<Product>() { p4, p5 }
            };
            Order o2 = new Order
            {
                Name = "Заказ2",
                State = "Иркутская",
                City = "Иркутск",
                StreetName = "Мира",
                HouseNumber = "10",
                FlatNumber = 210,
                Zip = 606123,
                Country = "Россия",
                Products = new List<Product>() { p1, p2 }
            };
            Order o3 = new Order
            {
                Name = "Заказ3",
                State = "Кемеровская",
                City = "Кемеровская",
                StreetName = "Дружбы Народов",
                HouseNumber = "34",
                FlatNumber = 53,
                Zip = 623123,
                Country = "Россия",
                Products = new List<Product>() { p3, p5 }
            };

            if (!context.Orders.Any()) context.AddRange(o1, o2, o3);

            Supplier s1 = new Supplier { Name = "Заказчик1", ContactNumber = "89134561234", ContactEmail = "andreev@gmail.com", ContactPerson = "Андрей Андреев" };
            Supplier s2 = new Supplier { Name = "Заказчик2", ContactNumber = "89417652431", ContactEmail = "sergeev@gmail.com", ContactPerson = "Сергей Сергеев" };
            Supplier s3 = new Supplier { Name = "Заказчик3", ContactNumber = "89991234567", ContactEmail = "Ivanov@gmail.com", ContactPerson = "Иван Иванов" };
            if (!context.Suppliers.Any()) context.AddRange(s1,s2,s3);

            context.SaveChanges();
        }
    }
}
