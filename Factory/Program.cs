using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
	internal class Program
	{
		//
		static void Main()
		{
			ServiceProvider serviceProvider = new ServiceCollection()
				.AddSingleton<ThingOneFactory>()
				.AddSingleton<ThingTwoFactory>()
				.BuildServiceProvider();

			ThingOneFactory roadLogistics = serviceProvider.GetRequiredService<ThingOneFactory>();
			roadLogistics.DemoProduct();

			ThingTwoFactory seaLogistics = serviceProvider.GetRequiredService<ThingTwoFactory>();
			seaLogistics.DemoProduct();
		}
	}

	internal interface IThingFactory
	{
		IProduct CreateProduct();

		void DemoProduct();
	}

	internal class ThingOneFactory : IThingFactory
	{
		public IProduct CreateProduct() =>
			new ThingOne();

		public void DemoProduct()
		{
			IProduct product = CreateProduct();
			product.Demo();
		}
	}

	internal class ThingTwoFactory : IThingFactory
	{
		public IProduct CreateProduct() =>
			new ThingTwo();

		public void DemoProduct()
		{
			IProduct product = CreateProduct();
			product.Demo();
		}
	}

	internal interface IProduct
	{
		void Demo();
	}

	internal class ThingOne : IProduct
	{
		public void Demo()
		{
            Console.WriteLine($"Demo of {nameof(ThingOne)}");
        }
	}

	internal class ThingTwo : IProduct
	{
		public void Demo()
		{
			Console.WriteLine($"Demo of {nameof(ThingTwo)}");
		}
	}
}
