using HomeWork18.Services.Abstracts;

namespace HomeWork18
{
    internal class App
    {
        private readonly IUserService _userService;
        private readonly IResourseService _resourseService;
        private readonly IAuthenticationService _authenticationService;

        public App(
            IUserService userService,
            IResourseService resourseService,
            IAuthenticationService authenticationService)
        {
            _userService = userService;
            _resourseService = resourseService;
            _authenticationService = authenticationService;
        }

        public async Task StartUp()
        {
            var getUsers = Task.Run(async () => await _userService.GetUsersAsync(2));
            var getUser = Task.Run(async () => await _userService.GetUserAsync(7));
            var getFailedUser = Task.Run(async() => await _userService.GetUserAsync(23));

            var getSource = Task.Run(async () => await _resourseService.GetResourceAsync(2));
            var getSources = Task.Run(async () => await _resourseService.GetListResourcesAsync());
            var getFailedSource = Task.Run(async () => await _resourseService.GetResourceAsync(23));

            var CreateEmployee = Task.Run(async () => await _userService.CreateEmployeeAsync("morpheus", "leader"));
            var updateEmployeePut = Task.Run(async () => await _userService.UpdateEmployeeAsync(2, "morpheus", "zion resident"));
            var modifyEmployeePath = Task.Run(async () => await _userService.ModifyEmployeeAsync(2, "morpheus", "zion resident"));
            var deleteEmployee = Task.Run(async () => await _userService.DeleteEmployee(2));

            var register = Task.Run(async () => await _authenticationService.RegisterAsync("eve.holt@reqres.in", "pistol"));
            var registerFailed = Task.Run(async () => await _authenticationService.RegisterAsync("sydney@fife", null!));
            var login = Task.Run(async () => await _authenticationService.LoginAsync("eve.holt@reqres.in", "cityslicka"));
            var loginFailed = Task.Run(async () => await _authenticationService.LoginAsync("peter@klaven", null!));

            var delaylist = Task.Run(async () => await _userService.GetDelaiesUsersAsync(3));

            var getUsers1 = await getUsers;
            var getUser1 = await getUser;
            var getFailedUser1 = await getFailedUser;

            var getSource1 = await getSource;
            var getSources1 = await getSources;
            var getFailedSource1 = await getFailedSource;

            var CreateEmployee1 = await CreateEmployee;
            var updateEmployeePut1 = await updateEmployeePut;
            var modifyEmployeePath1 = await modifyEmployeePath;
            var deleteEmployee1 = await deleteEmployee;

            var register1 = await register;
            var registerFailed1 = await registerFailed;
            var login1 = await login;
            var loginFailed1 = await loginFailed;

            var delaylist1 = await delaylist;
        }
    }
}
