using AmericanOptions.Helpers;
using AmericanOptions.OptimalExerciseBoundary;
using AmericanOptions.PutOptions;
using System;
using System.Windows.Forms;
using Unity;

namespace AmericanOptions
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<IIntegralPoints, IntegralPoints>();
            container.RegisterType<INormal, Normal>();
            container.RegisterType<IBtCalculator, BtCalculator>();
            container.RegisterType<IBtIntegralFunction, BtIntegralFunction>();
            container.RegisterType<IAmercianPut, AmercianPut>();
            container.RegisterType<IEuropeanPut, EuropeanPut>();
            container.RegisterType<IPutIntegralFunction, PutIntegralFunction>();
            container.RegisterType<IInputsValidator, InputsValidator>();
            container.RegisterType<ICalculator, Calculator>();

            ICalculator calc = container.Resolve<ICalculator>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(calc));
        }
    }
}
