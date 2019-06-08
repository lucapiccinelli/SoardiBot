﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Soardibot;

namespace sbcli
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<SoardiBotStart>(url: $"http://localhost:9090/"))
            {
                Console.ReadLine();
            }
        }
    }
}
