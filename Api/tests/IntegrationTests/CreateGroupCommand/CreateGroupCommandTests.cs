using Application.Groups.Commands.CreateGroup;
using Application.Groups.Queries;
using Application.Groups.Queries.GetUserGroups;
using IntegrationTests.SeedWork;

namespace IntegrationTests.CreateGroupCommandTests
{
    public class CreateGroupCommandTests : TestBase
    {
        [Fact]
        public async Task CreateGroupCommand_Executed_Successfully()
        {
            BeforeTest();

            await AppModule.ExecuteCommand(new CreateGroupCommand("Group", "Default"));

            var groups = await AppModule.Query<GetUserGroupsQuery, IList<GroupDto>>(new GetUserGroupsQuery());

            AfterTest();

            Assert.True(groups.Count > 0);
        }
    }
}
