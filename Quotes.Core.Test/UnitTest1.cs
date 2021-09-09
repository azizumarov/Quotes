using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Quotes.Core.Test.Mocks;

namespace Quotes.Core.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SearchByCategoryAsync()
        {
            var quotesRepo = new QuotesRepositoryMock();
            var service = new QuotesService(quotesRepo);

            var result = await service.GetQuotesAsync(null, null, "", "Category");

            Assert.AreEqual(result.Count(), 3);

        }
    }
}