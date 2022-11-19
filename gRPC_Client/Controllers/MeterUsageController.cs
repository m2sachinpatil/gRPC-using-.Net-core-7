using Grpc.Core;
using Grpc.Net.Client;
using gRPC_Client.Entity;
using gRPC_Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace gRPC_Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterUsageController : ControllerBase
    {
        private readonly ILogger<MeterUsageController> _logger;

        public MeterUsageController(ILogger<MeterUsageController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Service Endpoint : Get meter usage data
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetMeterUsage")]
        public async Task<string> GetAsync()
        {
            List<MeterUsageEntity> usageData = new(); /// Space complexity O(N)

            var channel = GrpcChannel.ForAddress(Constant.channelURL);
            try
            {
                var client = new MeterUsageService.MeterUsageServiceClient(channel);

                using var call = client.GetMeterData(new Request { Filters = "" }
                  , deadline: DateTime.UtcNow.AddMinutes(10)
                );

                await foreach (var item in call.ResponseStream.ReadAllAsync())  //  Time complexity O(N)
                {
                    var usage = new MeterUsageEntity
                    {
                        Time = item.Time,
                        MeterUsage = item.MeterUsage,
                    };
                    usageData.Add(usage);
                }
            }
            catch (RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.DeadlineExceeded)
            {
                _logger.LogWarning("Timeout");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return JsonConvert.SerializeObject(usageData);

        }
    }
}