using WebApi.DbOperations;
using WebApi.Entities;

namespace TestSetup
{    
        public static class Authors
        {
            public static void AddAuthors(this BookStoreDbContext context)
            {
                    context.Authors.AddRange(
                        new Author{ Name= "TestAuthor1"},
                        new Author{ Name= "TestAuthor2" },
                        new Author{ Name= "TestAuthor2"}
                    );
            }
        }
}