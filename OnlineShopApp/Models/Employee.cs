using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class Employee : PropertyChange
{
    public int IdEmployee { get; set; }

    private string? nameEmployee;
    public string? NameEmployee 
    { 
        get { return nameEmployee; }
        set
        {
            nameEmployee = value;
            OnPropertyChanged(nameof(NameEmployee));
        }
    }

    private string? familyEmployee;
    public string? FamilyEmployee 
    { 
        get { return familyEmployee; }
        set
        {
            familyEmployee = value;
            OnPropertyChanged(nameof(FamilyEmployee));
        }
    }

    private string? emailEmployee;
    public string? EmailEmployee 
    { 
        get {  return emailEmployee; }
        set
        {
            emailEmployee = value;
            OnPropertyChanged(nameof(EmailEmployee));
        }
    }

    private string? passwordEmployee;
    public string? PasswordEmployee 
    { 
        get {  return passwordEmployee; }
        set
        {
            passwordEmployee = value;
            OnPropertyChanged(nameof(PasswordEmployee));
        }
    }

    private int? salaryEmployee;
    public int? SalaryEmployee
    {
        get { return salaryEmployee; }
        set
        {
            salaryEmployee = value;
            OnPropertyChanged(nameof(SalaryEmployee));
        }
    }

    private int? idStore;
    public int? IdStore 
    { 
        get { return idStore; }
        set
        {
            idStore = value;
            OnPropertyChanged(nameof(IdStore));
        }
    }


    public virtual Store? IdStoreNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set;} = new List<Order>();

    public string Name { get { return FamilyEmployee + ' ' + NameEmployee; } }

    [NotMapped]
    private bool isEditName;
    [NotMapped]
    public bool IsEditName
    {
        get { return isEditName; }
        set
        {
            isEditName = value;
            OnPropertyChanged(nameof(IsEditName));
        }
    }

    [NotMapped]
    private bool isEditFamily;
    [NotMapped]
    public bool IsEditFamily
    {
        get { return isEditFamily; }
        set
        {
            isEditFamily = value;
            OnPropertyChanged(nameof(IsEditFamily));
        }
    }

    [NotMapped]
    private bool isEditEmail;
    [NotMapped]
    public bool IsEditEmail
    {
        get { return isEditEmail; }
        set
        {
            isEditEmail = value;
            OnPropertyChanged(nameof(IsEditEmail));
        }
    }

    [NotMapped]
    private bool isEditPassword;
    [NotMapped]
    public bool IsEditPassword
    {
        get { return isEditPassword; }
        set
        {
            isEditPassword = value;
            OnPropertyChanged(nameof(IsEditPassword));
        }
    }

    [NotMapped]
    private bool isEditSalary;
    [NotMapped]
    public bool IsEditSalary
    {
        get { return isEditSalary; }
        set
        {
            isEditSalary = value;
            OnPropertyChanged(nameof(IsEditSalary));
        }
    }
}
