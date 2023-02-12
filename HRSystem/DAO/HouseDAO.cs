using System;
using HRSystem.Models;
using HRSystem.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace HRSystem.DAO
{
    public class HouseDAO
    {
        private readonly HRDbContext _dbContext;

        public HouseDAO(HRDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<HouseDetail> viewHouseDetail()
        {
            var set = (from Employee in _dbContext.Employees
                       join Person in _dbContext.Persons on Employee.PersonId equals Person.Id
                       join House in _dbContext.Houses on Employee.HouseId equals House.ID
                       select new HouseDetail
                       {
                           HouseAddress = House.Address,
                           PreferredName = Person.Firstname,
                           Phone = Person.CellPhone
                       }).ToList();
            return set;
        }

       
        public List<HouseDetailHR> viewHouseDetailHR()
        {
            var set = (from House in _dbContext.Houses
                       join Contact in _dbContext.Contacts on House.ContactID equals Contact.Id
                       join Person in _dbContext.Persons on Contact.PersonId equals Person.Id
                       select new HouseDetailHR
                       {
                           HouseAddress = House.Address,
                           Landlord = Person.Firstname,
                           Phone = Person.CellPhone,
                           Email = Person.Email,
                           NumberOfEmployee = House.NumberOfPerson
                       }).ToList();
            return set;
        }


        public void addHouse(House house)
        {
            _dbContext.Houses.Add(house);
            _dbContext.SaveChanges();
        }

        public void removeHouse(int id)
        {
            House house = _dbContext.Houses.FirstOrDefault(c => c.ID == id);

            _dbContext.Houses.Remove(house);
            _dbContext.SaveChanges();
        }


        public void sendReport(CreateFacilityReport createFacilityReport, int pid)
        {
            // report：Title + Description
            FacilityReport facilityReport = new FacilityReport();

            facilityReport.Title = createFacilityReport.Title;
            facilityReport.Description = createFacilityReport.Description;
            facilityReport.ReportDate = DateTime.Now;
            facilityReport.STATUS = "Open";


            int eid = (from Employee in _dbContext.Employees
                       join Person in _dbContext.Persons on Employee.PersonId equals Person.Id
                       where Person.Id == pid
                       select Employee.Id).FirstOrDefault();

            facilityReport.EmployeeID = eid;


            _dbContext.FacilityReports.Add(facilityReport);
            _dbContext.SaveChanges();
        }

        //
        public List<FacilityReport> viewReport()
        {
            var result = _dbContext.FacilityReports
                    .Include(d => d.FacilityReportDetails)
                    .ToList();
            return result ;


            //var result = (from FacilityReport in _dbContext.FacilityReports.Include(d => d.FacilityReportDetails)
            //              join Employee in _dbContext.Employees on Employee.ID equals FacilityReport.EmployeeID
            //              join Person in _dbContext.Persons on Person.ID
            //              select new FacilityReportDetail
            //              {
            //                  Comments = FacilityReportDetail.Comments,
            //                  EmployeeID = FacilityReportDetail.EmployeeID,
            //                  LastModificationDate = FacilityReportDetail.LastModificationDate
            //              }).ToList();
            //return result;
        }





        public List<FacilityReport> viewReportById(int pid)
        {
            int eid = (from Employee in _dbContext.Employees
                            join Person in _dbContext.Persons on Employee.PersonId equals Person.Id
                            where Person.Id == pid
                            select Employee.Id).FirstOrDefault();

            var result = _dbContext.FacilityReports
                    .Where(r =>r.EmployeeID == eid)
                    .ToList();

            //var result = _dbContext.FacilityReports
            //        .Include(d => d.FacilityReportDetails)
            //        .Where(r => r.EmployeeID == eid)
            //        .ToList();
            return result;

        }

        public void addComment(CreateFacilityDetail createFacilityDetail)
        {
            FacilityReportDetail facilityReportDetail = new FacilityReportDetail();

            facilityReportDetail.Comments = createFacilityDetail.Comments;
            facilityReportDetail.ReportID = createFacilityDetail.ReportID;
            facilityReportDetail.EmployeeID = createFacilityDetail.EmployeeID;
            facilityReportDetail.CreatedDate = DateTime.Now;
            facilityReportDetail.LastModificationDate = DateTime.Now;



            _dbContext.FacilityReportDetails.Add(facilityReportDetail);
            _dbContext.SaveChanges();
        }


        public List<FacilityReportDetail> getComment()
        {
            return _dbContext.FacilityReportDetails.ToList();
        }


        public void updateComment(CreateFacilityDetail createFacilityDetail)
        {
            FacilityReportDetail facilityReportDetail = getComment().Where(c => c.ID == createFacilityDetail.ID).FirstOrDefault();

            facilityReportDetail.Comments = createFacilityDetail.Comments;
            facilityReportDetail.LastModificationDate = DateTime.Now;

            _dbContext.FacilityReportDetails.Update(facilityReportDetail);
            _dbContext.SaveChanges();
        }


    }
}
