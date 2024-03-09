using HomeWork18.Services.Abstracts;

namespace HomeWork18
{
    internal class App
    {
        private readonly IUserService _userService;
        private readonly IResourseService _resourseService;

        public App(IUserService userService, IResourseService resourseService)
        {
            _userService = userService;
            _resourseService = resourseService;
        }

        public async Task StartUp()
        {
            var users = await _userService.GetUsersAsync(2);

            var user = await _userService.GetUserAsync(7);

            user = await _userService.GetUserAsync(23);

            var source = await _resourseService.GetResourceAsync(2);

            var sources = await _resourseService.GetListResourcesAsync();

            source = await _resourseService.GetResourceAsync(23);

            var createUser = await _userService.CreateEmployeeAsync("morpheus", "leader");

            var updateUser = await _userService.UpdateEmployeeAsync(createUser.Id, "morpheus", "zion resident");

            var updatePath = await _userService.ModifyEmployeeAsync(createUser.Id, "morpheus", "zion resident");

            var deleteEmployee = await _userService.DeleteEmployee(createUser.Id);

            //var register = await _userService.RegisterationAsync("eve.holt@reqres.in", "pistol");

            //register = await _userService.RegisterationAsync("sydney@fife");

            //var login = await _userService.LoginAsync("eve.holt@reqres.in", "cityslicka");

            //login = await _userService.LoginAsync("peter@klaven");

            //var delaylist = await _userService.GetDelayAsync(3);
        }
    }
}
