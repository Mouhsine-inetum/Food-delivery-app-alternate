using FoodDeliveryClient.App.Models.Dto.Users;
using FoodDeliveryClient.App.Models.Inputs.Users;
using FoodDeliveryClient.App.Services.Interfaces;
using Microsoft.Identity.Web;
using Polly;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FoodDeliveryClient.App.Services.Cores
{
    public class PartnerService : IPartnerService
    {
        private readonly HttpClient _httpClient;

        public PartnerService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> DeletePartnerAsync(string id)
        {
            var data = await _httpClient.DeleteAsync(id);
            var success = data.IsSuccessStatusCode;
            return await Task.FromResult(success);
        }

        public async Task<PartnersDto> GetPartnerAsync(string id)
        {
            var data = await _httpClient.GetAsync(id);
            var rawdata = await data.Content.ReadAsStringAsync();
            PartnersDto partner = JsonSerializer.Deserialize<PartnersDto>(rawdata);
            return await Task.FromResult(partner);
        }

        public async Task<IList<PartnersDto>> GetPartnersAsync()
        {
            List<PartnersDto> partners = new ();
            var data = await _httpClient.GetAsync("?status=2");
            var rawdata=await data.Content.ReadAsStringAsync();
            partners = JsonSerializer.Deserialize<List<PartnersDto>>(rawdata);
            return await Task.FromResult(partners);
        }

        public async Task<bool> PostPartnerAsync(string path,Partner resource)
        {
            var data = await _httpClient.PostAsJsonAsync(path, resource);
            var success = data.IsSuccessStatusCode;
            return await Task.FromResult(success);
        }

        
    }
}
