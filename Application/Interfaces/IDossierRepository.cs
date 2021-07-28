using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuotationsWebApi.Repository
{
    public interface IDossierRepository
    {
        Task CreateDossier(Dossier dossier);
        Task DeleteDossier(Dossier dossier);
        Task<List<Dossier>> GetAllDossier();
        Task<Dossier> GetDossierById(Guid id);
        Task<Dossier> Patch(Guid id, JsonPatchDocument<Dossier> dossier);
        Task<Dossier> Update(Dossier dossier);
        bool DossierExists(Guid id);
    }
}