using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MooGame.Core;

public class Program
{
   public static void Main()
   {
      var services = ConfigureServices();
      var serviceProvider = services.BuildServiceProvider();
      serviceProvider.GetService<Game>()!.Run();
   }

   private static IServiceCollection ConfigureServices()
   {
      var services = new ServiceCollection();
      services.AddSingleton<IUserInputHandler, UserInputHandler>();
      services.AddSingleton<IGameOutputHandler, GameOutputHandler>();
      services.AddSingleton<IGameLogicHandler, GameLogicHandler>();
      services.AddSingleton<IScoreListHandler, ScoreListHandler>();
      services.AddSingleton<Game>();
      return services;
   }
}


