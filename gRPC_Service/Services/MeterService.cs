using Grpc.Core;
using System.Linq.Expressions;

namespace gRPC_Service.Services
{
    public class MeterService : MeterUsageService.MeterUsageServiceBase
    {

        public override async Task
           GetMeterData(Request request,
           IServerStreamWriter<MeterUsageDataModel> responseStream, ServerCallContext context)
        {
            try
            { 
            using var reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "meterusage.csv")); // Space complexity O(K)
                string line; bool isFirstLine = true;
                while ((line = reader.ReadLine()) != null)
                {
                    var pieces = line.Split(',');
                    var _model = new MeterUsageDataModel();

                    try
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }

                        // NOTE: committed to avoid unnecessary type casting for swagger and UI,
                        //_model.Time = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime
                        //   ((DateTime.TryParse(pieces[0], out DateTime _dateShip) ? _dateShip : DateTime.MinValue).ToUniversalTime());

                        _model.Time = pieces[0];
                        _model.MeterUsage = float.TryParse(pieces[1], out float _unitCost) ? _unitCost : 0; 

                        await responseStream.WriteAsync(_model); // Timeseries data
                    }
                    catch (Exception ex)
                    {
                        throw new RpcException(new Status(StatusCode.Internal, ex.ToString()));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}