using Packt.Shared;
using static System.Console;
using Microsoft.EntityFrameworkCore;    // include extension method

// namespaces needed for logging
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

WriteLine($"Using {ProjectConstants.DataBaseProvider} database provider.");

QueryingCategories();

// FilteredIncludes();

QueryingProducts();

// Querying EF Core models
static void QueryingCategories()
{
	// Creating an instance of the Northwind class that will manage the database.
	// Database context instances are desifgned for short lifetimes in a unit of work.
	// They should be disposable asap.
	using (Northwind db = new())
	{
		ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
		loggerFactory.AddProvider(new ConsoleLoggerProvider());

		WriteLine("Categories and how many products they have:");

		// a query to get all categories and their related products
		IQueryable<Category>? categories = db.Categories?.Include(category => category.Products);

		if (categories is null)
		{
			WriteLine("No categories found.");
			return;
		}

		// execute query and enumerate results, outputting the name and number
		// of products for each one
		foreach (Category category in categories)
		{
			WriteLine($"{category.CategoryName} has {category.Products.Count} products.");
		}
	}
}

// Filtering included entities

static void FilteredIncludes()
{
	// creating an instance of the Northwind class that will manage the database
	using (Northwind database = new())
	{
		// prompt the user to enter a minimum value for units in stock
		Write("Enter a minumum for units in stock: ");
		string unitsInStock = ReadLine() ?? "10";
		int stock = int.Parse(unitsInStock);	

		// creating a query for categories that have products with that minimum
		// number of units in stock
		IQueryable<Category>? categories = database.Categories?
			.Include(category => category.Products.Where(product => product.Stock >= stock));

        // outputting the name and units in stock for each one
        if (categories is null)
        {
            WriteLine("No categories found.");
            return;
        }

		WriteLine($"ToQueryString: {categories.ToQueryString()}");

        foreach (Category category in categories)
		{
            WriteLine($"{category.CategoryName} has {category.Products.Count} products with a minimum of {stock} units in stock.");

			foreach (Product product in category.Products)
			{
				WriteLine($"	{product.ProductName} has {product.Stock} units in stock.");
			}

			WriteLine();
        }
	}
}

static void QueryingProducts()
{
	using(Northwind database = new())
	{
        ILoggerFactory loggerFactory = database.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());

        WriteLine("Products that cost more than a price, highest at top");
		string? input;
		decimal price;

		// prompt the user for a price for prodcuts, and loop until the 
		// input is a valid value
		do
		{
			Write("Enter a product price: ");
			input = ReadLine();
		} while (!decimal.TryParse(input, out price));

		IQueryable<Product>? products = database.Products?
			.Where(product => product.Cost > price)
			.OrderByDescending(product => product.Cost);

        if (products is null)
        {
            WriteLine("No products found.");
            return;
        }

        foreach (Product product in products)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00} and has {3} in stock.", 
				product.ProductId, 
				product.ProductName, 
				product.Cost, 
				product.Stock);
        }
    }
}