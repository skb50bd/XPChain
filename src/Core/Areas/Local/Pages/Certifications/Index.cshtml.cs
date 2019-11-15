using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Core.Areas.Local.Pages.Certifications
{
    public class IndexModel : PageModel
    {
        private readonly INodeRepository _repository;
        public IndexModel(INodeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LocalCertificate> LocalCertificates { get; set; }

        public void OnGet()
        {
            LocalCertificates = _repository.GetAll<LocalCertificate>();
        }
    }
}