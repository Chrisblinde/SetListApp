using SetList.Data;
using SetList.Models;
using SetList.Models.Show;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetList.Services
{
    public class ShowService
    {
        private readonly Guid _userId;

        public ShowService (Guid userId)
        {
            _userId = userId;
        }

    public bool CreateShow(ShowCreate model)
        {
            var entity =
                new Show()
                {
                    UserId = _userId,
                    BandName = model.Band,
                    Venue = model.Venue,
                    Location = model.Location,
                    Date = model.Date,
                    SetList = model.SetList

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Shows
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ShowListItem
                                {
                                    ShowId = e.ShowId,
                                    Venue = e.Venue,
                                    Location = e.Location,
                                    Date = e.Date
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
