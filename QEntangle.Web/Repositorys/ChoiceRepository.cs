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
    private readonly DatabaseContext databaseContext;

    public ChoiceRepository(DatabaseContext databaseContext)
    {
      this.databaseContext = databaseContext;
    }

    public async Task<IList<ChoiceData>> GetChoices()
    {
      List<ChoiceEntity> data = await (from c in this.databaseContext.Choice
                                       select c).ToListAsync();

      var result = data.Select(CreateGetDataFromEntity).ToList();

      return result;
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
  }
}
