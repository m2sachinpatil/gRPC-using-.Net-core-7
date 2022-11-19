using static System.Net.Mime.MediaTypeNames;

namespace gRPC_Client.Entity
{
    /// <summary>
    /// Meter usage entity
    /// </summary>
    public class MeterUsageEntity
    {
        /// <summary>
        /// Get Time data
        /// </summary>
        public string? Time { get; set; }

        /// <summary>
        /// Get Meter updage 
        /// </summary>
        public float MeterUsage { get; set; }

        public MeterUsageEntity()
        {
            MeterUsage = 00;
        }
    }
}
