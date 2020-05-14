using IrmaApp.Core.Entity;
using IrmaApp.Core.Model.Request;
using IrmaApp.Core.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmaApp.Core.Interface
{
    public interface IReportService
    {
       List<Senzor> GetReportBySenzorName(RequestReport report);
       List<SenzorDTO> GetReportBySenzorNameDTO(List<Senzor> senzori);
       List<ResponseReport> GenerateMeasurementRepot(List<SenzorDTO> senzorDTOs);
    }
}
