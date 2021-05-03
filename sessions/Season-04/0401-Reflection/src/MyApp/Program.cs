using System;
using System.Reflection;

namespace MyApp
{

    class Program
    {
        static void Main(string[] args)
        {

            Demo8();

        }

        static void Demo1() {

            // Let's inspect the FritzHat
            var type = typeof(FritzHat);

            Console.WriteLine("A FritzHat is comprised of:");

            foreach (var item in type.GetProperties())
            {
                Console.WriteLine($"{item.Name}: {item.PropertyType.Name}");
            }

        }

        static void Demo2() {

            // Let's look at a running instance
            var blazorHat = new FritzHat() {
                Id=1,
                Name="Blazor Hat",
                AcquiredDate = new DateTime(2019, 5, 1),
                Theme = Theme.Tech
            };

            var type = blazorHat.GetType();

            Console.WriteLine("The BlazorHat is");

            foreach (var item in type.GetProperties())
            {
                Console.WriteLine($"{item.Name}: {item.PropertyType.Name} -- Value: {item.GetValue(blazorHat)}");
            }


        }

        static void Demo3() {

            // Let's look at a running instance
            var blazorHat = new FritzHat() {
                Id=1,
                Name="Blazor Hat",
                AcquiredDate = new DateTime(2019, 5, 1),
                Theme = Theme.Tech
            };

            // blazorHat.Name = "Foo";

            var type = blazorHat.GetType();

            Console.WriteLine("The BlazorHat is");

            foreach (var item in type.GetProperties())
            {
                Console.WriteLine($"{item.Name}: {item.PropertyType.Name} -- Value: {item.GetValue(blazorHat)}");
            }


        }

        static void Demo4() {

            // Let's inspect the FritzHat
            var type = typeof(FritzHat);

            Console.WriteLine("A FritzHat has these methods:");

            foreach (var item in type.GetMethods())
            {

                var scope = item.IsPublic ? "public" : item.IsPrivate ? "private" : item.IsAssembly ? "internal" : "protected";

                Console.WriteLine($"{scope} {item.Name}: {item.ReturnType.Name}");
                if (item.GetParameters().Length > 0) {

                    Console.WriteLine("   With parameters: ");
                    foreach (var parm in item.GetParameters())
                    {
                        Console.WriteLine($"      {parm.Name}: {parm.ParameterType.Name}");
                    }

                }
            }

        }

        static void Demo5() {

            // Let's look at base types of FritzHat
            var type = typeof(FritzHat);

            Console.WriteLine("A FritzHat inherits: ");

            var baseType = type.BaseType;
            var indent = "--";
            while (baseType.Name != "Object") {

                Console.WriteLine($"{indent} {baseType.Name}");
                baseType = baseType.BaseType;
                indent = indent + "--";
            }
            Console.WriteLine($"{indent} {baseType.Name}");

        }

        static void Demo6() {

            // Let's look at the Shelf<T> type
            var type = typeof(Shelf<FritzHat>);

            Console.WriteLine("A Shelf<FritzHat> is: ");

            Console.WriteLine($"IsGeneric: {type.IsGenericType}");
            Console.WriteLine($"GenericType: {type.GenericTypeArguments[0].Name}");

        }

        static void Demo7() {

            // let's look at interfaces of the FritzHat
            var type = typeof(FritzHat);

            Console.WriteLine("Interfaces of the FritzHat:");

            foreach (var item in type.GetInterfaces())
            {
                Console.WriteLine($"{item.Name}");             
            }

        }

        static void Demo8() {

            // let's look at interfaces of the FritzHat
            var type = typeof(FritzHat);

            Console.WriteLine("Attributes of the FritzHat:");

            foreach (var item in type.CustomAttributes)
            {
                Console.WriteLine($"{item.AttributeType.Name}");             
            }

        }

    }
}
