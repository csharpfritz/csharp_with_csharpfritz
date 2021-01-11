using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using _5_ModelBinding.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace _6_ContentFormatting {

    public class VcardInputFormatter : TextInputFormatter
    {
        public VcardInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(Contact);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context, Encoding effectiveEncoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;

            var logger = serviceProvider.GetRequiredService<ILogger<VcardInputFormatter>>();

            using var reader = new StreamReader(httpContext.Request.Body, effectiveEncoding);
            string nameLine = null;

            try
            {
                await ReadLineAsync("BEGIN:VCARD", reader, context, logger);
                await ReadLineAsync("VERSION:", reader, context, logger);

                nameLine = await ReadLineAsync("N:", reader, context, logger);

                var split = nameLine.Split(";".ToCharArray());
                var contact = new Contact
                {
                    Last = split[0].Substring(2),
                    First = split[1]
                };

                await ReadLineAsync("FN:", reader, context, logger);
                await ReadLineAsync("END:VCARD", reader, context, logger);

                logger.LogInformation("nameLine = {nameLine}", nameLine);

                return await InputFormatterResult.SuccessAsync(contact);
            }
            catch
            {
                logger.LogError("Read failed: nameLine = {nameLine}", nameLine);
                return await InputFormatterResult.FailureAsync();
            }
        }

        private static async Task<string> ReadLineAsync(
            string expectedText, StreamReader reader, InputFormatterContext context,
            ILogger logger)
        {
            var line = await reader.ReadLineAsync();

            if (!line.StartsWith(expectedText))
            {
                var errorMessage = $"Looked for '{expectedText}' and got '{line}'";

                context.ModelState.TryAddModelError(context.ModelName, errorMessage);
                logger.LogError(errorMessage);

                throw new Exception(errorMessage);
            }

            return line;
        }
    }

public class VcardOutputFormatter : TextOutputFormatter
{
    public VcardOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type type)
    {
        return typeof(Contact).IsAssignableFrom(type) ||
            typeof(IEnumerable<Contact>).IsAssignableFrom(type);
    }

    public override async Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var httpContext = context.HttpContext;
        var serviceProvider = httpContext.RequestServices;

        var logger = serviceProvider.GetRequiredService<ILogger<VcardOutputFormatter>>();
        var buffer = new StringBuilder();

        if (context.Object is IEnumerable<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                FormatVcard(buffer, contact, logger);
            }
        }
        else
        {
            FormatVcard(buffer, (Contact)context.Object, logger);
        }

        await httpContext.Response.WriteAsync(buffer.ToString());
    }

    private static void FormatVcard(
        StringBuilder buffer, Contact contact, ILogger logger)
    {
        buffer.AppendLine("BEGIN:VCARD");
        buffer.AppendLine("VERSION:2.1");
        buffer.AppendLine($"N:{contact.Last};{contact.First}");
        buffer.AppendLine($"FN:{contact.First} {contact.Last}");
        buffer.AppendLine($"UID:{contact.id}");
        buffer.AppendLine("END:VCARD");

        logger.LogInformation("Writing {FirstName} {LastName}",
            contact.First, contact.Last);
    }
}
}