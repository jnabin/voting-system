using Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace voting_system.Dto
{
    public class CreateCategory
    {
        public string Name { get; set; }

        public static implicit operator Category(CreateCategory category)
        {
            return new Category
            {
                Name = category.Name
            };
        }
    }
}
