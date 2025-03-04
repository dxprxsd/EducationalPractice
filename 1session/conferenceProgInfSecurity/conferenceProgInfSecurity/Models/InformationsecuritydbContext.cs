using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace conferenceProgInfSecurity.Models;

public partial class InformationsecuritydbContext : DbContext
{
    public InformationsecuritydbContext()
    {
    }

    public InformationsecuritydbContext(DbContextOptions<InformationsecuritydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Jury> Juries { get; set; }

    public virtual DbSet<Meropriyatie> Meropriyaties { get; set; }

    public virtual DbSet<Meropriyatieandactivity> Meropriyatieandactivities { get; set; }

    public virtual DbSet<Moderator> Moderators { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<Sobitie> Sobities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=informationsecuritydb;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Activitiesid).HasName("activities_pkey");

            entity.ToTable("activities");

            entity.Property(e => e.Activitiesid).HasColumnName("activitiesid");
            entity.Property(e => e.Activitiesname).HasColumnName("activitiesname");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Idcity).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.Idcity).HasColumnName("idcity");
            entity.Property(e => e.Cityimage).HasColumnName("cityimage");
            entity.Property(e => e.Cityname).HasColumnName("cityname");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Idclient).HasName("client_pkey");

            entity.ToTable("client");

            entity.Property(e => e.Idclient).HasColumnName("idclient");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Dob)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dob");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Nameclient)
                .HasMaxLength(100)
                .HasColumnName("nameclient");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymicclient)
                .HasMaxLength(100)
                .HasColumnName("patronymicclient");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Snameclient)
                .HasMaxLength(100)
                .HasColumnName("snameclient");

            entity.HasOne(d => d.Country).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Countryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_countryid_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Genderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_genderid_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Idcountry).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.Property(e => e.Idcountry).HasColumnName("idcountry");
            entity.Property(e => e.Countryname).HasColumnName("countryname");
            entity.Property(e => e.Countrynameeng).HasColumnName("countrynameeng");
            entity.Property(e => e.Firstcode)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("firstcode");
            entity.Property(e => e.Secondcode).HasColumnName("secondcode");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.Iddirections).HasName("directions_pkey");

            entity.ToTable("directions");

            entity.Property(e => e.Iddirections).HasColumnName("iddirections");
            entity.Property(e => e.Directionname).HasColumnName("directionname");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Idgender).HasName("genders_pkey");

            entity.ToTable("genders");

            entity.Property(e => e.Idgender).HasColumnName("idgender");
            entity.Property(e => e.Gendername).HasColumnName("gendername");
        });

        modelBuilder.Entity<Jury>(entity =>
        {
            entity.HasKey(e => e.Juryid).HasName("jury_pkey");

            entity.ToTable("jury");

            entity.Property(e => e.Juryid).HasColumnName("juryid");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Directionsid).HasColumnName("directionsid");
            entity.Property(e => e.Dob)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dob");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Namejury)
                .HasMaxLength(100)
                .HasColumnName("namejury");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymicjury)
                .HasMaxLength(100)
                .HasColumnName("patronymicjury");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Snamejury)
                .HasMaxLength(100)
                .HasColumnName("snamejury");

            entity.HasOne(d => d.Country).WithMany(p => p.Juries)
                .HasForeignKey(d => d.Countryid)
                .HasConstraintName("jury_countryid_fkey");

            entity.HasOne(d => d.Directions).WithMany(p => p.Juries)
                .HasForeignKey(d => d.Directionsid)
                .HasConstraintName("jury_directionsid_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Juries)
                .HasForeignKey(d => d.Genderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jury_genderid_fkey");
        });

        modelBuilder.Entity<Meropriyatie>(entity =>
        {
            entity.HasKey(e => e.Meropriyatieid).HasName("meropriyatie_pkey");

            entity.ToTable("meropriyatie");

            entity.Property(e => e.Meropriyatieid).HasColumnName("meropriyatieid");
            entity.Property(e => e.Cityid).HasColumnName("cityid");
            entity.Property(e => e.Directionsid).HasColumnName("directionsid");
            entity.Property(e => e.Meropriyatiedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("meropriyatiedate");
            entity.Property(e => e.Meropriyatiename).HasColumnName("meropriyatiename");
            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.HasOne(d => d.City).WithMany(p => p.Meropriyaties)
                .HasForeignKey(d => d.Cityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("meropriyatie_cityid_fkey");

            entity.HasOne(d => d.Directions).WithMany(p => p.Meropriyaties)
                .HasForeignKey(d => d.Directionsid)
                .HasConstraintName("meropriyatie_directions_fk");
        });

        modelBuilder.Entity<Meropriyatieandactivity>(entity =>
        {
            entity.HasKey(e => e.Meropriyatieandactivitiesid).HasName("meropriyatieandactivities_pkey");

            entity.ToTable("meropriyatieandactivities");

            entity.Property(e => e.Meropriyatieandactivitiesid).HasColumnName("meropriyatieandactivitiesid");
            entity.Property(e => e.Dayscount).HasColumnName("dayscount");
            entity.Property(e => e.Fifthjury).HasColumnName("fifthjury");
            entity.Property(e => e.Firstjury).HasColumnName("firstjury");
            entity.Property(e => e.Fourthjury).HasColumnName("fourthjury");
            entity.Property(e => e.Idactivities).HasColumnName("idactivities");
            entity.Property(e => e.Idmeropriyatie).HasColumnName("idmeropriyatie");
            entity.Property(e => e.Idmoderator).HasColumnName("idmoderator");
            entity.Property(e => e.Numberday).HasColumnName("numberday");
            entity.Property(e => e.Secondjury).HasColumnName("secondjury");
            entity.Property(e => e.Startdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Thirdjury).HasColumnName("thirdjury");
            entity.Property(e => e.Timestart).HasColumnName("timestart");
            entity.Property(e => e.Winnerid).HasColumnName("winnerid");

            entity.HasOne(d => d.FifthjuryNavigation).WithMany(p => p.MeropriyatieandactivityFifthjuryNavigations)
                .HasForeignKey(d => d.Fifthjury)
                .HasConstraintName("meropriyatieandactivities_fifthjury_fkey");

            entity.HasOne(d => d.FirstjuryNavigation).WithMany(p => p.MeropriyatieandactivityFirstjuryNavigations)
                .HasForeignKey(d => d.Firstjury)
                .HasConstraintName("meropriyatieandactivities_firstjury_fkey");

            entity.HasOne(d => d.FourthjuryNavigation).WithMany(p => p.MeropriyatieandactivityFourthjuryNavigations)
                .HasForeignKey(d => d.Fourthjury)
                .HasConstraintName("meropriyatieandactivities_fourthjury_fkey");

            entity.HasOne(d => d.IdactivitiesNavigation).WithMany(p => p.Meropriyatieandactivities)
                .HasForeignKey(d => d.Idactivities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("meropriyatieandactivities_idactivities_fkey");

            entity.HasOne(d => d.IdmeropriyatieNavigation).WithMany(p => p.Meropriyatieandactivities)
                .HasForeignKey(d => d.Idmeropriyatie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("meropriyatieandactivities_idmeropriyatie_fkey");

            entity.HasOne(d => d.IdmoderatorNavigation).WithMany(p => p.Meropriyatieandactivities)
                .HasForeignKey(d => d.Idmoderator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("meropriyatieandactivities_idmoderator_fkey");

            entity.HasOne(d => d.SecondjuryNavigation).WithMany(p => p.MeropriyatieandactivitySecondjuryNavigations)
                .HasForeignKey(d => d.Secondjury)
                .HasConstraintName("meropriyatieandactivities_secondjury_fkey");

            entity.HasOne(d => d.ThirdjuryNavigation).WithMany(p => p.MeropriyatieandactivityThirdjuryNavigations)
                .HasForeignKey(d => d.Thirdjury)
                .HasConstraintName("meropriyatieandactivities_thirdjury_fkey");

            entity.HasOne(d => d.Winner).WithMany(p => p.Meropriyatieandactivities)
                .HasForeignKey(d => d.Winnerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("meropriyatieandactivities_winnerid_fkey");
        });

        modelBuilder.Entity<Moderator>(entity =>
        {
            entity.HasKey(e => e.Moderatorid).HasName("moderators_pkey");

            entity.ToTable("moderators");

            entity.Property(e => e.Moderatorid).HasColumnName("moderatorid");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Directionsid).HasColumnName("directionsid");
            entity.Property(e => e.Dob)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dob");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Namemoderator)
                .HasMaxLength(100)
                .HasColumnName("namemoderator");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymicmoderator)
                .HasMaxLength(100)
                .HasColumnName("patronymicmoderator");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Snamemoderator)
                .HasMaxLength(100)
                .HasColumnName("snamemoderator");
            entity.Property(e => e.Sobitieid).HasColumnName("sobitieid");

            entity.HasOne(d => d.Country).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Countryid)
                .HasConstraintName("moderators_countryid_fkey");

            entity.HasOne(d => d.Directions).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Directionsid)
                .HasConstraintName("moderators_directionsid_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Genderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moderators_genderid_fkey");

            entity.HasOne(d => d.Sobitie).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.Sobitieid)
                .HasConstraintName("moderators_sobitieid_fkey");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.HasKey(e => e.Idorganizer).HasName("organizers_pkey");

            entity.ToTable("organizers");

            entity.Property(e => e.Idorganizer).HasColumnName("idorganizer");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Dob)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dob");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Nameorganizer)
                .HasMaxLength(100)
                .HasColumnName("nameorganizer");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymicorganizer)
                .HasMaxLength(100)
                .HasColumnName("patronymicorganizer");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Snameorganizer)
                .HasMaxLength(100)
                .HasColumnName("snameorganizer");

            entity.HasOne(d => d.Country).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.Countryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizers_countryid_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Organizers)
                .HasForeignKey(d => d.Genderid)
                .HasConstraintName("organizers_genderid_fkey");
        });

        modelBuilder.Entity<Sobitie>(entity =>
        {
            entity.HasKey(e => e.Idsobitie).HasName("sobitie_pkey");

            entity.ToTable("sobitie");

            entity.Property(e => e.Idsobitie).HasColumnName("idsobitie");
            entity.Property(e => e.Sobitiename).HasColumnName("sobitiename");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
