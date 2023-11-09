using Dapper;
using INSN.Web.DataAccess;
using INSN.Web.Entities.DocumentoLegal;
using INSN.Web.Repositories.Interfaces.Home;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace INSN.Web.Repositories.Implementaciones.Home
{
    /// <summary>
    /// Metodos de Documento Legal 
    /// </summary>
    public class DocumentoLegalRepository : RepositoryBase<DocumentoLegal>, IDocumentoLegalRepository
    {
        public DocumentoLegalRepository(INSNWebDBContext context) : base(context)
        {
        }

        //public async Task<ICollection<DocumentoLegal>> ListAsync(string? Documento)
        //{
        //    #region Dapper

        //    var query = await Context.Database.GetDbConnection().QueryAsync<DocumentoLegal>("SP_Documento_Legal_SEL",
        //        commandType: CommandType.StoredProcedure,
        //        param: new
        //        {
        //            Documento = Documento

        //        });

        //    return query.ToList();
        //    #endregion
        //}

        public async Task<ICollection<DocumentoLegal>> ListarDocumentoLegalesAsync(string Documento, int TipoDocumentoId, string Estado, int Page, int Rows)
        {
            var connection = Context.Database.GetDbConnection();

            var query = await connection.QueryAsync<DocumentoLegal>("SP_Documento_Legal_SEL", commandType: System.Data.CommandType.StoredProcedure, param: new
            {
                Documento = Documento,
                TipoDocumentoId = TipoDocumentoId,
                Estado = Estado,
                Page = (Page - 1) * Rows,
                Rows = Rows
            });

            return query.ToList();
        }
    }
}
