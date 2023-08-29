using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Infrastructure.Data.Common
{
    public class BaseEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }
    }
}
