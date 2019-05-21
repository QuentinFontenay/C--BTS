using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.service;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.controller
{
    public class StockController
    {
        private StockService StockService = new StockService();
        public List<StockDTO> GetStockDTOs()
        {
            return StockService.GetStockDTOs();
        }

        public void RemoveStock(List<StockDTO> StockDTOs)
        {
            StockService.RemoveStock(StockDTOs);
        }

        public void AddStock(List<StockDTO> StockDTOs)
        {
            StockService.AddStock(StockDTOs);
        }

        public List<StockDTO> UpdateStock(int id, string column, string value)
        {
            return StockService.UpdateStock(id, column, value);
        }
    }
}
