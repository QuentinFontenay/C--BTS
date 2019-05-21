using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.service.converter
{
    public class StockConverter
    {
        public List<StockDTO> GetStockDTOs(List<StockDAO> stockDAOs)
        {
            List<StockDTO> stockDTOs = new List<StockDTO>();

            foreach (var stockDAO in stockDAOs)
            {
                StockDTO stockDTO = new StockDTO();

                stockDTO.IdStock = stockDAO.IdStock;
                stockDTO.Repas = stockDAO.Repas;
                stockDTO.Boissons = stockDAO.Boissons;
                stockDTO.Magazines = stockDAO.Magazines;
                stockDTO.IdAvion = stockDAO.IdAvion;
                stockDTO.produitHygienique = stockDAO.produitHygienique;

                stockDTOs.Add(stockDTO);
            }

            return stockDTOs;
        }

        public List<int> RemoveStock(List<StockDTO> stockDTOs)
        {
            List<int> ids = new List<int>();

            foreach (var stockDTO in stockDTOs)
            {
                ids.Add(stockDTO.IdStock);
            }

            return ids;
        }

        public List<StockDAO> AddStock(List<StockDTO> stockDTOs)
        {
            List<StockDAO> stockDAOs = new List<StockDAO>();

            foreach (var stockDTO in stockDTOs)
            {
                StockDAO stockDAO = new StockDAO();

                stockDAO.IdStock = stockDTO.IdStock;
                stockDAO.Repas = stockDTO.Repas;
                stockDAO.Boissons = stockDTO.Boissons;
                stockDAO.Magazines = stockDTO.Magazines;
                stockDAO.IdAvion = stockDTO.IdAvion;
                stockDAO.produitHygienique = stockDTO.produitHygienique;

                stockDAOs.Add(stockDAO);
            }

            return stockDAOs;
        }
    }
}
