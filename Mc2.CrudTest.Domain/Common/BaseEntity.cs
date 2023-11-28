namespace Mc2.CrudTest.Domain.Common
{
    public class BaseEntity<T> where T : struct
    {
        //[Key]
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }


        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
