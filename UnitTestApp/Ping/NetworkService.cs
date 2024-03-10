
using System.Net.NetworkInformation;
using UnitTestApp.DNS;

namespace NetWorkUtility.Test.Ping {
    public class NetworkService {
        private readonly IDNS _dns;
        public NetworkService(IDNS dns) {
            _dns = dns;
        }
        public string SendPing() {
            var sent = _dns.SendDNS();
            return sent ? 
                "Success: Ping Sent" :
                "Failed: Ping not sent";
        }

        public long PingTimeout(long endTime, long duration) {
            return endTime + duration;
        }

        public DateTime LastPingDate() {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions() {
            return new() {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IList<PingOptions> GetRescentPings() {
             return new List<PingOptions> {
                 new() { DontFragment = true, Ttl = 1 },
                 new() { DontFragment = false, Ttl = 3 },
                 new() { DontFragment = true, Ttl = 5 },
                 new() { DontFragment = true, Ttl = 7 }
             };
        }
    }
}
