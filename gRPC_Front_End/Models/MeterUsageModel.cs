using NuGet.Packaging.Signing;

namespace gRPC_Front_End.Models
{
    public class MeterUsageModel
    {
        /// <summary>
        /// Get Time data
        /// </summary>
        public string? Time { get; set; }

        /// <summary>
        /// Get Meter updage 
        /// </summary>
        public float MeterUsage { get; set; }
    }
}
