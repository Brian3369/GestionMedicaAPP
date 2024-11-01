using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Domain.Entities.System;
using GestionMedicaAPP.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;

namespace GestionMedicaAPP.Persistance.Context
{
    public partial class GestionMedicaContext : DbContext
    {
        public GestionMedicaContext(DbContextOptions<GestionMedicaContext> options) : base(options)
        {

        }

        #region "Appointmets Entities"
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailability { get; set; }
        #endregion

        #region "Insurance Entities"
        public DbSet<InsuranceProviders> InsuranceProvider { get; set; }
        public DbSet<NetworkType> NetwordType { get; set; }
        #endregion

        #region "Medical Entities"
        public DbSet<AvailabilityModes> AvailabilityModes { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
        #endregion

        #region "System Entities"
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        #endregion

        #region "Users Entities"
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patiens { get; set; }
        public DbSet<Users> Users { get; set; }
        #endregion
    }
}
