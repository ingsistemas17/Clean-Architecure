using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Entity;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.UseCases;
using System.Linq;
using Web.Api.Core.Dto.UseCaseRequests;
using System.Transactions;

namespace Web.Api.Core.UseCases
{
    public class VentaUseCase: IVentaUseCase
    {

        private readonly IRepository _repository;

        private readonly string NOTEXIST_CLIENT = "NOTEXIST_CLIENT";
        private readonly string NOTEXIST_PRODUCT = "NOTEXIST_PRODUCT";
        private readonly string NOT_STOCK_PRODUCT = "NOT_STOCK_PRODUCT";
        private readonly string NOT_COUNT_PRODUCT = "NOT_COUNT_PRODUCT";


        public VentaUseCase(IRepository repository)
        {
            this._repository = repository;
        }

        public Cliente GetCliente(decimal Identificacion)
        {

            var cliente =  _repository.List<Cliente>().FirstOrDefault(a => a.Identifiacion == Identificacion);

            if (cliente != null)
                return cliente;
            else
                throw new Exception(NOTEXIST_CLIENT);


        }

        public Producto GetProduct(string codigo)
        {
            var producto = _repository.List<Producto>().FirstOrDefault(a => a.Codigo == codigo);
            if (producto != null)
                return producto;
            else
                throw new Exception(NOTEXIST_PRODUCT);
        }

        public Factura RegistrarVenta(RegistrarVentaRequest registrarVenta)
        {
            Factura factura;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    var cliente = _repository.List<Cliente>().FirstOrDefault(a => a.IdCliente == registrarVenta.IdCliente);
                    if (cliente == null )
                        throw new Exception(NOTEXIST_CLIENT);

                    factura = AddFactura(registrarVenta.IdCliente);
                    var productos = _repository.List<Producto>();

                    if(productos != null)
                    {

                       var FacturaDetalles = AddFacturaDetalle(registrarVenta.Productos, productos, factura.IdFactura);
                       decimal total = FacturaDetalles.Sum(a => a.ValorTotal);

                        factura.ValorTotal = total;
                        _repository.Update<Factura>(factura);

                    }


                    scope.Complete();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return factura;
        }

        private List<FacturaDetalle> AddFacturaDetalle(List<RegistrarProductoRequest> productosRequest, List<Producto> productos, decimal idFactura)
        {
            List<FacturaDetalle> facturaDetalles = new List<FacturaDetalle>();

            foreach (var p in productosRequest)
            {
                if(p.Cantidad <= 0)
                    throw new Exception(NOT_COUNT_PRODUCT);

                var product = productos.FirstOrDefault(a => a.IdProducto == p.IdProducto);

                if (product == null) 
                    throw new Exception(NOTEXIST_PRODUCT);

                if (product.Stock < p.Cantidad)
                    throw new Exception(NOT_STOCK_PRODUCT);
                else
                    product.Stock = product.Stock - p.Cantidad;



                FacturaDetalle facturaDetalle = new FacturaDetalle()
                {
                    IdFactura = idFactura,
                    Cantidad = p.Cantidad,
                    ValorUnidad = product.ValorUnidad,
                    ValorTotal = (p.Cantidad * product.ValorUnidad),
                    IdProducto = product.IdProducto

                };

                _repository.Update<Producto>(product);
                _repository.Add<FacturaDetalle>(facturaDetalle);
                facturaDetalles.Add(facturaDetalle);
            }

            return facturaDetalles;
        }

        private Factura AddFactura(decimal idCliente)
        {
            Factura factura = new Factura()
            {
                FechaVenta = DateTime.Now,
                IdCliente = idCliente,
                ValorTotal = 0
            };

            _repository.Add<Factura>(factura);

            return factura;
        }
    }
}
