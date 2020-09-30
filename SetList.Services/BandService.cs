﻿using SetList.Data;
using SetList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SetList.Services
{
    public class BandService
    {
        private readonly Guid _userId;
        public BandService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBand(BandCreate model)
        {
            var entity =
                new Band()
                {
                    UserId = _userId,
                    Name = model.Name,
                    Members = model.Members,
                    YearsActive = model.YearsActive,
                    NumberOfAlbums = model.NumberOfAlbums
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Bands.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BandListItem> GetBands()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Bands
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new BandListItem
                                {
                                    BandId = e.BandId,
                                    Name = e.Name,
                                    Members = e.Members,
                                    YearsActive = e.YearsActive,
                                    NumberOfAlbums = e.NumberOfAlbums

                                }
                        );
                return query.ToArray();
            }
        }
    }
}