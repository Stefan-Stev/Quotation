using Microsoft.AspNetCore.JsonPatch;
using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuotationsWebApi.Repository
{
    public interface IDossierRepository
    {
        Task CreateDossier(Dossier dossier);
        Task DeleteDossier(Guid id);
        Task<List<Dossier>> GetAllDossier();
        Task<Dossier> GetDossierById(Guid id);
        Task<Dossier> Patch(Guid id, JsonPatchDocument<Dossier> dossier);
        Task Update(Dossier dossier);
        bool DossierExists(Guid id);
    }
}