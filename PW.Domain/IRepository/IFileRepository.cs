using _01_Framework.Domain;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.Models;
using System.Collections.Generic;

namespace PW.Domain.IRepository
{
    public interface IFileRepository : IRepository<long, Files>
    {
        public FileViewModel GetDetails(long Id);
        List<FileViewModel> Search(FileViewModel command = null);
        List<FileViewModel> GetbyType(int Id);
    }
}
