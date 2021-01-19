using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class XTEC_DigitalContext : DbContext
    {
        public XTEC_DigitalContext()
        {
        }

        public XTEC_DigitalContext(DbContextOptions<XTEC_DigitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Archivo> Archivos { get; set; }
        public virtual DbSet<Carpetum> Carpeta { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Entregable> Entregables { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual DbSet<EstudianteGrupo> EstudianteGrupos { get; set; }
        public virtual DbSet<Evaluacion> Evaluacions { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<MatriculadosV> MatriculadosVs { get; set; }
        public virtual DbSet<NotasEstudianteV> NotasEstudianteVs { get; set; }
        public virtual DbSet<NotasProfesorV> NotasProfesorVs { get; set; }
        public virtual DbSet<Noticium> Noticia { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<ProfesorCurso> ProfesorCursos { get; set; }
        public virtual DbSet<Rubro> Rubros { get; set; }
        public virtual DbSet<SubGrupo> SubGrupos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:xtec-digital.database.windows.net,1433;Initial Catalog=XTEC_Digital;Persist Security Info=False;User ID=RoJo_Savs;Password=:EbmV276}+Lu*5fZ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.ToTable("ARCHIVO");

                entity.Property(e => e.ArchivoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("archivo_id");

                entity.Property(e => e.ArchivoPdf)
                    .IsUnicode(false)
                    .HasColumnName("archivo_pdf");

                entity.Property(e => e.CarpetaId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("carpeta_id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tamanio).HasColumnName("tamanio");

                entity.HasOne(d => d.Carpeta)
                    .WithMany(p => p.Archivos)
                    .HasForeignKey(d => d.CarpetaId)
                    .HasConstraintName("ARCHIVO_CARPETA_FK");
            });

            modelBuilder.Entity<Carpetum>(entity =>
            {
                entity.HasKey(e => e.CarpetaId)
                    .HasName("PK__CARPETA__05E0DB8E93DDCAC9");

                entity.ToTable("CARPETA");

                entity.Property(e => e.CarpetaId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("carpeta_id");

                entity.Property(e => e.GrupoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("grupo_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.RutaUrl)
                    .IsUnicode(false)
                    .HasColumnName("ruta_url");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Carpeta)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("CARPETA_GRUPO_FK");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__CURSO__40F9A20743037337");

                entity.ToTable("CURSO");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Carrera)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("carrera");

                entity.Property(e => e.Creditos).HasColumnName("creditos");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Entregable>(entity =>
            {
                entity.ToTable("ENTREGABLE");

                entity.Property(e => e.EntregableId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("entregable_id");

                entity.Property(e => e.ArchivoEntregable)
                    .IsUnicode(false)
                    .HasColumnName("archivo_entregable");

                entity.Property(e => e.ArchivoRetroalimentacion)
                    .IsUnicode(false)
                    .HasColumnName("archivo_retroalimentacion");

                entity.Property(e => e.EvaluacionId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("evaluacion_id");

                entity.Property(e => e.Evaluado).HasColumnName("evaluado");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.Property(e => e.Observaciones)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.Publico).HasColumnName("publico");

                entity.HasOne(d => d.Evaluacion)
                    .WithMany(p => p.Entregables)
                    .HasForeignKey(d => d.EvaluacionId)
                    .HasConstraintName("ENTREGABLE_EVALUACION_FK");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Carnet)
                    .HasName("PK__ESTUDIAN__4CDEAA6F01705974");

                entity.ToTable("ESTUDIANTE");

                entity.Property(e => e.Carnet)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("carnet");
            });

            modelBuilder.Entity<EstudianteCurso>(entity =>
            {
                entity.HasKey(e => new { e.EstudianteId, e.CursoId })
                    .HasName("PK__ESTUDIAN__B7EEB3FB55191FC4");

                entity.ToTable("ESTUDIANTE_CURSO");

                entity.Property(e => e.EstudianteId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estudiante_id");

                entity.Property(e => e.CursoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("curso_id");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.EstudianteCursos)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ESTUDIANTE_CURSO_A_CURSO_FK");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.EstudianteCursos)
                    .HasForeignKey(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ESTUDIANTE_CURSO_A_ESTUDIANTE_FK");
            });

            modelBuilder.Entity<EstudianteGrupo>(entity =>
            {
                entity.HasKey(e => new { e.EstudianteId, e.GrupoId })
                    .HasName("PK__ESTUDIAN__AB3F17F75EDA795F");

                entity.ToTable("ESTUDIANTE_GRUPO");

                entity.Property(e => e.EstudianteId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estudiante_id");

                entity.Property(e => e.GrupoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("grupo_id");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.EstudianteGrupos)
                    .HasForeignKey(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ESTUDIANTE_GRUPO_A_ESTUDIANTE_FK");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.EstudianteGrupos)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ESTUDIANTE_GRUPO_A_GRUPO_FK");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.ToTable("EVALUACION");

                entity.Property(e => e.EvaluacionId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("evaluacion_id");

                entity.Property(e => e.EspecificacionArchivo)
                    .IsUnicode(false)
                    .HasColumnName("especificacion_archivo");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("date")
                    .HasColumnName("fecha_entrega");

                entity.Property(e => e.GrupalIndividual).HasColumnName("grupal_individual");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

                entity.Property(e => e.RubroId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("rubro_id");

                entity.HasOne(d => d.Rubro)
                    .WithMany(p => p.Evaluacions)
                    .HasForeignKey(d => d.RubroId)
                    .HasConstraintName("EVALUACION_RUBROS_FK");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("GRUPO");

                entity.Property(e => e.GrupoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("grupo_id");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.Cupo).HasColumnName("cupo");

                entity.Property(e => e.CursoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("curso_id");

                entity.Property(e => e.Matriculados).HasColumnName("matriculados");

                entity.Property(e => e.NumeroGrupo).HasColumnName("numero_grupo");

                entity.Property(e => e.Periodo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("periodo")
                    .IsFixedLength(true);

                entity.Property(e => e.ProfesorId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("profesor_id");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.CursoId)
                    .HasConstraintName("GRUPO_CURSO_FK");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("GRUPO_PROFESOR_FK");
            });

            modelBuilder.Entity<MatriculadosV>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MatriculadosV");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.EstudianteId)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estudiante_id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<NotasEstudianteV>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NotasEstudianteV");

                entity.Property(e => e.Carnet)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDeEvaluacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rubro)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NotasProfesorV>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NotasProfesorV");

                entity.Property(e => e.Carnet)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDeEvaluacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rubro)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Noticium>(entity =>
            {
                entity.HasKey(e => e.NoticiaId)
                    .HasName("PK__NOTICIA__4B568A6C431C0558");

                entity.ToTable("NOTICIA");

                entity.Property(e => e.NoticiaId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("noticia_id");

                entity.Property(e => e.Autor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("autor");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.GrupoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("grupo_id");

                entity.Property(e => e.Mensaje)
                    .IsUnicode(false)
                    .HasColumnName("mensaje");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("NOTICIA_GRUPO_FK");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__PROFESOR__415B7BE4DE4948EF");

                entity.ToTable("PROFESOR");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cedula");
            });

            modelBuilder.Entity<ProfesorCurso>(entity =>
            {
                entity.HasKey(e => new { e.ProfesorId, e.CursoId })
                    .HasName("PK__PROFESOR__51E795552BFF47B8");

                entity.ToTable("PROFESOR_CURSO");

                entity.Property(e => e.ProfesorId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("profesor_id");

                entity.Property(e => e.CursoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("curso_id");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.ProfesorCursos)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROFESOR_CURSO_A_CURSO_FK");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.ProfesorCursos)
                    .HasForeignKey(d => d.ProfesorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROFESOR_CURSO_A_PROFESOR_FK");
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.ToTable("RUBROS");

                entity.Property(e => e.RubroId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("rubro_id");

                entity.Property(e => e.GrupoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("grupo_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Rubros)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("RUBROS_GRUPO_FK");
            });

            modelBuilder.Entity<SubGrupo>(entity =>
            {
                entity.HasKey(e => new { e.SubGrupoId, e.EstudianteId, e.GrupoId, e.EntregableId })
                    .HasName("PK__SUB_GRUP__CD9093238E2F726B");

                entity.ToTable("SUB_GRUPO");

                entity.Property(e => e.SubGrupoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("sub_grupo_id");

                entity.Property(e => e.EstudianteId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estudiante_id");

                entity.Property(e => e.GrupoId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("grupo_id");

                entity.Property(e => e.EntregableId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("entregable_id");

                entity.HasOne(d => d.Entregable)
                    .WithMany(p => p.SubGrupos)
                    .HasForeignKey(d => d.EntregableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SUB_GRUPO_ENTREGABLE_FK");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.SubGrupos)
                    .HasForeignKey(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SUB_GRUPO_ESTUDIANTE_FK");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.SubGrupos)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SUB_GRUPO_A_GRUPO_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
