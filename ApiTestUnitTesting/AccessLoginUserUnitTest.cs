using ApiTestUnitTesting.MockDependicies;
using ClassLibraryDomain.UsesCases;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters;
using Xunit.Priority;

namespace ApiTestUnitTesting
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class AccessLoginUserUnitTest
    {
        private readonly AccessController _accessController;

        public AccessLoginUserUnitTest()
        {
            _accessController = new AccessController(new ConfigurationDummy(), 
                MapperTotalSingleton.GetMapper(), 
                new UserAccessUseCase(new UserAccessPersistenceAdapter(new AudioStoreDbContext(), MapperTotalSingleton.GetMapper())));
        }

        [Fact, Priority(-2)]
        public async Task LoginUserGettingTokenSuccess()
        {
            var result = await _accessController.UserLoginToken("egomez", "54001990");

            Assert.True(result.Status);
            Assert.NotEqual(result.Data.Token, string.Empty);
        }

        [Fact, Priority(-1)]
        public async Task LoginUserGettingTokenFail()
        {
            var result = await _accessController.UserLoginToken("egomez", "5400");

            Assert.False(result.Status);
            Assert.Equal(result.Data.Token, string.Empty);
        }
    }
}