using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {

        private readonly MyFinanceDbContext _dbContext;

        public TransacaoService(MyFinanceDbContext dbContext){

            _dbContext = dbContext;

        }
        public void Cadastrar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;

            if (Entidade.Id == null){
                dbSet.Add(Entidade);
            }
            else{
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = Microsoft.EntityFrameworkCore.EntityState.Modfied; 
            }
           
           _dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var PlanoConta = new Transacao (){Id = id};
            _dbContext.Attach(Transacao );
            _dbContext.Remove(Transacao );
            _dbContext.Savechanges();

        }

        public List<Transacao > ListarRegistros()
        {
            var dbSet = _dbContext.Transacao ;
            return dbSet.ToList();
        }

        public Transacao  RetornarRegistro(int id)
        {
            return _dbContext.Transacao.Where(x => x.Id == id).Frist();
    }
}