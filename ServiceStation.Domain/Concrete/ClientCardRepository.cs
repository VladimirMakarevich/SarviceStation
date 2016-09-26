using ServiceStation.Domain.Model;
using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ServiceStation.Domain.Concrete
{
    public partial class EfRepository
    {
        public IQueryable<ClientCard> ClientCard
        {
            get
            {
                return db.ClientCardsi;
            }
        }

        #region AddClientCardAsync
        public async Task<string> AddClientCardAsync(ClientCard model)
        {
            using (var contextDb = db.Database.BeginTransaction())
            {
                try
                {
                    db.ClientCardsi.Add(model);
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

        #region CheckClientCardAsync
        public async Task<ClientCard> CheckClientCardAsync(ClientCard model)
        {
            try
            {
                var result = await db.ClientCardsi.OrderBy(m => m.ClientId).FirstOrDefaultAsync(m => m.FirstName == model.FirstName.Trim() &&
                m.LastName == model.LastName.Trim() || m.Phone == model.Phone.Trim() || m.Email == model.Email.Trim());
                if (result!=null)
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
