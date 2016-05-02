using System.Data.Entity.ModelConfiguration;

namespace Project.Data.Mapping
{
    public abstract class BNAEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected BNAEntityTypeConfiguration()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }
    }
}
