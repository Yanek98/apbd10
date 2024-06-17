using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IPrescriptionService
{
    public Task<PrescDTO> AddPrescription([FromBody] PrescDTO prescDto);
    public void setConfig(IConfiguration configuration);
}