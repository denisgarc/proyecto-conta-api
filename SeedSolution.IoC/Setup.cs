using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using SeedSolution.Data.Connection;
using SeedSolution.Data.Connection.Interfaces;
using SeedSolution.Data.SecurityAcces;
using SeedSolution.Data.Interfaces.SecurityAcces;
using SeedSolution.Business.SecurityAccess;
using SeedSolution.Business.Interfaces;

using SeedSolution.Business.Inventory;
using SeedSolution.Business.Interfaces.Inventory;
using SeedSolution.Data.Interfaces.Inventory;
using SeedSolution.Data.Inventory;

namespace SeedSolution.IoC
{
    public class Setup
    {
        public static void ConfigureIoC(Action<ConfigurationExpression> MoreIoCConfigurations)
        {
            ObjectFactory.Configure(x =>
            {   
                // Generales
                x.For<IConnectionTools>().Use<MSSQLTools>();
                x.For<ISysUser>().Use<SysUserDB>();
                x.For<ISecurityAccesBL>().Use<SecurtiyAccesBL>();

                // Repositorios
                x.For<IBranchRepository>().Use<BranchRepository>();
                x.For<IBrandRepository>().Use<BrandRepository>();
                x.For<ICardexRepository>().Use<CardexRepository>();
                x.For<IColorRepository>().Use<ColorRepository>();
                x.For<IOperationRepository>().Use<OperationRepository>();
                x.For<IProductRepository>().Use<ProductRepository>();

                // Bussiness Layer
                x.For<IBranchBL>().Use<BranchBL>();
                x.For<IBrandBL>().Use<BrandBL>();
                x.For<ICardexBL>().Use<CardexBL>();
                x.For<IColorBL>().Use<ColorBL>();
                x.For<IOperationBL>().Use<OperationBL>();
                x.For<IProductBL>().Use<ProductBL>();

                //Más configuraciones
                MoreIoCConfigurations(x);
            });
        }
    }
}
