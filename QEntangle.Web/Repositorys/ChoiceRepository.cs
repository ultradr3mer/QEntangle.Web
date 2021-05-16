using Microsoft.EntityFrameworkCore;
using QEntangle.Web.Data;
using QEntangle.Web.Database;
using QEntangle.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QEntangle.Web.Repositorys
{
  public class ChoiceRepository : IChoiceRepository
  {
    #region Fields

    private readonly DatabaseContext databaseContext;

    #endregion Fields

    #region Constructors

    public ChoiceRepository(DatabaseContext databaseContext)
    {
      this.databaseContext = databaseContext;
    }

    #endregion Constructors

    #region Methods

    public async Task Delete(ChoiceEntity entity)
    {
      this.databaseContext.Remove(entity);
      await this.databaseContext.SaveChangesAsync();
    }

    public async Task<ChoiceEntity> Get(Guid choiceId, Guid userId)
    {
      ChoiceEntity data = await (from c in this.databaseContext.Choice
                                 where c.Id == choiceId && c.UserId == userId
                                 select c).FirstOrDefaultAsync();

      return data;
    }

    public async Task<IList<ChoiceData>> GetChoices(Guid userId)
    {
      List<ChoiceEntity> data = await (from c in this.databaseContext.Choice
                                       where c.UserId == userId && c.IsArchived == false
                                       select c).OrderByDescending(o => o.EvaluatedDate ?? o.CreatedDate).ToListAsync();

      List<ChoiceData> result = data.Select(CreateGetDataFromEntity).ToList();

      return result;
    }

    public async Task PostAsync(ChoiceEntity entity)
    {
      await this.databaseContext.AddAsync(entity);
      await this.databaseContext.SaveChangesAsync();
    }

    public async Task SaveChanges()
    {
      await this.databaseContext.SaveChangesAsync();
    }

    private static ChoiceData CreateGetDataFromEntity(ChoiceEntity entity)
    {
      return new ChoiceData()
      {
        Id = entity.Id,
        Name = entity.Name,
        Options = entity.Options.Split(","),
        DefinitiveOption = entity.DefinitiveOption
      };
    }

    #endregion Methods
  }
}