using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiceStation.Models
{
    #region ClientCardViewModel
    public class ClientCardViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "MM.DD.YYYY")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm.dd.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //public IEnumerable<RelatedCars> ClientCars { get; set; }
        //public IEnumerable<Orders> ClientOrder { get; set; }
    }
    #endregion

    #region ClientListViewModel
    public class ClientListViewModel
    {
        public IEnumerable<ClientCard> ClientCards { get; set; }
        public ListView PagingView { get; set; }
    }
    #endregion

    #region Birth Date
    public class BirthDate
    {
        public int BirthDateDay;

        public IEnumerable<SelectListItem> BirthDateDaySelectList
        {
            get
            {
                for (int i = 1; i < 32; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthDateDay == i
                    };
                }
            }
        }

        public int BirthDateMonth;

        public IEnumerable<SelectListItem> BirthDateMonthSelectList
        {
            get
            {
                for (int i = 1; i < 13; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = new DateTime(2000, i, 1).ToString("MMMM"),
                        Selected = BirthDateMonth == i
                    };
                }
            }
        }

        public int BirthDateYear;

        public IEnumerable<SelectListItem> BirthDateYearSelectList
        {
            get
            {
                for (int i = 1; i < DateTime.Now.Year; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = BirthDateYear == i
                    };
                }
            }
        }


    }
    #endregion

    #region
    public class CheckClientViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
    #endregion
}