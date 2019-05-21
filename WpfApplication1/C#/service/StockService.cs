using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.StockRepository;
using WpfApplication1.C_.service.converter;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.service
{
    public class StockService
    {
        private string adapter = ConfigurationManager.AppSettings["dbtype"].ToString();

        private StockConverter stockConverter = new StockConverter();

        private Abstract_StockRepository _stockRepository;

        public StockService()
        {
            switch (adapter)
            {
                case "MySQL":
                    this._stockRepository = new MySQL_StockRepository();
                    break;
                case "Oracle":
                    this._stockRepository = new Oracle_StockRepository();
                    break;
                case "SQLserver":
                    this._stockRepository = new SQLserver_StockRepository();
                    break;
            }
        }

        //overcharge GetAvionDTO with and without id, without you select all in bdd

        public List<StockDTO> GetStockDTOs()
        {
            return stockConverter.GetStockDTOs(this._stockRepository.GetStockDAOsInternal());
        }
        public void RemoveStock(List<StockDTO> stockDTOs)
        {
            this._stockRepository.RemoveStock(stockConverter.RemoveStock(stockDTOs));
        }

        public void RemoveTotalStock()
        {
            this._stockRepository.RemoveStockInternal();
        }

        public void AddStock(List<StockDTO> stockDTOs)
        {
            this._stockRepository.AddStock(stockConverter.AddStock(stockDTOs));
        }

        public List<StockDTO> UpdateStock(int id, string column, string value)
        {
            return stockConverter.GetStockDTOs(this._stockRepository.UpdateStock(id, column, value));
        }
    }
}
