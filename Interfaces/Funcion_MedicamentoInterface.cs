using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface Funcion_MedicamentoInterface
    {
        public Response GetFuncione_Medicamento();

        public Response ShowFuncion_Medicamento(int Id);

        public Task<Response> CreateFuncion_Medicamento(Funcion_medicamento _funcion_Medicamento);

        public Task<Response> UpdateFuncion_Medicamento(int id, Funcion_medicamento _funcion_Medicamento);

        public Response GeFunciones_MedicamentoActivas(int estado_Id);
    }
}
