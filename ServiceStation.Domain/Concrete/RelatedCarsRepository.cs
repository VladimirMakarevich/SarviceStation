using ServiceStation.Domain.Model;
using System;
using System.Data.Entity;
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

        #region AddCarAsync
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
        #endregion

        #region DeleteCarAsync
        public async Task<string> DeleteCarAsync(RelatedCars model)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.RelatedCarsi.Remove(model);
                    await db.SaveChangesAsync();

                    contextDb.Commit();
                }
                catch (Exception ex)
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
        #endregion

        #region ModifeidCarAsync
        public async Task<string> ModifeidCarAsync(RelatedCars model)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.Entry(model).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    contextDb.Commit();
                }
                catch (Exception ex)
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
        #endregion

        #region CheckFreeCarAsync
        public async Task<RelatedCars> CheckFreeCarAsync(RelatedCars model)
        {
            try
            {
                var result = await db.RelatedCarsi.FirstOrDefaultAsync(m => m.Make == model.Make && m.Models == model.Models && m.Year == model.Year);

                if (result != null)
                {
                    return result;
                }
            }
            catch (System.Exception)
            {
                return null;
            }
            return null;
        }
        #endregion
    }
}
