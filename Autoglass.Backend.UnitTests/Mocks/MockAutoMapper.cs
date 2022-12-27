using AutoMapper;
using Moq;

namespace Autoglass.Backend.UnitTests.Mocks
{
    public class MockAutoMapper : Mock<IMapper>
    {
        public MockAutoMapper() : base(MockBehavior.Strict) { }

        public MockAutoMapper MockMap<T>(object source, T destination)
        {
            Setup(m => m.Map<T>(source)).Returns(destination);

            return this;
        }
    }
}
