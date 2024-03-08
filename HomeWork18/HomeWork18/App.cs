using HomeWork18.Services.Abstracts;

namespace HomeWork18
{
    internal class App
    {
        private readonly IUserService _userService;

        public App(IUserService userService)
        {
            _userService = userService;
        }

        public async Task StartUp()
        {
            var users = await _userService.GetListUsersAsync(2);

            var user = await _userService.GetUserAsync(7);

            user = await _userService.GetUserAsync(23);

            var source = await _userService.GetResourceAsync(1);

            var sources = await _userService.GetListResourcesAsync();

            source = await _userService.GetResourceAsync(23);

            var createUser = await _userService.CreateUser("morpheus", "leader");

            createUser.Job = "zion resident";

            var updateUser = await _userService.UpdateUserPutAsync(createUser);

            var updatePath = await _userService.UpdateUserPathAsync(createUser);

            var deleteUnit = await _userService.DeleteUser(createUser.Id);

            var register = await _userService.RegisterationAsync("eve.holt@reqres.in", "pistol");

            register = await _userService.RegisterationAsync("sydney@fife");

            var login = await _userService.LoginAsync("eve.holt@reqres.in", "cityslicka");

            login = await _userService.LoginAsync("peter@klaven");

            var delaylist = await _userService.GetDelayAsync(3);
        }
    }
}
