using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetWorkUtility.Test.Ping;
using System.Net.NetworkInformation;
using UnitTestApp.DNS;
using Xunit;

namespace NetworkUtility.Test.PingTests {
    public class NetworkServiceTests {
        private readonly NetworkService _service;
        private readonly IDNS _dns;
 
        public NetworkServiceTests() { 
            //fake dependecies
            _dns = A.Fake<IDNS>();

            //SUT
            _service = new(_dns);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnsString() {
            //Arrange
            A.CallTo(()=>_dns.SendDNS()).Returns(true);

            //Act
            var result = _service.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(5,8,13)]
        public void NetworkService_PingTimeout_ReturnsLong(long endTime, long duration, long expected) {

            //Act
            var result = _service.PingTimeout(endTime, duration);

            //Assert
            result.Should().Be(expected);
            result.Should().BeLessThan(60);
            result.Should().BeGreaterThan(0);
            result.Should().NotBeInRange(-1000, 0);
        }
        
        [Fact]
        public void NetworkService_LastPingDate_ReturnsDate() {
            //Act
            var result = _service.LastPingDate();

            //Assert
            result.Should().BeAfter(31.December(2023));
            result.Should().BeBefore(31.December(2024));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject() {
            //Arrange
            PingOptions expected = new(){ 
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _service.GetPingOptions();

            //Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }
        
        [Fact]
        public void NetworkService_GetRescentPings_ReturnsObject() {
            //Arrange
            PingOptions expected = new(){ 
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _service.GetRescentPings();

            //Assert
            result.Should().BeOfType<List<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(p => p.DontFragment == false);
        }
    }
}