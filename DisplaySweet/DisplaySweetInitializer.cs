namespace DisplaySweet
{
    public class DisplaySweetInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DisplaySweetDbContext>
    {
        protected override void Seed(DisplaySweetDbContext context)
        {
            context.Navigation.AddRange(new[]
            {
                new Navigation
                {
                    Id = "2199fb7e-b249-4a22-acab-221a677cee9b",
                    Index = 0,
                    Type = "string"
                },
                new Navigation
                {
                    Id = "6c673c1f-8345-4d5c-9652-cca03d56a3ac",
                    Index = 1,
                    Type = "string"
                }
            });

            context.Child.AddRange(new[]
            {
                new Child
                {
                    Id = "cff20369-bb02-4720-b1e9-8870f54d0073",
                    Index = 0,
                    ParentId = "2199fb7e-b249-4a22-acab-221a677cee9b",
                    Template = "templateString",
                    Type = "typeString",
                    NavigationId = "2199fb7e-b249-4a22-acab-221a677cee9b"
                },
                new Child
                {
                    Id = "c4e14101-9713-463a-b028-deb23c9f38bf",
                    Index = 1,
                    ParentId = "2199fb7e-b249-4a22-acab-221a677cee9b",
                    Template = "templateString",
                    Type = "typeString",
                    NavigationId = "2199fb7e-b249-4a22-acab-221a677cee9b"
                },
                new Child
                {
                    Id = "85c703dd-4887-4e9d-a1b7-14022958860b",
                    Template = "templateString",
                    Type = "typeString",
                    NavigationId = "6c673c1f-8345-4d5c-9652-cca03d56a3ac"
                }
            });

            context.Component.AddRange(new[]
            {
                new Component
                {
                    Id = "cff20369-bb02-4720-b1e9-8870f54d0073",
                    Type = "string"
                },
                new Component
                {
                    Id = "c4e14101-9713-463a-b028-deb23c9f38bf"
                },
                new Component
                {
                    Id = "85c703dd-4887-4e9d-a1b7-14022958860b",
                    CompanyLogo = "urlString",
                    MainImage = "urlString",
                    Type = "string"
                }
            });

            context.Data.AddRange(new[]
            {
                new Data
                {
                    Id = "0",
                    Asset = "urlString",
                    ComponentId = "cff20369-bb02-4720-b1e9-8870f54d0073"
                },
                new Data
                {
                    Id = "1",
                    Asset = "urlString",
                    ComponentId = "cff20369-bb02-4720-b1e9-8870f54d0073"
                },
                new Data
                {
                    Id = "0",
                    Type =  "typeString",
                    ComponentId = "c4e14101-9713-463a-b028-deb23c9f38bf"
                }
            });

            context.Caption.AddRange(new[]
            {
                new Caption
                {
                    Id = "0",
                    Language_0 = "string0",
                    Language_1 = "string0",
                    DataId = "0",
                    ComponentId = "cff20369-bb02-4720-b1e9-8870f54d0073"
                },
                new Caption
                {
                    Id = "1",
                    Language_0 = "string1",
                    Language_1 = "string1",
                    DataId = "1",
                    ComponentId = "cff20369-bb02-4720-b1e9-8870f54d0073"
                }
            });

            context.Style.AddRange(new[]
            {
                new Style
                {
                    Id = "0",
                    Asset = "urlString",
                    DataId = "0",
                    ComponentId = "c4e14101-9713-463a-b028-deb23c9f38bf"
                },
                new Style
                {
                    Id = "1",
                    Asset = "urlString",
                    DataId = "0",
                    ComponentId = "c4e14101-9713-463a-b028-deb23c9f38bf"
                }
            });

            context.Name.AddRange(new[]
            {
                new Name
                {
                    Id = "0",
                    Language_0 = "string0",
                    Language_1 = "string0",
                    StyleId = "0",
                    DataId = "0",
                    ComponentId = "c4e14101-9713-463a-b028-deb23c9f38bf"
                },
                new Name
                {
                    Id = "0",
                    Language_0 = "string1",
                    Language_1 = "string1",
                    StyleId = "1",
                    DataId = "0",
                    ComponentId = "c4e14101-9713-463a-b028-deb23c9f38bf"
                }
            });

            context.SaveChanges();
        }
    }
}
