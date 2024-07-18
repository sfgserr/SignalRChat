using Application.Contracts;
using Application.Groups.Commands.CreateGroup;
using Application.Groups.Queries;
using Application.Groups.Queries.GetUserGroups;
using IntegrationTests.SeedWork;
using IntegrationTests.SeedWork.Testing;

namespace IntegrationTests.CreateGroupCommandTests
{
    public class CreateGroupCommandTests : Sut
    {
        [Fact]
        public async Task CreateGroupCommand_Executed_Successfully()
        {
            var result = await Test(async () =>
            {
                await AppModule.ExecuteCommand(new CreateGroupCommand("Group", "Default"));

                await AssertEventually(10000, new GetCreatedGroupsTest(AppModule));
            });

            Assert.True(result.IsSuccessfully);
        }
    }

    public class GetCreatedGroupsTest(IAppModule appModule) : IProbe
    {
        private readonly IAppModule _appModule = appModule;

        private IList<GroupDto>? _groups;    

        public bool IsSatisfied()
        {
            return _groups is not null && _groups.Count > 0;
        }

        public async Task SampleAsync()
        {
            _groups = await _appModule.Query<GetUserGroupsQuery, IList<GroupDto>>(new GetUserGroupsQuery());
        }

        public string DescribeFailureTo()
        {
            return "Group wasn't created";
        }
    }
}
