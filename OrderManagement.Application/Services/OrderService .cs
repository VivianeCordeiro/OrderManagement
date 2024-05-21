using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Application.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderManagement.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly HttpClient _httpClient;
        public OrderService(
            IOrderRepository orderRepository,
            HttpClient httpClient)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }


        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }

        public async Task<bool> CreateOrders(Order data)
        {
            return await _orderRepository.CreateOrders(data);
            //throw new NotImplementedException();
        }

        public async Task<AnalyzedData> DataManagement(List<OrdersData> ordersData)
        {
            var data = new AnalyzedData();

            data.Celular = ordersData.Count(item => item.Produto == "Celular");
            data.Televisao = ordersData.Count(item => item.Produto == "Televisão");
            data.Notebook = ordersData.Count(item => item.Produto == "Notebook");

            foreach (var order in ordersData)
            {
                var region = await GetRegionFromCep(order.CEP);
                switch (region)
                {
                    case "Sul":
                        data.Sul++;
                        data.Sales.Add(new Sales
                        {
                            Name = order.RazaoSocial,
                            Product = order.Produto,
                            DeliveryDate = order.Date.AddDays(5),
                            FinalValue = CalculatePrice(order.Produto) * 1.2,

                        }) ;


                        break;
                    case "Sudeste":
                        data.Sudeste++;
                        data.Sales.Add(new Sales
                        {
                            Name = order.RazaoSocial,
                            Product = order.Produto,
                            DeliveryDate = order.Date.AddDays(1),
                            FinalValue = CalculatePrice(order.Produto) * 1.1,

                        });
                        break;
                    case "Nordeste":
                        data.Nordeste++;
                        data.Sales.Add(new Sales
                        {
                            Name = order.RazaoSocial,
                            Product = order.Produto,
                            DeliveryDate = order.Date.AddDays(10),
                            FinalValue = CalculatePrice(order.Produto) * 1.3,

                        });
                        break;
                    case "Norte":
                        data.Norte++;
                        data.Sales.Add(new Sales
                        {
                            Name = order.RazaoSocial,
                            Product = order.Produto,
                            DeliveryDate = order.Date.AddDays(10),
                            FinalValue = CalculatePrice(order.Produto) * 1.3,

                        });
                        break;
                    case "Centro-Oeste":
                        data.CentroOeste++;
                        data.Sales.Add(new Sales
                        {
                            Name = order.RazaoSocial,
                            Product = order.Produto,
                            DeliveryDate = order.Date.AddDays(5),
                            FinalValue = CalculatePrice(order.Produto) * 1.2,

                        });
                        break;
                    case "SP":
                        data.SP++;
                        data.Sales.Add(new Sales
                        {
                            Name = order.RazaoSocial,
                            Product = order.Produto,
                            DeliveryDate = order.Date,
                            FinalValue = CalculatePrice(order.Produto),

                        });
                        break;
                }
            }

            return data;
        }

        private async Task<string> GetRegionFromCep(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var viaCepResponse = JsonSerializer.Deserialize<ViaCepResponse>(jsonResponse);
                return GetRegion(viaCepResponse.uf, viaCepResponse.localidade);
            }

            return "Unknown";
        }

        private string GetRegion(string uf, string localidade)
        {
            switch (uf)
            {
                case "SP":
                    return localidade == "São Paulo" ? "SP" : "Sudeste";
                case "RJ":
                case "MG":
                case "ES":
                    return "Sudeste";
                case "PR":
                case "SC":
                case "RS":
                    return "Sul";
                case "BA":
                case "PE":
                case "CE":
                case "RN":
                case "PB":
                case "SE":
                case "AL":
                case "PI":
                case "MA":
                    return "Nordeste";
                case "DF":
                case "GO":
                case "MT":
                case "MS":
                    return "Centro-Oeste";
                case "AM":
                case "RR":
                case "AP":
                case "PA":
                case "TO":
                case "RO":
                case "AC":
                    return "Norte";
                default:
                    return "Unknown";
            }
        }
        private double CalculatePrice(string product)
        {
            if (product == "Televisão") { return 5000; }
            if (product == "Notebook") { return 3000; }
            else { return 1000; }
        }
        private class ViaCepResponse
        {
            public string uf { get; set; }
            public string localidade { get; set; }
        }


    }
}