using Domain;
using LiteDB;

namespace Data
{
    public static class MapperConfiguration
    {
        public static BsonMapper Configure(
            this BsonMapper mapper)
        {
            #region XPChain Types
            mapper.Entity<Block>()
                      .Id(b => b.Id)
                      .Ignore(b => b.Payload)
                      .Ignore(b => b.ContentForBlockHashing);

            mapper.Entity<Certificate>()
                  .Id(c => c.Id)
                  .Ignore(c => c.Payload);

            mapper.Entity<Employee>()
                  .Id(e => e.Id)
                  .Ignore(e => e.Payload);

            mapper.Entity<Organization>()
                  .Id(o => o.Id)
                  .Ignore(o => o.Payload);

            mapper.Entity<Project>()
                  .Id(p => p.Id);

            mapper.Entity<Resignation>()
                  .Id(o => o.Id)
                  .Ignore(o => o.Payload);

            mapper.Entity<UnitOfWork>()
                  .Id(u => u.Id)
                  .Ignore(u => u.Payload);

            #endregion

            #region Local Types

            mapper.Entity<Host>()
                  .Id(h => h.Id);

            mapper.Entity<LocalCertificate>()
                  .Id(lc => lc.Id)
                  .Ignore(lc => lc.IsReadyToDeploy);

            mapper.Entity<LocalEmployee>()
                  .Id(lo => lo.Id)
                  .Ignore(le => le.IdentificationMessage)
                  .Ignore(le => le.IsReadyToDeploy);

            mapper.Entity<LocalOrganization>()
                  .Id(lo => lo.Id)
                  .Ignore(lo => lo.IsReadyToDeploy);

            mapper.Entity<LocalResignation>()
                  .Id(lc => lc.Id)
                  .Ignore(lc => lc.IsReadyToDeploy);

            mapper.Entity<LocalUnitOfWork>()
                  .Id(lc => lc.Id)
                  .Ignore(lc => lc.IsReadyToDeploy);

            #endregion
            return mapper;
        }
    }
}
