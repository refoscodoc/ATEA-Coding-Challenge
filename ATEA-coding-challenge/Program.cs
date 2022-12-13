﻿using System.Diagnostics;
using ATEA_coding_challenge.Builder;
using ATEA_coding_challenge.Extensions;
using ATEA_coding_challenge.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.DataAccessLayer;
using Persistence.Repositories;
using Persistence.Repositories.Interfaces;

namespace ATEA_coding_challenge;

static class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length != 2)
        {
            throw new Exception("Please provide exactly two arguments");
        }

        var host = BuilderCreator.CreateDefaultBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<AteaChallengeDbContext>();
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        var businessLayer = new BusinessLayer((IAteaChallengeRepository)host.Services.GetService(typeof(IAteaChallengeRepository)));
        await businessLayer.SaveEntries(args);
        var isContinuing = "";

        while (isContinuing != "N")
        {
            Console.WriteLine("The sum of the two arguments is: " + args.SumFirstTwoArgs());
            Console.WriteLine("===========================");
            Console.WriteLine("What operation would you like to perform? \n1) show latest 5 entries in Db \n2) show entries and details for a specific entry");
            Console.WriteLine("===========================");
            var operation = Convert.ToInt32(Console.ReadLine());

            // if (!Int32.TryParse(input, out var number) || Int32.Parse(input) <= 0 || Int32.Parse(input) >= 4)
            if(operation < 1 || operation > 3)
            {
                Console.WriteLine("The value should be between 1 and 3.");
                continue;
            }
            
            switch (operation)
            {
                case 1: await businessLayer.ReadDbEntries();
                    break;
                case 2: await businessLayer.FindEntryById();
                    break;
                // case 3: businessLayer();
                //     break;
                default: break;
            }
            Console.WriteLine("Continue with another operation? y/n");
            isContinuing = Console.ReadLine()?.ToUpper();
        }
    }
}