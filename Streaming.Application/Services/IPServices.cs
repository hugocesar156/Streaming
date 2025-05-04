using Streaming.Application.Models.Services;
using Streaming.Shared;
using System.Net;
using System.Net.Http.Json;

namespace Streaming.Application.Services
{
    public class IPServices
    {
        public static async Task<AddressByIPResponse> GetAddressByIPAsync(string ipAddress)
        {
            try
            {
                var client = new HttpClient();
                var addressByIP = await client.GetFromJsonAsync<AddressByIPResponse>($"http://ip-api.com/json/{ipAddress}");

                if (addressByIP is not null)
                {
                    return addressByIP;
                }

                throw new StreamingException(HttpStatusCode.InternalServerError, ErrorMessages.InternalServerError, ErrorMessages.AddressIPClient);
            }
            catch (StreamingException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new StreamingException(HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
