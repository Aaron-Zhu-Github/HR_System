using System;
using HRSystem.Models;
using HRSystem.DTO;
using Microsoft.AspNetCore.Mvc;

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


        public void sendReport(CreateFacilityReport createFacilityReport)
        {
            // report：Title + Description
            FacilityReport facilityReport = new FacilityReport();

            facilityReport.Title = createFacilityReport.Title;
            facilityReport.Description = createFacilityReport.Description;
            facilityReport.ReportDate = DateTime.Now;

            _dbContext.FacilityReports.Add(facilityReport);
            _dbContext.SaveChanges();
        }

        //Error:Invalid column name 'FacilityReportID'
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


        public void updateComment(FacilityReportDetail facilityReportDetail)
        {

            _dbContext.FacilityReportDetails.Update(facilityReportDetail);
            _dbContext.SaveChanges();
        }
    }
}
