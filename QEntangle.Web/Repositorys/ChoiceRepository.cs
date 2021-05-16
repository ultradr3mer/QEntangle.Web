using Microsoft.EntityFrameworkCore;
using QEntangle.Web.Data;
using QEntangle.Web.Database;
using QEntangle.Web.Exceptions;
using QEntangle.Web.Interfaces;
using QEntangle.Web.Models;
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

    public async Task<ChoiceEntity> GetChoice(Guid choiceId, Guid userId)
    {
      ChoiceEntity data = await (from c in this.databaseContext.Choice
                                 where c.Id == choiceId && c.UserId == userId
                                 select c).FirstOrDefaultAsync();

      return data;
    }

    public async Task<IList<ChoiceData>> GetChoices(Guid userId)
    {
      List<ChoiceEntity> data = await (from c in this.databaseContext.Choice
                                       where c.UserId == userId
                                       select c).OrderByDescending(o => o.EvaluatedDate ?? o.CreatedDate).ToListAsync();

      var result = data.Select(CreateGetDataFromEntity).ToList();

      return result;
    }

    public async Task PostChoiceAsync(ChoiceEntity entity)
    {
      await databaseContext.AddAsync(entity);
      await databaseContext.SaveChangesAsync();
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

    public async Task SaveChanges()
    {
      await databaseContext.SaveChangesAsync();
    }

    #endregion Methods
  }
}