using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Data;
using JobPortalAPI.SP_Models;
using JobPortalAPI.Models;
using JobPortalAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private JobPortalDbContext context;
        public EmployeeRepository(JobPortalDbContext _context)
        {
            context = _context;
        }

        public async Task AddEmployee(Employee employee)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var employeeInfo = new EmployeeInfo
                    {
                        EmployeeName = employee.EmployeeName,
                        CollegeName = employee.CollegeName,
                        Qualification = employee.Qualification,
                        Percentage = employee.Percentage,
                        Speciality = employee.Speciality,
                        TechnologiesStudied = employee.TechnologiesStudied,
                        SoftSkill = employee.SoftSkill,
                        Internship = employee.Internship,
                        Certification = employee.Certification,
                        EmailId = employee.EmailId,
                        PhoneNumber = employee.PhoneNumber,
                        LinkedinUrl = employee.LinkedinUrl,
                        CityId = employee.CityId,
                        OfferLetter = employee.OfferLetter,
                        Experience = employee.Experience,
                    };
                    context.EmployeeInfos.Add(employeeInfo);
                    await context.SaveChangesAsync();

                    var employeeDocument = new EmployeeDocument
                    {
                        GraduationMarksheet = employee.GraduationMarksheet,
                        PassingCertificate = employee.PassingCertificate,
                        AadharCard = employee.AadharCard,
                        PANCard = employee.PANCard,
                        PassportDoc = employee.PassportDoc,
                        IdentityPhoto = employee.IdentityPhoto,
                        Resume = employee.Resume,
                        TenthMarksheet = employee.TenthMarksheet,
                        TwelthMarksheet = employee.TwelthMarksheet,
                    };
                    context.EmployeeDocuments.Add(employeeDocument);
                    await context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }

        public async Task<List<EmployeeInfo>> GetAllEmployee()
        {
            return await context.EmployeeInfos.Include(e => e.EmployeeDocuments).ToListAsync();
        }

        public async Task<EmployeeInfo> GetEmployeeById(int id)
        {
            return await context.EmployeeInfos.Include(e => e.EmployeeDocuments).FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task UpdateEmployee(Employee emp)
        {
            var existingEmployee = await context.EmployeeInfos.Include(e => e.EmployeeDocuments).FirstOrDefaultAsync(e => e.EmployeeId == emp.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = emp.EmployeeName;
                existingEmployee.CollegeName = emp.CollegeName;
                existingEmployee.Qualification = emp.Qualification;
                existingEmployee.Percentage = emp.Percentage;
                existingEmployee.Speciality = emp.Speciality;
                existingEmployee.TechnologiesStudied = emp.TechnologiesStudied;
                existingEmployee.SoftSkill = emp.SoftSkill;
                existingEmployee.Internship = emp.Internship;
                existingEmployee.Certification = emp.Certification;
                existingEmployee.EmailId = emp.EmailId;
                existingEmployee.PhoneNumber = emp.PhoneNumber;
                existingEmployee.LinkedinUrl = emp.LinkedinUrl;
                existingEmployee.CityId = emp.CityId;
                existingEmployee.OfferLetter = emp.OfferLetter;
                existingEmployee.Experience = emp.Experience;
                foreach (var document in existingEmployee.EmployeeDocuments)
                {
                    var existingDocument = existingEmployee.EmployeeDocuments
                        .FirstOrDefault(d => d.EmployeeId == document.EmployeeId);

                    if (existingDocument != null)
                    {
                        existingDocument.GraduationMarksheet = document.GraduationMarksheet;
                        existingDocument.PassingCertificate=document.PassingCertificate;
                        existingDocument.AadharCard=document.AadharCard;
                        existingDocument.PANCard=document.PANCard;
                        existingDocument.PassportDoc=document.PassportDoc;
                        existingDocument.IdentityPhoto=document.IdentityPhoto;
                        existingDocument.Resume=document.Resume;
                        existingDocument.TenthMarksheet=document.TenthMarksheet;
                        existingDocument.TwelthMarksheet=document.TwelthMarksheet;
                    }
                    else
                    {
                        // If document doesn't exist, it may be a new document, so add it
                        existingEmployee.EmployeeDocuments.Add(document);
                    }
                }
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployeeById(int id)
        {
            var empToDelete = await context.EmployeeInfos.Include(e => e.EmployeeDocuments).FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (empToDelete != null)
            {
                context.EmployeeDocuments.RemoveRange(empToDelete.EmployeeDocuments);
                context.EmployeeInfos.Remove(empToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}