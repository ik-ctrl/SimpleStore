using SimpleStore.Database;

namespace SimpleStore.Models.Misc.DbInitializers
{
    interface  IInitializer
    {
        void Initialize(StoreContext context);
    }
}
