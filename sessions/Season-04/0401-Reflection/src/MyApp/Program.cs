using System;
using System.Diagnostics;
using System.Reflection;
using BaseLib;

namespace MyApp
{

    class Program
    {
        static void Main(string[] args)
        {

            Demo9();

        }

        static void Demo1() {

            // Let's inspect the FritzHat
            var type = typeof(FritzHat);

            Console.WriteLine($"A {nameof(FritzHat)} is comprised of:");

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

            //blazorHat.Name = "Foo";

            var type = blazorHat.GetType();
            type.GetProperty("Name").SetValue(blazorHat, "djsqrd047's hat");

            Console.WriteLine("The BlazorHat is");

            foreach (var item in type.GetProperties())
            {
                Console.WriteLine($"{item.Name}: {item.PropertyType.Name} -- Value: {item.GetValue(blazorHat)}");
            }


        }

        static void Demo4() {

            var sw = Stopwatch.StartNew();

            // Let's inspect the FritzHat
            var type = typeof(FritzHat);

            Console.WriteLine($"typeof took {sw.ElapsedMilliseconds}ms");

            Console.WriteLine("A FritzHat has these methods:");

            sw.Restart();
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
            Console.WriteLine($"Inspecting methods took {sw.ElapsedMilliseconds}ms");

        }

        static void Demo5() {

            // Let's look at base types of FritzHat
            var type = typeof(FritzHat);

            Console.WriteLine("A FritzHat inherits: ");

            var baseType = type.BaseType;
            var indent = "--";
            while (baseType != null) {

                Console.WriteLine($"{indent} {baseType.Name}");
                baseType = baseType.BaseType;
                indent = indent + "--";
            }

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

            var type = typeof(FritzHat);

            Console.WriteLine("Attributes of the FritzHat:");

            foreach (var item in type.CustomAttributes)
            {
                Console.WriteLine($"{item.AttributeType.Name}");

                foreach (var arg in item.NamedArguments)
                {
                    Console.WriteLine($"{arg.MemberName}: {arg.TypedValue}");

                }

            }

        }

        static void Demo8a() {

            var fritzHatType = Assembly.GetExecutingAssembly().GetType("MyApp.FritzHat");

            var myHat = (IHat)Activator.CreateInstance(fritzHatType);

            myHat.Name = "Fritz's Dynamic Hat";

            Console.WriteLine($"MyHat is a: {myHat.GetType().Name}");

            var type = myHat.GetType();

            Console.WriteLine("The created hat is");

            foreach (var item in type.GetProperties())
            {
                Console.WriteLine($"{item.Name}: {item.PropertyType.Name} -- Value: {item.GetValue(myHat)}");
            }

        }

        static void Demo9() {

            // Let's work with the Assembly directly
            var asm = Assembly.LoadFile($"/Users/jfritz/dev/csharp_with_csharpfritz/sessions/Season-04/0401-Reflection/src/MyLib/bin/Debug/net5.0/MyLib.dll");

            foreach (var type in asm.GetTypes())
            {
                Console.WriteLine($"Found type: {type.Name}");
            }

            var contactType = asm.GetType("MyLib.Contact");

            var myContact = Activator.CreateInstance(contactType) as IContact;
            myContact.GivenName = "Jeff";
            myContact.SurName = "Fritz";
            myContact.Age = 31;
            // contactType.GetProperty("GivenName").SetValue(myContact, "Jeff");
            // contactType.GetProperty("SurName").SetValue(myContact, "Fritz");
            // contactType.GetProperty("Age").SetValue(myContact, 29);

            foreach (var item in contactType.GetProperties())
            {
                Console.WriteLine($"{item.Name}: {item.PropertyType.Name} -- Value: {item.GetValue(myContact)}");
            }


        }

    }
}
