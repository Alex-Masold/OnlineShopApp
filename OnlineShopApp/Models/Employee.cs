﻿using OnlineShop.Models.Base;
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


}
