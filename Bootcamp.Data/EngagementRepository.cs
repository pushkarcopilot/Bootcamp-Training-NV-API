﻿using AutoMapper;
using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;
using static Bootcamp.Data.Enums.Masters;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bootcamp.Data
{
    public class EngagementRepository : IEngagementRepository
    {
        private readonly EngagementDbContext _dbContext;

        public EngagementRepository(EngagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Engagement>> GetAllEngagements()
        {
            if (_dbContext.Engagements == null)
            {
                return null; 
            }

            return await _dbContext.Engagements.ToListAsync();
        }
        public void AddEngagement(string clientName, DateTimeOffset auditStartDate, DateTimeOffset auditEndDate, int countryId, List<int> auditors, AuditTypeValue auditTypeId, EngagementStatusValue engagementStatusId)
        {
            var newEngagement = new Engagement()
            {
                ClientName = clientName,
                AuditStartDate = auditStartDate,
                AuditEndDate = auditEndDate,
                CountryId = countryId,
                Auditors = auditors,
                AuditTypeId = auditTypeId,
                StatusId = engagementStatusId,
            };

            _dbContext.Engagements.Add(newEngagement);

            _dbContext.SaveChanges();
        }

        public void AddBackupSettings(string backupFrequency)
        {
            var existingEntity = _dbContext.EngagementSettings
                                .SingleOrDefault(e => e.KeyName == "BackupFrequency");

            if (existingEntity != null)
            {
                existingEntity.ValueVarChar = backupFrequency;
            }
            else
            {
                var newSetting = new EngagementSetting
                {
                    KeyName = "BackupFrequency",
                    DataType = "String",
                    ValueVarChar = backupFrequency,
                };

                _dbContext.EngagementSettings.Add(newSetting);
            }

            _dbContext.SaveChanges();
        }

        public string? GetEngagementBackupFrequency()
        {
            var engagementSetting = (from e in _dbContext.EngagementSettings
                                     where e.KeyName == "BackupFrequency"
                                     select new
                                     {
                                         Value = e.ValueVarChar,
                                     }).FirstOrDefault();

            return engagementSetting?.Value;
        }

        public EngagementBackup? GetEngagementBackupById(int id)
        {
            return _dbContext.EngagementBackups.SingleOrDefault(e => e.EngagementId == id);
        }

        public void PerformEngagementBackup(EngagementBackup? backup, bool shouldUpdate)
        {
            if (shouldUpdate)
            {
                _dbContext.Update(backup);
            }
            else
            {
                _dbContext.Add(backup);
            }

            _dbContext.SaveChanges();
        }
    }
}

