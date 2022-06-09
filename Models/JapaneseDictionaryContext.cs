using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApi.Models
{
    public partial class JapaneseDictionaryContext : DbContext
    {
        public JapaneseDictionaryContext()
        {
        }

        public JapaneseDictionaryContext(DbContextOptions<JapaneseDictionaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Commentary> Commentaries { get; set; } = null!;
        public virtual DbSet<FormAdj> FormAdjs { get; set; } = null!;
        public virtual DbSet<FormVerb> FormVerbs { get; set; } = null!;
        public virtual DbSet<Kanji> Kanjis { get; set; } = null!;
        public virtual DbSet<KanjisFr> KanjisFrs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Word> Words { get; set; } = null!;
        public virtual DbSet<WordsFr> WordsFrs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

                var connectionString = configuration.GetConnectionString("JapBD");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commentary>(entity =>
            {
                entity.ToTable("Commentary");

                entity.Property(e => e.CommentaryId).HasColumnName("commentaryId");

                entity.Property(e => e.Commentary1)
                    .HasColumnType("text")
                    .HasColumnName("commentary");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.WordId).HasColumnName("wordId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Commentaries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_commentary_user");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.Commentaries)
                    .HasForeignKey(d => d.WordId)
                    .HasConstraintName("fk_commentary_word");
            });

            modelBuilder.Entity<FormAdj>(entity =>
            {
                entity.ToTable("FormAdj");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Conditionnel)
                    .HasMaxLength(50)
                    .HasColumnName("conditionnel");

                entity.Property(e => e.ConditionnelPa)
                    .HasMaxLength(50)
                    .HasColumnName("conditionnel_pa");

                entity.Property(e => e.ForNPa)
                    .HasMaxLength(50)
                    .HasColumnName("for_n_pa");

                entity.Property(e => e.ForNPaHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_n_pa_hi");

                entity.Property(e => e.ForNPr)
                    .HasMaxLength(50)
                    .HasColumnName("for_n_pr");

                entity.Property(e => e.ForNPrHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_n_pr_hi");

                entity.Property(e => e.ForPa)
                    .HasMaxLength(50)
                    .HasColumnName("for_pa");

                entity.Property(e => e.ForPaHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_pa_hi");

                entity.Property(e => e.ForPr)
                    .HasMaxLength(50)
                    .HasColumnName("for_pr");

                entity.Property(e => e.ForPrHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_pr_hi");

                entity.Property(e => e.Intentionnelle)
                    .HasMaxLength(50)
                    .HasColumnName("intentionnelle");

                entity.Property(e => e.IntentionnelleHi)
                    .HasMaxLength(50)
                    .HasColumnName("intentionnelle_hi");

                entity.Property(e => e.NPa)
                    .HasMaxLength(50)
                    .HasColumnName("n_pa");

                entity.Property(e => e.NPaHi)
                    .HasMaxLength(50)
                    .HasColumnName("n_pa_hi");

                entity.Property(e => e.NPr)
                    .HasMaxLength(50)
                    .HasColumnName("n_pr");

                entity.Property(e => e.NPrHi)
                    .HasMaxLength(50)
                    .HasColumnName("n_pr_hi");

                entity.Property(e => e.NTe)
                    .HasMaxLength(50)
                    .HasColumnName("n_te");

                entity.Property(e => e.NTeHi)
                    .HasMaxLength(50)
                    .HasColumnName("n_te_hi");

                entity.Property(e => e.Pa)
                    .HasMaxLength(50)
                    .HasColumnName("pa");

                entity.Property(e => e.PaHi)
                    .HasMaxLength(50)
                    .HasColumnName("pa_hi");

                entity.Property(e => e.Te)
                    .HasMaxLength(50)
                    .HasColumnName("te");

                entity.Property(e => e.TeHi)
                    .HasMaxLength(50)
                    .HasColumnName("te_hi");

                entity.Property(e => e.Type)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<FormVerb>(entity =>
            {
                entity.ToTable("FormVerb");

                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Causative)
                    .HasMaxLength(50)
                    .HasColumnName("causative");

                entity.Property(e => e.Conditionnel)
                    .HasMaxLength(50)
                    .HasColumnName("conditionnel");

                entity.Property(e => e.ConditionnelPa)
                    .HasMaxLength(50)
                    .HasColumnName("conditionnel_pa");

                entity.Property(e => e.Conjectural)
                    .HasMaxLength(50)
                    .HasColumnName("conjectural");

                entity.Property(e => e.ConjecturalFor)
                    .HasMaxLength(50)
                    .HasColumnName("conjectural_for");

                entity.Property(e => e.ConjecturalForHi)
                    .HasMaxLength(50)
                    .HasColumnName("conjectural_for_hi");

                entity.Property(e => e.ConjecturalHi)
                    .HasMaxLength(50)
                    .HasColumnName("conjectural_hi");

                entity.Property(e => e.Dan).HasColumnName("dan");

                entity.Property(e => e.ForNPa)
                    .HasMaxLength(50)
                    .HasColumnName("for_n_pa");

                entity.Property(e => e.ForNPaHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_n_pa_hi");

                entity.Property(e => e.ForNPr)
                    .HasMaxLength(50)
                    .HasColumnName("for_n_pr");

                entity.Property(e => e.ForNPrHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_n_pr_hi");

                entity.Property(e => e.ForPa)
                    .HasMaxLength(50)
                    .HasColumnName("for_pa");

                entity.Property(e => e.ForPaHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_pa_hi");

                entity.Property(e => e.ForPassif)
                    .HasMaxLength(50)
                    .HasColumnName("for_passif");

                entity.Property(e => e.ForPassifHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_passif_hi");

                entity.Property(e => e.ForPotentiel)
                    .HasMaxLength(50)
                    .HasColumnName("for_potentiel");

                entity.Property(e => e.ForPotentielHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_potentiel_hi");

                entity.Property(e => e.ForPr)
                    .HasMaxLength(50)
                    .HasColumnName("for_pr");

                entity.Property(e => e.ForPrHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_pr_hi");

                entity.Property(e => e.ForToo)
                    .HasMaxLength(50)
                    .HasColumnName("for_too");

                entity.Property(e => e.ForTooHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_too_hi");

                entity.Property(e => e.ForTooPa)
                    .HasMaxLength(50)
                    .HasColumnName("for_too_pa");

                entity.Property(e => e.ForTooPaHi)
                    .HasMaxLength(50)
                    .HasColumnName("for_too_pa_hi");

                entity.Property(e => e.Imperative)
                    .HasMaxLength(50)
                    .HasColumnName("imperative");

                entity.Property(e => e.ImperativeHi)
                    .HasMaxLength(50)
                    .HasColumnName("imperative_hi");

                entity.Property(e => e.NPa)
                    .HasMaxLength(50)
                    .HasColumnName("n_pa");

                entity.Property(e => e.NPaHi)
                    .HasMaxLength(50)
                    .HasColumnName("n_pa_hi");

                entity.Property(e => e.NPr)
                    .HasMaxLength(50)
                    .HasColumnName("n_pr");

                entity.Property(e => e.NPrHi)
                    .HasMaxLength(50)
                    .HasColumnName("n_pr_hi");

                entity.Property(e => e.Obligation)
                    .HasMaxLength(50)
                    .HasColumnName("obligation");

                entity.Property(e => e.Pa)
                    .HasMaxLength(50)
                    .HasColumnName("pa");

                entity.Property(e => e.PaHi)
                    .HasMaxLength(50)
                    .HasColumnName("pa_hi");

                entity.Property(e => e.Passif)
                    .HasMaxLength(50)
                    .HasColumnName("passif");

                entity.Property(e => e.PassifHi)
                    .HasMaxLength(50)
                    .HasColumnName("passif_hi");

                entity.Property(e => e.Potentiel)
                    .HasMaxLength(50)
                    .HasColumnName("potentiel");

                entity.Property(e => e.PotentielHi)
                    .HasMaxLength(50)
                    .HasColumnName("potentiel_hi");

                entity.Property(e => e.Stem)
                    .HasMaxLength(50)
                    .HasColumnName("stem");

                entity.Property(e => e.StemHi)
                    .HasMaxLength(50)
                    .HasColumnName("stem_hi");

                entity.Property(e => e.Te)
                    .HasMaxLength(50)
                    .HasColumnName("te");

                entity.Property(e => e.TeHi)
                    .HasMaxLength(50)
                    .HasColumnName("te_hi");

                entity.Property(e => e.Volutive)
                    .HasMaxLength(50)
                    .HasColumnName("volutive");
            });

            modelBuilder.Entity<Kanji>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Jlpt).HasColumnName("jlpt");

                entity.Property(e => e.Kanji1)
                    .HasMaxLength(50)
                    .HasColumnName("kanji");

                entity.Property(e => e.Kun)
                    .HasMaxLength(50)
                    .HasColumnName("kun");

                entity.Property(e => e.KunRo)
                    .HasMaxLength(50)
                    .HasColumnName("kun_ro");

                entity.Property(e => e.NbStrikes).HasColumnName("nb_strikes");

                entity.Property(e => e.On)
                    .HasMaxLength(50)
                    .HasColumnName("on");

                entity.Property(e => e.OnKa)
                    .HasMaxLength(50)
                    .HasColumnName("on_ka");

                entity.Property(e => e.OnRo)
                    .HasMaxLength(50)
                    .HasColumnName("on_ro");

                entity.Property(e => e.SKun)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun");

                entity.Property(e => e.SKun2)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun_2");

                entity.Property(e => e.SKun3)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun_3");

                entity.Property(e => e.SKunRo)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun_ro");

                entity.Property(e => e.SKunRo2)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun_ro_2");

                entity.Property(e => e.SKunRo3)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun_ro_3");

                entity.Property(e => e.SOn)
                    .HasMaxLength(50)
                    .HasColumnName("s_on");

                entity.Property(e => e.SOn2)
                    .HasMaxLength(50)
                    .HasColumnName("s_on_2");

                entity.Property(e => e.SOnKa)
                    .HasMaxLength(50)
                    .HasColumnName("s_on_ka");

                entity.Property(e => e.SOnKa2)
                    .HasMaxLength(50)
                    .HasColumnName("s_on_ka_2");

                entity.Property(e => e.SOnRo)
                    .HasMaxLength(50)
                    .HasColumnName("s_on_ro");

                entity.Property(e => e.SOnRo2)
                    .HasMaxLength(50)
                    .HasColumnName("s_on_ro_2");
            });

            modelBuilder.Entity<KanjisFr>(entity =>
            {
                entity.ToTable("KanjisFR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("_id");

                entity.Property(e => e.KunFr)
                    .HasMaxLength(50)
                    .HasColumnName("kun_fr");

                entity.Property(e => e.OnFr)
                    .HasMaxLength(50)
                    .HasColumnName("on_fr");

                entity.Property(e => e.SKunFr)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun_fr");

                entity.Property(e => e.SKunFr2)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun_fr_2");

                entity.Property(e => e.SKunFr3)
                    .HasMaxLength(50)
                    .HasColumnName("s_kun_fr_3");

                entity.Property(e => e.SOnFr)
                    .HasMaxLength(50)
                    .HasColumnName("s_on_fr");

                entity.Property(e => e.SOnFr2)
                    .HasMaxLength(50)
                    .HasColumnName("s_on_fr_2");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.KanjisFr)
                    .HasForeignKey<KanjisFr>(d => d.Id)
                    .HasConstraintName("fk_kanjisfr_kanjis");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("createdDate");

                entity.Property(e => e.EMail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("eMail");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PassWord).HasColumnName("passWord");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("_id");

                entity.Property(e => e.Adj)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("adj");

                entity.Property(e => e.Filters)
                    .HasMaxLength(50)
                    .HasColumnName("filters");

                entity.Property(e => e.JpDefinition)
                    .HasMaxLength(50)
                    .HasColumnName("jp_definition");

                entity.Property(e => e.JpDefinitionRo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("jp_definition_ro");

                entity.Property(e => e.JpHiragana)
                    .HasMaxLength(50)
                    .HasColumnName("jp_hiragana");

                entity.Property(e => e.JpKanji)
                    .HasMaxLength(50)
                    .HasColumnName("jp_kanji");

                entity.Property(e => e.JpKatakana)
                    .HasMaxLength(50)
                    .HasColumnName("jp_katakana");

                entity.Property(e => e.JpRomanji)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("jp_romanji");

                entity.Property(e => e.NbHi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nb_hi");

                entity.Property(e => e.NbRo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nb_ro");

                entity.Property(e => e.Stem)
                    .HasMaxLength(3)
                    .HasColumnName("stem");

                entity.Property(e => e.Tense)
                    .HasMaxLength(50)
                    .HasColumnName("tense");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.Verb).HasColumnName("verb");
            });

            modelBuilder.Entity<WordsFr>(entity =>
            {
                entity.ToTable("WordsFR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("_id");

                entity.Property(e => e.BlueWord)
                    .HasMaxLength(50)
                    .HasColumnName("blue_word");

                entity.Property(e => e.FrDefinition)
                    .HasMaxLength(50)
                    .HasColumnName("fr_definition");

                entity.Property(e => e.FrExplication)
                    .HasMaxLength(50)
                    .HasColumnName("fr_explication");

                entity.Property(e => e.French)
                    .HasMaxLength(50)
                    .HasColumnName("french");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.WordsFr)
                    .HasForeignKey<WordsFr>(d => d.Id)
                    .HasConstraintName("fk_wordsfr_word");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
