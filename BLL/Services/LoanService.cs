using BLL.Entities;
using BLL.Mappers;
using D = DAL.Entities;
using Common.Repositories;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class LoanService : ILoanRepository<Loan>
	{
		private readonly ILoanRepository<D.Loan> _loanRepository;

		public LoanService(ILoanRepository<D.Loan> loanRepository)
		{
			_loanRepository = loanRepository;
		}

		// Récupérer tous les emprunts
		public IEnumerable<Loan> Get()
		{
			return _loanRepository.Get().Select(dal => dal.ToBLL());
		}

		// Récupérer un emprunt par son identifiant
		public Loan Get(int loanId)
		{
			var loan = _loanRepository.Get(loanId)?.ToBLL();
			return loan;
		}

		// Récupérer tous les jeux (y compris ceux désactivés)
		public IEnumerable<Loan> GetAll()
		{
			return _loanRepository.GetAll().Select(dal => dal.ToBLL());
		}

		// Récupérer les jeux actifs (non désactivés)
		public IEnumerable<Loan> GetAllActive()
		{
			return _loanRepository.GetAllActive().Select(dal => dal.ToBLL());
		}

		// Ajouter un emprunt
		public int Insert(Loan loan)
		{
			return _loanRepository.Insert(loan.ToDAL());
		}

		// Mettre à jour un emprunt
		public void Update(int loanId, Loan loan)
		{
			_loanRepository.Update(loanId, loan.ToDAL());
		}

		// Supprimer un emprunt
		public void Delete(int loanId)
		{
			_loanRepository.Delete(loanId);
		}

		/*
		// Récupérer tous les emprunts par un emprunteur
		public IEnumerable<Loan> GetByEmprunteur(int emprunteurId)
		{
			return _loanRepository.GetByEmprunteur(emprunteurId).Select(dal => dal.ToBLL());
		}

		// Récupérer tous les emprunts par un prêteur
		public IEnumerable<Loan> GetByPreteur(int preteurId)
		{
			return _loanRepository.GetByPreteur(preteurId).Select(dal => dal.ToBLL());
		}
		*/
	}
}