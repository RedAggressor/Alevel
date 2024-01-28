using Abstracts;
using Models.Enum;
using Services.Abstracts;

namespace HomeWork9
{
    internal class App
    {
        private IAction _action;
        private ILoggerService _logger;

        public App(IAction action, ILoggerService loggerService)
        { 
            _action = action;
            _logger = loggerService;
        }

        public void Run()
        {
            for (int i = 1; i <= 100; i++)
            {
                try
                {
                    int rnt = new Random().Next(0, 4);

                    RunOneOfMethodAction(rnt);
                }
                catch (BusinessException bex)
                {
                    _logger.Log(LogType.Error, $"Action got this custom Exception: {bex}");
                }
                catch (Exception ex) 
                {
                    _logger.Log(LogType.Error, $"Action failed by reason: {ex}");
                }
            }
        }

        private void RunOneOfMethodAction(int number)
        {
            switch (number)
            {
                case 1:
                    {
                        _action.StartMethod();
                        break;
                    }
                case 2:
                    {
                        _action.BusinessException();
                        break;
                    }
                case 3:
                    {
                        _action.ThrowExeption();
                        break;
                    }
            };
        }
    }
}
