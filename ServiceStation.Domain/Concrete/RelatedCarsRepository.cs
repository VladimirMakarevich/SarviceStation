using ServiceStation.Domain.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Concrete
{
    public partial class EfRepository
    {
        public IQueryable<RelatedCars> RelatedCars
        {
            get
            {
                return db.RelatedCarsi;
            }
        }

        public async Task<string> AddCarAsync(RelatedCars model)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.RelatedCarsi.Add(model);
                    await db.SaveChangesAsync();

                    contextDb.Commit();
                }
                catch (System.Exception ex)
                {
                    contextDb.Rollback();
                    string src = String.Format("error when adding a new entry: Message: {0}, \n Source: {1}," +
                        "\n Stack Trace: {2}, \n Inner Exception: {3}.",
                        ex.Message, ex.Source, ex.StackTrace, ex.InnerException);
                    return src;
                }
            }
            return null;
        }
    }
}
