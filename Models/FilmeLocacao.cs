
namespace Models {
    public class FilmeLocacao {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }
        public int LocacaoId { get; set; }
        public virtual Locacao Locacao { get; set; }
    }
}
