using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DisplaySweet
{
    internal static class Program
    {
        static void Main()
        {
            var context = new DisplaySweetDbContext();

            var navigation = new Dictionary<string, object>
            {
                {
                    "navigation",
                    context.Navigation.ToList().ToDictionary(n => n.Id, n => new
                    {
                        children = n.Children.ToDictionary(c => c.Id, c => c),
                        index = n.Index,
                        type = n.Type
                    })
                }
            };

            var components = new Dictionary<string, object>
            {
                {
                    "components",
                    context.Component.ToList().ToDictionary(n => n.Id, n => new
                    {
                        data = n.Data == null || !n.Data.Any()
                            ? new { n.CompanyLogo, n.MainImage }
                            : (object)n.Data.ToDictionary(d => d.Id,
                                d => new
                                {
                                    asset = d.Asset,
                                    caption = d.Captions == null || !d.Captions.Any()
                                        ? null
                                        : (object)d.Captions.First(),
                                    styles = d.Styles == null || !d.Styles.Any()
                                        ? null
                                        : (object)d.Styles.ToDictionary(s => s.Id, s => new
                                        {
                                            asset = s.Asset,
                                            name = s.Names == null || !s.Names.Any()
                                                ? null
                                                : (object)s.Names.First()
                                        }),
                                    type = d.Type
                                }),
                        type = n.Type
                    })
                }
            };

            Console.Write(JsonConvert.SerializeObject(navigation, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            }));

            Console.WriteLine();

            Console.Write(JsonConvert.SerializeObject(components, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            }));

            Console.ReadLine();
        }
    }
}
