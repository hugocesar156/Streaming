using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Models;
using Streaming.DAL.StoredProcedures.Models;

namespace Streaming.DAL.Context;

public partial class StreamingDataContext : DbContext
{
    public StreamingDataContext()
    {
    }

    public StreamingDataContext(DbContextOptions<StreamingDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AUDIO> AUDIOs { get; set; }

    public virtual DbSet<CAST> CASTs { get; set; }

    public virtual DbSet<CATALOG_CATEGORY> CATALOG_CATEGORies { get; set; }

    public virtual DbSet<CATALOG_CONTENT> CATALOG_CONTENTs { get; set; }

    public virtual DbSet<CATALOG_REGION> CATALOG_REGIONs { get; set; }

    public virtual DbSet<CATALOG_REGION_ITEM> CATALOG_REGION_ITEMs { get; set; }

    public virtual DbSet<CATEGORY> CATEGORies { get; set; }

    public virtual DbSet<CONTENT> CONTENTs { get; set; }

    public virtual DbSet<FILM> FILMs { get; set; }

    public virtual DbSet<KEEP_WHATCHING> KEEP_WHATCHINGs { get; set; }

    public virtual DbSet<LANGUAGE> LANGUAGEs { get; set; }

    public virtual DbSet<MEDIum> MEDIAs { get; set; }

    public virtual DbSet<MY_LIST> MY_LISTs { get; set; }

    public virtual DbSet<PROFILE> PROFILEs { get; set; }

    public virtual DbSet<RESOLUTION> RESOLUTIONs { get; set; }

    public virtual DbSet<SERIES> SERIES { get; set; }

    public virtual DbSet<SERIES_EPISODE> SERIES_EPISODEs { get; set; }

    public virtual DbSet<SUBTITLE> SUBTITLEs { get; set; }

    public virtual DbSet<USER> USERs { get; set; }

    public virtual DbSet<CATALOG_BY_REGION_PROCEDURE> SP_CATALOG_BY_REGION { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CATALOG_BY_REGION_PROCEDURE>().HasNoKey();

        modelBuilder.Entity<AUDIO>(entity =>
        {
            entity.HasKey(e => e.ID_AUDIO).HasName("PK__AUDIO__F6AA3BDF4AC69657");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.AUDIOs).HasConstraintName("FK__AUDIO__ID_FILM__37703C52");

            entity.HasOne(d => d.ID_LANGUAGENavigation).WithMany(p => p.AUDIOs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AUDIO__ID_LANGUA__367C1819");

            entity.HasOne(d => d.ID_SERIES_EPISODENavigation).WithMany(p => p.AUDIOs).HasConstraintName("FK__AUDIO__ID_SERIES__3864608B");
        });

        modelBuilder.Entity<CAST>(entity =>
        {
            entity.HasKey(e => e.ID_CAST).HasName("PK__CAST__7A168884B2C6BE42");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.CASTs).HasConstraintName("FK__CAST__ID_FILM__68487DD7");

            entity.HasOne(d => d.ID_SERIESNavigation).WithMany(p => p.CASTs).HasConstraintName("FK__CAST__ID_SERIES__693CA210");
        });

        modelBuilder.Entity<CATALOG_CATEGORY>(entity =>
        {
            entity.HasKey(e => e.ID_CATALOG_CATEGORY).HasName("PK__CATALOG___D5E870C7FB7B88C5");

            entity.HasOne(d => d.ID_CATEGORYNavigation).WithMany(p => p.CATALOG_CATEGORies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CATALOG_C__ID_CA__208CD6FA");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.CATALOG_CATEGORies).HasConstraintName("FK__CATALOG_C__ID_FI__2180FB33");

            entity.HasOne(d => d.ID_SERIESNavigation).WithMany(p => p.CATALOG_CATEGORies).HasConstraintName("FK__CATALOG_C__ID_SE__22751F6C");
        });

        modelBuilder.Entity<CATALOG_CONTENT>(entity =>
        {
            entity.HasKey(e => e.ID_CATALOG_CONTENT).HasName("PK__CATALOG___DE099820E0D8199D");

            entity.HasOne(d => d.ID_CONTENTNavigation).WithMany(p => p.CATALOG_CONTENTs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CATALOG_C__ID_CO__25518C17");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.CATALOG_CONTENTs).HasConstraintName("FK__CATALOG_C__ID_FI__2645B050");

            entity.HasOne(d => d.ID_SERIES_EPISODENavigation).WithMany(p => p.CATALOG_CONTENTs).HasConstraintName("FK__CATALOG_C__ID_SE__2739D489");
        });

        modelBuilder.Entity<CATALOG_REGION>(entity =>
        {
            entity.HasKey(e => e.ID_CATALOG_REGION).HasName("PK__CATALOG___8461C381C2816DFE");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.CATALOG_REGIONs).HasConstraintName("FK__CATALOG_R__ID_FI__1BC821DD");

            entity.HasOne(d => d.ID_LANGUAGENavigation).WithMany(p => p.CATALOG_REGIONs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CATALOG_R__ID_LA__1DB06A4F");

            entity.HasOne(d => d.ID_SERIESNavigation).WithMany(p => p.CATALOG_REGIONs).HasConstraintName("FK__CATALOG_R__ID_SE__3E1D39E1");
        });

        modelBuilder.Entity<CATALOG_REGION_ITEM>(entity =>
        {
            entity.HasKey(e => e.ID_CATALOG_REGION_ITEM).HasName("PK__CATALOG___77E0F673F41376AE");

            entity.HasOne(d => d.ID_CATALOG_REGIONNavigation).WithMany(p => p.CATALOG_REGION_ITEMs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CATALOG_R__ID_CA__40F9A68C");

            entity.HasOne(d => d.ID_SERIES_EPISODENavigation).WithMany(p => p.CATALOG_REGION_ITEMs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CATALOG_R__ID_SE__41EDCAC5");
        });

        modelBuilder.Entity<CATEGORY>(entity =>
        {
            entity.HasKey(e => e.ID_CATEGORY).HasName("PK__CATEGORY__EC9B18B785831442");
        });

        modelBuilder.Entity<CONTENT>(entity =>
        {
            entity.HasKey(e => e.ID_CONTENT).HasName("PK__CONTENT__D9FD679E02CE61F8");
        });

        modelBuilder.Entity<FILM>(entity =>
        {
            entity.HasKey(e => e.ID_FILM).HasName("PK__FILM__62C9DB1C2779642A");

            entity.HasOne(d => d.ID_LANGUAGENavigation).WithMany(p => p.FILMs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FILM__ID_LANGUAG__0C85DE4D");
        });

        modelBuilder.Entity<KEEP_WHATCHING>(entity =>
        {
            entity.HasKey(e => e.ID_KEEP_WHATCHING).HasName("PK__KEEP_WHA__07C65FDD31B6987E");

            entity.HasOne(d => d.ID_PROFILENavigation).WithMany(p => p.KEEP_WHATCHINGs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KEEP_WHAT__ID_PR__18EBB532");
        });

        modelBuilder.Entity<LANGUAGE>(entity =>
        {
            entity.HasKey(e => e.ID_LANGUAGE).HasName("PK__LANGUAGE__2CED4A2D7B11DC7E");

            entity.Property(e => e.COUNTRY_CODE).HasDefaultValue("");
        });

        modelBuilder.Entity<MEDIum>(entity =>
        {
            entity.HasKey(e => e.ID_MEDIA).HasName("PK__MEDIA__0395534DEAD27411");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.MEDIa).HasConstraintName("FK__MEDIA__ID_FILM__787EE5A0");

            entity.HasOne(d => d.ID_RESOLUTIONNavigation).WithMany(p => p.MEDIa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MEDIA__ID_RESOLU__282DF8C2");

            entity.HasOne(d => d.ID_SERIES_EPISODENavigation).WithMany(p => p.MEDIa).HasConstraintName("FK__MEDIA__ID_SERIES__797309D9");
        });

        modelBuilder.Entity<MY_LIST>(entity =>
        {
            entity.HasKey(e => e.ID_MY_LIST).HasName("PK__MY_LIST__B98514CBE6676166");

            entity.HasOne(d => d.ID_PROFILENavigation).WithMany(p => p.MY_LISTs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MY_LIST__ID_PROF__4E88ABD4");
        });

        modelBuilder.Entity<PROFILE>(entity =>
        {
            entity.HasKey(e => e.ID_PROFILE).HasName("PK__PROFILE__0DB303E0F5A9DDD4");

            entity.HasOne(d => d.ID_USERNavigation).WithMany(p => p.PROFILEs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PROFILE__ID_USER__4BAC3F29");
        });

        modelBuilder.Entity<RESOLUTION>(entity =>
        {
            entity.HasKey(e => e.ID_RESOLUTION).HasName("PK__RESOLUTI__F00FB2927C632FBC");
        });

        modelBuilder.Entity<SERIES>(entity =>
        {
            entity.HasKey(e => e.ID_SERIES).HasName("PK__SERIES__3DCEE9629CDC0744");

            entity.HasOne(d => d.ID_LANGUAGENavigation).WithMany(p => p.SERIES)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERIES__ID_LANGU__0D7A0286");
        });

        modelBuilder.Entity<SERIES_EPISODE>(entity =>
        {
            entity.HasKey(e => e.ID_SERIES_EPISODE).HasName("PK__SERIES_E__E7BD1614258B9CA2");

            entity.HasOne(d => d.ID_SERIESNavigation).WithMany(p => p.SERIES_EPISODEs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERIES_EP__ID_SE__45F365D3");
        });

        modelBuilder.Entity<SUBTITLE>(entity =>
        {
            entity.HasKey(e => e.ID_SUBTITLES).HasName("PK__SUBTITLE__6FD21C7C49D4BD24");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.SUBTITLEs).HasConstraintName("FK__SUBTITLES__ID_FI__3C34F16F");

            entity.HasOne(d => d.ID_LANGUAGENavigation).WithMany(p => p.SUBTITLEs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SUBTITLES__ID_LA__3B40CD36");

            entity.HasOne(d => d.ID_SERIES_EPISODENavigation).WithMany(p => p.SUBTITLEs).HasConstraintName("FK__SUBTITLES__ID_SE__3D2915A8");
        });

        modelBuilder.Entity<USER>(entity =>
        {
            entity.HasKey(e => e.ID_USER).HasName("PK__USER__95F48440ADAF4DF9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
