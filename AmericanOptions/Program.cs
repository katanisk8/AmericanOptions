using AmericanOptions.ClickHelpers;
using AmericanOptions.Helpers;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;
using MathNet.Numerics.Distributions;
using System;
using System.Windows.Forms;
using AmericanOptions.Validations;
using AmericanOptions.Windows;
using Unity;
using Unity.Injection;
using System.ComponentModel;

namespace AmericanOptions
{
   internal static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      private static void Main()
      {
         UnityContainer container = new UnityContainer();

         container.RegisterType<IUnivariateDistribution, Normal>(new InjectionConstructor());
         container.RegisterType<IIntegralPoints, IntegralPoints>();
         container.RegisterType<IBtCalculator, BtCalculator>();
         container.RegisterType<IBtIntegralFunction, BtIntegralFunction>();
         container.RegisterType<IAmercianPut, AmercianPut>();
         container.RegisterType<IEuropeanPut, EuropeanPut>();
         container.RegisterType<IPutIntegralFunction, PutIntegralFunction>();
         container.RegisterType<ICalculator, Calculator>();
         container.RegisterType<IInputsValidator, InputsValidator>();
         container.RegisterType<ICleaner, Cleaner>();
         container.RegisterType<IMemoryMeasurer, MemoryMeasurer>();
         container.RegisterType<BackgroundWorker, BackgroundWorker>();
         container.RegisterType<IContainerControl, MainForm>();

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         Form form = container.Resolve<IContainerControl>() as Form;

         Application.Run(form);
         Application.Exit();
      }
   }
}
